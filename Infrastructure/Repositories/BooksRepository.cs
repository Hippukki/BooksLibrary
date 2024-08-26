using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;
namespace Infrastructure.Repositories;

internal sealed class BooksRepository : BaseRepository<Book>, IBooksRepository
{
    public BooksRepository(ApplicationDbContext context, ILogger<Book> logger) : base(context, logger)
    {
    }
}
