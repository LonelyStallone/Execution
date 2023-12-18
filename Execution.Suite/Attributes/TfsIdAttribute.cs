namespace Execution.Suite.Attributes;

public class TfsIdAttribute : Attribute
{
    public int Id { get; }
    public TfsIdAttribute() { }
    public TfsIdAttribute(int id) => Id = id;
}
