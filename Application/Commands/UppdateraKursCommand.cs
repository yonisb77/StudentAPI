using MediatR;

namespace Application.Commands;

public record UppdateraKursCommand(int Id, string Kursnamn, int Poang, int? LarareId) : IRequest<bool>;