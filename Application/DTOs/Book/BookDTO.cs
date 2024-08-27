using Application.DTOs.Author;
using Application.DTOs.Publisher;

namespace Application.DTOs.Book;
public class BookDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public AuthorDTO Author { get; set; }
    public DateOnly PublishedIn { get; set; }
    public string ISBN { get; set; }
    public PublisherDTO Publisher { get; set; }
    public int PagesCount { get; set; }
}
