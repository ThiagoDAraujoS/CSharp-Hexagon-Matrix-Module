using System.Collections;
using System.Collections.Generic;

namespace Hex {
	/// <summary>
	/// Abstract implementation of a Hexagon array, serves as base for other hexagon data structures.
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Array<T> : IEnumerable<T> {
		/// <summary>
		/// The data saved inside this container
		/// </summary>
		protected T[] data;

		/// <summary>
		/// Return if index is outside of data array bounds
		/// </summary>
		protected bool IsIndexOutOfDataArrayBounds(int index) => index < 0 || index >= data.Length;

		/// <summary>
		/// Indexer using axial coordinates to a hexagon
		/// </summary>
		/// <returns>Element</returns>
		public T this[int x, int y] {
			get => this[new Vector(x, y)];
			set => this[new Vector(x, y)] = value;
		}

		/// <summary>
		/// Indexer using cube hex vector to find a hexagon
		/// </summary>
		/// <param name="id">ID</param>
		/// <returns>Element</returns>
		public T this[Vector id] {
			get => data[GetIndex(id)];
			set => data[GetIndex(id)] = value;
		}

		/// <summary>
		/// Build new a hexagon Array
		/// </summary>
		protected Array(int length) => data = new T[length];

		/// <summary>
		/// This maps an cube coordinate Id into a 1D index, 
		/// its used to access the data inside the array containing the Hex's info.
		/// </summary>
		/// <returns>1D Index</returns>
		//protected abstract int GetId(int x, int y);
		protected abstract int GetIndex(Vector id);
		
		/// <summary>
		/// Check if Cube hex.vector id is out of bounds
		/// </summary>
		/// <param name="id">hex.vector id</param>
		/// <returns>If is outside bounds.</returns>
		public abstract bool IsOutOfBounds(Vector id);

		/// <summary>
		/// Project a index into a 3D Hexagon Cube Id
		/// </summary>
		/// <param name="index">1D Index</param>
		/// <returns>vector id</returns>
		protected abstract Vector GetId(int index);

		/// <summary>
		/// Delegate used to iterate over the elements of this data structure
		/// </summary>
		/// <param name="id">The index of the item</param>
		/// <param name="item">A ref to the item</param>
		public delegate void ExplicitForeachOperationDelegate(Vector id, ref T item);

		/// <summary>
		/// Iterate over hexagons
		/// </summary>
		/// <param name="action">The Action that will be called for each element of the structure</param>
		public void Foreach(ExplicitForeachOperationDelegate action) {
			for (int index = 0; index < data.Length; index++)
				action(GetId(index), ref data[index]);
		}

		public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>) data).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();
	}
}
