namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("cart")]
    public partial class cart
    {
        public int Id { get; set; }

        public int? LocationId { get; set; }

        public int? UserId { get; set; }

        public int? ProductId { get; set; }

        public int Quantity { get; set; }

        public decimal TotalPrice { get; set; }

        public virtual LocationTable LocationTable { get; set; }

        public virtual Product Product { get; set; }

        public virtual User User { get; set; }
    }
}
