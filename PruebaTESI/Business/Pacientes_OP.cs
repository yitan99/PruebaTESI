using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using PruebaTESI.Entities;
using PruebaTESI.Entities.DTO;
using Microsoft.EntityFrameworkCore;
using PruebaTESI.Data;
using System.Globalization;

namespace PruebaTESI.Business
{    
    public class Pacientes_OP
    {
        private int _anioActual = 2024;
        public List<PAZIENTI_DTO> getLstPacientes() 
        {
            List<PAZIENTI_DTO> lstPacientes = new List<PAZIENTI_DTO>();
            List<PAZIENTI_DTO> lstPacientesF = new List<PAZIENTI_DTO>();
            int yearTop  = DateTime.Now.AddYears(-35).Year;
            DateTime dtFirstDateMonths = DateTime.Now.AddMonths(-4);
            dtFirstDateMonths = new DateTime(dtFirstDateMonths.Year, dtFirstDateMonths.Month,1);
            try
            {
                using (ApplicationDbContext db = new ApplicationDbContext())
                {

                    lstPacientes = (from p in db.PAZIENTI
                                    join pp in db.PRELIEVI_PRENO on p.ID_PAZIENTE equals pp.ID_PAZIENTE
                                    where  p.DATA_NASCITA.Length>0 && pp.DATA_ORA_PRELIEVO.Length > 0
                                    //where p.DATA_NASCITA.Value.Year >= yearTop
                                    //&& pp.DATA_ORA_PRELIEVO >= dtFirstDateMonths
                                    select new PAZIENTI_DTO()
                                    {
                                        COGNOME = p.COGNOME,
                                        NOME = p.NOME,
                                        ID_PAZIENTE = p.ID_PAZIENTE,
                                        DATA_NASCITA= p.DATA_NASCITA,
                                        DATA_ORA_PRELIEVO=pp.DATA_ORA_PRELIEVO,
                                        
                                        dDATA_NASCITA= (new DateTime(int.Parse(p.DATA_NASCITA.Substring(0,4))
                                                                    ,int.Parse(p.DATA_NASCITA.Substring(5,2))
                                                                    ,int.Parse(p.DATA_NASCITA.Substring(8, 2)))),//   (YYYY-MM-DD)
                                        dDATA_ORA_PRELIEVO= (new DateTime(int.Parse(pp.DATA_ORA_PRELIEVO.Substring(0,4))
                                                                    ,int.Parse(pp.DATA_ORA_PRELIEVO.Substring(5,2))
                                                                    ,int.Parse(pp.DATA_ORA_PRELIEVO.Substring(8,2)))),                                                                                
                                        //edad = (_anioActual - p.DATA_NASCITA.Value.Year)
                                    }).ToList();

                    lstPacientesF = lstPacientes
                                    .Where(q => q.dDATA_NASCITA.Year <= yearTop && q.dDATA_ORA_PRELIEVO >= dtFirstDateMonths).ToList();

                    foreach (PAZIENTI_DTO p in lstPacientesF)
                    {
                        p.edad = (_anioActual - p.dDATA_NASCITA.Year);
                    }
                                    

                }
            }
            catch (Exception ex)
            { 
            
            }

            return lstPacientesF;
        }

    }
}