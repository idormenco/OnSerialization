using System;
using System.Collections.Generic;
using System.Text;
using Bogus;

namespace Serialization.Demo {

	public class DataGenerator {
		private readonly Dictionary<Type, Func<Faker, IPet>> petBuilder = new Dictionary<Type, Func<Faker, IPet>> () { { typeof (Cat), (f) => BuildACat (f) }, { typeof (Dog), (f) => BuildADog (f) }, { typeof (GoldFish), (f) => BuildAGoldFish (f) }, { typeof (Timisoreana), (f) => BuildATimisoreana (f) },
		};

		private static Cat BuildACat (Faker f) {
			return new Cat () {
				GivesFucks = f.Random.Bool (),
					Name = f.Person.FirstName,
					OwnedSince = f.Date.Past ()
			};
		}
		private static Timisoreana BuildATimisoreana (Faker f) {
			return new Timisoreana () {
				Volume = f.PickRandom (new decimal[] { 0.5m, 1, 1.5m, 2 })
			};
		}
		private static Dog BuildADog (Faker f) {
			return new Dog () {
				BarkDecibels = f.Random.Float (10, 100)
			};
		}
		private static GoldFish BuildAGoldFish (Faker f) {
			return new GoldFish () {
				MemoryDuration = f.Random.Int (1, 5)
			};
		}

		public BFO GetBFO () {
			List<Person> persons = new List<Person> ();

			PersonsFaker ()
				.FinishWith ((f, p) => {
					persons.Add (p);
				});

			var bfoFaker = new Faker<BFO> ()
				.RuleFor (p => p.Created, f => f.Date.Past ())
				.RuleFor (p => p.Author, f => f.Name.FullName ())
				.RuleFor (p => p.Email, f => f.Internet.Email ())
				.RuleFor (p => p.Company, f => f.Company.CompanyName ())
				.RuleFor (p => p.Version, f => f.PickRandom (new [] { 1, 2, 3, 4, 5 }))
				.RuleFor (p => p.IsPrivate, f => f.Random.Bool ())
				.RuleFor (p => p.ShouldAuthorReviewIt, f => f.PickRandomParam (true, false, null as bool?))
				.RuleFor (p => p.Mark, f => f.Random.Decimal ())
				.RuleFor (p => p.RandomFloat, f => f.Random.Float ())
				.RuleFor (p => p.DocumentType, f => f.PickRandom<DocumentTypeEnum> ())
				.RuleFor (p => p.Persons, f => persons)
				.RuleFor (p => p.Houses, f => HouseFaker ().Generate (30));

			return bfoFaker.Generate ();
		}

		private Faker<House> HouseFaker () {
			return new Faker<House> ()
				.RuleFor (x => x.Address, f => f.Address.FullAddress ())
				.RuleFor (x => x.HouseType, f => f.PickRandom<HouseTypeEnum> ())
				.RuleFor (x => x.Habitants, f => PersonsFaker ().Generate (f.Random.Int (0, 3)));
		}

		public Faker<Person> PersonsFaker () {
			return new Faker<Person> ()
				.RuleFor (x => x.Name, f => f.Name.FirstName ())
				.RuleFor (x => x.Status, f => f.PickRandom<Status>())

				.RuleFor (x => x.BirthDate, f => f.Date.PastOffset (20,new DateTimeOffset(new DateTime(2000,1,1))))
				.RuleFor (x => x.MariedDate, f => f.Date.Recent ())
				.RuleFor (x => x.Pets, f => PetsFaker ().Generate (f.Random.Int (0, 4)));
		}

		public Faker<IPet> PetsFaker () {
			return new Faker<IPet> ()
				.CustomInstantiator (f => {
					var type = f.PickRandom (new [] { typeof (Cat), typeof (Dog), typeof (GoldFish), typeof (Timisoreana) });
					return petBuilder[type] (f);
				})
				.RuleFor (p => p.Name, f => f.Name.FirstName ())
				.RuleFor (p => p.OwnedSince, f => f.Date.Past (2));
		}
	}
}