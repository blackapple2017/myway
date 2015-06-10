<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modules_HoSoNhanSu_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="SouthHoSoNhanSu.ascx" TagName="SouthHoSoNhanSu" TagPrefix="uc1" %>
<%@ Register Src="../Base/ExcelReader/ExcelReader.ascx" TagName="ExcelReader" TagPrefix="uc3" %>
<%@ Register Src="CapNhatAnhHangLoat.ascx" TagName="CapNhatAnhHangLoat" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="CSS.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript" src="../Home/js/jquery.min.js"></script>
    <script type="text/javascript" src="../../Resource/js/global.js"></script>
    <script src="JScript.js" type="text/javascript"></script>
    <script src="ValidateInputForm.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfAnhDaiDien" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfSelectedDepartment" />
        <ext:Hidden runat="server" ID="hdfQuery" />
        <ext:Hidden runat="server" ID="hdfIsChuaCoAnh" Text="false" />
        <ext:Hidden runat="server" ID="hdfQueryReport" />
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
        <ext:Store runat="server" ID="cbx_diadiemlamviec_Store" AutoLoad="false">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="SearchDanhMucHandler.ashx">
                </ext:HttpProxy>
            </Proxy>
            <BaseParams>
                <ext:Parameter Name="table" Value="DM_DIADIEMLAMVIEC" Mode="Value">
                </ext:Parameter>
                <ext:Parameter Name="ma" Value="MA_DIADIEM" Mode="Value">
                </ext:Parameter>
                <ext:Parameter Name="ten" Value="TEN_DIADIEM" Mode="Value">
                </ext:Parameter>
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
        <ext:Window runat="server" Title="Thêm danh mục" Icon="Add" Layout="BorderLayout"
            Width="550" Modal="true" Hidden="true" Padding="6" Height="350" Constrain="true"
            ID="wdAddCategory" Resizable="true">
            <TopBar>
                <ext:Toolbar runat="server">
                    <Items>
                        <ext:Button runat="server" ID="btnAddCategory" Text="Thêm mới" Icon="Add">
                            <Listeners>
                                <Click Handler="btnAddCategory.disable(); txtMaDM.show(); txtTenDM.show(); btnSave.show(); btnCancel.show(); txtMaDM.focus();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnDeleteCategory" Text="Xóa" Icon="Delete" Disabled="true">
                            <DirectEvents>
                                <Click OnEvent="btnDeleteCategory_Click">
                                    <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa?"
                                        ConfirmRequest="true" />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:ToolbarSeparator runat="server" />
                        <ext:TextField runat="server" ID="txtMaDM" FieldLabel="Mã" Width="150" LabelWidth="40"
                            Hidden="true" MaxLength="20" MaskRe="/[a-z|A-Z|0-9|\_|\-|\ ]/" />
                        <ext:ToolbarSpacer Width="5" />
                        <ext:TextField runat="server" ID="txtTenDM" FieldLabel="Tên" Width="150" LabelWidth="40"
                            Hidden="true" MaxLength="100" />
                        <ext:ToolbarSpacer Width="5" />
                        <ext:Button runat="server" ID="btnSave" Text="Lưu" Icon="Disk" Hidden="true">
                            <Listeners>
                                <Click Handler="return checkInputCategory();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnSave_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnCancel" Text="Hủy" Icon="Cancel" Hidden="true">
                            <Listeners>
                                <Click Handler="resetInputCategory();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Items>
                <ext:Hidden runat="server" ID="hdfTableDM" />
                <ext:Hidden runat="server" ID="hdfColMa" />
                <ext:Hidden runat="server" ID="hdfColTen" />
                <ext:Hidden runat="server" ID="hdfCurrentCategory" />
                <ext:GridPanel ID="grpCategory" runat="server" Border="false" TrackMouseOver="true"
                    StripeRows="true" AutoExpandColumn="CateName" Region="Center">
                    <Store>
                        <ext:Store ID="stCategory" runat="server" AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="start" Value="={20}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="table" Value="hdfTableDM.getValue()" Mode="Raw" />
                                <ext:Parameter Name="ma" Value="hdfColMa.getValue()" Mode="Raw" />
                                <ext:Parameter Name="ten" Value="hdfColTen.getValue()" Mode="Raw" />
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
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:Column ColumnID="Company" Header="Mã danh mục" Width="100" DataIndex="MA" />
                            <ext:Column Header="Tên danh mục" ColumnID="CateName" Width="175" DataIndex="TEN">
                                <Editor>
                                    <ext:TextField runat="server" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelCategory" runat="server">
                            <Listeners>
                                <RowSelect Handler="btnDeleteCategory.enable();" />
                                <RowDeselect Handler="btnDeleteCategory.disable();" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <AfterEdit Fn="afterEditCategory" />
                    </Listeners>
                    <LoadMask ShowMask="true" />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="20">
                            <Listeners>
                                <Change Handler="RowSelectionModelCategory.clearSelections();" />
                            </Listeners>
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
            <Listeners>
                <Hide Handler="btnCancel.hide(); btnSave.hide(); txtMaDM.reset(); txtTenDM.reset(); txtTenDM.hide(); txtMaDM.hide(); btnAddCategory.enable();" />
                <BeforeShow Handler="beforeShowWdCategory();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý chọn" Icon="Accept">
                    <Listeners>
                        <Click Handler="if(CheckSelectedRows(grpCategory)){selectedCategory();}" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAddCategory.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuAdd" runat="server" Icon="Add" Text="<%$ Resources:HOSO, add%>">
                    <Listeners>
                        <Click Handler="#{hdfCommandButton}.setValue('Insert');#{wdInputEmployee}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="<%$ Resources:HOSO, edit%>">
                    <Listeners>
                        <Click Handler="return CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu});" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnEdit_Click" Before="#{hdfCommandButton}.setValue('Edit');">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuDelete" runat="server" Icon="Delete" Text="<%$ Resources:HOSO, delete%>">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(grp_HoSoNhanSu, store_HoSoNhanSu)" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem ID="mnuBaoCao" runat="server" Icon="Printer" Text="<%$ Resources:HOSO, report%>">
                    <Menu>
                        <ext:Menu runat="server">
                            <Items>
                                <ext:MenuItem runat="server" ID="mnuBaoCaoThongTinHoSo" Icon="PrinterGo" Text="<%$ Resources:HOSO, Profile_information%>">
                                    <Listeners>
                                        <Click Handler="if (CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu}) == false) {return;} else {#{hdfTypeReport}.setValue('HoSo'); wdShowReport.show();}" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" ID="mnuBaoCaoTaiSanCapPhat" Text=" <%$ Resources:HOSO, Asset_Allocation%>"
                                    Icon="PrinterGo">
                                    <Listeners>
                                        <Click Handler="if (CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu}) == false) {return;} else {#{hdfTypeReport}.setValue('TaiSan'); wdShowReport.show();}" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuTienIch" runat="server" Icon="Build" Text="<%$ Resources:HOSO, utility%>">
                    <Menu>
                        <ext:Menu runat="server">
                            <Items>
                                <ext:MenuItem ID="mnuNhanDoi" runat="server" Icon="DiskMultiple" Text="<%$ Resources:HOSO, Double_data%>">
                                    <Listeners>
                                        <Click Handler="if (hdfRecordID.getValue() == '') { alert('Bạn chưa chọn cán bộ nào'); return false; }" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="mnuNhanDoiDuLieu_Click" Before="#{btnUpdateEdit}.hide();#{btn_InsertandClose}.show();#{btnCapNhat}.show();">
                                            <EventMask ShowMask="true" Msg="<%$ Resources:HOSO, Loading%>" />
                                        </Click>
                                    </DirectEvents>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuNhapExcel" runat="server" Icon="PageExcel" Text="<%$ Resources:HOSO, enter_from_excel%>"
                                    Hidden="true">
                                    <Listeners>
                                        <Click Handler="ExcelReader1_wdImportDataFromExcel.show();#{wdNhapTuExcel}.show();" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuCapNhatAnh" runat="server" Icon="Image" Hidden="true" Text="<%$ Resources:HOSO, mass_update_image%>">
                                    <Listeners>
                                        <Click Handler="CapNhatAnhHangLoat1_wdCapNhatAnhHangLoat.show(); tb.hide();SouthHoSoNhanSu1_Toolbar1sdsds.hide();" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window runat="server" Title="<%$ Resources:HOSO, Select_Image%>" Resizable="false"
            Icon="ImageAdd" Hidden="true" Padding="6" ID="wdUploadImageWindow" Width="400"
            Modal="true" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="frmPanelUploadImage">
                    <Items>
                        <ext:Hidden runat="server" Text="~/Modules/NhanSu/ImageNhanSu" ID="hdfImageFolder" />
                        <ext:Hidden runat="server" ID="hdfColumnName" />
                        <ext:FileUploadField runat="server" ID="fufUploadControl" AllowBlank="false" RegexText="<%$ Resources:HOSO, Formats_file_is_not_valid%>"
                            Regex="(http(s?):)|([/|.|\w|\s])*\.(?:jpg|gif|png|bmp|jpeg|JPG|PNG|GIF|BMP|JPEG)"
                            AnchorHorizontal="100%" FieldLabel="<%$ Resources:HOSO, Select_Image%>">
                            <Listeners>
                                <FileSelected Handler="if (#{frmPanelUploadImage}.getForm().isValid()){#{btnAccept}.enable();}else{Ext.Msg.alert('<asp:Literal runat=\'server\' Text=\'<%$ Resources:HOSO, notify%>\' />','<asp:Literal runat=\'server\' Text=\'<%$ Resources:HOSO, Formats_file_is_not_valid%>\' />, <asp:Literal runat=\'server\' Text=\'<%$ Resources:HOSO, software_only_accept_image%>\' />');#{btnAccept}.disable();}" />
                            </Listeners>
                        </ext:FileUploadField>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnAccept" Text="<%$ Resources:HOSO, Accept%>" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnAccept_Click">
                            <EventMask ShowMask="true" Msg="<%$ Resources:HOSO, Please_wait%>" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="<%$ Resources:HOSO, close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdUploadImageWindow}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{btnAccept}.disable();" />
                <Hide Handler="fufUploadControl.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window Width="1000" ID="wdInputEmployee" AutoHeight="true" Maximizable="true"
            runat="server" Hidden="true" Icon="Add" Modal="true" Resizable="true" Constrain="true"
            Title="Nhập thông tin hồ sơ" Layout="FormLayout" EnableViewState="false">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommandButton" Text="Insert" />
                <ext:TabPanel Border="false" runat="server" Cls="bkGround" Padding="6" ID="tab_hosonhansu"
                    Height="485" DeferredRender="false">
                    <Items>
                        <ext:Panel ID="pnl_HoSoNhanSu" Title="<%$ Resources:HOSO, HR_profile%>" runat="server"
                            AutoHeight="true" AnchorHorizontal="100%" Border="false" TabIndex="0">
                            <Items>
                                <ext:Container runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                                    <Items>
                                        <ext:FieldSet ID="fs_hosonhansu" runat="server" Title="<%$ Resources:HOSO, personal_information%>"
                                            Layout="ColumnLayout" Height="180">
                                            <Items>
                                                <ext:Container runat="server" Height="180" ID="Container23" ColumnWidth=".14">
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
                                                        <ext:Hidden runat="server" ID="hdfMaCB" />
                                                        <ext:TextField ID="txt_macb" runat="server" FieldLabel="<%$ Resources:HOSO, MaCanBo%>"
                                                            CtCls="requiredData" AllowBlank="false" TabIndex="1" AnchorHorizontal="98%" MaxLength="20"
                                                            MaxLengthText="Bạn chỉ được nhập tối đa 20 ký tự">
                                                            <Listeners>
                                                                <Blur Handler="hdfMaCB.setValue(txt_macb.getValue());" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:TextField ID="txt_sohieucbccvc" runat="server" FieldLabel="<%$ Resources:HOSO, SoHieuCanBo%>"
                                                            AllowBlank="true" TabIndex="2" MaxLength="50" MaxLengthText="<%$ Resources:HOSO, maximum_characters%>"
                                                            AnchorHorizontal="98%">
                                                        </ext:TextField>
                                                        <ext:TextField ID="txt_hoten" runat="server" CtCls="requiredData" FieldLabel="<%$ Resources:HOSO, staff_name_required%>"
                                                            AllowBlank="false" TabIndex="3" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="<%$ Resources:HOSO, maximum_characters%>">
                                                            <Listeners>
                                                                <Blur Handler="ChuanHoaTen(#{txt_hoten});" />
                                                            </Listeners>
                                                            <ToolTips>
                                                                <ext:ToolTip ID="ToolTip2" runat="server" Title="<%$ Resources:HOSO, guide%>" Html="Phần mềm sẽ tự động chuẩn hóa họ và tên của bạn. Ví dụ: bạn nhập nguyễn văn huy, kết quả trả về Nguyễn Văn Huy." />
                                                            </ToolTips>
                                                        </ext:TextField>
                                                        <ext:TextField ID="txt_bidanh1" FieldLabel="Bí danh" runat="server" AllowBlank="true"
                                                            Hidden="true" TabIndex="4" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="<%$ Resources:HOSO, maximum_characters%>">
                                                        </ext:TextField>
                                                        <ext:DateField runat="server" ID="dfNgaySinh" CtCls="requiredData" FieldLabel="<%$ Resources:HOSO, staff_birthday_required%>"
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
                                                <ext:Container runat="server" Height="180" ID="Container1" ColumnWidth=".29" Layout="FormLayout">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txt_machamcong" FieldLabel="Mã chấm công" AnchorHorizontal="98%"
                                                            TabIndex="9" MaxLength="20">
                                                        </ext:TextField>
                                                        <ext:TextField ID="txt_quequan" runat="server" FieldLabel="Quê quán" AnchorHorizontal="98%"
                                                            TabIndex="10" MaxLength="1000">
                                                        </ext:TextField>
                                                        <ext:TextField ID="txt_noisinh" runat="server" FieldLabel="Nơi sinh" AllowBlank="true"
                                                            TabIndex="11" AnchorHorizontal="98%" MaxLength="1000">
                                                        </ext:TextField>
                                                        <ext:Hidden runat="server" ID="hdfQuocTich" />
                                                        <ext:ComboBox runat="server" ID="cbx_quoctich" FieldLabel="Quốc tịch<span style='color:red;'>*</span>"
                                                            CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%"
                                                            ListWidth="250" TabIndex="12" Editable="true" ItemSelector="div.list-item" PageSize="15"
                                                            LoadingText="<%$ Resources:HOSO, Loading%>" EmptyText="Gõ để tìm kiếm">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                <Focus Handler="cbx_quoctich_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();hdfQuocTich.setValue(cbx_quoctich.getValue());#{cbx_tinhthanh_Store}.reload();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }
                                                                                        if (index == 1) { showWdAddCategory('QuocTich'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden runat="server" ID="hdfTinhThanh" />
                                                        <ext:ComboBox runat="server" ID="cbx_tinhthanh" FieldLabel="Tỉnh thành" DisplayField="TEN"
                                                            MinChars="1" EmptyText="Gõ để tìm kiếm" ValueField="MA" AnchorHorizontal="98%" ListWidth="250"
                                                            TabIndex="13" Editable="true" ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                <Focus Handler="if (#{cbx_quoctich}.getValue() == '') {#{cbx_tinhthanh_Store}.removeAll(); alert('Bạn phải chọn quốc tịch trước');} else {#{cbx_tinhthanh_Store}.reload();}" />
                                                                <Select Handler="this.triggers[0].show();hdfTinhThanh.setValue(cbx_tinhthanh.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }
                                                                                        if (index == 1) { showWdAddCategory('TinhThanh'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden runat="server" ID="hdfDanToc" />
                                                        <ext:ComboBox runat="server" ID="cbx_dantoc" FieldLabel="Dân tộc<span style='color:red;'>*</span>"
                                                            CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%" ListWidth="250"
                                                            EmptyText="Gõ để tìm kiếm" TabIndex="14" ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                <Focus Handler="cbx_dantoc_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();hdfDanToc.setValue(cbx_dantoc.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }
                                                                                        if (index == 1) { showWdAddCategory('DanToc'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" Height="180" ID="Container2" ColumnWidth=".28" Layout="FormLayout">
                                                    <Items>
                                                        <ext:Hidden runat="server" ID="hdfTonGiao" />
                                                        <ext:ComboBox runat="server" ID="cbx_tongiao" MinChars="1" FieldLabel="Tôn giáo" ListWidth="250"
                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="15" Editable="false"
                                                            ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <ext:Store runat="server" ID="cbx_tongiao_Store" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                                                    </Proxy>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="table" Value="DM_TONGIAO" Mode="Value" />
                                                                        <ext:Parameter Name="ma" Value="MA_TONGIAO" Mode="Value" />
                                                                        <ext:Parameter Name="ten" Value="TEN_TONGIAO" Mode="Value" />
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
                                                                <Focus Handler="cbx_tongiao_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();hdfTonGiao.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfTonGiao.reset(); }
                                                                                        if (index == 1) { showWdAddCategory('TonGiao'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden runat="server" ID="hdfHonNhan" />
                                                        <ext:ComboBox runat="server" ID="cbx_tthonnhan" FieldLabel="TT Hôn nhân<span style='color:red;'>*</span>"
                                                            CtCls="requiredData" DisplayField="TEN" ValueField="MA" EmptyText="Tình trạng hôn nhân"
                                                            MinChars="1" AnchorHorizontal="100%" TabIndex="16" ItemSelector="div.list-item"
                                                            Editable="true" AllowBlank="false">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <ext:Store runat="server" ID="cbx_tthonnhan_Store" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                                                    </Proxy>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="table" Value="DM_TT_HN" Mode="Value" />
                                                                        <ext:Parameter Name="ma" Value="MA_TT_HN" Mode="Value" />
                                                                        <ext:Parameter Name="ten" Value="TEN_TT_HN" Mode="Value" />
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
                                                                <Focus Handler="cbx_tthonnhan_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();hdfHonNhan.setValue(cbx_tthonnhan.getValue());" />
                                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }
                                                                                        if (index == 1) { showWdAddCategory('TinhTrangHonNhan'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden runat="server" ID="hdfThanhPhanBanThan" />
                                                        <ext:ComboBox runat="server" ID="cbx_tpbanthan" FieldLabel="TP bản thân" EmptyText="Thành phần bản thân"
                                                            MinChars="1" DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="17"
                                                            ItemSelector="div.list-item" Editable="true">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <ext:Store runat="server" ID="cbx_tpbanthan_Store" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                                                    </Proxy>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="table" Value="DM_TP_BANTHAN" Mode="Value" />
                                                                        <ext:Parameter Name="ma" Value="MA_TP_BANTHAN" Mode="Value" />
                                                                        <ext:Parameter Name="ten" Value="TEN_TP_BANTHAN" Mode="Value" />
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
                                                                <Focus Handler="cbx_tpbanthan_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); hdfThanhPhanBanThan.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfThanhPhanBanThan.reset();}
                                                                                        if (index == 1) { showWdAddCategory('ThanhPhanBanThan'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden runat="server" ID="hdfThanhPhanGiaDinh" />
                                                        <ext:ComboBox runat="server" ID="cbx_tpgiadinh" EmptyText="Thành phần gia đình" FieldLabel="TP gia đình"
                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="18" ItemSelector="div.list-item"
                                                            MinChars="1">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <ext:Store runat="server" ID="cbx_tpgiadinh_Store" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                                                    </Proxy>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="table" Value="DM_TP_GIADINH" Mode="Value" />
                                                                        <ext:Parameter Name="ma" Value="MA_TP_GIADINH" Mode="Value" />
                                                                        <ext:Parameter Name="ten" Value="TEN_TP_GIADINH" Mode="Value" />
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
                                                                <Focus Handler="cbx_tpgiadinh_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); hdfThanhPhanGiaDinh.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfThanhPhanGiaDinh.reset(); }
                                                                                        if (index == 1) { showWdAddCategory('ThanhPhanGiaDinh'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:FieldSet>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="contan1" runat="server" Height="153" AnchorHorizontal="100%" Layout="ColumnLayout">
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
                                                                    AllowBlank="true" TabIndex="20" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_dtcoquan" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Điện thoại CQ"
                                                                    TabIndex="21" AnchorHorizontal="98%" MaxLength="22" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_dtnha" FieldLabel="Điện thoại nhà" MaskRe="/[0-9\.]/" runat="server"
                                                                    AllowBlank="true" TabIndex="23" AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="FormLayout" ID="ctn105" ColumnWidth=".5" LabelWidth="62">
                                                            <Items>
                                                                <ext:TextField ID="txt_email" runat="server" FieldLabel="<%$ Resources:HOSO, EmailNoiBo%>"
                                                                    AllowBlank="true" TabIndex="24" AnchorHorizontal="100%" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
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
                                                    runat="server" FieldLabel="Trường đào tạo" PageSize="15" ItemSelector="div.search-item"
                                                    MinChars="1" EmptyText="gõ để tìm kiếm" ID="cbxTruongDaoTao" LoadingText="Đang tải dữ liệu..."
                                                    TabIndex="26">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        <ext:FieldTrigger Icon="SimpleAdd" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="Store3" runat="server" AutoLoad="false">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                    <Template ID="Template19" runat="server">
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
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfMaTruongDaoTao.reset(); }
                                                                                if (index == 1) { showWdAddCategory('TruongDaoTao'); this.collapse(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:Hidden runat="server" ID="hdfMaChuyenNganh" />
                                                <ext:ComboBox AnchorHorizontal="100%" ValueField="MA" DisplayField="TEN" runat="server"
                                                    FieldLabel="Chuyên ngành" PageSize="15" HideTrigger="false" ItemSelector="div.search-item"
                                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ID="cbxChuyenNganh" LoadingText="Đang tải dữ liệu..."
                                                    TabIndex="27">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        <ext:FieldTrigger Icon="SimpleAdd" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="cbxChuyenNganhStore" runat="server" AutoLoad="false">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                        <ext:ToolTip runat="server" ID="ToolTip3" Title="Hướng dẫn" Html="Nhập tên chuyên ngành để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                    </ToolTips>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show(); hdfMaChuyenNganh.setValue(cbxChuyenNganh.getValue());" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfMaChuyenNganh.reset(); }
                                                                                if (index == 1) { showWdAddCategory('ChuyenNganh'); this.collapse(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:Container runat="server" ID="ctn100" Layout="ColumnLayout" AnchorHorizontal="100%"
                                                    Height="150">
                                                    <Items>
                                                        <ext:Container runat="server" Height="150" ID="ctn101" ColumnWidth=".5" Layout="FormLayout">
                                                            <Items>
                                                                <ext:Hidden runat="server" ID="hdfXepLoai" />
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
                                                                        <Focus Handler="cbx_xeploai_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();hdfXepLoai.setValue(cbx_xeploai.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfXepLoai.reset(); }
                                                                                                if (index == 1) { showWdAddCategory('XepLoai'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="hdfTinHoc" />
                                                                <ext:ComboBox runat="server" ID="cbx_tinhoc" FieldLabel="Tin học" DisplayField="TEN"
                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="29" Editable="false" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_tinhoc_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();hdfTinHoc.setValue(cbx_tinhoc.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfTinHoc.reset(); }
                                                                                                if (index == 1) { showWdAddCategory('TinHoc'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="hdfNgoaiNgu" />
                                                                <ext:ComboBox runat="server" ID="cbx_ngoaingu" FieldLabel="Ngoại ngữ" DisplayField="TEN"
                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="30" Editable="false" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_ngoaingu_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();hdfNgoaiNgu.setValue(cbx_ngoaingu.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfNgoaiNgu.reset(); }
                                                                                                if (index == 1) { showWdAddCategory('NgoaiNgu'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Height="150" ID="ctn102" ColumnWidth=".5" Layout="FormLayout">
                                                            <Items>
                                                                <ext:NumberField ID="tf_namtotnghiep" runat="server" FieldLabel="Năm tốt nghiệp"
                                                                    AllowBlank="true" TabIndex="31" AnchorHorizontal="100%" MaxLength="4" MinLength="4">
                                                                </ext:NumberField>
                                                                <ext:Hidden runat="server" ID="hdfTrinhDo" />
                                                                <ext:ComboBox runat="server" ID="cbx_trinhdo" FieldLabel="Trình độ" DisplayField="TEN"
                                                                    MinChars="1" ValueField="MA" AnchorHorizontal="100%" TabIndex="32" Editable="false"
                                                                    ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <ext:Store runat="server" ID="cbx_trinhdo_Store" AutoLoad="false">
                                                                            <Proxy>
                                                                                <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                                                            </Proxy>
                                                                            <BaseParams>
                                                                                <ext:Parameter Name="table" Value="DM_TRINHDO" Mode="Value" />
                                                                                <ext:Parameter Name="ma" Value="MA_TRINHDO" Mode="Value" />
                                                                                <ext:Parameter Name="ten" Value="TEN_TRINHDO" Mode="Value" />
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
                                                                        <Focus Handler="cbx_trinhdo_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();hdfTrinhDo.setValue(cbx_trinhdo.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }
                                                                                                if (index == 1) { showWdAddCategory('TrinhDo'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="tdVanHoa" />
                                                                <ext:ComboBox runat="server" ID="cbx_tdvanhoa" FieldLabel="TĐ văn hóa" DisplayField="TEN"
                                                                    ValueField="MA" AnchorHorizontal="100%" TabIndex="33" Editable="false" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_tdvanhoa_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();tdVanHoa.setValue(cbx_tdvanhoa.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }
                                                                                                if (index == 1) { showWdAddCategory('TrinhDoVanHoa'); this.collapse(); }" />
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
                                        <ext:FieldSet ID="FieldSet3" runat="server" Title="Thông tin công việc" Height="102"
                                            Layout="ColumnLayout">
                                            <Items>
                                                <ext:Container runat="server" Height="75" ID="Container7" Layout="FormLayout" ColumnWidth=".5">
                                                    <Items>
                                                        <ext:Hidden runat="server" ID="hdfBoPhan" />
                                                        <ext:ComboBox runat="server" ID="cbx_bophan" FieldLabel="Bộ phận<span style='color:red;'>*</span>"
                                                            CtCls="requiredData" DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..."
                                                            ItemSelector="div.list-item" AnchorHorizontal="98%" TabIndex="33" Editable="false"
                                                            AllowBlank="false">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template37" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                              <div class="list-item"> 
                                                                        <tpl if="MA &gt; '-a'">{TEN}</tpl>
                                                                        <tpl if="MA &lt; 0"><span class='lineThrough'>{TEN}</span></tpl> 
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
                                                                <Focus Handler="cbx_bophan_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); if (cbx_bophan.getValue() <= 0) {alert('Bạn không có quyền thao tác với bộ phận này!'); cbx_bophan.reset();}else{hdfBoPhan.setValue(cbx_bophan.getValue());}" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Container runat="server" AutoHeight="true" ID="Container8" Layout="ColumnLayout"
                                                            ColumnWidth=".5" AnchorHorizontal="98%">
                                                            <Items>
                                                                <ext:Container runat="server" ColumnWidth="0.5" Height="180" Layout="FormLayout">
                                                                    <Items>
                                                                        <ext:DateField Editable="true" ID="date_tuyendau" Vtype="daterange" FieldLabel="Ngày thử việc"
                                                                            runat="server" AnchorHorizontal="98%" TabIndex="34" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ngaynhanct}.setMinValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:TextField runat="server" ID="txtSoNgayHocViec" FieldLabel="<%$ Resources:HOSO, SoNgayHocViec%>"
                                                                            AnchorHorizontal="98%" MaskRe="/[0-9]/" MaxLength="10">
                                                                        </ext:TextField>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container runat="server" ColumnWidth="0.5" Height="180" Layout="FormLayout"
                                                                    LabelWidth="105">
                                                                    <Items>
                                                                        <%--date_ngaynhanct--%>
                                                                        <ext:DateField Editable="true" ID="date_ngaynhanct" FieldLabel="Ngày chính thức"
                                                                            runat="server" AnchorHorizontal="100%" TabIndex="35" MaskRe="/[0-9|/]/" Format="d/M/yyyy"
                                                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                                <%-- #{date_tuyendau}.setMaxValue(); #{date_nghi}.setMinValue(); --%>
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:TextField runat="server" ID="txtThoiGianThuViec" FieldLabel="<%$ Resources:HOSO, ThoiGianThuViec%>"
                                                                            AnchorHorizontal="100%" MaskRe="/[0-9]/" MaxLength="10">
                                                                        </ext:TextField>
                                                                    </Items>
                                                                </ext:Container>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".5">
                                                    <Items>
                                                        <ext:Container runat="server" Layout="ColumnLayout" Height="75">
                                                            <Items>
                                                                <ext:Container ID="Container9" runat="server" ColumnWidth=".52" Layout="FormLayout"
                                                                    LabelWidth="115">
                                                                    <Items>
                                                                        <ext:Hidden runat="server" ID="hdfChucVu" />
                                                                        <ext:ComboBox runat="server" ID="cbx_chucvu" FieldLabel="Chức vụ" DisplayField="TEN"
                                                                            PageSize="15" MinChars="1" ValueField="MA" AnchorHorizontal="98%" TabIndex="37" 
                                                                            Editable="true" ItemSelector="div.list-item" EmptyText="Gõ để tìm kiếm" ListWidth="220"
                                                                            LoadingText="Đang tải dữ liệu">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                                <Focus Handler="cbx_chucvu_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfChucVu.setValue(cbx_chucvu.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChucVu.reset(); }
                                                                                                        if (index == 1) { showWdAddCategory('ChucVu'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:Hidden runat="server" ID="hdfHinhThucLamViec" />
                                                                        <ext:ComboBox runat="server" ID="cbxHinhThucLamViec" FieldLabel="Hình thức làm việc<span style='color:red;'>*</span>"
                                                                            CtCls="requiredData" DisplayField="Value" ValueField="ID" LoadingText="Đang tải dữ liệu..."
                                                                            ItemSelector="div.list-item" AnchorHorizontal="98%" TabIndex="33" Editable="false"
                                                                            AllowBlank="false">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Template ID="Template38" runat="server">
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
                                                                                <Focus Handler="cbxHinhThucLamViec_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();hdfHinhThucLamViec.setValue(cbxHinhThucLamViec.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:Hidden runat="server" ID="hdfHTTuyenDung" />
                                                                        <ext:ComboBox runat="server" ID="cbx_httuyen" FieldLabel="Đơn vị ký hợp đồng" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="98%" TabIndex="81" Editable="false" ItemSelector="div.list-item"
                                                                            StoreID="cbx_httuyen_Store">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                            <Listeners>
                                                                                <Focus Handler="cbx_httuyen_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show();hdfHTTuyenDung.setValue(this.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfHTTuyenDung.reset(); }
                                                                                                            if (index == 1) { showWdAddCategory('HTTuyenDung'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:Container>
                                                                <ext:Container ID="Container10" runat="server" ColumnWidth=".48" Layout="FormLayout">
                                                                    <Items>
                                                                        <ext:Hidden runat="server" ID="hdfViTriCongViec" />
                                                                        <ext:ComboBox runat="server" ID="cbx_congviec" FieldLabel="Vị trí công việc" DisplayField="TEN"
                                                                            ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
                                                                            AnchorHorizontal="100%" TabIndex="38" Editable="true" ListWidth="150" AllowBlank="false"
                                                                            PageSize="15" MinChars="1" EmptyText="Gõ để tìm kiếm">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                                <ext:ToolTip runat="server" ID="ToolTip6" Title="Hướng dẫn" Html="Nhập tên vị trí công việc để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                            </ToolTips>
                                                                            <Listeners>
                                                                                <Focus Handler="cbx_congviec_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfViTriCongViec.setValue(cbx_congviec.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfViTriCongViec.reset(); }
                                                                                                        if (index == 1) { showWdAddCategory('CongViec'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:TextField runat="server" EmptyText="Kinh nghiệm trước khi vào công ty" ID="cbx_congtrinh"
                                                                            FieldLabel="Kinh nghiệm" AnchorHorizontal="100%" TabIndex="39">
                                                                            <ToolTips>
                                                                                <ext:ToolTip runat="server" Title="Hướng dẫn" Html="Số năm kinh nghiệm trước khi vào công ty">
                                                                                </ext:ToolTip>
                                                                            </ToolTips>
                                                                        </ext:TextField>
                                                                        <ext:Hidden runat="server" ID="hdfBiDanh" />
                                                                        <ext:ComboBox runat="server" ID="txt_bidanh" FieldLabel="Địa điểm làm việc" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="81" ItemSelector="div.list-item"
                                                                            StoreID="cbx_diadiemlamviec_Store">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
                                                                            </Triggers>
                                                                            <Template ID="Template21" runat="server">
                                                                                <Html>
                                                                                    <tpl for=".">
						                                                                <div class="list-item"> 
							                                                                {TEN}
						                                                                </div>
					                                                                </tpl>
                                                                                </Html>
                                                                            </Template>
                                                                            <Listeners>
                                                                                <Focus Handler="cbx_diadiemlamviec_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfBiDanh.setValue(txt_bidanh.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfBiDanh.reset();}
                                                                                                        if (index == 1) { showWdAddCategory('DiaDiemLamViec'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
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
                            AutoHeight="true" AnchorHorizontal="100%" Border="false" TabIndex="1">
                            <Items>
                                <ext:Container runat="server" Layout="ColumnLayout" AnchorHorizontal="100%" AutoHeight="true">
                                    <Items>
                                        <ext:Container runat="server" ColumnWidth="0.65" Layout="FormLayout" AutoHeight="true"
                                            Height="410">
                                            <Items>
                                                <ext:FieldSet runat="server" Layout="ColumnLayout" Title="Thông tin bảo hiểm" AutoHeight="true"
                                                    AnchorHorizontal="99%">
                                                    <Items>
                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="130">
                                                            <Items>
                                                                <ext:TextField ID="txt_sothebhyt" runat="server" CtCls="requiredDataWG" FieldLabel="Số thẻ BHYT"
                                                                    AllowBlank="true" TabIndex="40" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                </ext:TextField>
                                                                <ext:DateField runat="server" ID="dfNgayDongBHYT" CtCls="requiredData" FieldLabel="Ngày đóng BHYT"
                                                                    AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayHetHanBHYT}.setMinValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:DateField runat="server" ID="dfNgayHetHanBHYT" CtCls="requiredData" FieldLabel="Hết hạn BHYT"
                                                                    AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayDongBHYT}.setMaxValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:Hidden runat="server" ID="hdfNoiKhamChuaBenh" />
                                                                <ext:ComboBox runat="server" ID="cbx_noikcb" CtCls="requiredData" FieldLabel="Nơi khám bệnh"
                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="98%" TabIndex="47" Editable="true"
                                                                    ListWidth="200" MinChars="1" ItemSelector="div.list-item" EmptyText="Gõ tên để tìm kiếm"
                                                                    PageSize="15" LoadingText="Đang tải dữ liệu...">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                        <ext:ToolTip runat="server" ID="ToolTip5" Title="Hướng dẫn" Html="Nhập tên nơi khám chữa bệnh để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                    </ToolTips>
                                                                    <Listeners>
                                                                        <Focus Handler="cbx_noikcb_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show(); hdfNoiKhamChuaBenh.setValue(this.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfNoiKhamChuaBenh.reset();}
                                                                                                    if (index == 1) { showWdAddCategory('NoiKhamChuaBenh'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:TextField ID="txt_tiledongbh" runat="server" CtCls="requiredDataWG" FieldLabel="Tỷ lệ đóng BH"
                                                                    AllowBlank="true" TabIndex="48" AnchorHorizontal="98%" MaxLength="50" MaskRe="/[0-9|%]/">
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="130">
                                                            <Items>
                                                                <ext:TextField ID="txt_sothebhxh" CtCls="requiredDataWG" runat="server" FieldLabel="Số thẻ BHXH"
                                                                    AllowBlank="true" TabIndex="49" AnchorHorizontal="100%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                </ext:TextField>
                                                                <ext:Hidden runat="server" ID="hdfNoiCapBHXH" />
                                                                <ext:ComboBox runat="server" ID="cbx_noicapbhxh" CtCls="requiredDataWG" FieldLabel="Nơi cấp BHXH"
                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="50" Editable="false"
                                                                    ListWidth="200" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_noicapbhxh_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();hdfNoiCapBHXH.setValue(this.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfNoiCapBHXH.reset();}
                                                                                                    if (index == 1) { showWdAddCategory('NoiCapBHXH'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:DateField runat="server" ID="dfNgayCapBHXH" CtCls="requiredDataWG" FieldLabel="Ngày cấp BHXH"
                                                                    AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ketthucbh}.setMinValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:Hidden runat="server" ID="hdfHuongChinhSach" />
                                                                <ext:ComboBox runat="server" ID="cbx_huongcs" FieldLabel="Dạng chính sách" DisplayField="TEN"
                                                                    ValueField="MA" AnchorHorizontal="100%" TabIndex="54" Editable="false" ListWidth="200"
                                                                    ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_huongcs_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show();hdfHuongChinhSach.setValue(this.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfHuongChinhSach.reset(); }
                                                                                               if (index == 1) { showWdAddCategory('HuongChinhSach'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:DateField Editable="true" ID="date_ketthucbh" CtCls="requiredDataWG" EmptyText="Ngày kết thúc bảo hiểm"
                                                                    FieldLabel="Kết thúc BH" runat="server" AnchorHorizontal="100%" TabIndex="55"
                                                                    MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayCapBHXH}.setMaxValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:FieldSet>
                                                <ext:FieldSet runat="server" Layout="ColumnLayout" Title="Chứng minh nhân dân - Hộ chiếu"
                                                    AutoHeight="true" AnchorHorizontal="99%">
                                                    <Items>
                                                        <ext:Container ID="Container17" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                                                            Height="100">
                                                            <Items>
                                                                <ext:TextField ID="txt_socmnd" CtCls="requiredDataWG" runat="server" MaskRe="/[0-9\.]/"
                                                                    FieldLabel="Số CMND" AllowBlank="true" TabIndex="56" AnchorHorizontal="98%" MaxLength="12"
                                                                    MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                </ext:TextField>
                                                                <ext:DateField Editable="true" ID="date_capcmnd" CtCls="requiredDataWG" FieldLabel="Ngày cấp CMND"
                                                                    runat="server" AnchorHorizontal="98%" TabIndex="57" MaskRe="/[0-9|/]/" Format="d/M/yyyy"
                                                                    Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:Hidden runat="server" ID="hdfNoiCapCMND" />
                                                                <ext:ComboBox runat="server" ID="cbx_noicapcmnd" CtCls="requiredDataWG" FieldLabel="Nơi cấp CMND"
                                                                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="98%" TabIndex="58" Editable="true"
                                                                    ListWidth="200" MinChars="1" ItemSelector="div.list-item" PageSize="15" LoadingText="Đang tải dữ liệu..."
                                                                    EmptyText="Gõ để tìm kiếm">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                                                                        <ext:ToolTip runat="server" ID="ToolTip4" Title="Hướng dẫn" Html="Nhập tên nơi cấp CMND để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                                                    </ToolTips>
                                                                    <Listeners>
                                                                        <Focus Handler="cbx_noicapcmnd_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show(); hdfNoiCapCMND.setValue(this.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfNoiCapCMND.reset(); }
                                                                                                if (index == 1) { showWdAddCategory('NoiCapCMND'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="100">
                                                            <Items>
                                                                <ext:TextField ID="txt_sohochieu" runat="server" FieldLabel="Số hộ chiếu" AllowBlank="true"
                                                                    TabIndex="59" AnchorHorizontal="100%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                </ext:TextField>
                                                                <ext:DateField Editable="true" ID="date_ngaycaphc" EmptyText="Ngày cấp hộ chiếu"
                                                                    FieldLabel="Ngày cấp HC" runat="server" AnchorHorizontal="100%" TabIndex="60"
                                                                    Vtype="daterange" MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày không đúng">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{date_hethanhc}.setMinValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:DateField Editable="true" ID="date_hethanhc" FieldLabel="Hết hạn hộ chiếu" runat="server"
                                                                    AnchorHorizontal="100%" TabIndex="61" Vtype="daterange" MaskRe="/[0-9|/]/" Format="d/M/yyyy"
                                                                    Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ngaycaphc}.setMaxValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:Hidden runat="server" ID="hdfNoiCapHoChieu" />
                                                                <ext:ComboBox runat="server" ID="cbx_noicaphc" FieldLabel="Nơi cấp hộ chiếu" DisplayField="TEN"
                                                                    ValueField="MA" AnchorHorizontal="100%" EmptyText="Nơi cấp hộ chiếu" TabIndex="62"
                                                                    Editable="false" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_noicaphc_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show(); hdfNoiCapHoChieu.setValue(this.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfNoiCapHoChieu.reset(); }
                                                                                                if (index == 1) { showWdAddCategory('NoiCapHoChieu'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:FieldSet>
                                                <ext:FieldSet runat="server" Layout="ColumnLayout" Title="Thông tin đoàn thể" AutoHeight="true"
                                                    AnchorHorizontal="99%">
                                                    <Items>
                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="75">
                                                            <Items>
                                                                <ext:DateField Editable="true" ID="date_ngayvaodoan" FieldLabel="Ngày vào Đoàn" runat="server"
                                                                    AnchorHorizontal="98%" TabIndex="63" MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                    RegexText="Định dạng ngày không đúng">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:DateField>
                                                                <ext:Hidden runat="server" ID="hdfChucVuDoan" />
                                                                <ext:ComboBox runat="server" ID="cbx_chucvudoan" FieldLabel="Chức vụ Đoàn" DisplayField="TEN"
                                                                    ValueField="MA" AnchorHorizontal="98%" TabIndex="64" Editable="false" ListWidth="200"
                                                                    ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                        <Focus Handler="cbx_chucvudoan_Store.reload();" />
                                                                        <Select Handler="this.triggers[0].show(); hdfChucVuDoan.setValue(this.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfChucVuDoan.reset(); }
                                                                                                if (index == 1) { showWdAddCategory('ChucVuDoan'); this.collapse(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:TextField ID="txt_noiketnapdoan" runat="server" FieldLabel="Nơi kết nạp Đoàn"
                                                                    AnchorHorizontal="98%" AllowBlank="true" TabIndex="65" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="75">
                                                            <Items>
                                                                <ext:DateField Editable="true" ID="date_vaocongdoan" FieldLabel="Ngày vào công đoàn"
                                                                    runat="server" AnchorHorizontal="100%" TabIndex="66" MaskRe="/[0-9|/]/" Format="d/M/yyyy"
                                                                    Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Listeners>
                                                                        <Select Handler="this.triggers[0].show();" />
                                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
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
                                            Title="Thông tin chính trị" Height="405">
                                            <Items>
                                                <ext:Container runat="server" Layout="FormLayout" AnchorHorizontal="100%" Height="210"
                                                    LabelWidth="125">
                                                    <Items>
                                                        <ext:Hidden runat="server" ID="hdfLyLuanChinhTri" />
                                                        <ext:ComboBox runat="server" ID="cbx_trinhdochinhtri" FieldLabel="Trình độ chính trị"
                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="68" Editable="false"
                                                            ListWidth="200" ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <Focus Handler="cbx_trinhdochinhtri_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show();hdfLyLuanChinhTri.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfLyLuanChinhTri.reset(); }
                                                                                        if (index == 1) { showWdAddCategory('TrinhDoChinhTri'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:DateField Editable="true" ID="date_thamgiacm" FieldLabel="Tham gia cách mạng"
                                                            runat="server" EmptyText="Ngày tham gia cách mạng" AnchorHorizontal="100%" TabIndex="69"
                                                            MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày không đúng">
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
                                                        <ext:DateField Editable="true" ID="date_vaodang" FieldLabel="Ngày vào đảng" runat="server"
                                                            AnchorHorizontal="100%" TabIndex="71" Disabled="true" Vtype="daterange" MaskRe="/[0-9|/]/"
                                                            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày không đúng">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ngayvaodangct}.setMinValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:DateField Editable="true" ID="date_ngayvaodangct" FieldLabel="Vào Đảng chính thức"
                                                            runat="server" AnchorHorizontal="100%" TabIndex="72" Disabled="true" Vtype="daterange"
                                                            MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày không đúng">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_vaodang}.setMaxValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:TextField ID="txt_noiketnapdang" runat="server" FieldLabel="Nơi kết nạp Đảng"
                                                            Disabled="true" AllowBlank="true" TabIndex="73" AnchorHorizontal="100%" MaxLength="50"
                                                            MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                        </ext:TextField>
                                                        <ext:Hidden runat="server" ID="hdfChucVuDang" />
                                                        <ext:ComboBox runat="server" ID="cbx_chuvudang" FieldLabel="Chức vụ đảng" DisplayField="TEN"
                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="74" Editable="false" ItemSelector="div.list-item"
                                                            Disabled="true">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <Focus Handler="cbx_chuvudang_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); hdfChucVuDang.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChucVuDang.reset();}
                                                                                        if (index == 1) { showWdAddCategory('ChucVuDang'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txt_noisinhhoatdang" FieldLabel="Nơi sinh hoạt"
                                                            EmptyText="Nơi sinh hoạt Đảng" AnchorHorizontal="100%" Disabled="true" TabIndex="75" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" Layout="FormLayout" AnchorHorizontal="100%" Height="130"
                                                    LabelWidth="125">
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
                                                        <ext:DateField Editable="true" ID="date_nhapngu" FieldLabel="Ngày nhập ngũ" runat="server"
                                                            AnchorHorizontal="100%" TabIndex="77" Disabled="true" Vtype="daterange" MaskRe="/[0-9|/]/"
                                                            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                            RegexText="Định dạng ngày không đúng">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_xuatngu}.setMinValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:DateField Editable="true" ID="date_xuatngu" FieldLabel="Ngày xuất ngũ" runat="server"
                                                            AnchorHorizontal="100%" TabIndex="78" Disabled="true" MaskRe="/[0-9|/]/" Format="d/M/yyyy"
                                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_nhapngu}.setMaxValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:Hidden runat="server" ID="hdfQuanHamCaoNhat" />
                                                        <ext:ComboBox runat="server" ID="cbx_bacquandoi" FieldLabel="Bậc quân đội" DisplayField="TEN"
                                                            EmptyText="Ví dụ Đại tá, thiếu úy..." ValueField="MA" AnchorHorizontal="100%"
                                                            TabIndex="79" Editable="false" ItemSelector="div.list-item" Disabled="true">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <Focus Handler="cbx_bacquandoi_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); hdfQuanHamCaoNhat.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfQuanHamCaoNhat.reset(); }
                                                                                        if (index == 1) { showWdAddCategory('CapBacQuanDoi'); this.collapse(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden runat="server" ID="hdfChucVuQuanDoi" />
                                                        <ext:ComboBox runat="server" ID="cbx_chucvuquandoi" FieldLabel="Chức vụ quân đội"
                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="80" Editable="false"
                                                            Disabled="true" ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                <Focus Handler="cbx_chucvuquandoi_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); hdfChucVuQuanDoi.setValue(this.getValue());" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChucVuQuanDoi.reset();}
                                                                                        if (index == 1) { showWdAddCategory('ChucVuQuanDoi'); this.collapse(); }" />
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
                                <ext:Container runat="server" AutoHeight="true" AnchorHorizontal="100%" Layout="ColumnLayout">
                                    <Items>
                                        <ext:Container runat="server" ColumnWidth="0.67" Layout="FormLayout">
                                            <Items>
                                                <ext:Container runat="server" Layout="ColumnLayout" Height="220">
                                                    <Items>
                                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" Height="210">
                                                            <Items>
                                                                <ext:FieldSet runat="server" AnchorHorizontal="98%" Title="Thông tin công việc khác"
                                                                    Layout="FormLayout" Height="213">
                                                                    <Items>
                                                                        <ext:DateField Editable="true" ID="date_bonhiemcv" FieldLabel="Ngày BNCV" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="82" MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                            RegexText="Định dạng ngày không đúng">
                                                                            <ToolTips>
                                                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="Hướng dẫn" Html="Ngày bổ nhiệm chức vụ">
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
                                                                        <ext:Hidden runat="server" ID="hdfNgach" />
                                                                        <ext:ComboBox runat="server" ID="cbx_ngach" FieldLabel="Ngạch" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="83" Editable="false" ItemSelector="div.list-item">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <Focus Handler="cbx_ngach_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfNgach.setValue(this.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfNgach.reset(); }
                                                                                                        if (index == 1) { showWdAddCategory('Ngach'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:DateField Editable="true" ID="date_bnngach" FieldLabel="Bổ nhiệm ngạch" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="84" MaskRe="/[0-9|/]/" Format="d/M/yyyy" EmptyText="Ngày bổ nhiệm ngạch"
                                                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:Hidden runat="server" ID="hdfQuanLyNhaNuoc" />
                                                                        <ext:ComboBox runat="server" ID="cbx_trinhdoquanly" FieldLabel="Trình độ QL" DisplayField="TEN"
                                                                            ValueField="MA" AnchorHorizontal="100%" TabIndex="85" Editable="false" ItemSelector="div.list-item">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <Focus Handler="cbx_trinhdoquanly_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfQuanLyNhaNuoc.setValue(this.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfQuanLyNhaNuoc.reset();}
                                                                                                         if (index == 1) { showWdAddCategory('TrinhDoQuanLy'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:Hidden runat="server" ID="hdfTrinhDoQLKT" />
                                                                        <ext:ComboBox runat="server" ID="cbx_trinhdoquanlykt" FieldLabel="Trình độ QLKT"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="86" Editable="false"
                                                                            ItemSelector="div.list-item">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <Focus Handler="cbx_trinhdoquanlykt_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfTrinhDoQLKT.setValue(this.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfTrinhDoQLKT.reset(); }
                                                                                                        if (index == 1) { showWdAddCategory('TrinhDoQuanLyKT'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:TextField runat="server" ID="txt_username" FieldLabel="Tên đăng nhập" AnchorHorizontal="100%"
                                                                            EnableKeyEvents="true" TabIndex="87" Disabled="true">
                                                                        </ext:TextField>
                                                                    </Items>
                                                                </ext:FieldSet>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container ID="Container11" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                                            <Items>
                                                                <ext:FieldSet runat="server" AnchorHorizontal="98%" Title="Thông tin tài khoản ngân hàng"
                                                                    Layout="FormLayout" Height="102">
                                                                    <Items>
                                                                        <ext:TextField ID="txt_sotaikhoan" CtCls="requiredData" runat="server" FieldLabel="Số tài khoản"
                                                                            AnchorHorizontal="100%" AllowBlank="true" TabIndex="88" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự"
                                                                            EmptyText="Số tài khoản ngân hàng">
                                                                        </ext:TextField>
                                                                        <ext:Hidden runat="server" ID="hdfNganHang" />
                                                                        <ext:ComboBox runat="server" ID="cbx_nganhang" CtCls="requiredData" FieldLabel="Ngân hàng"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="89" Editable="false"
                                                                            ItemSelector="div.list-item">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <Focus Handler="cbx_nganhang_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfNganHang.setValue(cbx_nganhang.getValue()); " />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfNganHang.reset(); }
                                                                                                        if (index == 1) { showWdAddCategory('NganHang'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                        <ext:TextField ID="txt_masothuecanhan" CtCls="requiredData" runat="server" FieldLabel="Mã số thuế"
                                                                            EmptyText="Mã số thuế cá nhân" AllowBlank="true" TabIndex="90" AnchorHorizontal="100%"
                                                                            MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                                        </ext:TextField>
                                                                    </Items>
                                                                </ext:FieldSet>
                                                                <ext:FieldSet runat="server" AnchorHorizontal="98%" Title="Thông tin thôi việc" Layout="FormLayout"
                                                                    Height="102">
                                                                    <Items>
                                                                        <ext:Checkbox ID="chk_danghi" FieldLabel="Đã thôi việc" runat="server" TabIndex="91">
                                                                            <Listeners>
                                                                                <Check Handler="if(#{chk_danghi}.checked==true){
                                                                                     #{date_nghi}.enable();
                                                                                     #{cbx_lydonghi}.enable();
                                                                               }
                                                                               else{
                                                                                    #{date_nghi}.disable();
                                                                                    #{cbx_lydonghi}.disable();
                                                                               }
                                                                               " />
                                                                            </Listeners>
                                                                        </ext:Checkbox>
                                                                        <ext:DateField ID="date_nghi" Disabled="true" FieldLabel="Ngày thôi việc" runat="server"
                                                                            AnchorHorizontal="100%" TabIndex="92" MaskRe="/[0-9|/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                                            RegexText="Định dạng ngày không đúng">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="false" />
                                                                            </Triggers>
                                                                            <Listeners>
                                                                                <Select Handler="this.triggers[0].show();" />
                                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{date_ngaynhanct}.setMaxValue(); this.triggers[0].hide(); }" />
                                                                            </Listeners>
                                                                        </ext:DateField>
                                                                        <ext:Hidden runat="server" ID="hdfLyDoNghiViec" />
                                                                        <ext:ComboBox runat="server" ID="cbx_lydonghi" Disabled="true" FieldLabel="Lý do thôi việc"
                                                                            DisplayField="TEN" ValueField="MA" AnchorHorizontal="100%" TabIndex="93" Editable="false">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
                                                                            </Triggers>
                                                                            <Store>
                                                                                <ext:Store runat="server" ID="cbx_lydonghi_Store" AutoLoad="false" OnRefreshData="cbx_lydonghi_Store_OnRefreshData">
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
                                                                                <Focus Handler="cbx_lydonghi_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfLyDoNghiViec.setValue(this.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfLyDoNghiViec.reset(); }
                                                                                                            if (index == 1) { showWdAddCategory('LyDoNghiViec'); this.collapse(); }" />
                                                                            </Listeners>
                                                                        </ext:ComboBox>
                                                                    </Items>
                                                                </ext:FieldSet>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" Layout="FormLayout" Height="200">
                                                    <Items>
                                                        <ext:FieldSet ID="FieldSet4" runat="server" Layout="FormLayout" Title="Thông tin khác"
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
                                                <ext:Container runat="server" ID="Container16" Layout="ColumnLayout" AnchorHorizontal="100%"
                                                    Height="220">
                                                    <Items>
                                                        <ext:Container runat="server" ID="Container18" Layout="FormLayout" ColumnWidth="1"
                                                            Height="210">
                                                            <Items>
                                                                <ext:FieldSet ID="FieldSet5" runat="server" Title="Thông tin sức khỏe" Layout="FormLayout"
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
                                                                        <ext:CompositeField ID="CompositeField4" runat="server" AnchorHorizontal="100%" FieldLabel="Cao/Cân nặng">
                                                                            <Items>
                                                                                <ext:NumberField runat="server" EmptyText="Cao" ID="txt_chieucao" Width="50" TabIndex="98" />
                                                                                <ext:DisplayField ID="DisplayField3" runat="server" Text="cm  /" />
                                                                                <ext:NumberField runat="server" ID="txt_cannang" EmptyText="Nặng" Width="50" TabIndex="99" />
                                                                                <ext:DisplayField ID="DisplayField4" runat="server" Text="Kg" />
                                                                            </Items>
                                                                        </ext:CompositeField>
                                                                        <ext:Hidden runat="server" ID="hdfTTSucKhoe" />
                                                                        <ext:ComboBox runat="server" ID="cbx_ttsuckhoe" FieldLabel="Tình trạng SK" DisplayField="TEN"
                                                                            ValueField="MA" EmptyText="Tình trạng sức khỏe" AnchorHorizontal="100%" TabIndex="100"
                                                                            ItemSelector="div.list-item" Editable="false">
                                                                            <Triggers>
                                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                                <ext:FieldTrigger Icon="SimpleAdd" />
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
                                                                                <Focus Handler="cbx_ttsuckhoe_Store.reload();" />
                                                                                <Select Handler="this.triggers[0].show(); hdfTTSucKhoe.setValue(this.getValue());" />
                                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfTTSucKhoe.reset(); }
                                                                                                        if (index == 1) { showWdAddCategory('TTSucKhoe'); this.collapse(); }" />
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
                                                <ext:Container runat="server" ID="Container15" Layout="FormLayout" AnchorHorizontal="100%">
                                                    <Items>
                                                        <ext:FieldSet runat="server" ID="FieldSet6" Title="Liên hệ trong trường hợp khẩn cấp"
                                                            Layout="FormLayout" AnchorHorizontal="100%">
                                                            <Items>
                                                                <ext:TextField ID="txt_nguoilienhe" CtCls="requiredDataWG" runat="server" FieldLabel="Người liên hệ"
                                                                    AnchorHorizontal="100%" AllowBlank="true" TabIndex="105" MaxLength="50" EmptyText="Họ và tên người liên hệ">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_sdtnguoilh" CtCls="requiredDataWG" MaskRe="/[0-9\.]/" runat="server"
                                                                    FieldLabel="SDT người LH" EmptyText="Số điện thoại người liên hệ" AnchorHorizontal="100%"
                                                                    TabIndex="106" MaxLength="50">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txtMoiQH" CtCls="requiredDataWG" runat="server" FieldLabel="Quan hệ với CB"
                                                                    EmptyText="Ví dụ: Bố, Mẹ, ..." AnchorHorizontal="100%" TabIndex="107" MaxLength="100">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_emailnguoilh" CtCls="requiredDataWG" runat="server" FieldLabel="Email"
                                                                    EmptyText="Email người liên hệ" AnchorHorizontal="100%" MaxLength="100" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                                    RegexText="Định dạng email không đúng" TabIndex="108">
                                                                </ext:TextField>
                                                                <ext:TextArea ID="txt_diachinguoilienhe" CtCls="requiredDataWG" runat="server" FieldLabel="Địa chỉ"
                                                                    AnchorHorizontal="100%" Height="40" MaxLength="1000" TabIndex="109">
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
            <Listeners>
                <BeforeShow Handler="if(#{hdfCommandButton}.getValue()=='Insert'){
                                           #{DirectMethods}.GeneratePrimaryKey();
                                           #{btnUpdateEdit}.hide();
                                           #{btn_InsertandClose}.show();
                                           #{btnCapNhat}.show();
                                         }else
                                         {
                                            #{btnUpdateEdit}.show();
                                            #{btn_InsertandClose}.hide();
                                            #{btnCapNhat}.hide();
                                         }; 
                                         " />
                <Hide Handler="ResetControl();txt_macb.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="btnCapNhat" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btn_InsertandClose_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Disk" Text="Cập nhật" ID="btnUpdateEdit">
                    <Listeners>
                        <Click Handler="return ValidateInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btn_InsertandClose_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btn_InsertandClose" runat="server" Text="Cập nhật & đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btn_InsertandClose_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button6" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdInputEmployee}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" ID="wdInputReportParameter"
            Constrain="true" Title="Tham số báo cáo" Padding="6" Resizable="false" Width="450"
            AutoHeight="true" Icon="Printer">
            <Items>
                <ext:TextField runat="server" Text="BÁO CÁO DANH SÁCH NHÂN SỰ" Width="420" ID="txtReportTitle"
                    CtCls="requiredData" FieldLabel="Tiêu đề báo cáo<span style='color:red;'>*</span>" />
                <ext:Container runat="server" Height="50" LabelAlign="Top" AnchorHorizontal="100%"
                    Layout="ColumnLayout">
                    <Items>
                        <ext:Container runat="server" Layout="FormLayout" LabelAlign="Top" ColumnWidth="0.33">
                            <Items>
                                <ext:TextField runat="server" ID="txtReportCreator" FieldLabel="Người lập" LabelAlign="Top"
                                    AnchorHorizontal="99%" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container3" runat="server" Layout="FormLayout" LabelAlign="Top"
                            ColumnWidth="0.33">
                            <Items>
                                <ext:TextField ID="txtRoomHeader" runat="server" LabelAlign="Top" FieldLabel="Trưởng phòng HCNS"
                                    AnchorHorizontal="99%" />
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container4" runat="server" Layout="FormLayout" LabelAlign="Top"
                            ColumnWidth="0.33">
                            <Items>
                                <ext:TextField ID="txtDirector" runat="server" LabelAlign="Top" FieldLabel="Tổng giám đốc"
                                    AnchorHorizontal="100%" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="btnShowReport" runat="server" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="if(txtReportTitle.getValue()==''){alert('Bạn chưa nhập tiêu đề báo cáo');return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnShowReport_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdInputReportParameter.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo hồ sơ nhân viên" Maximized="true" Icon="Printer">
            <Items>
                <ext:Hidden runat="server" ID="hdfTypeReport" />
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="ShowReportAction();" />
                <Hide Handler="hdfQueryReport.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Width="700" AutoHeight="true" runat="server" Modal="true" Icon="PageExcel"
            Constrain="true" Hidden="true" Title="Nhập từ Excel" ID="wdNhapTuExcel" Resizable="false">
            <Content>
                <uc3:ExcelReader ID="ExcelReader1" ExcelTemplateUrl="../HoSoNhanSu/ExcelMau/Mau_Ho_So_Nhan_Su.xls"
                    ExcelStoreFolder="../HoSoNhanSu/ExcelFile" MathRuleXmlUrl="../HoSoNhanSu/MathRule.xml"
                    DeleteExcelAfterInsert="true" PrimaryKeyName="PR_KEY" PrKeyIsAutoIncrement="true"
                    TableName="HOSO" MaxRecord="100" runat="server" />
            </Content>
        </ext:Window>
        <uc2:CapNhatAnhHangLoat ID="CapNhatAnhHangLoat1" runat="server" />
        <ext:Store ID="store_HoSoNhanSu" AutoLoad="true" runat="server">
            <Listeners>
                <Load Handler="checkboxSelection.clearSelections();hdfRecordID.reset();SouthHoSoNhanSu1_hdfRecordID.reset();" />
            </Listeners>
            <Proxy>
                <ext:HttpProxy Method="POST" Url="HandlerHoSoNhanSu.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfSelectedDepartment.getValue()" Mode="Raw" />
                <ext:Parameter Name="Query" Value="hdfQuery.getValue()" Mode="Raw" />
                <ext:Parameter Name="IsChuaCoAnh" Value="hdfIsChuaCoAnh.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="PR_KEY">
                    <Fields>
                        <ext:RecordField Name="PR_KEY" />
                        <ext:RecordField Name="MA_CB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="MA_GIOITINH" />
                        <ext:RecordField Name="NGAY_SINH" />
                        <ext:RecordField Name="TUOI" />
                        <ext:RecordField Name="TEN_TT_HN" />
                        <ext:RecordField Name="TEN_BOPHAN" />
                        <ext:RecordField Name="TEN_CHUCVU" />
                        <ext:RecordField Name="TEN_CONGVIEC" />
                        <ext:RecordField Name="TEN_TRINHDO" />
                        <ext:RecordField Name="TEN_CHUYENNGANH" />
                        <ext:RecordField Name="TEN_TINHTHANH" />
                        <ext:RecordField Name="HS_LUONG" />
                        <ext:RecordField Name="BAC_LUONG" />
                        <ext:RecordField Name="DIA_CHI_LH" />
                        <ext:RecordField Name="DI_DONG" />
                        <ext:RecordField Name="EMAIL" />
                        <ext:RecordField Name="DA_NGHI" />
                        <ext:RecordField Name="ThamNien" />
                        <%-- Thông tin cơ bản --%>
                        <ext:RecordField Name="PHOTO" />
                        <ext:RecordField Name="BI_DANH" />
                        <ext:RecordField Name="NGAY_TUYEN_DTIEN" />
                        <ext:RecordField Name="NGAY_TUYEN_CHINHTHUC" />
                        <ext:RecordField Name="NguoiLienHe" />
                        <ext:RecordField Name="QuanHeVoiCanBo" />
                        <ext:RecordField Name="SO_CMND" />
                        <ext:RecordField Name="NGAYCAP_CMND" />
                        <ext:RecordField Name="MA_NOICAP_CMND" />
                        <ext:RecordField Name="DT_CQUAN" />
                        <ext:RecordField Name="DT_NHA" />
                        <ext:RecordField Name="SDTNguoiLienHe" />
                        <ext:RecordField Name="SO_HOCHIEU" />
                        <ext:RecordField Name="NGAYCAP_HOCHIEU" />
                        <ext:RecordField Name="TEN_NOICAP_HOCHIEU" />
                        <ext:RecordField Name="TEN_NGACH" />
                        <ext:RecordField Name="TEN_LOAI_HDONG" />
                        <ext:RecordField Name="TEN_NOICAP_CMND" />
                        <ext:RecordField Name="TEN_HT_TUYENDUNG" />
                        <ext:RecordField Name="TEN_DIADIEM" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp" HideBorders="True">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel runat="server" ID="grp_HoSoNhanSu" StoreID="store_HoSoNhanSu" Border="false" EnableColumnMove="false"
                            StripeRows="True" TrackMouseOver="true" AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnAddNew" runat="server" Text="<%$ Resources:HOSO, add%>" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{hdfCommandButton}.setValue('Insert');#{wdInputEmployee}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="<%$ Resources:HOSO, edit%>"
                                            Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="return CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu});" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEdit_Click" Before="#{hdfCommandButton}.setValue('Edit');">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="<%$ Resources:HOSO, delete%>" Disabled="true"
                                            Icon="Delete">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert ('<%$ Resources:HOSO, no_selected_record%>'); return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation Title="<%$ Resources:HOSO, warning%>" Message="<%$ Resources:HOSO, are_you_sure%>"
                                                        ConfirmRequest="true" />
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnBaoCao" Icon="Printer" Text="Báo cáo">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <%--Báo cáo Hồ sơ nhân sự--%>
                                                        <ext:MenuItem runat="server" ID="mnuThongTinHoSo" Text="1. Thông tin hồ sơ" Icon="PrinterGo">
                                                            <Listeners>
                                                                <Click Handler="if (CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu}) == false) {return;} else {#{hdfTypeReport}.setValue('HoSo'); wdShowReport.show();}" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <%--Báo cáo Cấp phát tài sản--%>
                                                        <ext:MenuItem runat="server" ID="mnuTaiSanCapPhat" Text="2. Tài sản cấp phát" Icon="PrinterGo">
                                                            <Listeners>
                                                                <Click Handler="if (CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu}) == false) {return;} else {#{hdfTypeReport}.setValue('TaiSan'); wdShowReport.show();}" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <%--Báo cáo Danh sách nhân sự--%>
                                                        <ext:MenuItem runat="server" ID="MenuItem1" Text="3. Danh sách nhân sự" Icon="PrinterGo">
                                                            <Listeners>
                                                                <Click Handler="wdInputReportParameter.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="btnTienIchHoSo" runat="server" Text="Tiện ích" Icon="Build">
                                            <Menu>
                                                <ext:Menu ID="Menu4" runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="Nhân đôi dữ liệu"
                                                            Icon="DiskMultiple">
                                                            <Listeners>
                                                                <Click Handler="return CheckSelectedRecord(#{grp_HoSoNhanSu}, #{store_HoSoNhanSu});" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuNhanDoiDuLieu_Click" Before="#{btnUpdateEdit}.hide();#{btn_InsertandClose}.show();#{btnCapNhat}.show();">
                                                                    <EventMask ShowMask="true" Msg="Đang tải dữ liệu ..." />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuNhapTuExcel" Text="Nhập từ Excel" Hidden="false"
                                                            Icon="PageExcel">
                                                            <Listeners>
                                                                <Click Handler="ExcelReader1_wdImportDataFromExcel.show();#{wdNhapTuExcel}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="mnuCapNhatAnhHangLoat" Hidden="false" Text="Cập nhật ảnh hàng loạt"
                                                            Icon="Images">
                                                            <Listeners>
                                                                <Click Handler="CapNhatAnhHangLoat1_wdCapNhatAnhHangLoat.show(); tb.hide();SouthHoSoNhanSu1_Toolbar1sdsds.hide();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuExportAllNhanSu" Text="Xuất tất dữ liệu nhân sự" Icon="PageExcel" runat="server">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuExportAllNhanSu_Click">

                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập tên, mã cán bộ hoặc số CMND"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{store_HoSoNhanSu}.reload(); }" />
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
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv" LockText="Cố định cột này lại" UnlockText="Hủy cố định cột">
                                    <HeaderRows>
                                        <ext:HeaderRow>
                                            <Columns>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox ID="filterGioiTinh" runat="server" Width="50" SelectedIndex="0">
                                                            <Items>
                                                                <ext:ListItem Text="Tất cả" Value="" />
                                                                <ext:ListItem Text="Nam" Value="M" />
                                                                <ext:ListItem Text="Nữ" Value="F" />
                                                            </Items>
                                                            <Listeners>
                                                                <Select Handler="#{DirectMethods}.SetValueQuery();
                                                                        if (filterGioiTinh.getValue() == '') {$('#filterGioiTinh').removeClass('combo-selected');}
                                                                        else {$('#filterGioiTinh').addClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox ID="filterNgaySinh" Width="80" runat="server" Editable="true" DisplayField="TEN_NAMSINH"
                                                            ListWidth="250" PageSize="15" ValueField="NAM_SINH">
                                                            <Store>
                                                                <ext:Store runat="server" ID="filterNgaySinhStore" AutoLoad="False" OnRefreshData="filterNgaySinhStore_Store_OnRefreshData">
                                                                    <Reader>
                                                                        <ext:JsonReader IDProperty="NAM_SINH">
                                                                            <Fields>
                                                                                <ext:RecordField Name="NAM_SINH" />
                                                                                <ext:RecordField Name="TEN_NAMSINH" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                            <Listeners>
                                                                <Focus Handler="filterNgaySinhStore.reload();" />
                                                                <Select Handler="#{DirectMethods}.SetValueQuery();
                                                                    if (filterNgaySinh.getValue() == '-1') {$('#filterNgaySinh').removeClass('combo-selected');}
                                                                    else {$('#filterNgaySinh').addClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false" />
                                                <ext:HeaderColumn AutoWidthElement="false" />
                                                <ext:HeaderColumn AutoWidthElement="false" />
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterChucVu" DisplayField="TEN" ValueField="MA"
                                                            PageSize="15" Width="120" Editable="true" ListWidth="250" ItemSelector="div.list-item"
                                                            StoreID="cbx_chucvu_Store">
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
                                                                <Focus Handler="filterChucVu.store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterChucVu').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterChucVu').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterCongViec" DisplayField="TEN" ValueField="MA"
                                                            Width="120" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item"
                                                            StoreID="cbx_congviec_Store">
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
                                                                <Focus Handler="cbx_congviec_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterCongViec').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterCongViec').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:TextField runat="server" ID="filterThamNien" Width="130" EnableKeyEvents="true"
                                                            MaskRe="">
                                                            <Listeners>
                                                                <KeyPress Fn="enterKeyPressHandler1" />
                                                            </Listeners>
                                                            <ToolTips>
                                                                <ext:ToolTip runat="server" Title="Tìm kiếm thâm niên lớn hơn 6 tháng: Nhập >6<br>Tìm kiếm thâm niên từ 6 đến 8 tháng: Nhập 6-8" />
                                                            </ToolTips>
                                                        </ext:TextField>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterHTTuyenDung" DisplayField="TEN" ValueField="MA"
                                                            Width="130" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item"
                                                            StoreID="cbx_httuyen_Store">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template12" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Listeners>
                                                                <Focus Handler="cbx_httuyen_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterHTTuyenDung').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterHTTuyenDung').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterDiaDiemLamViec" DisplayField="TEN" ValueField="MA"
                                                            Width="130" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item"
                                                            StoreID="cbx_diadiemlamviec_Store">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template43" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Listeners>
                                                                <Focus Handler="cbx_diadiemlamviec_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterDiaDiemLamViec').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterDiaDiemLamViec').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterTrinhDo" DisplayField="TEN" ValueField="MA"
                                                            Width="130" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item"
                                                            StoreID="cbx_trinhdo_Store">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
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
                                                                <Focus Handler="cbx_trinhdo_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterTrinhDo').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterTrinhDo').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterChuyenNganh" DisplayField="TEN" ValueField="MA"
                                                            Width="150" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item"
                                                            StoreID="cbxChuyenNganhStore">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
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
                                                                <Focus Handler="cbxChuyenNganhStore.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterChuyenNganh').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterChuyenNganh').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterTinhThanh" DisplayField="TEN" ValueField="MA"
                                                            Width="90" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Store>
                                                                <ext:Store runat="server" ID="filterTinhThanhStore" AutoLoad="false" OnRefreshData="filterTinhThanhStore_OnRefreshData">
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
                                                            <Template ID="Template42" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Listeners>
                                                                <Focus Handler="filterTinhThanhStore.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterTinhThanh').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterTinhThanh').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox runat="server" ID="filterLoaiHopDong" DisplayField="TEN" ValueField="MA"
                                                            Width="250" Editable="true" ListWidth="250" PageSize="15" ItemSelector="div.list-item">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Store>
                                                                <ext:Store runat="server" ID="filterLoaiHopDong_Store" AutoLoad="false" OnRefreshData="filterLoaiHopDong_Store_OnRefreshData">
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
                                                                <Focus Handler="filterLoaiHopDong_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); #{DirectMethods}.SetValueQuery(); $('#filterLoaiHopDong').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{DirectMethods}.SetValueQuery(); 
                                                                    $('#filterLoaiHopDong').removeClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:TextField Width="300" ID="filterDiaChiLH" runat="server" EnableKeyEvents="true">
                                                            <Listeners>
                                                                <KeyPress Fn="enterKeyPressHandler1" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:TextField Width="100" ID="filterDiDong" runat="server" EnableKeyEvents="true"
                                                            MaskRe="[0-9|.,]">
                                                            <Listeners>
                                                                <KeyPress Fn="enterKeyPressHandler1" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:TextField Width="175" ID="filterEmail" runat="server" EnableKeyEvents="true">
                                                            <Listeners>
                                                                <KeyPress Fn="enterKeyPressHandler1" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn AutoWidthElement="false">
                                                    <Component>
                                                        <ext:ComboBox ID="filterDaNghi" runat="server" Width="100" SelectedIndex="0" Editable="false">
                                                            <Items>
                                                                <ext:ListItem Text="Tất cả" Value="-1" />
                                                                <ext:ListItem Text="Đang làm việc" Value="0" />
                                                                <ext:ListItem Text="Đã thôi việc" Value="1" />
                                                            </Items>
                                                            <SelectedItem Value="-1" />
                                                            <Listeners>
                                                                <Select Handler="#{DirectMethods}.SetValueQuery();
                                                                    if (filterDaNghi.getValue() == '0') {$('#filterDaNghi').removeClass('combo-selected');}
                                                                    else {$('#filterDaNghi').addClass('combo-selected');}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                            </Columns>
                                        </ext:HeaderRow>
                                    </HeaderRows>
                                </ext:LockingGridView>
                            </View>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Locked="True" Width="35" Header="STT" />
                                    <ext:Column ColumnID="MA_CB" Width="70" Locked="True" Header="Mã CBNV" DataIndex="MA_CB">
                                        <Renderer Fn="RenderHightLight" />
                                    </ext:Column>
                                    <ext:Column ColumnID="HO_TEN" Width="150" Locked="True" Header="Họ tên" DataIndex="HO_TEN">
                                        <Renderer Fn="RenderHightLight" />
                                    </ext:Column>
                                    <ext:Column ColumnID="MA_GIOITINH" Width="50" Header="Giới tính" DataIndex="MA_GIOITINH">
                                        <Renderer Fn="RenderGender" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NGAY_SINH" Format="dd/MM/yyyy" Width="80" Header="Ngày sinh"
                                        DataIndex="NGAY_SINH" />
                                    <ext:Column ColumnID="TUOI" DataIndex="TUOI" Width="50" Align="Right" Header="Tuổi">
                                        <Renderer Handler="return GetAge(record.data.NGAY_SINH)" />
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_TT_HN" Width="80" Header="Hôn nhân" DataIndex="TEN_TT_HN" />
                                    <ext:Column ColumnID="TEN_BOPHAN" Width="230" Header="Bộ phận" DataIndex="TEN_BOPHAN" />
                                    <ext:Column ColumnID="TEN_CHUCVU" Width="120" Header="Chức vụ" DataIndex="TEN_CHUCVU" />
                                    <ext:Column ColumnID="TEN_CONGVIEC" Width="120" Header="Vị trí công việc" DataIndex="TEN_CONGVIEC" />
                                    <ext:Column ColumnID="ThamNien" Width="130" Header="Thâm niên" DataIndex="ThamNien">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_HT_TUYENDUNG" Width="130" Header="Đơn vị ký hợp đồng" DataIndex="TEN_HT_TUYENDUNG" />
                                    <ext:Column ColumnID="TEN_DIADIEM" Width="130" Header="Địa điểm làm việc" DataIndex="TEN_DIADIEM" />
                                    <ext:Column ColumnID="TEN_TRINHDO" Width="130" Header="Trình độ" DataIndex="TEN_TRINHDO" />
                                    <ext:Column ColumnID="TEN_CHUYENNGANH" Width="150" Header="Chuyên ngành" DataIndex="TEN_CHUYENNGANH" />
                                    <ext:Column ColumnID="TEN_TINHTHANH" Width="90" Header="Tỉnh thành" DataIndex="TEN_TINHTHANH" />
                                    <ext:Column ColumnID="TEN_LOAI_HDONG" Width="250" Header="Loại hợp đồng" DataIndex="TEN_LOAI_HDONG" />
                                    <ext:Column ColumnID="DIA_CHI_LH" Width="300" Header="Chỗ ở hiện nay" DataIndex="DIA_CHI_LH" />
                                    <ext:Column ColumnID="DI_DONG" Width="100" Header="Di động" DataIndex="DI_DONG" />
                                    <ext:Column ColumnID="EMAIL" Width="175" Header="Email nội bộ" DataIndex="EMAIL" />
                                    <ext:Column ColumnID="DA_NGHI" Width="100" Align="Center" Header="Tình trạng" DataIndex="DA_NGHI">
                                        <Renderer Fn="GetMirrorBooleanIcon" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);
                                                            SouthHoSoNhanSu1_hdfRecordID.setValue(hdfRecordID.getValue());
                                                            ReloadStoreOfTabIndex();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                    PageSize="15" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>"
                                    FirstText="<%$ Resources:HOSO, first_page%>" DisplayMsg="<%$ Resources:HOSO, description_record%>"
                                    runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, page_size%>" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
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
                                            <SelectedItem Value="15" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Listeners>
                                        <Change Handler="checkboxSelection.clearSelections();hdfRecordID.reset();SouthHoSoNhanSu1_hdfRecordID.reset();
                                            try{btnEdit.disable();}catch(e){}try{btnDelete.disable();}catch(e)  {}" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" />
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grp_HoSoNhanSu}.getSelectionModel().selectRow(rowIndex);" />
                                <%-- <ViewReady Handler="ReloadStoreCombobox();" />--%>
                            </Listeners>
                        </ext:GridPanel>
                    </Center>
                    <South>
                        <ext:Panel runat="server" ID="fd" Height="220">
                            <Content>
                                <uc1:SouthHoSoNhanSu ID="SouthHoSoNhanSu1" runat="server" />
                            </Content>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
