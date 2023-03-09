using UnityEngine;

[System.Serializable]
public struct RegionData
{
	public Color color;
	[Min(0.1f)]
	public float height;
}
