namespace Coffee3.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("drink")]
    public partial class drink
    {
        [Key]
        [StringLength(20)]
        public string code { get; set; }

        [StringLength(40)]
        public string nameof { get; set; }

        [StringLength(40)]
        public string urlpic { get; set; }

        [Required]
        [StringLength(20)]
        public string drinktypecode { get; set; }

        public virtual drinktype drinktype { get; set; }
    }
}
