﻿using System;

///<summary>Vector Hex is a int vector3 like struct that contain hexagon coordinates, it also provides methods to deal with those coordinates and some shorthand readonly values</summary>
public struct VectorHex{
    //x, y, z values
    public int x, y, z;

    ///<summary>Builds vector from xyz coordinates</summary>
    public VectorHex(int x, int y, int z) {
        this.x = x;
        this.y = y;
        this.z = z;

    }
    public VectorHex(int x, int y) {
        this.x = x;
        this.y = y;
        this.z = -x -y;
    }
    
    public static readonly VectorHex XPos = new VectorHex( 0,  1, -1);
    public static readonly VectorHex XNeg = new VectorHex( 0, -1,  1);
    
    public static readonly VectorHex YPos = new VectorHex( 1,  0, -1);
    public static readonly VectorHex YNeg = new VectorHex(-1,  0,  1);
    
    public static readonly VectorHex ZPos = new VectorHex( 1, -1,  0);
    public static readonly VectorHex ZNeg = new VectorHex(-1,  1,  0);
    
    public int Distance(VectorHex target) {
        return ( Math.Abs(x - target.x) + Math.Abs(y - target.y) + Math.Abs(z - target.z) ) / 2;
    }


    public bool IsLegal { get => x + y + z == 0;  }

    public void Validate() {
        #if(UNITY_EDITOR)
            if(x + y + z != 0)
                throw new Exception("Ilegal vector initialized");
        #endif
    }
    public static VectorHex operator +(VectorHex num1, VectorHex num2){
        return new VectorHex(
            num1.x + num2.x, 
            num1.y + num2.y, 
            num1.z + num2.z
        );
    }
    public static VectorHex operator -(VectorHex num1, VectorHex num2){
        return new VectorHex(
            num1.x - num2.x, 
            num1.y - num2.y, 
            num1.z - num2.z
        );
    }
    public static VectorHex operator *(VectorHex num, int scalar){
        return new VectorHex(
            num.x * scalar, 
            num.y * scalar, 
            num.z * scalar
        );
    }
    public static VectorHex operator /(VectorHex num, int scalar){
        return new VectorHex(
            num.x / scalar, 
            num.y / scalar, 
            num.z / scalar
        );
    }
}
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
