using System;
public class HexMatrix<T>
{
    private T[] data;

    private int length;

    private int MapHexInto1DArray(int x, int y) {
        return length * y + x + y / 2;
    }

    private VectorHex Project1DArrayIntoHex(int i) {
        int y = i / length;
        int x = i % length - y / 2;
        return new VectorHex(x, y,-x -y);
    }

    public T this[int x, int y, int z = 0] {
        get {   return data[MapHexInto1DArray(x, y)];}
        set {   data[MapHexInto1DArray(x, y)] = value;}
    }

    public T this[VectorHex i] {
        get{    return this[i.x, i.y]; }
        set{    this[i.x, i.y] = value; }
    }

    public HexMatrix(int length, int height) {
        this.length = length;
        data = new T[length * height];
    }

    public delegate void ForeachOperation(VectorHex index, ref T item);
    
    public void Foreach (ForeachOperation action) {
        for (int i = 0; i < data.Length; i++)
            action(Project1DArrayIntoHex(i), ref data[i]);
    }
    
}
