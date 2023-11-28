using System;
using System.ComponentModel.DataAnnotations;

namespace ShopWebApp.Core.Entities
{
    public class EntityBase
    {
        [Key]
        public int Id { get; set; }
        public EntityBase()
        {
            Enabled = true;
            Modified = DateTime.UtcNow;
        }
        public bool Enabled { get; set; }
        public DateTime? Modified { get; set; }
    }
}
