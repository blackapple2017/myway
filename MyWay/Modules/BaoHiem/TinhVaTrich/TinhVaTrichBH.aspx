<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TinhVaTrichBH.aspx.cs" Inherits="Modules_BaoHiem_TinhVaTrichBH" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var EnterTinhVaTrichBaoHiem = function (f, e) {
            if (e.getKey() == e.ENTER) {
                grpTinhVaTrichBaoHiem_store.reload();
            }
        }
        var RenderThangNam = function (value, p, record) {
            if (value == null || value.length == 0)
                return "";
            var nam = parseInt(value / 12);
            var sothang = value % 12;
            var rs = sothang + "/" + nam;
            return "<span style='float:right;'>" + rs + "</span>"; // + " VNĐ";
        }
        var SetMonthYear = function () {
            if (new Date().getMonth != 0) {
                spnNam.setValue(new Date().getFullYear());
                cbxThang.setValue(new Date().getMonth());
            }
            else {
                spnNam.setValue(new Date().getFullYear() - 1);
                cbxThang.setValue(12);
            }
        }
        var btnsuaClick = function (grid, store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                nfNVBHXH.setValue(r.data.SoTienNVBHXH);
                nfNVBHYT.setValue(r.data.SoTienNVBHYT);
                nfNVBHTN.setValue(r.data.SoTienNVBHTN);
                nfDVBHXH.setValue(r.data.SoTienDVBHXH);
                nfDVBHYT.setValue(r.data.SoTienDVBHYT);
                nfDVBHTN.setValue(r.data.SoTienDVBHTN);

            }
            wdUpdate.show();
        }
        var submitValue = function (grid, hiddenFormat) {
            hiddenFormat.setValue(Ext.encode(grpTinhVaTrichBaoHiem_store.getRecordsValues({ filterField: function (r, name, value) { return name != 'ID'; } })));
            grpTinhVaTrichBaoHiem_store.submitData(true);
        }
        var GetBooleanIcon1 = function (value, p, record) {
            var sImageCheck = "<img src='../../../Resource/images/check.png' />";
            var sImageUnCheck = "<img src='../../../Resource/images/uncheck.gif' />";
            if (value == "1") {
                return sImageCheck;
            } else if (value == "0") {
                return sImageUnCheck;
            }
            return "";
        }

        var setEnableButton = function () {
            btnTinhVaTrichLuong.enable();
            btnsua.enable();
            btnExportExcel.enable();
            chkLocQuanLyBaoHiem.enable();
        }
        var setDisableButton = function () {
            btnTinhVaTrichLuong.disable();
            btnsua.disable();
            btnExportExcel.enable();
            chkLocQuanLyBaoHiem.enable();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfMa" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden ID="hdfIDBangLuong" runat="server" />
        <ext:Hidden runat="server" ID="hdfDaKhoa" />
        <ext:Hidden ID="FormatType" runat="server" />
        <ext:Store ID="grpTinhVaTrichBaoHiem_store" runat="server" AutoLoad="true" ShowWarningOnFailure="true" OnSubmitData="grpTinhVaTrichBaoHiem_store_Submit">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerTinhVaTrichBaoHiem.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="IDBangLuong" Value="hdfIDBangLuong.getValue()" Mode="Raw" />
                <ext:Parameter Name="LocQuanLyBaoHiem" Value="chkLocQuanLyBaoHiem.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="SoTienDVBHTN" />
                        <ext:RecordField Name="SoTienDVBHXH" />
                        <ext:RecordField Name="SoTienDVBHYT" />
                        <ext:RecordField Name="SoTienNVBHTN" />
                        <ext:RecordField Name="SoTienNVBHXH" />
                        <ext:RecordField Name="SoTienNVBHYT" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="MaNhanVien" />
                        <ext:RecordField Name="LuongDongBH" />
                        <ext:RecordField Name="TongTienDongBHNV" />
                        <ext:RecordField Name="TongTienDongBHDV" />
                        <ext:RecordField Name="TongCong" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
            <Listeners>
                <Load Handler="btnsua.disable();" />
            </Listeners>
        </ext:Store>
        <ext:Window Modal="true" Hidden="true" runat="server" ID="wdQuanLyBangTrichLuong"
            Constrain="true" Title="Quản lý tính và trích bảo hiểm" Icon="Table" Layout="FormLayout"
            Width="777" AutoHeight="true">
            <Items>
                <ext:GridPanel ID="grpQuanLyTrichBaoHiem" runat="server" StripeRows="true" Border="false" AutoExpandColumn="colTenBangLuong"
                    AnchorHorizontal="100%" Header="false" Height="350" Title="Chọn bảng lương">
                    <Store>
                        <ext:Store ID="grpQuanLyTrichBaoHiemStore" AutoLoad="true" AutoSave="true" ShowWarningOnFailure="false"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" runat="server">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="HandlerQuanLyBangTinhVaTrich.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="IDBangLuong" Root="Data" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="IDBangLuong" />
                                        <ext:RecordField Name="TenBangLuong" />
                                        <ext:RecordField Name="ThangNam" />
                                        <ext:RecordField Name="SoNhanVien" />
                                        <ext:RecordField Name="TienDonViTrich" />
                                        <ext:RecordField Name="TienNhanVienTrich" />
                                        <ext:RecordField Name="TongTien" />
                                        <ext:RecordField Name="DaKhoa" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel3" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="30" />
                            <ext:Column ColumnID="colTenBangLuong" DataIndex="TenBangLuong" Header="Tên bảng lương" Width="120" />
                            <ext:Column ColumnID="colThangNam" DataIndex="ThangNam" Header="Tháng" Width="60">
                                <Renderer Fn="RenderThangNam" />
                            </ext:Column>
                            <ext:Column ColumnID="colSoNhanVien" DataIndex="SoNhanVien" Header="Số nhân viên"
                                Align="Right" Width="85">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="colTienNhanVienTrich" DataIndex="TienNhanVienTrich" Header="Số tiền nhân viên trích vào lương"
                                Align="Right" Width="110">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="colTienDonViTrich" Header="Số tiền đơn vị trích vào lương"
                                DataIndex="TienDonViTrich" Width="90">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="colTongTien" Header="Tổng số tiền trích" DataIndex="TongTien"
                                Width="100">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="colDaKhoa" Header="Đã khóa" DataIndex="DaKhoa" Width="50">
                                <Renderer Fn="GetBooleanIcon1" />
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelBangTrichLuong" runat="server">
                            <Listeners>
                                <RowSelect Handler="hdfDaKhoa.setValue(RowSelectionModelBangTrichLuong.getSelected().data.DaKhoa);
                                    if(hdfDaKhoa.getValue()=='false') setEnableButton(); else setDisableButton(); " />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10">
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="Page size:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="5" />
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="20" />
                                    </Items>
                                    <SelectedItem Value="10" />
                                    <Listeners>
                                        <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYQuanLyBangChamCong" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="hdfIDBangLuong.setValue(RowSelectionModelBangTrichLuong.getSelected().id);grpDangKyDongMoiBaoHiem.setTitle(RowSelectionModelBangTrichLuong.getSelected().data.TenBangLuong);  if(hdfIDBangLuong.getValue()>0){ wdQuanLyBangTrichLuong.hide();grpTinhVaTrichBaoHiem_store.reload();} else  alert('Bạn chưa chọn bảng lương');" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnClosewdQuanLyBangChamCong" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdQuanLyBangTrichLuong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{grpQuanLyTrichBaoHiemStore}.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdUpdate" Modal="true" Title="Sửa trích bảo hiểm"
            Icon="Pencil" Constrain="false" Width="478" Padding="6" Hidden="true" AutoHeight="true">
            <Items>
                <ext:Container runat="server" ID="containcha" Layout="ContainerLayout">
                    <Items>
                        <ext:FieldSet runat="server" ID="panel12" Title="Trích bảo hiểm cho nhân viên">
                            <Items>
                                <ext:Container runat="server" ID="containcon" Layout="ColumnLayout" ColumnWidth="0.5"
                                    Height="50">
                                    <Items>
                                        <ext:NumberField runat="server" MaskRe="/[0-9]/" StyleSpec="text-align:right" FieldLabel="Tiền đóng BHXH" ID="nfNVBHXH" LabelAlign="Top">
                                        </ext:NumberField>
                                        <ext:NumberField runat="server" MaskRe="/[0-9]/" StyleSpec="text-align:right" FieldLabel="Tiền đóng BHYT" ID="nfNVBHYT" LabelAlign="Top">
                                        </ext:NumberField>
                                        <ext:NumberField runat="server" MaskRe="/[0-9]/" StyleSpec="text-align:right" FieldLabel="Tiền đóng BHTN" LabelAlign="Top" ID="nfNVBHTN">
                                        </ext:NumberField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet runat="server" ID="FieldSet1" Title="Trích bảo hiểm cho đơn vị">
                            <Items>
                                <ext:Container runat="server" ID="Container2" Layout="ColumnLayout" ColumnWidth="0.5"
                                    Height="50">
                                    <Items>
                                        <ext:NumberField runat="server" MaskRe="/[0-9]/" StyleSpec="text-align:right" FieldLabel="Tiền đóng BHXH" ID="nfDVBHXH" LabelAlign="Top">
                                        </ext:NumberField>
                                        <ext:NumberField runat="server" MaskRe="/[0-9]/" StyleSpec="text-align:right" FieldLabel="Tiền đóng BHYT" ID="nfDVBHYT" LabelAlign="Top">
                                        </ext:NumberField>
                                        <ext:NumberField runat="server" MaskRe="/[0-9]/" StyleSpec="text-align:right" FieldLabel="Tiền đóng BHTN" LabelAlign="Top" ID="nfDVBHTN">
                                        </ext:NumberField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btupdate" Icon="Disk" Text="Cập nhật">
                    <DirectEvents>
                        <Click OnEvent="bt_update">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btndonglai" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="#{wdUpdate}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel Height="200" runat="server" Border="false" AnchorVertical="100%" Layout="BorderLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grpDangKyDongMoiBaoHiem" StoreID="grpTinhVaTrichBaoHiem_store"
                                    Border="false" AnchorHorizontal="100%" Region="Center" StripeRows="true" Title="Bạn chưa chọn bảng lương">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button runat="server" ID="btnThangTrichBaoHiem" Text="Chọn bảng tính lương"
                                                    Icon="Table">
                                                    <Listeners>
                                                        <Click Handler="grpQuanLyTrichBaoHiemStore.reload(); wdQuanLyBangTrichLuong.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:ToolbarSpacer Width="10" />
                                                <ext:Button runat="server" ID="btnsua" Icon="Pencil" Text="Sửa" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="btnsuaClick(grpDangKyDongMoiBaoHiem,grpTinhVaTrichBaoHiem_store);" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnTinhVaTrichLuong" Text="Tính và trích lương" Icon="Calculator" Disabled="true">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnTinhVaTrichLuongClick">
                                                            <EventMask Msg="Đang xử lý..." ShowMask="true" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnExportExcel" Icon="PageExcel" Text="Xuất ra Excel">
                                                    <Listeners>
                                                        <Click Handler="alert('Phiên bản dùng thử không hỗ trợ chức năng này'); submitValue(#{grpDangKyDongMoiBaoHiem}, #{FormatType});" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:ToolbarSpacer Width="10" />
                                                <ext:Checkbox runat="server" ID="chkLocQuanLyBaoHiem" Checked="false" BoxLabel="Lọc những người được quản lý bảo hiểm" Disabled="true">
                                                    <Listeners>
                                                        <Check Handler=" #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:Checkbox>
                                                <ext:ToolbarFill runat="server" ID="tbfill" />
                                                <ext:TextField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                                    ID="txtSearch">
                                                    <Listeners>
                                                        <KeyPress Fn="EnterTinhVaTrichBaoHiem" />
                                                    </Listeners>
                                                </ext:TextField>
                                                <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                    <Listeners>
                                                        <Click Handler="#{grpTinhVaTrichBaoHiem_store}.reload();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="35" Locked="true">
                                            </ext:RowNumbererColumn>
                                            <ext:Column ColumnID="colMaCanBo" Width="100" DataIndex="MaNhanVien" Header="Mã nhân viên"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="colTenCanBo" Width="150" DataIndex="HoTen" Header="Tên nhân viên"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="LuongDongBH" Width="105" DataIndex="LuongDongBH" Header="Lương bảo hiểm"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="SoTienNVBHXH" Width="111" DataIndex="SoTienNVBHXH" Header="Số tiền nhân viên đóng BHXH"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="SoTienNVBHYT" Width="111" DataIndex="SoTienNVBHYT" Header="Số tiền nhân viên đóng BHYT"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="SoTienNVBHTN" Width="111" DataIndex="SoTienNVBHTN" Header="Số tiền nhân viên đóng BHTN"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="SoTienDVBHXH" Width="111" DataIndex="SoTienDVBHXH" Header="Số tiền đơn vị đóng BHXH"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="SoTienDVBHYT" Width="111" DataIndex="SoTienDVBHYT" Header="Số tiền đơn vị đóng BHYT"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="SoTienDVBHTN" Width="111" DataIndex="SoTienDVBHTN" Header="Số tiền đơn vị đóng BHTN"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="TongTienDongBHNV" Width="111" DataIndex="TongTienDongBHNV"
                                                Header="Tổng tiền đóng bảo hiểm NV" Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="TongTienDongBHDV" Width="111" Align="Right" DataIndex="TongTienDongBHDV"
                                                Header="Tổng tiền đóng bảo hiểm ĐV">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="Tổng cộng" Width="150" DataIndex="TongCong" Align="Right" Header="Tổng tiền đóng bảo hiểm">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                            PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                            DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                            <Items>
                                                <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                                    <Items>
                                                        <ext:ListItem Text="15" />
                                                        <ext:ListItem Text="30" />
                                                        <ext:ListItem Text="50" />
                                                        <ext:ListItem Text="70" />
                                                        <ext:ListItem Text="100" />
                                                    </Items>
                                                    <Listeners>
                                                        <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <View>
                                        <ext:LockingGridView runat="server" ID="lk1">
                                        </ext:LockingGridView>
                                    </View>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="RowSelection1">
                                            <Listeners>
                                                <RowSelect Handler="#{hdfMa}.setValue(#{RowSelection1}.getSelected().data.ID);  if(hdfDaKhoa.getValue()=='false') setEnableButton(); else setDisableButton();" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <Listeners>
                                        <RowDblClick Handler="if(hdfDaKhoa.getValue()=='false') setEnableButton(); else {setDisableButton();alert('Bảng lương đã bị khóa');}" />
                                    </Listeners>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
