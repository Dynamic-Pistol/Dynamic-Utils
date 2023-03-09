using System.Collections;
using UnityEngine;
using Unity.Jobs;
using Unity.Collections;
using Unity.Mathematics;
using TMPro;

/// <summary>
/// A static class that contains useful helper functions
/// </summary>
public static class DynamicUtils
{

	#region Variables

	private static readonly Camera mainCamera = Camera.main;

	#endregion

	#region Methods

	#region Random

	public static bool GetChance(int chance) => UnityEngine.Random.value <= chance / 100;

	#endregion

	#region Math

	/// <summary>
	/// A static function to get a WorldPoint from the Screen
	/// </summary>
	/// <param name="targetPosition">target Position</param>
	/// <returns></returns>
	public static Vector3 ScreenToWorldPoint(Vector3 targetPosition) => mainCamera.ScreenToWorldPoint(targetPosition);

	/// <summary>
	/// Clamps a Vector2
	/// </summary>
	/// <param name="value"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns>a Vector2 between the min and max value</returns>
	public static Vector2 ClampVector2(Vector2 value, Vector2 min, Vector2 max)
	{
		float x = Mathf.Clamp(value.x, min.x, max.x);
		float y = Mathf.Clamp(value.y, min.y, max.y);
		return new Vector2(x, y);
	}

	/// <summary>
	/// Clamps a Vector3
	/// </summary>
	/// <param name="value"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns>a Vector3 between the min and max value</returns>
	public static Vector3 ClampVector3(Vector3 value, Vector3 min, Vector3 max)
	{
		float x = Mathf.Clamp(value.x, min.x, max.x);
		float y = Mathf.Clamp(value.y, min.y, max.y);
		float z = Mathf.Clamp(value.z, min.z, max.z);
		return new Vector3(x, y, z);
	}

	/// <summary>
	/// Clamps a Vector2Int
	/// </summary>
	/// <param name="value"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns>a Vector2Int between the min and max value</returns>
	public static Vector2Int ClampVector2Int(Vector2Int value, Vector2Int min, Vector2Int max)
	{
		int x = Mathf.Clamp(value.x, min.x, max.x);
		int y = Mathf.Clamp(value.y, min.y, max.y);
		return new Vector2Int(x, y);
	}

	/// <summary>
	/// Clamps a Vector3Int
	/// </summary>
	/// <param name="value"></param>
	/// <param name="min"></param>
	/// <param name="max"></param>
	/// <returns>a Vector3Int between the min and max value</returns>
	public static Vector3Int ClampVector3Int(Vector3Int value, Vector3Int min, Vector3Int max)
	{
		int x = Mathf.Clamp(value.x, min.x, max.x);
		int y = Mathf.Clamp(value.y, min.y, max.y);
		int z = Mathf.Clamp(value.z, min.z, max.z);
		return new Vector3Int(x, y, z);
	}

	#endregion


	public static class NoiseGenerator
	{
		public static NativeArray2D<float> GenerateNoiseMap(NoiseData noiseData)
		{
			if (noiseData.scale <= 0)
				noiseData.scale = 0.0001f;
			NativeArray<float2> octaveOffsets = new NativeArray<float2>(noiseData.octaves, Allocator.TempJob);

			Unity.Mathematics.Random random = new Unity.Mathematics.Random(noiseData.seed);

			for (var i = 0; i < noiseData.octaves; i++)
			{
				var offsetX = random.NextInt(-100000, 100000) + noiseData.offSet.x;
				var offsetY = random.NextInt(-100000, 100000) + noiseData.offSet.y;
				var nativeOctaveOffsets = octaveOffsets;
				nativeOctaveOffsets[i] = new float2(offsetX, offsetY);
			}

			NativeArray2D<float> noiseMap = new NativeArray2D<float>(TerrainData.chunkSize, TerrainData.chunkSize, Allocator.TempJob);

			NoiseJob job = new NoiseJob
			{
				noiseData = noiseData,
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

	public static class MeshBuilder
	{
		public static MeshData GenerateTerrainMesh(NativeArray2D<float> heightMap, TerrainData terrainData)
		{
			TerrainMeshGenJob genJob = new TerrainMeshGenJob
			{
				heightMap = heightMap,
				terrainData = terrainData,
			};

			genJob.Setup();

			JobHandle jobHandle = genJob.Schedule();
			jobHandle.Complete();

			MeshData meshData = genJob.MeshDataGet;

			return meshData;
		}
	}

	public static NativeArray<Color> GenerateColorMap(NativeArray2D<float> noiseHeight, RegionData[] regions)
	{
		int mapWidth = noiseHeight.Get1stLength;
		int mapHeight = noiseHeight.Get2ndLength;

		NativeArray<Color> colorMap = new NativeArray<Color>(mapWidth * mapHeight, Allocator.Persistent);

		for (int x = 0; x < mapWidth; x++)
		{
			for (int y = 0; y < mapHeight; y++)
			{
				foreach (var region in regions)
				{
					if (noiseHeight[x, y] <= region.height)
					{
						colorMap[x + y * mapWidth] = region.color;
						break;
					}
				}
			}
		}

		return colorMap;
	}


	#region World UI

	public static TextMeshPro CreateText(string gameobjectName = "New TextGameobject",Vector3 position = new Vector3(),Transform parent = null,string text = "Text",float size = 10, TextAlignmentOptions alignmentOptions = TextAlignmentOptions.Center)
    {
        GameObject textGO = new GameObject(gameobjectName);
        Transform textTrans = textGO.transform;
        textTrans.position = position;
        textTrans.parent = parent;
        TextMeshPro textMesh = textGO.AddComponent<TextMeshPro>();
        textMesh.SetText(text);
        textMesh.fontSize = size;
        textMesh.alignment = alignmentOptions;
        textMesh.ForceMeshUpdate();
        return textMesh;
    }

	#endregion

	#endregion

}
