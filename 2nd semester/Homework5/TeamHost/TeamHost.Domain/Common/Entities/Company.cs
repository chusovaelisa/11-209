namespace TeamHost.Domain.Entities;

/// <summary>
/// Разработчик
/// </summary>
public class Company
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Описание
    /// </summary>
    public string Description { get; set; }

    /// <summary>
    /// Страна
    /// </summary>
    public Country Country { get; set; }
}