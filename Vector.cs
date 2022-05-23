using UnityEngine;

namespace Hex {
    ///<summary>
    /// Vector Hex is a int vector3 like struct that contain hexagon coordinates,
    /// it also provides methods to deal with those coordinates and some shorthand readonly values
    /// </summary>
    public struct Vector {
        //x, y, z values
        public readonly int x, y, z;

        ///<summary>
        /// Builds vector from xyz cube coordinates
        /// </summary>
        public Vector(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        /// <summary>
        /// Builds a vector from a xy axial coordinates
        /// </summary>
        public Vector(int x, int y) {
            this.x = x;
            this.y = y;
            z = -x - y;
        }

        public static readonly Vector XPos = new Vector(0, 1, -1);
        public static readonly Vector XNeg = new Vector(0, -1, 1);
        public static readonly Vector YPos = new Vector(1, 0, -1);
        public static readonly Vector YNeg = new Vector(-1, 0, 1);
        public static readonly Vector ZPos = new Vector(1, -1, 0);
        public static readonly Vector ZNeg = new Vector(-1, 1, 0);

        /// <summary>
        /// shorthand for 3 squared;
        /// </summary>
        public static readonly float RootOf3 = Mathf.Sqrt(3f);

        ///<summary>
        /// Returns a physical position of a given hexagon inside this container
        /// </summary>
        public Vector3 Position(float scale = 1f, float height = 0f) =>
            new Vector3(
                scale * (RootOf3 * x + RootOf3 / 2f * y),
                height,
                scale * (3f / 2f * y));

        /// <summary>
        /// Calculate the distance between two hexagons
        /// </summary>
        public int Distance(Vector target) =>
            (System.Math.Abs(x - target.x) + System.Math.Abs(y - target.y) + System.Math.Abs(z - target.z)) / 2;

        /// <summary>
        /// Verify if the given hexagon is legal
        /// </summary>
        public bool IsLegal => x + y + z == 0;

        /// <summary>
        /// Convert Hex.vector to world position
        /// </summary>
        public static implicit operator Vector3(Vector v) => v.Position();

        /// <summary>
        /// throw exception if the hexagon is illegal
        /// </summary>
        public Vector Validate() {
            if (!IsLegal) {
#if(UNITY_EDITOR)
                throw new System.Exception("Illegal " + ToString() + " vector is not allowed");
#else
                return Fix();
#endif
            }
            return this;
        }

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

        public static Vector operator *(Vector v, int scalar) => new Vector(v.x * scalar, v.y * scalar, v.z * scalar);

        public static Vector operator /(Vector v, int scalar) => new Vector(v.x / scalar, v.y / scalar, v.z / scalar);

        public override string ToString() => "Hex - X." + x + " Y." + y + " Z." + z;

        ///<summary>
        /// Rounds a float Hex vector into a legal int hex vector
        /// </summary>
        public static Vector Round(Vector3 vector) {
            int roundX = Mathf.RoundToInt(vector.x),
                roundY = Mathf.RoundToInt(vector.y),
                roundZ = Mathf.RoundToInt(vector.z);
            float diffX = Mathf.Abs(roundX - vector.x),
                  diffY = Mathf.Abs(roundY - vector.x),
                  diffZ = Mathf.Abs(roundZ - vector.x);
            if (diffX > diffY && diffX > diffZ)
                roundX = -roundY - roundZ;
            else if (diffY > diffZ)
                roundY = -roundX - roundZ;
            else
                roundZ = -roundX - roundY;
            return new Vector(roundX, roundY, roundZ);
        }

        /// <summary>
        /// return a legal vector from a given vector
        /// </summary>
        public Vector Fix() =>
            IsLegal ? this : new Vector(
                Mathf.RoundToInt((x + x - y - z) / 3f),
                Mathf.RoundToInt((y + y - x - z) / 3f));
    }

    public static class Vector3Extension {
        ///<summary>
        /// Returns a hexagon ID from a x and z coordinate position
        ///</summary>
        public static Vector WorldPositionToHexVector(this Vector3 position, float scale = 1f) {
            float ix = (Vector.RootOf3 / 3f * position.x - 1f / 3f * position.z) / scale;
            float iy = (2f / 3f * position.z) / scale;
            return Vector.Round(new Vector3(ix, iy, -ix - iy));
        }
    }
}