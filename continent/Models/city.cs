namespace continent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("city")]
    public partial class city
    {
        public city()
        {
            areas = new HashSet<area>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int CO_id { get; set; }

        public virtual ICollection<area> areas { get; set; }

        public virtual country country { get; set; }
    }
}
