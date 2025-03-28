﻿using Company.Data.Contexts;
using Company.Data.Models;
using Company.Repository.Interfaces;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Company.Repository.Repository
{
    public class GenericRepository <T> : IGenericRepository <T> where T : BaseEntity
    {
        private readonly CompanyDbContext _context;
        public GenericRepository(CompanyDbContext context) 
        {
            _context = context;
        }
        public void Add(T entity)
        => _context.Add(entity);

        public void Delete(T entity)
        => _context.Remove(entity);

        public IEnumerable<T> GetAll()
        => _context.Set<T>().ToList();

        public T GetById(int id)
        => _context.Set<T>().FirstOrDefault(x => x.Id == id);
        public void Update(T entity)
        => _context.Update(entity);
    }
}
