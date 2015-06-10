<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DonViPhuTrachDaoTao.aspx.cs" Inherits="Modules_DaoTao_DonViPhuTrachDaoTao" %>

<%@ Register src="../Base/GridPanel/GridPanel.ascx" tagname="GridPanel" tagprefix="uc1" %>

<%@ Register src="../Base/SingleGridPanel/SingleGridPanel.ascx" tagname="SingleGridPanel" tagprefix="uc2" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div> 
        <uc2:SingleGridPanel ID="grvDonViPhuTrachDaoTao" runat="server" TableOrViewName="DM_DOITACDAOTAO" DisplayPrimaryColumn="true" IDProperty="Ma" 
           EmptyTextSearch="Nhập mã hoặc tên đối tác"/>
    </div>
    </form>
</body>
</html>
