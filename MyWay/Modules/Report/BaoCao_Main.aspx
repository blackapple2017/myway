<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCao_Main.aspx.cs" Inherits="Modules_Report_BaoCao_Main" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="ReportViewer.ascx" TagName="ReportViewer" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div#Panel1
        {
            border-top: 1px solid #99bbe8 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <div style="height: 10px;">
        </div>
        <center>
            <uc1:ReportViewer ID="ReportViewer1" runat="server" />
        </center>
        <%--<ext:Viewport ID="Viewport1" runat="server" Layout="Fit">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel ID="Panel1" Border="false" Header="false" Title="Chi tiết báo cáo" runat="server" Layout="FitLayout">
                            <Content>
                                <div style="height:10px;">
                                </div>
                                <uc1:ReportViewer ID="ReportViewer1" runat="server" />
                            </Content>
                        </ext:Panel>
                    </Center>
                    <North Collapsible="true" Split="false"> 
                        <ext:Panel ID="Panel2" runat="server" Border="false" Title="Điều kiện báo cáo" Height="200">
                            <Items>
                                <ext:TabPanel runat="server" Border="false">
                                    <Items>
                                        <ext:Panel ID="Panel4" Padding="6" Height="180" Icon="Anchor" runat="server" Title="Thông tin chung">
                                            <Items>
                                                <ext:TextField runat="server" FieldLabel="Tiêu đề báo cáo" />
                                                <ext:TextField ID="TextField1" runat="server" FieldLabel="Người lập báo cáo" />
                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel runat="server" Icon="Font" Padding="6" Title="Kiểu chữ">
                                            <Items>
                                                
                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel ID="pnlFilter" Padding="6" runat="server" Icon="PageRefresh" Title="Điều kiện lọc">
                                            
                                        </ext:Panel>
                                    </Items>
                                </ext:TabPanel>
                            </Items>
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button runat="server" Text="Bắt đầu báo cáo" Icon="Printer"></ext:Button>
                                        <ext:Button ID="Button1" runat="server" Text="Chuyển về thiết lập mặc định" Icon="Reload"></ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                    </North>
        </ext:BorderLayout> </Items> </ext:Viewport>--%>
    </div>
    </form>
</body>
</html>
