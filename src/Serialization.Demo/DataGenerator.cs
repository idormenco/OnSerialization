using Bogus;
using System;
using System.Collections.Generic;
using System.Text;

namespace Serialization.Demo
{
    public class DataGenerator
    {
		public BFO GetBFO()
		{
			var testBlogPosts = new Faker<BFO>()
				.RuleFor(p => p.Created, f => f.Date.Past())
				.RuleFor(p => p.Author, f => f.Name.FullName())
				.RuleFor(p => p.Email, f => f.Internet.Email())
				.RuleFor(p => p.Company, f => f.Company.CompanyName())
				.RuleFor(p => p.Version, f => f.PickRandom(new[] { 1, 2, 3, 4, 5 }))
				.RuleFor(p => p.IsPrivate, f => f.Random.Bool())
				.RuleFor(p => p.ShouldAuthorReviewIt, f => f.PickRandomParam(true, false, null as bool?))
				.RuleFor(p => p.Mark, f => f.Random.Decimal())
				.RuleFor(p => p.RandomFloat, f => f.Random.Float())
				.RuleFor(p => p.DocumentType, f => f.PickRandom<DocumentTypeEnum>());





			return testBlogPosts.Generate();
		}
    }
}
