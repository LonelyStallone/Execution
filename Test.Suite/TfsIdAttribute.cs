namespace Detection.Suite;

class TfsIdAttribute : Attribute
{
    public int Age { get; }
    public TfsIdAttribute() { }
    public TfsIdAttribute(int age) => Age = age;
}
