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

	

	


	#endregion

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
