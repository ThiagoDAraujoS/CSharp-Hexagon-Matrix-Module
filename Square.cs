namespace Hex {
	/// <summary>
	/// Square mat implementation of a hexagon matrix
	/// </summary>
	public class Square<T> : Array<T> {
		///<summary>
		/// The size of the data inside this container
		/// </summary>
		public int Length { get; private set; }
		public int Height => data.Length/Length;
		
		///<summary>
		/// This maps an axial coordinate system into a 1D index, its used to access the data array containing the Hex's info
		/// </summary>
		public override int GetIndex(Vector id) => Length * id.y + id.x + id.y / 2;
		

		/// <summary>
		/// Check if index is out of matrix bounds
		/// </summary>
		public override bool IsOutOfBounds(Vector id) =>
			id.x < -id.y / 2 ||
			id.x >= Length - id.y / 2 ||
			IsIndexOutOfDataArrayBounds(GetIndex(id));

		///<summary>
		/// project a index into a 3D Hexagon Vector
		/// </summary>
		public override Vector GetId(int index) {
			int y = index / Length;
			int x = index % Length - y / 2;
			return new Vector(x, y);
		}

		///<summary>
		/// Builds a hexagon Matrix using a length and height values
		/// </summary>
		public Square(int length, int height) : base(length * height) => this.Length = length;
	}
}