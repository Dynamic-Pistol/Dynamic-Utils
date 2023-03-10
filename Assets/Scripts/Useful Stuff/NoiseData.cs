using Unity.Collections;
using Unity.Jobs;
using Unity.Mathematics;
using UnityEngine;

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
}
