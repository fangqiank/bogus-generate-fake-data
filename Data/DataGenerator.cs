using Bogus;
namespace Bogus_Data.Data
{
    public class DataGenerator
    {
        Faker<PersonModel> personFaker;

        public DataGenerator()
        {
            Randomizer.Seed = new Random(123);

            personFaker = new Faker<PersonModel>()
                 .RuleFor(u => u.Id, f => f.Random.Int(1, 10000))
                 .RuleFor(u => u.FirstName, f => f.Name.FirstName())
                 .RuleFor(u => u.LastName, f => f.Name.LastName())
                 .RuleFor(u => u.Email, (f, u) => f.Internet.Email(u.FirstName, u.LastName))
                 .RuleFor(u => u.Phone, f => f.Phone.PhoneNumber())
                 .RuleFor(u => u.Address, f => f.Address.StreetAddress())
                 .RuleFor(u => u.City, f => f.Address.City())
                 .RuleFor(u => u.StateAbbr, f => f.Address.StateAbbr())
                 .RuleFor(u => u.ZipCode, f => f.Address.ZipCode())
                 .RuleFor(u => u.Rating, f => f.PickRandom<CreditRating>());
        }

        public PersonModel GeneratePerson()
        {
            return personFaker.Generate();
        }

        public IEnumerable<PersonModel> GeneatorMultiRecords()
        {
            return personFaker.GenerateForever();
        }
    }
}
