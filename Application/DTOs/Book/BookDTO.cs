﻿using Application.DTOs.Author;
using Application.DTOs.Publisher;

namespace Application.DTOs.Book;

/// <summary>
/// DTO книги
/// </summary>
public class BookDTO
{
    /// <summary>
    /// Идентификатор
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    /// Название
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Автор
    /// </summary>
    public AuthorDTO Author { get; set; }

    /// <summary>
    /// Дата публшикации
    /// </summary>
    public DateOnly? PublishedIn { get; set; }

    /// <summary>
    /// ISBN
    /// </summary>
    public string ISBN { get; set; }

    /// <summary>
    /// Издатель
    /// </summary>
    public PublisherDTO? Publisher { get; set; }

    /// <summary>
    /// Количество страниц
    /// </summary>
    public int PagesCount { get; set; }
}
