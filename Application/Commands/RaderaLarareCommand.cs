using MediatR;

namespace Application.Commands;

public record RaderaLarareCommand(int Id) : IRequest<bool>;