<style>
h3, h2, ul, ol{
  margin: 0 0 5px;
}
</style>
# Description:
Here there will be a description

# Index:
- ### public struct [Hex.Vector](#public-struct-hexvector-1)
  - **[Static Unit Vectors](#static-unit-vectors)**
  - **[Constructors](#constructors)**
  - **[Operators](#operators)**
  - **Public Methods**
    - public _Vector3_ **[Position](#public-vector3-position-float-size--1f-float-height--0f)**
    - public _int_ **[Distance](#public-int-distance-hexvector-target)**
    - public static _Hex.Vector_ **[Round](#public-static-hexvector-round-vector3-vector)**
  - **Public Extensions**
    - public static _Hex.Vector_ **[PointToHexVector](#public-static-hexvector-pointtohexvector-float-size--1f)**
- ### public abstract class [Hex.Matrix\<T>](#public-abstract-class-hexmatrixt--ienumerablet) : IEnumerable<T>
  - **[Generic Data](#generic-data)**
  - **[Indexers](#indexers)**
  - **[Constructor](#constructor)**
  - **Public Methods**
    - public _bool_ **[IsOutOfArrayBounds](#public-bool-isoutofarraybounds)**
    - public _void_ **[Foreach](#public-void-foreach)**
  - **Abstract Methods**
    - public abstract _Hex.Vector_ **[Project1DArrayIntoHex](#public-abstract-hexvector-project1darrayintohex)**
    - protected abstract _int_ **[MapHexInto1DArray](#protected-abstract-int-maphexinto1darray)**
    - protected abstract _bool_ **[IsOutOfBounds](#protected-abstract-bool-isoutofbounds)**
- ### public class [Hex.Square\<T>](#public-class-hexsquaret--hexmatrixt-1) : [Hex.Matrix\<T>](#public-abstract-class-hexmatrixt--ienumerablet)
  - **[Properties](#properties)**
  - **[Constructors](#constructors-1)**
  - **Override Methods**
    - public override _Hex.Vector_ **[Project1DArrayIntoHex](#public-override-hexvector-project1darrayintohex)**
    - protected override _int_ **[MapHexInto1DArray](#protected-override-int-maphexinto1darray)**
    - protected override _bool_ **[IsOutOfBounds](#protected-override-bool-isoutofbounds)**


___


<style>
h3, h2, ul, ol{
  margin: 0 0 20px;
}
</style>













# public struct Hex.Vector
## Description
Hex.Vector is a immutable struct that represents a 3d vector in the hexagonal cube space.
It can be used to represent a position in a hexagonal grid. 
And it contains a set of public X, Y and Z integers as properties.

Hex.Vectors are considered illegal if the sum of their values dont
equate to 0.

___

## Members
## Static Unit Vectors
### Description
The static unit vectors a set of six readonly vectors used to represent the six directions of the hexagonal cube space.
They are used to manipulate the hex.vector in the hexagonal cube space.
~~~ c#
public static readonly Hex.Vector XPos;
public static readonly Hex.Vector XNeg;
public static readonly Hex.Vector YPos;
public static readonly Hex.Vector YNeg;
public static readonly Hex.Vector ZPos;
public static readonly Hex.Vector ZNeg;
~~~
### Example
~~~ c#
//Create a new hex.vector
Hex.Vector v = new Hex.Vector(0, 0);

//Move the vector 1 into the x direction
v += Hex.Vector.XPos;

//Move the vector 3 hexes into the -y direction
v += Hex.Vector.YNeg * 3;
~~~

___

## Constructors
### Description
Hex.Vector has a constructor that takes x and y coordinate as parameters.
the third parameter is inferred from the x and y values.
Since some coordinates could be illegal,
its not recommended to use the constructor with the third parameter.
~~~ c#
public Vector(int x, int y);
public Vector(int x, int y, int z);
~~~
### Example
~~~ c#
//Create a new hex.vector
Hex.Vector v = new Hex.Vector(0, 0);

//This will generate a illegal vector
Hex.vector v2 = new Hex.Vector(1, 2, 3);
debug.log(v2.IsLegal); //false
~~~

___

## Operators
### Description
Hex.Vectors behaves like a vector in the mathematical sense.
They have a set of operators that can be used to manipulate them.
~~~ c#
public static Vector operator +(Vector v1, Vector v2);
public static Vector operator -(Vector v1, Vector v2);
public static Vector operator *(Vector v, int scalar);
public static Vector operator /(Vector v, int scalar);
~~~
### Example
~~~ c#
Hex.Vector v = new Hex.Vector(1, 2) + new Hex.Vector(3, 4); //v = (4, 6, -10)
~~~

___

## public _Vector3_ Position (float size = 1f, float height = 0f)
### Description
Returns a position in the 3d space represented by the hex.vector.
The size and height parameters are used to scale the vector.
Hex.Vector will be implicitly casted into Vector3 using the Position() function 
~~~ c#
public static implicit operator Vector3(Hex.Vector v);
public Vector3 Position (float size = 1f, float height = 0f)
~~~
### Example
~~~ c#
transform.position = new Hex.Vector(2, 3).Position();
transform.position = new Hex.Vector(2, 3);
~~~

___

## public _int_ Distance (Hex.Vector target)
### Description
Return the distance in hexagons between the vector and the target.
### Example
~~~ c#
Hex.Vector v = new Hex.Vector(1, 2);
Hex.Vector v2 = new Hex.Vector(3, -4);
int distance = v.Distance(v2);
~~~

___

## public static _Hex.Vector_ Round (Vector3 vector)
### Description
Rounds the Vector3 to the nearest legal Hex.Vector.
### Example
~~~ c#
Hex.Vector v = Hex.Vector.Round(transform.position);
~~~

___

## Public Extensions

## public static _Hex.Vector_ PointToHexVector (float size = 1f)
### Description
Extends the Vector3 class to convert a point in the 3d space to a Hex.Vector.
The size parameter is used to scale the Vector3.
### Example
~~~ c#
Hex.Vector v = transform.position.PointToHexVector();
~~~

___














# public abstract class Hex.Matrix\<T> : IEnumerable\<T>
## Description


___

## Members
## Generic Data
### Description
### Example
~~~ c#
~~~

___

## Indexers
### Description
### Example
~~~ c#
~~~

___

## Constructor
### Description
### Example
~~~ c#
~~~

___

## public _bool_ IsOutOfArrayBounds
### Description
### Example
~~~ c#
~~~

___

## public _void_ Foreach
### Description
### Example
~~~ c#
~~~

___

## public abstract _Hex.Vector_ Project1DArrayIntoHex
### Description
### Example
~~~ c#
~~~

___

## protected abstract _int_ MapHexInto1DArray
### Description
### Example
~~~ c#
~~~

___

## protected abstract _bool_ IsOutOfBounds
### Description
### Example
~~~ c#
~~~

___






# public class Hex.Square\<T> : [Hex.Matrix\<T>](hexMatrix.md)
## Description


___

## Members
## Properties
### Description
### Example
~~~ c#
~~~

___

## Constructors
### Description
### Example
~~~ c#
~~~

___

## public override _Hex.Vector_ Project1DArrayIntoHex
### Description
### Example
~~~ c#
~~~

___

## protected override _int_ MapHexInto1DArray
### Description
### Example
~~~ c#
~~~

___

## protected override _bool_ IsOutOfBounds
### Description
### Example
~~~ c#
~~~

___



















