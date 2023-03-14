using System.IO;
using UnityEditor;
using UnityEditorInternal;
using UnityEngine;

public static class ConstantsGenerator
{
    public const string BASE_TEMPLATE_START = "public static class UnityConstants\n{\n ";
    public const string BASE_TEMPLATE_END = "\n}";

    [MenuItem("Tools/Generate Constants")]
    public static void GenerateConstants() 
    {
        FileStream fileStream = new FileStream(Application.dataPath + "/Scripts/Constants.cs", FileMode.Create);
        var layerRegion = GenerateRegion("Layers");
        var tagsRegion = GenerateRegion("Tags");
        var sortingLayerRegion = GenerateRegion("Sorting Layers");
        
		using (StreamWriter streamWriter = new StreamWriter(fileStream))
        {
            streamWriter.Write(BASE_TEMPLATE_START);

            streamWriter.WriteLine(layerRegion.Item1);

			foreach (var layerName in InternalEditorUtility.layers)
			{
                streamWriter.WriteLine(GenerateField(layerName, DataType.Layer));
			}

			streamWriter.WriteLine(layerRegion.Item2);
			streamWriter.WriteLine(tagsRegion.Item1);

			foreach (var tagName in InternalEditorUtility.tags)
			{
                streamWriter.WriteLine(GenerateField(tagName, DataType.Tag));
			}

			streamWriter.WriteLine(tagsRegion.Item2);
			streamWriter.WriteLine(sortingLayerRegion.Item1);

			foreach (var sortingLayer in SortingLayer.layers)
			{
                streamWriter.WriteLine(GenerateField(sortingLayer.name, DataType.SortingLayer));
			}

            streamWriter.WriteLine(sortingLayerRegion.Item2);

			streamWriter.Write(BASE_TEMPLATE_END);
            streamWriter.Close();
        }
    }

    private static string GenerateField(string name,DataType dataType)
    {
        string fieldName = name.Replace(' ', '_').ToUpper();
        string fieldText = $"public const string {dataType}_{fieldName} = \"{name}\";";
        return fieldText;
    }

	private static (string,string) GenerateRegion(string name)
    {
        return ($"#region {name}", "#endregion");
    }

    private enum DataType
    {
        Layer,
        Tag,
        SortingLayer
    }
}
