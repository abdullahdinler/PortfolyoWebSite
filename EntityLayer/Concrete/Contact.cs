using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Contact
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string FullName { get; set; }
        [Required]
        public string Mail { get; set; }
        [Required]
        public string Subject { get; set; }
        [Required]
        public string MessageTxt { get; set; }
        public DateTime MessageDate { get; set; }
        public bool Status { get; set; }
    }
}
