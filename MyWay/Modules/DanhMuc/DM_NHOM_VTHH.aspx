<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_NHOM_VTHH.aspx.cs" Inherits="Modules_DanhMuc_DM_NHOM_VTHH" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="../Base/ExcelReader/ExcelReader.ascx" tagname="ExcelReader" tagprefix="uc2" %>
<%@ Register src="../Base/GridPanel/GridPanel.ascx" tagname="GridPanel" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>  
       <%-- <uc2:ExcelReader ID="ExcelReader1" runat="server" ExcelTemplateUrl="../DanhMuc/TemplateExcel/Mau_nhap_lieu_nhom_VTHH.xls" ExcelStoreFolder="../DanhMuc/ExcelFile" MathRuleXmlUrl="../DanhMuc/MathRule/NhomVTHH.xml" DeleteExcelAfterInsert="true" PrimaryKeyName="MA_NHOM_VTHH" PrKeyIsAutoIncrement="true" TableName="DM_NHOM_VTHH" MaxRecord="100" />--%>
        <ext:Button Icon="PageExcel" runat="server" Text="Nhập từ Excel" ID="btnImportFromExcel">
          <%--  <Listeners>
                <Click Handler="ExcelReader1_wdImportDataFromExcel.show();" />
            </Listeners>--%>
        </ext:Button>
        <uc1:GridPanel ID="grp_dm_nhom_vthh" runat="server" /> 
    </div>
    </form>
</body>
</html>
