<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HopDong.aspx.cs" Inherits="Modules_HoSoNhanSu_QuanLy_HopDong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="~/Modules/ChooseEmployee/ucChooseEmployee.ascx" TagPrefix="uc1"
    TagName="ucChooseEmployee" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <link href="../CSS.css" rel="stylesheet" type="text/css" />
    <script src="../../Home/js/jquery.min.js" type="text/javascript"></script>
    <style type="text/css">
        div#grp_HopDong .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }

        #pnReportPanel .x-tab-panel-header {
            display: none !important;
        }

        .Download {
            background-image: url(../../../Resource/images/download.png) !important;
        }
    </style>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="../../../Resource/js/global.js" type="text/javascript"></script>
    <script type="text/javascript">
        var prepare = function (grid, command, record, row, col, value) {
            if (record.data.TepTinDinhKem == '' && command.command == "Download") {
                command.hidden = true;
                command.hideMode = "visibility";
            }
        }
        var keyPresstxtSearch = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                RowSelectionModel1.clearSelections();
                if (this.getValue() == '') {
                    this.triggers[0].hide();
                }
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var checkDeleteAttackFile = function (el, hdf, fuf) {
            var size = 0;
            for (var num1 = 0; num1 < el.files.length; num1++) {
                var file = el.files[num1];
                size += file.size;
            }
            if (size > 10485760) {
                hdf.reset(); fuf.reset();
                return false;
            }
            return true;
        }
        var ResetWdHopDongHangLoat = function () {
            txtHopDongSoHopDongHL.reset(); cbHopDongLoaiHopDongHL.reset(); cbHopDongTinhTrangHopDongHL.reset();
            cbHopDongCongViecHL.reset(); dfHopDongNgayHopDongHL.reset(); dfHopDongNgayKiKetHL.reset();
            dfNgayCoHieuLucHL.reset();
            //cbx_HopDongChucVuHL.reset();
            fufHopDongTepTinHL.reset(); txtHopDongGhiChuHL.reset();
            hdfNguoiKyHangLoat.reset();
            txt_NguoiKyHDHL2.reset(); hdfHopDongTepTinDKHL.reset();
            grp_DanhSachCanBoStore.removeAll();
        }
        var ReloadGrid = function () {
            PagingToolbar1.pageIndex = 0;
            PagingToolbar1.doLoad();
            RowSelectionModel1.clearSelections();
        }
        var triggershowChooseEmplyee = function (f, e) {
            if (e.getKey() == e.ENTER) {
                ucChooseEmployee1_wdChooseUser.show();
            }
        }
        var CheckInputKTKLHangLoat = function (el) {
            if (txtHopDongSoHopDongHL.getValue().trim() == '') {
                alert('Bạn chưa nhập số hợp đồng');
                txtHopDongSoHopDongHL.focus();
                return false;
            }
            if (cbHopDongLoaiHopDongHL.getValue().trim() == '') {
                alert('Bạn chưa chọn loại hợp đồng');
                cbHopDongLoaiHopDongHL.focus();
                return false;
            }
            if (dfHopDongNgayHopDongHL.getValue() == '') {
                alert('Bạn chưa chọn ngày ký hợp đồng');
                dfHopDongNgayHopDongHL.focus();
                return false;
            }
            if (dfNgayCoHieuLucHL.getValue() == '') {
                alert('Bạn chưa nhập ngày hợp đồng có hiệu lực');
                dfNgayCoHieuLucHL.focus();
                return false;
            }

            var size = 0;
            for (var num1 = 0; num1 < el.files.length; num1++) {
                var file = el.files[num1];
                size += file.size;
            }
            if (size > 10485760) {
                alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
                return false;
            }
            if (grp_DanhSachCanBo.store.getCount() == 0) {
                alert('Bạn chưa chọn cán bộ nào!');
                return false;
            }
            return true;
        }
        var searchBoxKT = function (f, e) {
            hdfLyDoKTTemp.setValue(cbLyDoKhenThuong.getRawValue());
            if (hdfIsDanhMuc.getValue() == '1') {
                hdfIsDanhMuc.setValue('2');
            }
            if (cbLyDoKhenThuong.getRawValue() == '') {
                hdfIsDanhMuc.reset();
            }
        }
        var searchBoxKT2 = function (f, e) {
            hdfLyDoTempl.setValue(cbbLyDoHangLoat.getRawValue());
            if (hdfIsDanhMuc.getValue() == '1') {
                hdfIsDanhMuc.setValue('2');
            }
            if (cbbLyDoHangLoat.getRawValue() == '') {
                hdfIsDanhMuc.reset();
            }
        }
        var SetTitlewdKhenThuong = function () {
            if (hdfTypePage.getValue() == "KyLuat") {
                wdKhenThuong.setTitle("Thông tin kỷ luật");
                cbxCapKhenThuong.setFieldLabel("Cấp kỷ luật<span style='color:red'>*</span>");
                cbLyDoKhenThuong.setFieldLabel("Lý do kỷ luật<span style='color:red'>*</span>");
            } else {
                wdKhenThuong.setTitle("Thông tin khen thưởng");
                cbLyDoKhenThuong.setFieldLabel("Lý do khen thưởng<span style='color:red'>*</span>");
                cbxCapKhenThuong.setFieldLabel("Cấp khen thưởng<span style='color:red'>*</span>");
            }
            txtKhenThuongSoQuyetDinh.focus();
        }
        var addRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi) {
            var rowindex = getSelectedIndexRow();
            grp_DanhSachCanBo.insertRecord(rowindex, {
                PR_KEY: pr_keyhoso,
                MA_CB: ma_cb,
                HO_TEN: ho_ten,
                TEN_DONVI: ten_donvi
            });
            grp_DanhSachCanBo.getView().refresh();
            grp_DanhSachCanBo.getSelectionModel().selectRow(rowindex);
        }
        var getSelectedIndexRow = function () {
            var record = grp_DanhSachCanBo.getSelectionModel().getSelected();
            var index = grp_DanhSachCanBo.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }
        var ResetWdHopDong = function () {
            txtHopDongSoHopDong.reset(); cbHopDongLoaiHopDong.reset(); cbHopDongTinhTrangHopDong.reset();
            cbHopDongCongViec.reset(); dfHopDongNgayHopDong.reset(); dfHopDongNgayKiKet.reset();
            dfNgayCoHieuLuc.reset();
            //cbx_HopDongChucVu.reset();
            fufHopDongTepTin.reset(); txtHopDongGhiChu.reset();
            hdfPrkeyNguoiKyHD.reset();
            tgf_NguoiKyHD.reset(); hdfHopDongTepTinDK.reset();
        }
        var onKeyUp = function (field) {
            var v = this.processValue(this.getRawValue()),
                field;
            if (this.startDateField) {
                field = Ext.getCmp(this.startDateField);
                field.setMaxValue();
                this.dateRangeMax = null;
            } else if (this.endDateField) {
                field = Ext.getCmp(this.endDateField);
                field.setMinValue();
                this.dateRangeMin = null;
            }
            field.validate();
        }
        var CheckInputHopDong = function (el) {
            if (txtHopDongSoHopDong.getValue().trim() == '') {
                alert('Bạn chưa nhập số hợp đồng');
                txtHopDongSoHopDong.focus();
                return false;
            }
            if (cbHopDongLoaiHopDong.getValue().trim() == '') {
                alert('Bạn chưa chọn loại hợp đồng');
                cbHopDongLoaiHopDong.focus();
                return false;
            }
            if (dfHopDongNgayHopDong.getValue() == '') {
                alert('Bạn chưa chọn ngày ký hợp đồng');
                dfHopDongNgayHopDong.focus();
                return false;
            }
            if (dfNgayCoHieuLuc.getValue() == '') {
                alert('Bạn chưa nhập ngày hợp đồng có hiệu lực');
                dfNgayCoHieuLuc.focus();
                return false;
            }

            var size = 0;
            for (var num1 = 0; num1 < el.files.length; num1++) {
                var file = el.files[num1];
                size += file.size;
            }
            if (size > 10485760) {
                alert('Phần mềm chỉ hỗ trợ các tệp tin đính kèm nhỏ hơn 10MB');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="RM" runat="server">
            </ext:ResourceManager>
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfPrKey" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfMenuID" />
            <ext:Hidden runat="server" ID="hdfTotalRecord" />
            <ext:Hidden runat="server" ID="hdfUserID" />
            <ext:Hidden runat="server" ID="hdfTypeWindow" />
            <ext:Store runat="server" AutoLoad="false" ID="StoreCongViec">
                <Proxy>
                    <ext:HttpProxy Method="POST" Url="../SearchDanhMucHandler.ashx" />
                </Proxy>
                <BaseParams>
                    <ext:Parameter Name="table" Value="DM_CONGVIEC" Mode="Value" />
                    <ext:Parameter Name="ma" Value="MA_CONGVIEC" Mode="Value" />
                    <ext:Parameter Name="ten" Value="TEN_CONGVIEC" Mode="Value" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="plants" TotalProperty="total" IDProperty="MA">
                        <Fields>
                            <ext:RecordField Name="MA" />
                            <ext:RecordField Name="TEN" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <uc1:ucChooseEmployee runat="server" ID="ucChooseEmployee" ChiChonMotCanBo="false"
                DisplayWorkingStatus="DangLamViec" />
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" ChiChonMotCanBo="true"
                DisplayWorkingStatus="DangLamViec" />
            <ext:Store runat="server" ID="cbHopDongLoaiHopDongStore" AutoLoad="false">
                <Proxy>
                    <ext:HttpProxy Method="POST" Url="../SearchDanhMucHandler.ashx" />
                </Proxy>
                <BaseParams>
                    <ext:Parameter Name="table" Value="DM_LOAI_HDONG" Mode="Value" />
                    <ext:Parameter Name="ma" Value="MA_LOAI_HDONG" Mode="Value" />
                    <ext:Parameter Name="ten" Value="TEN_LOAI_HDONG" Mode="Value" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="plants" TotalProperty="total" IDProperty="MA">
                        <Fields>
                            <ext:RecordField Name="MA" />
                            <ext:RecordField Name="TEN" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Store runat="server" ID="cbHopDongTinhTrangHopDongStore" AutoLoad="false">
                <Proxy>
                    <ext:HttpProxy Method="POST" Url="../SearchDanhMucHandler.ashx" />
                </Proxy>
                <BaseParams>
                    <ext:Parameter Name="table" Value="DM_TT_HDONG" Mode="Value" />
                    <ext:Parameter Name="ma" Value="MA_TT_HDONG" Mode="Value" />
                    <ext:Parameter Name="ten" Value="TEN_TT_HDONG" Mode="Value" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="plants" TotalProperty="total" IDProperty="MA">
                        <Fields>
                            <ext:RecordField Name="MA" />
                            <ext:RecordField Name="TEN" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Store runat="server" ID="cbx_HopDongChucVu_Store" AutoLoad="false">
                <Proxy>
                    <ext:HttpProxy Method="POST" Url="../SearchDanhMucHandler.ashx" />
                </Proxy>
                <BaseParams>
                    <ext:Parameter Name="table" Value="DM_CHUCVU" Mode="Value" />
                    <ext:Parameter Name="ma" Value="MA_CHUCVU" Mode="Value" />
                    <ext:Parameter Name="ten" Value="TEN_CHUCVU" Mode="Value" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="plants" TotalProperty="total" IDProperty="MA">
                        <Fields>
                            <ext:RecordField Name="MA" />
                            <ext:RecordField Name="TEN" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Window ID="wdHopDong" AutoHeight="true" Width="550" runat="server" Padding="6"
                EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
                Icon="Pencil" Title="Hợp đồng" Resizable="false">
                <Items>
                    <ext:Container ID="Container4" runat="server" Layout="Column" Height="27">
                        <Items>
                            <ext:Container ID="Container5" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:CompositeField ID="CompositeField11" runat="server" AnchorHorizontal="99%">
                                        <Items>
                                            <ext:TextField runat="server" FieldLabel="Số hợp đồng<span style='color:red;'>*</span>"
                                                Width="120" ID="txtHopDongSoHopDong" MaxLength="30" CtCls="requiredData" />
                                            <ext:Button runat="server" ID="btnSinhSoHopDong" Icon="Reload">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip1" runat="server" Title="Hướng dẫn" Html="Sinh số hợp đồng mới (Chỉ áp dụng cho trường hợp chưa có số hợp đồng)" />
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="if (#{txtHopDongSoHopDong}.getValue().trim() != '' && #{txtHopDongSoHopDong}.getValue() != null) { this.blur(); alert('Số hợp đồng đã được sinh');} else {#{DirectMethods}.GenerateSoQD();}" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:CompositeField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container6" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:ComboBox runat="server" ID="cbHopDongTinhTrangHopDong" DisplayField="TEN"
                                        ItemSelector="div.list-item" FieldLabel="Tình trạng HĐ" Editable="true" ValueField="MA"
                                        AnchorHorizontal="98%" StoreID="cbHopDongTinhTrangHopDongStore">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Template ID="Template4" runat="server">
                                            <Html>
                                                <tpl for=".">
						                        <div class="list-item"> 
							                        {TEN}
						                        </div>
					                        </tpl>
                                            </Html>
                                        </Template>
                                        <Listeners>
                                            <Focus Handler="#{cbHopDongTinhTrangHopDongStore}.reload();" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Hidden runat="server" ID="hdfMaHopDongOld" />
                    <ext:ComboBox runat="server" ID="cbHopDongLoaiHopDong" DisplayField="TEN" MinChars="1" PageSize="15"
                        ItemSelector="div.list-item" FieldLabel="Loại hợp đồng<span style='color:red;'>*</span>"
                        Editable="true" ValueField="MA" AnchorHorizontal="99%" CtCls="requiredData"
                        StoreID="cbHopDongLoaiHopDongStore">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Template ID="Template2" runat="server">
                            <Html>
                                <tpl for=".">
						            <div class="list-item"> 
							            {TEN}
						            </div>
					            </tpl>
                            </Html>
                        </Template>
                        <Listeners>
                            <Focus Handler="#{cbHopDongLoaiHopDongStore}.reload();" />
                            <Select Handler="this.triggers[0].show();#{DirectMethods}.SetNgayHetHD();" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:ComboBox runat="server" ID="cbHopDongCongViec" DisplayField="TEN" FieldLabel="Chức vụ" MinChars="1" PageSize="15"
                        StoreID="StoreCongViec" Editable="true" ValueField="MA" AnchorHorizontal="99%"
                        ItemSelector="div.list-item">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Template ID="Template5" runat="server">
                            <Html>
                                <tpl for=".">
						            <div class="list-item"> 
							            {TEN}
						            </div>
					            </tpl>
                            </Html>
                        </Template>
                        <Listeners>
                            <Focus Handler="#{StoreCongViec}.reload();" />
                            <Select Handler="this.triggers[0].show();" />
                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                        </Listeners>
                    </ext:ComboBox>
                    <%--<ext:ComboBox runat="server" ID="cbx_HopDongChucVu" FieldLabel="Chức vụ" DisplayField="TEN"
                        StoreID="cbx_HopDongChucVu_Store" ValueField="MA" AnchorHorizontal="99%"
                        Editable="true" ItemSelector="div.list-item">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Template ID="Template27" runat="server">
                            <Html>
                                <tpl for=".">
						                <div class="list-item"> 
							                {TEN}
						                </div>
					                </tpl>
                            </Html>
                        </Template>
                        <Listeners>
                            <Expand Handler="if(#{cbx_HopDongChucVu}.store.getCount()==0) #{cbx_HopDongChucVu_Store}.reload();" />
                            <Select Handler="this.triggers[0].show();" />
                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                        </Listeners>
                    </ext:ComboBox>--%>
                    <ext:Container ID="Container43" runat="server" Layout="Column" Height="52">
                        <Items>
                            <ext:Container ID="Container44" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:DateField runat="server" Vtype="daterange" FieldLabel="Ngày ký kết<span style='color:red;'>*</span>"
                                        ID="dfHopDongNgayHopDong" AnchorHorizontal="99%" Editable="true" MaskRe="/[0-9\/]/"
                                        Format="d/M/yyyy" CtCls="requiredData" TabIndex="5">
                                    </ext:DateField>
                                    <ext:Hidden runat="server" ID="hdfPrkeyNguoiKyHD" />
                                    <ext:TriggerField runat="server" ID="tgf_NguoiKyHD" FieldLabel="Người ký HD"
                                        AnchorHorizontal="99%" Editable="true" TabIndex="8">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" />
                                            <ext:FieldTrigger Icon="SimplePlus" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="if(index == 1){ucChooseEmployee1_wdChooseUser.show();}
                                                                    else if(index==0){ #{hdfPrKeyNguoiKyHD}.reset(); this.clear(); }  " />
                                        </Listeners>
                                    </ext:TriggerField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container45" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:DateField runat="server" FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>"
                                        ID="dfNgayCoHieuLuc" AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/"
                                        Format="d/M/yyyy" CtCls="requiredData" TabIndex="6">
                                        <Listeners>
                                            <Select Handler="#{DirectMethods}.SetNgayHetHD();" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:DateField runat="server" Vtype="daterange" FieldLabel="Ngày hết hạn" ID="dfHopDongNgayKiKet"
                                        AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" TabIndex="7">
                                    </ext:DateField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Hidden runat="server" ID="hdfHopDongTepTinDK" />
                    <ext:CompositeField ID="CompositeField2" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
                        <Items>
                            <ext:FileUploadField ID="fufHopDongTepTin" runat="server" EmptyText="Chọn tệp tin"
                                ButtonText="" Icon="Attach" Width="380">
                            </ext:FileUploadField>
                            <ext:Button runat="server" ID="btnHopDongAttachDownload" Icon="ArrowDown" ToolTip="Tải về" Hidden="true">
                                <DirectEvents>
                                    <Click OnEvent="btnHopDongAttachDownload_Click" IsUpload="true" />
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" ID="btnHopDongAttachDelete" Icon="Delete" ToolTip="Xóa">
                                <Listeners>
                                    <Click Handler="return checkDeleteAttackFile(#{fufHopDongTepTin}.fileInput.dom, #{hdfHopDongTepTinDK}, #{fufHopDongTepTin});" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnHopDongAttachDelete_Click" After="#{fufHopDongTepTin}.reset();">
                                        <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                            ConfirmRequest="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:CompositeField>
                    <ext:TextArea runat="server" ID="txtHopDongGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="99%"
                        TabIndex="11" />
                </Items>
                <Buttons>
                    <ext:Button ID="btnUpdateHopDong" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputHopDong(#{fufHopDongTepTin}.fileInput.dom);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateHopDong_Click" After="ResetWdHopDong();">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnEditHopDong" Icon="Disk" Hidden="true" Text="Cập nhật">
                        <Listeners>
                            <Click Handler="return CheckInputHopDong(#{fufHopDongTepTin}.fileInput.dom);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateHopDong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Update">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button20" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputHopDong(#{fufHopDongTepTin}.fileInput.dom);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateHopDong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button21" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdHopDong}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="#{btnUpdateHopDong}.show();#{btnEditHopDong}.hide();#{Button20}.show();ResetWdHopDong();" />
                    <Show Handler="hdfTypeWindow.setValue('One');" />
                </Listeners>
            </ext:Window>
            <ext:Viewport ID="vp" runat="server" HideBorders="true">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:GridPanel ID="grp_HopDong" TrackMouseOver="true" Header="false" runat="server"
                                StripeRows="true" Border="false" AnchorHorizontal="100%">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:Button runat="server" ID="btnAdd" Text="Thêm" Icon="Add">
                                                <Listeners>
                                                    <Click Handler="btnUpdateHopDong.show();btnEditHopDong.hide();Button20.show();wdHopDongHangLoat.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnEdit" Text="Sửa" Icon="Pencil" Disabled="true">
                                                <Listeners>
                                                    <Click Handler="if (CheckSelectedRows(grp_HopDong) == false) {return false;} btnUpdateHopDong.hide();btnEditHopDong.show();Button20.hide();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnEdit_Click">
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnDelete" Text="Xóa" Icon="Delete" Disabled="true">
                                                <Listeners>
                                                    <Click Handler="return CheckSelectedRow(grp_HopDong);" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnDelete_Click">
                                                        <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa?"
                                                            ConfirmRequest="true" />
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:ToolbarSpacer Width="5" />
                                            <ext:Button runat="server" Text="Báo cáo" ID="btnPrint" Icon="Printer" Hidden="true">
                                                <%--<Listeners>
                                                <Click Handler="wdShowReport.show();" />
                                            </Listeners>--%>
                                            </ext:Button>
                                            <ext:ToolbarSeparator />
                                            <%--     <ext:ToolbarSpacer Width="5" />--%>
                                            <ext:DisplayField ID="DisplayField1" runat="server" Text="Từ ngày: " Hidden="true" />
                                            <ext:ToolbarSpacer Width="5" />
                                            <ext:DateField ID="dfNgayBatDau" runat="server" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                                Vtype="daterange" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Width="120" Hidden="true">
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    <TriggerClick Handler="if (index == 0) { this.reset();dfNgayKetThuc.setMinValue(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                                </Listeners>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                            </ext:DateField>
                                            <ext:ToolbarSpacer Width="10" />
                                            <ext:DisplayField ID="DisplayField2" runat="server" Text="đến ngày: " Hidden="true" />
                                            <ext:ToolbarSpacer Width="5" />
                                            <ext:DateField ID="dfNgayKetThuc" runat="server" AnchorHorizontal="100%" MaskRe="/[0-9\/]/"
                                                Hidden="true" Format="d/M/yyyy" Vtype="daterange" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Width="120">
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    <TriggerClick Handler="if (index == 0) { this.reset();dfNgayBatDau.setMaxValue(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                                </Listeners>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                            </ext:DateField>
                                            <ext:ToolbarFill />
                                            <ext:TriggerField runat="server" ID="txtSearch" EnableKeyEvents="true" Width="220"
                                                EmptyText="Nhập mã, họ tên nhân viên">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="keyPresstxtSearch" />
                                                    <TriggerClick Handler="this.triggers[0].hide(); this.clear();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); RowSelectionModel1.clearSelections();" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button runat="server" ID="btnSearch" Text="Tìm kiếm" Icon="Zoom">
                                                <Listeners>
                                                    <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); RowSelectionModel1.clearSelections();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store runat="server" ID="StoreHopDong">
                                        <Proxy>
                                            <ext:HttpProxy Method="POST" Url="Handler/HandlerHopDong.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={25}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="TuNgay" Value="dfNgayBatDau.getRawValue()" Mode="Raw" />
                                            <ext:Parameter Name="DenNgay" Value="dfNgayKetThuc.getRawValue()" Mode="Raw" />
                                            <ext:Parameter Name="LoaiHopDong" Value="cb_LoaiHopDong_Find.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="ChucDanh" Value="filterCongViec.getValue()" Mode="Raw" />
                                            <%--<ext:Parameter Name="ChucVu" Value="filterChucVu.getValue()" Mode="Raw" />--%>
                                            <ext:Parameter Name="TinhTrangHD" Value="cbx_TinhTrangHD_Find.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="PR_KEY" Root="plants" TotalProperty="total">
                                                <Fields>
                                                    <ext:RecordField Name="PR_KEY" Type="Float" />
                                                    <ext:RecordField Name="FR_KEY" />
                                                    <ext:RecordField Name="MA_CB" />
                                                    <ext:RecordField Name="HO_TEN" />
                                                    <ext:RecordField Name="SO_HDONG" />
                                                    <ext:RecordField Name="TEN_LOAI_HDONG" />
                                                    <ext:RecordField Name="TEN_CONGVIEC" />
                                                    <ext:RecordField Name="TEN_CHUCVU" />
                                                    <ext:RecordField Name="NGAY_HDONG" />
                                                    <ext:RecordField Name="NgayCoHieuLuc" />
                                                    <ext:RecordField Name="NGAYKT_HDONG" />
                                                    <ext:RecordField Name="TEN_TT_HDONG" />
                                                    <ext:RecordField Name="NguoiKy" />
                                                    <ext:RecordField Name="TepTinDinhKem" />
                                                    <ext:RecordField Name="GhiChu" />
                                                    <ext:RecordField Name="TEN_DONVI" />
                                                    <%--<ext:RecordField Name="DonViQuanLy" />--%>
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                        <Listeners>
                                            <Load Handler="#{RowSelectionModel1}.clearSelections();" />
                                        </Listeners>
                                    </ext:Store>
                                </Store>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="35" Locked="true" />
                                        <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                            <Commands>
                                                <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                                    <ToolTip Text="Tải tệp tin đính kèm" />
                                                </ext:ImageCommand>
                                            </Commands>
                                            <PrepareCommand Fn="prepare" />
                                        </ext:Column>
                                        <ext:Column Header="Mã nhân viên" Width="85" Align="Left" Locked="true" DataIndex="MA_CB" />
                                        <ext:Column Header="Họ tên" Width="150" Align="Left" Locked="true" DataIndex="HO_TEN" />
                                        <ext:Column Header="Phòng ban" Width="200" Align="Left" DataIndex="TEN_DONVI" />
                                        <%--<ext:Column Header="Đơn vị quản lý" Width="250" Align="Left" DataIndex="DonViQuanLy" />--%>
                                        <ext:Column Header="Số hợp đồng" Width="120" Align="Left" DataIndex="SO_HDONG" />
                                        <ext:Column Header="Loại hợp đồng" Width="200" Align="Left" DataIndex="TEN_LOAI_HDONG" />
                                        <ext:Column Header="Chức vụ" Width="150" Align="Left" DataIndex="TEN_CONGVIEC" />
                                        <%--<ext:Column Header="Chức vụ" Width="150" Align="Left" DataIndex="TEN_CHUCVU" />--%>
                                        <ext:Column Header="Tình trạng hợp đồng" Width="150" Align="Left" DataIndex="TEN_TT_HDONG" />
                                        <ext:DateColumn Header="Ngày ký kết" Width="90" Align="Center" DataIndex="NGAY_HDONG"
                                            Format="dd/MM/yyyy" />
                                        <ext:DateColumn Header="Ngày hiệu lực" Width="90" Align="Center" DataIndex="NgayCoHieuLuc"
                                            Format="dd/MM/yyyy" />
                                        <ext:DateColumn Header="Ngày hết hạn" Width="90" Align="Center" DataIndex="NGAYKT_HDONG"
                                            Format="dd/MM/yyyy" />

                                        <ext:Column Header="Người ký HĐ" Width="150" Align="Left" DataIndex="NguoiKy" />
                                        <ext:Column Header="Ghi chú" Width="300" Align="Left" DataIndex="GhiChu" />
                                        <ext:Column ColumnID="Hidden" Width="0" DataIndex="" Align="Center" Locked="false">
                                            <Commands>
                                                <ext:ImageCommand CommandName="Hidden">
                                                </ext:ImageCommand>
                                            </Commands>
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv">
                                        <HeaderRows>
                                            <ext:HeaderRow>
                                                <Columns>
                                                    <%--                     <ext:HeaderColumn AutoWidthElement="false" />--%>
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox runat="server" ID="cb_LoaiHopDong_Find" DisplayField="TEN" MinChars="1" PageSize="15"
                                                                ItemSelector="div.list-item" Editable="true" ValueField="MA" Width="200"
                                                                TabIndex="2" EmptyText="gõ để tìm kiếm" StoreID="cbHopDongLoaiHopDongStore">
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Template ID="Template8" runat="server">
                                                                    <Html>
                                                                        <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                    </Html>
                                                                </Template>
                                                                <Listeners>
                                                                    <Focus Handler="#{cbHopDongLoaiHopDongStore}.reload();" />
                                                                    <Select Handler="this.triggers[0].show();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); 
                                                                                if (cb_LoaiHopDong_Find.getValue() == '-1') {$('#cb_LoaiHopDong_Find').removeClass('combo-selected');}
                                                                                else {$('#cb_LoaiHopDong_Find').addClass('combo-selected');}" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();
                                                                                        #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();$('#cb_LoaiHopDong_Find').removeClass('combo-selected'); }" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox runat="server" ID="filterCongViec" DisplayField="TEN" ValueField="MA" Width="150"
                                                                MinChars="1" PageSize="20" Editable="true" ListWidth="200" ItemSelector="div.list-item"
                                                                StoreID="StoreCongViec" LoadingText="Đang tải dữ liệu..." EmptyText="gõ để tìm kiếm">
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Template ID="Template18" runat="server">
                                                                    <Html>
                                                                        <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                    </Html>
                                                                </Template>
                                                                <Listeners>
                                                                    <Focus Handler="StoreCongViec.reload();" />
                                                                    <Select Handler="this.triggers[0].show();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();
                                                                 if (filterCongViec.getValue() == '-1') {$('#filterCongViec').removeClass('combo-selected');}
                                                                                else {$('#filterCongViec').addClass('combo-selected');}" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();
                                                                $('#filterCongViec').removeClass('combo-selected');} " />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <%--<ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox runat="server" ID="filterChucVu" DisplayField="TEN" ValueField="MA" Width="150"
                                                                MinChars="1" PageSize="20" EmptyText="gõ để tìm kiếm" Editable="true"
                                                                ListWidth="200" ItemSelector="div.list-item" StoreID="cbx_HopDongChucVu_Store"
                                                                LoadingText="Đang tải dữ liệu...">
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Template ID="Template39" runat="server">
                                                                    <Html>
                                                                        <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                    </Html>
                                                                </Template>
                                                                <Listeners>
                                                                    <Expand Handler="cbx_HopDongChucVu_Store.reload();" />
                                                                    <Select Handler="this.triggers[0].show(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();
                                                                  if (filterChucVu.getValue() == '-1') {$('#filterChucVu').removeClass('combo-selected');}
                                                                                else {$('#filterChucVu').addClass('combo-selected');}" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex =0; #{PagingToolbar1}.doLoad();
                                                                $('#filterChucVu').removeClass('combo-selected');}" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>--%>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox runat="server" ID="cbx_TinhTrangHD_Find" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                                                                ItemSelector="div.list-item" Editable="true" ValueField="MA" Width="200"
                                                                TabIndex="3" EmptyText="gõ để tìm kiếm" StoreID="cbHopDongTinhTrangHopDongStore">
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Template ID="Template9" runat="server">
                                                                    <Html>
                                                                        <tpl for=".">
						                                            <div class="list-item"> 
							                                            {TEN}
						                                            </div>
					                                            </tpl>
                                                                    </Html>
                                                                </Template>
                                                                <Listeners>
                                                                    <Expand Handler="#{cbHopDongTinhTrangHopDongStore}.reload();" />
                                                                    <Select Handler="this.triggers[0].show(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();
                                                                  if (cbx_TinhTrangHD_Find.getValue() == '-1') {$('#cbx_TinhTrangHD_Find').removeClass('combo-selected');}
                                                                                else {$('#cbx_TinhTrangHD_Find').addClass('combo-selected');}" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); 
                                                                $('#cbx_TinhTrangHD_Find').removeClass('combo-selected');}" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                </Columns>
                                            </ext:HeaderRow>
                                        </HeaderRows>
                                    </ext:LockingGridView>
                                </View>
                                <LoadMask ShowMask="true" Msg="Đang tải...." />
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="RowSelectionModel1">
                                        <Listeners>
                                            <RowSelect Handler="hdfRecordID.setValue(RowSelectionModel1.getSelected().data.PR_KEY);hdfPrKey.setValue(RowSelectionModel1.getSelected().data.FR_KEY); " />
                                            <%--<RowDeselect Handler="hdfRecordID.reset();" />--%>
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <Listeners>
                                    <ViewReady Handler="if(#{cbHopDongLoaiHopDong}.store.getCount()==0){#{cbHopDongLoaiHopDongStore}.reload();}
                                        if(#{cbHopDongTinhTrangHopDong}.store.getCount()==0){#{cbHopDongTinhTrangHopDongStore}.reload();}
                                        if(#{cbHopDongCongViec}.store.getCount()==0){#{StoreCongViec}.reload();}
                                        " />
                                    <%--if(#{cbx_HopDongChucVu}.store.getCount()==0) #{cbx_HopDongChucVu_Store}.reload();--%>
                                    <Command Handler="Ext.net.DirectMethods.DownloadAttach(record.data.TepTinDinhKem, {isUpload: true});" />
                                </Listeners>
                                <Listeners>
                                    <RowDblClick Handler="" />
                                </Listeners>
                                <DirectEvents>
                                    <RowDblClick>
                                        <EventMask ShowMask="true" />
                                    </RowDblClick>
                                </DirectEvents>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên một trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="15" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="100" />
                                                    <ext:ListItem Text="200" />
                                                    <ext:ListItem Text="500" />
                                                    <ext:ListItem Text="1000" />
                                                    <ext:ListItem Text="2000" />
                                                    <ext:ListItem Text="5000" />
                                                    <ext:ListItem Text="10000" />
                                                </Items>
                                                <SelectedItem Value="25" />
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
            <ext:Window runat="server" ID="wdHopDongHangLoat" Constrain="true" Modal="true" Title="Thêm hợp đồng hàng loạt"
                Icon="UserAdd" Layout="FormLayout" Resizable="false" AutoHeight="true" Width="650"
                Hidden="true" Padding="6" LabelWidth="120">
                <Items>
                    <ext:Container ID="Container7" runat="server" Layout="Column" Height="27">
                        <Items>
                            <ext:Container ID="Container8" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5"
                                LabelWidth="120">
                                <Items>
                                    <ext:CompositeField ID="CompositeField1" runat="server" AnchorHorizontal="99%">
                                        <Items>
                                            <ext:TextField runat="server" FieldLabel="Số hợp đồng<span style='color:red;'>*</span>"
                                                Width="150" ID="txtHopDongSoHopDongHL" MaxLength="30" CtCls="requiredData" />
                                            <ext:Button runat="server" ID="Button1" Icon="Reload">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip2" runat="server" Title="Hướng dẫn" Html="Sinh số hợp đồng mới (Chỉ áp dụng cho trường hợp chưa có số hợp đồng)" />
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="if (#{txtHopDongSoHopDongHL}.getValue().trim() != '' && #{txtHopDongSoHopDongHL}.getValue() != null) { this.blur(); alert('Số hợp đồng đã được sinh');} else {#{DirectMethods}.GenerateSoQDHL();}" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:CompositeField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container9" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:ComboBox runat="server" ID="cbHopDongTinhTrangHopDongHL" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                                        ItemSelector="div.list-item" FieldLabel="Tình trạng HĐ" Editable="true" ValueField="MA"
                                        AnchorHorizontal="98%" StoreID="cbHopDongTinhTrangHopDongStore">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Template ID="Template3" runat="server">
                                            <Html>
                                                <tpl for=".">
				                                    <div class="list-item"> 
					                                    {TEN}
				                                    </div>
			                                    </tpl>
                                            </Html>
                                        </Template>
                                        <Listeners>
                                            <Focus Handler="#{cbHopDongTinhTrangHopDongStore}.reload();" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Hidden runat="server" ID="hdfLoaiHopDong" />
                    <ext:ComboBox runat="server" ID="cbHopDongLoaiHopDongHL" DisplayField="TEN" MinChars="1" PageSize="15"
                        ItemSelector="div.list-item" FieldLabel="Loại hợp đồng<span style='color:red;'>*</span>"
                        Editable="true" StoreID="cbHopDongLoaiHopDongStore" ValueField="MA"
                        AnchorHorizontal="99%" CtCls="requiredData">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Template ID="Template1" runat="server">
                            <Html>
                                <tpl for=".">
						            <div class="list-item"> 
							            {TEN}
						            </div>
					            </tpl>
                            </Html>
                        </Template>
                        <Listeners>
                            <Focus Handler="#{cbHopDongLoaiHopDongStore}.reload();" />
                            <Select Handler="this.triggers[0].show();#{DirectMethods}.SetNgayHetHDHL();" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:ComboBox runat="server" ID="cbHopDongCongViecHL" DisplayField="TEN" MinChars="1" PageSize="15"
                        FieldLabel="Chức vụ" StoreID="StoreCongViec" Editable="true" ValueField="MA"
                        AnchorHorizontal="99%" ItemSelector="div.list-item">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Template ID="Template6" runat="server">
                            <Html>
                                <tpl for=".">
						            <div class="list-item"> 
							            {TEN}
						            </div>
					            </tpl>
                            </Html>
                        </Template>
                        <Listeners>
                            <Focus Handler="#{StoreCongViec}.reload();" />
                            <Select Handler="this.triggers[0].show();" />
                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:Container ID="Container1" runat="server" Layout="Column" Height="60">
                        <Items>
                            <ext:Container ID="Container2" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5"
                                LabelWidth="120">
                                <Items>

                                    <ext:DateField runat="server" Vtype="daterange" FieldLabel="Ngày ký kết<span style='color:red;'>*</span>"
                                        ID="dfHopDongNgayHopDongHL" AnchorHorizontal="99%" Editable="true" MaskRe="/[0-9\/]/"
                                        Format="d/M/yyyy" CtCls="requiredData">
                                    </ext:DateField>
                                    <%--<ext:TextField ID="txt_NguoiKyHDHL" runat="server" FieldLabel="Người ký HĐ" AllowBlank="false"
                                        AnchorHorizontal="99%" MaxLength="20" LabelWidth="165" Width="300">
                                    </ext:TextField>--%>
                                    <ext:Hidden runat="server" ID="hdfNguoiKyHangLoat" />
                                    <ext:TriggerField runat="server" ID="txt_NguoiKyHDHL2" FieldLabel="Người ký HD"
                                        AnchorHorizontal="99%" Editable="true" TabIndex="8">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" />
                                            <ext:FieldTrigger Icon="SimplePlus" />
                                        </Triggers>
                                        <Listeners>
                                            <TriggerClick Handler="if(index == 1){ucChooseEmployee1_wdChooseUser.show();}
                                                                    else if(index==0){#{hdfNguoiKyHangLoat}.setValue('');this.clear(); }  " />
                                        </Listeners>
                                    </ext:TriggerField>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container3" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <%--<ext:ComboBox runat="server" ID="cbx_HopDongChucVuHL" FieldLabel="Chức vụ" DisplayField="TEN"
                                        StoreID="cbx_HopDongChucVu_Store" ValueField="MA" AnchorHorizontal="98%"
                                        Editable="true" ItemSelector="div.list-item">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Template ID="Template7" runat="server">
                                            <Html>
                                                <tpl for=".">
						                <div class="list-item"> 
							                {TEN}
						                </div>
					                </tpl>
                                            </Html>
                                        </Template>
                                        <Listeners>
                                            <Expand Handler="if(#{cbx_HopDongChucVuHL}.store.getCount()==0) #{cbx_HopDongChucVu_Store}.reload();" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>--%>
                                    <ext:DateField runat="server" FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>"
                                        ID="dfNgayCoHieuLucHL" AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/"
                                        Format="d/M/yyyy" CtCls="requiredData">
                                        <Listeners>
                                            <Select Handler="#{DirectMethods}.SetNgayHetHDHL();" />
                                            <Blur Handler="#{DirectMethods}.SetNgayHetHDHL();" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:DateField runat="server" Vtype="daterange" FieldLabel="Ngày hết hạn" ID="dfHopDongNgayKiKetHL"
                                        AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy">
                                    </ext:DateField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Hidden runat="server" ID="hdfHopDongTepTinDKHL" />
                    <ext:CompositeField ID="CompositeField3" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
                        <Items>
                            <ext:FileUploadField ID="fufHopDongTepTinHL" runat="server" EmptyText="Chọn tệp tin"
                                ButtonText="" Icon="Attach" Width="460">
                            </ext:FileUploadField>
                            <ext:Button runat="server" ID="Button2" Icon="ArrowDown" ToolTip="Tải về" Hidden="true">
                                <DirectEvents>
                                    <Click OnEvent="btnHopDongAttachDownload_Click" IsUpload="true" />
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" ID="Button3" Icon="Delete" ToolTip="Xóa">
                                <Listeners>
                                    <Click Handler="return checkDeleteAttackFile(#{fufHopDongTepTinHL}.fileInput.dom, #{hdfHopDongTepTinDKHL}, #{fufHopDongTepTinHL});" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnHopDongAttachDelete_Click" After="#{fufHopDongTepTinHL}.reset();">
                                        <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                            ConfirmRequest="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:CompositeField>
                    <ext:TextArea runat="server" ID="txtHopDongGhiChuHL" FieldLabel="Ghi chú" AnchorHorizontal="99%"
                        Height="35" />
                    <ext:Container runat="server" ID="ctn23" Layout="BorderLayout" Height="230">
                        <Items>
                            <ext:GridPanel runat="server" ID="grp_DanhSachCanBo" TrackMouseOver="true" Title="Danh sách cán bộ"
                                StripeRows="true" Border="true" Region="Center" Icon="User" AutoExpandColumn="TEN_DONVI"
                                AutoExpandMin="150">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tbDanhSachQD">
                                        <Items>
                                            <ext:Button runat="server" ID="btnChonDanhSachCanBo" Icon="UserAdd" Text="Chọn cán bộ"
                                                TabIndex="12">
                                                <Listeners>
                                                    <Click Handler="ucChooseEmployee_wdChooseUser.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnXoaCanBo" Icon="Delete" Text="Xóa" Disabled="true"
                                                TabIndex="13">
                                                <Listeners>
                                                    <Click Handler="#{grp_DanhSachCanBo}.deleteSelected(); #{hdfTotalRecord}.setValue(#{hdfTotalRecord}.getValue()*1 - 1);if(hdfTotalRecord.getValue() ==0){btnXoaCanBo.disable();}" />
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
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel3" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="40" />
                                        <ext:Column ColumnID="MA_CB" Header="Mã cán bộ" Width="100" DataIndex="MA_CB" />
                                        <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="200" DataIndex="HO_TEN" />
                                        <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="100" DataIndex="TEN_DONVI">
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv1" />
                                </View>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="chkEmployeeRowSelection">
                                        <Listeners>
                                            <RowSelect Handler="btnXoaCanBo.enable();" />
                                            <%--<RowDeselect Handler="btnXoaCanBo.disable();" />--%>
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
                            <Click Handler=" if (CheckInputKTKLHangLoat(#{fufHopDongTepTinHL}.fileInput.dom) == true){#{grp_DanhSachCanBo}.save();}" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnDongLaiHL" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdHopDongHangLoat.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetWdHopDongHangLoat();" />
                    <Show Handler="hdfTypeWindow.setValue('More');" />
                </Listeners>
            </ext:Window>
            <%--    <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo quyết định lương" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../../Report/BaoCao_Main.aspx?type='+hdfTypeReport.getValue(), hdfTitleReport.getValue());" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>--%>
        </div>
    </form>
</body>
</html>
