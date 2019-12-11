using UnityEngine;
///<summary>Vector Hex is a int vector3 like struct that contain hexagon coordinates, it also provides methods to deal with those coordinates and some shorthand readonly values</summary>
namespace Hex{
    public struct Vector{
        //x, y, z values
        public int x, y, z;

        ///<summary>Builds vector from xyz coordinates</summary>
        public Vector(int x, int y, int z) {
            this.x = x;
            this.y = y;
            this.z = z;

        }
        public Vector(int x, int y) {
            this.x = x;
            this.y = y;
            this.z = -x -y;
        }

        public static readonly Vector XPos = new Vector( 0,  1, -1);
        public static readonly Vector XNeg = new Vector( 0, -1,  1);
        
        public static readonly Vector YPos = new Vector( 1,  0, -1);
        public static readonly Vector YNeg = new Vector(-1,  0,  1);
        
        public static readonly Vector ZPos = new Vector( 1, -1,  0);
        public static readonly Vector ZNeg = new Vector(-1,  1,  0);
        
        public int Distance(Vector target) {
            return ( System.Math.Abs(x - target.x) + System.Math.Abs(y - target.y) + System.Math.Abs(z - target.z) ) / 2;
        }

        public bool IsLegal { get { return x + y + z == 0; }  }

        public static implicit operator Vector3(Vector o){
            return new Vector3((float)o.x, 0f, (float)o.y);
        }

        public void Validate() {
            #if(UNITY_EDITOR)
                if(x + y + z != 0)
                    throw new System.Exception("Illegal vector initialized");
            #endif
        }
        public static Vector operator +(Vector num1, Vector num2){
            return new Vector(
                num1.x + num2.x, 
                num1.y + num2.y, 
                num1.z + num2.z
            );
        }
        public static Vector operator -(Vector num1, Vector num2){
            return new Vector(
                num1.x - num2.x, 
                num1.y - num2.y, 
                num1.z - num2.z
            );
        }
        public static Vector operator *(Vector num, int scalar){
            return new Vector(
                num.x * scalar, 
                num.y * scalar, 
                num.z * scalar
            );
        }
        public static Vector operator /(Vector num, int scalar){
            return new Vector(
                num.x / scalar, 
                num.y / scalar, 
                num.z / scalar
            );
        }
        public override string  ToString(){
            return "Hex - X." + x + " Y." + y + " Z." + z;
        }

        ///<summary>Rounds a float Hex vector into a int hex vector
        public static Vector Round(Vector3 vector){
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
                rounded.x = -rounded.y -rounded.z;
            else if (diff.y > diff.z)
                rounded.y = -rounded.x -rounded.z;
            else
                rounded.z = -rounded.x -rounded.y;
            return rounded;
        }
    }
}