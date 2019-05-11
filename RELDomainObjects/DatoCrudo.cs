using System;
using System.Collections.Generic;
using System.Data;

namespace REL.DomainObjects
{
    public class DatoCrudo
    {
        #region PROPIEDADES
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public decimal DNI { get; set; }
        public string Puntuacion { get; set; }
        public string Comentario { get; set; }
        public DateTime Fecha { get; set; }

        public string FechaString { get; set; }
        #endregion

        #region METODOS
        /// <summary>
        /// Retorna una "DatoCrudo" obteniendo los datos desde un DataRow
        /// Autor: Edison Vidal
        /// Fecha de Creacion: 22/10/2017
        /// Última modificación: 22/10/2017
        /// Última modificación por: Edison Vidal
        /// </summary>
        /// <param name="row">DataRow que contiene la información necesaria para armar el objeto</param>
        /// <returns>DatoCrudo construido en función de la información dada como parámetro</returns>
        public static DatoCrudo GetFromDataRow(DataRow row)
        {
            DatoCrudo oDatoCrudo = new DatoCrudo()
            {
                Nombre = Convert.ToString(row["Nombre"]),
                Apellido = Convert.ToString(row["Apellido"]),
                DNI = Convert.ToDecimal(row["DNI"]),
                Puntuacion = Convert.ToString(row["Puntuacion"]),
                Comentario = Convert.ToString(row["Comentario"]),
                Fecha = Convert.ToDateTime(row["Fecha"])
            };

            oDatoCrudo.FechaString = oDatoCrudo.Fecha.ToString("dd/MM/yyyy hh:mm");// ((DateTime)oDatoCrudo.Fecha).ToString("yyyy-MM-dd");

            return oDatoCrudo;
        }

        /// <summary>
        /// Retorna una lista de "DatoCrudo", obteniendo los datos desde un DataSet
        /// Autor: Edison Vidal
		/// Fecha de Creacion: 22/10/2017
		/// Última modificación: 22/10/2017
		/// Última modificación por: Edison Vidal
        /// Modificación: Creación del método
        /// </summary>
        /// <param name="ds">DataSet que contiene la información necesaria para armar los objetos</param>
        /// <returns>List<DatoCrudo> construida en función de la información dada como párametro</returns>
        public static List<DatoCrudo> GetFromDS(DataSet ds)
        {
            if (ds.Tables.Count == 0) return null;

            List<DatoCrudo> retList = new List<DatoCrudo>();
            foreach (DataRow row in ds.Tables[0].Rows)
            {
                retList.Add(GetFromDataRow(row));
            }

            return retList;
        }
        #endregion
    }
}
