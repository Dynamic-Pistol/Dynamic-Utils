using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Dynamic.Serialization
{
	public sealed class Vector3SerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Vector3 data = (Vector3)obj;
			info.AddValue("x", data.x);
			info.AddValue("y", data.y);
			info.AddValue("z", data.z);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Vector3 data = (Vector3)obj;
			data.x = info.GetSingle("x");
			data.y = info.GetSingle("y");
			data.z = info.GetSingle("z");
			obj = data;
			return obj;
		}
	}
}