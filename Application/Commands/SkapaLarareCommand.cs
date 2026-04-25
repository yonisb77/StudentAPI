using MediatR;

namespace Application.Commands;

public record SkapaLarareCommand(string Namn) : IRequest<int>;