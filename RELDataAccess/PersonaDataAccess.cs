using REL.DomainObjects;
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace REL.DataAccess
{
    public class PersonaDataAccess : IDisposable
    {
        /// <summary>
        /// Nombre de la tabla que usa
        /// </summary>
        private const string ObjectName = "REL_Persona";

        /// <summary>
        /// Función para usar el using
        /// </summary>
        public void Dispose()
        {

        }

        /// <summary>
        /// Obtiene un registro de GEN_Valores por un id
        /// </summary>
        /// <param name="oTipoValor"></param>
        /// <returns></returns>
        public DataSet GetByID(Persona oPersona)
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

                        oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oPersona.IdPersona));
                        oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oPersona.RowId));

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
        /// Inserta un registro en GEN_Valores
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public Persona Insert(Persona oPersona)
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

                    oComm.Parameters.Add(new SqlParameter("@IdPersona", SqlDbType.Int, 0, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oPersona.IdPersona));
                    oComm.Parameters.Add(new SqlParameter("@Nombre", SqlDbType.VarChar, 100, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oPersona.Nombre));
                    oComm.Parameters.Add(new SqlParameter("@Apellido", SqlDbType.VarChar, 64, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oPersona.Apellido));
                    oComm.Parameters.Add(new SqlParameter("@DNI", SqlDbType.Decimal, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oPersona.DNI));
                    oComm.Parameters.Add(new SqlParameter("@FecNac", SqlDbType.DateTime, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oPersona.FecNac));
                    oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, oPersona.IdCompania));

                    oComm.Parameters.Add(new SqlParameter("@UsuarioAlta", SqlDbType.VarChar, 0, ParameterDirection.Input, true, 0, 0, null, DataRowVersion.Original, oPersona.UsuarioAlta));
                    oComm.Parameters.Add(new SqlParameter("@RowId", SqlDbType.Timestamp, 8, ParameterDirection.InputOutput, false, 0, 0, null, DataRowVersion.Original, oPersona.RowId));

                    int rowsAffected = oComm.ExecuteNonQuery();

                    if (rowsAffected == 0)
                    {
                        throw new Exception("No se insertó ningún registro. Por favor, reintente la operación.");
                    }

                    oPersona.IdPersona = (int)oComm.Parameters["@IdPersona"].Value;
                    oPersona.RowId = (Byte[])oComm.Parameters["@Rowid"].Value;

                    oTran.Commit();
                }
            }
            catch (Exception e)
            {
                oTran.Rollback();
                throw new Exception("Hubo un error al insertar a una persona en la base de datos.");
            }
            finally
            {
                oConn.Close();
                oTran.Dispose();
            }

            return oPersona;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oValor"></param>
        /// <returns></returns>
        public DataSet GetPersonaForCombo(int idCompania)
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
                        oComm.CommandText = ObjectName + "_GetForCombo";

                        oComm.Parameters.Add(new SqlParameter("@IdCompania", SqlDbType.Int, 0, ParameterDirection.Input, false, 0, 0, null, DataRowVersion.Original, idCompania));

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
