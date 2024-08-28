using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

/// <summary>
/// Тип поиска
/// </summary>
public enum SearchTypes
{
    /// <summary>
    /// Отсутствует
    /// </summary>
    [Display(Name = "Без фильтра")]
    None,

    /// <summary>
    /// По названию
    /// </summary>
    [Display(Name = "По названию")]
    Name,

    /// <summary>
    /// По ISBN
    /// </summary>
    [Display(Name = "По ISBN")]
    ISBN,

    /// <summary>
    /// По автору
    /// </summary>
    [Display(Name = "По автору")]
    Author,

    /// <summary>
    /// По издателю
    /// </summary>
    [Display(Name = "По издателю")]
    Publisher
}
