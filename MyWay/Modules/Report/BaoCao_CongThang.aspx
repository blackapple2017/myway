<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCao_CongThang.aspx.cs" Inherits="Modules_Report_BaoCao_CongThang" %>

<%@ Register src="ReportViewer.ascx" tagname="ReportViewer" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <uc1:ReportViewer ID="ReportViewer_BangCong" runat="server" />
    
    </div>
    </form>
</body>
</html>
