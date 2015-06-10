<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DotDanhGia.aspx.cs" Inherits="Modules_DanhGia_DotDanhGia" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .x-layout-collapsed-south
        {
            background: url(../../../Resource/images/Choncanbodanhgia.png) no-repeat center !important;
        }
        .x-layout-collapsed-east
        {
            background: url(../../../Resource/images/Cactieuchidanhgia.png) no-repeat center !important;
        }
        #ext-gen234
        {
            border-top: 1px solid #8DB2E3 !important;
        }
        #grp_CanBoDuocDanhGia, #Panel2, #GridPanel1
        {
            border-right: 1px solid #8DB2E3 !important;
        }
        #Panel1, #grp_ChonTieuChi
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        #PagingToolbar1
        {
            border-bottom: 1px solid #8DB2E3 !important;
        }
        #grp_DanhSachTieuChi
        {
            border-bottom: 1px solid #8DB2E3 !important;
        }
    </style>
    <asp:Literal Text="" ID="ltrColapsibleStyle" runat="server" />
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                GridPanel1.getSelectionModel().clearSelections();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
        }

        var GetNameHinhThuc = function (value, p, record) {
            if (value == '0') {
                return 'Đánh giá cả đơn vị';
            }
            else if (value == '1') {
                return 'Đánh giá trong phòng';
            }
            else if (value == '2') {
                return 'Chỉ định cán bộ đánh giá';
            }
        }

        //        var RemoveItemOnGrid = function (grid, Store) {
        //            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
        //                if (btn == "yes") {
        //                    try {
        //                        grid.getRowEditor().stopEditing();
        //                    } catch (e) {

        //                    }
        //                    var s = grid.getSelectionModel().getSelections();
        //                     
        //                    for (var i = 0, r; r = s[i]; i++) {
        //                        //Store.remove(r);
        //                        Ext.net.DirectMethods.DeleteRecord(r.data.ID);

        //                    }
        //                    Store.reload();
        //                }
        //            });

        //        }

        var RemoveItemOnGridTieuChiDanhGia = function (grid, Store) {
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
                        Ext.net.DirectMethods.DeleteRecordTieuChi(r.data.ID);
                    }
                }
            });
        }

        var RemoveItemOnGrid_CB1 = function (grid, Store) {
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
                        Ext.net.DirectMethods.DeleteRecordCanBoDuocDanhGia(r.data.ID);
                    }
                }
            });
        }

        var RemoveItemOnGrid_CB2 = function (grid, Store) {
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
                        Ext.net.DirectMethods.DeleteRecordCanBoThamDanhGia(r.data.ID);
                        try {
                            btnEdit.disable();
                            btnDelete.disable();
                        }
                        catch (e) { }
                    }
                }
            });
        }

        var CheckInput = function () {
            if (txtID.getValue() == '') {
                alert("Bạn chưa nhập mã đợt đánh giá");
                txtID.focus();
                return false;
            }
            if (!cbxChonCanBo.getValue()) {
                alert('Bạn chưa chọn người quản lý');
                cbxChonCanBo.focus();
                return false;
            }
            if (txtTenDotDanhGia.getValue() == '') {
                alert("Bạn chưa nhập tên đợt đánh giá");
                txtTenDotDanhGia.focus();
                return false;
            }
            if (!txtTuNgay.getValue()) {
                alert('Bạn chưa nhập ngày bắt đầu');
                txtTuNgay.focus();
                return false;
            }
            if (cbxTrangThai.getValue() == '') {
                alert("Bạn chưa nhập trạng thái đánh giá");
                cbxTrangThai.focus();
                return false;
            }
            if (cbxLoaiDanhGia.getValue() == '') {
                alert('Bạn chưa chọn hình thức đánh giá');
                cbxLoaiDanhGia.focus();
                return false;
            }
            if (cbLoaiXepHang.getValue() == '') {
                alert('Bạn chưa chọn hình thức xếp loại');
                cbLoaiXepHang.focus();
                return false;
            }
            if (txtTuDanhGia.getValue() == '') {
                alert('Bạn chưa nhập tỷ lệ điểm tự đánh giá');
                txtTuDanhGia.focus();
                return false;
            }
            if (txtQuanlyDanhGia.getValue() == '') {
                alert('Bạn chưa nhập tỷ lệ điểm quản lý đánh giá');
                txtQuanlyDanhGia.focus();
                return false;
            }
            if (txtNguoiKhacDanhGia.getValue() == '') {
                alert('Bạn chưa nhập tỷ lệ điểm người khác đánh giá');
                txtNguoiKhacDanhGia.focus();
                return false;
            }
            if (txtTuDanhGia.getValue() * 1 + txtQuanlyDanhGia.getValue() * 1 + txtNguoiKhacDanhGia.getValue() * 1 != 100) {
                alert('Tổng các tỷ lệ điểm đánh giá phải bằng 100%');
                txtQuanlyDanhGia.focus();
                return false;
            }
            if ((txtTuNgay.getValue() != '' && txtDenNgay.getValue() != '') && (txtTuNgay.getValue() > txtDenNgay.getValue())) {
                alert('Ngày bắt đầu lớn hơn ngày kết thúc');
                txtTuNgay.focus();
                return false;
            }
            return ConfirmChangeHinhThucDanhGia();
        }

        var ConfirmChangeHinhThucDanhGia = function () {
            if (hdfOldHinhThucDanhGia.getValue() != '' && hdfOldHinhThucDanhGia.getValue() != cbxLoaiDanhGia.getValue()) {
                if (confirm('Để thay đổi hình thức đánh giá, phần mềm sẽ xóa bỏ các kết quả đánh giá trước đó. Bạn có thật sự muốn thay đổi?') == true) {
                    hdfIsChangeHinhThucDanhGia.setValue('Yes');
                    return true;
                }
            }
        }

        var resetWindowHide = function () {
            try {
                txtID.reset(); txtTenDotDanhGia.reset(); txtTuNgay.reset(); txtDenNgay.reset(); txtGhiChu.reset(); cbxLoaiDanhGia.reset(); cbxTrangThai.reset();
                txtTuDanhGia.reset(); txtQuanlyDanhGia.reset(); txtNguoiKhacDanhGia.reset(); cbLoaiXepHang.reset(); hdfMaNguoiQL.reset();
                cbxChonCanBo.reset();
            } catch (e) { }
        }

        var ReloadStoreOfSouth = function () {
            Ext.net.DirectMethods.DisableButton();
            //            grp_CanBoThamGiaDanhGia_Store.reload();
            //            grp_CanBoDuocDanhGia_Store.reload();
            if (Panel1.collapsed == false)
                grp_DanhSachTieuChi_Store.reload();
            //            btnThemCanBoThamGiaDanhGia.enable();
            //            btnThemCanBoDuocDanhGia.enable();
            btnThemTieuChi.enable();
        }

        function Delete(grid, Store) {
            for (var i = grid.store.totalLength; i >= 0; i--) {
                grid.getSelectionModel().selectRow(i, true);
                grid.deleteSelected();
            }
            Store.commitChanges();
        }

        var SelectedRowClick = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            var str = '';
            for (var i = 0, r; r = s[i]; i++) {
                str += r.data.MaNhom + ',';
            }
            hdfMaNhom.setValue(str);
            grp_ChonTieuChi_Store.reload();
        }

        var DisableNhanDoi = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                if (r.data.HinhThucDanhGia == 0 || r.data.HinhThucDanhGia == 1) {
                    chkBiDanhGia.checked = true;
                    chkBiDanhGia.disable();
                    chkThamGiaDanhGia.checked = true;
                    chkThamGiaDanhGia.disable();
                }
                else {
                    chkBiDanhGia.enable();
                    chkThamGiaDanhGia.enable();
                }
            }
        }

        var myOnCheckClick = function () {
            this[!this.checkbox.dom.checked ? "expand" : "collapse"]();
        };

        var CheckSelectedRecord = function (grid, Store) {

            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một bản ghi');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="if(cbxTrangThai.store.getCount()==0) cbxTrangThai_Store.reload();
                    if(cbLoaiXepHang.store.getCount()==0) cbLoaiXepHang_Store.reload();" />
            </Listeners>
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden ID="hdfCanBoThamGiaDanhGiaID" runat="server" />
        <ext:Hidden runat="server" ID="hdfChonCanBo" />
        <ext:Hidden runat="server" ID="hdfMaNhom" />
        <%-- bằng 1 nếu chọn cán bộ được đánh giá, 0 nếu chọn cán bộ tham gian đánh giá --%>
        <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
            Padding="6" Constrain="true" Title="Nhập mã đợt đánh giá mới" Hidden="true" Icon="DiskMultiple"
            runat="server" AutoHeight="true">
            <Items>
                <ext:TextField FieldLabel="Nhập mã mới<span style='color:red;'>*</span>" CtCls="requiredData"
                    runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%" MaxLength="20" />
                <ext:TextField FieldLabel="Nhập tên mới<span style='color:red;'>*</span>" CtCls="requiredData"
                    runat="server" ID="txtTenDotMoi" AnchorHorizontal="100%" MaxLength="500" />
                <ext:FieldSet ID="FieldSet1" runat="server" CheckboxToggle="true" Title="Không nhân đôi dữ liệu liên quan"
                    AutoHeight="true" LabelWidth="30" Layout="Form" Collapsed="false">
                    <CustomConfig>
                        <ext:ConfigItem Name="onCheckClick" Value="myOnCheckClick" Mode="Raw" />
                    </CustomConfig>
                    <Items>
                        <ext:Checkbox ID="chkBiDanhGia" runat="server" BoxLabel="Nhân đôi cán bộ bị đánh giá"
                            Checked="true" />
                        <ext:Checkbox ID="chkThamGiaDanhGia" runat="server" BoxLabel="Nhân đôi cán bộ tham gia đánh giá"
                            Checked="true" />
                        <ext:Checkbox ID="chkTieuChiDanhGia" runat="server" BoxLabel="Nhân đôi các tiêu chí đánh giá"
                            Checked="true" />
                    </Items>
                    <Listeners>
                        <Render Handler="this.checkbox.dom.checked = this.collapsed;" />
                        <Collapse Handler="this.checkbox.dom.checked = true; chkBiDanhGia.setValue(false); chkThamGiaDanhGia.setValue(false); chkTieuChiDanhGia.setValue(false);" />
                        <Expand Handler="this.checkbox.dom.checked = false;" />
                    </Listeners>
                </ext:FieldSet>
            </Items>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset();txtTenDotMoi.reset(); FieldSet1.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                    <Listeners>
                        <Click Handler="if(txtmaloaihdcoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnOK_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="wdInputNewPrimaryKey.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                    <Listeners>
                        <Click Handler="#{wdAddWindow}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem4" runat="server" Icon="Delete" Text="Xóa">
                    <Listeners>
                        <%--  <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />--%>
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="DeleteRecord">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                    <Listeners>
                        <Click Handler="return CheckSelectedRecord(GridPanel1,Store1);#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnEdit_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuSeparator runat="server" ID="mnuDuplicate" />
                <ext:MenuItem ID="mnuDuplicateData" runat="server" Icon="DiskMultiple" Text="Nhân đôi dữ liệu">
                    <Listeners>
                        <Click Handler="wdInputNewPrimaryKey.show();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <%--<ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="600" Modal="true" Constrain="true" Padding="5" ID="wdConfig" Title="Cấu hình thông tin cho đợt đánh giá"
            Icon="Cog">
            <Items>
                <ext:FieldSet runat="server" AnchorHorizontal="100%" Layout="ColumnLayout" Title="Tỷ lệ điểm đánh giá">
                    <Items>
                        <ext:Container runat="server" ColumnWidth="0.5" Height="60" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtTuDanhGia" AnchorHorizontal="99%" AllowBlank="false"
                                    FieldLabel="Tự đánh giá" MaxLength="5">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtNguoiKhacDanhGia" AnchorHorizontal="99%" AllowBlank="false"
                                    FieldLabel="Người khác đánh giá" MaxLength="5">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ColumnWidth="0.5" Height="60" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtQuanLyDanhGia" AnchorHorizontal="99%" AllowBlank="false"
                                    FieldLabel="Quản lý đánh giá" MaxLength="5">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" AnchorHorizontal="100%" Layout="ColumnLayout" Title="Xếp hạng cán bộ">
                    <Items>
                        
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button ID="btnLuuLai" runat="server" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="if (txtTuDanhGia.getValue() == '') {
                                alert('Bạn chưa nhập tỷ lệ điểm tự đánh giá');
                                txtTuDanhGia.focus();
                                return false;
                            }
                            if (txtNguoiKhacDanhGia.getValue() == '')
                            {
                                alert('Bạn chưa nhập tỷ lệ người khác đánh giá');
                                txtNguoiKhacDanhGia.focus();
                                return false;
                            }
                            if (txtQuanLyDanhGia.getValue() == '')
                            {
                                alert('Bạn chưa nhập tỷ lệ người quản lý đánh giá');
                                txtQuanLyDanhGia.focus();
                                return false;
                            }
                            return true;" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnLuuLai_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnHuy" runat="server" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="wdConfig.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txtTuDanhGia.reset();txtNguoiKhacDanhGia.reset();txtQuanLyDanhGia.reset();" />
            </Listeners>
        </ext:Window>--%>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="600" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới đợt đánh giá"
            Icon="Add">
            <Items>
                <ext:FieldSet runat="server" Title="Các thông tin chung" AnchorHorizontal="100%"
                    Layout="FormLayout" LabelWidth="105">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfOldHinhThucDanhGia" />
                        <ext:Hidden runat="server" ID="hdfIsChangeHinhThucDanhGia" />
                        <ext:Container runat="server" ID="ctn80" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="27">
                            <Items>
                                <ext:Container runat="server" ID="Container2" Layout="FormLayout" ColumnWidth="0.5"
                                    LabelWidth="105">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtID" AllowBlank="false" FieldLabel="Mã đợt đánh giá<span style='color: red;'>*</span>"
                                            AnchorHorizontal="98%" MaxLength="20" TabIndex="1" CtCls="requiredData" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn81" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfMaNguoiQL" />
                                        <ext:ComboBox ID="cbxChonCanBo" ValueField="PRKEY" DisplayField="HOTEN" FieldLabel="Người quản lý<span style='color: red;'>*</span>"
                                            PageSize="10" ListWidth="180" ItemSelector="div.search-item" MinChars="1" EmptyText="nhập tên để tìm kiếm"
                                            TabIndex="2" LoadingText="Đang tải dữ liệu..." AnchorHorizontal="100%" runat="server"
                                            CtCls="requiredData">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="POST" Url="../../HoSoNhanSu/QuyetDinhLuong/SearchUserHandler.ashx" />
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
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show(); hdfMaNguoiQL.setValue(cbxChonCanBo.getValue());" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfMaNguoiQL.reset(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:TextField runat="server" ID="txtTenDotDanhGia" FieldLabel="Tên đợt đánh giá<span style='color: red;'>*</span>"
                            AnchorHorizontal="100%" AllowBlank="false" MaxLength="500" TabIndex="3" CtCls="requiredData" />
                        <ext:Container ID="Container18" AnchorHorizontal="100%" runat="server" Layout="Column"
                            Height="53">
                            <Items>
                                <ext:Container ID="Container19" runat="server" LabelWidth="105" LabelAlign="left"
                                    Layout="Form" ColumnWidth=".5">
                                    <Items>
                                        <ext:DateField runat="server" MaskRe="/[0-9\/]/" ID="txtTuNgay" Vtype="daterange"
                                            FieldLabel="Ngày bắt đầu<span style='color: red;'>*</span>" AnchorHorizontal="99%"
                                            TabIndex="4" CtCls="requiredData">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{txtDenNgay}.setMinValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:ComboBox runat="server" FieldLabel="Hình thức<span style='color: red;'>*</span>"
                                            CtCls="requiredData" ID="cbxLoaiDanhGia" AnchorHorizontal="99%" Editable="false"
                                            ListWidth="200" TabIndex="5">
                                            <Items>
                                                <%--<ext:ListItem Text="Đánh giá cả đơn vị" Value="0" />
                                                <ext:ListItem Text="Đánh giá trong phòng" Value="1" />--%>
                                                <ext:ListItem Text="Chỉ định cán bộ đánh giá" Value="2" />
                                            </Items>
                                            <SelectedItem Value="2" />
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container1" runat="server" LabelWidth="105" LabelAlign="left"
                                    Layout="Form" ColumnWidth=".5">
                                    <Items>
                                        <ext:DateField runat="server" MaskRe="/[0-9\/]/" Vtype="daterange" ID="txtDenNgay"
                                            FieldLabel="Ngày kết thúc" AnchorHorizontal="100%" TabIndex="4">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{txtTuNgay}.setMaxValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:ComboBox runat="server" ID="cbxTrangThai" FieldLabel="Trạng thái<span style='color: red;'>*</span>"
                                            DisplayField="Value" ValueField="Value" AnchorHorizontal="100%" TabIndex="6"
                                            CtCls="requiredData" Editable="false">
                                            <Store>
                                                <ext:Store runat="server" ID="cbxTrangThai_Store" AutoLoad="False" OnRefreshData="cbxTrangThai_Store_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="Value">
                                                            <Fields>
                                                                <ext:RecordField Name="Value" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <SelectedItem Value="Lên kế hoạch" />
                                            <Listeners>
                                                <Expand Handler="if(#{cbxTrangThai}.store.getCount()==0){#{cbxTrangThai_Store}.reload();}" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" Height="60" AnchorHorizontal="100%"
                            MaxLength="500" TabIndex="7" />
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet ID="FieldSet2" runat="server" Title="Thông tin xếp hạng nhân viên"
                    AnchorHorizontal="100%" Layout="FormLayout" AutoHeight="true">
                    <Items>
                        <ext:Container ID="Container10" runat="server" Layout="FormLayout" AnchorHorizontal="100%"
                            Height="35" LabelWidth="105">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbLoaiXepHang" FieldLabel="Hình thức xếp hạng<span style='color: red;'>*</span>"
                                    DisplayField="TenXepHang" ValueField="MaXepHang" AnchorHorizontal="100%" TabIndex="8"
                                    CtCls="requiredData" Editable="false" ListWidth="250">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store runat="server" ID="cbLoaiXepHang_Store" AutoLoad="False" OnRefreshData="cbLoaiXepHang_Store_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MaXepHang">
                                                    <Fields>
                                                        <ext:RecordField Name="MaXepHang" />
                                                        <ext:RecordField Name="TenXepHang" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Expand Handler="if(cbxTrangThai.store.getCount()==0) cbLoaiXepHang_Store.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" Title="Cấu hình tỷ lệ điểm đánh giá" AnchorHorizontal="100%"
                    Layout="FormLayout" AutoHeight="true">
                    <Items>
                        <ext:Container runat="server" Layout="ColumnLayout" AnchorHorizontal="100%" AutoHeight="true">
                            <Items>
                                <ext:Container ID="Container8" runat="server" Layout="FormLayout" Height="60" ColumnWidth="0.5"
                                    LabelWidth="105">
                                    <Items>
                                        <ext:CompositeField runat="server" AnchorHorizontal="100%" FieldLabel="Tự đánh giá<span style='color: red;'>*</span>"
                                            CtCls="requiredData">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtTuDanhGia" Width="90" MaskRe="/[0-9\.,]/" AnchorHorizontal="99%"
                                                    TabIndex="9" Text="0" />
                                                <ext:DisplayField runat="server" Text="%" />
                                            </Items>
                                        </ext:CompositeField>
                                        <ext:CompositeField ID="CompositeField1" runat="server" AnchorHorizontal="100%" FieldLabel="Quản lý đánh giá<span style='color: red;'>*</span>"
                                            CtCls="requiredData">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtQuanlyDanhGia" Width="90" MaskRe="/[0-9\.,]/"
                                                    AnchorHorizontal="99%" TabIndex="10" Text="100" />
                                                <ext:DisplayField ID="DisplayField1" runat="server" Text="%" />
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container9" runat="server" Layout="FormLayout" Height="60" ColumnWidth="0.5">
                                    <Items>
                                        <ext:CompositeField ID="CompositeField2" runat="server" AnchorHorizontal="100%" FieldLabel="Người khác đánh giá<span style='color: red;'>*</span>"
                                            CtCls="requiredData">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtNguoiKhacDanhGia" Width="90" MaskRe="/[0-9\.,]/"
                                                    AnchorHorizontal="100%" TabIndex="11" Text="0" />
                                                <ext:DisplayField ID="DisplayField2" runat="server" Text="%" />
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" Layout="FitLayout" AnchorHorizontal="100%" AutoHeight="true">
                            <Items>
                                <ext:DisplayField runat="server" Text="Điểm đánh giá trung bình được tính theo tỷ lệ % giữa: Điểm tự đánh giá, Điểm nhân viên khác đánh giá và Điểm người quản lý đánh giá" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click" After="resetWindowHide();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnSua" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddWindow}.hide();resetWindowHide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show(); resetWindowHide(); Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <uc1:ucChooseEmployee ID="ucChooseEmployee1" DisplayWorkingStatus="DangLamViec" runat="server"
            ChiChonMotCanBo="false" />
        <ext:Window runat="server" Resizable="false" Hidden="true" Height="450" Layout="FormLayout"
            Width="700" Modal="true" Padding="6" Constrain="true" ID="wdThemTieuChiDanhGia"
            Title="Thêm cán bộ tham gia đánh giá" Icon="BookOpenMark">
            <Items>
                <ext:BorderLayout runat="server" ID="BorderLayout1">
                    <West Collapsible="false" Split="true">
                        <ext:Panel ID="Panel2" runat="server" Collapsed="false" Width="170" Border="false"
                            Layout="BorderLayout" Title="Các nhóm tiêu chí đánh giá">
                            <Items>
                                <ext:Hidden ID="hdfgrp_NhomTC" runat="server" />
                                <ext:GridPanel ID="grp_NhomTC" Border="false" runat="server" AutoExpandColumn="TenNhom"
                                    AutoExpandMin="150" StripeRows="true" TrackMouseOver="false" Region="Center"
                                    Height="450">
                                    <Store>
                                        <ext:Store ID="grp_NhomTC_Store" AutoLoad="true" runat="server" OnRefreshData="grp_NhomTC_Store_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MaNhom">
                                                    <Fields>
                                                        <ext:RecordField Name="MaNhom" />
                                                        <ext:RecordField Name="TenNhom" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel3" runat="server">
                                        <Columns>
                                            <ext:Column ColumnID="TenNhom" Header="Tên nhóm" DataIndex="TenNhom" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" ID="CheckboxSelectionModel1">
                                            <Listeners>
                                                <SelectionChange Handler="SelectedRowClick(#{grp_NhomTC}, #{grp_NhomTC_Store});" />
                                            </Listeners>
                                        </ext:CheckboxSelectionModel>
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grp_ChonTieuChi" Border="false" runat="server" StripeRows="true"
                            AutoExpandColumn="TenNhom" AutoExpandMin="200" TrackMouseOver="false" AnchorHorizontal="100%"
                            Title="Danh sách các tiêu chí đánh giá">
                            <Store>
                                <ext:Store ID="grp_ChonTieuChi_Store" GroupField="TenNhomCha" AutoLoad="true" runat="server"
                                    OnRefreshData="grp_ChonTieuChi_Store_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="MaNhom">
                                            <Fields>
                                                <ext:RecordField Name="MaNhom" />
                                                <ext:RecordField Name="TenNhom" />
                                                <ext:RecordField Name="HeSo" />
                                                <ext:RecordField Name="GhiChu" />
                                                <ext:RecordField Name="CreatedDate" />
                                                <ext:RecordField Name="CreatedBy" />
                                                <ext:RecordField Name="MaDonVi" />
                                                <ext:RecordField Name="ParentID" />
                                                <ext:RecordField Name="TenNhomCha" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Width="30" Header="STT" Groupable="false" />
                                    <ext:GroupingSummaryColumn ColumnID="TenNhomCha" Width="150" Header="TenNhomCha"
                                        Sortable="true" DataIndex="TenNhomCha" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                    <ext:Column ColumnID="MaNhom" Width="60" Header="Mã tiêu chí" DataIndex="MaNhom"
                                        Groupable="false" />
                                    <ext:Column ColumnID="TenNhom" Width="200" Header="Tên tiêu chí" DataIndex="TenNhom"
                                        Groupable="false" />
                                    <ext:Column ColumnID="HeSo" Width="35" Align="Right" Header="Hệ số" DataIndex="HeSo"
                                        Groupable="false" />
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel runat="server" ID="checkboxSelectionTieuChiDG" SingleSelect="false">
                                </ext:CheckboxSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            <Buttons>
                <ext:Button ID="btnDongYThemTieuChi" runat="server" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnDongYThemTieuChi_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnHuyBo" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThemTieuChiDanhGia.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (hdfRecordID.getValue() != hdfgrp_NhomTC.getValue()) {
                        grp_NhomTC_Store.reload(); 
                        grp_ChonTieuChi_Store.reload();
                        hdfgrp_NhomTC.setValue(hdfRecordID.getValue());
                    }" />
                <Hide Handler="#{grp_NhomTC}.getSelectionModel().clearSelections();
                    #{grp_ChonTieuChi}.getSelectionModel().clearSelections();" />
            </Listeners>
        </ext:Window>
        <%--<ext:Window runat="server" Resizable="false" Hidden="true" Height="450" Layout="FormLayout"
            Width="600" Modal="true" Padding="6" Constrain="true" ID="wdThemCanBoThamGiaDanhGia"
            Title="Thêm cán bộ tham gia đánh giá" Icon="UserAdd">
            <Items>
                <ext:BorderLayout runat="server" ID="brdLayout">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="Panel1" runat="server" Collapsed="false" Width="240" Border="false"
                            Layout="BorderLayout" Title="Danh sách các cán bộ được đánh giá">
                            <Items>
                                <ext:Hidden ID="hdfDanhSachCBDuocDanhGiaID" runat="server" />
                                <ext:GridPanel ID="grp_DanhSachCBDuocDanhGia" Border="false" runat="server" AutoExpandColumn="HO_TEN"
                                    StripeRows="true" TrackMouseOver="false" Region="Center" Height="450">
                                    <Store>
                                        <ext:Store ID="grp_DanhSachCBDuocDanhGia_Store" ShowWarningOnFailure="false" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                            AutoLoad="true" OnRefreshData="grp_DanhSachCBDuocDanhGia_Store_OnRefreshData" runat="server">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="MaCB" />
                                                        <ext:RecordField Name="HO_TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModelDanhSachCBDuocDanhGia" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" />
                                            <ext:Column ColumnID="MA_CB" Width="65" Header="Mã cán bộ" DataIndex="MA_CB" />
                                            <ext:Column ColumnID="HO_TEN" Width="75" Header="Họ tên" DataIndex="HO_TEN" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" ID="checkSelection" SingleSelect="true">
                                            <Listeners>
                                            </Listeners>
                                        </ext:CheckboxSelectionModel>
                                    </SelectionModel>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grp_DanhSachCBThamGiaDanhGia" Border="false" runat="server" StripeRows="true"
                            AutoExpandColumn="HO_TEN" TrackMouseOver="false" AnchorHorizontal="100%" Title="Danh sách cán bộ tham gia đánh giá">
                            <BottomBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button runat="server" ID="btnChonCBThamGiaDanhGia" Icon="UserAdd" Text="Chọn cán bộ">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn đợt đánh giá nào!'); return false;} hdfChonCanBo.setValue('0'); ucChooseEmployee1_wdChooseUser.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnXoaCBThamGiaDanhGia" Icon="Delete" Text="Xóa" Disabled="true">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </BottomBar>
                            <Store>
                                <ext:Store ID="grp_DanhSachCBThamGiaDanhGia_Store" AutoLoad="true" runat="server"
                                    OnRefreshData="grp_DanhSachCBThamGiaDanhGia_Store_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="MA_CB" />
                                                <ext:RecordField Name="HO_TEN" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                    <ext:Column ColumnID="MA_CB" Width="70" Header="Mã cán bộ" DataIndex="MA_CB" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" DataIndex="HO_TEN" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel1" SingleSelect="true">
                                    <Listeners>
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            <Listeners>
                <BeforeShow Handler="grp_DanhSachCBDuocDanhGia_Store.reload();" />
            </Listeners>
        </ext:Window>--%>
        <ext:Store ID="Store1" GroupField="Year" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerDotDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="TenDotDanhGia" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                        <ext:RecordField Name="TrangThaiDanhGia" />
                        <ext:RecordField Name="GhiChu" />
                        <ext:RecordField Name="CreatedBy" />
                        <ext:RecordField Name="CreatedDate" />
                        <ext:RecordField Name="MaDonVi" />
                        <ext:RecordField Name="HinhThucDanhGia" />
                        <ext:RecordField Name="Year" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                            Icon="ApplicationViewColumns" AutoExpandColumn="TenDotDanhGia" AutoExpandMin="150"
                            TrackMouseOver="false" AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{wdAddWindow}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="return CheckSelectedRecord(GridPanel1,Store1);#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEdit_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                            <%--<Listeners>
                                                <Click Handler="RemoveItemOnGrid(GridPanel1,Store1);" />
                                            </Listeners>--%>
                                            <DirectEvents>
                                                <Click OnEvent="DeleteRecord">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                        <ext:Button ID="Button1" runat="server" Text="Tiện ích" Icon="Build">
                                            <Menu>
                                                <ext:Menu ID="Menu4" runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="Nhân đôi dữ liệu"
                                                            Icon="DiskMultiple">
                                                            <Listeners>
                                                                <Click Handler="#{wdInputNewPrimaryKey}.show(); DisableNhanDoi(#{GridPanel1});" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <%--<ext:Button ID="btnConfig" runat="server" Icon="Cog" Disabled="true" Text="Cấu hình">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '')
                                                    {
                                                        alert('Bạn chưa chọn đợt đánh giá nào');
                                                        return false;
                                                    }
                                                    return true;" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnConfig_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>--%>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
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
                                    <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                                    <ext:Column ColumnID="ID" Header="Mã đợt" DataIndex="ID" Width="70" />
                                    <ext:Column ColumnID="TenDotDanhGia" Width="150" Header="Tên đợt đánh giá" DataIndex="TenDotDanhGia" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="TuNgay" Header="Ngày bắt đầu" DataIndex="TuNgay"
                                        Width="85" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="DenNgay" Header="Ngày kết thúc" DataIndex="DenNgay"
                                        Width="85" />
                                    <ext:Column ColumnID="TrangThaiDanhGia" Header="Trạng thái" DataIndex="TrangThaiDanhGia"
                                        Width="110" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Header="Ngày tạo" DataIndex="CreatedDate"
                                        Width="85" />
                                    <ext:Column ColumnID="HinhThucDanhGia" Header="Hình thức đánh giá" DataIndex="HinhThucDanhGia"
                                        Width="140">
                                        <Renderer Fn="GetNameHinhThuc" />
                                    </ext:Column>
                                    <ext:GroupingSummaryColumn ColumnID="Year" Width="150" Header="Year" Sortable="true"
                                        DataIndex="Year" Hideable="false">
                                        <Renderer Handler="return 'Năm ' + record.data.Year;" />
                                    </ext:GroupingSummaryColumn>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView3" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);btnEdit.enable();btnDelete.enable();mnuNhanDoiDuLieu.enable();ReloadStoreOfSouth();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="10" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Listeners>
                                        <Change Handler="checkboxSelection.clearSelections();" />
                                    </Listeners>
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="5" />
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
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
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                <RowDblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                            </Listeners>
                            <DirectEvents>
                                <RowDblClick OnEvent="btnEdit_Click">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </RowDblClick>
                            </DirectEvents>
                        </ext:GridPanel>
                    </Center>
                    <South Split="false">
                        <ext:Panel runat="server" ID="fd" Height="250" Collapsed="false" Collapsible="true"
                            Icon="User" Title="Danh sách cán bộ tham gia đợt đánh giá" Border="false">
                            <Items>
                                <ext:Container ID="Container5" runat="server" Layout="Column" Height="240">
                                    <Items>
                                        <ext:Container ID="Container6" runat="server" LabelWidth="70" LabelAlign="left" Layout="Form"
                                            ColumnWidth=".5">
                                            <Items>
                                                <ext:Hidden ID="hdfCanBoDuocDanhGiaID" runat="server" />
                                                <ext:GridPanel ID="grp_CanBoDuocDanhGia" runat="server" StripeRows="true" Border="false"
                                                    TrackMouseOver="true" AnchorHorizontal="100%" Height="223" AutoExpandColumn="HO_TEN"
                                                    AutoExpandMin="110" Title="Danh sách cán bộ bị đánh giá">
                                                    <TopBar>
                                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                                            <Items>
                                                                <ext:Button runat="server" ID="btnThemCanBoDuocDanhGia" Icon="UserAdd" Text="Thêm cán bộ"
                                                                    Disabled="true">
                                                                    <Listeners>
                                                                        <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn đợt đánh giá nào!'); return false;} hdfChonCanBo.setValue('1'); ucChooseEmployee1_wdChooseUser.show();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                                <ext:Button runat="server" ID="btnXoaCanBoDuocDanhGia" Icon="Delete" Text="Xóa" Disabled="true">
                                                                    <Listeners>
                                                                        <Click Handler="RemoveItemOnGrid_CB1(#{grp_CanBoDuocDanhGia}, #{grp_CanBoDuocDanhGia_Store})" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </Items>
                                                        </ext:Toolbar>
                                                    </TopBar>
                                                    <Store>
                                                        <ext:Store ID="grp_CanBoDuocDanhGia_Store" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                                                            RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="grp_CanBoDuocDanhGia_Store_OnRefreshData"
                                                            runat="server">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="MaCB" />
                                                                        <ext:RecordField Name="HO_TEN" />
                                                                        <ext:RecordField Name="TEN_PHONG" />
                                                                        <ext:RecordField Name="TEN_CHUCVU" />
                                                                        <ext:RecordField Name="CreatedDate" />
                                                                        <ext:RecordField Name="CreatedBy" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <ColumnModel ID="ColumnModelCanBoDuocDanhGia" runat="server">
                                                        <Columns>
                                                            <ext:RowNumbererColumn Width="35" Header="STT" />
                                                            <ext:Column ColumnID="MaCB" Width="70" Header="Mã cán bộ" DataIndex="MaCB" />
                                                            <ext:Column ColumnID="HO_TEN" Width="110" Header="Tên cán bộ" DataIndex="HO_TEN" />
                                                            <ext:Column ColumnID="TEN_PHONG" Width="200" Header="Phòng ban" DataIndex="TEN_PHONG" />
                                                            <ext:Column ColumnID="TEN_CHUCVU" Width="80" Header="Chức vụ" DataIndex="TEN_CHUCVU" />
                                                            <%--<ext:DateColumn Format="dd/MM/yyyy" Width="75" ColumnID="CreatedDate" Header="Ngày tạo" DataIndex="CreatedDate" />--%>
                                                        </Columns>
                                                    </ColumnModel>
                                                    <BottomBar>
                                                        <ext:PagingToolbar ID="PagingToolbar3" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                                            PageSize="5" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                                            DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                                            <Items>
                                                                <ext:Label ID="Label2" runat="server" Text="Số bản ghi trên 1 trang:" />
                                                                <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                                                <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                                                    <Items>
                                                                        <ext:ListItem Text="5" />
                                                                        <ext:ListItem Text="10" />
                                                                        <ext:ListItem Text="15" />
                                                                    </Items>
                                                                    <Listeners>
                                                                        <Select Handler="#{PagingToolbar3}.pageSize = parseInt(this.getValue()); #{PagingToolbar3}.doLoad();" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:PagingToolbar>
                                                    </BottomBar>
                                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                                    <SelectionModel>
                                                        <ext:RowSelectionModel ID="RowSelectionCanBoDuocDanhGia" runat="server">
                                                            <Listeners>
                                                                <RowSelect Handler="btnXoaCanBoDuocDanhGia.setDisabled(false);" />
                                                            </Listeners>
                                                        </ext:RowSelectionModel>
                                                    </SelectionModel>
                                                </ext:GridPanel>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container7" runat="server" LabelWidth="70" LabelAlign="left" Layout="Form"
                                            ColumnWidth=".5">
                                            <Items>
                                                <ext:GridPanel ID="grp_CanBoThamGiaDanhGia" runat="server" StripeRows="true" Border="false"
                                                    TrackMouseOver="true" AnchorHorizontal="100%" Height="223" AutoExpandColumn="TenCBDanhGia"
                                                    AutoExpandMin="115" Title="Danh sách cán bộ tham gia đánh giá">
                                                    <TopBar>
                                                        <ext:Toolbar ID="Toolbar2" runat="server">
                                                            <Items>
                                                                <ext:Button runat="server" ID="btnThemCanBoThamGiaDanhGia" Icon="UserAdd" Text="Thêm cán bộ"
                                                                    Disabled="true">
                                                                    <Listeners>
                                                                        <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn đợt đánh giá nào!'); return false;} hdfChonCanBo.setValue('0'); ucChooseEmployee1_wdChooseUser.show();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                                <ext:Button runat="server" ID="btnXoaCanBoThamGiaDanhGia" Icon="Delete" Text="Xóa"
                                                                    Disabled="true">
                                                                    <Listeners>
                                                                        <Click Handler="RemoveItemOnGrid_CB2(#{grp_CanBoThamGiaDanhGia}, #{grp_CanBoThamGiaDanhGia_Store})" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </Items>
                                                        </ext:Toolbar>
                                                    </TopBar>
                                                    <Store>
                                                        <ext:Store ID="grp_CanBoThamGiaDanhGia_Store" AutoSave="true" ShowWarningOnFailure="false"
                                                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="grp_CanBoThamGiaDanhGia_Store_OnRefreshData"
                                                            runat="server">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="MaDotDanhGia" />
                                                                        <ext:RecordField Name="TenDotDanhGia" />
                                                                        <ext:RecordField Name="MaCBDanhGia" />
                                                                        <ext:RecordField Name="TenCBDanhGia" />
                                                                        <ext:RecordField Name="MaCBBiDanhGia" />
                                                                        <ext:RecordField Name="CreatedDate" />
                                                                        <ext:RecordField Name="CreatedBy" />
                                                                        <ext:RecordField Name="TenPhong" />
                                                                        <ext:RecordField Name="TenChucVu" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <ColumnModel ID="ColumnModelCanBoThamGiaDanhGia" runat="server">
                                                        <Columns>
                                                            <ext:RowNumbererColumn Width="30" Header="STT" />
                                                            <ext:Column ColumnID="MaCBDanhGia" Width="70" Header="Mã cán bộ" DataIndex="MaCBDanhGia" />
                                                            <ext:Column ColumnID="TenCBDanhGia" Width="110" Header="Tên cán bộ đánh giá" DataIndex="TenCBDanhGia" />
                                                            <ext:Column ColumnID="TenPhong" Width="200" Header="Phòng ban" DataIndex="TenPhong" />
                                                            <ext:Column ColumnID="TenChucVu" Width="80" Header="Chức vụ" DataIndex="TenChucVu" />
                                                            <%--<ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Width="75" Header="Ngày tạo" DataIndex="CreatedDate" />--%>
                                                        </Columns>
                                                    </ColumnModel>
                                                    <BottomBar>
                                                        <ext:PagingToolbar ID="PagingToolbar4" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                                            PageSize="5" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                                            DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                                            <Listeners>
                                                                <Change Handler="RowSelectionCanBoThamGiaDanhGia.clearSelections();" />
                                                            </Listeners>
                                                            <Items>
                                                                <ext:Label ID="Label3" runat="server" Text="Số bản ghi trên 1 trang:" />
                                                                <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                                                <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
                                                                    <Items>
                                                                        <ext:ListItem Text="5" />
                                                                        <ext:ListItem Text="10" />
                                                                        <ext:ListItem Text="15" />
                                                                    </Items>
                                                                    <Listeners>
                                                                        <Select Handler="#{PagingToolbar4}.pageSize = parseInt(this.getValue()); #{PagingToolbar4}.doLoad();" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:PagingToolbar>
                                                    </BottomBar>
                                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                                    <SelectionModel>
                                                        <ext:RowSelectionModel ID="RowSelectionCanBoThamGiaDanhGia" runat="server">
                                                            <Listeners>
                                                                <RowSelect Handler="btnXoaCanBoThamGiaDanhGia.enable();" />
                                                            </Listeners>
                                                        </ext:RowSelectionModel>
                                                    </SelectionModel>
                                                </ext:GridPanel>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Panel>
                    </South>
                    <East Collapsible="true" Split="true">
                        <ext:Panel ID="Panel1" runat="server" Collapsed="true" Width="430" Border="false"
                            Layout="BorderLayout" Title="Các tiêu chí của đợt đánh giá" Icon="BookOpenMark">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfDanhSachTieuChi" />
                                <ext:GridPanel ID="grp_DanhSachTieuChi" Border="false" runat="server" AutoExpandColumn="TenNhom"
                                    AutoExpandMin="120" StripeRows="true" TrackMouseOver="false" Region="Center"
                                    Height="450">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar3" runat="server">
                                            <Items>
                                                <ext:Button ID="btnThemTieuChi" runat="server" Disabled="true" Text="Thêm tiêu chí"
                                                    Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn đợt đánh giá'); return false;} wdThemTieuChiDanhGia.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btnXoaTieuChi" runat="server" Disabled="true" Text="Xóa" Icon="Delete">
                                                    <Listeners>
                                                        <Click Handler="RemoveItemOnGridTieuChiDanhGia(#{grp_DanhSachTieuChi}, #{grp_DanhSachTieuChi_Store});" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Store>
                                        <ext:Store ID="grp_DanhSachTieuChi_Store" GroupField="TenNhomCha" AutoLoad="true"
                                            runat="server">
                                            <Proxy>
                                                <ext:HttpProxy Method="GET" Url="HandlerTieuChiDanhGia.ashx" />
                                            </Proxy>
                                            <AutoLoadParams>
                                                <ext:Parameter Name="start" Value="={0}" />
                                                <ext:Parameter Name="limit" Value="={10}" />
                                            </AutoLoadParams>
                                            <BaseParams>
                                                <ext:Parameter Name="MaDotDanhGia" Value="hdfRecordID.getValue()" Mode="Raw" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="MaTieuChi" />
                                                        <ext:RecordField Name="TenNhom" />
                                                        <ext:RecordField Name="TenNhomCha" />
                                                        <ext:RecordField Name="HeSo" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" Groupable="false" />
                                            <ext:Column ColumnID="MaTieuChi" Header="Mã tiêu chí" DataIndex="MaTieuChi" Width="40"
                                                Groupable="false" />
                                            <ext:Column ColumnID="TenNhom" Header="Tên tiêu chí" Width="120" DataIndex="TenNhom"
                                                Groupable="false" />
                                            <ext:GroupingSummaryColumn ColumnID="TenNhomCha" Width="50" Header="TenNhomCha" Sortable="true"
                                                DataIndex="TenNhomCha" Hideable="false">
                                            </ext:GroupingSummaryColumn>
                                            <ext:Column ColumnID="HeSo" Header="Hệ số" Align="Right" Width="30" DataIndex="HeSo"
                                                Groupable="false" />
                                        </Columns>
                                    </ColumnModel>
                                    <View>
                                        <ext:GroupingView ID="GroupingView2" runat="server" ForceFit="true" MarkDirty="false"
                                            ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                                    </View>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="checkSelection">
                                            <Listeners>
                                                <RowSelect Handler="btnXoaTieuChi.enable();" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                            PageSize="10" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                            DisplayMsg="{0} đến {1} / {2}" runat="server">
                                            <Listeners>
                                                <Change Handler="checkSelection.clearSelections();" />
                                            </Listeners>
                                            <Items>
                                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                                <ext:ComboBox ID="ComboBox1" runat="server" Width="50">
                                                    <Items>
                                                        <ext:ListItem Text="10" />
                                                        <ext:ListItem Text="15" />
                                                        <ext:ListItem Text="20" />
                                                    </Items>
                                                    <Listeners>
                                                        <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                </ext:GridPanel>
                            </Items>
                            <Listeners>
                                <Expand Handler="if (hdfRecordID.getValue() != hdfDanhSachTieuChi.getValue())
                                    {
                                        grp_DanhSachTieuChi_Store.reload();
                                        hdfDanhSachTieuChi.setValue(hdfRecordID.getValue());
                                    }" />
                            </Listeners>
                        </ext:Panel>
                    </East>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
