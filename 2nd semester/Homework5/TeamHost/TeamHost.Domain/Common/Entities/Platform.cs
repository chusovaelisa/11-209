﻿using TeamHost.Domain.Common;

namespace TeamHost.Domain.Entities;

/// <summary>
/// Платформа
/// </summary>
public class Platform : BaseEntity
{
    /// <summary>
    /// Имя
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// Код
    /// </summary>
    public string Code { get; set; }

    /// <summary>
    /// Изображение
    /// </summary>
    public StaticFile Image { get; set; }
}