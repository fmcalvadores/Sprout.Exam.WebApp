using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Repository
{

    public interface IEntity 
    {

    }

    public interface IEntity<T> : IEntity
    {
        T Id { get; set; }
    }

    public interface IExtendedEntity<T> : IEntity
    {
        T Id { get; set; }   
    }
}
