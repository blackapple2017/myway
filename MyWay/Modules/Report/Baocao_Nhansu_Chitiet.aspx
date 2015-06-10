<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Baocao_Nhansu_Chitiet.aspx.cs" Inherits="Modules_Report_Baocao_Nhansu_Chitiet" %>

<%@ Register src="ReportViewer.ascx" tagname="ReportViewer" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #Report_baocao_nhansu_chitiet_ReportViewer1_Div
        {
            margin:0px auto !important
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ReportViewer ID="Report_baocao_nhansu_chitiet" runat="server" />
    
    </div>
    </form>
</body>
</html>
