using Unity.Burst;
using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;

[BurstCompile]
public struct NoiseJob : IJobParallelFor
{
	public NoiseData noiseData;

	[ReadOnly]
	public NativeArray<float2> octaveOffsets;

	public NativeArray2D<float> result;

	public void Execute(int index)
	{
		var amplitude = 1f;
		var frequency = 1f;
		var noiseHeight = 0f;

		var x = index % TerrainData.chunkSize;
		var y = index / TerrainData.chunkSize;

		for (var i = 0; i < noiseData.octaves; i++)
		{
			var sampleX = x / noiseData.scale * frequency + octaveOffsets[i].x;
			var sampleY = y / noiseData.scale * frequency + octaveOffsets[i].y;

			var perlinValue = noise.cnoise(new float2(sampleX, sampleY)) * 2 - 1;

			noiseHeight += perlinValue * amplitude;

			amplitude *= noiseData.persistance;
			frequency *= noiseData.lacunarity;
		}

		result[x, y] = noiseHeight;

	}
}

