using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Repository
{
    public abstract class ExtendedEntity<T> : IExtendedEntity<T>
    {
     
        public T Id { get; set; }

    }
}
