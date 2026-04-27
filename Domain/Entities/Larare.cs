using System.Text.Json.Serialization;

namespace Domain.Entities;

public class Larare
{
    public int Id { get; set; }
    public string Namn { get; set; } = string.Empty;

    [JsonIgnore]
    public List<Kurs> Kurser { get; set; } = new();
}