using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DomainObjects
{
    public class Persona
    {
        #region PROPIEDADES
        public int? IdPersona { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal? DNI { get; set; }
        public DateTime FecNac { get; set; }
        public int? IdCompania { get; set; }

        public bool? Borrado { get; set; }
        public DateTime? FechaUltModif { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string UsuarioUltModif { get; set; }
        public string UsuarioAlta { get; set; }

        public byte[] RowId { get; set; }
        #endregion

        #region METODOS

        /// <summary>
        /// Retorna una "persona" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 06/08/2017
        /// Última modificación: 06/08/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>Persona construido en función de la información dada como parámetro</returns>
        public static Persona GetFromDataRow(DataRow row)
        {
            Persona oPersona = new Persona()
            {
                IdPersona = Convert.ToInt32(row["IdPersona"]),
                Nombre = Convert.ToString(row["Nombre"]),
                Apellido = Convert.ToString(row["Apellido"]),
                DNI = Convert.ToDecimal(row["DNI"]),
                FecNac = Convert.ToDateTime(row["FecNac"]),
                IdCompania = Convert.ToInt32(row["IdCompania"])
            };

            if (row.Table.Columns.Contains("Borrado"))
                oPersona.Borrado = Convert.ToBoolean(row["Borrado"]);
            if (row.Table.Columns.Contains("FechaAlta"))
                oPersona.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
            if (row.Table.Columns.Contains("UsuarioAlta"))
                oPersona.UsuarioAlta = Convert.ToString(row["UsuarioAlta"]);
            if (row.Table.Columns.Contains("FechaUltModif"))
                oPersona.FechaUltModif = Convert.ToDateTime(row["FechaUltModif"]);
            if (row.Table.Columns.Contains("UsuarioUltModif"))
                oPersona.UsuarioUltModif = Convert.ToString(row["UsuarioUltModif"]);
            if (row.Table.Columns.Contains("RowId"))
                oPersona.RowId = (Byte[])row["RowId"];

            return oPersona;
        }

        /// <summary>
        /// Retorna una lista de "Persona", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 06/08/2017
		/// Última modificación: 06/08/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<CriteriosAsignacion> construida en función de la información dada como párametro</returns>
        public static List<Persona> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<Persona> retList = new List<Persona>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }
        #endregion
    }
}
