using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PruebaTESI.Entities
{
    public class PRELIEVI_PRENO
    {
        [Key]
        public int ID_PAZIENTE { get; set; }
        public string DATA_ORA_PRELIEVO { get; set; }
    }
}
