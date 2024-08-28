using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;
public class ApplicationDbContext : DbContext
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }
    public DbSet<Publisher> Publishers { get; set; }

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
    {
        Database.EnsureCreated();
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        //var author = new Author { Id = 1, Name = "Ибрагим" };
        //var publisher = new Publisher {Id = 1, Name = "Фокс"};
        //modelBuilder.Entity<Author>().HasData(author);
        //modelBuilder.Entity<Publisher>().HasData(publisher);
        //modelBuilder.Entity<Book>().HasData(
        //    new Book
        //    {
        //        Id = 1,
        //        Name = "Сказки",
        //        AuthorId = author.Id,
        //        PublishedIn = new DateOnly(2012, 10, 22),
        //        ISBN = "5425-4352-452-2534",
        //        PublisherId = publisher.Id,
        //        PagesCount = 345
        //    },
        //    new Book
        //    {
        //        Id = 2,
        //        Name = "Поэма",
        //        AuthorId = author.Id,
        //        PublishedIn = new DateOnly(2020, 7, 13),
        //        ISBN = "232-322-434-5344",
        //        PublisherId = publisher.Id,
        //        PagesCount = 345
        //    });
    }
}
