using System;
using System.Collections.Generic;

namespace Serialization.Demo
{
	public enum MariageStatus
	{
		Single,
		Married,
		KMP=9
	}

	public class Person
	{
		public string Name { get; set; }
		public DateTime BirthDate { get; set; }
		public DateTime MariedDate { get; set; }
		public MariageStatus MariageStatus { get; set; }
		public List<IPet> Pets { get; set; } = new List<IPet>();
	}
}