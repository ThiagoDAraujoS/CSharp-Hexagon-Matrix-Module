namespace Hex {
	/// <summary>
	/// Square mat implementation of a hexagon matrix
	/// </summary>
	public class Square<T> : Matrix<T> {
		///<summary>
		/// The size of the data inside this container
		/// </summary>
		protected int length;

		///<summary>
		/// This maps an axial coordinate system into a 1D index, its used to access the data array containing the Hex's info
		/// </summary>
		protected override int MapHexInto1DArray(int x, int y) => length * y + x + y / 2;

		/// <summary>
		/// Check if index is out of matrix bounds
		/// </summary>
		public override bool IsOutOfBounds(Vector index) =>
			index.x < -index.y / 2 ||
			index.x >= length - index.y / 2 ||
			IsOutOfArrayBounds(MapHexInto1DArray(index.x, index.y));

		///<summary>
		/// project a index into a 3D Hexagon Vector
		/// </summary>
		protected override Vector Project1DArrayIntoHex(int i) {
			int y = i / length;
			int x = i % length - y / 2;
			return new Vector(x, y, -x - y);
		}

		///<summary>
		/// Builds a hexagon Matrix using a length and height values
		/// </summary>
		public Square(int length, int height) : base(length * height) => this.length = length;
	}
}