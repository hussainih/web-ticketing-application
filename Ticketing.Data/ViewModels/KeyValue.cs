using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Ticketing.Data.ViewModels
{
    public class KeyValue
    {
        [Required(ErrorMessage = "Select an Option")]
        public string Key { get; set; }

        
        public string Value { get; set; }
    }
}