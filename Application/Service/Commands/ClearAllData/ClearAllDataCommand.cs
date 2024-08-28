using Domain.Abstractions;
using MediatR;

namespace Application.Service.Commands.ClearAllData;
public record ClearAllDataCommand() : IRequest<Result>;
