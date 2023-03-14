using System;
using Unity.Collections;
using UnityEngine;
using Dynamic.Dots;

public struct MapData : IDisposable
{
	public NativeArray2D<float> height;
	public NativeArray<Color> colors;

	public MapData(NativeArray2D<float> height,NativeArray<Color> colors)
	{
		this.height = height;
		this.colors = colors;
	}

	public void Dispose()
	{
		height.Dispose();
		colors.Dispose();
	}
}
