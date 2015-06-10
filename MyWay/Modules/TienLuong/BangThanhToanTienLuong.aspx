<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangThanhToanTienLuong.aspx.cs"
    Inherits="Modules_TienLuong_BangThanhToanTienLuong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../Resource/js/RenderJS.js"></script>
    <script type="text/javascript">
        var getSelectedIndexRow = function (grid) {
            var record = grid.getSelectionModel().getSelected();
            var index = grid.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }
        var btnThemClick = function () {
            wdThemBangTinhLuong.setTitle("Thêm mới bảng tính lương");
            wdThemBangTinhLuong.setIconClass("icon-add");
            wdThemBangTinhLuong.show();
            cbChonThang.enable();
            spinChonNam.enable();
            txtTenBangTinhLuong.setValue('Bảng tính lương tháng ' + cbChonThang.getValue() + ' năm ' + spinChonNam.getValue());
            hdfLoaiCapNhat.setValue("Them");
            cbbChonBangChamCong.reset();
            cbbChonBangChamCongStore.reload();
            cbChonThang.reset();
            txtTenBangTinhLuong.reset();
            spinChonNam.reset();
            txtTenBangTinhLuong.reset();
        }
        var btnSuaClick = function (grid, store) {
            wdThemBangTinhLuong.setTitle("Sửa bảng tính lương");
            wdThemBangTinhLuong.setIconClass("icon-pencil");
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                cbChonThang.setValue(r.data.Month);
                cbChonThang.disable();
                spinChonNam.setValue(r.data.Year);
                spinChonNam.disable();
                txtTenBangTinhLuong.setValue(r.data.Title);
            }
            cbbChonBangChamCong.reset();
            cbbChonBangChamCongStore.reload();
            wdThemBangTinhLuong.show();
            hdfLoaiCapNhat.setValue("Sua");
        }

        var keyEnterPress = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar.pageIndex = 0; PagingToolbar.doLoad();
            }
        }
        var CheckChonBangChamCong = function (grid) {
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

    </script>
    <style type="text/css">
        .search-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }

        .westDonXinNghi .x-layout-collapsed-west {
            background: url(../../Resource/images/CacDonDaGui.png) no-repeat center;
        }

        .search-item h3 {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }

            .search-item h3 span {
                float: right;
                font-weight: normal;
                margin: 0 0 5px 5px;
                width: 100px;
                display: block;
                clear: none;
            }

        #grpThongTinCanBo .ux-grid-hd-group-row-0 {
            height: 91px;
        }

        .x-grid3-td-expander {
            display: none !important;
        }

        #grpThongTinCanBo .x-panel-body {
            border-right: 1px solid #99BBE8;
        }

        div#grpThongTinCanBo .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager ID="RM" runat="server" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfCurrentMaDonVi" />
        <ext:Menu runat="server" ID="RowContextMenuThemBangLuong">
            <Items>
                <ext:MenuItem ID="MenuItem1" runat="server" Text="Thêm" Icon="Add">
                    <Listeners>
                        <Click Handler="btnThemClick();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem2" runat="server" Text="Sửa" Icon="Pencil">
                    <Listeners>
                        <Click Handler="btnSuaClick(grpDanhSachBangTinhLuong,grpDanhSachBangTinhLuongStore);" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem3" runat="server" Text="Xóa" Icon="Delete">
                    <DirectEvents>
                        <Click OnEvent="btnXoaBangTinhLuongClick">
                            <Confirmation Title="Thông báo" Message="Bạn có chắc bạn muốn xóa bảng tính lương này?"
                                ConfirmRequest="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Store ID="grpBangThanhToanTienLuongStore" runat="server" AutoLoad="false" AutoSave="true"
            ShowWarningOnFailure="false" OnBeforeStoreChanged="grpBangThanhToanTienLuongStoreChange">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="Handler/BangThanhToanTienLuongHandler.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={20}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="IDBangTinhLuong" Value="#{hdfRecordID}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SelectedMaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="#{hdfCurrentMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_DONVI" />
                        <ext:RecordField Name="MA_LOAI_HDONG" />
                        <ext:RecordField Name="LuongCoBan" />
                        <ext:RecordField Name="LuongTrachNhiem" />
                        <ext:RecordField Name="PhuCapTienAn" />
                        <ext:RecordField Name="PhuCapChucVu" />
                        <ext:RecordField Name="PhuCapKiemNhiem" />
                        <ext:RecordField Name="TongLuong" />
                        <ext:RecordField Name="PhuCapKhac" />
                        <ext:RecordField Name="GioCongDinhMuc" />
                        <ext:RecordField Name="GioCongThucTe" />
                        <ext:RecordField Name="TongCaLamViecNgayThuong" />
                        <ext:RecordField Name="TongCaLamViecNgayThuong150" />
                        <ext:RecordField Name="TongCaLamViecNgayNghi" />
                        <ext:RecordField Name="TongCaLamViecNgayLe" />
                        <ext:RecordField Name="TongCong" />
                        <ext:RecordField Name="LuongThoiGianNgayThuong" />
                        <ext:RecordField Name="LuongThemGio" />
                        <ext:RecordField Name="LuongPhepGioCong" />
                        <ext:RecordField Name="LuongPhepSoTien" />
                        <ext:RecordField Name="LuongThuong" />
                        <ext:RecordField Name="LuongThang13" />
                        <ext:RecordField Name="TongThuNhap" />
                        <ext:RecordField Name="GiamTruBHXH" />
                        <ext:RecordField Name="GiamTruBHYT" />
                        <ext:RecordField Name="GiamTruBHTN" />
                        <ext:RecordField Name="GiamTruPhiCongDoan" />
                        <ext:RecordField Name="SoNguoiPhuThuoc" />
                        <ext:RecordField Name="TienAnKhauTruThueTNCN" />
                        <ext:RecordField Name="ThemGioCaoHonNgayThuong" />
                        <ext:RecordField Name="ThuNhapTinhThue" />
                        <ext:RecordField Name="ThueTNCNPhaiNop" />
                        <ext:RecordField Name="ThueCuoiNamHoanTraHoacNopThem" />
                        <ext:RecordField Name="TongThuNhapNET" />
                        <ext:RecordField Name="TamUng" />
                        <ext:RecordField Name="HaThuong" />
                        <ext:RecordField Name="TienComHocVo" />
                        <ext:RecordField Name="TongHopAnCa" />
                        <ext:RecordField Name="TruyThuKhac" />
                        <ext:RecordField Name="ThucLinh" />
                        <ext:RecordField Name="ATM" />
                        <ext:RecordField Name="TienMat" />
                        <ext:RecordField Name="GhiChu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdThemBangTinhLuong" Modal="true" Hidden="true" Constrain="true"
            Title="Thêm bảng tính lương" Icon="Add" Layout="FormLayout" Width="500" AutoHeight="true"
            Padding="10" LabelWidth="135">
            <Items>
                <ext:CompositeField runat="server" ID="cf1" FieldLabel="Chọn tháng">
                    <Items>
                        <ext:ComboBox runat="server" Width="160" ID="cbChonThang" SelectedIndex="0" FieldLabel="Chọn tháng"
                            Editable="false" LabelWidth="60">
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
                                <Select Handler="txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue());cbbChonBangChamCong.reset();cbbChonBangChamCongStore.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DisplayField ID="DisplayField1" runat="server" Text="Chọn năm">
                            <Listeners>
                            </Listeners>
                        </ext:DisplayField>
                        <ext:SpinnerField ID="spinChonNam" runat="server" Width="60" MaxLength="4" MinLength="4">
                            <Listeners>
                                <Spin Handler="txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue());cbbChonBangChamCong.reset();cbbChonBangChamCongStore.reload();" />
                            </Listeners>
                        </ext:SpinnerField>
                    </Items>
                </ext:CompositeField>
                <ext:ComboBox runat="server" ID="cbbChonBangChamCong" AnchorHorizontal="99%" FieldLabel="Chọn bảng chấm công<span style='color:red'>*</span>"
                    ItemSelector="div.search-item" TypeAhead="false" DisplayField="Title" ValueField="ID" Editable="false">
                    <Store>
                        <ext:Store ID="cbbChonBangChamCongStore" AutoLoad="false" GroupField="Nam" runat="server"
                            GroupDir="DESC">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="Handler/ChonBangChamCongHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="Thang" Value="cbChonThang.getValue()" Mode="Raw" />
                                <ext:Parameter Name="Nam" Value="spinChonNam.getValue()" Mode="Raw" />
                                <ext:Parameter Name="MaDonVi" Value="hdfCurrentMaDonVi.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="Title" />
                                        <ext:RecordField Name="DaKhoa" />
                                        <ext:RecordField Name="Thang" />
                                        <ext:RecordField Name="Nam" />
                                        <ext:RecordField Name="MaDonVi" />
                                        <ext:RecordField Name="TenDonVi" />
                                        <ext:RecordField Name="CreatedDate" />
                                        <ext:RecordField Name="CreatedBy" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Template ID="Template3" runat="server">
                        <Html>
                            <tpl for=".">
						                                  <div class="search-item">
							                                 <h3>{Title}</h3>
							                                 {TEN_PHONG}</BR>
                                                             Đơn vị sử dụng:<b> {TenDonVi}</b><br />
                                                              Tình trạng: <b>{DaKhoa}</b>
						                                  </div>
					                                   </tpl>
                        </Html>
                    </Template>
                </ext:ComboBox>
                <ext:TextArea runat="server" ID="txtTenBangTinhLuong" AnchorHorizontal="99%" FieldLabel="Tên bảng tính lương" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYThemBangTinh" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnDongYThemBangTinhClick" >
                            <EventMask Msg="Đang xử lý..." ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLaiThemBangTinh" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThemBangTinhLuong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" ID="wdQuanLyBangTinhLuong"
            Constrain="true" Title="Quản lý bảng tính lương" Icon="Table" Layout="FormLayout"
            Width="700" AutoHeight="true">
            <Items>
                <ext:Hidden ID="hdfRecordID" runat="server" />
                <ext:Hidden ID="hdfLoaiCapNhat" runat="server" />
                <ext:GridPanel ID="grpDanhSachBangTinhLuong" runat="server" StripeRows="true" Border="false"
                    AnchorHorizontal="100%" Header="false" Height="350" Title="Danh sách bảng tính lương"
                    AutoExpandColumn="Title">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tbgr">
                            <Items>
                                <ext:Button runat="server" ID="btnThemBangTinhLuong" Text="Thêm" Icon="Add">
                                    <Listeners>
                                        <Click Handler="btnThemClick();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Disabled="true" ID="btnSuaBangTinhLuong" Text="Sửa" Icon="Pencil">
                                    <Listeners>
                                        <Click Handler="btnSuaClick(grpDanhSachBangTinhLuong,grpDanhSachBangTinhLuongStore);" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="Xóa" Icon="Delete" Disabled="true" ID="btnXoaBangTinhLuong">
                                    <DirectEvents>
                                        <Click OnEvent="btnXoaBangTinhLuongClick">
                                            <Confirmation Title="Thông báo" Message="Bạn có chắc bạn muốn xóa bảng tính lương này?"
                                                ConfirmRequest="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Store>
                        <ext:Store ID="grpDanhSachBangTinhLuongStore" AutoLoad="false" GroupField="Year"
                            runat="server" GroupDir="DESC">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="Handler/QuanLyBangTinhLuongHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="hdfCurrentMaDonVi.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="Title" />
                                        <ext:RecordField Name="CreatedDate" />
                                        <ext:RecordField Name="CreateBy" />
                                        <ext:RecordField Name="Month" />
                                        <ext:RecordField Name="Year" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel3" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="30" />
                            <ext:Column ColumnID="colTitle" Header="Tên bảng tính lương" Width="160" DataIndex="Title" />
                            <ext:Column ColumnID="colMonth" Header="Tháng" Width="70" DataIndex="Month" />
                            <ext:Column ColumnID="colYear" Header="Năm" Width="70" DataIndex="Year" />
                            <ext:Column ColumnID="colCreateBy" Header="Người tạo" Width="100" DataIndex="CreateBy" />
                            <ext:DateColumn ColumnID="colCreateDate" Header="Ngày tạo" Width="70" Format="dd/MM/yyyy"
                                DataIndex="CreatedDate" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelBangTinhLuong" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="btnSuaBangTinhLuong.enable();btnXoaBangTinhLuong.enable(); hdfRecordID.setValue(RowSelectionModelBangTinhLuong.getSelected().id);" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <View>
                        <ext:GroupingView runat="server" ID="gv" HideGroupedColumn="true">
                        </ext:GroupingView>
                    </View>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10">
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="Page size:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
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
                    <Listeners>
                        <RowDblClick Handler="btnSuaClick(grpDanhSachBangTinhLuong,grpDanhSachBangTinhLuongStore);" />
                        <RowContextMenu Handler="e.preventDefault(); #{RowContextMenuThemBangLuong}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenuThemBangLuong}.showAt(e.getXY());grpDanhSachBangTinhLuong.getSelectionModel().selectRow(rowIndex);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYBangTinhLuong" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckChonBangChamCong(grpDanhSachBangTinhLuong);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnDongYBangTinhLuongClick">
                            <EventMask Msg="Đang xử lý..." ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongQuanLyBangTinhLuong" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdQuanLyBangTinhLuong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{grpDanhSachBangTinhLuongStore}.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdThayDoiNhanhGiaTri" Modal="true" Hidden="true" Constrain="true"
            Title="Thay đổi nhanh giá trị" Icon="Sum" Layout="FormLayout" Padding="6" Width="450" Resizable="false"
            AutoHeight="true">
            <Items>
                <ext:Container Height="30" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ColumnWidth=".35" Layout="FormLayout">
                            <Items>
                                <ext:NumberField ID="NumberField15" FieldLabel="Chỉ số cột" AnchorHorizontal="98%"
                                    runat="server" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container1" runat="server" ColumnWidth=".65" Layout="FormLayout">
                            <Items>
                                <ext:TextField ID="txtGiaTri" runat="server" FieldLabel="Giá trị" MaskRe="/[0-9\.]/" AllowBlank="true"
                                    AnchorHorizontal="100%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container2" Height="30" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container3" runat="server" ColumnWidth=".35" Layout="FormLayout">
                            <Items>
                                <ext:NumberField ID="NumberField16" FieldLabel="Chỉ số cột" AnchorHorizontal="98%"
                                    runat="server" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container4" runat="server" ColumnWidth=".65" Layout="FormLayout">
                            <Items>
                                <ext:TextField ID="TextField1" runat="server" FieldLabel="Giá trị" MaskRe="/[0-9\.]/" AllowBlank="true"
                                    AnchorHorizontal="100%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container5" Height="30" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container6" runat="server" ColumnWidth=".35" Layout="FormLayout">
                            <Items>
                                <ext:NumberField ID="NumberField17" FieldLabel="Chỉ số cột" AnchorHorizontal="98%"
                                    runat="server" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container7" runat="server" ColumnWidth=".65" Layout="FormLayout">
                            <Items>
                                <ext:TextField ID="TextField2" runat="server" FieldLabel="Giá trị" MaskRe="/[0-9\.]/" AllowBlank="true"
                                    AnchorHorizontal="100%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container8" Height="30" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container9" runat="server" ColumnWidth=".35" Layout="FormLayout">
                            <Items>
                                <ext:NumberField ID="NumberField18" FieldLabel="Chỉ số cột" AnchorHorizontal="98%"
                                    runat="server" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container10" runat="server" ColumnWidth=".65" Layout="FormLayout">
                            <Items>
                                <ext:TextField ID="TextField3" runat="server" FieldLabel="Giá trị" MaskRe="/[0-9\.]/" AllowBlank="true"
                                    AnchorHorizontal="100%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:RadioGroup runat="server" FieldLabel="Đối tượng" AnchorHorizontal="100%" ColumnsNumber="1">
                    <Items>
                        <ext:Radio runat="server" ID="rdSelectedEmployees" Checked="true" BoxLabel="Chỉ áp dụng đối với những nhân viên được chọn">
                        </ext:Radio>
                        <ext:Radio runat="server" ID="rdAllEmployees" BoxLabel="Tất cả nhân viên trong bảng lương">
                        </ext:Radio>
                    </Items>
                </ext:RadioGroup>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý" Icon="Accept">
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThayDoiNhanhGiaTri.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdChonBangChamCong" Modal="true" Hidden="true" Constrain="true"
            Title="Chọn bảng chấm công" Icon="BookOpen" Layout="FormLayout" Width="700" AutoHeight="true">
            <Items>
                <ext:GridPanel ID="grpChonBangChamCong" runat="server" StripeRows="true" Border="false"
                    AnchorHorizontal="100%" Header="false" Height="350" Title="Danh sách bảng chấm công"
                    AutoExpandColumn="Title">
                    <Store>
                        <ext:Store ID="grpChonBangChamCongStore" AutoLoad="false" GroupField="Nam" runat="server"
                            GroupDir="DESC">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="Handler/ChonBangChamCongHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="hdfCurrentMaDonVi.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="Title" />
                                        <ext:RecordField Name="Lock" />
                                        <ext:RecordField Name="Thang" />
                                        <ext:RecordField Name="Nam" />
                                        <ext:RecordField Name="MaDonVi" />
                                        <ext:RecordField Name="TenDonVi" />
                                        <ext:RecordField Name="CreatedDate" />
                                        <ext:RecordField Name="CreatedBy" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel4" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="30" />
                            <ext:Column ColumnID="colTitle" Header="Tên bảng tính lương" Width="160" DataIndex="Title" />
                            <ext:Column ColumnID="colLock" Header="Đã khóa" Width="50" DataIndex="Lock">
                                <Renderer Fn="GetBooleanIcon" />
                            </ext:Column>
                            <ext:Column ColumnID="colMonth" Header="Tháng" Width="50" DataIndex="Thang" />
                            <ext:Column ColumnID="colYear" Header="Năm" Width="50" DataIndex="Nam" />
                            <ext:Column ColumnID="colTenDonVi" Header="Đơn vị sử dụng" DataIndex="TenDonVi" Width="170" />
                            <%--<ext:Column ColumnID="colCreateBy" Header="Người tạo" Width="100" DataIndex="CreatedBy" />
                            <ext:DateColumn ColumnID="colCreateDate" Header="Ngày tạo" Width="70" Format="dd/MM/yyyy" DataIndex="CreatedDate" />--%>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true" />
                    </SelectionModel>
                    <View>
                        <ext:GroupingView runat="server" ID="GroupingView1" HideGroupedColumn="true">
                        </ext:GroupingView>
                    </View>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="5" />
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="20" />
                                    </Items>
                                    <SelectedItem Value="10" />
                                    <Listeners>
                                        <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <%--<ext:Button runat="server" ID="btnDongYChonBangChamCong" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnDongYChonBangChamCongClick" />
                    </DirectEvents>
                </ext:Button>--%>
                <ext:Button runat="server" ID="btnDongLaiChonBangChamCong" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChonBangChamCong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{grpChonBangChamCongStore}.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <North>
                        <ext:Panel Border="false" runat="server" Title="Bạn chưa chọn bảng thanh toán tiền lương"
                            ID="pnlWrapper">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button runat="server" ID="btnQuanLyBangTinhLuong" Text="Quản lý bảng tính lương"
                                            Icon="Table">
                                            <Listeners>
                                                <Click Handler="wdQuanLyBangTinhLuong.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnChonBangChamCong" Text="Chọn bảng chấm công" Icon="BookOpen"
                                            Disabled="true" Hidden="true">
                                            <Listeners>
                                                <Click Handler="wdChonBangChamCong.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnTinhLuong" Text="Tính lương" Icon="Calculator">
                                            <DirectEvents>
                                                <Click  OnEvent="btnTinhLuongClick" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" ID="tbs" />
                                        <%--<ext:Button ID="tbnQuanLyNhanVien" runat="server" Text="Quản lý nhân viên" Icon="User">
                                            <Menu>
                                                <ext:Menu runat="server" ID="mnuQuanLyNhanVien">
                                                    <Items>
                                                        <ext:MenuItem ID="MenuItem4" runat="server" Icon="UserAdd" Text="Thêm nhân viên">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" Icon="UserDelete" Text="Xóa nhân viên">
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>--%>
                                        <%--<ext:Button runat="server" Text="Tiện ích tính toán" ID="btnTienIchTinhToan" Icon="Sum">
                                            <Menu>
                                                <ext:Menu runat="server" ID="mnuTienIchTinhToan">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Text="Thay đổi nhanh giá trị">
                                                            <Listeners>
                                                                <Click Handler="wdThayDoiNhanhGiaTri.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" Text="Tính lại những người chưa tính">

                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" Text="Tính lại tất cả">

                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>--%>
                                        <ext:Button runat="server" Text="Khóa bảng lương" Icon="Lock"></ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TextField ID="txtSearchKey" EnableKeyEvents="true" Width="220" runat="server"
                                            EmptyText="Nhập từ khóa tìm kiếm...">
                                            <Listeners>
                                                <KeyPress Fn="keyEnterPress" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button ID="Button1" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                            <Listeners>
                                                <Click Handler="PagingToolbar.pageIndex=0;PagingToolbar.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                    </North>
                    <Center>
                        <ext:Container runat="server" ID="ctn60" Layout="ColumnLayout" AnchorVertical="100%"
                            AnchorHorizontal="100%">
                            <Items>
                                <ext:Container runat="server" ID="ctn61" Layout="FitLayout" Width="410">
                                    <Items>
                                        <ext:GridPanel ID="grpThongTinCanBo" Border="false" runat="server" AutoScroll="false"
                                            Header="false" StoreID="grpBangThanhToanTienLuongStore" StripeRows="true" Region="Center"
                                            Title=" ">
                                            <ColumnModel ID="ColumnModel2" runat="server" Height="200">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="1" Width="30" />
                                                    <ext:Column DataIndex="HO_TEN" Header="2" Width="150" />
                                                    <ext:Column DataIndex="TEN_DONVI" Header="3" Width="158" />
                                                    <ext:Column DataIndex="MA_LOAI_HDONG" Header="4" Width="69" />
                                                </Columns>
                                            </ColumnModel>
                                            <View>
                                                <ext:GridView>
                                                    <HeaderGroupRows>
                                                        <ext:HeaderGroupRow>
                                                            <Columns>
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="STT" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Họ tên" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Bộ phận" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Loại HĐLĐ" />
                                                            </Columns>
                                                        </ext:HeaderGroupRow>
                                                    </HeaderGroupRows>
                                                </ext:GridView>
                                            </View>
                                            <SelectionModel>
                                                <ext:RowSelectionModel runat="server" ID="rs1" SingleSelect="false">
                                                    <Listeners>
                                                        <RowSelect Handler="if(getSelectedIndexRow(grpBangThanhToanTienLuong)!=getSelectedIndexRow(grpThongTinCanBo)) grpBangThanhToanTienLuong.getSelectionModel().selectRow(getSelectedIndexRow(grpThongTinCanBo));" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                                    PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                                    DisplayMsg="{1} / {2} " runat="server">
                                                </ext:PagingToolbar>
                                            </BottomBar>
                                            <%--<LoadMask ShowMask="true" />--%>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn62" Layout="FitLayout" ColumnWidth="1">
                                    <Items>
                                        <ext:GridPanel ID="grpBangThanhToanTienLuong" Border="false" runat="server" Header="false"
                                            StoreID="grpBangThanhToanTienLuongStore" StripeRows="true" Region="Center" Title=" ">
                                            <ColumnModel ID="ColumnModel1" runat="server">
                                                <Columns>
                                                    <ext:Column DataIndex="LuongCoBan" Header="5" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField1" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField1.getValue()==''){NumberField1.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongTrachNhiem" Header="6" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField2" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField2.getValue()==''){NumberField2.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="PhuCapTienAn" Header="7" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="TextField6" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(TextField6.getValue()==''){TextField6.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="PhuCapChucVu" Header="8" Width="73">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField3" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField3.getValue()==''){NumberField3.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="PhuCapKiemNhiem" Header="9" Width="73">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField4" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField4.getValue()==''){NumberField4.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongLuong" Header="10=5+6+7+8+9">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField9" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="PhuCapKhac" Header="11">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField5" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField5.getValue()==''){NumberField5.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GioCongDinhMuc" Header="12" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField11" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GioCongThucTe" Header="13" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField12" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongCaLamViecNgayThuong" Header="14" Width="75">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField13" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongCaLamViecNgayThuong150" Header="15" Width="75">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField14" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongCaLamViecNgayNghi" Header="16" Width="75">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField15" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongCaLamViecNgayLe" Header="17" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField16" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongCong" Header="18" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField17" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongThoiGianNgayThuong" Header="19" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField6" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField6.getValue()==''){NumberField6.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongThemGio" Header="20" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField7" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField7.getValue()==''){NumberField7.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongPhepGioCong" Header="21" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField20" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongPhepSoTien" Header="22" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField21" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongThuong" Header="23" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField8" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField8.getValue()==''){NumberField8.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="LuongThang13" Header="24" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField9" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField9.getValue()==''){NumberField9.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongThuNhap" Header="25" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField24" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GiamTruBHXH" Header="26" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField25" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GiamTruBHYT" Header="27" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField26" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GiamTruBHTN" Header="28" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField27" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GiamTruPhiCongDoan" Header="29" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField28" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="SoNguoiPhuThuoc" Header="30" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField10" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField10.getValue()==''){NumberField10.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TienAnKhauTruThueTNCN" Header="31" Width="80">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField11" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField11.getValue()==''){NumberField11.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="ThemGioCaoHonNgayThuong" Header="32" Width="95">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField31" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="ThuNhapTinhThue" Header="33" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField32" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="ThueTNCNPhaiNop" Header="34" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField33" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="ThueCuoiNamHoanTraHoacNopThem" Header="35" Width="115">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField34" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongThuNhapNET" Header="36" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField35" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TamUng" Header="37" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField36" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="HaThuong" Header="38" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField37" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TienComHocVo" Header="39" Width="125">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField38" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TongHopAnCa" Header="40" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField39" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TruyThuKhac" Header="41" Width="70">
                                                        <%--<Editor>
                                                        <ext:TextField runat="server" ID="TextField40" AnchorHorizontal="100%">
                                                        </ext:TextField>
                                                    </Editor>--%>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="ThucLinh" Header="42" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField12" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField12.getValue()==''){NumberField12.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="ATM" Header="43" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField13" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField13.getValue()==''){NumberField13.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="TienMat" Header="44" Width="70">
                                                        <Editor>
                                                            <ext:NumberField MinValue="0" runat="server" ID="NumberField14" AnchorHorizontal="100%">
                                                                <Listeners>
                                                                    <Blur Handler="if(NumberField14.getValue()==''){NumberField14.setValue('0')}" />
                                                                </Listeners>
                                                            </ext:NumberField>
                                                        </Editor>
                                                        <Renderer Fn="RenderVND0" />
                                                    </ext:Column>
                                                    <ext:Column DataIndex="GhiChu" Header="45" Width="70">
                                                        <Editor>
                                                            <ext:TextField runat="server" ID="TextField44" AnchorHorizontal="100%">
                                                            </ext:TextField>
                                                        </Editor>
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <View>
                                                <ext:GridView ID="GridView1" runat="server" ForceFit="false">
                                                    <HeaderGroupRows>
                                                        <ext:HeaderGroupRow>
                                                            <Columns>
                                                                <%--       <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="STT" />
                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="STT" />
                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Họ tên" />
                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Bộ phận" />--%>
                                                                <%--<ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="a" />--%>
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="" />
                                                                <ext:HeaderGroupColumn ColSpan="7" Align="Center" Header="Lương và phụ cấp công việc trong tháng" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Giờ công định mức" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Giờ làm việc chính" />
                                                                <ext:HeaderGroupColumn ColSpan="4" Align="Center" Header="Giờ công làm thêm" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Tổng cộng" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Lương thời gian ngày thường" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Lương làm thêm giờ" />
                                                                <ext:HeaderGroupColumn ColSpan="2" Align="Center" Header="Lương phép,CĐ" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Các khoản thưởng" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Lương tháng 13" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Tổng thu nhập (Gross)" />
                                                                <ext:HeaderGroupColumn ColSpan="9" Align="Center" Header="CÁC KHOẢN KHẤU TRỪ" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="QT thuế TNCN năm được hoàn trả hoặc phải nộp thêm " />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="TỔNG THU NHẬP (Net)" />
                                                                <ext:HeaderGroupColumn ColSpan="5" Align="Center" Header="CÁC KHOẢN TRỪ KHÁC" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Thực lĩnh" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="TT ATM" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="TT Tiền mặt" />
                                                                <ext:HeaderGroupColumn ColSpan="1" Align="Center" Header="Ghi chú" />
                                                            </Columns>
                                                        </ext:HeaderGroupRow>
                                                        <ext:HeaderGroupRow>
                                                            <Columns>
                                                                <%--         <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />--%>
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Lương cơ bản" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Lương trách nhiệm" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Phụ cấp ăn ca" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Phụ cấp chức vụ" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Phụ cấp kiêm nhiệm" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tổng lương" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Phụ cấp khác" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Ngày thường 100%" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Ngày thường 150%" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Ngày nghỉ 200%" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Ngày lễ" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Giờ công" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Số tiền" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="BHXH" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="BHYT" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="BHTN" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="KPCĐ" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="SNPT" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tiền ăn khấu trừ thuế TNCN" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Thêm giờ cao hơn ngày thường" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="TN tính thuế" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Thuế TNCN phải nộp" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tạm ứng" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Hạ thưởng" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tiền cơm thực tế+ Học võ thu lại 20.000đ/công" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tổng hợp ăn ca" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Truy thu khác" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                                <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="" />
                                                            </Columns>
                                                        </ext:HeaderGroupRow>
                                                    </HeaderGroupRows>
                                                </ext:GridView>
                                            </View>
                                            <BottomBar>
                                                <ext:Toolbar runat="server" ID="tb2">
                                                    <Items>
                                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                        <ext:Button runat="server" ID="btnBlank" Text="">
                                                        </ext:Button>
                                                        <ext:ToolbarFill runat="server" ID="tbFill" />
                                                        <ext:DisplayField runat="server" ID="dpfTongSoTien" Html="<b style='color:#15428B; font-size:12px;'>Tổng cộng : 0 VNĐ <i></i></b>" />
                                                        <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                                    </Items>
                                                </ext:Toolbar>
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="if(getSelectedIndexRow(grpBangThanhToanTienLuong)!=getSelectedIndexRow(grpThongTinCanBo)) grpThongTinCanBo.getSelectionModel().selectRow(getSelectedIndexRow(grpBangThanhToanTienLuong));" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Plugins>
                                                <ext:RowExpander ID="RowExpander1" runat="server" />
                                            </Plugins>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
