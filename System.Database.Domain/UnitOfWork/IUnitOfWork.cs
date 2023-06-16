using System;
using System.Collections.Generic;
using System.Database.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace System.Database.Domain.UnitOfWork
{
    public interface IUnitOfWork
    {
        ICostumerRepository CostumerRepository { get; }
        void Commit();
        void Rollback();
        Task CommitAsync();
        Task RollbackAsync();
    }
}