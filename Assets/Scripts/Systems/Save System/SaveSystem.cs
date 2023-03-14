using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;
using Dynamic.Serialization;

namespace Dynamic
{
	public class SaveSystem
	{
		public static void Save<T>(T saveable, int index) where T : class, ISaveable
		{
			string path = Application.persistentDataPath + $"/Save{index}.save";
			FileStream stream = new FileStream(path, FileMode.OpenOrCreate);
			BinaryFormatter formatter = GetBinaryFormatter();
			formatter.Serialize(stream, saveable);
			stream.Close();
		}

		public static T Load<T>(int index) where T : class, ISaveable
		{
			string path = Application.persistentDataPath + $"/Save{index}.save";
			if (!File.Exists(path))
			{
				Debug.LogWarning("File doesn't exist!");
				return null;
			}
			FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
			BinaryFormatter formatter = GetBinaryFormatter();
			var data = (T)formatter.Deserialize(fileStream);
			fileStream.Close();
			return data;
		}

		private static BinaryFormatter GetBinaryFormatter()
		{
			BinaryFormatter binaryFormatter = new BinaryFormatter();

			SurrogateSelector surrogateSelector = new SurrogateSelector();
			surrogateSelector.AddSurrogate(typeof(Vector3), new StreamingContext(StreamingContextStates.All), new Vector3SerializationSurrogate());
			surrogateSelector.AddSurrogate(typeof(Quaternion), new StreamingContext(StreamingContextStates.All), new QuaternionSerializationSurrogate());
			surrogateSelector.AddSurrogate(typeof(Color), new StreamingContext(StreamingContextStates.All), new ColorSerializationSurrogate());

			binaryFormatter.SurrogateSelector = surrogateSelector;
			return binaryFormatter;
		}
	}
}