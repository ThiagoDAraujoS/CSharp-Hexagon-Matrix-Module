using System;
using System.Collections;

namespace Hex{
    ///<summary> The Matrix is the Main data container in this module, it offers an Hexagon matrix's interface to a 1D array </summary>
    public class Matrix<T> : System.Collections.Generic.IEnumerator<T>
    {
        ///<summary>The data saved inside this container </summary>
        protected T[] data;

        ///<summary> The size of the data inside this container </summary>
        protected int length;

        ///<summary> An iterator used by the IEnumerator </summary>
        private int iterator = 0;

        ///<summary> The current element pointed by the IEnumerator </summary>
        public T Current => data[iterator];

        ///<summary> The current element pointed by the IEnumerator </summary>
        object IEnumerator.Current => Current;

        ///<summary> This maps an axial coordinate system into a 1D index, its used to access the data array containing the Hex's info </summary>
        public int MapHexInto1DArray(int x, int y) {
            return length * y + x + y / 2;
        }

        public bool IsOutOfArrayBounds(int index){
            return index < 0 || index >= data.Length;
        }
        public bool IsOutOfBounds(Vector index){
            return (index.x < -index.y/2 || index.x >= length -index.y/2) || IsOutOfArrayBounds(MapHexInto1DArray(index.x, index.y));
        }

        ///<summary> project a index into a 3D Hexagon Vector </summary>
        public Vector Project1DArrayIntoHex(int i) {
            int y = i / length;
            int x = i % length - y / 2;
            return new Vector(x, y,-x -y);
        }

        ///<summary> an indexer using cube coordinates to a hexagon </summary>
        public T this[int x, int y, int z = 0] {
            get {   return data[MapHexInto1DArray(x, y)];}
            set {   data[MapHexInto1DArray(x, y)] = value;}
        }

        ///<summary> an indexer using 1D index to get a hexagon </summary>
        public T this[Vector i] {
            get{    return this[i.x, i.y]; }
            set{    this[i.x, i.y] = value; }
        }

        ///<summary> Builds a hexagon Matrix using a length and height values </summary>
        public Matrix(int length, int height) {
            this.length = length;
            data = new T[length * height];
        }

        public delegate void ExplicitForeachOperationDelegate(Vector index, ref T item);
        
        ///<summary> foraches all hexagons using the "Explicit Foreach Operation Delegate" for each iteration (like LINQ does) </summary>
        public void Foreach (ExplicitForeachOperationDelegate action) {
            for (int i = 0; i < data.Length; i++)
                action(Project1DArrayIntoHex(i), ref data[i]);
        }
        ///<summary> IEnumerator's move next method </summary>
        public bool MoveNext() {
            iterator++;
            return (iterator < data.Length);
        }
        ///<summary> IEnumerator's Reset Method </summary>
        public void Reset() { iterator = 0; }

        ///<summary> IEnumerator's Dispose </summary>
        public void Dispose(){ }
    }
}
