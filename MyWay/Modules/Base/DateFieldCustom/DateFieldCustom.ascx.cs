using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;

public partial class Modules_Base_DateFieldCustom_DateFieldCustom : System.Web.UI.UserControl
{
    protected void Page_Load(object sender, EventArgs e)
    {
        string[] monthNames = {"T1", "T2", "T3", "T4", "T5", "T6", "T7", "T8", "T9", "T10", "T11", "T12"};
        string[] dayNames = {"T2", "T3", "T4", "T5", "T6", "T7", "CN"};
        dfCustomDateField.MonthNames = monthNames;
        dfCustomDateField.DayNames = dayNames;
    }
}