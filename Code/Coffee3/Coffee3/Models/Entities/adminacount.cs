namespace Coffee3.Models.Entities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("adminaccount")]
    public partial class adminaccount
    {
        [Key]
        [StringLength(20)]
        public string username { get; set; }
        public string UserName { get; internal set; }
        [StringLength(20)]
        public string passwordhash { get; set; }

        [StringLength(20)]
        public string roles { get; set; }

    }
}
