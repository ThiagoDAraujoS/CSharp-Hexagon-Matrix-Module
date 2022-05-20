using UnityEngine;

namespace Hex {
    ///<summary>
    /// Vector Hex is a int vector3 like struct that contain hexagon coordinates,
    /// it also provides methods to deal with those coordinates and some shorthand readonly values
    /// </summary>
    public struct Vector {
        //x, y, z values
        public int x, y, z;

        ///<summary>
        /// Builds vector from xyz coordinates
        /// </summary>
        public Vector(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;
        }

        public Vector(int x, int y) {
            this.x = x;
            this.y = y;
            this.z = -x - y;
        }

        public static readonly Vector XPos = new Vector(0, 1, -1);
        public static readonly Vector XNeg = new Vector(0, -1, 1);

        public static readonly Vector YPos = new Vector(1, 0, -1);
        public static readonly Vector YNeg = new Vector(-1, 0, 1);

        public static readonly Vector ZPos = new Vector(1, -1, 0);
        public static readonly Vector ZNeg = new Vector(-1, 1, 0);

        public static readonly float SqrOf3 = Mathf.Sqrt(3f);

        ///<summary>
        /// Returns a physical position of a given hexagon inside this container
        /// </summary>
        public Vector3 Position(float size, float height = 0f) =>
            new Vector3(
                size * (SqrOf3 * (float) x + SqrOf3 / 2f * (float) y),
                height,
                size * (3f / 2f * y));

        public int Distance(Vector target) =>
            (System.Math.Abs(x - target.x) + System.Math.Abs(y - target.y) + System.Math.Abs(z - target.z)) / 2;

        public bool IsLegal => x + y + z == 0;

        public static implicit operator Vector3(Vector v) => v.Position(1f);

        public void Validate() {
#if(UNITY_EDITOR)
            if (!IsLegal)
                throw new System.Exception("Illegal vector initialized");
#endif
        }

        public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);

        public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);

        public static Vector operator *(Vector v, int scalar) => new Vector(v.x * scalar, v.y * scalar, v.z * scalar);

        public static Vector operator /(Vector v, int scalar) => new Vector(v.x / scalar, v.y / scalar, v.z / scalar);

        public override string ToString() => "Hex - X." + x + " Y." + y + " Z." + z;

        ///<summary>
        /// Rounds a float Hex vector into a int hex vector
        /// </summary>
        public static Vector Round(Vector3 vector) {
            Vector rounded = new Vector(
                Mathf.RoundToInt(vector.x),
                Mathf.RoundToInt(vector.y),
                Mathf.RoundToInt(vector.z)
            );
            Vector3 diff = new Vector3(
                Mathf.Abs(rounded.x - vector.x),
                Mathf.Abs(rounded.y - vector.y),
                Mathf.Abs(rounded.z - vector.z)
            );
            if (diff.x > diff.y && diff.x > diff.z)
                rounded.x = -rounded.y - rounded.z;
            else if (diff.y > diff.z)
                rounded.y = -rounded.x - rounded.z;
            else
                rounded.z = -rounded.x - rounded.y;
            return rounded;
        }
    }

    public static class Vector3Extension {
        ///<summary>
        /// Returns a hexagon ID from a x and z coordinate position
        ///</summary>
        public static Vector PointToHexVector(this Vector3 point, float size = 1f) {
            float ix = (Vector.SqrOf3 / 3f * point.x - 1f / 3f * point.z) / size;
            float iy = (2f / 3f * point.z) / size;
            return Vector.Round(new Vector3(ix, iy, -ix - iy));
        }
    }
}