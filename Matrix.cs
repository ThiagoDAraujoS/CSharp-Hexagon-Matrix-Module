using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Hex {

	public abstract class Matrix<T> : IEnumerator<T> {
		/// <summary>
		/// The data saved inside this container
		/// </summary>
		protected T[] data;

		/// <summary>
		/// Predicate if the Id is > than the array's length
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
		/// Start Building a hexagon Matrix
		/// </summary>
		public Matrix(int length) => data = new T[length];

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

		#region Custon Foreach
		/// <summary> Delegate used to foreach the elements of this datastruct</summary>
		/// <param name="index">The index of the item</param>
		/// <param name="item">A ref to the item</param>
		public delegate void ExplicitForeachOperationDelegate(Vector index, ref T item);

		/// <summary>
		/// foraches all hexagons using the "Explicit Foreach Operation Delegate" for each iteration (like LINQ does)
		/// </summary>
		/// <param name="action">The Action that will be called for each element of the structure</param>
		public void Foreach(ExplicitForeachOperationDelegate action) {
			for(int i = 0; i < data.Length; i++)
				action(Project1DArrayIntoHex(i), ref data[i]);
		}
		#endregion

		#region IEnumerator Implementation
		int iterator = 0;
		object IEnumerator.Current => data[iterator];
		T IEnumerator<T>.Current => data[iterator];
		bool IEnumerator.MoveNext() => ++iterator < data.Length;
		void IEnumerator.Reset() => iterator = 0;
		void IDisposable.Dispose() { }
		#endregion
	}
}
