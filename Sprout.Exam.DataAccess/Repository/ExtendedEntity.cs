using System;
using System.Collections.Generic;
using System.Text;

namespace Sprout.Exam.DataAccess.Repository
{
    public abstract class ExtendedEntity<T> : IExtendedEntity<T>
    {
        private DateTime? _createdDate;

        public T Id { get; set; }

        //public DateTime CreatedDate
        //{
        //    get { return _createdDate ?? DateTime.Now; }
        //    set { _createdDate = value; }
        //}

        //public DateTime? ModifiedDate { get; set; }

        //public string CreatedBy { get; set; }

        //public string ModifiedBy { get; set; }

        //public byte[] RowVersion { get; set; }
    }
}
