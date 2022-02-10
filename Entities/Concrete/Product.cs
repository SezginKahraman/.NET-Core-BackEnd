using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Product: IEntity //public yapınca bu class'a diğer katmanlar'da 
                        // ulaşabilsin demektir
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string ProductName { get; set; }
        public short UnitsInStock { get; set; }
        public decimal UnitPrice { get; set; }


    }
    //bir class'ın default'ı internal'dır
    //buna sadece o katman erişebilir demektir


}
