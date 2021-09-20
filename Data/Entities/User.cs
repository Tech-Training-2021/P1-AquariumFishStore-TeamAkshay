namespace Data.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class User
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public User()
        {
            carts = new HashSet<cart>();
            OrderTables = new HashSet<OrderTable>();
        }

        public int id { get; set; }

        public int? roleId { get; set; }

        public int? genderId { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Required]
        [StringLength(50)]
        public string email { get; set; }

        [StringLength(25)]
        public string password { get; set; }

        [StringLength(10)]
        public string phone_Number { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<cart> carts { get; set; }

        public virtual gender gender { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderTable> OrderTables { get; set; }

        public virtual role role { get; set; }
    }
}
