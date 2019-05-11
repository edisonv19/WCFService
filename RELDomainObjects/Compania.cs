using System;
using System.Collections.Generic;
using System.Data;

namespace REL.DomainObjects
{
    public class Compania
    {
        #region PROPIEDADES
        public int? IdCompania { get; set; }
        public string Nombre { get; set; }
        public decimal? CUIT { get; set; }
        public int? TipoCompania { get; set; }

        public bool? Borrado { get; set; }
        public DateTime? FechaUltModif { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string UsuarioUltModif { get; set; }
        public string UsuarioAlta { get; set; }

        public byte[] RowId { get; set; }
        #endregion

        #region METODOS

        /// <summary>
        /// Retorna una "Compania" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 12/08/2017
        /// Última modificación: 12/08/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>Compania construido en función de la información dada como parámetro</returns>
        public static Compania GetFromDataRow(DataRow row)
        {
            Compania oCompania = new Compania()
            {
                IdCompania = Convert.ToInt32(row["IdCompania"]),
                Nombre = Convert.ToString(row["Nombre"]),
                CUIT = Convert.ToDecimal(row["CUIT"]),
                TipoCompania = Convert.ToInt32(row["TipoCompania"])
            };

            if (row.Table.Columns.Contains("Borrado"))
                oCompania.Borrado = Convert.ToBoolean(row["Borrado"]);
            if (row.Table.Columns.Contains("FechaAlta"))
                oCompania.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
            if (row.Table.Columns.Contains("UsuarioAlta"))
                oCompania.UsuarioAlta = Convert.ToString(row["UsuarioAlta"]);
            if (row.Table.Columns.Contains("FechaUltModif"))
                oCompania.FechaUltModif = Convert.ToDateTime(row["FechaUltModif"]);
            if (row.Table.Columns.Contains("UsuarioUltModif"))
                oCompania.UsuarioUltModif = Convert.ToString(row["UsuarioUltModif"]);
            if (row.Table.Columns.Contains("RowId"))
                oCompania.RowId = (Byte[])row["RowId"];

            return oCompania;
        }

        /// <summary>
        /// Retorna una lista de "Compania", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 12/08/2017
		/// Última modificación: 12/08/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<Compania> construida en función de la información dada como párametro</returns>
        public static List<Compania> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<Compania> retList = new List<Compania>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }

        #endregion
    }
}
