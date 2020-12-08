using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Torito.Data.Persistance.DataModels
{
    public class TweetDbo
    {        
        [Key]
        public ulong Id { get; set; }
        public string AuthorId { get; set; }
        public string Text { get; set; }
        public EntityDbo Entities { get; set; }
        public string Source { get; set; }
        public DateTime? CreatedAt { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public DateTime LastUpdated { get; set; }
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public DateTime InsertedAt { get; set; }

        //public string Lang { get; set; }

        //public bool? PossiblySensitive { get; set; }

        //public PublicMetrics PublicMetrics { get; set; }

        //public string ConversationId { get; set; }

    }
}
