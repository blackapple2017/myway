<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TieuChiDanhGia.aspx.cs" Inherits="Modules_DanhGia_TieuChiDanhGia" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/CacNhomTieuChiDanhGia.png) no-repeat center !important;
        }
    </style>
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

        var SelectedRowClick = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            var str = '';
            for (var i = 0, r; r = s[i]; i++) {
                str += r.data.MaNhom + ',';
            }
            hdfMaNhom.setValue(str);
            Store1.reload();
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
                        Ext.net.DirectMethods.DeleteRecord(r.data.MaNhom);
                        btnEdit.disable();
                        btnDelete.disable();
                    }
                }
            });
        }

        var RemoveNhomTieuChi = function (grid, Store) {
            if (hdfMaNhom.getValue() == '') {
                alert('Bạn chưa chọn nhóm nào!');
                return false;
            }
            Ext.Msg.confirm('Xác nhận', 'Khi xóa một nhóm tiêu chí tất cả các tiêu chí trong nhóm cũng bị xóa. Bạn có chắc chắn muốn xóa không?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    }
                    catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.remove(r);
                        Ext.net.DirectMethods.DeleteNhomTieuChi(r.data.MaNhom);
                        btnEdit.disable();
                        btnDelete.disable();
                    }
                    Store.commitChanges();
                    grp_NhomTC_Store.reload();
                    Store1.reload();
                }
            });
        }

        var CheckInput = function () {

            if (txtMaNhom.getValue() == '') {
                alert("Bạn chưa nhập mã tiêu chí");
                txtMaNhom.focus();
                return false;
            }
            if (txtTenNhom.getValue() == '') {
                alert("Bạn chưa nhập tên tiêu chí");
                txtTenNhom.focus();
                return false;
            }
            if (txtHeSo.getValue() == '') {
                alert("Bạn chưa nhập hệ số");
                txtHeSo.focus();
                return false;
            }
            if (cbxTieuChiCha.getValue() == '') {
                alert("Bạn chưa chọn nhóm tiêu chí");
                cbxTieuChiCha.focus();
                return false;
            }
            return true;
        }

        var resetWindowHide = function () {
            txtMaNhom.reset(); txtTenNhom.reset(); txtHeSo.reset(); txtGhiChu.reset();
        }

        var btnEditClick = function () {
            if (hdfMaNhom.getValue() == '') {
                alert('Bạn chưa chọn nhóm nào!');
                return false;
            }
            else {
                var str = hdfMaNhom.getValue().split(',');
                if (str.length > 2) {
                    alert('Bạn chỉ được chọn một nhóm để sửa');
                    return false;
                }
            }
            var s = grp_NhomTC.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                hdfRecordID.setValue(r.data.MaNhom);
            }
            btnCapNhat.hide();
            btnSua.show();
            btnCapNhat_DongLai.hide();
            cbxTieuChiCha.setDisabled(true);
            return true;
        }

        var submitValue = function (grid, hiddenFormat) {
            hiddenFormat.setValue(Ext.encode(Store1.getRecordsValues({ filterField: function (r, name, value) { return (name != 'CreatedDate' && name != 'CreatedBy' && name != 'MaDonVi' && name != 'TenNhomCha' && name != 'ParentID'); } })));
            Store1.submitData(true);
        };

        var getSelectedIndexRow = function () {
            var record = grpTestList.getSelectionModel().getSelected();
            var index = grpTestList.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }

        var addRecord = function (id, explain_name, min_point, max_point, order) {
            var rowindex = getSelectedIndexRow();
            grpTestList.insertRecord(rowindex, {
                ID: id,
                ExplainName: explain_name,
                MinPoint: min_point,
                MaxPoint: max_point,
                Order: order
            });
            grpTestList.getView().refresh();
            grpTestList.getSelectionModel().selectRow(rowindex);
            //grpProductDetailStore.commitChanges();
        }

        addUpdatedRecord = function (id, explain_name, min_point, max_point, order) {
            var rowindex = getSelectedIndexRow();
            var prkey = 0;
            //xóa bản ghi cũ
            var s = grpTestList.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                prkey = r.data.productid;
                grpTestListStore.remove(r);
            }
            //Thêm bản ghi đã update
            grpTestList.insertRecord(rowindex, {
                ID: id,
                ExplainName: explain_name,
                MinPoint: min_point,
                MaxPoint: max_point,
                Order: order
            });
            grpTestList.getView().refresh();
            grpTestList.getSelectionModel().selectRow(rowindex);
        }
        var ValidateAddCriterion = function () {
            if (!txtCriterionCode.getValue()) {
                alert('Bạn chưa nhập mã tiêu chí');
                txtCriterionCode.focus();
                return false;
            }
            if (!txtCriterionName.getValue()) {
                alert('Bạn chưa nhập tên tiêu chí');
                txtCriterionName.focus();
                return false;
            }
            if (!cbxCriterionGroup.getValue()) {
                alert('Bạn chưa chọn nhóm tiêu chí');
                cbxCriterionGroup.focus();
                return false;
            }
            return true;
        }
        var ResetCriterionWindow = function () {
            txtCriterionCode.reset(); txtCriterionWeight.reset(); txtCriterionName.reset();
            cbxCriterionGroup.reset(); txtNote.reset(); hdfIsEdit.reset(); hdfClose.reset();
            try { grpTestListStore.removeAll(); } catch (e) { } hdfInsertedID.reset();
        }

        var CheckSelectedRecord = function (grid, Store) {
            if (hdfRecordID.getValue() == '') {
                alert('Bạn chưa chọn dòng nào');
                return false;
            }

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
    <style type="text/css">
        div#pnReportPanel .x-tab-panel-header
        {
            display: none !important;
        }
        .x-layout-split
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        #GridPanel1
        {
            border-left: 1px solid #8DB2E3 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMaNhom" />
        <ext:Hidden runat="server" ID="hdfTypeCommand" />
        <ext:Hidden runat="server" ID="hdfClose" />
        <ext:Hidden runat="server" ID="hdfInsertedID" />
        <ext:Hidden runat="server" ID="hdfIsEdit" />
        <ext:Hidden ID="FormatType" runat="server" />
        <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
            Padding="6" Constrain="false" Title="Nhập khóa chính mới" Hidden="true" Icon="Add"
            runat="server" AutoHeight="true">
            <Items>
                <ext:TextField FieldLabel="Nhập mã<span style='color:red;'>*</span>" CtCls="requiredData"
                    runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%" MaxLength="20" />
            </Items>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                    <Listeners>
                        <Click Handler="if(txtmaloaihdcoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnOK_Click">
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
                        <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                    <Listeners>
                        <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{btnCapNhat_DongLai}.hide();" />
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
        <ext:Store runat="server" ID="cbxCriterionGroupStore" AutoLoad="False" OnRefreshData="cbxCriterionGroupStore_OnRefreshData">
            <Reader>
                <ext:JsonReader IDProperty="MaNhom">
                    <Fields>
                        <ext:RecordField Name="MaNhom" />
                        <ext:RecordField Name="TenNhom" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdChuyenTiep" Width="500" Icon="TransmitGo" Title="Thay đổi nhóm tiêu chí"
            AutoHeight="true" Padding="10" Modal="true" Constrain="true" Hidden="true" Layout="FormLayout">
            <Items>
                <ext:ComboBox runat="server" ID="cbxChuyenTiepNhomTC" FieldLabel="Nhóm tiêu chí<span style='color:red;'>*</span>"
                    CtCls="requiredData" DisplayField="TenNhom" ValueField="MaNhom" AnchorHorizontal="100%"
                    TabIndex="6" Editable="false" AllowBlank="false">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store runat="server" ID="cbxChuyenTiepNhomTC_Store" AutoLoad="false" OnRefreshData="cbxChuyenTiepNhomTC_Store_OnRefreshData">
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
                    <ToolTips>
                        <ext:ToolTip runat="server" Title="Chọn nhóm tiêu chí mới cần chuyển sang" />
                    </ToolTips>
                    <Listeners>
                        <Expand Handler="if(cbxChuyenTiepNhomTC.store.getCount()==0) cbxChuyenTiepNhomTC_Store.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnChuyenTiep" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="if (cbxChuyenTiepNhomTC.getValue() == '') {
                                alert('Bạn chưa chọn nhóm tiêu chí mới');
                                cbxChuyenTiepNhomTC.focus();
                                return false;
                            }" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChuyenTiep_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLai" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChuyenTiep.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="cbxChuyenTiepNhomTC.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdNhapTuExcel" Width="500" Icon="PageExcel" Title="Đọc từ file excel"
            Height="160" Padding="10" Modal="true" Constrain="true" Hidden="true" Layout="FormLayout">
            <Items>
                <ext:FormPanel ID="BasicForm" runat="server" Border="false" MonitorValid="true">
                    <Items>
                        <ext:FileUploadField ID="FileUploadField1" runat="server" Text="" FieldLabel="Chọn file Excel<span style='color:red;'>*</span>"
                            CtCls="requiredData" Icon="ImageAdd" AnchorHorizontal="100%" AllowBlank="false">
                            <Listeners>
                                <FileSelected Handler="if(#{FileUploadField1}.getValue().lastIndexOf('.xls')!=-1 && #{FileUploadField1}.getValue().lastIndexOf('.xlsx')==-1){
                                    #{cbSheetNameStore}.reload();#{cbSheetName}.enable();
                                    }" />
                            </Listeners>
                        </ext:FileUploadField>
                        <ext:ComboBox ID="cbSheetName" Disabled="true" FieldLabel="Chọn sheet<span style='color:red;'>*</span>"
                            CtCls="requiredData" SelectedIndex="0" Editable="false" AnchorHorizontal="100%"
                            runat="server" DisplayField="SheetName" ValueField="SheetName" SelectOnFocus="true"
                            AllowBlank="false">
                            <Store>
                                <ext:Store ID="cbSheetNameStore" runat="server" OnRefreshData="cbSheetNameStore_OnRefreshData"
                                    AutoLoad="false" EnableViewState="false">
                                    <DirectEventConfig>
                                        <EventMask ShowMask="false" />
                                    </DirectEventConfig>
                                    <Reader>
                                        <ext:JsonReader IDProperty="SheetName">
                                            <Fields>
                                                <ext:RecordField Name="SheetName" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="cbxChonNhomTC" FieldLabel="Nhóm tiêu chí<span style='color:red;'>*</span>"
                            CtCls="requiredData" DisplayField="TenNhom" ValueField="MaNhom" AnchorHorizontal="100%"
                            StoreID="cbxCriterionGroupStore" TabIndex="6" Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <%--<Store>
                                <ext:Store runat="server" ID="cbxChonNhomTC_Store" AutoLoad="false" OnRefreshData="cbxChonNhomTC_Store_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="MaNhom">
                                            <Fields>
                                                <ext:RecordField Name="MaNhom" />
                                                <ext:RecordField Name="TenNhom" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>--%>
                            <Listeners>
                                <Expand Handler="cbxChonNhomTC.store.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                    <Listeners>
                        <ClientValidation Handler="#{btnImport}.setDisabled(!valid);" />
                    </Listeners>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnTaiTepMau" runat="server" Text="Tải file mẫu" Icon="Attach">
                    <DirectEvents>
                        <Click OnEvent="DownloadBangChamCongMau" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnImport" runat="server" Text="Nhập dữ liệu" Hidden="false" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="ImportDataFromExcel">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDong" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdNhapTuExcel.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{FileUploadField1}.reset(); #{cbSheetName}.reset(); #{cbxChonNhomTC}.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới tiêu chí đánh giá"
            Icon="Add">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommand" />
                <ext:TextField runat="server" ID="txtMaNhom" FieldLabel="Mã tiêu chí<span style='color:red;'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="99%" MaxLength="20" />
                <ext:TextField runat="server" ID="txtTenNhom" FieldLabel="Tên tiêu chí<span style='color:red;'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="99%" MaxLength="500" />
                <ext:TextField ID="txtHeSo" MaskRe="/[0-9\.,]/" runat="server" FieldLabel="Hệ số<span style='color:red;'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="99%" MaxLength="10" />
                <ext:ComboBox runat="server" ID="cbxTieuChiCha" FieldLabel="Nhóm tiêu chí<span style='color:red;'>*</span>"
                    CtCls="requiredData" DisplayField="TenNhom" ValueField="MaNhom" AnchorHorizontal="99%"
                    TabIndex="6" Editable="false">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store runat="server" ID="cbxTieuChiCha_Store" AutoLoad="False" OnRefreshData="cbxTieuChiCha_Store_OnRefreshData">
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
                    <Listeners>
                        <Expand Handler="cbxTieuChiCha_Store.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="99%"
                    Height="80" MaxLength="500" />
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
                <ext:Button ID="btnCapNhat_DongLai" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
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
                <BeforeShow Handler="if(cbxTieuChiCha.store.getCount()==0) cbxTieuChiCha_Store.reload();" />
                <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{btnCapNhat_DongLai}.show(); resetWindowHide(); #{cbxTieuChiCha}.reset(); Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddNewEstimateCriterion"
            Title="Thêm mới tiêu chí đánh giá" Icon="Add">
            <Items>
                <ext:FieldSet runat="server" ID="fs1" Title="Thông tin tiêu chí" Layout="FormLayout"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="ctn40" AnchorHorizontal="100%" Layout="ColumnLayout"
                            Height="27">
                            <Items>
                                <ext:Container runat="server" ID="ctn41" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtCriterionCode" FieldLabel="Mã tiêu chí<span style='color:red;'>*</span>"
                                            CtCls="requiredData" MaxLength="20" AnchorHorizontal="98%" TabIndex="1">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn42" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtCriterionWeight" FieldLabel="Hệ số" MaxLength="15"
                                            AnchorHorizontal="100%" MaskRe="/[0-9.,]/" Text="1" TabIndex="2">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:TextField runat="server" ID="txtCriterionName" FieldLabel="Tên tiêu chí<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="100%" MaxLength="1000" TabIndex="4">
                        </ext:TextField>
                        <ext:ComboBox runat="server" ID="cbxCriterionGroup" FieldLabel="Nhóm tiêu chí<span style='color:red;'>*</span>"
                            CtCls="requiredData" DisplayField="TenNhom" ValueField="MaNhom" AnchorHorizontal="100%"
                            TabIndex="5" Editable="false" StoreID="cbxCriterionGroupStore">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Expand Handler="cbxCriterionGroup.store.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextArea runat="server" ID="txtNote" AnchorHorizontal="100%" FieldLabel="Ghi chú"
                            MaxLength="4000" TabIndex="6">
                        </ext:TextArea>
                    </Items>
                </ext:FieldSet>
                <ext:Container runat="server" ID="Container25" Layout="BorderLayout" Height="250">
                    <Items>
                        <ext:GridPanel runat="server" ID="grpTestList" TrackMouseOver="true" Title="Hướng dẫn chấm điểm"
                            StripeRows="true" Border="true" Region="Center" Icon="User" ClicksToEdit="1"
                            AutoExpandColumn="ExplainName">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbTracNghiem">
                                    <Items>
                                        <ext:Button runat="server" ID="btnAddTest" Icon="Add" Text="Thêm mới">
                                            <Listeners>
                                                <Click Handler="addRecord('', '', 0, 0, 1);" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnDeleteTest" Icon="Delete" Text="Xóa">
                                            <Listeners>
                                                <Click Handler="#{grpTestList}.deleteSelected();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="grpTestListStore" AutoSave="false" AutoLoad="false" runat="server"
                                    OnBeforeStoreChanged="HandleChanges" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                                    RefreshAfterSaving="None">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" Type="Int" />
                                                <ext:RecordField Name="CriterionID" />
                                                <ext:RecordField Name="ExplainName" />
                                                <ext:RecordField Name="MinPoint" Type="Int" />
                                                <ext:RecordField Name="MaxPoint" Type="Int" />
                                                <ext:RecordField Name="Order" Type="Int" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <%--<ext:Column ColumnID="ID" Header="Mã" Locked="true" Width="70" DataIndex="ID" />--%>
                                    <ext:Column ColumnID="ExplainName" Header="Tên" Locked="true" Width="150" DataIndex="ExplainName">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtExplainName" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="MinPoint" Header="Từ điểm" Width="70" DataIndex="MinPoint">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtMinPoint" MaskRe="/[0-9]/" MaxLength="6" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="MaxPoint" Header="Đến điểm" Width="70" DataIndex="MaxPoint">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtMaxPoint" MaskRe="/[0-9]/" MaxLength="6" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="Order" Header="Thứ tự" Width="70" DataIndex="Order">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtOrder" MaskRe="/[0-9]/" Text="1" />
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModelTracNghiem" SingleSelect="true">
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <Listeners>
                                <AfterEdit Handler="hdfIsEdit.setValue('True');" />
                            </Listeners>
                        </ext:GridPanel>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdateAddCriterion" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateAddCriterion();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateCriterion_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateEditCriterion" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateAddCriterion();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateCriterion_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Edit" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateEditAndCloseCriterion" Text="Cập nhật và đóng lại"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateAddCriterion();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateCriterion_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCloseCreterion" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAddNewEstimateCriterion.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetCriterionWindow();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="Store1" GroupField="TenNhomCha" AutoLoad="true" runat="server" OnSubmitData="Store1_Submit">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerTieuChiDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="ParentTCID" Value="hdfMaNhom.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaNhom">
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
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="Panel1" runat="server" Collapsed="false" Width="240" Border="false"
                            Layout="BorderLayout" Title="Các nhóm tiêu chí đánh giá">
                            <Items>
                                <ext:GridPanel ID="grp_NhomTC" Border="false" runat="server" AutoExpandColumn="TenNhom"
                                    AutoExpandMin="150" StripeRows="true" TrackMouseOver="false" Region="Center"
                                    Height="450">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button ID="btnThemNhomTC" runat="server" Text="Thêm mới" Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{cbxTieuChiCha}.setValue('-1'); #{cbxTieuChiCha}.setDisabled(true); #{wdAddWindow}.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btnSuaNhomTC" runat="server" Text="Sửa" Icon="Pencil" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="return btnEditClick();" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="btnEdit_Click">
                                                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                            <ExtraParams>
                                                                <ext:Parameter Name="EditNhomTC" Value="True" />
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnXoaNhomTC" runat="server" Text="Xóa" Icon="Delete" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="RemoveNhomTieuChi(grp_NhomTC, grp_NhomTC_Store);" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Store>
                                        <ext:Store ID="grp_NhomTC_Store" AutoLoad="true" runat="server" OnRefreshData="grp_NhomTC_Store_Refresh">
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
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" />
                                            <ext:Column ColumnID="TenNhom" Header="Tên nhóm" DataIndex="TenNhom" />
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:CheckboxSelectionModel runat="server" ID="checkSelection">
                                            <Listeners>
                                                <SelectionChange Handler="SelectedRowClick(#{grp_NhomTC}, #{grp_NhomTC_Store});" />
                                                <RowSelect Handler="btnSuaNhomTC.enable();btnXoaNhomTC.enable();" />
                                            </Listeners>
                                        </ext:CheckboxSelectionModel>
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                            AutoExpandColumn="TenNhom" TrackMouseOver="false" AnchorHorizontal="100%" AutoExpandMin="200">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="btnUpdateAddCriterion.show();btnUpdateEditCriterion.hide();btnUpdateEditAndCloseCriterion.show();txtCriterionCode.enable();#{wdAddNewEstimateCriterion}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});btnUpdateAddCriterion.hide();btnUpdateEditCriterion.show();btnUpdateEditAndCloseCriterion.hide();txtCriterionCode.disable();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEditCriterion_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                        <ext:Button ID="btnTienIch" runat="server" Text="Tiện ích" Icon="Build">
                                            <Menu>
                                                <ext:Menu ID="Menu4" runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="Nhân đôi dữ liệu"
                                                            Icon="DiskMultiple">
                                                            <Listeners>
                                                                <Click Handler="if (CheckSelectedRows(#{GridPanel1}) == false) {return false;} #{wdInputNewPrimaryKey}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuChuyenTiep" Disabled="true" Text="Chuyển sang nhóm khác"
                                                            Icon="TransmitGo">
                                                            <Listeners>
                                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn tiêu chí nào!'); return false;} wdChuyenTiep.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuNhapTuExcel" Text="Nhập từ file Excel" Icon="PageExcel">
                                                            <Listeners>
                                                                <Click Handler="wdNhapTuExcel.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuXuatRaExcel" Text="Xuất ra file Excel" Icon="PageExcel">
                                                            <Listeners>
                                                                <Click Handler="submitValue(#{GridPanel1}, #{FormatType});" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <%--<ext:TextField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                            ID="txtSearch">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="#{Store1}.reload();" />
                                            </Listeners>
                                        </ext:Button>--%>
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
                                    <ext:RowNumbererColumn Width="30" Header="STT" Groupable="false" />
                                    <ext:Column ColumnID="MaNhom" Width="50" Header="Mã tiêu chí" DataIndex="MaNhom"
                                        Groupable="false" />
                                    <ext:Column ColumnID="TenNhom" Width="200" Header="Tên tiêu chí" DataIndex="TenNhom"
                                        Groupable="false" />
                                    <ext:Column ColumnID="HeSo" Width="40" Align="Right" Header="Hệ số" DataIndex="HeSo"
                                        Groupable="true" />
                                    <ext:Column ColumnID="GhiChu" Width="150" Header="Ghi chú" DataIndex="GhiChu" Groupable="false" />
                                    <ext:DateColumn Format="dd/MM/yyyy" Width="70" ColumnID="CreatedDate" Header="Ngày tạo"
                                        DataIndex="CreatedDate" Groupable="false" />
                                    <ext:GroupingSummaryColumn ColumnID="TenNhomCha" Width="150" Header="TenNhomCha"
                                        Sortable="true" DataIndex="TenNhomCha" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);btnEdit.enable();btnDelete.enable();mnuNhanDoiDuLieu.enable();mnuChuyenTiep.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" IDMode="Static" EmptyMsg="Hiện không có dữ liệu"
                                    PageSize="15" NextText="Trang sau" PrevText="Trang trước" LastText="Trang cuối cùng"
                                    FirstText="Trang đầu tiên" DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="40" />
                                            </Items>
                                            <SelectedItem Value="15" />
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
                                <RowDblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{btnCapNhat_DongLai}.hide();#{cbxTieuChiCha}.setDisabled(false);" />
                            </Listeners>
                            <DirectEvents>
                                <RowDblClick OnEvent="btnEditCriterion_Click" Before="btnUpdateAddCriterion.hide();btnUpdateEditCriterion.show();btnUpdateEditAndCloseCriterion.hide();txtCriterionCode.disable();">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </RowDblClick>
                            </DirectEvents>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
