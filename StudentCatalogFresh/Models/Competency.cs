using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace StudentCatalogFresh.Models
{
    public class Competency
    {
        public int CompetencyId { get; set; }
        public string Name { get; set; }

        //Tilføjet for at skabe relationer i tabeller
        public int CompetencyHeaderId { get; set; }
        public CompetencyHeader CompetencyHeader { get; set; }
    }
}