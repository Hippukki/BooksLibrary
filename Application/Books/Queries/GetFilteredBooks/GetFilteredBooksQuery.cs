using Application.DTOs.Book;
using Domain.Abstractions;
using Domain.Query;
using MediatR;

namespace Application.Books.Queries.GetFilteredBooks;
public record GetFilteredBooksQuery(Filter Filter) : IRequest<Result<IEnumerable<BookDTO>>>;
