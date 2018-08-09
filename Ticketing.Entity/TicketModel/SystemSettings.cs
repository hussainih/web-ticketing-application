using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ticketing.Entity.TicketModel
{
    public class SystemSettings
    {
        public SystemSettings()
        {
            Version = DateTime.UtcNow;
        }
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid RecID { get; set; }
        public string ConfigurationFor { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }

        public DateTime Version { get; set; }
    }
}
