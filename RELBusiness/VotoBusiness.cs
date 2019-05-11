using REL.DataAccess;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;

namespace REL.Business
{
    public class VotoBusiness : IDisposable
    {
        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        public Voto GetVotoById(Voto oVoto)
        {
            using (VotoDataAccess tDataAccess = new VotoDataAccess())
            {
                DataSet ds = tDataAccess.GetByID(oVoto);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Voto.GetFromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oVotoFilter"></param>
        /// <returns></returns>
        public List<Voto> GetValoresByFilter(VotoFilter oVotoFilter)
        {
            using (VotoDataAccess oVotoDataAccess = new VotoDataAccess())
            {
                DataSet ds = oVotoDataAccess.GetListByFilter(oVotoFilter);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Voto.GetFromDS(ds);
                }
            }
            return null;
        }

        public Voto InsertVoto(Voto oVoto)
        {
            // Pregunto si la persona ya realizó la votación
            Voto voto = this.GetVotoById(oVoto);
            if (voto != null)
            {
                throw new Exception(string.Format("La persona {0} ya realizó la votación del día", oVoto.IdPersona));
            }

            using (VotoDataAccess tDataAccess = new VotoDataAccess())
            {
                return tDataAccess.Insert(oVoto);
            }
        }

        public List<DatoCrudo> GetDatosCrudosByFilter(DatoCrudoFilter oDatoCrudoFilter)
        {
            using (VotoDataAccess oVotoDataAccess = new VotoDataAccess())
            {
                DataSet ds = oVotoDataAccess.GetDatosCrudosByFilter(oDatoCrudoFilter);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DatoCrudo.GetFromDS(ds);
                }
            }
            return null;
        }

        public List<DatoResumen> GetResumen(DatoResumenFilter oFilter)
        {
            using (VotoDataAccess oVotoDataAccess = new VotoDataAccess())
            {
                DataSet ds = oVotoDataAccess.GetResumen(oFilter);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return DatoResumen.GetFromDS(ds);
                }

                return null;
            }
        }
    }
}
