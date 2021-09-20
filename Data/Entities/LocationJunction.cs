namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("LocationJunction")]
    public partial class LocationJunction
    {
        public int Id { get; set; }

        public int? LocationId { get; set; }

        public int? ProductId { get; set; }

        public virtual LocationTable LocationTable { get; set; }

        public virtual Product Product { get; set; }
    }
}
