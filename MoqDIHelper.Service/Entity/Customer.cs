namespace UnitTestMockHelper.Service.Entity
{
    public class Customer
    {
        public string Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public override string ToString()
        {
            return $"{Id} id bilgisine sahip {FirstName} {LastName} isimli customer eklendi.";
        }
    }
}