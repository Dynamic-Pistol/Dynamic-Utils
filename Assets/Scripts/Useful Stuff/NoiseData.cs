using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;
using Dynamic.Dots;
using Unity.Burst;

[System.Serializable]
public struct NoiseData
{
    public float2 offSet;
	public uint seed;
    [Min(0.0001f)]
    public float scale;
    [Min(1)]
    public int octaves;
    public float persistance;
    public float lacunarity; 
	
	public NativeArray2D<float> GenerateNoiseMap()
	{
		if (scale <= 0)
			scale = 0.0001f;
		NativeArray<float2> octaveOffsets = new NativeArray<float2>(octaves, Allocator.TempJob);

		Unity.Mathematics.Random random = new Unity.Mathematics.Random(seed);

		for (var i = 0; i < octaves; i++)
		{
			var offsetX = random.NextInt(-100000, 100000) + offSet.x;
			var offsetY = random.NextInt(-100000, 100000) + offSet.y;
			var nativeOctaveOffsets = octaveOffsets;
			nativeOctaveOffsets[i] = new float2(offsetX, offsetY);
		}

		NativeArray2D<float> noiseMap = new NativeArray2D<float>(TerrainData.chunkSize, TerrainData.chunkSize, Allocator.TempJob);

		NoiseJob job = new NoiseJob
		{
			noiseData = this,
			octaveOffsets = octaveOffsets,
			result = noiseMap,
		};

		JobHandle jobHandle = job.Schedule(noiseMap.ValueLength, 32);
		jobHandle.Complete();

		octaveOffsets.Dispose();

		float minNoiseHeight = float.MaxValue;
		float maxNoiseHeight = float.MinValue;

		for (int x = 0; x < noiseMap.Get1stLength; x++)
		{
			for (int y = 0; y < noiseMap.Get2ndLength; y++)
			{
				if (noiseMap[x, y] > maxNoiseHeight)
					maxNoiseHeight = noiseMap[x, y];
				else if (noiseMap[x, y] < minNoiseHeight)
					minNoiseHeight = noiseMap[x, y];
			}
		}

		for (int x = 0; x < noiseMap.Get1stLength; x++)
		{
			for (int y = 0; y < noiseMap.Get2ndLength; y++)
			{
				noiseMap[x, y] = math.unlerp(minNoiseHeight, maxNoiseHeight, noiseMap[x, y]);
			}
		}

		return noiseMap;
	}

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
}
