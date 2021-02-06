using Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.Concrete
{
    public class Category:IEntity
    {
        //Çıplak Class Kalmasın! Her class bir Interface tarafından yönetilir.
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
    }


}
