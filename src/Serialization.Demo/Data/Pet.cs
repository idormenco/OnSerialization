using System;

namespace Serialization.Demo.Data
{
	public interface IPet
	{
		string Name { get; set; }
		DateTime OwnedSince { get; set; }
	}

	public class Cat : IPet
	{
		public string Name { get; set; }
		public DateTime OwnedSince { get; set; }
		public bool GivesFucks { get; set; }
	}

	public class Dog : IPet
	{
		public string Name { get; set; }
		public DateTime OwnedSince { get; set; }
		public float BarkDecibels { get; set; }

	}

	public class Timisoreana : IPet
	{
		public string Name { get; set; }
		public DateTime OwnedSince { get; set; }
		public decimal Volume { get; set; }
	}

	public class GoldFish : IPet
	{
		public string Name { get; set; }
		public DateTime OwnedSince { get; set; }
		public int MemoryDuration { get; set; }
	}
}