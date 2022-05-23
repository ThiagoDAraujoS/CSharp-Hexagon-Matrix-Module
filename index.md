<style>
ul h3, ul{
  margin: 0 0 4px;
}
</style>

# Index:
- ### struct [Hex.Vector](#public-struct-hexvector)
  - **[Static Unit Vectors](#static-unit-vectors)**
  - **[Constructor](#constructor)**
  - **[Operators](#operators)**
  - **Public Methods**
    - **[Position](#position)**
    - **[Distance](#distance)**
  - **Public Extensions**
    - **[WorldPositionToHexVector](#worldpositiontohexvector)**
- ### abstract class [Hex.Array\<T>](#public-abstract-hexarrayt--ienumerable) : IEnumerable<T>
  - **[Indexers](#indexers)**
  - **Public Methods**
    - **[Foreach](#foreach)**
  - **Abstract Methods**
    - **[GetId](#getid)**
    - **[GetIndex](#getindex)**
    - **[IsOutOfBounds](#isoutofbounds)**
- ### class [Hex.Square\<T>](#public-class-hexsquaret--hexarrayt) : [Hex.Array\<T>](#public-abstract-hexarrayt--ienumerable)
  - **[Constructor](#constructor-1)**
  - **[Properties](#properties)**


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
//Create a new hex.vector.
Hex.Vector v = new Hex.Vector(0, 0);

//Move the vector 1 into the x direction.
v += Hex.Vector.XPos;

//Move the vector 3 hexes into the -y direction.
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
//Create a new hex.vector by adding two vectors.
//The third parameter is inferred from the x and y values.
Hex.Vector v = new Hex.Vector(1, 2) + new Hex.Vector(3, 4); //v = (4, 6, -10)
~~~

___

## Public Methods
## Position
### Description
Returns a position in the 3d space represented by the Hex.Vector.
The scale and height parameters are used to scale the vector in the 3d space.
A Hex.Vector will be implicitly casted into Vector3 using the Position() function.
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
int distance = v.Distance(v2); //distance = 5.
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

# public abstract Hex.Array\<T> : IEnumerable<T>
## Description
Base class for all hexagonal data structures. It wraps an array with generic T objects
and provides a set of methods to manipulate the array using the hexagonal cube space.

Child classes should ideally represent different shapes of hexagonal data structures.

___

## Indexers
### Description
The indexers are used to access the array using Hex.Vectors or a set of Hex.Vector components.
~~~ c#
public T this[Vector id];
public T this[int x, int y];
~~~
### Example
~~~ c#
hexArray[new Hex.Vector(1, 2)] = 1;
hexArray[1, 2] = 2;
~~~

___

## Public Methods
## Foreach
provides a foreach loop to iterate over the array while exposing
the Hex.Vector Id and reference to the value.
### Description
~~~ c#
public delegate void ExplicitForeachOperationDelegate(Vector id, ref T item);
public void Foreach(ExplicitForeachOperationDelegate action);
~~~
### Example
~~~ c#
hexArray.Foreach((Hex.Vector id, ref string item) => 
    item = id.ToString(); 
});
~~~

___

## Abstract Methods
## GetId
### Description
Returns the Hex.Vector that represents the id of the array.
~~~ c#
public abstract Vector GetId(int index);
~~~
### Example
~~~ c#
//Get the hex.vector id of the object stored in the position 0 of the array
Hex.Vector id = hexArray.GetId(0);
~~~

___

## GetIndex
### Description
Returns the index of the object represented by the Hex.Vector.
~~~ c#
public abstract int GetIndex(Vector id);
~~~
### Example
~~~ c#
//Create a new hex.vector.
Hex.Vector id = new Hex.Vector(1, 2);

//Check if the hex.vector is not out of bounds.
if(!hexArray.IsOutOfBounds(id))

    //Get the index of the hex.vector
    int index = hexArray.GetIndex(id);
~~~

___

## IsOutOfBounds
### Description
Returns true if the hex.vector is out of bounds.
~~~ c#
public abstract bool IsOutOfBounds(Vector id);
~~~

___

<br>

# public class Hex.Square\<T> : [Hex.Array\<T>](#public-abstract-class-hexmatrixt--ienumerablet)
## Description
Hex.Square implements Hex.Array and represents a rectangular 2d array of hexagons.

___

## Constructor
### Description
~~~ c#
public Square(int length, int height);
~~~
### Example
~~~ c#
//Create a new 3 by 4 Hex.Square data structure.
Hex.Square<int> square = new Hex.Square<int>(3, 4);
~~~

___

## Properties
### Description
~~~ c#
public int Length {get};
public int Height {get};
~~~
### Example
~~~ c#
//Create a new 3 by 4 Hex.Square data structure.
Hex.Square<int> square = new Hex.Square<int>(3, 4);

Debug.Log(square.Length); //3
Debug.Log(square.Height); //4
~~~

___



