using System.Collections;
using System.Collections.Generic;

namespace Hex {
	/// <summary>
	/// Abstract implementation of a Hexagonal matrix 
	/// </summary>
	/// <typeparam name="T"></typeparam>
	public abstract class Matrix<T> : IEnumerable<T> {
		/// <summary>
		/// The data saved inside this container
		/// </summary>
		protected T[] data;

		/// <summary>
		/// Predicate if index is out of 1d array bounds
		/// </summary>
		public bool IsOutOfArrayBounds(int index) => index < 0 || index >= data.Length;

		/// <summary>
		/// Indexer using cube coordinates to a hexagon
		/// </summary>
		/// <returns>Element</returns>
		public T this[int x, int y, int z = 0] {
			get => data[MapHexInto1DArray(x, y)];
			set => data[MapHexInto1DArray(x, y)] = value;
		}

		/// <summary>
		/// Indexer using 1D index to get a hexagon
		/// </summary>
		/// <param name="i">ID</param>
		/// <returns>Element</returns>
		public T this[Vector i] {
			get => this[i.x, i.y];
			set => this[i.x, i.y] = value;
		}

		/// <summary>
		/// Build new a hexagon Matrix
		/// </summary>
		protected Matrix(int length) => data = new T[length];

		/// <summary>
		/// This maps an axial coordinate system into a 1D, 
		/// its used to access the data array containing the Hex's info.
		/// </summary>
		/// <returns>1D Index</returns>
		protected abstract int MapHexInto1DArray(int x, int y);

		/// <summary>
		/// Check if Cube index is out of bounds
		/// </summary>
		/// <param name="index">Cube index</param>
		/// <returns>If is outside bounds.</returns>
		public abstract bool IsOutOfBounds(Vector index);

		/// <summary>
		/// Project a index into a 3D Hexagon Cube Index 
		/// </summary>
		/// <param name="i">1D Index</param>
		/// <returns>Cube Index</returns>
		protected abstract Vector Project1DArrayIntoHex(int i);

		/// <summary>
		/// Delegate used to iterate over the elements of this data structure
		/// </summary>
		/// <param name="index">The index of the item</param>
		/// <param name="item">A ref to the item</param>
		public delegate void ExplicitForeachOperationDelegate(Vector index, ref T item);

		/// <summary>
		/// Iterate over hexagons
		/// </summary>
		/// <param name="action">The Action that will be called for each element of the structure</param>
		public void Foreach(ExplicitForeachOperationDelegate action) {
			for (int i = 0; i < data.Length; i++)
				action(Project1DArrayIntoHex(i), ref data[i]);
		}

		public IEnumerator<T> GetEnumerator() => ((IEnumerable<T>) data).GetEnumerator();

		IEnumerator IEnumerable.GetEnumerator() => data.GetEnumerator();
	}
}
