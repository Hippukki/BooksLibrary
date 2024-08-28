using Domain.Abstractions;
using Domain.Interfaces;
using Domain.Query;
using MediatR;

namespace Application.Service.Commands.ClearAllData;
public class ClearAllDataCommandHandler : IRequestHandler<ClearAllDataCommand, Result>
{
    private readonly IBooksRepository _booksRepository;
    private readonly IAuthorsRepository _authorsRepository;
    private readonly IPublishersRepository _publishersRepository;

    public ClearAllDataCommandHandler(IBooksRepository booksRepository, IAuthorsRepository authorsRepository, IPublishersRepository publishersRepository)
    {
        _booksRepository = booksRepository;
        _authorsRepository = authorsRepository;
        _publishersRepository = publishersRepository;
    }

    public async Task<Result> Handle(ClearAllDataCommand request, CancellationToken cancellationToken)
    {
        var clearAuthorsResult = await _authorsRepository.ClearTableAsync();
        if (clearAuthorsResult.HasError)
            return clearAuthorsResult;

        var clearPublishersResult = await _publishersRepository.ClearTableAsync();
        if(clearPublishersResult.HasError) 
            return clearPublishersResult;

        var clearBooksResult = await _booksRepository.ClearTableAsync();
        if(clearBooksResult.HasError) 
            return clearBooksResult;

        return new SuccessResult();
    }
}
