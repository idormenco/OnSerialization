using System;
using System.IO;
using System.Xml;
using System.Xml.Serialization;

namespace Serialization.Demo.Serializators
{
	public static class XmlSerializator
	{
		public static string SerializeToXml<T>(this T value)
		{
			try
			{
				var xmlserializer = new XmlSerializer(typeof(T));
				var stringWriter = new StringWriter();
				using (var writer = XmlWriter.Create(stringWriter))
				{
					xmlserializer.Serialize(writer, value);
					return stringWriter.ToString();
				}
			}
			catch (Exception ex)
			{
				throw new Exception("An error occurred", ex);
			}
		}
	}
}
