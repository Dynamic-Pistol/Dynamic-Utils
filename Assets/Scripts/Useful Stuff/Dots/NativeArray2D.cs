using System;
using Unity.Collections;

public struct NativeArray2D<T> : IDisposable where T : unmanaged
{
	[NativeDisableParallelForRestriction]
	private NativeArray<T> _values;
	private int _length_1;
	private int _length_2;

	public NativeArray2D(int length1,int length2,Allocator allocator)
	{
		_length_1 = length1;
		_length_2 = length2;
		_values = new NativeArray<T>(length1 * length2, allocator);
	}

	public T this[int x,int y]
	{
		get => _values[x + y * _length_1];
		set => _values[x + y * _length_1] = value;
	}

	public void Dispose()
	{
		_values.Dispose();
	}

	public int Get1stLength => _length_1;
	public int Get2ndLength => _length_2;
	public int ValueLength => _values.Length;

}
