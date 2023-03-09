using UnityEngine;

public class TerrainChunk
{
	private GameObject meshObject;
	private Vector2 position;
	private Bounds bounds;

	public TerrainChunk(Vector2 coord, int size,Material material)
	{
		position = coord * size;
		bounds = new Bounds(position, Vector2.one * size);
		Vector3 positionV3 = new Vector3(position.x, 0, position.y);

		meshObject = new GameObject($"{coord.x},{coord.y}");
		meshObject.transform.position = positionV3;
		meshObject.transform.localScale = Vector3.one * size / 10f;
		var filter = meshObject.AddComponent<MeshFilter>();
		var renderer = meshObject.AddComponent<MeshRenderer>();
		//filter.sharedMesh = meshData.CreateMesh();
		renderer.sharedMaterial = material;
		//meshData.Dispose();
		SetVisible(false);
	}

	public void UpdateTerrainChunk()
	{
		//float viewerDistanceFromNearestEdge = Mathf.Sqrt(bounds.SqrDistance(EndlessTerrain.viewerPosition));
		//bool visible = viewerDistanceFromNearestEdge <= EndlessTerrain.maxViewDistance;
		//SetVisible(visible);
	}

	public void SetVisible(bool visible) => meshObject.SetActive(visible);

	public bool IsVisible => meshObject.activeSelf;
}
