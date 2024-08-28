using System.ComponentModel.DataAnnotations;

namespace Application.DTOs.Book;

/// <summary>
/// DTO для создания новой книги
/// </summary>
public class NewBookDTO
{
    /// <summary>
    /// Название
    /// </summary>
    [Required]
    public string Name { get; set; }

    /// <summary>
    /// Идентификатор автора
    /// </summary>
    [Required]
    public int AuthorId { get; set; }

    /// <summary>
    /// Дата публикации
    /// </summary>
    public DateOnly? PublishedIn { get; set; }

    /// <summary>
    /// ISBN
    /// </summary>
    [Required]
    public string ISBN { get; set; }

    /// <summary>
    /// Идентификатор издателя
    /// </summary>
    public int? PublisherId { get; set; }

    /// <summary>
    /// Количество страниц
    /// </summary>
    [Required]
    public int PagesCount { get; set; }
}
