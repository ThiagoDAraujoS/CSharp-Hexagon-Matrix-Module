using UnityEngine;
namespace Hex{
    
    public class Board<T> : Matrix<T>
    {
        private float size;

        private static readonly float sqrOf3 = Mathf.Sqrt(3f);
        private static readonly Vector3 r = new Vector3(sqrOf3, 0f, 3f) * 0.5f;
        private static readonly Vector3 q = new Vector3(sqrOf3, 0f, 0f);

        public Board(int length, int height, float size) : base(length, height) {
            this.size = size;
        }
        public Vector3 Position(Vector index, float height = 0f){  
            return new Vector3 (
                size * (sqrOf3 * (float)index.x + sqrOf3/2f * (float)index.y), 
                height, 
                size * (3f/2f * index.y));  
        }
        public Vector PointToIndex(Vector3 point){
            float Ix = (sqrOf3/3f * point.x - 1f/3f * point.z)/size;
            float Iy = (2f/3f * point.z)/size;   
            return  Vector.Round(new Vector3(Ix, Iy, -Ix-Iy));
        }
    }
}