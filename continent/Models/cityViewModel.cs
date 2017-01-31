using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace continent.Models
{
    public class cityViewModel
    {
        public int id { get; set; }

        [StringLength(50)]
        public string name { get; set; }

        public int CO_id { get; set; }

    }
}