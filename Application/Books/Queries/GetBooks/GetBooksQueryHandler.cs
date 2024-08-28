using Application.DTOs.Book;
using AutoMapper;
using Domain.Abstractions;
using Domain.Interfaces;
using Domain.Query;
using MediatR;

namespace Application.Books.Queries.GetBooks;
public class GetBooksQueryHandler : IRequestHandler<GetBooksQuery, Result<IEnumerable<BookDTO>>>
{
    private readonly IBooksRepository _booksRepository;
    private readonly IMapper _mapper;

    public GetBooksQueryHandler(IBooksRepository booksRepository, IMapper mapper)
    {
        _booksRepository = booksRepository;
        _mapper = mapper;
    }

    public async Task<Result<IEnumerable<BookDTO>>> Handle(GetBooksQuery request, CancellationToken cancellationToken)
    {
        var getBooksResult = await _booksRepository.GetCollectionAsync(x =>
            !x.IsDeleted, 
            book => book.Author, 
            book => book.Publisher);

        if (getBooksResult.HasError)
            return new ErrorResult<IEnumerable<BookDTO>>(getBooksResult);

        return new SuccessResult<IEnumerable<BookDTO>>(
            _mapper.Map<IEnumerable<BookDTO>>(getBooksResult.ResponseObject));
    }
}
