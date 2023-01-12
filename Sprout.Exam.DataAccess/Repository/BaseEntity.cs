using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Repository
{
    public abstract class BaseEntity<T> : IEntity<T>
    {
        public T Id { get; set; }

    }
}
