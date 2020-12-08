using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Data.Persistance.DataModels
{
    public class AnnotationDbo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public int? Start { get; set; }

        public int? End { get; set; }

        public double? Probability { get; set; }

        public string Type { get; set; }

        public string NormalizedText { get; set; }
    }
}
