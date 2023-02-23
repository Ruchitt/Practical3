﻿using Practical3.Data;
using Practical3.DataAccess.Repository.IRepository;
using Practical3.Models;
using Practical3.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practical3.DataAccess.Repository
{
    public class CategoryRepository:Repository<Category>,ICategoryRepository
    {
        private ApplicationDbContext _db;

        public CategoryRepository(ApplicationDbContext db):base(db) 
        {
            _db = db;
        }
    }
}
