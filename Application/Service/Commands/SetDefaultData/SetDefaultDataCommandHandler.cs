using Domain.Abstractions;
using Domain.Entities;
using Domain.Interfaces;
using Domain.Query;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Application.Service.Commands.SetDefaultData;
public class SetDefaultDataCommandHandler : IRequestHandler<SetDefaultDataCommand, Result>
{
    private readonly IBooksRepository _booksRepository;
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IPublishersRepository _publishersRepository;
    private readonly ILogger<SetDefaultDataCommandHandler> _logger;

    public SetDefaultDataCommandHandler(IBooksRepository booksRepository, IAuthorsRepository authorsRepository, IPublishersRepository publishersRepository, ILogger<SetDefaultDataCommandHandler> logger)
    {
        _booksRepository = booksRepository;
        _authorsRepository = authorsRepository;
        _publishersRepository = publishersRepository;
        _logger = logger;
    }

    public async Task<Result> Handle(SetDefaultDataCommand request, CancellationToken cancellationToken)
    {
        var authors = new List<Author>
        {
            new Author { Name = "Author 1", CreatedAt = DateTime.UtcNow },
            new Author { Name = "Author 2", CreatedAt = DateTime.UtcNow },
            new Author { Name = "Author 3", CreatedAt = DateTime.UtcNow }
        };

        foreach (var author in authors)
        {
            var result = await _authorsRepository.SaveItemAsync(author);
            if(result.HasError)
                _logger.LogError(result.Message);
        }

        var publishers = new List<Publisher>
        {
            new Publisher { Name = "Publisher 1", CreatedAt = DateTime.UtcNow },
            new Publisher { Name = "Publisher 2", CreatedAt = DateTime.UtcNow },
            new Publisher { Name = "Publisher 3", CreatedAt = DateTime.UtcNow }
        };

        foreach (var publisher in publishers)
        {
            var result = await _publishersRepository.SaveItemAsync(publisher);
            if (result.HasError)
                _logger.LogError(result.Message);
        }

        var books = new List<Book>
        {
            new Book { Name = "Book 1", AuthorId = authors[0].Id, PublishedIn = new DateOnly(2020, 1, 1), ISBN = "111-1", PublisherId = publishers[0].Id, PagesCount = 100, CreatedAt = DateTime.UtcNow },
            new Book { Name = "Book 2", AuthorId = authors[1].Id, PublishedIn = new DateOnly(2021, 2, 2), ISBN = "222-2", PublisherId = publishers[1].Id, PagesCount = 200, CreatedAt = DateTime.UtcNow },
            new Book { Name = "Book 3", AuthorId = authors[2].Id, PublishedIn = new DateOnly(2022, 3, 3), ISBN = "333-3", PublisherId = publishers[2].Id, PagesCount = 300, CreatedAt = DateTime.UtcNow },
            new Book { Name = "Book 4", AuthorId = authors[0].Id, PublishedIn = new DateOnly(2023, 4, 4), ISBN = "444-4", PublisherId = publishers[1].Id, PagesCount = 400, CreatedAt = DateTime.UtcNow },
            new Book { Name = "Book 5", AuthorId = authors[1].Id, PublishedIn = new DateOnly(2024, 5, 5), ISBN = "555-5", PublisherId = publishers[0].Id, PagesCount = 500, CreatedAt = DateTime.UtcNow }
        };

        foreach (var book in books)
        {
            var result = await _booksRepository.SaveItemAsync(book);
            if (result.HasError)
                _logger.LogError(result.Message);
        }

        return new SuccessResult();
    }

}
