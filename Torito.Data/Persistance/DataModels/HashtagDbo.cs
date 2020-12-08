using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Data.Persistance.DataModels
{
    public class HashtagDbo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Start { get; set; }
        public int? End { get; set; }
        public string Tag { get; set; }
    }
}
