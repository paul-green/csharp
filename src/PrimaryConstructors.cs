// don't do this
class Person
{
    readonly DateOnly dob;
    public Person(DateOnly dob)
    {
        this.dob = dob;
    }

    public void Dump()
    {
        Console.WriteLine($"DOB : {this.dob}");
    }
}

// do this
// drawback : no place to run constructor logic 
// 
class AnotherPerson(DateOnly dob)
{
    public void Dump()
    {
        Console.WriteLine($"DOB : {dob}");
    }
}


