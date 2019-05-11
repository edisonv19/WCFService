using REL.DataAccess;
using REL.DomainObjects;
using System;
using System.Data;

namespace REL.Business
{
    public class CompaniaBusiness : IDisposable
    {
        public void Dispose()
        {
        }

        public Compania GetCompaniaById(Compania oCompania)
        {
            using (CompaniaDataAccess tDataAccess = new CompaniaDataAccess())
            {
                DataSet ds = tDataAccess.GetByID(oCompania);
                if (ds != null && ds.Tables.Count > 0 && ds.Tables[0].Rows.Count > 0)
                {
                    return Compania.GetFromDataRow(ds.Tables[0].Rows[0]);
                }
            }
            return null;
        }

        public Compania InsertCompania(Compania oCompania)
        {
            using (CompaniaDataAccess tDataAccess = new CompaniaDataAccess())
            {
                tDataAccess.Insert(oCompania);
            }

            return this.GetCompaniaById(oCompania);
        }
    }
}
