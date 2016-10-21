var Person = (function () {
    function Person(Id, Name, Passwort, IsAktiv, CounterValues) {
        this.Id = Id;
        this.Name = Name;
        this.Passwort = Passwort;
        this.IsAktiv = IsAktiv;
        this.CounterValues = CounterValues;
    }
    return Person;
}());
