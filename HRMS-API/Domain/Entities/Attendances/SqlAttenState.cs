﻿using Domain.Entities.Common;

namespace Domain.Entities.Attendances;
public class SqlAttenState : Entity
{
    public string Code { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty;
}