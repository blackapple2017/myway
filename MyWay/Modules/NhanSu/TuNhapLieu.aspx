<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TuNhapLieu.aspx.cs" Inherits="Modules_NhanSu_TuNhapLieu" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="TuCapNhatJs.js" type="text/javascript"></script>
    <script src="../HoSoNhanSu/ValidateInputForm.js" type="text/javascript"></script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="../../Resource/js/global.js" type="text/javascript"></script>
    <script type="text/javascript">
        var searchBoxKT = function (f, e) {
            SouthHoSoNhanSu1_hdfLyDoKTTemp.setValue(SouthHoSoNhanSu1_cbLyDoKhenThuong.getRawValue());
            if (SouthHoSoNhanSu1_hdfIsDanhMuc.getValue() == '1') {
                SouthHoSoNhanSu1_hdfIsDanhMuc.setValue('2');
            }
            if (SouthHoSoNhanSu1_cbLyDoKhenThuong.getRawValue() == '') {
                SouthHoSoNhanSu1_hdfIsDanhMuc.reset();
            }
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
        };
    </script>
    <style type="text/css">
        .bkGround .x-tab-panel-body
        {
            background: #DFE8F6 !important;
        }
        
        .x-panel-body
        {
            background: #DFE8F6 !important;
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
        
        .search-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 3px 3px 3px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }
        
        .search-item h3
        {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }
        
        #TabBottomPanel
        {
            border-top: 1px solid #8DB2E3 !important;
        }
        
        #img_anhdaidien
        {
            border: 1px solid #8DB2E3 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server" method="post" enctype="multipart/form-data">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="
                        cbx_quoctich_Store.reload();cbx_dantoc_Store.reload();cbx_tthonnhan_Store.reload();cbx_congviec_Store.reload();cbxHinhThucLamViec_Store.reload();
                        cbx_tongiao_Store.reload();cbx_tinhthanh_Store.reload();cbx_chucvu.store.reload();cbx_tpgiadinh_Store.reload();
                        cbx_ttsuckhoe_Store.reload();cbx_xeploai_Store.reload();cbx_tinhoc_Store.reload();cbx_tpbanthan_Store.reload();
                        cbx_ngoaingu_Store.reload();cbx_trinhdo_Store.reload();cbx_tdvanhoa_Store.reload();cbx_bophan_Store.reload();
                        cbx_noicapbhxh_Store.reload();cbx_noikcb_Store.reload();cbx_huongcs_Store.reload(); 
                        cbx_noicapcmnd_Store.reload();cbx_trinhdochinhtri_Store.reload();cbx_chuvudang_Store.reload();cbx_bacquandoi_Store.reload();
                        cbx_chucvuquandoi_Store.reload();cbx_chucvudoan_Store.reload();cbx_noicaphc_Store.reload();cbx_httuyen_Store.reload();
                        cbx_ngach_Store.reload();cbx_trinhdoquanly_Store.reload();cbx_trinhdoquanlykt_Store.reload();cbx_nganhang_Store.reload(); 
                    " />
            </Listeners>
        </ext:ResourceManager>
        <uc1:ucChooseEmployee ChiChonMotCanBo="true" ID="ucChooseEmployee1" runat="server" />
        <ext:Hidden runat="server" ID="hdfTypeWindow" />
        <ext:Hidden runat="server" ID="hdfButtonClick" />
        <ext:Hidden runat="server" ID="hdfButton" />
        <ext:Hidden runat="server" ID="hdfMaDonViTinh" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Window runat="server" Layout="BorderLayout" Padding="6" Modal="true" Title="Quản lý đơn vị tính"
            Width="500" Constrain="true" ID="wdDonViTinh" Icon="DeviceStylus" Height="300"
            Hidden="true">
            <TopBar>
                <ext:Toolbar runat="server" ID="tbCongNo">
                    <Items>
                        <ext:Button ID="btnAddDonViTinh" runat="server" Text="Thêm mới" Icon="Add">
                            <Listeners>
                                <Click Handler="#{hdfButton}.setValue('insert');addDonViTinh();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button ID="btnDeleteDonViTinh" Disabled="true" runat="server" Text="Xóa" Icon="Delete">
                            <Listeners>
                                <Click Handler="#{hdfButton}.setValue('delete');deleteDonViTinh(#{DirectMethods});" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnEditDonViTinh" Disabled="true" Text="Sửa" Icon="Pencil">
                            <Listeners>
                                <Click Handler="#{hdfButton}.setValue('edit');editDonViTinh();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Listeners>
                <BeforeShow Handler="#{hdfhasChange}.reset();" />
                <Hide Handler="if(#{hdfhasChange}.getValue()!='') #{grpDonViTinh_Store}.reload();" />
            </Listeners>
            <Items>
                <ext:Hidden runat="server" ID="hdfhasChange" />
                <ext:GridPanel ID="grpDonViTinh" Region="Center" runat="server" StripeRows="true"
                    Border="false" TrackMouseOver="true" AutoExpandColumn="TEN_DVT" AutoScroll="true"
                    AnchorHorizontal="100%" Height="200">
                    <Store>
                        <ext:Store ID="grpDonViTinh_Store" runat="server" AutoLoad="false" OnRefreshData="grpDonViTinh_Store_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_DVT">
                                    <Fields>
                                        <ext:RecordField Name="MA_DVT" />
                                        <ext:RecordField Name="TEN_DVT" />
                                        <ext:RecordField Name="GHI_CHU" />
                                        <ext:RecordField Name="DATE_CREATE" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel22" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="MA_DVT" Header="Mã đơn vị tính" DataIndex="MA_DVT" Width="60">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtMaDonViTinh">
                                    </ext:TextField>
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="TEN_DVT" Header="Tên đơn vị tính" DataIndex="TEN_DVT" Width="150">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtTenDonViTinh">
                                    </ext:TextField>
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" Width="100">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtGhiChuDVT">
                                    </ext:TextField>
                                </Editor>
                            </ext:Column>
                            <ext:DateColumn Format="dd/MM/yyyy" Width="80" Header="Ngày tạo" DataIndex="DATE_CREATE" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <Plugins>
                        <ext:RowEditor ID="RowEditor1" runat="server" CancelText="Hủy" SaveText="Cập nhật">
                            <Listeners>
                                <CancelEdit Handler="RemoveCanceledRecord(#{grpDonViTinh}, #{grpDonViTinh_Store});" />
                                <AfterEdit Handler="SaveDonViTinh(#{txtMaDonViTinh}.getValue(), #{txtTenDonViTinh}.getValue(), #{txtGhiChuDVT}.getValue(), #{DirectMethods}); #{hdfhasChange}.setValue('True');" />
                            </Listeners>
                        </ext:RowEditor>
                    </Plugins>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="#{btnDeleteDonViTinh}.enable();#{btnEditDonViTinh}.enable();" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="#{hdfButton}.setValue('edit');editDonViTinh();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button ID="Button4" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdDonViTinh}.hide()" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{grpDonViTinh_Store}.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Title="Chọn ảnh" Resizable="false" Icon="ImageAdd" Hidden="true"
            Padding="6" ID="wdUploadImageWindow" Width="400" Modal="true" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="frmPanelUploadImage">
                    <Items>
                        <ext:Hidden runat="server" Text="~/Modules/NhanSu/ImageNhanSu" ID="hdfImageFolder" />
                        <ext:Hidden runat="server" ID="hdfUploadedImage" />
                        <ext:FileUploadField runat="server" ID="fufUploadControl" AllowBlank="false" RegexText="Định dạng tệp tin không hợp lệ"
                            Regex="(http(s?):)|([/|.|\w|\s])*\.(?:jpg|gif|png|bmp|jpeg|JPG|PNG|GIF|BMP|JPEG)"
                            AnchorHorizontal="100%" FieldLabel="Chọn ảnh">
                            <Listeners>
                                <FileSelected Handler="if (#{frmPanelUploadImage}.getForm().isValid())
                                                {
                                                    #{btnUpdateImage}.enable();    
                                                }else
                                                {
                                                    alert('Định dạng file không hợp lệ, chương trình chỉ chấp nhận định dạng jpg, bmp, jpeg, gif, png!');
                                                    #{btnUpdateImage}.disable();
                                                }" />
                            </Listeners>
                        </ext:FileUploadField>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdateImage" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnUpdateImage_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdUploadImageWindow}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{btnUpdateImage}.disable();" />
                <Hide Handler="fufUploadControl.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdQuanHeGiaDinh" AutoHeight="true" Width="520" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Quan hệ gia đình" Resizable="false">
            <Items>
                <ext:Container ID="Container56" runat="server" Layout="Column" Height="85">
                    <Items>
                        <ext:Container ID="Container57" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" FieldLabel="Họ tên<span style='color:red'>*</span>"
                                    CtCls="requiredData" ID="txtQHGDHoTen" AnchorHorizontal="95%" TabIndex="408"
                                    MaxLength="50" />
                                <ext:TextField runat="server" ID="txtQHGDNamSinh" MaskRe="/[0-9\.]/" FieldLabel="Năm sinh"
                                    AnchorHorizontal="95%" TabIndex="409" MaxLength="4" MinLength="4" />
                                <ext:TextField runat="server" FieldLabel="Nghề nghiệp" ID="txtQHGDNgheNghiep" AnchorHorizontal="95%"
                                    TabIndex="410" MaxLength="50" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container58" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                            <Items>
                                <ext:ComboBox runat="server" Editable="false" FieldLabel="Giới tính<span style='color:red'>*</span>"
                                    CtCls="requiredData" ID="cbQHGDGioiTinh" AnchorHorizontal="100%" SelectedIndex="0"
                                    TabIndex="411">
                                    <Items>
                                        <ext:ListItem Value="Nam" Text="Nam" />
                                        <ext:ListItem Value="Nữ" Text="Nữ" />
                                    </Items>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox runat="server" ID="cbQuanHeGiaDinh" Editable="false" DisplayField="TEN_QUANHE"
                                    CtCls="requiredData" TabIndex="412" FieldLabel="Quan hệ<span style='color:red'>*</span>"
                                    ValueField="MA_QUANHE" AnchorHorizontal="100%">
                                    <Store>
                                        <ext:Store ID="cbQuanHeGiaDinhStore" runat="server" AutoLoad="false" OnRefreshData="cbQuanHeGiaDinhStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_QUANHE">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_QUANHE" />
                                                        <ext:RecordField Name="TEN_QUANHE" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Expand Handler="#{cbQuanHeGiaDinhStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField runat="server" FieldLabel="Nơi làm việc" ID="txtQHGDNoiLamViec" AnchorHorizontal="100%"
                                    TabIndex="413" MaxLength="50" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Checkbox runat="server" ID="chkQHGDLaNguoiPhuThuoc" BoxLabel="Là người phụ thuộc"
                    TabIndex="414" Checked="false">
                    <Listeners>
                        <Check Handler="if (#{chkQHGDLaNguoiPhuThuoc}.checked == true) {
                                                #{dfQHGDBatDauGiamTru}.enable();
                                                #{dfQHGDKetThucGiamTru}.enable();
                                            }
                                            else
                                            {
                                                #{dfQHGDBatDauGiamTru}.disable();
                                                #{dfQHGDKetThucGiamTru}.disable();
                                            }
                                        " />
                    </Listeners>
                </ext:Checkbox>
                <ext:Container ID="Container31" runat="server" Layout="ColumnLayout" Height="35">
                    <Items>
                        <ext:Container ID="Container33" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:DateField runat="server" ID="dfQHGDBatDauGiamTru" Disabled="true" Vtype="daterange"
                                    TabIndex="415" FieldLabel="Bắt đầu giảm trừ" AnchorHorizontal="95%" Editable="false">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container36" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:DateField runat="server" ID="dfQHGDKetThucGiamTru" Disabled="true" Vtype="daterange"
                                    TabIndex="416" FieldLabel="K/thúc giảm trừ" AnchorHorizontal="100%" Editable="false">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtQHGDGhiChu" AnchorHorizontal="100%"
                    TabIndex="417" MaxLength="500" />
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateQuanHeGiaDinh" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidInputQuanHeGiaDinh();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuanHeGiaDinh_Click" After="resetFormQuanHeGiaDinh">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnUpdate" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidInputQuanHeGiaDinh();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuanHeGiaDinh_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatVaDongQHGD" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidInputQuanHeGiaDinh();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuanHeGiaDinh_Click" After="resetFormQuanHeGiaDinh">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button29" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdQuanHeGiaDinh}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetFormQuanHeGiaDinh();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdAddBangCap" Width="600" EnableViewState="false"
            Title="Quá trình học tập" Resizable="false" Constrain="true" Modal="true" Icon="Add"
            AutoHeight="true" Hidden="true" Padding="6">
            <Items>
                <ext:Container runat="server" ID="Container26" Layout="ColumnLayout" Height="150">
                    <Items>
                        <ext:Container runat="server" ID="Container28" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:ComboBox Editable="false" ID="cbx_NoiDaoTaoBangCap" runat="server" DisplayField="TEN_TRUONG_DAOTAO"
                                    TabIndex="600" ValueField="MA_TRUONG_DAOTAO" FieldLabel="Nơi đào tạo<span style='color:red'>*</span>"
                                    AnchorHorizontal="95%">
                                    <Store>
                                        <ext:Store runat="server" AutoLoad="false" OnRefreshData="cbx_NoiDaoTaoBangCapStore_OnRefreshData"
                                            ID="cbx_NoiDaoTaoBangCapStore">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_TRUONG_DAOTAO">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_TRUONG_DAOTAO">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_TRUONG_DAOTAO">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        <Expand Handler="#{cbx_NoiDaoTaoBangCapStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox Editable="false" runat="server" DisplayField="TEN_HT_DAOTAO" ValueField="MA_HT_DAOTAO"
                                    TabIndex="601" ID="cbx_hinhthucdaotaobang" FieldLabel="Hình thức<span style='color:red'>*</span>"
                                    AnchorHorizontal="95%">
                                    <Store>
                                        <ext:Store runat="server" OnRefreshData="cbx_hinhthucdaotaobangStore_OnRefreshData"
                                            AutoLoad="false" ID="cbx_hinhthucdaotaobangStore">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_HT_DAOTAO">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_HT_DAOTAO">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_HT_DAOTAO">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        <Expand Handler="#{cbx_hinhthucdaotaobangStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField ID="txt_khoa" AllowBlank="false" runat="server" FieldLabel="Khoa<span style='color:red'>*</span>"
                                    TabIndex="602" AnchorHorizontal="95%" MaxLength="200">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="df_ngaybatdauhoc" FieldLabel="Từ ngày" AnchorHorizontal="95%"
                                    TabIndex="603" Editable="false">
                                </ext:DateField>
                                <ext:Checkbox ID="Chk_DaTotNghiep" runat="server" AnchorHorizontal="95%" BoxLabel="Đã tốt nghiệp"
                                    Checked="true" TabIndex="604">
                                </ext:Checkbox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container29" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:ComboBox Editable="false" runat="server" DisplayField="TEN_CHUYENNGANH" ValueField="MA_CHUYENNGANH"
                                    ID="cbx_ChuyenNganhBangCap" FieldLabel="Chuyên ngành<span style='color:red'>*</span>"
                                    AnchorHorizontal="100%" TabIndex="605">
                                    <Store>
                                        <ext:Store runat="server" AutoLoad="false" OnRefreshData="cbx_ChuyenNganhBangCapStore_OnRefreshData"
                                            ID="cbx_ChuyenNganhBangCapStore">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_CHUYENNGANH">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_CHUYENNGANH">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_CHUYENNGANH">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        <Expand Handler="#{cbx_ChuyenNganhBangCapStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox Editable="false" runat="server" DisplayField="TEN_TRINHDO" ValueField="MA_TRINHDO"
                                    ID="cbx_trinhdobangcap" FieldLabel="Trình độ<span style='color:red'>*</span>"
                                    TabIndex="606" AnchorHorizontal="100%">
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_trinhdobangcapStore" AutoLoad="false" OnRefreshData="cbx_trinhdobangcapStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_TRINHDO">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_TRINHDO">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_TRINHDO">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        <Expand Handler="#{cbx_trinhdobangcapStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ComboBox Editable="false" runat="server" ID="cbx_xeploaiBangCap" DisplayField="TEN_XEPLOAI"
                                    TabIndex="607" ValueField="MA_XEPLOAI" FieldLabel="Xếp loại" AnchorHorizontal="100%">
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_xeploaiBangCapStore" AutoLoad="false" OnRefreshData="cbx_xeploaiBangCapStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_XEPLOAI">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_XEPLOAI">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_XEPLOAI">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        <Expand Handler="#{cbx_xeploaiBangCapStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:DateField runat="server" ID="df_ngayketthuchoc" FieldLabel="Đến ngày" AnchorHorizontal="100%"
                                    TabIndex="608" Editable="false">
                                </ext:DateField>
                                <ext:DateField runat="server" ID="df_NgayNhanBang" FieldLabel="Ngày nhận bằng" AnchorHorizontal="100%"
                                    TabIndex="609" Editable="false">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdateBangCap" Icon="Disk" Text="Cập nhật" TabIndex="610">
                    <Listeners>
                        <Click Handler="return ValidInputQuaTrinhHocTap();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateBangCap_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btn_EditBangCap" Hidden="true" Text="Cập nhật" Icon="Disk"
                    TabIndex="611">
                    <Listeners>
                        <Click Handler="return ValidInputQuaTrinhHocTap();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateBangCap_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateandCloseBangCap" Icon="Disk" Text="Cập nhật & đóng lại"
                    TabIndex="612">
                    <Listeners>
                        <Click Handler="return ValidInputQuaTrinhHocTap();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateBangCap_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btn_ThoatBangCap" Icon="Decline" Text="Đóng lại" TabIndex="613">
                    <Listeners>
                        <Click Handler="#{wdAddBangCap}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetWdQuaTrinhHocTap();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdKinhNghiemLamViec" Width="600" EnableViewState="false"
            Title="Kinh nghiệm làm việc" Resizable="false" Constrain="true" Modal="true"
            Icon="Add" AutoHeight="true" Hidden="true" Padding="6" Layout="FormLayout">
            <Items>
                <ext:Container runat="server" ID="Container9" AnchorHorizontal="100%" Layout="ColumnLayout"
                    Height="52">
                    <Items>
                        <ext:Container runat="server" ID="cot1" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" ID="txt_noilamviec" FieldLabel="Nơi làm việc<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="95%" AllowBlank="false" TabIndex="1" MaxLength="500">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfKNLVTuNgay" FieldLabel="Từ ngày<span style='color:red;'>*</span>"
                                    CtCls="requiredData" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" AnchorHorizontal="95%">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container8" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" ID="txt_vitriconviec" FieldLabel="Chức danh<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AllowBlank="false" AnchorHorizontal="100%" TabIndex="2"
                                    MaxLength="500">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfKNLVDenNgay" FieldLabel="Đến ngày" Editable="true"
                                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" AnchorHorizontal="100%">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txtThanhTichTrongCongViec" FieldLabel="Thành tích"
                    EmptyText="Thành tích đạt được trong công việc" AllowBlank="false" AnchorHorizontal="100%"
                    TabIndex="3" MaxLength="500">
                </ext:TextField>
                <ext:Container AnchorHorizontal="100%" runat="server" Height="30" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ColumnWidth="0.5" runat="server" Layout="FormLayout" Height="30">
                            <Items>
                                <ext:NumberField ID="nbfMucLuong" AnchorHorizontal="95%" runat="server" FieldLabel="Mức lương"
                                    MaxLength="9" />
                            </Items>
                        </ext:Container>
                        <ext:TextField runat="server" ID="txtLyDoThoiViec" FieldLabel="Lý do thôi việc" ColumnWidth="0.5" />
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtGhiChuKinhNghiemLamViec" FieldLabel="Ghi chú"
                    AnchorHorizontal="100%" TabIndex="6" MaxLength="500" Height="50">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="Update" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="return CheckInputKinhNghiemLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="UpdateKinhNghiemLamViec_Click" After="ResetWdKinhNghiemLamViec();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditKinhNghiem" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKinhNghiemLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="UpdateKinhNghiemLamViec_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="UpdateandClose" Icon="Disk" Text="Cập nhật & đóng lại">
                    <Listeners>
                        <Click Handler="return CheckInputKinhNghiemLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="UpdateKinhNghiemLamViec_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Close" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="#{wdKinhNghiemLamViec}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{Update}.show();#{btnEditKinhNghiem}.hide();#{UpdateandClose}.show();ResetWdKinhNghiemLamViec();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdAddChungChi" Width="600" EnableViewState="false"
            Title="Chứng chỉ" Resizable="true" Constrain="true" Modal="true" Icon="Add" AutoHeight="true"
            Hidden="true" Padding="6" Layout="FormLayout">
            <Items>
                <ext:Container runat="server" ID="Container10" Layout="ColumnLayout" Height="27">
                    <Items>
                        <ext:Container runat="server" ID="Container1" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:ComboBox runat="server" ValueField="MA_CHUNGCHI" DisplayField="TEN_CHUNGCHI"
                                    ID="cbx_tenchungchi" FieldLabel="Chứng chỉ<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="95%" TabIndex="1" Editable="false" ItemSelector="div.list-item">
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_tenchungchiStore" OnRefreshData="cbx_tenchungchiStore_OnRefreshData"
                                            AutoLoad="false">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_CHUNGCHI">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_CHUNGCHI">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_CHUNGCHI">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template47" runat="server">
                                        <Html>
                                            <tpl for=".">
						                    <div class="list-item"> 
							                    {TEN_CHUNGCHI}
						                    </div>
					                    </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbx_tenchungchiStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container16" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbx_XepLoaiChungChi" DisplayField="TEN_XEPLOAI"
                                    ValueField="MA_XEPLOAI" FieldLabel="Xếp loại<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="100%" TabIndex="2" Editable="false" ItemSelector="div.list-item">
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_XepLoaiChungChiStore" OnRefreshData="cbx_XepLoaiChungChiStore_OnRefreshData"
                                            AutoLoad="false">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_XEPLOAI">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_XEPLOAI">
                                                        </ext:RecordField>
                                                        <ext:RecordField Name="TEN_XEPLOAI">
                                                        </ext:RecordField>
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template48" runat="server">
                                        <Html>
                                            <tpl for=".">
						                    <div class="list-item"> 
							                    {TEN_XEPLOAI}
						                    </div>
					                    </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbx_XepLoaiChungChiStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="cbx_NoiDaoTao" FieldLabel="Nơi đào tạo" AnchorHorizontal="100%"
                    TabIndex="3" MaxLength="500">
                </ext:TextField>
                <ext:Container runat="server" ID="Container17" Layout="ColumnLayout" Height="27">
                    <Items>
                        <ext:Container runat="server" ID="Container3" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:DateField runat="server" ID="df_NgayCap" Vtype="daterange" FieldLabel="Ngày cấp"
                                    Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" AnchorHorizontal="95%" TabIndex="4">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container4" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:DateField runat="server" ID="df_NgayHetHan" Vtype="daterange" FieldLabel="Ngày hết hạn"
                                    Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" AnchorHorizontal="100%"
                                    TabIndex="5">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtGhiChuChungChi" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                    TabIndex="6" MaxLength="5000">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdateChungChi" Icon="Disk" Text="Cập nhật" TabIndex="906">
                    <Listeners>
                        <Click Handler="return ValidInputAddChungChi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateChungChi_Click" After="resetWdChungChi">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditChungChi" Hidden="true" Text="Cập nhật" Icon="Disk"
                    TabIndex="907">
                    <Listeners>
                        <Click Handler="return ValidInputAddChungChi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateChungChi_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateandCloseChungChi" Icon="Disk" Text="Cập nhật & đóng lại"
                    TabIndex="908">
                    <Listeners>
                        <Click Handler="return ValidInputAddChungChi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateChungChi_Click" After="resetWdChungChi">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button3" Icon="Decline" Text="Đóng lại" TabIndex="909">
                    <Listeners>
                        <Click Handler="#{wdAddChungChi}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetWdChungChi();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdAddTaiSan" AutoHeight="true" Width="400" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Tài sản" Resizable="false">
            <Items>
                <ext:ComboBox runat="server" ID="cbTaiSan" Editable="false" AnchorHorizontal="100%"
                    DisplayField="TEN_VTHH" FieldLabel="Chọn vật tư<span style='color:red;'>*</span>"
                    ValueField="MA_VTHH" ItemSelector="div.list-item" CtCls="requiredData">
                    <Store>
                        <ext:Store ID="cbTaiSanStore" runat="server" AutoLoad="false" OnRefreshData="cbTaiSanStore_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_VTHH">
                                    <Fields>
                                        <ext:RecordField Name="MA_VTHH" />
                                        <ext:RecordField Name="TEN_VTHH" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Template ID="Template42" runat="server">
                        <Html>
                            <tpl for=".">
						<div class="list-item"> 
							{TEN_VTHH}
						</div>
					</tpl>
                        </Html>
                    </Template>
                    <Listeners>
                        <Expand Handler="#{cbTaiSanStore}.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:CompositeField ID="CompositeField13" runat="server" FieldLabel="Số lượng<span style='color:red;'>*</span>"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:TextField runat="server" ID="txtTaiSanSoLuong" Width="50" MaskRe="/[0-9]/" CtCls="requiredData" />
                        <ext:DisplayField ID="DisplayField13" runat="server" Text="Đơn vị tính" />
                        <ext:ComboBox runat="server" ID="cbxDonViTinh" Editable="false" Width="150" DisplayField="TEN_DVT"
                            FieldLabel="Đơn vị tính" ValueField="MA_DVT" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store ID="cbxDonViTinh_Store" runat="server" AutoLoad="false" OnRefreshData="cbxDonViTinh_Store_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="MA_DVT">
                                            <Fields>
                                                <ext:RecordField Name="MA_DVT" />
                                                <ext:RecordField Name="TEN_DVT" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Triggers>
                                <ext:FieldTrigger Icon="SimpleEllipsis" />
                            </Triggers>
                            <Template ID="Template43" runat="server">
                                <Html>
                                    <tpl for=".">
						        <div class="list-item"> 
							        {TEN_DVT}
						        </div>
					        </tpl>
                                </Html>
                            </Template>
                            <Listeners>
                                <Expand Handler="#{cbxDonViTinh_Store}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="#{wdDonViTinh}.show();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:CompositeField>
                <ext:DateField ID="tsDateField" runat="server" FieldLabel="Ngày nhận" AnchorHorizontal="100%"
                    Editable="false" />
                <ext:TextField ID="tsTxtinhTrang" runat="server" FieldLabel="Tình trạng<span style='color:red;'>*</span>"
                    AnchorHorizontal="100%" MaxLength="50" CtCls="requiredData" />
                <ext:TextArea ID="tsGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                    MaxLength="50" />
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateTaiSan" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputTaiSan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateTaiSan_Click" After="ResetWdTaiSan();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditTaiSan" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputTaiSan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateTaiSan_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnUpdateCloseTaiSan" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputTaiSan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateTaiSan_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button6" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddTaiSan}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{Button2}.show();#{btnEditTaiSan}.hide();#{btnUpdateTaiSan}.show();ResetWdTaiSan();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdKhaNang" AutoHeight="true" Width="400" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Khả năng" Resizable="false">
            <Items>
                <ext:ComboBox runat="server" ID="cbKhaNang" DisplayField="TEN_KHANANG" FieldLabel="Khả năng<span style='color:red;'>*</span>"
                    ValueField="MA_KHANANG" AnchorHorizontal="100%" Editable="false" TabIndex="316">
                    <Store>
                        <ext:Store ID="cbKhaNangStore" runat="server" AutoLoad="false" OnRefreshData="cbKhaNangStore_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_KHANANG">
                                    <Fields>
                                        <ext:RecordField Name="MA_KHANANG" />
                                        <ext:RecordField Name="TEN_KHANANG" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Expand Handler="#{cbKhaNangStore}.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox runat="server" ID="cbKhaNangXepLoai" DisplayField="TEN_XEPLOAI" FieldLabel="Xếp loại<span style='color:red'>*</span>"
                    ValueField="MA_XEPLOAI" AnchorHorizontal="100%" Editable="false" TabIndex="317">
                    <Store>
                        <ext:Store ID="cbKhaNangXepLoaiStore" runat="server" AutoLoad="false" OnRefreshData="cbKhaNangXepLoaiStore_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_XEPLOAI">
                                    <Fields>
                                        <ext:RecordField Name="MA_XEPLOAI" />
                                        <ext:RecordField Name="TEN_XEPLOAI" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Expand Handler="#{cbKhaNangXepLoaiStore}.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextArea ID="txtKhaNangGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                    TabIndex="318" MaxLength="500" />
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateKhaNang" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidInputKhaNang();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKhaNang_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditKhaNang" runat="server" Text="Cập nhật" Hidden="true" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidInputKhaNang();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKhaNang_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatVaDongKhaNang" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidInputKhaNang();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKhaNang_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button23" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdKhaNang}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetKhaNang();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdKhenThuong" AutoHeight="true" Width="550" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Khen thưởng" Resizable="false">
            <Items>
                <ext:TextField runat="server" FieldLabel="Số quyết định<span style='color:red;'>*</span>"
                    CtCls="requiredData" ID="txtKhenThuongSoQuyetDinh" AnchorHorizontal="99%" TabIndex="400"
                    MaxLength="20" />
                <ext:Container ID="Container53" runat="server" Layout="ColumnLayout" Height="55">
                    <Items>
                        <ext:Container ID="Container54" runat="server" LabelAlign="left" Layout="FormLayout"
                            ColumnWidth="0.5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfKhenThuongNguoiQD" />
                                <ext:TriggerField runat="server" ID="tgf_KhenThuong_NguoiRaQD" FieldLabel="Người quyết định"
                                    AnchorHorizontal="99%" Editable="false" TabIndex="401">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="SimplePlus" />
                                    </Triggers>
                                    <Listeners>
                                        <TriggerClick Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:Hidden runat="server" ID="hdfIsDanhMuc" Text="0" />
                                <%-- 0: user enter text, 1: user select item, 2: user select and edit --%>
                                <ext:Hidden runat="server" ID="hdfMaLyDoKhenThuong" />
                                <ext:Hidden runat="server" ID="hdfLyDoKTTemp" />
                                <ext:ComboBox runat="server" ID="cbLyDoKhenThuong" DisplayField="TEN_LYDO_KTHUONG"
                                    CtCls="requiredData" FieldLabel="Lý do thưởng<span style='color:red;'>*</span>"
                                    ValueField="MA_LYDO_KTHUONG" AnchorHorizontal="99%" TabIndex="402" Editable="true"
                                    ItemSelector="div.list-item">
                                    <Store>
                                        <ext:Store ID="cbLyDoKhenThuongStore" runat="server" AutoLoad="false" OnRefreshData="cbLyDoKhenThuongStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_LYDO_KTHUONG">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_LYDO_KTHUONG" />
                                                        <ext:RecordField Name="TEN_LYDO_KTHUONG" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template2" runat="server">
                                        <Html>
                                            <tpl for=".">
						                <div class="list-item"> 
							                {TEN_LYDO_KTHUONG}
						                </div>
					                </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbLyDoKhenThuongStore}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfMaLyDoKhenThuong}.setValue(#{cbLyDoKhenThuong}.getValue());
                                                            #{hdfIsDanhMuc}.setValue('1');
                                                            #{hdfLyDoKTTemp}.setValue(#{cbLyDoKhenThuong}.getRawValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfIsDanhMuc}.reset(); }" />
                                        <KeyUp Fn="searchBoxKT" />
                                        <Blur Handler="#{cbLyDoKhenThuong}.setRawValue(#{hdfLyDoKTTemp}.getValue());
                                    if (#{hdfIsDanhMuc}.getValue() != '1') {#{cbLyDoKhenThuong}.setValue(#{hdfLyDoKTTemp}.getValue());}" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container55" runat="server" LabelAlign="left" Layout="FormLayout"
                            LabelWidth="110" ColumnWidth="0.5">
                            <Items>
                                <ext:DateField runat="server" FieldLabel="Ngày quyết định<span style='color:red;'>*</span>"
                                    CtCls="requiredData" ID="dfKhenThuongNgayQuyetDinh" AnchorHorizontal="98%" TabIndex="403"
                                    Editable="false" />
                                <ext:ComboBox runat="server" ID="cbHinhThucKhenThuong" DisplayField="TEN_HT_KTHUONG"
                                    FieldLabel="Hình thức<span style='color:red;'>*</span>" ValueField="MA_HT_KTHUONG"
                                    CtCls="requiredData" AnchorHorizontal="98%" TabIndex="404" Editable="false" ItemSelector="div.list-item">
                                    <Store>
                                        <ext:Store ID="cbHinhThucKhenThuongStore" runat="server" AutoLoad="false" OnRefreshData="cbHinhThucKhenThuongStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_HT_KTHUONG">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_HT_KTHUONG" />
                                                        <ext:RecordField Name="TEN_HT_KTHUONG" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template18" runat="server">
                                        <Html>
                                            <tpl for=".">
						                <div class="list-item"> 
							                {TEN_HT_KTHUONG}
						                </div>
					                </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbHinhThucKhenThuongStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txtKhenThuongSoTien" FieldLabel="Số tiền" AnchorHorizontal="99%"
                    TabIndex="405" MaxLength="16" MaskRe="/[0-9]/" />
                <ext:Hidden runat="server" ID="hdfKhenThuongTepTinDinhKem" />
                <ext:CompositeField ID="CompositeField8" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
                    <Items>
                        <ext:FileUploadField ID="fufKhenThuongTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                            ButtonText="" Icon="Attach" Width="358" TabIndex="406">
                        </ext:FileUploadField>
                        <ext:Button runat="server" ID="btnKhenThuongDownload" Icon="ArrowDown" ToolTip="Tải về">
                            <DirectEvents>
                                <Click OnEvent="btnKhenThuongDownload_Click" IsUpload="true" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnKhenThuongDelete" Icon="Delete" ToolTip="Xóa">
                            <Listeners>
                                <Click Handler="#{fufKhenThuongTepTinDinhKem}.reset();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnKhenThuongDelete_Click" After="#{fufKhenThuongTepTinDinhKem}.reset();">
                                    <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                        ConfirmRequest="true" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:CompositeField>
                <ext:Container ID="Container59" runat="server" Layout="ColumnLayout" Height="100">
                    <Items>
                        <ext:Container ID="Container60" runat="server" LabelAlign="left" Layout="FormLayout"
                            ColumnWidth="1">
                            <Items>
                                <ext:TextArea ID="txtKhenThuongGhiCHu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="99%"
                                    TabIndex="407" MaxLength="1000" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateKhenThuong" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKhenThuong(#{fufKhenThuongTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKhenThuong_Click" After="ResetWdKhenThuong();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditKhenThuong" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKhenThuong(#{fufKhenThuongTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKhenThuong_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button24" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKhenThuong(#{fufKhenThuongTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKhenThuong_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button25" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdKhenThuong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnUpdateKhenThuong}.show();#{btnEditKhenThuong}.hide();#{Button24}.show();ResetWdKhenThuong();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdKyLuat" AutoHeight="true" Width="550" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Kỷ luật" Resizable="false">
            <Items>
                <ext:TextField runat="server" FieldLabel="Số quyết định<span style='color:red;'>*</span>"
                    ID="txtKyLuatSoQD" AnchorHorizontal="99%" TabIndex="1" MaxLength="50" />
                <ext:Container ID="Container61" runat="server" Layout="Column" Height="55">
                    <Items>
                        <ext:Container ID="Container62" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfKyLuatNguoiQD" />
                                <ext:TriggerField runat="server" ID="tgfKyLuatNguoiQD" FieldLabel="Người quyết định"
                                    AnchorHorizontal="99%" Editable="false">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="SimplePlus" />
                                    </Triggers>
                                    <Listeners>
                                        <TriggerClick Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:ComboBox runat="server" ID="cbLyDoKyLuat" DisplayField="TEN_LYDO_KYLUAT" FieldLabel="Lý do<span style='color:red;'>*</span>"
                                    ValueField="MA_LYDO_KYLUAT" AnchorHorizontal="99%" TabIndex="3" Editable="false"
                                    ItemSelector="div.list-item">
                                    <Store>
                                        <ext:Store ID="cbLyDoKyLuatStore" runat="server" AutoLoad="false" OnRefreshData="cbLyDoKyLuatStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_LYDO_KYLUAT">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_LYDO_KYLUAT" />
                                                        <ext:RecordField Name="TEN_LYDO_KYLUAT" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template19" runat="server">
                                        <Html>
                                            <tpl for=".">
						                <div class="list-item"> 
							                {TEN_LYDO_KYLUAT}
						                </div>
					                </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbLyDoKyLuatStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container63" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5"
                            LabelWidth="110">
                            <Items>
                                <ext:DateField runat="server" FieldLabel="Ngày quyết định<span style='color:red;'>*</span>"
                                    ID="dfKyLuatNgayQuyetDinh" AnchorHorizontal="98%" TabIndex="2" Editable="false" />
                                <ext:ComboBox runat="server" ID="cbHinhThucKyLuat" DisplayField="TEN_HT_KYLUAT" FieldLabel="Hình thức<span style='color:red;'>*</span>"
                                    ValueField="MA_HT_KYLUAT" AnchorHorizontal="98%" TabIndex="4" Editable="false"
                                    ItemSelector="div.list-item">
                                    <Store>
                                        <ext:Store ID="cbHinhThucKyLuatStore" runat="server" AutoLoad="false" OnRefreshData="cbHinhThucKyLuatStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_HT_KYLUAT">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_HT_KYLUAT" />
                                                        <ext:RecordField Name="TEN_HT_KYLUAT" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template38" runat="server">
                                        <Html>
                                            <tpl for=".">
						                <div class="list-item"> 
							                {TEN_HT_KYLUAT}
						                </div>
					                </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbHinhThucKyLuatStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:NumberField runat="server" ID="txtKyLuatSoTien" FieldLabel="Số tiền" AnchorHorizontal="99%"
                    TabIndex="5" MaxLength="16" />
                <ext:Hidden runat="server" ID="hdfKyLuatTepTinDinhKem" />
                <ext:CompositeField ID="CompositeField9" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
                    <Items>
                        <ext:FileUploadField ID="fufKyLuatTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                            ButtonText="" Icon="Attach" Width="358">
                        </ext:FileUploadField>
                        <ext:Button runat="server" ID="btnKyLuatDownload" Icon="ArrowDown" ToolTip="Tải về">
                            <DirectEvents>
                                <Click OnEvent="btnKyLuatDownload_Click" IsUpload="true" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnKyLuatDelete" Icon="Delete" ToolTip="Xóa">
                            <Listeners>
                                <Click Handler="#{fufKyLuatTepTinDinhKem}.reset();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnKyLuatDelete_Click">
                                    <EventMask ShowMask="true" />
                                    <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                        ConfirmRequest="true" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:CompositeField>
                <ext:TextArea ID="txtKyLuatGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="99%"
                    TabIndex="6" />
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhatKyLuat" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKyLuat(#{fufKyLuatTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKyLuat_Click" After="ResetWdKyLuat();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditKyLuat" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKyLuat(#{fufKyLuatTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKyLuat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button26" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputKyLuat(#{fufKyLuatTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKyLuat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button27" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdKyLuat}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') Ext.net.DirectMethods.GenerateKyLuatSoQD();" />
                <Hide Handler="#{btnCapNhatKyLuat}.show();#{btnEditKyLuat}.hide();#{Button26}.show();ResetWdKyLuat();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdQuaTrinhCongTac" AutoHeight="true" Width="550" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Quá trình công tác" Resizable="false">
            <Items>
                <ext:TextField runat="server" ID="txtQTCTSoQD" FieldLabel="Số quyết định" AnchorHorizontal="99%"
                    MaxLength="50" TabIndex="500" />
                <ext:Container ID="Container64" runat="server" Layout="ColumnLayout" Height="78">
                    <Items>
                        <ext:Container ID="Container65" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfQTCTNguoiQuyetDinh" />
                                <ext:TriggerField runat="server" ID="tgf_QTCTNguoiQuyetDinh" FieldLabel="Người quyết định"
                                    AnchorHorizontal="98%" Editable="false" TabIndex="501">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="SimplePlus" />
                                    </Triggers>
                                    <Listeners>
                                        <TriggerClick Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:DateField runat="server" ID="dfQTCTNgayBatDau" Vtype="daterange" AnchorHorizontal="98%"
                                    CtCls="requiredData" TabIndex="502" FieldLabel="Ngày bắt đầu<span style='color:red;'>*</span>"
                                    Editable="false">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container66" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                            LabelWidth="110">
                            <Items>
                                <ext:DateField runat="server" ID="dfQTCTNgayQuyetDinh" Vtype="daterange" AnchorHorizontal="98%"
                                    TabIndex="503" FieldLabel="Ngày quyết định" Editable="false">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                                <ext:DateField runat="server" ID="dfQTCTNgayKetThuc" Vtype="daterange" AnchorHorizontal="98%"
                                    CtCls="requiredData" TabIndex="504" FieldLabel="Ngày kết thúc<span style='color:red;'>*</span>"
                                    Editable="false">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtQTCTNoiDungCongViec" FieldLabel="Nội dung công việc<span style='color:red;'>*</span>"
                    TabIndex="505" AnchorHorizontal="99%" MaxLength="1000" Height="40" CtCls="requiredData" />
                <ext:ComboBox runat="server" ID="cbCongTacQuocGia" Editable="false" DisplayField="TEN_NUOC"
                    FieldLabel="Quốc gia" ValueField="MA_NUOC" AnchorHorizontal="100%" TabIndex="506"
                    ItemSelector="div.list-item">
                    <Store>
                        <ext:Store ID="cbCongTacQuocGiaStore" runat="server" AutoLoad="false" OnRefreshData="cbCongTacQuocGiaStore_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_NUOC">
                                    <Fields>
                                        <ext:RecordField Name="MA_NUOC" />
                                        <ext:RecordField Name="TEN_NUOC" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Template ID="Template39" runat="server">
                        <Html>
                            <tpl for=".">
						                <div class="list-item"> 
							                {TEN_NUOC}
						                </div>
					                </tpl>
                        </Html>
                    </Template>
                    <Listeners>
                        <Expand Handler="#{cbCongTacQuocGiaStore}.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField runat="server" ID="txtQTCTDiaDiemCT" FieldLabel="Nơi công tác<span style='color:red;'>*</span>"
                    TabIndex="507" AnchorHorizontal="99%" MaxLength="1000" CtCls="requiredData" />
                <ext:TextField runat="server" ID="txtQTCTNguoiLienQuan" FieldLabel="Người liên quan"
                    TabIndex="508" AnchorHorizontal="99%" MaxLength="1000" />
                <ext:Hidden runat="server" ID="hdfQTCTTepTinDinhKem" />
                <ext:CompositeField ID="CompositeField10" runat="server" AnchorHorizontal="99%" FieldLabel="Tệp tin đính kèm">
                    <Items>
                        <ext:FileUploadField ID="fufQTCTTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                            TabIndex="509" ButtonText="" Icon="Attach" Width="358">
                        </ext:FileUploadField>
                        <ext:Button runat="server" ID="btnQTCTDownload" Icon="ArrowDown" ToolTip="Tải về">
                            <DirectEvents>
                                <Click OnEvent="btnQTCTDownload_Click" IsUpload="true" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnQTCTDelete" Icon="Delete" ToolTip="Xóa">
                            <Listeners>
                                <Click Handler="#{fufQTCTTepTinDinhKem}.reset();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnQTCTDelete_Click">
                                    <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                    <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:CompositeField>
                <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtCongTacGhiChu" AnchorHorizontal="99%"
                    TabIndex="510">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhatQuaTrinhCongTac" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuaTrinhCongTac(#{fufQTCTTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatQuaTrinhCongTac_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditQuaTrinhCongTac" Text="Cập nhật" Icon="Disk"
                    Hidden="true">
                    <Listeners>
                        <Click Handler="return CheckInputQuaTrinhCongTac(#{fufQTCTTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatQuaTrinhCongTac_Click" After="ResetWdQuaTrinhCongTac();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button30" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuaTrinhCongTac(#{fufQTCTTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatQuaTrinhCongTac_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button31" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdQuaTrinhCongTac}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') #{DirectMethods}.GenerateQTCTSoQD();" />
                <Hide Handler="#{btnCapNhatQuaTrinhCongTac}.show();#{btnEditQuaTrinhCongTac}.hide();#{Button30}.show();ResetWdQuaTrinhCongTac();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdQuaTrinhDieuChuyen" AutoHeight="true" Width="550" runat="server"
            Padding="6" EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true"
            Constrain="true" Icon="Add" Title="Quá trình điều chuyển" Resizable="false">
            <Items>
                <ext:TextField runat="server" ID="txtQTDCSoQuyetDinh" FieldLabel="Số quyết định"
                    AnchorHorizontal="99%" TabIndex="1" />
                <ext:Container ID="Container5" runat="server" Layout="ColumnLayout" Height="55">
                    <Items>
                        <ext:Container ID="Container6" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfQTDCNguoiQuyetDinh" />
                                <ext:TriggerField runat="server" ID="tgfQTDCNguoiQuyetDinh" FieldLabel="Người quyết định"
                                    AnchorHorizontal="98%" Editable="false" TabIndex="2">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="SimplePlus" />
                                    </Triggers>
                                    <Listeners>
                                        <TriggerClick Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:DateField runat="server" ID="dfQTDCNgayCoHieuLuc" AnchorHorizontal="98%" FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>"
                                    CtCls="requiredData" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" TabIndex="3">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfQTDCNgayHetHieuLuc}.setMinValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container7" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                            LabelWidth="110">
                            <Items>
                                <ext:DateField runat="server" ID="dfQTDCNgayQuyetDinh" AnchorHorizontal="98%" FieldLabel="Ngày quyết định<span style='color:red;'>*</span>"
                                    CtCls="requiredData" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" TabIndex="4" />
                                <ext:DateField runat="server" ID="dfQTDCNgayHetHieuLuc" AnchorHorizontal="98%" FieldLabel="Hết hiệu lực"
                                    Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" TabIndex="5">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfQTDCNgayCoHieuLuc}.setMaxValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <%-- Chức vụ mới - công việc mới --%>
                <ext:ComboBox runat="server" ID="cbxQTDCBoPhanMoi" FieldLabel="Bộ phận mới<span style='color:red;'>*</span>"
                    DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
                    AnchorHorizontal="99%" TabIndex="9" Editable="false" CtCls="requiredData">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store runat="server" ID="cbxQTDCBoPhanMoi_Store" AutoLoad="false" OnRefreshData="cbxQTDCBoPhanMoi_Store_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA">
                                    <Fields>
                                        <ext:RecordField Name="MA" />
                                        <ext:RecordField Name="TEN" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Template ID="Template40" runat="server">
                        <Html>
                            <tpl for=".">
						        <div class="list-item"> 
							        {TEN}
						        </div>
					        </tpl>
                        </Html>
                    </Template>
                    <Listeners>
                        <Expand Handler="#{cbxQTDCBoPhanMoi_Store}.reload();" />
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Container runat="server" ID="ctndc1" Layout="ColumnLayout" AnchorHorizontal="100%"
                    Height="27">
                    <Items>
                        <ext:Container runat="server" ID="ctndc2" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbxQTDCChucVuMoi" FieldLabel="Chức vụ mới" DisplayField="TEN"
                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="10" Editable="false" ItemSelector="div.list-item">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store runat="server" ID="cbxQTDCChucVuMoi_Store" AutoLoad="false" OnRefreshData="cbxQTDCChucVuMoi_Store_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA">
                                                    <Fields>
                                                        <ext:RecordField Name="MA" />
                                                        <ext:RecordField Name="TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template41" runat="server">
                                        <Html>
                                            <tpl for=".">
					                            <div class="list-item"> 
						                            {TEN}
					                            </div>
				                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbxQTDCChucVuMoi_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctndc3" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbxCongViecMoi" FieldLabel="Chức danh mới" DisplayField="TEN"
                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="11" Editable="false" ItemSelector="div.list-item">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store runat="server" ID="cbxCongViecMoi_Store" AutoLoad="false" OnRefreshData="cbxCongViecMoi_Store_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA">
                                                    <Fields>
                                                        <ext:RecordField Name="MA" />
                                                        <ext:RecordField Name="TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template44" runat="server">
                                        <Html>
                                            <tpl for=".">
					                            <div class="list-item"> 
						                            {TEN}
					                            </div>
				                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Expand Handler="#{cbxCongViecMoi_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <%-- Kết thúc chức vụ mới --%>
                <ext:Hidden runat="server" ID="hdfQTDCTepTinDinhKem" />
                <ext:CompositeField ID="CompositeField1" runat="server" AnchorHorizontal="99%" FieldLabel="Tệp tin đính kèm">
                    <Items>
                        <ext:FileUploadField ID="fufQTDCTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                            ButtonText="" Icon="Attach" Width="358">
                        </ext:FileUploadField>
                        <ext:Button runat="server" ID="btnQTDCDownload" Icon="ArrowDown" ToolTip="Tải về">
                            <DirectEvents>
                                <Click OnEvent="btnQTDCDownload_Click" IsUpload="true" />
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnQTDCDelete" Icon="Delete" ToolTip="Xóa">
                            <DirectEvents>
                                <Click OnEvent="btnQTDCDelete_Click" After="#{fufQTDCTepTinDinhKem}.reset();">
                                    <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                        ConfirmRequest="true" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:CompositeField>
                <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtDieuChuyenGhiChu" AnchorHorizontal="99%"
                    TabIndex="12">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateQuaTrinhDC" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuaTrinhDieuChuyen(#{fufQTDCTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuaTrinhDC_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnUpdateQuaTrinhDieuChuyen" Hidden="true" runat="server" Text="Cập nhật"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuaTrinhDieuChuyen(#{fufQTDCTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuaTrinhDC_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button32" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuaTrinhDieuChuyen(#{fufQTDCTepTinDinhKem}.fileInput.dom);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuaTrinhDC_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button33" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdQuaTrinhDieuChuyen}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') #{DirectMethods}.GenerateQTDCSoQD();" />
                <Hide Handler="#{btnUpdateQuaTrinhDC}.show();#{btnUpdateQuaTrinhDieuChuyen}.hide();#{Button32}.show();ResetWdQuaTrinhDieuChuyen();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdTaiNanLaoDong" AutoHeight="true" Width="400" runat="server" Padding="6"
            EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
            Icon="Add" Title="Tai nạn lao động" Resizable="false">
            <Items>
                <ext:DateField runat="server" ID="TaiNan_dfNgayXayRa" Vtype="daterange" FieldLabel="Ngày xảy ra"
                    Editable="false" AnchorHorizontal="100%">
                </ext:DateField>
                <ext:TextArea ID="TaiNan_txtLydo" Height="40" runat="server" FieldLabel="Nguyên nhân<span style='color:red;'>*</span>"
                    AnchorHorizontal="100%" MaxLength="500" />
                <ext:TextField runat="server" ID="TaiNan_txtDiaDiemXayRa" FieldLabel="Địa điểm<span style='color:red;'>*</span>"
                    AnchorHorizontal="100%" MaxLength="500" />
                <ext:TextField runat="server" ID="TaiNan_txtThietHai" FieldLabel="Thiệt hại" AnchorHorizontal="100%"
                    MaxLength="500" />
                <ext:TextField runat="server" ID="TaiNan_txtThuongTat" FieldLabel="Thương tật" AnchorHorizontal="100%"
                    MaxLength="500" />
                <ext:TextField runat="server" ID="TaiNan_txtBoiThuong" MaskRe="/[0-9\.]/" FieldLabel="Bồi thường"
                    AnchorHorizontal="100%" MaxLength="12">
                    <Listeners>
                        <Change Handler="this.setValue(Ext.util.Format.number(newValue.replace(/[,]/g, ''), '0,000'));" />
                    </Listeners>
                </ext:TextField>
                <ext:DateField runat="server" ID="TaiNan_txtNgayBoiThuong" Vtype="daterange" FieldLabel="Ngày bồi thường"
                    Editable="false" AnchorHorizontal="100%">
                </ext:DateField>
                <ext:TextArea Height="40" runat="server" ID="TaiNan_txtGhiChu" FieldLabel="Ghi chú"
                    AnchorHorizontal="100%" />
            </Items>
            <Buttons>
                <ext:Button ID="btnInsertTaiNan" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputTaiNanLaoDong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateTaiNan_Click" After="ResetWdTaiNanLaoDong();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateTaiNan" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputTaiNanLaoDong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateTaiNan_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update">
                                </ext:Parameter>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnInsertTaiNanAndClose" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputTaiNanLaoDong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateTaiNan_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button34" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdTaiNanLaoDong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnInsertTaiNan}.show();#{btnUpdateTaiNan}.hide();#{btnInsertTaiNanAndClose}.show();ResetWdTaiNanLaoDong();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Hidden="true" Resizable="false" Padding="6" Layout="FormLayout"
            Modal="true" Width="500" ID="wdAttachFile" LabelWidth="120" Title="Tệp tin đính kèm"
            Icon="Attach" AutoHeight="true" Constrain="true">
            <Items>
                <ext:TextField ID="txtFileName" runat="server" AnchorHorizontal="100%" FieldLabel="Tên tệp tin<span style='color:red;'>*</span>"
                    MaxLength="200" />
                <ext:Hidden runat="server" ID="hdfAttachFile" />
                <ext:FileUploadField ID="file_cv" runat="server" FieldLabel="Tệp tin đính kèm<span style='color:red;'>*</span>"
                    AnchorHorizontal="100%" Icon="Attach">
                    <Listeners>
                        <FileSelected Handler="GetFileNameUpload();" />
                    </Listeners>
                </ext:FileUploadField>
                <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtGhiChu" AnchorHorizontal="100%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateAtachFile" runat="server" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="return ValidInputAttachFile();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateAtachFile_Click" After="resetAttachFile();">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditAttachFile" Hidden="true" runat="server" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="return ValidInputAttachFile();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateAtachFile_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatVaDongAttachFile" runat="server" Icon="Disk" Text="Cập nhật & Đóng lại">
                    <Listeners>
                        <Click Handler="return ValidInputAttachFile();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateAtachFile_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button13" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAttachFile.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetAttachFile();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:FormPanel runat="server" Border="false" AnchorHorizontal="100%" Title="Thông tin"
                            Header="false" AutoScroll="true">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button ID="btnUpdateInformation" runat="server" Text="Cập nhật" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="return ValidateInput();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnUpdateInformation_Click">
                                                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:Hidden runat="server" ID="hdfCommandType" Text="Edit" />
                                <ext:Hidden ID="hdf_PR_KEY" runat="server" Text="" />
                                <ext:TabPanel ID="tpnl_Hosonhansu" Cls="bkGround" Padding="6" runat="server" AnchorHorizontal="100%"
                                    Border="false" DeferredRender="false">
                                    <Items>
                                        <ext:Panel ID="pnl_HoSoNhanSu" Title="Hồ sơ nhân sự" runat="server" AutoHeight="true"
                                            AnchorHorizontal="100%" Border="false" TabIndex="0" Layout="FormLayout">
                                            <Items>
                                                <ext:Container runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                                                    <Items>
                                                        <ext:FieldSet ID="fs_hosonhansu" runat="server" Title="Thông tin cá nhân" Layout="ColumnLayout"
                                                            Height="180" AnchorHorizontal="100%">
                                                            <Items>
                                                                <ext:Container ID="Container2" runat="server" Height="180" ColumnWidth=".14">
                                                                    <Items>
                                                                        <ext:ImageButton ID="img_anhdaidien" OverImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg"
                                                                            ImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg" runat="server" Width="120"
                                                                            Height="150" TabIndex="0">
                                                                            <Listeners>
                                                                                <Click Handler="#{wdUploadImageWindow}.show();" />
                                                                            </Listeners>
                                                                        </ext:ImageButton>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container runat="server" Height="180" ID="ctan1" ColumnWidth=".29" Layout="FormLayout">
                                                                    <Items>
                                                                        <ext:TextField ID="txt_sohieucbccvc" runat="server" FieldLabel="Số hiệu CBCCVC" AllowBlank="true"
                                                                            TabIndex="2" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự"
                                                                            AnchorHorizontal="98%">
                                                                        </ext:TextField>
                                                                        <ext:TextField ID="txt_hoten" CtCls="requiredData" runat="server" FieldLabel="Tên cán bộ<span style='color:red;'>*</span>"
                                                                            AllowBlank="false" TabIndex="3" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                            <Listeners>
                                                                                <Blur Handler="ChuanHoaTen(txt_hoten);" />
                                                                            </Listeners>
                                                                            <ToolTips>
                                                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="Hướng dẫn" Html="Phần mềm sẽ tự động chuẩn hóa họ và tên của bạn. Ví dụ: bạn nhập nguyễn văn huy, kết quả trả về Nguyễn Văn Huy." />
                                                                            </ToolTips>
                                                                        </ext:TextField>
                                                                        <ext:TextField ID="txt_bidanh" FieldLabel="Bí danh" runat="server" AllowBlank="true"
                                                                            TabIndex="4" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                        </ext:TextField>
                                                                        <ext:DateField runat="server" CtCls="requiredData" ID="dfNgaySinh" FieldLabel="Ngày sinh<span style='color:red;'>*</span>"
                                                                            AnchorHorizontal="98%" TabIndex="7" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                            RegexText="Định dạng ngày sinh không đúng">
                                                                        </ext:DateField>
                                                                        <ext:ComboBox ID="cbx_gioitinh" FieldLabel="Giới tính" Editable="false" runat="server"
                                                                            AnchorHorizontal="98%" TabIndex="8" SelectedIndex="0" AllowBlank="false">
                                                                            <Items>
                                                                                <ext:ListItem Text="Nam" Value="M" />
                                                                                <ext:ListItem Text="Nữ" Value="F" />
                                                                            </Items>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container ID="Container23" runat="server" Height="180" AnchorHorizontal="99%"
                                                                    ColumnWidth=".29" Layout="FormLayout">
                                                                    <Items>
                                                                        <ext:TextField ID="txt_quequan" runat="server" FieldLabel="Quê quán" AnchorHorizontal="98%"
                                                                            TabIndex="10" MaxLength="1000">
                                                                        </ext:TextField>
                                                                        <ext:TextField ID="txt_noisinh" runat="server" FieldLabel="Nơi sinh" AllowBlank="true"
                                                                            TabIndex="11" AnchorHorizontal="98%" MaxLength="1000">
                                                                        </ext:TextField>
                                                                        <ext:Hidden runat="server" ID="hdfQuocTich" />
                                                                        <ext:ComboBox runat="server" ID="cbx_quoctich" FieldLabel="Quốc tịch<span style='color:red;'>*</span>"
                                                                            CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%"
                                                                            ListWidth="200" TabIndex="12" Editable="true" ItemSelector="div.list-item" LoadingText="<%$ Resources:HOSO, Loading%>"
                                                                            EmptyText="Gõ để tìm kiếm">
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
                                                                            <Store>
                                                                                <ext:Store ID="cbx_quoctich_Store" runat="server" AutoLoad="false">
                                                                                    <Proxy>
                                                                                        <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                    </Proxy>
                                                                                    <BaseParams>
                                                                                        <ext:Parameter Name="table" Value="DM_NUOC" Mode="Value" />
                                                                                        <ext:Parameter Name="ma" Value="MA_NUOC" Mode="Value" />
                                                                                        <ext:Parameter Name="ten" Value="TEN_NUOC" Mode="Value" />
                                                                                    </BaseParams>
                                                                                    <Reader>
                                                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_quoctich_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();hdfQuocTich.setValue(cbx_quoctich.getValue());#{cbx_tinhthanh_Store}.reload();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:Hidden runat="server" ID="hdfTinhThanh" />
                                                                        <ext:ComboBox runat="server" ID="cbx_tinhthanh" FieldLabel="Tỉnh thành" DisplayField="TEN"
                                                                            MinChars="1" EmptyText="Gõ để tìm kiếm" ValueField="MA" AnchorHorizontal="98%"
                                                                            TabIndex="13" Editable="true" ItemSelector="div.list-item">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_tinhthanh_Store" AutoLoad="false">
                                                                                    <Proxy>
                                                                                        <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                    </Proxy>
                                                                                    <BaseParams>
                                                                                        <ext:Parameter Name="table" Value="DM_TINHTHANH" Mode="Value" />
                                                                                        <ext:Parameter Name="ma" Value="MA_TINHTHANH" Mode="Value" />
                                                                                        <ext:Parameter Name="ten" Value="TEN_TINHTHANH" Mode="Value" />
                                                                                    </BaseParams>
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA" Root="plants" TotalProperty="total">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="if (#{cbx_quoctich}.getValue() == '') {alert('Bạn phải chọn quốc tịch trước');} else {#{cbx_tinhthanh_Store}.reload();}" />
                                                                                <Select Handler="this.triggers[0].show();hdfTinhThanh.setValue(cbx_tinhthanh.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:Hidden runat="server" ID="hdfDanToc" />
                                                                        <ext:ComboBox runat="server" ID="cbx_dantoc" FieldLabel="Dân tộc<span style='color:red;'>*</span>"
                                                                            CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%"
                                                                            EmptyText="Gõ để tìm kiếm" TabIndex="14" ItemSelector="div.list-item">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_dantoc_Store" AutoLoad="false">
                                                                                    <Proxy>
                                                                                        <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                    </Proxy>
                                                                                    <BaseParams>
                                                                                        <ext:Parameter Name="table" Value="DM_DANTOC" Mode="Value" />
                                                                                        <ext:Parameter Name="ma" Value="MA_DANTOC" Mode="Value" />
                                                                                        <ext:Parameter Name="ten" Value="TEN_DANTOC" Mode="Value" />
                                                                                    </BaseParams>
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA" Root="plants" TotalProperty="total">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_dantoc_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();hdfDanToc.setValue(cbx_dantoc.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container ID="Container47" runat="server" Height="180" AnchorHorizontal="99%"
                                                                    ColumnWidth=".28" Layout="FormLayout">
                                                                    <Items>
                                                                        <ext:ComboBox runat="server" ID="cbx_tongiao" FieldLabel="Tôn giáo" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="15" Editable="false" ItemSelector="div.list-item">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_tongiao_Store" AutoLoad="false" OnRefreshData="cbx_tongiao_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_tongiao_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:ComboBox runat="server" ID="cbx_tthonnhan" CtCls="requiredData" FieldLabel="TT Hôn nhân<span style='color:red;'>*</span>"
                                                                            DisplayField="TEN" ValueField="MA" EmptyText="Tình trạng hôn nhân" AnchorHorizontal="100%"
                                                                            TabIndex="16" ItemSelector="div.list-item" Editable="false" AllowBlank="false">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_tthonnhan_Store" AutoLoad="false" OnRefreshData="cbx_tthonnhan_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_tthonnhan_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:ComboBox runat="server" ID="cbx_tpbanthan" FieldLabel="TP bản thân" EmptyText="Thành phần bản thân"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="17" ItemSelector="div.list-item"
                                                                            Editable="false">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_tpbanthan_Store" AutoLoad="false" OnRefreshData="cbx_tpbanthan_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_tpbanthan_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:ComboBox runat="server" ID="cbx_tpgiadinh" EmptyText="Thành phần gia đình" FieldLabel="TP gia đình"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="18" ItemSelector="div.list-item"
                                                                            Editable="false">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_tpgiadinh_Store" AutoLoad="false" OnRefreshData="cbx_tpgiadinh_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_tpgiadinh_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:FieldSet>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="contan1" runat="server" Height="155" AnchorHorizontal="100%" Layout="ColumnLayout">
                                                    <Items>
                                                        <ext:FieldSet ID="fs2" runat="server" Title="Thông tin liên hệ" Layout="FormLayout"
                                                            ColumnWidth=".5">
                                                            <Items>
                                                                <ext:TextField ID="txt_hokhau" runat="server" EmptyText="Hộ khẩu thường trú" FieldLabel="Hộ khẩu TT"
                                                                    Width="260" AllowBlank="true" TabIndex="19" AnchorHorizontal="100%">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_diachilienhe" runat="server" FieldLabel="Chỗ ở hiện nay" TabIndex="20"
                                                                    AnchorHorizontal="100%">
                                                                </ext:TextField>
                                                                <ext:Container runat="server" Height="80" ID="ctn103" Layout="ColumnLayout">
                                                                    <Items>
                                                                        <ext:Container runat="server" Layout="FormLayout" ID="ctn104" ColumnWidth=".5">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_didong" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Di động"
                                                                                    AllowBlank="true" TabIndex="21" AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                                                </ext:TextField>
                                                                                <ext:TextField ID="txt_dtcoquan" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Điện thoại CQ"
                                                                                    TabIndex="20" AnchorHorizontal="98%" MaxLength="22" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                                                </ext:TextField>
                                                                                <ext:TextField ID="txt_dtnha" FieldLabel="Điện thoại nhà" MaskRe="/[0-9\.]/" runat="server"
                                                                                    AllowBlank="true" TabIndex="23" AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Container>
                                                                        <ext:Container runat="server" Layout="FormLayout" ID="ctn105" ColumnWidth=".5">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_email" runat="server" FieldLabel="Email" AllowBlank="true"
                                                                                    TabIndex="24" AnchorHorizontal="100%" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                                                    RegexText="Định dạng email không đúng" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                                <ext:TextField ID="txt_emailkhac" runat="server" FieldLabel="Email khác" AllowBlank="true"
                                                                                    TabIndex="25" AnchorHorizontal="100%" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                                                    RegexText="Định dạng email không đúng" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:FieldSet>
                                                        <ext:FieldSet ID="fs1" runat="server" Title="Trình độ" Layout="FormLayout" ColumnWidth=".5">
                                                            <Items>
                                                                <ext:Hidden runat="server" ID="hdfMaTruongDaoTao" />
                                                                <ext:ComboBox AnchorHorizontal="100%" ValueField="MA" HideTrigger="false" DisplayField="TEN"
                                                                    runat="server" FieldLabel="Trường đào tạo" ItemSelector="div.search-item"
                                                                    MinChars="1" EmptyText="gõ để tìm kiếm" ID="cbxTruongDaoTao" LoadingText="Đang tải dữ liệu..."
                                                                    TabIndex="26">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Store>
                                                                        <ext:Store ID="Store3" runat="server" AutoLoad="false">
                                                                            <Proxy>
                                                                                <ext:HttpProxy Method="POST" Url="~/Modules/HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                            </Proxy>
                                                                            <BaseParams>
                                                                                <ext:Parameter Name="table" Value="DM_TRUONG_DAOTAO" Mode="Value" />
                                                                                <ext:Parameter Name="ma" Value="MA_TRUONG_DAOTAO" Mode="Value" />
                                                                                <ext:Parameter Name="ten" Value="TEN_TRUONG_DAOTAO" Mode="Value" />
                                                                            </BaseParams>
                                                                            <Reader>
                                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="MA" />
                                                                                        <ext:RecordField Name="TEN" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <Template ID="Template11" runat="server">
                                                                        <Html>
                                                                            <tpl for=".">
						                                                        <div class="search-item">
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                                                        </Html>
                                                                    </Template>
                                                                    <ToolTips>
                                                                        <ext:ToolTip runat="server" ID="ttTruongDT" Title="Hướng dẫn" Html="Nhập tên trường đào tạo để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                    </ToolTips>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show(); hdfMaTruongDaoTao.setValue(cbxTruongDaoTao.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfMaTruongDaoTao.reset(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="hdfMaChuyenNganh" />
                                                                <ext:ComboBox AnchorHorizontal="100%" ValueField="MA" DisplayField="TEN" runat="server"
                                                                    FieldLabel="Chuyên ngành" HideTrigger="false" ItemSelector="div.search-item"
                                                                    MinChars="1" EmptyText="gõ để tìm kiếm" ID="cbxChuyenNganh" LoadingText="Đang tải dữ liệu..."
                                                                    TabIndex="27">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Store>
                                                                        <ext:Store ID="Store1" runat="server" AutoLoad="false">
                                                                            <Proxy>
                                                                                <ext:HttpProxy Method="POST" Url="~/Modules/HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                            </Proxy>
                                                                            <BaseParams>
                                                                                <ext:Parameter Name="table" Value="DM_CHUYENNGANH" Mode="Value" />
                                                                                <ext:Parameter Name="ma" Value="MA_CHUYENNGANH" Mode="Value" />
                                                                                <ext:Parameter Name="ten" Value="TEN_CHUYENNGANH" Mode="Value" />
                                                                            </BaseParams>
                                                                            <Reader>
                                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="MA" />
                                                                                        <ext:RecordField Name="TEN" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <Template ID="Template12" runat="server">
                                                                        <Html>
                                                                            <tpl for=".">
						                                                        <div class="search-item">
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                                                        </Html>
                                                                    </Template>
                                                                    <ToolTips>
                                                                        <ext:ToolTip runat="server" ID="ToolTip3" Title="Hướng dẫn" Html="Nhập tên chuyên ngành để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                    </ToolTips>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show(); hdfMaChuyenNganh.setValue(cbxChuyenNganh.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfMaChuyenNganh.reset(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Container runat="server" ID="ctn100" Layout="ColumnLayout" AnchorHorizontal="100%"
                                                                    Height="150">
                                                                    <Items>
                                                                        <ext:Container runat="server" Height="150" ID="ctn101" ColumnWidth=".5" Layout="FormLayout">
                                                                            <Items>
                                                                                <ext:ComboBox runat="server" ID="cbx_xeploai" FieldLabel="Xếp loại" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="28" Editable="false" ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template13" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_xeploai_Store" AutoLoad="false" OnRefreshData="cbx_xeploai_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_xeploai_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <ext:ComboBox runat="server" ID="cbx_tinhoc" FieldLabel="Tin học" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="29" Editable="false" ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template14" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_tinhoc_Store" AutoLoad="false" OnRefreshData="cbx_tinhoc_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_tinhoc_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <ext:ComboBox runat="server" ID="cbx_ngoaingu" FieldLabel="Ngoại ngữ" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="30" Editable="false" ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template15" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_ngoaingu_Store" AutoLoad="false" OnRefreshData="cbx_ngoaingu_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_ngoaingu_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                            </Items>
                                                                        </ext:Container>
                                                                        <ext:Container runat="server" Height="150" ID="ctn102" ColumnWidth=".5" Layout="FormLayout">
                                                                            <Items>
                                                                                <ext:NumberField ID="tf_namtotnghiep" runat="server" FieldLabel="Năm tốt nghiệp"
                                                                                    AllowBlank="true" TabIndex="31" AnchorHorizontal="100%" MaxLength="4" MinLength="4">
                                                                                </ext:NumberField>
                                                                                <ext:ComboBox runat="server" ID="cbx_trinhdo" FieldLabel="Trình độ" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="100%" TabIndex="32" Editable="false" ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template16" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_trinhdo_Store" AutoLoad="false" OnRefreshData="cbx_trinhdo_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_trinhdo_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <ext:ComboBox runat="server" ID="cbx_tdvanhoa" FieldLabel="TĐ văn hóa" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="100%" TabIndex="33" Editable="false" ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template17" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_tdvanhoa_Store" AutoLoad="false" OnRefreshData="cbx_tdvanhoa_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_tdvanhoa_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:FieldSet>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                                                    <Items>
                                                        <ext:FieldSet ID="FieldSet1" runat="server" Title="Thông tin công việc" Layout="ColumnLayout"
                                                            Height="95">
                                                            <Items>
                                                                <ext:Container runat="server" Height="50" ID="Container11" Layout="FormLayout" ColumnWidth=".5">
                                                                    <Items>
                                                                        <ext:ComboBox runat="server" ID="cbx_bophan" CtCls="requiredData" FieldLabel="Bộ phận<span style='color:red;'>*</span>"
                                                                            DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
                                                                            AnchorHorizontal="98%" TabIndex="33" Editable="false" AllowBlank="false">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Template ID="Template37" runat="server">
                                                                                <Html>
                                                                                    <tpl for=".">
						                                              <div class="list-item"> 
							                                             {TEN}
						                                              </div>
					                                               </tpl>
                                                                                </Html>
                                                                            </Template>
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_bophan_Store" AutoLoad="false" OnRefreshData="cbx_bophan_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_bophan_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:Container runat="server" AutoHeight="true" ID="Container41" Layout="ColumnLayout"
                                                                            ColumnWidth=".5" AnchorHorizontal="98%">
                                                                            <Items>
                                                                                <ext:Container ID="Container42" runat="server" ColumnWidth="0.5" Height="180" Layout="FormLayout">
                                                                                    <Items>
                                                                                        <ext:DateField Editable="true" ID="date_tuyendau" Vtype="daterange" FieldLabel="Ngày thử việc"
                                                                                            runat="server" AnchorHorizontal="98%" TabIndex="34" MaskRe="/[0-9|/]/" Format="d/M/yyyy">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Listeners>
                                                                                                <Blur Handler="ChuanHoaDateField(#{date_tuyendau});" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ngaynhanct}.setMinValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:DateField>
                                                                                    </Items>
                                                                                </ext:Container>
                                                                                <ext:Container ID="Container48" runat="server" ColumnWidth="0.5" Height="180" Layout="FormLayout">
                                                                                    <Items>
                                                                                        <ext:DateField Editable="true" ID="date_ngaynhanct" Vtype="daterange" FieldLabel="Ngày chính thức"
                                                                                            runat="server" AnchorHorizontal="100%" TabIndex="35" Format="d/M/yyyy">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Listeners>
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_tuyendau}.setMaxValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:DateField>
                                                                                    </Items>
                                                                                </ext:Container>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container ID="Container49" runat="server" Layout="FormLayout" ColumnWidth=".5">
                                                                    <Items>
                                                                        <ext:Container ID="Container50" runat="server" Layout="ColumnLayout" Height="55">
                                                                            <Items>
                                                                                <ext:Container ID="Container51" runat="server" AnchorHorizontal="99%" ColumnWidth=".52"
                                                                                    Layout="FormLayout" LabelWidth="124">
                                                                                    <Items>
                                                                                        <ext:Hidden runat="server" ID="hdfChucVu" />
                                                                                        <ext:ComboBox runat="server" ID="cbx_chucvu" FieldLabel="Chức vụ" DisplayField="TEN"
                                                                                            MinChars="1" ValueField="MA" AnchorHorizontal="98%" TabIndex="37" Editable="true"
                                                                                            ItemSelector="div.list-item" EmptyText="Gõ để tìm kiếm" ListWidth="150" LoadingText="Đang tải dữ liệu">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template20" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store ID="cbx_chucvu_Store" runat="server" AutoLoad="false">
                                                                                                    <Proxy>
                                                                                                        <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                                    </Proxy>
                                                                                                    <BaseParams>
                                                                                                        <ext:Parameter Name="table" Value="DM_CHUCVU" Mode="Value" />
                                                                                                        <ext:Parameter Name="ma" Value="MA_CHUCVU" Mode="Value" />
                                                                                                        <ext:Parameter Name="ten" Value="TEN_CHUCVU" Mode="Value" />
                                                                                                    </BaseParams>
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <ToolTips>
                                                                                                <ext:ToolTip runat="server" ID="ToolTip7" Title="Hướng dẫn" Html="Nhập tên chức vụ để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                                            </ToolTips>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_chucvu_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show(); hdfChucVu.setValue(cbx_chucvu.getValue());" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChucVu.reset(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:ComboBox runat="server" ID="cbxHinhThucLamViec" FieldLabel="Hình thức làm việc<span style='color:red;'>*</span>"
                                                                                            CtCls="requiredData" DisplayField="Value" ValueField="ID" LoadingText="Đang tải dữ liệu..."
                                                                                            ItemSelector="div.list-item" AnchorHorizontal="98%" TabIndex="33" Editable="false"
                                                                                            AllowBlank="false">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template46" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {Value}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbxHinhThucLamViec_Store" AutoLoad="false" OnRefreshData="cbxHinhThucLamViec_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="ID">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="ID" />
                                                                                                                <ext:RecordField Name="Value" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbxHinhThucLamViec_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                    </Items>
                                                                                </ext:Container>
                                                                                <ext:Container ID="Container52" runat="server" ColumnWidth=".48" Layout="FormLayout">
                                                                                    <Items>
                                                                                        <ext:Hidden runat="server" ID="hdfViTriCongViec" />
                                                                                        <ext:ComboBox runat="server" Hidden="false" ID="cbx_congviec" FieldLabel="Chức danh"
                                                                                            DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
                                                                                            AnchorHorizontal="100%" TabIndex="38" Editable="true" ListWidth="150" AllowBlank="true"
                                                                                            MinChars="1" EmptyText="Gõ để tìm kiếm">
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
                                                                                            <Store>
                                                                                                <ext:Store ID="cbx_congviec_Store" runat="server" AutoLoad="false">
                                                                                                    <Proxy>
                                                                                                        <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                                    </Proxy>
                                                                                                    <BaseParams>
                                                                                                        <ext:Parameter Name="table" Value="DM_CONGVIEC" Mode="Value" />
                                                                                                        <ext:Parameter Name="ma" Value="MA_CONGVIEC" Mode="Value" />
                                                                                                        <ext:Parameter Name="ten" Value="TEN_CONGVIEC" Mode="Value" />
                                                                                                    </BaseParams>
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <ToolTips>
                                                                                                <ext:ToolTip runat="server" ID="ToolTip6" Title="Hướng dẫn" Html="Nhập tên chức danh để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                                            </ToolTips>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_congviec_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show(); hdfViTriCongViec.setValue(cbx_congviec.getValue());" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfViTriCongViec.reset(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:TextField runat="server" EmptyText="Kinh nghiệm trước khi vào công ty" ID="cbx_congtrinh"
                                                                                            FieldLabel="Kinh nghiệm" AnchorHorizontal="100%" TabIndex="39">
                                                                                            <ToolTips>
                                                                                                <ext:ToolTip ID="ToolTip4" runat="server" Title="Hướng dẫn" Html="Số năm kinh nghiệm trước khi vào công ty">
                                                                                                </ext:ToolTip>
                                                                                            </ToolTips>
                                                                                        </ext:TextField>
                                                                                    </Items>
                                                                                </ext:Container>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:FieldSet>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel ID="pnl_ThongTinThem" Title="Bảo hiểm, CMT, chính trị" runat="server"
                                            AutoHeight="true" AnchorHorizontal="100%" Border="false" TabIndex="1" Layout="FormLayout">
                                            <Items>
                                                <ext:Container ID="Container12" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%"
                                                    AutoHeight="true">
                                                    <Items>
                                                        <ext:Container ID="Container13" runat="server" ColumnWidth="0.65" Layout="FormLayout"
                                                            AutoHeight="true" Height="410">
                                                            <Items>
                                                                <ext:FieldSet runat="server" Layout="ColumnLayout" Title="Thông tin bảo hiểm" AutoHeight="true"
                                                                    AnchorHorizontal="99%">
                                                                    <Items>
                                                                        <ext:Container ID="Container14" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                                            Height="130">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_sothebhyt" CtCls="requiredData" runat="server" FieldLabel="Số thẻ BHYT"
                                                                                    AllowBlank="true" TabIndex="40" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                                <%--<ext:CompositeField ID="CompositeField4" runat="server" FieldLabel="Ngày đóng BHYT"
                                                                                    AnchorHorizontal="99%">
                                                                                    <Items>
                                                                                        <ext:NumberField Width="36" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                                            runat="server" ID="nbfNgayDongBHYT" TabIndex="41">
                                                                                        </ext:NumberField>
                                                                                        <ext:DisplayField ID="DisplayField5" Text="-" runat="server" />
                                                                                        <ext:NumberField Width="43" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                                            runat="server" ID="nbfThangDongBHYT" TabIndex="42">
                                                                                        </ext:NumberField>
                                                                                        <ext:DisplayField ID="DisplayField6" Text="-" runat="server" />
                                                                                        <ext:NumberField Width="36" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                                            ID="nbfNamDongBHYT" TabIndex="43">
                                                                                        </ext:NumberField>
                                                                                    </Items>
                                                                                </ext:CompositeField>--%>
                                                                                <ext:DateField runat="server" CtCls="requiredData" ID="dfNgayDongBHYT" FieldLabel="Ngày đóng BHYT"
                                                                                    AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" RegexText="Định dạng ngày không đúng">
                                                                                    <Listeners>
                                                                                        <KeyUp Fn="onKeyUp" />
                                                                                    </Listeners>
                                                                                </ext:DateField>
                                                                                <%--<ext:CompositeField ID="CompositeField5" runat="server" FieldLabel="Hết hạn BHYT"
                                                                                    AnchorHorizontal="98%">
                                                                                    <Items>
                                                                                        <ext:NumberField Width="36" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                                            runat="server" ID="nbfNgayHetHanBHYT" TabIndex="44">
                                                                                        </ext:NumberField>
                                                                                        <ext:DisplayField ID="DisplayField7" Text="-" runat="server" />
                                                                                        <ext:NumberField Width="43" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                                            runat="server" ID="nbfThangHetHanBHYT" TabIndex="45">
                                                                                        </ext:NumberField>
                                                                                        <ext:DisplayField ID="DisplayField8" Text="-" runat="server" />
                                                                                        <ext:NumberField Width="36" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                                            ID="nbfNamHetHanBHYT" TabIndex="46">
                                                                                        </ext:NumberField>
                                                                                    </Items>
                                                                                </ext:CompositeField>--%>
                                                                                <ext:DateField runat="server" CtCls="requiredData" ID="dfNgayHetHanBHYT" FieldLabel="Hết hạn BHYT"
                                                                                    AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                                    RegexText="Định dạng ngày không đúng">
                                                                                </ext:DateField>
                                                                                <ext:ComboBox runat="server" ID="cbx_noikcb" CtCls="requiredData" FieldLabel="Nơi khám bệnh"
                                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="98%" TabIndex="47" Editable="true"
                                                                                    ListWidth="200" MinChars="1" ItemSelector="div.list-item" EmptyText="Gõ tên để tìm kiếm"
                                                                                    LoadingText="Đang tải dữ liệu...">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template23" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store ID="cbx_noikcb_Store" runat="server" AutoLoad="false">
                                                                                            <Proxy>
                                                                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                            </Proxy>
                                                                                            <BaseParams>
                                                                                                <ext:Parameter Name="table" Value="DM_NOI_KCB" Mode="Value" />
                                                                                                <ext:Parameter Name="ma" Value="MA_NOI_KCB" Mode="Value" />
                                                                                                <ext:Parameter Name="ten" Value="TEN_NOI_KCB" Mode="Value" />
                                                                                            </BaseParams>
                                                                                            <Reader>
                                                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <ToolTips>
                                                                                        <ext:ToolTip runat="server" ID="ToolTip8" Title="Hướng dẫn" Html="Nhập tên nơi khám chữa bệnh để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                                    </ToolTips>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_noikcb_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <ext:TextField ID="txt_tiledongbh" CtCls="requiredData" runat="server" FieldLabel="Tỷ lệ đóng BH"
                                                                                    AllowBlank="true" TabIndex="48" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Container>
                                                                        <ext:Container ID="Container15" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                                            Height="130">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_sothebhxh" CtCls="requiredData" runat="server" FieldLabel="Số thẻ BHXH"
                                                                                    AllowBlank="true" TabIndex="49" AnchorHorizontal="100%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                                <ext:ComboBox runat="server" ID="cbx_noicapbhxh" CtCls="requiredData" FieldLabel="Nơi cấp BHXH"
                                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="50" Editable="false"
                                                                                    ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template22" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_noicapbhxh_Store" AutoLoad="false" OnRefreshData="cbx_noicapbhxh_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_noicapbhxh_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <%--<ext:CompositeField ID="CompositeField6" runat="server" FieldLabel="Ngày cấp BHXH"
                                                                                    AnchorHorizontal="100%">
                                                                                    <Items>
                                                                                        <ext:NumberField Width="36" MaxLength="2" MinValue="1" MaxValue="31" EmptyText="Ngày"
                                                                                            runat="server" ID="nbfNgayCapBHXH" TabIndex="51">
                                                                                        </ext:NumberField>
                                                                                        <ext:DisplayField ID="DisplayField9" Text="-" runat="server" />
                                                                                        <ext:NumberField Width="43" EmptyText="Tháng" MaxLength="2" MinValue="1" MaxValue="12"
                                                                                            runat="server" ID="nbfThangCapBHXH" TabIndex="52">
                                                                                        </ext:NumberField>
                                                                                        <ext:DisplayField ID="DisplayField10" Text="-" runat="server" />
                                                                                        <ext:NumberField Width="36" EmptyText="Năm" MinLength="4" MaxLength="4" runat="server"
                                                                                            ID="nbfNamCapBHXH" TabIndex="53">
                                                                                        </ext:NumberField>
                                                                                    </Items>
                                                                                </ext:CompositeField>--%>
                                                                                <ext:DateField runat="server" ID="dfNgayCapBHXH" CtCls="requiredData" FieldLabel="Ngày cấp BHXH"
                                                                                    AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                                    RegexText="Định dạng ngày không đúng">
                                                                                </ext:DateField>
                                                                                <ext:ComboBox runat="server" ID="cbx_huongcs" FieldLabel="Dạng chính sách" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="100%" TabIndex="54" Editable="false" ListWidth="200"
                                                                                    ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template24" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_huongcs_Store" AutoLoad="false" OnRefreshData="cbx_huongcs_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_huongcs_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <ext:DateField Editable="false" ID="date_ketthucbh" CtCls="requiredData" FieldLabel="Kết thúc BH"
                                                                                    runat="server" AnchorHorizontal="100%" TabIndex="55">
                                                                                </ext:DateField>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:FieldSet>
                                                                <ext:FieldSet ID="FieldSet2" runat="server" Layout="ColumnLayout" Title="Chứng minh nhân dân - Hộ chiếu"
                                                                    AutoHeight="true" AnchorHorizontal="99%">
                                                                    <Items>
                                                                        <ext:Container ID="Container20" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                                            Height="100">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_socmnd" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Số CMND"
                                                                                    CtCls="requiredData" AllowBlank="true" TabIndex="56" AnchorHorizontal="98%" MaxLength="12"
                                                                                    MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                                <ext:DateField Editable="false" ID="date_capcmnd" CtCls="requiredData" FieldLabel="Ngày cấp CMND"
                                                                                    runat="server" AnchorHorizontal="98%" TabIndex="57">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Listeners>
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:DateField>
                                                                                <ext:ComboBox runat="server" ID="cbx_noicapcmnd" CtCls="requiredDataWG" FieldLabel="Nơi cấp CMND"
                                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="98%" TabIndex="58" Editable="true"
                                                                                    ListWidth="200" MinChars="1" ItemSelector="div.list-item" LoadingText="Đang tải dữ liệu..."
                                                                                    EmptyText="Gõ để tìm kiếm">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template25" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store ID="cbx_noicapcmnd_Store" runat="server" AutoLoad="false">
                                                                                            <Proxy>
                                                                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                                            </Proxy>
                                                                                            <BaseParams>
                                                                                                <ext:Parameter Name="table" Value="DM_NOICAP_CMND" Mode="Value" />
                                                                                                <ext:Parameter Name="ma" Value="MA_NOICAP_CMND" Mode="Value" />
                                                                                                <ext:Parameter Name="ten" Value="TEN_NOICAP_CMND" Mode="Value" />
                                                                                            </BaseParams>
                                                                                            <Reader>
                                                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <ToolTips>
                                                                                        <ext:ToolTip runat="server" ID="ToolTip5" Title="Hướng dẫn" Html="Nhập tên nơi cấp CMND để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                                    </ToolTips>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_noicapcmnd_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                            </Items>
                                                                        </ext:Container>
                                                                        <ext:Container ID="Container21" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                                            Height="100">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_sohochieu" runat="server" FieldLabel="Số hộ chiếu" AllowBlank="true"
                                                                                    TabIndex="59" AnchorHorizontal="100%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                                <ext:DateField Editable="false" ID="date_ngaycaphc" FieldLabel="Ngày cấp HC" runat="server"
                                                                                    AnchorHorizontal="100%" TabIndex="60">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Listeners>
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                        <KeyUp Fn="onKeyUp" />
                                                                                    </Listeners>
                                                                                </ext:DateField>
                                                                                <ext:DateField Editable="false" ID="date_hethanhc" FieldLabel="Hết hạn HC" runat="server"
                                                                                    AnchorHorizontal="100%" TabIndex="61">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Listeners>
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:DateField>
                                                                                <ext:ComboBox runat="server" ID="cbx_noicaphc" FieldLabel="Nơi cấp HC" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="100%" TabIndex="62" Editable="false" ItemSelector="div.list-item"
                                                                                    ListWidth="150">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template31" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_noicaphc_Store" AutoLoad="false" OnRefreshData="cbx_noicaphc_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_noicaphc_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:FieldSet>
                                                                <ext:FieldSet ID="FieldSet3" runat="server" Layout="ColumnLayout" Title="Thông tin đoàn thể"
                                                                    AutoHeight="true" AnchorHorizontal="99%">
                                                                    <Items>
                                                                        <ext:Container ID="Container22" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                                            Height="75">
                                                                            <Items>
                                                                                <ext:DateField Editable="false" ID="date_ngayvaodoan" FieldLabel="Ngày vào Đoàn"
                                                                                    runat="server" AnchorHorizontal="98%" TabIndex="63">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Listeners>
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                        <KeyUp Fn="onKeyUp" />
                                                                                    </Listeners>
                                                                                </ext:DateField>
                                                                                <ext:ComboBox runat="server" ID="cbx_chucvudoan" FieldLabel="Chức vụ Đoàn" DisplayField="TEN"
                                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="64" Editable="false" ListWidth="200"
                                                                                    ItemSelector="div.list-item">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Template ID="Template30" runat="server">
                                                                                        <Html>
                                                                                            <tpl for=".">
						                                                                        <div class="list-item"> 
							                                                                        {TEN}
						                                                                        </div>
					                                                                        </tpl>
                                                                                        </Html>
                                                                                    </Template>
                                                                                    <Store>
                                                                                        <ext:Store runat="server" ID="cbx_chucvudoan_Store" AutoLoad="false" OnRefreshData="cbx_chucvudoan_Store_OnRefreshData">
                                                                                            <Reader>
                                                                                                <ext:JsonReader IDProperty="MA">
                                                                                                    <Fields>
                                                                                                        <ext:RecordField Name="MA" />
                                                                                                        <ext:RecordField Name="TEN" />
                                                                                                    </Fields>
                                                                                                </ext:JsonReader>
                                                                                            </Reader>
                                                                                        </ext:Store>
                                                                                    </Store>
                                                                                    <Listeners>
                                                                                        <Expand Handler="cbx_chucvudoan_Store.reload();" />
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                    </Listeners>
                                                                                </ext:ComboBox>
                                                                                <ext:TextField ID="txt_noiketnapdoan" runat="server" FieldLabel="Nơi kết nạp Đoàn"
                                                                                    AnchorHorizontal="98%" AllowBlank="true" TabIndex="65" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Container>
                                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="75">
                                                                            <Items>
                                                                                <ext:DateField Editable="false" ID="date_vaocongdoan" FieldLabel="Ngày vào công đoàn"
                                                                                    runat="server" AnchorHorizontal="100%" TabIndex="66">
                                                                                    <Triggers>
                                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                    </Triggers>
                                                                                    <Listeners>
                                                                                        <Select Handler="this.triggers[0].show();" />
                                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                        <KeyUp Fn="onKeyUp" />
                                                                                    </Listeners>
                                                                                </ext:DateField>
                                                                                <ext:TextField runat="server" ID="txt_chucvucongdoan" FieldLabel="Chức vụ công đoàn"
                                                                                    AnchorHorizontal="100%" MaxLength="100" TabIndex="67">
                                                                                </ext:TextField>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:FieldSet>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:FieldSet ID="fsThongTinCtri" runat="server" ColumnWidth="0.33" Layout="FormLayout"
                                                            Title="Thông tin chính trị" LabelWidth="130" Height="405">
                                                            <Items>
                                                                <ext:Container ID="Container24" runat="server" Layout="FormLayout" AnchorHorizontal="100%"
                                                                    Height="210" LabelWidth="125">
                                                                    <Items>
                                                                        <ext:ComboBox runat="server" ID="cbx_trinhdochinhtri" FieldLabel="Trình độ chính trị"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="68" Editable="false"
                                                                            ListWidth="200" ItemSelector="div.list-item">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Template ID="Template26" runat="server">
                                                                                <Html>
                                                                                    <tpl for=".">
						                                                                <div class="list-item"> 
							                                                                {TEN}
						                                                                </div>
					                                                                </tpl>
                                                                                </Html>
                                                                            </Template>
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_trinhdochinhtri_Store" AutoLoad="false" OnRefreshData="cbx_trinhdochinhtri_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_trinhdochinhtri_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:DateField Editable="false" ID="date_thamgiacm" FieldLabel="Tham gia CM" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="69">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:Checkbox runat="server" ID="chkLaDangVien" BoxLabel="Là Đảng viên" Checked="false"
                                                                            TabIndex="70">
                                                                            <Listeners>
                                                                                <Check Handler="if (#{chkLaDangVien}.checked == true) {
                                                                                        #{date_vaodang}.enable(); #{date_ngayvaodangct}.enable();
                                                                                        #{txt_noiketnapdang}.enable(); #{cbx_chuvudang}.enable();
                                                                                        #{txt_noisinhhoatdang}.enable();
                                                                                    } else {
                                                                                        #{date_vaodang}.disable(); #{date_ngayvaodangct}.disable();
                                                                                        #{txt_noiketnapdang}.disable(); #{cbx_chuvudang}.disable();
                                                                                        #{txt_noisinhhoatdang}.disable();
                                                                                    }" />
                                                                            </Listeners>
                                                                        </ext:Checkbox>
                                                                        <ext:DateField Editable="false" ID="date_vaodang" FieldLabel="Ngày vào đảng" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="71" Disabled="true">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                <KeyUp Fn="onKeyUp" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:DateField Editable="false" ID="date_ngayvaodangct" FieldLabel="Vào Đảng chính thức"
                                                                            runat="server" AnchorHorizontal="100%" TabIndex="72" Disabled="true">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:TextField ID="txt_noiketnapdang" runat="server" FieldLabel="Nơi kết nạp Đảng"
                                                                            Disabled="true" AllowBlank="true" TabIndex="73" AnchorHorizontal="100%" MaxLength="50"
                                                                            MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                        </ext:TextField>
                                                                        <ext:ComboBox runat="server" ID="cbx_chuvudang" FieldLabel="Chức vụ đảng" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="74" Editable="false" ItemSelector="div.list-item"
                                                                            Disabled="true">
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
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_chuvudang_Store" AutoLoad="false" OnRefreshData="cbx_chuvudang_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_chuvudang_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:TextField runat="server" ID="txt_noisinhhoatdang" FieldLabel="Nơi sinh hoạt"
                                                                            EmptyText="Nơi sinh hoạt Đảng" AnchorHorizontal="100%" Disabled="true" TabIndex="75" />
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container ID="Container27" runat="server" Layout="FormLayout" AnchorHorizontal="100%"
                                                                    Height="130" LabelWidth="125">
                                                                    <Items>
                                                                        <ext:Checkbox runat="server" ID="chkDaThamGiaQuanDoi" BoxLabel="Đã tham gia quân đội"
                                                                            Checked="false" TabIndex="76">
                                                                            <Listeners>
                                                                                <Check Handler="if (#{chkDaThamGiaQuanDoi}.checked == true) {
                                                                                        #{date_nhapngu}.enable(); #{date_xuatngu}.enable();
                                                                                        #{cbx_bacquandoi}.enable(); #{cbx_chucvuquandoi}.enable();
                                                                                    } else {
                                                                                        #{date_nhapngu}.disable(); #{date_xuatngu}.disable();
                                                                                        #{cbx_bacquandoi}.disable(); #{cbx_chucvuquandoi}.disable();
                                                                                    }" />
                                                                            </Listeners>
                                                                        </ext:Checkbox>
                                                                        <ext:DateField Editable="false" ID="date_nhapngu" FieldLabel="Ngày nhập ngũ" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="77" Disabled="true">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:DateField Editable="false" ID="date_xuatngu" FieldLabel="Ngày xuất ngũ" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="78" Disabled="true">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:ComboBox runat="server" ID="cbx_bacquandoi" FieldLabel="Bậc quân đội" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="79" Editable="false" ItemSelector="div.list-item"
                                                                            Disabled="true">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Template ID="Template28" runat="server">
                                                                                <Html>
                                                                                    <tpl for=".">
						                                                                <div class="list-item"> 
							                                                                {TEN}
						                                                                </div>
					                                                                </tpl>
                                                                                </Html>
                                                                            </Template>
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_bacquandoi_Store" AutoLoad="false" OnRefreshData="cbx_bacquandoi_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_bacquandoi_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:ComboBox runat="server" ID="cbx_chucvuquandoi" FieldLabel="Chức vụ quân đội"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="80" Editable="false"
                                                                            Disabled="true" ItemSelector="div.list-item">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Template ID="Template29" runat="server">
                                                                                <Html>
                                                                                    <tpl for=".">
						                                                                <div class="list-item"> 
							                                                                {TEN}
						                                                                </div>
					                                                                </tpl>
                                                                                </Html>
                                                                            </Template>
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_chucvuquandoi_Store" AutoLoad="false" OnRefreshData="cbx_chucvuquandoi_Store_OnRefreshData">
                                                                                    <Reader>
                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                            <Fields>
                                                                                                <ext:RecordField Name="MA" />
                                                                                                <ext:RecordField Name="TEN" />
                                                                                            </Fields>
                                                                                        </ext:JsonReader>
                                                                                    </Reader>
                                                                                </ext:Store>
                                                                            </Store>
                                                                            <Listeners>
                                                                                <Expand Handler="cbx_chucvuquandoi_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:FieldSet>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Panel>
                                        <ext:Panel ID="Panel4" Title="Thông tin khác" runat="server" AutoHeight="true" AnchorHorizontal="100%"
                                            Border="false" TabIndex="2">
                                            <Items>
                                                <ext:Container ID="Container30" runat="server" AutoHeight="true" AnchorHorizontal="100%"
                                                    Layout="ColumnLayout">
                                                    <Items>
                                                        <ext:Container ID="Container32" runat="server" ColumnWidth="0.67" Layout="FormLayout">
                                                            <Items>
                                                                <ext:Container ID="Container34" runat="server" Layout="ColumnLayout" Height="220">
                                                                    <Items>
                                                                        <ext:Container ID="Container35" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                                            Height="210">
                                                                            <Items>
                                                                                <ext:FieldSet ID="FieldSet4" runat="server" AnchorHorizontal="98%" Title="Thông tin cá nhân khác"
                                                                                    Layout="FormLayout" Height="213">
                                                                                    <Items>
                                                                                        <ext:ComboBox runat="server" ID="cbx_httuyen" FieldLabel="Hình thức tuyển" DisplayField="TEN"
                                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="81" Editable="false" ItemSelector="div.list-item">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template32" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbx_httuyen_Store" AutoLoad="false" OnRefreshData="cbx_httuyen_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_httuyen_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:DateField Editable="true" ID="date_bonhiemcv" FieldLabel="Ngày BNCV" runat="server"
                                                                                            AnchorHorizontal="100%" TabIndex="82" MaskRe="/[0-9|/]/">
                                                                                            <ToolTips>
                                                                                                <ext:ToolTip ID="ToolTip2" runat="server" Title="Hướng dẫn" Html="Ngày bổ nhiệm chức vụ">
                                                                                                </ext:ToolTip>
                                                                                            </ToolTips>
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Listeners>
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:DateField>
                                                                                        <ext:ComboBox runat="server" ID="cbx_ngach" FieldLabel="Ngạch" DisplayField="TEN"
                                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="83" Editable="false" ItemSelector="div.list-item">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template33" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbx_ngach_Store" AutoLoad="false" OnRefreshData="cbx_ngach_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_ngach_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:DateField Editable="true" ID="date_bnngach" FieldLabel="Bổ nhiệm ngạch" runat="server"
                                                                                            AnchorHorizontal="100%" TabIndex="84" MaskRe="/[0-9|/]/" Format="d/M/yyyy" EmptyText="Ngày bổ nhiệm ngạch">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Listeners>
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:DateField>
                                                                                        <ext:ComboBox runat="server" ID="cbx_trinhdoquanly" FieldLabel="Trình độ QL" DisplayField="TEN"
                                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="85" Editable="false" ItemSelector="div.list-item">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template34" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbx_trinhdoquanly_Store" AutoLoad="false" OnRefreshData="cbx_trinhdoquanly_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_trinhdoquanly_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:ComboBox runat="server" ID="cbx_trinhdoquanlykt" FieldLabel="Trình độ QLKT"
                                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="86" Editable="false"
                                                                                            ItemSelector="div.list-item">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template35" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbx_trinhdoquanlykt_Store" AutoLoad="false" OnRefreshData="cbx_trinhdoquanlykt_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_trinhdoquanlykt_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:TextField runat="server" ID="txt_username" FieldLabel="Tên đăng nhập" AnchorHorizontal="100%"
                                                                                            EnableKeyEvents="true" TabIndex="87" Disabled="true">
                                                                                        </ext:TextField>
                                                                                    </Items>
                                                                                </ext:FieldSet>
                                                                            </Items>
                                                                        </ext:Container>
                                                                        <ext:Container ID="Container37" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                                                            <Items>
                                                                                <ext:FieldSet ID="FieldSet5" runat="server" AnchorHorizontal="98%" Title="Thông tin tài khoản ngân hàng"
                                                                                    Layout="FormLayout" Height="102">
                                                                                    <Items>
                                                                                        <ext:TextField ID="txt_sotaikhoan" runat="server" FieldLabel="Số tài khoản" AnchorHorizontal="100%"
                                                                                            CtCls="requiredData" AllowBlank="true" TabIndex="88" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự"
                                                                                            EmptyText="Số tài khoản ngân hàng">
                                                                                        </ext:TextField>
                                                                                        <ext:ComboBox runat="server" ID="cbx_nganhang" CtCls="requiredData" FieldLabel="Ngân hàng"
                                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="89" Editable="false"
                                                                                            ItemSelector="div.list-item">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template36" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbx_nganhang_Store" AutoLoad="false" OnRefreshData="cbx_nganhang_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_nganhang_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:TextField ID="txt_masothuecanhan" CtCls="requiredData" runat="server" FieldLabel="Mã số thuế"
                                                                                            AllowBlank="true" TabIndex="90" AnchorHorizontal="100%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                        </ext:TextField>
                                                                                    </Items>
                                                                                </ext:FieldSet>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container ID="Container43" runat="server" Layout="FormLayout" Height="200">
                                                                    <Items>
                                                                        <ext:FieldSet ID="FieldSet7" runat="server" Layout="FormLayout" Title="Thông tin khác"
                                                                            AnchorHorizontal="99%" Height="175">
                                                                            <Items>
                                                                                <ext:TextArea runat="server" ID="txtSOTHICH" FieldLabel="Sở thích" TabIndex="94"
                                                                                    AnchorHorizontal="100%" Height="45">
                                                                                </ext:TextArea>
                                                                                <ext:TextArea ID="txt_UuDiem" runat="server" FieldLabel="Ưu điểm" AllowBlank="true"
                                                                                    TabIndex="95" AnchorHorizontal="100%" Height="45">
                                                                                </ext:TextArea>
                                                                                <ext:TextArea ID="txt_NhuocDiem" runat="server" FieldLabel="Nhược điểm" AllowBlank="true"
                                                                                    TabIndex="96" AnchorHorizontal="100%" Height="45">
                                                                                </ext:TextArea>
                                                                            </Items>
                                                                        </ext:FieldSet>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" ID="Container100" Layout="FormLayout" ColumnWidth="0.33"
                                                            Height="400">
                                                            <Items>
                                                                <ext:Container runat="server" ID="Container44" Layout="ColumnLayout" AnchorHorizontal="100%"
                                                                    Height="220">
                                                                    <Items>
                                                                        <ext:Container runat="server" ID="Container45" Layout="FormLayout" ColumnWidth="1"
                                                                            Height="210">
                                                                            <Items>
                                                                                <ext:FieldSet ID="FieldSet8" runat="server" Title="Thông tin sức khỏe" Layout="FormLayout"
                                                                                    AnchorHorizontal="100%" Height="213">
                                                                                    <Items>
                                                                                        <ext:ComboBox ID="cbNhommau" runat="server" FieldLabel="Nhóm máu" AllowBlank="true"
                                                                                            TabIndex="97" Editable="false" AnchorHorizontal="100%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                                            <Items>
                                                                                                <ext:ListItem Text="Nhóm A" Value="A" />
                                                                                                <ext:ListItem Text="Nhóm B" Value="B" />
                                                                                                <ext:ListItem Text="Nhóm AB" Value="AB" />
                                                                                                <ext:ListItem Text="Nhóm O" Value="O" />
                                                                                            </Items>
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Listeners>
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:CompositeField ID="CompositeField7" runat="server" AnchorHorizontal="100%" FieldLabel="Cao/Cân nặng">
                                                                                            <Items>
                                                                                                <ext:NumberField runat="server" EmptyText="Cao" ID="txt_chieucao" Width="50" TabIndex="98"
                                                                                                    MaxLength="4" Regex="/[\d]+/" />
                                                                                                <ext:DisplayField ID="DisplayField11" runat="server" Text="cm  /" />
                                                                                                <ext:NumberField runat="server" ID="txt_cannang" EmptyText="Nặng" Width="50" TabIndex="99"
                                                                                                    MaxLength="3" Regex="/[\d]+/" />
                                                                                                <ext:DisplayField ID="DisplayField12" runat="server" Text="Kg" />
                                                                                            </Items>
                                                                                        </ext:CompositeField>
                                                                                        <ext:ComboBox runat="server" ID="cbx_ttsuckhoe" FieldLabel="Tình trạng SK" DisplayField="TEN"
                                                                                            ValueField="MA" EmptyText="Tình trạng sức khỏe" AnchorHorizontal="100%" TabIndex="100"
                                                                                            ItemSelector="div.list-item" Editable="false">
                                                                                            <Triggers>
                                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                            </Triggers>
                                                                                            <Template ID="Template10" runat="server">
                                                                                                <Html>
                                                                                                    <tpl for=".">
						                                                                                <div class="list-item"> 
							                                                                                {TEN}
						                                                                                </div>
					                                                                                </tpl>
                                                                                                </Html>
                                                                                            </Template>
                                                                                            <Store>
                                                                                                <ext:Store runat="server" ID="cbx_ttsuckhoe_Store" AutoLoad="false" OnRefreshData="cbx_ttsuckhoe_Store_OnRefreshData">
                                                                                                    <Reader>
                                                                                                        <ext:JsonReader IDProperty="MA">
                                                                                                            <Fields>
                                                                                                                <ext:RecordField Name="MA" />
                                                                                                                <ext:RecordField Name="TEN" />
                                                                                                            </Fields>
                                                                                                        </ext:JsonReader>
                                                                                                    </Reader>
                                                                                                </ext:Store>
                                                                                            </Store>
                                                                                            <Listeners>
                                                                                                <Expand Handler="cbx_ttsuckhoe_Store.reload();" />
                                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                                            </Listeners>
                                                                                        </ext:ComboBox>
                                                                                        <ext:Checkbox runat="server" ID="chkLaThuongBinh" BoxLabel="Là thương binh" TabIndex="101">
                                                                                            <Listeners>
                                                                                                <Check Handler="if (#{chkLaThuongBinh}.checked == true) {
                                                                                                        #{txt_HangThuongTat}.enable(); #{txt_SoThuongTat}.enable(); #{txt_HinhThucThuongTat}.enable();
                                                                                                    } else {
                                                                                                        #{txt_HangThuongTat}.disable(); #{txt_SoThuongTat}.disable(); #{txt_HinhThucThuongTat}.disable();
                                                                                                    }" />
                                                                                            </Listeners>
                                                                                        </ext:Checkbox>
                                                                                        <ext:TextField runat="server" ID="txt_HangThuongTat" FieldLabel="Hạng thương tật"
                                                                                            AnchorHorizontal="100%" MaxLength="100" Disabled="true" TabIndex="102">
                                                                                        </ext:TextField>
                                                                                        <ext:TextField runat="server" ID="txt_SoThuongTat" FieldLabel="Số thương tật" AnchorHorizontal="100%"
                                                                                            MaxLength="50" Disabled="true" TabIndex="103">
                                                                                        </ext:TextField>
                                                                                        <ext:TextField runat="server" ID="txt_HinhThucThuongTat" FieldLabel="Hình thức thương tật"
                                                                                            AnchorHorizontal="100%" MaxLength="500" Disabled="true" TabIndex="104">
                                                                                        </ext:TextField>
                                                                                    </Items>
                                                                                </ext:FieldSet>
                                                                            </Items>
                                                                        </ext:Container>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container runat="server" ID="Container46" Layout="FormLayout" AnchorHorizontal="100%">
                                                                    <Items>
                                                                        <ext:FieldSet runat="server" ID="FieldSet9" Title="Liên hệ trong trường hợp khẩn cấp"
                                                                            Layout="FormLayout" AnchorHorizontal="100%">
                                                                            <Items>
                                                                                <ext:TextField ID="txt_nguoilienhe" runat="server" CtCls="requiredData" FieldLabel="Người liên hệ"
                                                                                    AnchorHorizontal="100%" AllowBlank="true" TabIndex="105" MaxLength="50" EmptyText="Họ và tên người liên hệ">
                                                                                </ext:TextField>
                                                                                <ext:TextField ID="txt_sdtnguoilh" MaskRe="/[0-9\.]/" runat="server" FieldLabel="SDT người LH"
                                                                                    EmptyText="Số điện thoại người liên hệ" CtCls="requiredData" AnchorHorizontal="100%"
                                                                                    TabIndex="106" MaxLength="50">
                                                                                </ext:TextField>
                                                                                <ext:TextField ID="txtMoiQH" runat="server" CtCls="requiredData" FieldLabel="Quan hệ với CB"
                                                                                    EmptyText="Ví dụ: Bố, Mẹ, ..." AnchorHorizontal="100%" TabIndex="107" MaxLength="100">
                                                                                </ext:TextField>
                                                                                <ext:TextField ID="txt_emailnguoilh" runat="server" CtCls="requiredData" FieldLabel="Email"
                                                                                    EmptyText="Email người liên hệ" AnchorHorizontal="100%" MaxLength="100" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                                                    RegexText="Định dạng email không đúng" TabIndex="108">
                                                                                </ext:TextField>
                                                                                <ext:TextArea ID="txt_diachinguoilienhe" runat="server" FieldLabel="Địa chỉ" AnchorHorizontal="100%"
                                                                                    Height="40" MaxLength="1000" TabIndex="109">
                                                                                </ext:TextArea>
                                                                            </Items>
                                                                        </ext:FieldSet>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Panel>
                                    </Items>
                                </ext:TabPanel>
                            </Items>
                        </ext:FormPanel>
                    </Center>
                    <South>
                        <ext:TabPanel runat="server" Cls="bkGround" Border="false" ID="TabBottomPanel" Height="180">
                            <Items>
                                <ext:Panel ID="pnl_QuanHeGiaDinh" Title="Quan hệ gia đình" Layout="BorderLayout"
                                    AnchorHorizontal="100%" runat="server" Border="false">
                                    <Items>
                                        <ext:Hidden ID="hdfQuanHeGiaDinh" runat="server" Text="changed" />
                                        <ext:GridPanel ID="GridPanelQHGD" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Height="200"
                                            AutoExpandColumn="GHI_CHU" Region="Center">
                                            <Store>
                                                <ext:Store ID="StoreQHGD" AutoSave="true" AutoLoad="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="StoreQHGD_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="HO_TEN" />
                                                                <ext:RecordField Name="TUOI" />
                                                                <ext:RecordField Name="TEN_QUANHE" />
                                                                <ext:RecordField Name="NGHE_NGHIEP" />
                                                                <ext:RecordField Name="NOI_LAMVIEC" />
                                                                <ext:RecordField Name="GIOI_TINH" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                                <ext:RecordField Name="LaNguoiPhuThuoc" />
                                                                <ext:RecordField Name="NgayBatDauGiamTru" />
                                                                <ext:RecordField Name="NgayKetThucGiamTru" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel11" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="HO_TEN" Width="200" Header="Họ tên" DataIndex="HO_TEN" />
                                                    <ext:Column ColumnID="TUOI" Width="70" Header="Năm sinh" DataIndex="TUOI">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="TEN_QUANHE" Header="Quan hệ" DataIndex="TEN_QUANHE" />
                                                    <ext:Column ColumnID="NGHE_NGHIEP" Header="Nghề nghiệp" DataIndex="NGHE_NGHIEP" />
                                                    <ext:Column ColumnID="NOI_LAMVIEC" Header="Nơi làm việc" DataIndex="NOI_LAMVIEC" />
                                                    <ext:Column ColumnID="GIOI_TINH" Width="70" Header="Giới tính" DataIndex="GIOI_TINH">
                                                    </ext:Column>
                                                    <ext:CheckColumn ColumnID="LaNguoiPhuThuoc" Width="120" Header="Là người phụ thuộc"
                                                        DataIndex="LaNguoiPhuThuoc">
                                                    </ext:CheckColumn>
                                                    <ext:Column ColumnID="NgayBatDauGiamTru" Header="Bắt đầu giảm trừ" DataIndex="NgayBatDauGiamTru">
                                                        <Renderer Fn="RenderDate" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="NgayKetThucGiamTru" Header="Kết thúc giảm trừ" DataIndex="NgayKetThucGiamTru">
                                                        <Renderer Fn="RenderDate" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelQHGD" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                    <Listeners>
                                        <Activate Handler="if(#{hdfQuanHeGiaDinh}.getValue() == 'changed')
                                                   {
                                                        #{hdfQuanHeGiaDinh}.setValue('');
                                                        #{StoreQHGD}.reload();
                                                   }" />
                                    </Listeners>
                                </ext:Panel>
                                <ext:Panel ID="pnl_QuaTrinhHocTap" Title="Quá trình học tập" runat="server" Closable="true"
                                    Hidden="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{MenuItemHocTap}.setDisabled(false);" />
                                        <Activate Handler="
                                           if(#{hdfQuaTrinhHocTapState}.getValue() == 'changed')
                                           {
                                             #{Store_BangCap}.reload();
                                             #{hdfQuaTrinhHocTapState}.setValue('');
                                           }
                                          " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfQuaTrinhHocTapState" Text="changed" />
                                        <ext:GridPanel ID="GridPanel_BangCap" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoExpandColumn="TEN_TRUONG_DAOTAO" AutoScroll="true"
                                            AnchorHorizontal="100%" Height="200" Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_BangCap" AutoLoad="true" AutoSave="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="Store_BangCap_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="FR_KEY" />
                                                                <ext:RecordField Name="TEN_TRUONG_DAOTAO" />
                                                                <ext:RecordField Name="KHOA" />
                                                                <ext:RecordField Name="TU_NGAY" />
                                                                <ext:RecordField Name="DEN_NGAY" />
                                                                <ext:RecordField Name="TEN_CHUYENNGANH" />
                                                                <ext:RecordField Name="TEN_TRINHDO" />
                                                                <ext:RecordField Name="TEN_HT_DAOTAO" />
                                                                <ext:RecordField Name="TEN_XEPLOAI" />
                                                                <ext:RecordField Name="DA_TN" />
                                                                <ext:RecordField Name="NGAY_NHANBANG" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel20" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="TEN_TRUONG_DAOTAO" Header="Nơi đào tạo" DataIndex="TEN_TRUONG_DAOTAO" />
                                                    <ext:Column ColumnID="KHOA" Header="Khoa" DataIndex="KHOA" Width="150" />
                                                    <ext:DateColumn ColumnID="TU_NGAY" Width="70" Header="Từ ngày" DataIndex="TU_NGAY" />
                                                    <ext:DateColumn ColumnID="DEN_NGAY" Width="70" Header="Đến ngày" DataIndex="DEN_NGAY" />
                                                    <ext:Column ColumnID="TEN_CHUYENNGANH" Header="Chuyên ngành" DataIndex="TEN_CHUYENNGANH"
                                                        Width="200" />
                                                    <ext:Column ColumnID="TEN_TRINHDO" Width="70" Header="Trình độ" DataIndex="TEN_TRINHDO" />
                                                    <ext:Column ColumnID="TEN_HT_DAOTAO" Width="100" Header="Hình thức" DataIndex="TEN_HT_DAOTAO" />
                                                    <ext:Column ColumnID="TEN_XEPLOAI" Width="70" Header="Xếp loại" DataIndex="TEN_XEPLOAI" />
                                                    <ext:Column ColumnID="DA_TN" Width="100" Header="Đã tốt nghiệp" Align="Center" DataIndex="DA_TN">
                                                        <Renderer Fn="GetBooleanIcon" />
                                                    </ext:Column>
                                                    <ext:DateColumn ColumnID="NGAY_NHANBANG" Width="100" Header="Ngày nhận bằng" DataIndex="NGAY_NHANBANG" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel_BangCap" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="EditQuaTrinhHocTap();" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <%--<ext:Panel ID="pnl_KinhNghiemLamViec" Title="Kinh nghiệm làm việc" runat="server"
                                    Closable="true" Hidden="true" CloseAction="Hide" Layout ="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{MenuItemKNLV}.setDisabled(false);" />
                                        <Activate Handler="
                                                          if(#{hdfKinhNghiemLamViecStatus}.getValue() == 'changed')
                                                          {
                                                            #{hdfKinhNghiemLamViecStatus}.setValue('');
                                                            #{StoreKinhNghiemLamViec}.reload();
                                                          }
                                                          " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden ID="hdfKinhNghiemLamViecStatus" runat="server" Text="changed" />
                                        <ext:GridPanel ID="GridPanelKinhNghiemLamViec" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoExpandColumn="CongViecDamNhiem" AutoScroll="true" AnchorHorizontal="100%"
                                            Height="200" Region="Center">
                                            <Store>
                                                <ext:Store ID="StoreKinhNghiemLamViec" AutoLoad="true" AutoSave="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="StoreKinhNghiemLamViec_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="FR_KEY" />
                                                                <ext:RecordField Name="NoiLamViec" />
                                                                <ext:RecordField Name="ViTriCongViec" />
                                                                <ext:RecordField Name="CongViecDamNhiem" />
                                                                <ext:RecordField Name="TuThangNam" />
                                                                <ext:RecordField Name="DenThangNam" />
                                                                <ext:RecordField Name="LyDoChuyenCongTac" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel19" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="NoiLamViec" Header="Nơi làm việc" DataIndex="NoiLamViec" Width="200" />
                                                    <ext:Column ColumnID="ViTriCongViec" Header="Vị trí công việc" DataIndex="ViTriCongViec" />
                                                    <ext:Column ColumnID="CongViecDamNhiem" Header="Công việc đảm nhiệm" DataIndex="CongViecDamNhiem" />
                                                    <ext:Column ColumnID="TuThangNam" Width="100" Header="Từ ngày" DataIndex="TuThangNam">
                                                        <Renderer Fn="RenderDate" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="DenThangNam" Width="100" Header="Đến ngày" DataIndex="DenThangNam">
                                                        <Renderer Fn="RenderDate" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="LyDoChuyenCongTac" Width="150" Header="Lý do chuyển công tác"
                                                        DataIndex="LyDoChuyenCongTac" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelKinhNghiemLamViec" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>--%>
                                <ext:Panel ID="pnl_KinhNghiemLamViec" Title="Kinh nghiệm làm việc" runat="server"
                                    Closable="true" Hidden="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{MenuItemKNLV}.setDisabled(false);" />
                                        <Activate Handler="
                                                       if(#{hdfCheckKNLV}.getValue() == 'changed')
                                                       {                                                            
                                                            #{StoreKinhNghiemLamViec}.reload();
                                                            #{hdfCheckKNLV}.setValue('');
                                                       }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckKNLV" />
                                        <ext:GridPanel ID="GridPanelKinhNghiemLamViec" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoExpandColumn="GhiChu" AutoScroll="true" AnchorHorizontal="100%"
                                            Region="Center">
                                            <Store>
                                                <ext:Store ID="StoreKinhNghiemLamViec" AutoSave="true" AutoLoad="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="StoreKinhNghiemLamViec_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="FR_KEY" />
                                                                <ext:RecordField Name="NoiLamViec" />
                                                                <ext:RecordField Name="ViTriCongViec" />
                                                                <ext:RecordField Name="KinhNghiemDatDuoc" />
                                                                <ext:RecordField Name="TuThangNam" />
                                                                <ext:RecordField Name="DenThangNam" />
                                                                <ext:RecordField Name="LyDoThoiViec" />
                                                                <ext:RecordField Name="GhiChu" />
                                                                <ext:RecordField Name="MucLuong" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel19" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Width="35" Header="STT" />
                                                    <ext:Column ColumnID="NoiLamViec" Header="Nơi làm việc" DataIndex="NoiLamViec" Width="200" />
                                                    <ext:Column ColumnID="ViTriCongViec" Width="150" Header="Chức danh" DataIndex="ViTriCongViec" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="TuThangNam" Width="90" Header="Từ ngày"
                                                        DataIndex="TuThangNam" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="DenThangNam" Width="90" Header="Đến ngày"
                                                        DataIndex="DenThangNam" />
                                                    <ext:Column ColumnID="KinhNghiemDatDuoc" Width="150" Header="Thành tích đạt được"
                                                        DataIndex="KinhNghiemDatDuoc" />
                                                    <ext:Column ColumnID="MucLuong" Width="90" Header="Mức lương" DataIndex="MucLuong">
                                                        <Renderer Fn="RenderVND" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="LyDoThoiViec" Header="Lý do thôi việc" DataIndex="LyDoThoiViec" />
                                                    <ext:Column ColumnID="GhiChu" Header="Ghi chú" DataIndex="GhiChu" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelKinhNghiemLamViec" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="pnl_BangCapChungChi" Title="Bằng cấp chứng chỉ" runat="server" Closable="true"
                                    Hidden="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckChungChiLoaded" />
                                        <ext:Hidden ID="hdfBangCapChungChi" runat="server" Text="changed" />
                                        <ext:Hidden runat="server" ID="hdfChungChiID" />
                                        <ext:GridPanel ID="GridPanel_ChungChi" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoExpandColumn="TenChungChi" AutoScroll="true" AnchorHorizontal="100%"
                                            Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_BangCapChungChi" AutoSave="true" AutoLoad="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="Store_BangCapChungChi_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="FR_KEY" />
                                                                <ext:RecordField Name="TenChungChi" />
                                                                <ext:RecordField Name="TEN_XEPLOAI" />
                                                                <ext:RecordField Name="NoiDaoTao" />
                                                                <ext:RecordField Name="NgayCap" />
                                                                <ext:RecordField Name="NgayHetHan" />
                                                                <ext:RecordField Name="GhiChu" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel18" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="TenChungChi" Header="Tên chứng chỉ" DataIndex="TenChungChi" />
                                                    <ext:Column ColumnID="TEN_XEPLOAI" Header="Xếp loại" DataIndex="TEN_XEPLOAI" Width="100" />
                                                    <ext:Column ColumnID="NoiDaoTao" Header="Nơi đào tạo" DataIndex="NoiDaoTao" Width="200" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayCap" Width="80" Header="Ngày cấp"
                                                        DataIndex="NgayCap" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayHetHan" Width="80" Header="Ngày hết hạn"
                                                        DataIndex="NgayHetHan" />
                                                    <ext:Column ColumnID="GhiChu" Width="150" Header="Ghi chú" DataIndex="GhiChu" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel_ChungChi" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="hdfChungChiID.setValue(RowSelectionModel_ChungChi.getSelected().data.ID);" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                    <Listeners>
                                        <Close Handler="#{MenuItemBangCapChungChi}.setDisabled(false);" />
                                        <Activate Handler="
                                                   if(#{hdfBangCapChungChi}.getValue() == 'changed')
                                                   {
                                                        #{hdfBangCapChungChi}.setValue('');
                                                        #{Store_BangCapChungChi}.reload();
                                                   }" />
                                    </Listeners>
                                </ext:Panel>
                                <ext:Panel ID="pnl_TaiSan" Title="Tài sản" runat="server" Closable="true" Hidden="true"
                                    CloseAction="Hide" Layout="BorderLayout">
                                    <Items>
                                        <ext:Hidden ID="hdfTaiSanState" runat="server" Text="changed" />
                                        <ext:GridPanel ID="GridPanelTaiSan" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Height="200"
                                            AutoExpandColumn="GHI_CHU" Region="Center">
                                            <Store>
                                                <ext:Store ID="StoreTaiSan" AutoSave="true" AutoLoad="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="StoreTaiSan_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="MA_VTHH" />
                                                                <ext:RecordField Name="TEN_VTHH" />
                                                                <ext:RecordField Name="SoLuong" />
                                                                <ext:RecordField Name="TEN_DVT" />
                                                                <ext:RecordField Name="NGAY_NHAN" />
                                                                <ext:RecordField Name="TINH_TRANG" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel12" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                    <ext:Column ColumnID="TEN_VTHH" Width="200" Header="Tên vật tư" DataIndex="TEN_VTHH">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="SoLuong" Width="80" Header="Số lượng" DataIndex="SoLuong" />
                                                    <ext:Column ColumnID="TEN_DVT" Width="100" Header="Đơn vị tính" DataIndex="TEN_DVT" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_NHAN" Header="Ngày nhận" DataIndex="NGAY_NHAN">
                                                    </ext:DateColumn>
                                                    <ext:Column ColumnID="TINH_TRANG" Header="Tình trạng" DataIndex="TINH_TRANG">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelTaiSan" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                                <ViewReady Handler="cbTaiSanStore.reload();cbxDonViTinh_Store.reload();" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                    <Listeners>
                                        <Close Handler="#{mnuTaiSan}.setDisabled(false);" />
                                        <Activate Handler="
                                                   if(#{hdfTaiSanState}.getValue() == 'changed')
                                                   {
                                                        #{hdfTaiSanState}.setValue('');
                                                        #{StoreTaiSan}.reload();
                                                   }" />
                                    </Listeners>
                                </ext:Panel>
                                <ext:Panel ID="pnl_KhaNang" Title="Khả năng" runat="server" Hidden="true" Closable="true"
                                    CloseAction="Hide" Layout="BorderLayout">
                                    <Items>
                                        <ext:Hidden ID="hdfKhaNangState" runat="server" Text="changed" />
                                        <ext:GridPanel ID="GridPanelKhaNang" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Height="200"
                                            AutoExpandColumn="TEN_KHANANG" Region="Center">
                                            <Store>
                                                <ext:Store ID="StoreKhaNang" AutoSave="true" AutoLoad="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="StoreKhaNang_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="TEN_KHANANG" />
                                                                <ext:RecordField Name="TEN_XEPLOAI" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel8" runat="server">
                                                <Columns>
                                                    <ext:Column ColumnID="TEN_KHANANG" Header="Khả năng" DataIndex="TEN_KHANANG" />
                                                    <ext:Column ColumnID="TEN_XEPLOAI" Header="Xếp loại" DataIndex="TEN_XEPLOAI" />
                                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelKhaNang" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                    <Listeners>
                                        <Close Handler="#{mnuKhaNang}.setDisabled(false);" />
                                        <Activate Handler="
                                                   if(#{hdfKhaNangState}.getValue() == 'changed')
                                                   {
                                                        #{hdfKhaNangState}.setValue('');
                                                        #{StoreKhaNang}.reload();
                                                   }" />
                                    </Listeners>
                                </ext:Panel>
                                <ext:Panel ID="pnl_KhenThuong" Title="Khen thưởng" runat="server" Hidden="true" Closable="true"
                                    CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{mnuKhenThuong}.setDisabled(false);" />
                                        <Activate Handler="if(#{hdfKhenThuongRecordID}.getValue()=='')
                                                                {
                                                                    #{StoreKhenThuong}.reload();
                                                                    #{hdfKhenThuongRecordID}.setValue('Loaded');
                                                                }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden ID="hdfKhenThuongRecordID" runat="server" />
                                        <ext:GridPanel ID="GridPanelKhenThuong" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                                            AutoExpandColumn="TEN_LYDO_KTHUONG">
                                            <Store>
                                                <ext:Store ID="StoreKhenThuong" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreKhenThuong_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="TepTinDinhKem" />
                                                                <ext:RecordField Name="TEN_LYDO_KTHUONG" />
                                                                <ext:RecordField Name="TEN_HT_KTHUONG" />
                                                                <ext:RecordField Name="SO_TIEN" />
                                                                <ext:RecordField Name="SO_QD" />
                                                                <ext:RecordField Name="TEN_NGUOI_QD" />
                                                                <ext:RecordField Name="NGAY_QD" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel9" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Width="35" Header="STT" />
                                                    <ext:Column ColumnID="TepTinDinhKem" Header="" Width="25" DataIndex="TepTinDinhKem">
                                                        <Renderer Fn="RenderTepTinDinhKem" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="TEN_LYDO_KTHUONG" Header="Lý do khen thưởng" DataIndex="TEN_LYDO_KTHUONG" />
                                                    <ext:Column ColumnID="TEN_HT_KTHUONG" Width="200" Header="Hình thức khen thưởng"
                                                        DataIndex="TEN_HT_KTHUONG" />
                                                    <ext:Column ColumnID="SO_TIEN" Header="Số tiền" DataIndex="SO_TIEN">
                                                        <Renderer Fn="RenderVND" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="SO_QD" Header="Số QĐ" DataIndex="SO_QD" />
                                                    <ext:Column ColumnID="TEN_NGUOI_QD" Header="Người quyết định" Width="120" DataIndex="TEN_NGUOI_QD" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_QD" Header="Ngày quyết định" DataIndex="NGAY_QD" />
                                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelKhenThuong" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btnEditRecord}.enable();#{btnDeleteRecord}.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="EditKhenThuong();" />
                                                <ViewReady Handler="if(#{cbLyDoKhenThuong}.store.getCount()==0){#{cbLyDoKhenThuongStore}.reload();}
                                                                        if(#{cbHinhThucKhenThuong}.store.getCount()==0){#{cbHinhThucKhenThuongStore}.reload();}" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="panelKiLuat" Title="Kỷ luật" runat="server" Hidden="true" Closable="true"
                                    CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{mnuKyLuat}.setDisabled(false);" />
                                        <Activate Handler="if(#{hdfKyLuatRecordID}.getValue()!=#{hdf_PR_KEY}.getValue())
                                    {
                                        #{StoreKyLuat}.reload();
                                        #{hdfKyLuatRecordID}.setValue(#{hdf_PR_KEY}.getValue());
                                    }
                                    " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden ID="hdfKyLuatRecordID" runat="server" />
                                        <ext:GridPanel ID="GridPanelKyLuat" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                                            AutoExpandColumn="GHI_CHU" AutoExpandMin="150">
                                            <Store>
                                                <ext:Store ID="StoreKyLuat" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreKyLuat_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="SO_QD" />
                                                                <ext:RecordField Name="NGAY_QD" />
                                                                <ext:RecordField Name="TEN_LYDO_KYLUAT" />
                                                                <ext:RecordField Name="TEN_HT_KYLUAT" />
                                                                <ext:RecordField Name="SO_TIEN" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                                <ext:RecordField Name="TepTinDinhKem" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel10" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Width="35" Header="STT" />
                                                    <ext:Column ColumnID="TepTinDinhKem" Header="" Width="25" DataIndex="TepTinDinhKem">
                                                        <Renderer Fn="RenderTepTinDinhKem" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="SO_QD" Header="Số quyết định" DataIndex="SO_QD" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_QD" Header="Ngày quyết định" DataIndex="NGAY_QD" />
                                                    <ext:Column ColumnID="TEN_LYDO_KYLUAT" Width="250" Header="Lý do kỷ luật" DataIndex="TEN_LYDO_KYLUAT" />
                                                    <ext:Column ColumnID="TEN_HT_KYLUAT" Width="250" Header="Hình thức kỷ luật" DataIndex="TEN_HT_KYLUAT" />
                                                    <ext:Column ColumnID="SO_TIEN" Width="150" Header="Số tiền" DataIndex="SO_TIEN">
                                                        <Renderer Fn="RenderVND" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelKyLuat" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="" />
                                                <ViewReady Handler="if(#{cbLyDoKyLuat}.store.getCount()==0){#{cbLyDoKyLuatStore}.reload();}
                                                                    if(#{cbHinhThucKyLuat}.store.getCount()==0){#{cbHinhThucKyLuatStore}.reload();}" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="panelQuaTrinhCongTac" Title="Quá trình công tác" runat="server" Hidden="true"
                                    Closable="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{mnuQuaTrinhCongTac}.setDisabled(false);" />
                                        <Activate Handler="if(#{hdfQTCTRecordID}.getValue()=='')
                                                                {
                                                                    #{StoreQuaTrinhCongTac}.reload();
                                                                    #{hdfQTCTRecordID}.setValue('Loaded');
                                                                }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden ID="hdfQTCTRecordID" runat="server" />
                                        <ext:GridPanel ID="GridPanelQuaTrinhCTAC" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                                            AutoExpandColumn="DiaDiemCongTac" AutoExpandMin="100">
                                            <Store>
                                                <ext:Store ID="StoreQuaTrinhCongTac" AutoSave="true" ShowWarningOnFailure="false"
                                                    OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                                    AutoLoad="false" OnRefreshData="StoreQuaTrinhCongTac_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="SoQuyetDinh" />
                                                                <ext:RecordField Name="NgayQuyetDinh" />
                                                                <ext:RecordField Name="NgayBatDau" />
                                                                <ext:RecordField Name="NgayKetThuc" />
                                                                <ext:RecordField Name="NoiDungCongViec" />
                                                                <ext:RecordField Name="DiaDiemCongTac" />
                                                                <ext:RecordField Name="TenNuoc" />
                                                                <ext:RecordField Name="TepTinDinhKem" />
                                                                <ext:RecordField Name="GhiChu" />
                                                                <ext:RecordField Name="TEN_NGUOI_QD" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel14" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                    <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="TepTinDinhKem">
                                                        <Renderer Fn="RenderTepTinDinhKem" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="SoQuyetDinh" Header="Số quyết định" DataIndex="SoQuyetDinh" />
                                                    <ext:DateColumn ColumnID="NgayQuyetDinh" Header="Ngày quyết định" DataIndex="NgayQuyetDinh"
                                                        Format="dd/MM/yyyy" />
                                                    <ext:Column ColumnID="TEN_NGUOI_QD" Header="Người quyết định" DataIndex="TEN_NGUOI_QD" />
                                                    <ext:DateColumn ColumnID="NgayBatDau" Header="Ngày bắt đầu" DataIndex="NgayBatDau"
                                                        Format="dd/MM/yyyy" />
                                                    <ext:DateColumn ColumnID="NgayKetThuc" Header="Ngày kết thúc" DataIndex="NgayKetThuc"
                                                        Format="dd/MM/yyyy" />
                                                    <ext:Column ColumnID="NoiDungCongViec" Header="Nội dung công việc" Width="200" DataIndex="NoiDungCongViec" />
                                                    <ext:Column ColumnID="DiaDiemCongTac" Header="Nơi công tác" DataIndex="DiaDiemCongTac" />
                                                    <ext:Column ColumnID="TenNuoc" Header="Quốc gia" DataIndex="TenNuoc" />
                                                    <ext:Column ColumnID="GhiChu" Header="Ghi chú" DataIndex="GhiChu" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelQuaTrinhCongTac" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="btnDeleteRecord.enable();btnEditRecord.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="EditQuaTrinhCongTac();" />
                                                <ViewReady Handler="if(#{cbCongTacQuocGia}.store.getCount()==0){#{cbCongTacQuocGiaStore}.reload();}" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="panelQuaTrinhDieuChuyen" Title="Quá trình điều chuyển" runat="server"
                                    Hidden="true" Closable="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{mnuQuaTrinhDieuChuyen}.setDisabled(false);" />
                                        <Activate Handler="if(#{hdfQTDCRecordID}.getValue()=='')
                                                                {
                                                                    #{StoreQuaTrinhDieuChuyen}.reload();
                                                                    #{hdfQTDCRecordID}.setValue('Loaded');
                                                                }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden ID="hdfQTDCRecordID" runat="server" />
                                        <ext:GridPanel ID="GridPanelQuaTrinhDieuChuyen" runat="server" StripeRows="true"
                                            Border="false" TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%"
                                            Region="Center" AutoExpandColumn="GhiChu" AutoExpandMin="100">
                                            <Store>
                                                <ext:Store ID="StoreQuaTrinhDieuChuyen" AutoSave="true" ShowWarningOnFailure="false"
                                                    OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                                    AutoLoad="false" OnRefreshData="StoreQuaTrinhDieuChuyen_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="SoQuyetDinh" />
                                                                <ext:RecordField Name="TenNguoiQuyetDinh" />
                                                                <ext:RecordField Name="NgayQuyetDinh" />
                                                                <ext:RecordField Name="NgayCoHieuLuc" />
                                                                <ext:RecordField Name="NgayHetHieuLuc" />
                                                                <ext:RecordField Name="TenBoPhanCu" />
                                                                <ext:RecordField Name="TenBoPhanMoi" />
                                                                <ext:RecordField Name="TenChucVuCu" />
                                                                <ext:RecordField Name="TenChucVuMoi" />
                                                                <ext:RecordField Name="TenCongViecCu" />
                                                                <ext:RecordField Name="TenCongViecMoi" />
                                                                <ext:RecordField Name="TepTinDinhKem" />
                                                                <ext:RecordField Name="GhiChu" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel13" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                    <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="TepTinDinhKem">
                                                        <Renderer Fn="RenderTepTinDinhKem" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="SoQuyetDinh" Width="110" Header="Số quyết định" DataIndex="SoQuyetDinh" />
                                                    <ext:Column ColumnID="TenNguoiQuyetDinh" Width="150" Header="Người quyết định" DataIndex="TenNguoiQuyetDinh" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayQuyetDinh" Width="100" Header="Ngày quyết định"
                                                        DataIndex="NgayQuyetDinh" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayCoHieuLuc" Width="100" Header="Ngày hiệu lực"
                                                        DataIndex="NgayCoHieuLuc" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayHetHieuLuc" Width="100" Header="Ngày hết hiệu lực"
                                                        DataIndex="NgayHetHieuLuc" />
                                                    <ext:Column ColumnID="TenBoPhanCu" Width="150" Header="Bộ phận cũ" DataIndex="TenBoPhanCu" />
                                                    <ext:Column ColumnID="TenBoPhanMoi" Width="150" Header="Bộ phận mới" DataIndex="TenBoPhanMoi" />
                                                    <ext:Column ColumnID="TenChucVuCu" Header="Chức vụ cũ" Width="100" DataIndex="TenChucVuCu" />
                                                    <ext:Column ColumnID="TenChucVuMoi" Header="Chức vụ mới" Width="100" DataIndex="TenChucVuMoi" />
                                                    <ext:Column ColumnID="TenCongViecCu" Header="Chức danh cũ" Width="120" DataIndex="TenCongViecCu" />
                                                    <ext:Column ColumnID="TenCongViecMoi" Header="Chức danh mới" Width="120" DataIndex="TenCongViecMoi" />
                                                    <ext:Column ColumnID="GhiChu" Header="Ghi chú" Width="100" DataIndex="GhiChu" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelQuaTrinhDieuChuyen" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="btnDeleteRecord.enable();btnEditRecord.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="EditQuaTrinhDieuChuyen();" />
                                                <ViewReady Handler="if(#{cbxQTDCBoPhanMoi_Store}.getCount()==0) #{cbxQTDCBoPhanMoi_Store}.reload();
                                                    if(#{cbxQTDCChucVuMoi_Store}.getCount()==0) #{cbxQTDCChucVuMoi_Store}.reload();
                                                    if(#{cbxCongViecMoi_Store}.getCount()==0) #{cbxCongViecMoi_Store}.reload();" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="panelTaiNanLaoDong" Title="Tai nạn lao động" runat="server" Closable="true"
                                    Hidden="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Listeners>
                                        <Close Handler="#{mnuTaiNanLaoDong}.setDisabled(false);" />
                                        <Activate Handler="if(#{hdfCheckTNLDLoaded}.getValue()!=#{hdf_PR_KEY}.getValue())
                                            {
                                            #{StoreTaiNanLaoDong}.reload();
                                            #{hdfCheckTNLDLoaded}.setValue(#{hdf_PR_KEY}.getValue());
                                            }
                                            " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckTNLDLoaded" />
                                        <ext:GridPanel ID="GridPanelTaiNanLaoDong" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                                            AutoExpandColumn="LY_DO">
                                            <Store>
                                                <ext:Store ID="StoreTaiNanLaoDong" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreTaiNanLaoDong_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="LY_DO" />
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="NGAY_XAY_RA" />
                                                                <ext:RecordField Name="DIA_DIEM" />
                                                                <ext:RecordField Name="THIET_HAI" />
                                                                <ext:RecordField Name="THUONG_TAT" />
                                                                <ext:RecordField Name="NgayBoiThuong" />
                                                                <ext:RecordField Name="BOI_THUONG" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel16" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                    <ext:Column ColumnID="LY_DO" Header="Nguyên nhân tai nạn" Width="100" DataIndex="LY_DO">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="DIA_DIEM" Header="Địa điểm" Width="130" DataIndex="DIA_DIEM">
                                                    </ext:Column>
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_XAY_RA" Width="100" Header="Ngày xảy ra"
                                                        DataIndex="NGAY_XAY_RA">
                                                    </ext:DateColumn>
                                                    <ext:Column ColumnID="THUONG_TAT" Width="100" Header="Thương tật" DataIndex="THUONG_TAT">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="THIET_HAI" Width="130" Header="Thiệt hại" DataIndex="THIET_HAI">
                                                    </ext:Column>
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayBoiThuong" Width="100" Header="Ngày bồi thường"
                                                        DataIndex="NgayBoiThuong">
                                                    </ext:DateColumn>
                                                    <ext:Column ColumnID="BOI_THUONG" Width="130" Header="Bồi thường" DataIndex="BOI_THUONG">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="GHI_CHU" Width="150" Header="Ghi chú" DataIndex="GHI_CHU">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelTaiNanLaoDong" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="btnDeleteRecord.enable();btnEditRecord.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="EditTaiNanLaoDong();" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="pnl_TepTinDinhKem" Title="Tệp tin đính kèm" runat="server" Closable="true"
                                    Hidden="true" CloseAction="Hide" Layout="BorderLayout">
                                    <Items>
                                        <ext:Hidden ID="hdfTepTinDinhKem" runat="server" Text="changed" />
                                        <ext:GridPanel ID="grpTepTinDinhKem" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoExpandColumn="TenTepTin" AutoScroll="true" AnchorHorizontal="100%"
                                            Height="200" Region="Center">
                                            <TopBar>
                                                <ext:Toolbar runat="server" ID="tbpnlTepTinDinhKem">
                                                    <Items>
                                                        <ext:Button ID="btnDownloadFile" Disabled="true" runat="server" Text="Tải về" Icon="Attach">
                                                            <DirectEvents>
                                                                <Click OnEvent="btnDownloadAttachFile_Click" IsUpload="true">
                                                                    <ExtraParams>
                                                                        <ext:Parameter Name="AttachFile" Mode="Raw" Value="RowSelectionModelTepTinDinhKem.getSelected().data.Link">
                                                                        </ext:Parameter>
                                                                    </ExtraParams>
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </TopBar>
                                            <Store>
                                                <ext:Store ID="grpTepTinDinhKemStore" AutoSave="true" AutoLoad="true" OnBeforeStoreChanged="HandleChangesDelete"
                                                    OnRefreshData="grpTepTinDinhKemStore_OnRefreshData" runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="PR_KEY">
                                                            <Fields>
                                                                <ext:RecordField Name="PR_KEY" />
                                                                <ext:RecordField Name="TenTepTin" />
                                                                <ext:RecordField Name="Link" />
                                                                <ext:RecordField Name="GhiChu" />
                                                                <ext:RecordField Name="SizeKB" />
                                                                <ext:RecordField Name="CreatedDate" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel17" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                                    <ext:Column ColumnID="TenTepTin" Width="200" Header="Tên tệp tin" DataIndex="TenTepTin" />
                                                    <ext:Column ColumnID="SizeKB" Width="100" Header="Dung lượng(KB)" DataIndex="SizeKB" />
                                                    <ext:Column ColumnID="GhiChu" Width="300" Header="Ghi chú" DataIndex="GhiChu" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Width="100" Header="Ngày tạo"
                                                        DataIndex="CreatedDate" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModelTepTinDinhKem" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btnEditRecord}.enable();btnDeleteRecord.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="EditTepTinDinhKem();" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                    <Listeners>
                                        <Close Handler="#{MenuItemAttachFile}.setDisabled(false);" />
                                        <Activate Handler="
                                           if (#{hdfTepTinDinhKem}.getValue() == 'changed') {
                                            #{grpTepTinDinhKemStore}.reload();
                                            #{hdfTepTinDinhKem}.setValue('');
                                           }" />
                                    </Listeners>
                                </ext:Panel>
                            </Items>
                            <BottomBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button ID="CloseTab1" runat="server" Text="Thông tin thêm" Icon="Information">
                                            <Menu>
                                                <ext:Menu runat="server" ID="menuAddMoreTab">
                                                    <Items>
                                                        <%--                                                        <ext:MenuItem ID="mnuDaiBieu" runat="server" Text="1.Đại biểu">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_DaiBieu});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuDeTai" runat="server" Text="2.Đề tài">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_DeTai});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>--%>
                                                        <ext:MenuItem ID="mnuKhaNang" runat="server" Text="1.Khả năng">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_KhaNang});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuKhenThuong" runat="server" Text="2.Khen thưởng">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_KhenThuong});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <%--                                                        <ext:MenuItem ID="mnuKyLuat" runat="server" Text="3.Kỷ luật" Hidden="true">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{panelKiLuat});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>--%>
                                                        <ext:MenuItem ID="mnuQuanHeGiaDinh" runat="server" Text="3.Quan hệ gia đình">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_QuanHeGiaDinh});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuQuaTrinhCongTac" runat="server" Text="4.Quá trình công tác">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{panelQuaTrinhCongTac});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuQuaTrinhDieuChuyen" runat="server" Text="5.Quá trình điều chuyển">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{panelQuaTrinhDieuChuyen});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTaiSan" runat="server" Text="6.Tài sản">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_TaiSan});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItemAttachFile" runat="server" Text="7.Tệp tin đính kèm">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_TepTinDinhKem});this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItemHocTap" runat="server" Text="8.Quá trình học tập">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_QuaTrinhHocTap});this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItemKNLV" runat="server" Text="9.Kinh nghiệm làm việc">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_KinhNghiemLamViec});this.setDisabled(true);StoreKinhNghiemLamViec.reload();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItemBangCapChungChi" runat="server" Text="10.Bằng cấp chứng chỉ">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{pnl_BangCapChungChi});this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTaiNanLaoDong" runat="server" Text="11.Tai nạn lao động">
                                                            <Listeners>
                                                                <Click Handler="#{TabBottomPanel}.addTab(#{panelTaiNanLaoDong});
                                                                                    this.setDisabled(true);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                        <ext:Button Text="Thêm mới" Disabled="true" runat="server" ID="btnAddRecordInDetailTable"
                                            Icon="Add">
                                            <Listeners>
                                                <Click Handler="if(#{hdf_PR_KEY}.getValue() != '')
                                                    {
                                                        AddRecordClick(#{TabBottomPanel});
                                                    }else
                                                    {
                                                        alert('Bạn phải điền đủ thông tin sau đó ấn cập nhật thì mới có thể thêm mới thông tin này !');
                                                    }" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button Text="Xóa" Disabled="true" runat="server" ID="btnDeleteRecord" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="DeleteRecordOnGrid(#{TabBottomPanel});" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button Text="Sửa" Disabled="true" runat="server" ID="btnEditRecord" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="EditClick(#{TabBottomPanel});" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button Text="Nhân đôi" Disabled="true" runat="server" Hidden="true" ID="btnDuplicateRecord"
                                            Icon="DiskMultiple">
                                            <Listeners>
                                                <Click Handler="CopyRecord(#{TabBottomPanel});" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </BottomBar>
                        </ext:TabPanel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
