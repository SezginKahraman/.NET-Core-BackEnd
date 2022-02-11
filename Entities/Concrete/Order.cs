using Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    //veritabanı tabloları Entities ' in Concrete'sinde tutulur !
    //9.gün 1.42.48 !! önemli !
    //entities concrete 'e tablo nesnesi eklenir !
    //sonrasında direkt olarak, data access'deki abstarcta interface'i açılır
    public class Order:IEntity
    {
        public int OrderId { get; set; }
        public string CustomerId { get; set; }
        public int EmployeeId { get; set; }
        public DateTime OrderDate { get; set; }
        public string ShipCity { get; set; }

    }
}
