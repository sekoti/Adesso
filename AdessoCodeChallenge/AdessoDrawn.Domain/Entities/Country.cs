﻿using AdessoDraw.Domain.Models;

namespace AdessoDraw.Domain.Entities
{
    public class Country: BaseEntity<int>
    {
        public required string Name { get; set; }
    }
}
