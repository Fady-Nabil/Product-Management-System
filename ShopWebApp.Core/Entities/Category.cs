
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;


namespace ShopWebApp.Core.Entities
{
    public class Category : EntityBase
    {
        [Key]
        public int CategoryId { get; set; }
        public string Code { get; set; }

        public string Name { get; set; }
        public string About { get; set; }

        public IList<Subcategory> Subcategories { get; set; }

    }
}
