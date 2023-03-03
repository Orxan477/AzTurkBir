﻿using Aztobir.Core.Interfaces;
using Aztobir.Data.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aztobir.Data.Implementations
{
    public class CRUDRepository<TEntity> : ICRUDRepository<TEntity>
        where TEntity : class
    {
        private AppDbContext _context;

        public CRUDRepository(AppDbContext context)
        {
            _context = context;
        }
        public async Task CreateAsync(TEntity entity)
        {
            await _context.Set<TEntity>().AddAsync(entity);
        }

        public void DeleteAsync(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
        }

        public void UpdateAsync(TEntity entity)
        {
             _context.Set<TEntity>().Update(entity);
        }
    }
}
