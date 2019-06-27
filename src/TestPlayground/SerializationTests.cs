using Serialization.Demo;
using System.Collections.Generic;
using Xunit;
using Shouldly;
namespace TestPlayground
{
	public class SerializationTests
	{
		[Fact]
		public void When_generating_a_object_person_list_should_be_equal_to_habitants_list()
		{
			var bfo = DataGenerator.GetBFO();
			var mergedHabbitants = new List<Person>();
			bfo.Houses.ForEach(x => mergedHabbitants.AddRange(x.Habitants));

			mergedHabbitants.ShouldAllBe(item => bfo.Persons.Contains(item));

		}
	}
}
