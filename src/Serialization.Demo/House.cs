using System.Collections.Generic;

namespace Serialization.Demo
{
	public enum HouseTypeEnum
	{
		OnTheGround,
		BlockOfFlats,
		Hotel
	}

	public class House
	{
		public string Address { get; set; }
		public List<Person> Habitants { get; set; }
		public HouseTypeEnum HouseType { get; set; }
	}
}