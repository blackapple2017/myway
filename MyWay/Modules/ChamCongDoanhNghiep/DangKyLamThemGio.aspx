<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKyLamThemGio.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_DangKyLamThemGio" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #grpDangKyLamThemGio
        {
            border-left: 1px solid #99bbe8 !important;
        }
        #pnlCoCauToChuc-xsplit
        {
            border-right: none !important;
        }
        .disabled-input-style
        {
            color: #353848 !important;
        }
        .search-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }
        #grpDangKyLamThemGio .x-grid3-cell-inner
        {
            white-space: nowrap !important;
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
        
        .list-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
    </style>
    <%--Check input data--%>
    <script type="text/javascript">
        // using check in edit click
        var CheckSelectedRow = function (grid) {
            var count = 0;
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn bản ghi nào');
                return false;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một bản ghi');
                return false;
            }
            return true;
        }
        var CheckSelectedRowDelete = function (grid) {
            var count = 0;
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn bản ghi nào');
                return false;
            }
        }
        var CheckInputThemCanBo = function () {
            if (cbxChonCanBo.getValue() == '' || cbxChonCanBo.getValue() == null) {
                alert('Bạn chưa chọn cán bộ');
                cbxChonCanBo.focus();
                return false;
            }
            if (cbxChonCa.getValue() == '' || cbxChonCa.getValue() == null) {
                alert('Bạn chưa chọn ca làm việc');
                cbxChonCa.focus();
                return false;
            }
            if (dfTuNgay.getValue() == '' || dfTuNgay.getValue() == null) {
                alert('Bạn chưa chọn ngày bắt đầu làm thêm');
                dfTuNgay.focus();
                return false;
            }
            if (dfDenNgay.getValue() == '' || dfDenNgay.getValue() == null) {
                alert('Bạn chưa nhập ngày kết thúc làm thêm');
                dfDenNgay.focus();
                return false;
            }
            if (tfGioBatDauSauCa.getValue() == '' || tfGioBatDauSauCa.getValue() == null) {
                alert('Bạn chưa nhập giờ bắt đầu làm thêm');
                tfGioBatDauSauCa.focus();
                return false;
            }
            if (tfGioKetThucSauCa.getValue() == '' || tfGioKetThucSauCa.getValue() == null) {
                alert('Bạn chưa nhập giờ kết thúc làm thêm');
                tfGioKetThucSauCa.focus();
                return false;
            }
            //            if (tfGioBatDauSauCa.getValue() > tfGioKetThucSauCa.getValue()) {
            //                alert('Bạn nhập giờ làm không hợp lý');
            //                tfGioKetThucHL.focus();
            //                return false;
            //            }
            var start = tfGioBatDauSauCa.getValue().split(":");
            var giobatdau = start[0]; var phutbatdau = start[1];
            var end = tfGioKetThucSauCa.getValue().split(":");
            var gioketthuc = end[0]; var phutketthuc = end[1];
            if ((giobatdau * 1 > gioketthuc * 1) || (giobatdau * 1 == gioketthuc * 1) && phutbatdau * 1 > phutketthuc * 1) {
                alert('Bạn nhập giờ làm không hợp lý');
                tfGioKetThucSauCa.focus();
                return false;
            }
            return true;
        }
        var CheckInputThemCanBoHL = function () {
            if (cbxChonCaHL.getValue() == '' || cbxChonCaHL.getValue() == null) {
                alert('Bạn chưa chọn ca làm việc');
                cbxChonCaHL.focus();
                return false;
            }
            if (dfTuNgayHL.getValue() == '') {
                alert('Bạn chưa chọn ngày bắt đầu');
                dfTuNgayHL.focus();
                return false;
            }
            if (dfDenNgayHL.getValue() == '') {
                alert('Bạn chưa chọn ngày kết thúc');
                dfDenNgayHL.focus();
                return false;
            }
            if (tfGioBatDauHL.getValue() == '' || tfGioBatDauHL.getValue() == null) {
                alert('Bạn chưa chọn giờ bắt đầu');
                tfGioBatDauHL.focus();
                return false;
            }
            if (tfGioKetThucHL.getValue() == '' || tfGioKetThucHL.getValue() == null) {
                alert('Bạn chưa chọn giờ kết thúc');
                tfGioKetThucHL.focus();
                return false;
            }
            //            if (tfGioBatDauHL.getValue() > tfGioKetThucHL.getValue()) {
            //                alert('Bạn nhập giờ làm không hợp lý');
            //                tfGioKetThucHL.focus();
            //                return false;
            //            }
            var start = tfGioBatDauHL.getValue().split(":");
            var giobatdau = start[0]; var phutbatdau = start[1];
            var end = tfGioKetThucHL.getValue().split(":");
            var gioketthuc = end[0]; var phutketthuc = end[1];
            if ((giobatdau * 1 > gioketthuc * 1) || (giobatdau * 1 == gioketthuc * 1) && phutbatdau * 1 > phutketthuc * 1) {
                alert('Bạn nhập giờ làm không hợp lý');
                tfGioKetThucHL.focus();
                return false;
            }
            if (grp_DanhSachCanBo.store.getCount() == 0) {
                alert('Bạn chưa chọn cán bộ nào');
                return false;
            }
            if (hdfTotalRecord.getValue() * 1 == 0) {
                alert('Bạn chưa chọn cán bộ nào');
                return false;
            }

            return true;
        }
        var getSelectedIndexRow = function () {
            var record = grp_DanhSachCanBo.getSelectionModel().getSelected();
            var index = grp_DanhSachCanBo.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }

        var addRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi, ten_chucvu, ten_congviec) {
            var rowindex = getSelectedIndexRow();
            grp_DanhSachCanBo.insertRecord(rowindex, {
                PR_KEY: pr_keyhoso,
                MA_CB: ma_cb,
                HO_TEN: ho_ten,
                TEN_DONVI: ten_donvi,
                TEN_CHUCVU: ten_chucvu,
                TEN_CONGVIEC: ten_congviec
            });
            grp_DanhSachCanBo.getView().refresh();
            grp_DanhSachCanBo.getSelectionModel().selectRow(rowindex);
            //grp_DanhSachCanBoStore.commitChanges();
        }
    </script>
    <%--Render Data on grid and reset windows--%>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                grpDangKyLamThemGio.getSelectionModel().clearSelections();
                hdfRecordID.setValue('');
//                grpDangKyLamThemGioStore.reload();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
            if (txtSearch.getValue() == '') {
                this.triggers[0].hide();
            }
        }
        var checkDatetimeFilter = function () {
            if (dfFilterTuNgay.getValue() > dfFilterDenNgay.getValue()) {
                alert('Bạn nhập ngày tháng không hợp lý');
                dfFilterTuNgay.focus();
                return false;
            }
            return true;
        }
        var RenderTongGio = function (startTime, endTime) {
            var startHour = startTime.split(':')[0];
            var startMinute = startTime.split(':')[1];

            var endHour = endTime.split(':')[0];
            var endMinute = endTime.split(':')[1];

            var total = (endHour * 60 + endMinute) - (startHour * 60 + startMinute);
            if (total < (-12 * 60))
                total = total + 24 * 60;
            if (total > (12 * 60))
                total = total - 24 * 60;
            var rs = parseInt(total / 60) + ":" + (total % 60);
            return rs;
        }
        var ResetWdThemCanBo = function () {
            hdfChonCanBo.reset();
            cbxChonCanBo.reset();
            cbxChonCa.reset();
            dfDenNgay.reset();
            tfGioBatDauSauCa.reset();
            dfTuNgay.reset();
            tfGioKetThucSauCa.reset();
            txtGhiChu.reset();
        }
        var ResetWdThemCanBoHL = function () {
            cbxChonCaHL.reset(); dfTuNgayHL.reset(); tfGioBatDauHL.reset();
            dfDenNgayHL.reset(); tfGioKetThucHL.reset(); txtGhiChuHL.reset();
            dfTuNgayHL.setMaxValue(null);
            dfDenNgayHL.setMaxValue(null);
            grp_DanhSachCanBoStore.removeAll();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfTotalRecord" />
        <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" ChiChonMotCanBo="false"
            DisplayWorkingStatus="DangLamViec" />
        <ext:Window runat="server" ID="wdThemCanBo" Constrain="true" Modal="true" Title="Thêm cán bộ đăng ký làm thêm giờ"
            Icon="UserAdd" Layout="FormLayout" AutoHeight="true" Width="550" Hidden="true"
            Padding="6">
            <Items>
                <ext:Container runat="server" ID="ctn1" Layout="ColumnLayout" AnchorHorizontal="100%"
                    Height="78">
                    <Items>
                        <ext:Container runat="server" ID="ctn2" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfChonCanBo" />
                                <ext:ComboBox ID="cbxChonCanBo" ValueField="PRKEY" DisplayField="HOTEN" FieldLabel="Tên cán bộ<span style='color:red'>*</span>"
                                    CtCls="requiredData" PageSize="10" HideTrigger="true" ItemSelector="div.search-item"
                                    MinChars="1" ListWidth="200" EmptyText="nhập tên để tìm kiếm" LoadingText="Đang tải dữ liệu..."
                                    AnchorHorizontal="98%" runat="server">
                                    <Store>
                                        <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/QuyetDinhLuong/SearchUserHandler.ashx" />
                                            </Proxy>
                                            <Reader>
                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="HOTEN" />
                                                        <ext:RecordField Name="MACB" />
                                                        <ext:RecordField Name="NGAYSINH" />
                                                        <ext:RecordField Name="PHONGBAN" />
                                                        <ext:RecordField Name="PRKEY" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template4" runat="server">
                                        <Html>
                                            <tpl for=".">
						                        <div class="search-item">
							                        <h3>{HOTEN}</h3>
                                                    {MACB} <br />
                                                    <tpl if="NGAYSINH &gt; ''">{NGAYSINH:date("d/m/Y")}</tpl><br />
							                        {PHONGBAN}
						                        </div>
					                        </tpl>
                                        </Html>
                                    </Template>
                                    <DirectEvents>
                                        <Select OnEvent="cbxChonCanBo_Selected" />
                                    </DirectEvents>
                                </ext:ComboBox>
                                <ext:DateField runat="server" ID="dfTuNgay" FieldLabel="Từ ngày<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="98%" Vtype="daterange"
                                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày sinh không đúng">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfDenNgay}.setMinValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                                <%--<ext:TimeField ID="tfGioBatDauTruocCa" runat="server" MinTime="00:00" MaxTime="23:59"
                                            Increment="1" Format="H:mm" FieldLabel="Bắt đầu trước ca" AnchorHorizontal="98%"
                                            MaskRe="/[0-9:]/">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:TimeField>--%>
                                <ext:TimeField ID="tfGioBatDauSauCa" runat="server" MinTime="00:00" MaxTime="23:59"
                                    CtCls="requiredData" Increment="1" Format="H:mm" FieldLabel="Giờ bắt đầu<span style='color:red;'>*</span>"
                                    AnchorHorizontal="98%" MaskRe="/[0-9:]/">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:TimeField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctn3" Layout="FormLayout" ColumnWidth=".5" LabelWidth="105">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbxChonCa" FieldLabel="Chọn ca<span style='color:red;'>*</span>"
                                    DisplayField="TenCa" ValueField="ID" AnchorHorizontal="100%" ListWidth="200"
                                    CtCls="requiredData" Editable="false" ItemSelector="div.search-item">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template2" runat="server">
                                        <Html>
                                            <tpl for=".">
						                        <div class="search-item">
							                        <h3>{TenCa}</h3>
                                                    Mã ca: {MaCa} <br />
                                                    Thời gian: {GioVao} - {GioRa}
						                        </div>
					                        </tpl>
                                        </Html>
                                    </Template>
                                    <Store>
                                        <ext:Store runat="server" ID="cbxChonCaStore" AutoLoad="false" OnRefreshData="cbxChonCaStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="MaCa" />
                                                        <ext:RecordField Name="TenCa" />
                                                        <ext:RecordField Name="GioVao" />
                                                        <ext:RecordField Name="GioRa" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Expand Handler="if(cbxChonCa.store.getCount()==0) cbxChonCaStore.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:DateField runat="server" ID="dfDenNgay" FieldLabel="Đến ngày<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="100%" Vtype="daterange"
                                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày sinh không đúng">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfTuNgay}.setMaxValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                                <%--<ext:TimeField ID="tfGioKetThucTruocCa" runat="server" MinTime="00:00" MaxTime="23:59"
                                            Increment="1" Format="H:mm" FieldLabel="Kết thúc trước ca" AnchorHorizontal="100%"
                                            MaskRe="/[0-9:]/">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:TimeField>--%>
                                <ext:TimeField ID="tfGioKetThucSauCa" runat="server" MinTime="00:00" MaxTime="23:59"
                                    CtCls="requiredData" Increment="1" Format="H:mm" FieldLabel="Giờ kết thúc<span style='color:red;'>*</span>"
                                    AnchorHorizontal="100%" MaskRe="/[0-9:]/">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:TimeField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputThemCanBo();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEdit" Text="Cập nhật" Hidden="true" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputThemCanBo();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatDongLai" Text="Cập nhật và đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputThemCanBo();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnClose" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThemCanBo.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetWdThemCanBo();Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdThemCanBoHangLoat" Constrain="true" Modal="true"
            Title="Thêm cán bộ đăng ký làm thêm giờ hàng loạt" Icon="UserAdd" Layout="FormLayout"
            AutoHeight="true" Width="650" Hidden="true" Padding="6">
            <Items>
                <ext:Container runat="server" ID="ctn30" Layout="FormLayout" Height="195" AnchorHorizontal="100%">
                    <Items>
                        <ext:FormPanel runat="server" ID="fp1" Frame="true" AnchorHorizontal="100%" Title="Thông tin đăng ký làm thêm giờ"
                            Icon="Clock" Layout="FormLayout">
                            <Items>
                                <ext:Container runat="server" ID="ctn31" Layout="ColumnLayout" AnchorHorizontal="100%"
                                    Height="78">
                                    <Items>
                                        <ext:Container runat="server" ID="ctn32" Layout="FormLayout" ColumnWidth="0.5">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxChonCaHL" FieldLabel="Chọn ca<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" DisplayField="TenCa" ValueField="ID" AnchorHorizontal="98%"
                                                    TabIndex="14" Editable="false" ItemSelector="div.search-item" StoreID="cbxChonCaStore"
                                                    ListWidth="200">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Template ID="Template1" runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="search-item">
							                                        <h3>{TenCa}</h3>
                                                                    Mã ca: {MaCa} <br />
                                                                    Thời gian: {GioVao} - {GioRa}
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Listeners>
                                                        <Expand Handler="if(cbxChonCa.store.getCount()==0) cbxChonCaStore.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:DateField runat="server" ID="dfTuNgayHL" FieldLabel="Từ ngày<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" AnchorHorizontal="98%" Vtype="daterange"
                                                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                    RegexText="Định dạng ngày sinh không đúng">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfDenNgayHL}.setMinValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:DateField>
                                                <ext:TimeField ID="tfGioBatDauHL" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" FieldLabel="Giờ bắt đầu<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" AnchorHorizontal="98%" MaskRe="/[0-9:]/">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="ctn33" Layout="FormLayout" ColumnWidth="0.5">
                                            <Items>
                                                <ext:Container runat="server" ID="ctn34" AnchorHorizontal="100%" Height="25" />
                                                <ext:DateField runat="server" ID="dfDenNgayHL" FieldLabel="Đến ngày<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" AnchorHorizontal="100%" Vtype="daterange"
                                                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                    RegexText="Định dạng ngày sinh không đúng">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfTuNgayHL}.setMaxValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:DateField>
                                                <ext:TimeField ID="tfGioKetThucHL" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" FieldLabel="Giờ kết thúc<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" AnchorHorizontal="100%" MaskRe="/[0-9:]/">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                                <ext:TextArea runat="server" ID="txtGhiChuHL" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                                </ext:TextArea>
                            </Items>
                        </ext:FormPanel>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="ctn23" Layout="BorderLayout" Height="230">
                    <Items>
                        <ext:GridPanel runat="server" ID="grp_DanhSachCanBo" TrackMouseOver="true" Title="Danh sách cán bộ đăng ký làm thêm giờ"
                            StripeRows="true" Border="true" Region="Center" Icon="User" AutoExpandColumn="TEN_DONVI"
                            AutoExpandMin="150">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbDanhSachQD">
                                    <Items>
                                        <ext:Button runat="server" ID="btnChonDanhSachCanBo" Icon="UserAdd" Text="Chọn cán bộ">
                                            <Listeners>
                                                <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnXoaCanBo" Icon="Delete" Text="Xóa" Disabled="true">
                                            <Listeners>
                                                <Click Handler="#{grp_DanhSachCanBo}.deleteSelected(); #{hdfTotalRecord}.setValue(#{hdfTotalRecord}.getValue()*1 - 1);if(hdfTotalRecord.getValue() ==0){try{btnXoaCanBo.disable();}catch(e){}}" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="grp_DanhSachCanBoStore" AutoLoad="false" runat="server" ShowWarningOnFailure="false"
                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoSave="false" OnBeforeStoreChanged="HandleChanges">
                                    <Reader>
                                        <ext:JsonReader IDProperty="PR_KEY">
                                            <Fields>
                                                <ext:RecordField Name="PR_KEY" />
                                                <ext:RecordField Name="MA_CB" />
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="TEN_DONVI" />
                                                <ext:RecordField Name="TEN_CHUCVU" />
                                                <ext:RecordField Name="TEN_CONGVIEC" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="MA_CB" Header="Mã cán bộ" Locked="true" Width="80" DataIndex="MA_CB" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Locked="true" Width="150" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="150" DataIndex="TEN_DONVI">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_CHUCVU" Header="Chức vụ" Width="110" DataIndex="TEN_CHUCVU">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_CONGVIEC" Header="Vị trí công việc" Width="110" DataIndex="TEN_CONGVIEC">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv1" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModelDangKyHL">
                                    <Listeners>
                                        <RowSelect Handler="try{btnXoaCanBo.enable();}catch(e){}" />
                                        <RowDeselect Handler="try{btnXoaCanBo.disable();}catch(e){}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatHL" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="if (CheckInputThemCanBoHL() == true) #{grp_DanhSachCanBo}.save();" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLaiHL" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThemCanBoHangLoat.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetWdThemCanBoHL();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grpDangKyLamThemGioStore" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="Handler/HandlerDangKyLamThemGio.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="TuNgay" Value="dfFilterTuNgay.getRawValue()" Mode="Raw" />
                <ext:Parameter Name="DenNgay" Value="dfFilterDenNgay.getRawValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MaCB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_DONVI" />
                        <ext:RecordField Name="TEN_CHUCVU" />
                        <ext:RecordField Name="TEN_CONGVIEC" />
                        <ext:RecordField Name="FrBangPhanCaThang" />
                        <ext:RecordField Name="GioBatDauTruocCa" />
                        <ext:RecordField Name="GioKetThucTruocCa" />
                        <ext:RecordField Name="GioBatDauSauCa" />
                        <ext:RecordField Name="GioKetThucSauCa" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                        <ext:RecordField Name="MaCa" />
                        <ext:RecordField Name="TenCa" />
                        <ext:RecordField Name="TongGio" />
                        <ext:RecordField Name="GhiChu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="grpDangKyLamThemGio" Border="false" TrackMouseOver="true" runat="server"
                            StripeRows="true" Header="false" StoreID="grpDangKyLamThemGioStore" AutoExpandColumn="TEN_DONVI"
                            AutoExpandMin="250">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="bts">
                                    <Items>
                                        <ext:Button ID="btnThemNhanVien" runat="server" Text="Thêm cán bộ" Icon="UserAdd">
                                            <Menu>
                                                <ext:Menu runat="server" ID="mnu1">
                                                    <Items>
                                                        <ext:MenuItem runat="server" ID="mnuThemMotCanBo" Icon="User" Text="Đăng ký làm thêm giờ cho một cán bộ">
                                                            <Listeners>
                                                                <Click Handler="btnCapNhat.show(); btnEdit.hide(); btnCapNhatDongLai.show(); wdThemCanBo.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuThemCanBoHangLoat" Icon="User" Text="Đăng ký làm thêm giờ hàng loạt">
                                                            <Listeners>
                                                                <Click Handler="wdThemCanBoHangLoat.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="btnDieuChinh" runat="server" Text="Sửa" Icon="Pencil" Disabled="true">
                                            <Listeners>
                                                <Click Handler="if (CheckSelectedRow(#{grpDangKyLamThemGio}) == false) {return false;} btnCapNhat.hide(); btnEdit.show(); btnCapNhatDongLai.hide();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnDieuChinh_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnXoa" runat="server" Text="Xóa" Icon="Delete" Disabled="true">
                                            <Listeners>
                                                <Click Handler="if (CheckSelectedRowDelete(#{grpDangKyLamThemGio}) == false) {return false;} 
                                                    try{btnDieuChinh.disable();}catch(e){} try{btnXoa.disable();}catch(e){}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnXoa_Click">
                                                    <EventMask ShowMask="true" Msg="Đang xóa dữ liệu. Vui lòng chờ..." />
                                                    <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa?" ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:DateField runat="server" ID="dfFilterTuNgay" FieldLabel="Lọc từ ngày" Width="175"
                                            LabelWidth="65" MaxLength="10" MaskRe="[0-9|/]" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:ToolbarSpacer runat="server" Width="5" />
                                        <ext:DateField runat="server" ID="dfFilterDenNgay" FieldLabel="đến ngày" Width="160"
                                            LabelWidth="50" MaxLength="10" MaskRe="[0-9|/]" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show(); if(checkDatetimeFilter()){PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();}" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc họ tên cán bộ"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" Locked="true" />
                                    <ext:Column ColumnID="MaCB" Header="Mã cán bộ" Locked="true" Width="90" DataIndex="MaCB">
                                    </ext:Column>
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Locked="true" Width="160" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="250" DataIndex="TEN_DONVI" />
                                    <ext:Column ColumnID="TEN_CHUCVU" Header="Chức vụ" Width="150" DataIndex="TEN_CHUCVU" />
                                    <ext:Column ColumnID="TEN_CONGVIEC" Header="Vị trí công việc" Width="100" DataIndex="TEN_CONGVIEC" />
                                    <ext:DateColumn ColumnID="TuNgay" Header="Từ ngày" Width="75" DataIndex="TuNgay"
                                        Format="dd/MM/yyyy">
                                    </ext:DateColumn>
                                    <ext:DateColumn ColumnID="DenNgay" Header="Đến ngày" Width="75" DataIndex="DenNgay"
                                        Format="dd/MM/yyyy">
                                    </ext:DateColumn>
                                    <ext:Column ColumnID="TenCa" Header="Ca" Width="200" DataIndex="TenCa">
                                    </ext:Column>
                                    <%--<ext:Column ColumnID="GioBatDauTruocCa" Header="Giờ bắt đầu trước ca" Width="95"
                                        DataIndex="GioBatDauTruocCa">
                                    </ext:Column>
                                    <ext:Column ColumnID="GioKetThucTruocCa" Header="Giờ kết thúc trước ca" Width="95"
                                        DataIndex="GioKetThucTruocCa">
                                    </ext:Column>--%>
                                    <ext:Column ColumnID="GioBatDauSauCa" Header="Từ giờ" Width="95" DataIndex="GioBatDauSauCa">
                                    </ext:Column>
                                    <ext:Column ColumnID="GioKetThucSauCa" Header="Đến giờ" Width="95" DataIndex="GioKetThucSauCa">
                                    </ext:Column>
                                    <ext:Column ColumnID="TongGio" Header="Tổng giờ" Width="100" DataIndex="TongGio">
                                        <%--<Renderer Handler="return RenderTongGio(record.data.GioBatDauSauCa, record.data.GioKetThucSauCa);" />--%>
                                    </ext:Column>
                                    <ext:Column ColumnID="GhiChu" Header="Ghi chú" Width="150" DataIndex="GhiChu">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(RowSelectionModel1.getSelected().id); try{btnDieuChinh.enable();}catch(e){} try{btnXoa.enable();}catch(e){}" />
                                        <RowDeselect Handler="hdfRecordID.reset(); try{btnDieuChinh.disable();}catch(e){} try{btnXoa.disable();}catch(e){}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <%--<DirectEvents>
                                <RowDblClick OnEvent="btnDieuChinh_Click" Before="if (CheckSelectedRow(#{grpDangKyLamThemGio}) == false) {return false;} btnCapNhat.hide(); btnEdit.show(); btnCapNhatDongLai.hide();">
                                    <EventMask ShowMask="true" />
                                </RowDblClick>
                            </DirectEvents>--%>
                            <LoadMask ShowMask="true" />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="15">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                            </Items>
                                            <SelectedItem Value="15" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
