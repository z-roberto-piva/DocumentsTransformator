namespace DocumentsTransformator.Entities;
public class Student
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public int GradYear { get; init; }
    public double Gpa { get; init; }
}