using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;
internal sealed class AuthorsRepository : BaseRepository<Author>, IAuthorsRepository
{
    public AuthorsRepository(ApplicationDbContext context, ILogger<Author> logger) : base(context, logger)
    {
    }
}
