﻿using AdessoDraw.Domain.Context;
using AdessoDraw.Domain.Entities;
using AdessoDraw.Domain.Repositorys.Interfaces;


namespace AdessoDraw.Domain.Repositorys;
public class DrawRepository : Repository<Draw>, IDrawRepository
{
    public DrawRepository(DrawContext context) : base(context)
    {
    }
}
