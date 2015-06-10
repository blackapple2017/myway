<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Test.aspx.cs" Inherits="Modules_Base_DropDownFieldTree_Default" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="DropDownFieldTree.ascx" tagname="DropDownFieldTree" tagprefix="uc1" %>
<%@ Register src="../DateTime/DateTime.ascx" tagname="DateTime" tagprefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" /> 
        <uc2:DateTime ID="DateTime1" Width="400" runat="server" />
        <%--<uc1:DropDownFieldTree TableName="DM_DONVI" DisplayColumn="TenDonVi" NodeIDColumn="ID" ParentIDColumnName = "ParentID" ID="DropDownFieldTree1" runat="server" />--%>
    </div>
    </form>
</body>
</html>
