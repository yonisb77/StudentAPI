using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record HamtaAllaLarareQuery() : IRequest<IEnumerable<Larare>>;