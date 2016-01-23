namespace UnitTests.TestHelper.TestClasses
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Passwort { get; set; }

        public bool IsAktiv { get; set; }

        public Person()
        {
            Id = 0;
            Name = "TEST Name";
            Passwort = "P@ssw0rd";
            IsAktiv = true;
        }
    }
}