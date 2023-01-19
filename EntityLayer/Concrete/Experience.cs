using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityLayer.Concrete
{
    public class Experience
    {
        [Key]
        public int Id { get; set; }
        [StringLength(100)]
        public string WorkplaceName { get; set; }
        [StringLength(100)]
        public string Position { get; set; }
        [StringLength(1000)]
        public string WorkInfo { get; set; }
        public DateTime DateTime1 { get; set; }
        public DateTime DateTime2 { get; set; }
    }
}
