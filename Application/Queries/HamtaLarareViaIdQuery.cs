using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record HamtaLarareViaIdQuery(int Id) : IRequest<Larare?>;