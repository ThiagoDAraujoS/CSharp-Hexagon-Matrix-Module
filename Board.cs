using UnityEngine;
namespace Hex{
    ///<summary>  The board like the matrix offers an Hexagon matrix's interface to a 1D array, but differently it also has a "physical" hexagon size, and means to find the position of those hexagons in the world</summary>
    public class Board<T> : Matrix<T>
    {
        ///<summary> The physical size of each hexagon </summary>
        private float size;

        private static readonly float sqrOf3 = Mathf.Sqrt(3f);

        ///<summary> Builds a Board container </summary>
        public Board(int length, int height, float size) : base(length, height) {
            this.size = size;
        }

        ///<summary> Returns a physical position of a given hexagon inside this container </summary>
        public Vector3 Position(Vector index, float height = 0f){  
            return new Vector3 (
                size * (sqrOf3 * (float)index.x + sqrOf3/2f * (float)index.y), 
                height, 
                size * (3f/2f * index.y));  
        }
        ///<summary> Returns a hexagon ID from a x and z coordinate position</summary>
        public Vector PointToIndex(Vector3 point){
            float Ix = (sqrOf3/3f * point.x - 1f/3f * point.z)/size;
            float Iy = (2f/3f * point.z)/size;   
            return Vector.Round(new Vector3(Ix, Iy, -Ix-Iy));
        }
    }
}