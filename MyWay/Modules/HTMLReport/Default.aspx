<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modules_HTMLReport_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfMaCB" />
        <ext:Hidden runat="server" ID="hdfmaBC" />
        <uc1:ucChooseEmployee ID="ucChooseEmployee1" ChiChonMotCanBo="true" runat="server" />
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel Layout="BorderLayout" runat="server" ID="pnlPage" Border="false">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:ToolbarSpacer runat="server" ID="tbs" Width="5" />
                                        <ext:DisplayField runat="server" Text="Chọn mẫu quyết định" />
                                        <ext:ToolbarSpacer runat="server" ID="ToolbarSpacer1" Width="5" />
                                        <%--<ext:ComboBox runat="server" Editable="false" ID="cbxQD" DisplayField="Value" ValueField="Description"
                                            AnchorHorizontal="100%" ItemSelector="div.list-item">
                                            <Template ID="Template24" runat="server">
                                                <Html>
                                                    <tpl for=".">
						                             <div class="list-item"> 
							                              {Value}
						                             </div>
					                             </tpl>
                                                </Html>
                                            </Template>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxQD_Store" AutoLoad="false" OnRefreshData="cbxQD_Store_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader>
                                                            <Fields>
                                                                <ext:RecordField Name="ParamName" />
                                                                <ext:RecordField Name="Value" />
                                                                <ext:RecordField Name="Description" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Expand Handler="if(cbxQD.store.getCount()==0) cbxQD_Store.reload();" />
                                                <Select Handler="if(hdfMaCB.getValue()== '') {ucChooseEmployee1_wdChooseUser.show();} " />
                                            </Listeners>
                                            <DirectEvents>
                                                <Select OnEvent="FillRePort">
                                                    <EventMask ShowMask="true" />
                                                </Select>
                                            </DirectEvents>
                                        </ext:ComboBox>--%>
                                        <ext:ComboBox runat="server" Editable="false" ID="cbxBC" DisplayField="ReportName" ValueField="ID"
                                                AnchorHorizontal="100%" ItemSelector="div.list-item">
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
                                                    <Select Handler="hdfmaBC.setValue(cbxBC.getValue());if(hdfMaCB.getValue()== '') {ucChooseEmployee1_wdChooseUser.show();}" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Select OnEvent="FillRePort">
                                                        <EventMask ShowMask="true" />
                                                    </Select>
                                                </DirectEvents>
                                            </ext:ComboBox>
                                        <ext:ToolbarSpacer runat="server" ID="ToolbarSpacer2" Width="5" />
                                        <ext:Button runat="server" Text="Chọn nhân viên" Icon="User">
                                            <Listeners>
                                                <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="In ấn" Icon="Printer">
                                            <DirectEvents>
                                                <Click OnEvent="Printer_Click">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:HtmlEditor Region="Center" runat="server" ID="htmlEditor">
                                </ext:HtmlEditor>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
        <div>
        </div>
    </form>
</body>
</html>
