using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

[BurstCompile]
public struct TerrainMeshGenJob : IJob
{
	public TerrainData terrainData;
	private MeshData meshData;
	[NativeDisableParallelForRestriction]
	public NativeArray2D<float> heightMap;
	private int meshSimplificationLevel;
	private int verticesPerLine;
	private int mapSize;

	public MeshData MeshDataGet => meshData;

	public void Execute()
	{
		float topLeftX = (mapSize - 1) * -0.5f;
		float topLeftZ = (mapSize - 1) * 0.5f;

		int vertexIndex = 0;

		for (int y = 0; y < mapSize; y += meshSimplificationLevel)
		{
			for (int x = 0; x < mapSize; x += meshSimplificationLevel)
			{
				meshData.vertices[vertexIndex] = new float3(topLeftX + x, terrainData.heightCurve.Evaluate(heightMap[x, y]) * TerrainData.heightMultiplier, topLeftZ - y);
				meshData.uvs[vertexIndex] = new float2(x / (float)mapSize, y / (float)mapSize);

				if (x < mapSize - 1 && y < mapSize - 1)
				{
					meshData.AddTriangle(vertexIndex, vertexIndex + verticesPerLine + 1, vertexIndex + verticesPerLine);
					meshData.AddTriangle(vertexIndex + verticesPerLine + 1, vertexIndex, vertexIndex + 1);
				}

				vertexIndex++;
			}
		}
	}

	public void Setup()
	{
		meshSimplificationLevel = terrainData.levelOfDetail == 0 ? 1 : terrainData.levelOfDetail * 2;
		verticesPerLine = (TerrainData.chunkSize - 1) / meshSimplificationLevel + 1;
		meshData = new MeshData(verticesPerLine, verticesPerLine);
		mapSize = TerrainData.chunkSize;
	}
}
