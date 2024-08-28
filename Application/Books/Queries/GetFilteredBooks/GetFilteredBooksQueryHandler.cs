using Application.Books.Queries.GetBooks;
using Application.DTOs.Book;
using AutoMapper;
using Domain.Abstractions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Query;
using MediatR;

namespace Application.Books.Queries.GetFilteredBooks;
public class GetFilteredBooksQueryHandler : IRequestHandler<GetFilteredBooksQuery, Result<IEnumerable<BookDTO>>>
{
    private readonly IBooksRepository _booksRepository;
    private readonly IMapper _mapper;

    public GetFilteredBooksQueryHandler(IBooksRepository booksRepository, IMapper mapper)
    {
        _booksRepository = booksRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<BookDTO>>> Handle(GetFilteredBooksQuery request, CancellationToken cancellationToken)
    {
        var requestFilter = request.Filter;
        if (requestFilter.SearchType != SearchTypes.None && string.IsNullOrEmpty(requestFilter.SearchValue))
        {
            return new ErrorResult<IEnumerable<BookDTO>>(ErrorTypes.ValidateError, "Не заполнено значение для поля SearchValue");
        }

        // Получаем коллекцию книг из репозитория с применением фильтрации
        var getBooksResult = await _booksRepository.GetCollectionAsync(x =>
            !x.IsDeleted &&
            (requestFilter.SearchType == SearchTypes.None || (
                requestFilter.SearchType == SearchTypes.Name &&
                    x.Name.ToLower().Contains(requestFilter.SearchValue.ToLower()) ||
                requestFilter.SearchType == SearchTypes.ISBN &&
                    x.ISBN.Contains(requestFilter.SearchValue) ||
                requestFilter.SearchType == SearchTypes.Author &&
                    x.Author.Name.ToLower().Contains(requestFilter.SearchValue.ToLower()) ||
                requestFilter.SearchType == SearchTypes.Publisher &&
                    x.Publisher.Name.Contains(requestFilter.SearchValue)
            )),
            book => book.Author,
            book => book.Publisher);

        if (getBooksResult.HasError)
            return new ErrorResult<IEnumerable<BookDTO>>(getBooksResult);

        var books = getBooksResult.ResponseObject.AsQueryable();

        // Применение сортировки по дате публикации, если это указано в фильтре
        if (requestFilter.OrderByPublishDate)
        {
            books = requestFilter.Descending
                ? books.OrderByDescending(book => book.PublishedIn)
                : books.OrderBy(book => book.PublishedIn);
        }

        return new SuccessResult<IEnumerable<BookDTO>>(
            _mapper.Map<IEnumerable<BookDTO>>(books));
    }
}
