using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Dynamic.Serialization
{
	public sealed class QuaternionSerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Quaternion data = (Quaternion)obj;
			info.AddValue("x", data.x);
			info.AddValue("y", data.y);
			info.AddValue("z", data.z);
			info.AddValue("w", data.w);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Quaternion data = (Quaternion)obj;
			data.x = info.GetSingle("x");
			data.y = info.GetSingle("y");
			data.z = info.GetSingle("z");
			data.w = info.GetSingle("w");
			obj = data;
			return obj;
		}
	}
}