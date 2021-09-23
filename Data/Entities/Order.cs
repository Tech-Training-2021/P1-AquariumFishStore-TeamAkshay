namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Order.Order")]
    public partial class Order
    {
        public int OrderId { get; set; }

        public DateTime OrderDate { get; set; }

        [Required]
        [StringLength(255)]
        public string OrderNumber { get; set; }
    }
}
