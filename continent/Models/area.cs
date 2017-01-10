namespace continent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("area")]
    public partial class area
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int CI_id { get; set; }

        public virtual city city { get; set; }
    }
}
