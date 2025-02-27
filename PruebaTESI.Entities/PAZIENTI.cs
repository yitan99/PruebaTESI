using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;

namespace PruebaTESI.Entities
{
    public class PAZIENTI
    {
        [Key]
        public int ID_PAZIENTE { get; set; }
        public string NOME { get; set; }
        public string COGNOME { get; set; }
        public string DATA_NASCITA { get; set; }

        public DateTime dDATA_NASCITA { get; set; }

    }
}