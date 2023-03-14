using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TestSaveData : ISaveable
{
	public int amount;
	public Vector3 position;
	public Quaternion rotation;
	public Vector3 scale;
	public Color color;
}
