using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.Demo
{
	public enum DocumentTypeEnum
	{
		Unknown = 1,
		Example = 2,
		RandomType = 3
	}

	public class BFO
	{
		public List<Person> Persons { get; set; }
		public List<House> Houses { get; set; }
		public DateTime Created { get; set; }
		public DateTime? LastUpdated { get; set; }
		public string Author { get; set; }
		public string Email { get; set; }
		public string Company { get; set; }
		public int Version { get; set; }
		public bool IsPrivate { get; set; }
		public bool? ShouldAuthorReviewIt { get; set; }
		public decimal Mark { get; set; }
		public float RandomFloat { get; set; }
	}
}
