using AutoMapper;
using Domain.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using MediatR;

namespace Application.Books.Commands.SetBook;
public class SetBookCommandHandler : IRequestHandler<SetBookCommand, Result>
{
    private readonly IBooksRepository _booksRepository;

    public SetBookCommandHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<Result> Handle(SetBookCommand request, CancellationToken cancellationToken)
    {
        return await _booksRepository.SaveItemAsync(new Book
        {
            Name = request.Model.Name,
            AuthorId = request.Model.AuthorId,
            PublishedIn = request.Model.PublishedIn,
            ISBN = request.Model.ISBN,
            PublisherId = request.Model.PublisherId,
            PagesCount = request.Model.PagesCount,
        });
    }
}
