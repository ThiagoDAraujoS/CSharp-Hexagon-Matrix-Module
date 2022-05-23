<style>
ul h3, ul{
  margin: 0 0 4px;
}
</style>

# Index:
- ### struct [Hex.Vector](#public-struct-hexvector-1)
  - **[Static Unit Vectors](#static-unit-vectors)**
  - **[Constructor](#constructors)**
  - **[Operators](#operators)**
  - **Public Methods**
    - **[Position](#public-vector3-position-float-size--1f-float-height--0f)**
    - **[Distance](#public-int-distance-hexvector-target)**
  - **Public Extensions**
    - **[WorldPositionToHexVector](#public-static-hexvector-pointtohexvector-float-size--1f)**
- ### abstract class [Hex.Matrix\<T>](#public-abstract-class-hexmatrixt--ienumerablet) : IEnumerable<T>
  - **[Indexers](#indexers)**
  - **Public Methods**
    - **[Foreach](#public-void-foreach)**
  - **Abstract Methods**
    - **[GetId](#public-abstract-hexvector-project1darrayintohex)**
    - **[GetIndex](#protected-abstract-int-maphexinto1darray)**
    - **[IsOutOfBounds](#protected-abstract-bool-isoutofbounds)**
- ### class [Hex.Square\<T>](#public-class-hexsquaret--hexmatrixt-1) : [Hex.Matrix\<T>](#public-abstract-class-hexmatrixt--ienumerablet)
  - **[Properties](#properties)**
  - **[Constructors](#constructors-1)**
  - **Override Methods**
    - **[GetId](#public-override-hexvector-project1darrayintohex)**
    - **[GetIndex](#protected-override-int-maphexinto1darray)**
    - **[IsOutOfBounds](#protected-override-bool-isoutofbounds)**

<br>

___

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
The static unit vectors a set of six readonly vectors used to represent the six directions of the hexagonal cube space.
They are used to manipulate the hex.vector in the space.
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

## Constructor
Hex.Vector has a constructor that takes x and y coordinate as parameters.
the third parameter is inferred from the x and y values.
~~~ c#
public Vector(int x, int y);
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

## Public Methods
## Position
### Description
Returns a position in the 3d space represented by the hex.vector.
The scale and height parameters are used to scale the vector in the 3d space.
A Hex.Vector will be implicitly casted into Vector3 using the Position() function
~~~ c#
public static implicit operator Vector3(Hex.Vector v);
public Vector3 Position (float scale = 1f, float height = 0f);
~~~
### Example
~~~ c#
transform.position = new Hex.Vector(2, 3).Position();
transform.position = new Hex.Vector(2, 3);
~~~

___

## Distance
Return the distance in hexagons between the vector and the target.
### Description
~~~ c#
public int Distance (Hex.Vector target);
~~~
### Example
~~~ c#
Hex.Vector v = new Hex.Vector(1, 2);
Hex.Vector v2 = new Hex.Vector(3, -4);
int distance = v.Distance(v2); //distance = 5
~~~

___

## Public Extensions
## WorldPositionToHexVector
### Description
Extends the Vector3 class to convert a point in the 3d space to a Hex.Vector.
The scale parameter is used to scale the Vector3.
~~~ c#
public static Vector WorldPositionToHexVector(this Vector3 position, float scale = 1f);
~~~
### Example
~~~ c#
Hex.Vector v = transform.position.WorldPositionToHexVector();
~~~

___

<br>

# public abstract Hex.Matrix\<T> : IEnumerable<T>
## Description

___

## Indexers
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## Public Methods
## Foreach
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## Abstract Methods
## GetId
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

# GetIndex
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## IsOutOfBounds
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

# public class Hex.Square\<T> : [Hex.Matrix\<T>](#public-abstract-class-hexmatrixt--ienumerablet)
## Description

___

## Properties
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## Constructors
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## Override Methods
## GetId
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## GetIndex
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

## IsOutOfBounds
### Description
~~~ c#
~~~
### Example
~~~ c#
~~~

___

