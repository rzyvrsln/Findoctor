﻿using FindoctorData.DAL;
using FindoctorData.Repositories;

namespace FindoctorData.UnitOfWorks
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext dbContext;

        public UnitOfWork(AppDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IRepository<T> GetRepository<T>() where T : class, new()
        {
            return new Repository<T>(dbContext);
        }

        public async Task SaveChangeAsync()
        {
            await dbContext.SaveChangesAsync();
        }

    }
}
