using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.Data;
using Microsoft.Extensions.Logging;

namespace Infrastructure.Repositories;
internal sealed class PublishersRepository : BaseRepository<Publisher>, IPublishersRepository
{
    public PublishersRepository(ApplicationDbContext context, ILogger<Publisher> logger) : base(context, logger)
    {
    }
}
