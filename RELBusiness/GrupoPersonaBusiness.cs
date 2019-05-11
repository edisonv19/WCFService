using REL.DataAccess;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace REL.Business
{
    public class GrupoPersonaBusiness : IDisposable
    {
        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        public GrupoPersona GetGrupoPersonaById(GrupoPersona oGrupoPersona)
        {
            using (GrupoPersonaDataAccess tDataAccess = new GrupoPersonaDataAccess())
            {
                DataSet ds = tDataAccess.GetByID(oGrupoPersona);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return GrupoPersona.GetFromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public void InsertGrupoPersona(List<GrupoPersona> oListGrupoPersona, int idGrupo)
        {
            using (GrupoPersonaDataAccess tDataAccess = new GrupoPersonaDataAccess())
            {
                tDataAccess.InsertGrupoPersona(oListGrupoPersona, idGrupo);
            }
        }

        public void InsertGrupoPersona(SqlConnection oConn, SqlTransaction oTran, List<GrupoPersona> oListGrupoPersona, int idGrupo)
        {
            using (GrupoPersonaDataAccess tDataAccess = new GrupoPersonaDataAccess())
            {
                tDataAccess.InsertGrupoPersona(oConn, oTran, oListGrupoPersona, idGrupo);
            }
        }

        public void UpdateGrupoPersona(SqlConnection oConn, SqlTransaction oTran, List<GrupoPersona> oListGrupoPersona, int idGrupo)
        {
            using (GrupoPersonaDataAccess tDataAccess = new GrupoPersonaDataAccess())
            {
                tDataAccess.UpdateGrupoPersona(oConn, oTran, oListGrupoPersona, idGrupo);
            }
        }

        public void DeleteGrupoPersona(SqlConnection oConn, SqlTransaction oTran, int idGrupo)
        {
            using (GrupoPersonaDataAccess tDataAccess = new GrupoPersonaDataAccess())
            {
                tDataAccess.Delete(oConn, oTran, new GrupoPersona() { IdGrupo = idGrupo });
            }
        }

        public List<GrupoPersona> GetListByFilter(GrupoPersona oGrupoPersona)
        {
            using (GrupoPersonaDataAccess tDataAccess = new GrupoPersonaDataAccess())
            {
                DataSet ds = tDataAccess.GetListByFilter(oGrupoPersona);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return GrupoPersona.GetFromDS(ds);
                }
            }

            return null;
        }
    }
}
