using Domain.Entities;
using MediatR;

namespace Application.Queries;

public record HamtaKursViaIdQuery(int Id) : IRequest<Kurs?>;