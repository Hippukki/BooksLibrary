using Domain.Enums;

namespace Domain.Query;

/// <summary>
/// Фильтр
/// </summary>
public class Filter
{
    /// <summary>
    /// Значение поиска
    /// </summary>
    public string? SearchValue { get; set; }

    /// <summary>
    /// Тип поиска
    /// </summary>
    public SearchTypes SearchType { get; set; }

    /// <summary>
    /// Сортировка по дате публикации
    /// </summary>
    public bool OrderByPublishDate { get; set; }

    /// <summary>
    /// Сортирорвка по убыванию
    /// </summary>
    public bool Descending { get; set; }
}
