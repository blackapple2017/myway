<%@ Page Language="C#" AutoEventWireup="true" CodeFile="NhanVienNghiDaiNgay.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_NhanVienNghiDaiNgay" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .search-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }
        #grpNghiDaiNgay
        {
            border-bottom: 1px solid #99bbe8 !important;
        }
        #hsImage
        {
            border: 1px solid #99bbe8 !important;
        }
        .search-item h3
        {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }
        
        .search-item h3 span
        {
            float: right;
            font-weight: normal;
            margin: 0 0 5px 5px;
            width: 100px;
            display: block;
            clear: none;
        }
        
        p
        {
            width: 650px;
        }
        
        .ext-ie .x-form-text
        {
            position: static !important;
        }
        
        .panelGeneralInformation .x-panel-body
        {
            background: #DFE8F6 !important;
        }
    </style>
    <script type="text/javascript">
        var CheckChonNhieuDong = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn dòng nào');
                return false;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một dòng');
                return false;
            }
            return true;
        }

        var resetWindowsThemSuaNghiDaiNgay = function () {
            cbonhanvien.reset(); txtLyDoNghi.reset();
            cbbDongBH.reset(); dfNgayNopDon.reset();
            dfNgayNopDon.setMaxValue(); dfNgayNopDon.setMinValue();
            dfNgayDangKyNghi.reset(); dfNgayDangKyNghi.setMaxValue();
            dfNgayDangKyNghi.setMinValue(); dfNgayDiLamLai.reset();
            dfNgayDiLamLai.setMaxValue(); dfNgayDiLamLai.setMinValue();
            dfNgayNghiThucTe.reset(); dfNgayNghiThucTe.setMaxValue();
            dfNgayNghiThucTe.setMinValue(); dfNgayDiLamLaiThucTe.reset();
            dfNgayDiLamLaiThucTe.setMaxValue(); dfNgayDiLamLaiThucTe.setMinValue();
            txtGhiChu.reset();

        }
        var resetPanelThongTin = function () {
            txtMaCB.reset(); txtFullName.reset(); txtBiDanh.reset();
            txtDTCoQuan.reset(); txtDTNha.reset(); txtSoCMND.reset();
            txtNgayCapCMND.reset(); txtNoiCapCMND.reset(); txtDiaChi.reset();
            txtNgayThuViec.reset(); txtNgayNhan.reset(); txtNgach.reset();
            txtLoaiHD.reset(); grpNghiDaiNgayStore.reload();
        }
        var CheckInput = function () {
            if (hdfPRKEYHOSO.getValue() == '' || !cbonhanvien.getValue()) {
                alert('Bạn chưa chọn nhân viên nào');
                cbonhanvien.focus();
                return false;
            }
            if (!cbbDongBH.getValue()) {
                alert("Bạn chưa chọn trạng thái đóng bảo hiểm");
                cbbDongBH.focus();
                return false;
            }
            if (!dfNgayNopDon.getValue()) {
                alert("Bạn chưa chọn ngày nộp đơn");
                dfNgayNopDon.focus();
                return false;
            }
            if (!dfNgayDangKyNghi.getValue()) {
                alert("Bạn chưa chọn ngày đăng ký nghỉ");
                dfNgayNopDon.focus();
                return false;
            }
            if (!dfNgayDiLamLai.getValue()) {
                alert("Bạn chưa chọn ngày đi làm lại");
                dfNgayNopDon.focus();
                return false;
            }
            return true;
        }
        var RemoveItemOnGrid = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.remove(r);
                        Store.commitChanges();
                        Ext.net.DirectMethods.DeleteRecord(r.data.ID);
                        //btnEdit.disable();
                        //btnDelete.disable();
                    }
                }
            });
        }
        var enterKeyPressSearchKey = function (f, e) {
            if (e.getKey() == e.ENTER) {
                grpNghiDaiNgay.reload();
                hdfRecordID.setValue('');
                hdfPRKEYHOSO.setValue('');
                resetPanelThongTin();
            }
        }
    </script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="RM" runat="server" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfPRKEYHOSO" />
        <ext:Menu runat="server" ID="RowContextMenu">
            <Items>
                <ext:MenuItem ID="Button1" runat="server" Text="Thêm nhân viên" Icon="UserAdd">
                    <Listeners>
                        <Click Handler="wdThemSuaNghiDaiNgay.show();btnCapNhatThem.show();btnCapNhatThemVaDongLai.show();btnCapNhatSua.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemClick">
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="Button2" runat="server" Text="Sửa" Icon="Pencil">
                    <Listeners>
                        <Click Handler="return CheckChonNhieuDong(grpNghiDaiNgay);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSuaClick">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="Button3" runat="server" Text="Xóa" Icon="Delete">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(grpNghiDaiNgay,grpNghiDaiNgayStore);" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window runat="server" ID="wdThemSuaNghiDaiNgay" Width="470" AutoHeight="true"
            Resizable="false" Modal="true" Layout="FormLayout" Constrain="true" Hidden="true"
            Title="Thêm nhân viên" Icon="Add" Padding="6">
            <Items>
                <ext:FieldSet runat="server" ID="fs1" Title="Thông tin nhân viên" LabelWidth="110">
                    <Items>
                        <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                            DisplayField="HO_TEN" ValueField="PR_KEY" LoadingText="Đang tìm kiếm..." AnchorHorizontal="99%"
                            PageSize="10" ItemSelector="div.search-item" MinChars="1" Note="Bạn phải chọn 1 nhân viên"
                            ID="cbonhanvien" FieldLabel="Chọn nhân viên<span style='color:red;'>*</span>"
                            Width="300" LabelWidth="120">
                            <Store>
                                <ext:Store ID="Store1" runat="server" AutoLoad="true">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="Handler/ChonNhanVien.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="Start" Value="={0}" />
                                        <ext:Parameter Name="Limit" Value="={10}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                            <Fields>
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="PR_KEY" />
                                                <ext:RecordField Name="MA_CB" />
                                                <ext:RecordField Name="TEN_PHONG" />
                                                <ext:RecordField Name="NGAY_SINH" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Template ID="Template3" runat="server">
                                <Html>
                                    <tpl for=".">
						                                  <div class="search-item">
							                                 <h3>{HO_TEN}</h3>
							                                 {TEN_PHONG}</BR>
                                                            Ngày sinh: {NGAY_SINH:date("d/m/Y")}
						                                  </div>
					                                   </tpl>
                                </Html>
                            </Template>
                            <Listeners>
                                <Select Handler="#{hdfPRKEYHOSO}.setValue(cbonhanvien.getValue());" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="txtLyDoNghi" FieldLabel="Lý do nghỉ" AnchorHorizontal="99%">
                        </ext:TextField>
                        <ext:ComboBox runat="server" ID="cbbDongBH" FieldLabel="Đóng bảo hiểm<span style='color:red;'>*</span>"
                            AnchorHorizontal="99%" Editable="false">
                            <Items>
                                <ext:ListItem Value="0" Text="Không đóng bảo hiểm" />
                                <ext:ListItem Value="1" Text="Đang đóng bảo hiểm" />
                            </Items>
                        </ext:ComboBox>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="fs2" AutoHeight="true" Title="Đơn xin nghỉ" LabelWidth="120">
                    <Items>
                        <ext:DateField runat="server" ID="dfNgayNopDon" FieldLabel="Ngày nộp đơn<span style='color:red;'>*</span>">
                        </ext:DateField>
                        <ext:CompositeField runat="server" ID="cf3" FieldLabel="Ngày đăng ký nghỉ<span style='color:red;'>*</span>">
                            <Items>
                                <ext:DateField runat="server" ID="dfNgayDangKyNghi" Width="100" Vtype="daterange">
                                </ext:DateField>
                                <ext:DisplayField runat="server" ID="dfs1" Text="Ngày đi làm lại<span style='color:red;'>*</span>" />
                                <ext:DateField runat="server" ID="dfNgayDiLamLai" Width="100" Vtype="daterange">
                                </ext:DateField>
                            </Items>
                        </ext:CompositeField>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="fs3" AutoHeight="true" Title="Thông tin thực tế"
                    LabelWidth="120" Hidden="false">
                    <Items>
                        <ext:CompositeField runat="server" ID="CompositeField1" FieldLabel="Ngày nghỉ thực tế">
                            <Items>
                                <ext:DateField runat="server" ID="dfNgayNghiThucTe" Width="100" Vtype="daterange">
                                </ext:DateField>
                                <ext:DisplayField runat="server" ID="DisplayField1" Text="Ngày đi làm lại" />
                                <ext:DateField runat="server" ID="dfNgayDiLamLaiThucTe" Width="100" Vtype="daterange">
                                </ext:DateField>
                            </Items>
                        </ext:CompositeField>
                    </Items>
                </ext:FieldSet>
                <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="98%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatThem" Text="Cập nhật" Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatSua" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatSua_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatThemVaDongLai" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDongLai" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdThemSuaNghiDaiNgay}.hide();resetWindowsThemSuaNghiDaiNgay();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetWindowsThemSuaNghiDaiNgay();cbonhanvien.enable();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grpNghiDaiNgayStore" runat="server" AutoLoad="true">
            <Proxy>
                <ext:HttpProxy Url="Handler/NghiDaiNgay.ashx" Method="GET" Json="true">
                </ext:HttpProxy>
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="Start" Value="={0}" />
                <ext:Parameter Name="Limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader TotalProperty="TotalRecords" Root="Data" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="GhiChu" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="DongBH" />
                        <ext:RecordField Name="LyDoNghi" />
                        <ext:RecordField Name="NgayDangKyNghi" />
                        <ext:RecordField Name="NgayDiLamLai" />
                        <ext:RecordField Name="NgayDiLamLaiThucTe" />
                        <ext:RecordField Name="NgayNopDon" />
                        <ext:RecordField Name="NgayNghiThucTe" />
                        <ext:RecordField Name="PR_KEYHOSO" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="grpNghiDaiNgay" Border="false" runat="server" StoreID="grpNghiDaiNgayStore">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="bts">
                                    <Items>
                                        <ext:Button ID="btnThem" runat="server" Text="Thêm nhân viên" Icon="UserAdd">
                                            <Listeners>
                                                <Click Handler="wdThemSuaNghiDaiNgay.show();btnCapNhatThem.show();btnCapNhatThemVaDongLai.show();btnCapNhatSua.hide();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnThemClick">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnSua" runat="server" Text="Sửa" Icon="Pencil" Disabled="true">
                                            <Listeners>
                                                <Click Handler="return CheckChonNhieuDong(grpNghiDaiNgay);" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnSuaClick">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnXoa" runat="server" Text="Xóa" Icon="Delete" Disabled="true">
                                            <Listeners>
                                                <Click Handler="RemoveItemOnGrid(grpNghiDaiNgay,grpNghiDaiNgayStore);" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TextField runat="server" ID="txtSearchKey" Width="220" EmptyText="Nhập mã hoặc họ tên nhân viên..."
                                            EnableKeyEvents="true">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressSearchKey" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                                            <Listeners>
                                                <Click Handler=" grpNghiDaiNgay.reload(); hdfRecordID.setValue(''); hdfPRKEYHOSO.setValue(''); resetPanelThongTin();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                    <ext:Column DataIndex="HoTen" ColumnID="colHoTen" Header="Họ tên" Width="160" />
                                    <ext:Column DataIndex="LyDoNghi" ColumnID="colLyDoNghi" Header="Lý do nghỉ" Width="150" />
                                    <ext:Column DataIndex="DongBH" Header="Đóng BH" ColumnID="colDongBH" Align="Center">
                                        <Renderer Fn="GetBooleanIcon" />
                                    </ext:Column>
                                    <ext:DateColumn DataIndex="NgayNopDon" Header="Ngày nộp đơn" ColumnID="colNgayNopDon"
                                        Format="dd/MM/yyyy" />
                                    <ext:DateColumn DataIndex="NgayDangKyNghi" Header="Ngày đăng ký nghỉ" ColumnID="colNgayDangKyNghi"
                                        Format="dd/MM/yyyy" />
                                    <ext:DateColumn DataIndex="NgayDiLamLai" Header="Ngày đi làm lại" ColumnID="colNgayDiLamLai"
                                        Format="dd/MM/yyyy" />
                                    <ext:DateColumn DataIndex="NgayNghiThucTe" Header="Ngày nghỉ" ColumnID="colNgayNghiThucTe"
                                        Format="dd/MM/yyyy" />
                                    <ext:DateColumn DataIndex="NgayDiLamLaiThucTe" Header="Ngày đi làm lại" ColumnID="colNgayDiLamLaiThucTe"
                                        Format="dd/MM/yyyy" />
                                    <ext:Column DataIndex="GhiChu" Header="Ghi chú" Width="200" />
                                </Columns>
                            </ColumnModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="15" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="100" />
                                            </Items>
                                            <SelectedItem Value="15" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad(); " />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectedNghiDaiNgay" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{hdfRecordID}.setValue(#{RowSelectedNghiDaiNgay}.getSelected().id);#{btnSua}.enable();#{btnXoa}.enable();resetPanelThongTin(); Ext.net.DirectMethods.DienThongTinNhanVien(#{RowSelectedNghiDaiNgay}.getSelected().id);" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <Plugins>
                                <ext:RowExpander ID="RowExpander1" runat="server" />
                            </Plugins>
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grpNghiDaiNgay}.getSelectionModel().selectRow(rowIndex);" />
                            </Listeners>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu...." />
                            <DirectEvents>
                                <RowDblClick OnEvent="btnSuaClick" />
                            </DirectEvents>
                            <View>
                                <ext:GridView ID="GridView1" runat="server" ForceFit="false">
                                    <HeaderGroupRows>
                                        <ext:HeaderGroupRow>
                                            <Columns>
                                                <ext:HeaderGroupColumn ColSpan="5" Align="Center" Header="" />
                                                <ext:HeaderGroupColumn ColSpan="3" Align="Center" Header="ĐƠN" />
                                                <ext:HeaderGroupColumn ColSpan="2" Align="Center" Header="THỰC TẾ" />
                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="" />
                                            </Columns>
                                        </ext:HeaderGroupRow>
                                    </HeaderGroupRows>
                                </ext:GridView>
                            </View>
                        </ext:GridPanel>
                    </Center>
                    <South>
                        <ext:Panel ID="panelGeneralInformation" Cls="panelGeneralInformation" Title="Thông tin cơ bản"
                            Height="190" Padding="6" runat="server" Layout="FormLayout" Border="false">
                            <Items>
                                <ext:Container ID="Container1" Layout="ColumnLayout" runat="server" Height="200"
                                    AnchorHorizontal="100%">
                                    <Items>
                                        <ext:Container ID="Container20" Layout="FormLayout" runat="server" Width="130">
                                            <Items>
                                                <ext:ImageButton ID="hsImage" ImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person_NoClick.jpg"
                                                    runat="server" Width="120" Height="150" TabIndex="0">
                                                    <%--   <Listeners>
                                                            <Click Handler="#{wdUploadImageWindow}.show();" />
                                                        </Listeners>--%>
                                                </ext:ImageButton>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Contain8" Layout="FormLayout" ColumnWidth="0.9">
                                            <Items>
                                                <ext:Container runat="server" ID="Contain7" Layout="ColumnLayout" AnchorHorizontal="100%"
                                                    Height="200">
                                                    <Items>
                                                        <ext:Container ID="Contain1" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                                            <Items>
                                                                <ext:TextField FieldLabel="Mã cán bộ" EnableKeyEvents="true" AnchorHorizontal="95%"
                                                                    runat="server" ID="txtMaCB" Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Họ tên" AnchorHorizontal="95%" runat="server" ID="txtFullName"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Bí danh" AnchorHorizontal="95%" runat="server" ID="txtBiDanh"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Bộ phận" AnchorHorizontal="95%" runat="server" ID="txtBoPhan"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Điện thoại CQ" AnchorHorizontal="95%" runat="server" ID="txtDTCoQuan"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField> 
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container ID="Container2" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                                            <Items>
                                                                <ext:TextField FieldLabel="Điện thoại nhà" runat="server" AnchorHorizontal="95%"
                                                                    Height="25" ID="txtDTNha">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Số CMND" runat="server" AnchorHorizontal="95%" ID="txtSoCMND"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Ngày cấp CMND" runat="server" AnchorHorizontal="95%" ID="txtNgayCapCMND"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField AnchorHorizontal="95%" FieldLabel="Nơi cấp CMND" runat="server" ID="txtNoiCapCMND"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField runat="server" FieldLabel="Địa chỉ" ID="txtDiaChi" AnchorHorizontal="95%" > 
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container ID="Container3" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                                            <Items>
                                                                <ext:TextField FieldLabel="Ngày thử việc" runat="server" AnchorHorizontal="95%" ID="txtNgayThuViec"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Ngày nhận" runat="server" AnchorHorizontal="95%" ID="txtNgayNhan"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Ngạch" runat="server" AnchorHorizontal="95%" ID="txtNgach"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                                <ext:TextField FieldLabel="Loại HĐ" runat="server" AnchorHorizontal="95%" ID="txtLoaiHD"
                                                                    Height="25">
                                                                    <Listeners>
                                                                        <Focus Handler="this.blur();" />
                                                                    </Listeners>
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                            <Listeners>
                                <Activate Handler="" />
                            </Listeners>
                        </ext:Panel> 
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
