using REL.DomainObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DataAccess
{
    public class VotoDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "REL_Voto";

        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Obtiene un registro de REL_Voto por un id
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public DataSet GetByID(Voto oVoto)
        {
            // Creo la conexión y la transacción
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            DataSet ds = new DataSet();

            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand oComm = new SqlCommand())
                    {
                        oComm.Connection = oTran != null ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = ObjectName + "_GetByID";

                        oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oVoto.IdPersona));
                        oComm.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oVoto.FechaAlta));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.RowId));

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);

                        oTran.Commit();
                    }
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw e;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return ds;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public DataSet GetListByFilter(VotoFilter oVoto)
        {
            // Creo la conexión y la transacción
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            DataSet ds = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand oComm = new SqlCommand())
                    {
                        oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = ObjectName + "_GetListByFilter";

                        oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.IdPersona));
                        oComm.Parameters.Add(new SqlParameter("@Puntuacion", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.Puntuacion));
                        oComm.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.Comentario));
                        oComm.Parameters.Add(new SqlParameter("@FechaAltaFrom", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.FechaAltaFrom));
                        oComm.Parameters.Add(new SqlParameter("@FechaAltaTo", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.FechaAltaTo));

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw e;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return ds;
        }

        /// <summary>
        /// Inserta un registro en REL_Voto
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public Voto Insert(Voto oVoto)
        {
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            try
            {
                using (SqlCommand oComm = new SqlCommand())
                {
                    oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                    oComm.Transaction = oTran;

                    oComm.CommandType = CommandType.StoredProcedure;
                    oComm.CommandText = ObjectName + "_Insert";

                    oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oVoto.IdPersona));
                    oComm.Parameters.Add(new SqlParameter("@IdPuntuacion", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oVoto.IdPuntuacion));
                    oComm.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.Comentario));

                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 100, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oVoto.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oVoto.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oVoto.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception("Hubo un error al insertar el voto");
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oVoto;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public DataSet GetDatosCrudosByFilter(DatoCrudoFilter oDatoCrudoFilter)
        {
            // Creo la conexión y la transacción
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            DataSet ds = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand oComm = new SqlCommand())
                    {
                        oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = ObjectName + "_GetDatosCrudosByFilter";

                        oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.IdCompania));
                        oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.Nombre));
                        oComm.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.NVarChar, 50, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.Apellido));
                        oComm.Parameters.Add(new SqlParameter("@IdPuntuacion", SqlDbType.VarChar, 50, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.IdPuntuacion));
                        oComm.Parameters.Add(new SqlParameter("@Comentario", SqlDbType.NVarChar, 2000, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.Comentario));
                        oComm.Parameters.Add(new SqlParameter("@FechaAltaFrom", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.FechaAltaFrom));
                        oComm.Parameters.Add(new SqlParameter("@FechaAltaTo", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoCrudoFilter.FechaAltaTo));

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw e;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return ds;
        }

        public DataSet GetResumen(DatoResumenFilter oDatoResumenFilter)
        {
            // Creo la conexión y la transacción
            SqlConnection oConn = new SqlConnection(ConfigurationManager.ConnectionStrings["CONEXION"].ConnectionString);
            oConn.Open();
            SqlTransaction oTran = oConn.BeginTransaction();

            DataSet ds = new DataSet();
            try
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter())
                {
                    using (SqlCommand oComm = new SqlCommand())
                    {
                        oComm.Connection = (oTran != null) ? oTran.Connection : oConn;
                        oComm.Transaction = oTran;

                        oComm.CommandType = CommandType.StoredProcedure;
                        oComm.CommandText = ObjectName + "_GetResumen";

                        oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoResumenFilter.IdCompania));
                        oComm.Parameters.Add(new SqlParameter("@FechaAlta", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oDatoResumenFilter.FechaAlta));

                        adapter.SelectCommand = oComm;
                        adapter.Fill(ds);
                    }
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw e;
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return ds;
        }
    }
}
