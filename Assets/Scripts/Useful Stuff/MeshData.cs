using System;
using Unity.Collections;
using Unity.Mathematics;
using UnityEngine;

public struct MeshData : IDisposable
{
	[NativeDisableParallelForRestriction]
	public NativeArray<float3> vertices;
	[NativeDisableParallelForRestriction]
	public NativeArray<int> triangles;
	[NativeDisableParallelForRestriction]
	public NativeArray<float2> uvs;

	private int triangleIndex;

	public MeshData(int meshWidth,int meshHeight)
	{
		triangleIndex = 0;
		vertices = new NativeArray<float3>(meshHeight * meshHeight,Allocator.TempJob);
		uvs = new NativeArray<float2>(meshHeight * meshHeight,Allocator.TempJob);
		triangles = new NativeArray<int>((meshWidth - 1) * (meshHeight - 1) * 6,Allocator.TempJob);
	}

	public void AddTriangle(int a,int b, int c)
	{
		triangles[triangleIndex] = a;
		triangles[triangleIndex + 1] = b;
		triangles[triangleIndex + 2] = c;
		triangleIndex += 3;
	}

	public Mesh CreateMesh()
	{
		Mesh mesh = new Mesh();
		mesh.vertices = vertices.Reinterpret<Vector3>().ToArray();
		mesh.triangles = triangles.ToArray();
		mesh.uv = uvs.Reinterpret<Vector2>().ToArray();
		mesh.RecalculateNormals();
		return mesh;
	}

	public void Dispose()
	{
		vertices.Dispose();
		triangles.Dispose();
		uvs.Dispose();
	}
}
