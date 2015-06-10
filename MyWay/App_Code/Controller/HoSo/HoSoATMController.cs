using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for HoSoATMController
/// </summary>
public class HoSoATMController : LinqProvider
{
	public HoSoATMController()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public void Insert(DAL.HOSO_ATM atm)
    {
        if (atm != null)
        {
            dataContext.HOSO_ATMs.InsertOnSubmit(atm);
            Save();
        }
    }

    public void Update(DAL.HOSO_ATM atm)
    {
        DAL.HOSO_ATM atmOld = dataContext.HOSO_ATMs.Where(t => t.BankID == atm.BankID && t.PrKeyHoSo == atm.PrKeyHoSo).FirstOrDefault();
        if (atmOld != null)
        {
            atmOld.IsInUsed = atm.IsInUsed;
            atmOld.LastUpdatedBy = atm.LastUpdatedBy;
            atmOld.LastUpdatedDate = atm.LastUpdatedDate;
            atmOld.Note = atm.Note;
            atmOld.PrKeyHoSo = atm.PrKeyHoSo;
            atmOld.ATMNumber = atm.ATMNumber;
            atmOld.BankID = atm.BankID; 
            Save();
        }
    }

    public DAL.HOSO_ATM GetByBankInfo(string bankId, decimal prkeyHoSo)
    {
        return dataContext.HOSO_ATMs.Where(t => t.BankID == bankId && t.PrKeyHoSo == prkeyHoSo).FirstOrDefault();
    }
}