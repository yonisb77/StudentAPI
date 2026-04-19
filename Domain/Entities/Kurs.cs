namespace Domain.Entities;

public class Kurs
{
    public int Id { get; set; }
    public string Kursnamn { get; set; } = string.Empty;
    public int Poang { get; set; }
    public int? LarareId {  get; set;  }
}