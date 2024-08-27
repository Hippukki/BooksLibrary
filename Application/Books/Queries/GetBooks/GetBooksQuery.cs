using Application.DTOs.Book;
using Domain.Abstractions;
using MediatR;

namespace Application.Books.Queries.GetBooks;
public record GetBooksQuery() : IRequest<Result<IEnumerable<BookDTO>>>;
