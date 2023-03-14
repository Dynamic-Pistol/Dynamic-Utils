using UnityEngine;
using Dynamic;

public class Test : MonoBehaviour
{
    [SelfComponent]
    public MeshRenderer i;

    public void Save()
    {
        TestSaveData testSaveData = new TestSaveData()
        {
            position = transform.position,
            rotation = transform.rotation,
            scale = transform.localScale,
            color = i.sharedMaterial.color
        };
        SaveSystem.Save(testSaveData, 0);
        print(Application.persistentDataPath);
    }

    public void Load()
    {
        var data = SaveSystem.Load<TestSaveData>(0);
        transform.position = data.position;
        transform.rotation = data.rotation;
        transform.localScale = data.scale;
        i.sharedMaterial.color = data.color;
    }
}