using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Xml.Linq;

namespace TilausDBApp.ViewModels
{
    public class OrderRows
    {
        public int TilausID { get; set; }
        public int TuoteID { get; set; }

        [Display(Name = "Määrä")]
        public int Maara { get; set; }
        public float Ahinta { get; set; }
        public string Nimi { get; set; }

    }
}