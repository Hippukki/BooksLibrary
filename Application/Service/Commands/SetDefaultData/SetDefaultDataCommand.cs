using Domain.Abstractions;
using MediatR;

namespace Application.Service.Commands.SetDefaultData;
public record SetDefaultDataCommand() : IRequest<Result>;
