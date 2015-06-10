<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucQuanLyBangPhanCa.ascx.cs" Inherits="Modules_ChamCongDoanhNghiep_ucQuanLyBangPhanCa" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    var StartEdit = function (grid) {
        try {
            var record = grid.getSelectionModel().getSelected();
            var index = grid.store.indexOf(record);
            grid.getRowEditor().stopEditing();
            grid.getSelectionModel().selectRow(index);
            grid.getRowEditor().startEditing(index);
        } catch (e) {

        }
    }
</script>
<ext:Hidden runat="server" ID="hdfMaDonVi" />
<ext:Window runat="server" ID="wdQuanLyBangPhanCa" Constrain="true" Resizable="false"
    Layout="BorderLayout" Padding="0" Width="600" Height="350" Hidden="true" Modal="true"
    Title="Quản lý bảng phân ca">
    <Items>
        <ext:GridPanel
            ID="GridPanel1"
            runat="server"
            StripeRows="true"
            Border="false"
            Region="Center"
            AutoExpandColumn="Company">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" Text="Xóa" Disabled="true" ID="btnXoa" Icon="Delete">
                            <DirectEvents>
                                <Click OnEvent="btnXoa_Click">
                                    <EventMask ShowMask="true" Msg="Đang xóa dữ liệu" />
                                    <Confirmation Title="Cảnh báo" ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không ?" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" Text="Sửa" Disabled="true" ID="btnSua" Icon="Pencil">
                            <Listeners>
                                <Click Handler="StartEdit(#{GridPanel1});" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Store>
                <ext:Store ID="Store1" AutoLoad="false" runat="server" GroupField="Nam" GroupDir="DESC">
                    <Proxy>
                        <ext:HttpProxy Json="true" Method="GET" Url="Handler/QuanLyBangPhanCaHandler.ashx" />
                    </Proxy>
                    <AutoLoadParams>
                        <ext:Parameter Name="start" Value="={0}" />
                        <ext:Parameter Name="limit" Value="={30}" />
                    </AutoLoadParams>
                    <BaseParams>
                        <ext:Parameter Name="maDonVi" Mode="Raw" Value="hdfMaDonVi.getValue()" />
                    </BaseParams>
                    <Reader>
                        <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                            <Fields>
                                <ext:RecordField Name="ID" />
                                <ext:RecordField Name="Nam" />
                                <ext:RecordField Name="TenBangPhanCa" />
                                <ext:RecordField Name="SoNguoi" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel1" runat="server">
                <Columns>
                    <ext:RowNumbererColumn Header="STT" Width="35" />
                    <ext:Column ColumnID="Company" Header="Tên bảng phân ca" Width="160" DataIndex="TenBangPhanCa">
                        <Editor>
                            <ext:TextField runat="server" ID="txtTenBangPhanCa" />
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="Năm" Width="55" Align="Right" DataIndex="Nam" ColumnID="colNam">
                    </ext:Column>
                    <ext:Column Header="Số người có trong<br/> bảng phân ca" Width="100" DataIndex="SoNguoi" Align="Center">
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <View>
                <ext:GroupingView runat="server" ID="grpview1"></ext:GroupingView>
            </View>
            <Plugins>
                <ext:RowEditor ID="RowEditor1" runat="server" SaveText="Cập nhật" CancelText="Hủy">
                    <Listeners>
                        <AfterEdit Handler="#{DirectMethods}.Save(#{RowSelectionModel1}.getSelected().id,#{txtTenBangPhanCa}.getValue());#{Store1}.commitChanges();" />
                    </Listeners>
                </ext:RowEditor>
            </Plugins>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                    <Listeners>
                        <RowSelect Handler="#{btnXoa}.enable();#{btnSua}.enable();" />
                    </Listeners>
                </ext:RowSelectionModel>
            </SelectionModel>
            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                            <Items>
                                <ext:ListItem Text="10" />
                                <ext:ListItem Text="20" />
                                <ext:ListItem Text="30" />
                            </Items>
                            <SelectedItem Value="30" />
                            <Listeners>
                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:PagingToolbar>
            </BottomBar>
        </ext:GridPanel>
    </Items>
    <Listeners>
        <BeforeShow Handler="#{Store1}.reload();" />
    </Listeners>
    <Buttons>
        <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdQuanLyBangPhanCa}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
