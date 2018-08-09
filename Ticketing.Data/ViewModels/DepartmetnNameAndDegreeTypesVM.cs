using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Ticketing.Entity.TicketModel;

namespace Ticketing.Data.ViewModels
{
    public class DepartmetnNameAndDegreeTypesVM
    {
        public Guid DepartmentRecID { get; set; }
        public ICollection<DegreeType> AllDegreeTypes { get; set; }
        public string DegreeTypeSelected { get; set; }
    }
}