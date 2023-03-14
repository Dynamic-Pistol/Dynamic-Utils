using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using UnityEngine;

namespace Dynamic.Serialization
{
	public sealed class ColorSerializationSurrogate : ISerializationSurrogate
	{
		public void GetObjectData(object obj, SerializationInfo info, StreamingContext context)
		{
			Color data = (Color)obj;
			info.AddValue("r", data.r);
			info.AddValue("g", data.g);
			info.AddValue("b", data.b);
			info.AddValue("a", data.a);
		}

		public object SetObjectData(object obj, SerializationInfo info, StreamingContext context, ISurrogateSelector selector)
		{
			Color data = (Color)obj;
			data.r = info.GetSingle("r");
			data.g = info.GetSingle("g");
			data.b = info.GetSingle("b");
			data.a = info.GetSingle("a");
			obj = data;
			return obj;
		}
	}
}