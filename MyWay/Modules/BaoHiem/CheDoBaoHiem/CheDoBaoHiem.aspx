<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CheDoBaoHiem.aspx.cs" Inherits="Modules_BaoHiem_CheDoBaoHiem" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Assembly="Ext.Net.UX" Namespace="Ext.Net.UX" TagPrefix="extux" %>
<%@ Register Src="../UC_BHNHANVIEN_BAOHIEM/BHNHANVIEN_BAOHIEM.ascx" TagName="BHNHANVIEN_BAOHIEM"
    TagPrefix="uc1" %>
<%--<%@ Register Src="UC_BHNHANVIEN_BAOHIEM/BHNHANVIEN_BAOHIEM.ascx" TagName="BHNHANVIEN_BAOHIEM"
    TagPrefix="uc1" %>--%>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/LocTheoPhongBan.png) no-repeat center !important;
        }
        
        .list-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
        
        div#panel1-xsplit
        {
            border-left: 1px solid #98C0F4 !important;
            border-right: 1px solid #98C0F4 !important;
        }
        
        .x-tab-strip-top
        {
            display: none !important;
        }
        
        div#Panel3 .x-grid3-cell-inner, .x-grid3-hd-inner
        {
            white-space: nowrap !important;
        }
    </style>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var check_report_chedophatsinh = function () {
            if (hdfIDChiTietCheDoBaoHiem.getValue() == '') {
                alert('Bạn phải chọn 1 chế độ phát sinh');
                return false;
            }
            wdCheDoPhatSinhReport.show();
            return true;
        }
        var check_report_chedophatsinh1 = function () {
            if (hdfIDChiTietCheDoBaoHiem.getValue() == '') {
                alert('Bạn phải chọn 1 chế độ phát sinh');
                return false;
            }
            wdCheDoPhatSinhReport1.show();
            return true;
        }
        var check_report_chedophatsinh2 = function () {
            if (hdfIDChiTietCheDoBaoHiem.getValue() == '') {
                alert('Bạn phải chọn 1 chế độ phát sinh');
                return false;
            }
            wdCheDoPhatSinhReport2.show();
            return true;
        }
        var CheckSelectedRecord = function (grid, Store) {

            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một dòng');
                return false;
            }
            return true;
        }
        var check_themmoi_chungtu = function () {
            if (cboloaichungtu.getValue() == '') {
                alert('Bạn phải chọn loại chứng từ');
                cboloaichungtu.focus();
                return false;
            }
            if (txttenchungtu.getValue() == '') {
                alert('Bạn chưa nhập tên chứng từ');
                txttenchungtu.focus();
                return false;
            }
            if (parseInt("0" + txtTongSoLaoDong.getValue()) < parseInt("0" + txtTrongDoNu.getValue())) {
                alert('Tổng số lao động phải lớn hơn số lao động nữ')
                txtTrongDoNu.focus();
                return false;
            }
            return true;
        }
        var check_baocao = function () {
            if (hdfMadauphieu.getValue() == '') {
                alert('Bạn phải chọn 1 loại chứng từ');
                return false;
            }
            wdShowReport.show();
            return true;
        }
        var reset_dauphieu = function () {
            cboloaichungtu.reset();
            ThoiGianBaoCao.reset(); txttenchungtu.reset(); NamBaoCao.reset(); txtsochungtu.reset(); txtSoTaiKhoan.reset();
            txtMoTai.reset(); txtTongSoLaoDong.reset(); txtTrongDoNu.reset(); txtTongQuyLuong.reset();
        }
        var RemoveItemOnGrid_dauphieu = function (grid, Store) {
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
                        Ext.net.DirectMethods.DeleteRecord_dauphieu(r.data.IdDauPhieu);
                        btnXoaTenCT.disable();
                        btnSuaTenCT.disable();
                    }
                }
            });
        }
        var SetTuNgayDenNgay = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                //Store.commitChanges();
                if (r.data.IdDauPhieu == hdfMadauphieu.getValue()) {
                    hdfTuNgay.setValue(r.data.TuNgay);
                    hdfDenNgay.setValue(r.data.DenNgay);
                    return;
                }
                //Ext.net.DirectMethods.ThemNhanVienVaoDongBaoHiem(r.data.MaNhanVien, r.data.BHXH, r.data.BHYT, r.data.BHTN, r.data.LuongBaoHiem);
            }
        }
        var ReloadCenterGrid = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                if (hdfMadauphieu.getValue() == r.data.IdDauPhieu) {
                    hdfTuNgay.setValue(r.data.TuNgay);
                    hdfDenNgay.setValue(r.data.DenNgay);
                    continue;
                }
            }
            PagingToolbar5.pageIndex = 0; PagingToolbar5.doLoad();
        }
        var RenderSoNam = function (value, p, record) {

            if (value == null || value == "") {
                return "0" + " tháng";
            }
            var nam = parseInt(value / 12);
            var sothang = value % 12;
            if (nam == 0) {
                value = sothang + " tháng";
            }
            else {
                value = nam + " năm " + sothang + " tháng";
            }
            return value;
        }
        var RenderSoNgay = function (value, p, record) {

            if (value == null || value == "") {
                return "0" + " ngày";
            }

            return value + " ngày";
        }
        var ResetFormwdXemTheoNhanVien = function () {
            txtMaCanBo1.reset(); txtMaCanBo1.el.applyStyles("color:black");
            dfNgaySinh1.reset(); dfNgaySinh1.setMaxValue(); dfNgaySinh1.setMinValue();
            dfNgaySinh1.el.applyStyles("color:black"); txtSoCMND1.reset();
            txtSoCMND1.el.applyStyles("color:black"); txtHoTen1.reset();
            txtHoTen1.el.applyStyles("color:black"); txtSoSoBHXH1.reset();
            txtSoSoBHXH1.el.applyStyles("color:black"); txtThoiGianDong1.reset();
            txtThoiGianDong1.el.applyStyles("color:black"); cbbCheDo1.reset();
            cbbCheDo1.el.applyStyles("color:black"); dfNgayBatDau1.reset();
            dfNgayBatDau1.setMaxValue(); dfNgayBatDau1.setMinValue();
            dfNgayBatDau1.el.applyStyles("color:black"); txtSoNgayNghi1.reset();
            txtSoNgayNghi1.el.applyStyles("color:black"); txtLuyKe1.reset();
            txtLuyKe1.el.applyStyles("color:black"); txtSoTienDeNghi1.reset();
            txtSoTienDeNghi1.el.applyStyles("color:black"); chkDaThanhToan1.reset();
            chkDaThanhToan1.el.applyStyles("color:black"); cbbDieuKienHuong1.reset();
            cbbDieuKienHuong1.el.applyStyles("color:black"); dfNgayKetThuc1.reset();
            dfNgayKetThuc1.setMaxValue(); dfNgayKetThuc1.setMinValue();
            dfNgayKetThuc1.el.applyStyles("color:black"); txtChiTieuLuong1.reset();
            txtChiTieuLuong1.el.applyStyles("color:black"); txtGhiChu1.reset();
            txtGhiChu1.el.applyStyles("color:black");

        }
        var enterKeyToSearch2 = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                //grpBienDongBaoHiemStore.reload();
                grpChiTietNhanVienStore.removeAll();
                btnAddXemTheoNhanVien.disable();
                if (this.getValue() == '') {
                    this.triggers[0].hide();
                }
                //                grpChiTietNhanVienStore.removeAll(); Button1.disable();
            }
            if (txtSearchKey.getValue() != '') {
                txtSearchKey.triggers[0].show();
            }
        }
        var CheckNgayThang = function () {
            if (dfNgayBatDau1.getValue() != '' && dfNgayKetThuc1.getValue() != '' && cbbDieuKienHuong1.getValue() != '') {
                Ext.net.DirectMethods.TuDongTinhNgayTien();
            }
        }
        var ValidateInput = function () {
            if (dfNgayBatDau1.getValue() == '' || dfNgayKetThuc1.getValue() == '' || cbbDieuKienHuong1.getValue() == '' || cbbCheDo1.getValue() == '') {
                alert('Bạn chưa nhập đủ các tham số');
                return false;
            }
            if (dfNgayBatDau1.getValue() > dfNgayKetThuc1.getValue()) {
                alert('Ngày bắt đầu phải nhỏ hơn ngày bắt đầu');
                return false;
            }
            return true;
        }
        var XoaDongNhanVienCheDo = function (grid, Store) {

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
                        Ext.net.DirectMethods.XoaDongNhanVienCheDo(r.data.IDChiTietCheDoBaoHiem);
                        btnSuaXemTheoNhanVien.disable();
                        btnXoaXemTheoNhanVien.disable();
                    }
                }
            });
        }
        var resetAfterDelete = function (f, e) {
            RowSelectionModel4.clearSelections();
            btnXoaTenCT.disable();
            btnSuaTenCT.disable();
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
            if (count > 1) {
                alert('Bạn chỉ được chọn một bản ghi');
                return false;
            }
            return true;
        }
    </script>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:BHNHANVIEN_BAOHIEM ID="BHNHANVIEN_BAOHIEM1" runat="server" />
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="cbbCheDo1Store.reload();" />
            </Listeners>
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfIDNhanVienBaoHiem" />
        <ext:Hidden runat="server" ID="hdfwdShow" />
        <ext:Hidden runat="server" ID="hdfIDCheDoBaoHiem" />
        <ext:Hidden runat="server" ID="hdfDieuKienHuong" />
        <ext:Hidden runat="server" ID="hdfIDChiTietCheDoBaoHiem" />
        <ext:Hidden runat="server" ID="hdfTuNgay" />
        <ext:Hidden runat="server" ID="hdfDenNgay" />
        <ext:Hidden runat="server" ID="hdfMaBaoCao" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <%-- <uc1:BHNHANVIEN_BAOHIEM ID="BHNHANVIEN_BAOHIEM1" runat="server" />--%>
        <ext:Store ID="grpChiTietNhanVienStore" AutoLoad="false" runat="server">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="HandlerChiTietNhanVienCheDo.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={5}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="IDNhanVienBaoHiem" Value="#{hdfIDNhanVienBaoHiem}.getValue()"
                    Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDChiTietCheDoBaoHiem">
                    <Fields>
                        <ext:RecordField Name="IDChiTietCheDoBaoHiem" />
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                        <ext:RecordField Name="MaCheDo" />
                        <ext:RecordField Name="TenCheDo" />
                        <ext:RecordField Name="DieuKienHuong" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                        <ext:RecordField Name="SoNgayNghi" />
                        <ext:RecordField Name="SoTienDeNghi" />
                        <ext:RecordField Name="TinhTrangThanhToan" />
                        <ext:RecordField Name="GhiChu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdXemTheoNhanVien" Modal="true" Layout="FormLayout"
            Width="600" Padding="6" Constrain="true" Title="Quản lý chế độ bảo hiểm" Hidden="true"
            Icon="Add" AutoHeight="true">
            <Items>
                <ext:FieldSet ID="FieldSet1" runat="server" Title="Thông tin cán bộ" Layout="ColumnLayout"
                    Height="105" Border="true">
                    <Items>
                        <ext:Container ID="Container3" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtMaCanBo1" AnchorHorizontal="98%" AllowBlank="false"
                                    FieldLabel="<%$ Resources:HOSO, staff_code%>" Disabled="true">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfNgaySinh1" AnchorHorizontal="98%" FieldLabel="<%$ Resources:HOSO, staff_birthday%>"
                                    Disabled="true">
                                </ext:DateField>
                                <ext:TextField runat="server" ID="txtSoCMND1" AnchorHorizontal="98%" FieldLabel="Số CMND"
                                    Disabled="true">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container4" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtHoTen1" AnchorHorizontal="100%" AllowBlank="false"
                                    FieldLabel="<%$ Resources:HOSO, staff_name%>" Disabled="true">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtSoSoBHXH1" AnchorHorizontal="100%" FieldLabel="Số sổ BHXH"
                                    Disabled="true" EmptyText="Chưa có số sổ BHXH">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtThoiGianDong1" AnchorHorizontal="100%" FieldLabel="Thời gian đóng"
                                    Disabled="true" EmptyText="0 tháng">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="FieldSet2" runat="server" Title="Thông tin chế độ" Layout="FormLayout"
                    Height="220" Border="true">
                    <Items>
                        <ext:Container ID="Container5" runat="server" AnchorHorizontal="100%" Layout="ColumnLayout"
                            Height="145">
                            <Items>
                                <ext:Container ID="Container6" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                    Height="145">
                                    <Items>
                                        <ext:DateField runat="server" ID="dfNgayBatDau1" AnchorHorizontal="98%" FieldLabel="Ngày bắt đầu<span style='color:red'>*</span>"
                                            CtCls="requiredData" Editable="true" Vtype="daterange" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="<%$ Resources:Language, Date_fomart_not_correct%>">
                                            <Listeners>
                                                <Select Handler="CheckNgayThang();" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:ComboBox runat="server" ID="cbbCheDo1" AnchorHorizontal="98%" FieldLabel="Chế độ<span style='color:red'>*</span>"
                                            CtCls="requiredData" DisplayField="TenCheDoBaoHiem" ValueField="IDCheDoBaoHiem"
                                            Editable="false" ItemSelector="div.list-item" ListWidth="220">
                                            <Template runat="server">
                                                <Html>
                                                    <tpl for=".">
                                                           <div class="list-item">
                                                               {TenCheDoBaoHiem}
                                                           </div>
                                                       </tpl>
                                                </Html>
                                            </Template>
                                            <Store>
                                                <ext:Store runat="server" ID="cbbCheDo1Store" AutoLoad="false" OnRefreshData="cbbCheDo1Store_Refresh">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="IDCheDoBaoHiem">
                                                            <Fields>
                                                                <ext:RecordField Name="IDCheDoBaoHiem" />
                                                                <ext:RecordField Name="TenCheDoBaoHiem" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Expand Handler="if(cbbCheDo1.store.getCount()==0) cbbCheDo1Store.reload();" />
                                                <Select Handler="#{hdfIDCheDoBaoHiem}.setValue(cbbCheDo1.getValue()); cbbDieuKienHuong1Store.reload(); Ext.net.DirectMethods.cbbCheDo1_Selected(); " />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:Container ID="Container7" runat="server" AnchorHorizontal="98%" Layout="ColumnLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Container ID="Container8" runat="server" ColumnWidth=".60" Layout="FormLayout">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtSoNgayNghi1" FieldLabel="Số ngày/Lũy kế" AnchorHorizontal="100%"
                                                            MaskRe="/[0-9\.]/">
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container9" runat="server" ColumnWidth=".40" Layout="HBoxLayout">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtLuyKe1" AnchorHorizontal="95%" LabelWidth="6"
                                                            LabelSeparator="/" FieldLabel=" " Width="65" MaskRe="/[0-9\.]/" Disabled="true">
                                                        </ext:TextField>
                                                        <ext:DisplayField runat="server" FieldLabel="Ngày" LabelSeparator=" ">
                                                        </ext:DisplayField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:NumberField runat="server" AnchorHorizontal="98%" ID="txtSoTienDeNghi1" FieldLabel="Số tiền đề nghị<span style='color:red'>*</span>"
                                            CtCls="requiredData" MaxLength="12" AllowNegative="false">
                                            <ToolTips>
                                                <ext:ToolTip runat="server" ID="tipSoTienDeNghi" Title="Công thức" Html="Bạn chưa chọn điều kiện hưởng">
                                                </ext:ToolTip>
                                            </ToolTips>
                                        </ext:NumberField>
                                        <ext:Checkbox runat="server" AnchorHorizontal="98%" ID="chkDaThanhToan1" BoxLabel="Đã thanh toán">
                                        </ext:Checkbox>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container10" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                    LabelWidth="105" Height="135">
                                    <Items>
                                        <ext:DateField runat="server" ID="dfNgayKetThuc1" AnchorHorizontal="100%" FieldLabel="Ngày kết thúc<span style='color:red'>*</span>"
                                            CtCls="requiredData" Editable="true" Vtype="daterange" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="<%$ Resources:Language, Date_fomart_not_correct%>">
                                            <Listeners>
                                                <Select Handler="CheckNgayThang();" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:ComboBox runat="server" ID="cbbDieuKienHuong1" AnchorHorizontal="100%" FieldLabel="Điều kiện hưởng<span style='color:red'>*</span>"
                                            CtCls="requiredData" DisplayField="TenDieuKienHuong" ValueField="IDBangTinhCheDoBaoHiem"
                                            ItemSelector="div.list-item" Editable="false" ListWidth="200">
                                            <Template runat="server">
                                                <Html>
                                                    <tpl for=".">
                                                            <div class="list-item">
                                                                {TenDieuKienHuong}
                                                            </div>
                                                        </tpl>
                                                </Html>
                                            </Template>
                                            <Store>
                                                <ext:Store runat="server" ID="cbbDieuKienHuong1Store" AutoLoad="false" OnRefreshData="cbbDieuKienHuong1Store_Refresh">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="IDBangTinhCheDoBaoHiem">
                                                            <Fields>
                                                                <ext:RecordField Name="IDBangTinhCheDoBaoHiem" />
                                                                <ext:RecordField Name="TenDieuKienHuong" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Expand Handler="if(cbbDieuKienHuong1.store.getCount()==0) cbbDieuKienHuong1Store.reload();" />
                                                <Select Handler="hdfDieuKienHuong.setValue(cbbDieuKienHuong1.getValue()); CheckNgayThang(); Ext.net.DirectMethods.cbbDieuKienHuong1_Selected();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:TextField runat="server" ID="txtChiTieuLuong1" AnchorHorizontal="100%" FieldLabel="Lương đóng BH"
                                            Disabled="true">
                                        </ext:TextField>
                                        <%--   <ext:NumberField runat="server" ID="txtMucDoSuyGiam1" AnchorHorizontal="99%" FieldLabel="Mức độ suy giảm KNLĐ" Hidden="true">
                                            </ext:NumberField>--%>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:TextArea runat="server" AnchorHorizontal="100%" ID="txtGhiChu1" FieldLabel="Ghi chú"
                            Height="40">
                        </ext:TextArea>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button ID="Button8" runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatXemTheoNhanVienClick" After="wdXemTheoNhanVien.hide(); ">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button10" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdXemTheoNhanVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetFormwdXemTheoNhanVien();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grpNhanVienCheDo_Store" AutoLoad="true" runat="server" GroupField="TrangThai">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerNhanVienCheDo.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDNhanVien_BaoHiem">
                    <Fields>
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                        <ext:RecordField Name="MaNhanVien" />
                        <ext:RecordField Name="TenNhanVien" />
                        <ext:RecordField Name="PhongBan" />
                        <ext:RecordField Name="SoSoBHXH" />
                        <ext:RecordField Name="SoTheBHYT" />
                        <ext:RecordField Name="SoThangDongBH" />
                        <ext:RecordField Name="SoNgayNghiOmDau" />
                        <ext:RecordField Name="SoNgayNghiThaiSan" />
                        <ext:RecordField Name="SoNgayNghiDSPHSK" />
                        <ext:RecordField Name="TongTienThanhToan" />
                        <ext:RecordField Name="TrangThai" />
                        <ext:RecordField Name="HoDem" />
                        <ext:RecordField Name="Ten" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Hidden runat="server" ID="hdfRecordID">
        </ext:Hidden>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdxemchedotheothang"
            Title="Xem chế độ bảo hiểm theo tháng" Maximized="true" Icon="Date">
            <Items>
                <ext:TabPanel ID="pnReportPanel1" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel1}.remove(0);addHomePage(#{pnReportPanel1},'Homepage','../CheDoBaoHiem/XemCheDoTheoThang.aspx?prkey='+#{hdfRecordID}.getValue()+'&menuID='+hdfMenuID.getValue() , 'Xem chế độ bảo hiểm theo tháng')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button3" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdxemchedotheothang}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Store ID="grpDanhSachBaoCaoStore" runat="server" AutoLoad="true">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerBHDauBaoHiemCheDo.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IdDauPhieu">
                    <Fields>
                        <ext:RecordField Name="IdDauPhieu" />
                        <ext:RecordField Name="LoaiChungTu" />
                        <ext:RecordField Name="TenChungTu" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store ID="grpChiTietBaoCaoStore" runat="server" ShowWarningOnFailure="false"
            SkipIdForNewRecords="false" GroupField="GroupField" AutoLoad="false" GroupDir="ASC">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerDanhSachCheDo.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
                <ext:Parameter Name="TuNgay" Value="#{hdfTuNgay}.getValue()" Mode="Raw" />
                <ext:Parameter Name="DenNgay" Value="#{hdfDenNgay}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaBaoCao" Value="#{hdfMadauphieu}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords">
                    <Fields>
                        <ext:RecordField Name="IDCheDoBaoHiem" />
                        <ext:RecordField Name="IDNhanVien_BaoHiem" />
                        <ext:RecordField Name="MaCanBo" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="SoSoBHXH" />
                        <ext:RecordField Name="DieuKienTinhHuong" />
                        <ext:RecordField Name="ThoiGianDongBHXH" />
                        <ext:RecordField Name="TienLuongTinhHuong" />
                        <ext:RecordField Name="SoNgayNghi" />
                        <ext:RecordField Name="LuyKeTuDauNam" />
                        <ext:RecordField Name="SoTienDeNghi" />
                        <ext:RecordField Name="GhiChu" />
                        <ext:RecordField Name="GroupField" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Hidden runat="server" ID="hdfMadauphieu">
        </ext:Hidden>
        <ext:Window runat="server" Hidden="true" Layout="FormLayout" ID="wdQuanLyDanhSachBienDongEdit"
            Title="Thêm mới chứng từ" Padding="6" Width="550" Modal="true" AutoHeight="true"
            Icon="Add" Constrain="true">
            <Items>
                <ext:Container runat="server" Layout="ColumnLayout" Height="57">
                    <Items>
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:ComboBox runat="server" ID="cboloaichungtu" FieldLabel="Loại chứng từ<span style='color:red'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="98%" Editable="false" ListWidth="250">
                                    <Items>
<%--                                        <ext:ListItem Value="C66a-HD" Text="Mẫu C66a-HD Ốm đau (Mẫu cũ) " />
                                        <ext:ListItem Value="C67a-HD" Text="Mẫu C67a-HD Thai sản  (Mẫu cũ)" />
                                        <ext:ListItem Value="C68a-HD" Text="Mẫu C68a-HD DSPHSK sau ốm đau (Mẫu cũ)" />
                                        <ext:ListItem Value="C69a-HD" Text="Mẫu C69a-HD DSPHSK sau thai sản (Mẫu cũ)" />--%>
                                        <ext:ListItem Value="C70a-HD" Text="Mẫu C70a-HD" />
                                    </Items>
                                    <Listeners>
                                        <Select Handler="#{txttenchungtu}.setValue('Mẫu '+cboloaichungtu.getText() + ' ' +ThoiGianBaoCao.getText()+'/'+NamBaoCao.getValue());" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox runat="server" ID="ThoiGianBaoCao" FieldLabel="Tháng/Quý" AnchorHorizontal="98%">
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
                                        <ext:ListItem Text="Quý 1" Value="Quý 1" />
                                        <ext:ListItem Text="Quý 2" Value="Quý 2" />
                                        <ext:ListItem Text="Quý 3" Value="Quý 3" />
                                        <ext:ListItem Text="Quý 4" Value="Quý 4" />
                                    </Items>
                                    <Listeners>
                                        <Select Handler="#{txttenchungtu}.setValue('Mẫu '+cboloaichungtu.getText() +' '+ThoiGianBaoCao.getText()+'/'+NamBaoCao.getValue());" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtsochungtu" FieldLabel="Số chứng từ" AnchorHorizontal="100%">
                                </ext:TextField>
                                <ext:SpinnerField runat="server" ID="NamBaoCao" FieldLabel="Năm" AnchorHorizontal="100%">
                                    <Listeners>
                                        <Spin Handler="#{txttenchungtu}.setValue('Mẫu '+cboloaichungtu.getText() + ' ' +ThoiGianBaoCao.getText()+'/'+NamBaoCao.getValue());" />
                                        <Blur Handler="#{txttenchungtu}.setValue('Mẫu '+cboloaichungtu.getText() + ' ' +ThoiGianBaoCao.getText()+'/'+NamBaoCao.getValue());" />
                                    </Listeners>
                                </ext:SpinnerField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txttenchungtu" FieldLabel="Tên chứng từ<span style='color:red'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="100%">
                </ext:TextField>
                <ext:Container ID="Container1" runat="server" Layout="ColumnLayout" Height="57">
                    <Items>
                        <ext:Container ID="Container2" runat="server" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" ID="txtSoTaiKhoan" FieldLabel="Số tài khoản" AnchorHorizontal="98%">
                                </ext:TextField>
                                <ext:NumberField runat="server" ID="txtTongSoLaoDong" FieldLabel="Tổng số lao động" MaskRe="/[0-9]/"
                                    AllowNegative="false" MaxLength="9" AnchorHorizontal="98%">
                                </ext:NumberField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container11" runat="server" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" ID="txtMoTai" FieldLabel="Mở tại" AnchorHorizontal="100%">
                                </ext:TextField>
                                <ext:NumberField runat="server" ID="txtTrongDoNu" FieldLabel="Trong đó nữ" AnchorHorizontal="100%" MaskRe="/[0-9]/"
                                    AllowNegative="false" MaxLength="9" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:NumberField runat="server" ID="txtTongQuyLuong" FieldLabel="Tổng quỹ lương trong tháng/quý"
                    AllowNegative="false" MaxLength="16" AnchorHorizontal="100%" LabelWidth="190">
                </ext:NumberField>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btcapnhat" Icon="Disk" Text="<%$ Resources:Language, update%>">
                    <Listeners>
                        <Click Handler=" return check_themmoi_chungtu();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_themmoichungtu" After="reset_dauphieu();">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btcapnhat_update" Icon="Disk" Text="<%$ Resources:Language, update%>">
                    <DirectEvents>
                        <Click OnEvent="bt_update">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btcapnhatvadong" Icon="Disk" Text="<%$ Resources:Language, update_close%>">
                    <Listeners>
                        <Click Handler=" return check_themmoi_chungtu();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_themmoichungtu" After="reset_dauphieu();">
                            <ExtraParams>
                                <ext:Parameter Value="True" Name="D">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btthoat" Icon="Decline" Text="<%$ Resources:CommonMessage, Close%>">
                    <Listeners>
                        <Click Handler="#{wdQuanLyDanhSachBienDongEdit}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <DirectEvents>
                <Hide OnEvent="resetwindown_dauphieu">
                </Hide>
            </DirectEvents>
            <Listeners>
                <Hide Handler="reset_dauphieu();" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo thông tin nhân viên đóng bảo hiểm xã hội, bảo hiểm y tế" Maximized="true"
            Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel2" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{TabPanel2}.remove(0);addHomePage(#{TabPanel2},'Homepage','../../Report/BaoCao_Main.aspx?IdBcBaoHiem='+#{hdfMadauphieu}.getValue(), 'Báo cáo danh sách hưởng theo chế độ')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button9" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdQuanLyDanhSachCheDo"
            Title="Quản lý danh sách hưởng chế độ" Maximized="true">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="panel1" runat="server" Collapsed="false" Width="300" Border="false"
                            Layout="BorderLayout" Title="Danh sách chứng từ">
                            <Items>
                                <ext:GridPanel ID="grpDanhSachBaoCao" Border="false" runat="server" AutoExpandColumn="TenChungTu"
                                    StripeRows="true" TrackMouseOver="false" Region="Center" Height="450" StoreID="grpDanhSachBaoCaoStore">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button runat="server" ID="btnThemTenCT" Text="<%$ Resources:CommonMessage, Add%>" Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{wdQuanLyDanhSachBienDongEdit}.show();#{btcapnhat}.show();#{btcapnhatvadong}.show();#{btcapnhat_update}.hide();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnSuaTenCT" Text="<%$ Resources:CommonMessage, Edit%>" Icon="Pencil" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="return CheckSelectedRecord(#{grpDanhSachBaoCao},#{grpDanhSachBaoCaoStore});#{btcapnhat}.hide();#{btcapnhatvadong}.hide();#{btcapnhat_update}.show();" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="LoadEdit_DauPhieu">
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnXoaTenCT" Text="<%$ Resources:Language, delete%>" Icon="Delete" Disabled="true">
                                                    <%--<Listeners>
                                                        <Click Handler="RemoveItemOnGrid_dauphieu(grpDanhSachBaoCao,grpDanhSachBaoCaoStore)" />
                                                    </Listeners>--%>
                                                    <DirectEvents>
                                                        <Click OnEvent="Delete_DauPhieu">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation Title="Xác nhận" Message="<%$ Resources:CommonMessage, ConfirmDelete%>" ConfirmRequest="true" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" />
                                            <ext:Column ColumnID="TenChungTu" Header="Tên chứng từ" DataIndex="TenChungTu" />
                                        </Columns>
                                    </ColumnModel>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar4" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                            PageSize="20" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                                            DisplayMsg="{0} đến {1} / {2}" runat="server">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="RowSelectionModel4">
                                            <Listeners>
                                                <RowSelect Handler="#{hdfMadauphieu}.setValue(#{RowSelectionModel4}.getSelected().id); 
                                                        ReloadCenterGrid(grpDanhSachBaoCao,grpDanhSachBaoCaoStore);
                                                        #{btnSuaTenCT}.enable();#{btnXoaTenCT}.enable(); #{Button1}.enable();" />
                                                <RowDeselect Handler="#{hdfMadauphieu}.reset();
                                                        #{btnSuaTenCT}.disable();#{btnXoaTenCT}.disable(); #{Button1}.disable();" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <Listeners>
                                        <RowDblClick Handler="#{btcapnhat}.hide();#{btcapnhatvadong}.hide();#{btcapnhat_update}.show();" />
                                    </Listeners>
                                    <DirectEvents>
                                        <RowDblClick OnEvent="LoadEdit_DauPhieu">
                                        </RowDblClick>
                                    </DirectEvents>
                                    <View>
                                        <ext:GridView ID="GridView1" runat="server" ForceFit="false" />
                                    </View>
                                    <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grpChiTietBaoCao" Border="false" runat="server" StoreID="grpChiTietBaoCaoStore"
                            StripeRows="true" TrackMouseOver="false" AnchorHorizontal="100%" Title="Danh sách hưởng chế độ trong báo cáo">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar4" runat="server">
                                    <Items>
                                        <ext:Button runat="server" ID="Button1" Text="<%$ Resources:Language, report%>" Icon="Printer">
                                            <Listeners>
                                                <Click Handler="return check_baocao();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" Align="Left" />
                                    <ext:Column ColumnID="colMaNhanVien" Width="82" DataIndex="MaCanBo" Header="<%$ Resources:HOSO, staff_code%>">
                                    </ext:Column>
                                    <ext:Column ColumnID="colTenCanBo" Width="150" DataIndex="HoTen" Header="<%$ Resources:HOSO, staff_name%>">
                                    </ext:Column>
                                    <ext:Column ColumnID="colMaSo" Width="80" DataIndex="SoSoBHXH" Header="Số sổ BHXH">
                                    </ext:Column>
                                    <ext:Column ColumnID="colDieuKienTinhHuong" Width="130" DataIndex="DieuKienTinhHuong"
                                        Header="Điều kiện tính hưởng">
                                    </ext:Column>
                                    <ext:Column ColumnID="colThoiGianDongBHXH" Width="100" DataIndex="ThoiGianDongBHXH"
                                        Align="Right" Header="Thời gian đóng BHXH">
                                        <Renderer Fn="RenderSoNam" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colTienLuongTinhHuong" Width="100" Header="Tiền lương tính hưởng"
                                        Align="Right" DataIndex="TienLuongTinhHuong">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colSoNgayNghi" Width="100" DataIndex="SoNgayNghi" Header="Số ngày nghỉ"
                                        Align="Right">
                                    </ext:Column>
                                    <ext:Column ColumnID="colLuyKeTuDauNam" Width="100" DataIndex="LuyKeTuDauNam" Header="Lũy kế từ đầu năm"
                                        Align="Right">
                                    </ext:Column>
                                    <ext:Column ColumnID="colSoTienDeNghi" Width="100" DataIndex="SoTienDeNghi" Header="Số tiền đề nghị"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colGhiChu" Width="150" DataIndex="GhiChu" Header="<%$ Resources:QuanLyThoiViec, GhiChu%>">
                                    </ext:Column>
                                    <ext:Column ColumnID="colGroupField" Width="100" DataIndex="GroupField" Header="GroupField">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView2" runat="server" MarkDirty="false" ShowGroupName="false"
                                    EnableNoGroups="true" HideGroupedColumn="true">
                                </ext:GroupingView>
                            </View>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar5" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                    PageSize="20" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                                    DisplayMsg="{0} đến {1} / {2}" runat="server">
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang xử lý..." />
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel3" SingleSelect="true">
                                    <%-- <DirectEvents>
                                                    <RowSelect OnEvent="DotDanhGia_Click" Before="hdfMaDotDanhGia.setValue(checkSelection.getSelected().id);">
                                                        <EventMask ShowMask="true" />
                                                    </RowSelect>
                                                </DirectEvents>--%>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdCheDoPhatSinhReport"
            Title="Mẫu in" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel1" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{TabPanel1}.remove(0);addHomePage(#{TabPanel1},'Homepage','../../Report/BaoCao_Main.aspx?IdChiTietBH='+#{hdfIDChiTietCheDoBaoHiem}.getValue(), '')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button2" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdCheDoPhatSinhReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdCheDoPhatSinhReport1"
            Title="Mẫu in" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel3" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{TabPanel3}.remove(0);addHomePage(#{TabPanel3},'Homepage','../../Report/BaoCao_Main.aspx?IdChiTietBH1='+#{hdfIDChiTietCheDoBaoHiem}.getValue(), '')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button4" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdCheDoPhatSinhReport1}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdCheDoPhatSinhReport2"
            Title="Mẫu in" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel4" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{TabPanel4}.remove(0);addHomePage(#{TabPanel4},'Homepage','../../Report/BaoCao_Main.aspx?IdChiTietBH2='+#{hdfIDChiTietCheDoBaoHiem}.getValue(), '')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdCheDoPhatSinhReport2}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel ID="panel2" Layout="BorderLayout" Height="200" runat="server" Border="false"
                            AnchorVertical="100%">
                            <Items>
                                <ext:RowLayout ID="rl1" runat="server" Split="false" AnchorHorizontal="99%" AnchorVertical99="99%">
                                    <Rows>
                                        <ext:LayoutRow RowHeight="0.65">
                                            <Items>
                                                <ext:GridPanel runat="server" ID="grpNhanVienCheDo" Border="false" Region="Center"
                                                    AnchorHorizontal="99%" AnchorVertical="99%" StripeRows="true" TrackMouseOver="false"
                                                    StoreID="grpNhanVienCheDo_Store">
                                                    <TopBar>
                                                        <ext:Toolbar ID="toolbar2" runat="server">
                                                            <Items>
                                                                <ext:Button runat="server" ID="btxemtheothang" Icon="Date" Text="Xem theo tháng">
                                                                    <Listeners>
                                                                        <Click Handler="#{wdxemchedotheothang}.show();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                                <ext:Button runat="server" ID="btnQuanLyDanhSachCheDo" Text="Quản lý danh sách hưởng chế độ"
                                                                    Icon="Script">
                                                                    <Listeners>
                                                                        <Click Handler="#{wdQuanLyDanhSachCheDo}.show();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                                <%-- <ext:Button runat="server" ID="btnThem" Icon="Add" Text="<%$ Resources:CommonMessage, Add%>">
                                                                        <Listeners>
                                                                            <Click Handler="wdCheDoBaoHiem.show();" />
                                                                        </Listeners>
                                                                    </ext:Button>
                                                                    <ext:Button runat="server" ID="btnSua" Icon="Pencil" Text="<%$ Resources:CommonMessage, Edit%>">
                                                                    </ext:Button>
                                                                    <ext:Button runat="server" ID="btnXoa" Icon="Delete" Text="<%$ Resources:Language, delete%>">
                                                                    </ext:Button>
                                                                    <ext:ToolbarSpacer></ext:ToolbarSpacer>
                                                                    <ext:ToolbarSeparator></ext:ToolbarSeparator>
                                                                    <ext:Button runat="server" ID="btnToKhai" Icon="Script" Text="Tờ khai">
                                                                    </ext:Button>--%>
                                                                <ext:ToolbarFill runat="server" ID="tbfill" />
                                                                <%--<ext:TriggerField runat="server" EnableKeyEvents="true" Width="250" EmptyText="Tìm kiếm theo mã, tên, số sổ, số thẻ"
                                                                    ID="txtSearchKey">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <KeyPress Fn="enterKeyToSearch" />
                                                                        <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                                    </Listeners>
                                                                </ext:TriggerField>--%>
                                                                <ext:TriggerField runat="server" Width="250" EnableKeyEvents="true" ID="txtSearchKey"
                                                                    EmptyText="Tìm kiếm theo mã, tên, số sổ, số thẻ">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger HideTrigger="true" Icon="Clear" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <KeyPress Fn="enterKeyToSearch2" />
                                                                    </Listeners>
                                                                    <Listeners>
                                                                        <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();" />
                                                                    </Listeners>
                                                                </ext:TriggerField>
                                                                <ext:Button Text="<%$ Resources:Language, search%>" Icon="Zoom" runat="server" ID="btnSearch">
                                                                    <Listeners>
                                                                        <Click Handler=" PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); #{grpNhanVienCheDo_Store}.reload();  grpChiTietNhanVienStore.removeAll(); btnAddXemTheoNhanVien.disable();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </Items>
                                                        </ext:Toolbar>
                                                    </TopBar>
                                                    <ColumnModel ID="ColumnModel1" runat="server">
                                                        <Columns>
                                                            <ext:RowNumbererColumn Header="STT" Width="35" />
                                                            <ext:Column ColumnID="colMaNhanVien" Header="<%$ Resources:HOSO, staff_code%>" Width="90" DataIndex="MaNhanVien">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colTenNhanVien" Header="Tên nhân viên" Width="150" DataIndex="TenNhanVien">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colPhongBan" Header="<%$ Resources:HOSO, staff_section%>" Width="150" DataIndex="PhongBan" />
                                                            <ext:Column ColumnID="colSoSoBHXH" Header="Số sổ BHXH" Width="100" DataIndex="SoSoBHXH">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colSoTheBHYT" Header="Số thẻ BHYT" Width="100" DataIndex="SoTheBHYT">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colThoiGianDong" Header="Thời gian đóng" Width="100" DataIndex="SoThangDongBH"
                                                                Align="Right">
                                                                <Renderer Fn="RenderSoNam" />
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colSoNgayNghiOmDau" Header="Tổng số ngày nghỉ ốm đau" Width="90"
                                                                DataIndex="SoNgayNghiOmDau" Align="Right">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colSoNgayNghiThaiSan" Header="Tổng số ngày nghỉ thai sản" Width="90"
                                                                DataIndex="SoNgayNghiThaiSan" Align="Right">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colSoNgayNghiDSPHSK" Header="Tổng số ngày nghỉ DSPHSK" Width="97"
                                                                DataIndex="SoNgayNghiDSPHSK" Align="Right">
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colTongTienThanhToan" Header="Tổng tiền đã thanh toán" Width="140"
                                                                DataIndex="TongTienThanhToan" Align="Right">
                                                                <Renderer Fn="RenderVND" />
                                                            </ext:Column>
                                                            <ext:Column ColumnID="colTrangThai" Header="Trạng thái" Width="200" DataIndex="TrangThai">
                                                            </ext:Column>
                                                        </Columns>
                                                    </ColumnModel>
                                                    <BottomBar>
                                                        <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                                            PageSize="15" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                                                            DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                                                            <Items>
                                                                <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                                <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                                    <Items>
                                                                        <ext:ListItem Text="10" />
                                                                        <ext:ListItem Text="15" />
                                                                        <ext:ListItem Text="30" />
                                                                        <ext:ListItem Text="40" />
                                                                        <ext:ListItem Text="50" />
                                                                    </Items>
                                                                    <SelectedItem Value="15" />
                                                                    <Listeners>
                                                                        <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                            <Listeners>
                                                                <Change Handler="#{RowSelectionModel2}.clearSelections();" />
                                                            </Listeners>
                                                        </ext:PagingToolbar>
                                                    </BottomBar>
                                                    <SelectionModel>
                                                        <ext:RowSelectionModel runat="server" ID="RowSelectionModel2">
                                                            <Listeners>
                                                                <RowSelect Handler="#{btnAddXemTheoNhanVien}.enable();
                                                                                    #{btnSuaXemTheoNhanVien}.disable();
                                                                                    #{btnXoaXemTheoNhanVien}.disable();
                                                                                    #{hdfIDNhanVienBaoHiem}.setValue(#{RowSelectionModel2}.getSelected().id); 
                                                                                    RowSelectionModel1.clearSelections();
                                                                                    #{PagingToolbar3}.pageIndex = 0; #{PagingToolbar3}.doLoad();
                                                                                    " />
                                                                <RowDeselect Handler="#{btnAddXemTheoNhanVien}.disable();
                                                                                        #{btnSuaXemTheoNhanVien}.disable();
                                                                                        #{btnXoaXemTheoNhanVien}.disable();
                                                                                        #{hdfIDNhanVienBaoHiem}.reset(); 
                                                                                        RowSelectionModel1.clearSelections();
                                                                                        " />
                                                            </Listeners>
                                                        </ext:RowSelectionModel>
                                                    </SelectionModel>
                                                    <LoadMask ShowMask="true" />
                                                    <View>
                                                        <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                                                            ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                                        </ext:GroupingView>
                                                    </View>
                                                </ext:GridPanel>
                                            </Items>
                                        </ext:LayoutRow>
                                        <ext:LayoutRow runat="server" RowHeight="0.35">
                                            <Items>
                                                <ext:Panel ID="Panel3" runat="server" AnchorHorizontal="99%" AnchorVertical="99%"
                                                    Title="Chế độ phát sinh" Layout="BorderLayout" Border="false">
                                                    <Items>
                                                        <ext:GridPanel runat="server" ID="grpChiTietNhanVien" StoreID="grpChiTietNhanVienStore"
                                                            Border="false" Region="Center" AnchorHorizontal="99%" AnchorVertical="99%" StripeRows="true"
                                                            TrackMouseOver="False" AutoExpandMin="300" AutoScroll="true">
                                                            <TopBar>
                                                                <ext:Toolbar ID="Toolbar3" runat="server">
                                                                    <Items>
                                                                        <ext:Button runat="server" ID="btnAddXemTheoNhanVien" Icon="Add" Text="<%$ Resources:CommonMessage, Add%>" Disabled="true">
                                                                            <Listeners>
                                                                                <Click Handler="return CheckSelectedRows(grpNhanVienCheDo);" />
                                                                            </Listeners>
                                                                            <DirectEvents>
                                                                                <Click OnEvent="btnAddXemTheoNhanVien_Click" Before="#{hdfwdShow}.setValue('Them');wdXemTheoNhanVien.show();">
                                                                                    <EventMask ShowMask="true" />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" ID="btnSuaXemTheoNhanVien" Icon="Pencil" Text="<%$ Resources:CommonMessage, Edit%>" Disabled="true">
                                                                            <Listeners>
                                                                                <Click Handler ="return CheckSelectedRows(grpChiTietNhanVien);" />
                                                                            </Listeners>
                                                                            <DirectEvents>
                                                                                <Click OnEvent="btnAddXemTheoNhanVien_Click" Before="#{hdfwdShow}.setValue('Sua');wdXemTheoNhanVien.show();">
                                                                                    <EventMask ShowMask="true" />
                                                                                </Click>
                                                                            </DirectEvents>
                                                                        </ext:Button>
                                                                        <ext:Button runat="server" ID="btnXoaXemTheoNhanVien" Icon="Delete" Text="<%$ Resources:Language, delete%>" Disabled="true">
                                                                            <Listeners>
                                                                                <Click Handler="XoaDongNhanVienCheDo(grpChiTietNhanVien,grpChiTietNhanVienStore);" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:ToolbarSpacer>
                                                                        </ext:ToolbarSpacer>
                                                                        <ext:Button ID="mnuTienIch" runat="server" Icon="Script" Text="Mẫu in">
                                                                            <Menu>
                                                                                <ext:Menu ID="Menu1" runat="server">
                                                                                    <Items>
                                                                                        <ext:MenuItem ID="mnu1" runat="server" Icon="Printer" Text="Giấy chứng nhận nghỉ việc hưởng BHXH"
                                                                                            Disabled="true">
                                                                                            <Listeners>
                                                                                                <Click Handler=" return check_report_chedophatsinh();" />
                                                                                            </Listeners>
                                                                                        </ext:MenuItem>
                                                                                        <ext:MenuItem ID="mnu2" runat="server" Icon="Printer" Text="Giấy xác nhận nghỉ việc để chăm sóc con ốm đau"
                                                                                            Disabled="true">
                                                                                            <Listeners>
                                                                                                <Click Handler=" return check_report_chedophatsinh1();" />
                                                                                            </Listeners>
                                                                                        </ext:MenuItem>
                                                                                        <ext:MenuItem ID="mnu3" runat="server" Icon="Printer" Text="Đơn đề nghị hưởng trợ cấp thai sản"
                                                                                            Disabled="true">
                                                                                            <Listeners>
                                                                                                <Click Handler=" return check_report_chedophatsinh2();" />
                                                                                            </Listeners>
                                                                                        </ext:MenuItem>
                                                                                    </Items>
                                                                                </ext:Menu>
                                                                            </Menu>
                                                                        </ext:Button>
                                                                    </Items>
                                                                </ext:Toolbar>
                                                            </TopBar>
                                                            <ColumnModel ID="ColumnModel3" runat="server">
                                                                <Columns>
                                                                    <ext:RowNumbererColumn Header="STT" Width="30" Align="Left" Locked="true">
                                                                    </ext:RowNumbererColumn>
                                                                    <ext:Column ColumnID="colMaCheDo" Header="Mã chế độ" Width="110" DataIndex="MaCheDo"
                                                                        Locked="true">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colTenCheDo" Header="Tên chế độ" Width="250" DataIndex="TenCheDo"
                                                                        Locked="true">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colDieuKienHuong" Header="Điều kiện hưởng" Width="200" DataIndex="DieuKienHuong">
                                                                    </ext:Column>
                                                                    <ext:DateColumn ColumnID="colNgayBatDau" Header="Ngày bắt đầu" Width="100" Format="dd/MM/yyyy"
                                                                        DataIndex="TuNgay">
                                                                    </ext:DateColumn>
                                                                    <ext:DateColumn ColumnID="colNgayKetThuc" Header="Ngày kết thúc" Width="100" Format="dd/MM/yyyy"
                                                                        DataIndex="DenNgay">
                                                                    </ext:DateColumn>
                                                                    <ext:Column ColumnID="colSoNgayNghi" Header="Số ngày nghỉ" Width="100" DataIndex="SoNgayNghi">
                                                                    </ext:Column>
                                                                    <ext:Column ColumnID="colSoTienDeNghi" Header="Số tiền đề nghị" Width="100" DataIndex="SoTienDeNghi"
                                                                        Align="Right">
                                                                        <Renderer Fn="RenderVND" />
                                                                    </ext:Column>
                                                                    <ext:CheckColumn ColumnID="colTinhTrangThanhToan" Header="Tình trạng thanh toán"
                                                                        Width="70" DataIndex="TinhTrangThanhToan">
                                                                    </ext:CheckColumn>
                                                                    <ext:Column ColumnID="colGhiChu" Header="<%$ Resources:QuanLyThoiViec, GhiChu%>" Width="250" DataIndex="GhiChu">
                                                                    </ext:Column>
                                                                </Columns>
                                                            </ColumnModel>
                                                            <BottomBar>
                                                                <ext:PagingToolbar ID="PagingToolbar3" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                                                    PageSize="5" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                                                                    DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                                                                    <Items>
                                                                        <ext:Label ID="Label3" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                                                        <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                                                        <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                                                            <Items>
                                                                                <ext:ListItem Text="5" />
                                                                                <ext:ListItem Text="10" />
                                                                                <ext:ListItem Text="15" />
                                                                                <ext:ListItem Text="20" />
                                                                                <ext:ListItem Text="100" />
                                                                            </Items>
                                                                            <SelectedItem Value="5" />
                                                                            <Listeners>
                                                                                <Select Handler="#{PagingToolbar3}.pageSize = parseInt(this.getValue()); #{PagingToolbar3}.doLoad();" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                    <Listeners>
                                                                        <Change Handler="#{RowSelectionModel1}.clearSelections();" />
                                                                    </Listeners>
                                                                </ext:PagingToolbar>
                                                            </BottomBar>
                                                            <View>
                                                                <ext:LockingGridView runat="server" ID="lkv" LockText="Cố định cột này lại" UnlockText="Hủy cố định cột">
                                                                </ext:LockingGridView>
                                                            </View>
                                                            <DirectEvents>
                                                                <RowDblClick OnEvent="btnAddXemTheoNhanVien_Click" Before="#{hdfwdShow}.setValue('Sua');wdXemTheoNhanVien.show();">
                                                                    <EventMask ShowMask="true" />
                                                                </RowDblClick>
                                                            </DirectEvents>
                                                            <SelectionModel>
                                                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel1">
                                                                    <Listeners>
                                                                        <RowSelect Handler="#{btnSuaXemTheoNhanVien}.enable();
                                                                                            #{btnXoaXemTheoNhanVien}.enable();
                                                                                            #{mnu1}.enable();
                                                                                            #{mnu2}.enable();
                                                                                            #{mnu3}.enable();
                                                                                            #{hdfIDChiTietCheDoBaoHiem}.setValue(#{RowSelectionModel1}.getSelected().id);" />
                                                                        <RowDeselect Handler="#{btnSuaXemTheoNhanVien}.disable();
                                                                                            #{btnXoaXemTheoNhanVien}.disable();
                                                                                            #{mnu1}.disable();
                                                                                            #{mnu2}.disable();
                                                                                            #{mnu3}.disable();
                                                                                            #{hdfIDChiTietCheDoBaoHiem}.reset();" />
                                                                    </Listeners>
                                                                </ext:RowSelectionModel>
                                                            </SelectionModel>
                                                            <LoadMask ShowMask="true" />
                                                        </ext:GridPanel>
                                                    </Items>
                                                </ext:Panel>
                                            </Items>
                                        </ext:LayoutRow>
                                    </Rows>
                                </ext:RowLayout>
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
