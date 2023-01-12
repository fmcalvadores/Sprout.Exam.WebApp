using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Sprout.Exam.DataAccess.Repository
{
    public interface IRepository: IReadOnlyRepository
    {
        void Create<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Update<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Delete<TEntity>(object id)
            where TEntity : class, IEntity;

        void Delete<TEntity>(TEntity entity)
            where TEntity : class, IEntity;

        void Save();

        Task SaveAsync();
    }
}
