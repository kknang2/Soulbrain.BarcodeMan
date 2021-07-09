using Soulbrain.BarcodeMan.Domain.Entities;
using Soulbrain.BarcodeMan.EntityFramework;
using Soulbrain.BarcodeMan.Helpers;
using System;
using System.Data.Entity;

namespace Soulbrain.BarcodeMan.Repositories
{
    public class BaseRepository<TEntity> : IDisposable where TEntity : EntityAudited
    {
        protected readonly AppDbContext _context;

        public BaseRepository()
        {
            _context = new AppDbContext();
        }

        public IDbSet<TEntity> Entities
        {
            get
            {
                return _context.Set<TEntity>();
            }
        }

        public int Save(TEntity entity)
        {
            if (!entity.CreateDate.HasValue)
            {
                entity.CreateDate = DateTime.Now;
                entity.CreateID = AuditInfo.PersonID;
                entity.CreateIP = AuditInfo.ClientIPAddress;

                Entities.Add(entity);
            }

            entity.ModifyDate = DateTime.Now;
            entity.ModifyID = AuditInfo.PersonID;
            entity.ModifyIP = AuditInfo.ClientIPAddress;

            return _context.SaveChanges();
        }

        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    _context.Dispose();
                }
            }
            this.disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
