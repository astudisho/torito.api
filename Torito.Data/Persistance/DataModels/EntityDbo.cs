using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Data.Persistance.DataModels
{
    public class EntityDbo
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public List<AnnotationDbo> Annotations { get; set; }

        //public List<Mention> Mentions { get; set; }

        public List<HashtagDbo> Hashtags { get; set; }


    }
}
