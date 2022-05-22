---
title: Hexagonal Matrix Module
description: testest
---

## Index
1. [Description](#Description)
1. [Classes](#Classes)
    - [Hex.Vector](#HexVector)
    - [Hex.Matrix](#HexMatrix)
    - [Hex.Square](#HexSquare)

## Description
## Classes

## Hex.Vector
### Description
### Example
~~~ c#
~~~
### Members
~~~ c# 
public static Test
public static Main
~~~

## Hex.Matrix
### Description
### Example
~~~ c#
~~~

## Hex.Square
### Description
### Example
~~~ c#
~~~















~~~ C#
    struct Vector Hex.Vector
    
    Variables
    int x, y, z;
    
    Constructor
    Vector(int x, int y, int z);
    Vector(int x, int y);

    Static Readonly
    static readonly Vector XPos = new Vector( 0,  1, -1);
    static readonly Vector XNeg = new Vector( 0, -1,  1);
    static readonly Vector YPos = new Vector( 1,  0, -1);
    static readonly Vector YNeg = new Vector(-1,  0,  1);
    static readonly Vector ZPos = new Vector( 1, -1,  0);
    static readonly Vector ZNeg = new Vector(-1,  1,  0);

    Methods
    Vector3 Position(float size, float height = 0f);
    int Distance(Vector target);
    static Vector Round(Vector3 vector);
    
    Properties
    public bool IsLegal;
    
    Operators
    public static implicit operator Vector3(Vector v) => v.Position(1f);
    public static Vector operator +(Vector v1, Vector v2) => new Vector(v1.x + v2.x, v1.y + v2.y, v1.z + v2.z);
    public static Vector operator -(Vector v1, Vector v2) => new Vector(v1.x - v2.x, v1.y - v2.y, v1.z - v2.z);
    public static Vector operator *(Vector v, int scalar) => new Vector(v.x * scalar, v.y * scalar, v.z * scalar);
    public static Vector operator /(Vector v, int scalar) => new Vector(v.x / scalar, v.y / scalar, v.z / scalar);
    
    Overrides
    public override string ToString();

    

    public static Vector PointToHexVector(this Vector3 point, float size = 1f);


~~~

















{% highlight c# %}
public void Method(Test t){
}
{% endhighlight %}






~~~ c#
public void int myVariable;
~~~

## Welcome to GitHub Pages

You can use the [editor on GitHub](https://github.com/ThiagoDAraujoS/CSharp-Hexagon-Matrix-Module/edit/gh-pages/index.md) to maintain and preview the content for your website in Markdown files.

Whenever you commit to this repository, GitHub Pages will run [Jekyll](https://jekyllrb.com/) to rebuild the pages in your site, from the content in your Markdown files.

### Markdown

Markdown is a lightweight and easy-to-use syntax for styling your writing. It includes conventions for

```markdown
Syntax highlighted code block

# Header 1
## Header 2
### Header 3

- Bulleted
- List

1. Numbered
2. List

**Bold** and _Italic_ and `Code` text

[Link](url) and ![Image](src)
```

For more details see [Basic writing and formatting syntax](https://docs.github.com/en/github/writing-on-github/getting-started-with-writing-and-formatting-on-github/basic-writing-and-formatting-syntax).

### Jekyll Themes

Your Pages site will use the layout and styles from the Jekyll theme you have selected in your [repository settings](https://github.com/ThiagoDAraujoS/CSharp-Hexagon-Matrix-Module/settings/pages). The name of this theme is saved in the Jekyll `_config.yml` configuration file.

### Support or Contact

Having trouble with Pages? Check out our [documentation](https://docs.github.com/categories/github-pages-basics/) or [contact support](https://support.github.com/contact) and we’ll help you sort it out.
