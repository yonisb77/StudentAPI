using MediatR;

namespace Application.Commands;

public record UppdateraLarareCommand(int Id, string Namn) : IRequest<bool>;