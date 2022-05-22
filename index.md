<style>
h3, h2, ul, ol{
  margin: 0 0 5px;
}
</style>
## Description:
Here there will be a description

## Documentation:
- ### public struct [Hex.Vector](https://duckduckgo.com)
  - **[Static Unit Vectors](https://duckduckgo.com)**
  - **[Constructors](https://duckduckgo.com)**
  - **[Operators](https://duckduckgo.com)**
  - **Public Methods**
    - public _Vector3_ **[Position](https://duckduckgo.com)**
    - public _int_ **[Distance](https://duckduckgo.com)**
    - public static _Hex.Vector_ **[Round](https://duckduckgo.com)**
  - **Public Extensions**
    - public static _Hex.Vector_ **[PointToHexVector](https://duckduckgo.com)**
- ### public abstract class [Hex.Matrix\<T>](hexMatrix.md) : IEnumerable<T>
  - **[Generic Data](https://duckduckgo.com)**
  - **[Indexers](https://duckduckgo.com)**
  - **[Constructor](https://duckduckgo.com)**
  - **Public Methods**
    - public _bool_ **[IsOutOfArrayBounds](https://duckduckgo.com)**
    - public _void_ **[Foreach](https://duckduckgo.com)**
  - **Abstract Methods**
    - public abstract _Hex.Vector_ **[Project1DArrayIntoHex](https://duckduckgo.com)**
    - protected abstract _int_ **[MapHexInto1DArray](https://duckduckgo.com)**
    - protected abstract _bool_ **[IsOutOfBounds](https://duckduckgo.com)**
- ### public class [Hex.Square\<T>](https://duckduckgo.com) : [Hex.Matrix\<T>](https://duckduckgo.com)
  - **[Properties](https://duckduckgo.com)**
  - **[Constructors](https://duckduckgo.com)**
  - **[Override Methods](https://duckduckgo.com)**
    - public override _Hex.Vector_ **[Project1DArrayIntoHex](https://duckduckgo.com)**
    - protected override _int_ **[MapHexInto1DArray](https://duckduckgo.com)**
    - protected override _bool_ **[IsOutOfBounds](https://duckduckgo.com)**

  




