using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTESI.Entities.DTO
{
    public class PAZIENTI_DTO : PAZIENTI
    {
        public int edad { get; set; }
        public string DATA_ORA_PRELIEVO { get; set; }
        public DateTime? dDATA_ORA_PRELIEVO { get; set; }
    }
}
