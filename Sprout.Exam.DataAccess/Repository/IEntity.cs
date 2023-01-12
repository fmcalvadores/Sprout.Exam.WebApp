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
        //new T Id { get; set; }
        T Id { get; set; }
        //DateTime CreatedDate { get; set; }
        //DateTime? ModifiedDate { get; set; }
        //string CreatedBy { get; set; }
        //string ModifiedBy { get; set; }
    }
}
