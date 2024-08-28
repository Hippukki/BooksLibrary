using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

/// <summary>
/// Тип ошибки
/// </summary>
public enum ErrorTypes
{
    /// <summary>
    /// Нет ошибки
    /// </summary>
    None,

    /// <summary>
    /// Не найдена запись в базе данных
    /// </summary>
    [Display(Name = "Не найдена запись в базе данных")]
    NotFound,

    /// <summary>
    /// Произошла неизвестная ошибка
    /// </summary>
    [Display(Name = "Произошла неизвестная ошибка")]
    Unknown,

    /// <summary>
    /// Ошибка сохранения записи в бд
    /// </summary>
    [Display(Name = "Ошибка сохранения записи в бд")]
    SaveEntityError,

    /// <summary>
    /// При создании записи в базе данных произошла ошибка
    /// </summary>
    [Display(Name = "При создании записи в базе данных произошла ошибка")]
    InsertError,

    /// <summary>
    /// Ошибка при получении записи из базы данных
    /// </summary>
    [Display(Name = "Ошибка при получении записи из базы данных")]
    GetError,

    /// <summary>
    /// Ошибка при валидации данных
    /// </summary>
    [Display(Name = "Ошибка при валидации данных")]
    ValidateError
}
