namespace Coffee3.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("whatsup")]
    public partial class whatsup
    {
        [Key]
        [StringLength(20)]
        public string code { get; set; }

        [StringLength(20)]
        public string nameof { get; set; }

        [StringLength(1000)]
        public string descriptions { get; set; }

    }
}
