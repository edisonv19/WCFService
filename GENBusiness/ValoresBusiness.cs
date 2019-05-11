using System;
using System.Collections.Generic;
using GEN.DomainObjects;
using GEN.DataAccess;
using System.Data;

namespace GEN.Business
{
    public class ValoresBusiness : IDisposable
    {
        /// <summary>
        /// Función para utilizar el using
        /// </summary>
        public void Dispose()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="oTipoValorFilter"></param>
        /// <returns></returns>
        public List<TipoValor> GetValoresByFilter(TipoValorFilter oTipoValorFilter)
        {
            using (ValoresDataAccess oValoresDataAccess = new ValoresDataAccess())
            {
                DataSet ds = oValoresDataAccess.GetListByFilter(oTipoValorFilter);

                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return TipoValor.GetFromDS(ds);
                }
            }
            return null;
        }
    }
}
