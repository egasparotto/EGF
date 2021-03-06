﻿
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.EntityFrameworkCore.Infrastructure;

using System;

namespace EGF.Dominio.Contextos
{
    public interface IContexto : IDisposable
    {
        DbSet<T> Set<T>() where T : class;
        int SaveChanges();
        EntityEntry<T> Add<T>(T entidade) where T : class;
        EntityEntry<T> Update<T>(T entidade) where T : class;
        EntityEntry<T> Remove<T>(T entidade) where T : class;
        DatabaseFacade Database { get; }
        T ObterAntesDaAlteracao<T>(T entidade) where T : class;
    }
}
