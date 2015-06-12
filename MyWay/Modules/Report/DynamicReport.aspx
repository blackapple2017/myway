<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DynamicReport.aspx.cs" Inherits="Modules_Report_DynamicReport" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="ReportViewer.ascx" TagName="ReportViewer" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfMaBC" />
            <ext:Viewport ID="Tab4" runat="server" Border="false">
                <Items>
                    <ext:BorderLayout runat="server">
                        <Center>
                            <ext:Panel ID="Panel1" runat="server" Border="false">
                                <Items>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:ComboBox runat="server" Editable="false" ID="cbxBC" FieldLabel="Chọn mẫu quyết định" DisplayField="ReportName" ValueField="ID"
                                                AnchorHorizontal="100%" ItemSelector="div.list-item" Width="300">
                                                <Template ID="Template24" runat="server">
                                                    <Html>
                                                        <tpl for=".">
						                             <div class="list-item"> 
							                              {ReportName}
						                             </div>
					                             </tpl>
                                                    </Html>
                                                </Template>
                                                <Store>
                                                    <ext:Store runat="server" ID="cbxBC_Store" AutoLoad="false" OnRefreshData="cbxBC_Store_OnRefreshData">
                                                        <Reader>
                                                            <ext:JsonReader>
                                                                <Fields>
                                                                    <ext:RecordField Name="ReportName" />
                                                                    <ext:RecordField Name="ID" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <Listeners>
                                                    <Expand Handler="if(cbxBC.store.getCount()==0) cbxBC_Store.reload();" />
                                                    <Select Handler="hdfMaBC.setValue(cbxBC.getValue());btnAddBC.hide();btnSaveFile.show();btnXoaFile.show();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Select OnEvent="FillRePort">
                                                        <EventMask ShowMask="true" />
                                                    </Select>
                                                </DirectEvents>
                                            </ext:ComboBox>
                                            <ext:Button runat="server" Text="&nbsp&nbsp&nbsp<b>Thêm mới</b>&nbsp&nbsp&nbsp" ID="btnAddBC">
                                                <Listeners>
                                                    <Click Handler="wdNameFileHTML.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" Hidden="true" Text="&nbsp&nbsp&nbsp<b>Lưu</b>&nbsp&nbsp&nbsp" ID="btnSaveFile">
                                                <DirectEvents>
                                                    <Click OnEvent="Update_Click" />
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" Hidden="true" Text="&nbsp&nbsp&nbsp<b>Xóa</b>&nbsp&nbsp&nbsp" ID="btnXoaFile">
                                                <DirectEvents>
                                                    <Click OnEvent="Delete_Click">
                                                        <Confirmation Message="Bạn có chắc chắn muốn xóa mẫu quyết định này không"  Title="Cảnh báo" ConfirmRequest="true" />
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                    <ext:HtmlEditor runat="server" ID="htmlEditor" Width="1250" Height="700">
                                    </ext:HtmlEditor>
                                </Items>
                            </ext:Panel>
                        </Center>
                        <East>
                            <ext:GridPanel runat="server" ID="grpDMBind" Width="300">
                                <Store>
                                    <ext:Store ID="store_DMBind" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="Handler/ThamSoHandler.ashx" />
                                        </Proxy>
                                        <Reader>
                                            <ext:JsonReader Root="Data" TotalProperty="TotalRecord">
                                                <Fields>
                                                    <ext:RecordField Name="MA" />
                                                    <ext:RecordField Name="Description" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="35" />
                                        <ext:Column DataIndex="MA" Header="Mã" Width="150" Editable="true">
                                            <Editor>
                                                <ext:TextField runat="server" />
                                            </Editor>
                                            </ext:Column>
                                        <ext:Column DataIndex="Description" Header="Mô tả" Width="250" />
                                    </Columns>
                                </ColumnModel>
                            </ext:GridPanel>
                        </East>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
            <ext:Window runat="server" ID="wdNameFileHTML" Padding="5" Height="40" Width="445" Hidden="true" Title="Đặt tên báo cáo">
                <Items>
                    <ext:TextField runat="server" ID="txtNameHTML" FieldLabel="Tên mẫu báo cáo" LabelWidth="100" Width="420">
                    </ext:TextField>
                </Items>
                <BottomBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button runat="server" ID="btnSave" Text="&nbsp&nbsp&nbsp<b>Lưu</b>&nbsp&nbsp&nbsp">
                                <DirectEvents>
                                    <Click OnEvent="btnSave_Click" />
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
            </ext:Window>
        </div>

    </form>
</body>
</html>
