using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using DAL;

/// <summary>
/// Summary description for DonViController
/// </summary>
public partial class DonViController : LinqProvider
{
    public DonViController()
    {

    }

    public List<string> GetAllDepartments()
    {
        return GetDonViByUserIdParentChildren().Select(dv => dv.MA_DONVI).ToList();

    }

    public List<DM_DONVI> GetDonViByUserIdParentChildren()
    {
        return GetParentChildren(dataContext.DM_DONVIs);
    }
    
    private List<DAL.DM_DONVI> GetParentChildren(IEnumerable<DAL.DM_DONVI> source)
    {
        string space = string.Empty;
        var l1Grpup = source.Where(g => g.PARENT_ID == "0");
        var rs = new List<DAL.DM_DONVI>();
        foreach (DAL.DM_DONVI group in l1Grpup)
        {
            rs.Add(group);
            space = "-";
            rs.AddRange(GetParentChildren(source, group.MA_DONVI, space));
        }
        return rs;
    }

    private IEnumerable<DM_DONVI> GetParentChildren(IEnumerable<DM_DONVI> source, string parentID, string space)
    {

        var group = source.Where(g => g.PARENT_ID == parentID);
        string tempSpace = space;
        var rs = new List<DAL.DM_DONVI>();
        foreach (DAL.DM_DONVI itemGroup in group)
        {
            itemGroup.TEN_DONVI = tempSpace + " " + itemGroup.TEN_DONVI;
            rs.Add(itemGroup);
            tempSpace += "-";
            rs.AddRange(GetParentChildren(source, itemGroup.MA_DONVI, tempSpace));
            tempSpace = tempSpace.Substring(1);
        }
        return rs;
    }
   

}