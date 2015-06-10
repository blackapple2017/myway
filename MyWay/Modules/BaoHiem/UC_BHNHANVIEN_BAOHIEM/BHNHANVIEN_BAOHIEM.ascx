<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BHNHANVIEN_BAOHIEM.ascx.cs"
    Inherits="Modules_BaoHiem_UC_BHNHANVIEN_BAOHIEM_BHNHANVIEN_BAOHIEM" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    var store3;
    var SetStore = function (s3) {
        store3 = s3;
    }
    var enterKeyToSearch = function (f, e) {
        try {
            if (e.getKey() == e.ENTER) {
              store3.reload();
            }
        } catch (e) {

        }
    }
    var btnAddEmployee_CheckSelectRow = function (gridPanel) {
        if (gridPanel.getSelectionModel().getCount() == 0) {
            Ext.Msg.alert("Thông báo", "Bạn phải chọn một nhân viên !");
            return false;
        }
        return true;
    }
</script>
<ext:Hidden runat="server" ID="hdfMaDonVi" />
<ext:Hidden runat="server" ID="hdfMaPhong" />
<ext:Hidden runat="server" ID="hdfMaTo" />
<ext:Hidden runat="server" ID="hdfLoadDatafromHoso" />
<ext:Window Modal="true" Resizable="false" Hidden="true" runat="server" ID="wdChooseUser"
    Constrain="true" Title="Chọn danh sách nhân viên" Icon="UserAdd" Width="600"
    Padding="6" AutoHeight="true">
    <Items>
        <ext:Container ID="Container1" runat="server" Height="330" Layout="FormLayout">
            <Items>
                <ext:GridPanel runat="server" ID="EmployeeGrid" Icon="UserAdd" Header="false" Title="Danh sách nhân viên"
                    AutoExpandColumn="HoTen" AnchorHorizontal="100%" Height="330">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tbEmployeeGrid">
                            <Items>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <ext:TextField runat="server" EnableKeyEvents="true" ID="txtFullName" EmptyText="Nhập tên nhân viên">
                                    <Listeners>
                                        <KeyPress Fn="enterKeyToSearch" />
                                    </Listeners>
                                </ext:TextField>
                                <ext:Button ID="Button3" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                    <Listeners>
                                        <Click Handler="#{Store3}.reload();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel runat="server" ID="chkEmployeeRowSelection" />
                        
                    </SelectionModel>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="30" Header="STT" />
                            <ext:Column Header="Mã CB" Width="60" DataIndex="MaNhanVien">
                            </ext:Column>
                            <ext:Column Header="Họ tên" ColumnID="HoVaTen" DataIndex="HoTen">
                            </ext:Column>
                            <ext:DateColumn Header="Ngày sinh" Format="dd/MM/yyyy" DataIndex="NgaySinh">
                            </ext:DateColumn>
                            <ext:Column Header="Giới tính" DataIndex="GioiTinh">
                            </ext:Column>
                            <ext:Column Header="Số CMTND" DataIndex="SoCMTND">
                            </ext:Column>
                           
                        </Columns>
                    </ColumnModel>
                    <Store>
                        <ext:Store ID="Store3" ShowWarningOnFailure="false" SkipIdForNewRecords="false" runat="server">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="Handler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="limit" Value="={50}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="GetDataFromHoSo" Value="#{hdfLoadDatafromHoso}.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" IDProperty="MaNhanVien" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="MaNhanVien"  />
                                        <ext:RecordField Name="HoTen" />
                                        <ext:RecordField Name="NgaySinh" />
                                        <ext:RecordField Name="GioiTinh" />
                                        <ext:RecordField Name="SoCMTND" />
                                        <ext:RecordField Name="DiaChiLienHe" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <SaveMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                            PageSize="50" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                            DisplayMsg="{0}-{1} / tổng số {2} dòng" runat="server">
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Container>
    </Items>
    <Buttons>
        <ext:Button runat="server" Text="Đồng ý" ID="btnAddEmployee" Icon="Accept">
            <Listeners>
                <Click Handler="return btnAddEmployee_CheckSelectRow(#{EmployeeGrid});" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnAddEmployee_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button4" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdChooseUser}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="SetStore(#{Store3});" />
        <Hide Handler="#{EmployeeGrid}.getSelectionModel().clearSelections();" />
    </Listeners>
</ext:Window>
