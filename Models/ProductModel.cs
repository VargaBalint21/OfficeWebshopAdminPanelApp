using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OfficeWebshopAdminPanelApp.Models
{
    public class ProductModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Stock { get; set; }
        //public string Image { get; set; }
        public int? CategoryId { get; set; } // Nullable for cases where it is null
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; } // Nullable in case it's not deleted
    }


}
