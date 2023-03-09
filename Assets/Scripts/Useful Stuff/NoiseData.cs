using Unity.Collections;
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
}
