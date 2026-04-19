using MediatR;

namespace Application.Commands;

public record SkapaKursCommand(string Kursnamn, int Poang,  int? LarareId) : IRequest<int>;