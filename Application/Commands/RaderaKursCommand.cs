using MediatR;

namespace Application.Commands;

public record RaderaKursCommand(int Id) : IRequest<bool>;