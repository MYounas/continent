namespace continent.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("country")]
    public partial class country
    {
        public country()
        {
            cities = new HashSet<city>();
        }

        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public virtual ICollection<city> cities { get; set; }


    }
}
