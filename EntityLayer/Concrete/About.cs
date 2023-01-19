using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class About
    {
        [Key]
        public int Id { get; set; }
        [StringLength(50)]
        public string Name { get; set; }
        [StringLength(50)]
        public string SurName { get; set; }
        public string Img { get; set; }
        [StringLength(100)]
        public string Title { get; set; }
        public char Age { get; set; }
        public DateTime Birthday { get; set; }
        public string Degree { get; set; }
        public string Phone { get; set; }
        public string Mail { get; set; }
        public string City { get; set; }
        public string Freelance { get; set; }
        public string AboutTxt { get; set; }

    }

}
