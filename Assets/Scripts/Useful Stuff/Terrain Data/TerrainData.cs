using UnityEngine;

[System.Serializable]
public struct TerrainData : System.IDisposable
{
	public const int chunkSize = 241;
	[Range(0, 6)]
	public int levelOfDetail;
	public const int heightMultiplier = 25;
	public NativeCurve heightCurve;

	public void Dispose()
	{
		heightCurve.Dispose();
	}
}
