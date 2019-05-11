using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace REL.DomainObjects
{
    public class Voto
    {
        #region PROPIEDADES
        public int? IdPersona { get; set; }
        public int? IdPuntuacion { get; set; }
        public string Puntuacion { get; set; }
        public string Comentario { get; set; }

        public DateTime? FechaUltModif { get; set; }
        public DateTime? FechaAlta { get; set; }
        public string UsuarioUltModif { get; set; }
        public string UsuarioAlta { get; set; }

        public string FechaAltaString { get; set; }

        public byte[] RowId { get; set; }
        #endregion

        #region METODOS

        /// <summary>
        /// Retorna una "persona" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 12/08/2017
        /// Última modificación: 12/08/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>Persona construido en función de la información dada como parámetro</returns>
        public static Voto GetFromDataRow(DataRow row)
        {
            Voto oVoto = new Voto()
            {
                IdPersona = Convert.ToInt32(row["IdPersona"]),
                Puntuacion = Convert.ToString(row["IdPuntuacion"]),
                Comentario = Convert.ToString(row["Comentario"])
            };

            if (row.Table.Columns.Contains("FechaAlta"))
                oVoto.FechaAlta = Convert.ToDateTime(row["FechaAlta"]);
            if (row.Table.Columns.Contains("UsuarioAlta"))
                oVoto.UsuarioAlta = Convert.ToString(row["UsuarioAlta"]);
            if (row.Table.Columns.Contains("FechaUltModif"))
                oVoto.FechaUltModif = Convert.ToDateTime(row["FechaUltModif"]);
            if (row.Table.Columns.Contains("UsuarioUltModif"))
                oVoto.UsuarioUltModif = Convert.ToString(row["UsuarioUltModif"]);
            if (row.Table.Columns.Contains("RowId"))
                oVoto.RowId = (Byte[])row["RowId"];

            oVoto.FechaAltaString = ((DateTime)oVoto.FechaAlta).ToString("yyyy-MM-dd");

            return oVoto;
        }

        /// <summary>
        /// Retorna una lista de "CriteriosAsignacion", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 12/08/2017
		/// Última modificación: 12/08/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<Voto> construida en función de la información dada como párametro</returns>
        public static List<Voto> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<Voto> retList = new List<Voto>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }

        #endregion
    }
}
