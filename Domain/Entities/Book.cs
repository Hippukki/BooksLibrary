using Domain.Abstractions;

namespace Domain.Entities;
public class Book : Entity
{
    public string Name { get; set; }
    public int AuthorId { get; set; }
    public Author Author { get; set; }
    public DateOnly PublishedIn { get; set; }
    public string ISBN { get; set; }
    public Publisher Publisher { get; set; }
    public int PublisherId { get; set; }
    public int PagesCount { get; set; }
}
