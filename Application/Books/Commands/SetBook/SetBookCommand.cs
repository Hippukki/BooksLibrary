using Application.DTOs.Book;
using Domain.Abstractions;
using MediatR;

namespace Application.Books.Commands.SetBook;
 public record SetBookCommand(NewBookDTO Model) : IRequest<Result>;
