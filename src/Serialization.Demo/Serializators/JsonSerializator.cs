using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.Demo.Serializators
{
	public static class JsonSerializator
	{
		public static string SerializeToJson<T>(this T value)
		{
			try
			{
				return JsonConvert.SerializeObject(value);
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred", ex);
			}
		}
	}
}
