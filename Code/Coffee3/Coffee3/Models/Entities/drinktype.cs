namespace Coffee3.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("drinktype")]
    public partial class drinktype
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public drinktype()
        {
            drinks = new HashSet<drink>();
        }

        [Key]
        [StringLength(20)]
        public string code { get; set; }

        [StringLength(20)]
        public string nameof { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<drink> drinks { get; set; }
    }
}
