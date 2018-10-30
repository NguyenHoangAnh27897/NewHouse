using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace NewHouse.Models
{
    public class Data
    {
        public NH_Slider slider { get; set; }
        public NH_Solution sol { get; set; }
        public NH_Homepage hp { get; set; }
        public NH_Feature fea { get; set; }
        public List<NH_Project> pro { get; set; }
        public List<NH_News> news { get; set; }
        public NH_Partnership pns { get; set; }
        public List<NH_Partner> pn { get; set; }
        public List<NH_Architec> ar { get; set; }
        public NH_AboutUs ab { get; set; }
    }

    public class Architect
    {
        public NH_Architec architect { get; set; }
        public List<NH_Project> project { get; set; }
    }
}