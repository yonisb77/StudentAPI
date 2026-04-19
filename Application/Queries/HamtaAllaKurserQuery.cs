using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record HamtaAllaKurserQuery() : IRequest<IEnumerable<Kurs>>;