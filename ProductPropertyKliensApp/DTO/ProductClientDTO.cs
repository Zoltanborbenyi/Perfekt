using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductPropertyKliensApp.DTO
{
    internal class ProductClientDTO
    {
        public string Azonosító { get; set; }
        public string Sku { get; set; }
        public string TermékNév { get; set; }
        public string TípusAzonosító { get; set; }
        public string TípusNév { get; set; }
    }
}
