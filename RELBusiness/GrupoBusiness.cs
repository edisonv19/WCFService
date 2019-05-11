using REL.DataAccess;
using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;

namespace REL.Business
{
    public class GrupoBusiness : IDisposable
    {
        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {
        }

        public Grupo GetGrupoById(Grupo oGrupo)
        {
            using (GrupoDataAccess oGrupoDataAccess = new GrupoDataAccess())
            {
                DataSet ds = oGrupoDataAccess.GetByID(oGrupo);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Grupo.GetFromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public List<GrupoConsulta> GetListByFilter(GrupoFilter oGrupoFilter)
        {
            // Busco los grupos
            using (GrupoDataAccess oGrupoDataAccess = new GrupoDataAccess())
            {
                List<GrupoConsulta> oGrupos = null;
                DataSet ds = oGrupoDataAccess.GetListByFilter(oGrupoFilter);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    oGrupos = GrupoConsulta.GetFromDS(ds);

                    // Busco las personas de cada grupo
                    foreach (GrupoConsulta oGrupoConsulta in oGrupos)
                    {
                        using (GrupoPersonaBusiness oGrupoPersonaBusiness = new GrupoPersonaBusiness())
                        {
                            List<GrupoPersona> oGrupoPersona = oGrupoPersonaBusiness.GetListByFilter(new GrupoPersona() { IdGrupo = oGrupoConsulta.IdGrupo });
                            if (oGrupoPersona != null)
                            {
                                oGrupoConsulta.Personas = oGrupoPersona.Select(x => (int)x.IdPersona).ToList<int>();
                            }
                        }
                    }

                    return oGrupos;
                }
            }
            return null;
        }

        public Grupo InsertGrupo(Grupo oGrupo)
        {
            // Busco si existe la compania - Si no existe, creo Excepcion
            using (CompaniaBusiness oCompaniaBusiness = new CompaniaBusiness())
            {
                if (oCompaniaBusiness.GetCompaniaById(new Compania() { IdCompania = oGrupo.IdCompania }) == null)
                {
                    throw new Exception(string.Format("La compañia con id {0} no existe", oGrupo.IdCompania));
                }
            }

            // Inserto el Grupo
            using (GrupoDataAccess oGrupoDataAccess = new GrupoDataAccess())
            {
                oGrupo = oGrupoDataAccess.Insert(oGrupo);
            }

            return this.GetGrupoById(oGrupo);
        }

        /// <summary>
        /// Inserto el grupo y las personas en una sola transacción. Si en algún momento del proceso falla, se hace rollback de todo
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="personas"></param>
        /// <returns></returns>
        public Grupo InsertGrupoFull(Grupo oGrupo, List<int> personas)
        {
            // Busco si existe la compania - Si no existe, creo Excepcion
            using (CompaniaBusiness oCompaniaBusiness = new CompaniaBusiness())
            {
                if (oCompaniaBusiness.GetCompaniaById(new Compania() { IdCompania = oGrupo.IdCompania }) == null)
                {
                    throw new Exception(string.Format("La compañia con id {0} no existe", oGrupo.IdCompania));
                }
            }

            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            try
            {
                // Inserto el Grupo
                using (GrupoDataAccess oGrupoDataAccess = new GrupoDataAccess())
                {
                    oGrupo = oGrupoDataAccess.Insert(oConn, oTran, oGrupo);
                }

                // Obtengo la lista de objetos de GrupoPersonas
                List<GrupoPersona> oListGrupoPersona = this.GetGrupoPersonas(personas, oGrupo.IdGrupo, oGrupo.UsuarioAlta);

                // Inserto a las personas del grupo
                using (GrupoPersonaBusiness oGrupoPersonaBusiness = new GrupoPersonaBusiness())
                {
                    oGrupoPersonaBusiness.InsertGrupoPersona(oConn, oTran, oListGrupoPersona, (int)oGrupo.IdGrupo);
                }

                oTran.Commit();
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return this.GetGrupoById(oGrupo);
        }

        /// <summary>
        /// Actualiza el grupo y las personas en una sola transacción. Si en algún momento del proceso falla, se hace rollback de todo
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="personas"></param>
        /// <returns></returns>
        public Grupo UpdateGrupoFull(Grupo oGrupo, List<int> personas)
        {
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            try
            {
                // Actualizo el Grupo
                using (GrupoDataAccess oGrupoDataAccess = new GrupoDataAccess())
                {
                    oGrupo = oGrupoDataAccess.Update(oConn, oTran, oGrupo);
                }

                // Obtengo la lista de objetos de GrupoPersonas
                List<GrupoPersona> oListGrupoPersona = this.GetGrupoPersonas(personas, oGrupo.IdGrupo, oGrupo.UsuarioUltModif);

                // Inserto a las personas del grupo
                using (GrupoPersonaBusiness oGrupoPersonaBusiness = new GrupoPersonaBusiness())
                {
                    oGrupoPersonaBusiness.UpdateGrupoPersona(oConn, oTran, oListGrupoPersona, (int)oGrupo.IdGrupo);
                }

                oTran.Commit();
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return this.GetGrupoById(oGrupo);
        }

        /// <summary>
        /// Elimina el grupo y las personas en una sola transacción. Si en algún momento del proceso falla, se hace rollback de todo
        /// </summary>
        /// <param name="oGrupo"></param>
        /// <param name="personas"></param>
        /// <returns></returns>
        public void DeleteGrupoFull(Grupo oGrupo)
        {
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            try
            {
                // Elimina el Grupo
                using (GrupoDataAccess oGrupoDataAccess = new GrupoDataAccess())
                {
                    oGrupo = oGrupoDataAccess.Delete(oConn, oTran, oGrupo);
                }

                // Elimina a las personas del grupo
                using (GrupoPersonaBusiness oGrupoPersonaBusiness = new GrupoPersonaBusiness())
                {
                    oGrupoPersonaBusiness.DeleteGrupoPersona(oConn, oTran, (int)oGrupo.IdGrupo);
                }

                oTran.Commit();
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception(e.Message);
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }
        }

        private List<GrupoPersona> GetGrupoPersonas(List<int> personas, int? idGrupo, string usuario)
        {
            List<GrupoPersona> result = new List<GrupoPersona>();

            foreach (int p in personas)
            {
                GrupoPersona oGrupo = new GrupoPersona()
                {
                    IdPersona = p,
                    IdGrupo = idGrupo,
                    UsuarioAlta = usuario
                };

                result.Add(oGrupo);
            }

            return result;
        }
    }
}
