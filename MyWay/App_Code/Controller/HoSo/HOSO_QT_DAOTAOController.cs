using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;
/// Summary description for HOSO_QT_DAOTAO
/// </summary>
public class HOSO_QT_DAOTAOController : LinqProvider
{
    public HOSO_QT_DAOTAOController()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    public List<HOSO_QT_DAOTAO> GetHOSODTFr_key(decimal fr_key)
    {
            var hsdt = (from t in dataContext.HOSO_QT_DAOTAOs
                        where t.FR_KEY == fr_key
                  select t);
            return hsdt.ToList();

    }
}