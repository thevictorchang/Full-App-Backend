using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace MSAUniApp.Models
{
    public class Courseitem
    {
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int ID { get; set; }
        public Course Course { get; set; } // the course this course item belongs to
        public String Name { get; set; }
        public int Percent { get; set; }

    }
}