<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKyDongMoiBaoHiem.aspx.cs"
    Inherits="Modules_BaoHiem_DangKyDongMoiBaoHiem" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js"></script>
    <style type="text/css">
        div#Panel1-xsplit
        {
            border: 1px solid #98C0F4;
            border-bottom: none;
            border-top: none;
        }
        
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/LocTheoPhongBan.png) no-repeat center !important;
        }
        div#grpDangKyDongMoiBaoHiem .x-grid3-cell-inner, .x-grid3-hd-inner
        {
            white-space: nowrap !important;
        }
    </style>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var keyEnterPress = function (f, e) {
            if (e.getKey() == e.ENTER) {
                //                grpDangKyDongMoiBaoHiem_store.reload();
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var CheckSelectedRows = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn bản ghi nào!');
                return false;
            }
            return true;
        }
        var checkInputChonThangDangKy = function () {
            if (cbxThang.getValue() == '') {
                alert('Bạn chưa chọn tháng đăng ký');
                cbxThang.focus();
                return false;
            }
            if (spnNam.getValue == '') {
                alert('Bạn chưa chọn năm đăng ký');
                spnNam.focus();
                return false;
            }
            return true;
        }
        var ThemNhanVien = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn đang lưu những người được chọn để quản lý trong phân hệ bảo hiểm. Bạn có muốn tiếp tục?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.commitChanges();
                        Ext.net.DirectMethods.ThemNhanVienVaoDongBaoHiem(r.data.MaNhanVien,
                                                                        r.data.MaChucVu,
                                                                        r.data.DangDongBHXH,
                                                                        r.data.DangDongBHYT,
                                                                        r.data.DangDongBHTN,
                                                                        r.data.LuongBaoHiem,
                                                                        r.data.PhuCapCV,
                                                                        r.data.PhuCapTNN,
                                                                        r.data.PhuCapTNVK,
                                                                        r.data.PhuCapKhac
                            );
                    }
                }
            }
            );
            //grid.getRowEditor().stopEditing();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfThang" />
        <ext:Hidden runat="server" ID="hdfNam" />
        <ext:Store ID="grpDangKyDongMoiBaoHiem_store" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerDangKyDongMoi.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <%--                <ext:Parameter Name="Thang" Value="hdfThang.getValue()" Mode="Raw" />
                <ext:Parameter Name="Nam" Value="hdfNam.getValue()" Mode="Raw" />--%>
                <ext:Parameter Name="LoaiHD" Value="chkLocTheoLoaiHD.getValue()" Mode="Raw" />
                <%--                <ext:Parameter Name="NgayDiLam" Value="chkLocTheoSoNgayDiLam.getValue()" Mode="Raw" />--%>
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaNhanVien">
                    <Fields>
                        <ext:RecordField Name="MaNhanVien" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="TenBoPhan" />
                        <ext:RecordField Name="MaBoPhan" />
                        <ext:RecordField Name="MaChucVu" />
                        <ext:RecordField Name="TenChucVu" />
                        <ext:RecordField Name="LuongBaoHiem" />
                        <ext:RecordField Name="PhuCapCV" />
                        <ext:RecordField Name="PhuCapTNN" />
                        <ext:RecordField Name="PhuCapTNVK" />
                        <ext:RecordField Name="PhuCapKhac" />
                        <ext:RecordField Name="NgayBatDauHopDong" />
                        <ext:RecordField Name="DangDongBHXH" />
                        <ext:RecordField Name="DangDongBHYT" />
                        <ext:RecordField Name="DangDongBHTN" />
                        <ext:RecordField Name="TenLoaiHopDong" />
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdChonThangDangKy" Title="Tháng đăng ký với cơ quan bảo hiểm"
            Modal="true" Layout="FormLayout" Width="350" Padding="6" Constrain="true" Hidden="true"
            Icon="Add" AutoHeight="true">
            <Items>
                <ext:Container runat="server" ID="cts1" Layout="ColumnLayout" Height="30" >
                    <Items>
                        <ext:Container runat="server" ID="Container1" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="70">
                            <Items>
                                <ext:ComboBox runat="server" FieldLabel="Tháng" Editable="false" AnchorHorizontal="98%"
                                    SelectedIndex="0" ID="cbxThang">
                                    <Items>
                                        <ext:ListItem Text="Tháng 1" Value="1" />
                                        <ext:ListItem Text="Tháng 2" Value="2" />
                                        <ext:ListItem Text="Tháng 3" Value="3" />
                                        <ext:ListItem Text="Tháng 4" Value="4" />
                                        <ext:ListItem Text="Tháng 5" Value="5" />
                                        <ext:ListItem Text="Tháng 6" Value="6" />
                                        <ext:ListItem Text="Tháng 7" Value="7" />
                                        <ext:ListItem Text="Tháng 8" Value="8" />
                                        <ext:ListItem Text="Tháng 9" Value="9" />
                                        <ext:ListItem Text="Tháng 10" Value="10" />
                                        <ext:ListItem Text="Tháng 11" Value="11" />
                                        <ext:ListItem Text="Tháng 12" Value="12" />
                                    </Items>
                                    <Listeners>
                                        <%--<Select Handler="hdfThang.setValue(cbxThang.getValue()); grpDangKyDongMoiBaoHiem_store.reload();" />--%>
                                    </Listeners>
                                    <%--  <DirectEvents>
                                                            <Select OnEvent="cbxThang_Selected" />
                                                        </DirectEvents>--%>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container2" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="70">
                            <Items>
                                <ext:SpinnerField ID="spnNam" runat="server" LabelWidth="30" MinValue="1900" AnchorHorizontal="100%"
                                    FieldLabel="Năm" MaxValue="2100">
                                    <Listeners>
                                        <%--<Spin Handler="hdfNam.setValue(spnNam.getValue()); grpDangKyDongMoiBaoHiem_store.reload();" />--%>
                                    </Listeners>
                                </ext:SpinnerField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDangKyDongBH" Text="Đăng ký">
                    <Listeners>
                        <Click Handler="if (CheckSelectedRows(grpDangKyDongMoiBaoHiem) && checkInputChonThangDangKy()) {ThemNhanVien(grpDangKyDongMoiBaoHiem,grpDangKyDongMoiBaoHiem_store);}" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnClosewdChonThangDangKy" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="wdChonThangDangKy.hide()" />
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
                                <ext:GridPanel runat="server" ID="grpDangKyDongMoiBaoHiem" StoreID="grpDangKyDongMoiBaoHiem_store"
                                    Border="false" AnchorHorizontal="100%" Region="Center">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button runat="server" ID="btnLuu" Icon="Disk" Text="Đăng ký đóng mới">
                                                    <Listeners>
                                                        <Click Handler="if (CheckSelectedRows(grpDangKyDongMoiBaoHiem)) {wdChonThangDangKy.show();}" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:ToolbarSpacer Width="5" />
                                                <ext:ToolbarSeparator />
                                                <ext:Checkbox runat="server" ID="chkLocTheoLoaiHD" Checked="false" BoxLabel="Lọc theo ĐK loại hợp đồng">
                                                    <ToolTips>
                                                        <ext:ToolTip Draggable="true" ID="tl" runat="server" Header="true" Frame="true" Title="Lọc theo điều kiện loại hợp đồng"
                                                            Html="Lọc những cán bộ có loại hợp đồng được đóng bảo hiểm(khai báo ở form quy định chung)"
                                                            Width="300" />
                                                    </ToolTips>
                                                    <Listeners>
                                                        <Check Handler=" #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:Checkbox>
                                                <ext:ToolbarSpacer Width="5" />
                                                <ext:Checkbox runat="server" ID="chkLocTheoSoNgayDiLam" Checked="false" BoxLabel="Lọc theo ĐK số ngày đi làm"
                                                    Hidden="true">
                                                    <ToolTips>
                                                        <ext:ToolTip Draggable="true" ID="tl2" runat="server" Header="true" Frame="true"
                                                            Title="Lọc theo điều kiện số ngày đi làm tháng trước" Html="Lọc những cán bộ có số ngày đi làm tháng trước >15 ngày"
                                                            Width="300" />
                                                    </ToolTips>
                                                    <Listeners>
                                                        <Check Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:Checkbox>
                                                <ext:ToolbarSpacer Width="20">
                                                </ext:ToolbarSpacer>
                                                <ext:ToolbarFill runat="server" ID="tbfill" />
                                                <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Tìm kiếm theo mã hoặc theo tên"
                                                    ID="txtSearch">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <KeyPress Fn="keyEnterPress" />
                                                        <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                                <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                    <Listeners>
                                                        <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn ColumnID="colSTT" Header="STT" Width="30" Locked="true" />
                                            <ext:Column ColumnID="colMaCanBo" Width="100" DataIndex="MaNhanVien" Header="Mã cán bộ"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="colTenCanBo" Width="200" DataIndex="HoTen" Header="Họ tên"
                                                Locked="true">
                                            </ext:Column>
                                            <ext:Column ColumnID="colBoPhan" Width="200" DataIndex="TenBoPhan" Header="Bộ phận">
                                            </ext:Column>
                                            <ext:Column ColumnID="colChucVu" Width="160" DataIndex="TenChucVu" Header="Chức vụ">
                                            </ext:Column>
                                            <ext:Column ColumnID="colLuongDongBaoHiem" Width="100" DataIndex="LuongBaoHiem" Header="Lương đóng BH"
                                                Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapCV" Width="100" DataIndex="PhuCapCV" Header="Phụ cấp CV">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapTNN" Width="100" DataIndex="PhuCapTNN" Header="Phụ cấp TNN">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapTNVK" Width="110" DataIndex="PhuCapTNVK" Header="Phụ cấp TNVK">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="colPhuCapKhac" Width="100" DataIndex="PhuCapKhac" Header="Phụ cấp khác">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:DateColumn ColumnID="colNgayHieuLuc" Width="100" DataIndex="NgayBatDauHopDong"
                                                Header="Ngày hiệu lực" Format="dd/MM/yyyy" Align="Center">
                                            </ext:DateColumn>
                                            <ext:CheckColumn ColumnID="colBHXH" Width="50" DataIndex="DangDongBHXH" Header="BHXH">
                                            </ext:CheckColumn>
                                            <ext:CheckColumn ColumnID="colBHYT" Width="50" DataIndex="DangDongBHYT" Header="BHYT">
                                            </ext:CheckColumn>
                                            <ext:CheckColumn ColumnID="colBHTN" Width="50" DataIndex="DangDongBHTN" Header="BHTN">
                                            </ext:CheckColumn>
                                            <ext:Column ColumnID="colLoaiHopDong" Width="240" DataIndex="TenLoaiHopDong" Header="Loại hợp đồng">
                                            </ext:Column>
                                            <ext:DateColumn ColumnID="colNgayBatDauHopDong" Width="130" DataIndex="NgayBatDauHopDong"
                                                Header="Ngày bắt đầu hợp đồng" Format="dd/MM/yyyy" Align="Center">
                                            </ext:DateColumn>
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
                                                    <SelectedItem Value="30" />
                                                    <Listeners>
                                                        <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <View>
                                        <ext:LockingGridView runat="server" ForceFit="false" ID="lk1">
                                        </ext:LockingGridView>
                                    </View>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" EnableViewState="true" ID="checkBoxSelection"
                                            ColumnPosition="0">
                                            <Listeners>
                                                <RowSelect Handler="btnLuu.enable();" />
                                            </Listeners>
                                        </ext:CheckboxSelectionModel>
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
