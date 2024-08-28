using Domain.Abstractions;
using Domain.Enums;
using Domain.Interfaces;
using Domain.Query;
using MediatR;

namespace Application.Books.Commands.DeleteBook;
public class DeleteBookCommandHandler : IRequestHandler<DeleteBookCommand, Result>
{
    private readonly IBooksRepository _booksRepository;

    public DeleteBookCommandHandler(IBooksRepository booksRepository)
    {
        _booksRepository = booksRepository;
    }

    public async Task<Result> Handle(DeleteBookCommand request, CancellationToken cancellationToken)
    {
        if (request.Id is 0)
            return new ErrorResult(ErrorTypes.ValidateError, "Не указано значение поля Id");

        var getBookResult = await _booksRepository.GetItemAsync(x => x.Id == request.Id);
        if (getBookResult.HasError)
            return getBookResult;

        var entity = getBookResult.ResponseObject;
        entity.IsDeleted = true;

        return await _booksRepository.UpdateItemAsync(entity);

    }
}
