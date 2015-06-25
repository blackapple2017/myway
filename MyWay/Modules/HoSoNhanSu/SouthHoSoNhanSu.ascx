<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SouthHoSoNhanSu.ascx.cs"
    Inherits="Modules_HoSoNhanSu_SouthHoSoNhanSu" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
<script src="../../Resource/js/JScript.js" type="text/javascript"></script>
<script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
<script src="../../Resource/js/UtilitiesJavascript.js" type="text/javascript"></script>
<script src="../../Resource/js/global.js" type="text/javascript"></script>
<script src="SouthHoSoNhanSuScript.js" type="text/javascript"></script>
<style type="text/css">
    .Download {
        background-image: url(../../Resource/images/download.png) !important;
    }
</style>
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
    var searchBoxKL = function () {
        SouthHoSoNhanSu1_hdfLyDoKLTemp.setValue(SouthHoSoNhanSu1_cbLyDoKyLuat.getRawValue());
        if (SouthHoSoNhanSu1_hdfIsDanhMucKL.getValue() == '1') {
            SouthHoSoNhanSu1_hdfIsDanhMucKL.setValue('2');
        }
        if (SouthHoSoNhanSu1_cbLyDoKyLuat.getRawValue() == '') {
            SouthHoSoNhanSu1_hdfIsDanhMucKL.reset();
        }
    }
    var prepare = function (grid, command, record, row, col, value) {
        if (record.data.TepTinDinhKem == '' && command.command == "Download") {
            command.hidden = true;
            command.hideMode = "visibility";
        }
    }
    var GetBooleanIconHSUV = function (value, p, record) {
        var sImageCheck = "<img  src='../../../Resource/Images/check.png'>"
        var sImageUnCheck = "<img src='../../../Resource/Images/uncheck.gif'>"
        if (value == "1") {
            return sImageCheck;
        } else if (value == "0") {
            return sImageUnCheck;
        }
        return "";
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
</script>
<ext:Hidden runat="server" ID="hdfButton" />
<ext:Hidden runat="server" ID="hdfMaDonViTinh" />
<ext:Hidden runat="server" ID="hdfTypeWindow" />
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
        <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdDonViTinh}.hide()" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{grpDonViTinh_Store}.reload();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdTheNganHang" AutoHeight="true" Width="400" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Thẻ ngân hàng">
    <Items>
        <ext:Hidden runat="server" ID="hdf_PrKeyHoSo" />
        <ext:Hidden runat="server" ID="hdf_LastUpdatedBy" />
        <ext:TextField runat="server" ID="nbf_ATMNumber" CtCls="requiredData" FieldLabel="Số tài khoản<span style='color:red;'>*</span>"
            AnchorHorizontal="100%" />
        <ext:ComboBox runat="server" Editable="true" ID="cb_BankID" DisplayField="TEN" MinChars="1" PageSize="15"
            CtCls="requiredData" ValueField="MA" FieldLabel="Ngân hàng<span style='color:red;'>*</span>"
            EmptyText="Chọn ngân hàng" AnchorHorizontal="100%">
            <Store>
                <ext:Store runat="server" ID="Storecb_BankID" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                    </Proxy>
                    <BaseParams>
                        <ext:Parameter Name="table" Value="DM_NH" Mode="Value" />
                        <ext:Parameter Name="ma" Value="MA_NH" Mode="Value" />
                        <ext:Parameter Name="ten" Value="TEN_NH" Mode="Value" />
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
            </Store>
            <Listeners>
                <Focus Handler="#{Storecb_BankID}.reload();" />
            </Listeners>
        </ext:ComboBox>
        <ext:TextArea runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%" ID="txt_Note" />
        <ext:Checkbox runat="server" FieldLabel="Trạng thái" BoxLabel="Đang được sử dụng"
            ID="chk_IsInUsed">
        </ext:Checkbox>
    </Items>
    <Listeners>
        <Hide Handler="resetWdTheNganHang();" />
    </Listeners>
    <Buttons>
        <ext:Button runat="server" ID="Button5" Hidden="true" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return validateWdTheNganHang();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateTheNganHang_Click">
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update" />
                    </ExtraParams>
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnUpdateTheNganHang" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return validateWdTheNganHang();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateTheNganHang_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="Button4" Text="Cập nhật & Đóng lại" Icon="Disk">
            <Listeners>
                <Click Handler="return validateWdTheNganHang();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateTheNganHang_Click">
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True" />
                    </ExtraParams>
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdTheNganHang}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<ext:Window ID="wdQuaTrinhDaoTao" AutoHeight="true" Width="590" runat="server" Padding="0"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Quá trình đào tạo">
    <Items>
        <ext:Hidden runat="server" ID="hdfIsLoadDanhSachKhoaHoc" />
        <ext:Hidden runat="server" ID="hdfSelectedKhoaHoc" />
        <ext:GridPanel ID="grp_DanhSachKhoaHoc" Border="false" runat="server" StripeRows="true"
            Title="Chọn khóa học" AnchorHorizontal="100%" Height="290" AutoExpandColumn="TenkeHoach">
            <Store>
                <ext:Store ID="grp_DanhSachKhoaHocStore" runat="server" OnRefreshData="grp_DanhSachKhoaHocStore_OnRefreshData">
                    <Reader>
                        <ext:JsonReader IDProperty="MaKeHoach">
                            <Fields>
                                <ext:RecordField Name="MaKeHoach" />
                                <ext:RecordField Name="TenkeHoach" />
                                <ext:RecordField Name="KinhPhiCongTyHoTro" />
                                <ext:RecordField Name="KinhPhiNhanVienDong" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel15" runat="server">
                <Columns>
                    <ext:RowNumbererColumn Header="STT" Width="30" />
                    <ext:Column ColumnID="MaKeHoach" Header="Mã" Width="50" DataIndex="MaKeHoach" />
                    <ext:Column Header="Kế hoạch đào tạo" Width="75" DataIndex="TenkeHoach" />
                    <ext:Column Header="Công ty hỗ trợ" Width="100" DataIndex="KinhPhiCongTyHoTro">
                        <Renderer Fn="RenderVND" />
                    </ext:Column>
                    <ext:Column Header="Nhân viên đóng" Width="100" DataIndex="KinhPhiNhanVienDong">
                        <Renderer Fn="RenderVND" />
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <SelectionModel>
                <ext:CheckboxSelectionModel ID="RowSelectionModel1" runat="server" />
            </SelectionModel>
            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu" />
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                </ext:PagingToolbar>
            </BottomBar>
        </ext:GridPanel>
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateDaoTao" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="SetSelectedKhoahoc(SouthHoSoNhanSu1_hdfSelectedKhoaHoc,SouthHoSoNhanSu1_grp_DanhSachKhoaHoc)" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateDaoTao_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button11" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdQuaTrinhDaoTao}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="if(#{hdfIsLoadDanhSachKhoaHoc}.getValue()==''){#{grp_DanhSachKhoaHocStore}.reload();#{hdfIsLoadDanhSachKhoaHoc}.setValue('True');}" />
        <Hide Handler="#{grp_DanhSachKhoaHocStore}.reload();#{grp_DanhSachKhoaHoc}.getSelectionModel().clearSelections();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdBaoHiem" AutoHeight="true" Width="540" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Bảo hiểm">
    <Items>
        <ext:Container ID="Container18" runat="server" Layout="Column" Height="106">
            <Items>
                <ext:Container ID="Container19" runat="server" LabelWidth="70" LabelAlign="left"
                    Layout="Form" ColumnWidth=".5">
                    <Items>
                        <ext:TextField ID="txtBHDonVi" runat="server" FieldLabel="Đơn vị<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="95%" MaxLength="500" />
                        <ext:DateField ID="dfBHTuNgay" runat="server" Vtype="daterange" FieldLabel="Từ ngày"
                            AnchorHorizontal="95%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                        <ext:NumberField ID="txtBHPhuCap" runat="server" FieldLabel="Phụ cấp" AnchorHorizontal="95%"
                            MaxLength="18" />
                        <ext:NumberField ID="txtBHMucLuong" runat="server" FieldLabel="Mức lương" AnchorHorizontal="95%"
                            MaxLength="18" />
                    </Items>
                </ext:Container>
                <ext:Container ID="Container4" runat="server" LabelAlign="left" LabelWidth="70" Layout="Form"
                    ColumnWidth=".5">
                    <Items>
                        <ext:ComboBox runat="server" Editable="true" ID="cbBHCongViec" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            AnchorHorizontal="100%" FieldLabel="Công việc<span style='color:red;'>*</span>"
                            CtCls="requiredData" ValueField="MA" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store runat="server" AutoLoad="false" ID="StoreCongViec">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                            </Store>
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
                                <Focus Handler="#{StoreCongViec}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DateField ID="dfBHDenNgay" runat="server" Vtype="daterange" FieldLabel="Đến ngày"
                            AnchorHorizontal="100%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                        <ext:TextField ID="txtBHHSLuong" runat="server" FieldLabel="Hệ số lương" AnchorHorizontal="100%"
                            MaskRe="/[0-9\.]/" AllowDecimals="true" AllowNegative="false" MaxLength="15" />
                        <ext:TextField ID="txtBHTyle" runat="server" FieldLabel="Tỷ lệ %" EmptyText="0-100"
                            MaskRe="/[0-9\.]/" MinValue="0" MaxValue="100" AnchorHorizontal="100%" MaxLength="3" />
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Container ID="Container21" runat="server" Layout="Column" Height="80">
            <Items>
                <ext:Container ID="Container22" runat="server" LabelWidth="70" LabelAlign="left"
                    Layout="Form" ColumnWidth="1">
                    <Items>
                        <ext:TextArea ID="txtBHGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                            MaxLength="500" />
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateCongViec" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputBaoHiem();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateCongViec_Click" After="ResetWdBaoHiem();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnEditBaoHiem" Hidden="true" Icon="Disk" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputBaoHiem();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateCongViec_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCNVaDongBaoHiem" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputBaoHiem();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateCongViec_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button9" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdBaoHiem}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="#{btnUpdateCongViec}.show();#{btnEditBaoHiem}.hide();#{btnCNVaDongBaoHiem}.show();ResetWdBaoHiem();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdDaiBieu" AutoHeight="true" Width="490" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Đại biểu">
    <Items>
        <ext:Container ID="Container5" runat="server" Layout="Column" Height="55">
            <Items>
                <ext:Container ID="Container6" runat="server" LabelWidth="100" LabelAlign="left"
                    Layout="Form" ColumnWidth=".5">
                    <Items>
                        <ext:TextField ID="txtDBLoaiHinh" FieldLabel="Loại hình<span style='color:red;'>*</span>"
                            AnchorHorizontal="95%" runat="server" MaxLength="500" CtCls="requiredData" />
                        <ext:DateField ID="dfDBTuNgay" Vtype="daterange" FieldLabel="Từ ngày" runat="server"
                            AnchorHorizontal="95%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container7" runat="server" LabelAlign="left" LabelWidth="100"
                    Layout="Form" ColumnWidth=".5">
                    <Items>
                        <ext:TextField ID="txtDBNhiemKy" FieldLabel="Nhiệm kỳ<span style='color:red;'>*</span>"
                            AnchorHorizontal="100%" runat="server" MaxLength="500" CtCls="requiredData" />
                        <ext:DateField ID="dfDBDenNgay" Vtype="daterange" FieldLabel="Đến ngày" runat="server"
                            AnchorHorizontal="100%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:TextArea runat="server" LabelWidth="70" ID="txtDBGhiChu" FieldLabel="Ghi chú"
            AnchorHorizontal="100%" MaxLength="500">
        </ext:TextArea>
    </Items>
    <Buttons>
        <ext:Button ID="btnCapNhatDaiBieu" Text="Cập nhật" Icon="Disk" runat="server">
            <Listeners>
                <Click Handler="return CheckInputDaiBieu();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnCapNhatDaiBieu_Click" After="ResetWdDaiBieu();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnEditDaiBieu" Icon="Disk" Hidden="true" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputDaiBieu();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnCapNhatDaiBieu_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button7" Text="Cập nhật & Đóng lại" Icon="Disk" runat="server">
            <Listeners>
                <Click Handler="return CheckInputDaiBieu();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnCapNhatDaiBieu_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button12" Text="Đóng lại" Icon="Decline" runat="server">
            <Listeners>
                <Click Handler="#{wdDaiBieu}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="#{btnCapNhatDaiBieu}.show();#{btnEditDaiBieu}.hide();#{Button7}.show();ResetWdDaiBieu();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdDeTai" AutoHeight="true" Width="600" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Đề tài">
    <Items>
        <ext:TextField runat="server" ID="txtMaDeTai" FieldLabel="Mã đề tài<span style='color:red;'>*</span>"
            TabIndex="1" CtCls="requiredData" AnchorHorizontal="100%" MaxLength="50" />
        <ext:Container ID="Container38" runat="server" Layout="Column" Height="80">
            <Items>
                <ext:Container ID="Container39" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Tên đề tài<span style='color:red;'>*</span>"
                            TabIndex="2" AnchorHorizontal="95%" ID="txtDeTaiTenDeTai" MaxLength="500" CtCls="requiredData" />
                        <ext:TextField runat="server" FieldLabel="Chủ nhiệm đề tài" AnchorHorizontal="95%"
                            TabIndex="4" ID="txtDeTaiChuNhiemDeTai" MaxLength="500" />
                        <ext:DateField runat="server" Vtype="daterange" FieldLabel="Từ ngày" AnchorHorizontal="95%"
                            TabIndex="6" EnableKeyEvents="true" ID="txtDeTaiTuNgay" Editable="true" MaskRe="/[0-9\/]/"
                            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container40" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Cấp đề tài<span style='color:red;'>*</span>"
                            TabIndex="3" AnchorHorizontal="100%" ID="txtDeTaiCapDeTai" MaxLength="500" CtCls="requiredData" />
                        <ext:TextField runat="server" FieldLabel="Tư cách tham gia" AnchorHorizontal="100%"
                            TabIndex="5" ID="txDeTaiTuCachThamGia" MaxLength="500" />
                        <ext:DateField runat="server" Vtype="daterange" FieldLabel="Đến ngày" AnchorHorizontal="100%"
                            TabIndex="7" EnableKeyEvents="true" ID="txtDeTaiDenNgay" Editable="true" MaskRe="/[0-9\/]/"
                            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:TextField runat="server" FieldLabel="Kết quả" AnchorHorizontal="100%" ID="txtDeTaiKetQua"
            TabIndex="8" MaxLength="500" />
        <ext:Hidden runat="server" ID="hdfDeTaiTepTinDinhKem" />
        <ext:CompositeField ID="CompositeField11" runat="server" AnchorHorizontal="100%"
            FieldLabel="Tệp tin đính kèm">
            <Items>
                <ext:FileUploadField ID="fufDeTaiTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                    ButtonText="" Icon="Attach" Width="415">
                </ext:FileUploadField>
                <ext:Button runat="server" ID="btnDeTaiDownload" Icon="ArrowDown" ToolTip="Tải về"
                    Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnDeTaiDownload_Click" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDeTaiDelete" Icon="Delete" ToolTip="Xóa">
                    <Listeners>
                        <Click Handler="return checkDeleteAttackFile(#{fufDeTaiTepTinDinhKem}.fileInput.dom, #{hdfDeTaiTepTinDinhKem}, #{fufDeTaiTepTinDinhKem});" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnDeTaiDelete_Click" After="#{fufDeTaiTepTinDinhKem}.reset();">
                            <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                ConfirmRequest="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:CompositeField>
        <ext:TextArea ID="txtDeTaiGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
            TabIndex="9" MaxLength="500" />
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateDeTai" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputDeTai(#{fufDeTaiTepTinDinhKem}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateDeTai_Click" After="ResetWdDeTai();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnEditDeTai" Icon="Disk" Hidden="true" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputDeTai(#{fufDeTaiTepTinDinhKem}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateDeTai_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button18" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputDeTai(#{fufDeTaiTepTinDinhKem}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateDeTai_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button19" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdDeTai}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="#{btnUpdateDeTai}.show();#{btnEditDeTai}.hide();#{Button18}.show();ResetWdDeTai();" />
    </Listeners>
</ext:Window>
<uc1:ucChooseEmployee ID="ucChooseEmployee1" ChiChonMotCanBo="true" DisplayWorkingStatus="DangLamViec"
    runat="server" />
<ext:Window ID="wdHopDong" AutoHeight="true" Width="550" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Hợp đồng" Resizable="false">
    <Items>
        <ext:CompositeField runat="server" AnchorHorizontal="99%">
            <Items>
                <ext:TextField runat="server" FieldLabel="Số hợp đồng<span style='color:red;'>*</span>"
                    Width="386" ID="txtHopDongSoHopDong" MaxLength="30" CtCls="requiredData" />
                <ext:Button runat="server" ID="btnSinhSoHopDong" Icon="Reload">
                    <ToolTips>
                        <ext:ToolTip runat="server" Title="Hướng dẫn" Html="Sinh số hợp đồng mới (Chỉ áp dụng cho trường hợp chưa có số hợp đồng)" />
                    </ToolTips>
                    <Listeners>
                        <Click Handler="if (#{txtHopDongSoHopDong}.getValue().trim() != '' && #{txtHopDongSoHopDong}.getValue() != null) { this.blur(); alert('Số hợp đồng đã được sinh');} else {#{DirectMethods}.GenerateSoQD();}" />
                    </Listeners>
                </ext:Button>
            </Items>
        </ext:CompositeField>
        <ext:Hidden runat="server" ID="hdfMaHopDongOld" />
        <ext:ComboBox runat="server" ID="cbHopDongLoaiHopDong" DisplayField="TEN" MinChars="1" PageSize="15"
            ItemSelector="div.list-item" FieldLabel="Loại hợp đồng<span style='color:red;'>*</span>"
            Editable="true" ValueField="MA" AnchorHorizontal="99%" CtCls="requiredData">
            <Store>
                <ext:Store runat="server" ID="cbHopDongLoaiHopDongStore" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
            </Store>
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
        <ext:Hidden runat="server" ID="hdfTinhTrangHopDong" />
        <ext:ComboBox runat="server" ID="cbHopDongTinhTrangHopDong" DisplayField="TEN" MinChars="1" PageSize="15"
            ItemSelector="div.list-item" FieldLabel="Tình trạng HĐ" Editable="true" ValueField="MA"
            AnchorHorizontal="99%">
            <Store>
                <ext:Store runat="server" ID="cbHopDongTinhTrangHopDongStore" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
            </Store>
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
                <Select Handler="this.triggers[0].show(); #{hdfTinhTrangHopDong}.setValue(this.getValue());" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfTinhTrangHopDong}.reset(); }" />
            </Listeners>
        </ext:ComboBox>
        <ext:Hidden runat="server" ID="hdfViTriCongViec" />
        <ext:ComboBox runat="server" ID="cbx_congviec" FieldLabel="Vị trí công việc<span style='color:red;'>*</span>"
            CtCls="requiredData" DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..."
            ItemSelector="div.list-item" AnchorHorizontal="99%" Editable="true" AllowBlank="false"
            PageSize="15" MinChars="1" EmptyText="Gõ để tìm kiếm">
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
            <Listeners>
                <Expand Handler="#{cbx_congviec_Store}.reload();" />
                <Select Handler="this.triggers[0].show(); #{hdfViTriCongViec}.setValue(#{cbx_congviec}.getValue());" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfViTriCongViec}.reset(); }" />
            </Listeners>
        </ext:ComboBox>
        <ext:Container ID="Container43" runat="server" Layout="Column" Height="52">
            <Items>
                <ext:Container ID="Container44" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                    <Items>
                        <ext:DateField runat="server" Vtype="daterange" FieldLabel="Ngày ký kết<span style='color:red;'>*</span>"
                            ID="dfHopDongNgayHopDong" AnchorHorizontal="99%" Editable="true" MaskRe="/[0-9\/]/"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng"
                            Format="d/M/yyyy" CtCls="requiredData">
                        </ext:DateField>
                        <ext:DateField runat="server" FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>"
                            ID="dfNgayCoHieuLuc" AnchorHorizontal="99%" Editable="true" MaskRe="/[0-9\/]/"
                            Format="d/M/yyyy" CtCls="requiredData"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                            <Listeners>
                                <Select Handler="#{DirectMethods}.SetNgayHetHD();" />
                                <Blur Handler="#{DirectMethods}.SetNgayHetHD();" />
                            </Listeners>
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container45" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".5">
                    <Items>
                        <ext:DateField runat="server" Vtype="daterange" FieldLabel="Ngày hết hạn HĐ" ID="dfHopDongNgayKiKet"
                            AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Container runat="server" Layout="ColumnLayout" Height="27">
            <Items>
                <ext:Container runat="server" LabelAlign="Left" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfPrkeyNguoiKyHD" />
                        <ext:TriggerField runat="server" ID="tgf_NguoiKyHD" FieldLabel="Người ký HD" AnchorHorizontal="99%"
                            Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" />
                                <ext:FieldTrigger Icon="SimplePlus" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="if(index == 1){SouthHoSoNhanSu1_ucChooseEmployee1_wdChooseUser.show();}
                                                       else if(index==0){ #{hdfPrKeyNguoiKyHD}.reset(); this.clear(); } " />
                            </Listeners>
                        </ext:TriggerField>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" LabelAlign="Left" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:ComboBox runat="server" ID="cbx_HopDongChucVu" FieldLabel="Chức vụ" DisplayField="TEN" MinChars="1" PageSize="15"
                            ValueField="MA" AnchorHorizontal="98%" Editable="true" ItemSelector="div.list-item"
                            ListWidth="250">
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
                                <ext:Store runat="server" ID="cbx_HopDongChucVu_Store" AutoLoad="false">
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
                            <Listeners>
                                <Focus Handler="#{cbx_HopDongChucVu_Store}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Hidden runat="server" ID="hdfHopDongTepTinDK" />
        <ext:CompositeField runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
            <Items>
                <ext:FileUploadField ID="fufHopDongTepTin" runat="server" EmptyText="Chọn tệp tin"
                    ButtonText="" Icon="Attach" Width="358">
                </ext:FileUploadField>
                <ext:Button runat="server" ID="btnHopDongAttachDownload" Icon="ArrowDown" Hidden="true"
                    ToolTip="Tải về">
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
        <ext:ComboBox runat="server" ID="cbx_HopDongTrangThai" FieldLabel="Trạng thái HĐ"
            AnchorHorizontal="99%" Editable="false">
            <Items>
                <ext:ListItem Text="Chưa duyệt" Value="ChuaDuyet" />
                <ext:ListItem Text="Đã duyệt" Value="DaDuyet" />
            </Items>
            <SelectedItem Value="DaDuyet" />
        </ext:ComboBox>
        <ext:TextArea runat="server" ID="txtHopDongGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="99%" />
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
        <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert')#{DirectMethods}.GenerateSoQD();" />
        <Hide Handler="#{btnUpdateHopDong}.show();#{btnEditHopDong}.hide();#{Button20}.show();ResetWdHopDong();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdDienBienLuong" AutoHeight="true" Width="550" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Lương" Resizable="false">
    <Items>
        <ext:TextField runat="server" FieldLabel="Số quyết định"
                    Width="386" ID="txtSoQD" MaxLength="30" AnchorHorizontal="99%" />
        <ext:Hidden runat="server" ID="Hidden1" />
        <ext:TextField runat="server" FieldLabel="Hệ số lương" ID="txtHeSoLuong" AnchorHorizontal="99%" />
        <ext:Hidden runat="server" ID="Hidden2" />
        <ext:TextField runat="server" ID="txtLuongCung" MaskRe="[0-9]" MaxLength="11" FieldLabel="Lương cứng" CtCls="requiredData" AnchorHorizontal="99%"/>
        <ext:Hidden runat="server" ID="Hidden3" />
        <ext:TextField runat="server" ID="txtLuongDongBH" MaskRe="[0-9]" MaxLength="11" FieldLabel="Lương đóng BHXH" AnchorHorizontal="99%"/>
        <ext:DateField runat="server" ID="dfNgayHuongLuong" FieldLabel="Ngày hưởng lương" Format="dd/MM/yyyy" CtCls="requiredData" AnchorHorizontal="99%"/>
        <ext:DateField runat="server" ID="dfNgayHieuLuc" FieldLabel="Ngày hiệu lực" Format="dd/MM/yyyy" AnchorHorizontal="99%"/>
        <ext:Hidden runat="server" ID="Hidden5" CtCls="requiredData" />
        <ext:DateField runat="server" ID="dfNgayQuyetDinh" FieldLabel="Ngày quyết định" Format="dd/MM/yyyy" AnchorHorizontal="99%"/>
        <ext:TextArea runat="server" ID="TextArea1" FieldLabel="Ghi chú" AnchorHorizontal="99%" />
    </Items>
    <Buttons>
        <ext:Button ID="Button16" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputHopDong(#{fufHopDongTepTin}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateLuong_Click" After="ResetWdHopDong();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="Button17" Icon="Disk" Hidden="true" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputHopDong(#{fufHopDongTepTin}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateLuong_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button35" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
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
        <ext:Button ID="Button36" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdDienBienLuong}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert')#{DirectMethods}.GenerateSoQD();" />
        <Hide Handler="#{btnUpdateHopDong}.show();#{btnEditHopDong}.hide();#{Button20}.show();ResetWdHopDong();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdKhaNang" AutoHeight="true" Width="400" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Khả năng" Resizable="false">
    <Items>
        <ext:ComboBox runat="server" ID="cbKhaNang" DisplayField="TEN" FieldLabel="Khả năng<span style='color:red;'>*</span>"
            ValueField="MA" AnchorHorizontal="100%" Editable="true" ItemSelector="div.list-item" MinChars="1" PageSize="15"
            CtCls="requiredData">
            <Store>
                <ext:Store ID="cbKhaNangStore" runat="server" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                    </Proxy>
                    <BaseParams>
                        <ext:Parameter Name="table" Value="DM_KHANANG" Mode="Value" />
                        <ext:Parameter Name="ma" Value="MA_KHANANG" Mode="Value" />
                        <ext:Parameter Name="ten" Value="TEN_KHANANG" Mode="Value" />
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
            <Template ID="Template6" runat="server">
                <Html>
                    <tpl for=".">
						<div class="list-item"> 
							{TEN}
						</div>
					</tpl>
                </Html>
            </Template>
            <Triggers>
                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
            </Triggers>
            <Listeners>
                <Focus Handler="#{cbKhaNangStore}.reload();" />
                <Select Handler="this.triggers[0].show();" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
            </Listeners>
        </ext:ComboBox>
        <ext:ComboBox runat="server" ID="cbKhaNangXepLoai" DisplayField="TEN" FieldLabel="Xếp loại"
            ValueField="MA" AnchorHorizontal="100%" Editable="true" ItemSelector="div.list-item">
            <Store>
                <ext:Store ID="cbKhaNangXepLoaiStore" runat="server" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                    </Proxy>
                    <BaseParams>
                        <ext:Parameter Name="table" Value="DM_XEPLOAI" Mode="Value" />
                        <ext:Parameter Name="ma" Value="MA_XEPLOAI" Mode="Value" />
                        <ext:Parameter Name="ten" Value="TEN_XEPLOAI" Mode="Value" />
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
            </Store>
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
                <Focus Handler="#{cbKhaNangXepLoaiStore}.reload();" />
                <Select Handler="this.triggers[0].show();" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
            </Listeners>
        </ext:ComboBox>
        <ext:TextArea ID="txtKhaNangGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%" />
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateKhaNang" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputKhaNang();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateKhaNang_Click" After="ResetWdKhaNang();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnEditKhaNang" runat="server" Text="Cập nhật" Hidden="true" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputKhaNang();" />
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
        <ext:Button ID="Button22" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputKhaNang();" />
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
        <Hide Handler="#{btnUpdateKhaNang}.show();#{btnEditKhaNang}.hide();#{Button22}.show();ResetWdKhaNang();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdKhenThuong" AutoHeight="true" Width="550" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Khen thưởng" Resizable="false">
    <Items>
        <ext:Container ID="Container46" runat="server" Layout="ColumnLayout" Height="53">
            <Items>
                <ext:Container ID="Container47" runat="server" LabelAlign="left" Layout="FormLayout"
                    ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Số quyết định" ID="txtKhenThuongSoQuyetDinh"
                            AnchorHorizontal="98%" MaxLength="20" />
                        <ext:Hidden runat="server" ID="hdfKhenThuongNguoiQD" />
                        <ext:TriggerField runat="server" ID="tgf_KhenThuong_NguoiRaQD" FieldLabel="Người quyết định"
                            AnchorHorizontal="98%" Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimplePlus" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="SouthHoSoNhanSu1_ucChooseEmployee1_wdChooseUser.show();" />
                            </Listeners>
                        </ext:TriggerField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container48" runat="server" LabelAlign="left" Layout="FormLayout"
                    LabelWidth="110" ColumnWidth="0.5">
                    <Items>
                        <ext:ComboBox runat="server" ID="cbHinhThucKhenThuong" DisplayField="TEN"
                            FieldLabel="Hình thức<span style='color:red;'>*</span>" ValueField="MA" MinChars="1" PageSize="15" ListWidth="250"
                            AnchorHorizontal="98%" Editable="true" ItemSelector="div.list-item" CtCls="requiredData">
                            <Store>
                                <ext:Store ID="cbHinhThucKhenThuongStore" runat="server" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_HT_KTHUONG" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_HT_KTHUONG" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_HT_KTHUONG" Mode="Value" />
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
                            </Store>
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
                                <Focus Handler="#{cbHinhThucKhenThuongStore}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DateField runat="server" ID="dfKhenThuongNgayQuyetDinh" EnableKeyEvents="true"
                            Editable="true" FieldLabel="Ngày quyết định" AnchorHorizontal="98%" MaskRe="/[0-9\/]/"
                            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                            RegexText="Định dạng ngày không đúng" Vtype="daterange">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Hidden runat="server" ID="hdfIsDanhMuc" Text="0" />
        <%-- 0: user enter text, 1: user select item, 2: user select and edit --%>
        <ext:Hidden runat="server" ID="hdfMaLyDoKhenThuong" />
        <ext:Hidden runat="server" ID="hdfLyDoKTTemp" />
        <ext:ComboBox runat="server" ID="cbLyDoKhenThuong" DisplayField="TEN" FieldLabel="Lý do thưởng<span style='color:red;'>*</span>"
            ValueField="MA" AnchorHorizontal="99%" Editable="true" ItemSelector="div.list-item"
            MinChars="1" EmptyText="Gõ để tìm kiếm" LoadingText="Đang tải dữ liệu..." CtCls="requiredData" PageSize="15"
            EnableKeyEvents="true">
            <Store>
                <ext:Store ID="cbLyDoKhenThuongStore" runat="server" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                    </Proxy>
                    <BaseParams>
                        <ext:Parameter Name="table" Value="DM_LYDO_KTHUONG" Mode="Value" />
                        <ext:Parameter Name="ma" Value="MA_LYDO_KTHUONG" Mode="Value" />
                        <ext:Parameter Name="ten" Value="TEN_LYDO_KTHUONG" Mode="Value" />
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
                <Focus Handler="#{cbLyDoKhenThuongStore}.reload();" />
                <Select Handler="this.triggers[0].show(); #{hdfMaLyDoKhenThuong}.setValue(#{cbLyDoKhenThuong}.getValue());
                                        #{hdfIsDanhMuc}.setValue('1');
                                        #{hdfLyDoKTTemp}.setValue(#{cbLyDoKhenThuong}.getRawValue());" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfIsDanhMuc}.reset(); }" />
                <KeyUp Fn="searchBoxKT" />
                <Blur Handler="#{cbLyDoKhenThuong}.setRawValue(#{hdfLyDoKTTemp}.getValue());
                                    if (#{hdfIsDanhMuc}.getValue() != '1') {#{cbLyDoKhenThuong}.setValue(#{hdfLyDoKTTemp}.getValue());}" />
            </Listeners>
        </ext:ComboBox>
        <ext:Container runat="server" Height="27" AnchorHorizontal="100%" Layout="ColumnLayout">
            <Items>
                <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" ID="txtKhenThuongSoTien" FieldLabel="Số tiền" AnchorHorizontal="98%"
                            MaxLength="15" MaskRe="/[0-9]/" />
                    </Items>
                </ext:Container>
                <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="110">
                    <Items>
                        <ext:TextField MaskRe="[0-9\.]" EmptyText="VD: 10.5" runat="server" LabelWidth="110"
                            ID="nbfSoDiemKhenThuong" FieldLabel="Số điểm" MaxLength="9" AnchorHorizontal="98%" />
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Hidden runat="server" ID="hdfKhenThuongTepTinDinhKem" />
        <ext:CompositeField ID="CompositeField5" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
            <Items>
                <ext:FileUploadField ID="fufKhenThuongTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                    ButtonText="" Icon="Attach" Width="358">
                </ext:FileUploadField>
                <ext:Button runat="server" ID="btnKhenThuongDownload" Icon="ArrowDown" ToolTip="Tải về"
                    Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnKhenThuongDownload_Click" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnKhenThuongDelete" Icon="Delete" ToolTip="Xóa">
                    <Listeners>
                        <Click Handler="return checkDeleteAttackFile(#{fufKhenThuongTepTinDinhKem}.fileInput.dom, #{hdfKhenThuongTepTinDinhKem}, #{fufKhenThuongTepTinDinhKem});" />
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
        <ext:TextArea ID="txtKhenThuongGhiCHu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="99%"
            MaxLength="1000" />
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
        <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') #{DirectMethods}.GenerateKhenThuongSoQD();" />
        <Hide Handler="#{btnUpdateKhenThuong}.show();#{btnEditKhenThuong}.hide();#{Button24}.show();ResetWdKhenThuong();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdPhuCap" Width="600" runat="server" Padding="6" EnableViewState="false"
    Layout="FormLayout" Modal="true" Hidden="true" Constrain="true" Icon="Money"
    Title="Các khoản phụ cấp" Resizable="false" Height="450">
    <Items>
        <ext:BorderLayout runat="server" ID="brdlayout">
            <Items>
                <ext:Hidden ID="hdfPhuCapRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelPhuCap" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="TrangThai" AutoExpandMin="100">
                    <Store>
                        <ext:Store ID="StorePhuCap" AutoSave="false" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                            RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StorePhuCap_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="MaPhuCap" />
                                        <ext:RecordField Name="HeSo" />
                                        <ext:RecordField Name="SoTien" />
                                        <ext:RecordField Name="NgayQuyetDinh" />
                                        <ext:RecordField Name="NgayHieuLuc" />
                                        <ext:RecordField Name="NgayHetHieuLuc" />
                                        <ext:RecordField Name="NguoiQuyetDinh" />
                                        <ext:RecordField Name="TrangThai" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel21" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="MaPhuCap" Width="80" Header="Mã phụ cấp" DataIndex="MaPhuCap" />
                            <ext:Column ColumnID="HeSo" Width="60" Header="Hệ số" Align="Right" DataIndex="HeSo" />
                            <ext:Column ColumnID="SoTien" Width="100" Align="Right" Header="Số tiền" DataIndex="SoTien">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:DateColumn ColumnID="NgayQuyetDinh" Width="110" Format="dd/MM/yyyy" Header="Ngày quyết định"
                                DataIndex="NgayQuyetDinh" />
                            <ext:Column ColumnID="NguoiQuyetDinh" Width="150" Header="Người quyết định" DataIndex="NguoiQuyetDinh" />
                            <ext:DateColumn ColumnID="NgayHieuLuc" Width="90" Format="dd/MM/yyyy" Header="Ngày hiệu lực"
                                DataIndex="NgayHieuLuc" />
                            <ext:DateColumn ColumnID="NgayHetHieuLuc" Width="110" Format="dd/MM/yyyy" Header="Ngày hết hiệu lực"
                                DataIndex="NgayHetHieuLuc" />
                            <ext:Column ColumnID="TrangThai" Width="100" Header="Trạng thái" DataIndex="TrangThai" />
                        </Columns>
                    </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar4" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                            PageSize="15" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                            DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                        </ext:PagingToolbar>
                    </BottomBar>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="" />
                    </Listeners>
                    <Buttons>
                        <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                            <Listeners>
                                <Click Handler="#{wdPhuCap}.hide();" />
                            </Listeners>
                        </ext:Button>
                    </Buttons>
                </ext:GridPanel>
            </Items>
        </ext:BorderLayout>
    </Items>
    <Listeners>
        <BeforeShow Handler="if (#{hdfPhuCapRecordID}.getValue() != #{hdfDBLRecordID}.getValue())
            {
                #{StorePhuCap}.reload();
                #{hdfphucaprecordid}.setValue(#{hdfdblrecordid}.getValue());
            }" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdKyLuat" AutoHeight="true" Width="550" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Kỷ luật" Resizable="false">
    <Items>
        <ext:Container ID="Container51" runat="server" Layout="Column" Height="55">
            <Items>
                <ext:Container ID="Container52" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Số quyết định" ID="txtKyLuatSoQD" AnchorHorizontal="98%"
                            MaxLength="50" />
                        <ext:Hidden runat="server" ID="hdfKyLuatNguoiQD" />
                        <ext:TriggerField runat="server" ID="tgfKyLuatNguoiQD" FieldLabel="Người quyết định"
                            AnchorHorizontal="99%" Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="SimplePlus" />
                            </Triggers>
                            <Listeners>
                                <TriggerClick Handler="SouthHoSoNhanSu1_ucChooseEmployee1_wdChooseUser.show();" />
                            </Listeners>
                        </ext:TriggerField>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container53" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5"
                    LabelWidth="110">
                    <Items>
                        <ext:ComboBox runat="server" ID="cbHinhThucKyLuat" DisplayField="TEN" FieldLabel="Hình thức<span style='color:red;'>*</span>"
                            CtCls="requiredData" ValueField="MA" AnchorHorizontal="100%" Editable="true" MinChars="1" PageSize="15" ListWidth="250"
                            ItemSelector="div.list-item">
                            <Store>
                                <ext:Store ID="cbHinhThucKyLuatStore" runat="server" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_HT_KYLUAT" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_HT_KYLUAT" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_HT_KYLUAT" Mode="Value" />
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
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Template ID="Template11" runat="server">
                                <Html>
                                    <tpl for=".">
						                <div class="list-item"> 
							                {TEN}
						                </div>
					                </tpl>
                                </Html>
                            </Template>
                            <Listeners>
                                <Focus Handler="#{cbHinhThucKyLuatStore}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DateField runat="server" ID="dfKyLuatNgayQuyetDinh" EnableKeyEvents="true" Editable="true"
                            FieldLabel="Ngày quyết định" AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng"
                            Vtype="daterange">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Hidden runat="server" ID="hdfIsDanhMucKL" Text="0" />
        <%-- 0: user enter text, 1: user select item, 2: user select and edit --%>
        <ext:Hidden runat="server" ID="hdfMaLyDoKyLuat" />
        <ext:Hidden runat="server" ID="hdfLyDoKLTemp" />
        <ext:ComboBox runat="server" ID="cbLyDoKyLuat" DisplayField="TEN" FieldLabel="Lý do<span style='color:red;'>*</span>"
            CtCls="requiredData" ValueField="MA" AnchorHorizontal="100%" Editable="true" PageSize="15"
            ItemSelector="div.list-item" MinChars="1" EmptyText="Gõ để tìm kiếm" LoadingText="Đang tải dữ liệu..."
            EnableKeyEvents="true">
            <Store>
                <ext:Store ID="cbLyDoKyLuatStore" runat="server" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                    </Proxy>
                    <BaseParams>
                        <ext:Parameter Name="table" Value="DM_LYDO_KYLUAT" Mode="Value" />
                        <ext:Parameter Name="ma" Value="MA_LYDO_KYLUAT" Mode="Value" />
                        <ext:Parameter Name="ten" Value="TEN_LYDO_KYLUAT" Mode="Value" />
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
            </Store>
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
            <Listeners>
                <Focus Handler="#{cbLyDoKyLuatStore}.reload();" />
                <Select Handler="this.triggers[0].show();  #{hdfMaLyDoKyLuat}.setValue(#{cbLyDoKyLuat}.getValue());
				                        #{hdfIsDanhMucKL}.setValue('1');
				                        #{hdfLyDoKLTemp}.setValue(#{cbLyDoKyLuat}.getRawValue());" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfIsDanhMucKL}.reset(); }" />
                <KeyUp Fn="searchBoxKL" />
                <Blur Handler="#{cbLyDoKyLuat}.setRawValue(#{hdfLyDoKLTemp}.getValue());
			                            if (#{hdfIsDanhMucKL}.getValue() != '1') {#{cbLyDoKyLuat}.setValue(#{hdfLyDoKLTemp}.getValue());}" />
            </Listeners>
        </ext:ComboBox>
        <ext:Container runat="server" ID="ctiendiem" AnchorHorizontal="100%" Layout="ColumnLayout"
            Height="30">
            <Items>
                <ext:Container runat="server" Height="30" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField MaskRe="[0-9]" runat="server" ID="txtKyLuatSoTien" FieldLabel="Số tiền"
                            AnchorHorizontal="99%" MaxLength="15" />
                    </Items>
                </ext:Container>
                <ext:TextField MaskRe="[0-9\.]" EmptyText="VD: 10.5" runat="server" MaxLength="9"
                    ID="nbfSoDiem" ColumnWidth="0.5" FieldLabel="Số điểm" />
            </Items>
        </ext:Container>
        <ext:Hidden runat="server" ID="hdfKyLuatTepTinDinhKem" />
        <ext:CompositeField ID="CompositeField6" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
            <Items>
                <ext:FileUploadField ID="fufKyLuatTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                    ButtonText="" Icon="Attach" Width="365">
                </ext:FileUploadField>
                <ext:Button runat="server" ID="btnKyLuatDownload" Icon="ArrowDown" ToolTip="Tải về"
                    Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnKyLuatDownload_Click" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnKyLuatDelete" Icon="Delete" ToolTip="Xóa">
                    <Listeners>
                        <Click Handler="return checkDeleteAttackFile(#{fufKyLuatTepTinDinhKem}.fileInput.dom, #{hdfKyLuatTepTinDinhKem}, #{fufKyLuatTepTinDinhKem});" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnKyLuatDelete_Click" After="#{fufKyLuatTepTinDinhKem}.reset();">
                            <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                ConfirmRequest="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:CompositeField>
        <ext:TextArea ID="txtKyLuatGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%" />
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
        <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') #{DirectMethods}.GenerateKyLuatSoQD();" />
        <Hide Handler="#{btnCapNhatKyLuat}.show();#{btnEditKyLuat}.hide();#{Button26}.show();ResetWdKyLuat();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdQuanHeGiaDinh" AutoHeight="true" Width="550" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Quan hệ gia đình" Resizable="false">
    <Items>
        <ext:Container ID="Container56" runat="server" Layout="Column" Height="77">
            <Items>
                <ext:Container ID="Container57" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" FieldLabel="Họ tên<span style='color:red;'>*</span>"
                            CtCls="requiredData" ID="txtQHGDHoTen" AnchorHorizontal="95%" MaxLength="50">
                            <Listeners>
                                <Blur Handler="ChuanHoaTen(#{txtQHGDHoTen});" />
                            </Listeners>
                            <ToolTips>
                                <ext:ToolTip ID="ToolTip2" runat="server" Title="Hướng dẫn" Html="Phần mềm sẽ tự động chuẩn hóa họ và tên của bạn. Ví dụ: bạn nhập nguyễn văn huy, kết quả trả về Nguyễn Văn Huy." />
                            </ToolTips>
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txtQHGDNamSinh" FieldLabel="Năm sinh" AnchorHorizontal="95%"
                            MaxLength="4" MinLength="4" MaskRe="[0-9]" />
                        <ext:TextField runat="server" FieldLabel="Nghề nghiệp" ID="txtQHGDNgheNghiep" AnchorHorizontal="95%"
                            MaxLength="50" />
                    </Items>
                </ext:Container>
                <ext:Container ID="Container58" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                    <Items>
                        <ext:ComboBox runat="server" Editable="false" FieldLabel="Giới tính<span style='color:red;'>*</span>"
                            CtCls="requiredData" ID="cbQHGDGioiTinh" AnchorHorizontal="100%" SelectedIndex="0">
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
                        <ext:ComboBox runat="server" ID="cbQuanHeGiaDinh" Editable="true" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            FieldLabel="Quan hệ<span style='color:red;'>*</span>" CtCls="requiredData" ValueField="MA"
                            AnchorHorizontal="100%" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store ID="cbQuanHeGiaDinhStore" runat="server" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_QUANHE" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_QUANHE" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_QUANHE" Mode="Value" />
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
                            </Store>
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
                                <Focus Handler="#{cbQuanHeGiaDinhStore}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField runat="server" FieldLabel="Nơi làm việc" ID="txtQHGDNoiLamViec" AnchorHorizontal="100%"
                            MaxLength="50" />
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Container runat="server" Layout="ColumnLayout" Height="30" AnchorHorizontal="100%">
            <Items>
                <ext:Container Layout="FormLayout" runat="server" ID="ctainer" Height="30" ColumnWidth="0.5">
                    <Items>
                        <ext:Checkbox runat="server" ID="chkQHGDLaNguoiPhuThuoc" BoxLabel="Là người phụ thuộc"
                            Checked="false">
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
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txtSoCMT" FieldLabel="Số CMT" ColumnWidth="0.5"
                    MaxLength="12" MaskRe="[0-9]" />
            </Items>
        </ext:Container>
        <ext:Container runat="server" Layout="ColumnLayout" Height="35">
            <Items>
                <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:DateField runat="server" ID="dfQHGDBatDauGiamTru" Disabled="true" Vtype="daterange"
                            FieldLabel="Bắt đầu giảm trừ" AnchorHorizontal="95%" Editable="true" MaskRe="/[0-9\/]/"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng"
                            Format="d/M/yyyy">
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:DateField runat="server" ID="dfQHGDKetThucGiamTru" Disabled="true" Vtype="daterange"
                            FieldLabel="Kết thúc giảm trừ" AnchorHorizontal="100%" Editable="true" MaskRe="/[0-9\/]/"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng"
                            Format="d/M/yyyy">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtQHGDGhiChu" AnchorHorizontal="100%"
            MaxLength="500" />
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateQuanHeGiaDinh" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputQHGD();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateQuanHeGiaDinh_Click" After="ResetWdQuanHeGiaDinh();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnUpdate" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputQHGD();" />
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
        <ext:Button ID="Button28" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputQHGD();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateQuanHeGiaDinh_Click">
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
        <Hide Handler="#{btnUpdateQuanHeGiaDinh}.show();#{btnUpdate}.hide();#{Button28}.show();ResetWdQuanHeGiaDinh();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdQuaTrinhCongTac" AutoHeight="true" Width="550" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Quá trình công tác" Resizable="false">
    <Items>
        <ext:TextField runat="server" ID="txtQTCTSoQD" FieldLabel="Số quyết định" AnchorHorizontal="99%"
            TabIndex="1" MaxLength="50" />
        <ext:Container ID="Container25" runat="server" Layout="ColumnLayout" Height="78">
            <Items>
                <ext:Container ID="Container26" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfQTCTNguoiQuyetDinh" />
                        <ext:TriggerField runat="server" ID="tgf_QTCTNguoiQuyetDinh" FieldLabel="Người quyết định"
                            TabIndex="2" AnchorHorizontal="98%" Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                <ext:FieldTrigger Icon="SimplePlus" />
                            </Triggers>
                            <Listeners>
                                <Blur Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if (index == 0) {#{hdfQTCTNguoiQuyetDinh}.reset(); this.reset(); this.triggers[0].hide(); }else{SouthHoSoNhanSu1_ucChooseEmployee1_wdChooseUser.show();}" />
                            </Listeners>
                        </ext:TriggerField>
                        <ext:DateField runat="server" ID="dfQTCTNgayBatDau" Vtype="daterange" AnchorHorizontal="98%"
                            TabIndex="4" FieldLabel="Ngày bắt đầu<span style='color:red;'>*</span>" CtCls="requiredData" MaskRe="/[0-9\/]/"
                            Editable="true" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng"
                            Format="d/M/yyyy">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:DateField>
                        <ext:ComboBox runat="server" ID="cbCongTacQuocGia" Editable="true" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            TabIndex="6" FieldLabel="Quốc gia" ValueField="MA" AnchorHorizontal="98%" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store ID="cbCongTacQuocGiaStore" runat="server" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_NUOC" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_NUOC" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_NUOC" Mode="Value" />
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
                            </Store>
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
                            <Listeners>
                                <Focus Handler="#{cbCongTacQuocGiaStore}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container27" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                    LabelWidth="110">
                    <Items>
                        <ext:DateField runat="server" ID="dfQTCTNgayQuyetDinh" Vtype="daterange" AnchorHorizontal="98%"
                            TabIndex="3" FieldLabel="Ngày quyết định" Editable="true" MaskRe="/[0-9\/]/"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng"
                            Format="d/M/yyyy">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Select Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:DateField>
                        <ext:DateField runat="server" ID="dfQTCTNgayKetThuc" Vtype="daterange" AnchorHorizontal="98%"
                            TabIndex="5" FieldLabel="Ngày kết thúc<span style='color:red;'>*</span>" CtCls="requiredData"
                            Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
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
        <ext:TextField runat="server" ID="txtQTCTNoiDungCongViec" FieldLabel="Nội dung công việc<span style='color:red;'>*</span>"
            TabIndex="7" CtCls="requiredData" AnchorHorizontal="99%" MaxLength="500" />
        <ext:TextField runat="server" ID="txtQTCTDiaDiemCT" FieldLabel="Nơi công tác<span style='color:red;'>*</span>"
            TabIndex="8" CtCls="requiredData" AnchorHorizontal="99%" MaxLength="500" />
        <ext:TextField runat="server" ID="txtQTCTNguoiLienQuan" FieldLabel="Người liên quan"
            TabIndex="9" AnchorHorizontal="99%" MaxLength="500" />
        <ext:Hidden runat="server" ID="hdfQTCTTepTinDinhKem" />
        <ext:CompositeField ID="CompositeField7" runat="server" AnchorHorizontal="99%" FieldLabel="Tệp tin đính kèm">
            <Items>
                <ext:FileUploadField ID="fufQTCTTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                    ButtonText="" Icon="Attach" Width="358">
                </ext:FileUploadField>
                <ext:Button runat="server" ID="btnQTCTDownload" Icon="ArrowDown" ToolTip="Tải về"
                    Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnQTCTDownload_Click" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnQTCTDelete" Icon="Delete" ToolTip="Xóa">
                    <Listeners>
                        <Click Handler="return checkDeleteAttackFile(#{fufQTCTTepTinDinhKem}.fileInput.dom, #{hdfQTCTTepTinDinhKem}, #{fufQTCTTepTinDinhKem});" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnQTCTDelete_Click" After="#{fufQTCTTepTinDinhKem}.reset();">
                            <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                ConfirmRequest="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
            </Items>
        </ext:CompositeField>
        <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtCongTacGhiChu" AnchorHorizontal="99%"
            TabIndex="10" MaxLength="500">
        </ext:TextArea>
    </Items>
    <Buttons>
        <ext:Button ID="btnCapNhatQuaTrinhCongTac" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputQuaTrinhCongTac(#{fufQTCTTepTinDinhKem}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnCapNhatQuaTrinhCongTac_Click" After="ResetWdQuaTrinhCongTac();">
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
                <Click OnEvent="btnCapNhatQuaTrinhCongTac_Click">
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
            AnchorHorizontal="99%" />
        <ext:Container ID="Container28" runat="server" Layout="ColumnLayout" Height="55">
            <Items>
                <ext:Container ID="Container29" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfQTDCNguoiQuyetDinh" />
                        <ext:TriggerField runat="server" ID="tgfQTDCNguoiQuyetDinh" FieldLabel="Người quyết định"
                            AnchorHorizontal="98%" Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                <ext:FieldTrigger Icon="SimplePlus" />
                            </Triggers>
                            <Listeners>
                                <Blur Handler="this.triggers[0].show();" />
                                <TriggerClick Handler="if(index==0){#{hdfQTDCNguoiQuyetDinh}.reset(); this.reset();  this.triggers[0].hide();}else{SouthHoSoNhanSu1_ucChooseEmployee1_wdChooseUser.show();}" />
                            </Listeners>
                        </ext:TriggerField>
                        <ext:DateField runat="server" ID="dfQTDCNgayCoHieuLuc" AnchorHorizontal="98%" FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>"
                            CtCls="requiredData" Editable="true" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" MaskRe="/[0-9\/]/"
                            RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Format="d/M/yyyy" Vtype="daterange">
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
                <ext:Container ID="Container30" runat="server" Layout="FormLayout" ColumnWidth="0.5"
                    LabelWidth="110">
                    <Items>
                        <ext:DateField runat="server" ID="dfQTDCNgayQuyetDinh" AnchorHorizontal="98%" FieldLabel="Ngày quyết định<span style='color:red;'>*</span>" MaskRe="/[0-9\/]/"
                            CtCls="requiredData" Editable="true" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Format="d/M/yyyy" />
                        <ext:DateField runat="server" ID="dfQTDCNgayHetHieuLuc" AnchorHorizontal="98%" FieldLabel="Hết hiệu lực"
                            Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Vtype="daterange">
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
        <ext:Hidden runat="server" ID="hdfQTDCBoPhanMoi" />
        <ext:ComboBox runat="server" ID="cbxQTDCBoPhanMoi" FieldLabel="Bộ phận mới<span style='color:red;'>*</span>"
            DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
            AnchorHorizontal="99%" Editable="false" CtCls="requiredData">
            <Triggers>
                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
            </Triggers>
            <Store>
                <ext:Store runat="server" ID="cbxQTDCBoPhanCu_Store" AutoLoad="false" OnRefreshData="cbxQTDCBoPhanCu_Store_OnRefreshData">
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
            <Template ID="Template15" runat="server">
                <Html>
                    <tpl for=".">
						<div class="list-item"> 
							{TEN}
						</div>
					</tpl>
                </Html>
            </Template>
            <Listeners>
                <Expand Handler="#{cbxQTDCBoPhanCu_Store}.reload();" />
                <Select Handler="this.triggers[0].show(); #{hdfQTDCBoPhanMoi}.setValue(#{cbxQTDCBoPhanMoi}.getValue());" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfQTDCBoPhanMoi}.reset();}" />
            </Listeners>
        </ext:ComboBox>
        <ext:Container runat="server" ID="ctndc1" Layout="ColumnLayout" AnchorHorizontal="100%"
            Height="27">
            <Items>
                <ext:Container runat="server" ID="ctndc2" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfQTDCChucVuMoi" />
                        <ext:ComboBox runat="server" ID="cbxQTDCChucVuMoi" FieldLabel="Chức vụ mới" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            ValueField="MA" AnchorHorizontal="98%" Editable="true" ItemSelector="div.list-item">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Store>
                                <ext:Store runat="server" ID="cbxQTDCChucVuCu_Store" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
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
                            </Store>
                            <Template ID="Template29" runat="server">
                                <Html>
                                    <tpl for=".">
					                    <div class="list-item"> 
						                    {TEN}
					                    </div>
				                    </tpl>
                                </Html>
                            </Template>
                            <Listeners>
                                <Focus Handler="#{cbxQTDCChucVuCu_Store}.reload();" />
                                <Select Handler="this.triggers[0].show(); #{hdfQTDCChucVuMoi}.setValue(#{cbxQTDCChucVuMoi}.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfQTDCChucVuMoi}.reset(); }" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="ctndc3" Layout="FormLayout" ColumnWidth="0.5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfCongViecMoi" />
                        <ext:ComboBox runat="server" ID="cbxCongViecMoi" FieldLabel="Công việc mới" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            ValueField="MA" AnchorHorizontal="98%" Editable="true" ItemSelector="div.list-item">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Store>
                                <ext:Store runat="server" ID="cbxCongViecMoi_Store" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Json="true" Method="GET" Url="SearchDanhMucHandler.ashx"></ext:HttpProxy>
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_CONGVIEC" Mode="Value"></ext:Parameter>
                                        <ext:Parameter Name="ma" Value="MA_CONGVIEC" Mode="Value"></ext:Parameter>
                                        <ext:Parameter Name="ten" Value="TEN_CONGVIEC" Mode="Value"></ext:Parameter>
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
                            </Store>
                            <Template ID="Template17" runat="server">
                                <Html>
                                    <tpl for=".">
					                    <div class="list-item"> 
						                    {TEN}
					                    </div>
				                    </tpl>
                                </Html>
                            </Template>
                            <Listeners>
                                <Focus Handler="#{cbxCongViecMoi_Store}.reload();" />
                                <Select Handler="this.triggers[0].show(); #{hdfCongViecMoi}.setValue(#{cbxCongViecMoi}.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfCongViecMoi}.reset();}" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:Hidden runat="server" ID="hdfQTDCTepTinDinhKem" />
        <ext:CompositeField ID="CompositeField8" runat="server" AnchorHorizontal="99%" FieldLabel="Tệp tin đính kèm">
            <Items>
                <ext:FileUploadField ID="fufQTDCTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                    ButtonText="" Icon="Attach" Width="358">
                </ext:FileUploadField>
                <ext:Button runat="server" ID="btnQTDCDownload" Icon="ArrowDown" ToolTip="Tải về"
                    Hidden="true">
                    <DirectEvents>
                        <Click OnEvent="btnQTDCDownload_Click" IsUpload="true" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnQTDCDelete" Icon="Delete" ToolTip="Xóa">
                    <Listeners>
                        <Click Handler="return checkDeleteAttackFile(#{fufQTDCTepTinDinhKem}.fileInput.dom, #{hdfQTDCTepTinDinhKem}, #{fufQTDCTepTinDinhKem});" />
                    </Listeners>
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
            MaxLength="500">
        </ext:TextArea>
    </Items>
    <Buttons>
        <ext:Button ID="btnCapNhatQuaTrinhDieuChuyen" runat="server" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputQuaTrinhDieuChuyen(#{fufQTDCTepTinDinhKem}.fileInput.dom);" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnCapNhatQuaTrinhDieuChuyen_Click" After="ResetWdQuaTrinhDieuChuyen();">
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
                <Click OnEvent="btnCapNhatQuaTrinhDieuChuyen_Click">
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
                <Click OnEvent="btnCapNhatQuaTrinhDieuChuyen_Click">
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
        <Hide Handler="#{btnCapNhatQuaTrinhDieuChuyen}.show();#{btnUpdateQuaTrinhDieuChuyen}.hide();#{Button32}.show();ResetWdQuaTrinhDieuChuyen();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdAddTaiSan" AutoHeight="true" Width="500" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Tài sản" Resizable="false">
    <Content>
        <ext:ComboBox runat="server" ID="cbTaiSan" Editable="true" AnchorHorizontal="100%" MinChars="1" PageSize="15"
            DisplayField="TEN" FieldLabel="Chọn tài sản<span style='color:red;'>*</span>"
            CtCls="requiredData" ValueField="MA" ItemSelector="div.list-item">
            <Store>
                <ext:Store ID="cbTaiSanStore" runat="server" AutoLoad="false">
                    <Proxy>
                        <ext:HttpProxy Json="true" Method="GET" Url="SearchDanhMucHandler.ashx">
                        </ext:HttpProxy>
                    </Proxy>
                    <BaseParams>
                        <ext:Parameter Name="table" Value="DM_VTHH" Mode="Value"></ext:Parameter>
                        <ext:Parameter Name="ma" Value="MA_VTHH" Mode="Value"></ext:Parameter>
                        <ext:Parameter Name="ten" Value="TEN_VTHH" Mode="Value"></ext:Parameter>
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
            </Store>
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
                <Focus Handler="#{cbTaiSanStore}.reload();" />
                <Select Handler="this.triggers[0].show(); #{DirectMethods}.GetDVTByTaiSan(#{cbTaiSan}.getValue());" />
                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
            </Listeners>
        </ext:ComboBox>
        <ext:Hidden ID="hdfDonViTinh" runat="server">
        </ext:Hidden>
        <ext:CompositeField runat="server" FieldLabel="Số lượng<span style='color:red;'>*</span>"
            AnchorHorizontal="100%">
            <Items>
                <ext:TextField runat="server" ID="txtTaiSanSoLuong" CtCls="requiredData" Width="80"
                    MaxLength="7" MaskRe="/[0-9]/" />
                <ext:DisplayField runat="server" Text="Đơn vị tính<span style='color:red;'>*</span>" />
                <ext:ComboBox runat="server" ID="cbxDonViTinh" Editable="true" Width="213" DisplayField="TEN"
                    FieldLabel="Đơn vị tính<span style='color:red;'>*</span>" CtCls="requiredData" MinChars="1" PageSize="15"
                    ValueField="MA" ItemSelector="div.list-item">
                    <Store>
                        <ext:Store ID="cbxDonViTinh_Store" runat="server" AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="SearchDanhMucHandler.ashx">
                                </ext:HttpProxy>
                            </Proxy>
                            <BaseParams>
                                <ext:Parameter Name="table" Value="DM_DVT" Mode="Value"></ext:Parameter>
                                <ext:Parameter Name="ma" Value="MA_DVT" Mode="Value"></ext:Parameter>
                                <ext:Parameter Name="ten" Value="TEN_DVT" Mode="Value"></ext:Parameter>
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
                    </Store>
                    <Triggers>
                        <ext:FieldTrigger Icon="SimpleEllipsis" />
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
                    <Listeners>
                        <Focus Handler="#{cbxDonViTinh_Store}.reload();" />
                        <Select Handler="this.triggers[0].show();#{hdfDonViTinh}.setValue(#{cbxDonViTinh}.getValue());" />
                        <TriggerClick Handler="#{wdDonViTinh}.show();" />
                    </Listeners>
                </ext:ComboBox>
            </Items>
        </ext:CompositeField>
        <ext:DateField ID="tsDateField" runat="server" FieldLabel="Ngày nhận" AnchorHorizontal="100%" MaskRe="/[0-9\/]/"
            Editable="true" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Format="d/M/yyyy" />
        <ext:TextField ID="tsTxtinhTrang" runat="server" FieldLabel="Tình trạng<span style='color:red;'>*</span>"
            CtCls="requiredData" AnchorHorizontal="100%" MaxLength="50" />
        <ext:DateField runat="server" ID="dfTSanHSD" FieldLabel="Hạn sử dụng" Format="dd/MM/yyyy" />
        <ext:TextArea ID="tsGhiChu" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
            MaxLength="4000" />
    </Content>
    <Buttons>
        <ext:Button ID="Button2" runat="server" Text="Cập nhật" Icon="Disk">
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
        <ext:Button ID="btnUpdateTaiSan" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
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
<ext:Window runat="server" Hidden="true" Resizable="false" Padding="6" Layout="FormLayout"
    Modal="true" Width="500" ID="wdAttachFile" Title="Tệp tin đính kèm" Icon="Attach"
    AutoHeight="true" Constrain="true" LabelWidth="120">
    <Items>
        <ext:Hidden runat="server" ID="hdfDinhKem" />
        <ext:FileUploadField ID="file_cv" runat="server" FieldLabel="Tệp tin đính kèm<span style='color:red;'>*</span>"
            CtCls="requiredData" AnchorHorizontal="100%" Icon="Attach">
            <Listeners>
                <FileSelected Handler="GetFileNameUpload();" />
            </Listeners>
        </ext:FileUploadField>
        <ext:TextField ID="txtFileName" runat="server" AnchorHorizontal="100%" FieldLabel="Tên tệp tin<span style='color:red;'>*</span>"
            CtCls="requiredData" MaxLength="200" />
        <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtGhiChu" AnchorHorizontal="100%"
            MaxLength="500">
        </ext:TextArea>
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateAtachFile" runat="server" Icon="Disk" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputAttachFile();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateAtachFile_Click" After="ResetWdAttachFile();">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button10" runat="server" Icon="Disk" Text="Cập nhật & Đóng lại">
            <Listeners>
                <Click Handler="return CheckInputAttachFile();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateAtachFile_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnEditAttachFile" Hidden="true" runat="server" Icon="Disk" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputAttachFile();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateAtachFile_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button13" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdAttachFile}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{file_cv}.enable();" />
        <Hide Handler="#{btnEditAttachFile}.hide();#{Button10}.show();#{btnUpdateAtachFile}.show();ResetWdAttachFile();" />
    </Listeners>
</ext:Window>
<ext:Window runat="server" Hidden="true" Resizable="false" Padding="6" Layout="FormLayout"
    Modal="true" Width="500" ID="wdThuTucDauVao" Title="Thủ tục đầu vào" Icon="Attach"
    AutoHeight="true" Constrain="true" LabelWidth="120">
    <Items>
        <ext:Hidden runat="server" ID="hdfThuTucID" />
        <ext:TextField ID="txtTenThuTuc" runat="server" FieldLabel="Tên thủ tục đầu vào<span style='color:red;'>*</span>"
            CtCls="requiredData" AnchorHorizontal="100%" Icon="Attach">
        </ext:TextField>
        <ext:Checkbox ID="chbHoanThanh" runat="server" AnchorHorizontal="100%" FieldLabel="Đã hoàn thành<span style='color:red;'>*</span>"
            CtCls="requiredData" MaxLength="200" />
    </Items>
    <Buttons>
        <ext:Button ID="btnUpdateThuTuc" runat="server" Icon="Disk" Text="Cập nhật">
            <DirectEvents>
                <Click OnEvent="btnUpdateThuTuc_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnUpdateCloseThuTuc" runat="server" Icon="Disk" Text="Cập nhật & Đóng lại">
            <DirectEvents>
                <Click OnEvent="btnUpdateThuTuc_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnUpdateThuTuc1" Hidden="true" runat="server" Icon="Disk" Text="Cập nhật">
            <DirectEvents>
                <Click OnEvent="btnUpdateThuTuc_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Update">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnCloseThuTuc" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdThuTucDauVao}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{file_cv}.enable();" />
        <Hide Handler="#{btnUpdateThuTuc_Click}.hide();#{btnUpdateCloseThuTuc}.show();#{btnUpdateThuTuc1}.show();resetWdThuTuc();" />
    </Listeners>
</ext:Window>
<ext:Window runat="server" ID="wdAddBangCap" Width="600" EnableViewState="false"
    Title="Quá trình học tập" Resizable="false" Constrain="true" Modal="true" Icon="Add"
    AutoHeight="true" Hidden="true" Padding="6">
    <Items>
        <ext:Container runat="server" ID="Container13" Layout="ColumnLayout" Height="150">
            <Items>
                <ext:Container runat="server" ID="Container14" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfMaTruongDaoTao" />
                        <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" HideTrigger="false" DisplayField="TEN"
                            runat="server" FieldLabel="Trường đào tạo<span style='color:red;'>*</span>" CtCls="requiredData"
                            PageSize="15" ItemSelector="div.search-item" MinChars="1" EmptyText="Gõ để tìm kiếm"
                            ID="cbx_NoiDaoTaoBangCap" LoadingText="Đang tải dữ liệu...">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Store>
                                <ext:Store ID="cbx_NoiDaoTaoBangCapStore" runat="server" AutoLoad="false">
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
                                <Select Handler="this.triggers[0].show(); #{hdfMaTruongDaoTao}.setValue(#{cbx_NoiDaoTaoBangCap}.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfMaTruongDaoTao}.reset(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:ComboBox Editable="true" runat="server" DisplayField="TEN" ValueField="MA" MinChars="1" PageSize="15" ListWidth="250"
                            ID="cbx_hinhthucdaotaobang" FieldLabel="Hình thức<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="98%" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store runat="server" AutoLoad="false" ID="cbx_hinhthucdaotaobangStore">
                                    <Proxy>
                                        <ext:HttpProxy Json="true" Method="GET" Url="SearchDanhMucHandler.ashx"></ext:HttpProxy>
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_HT_DAOTAO" Mode="Value"></ext:Parameter>
                                        <ext:Parameter Name="ma" Value="MA_HT_DAOTAO" Mode="Value"></ext:Parameter>
                                        <ext:Parameter Name="ten" Value="TEN_HT_DAOTAO" Mode="Value"></ext:Parameter>
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
                            </Store>
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
                            <Listeners>
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                <Focus Handler="  #{cbx_hinhthucdaotaobangStore}.reload(); " />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField ID="txt_khoa" AllowBlank="true" runat="server" FieldLabel="Khoa" AnchorHorizontal="98%"
                            MaxLength="200">
                        </ext:TextField>
                        <ext:Checkbox ID="Chk_DaTotNghiep" runat="server" AnchorHorizontal="98%" BoxLabel="Đã tốt nghiệp"
                            Checked="false">
                            <Listeners>
                                <Check Handler="
                                    if (#{Chk_DaTotNghiep}.checked == true) {
                                        #{cbx_xeploaiBangCap}.enable();
                                        #{txtNamNhanBang}.enable();
                                    }
                                    else {
                                        #{cbx_xeploaiBangCap}.disable();
                                        #{txtNamNhanBang}.disable();
                                        #{cbx_xeploaiBangCap}.reset();
                                        #{txtNamNhanBang}.reset();
                                    }
                                " />
                            </Listeners>
                        </ext:Checkbox>
                        <ext:ComboBox Editable="true" runat="server" ID="cbx_xeploaiBangCap" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            ValueField="MA" FieldLabel="Xếp loại" AnchorHorizontal="98%" ItemSelector="div.list-item"
                            Disabled="true">
                            <Store>
                                <ext:Store runat="server" ID="cbx_xeploaiBangCapStore" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Json="true" Method="GET" Url="SearchDanhMucHandler.ashx"></ext:HttpProxy>
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_XEPLOAI" Mode="Value"></ext:Parameter>
                                        <ext:Parameter Name="ma" Value="MA_XEPLOAI" Mode="Value"></ext:Parameter>
                                        <ext:Parameter Name="ten" Value="TEN_XEPLOAI" Mode="Value"></ext:Parameter>
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
                            </Store>
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
                            <Listeners>
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                <Focus Handler="#{cbx_xeploaiBangCapStore}.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="Container15" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfMaChuyenNganh" />
                        <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" DisplayField="TEN" runat="server"
                            FieldLabel="Chuyên ngành<span style='color:red;'>*</span>" CtCls="requiredData" Editable="true"
                            PageSize="15" HideTrigger="false" ItemSelector="div.search-item" MinChars="1" ListWidth="250"
                            EmptyText="Gõ để tìm kiếm" ID="cbx_ChuyenNganhBangCap" LoadingText="Đang tải dữ liệu...">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Store>
                                <ext:Store ID="Store1" runat="server" AutoLoad="false">
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
                            <Template ID="Template16" runat="server">
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
                                <Select Handler="this.triggers[0].show(); #{hdfMaChuyenNganh}.setValue(#{cbx_ChuyenNganhBangCap}.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfMaChuyenNganh}.reset(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:ComboBox Editable="true" runat="server" DisplayField="TEN" ValueField="MA" MinChars="15" PageSize="15" ListWidth="250"
                            ID="cbx_trinhdobangcap" FieldLabel="Trình độ<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="98%" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store runat="server" ID="cbx_trinhdobangcapStore" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_TRINHDO" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_TRINHDO" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_TRINHDO" Mode="Value" />
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
                            <Listeners>
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                <Focus Handler="#{cbx_trinhdobangcapStore}.reload();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="txtTuNam" FieldLabel="Từ năm" AnchorHorizontal="98%"
                            MaskRe="[0-9]" MaxLength="4" MinLength="4">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txtDenNam" FieldLabel="Đến năm" AnchorHorizontal="98%"
                            MaskRe="[0-9]" MaxLength="4" MinLength="4">
                        </ext:TextField>
                        <%--<ext:DateField runat="server" Vtype="daterange" ID="df_ngaybatdauhoc" FieldLabel="Từ ngày"
                            AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy">
                        </ext:DateField>
                        <ext:DateField runat="server" Vtype="daterange" ID="df_ngayketthuchoc" FieldLabel="Đến ngày"
                            AnchorHorizontal="98%" Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy">
                          --%>
                        <ext:TextField runat="server" ID="txtNamNhanBang" FieldLabel="Năm nhận bằng" AnchorHorizontal="98%"
                            MaskRe="[0-9]" MaxLength="4" MinLength="4" />
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnUpdateBangCap" Icon="Disk" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputBangCap();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateBangCap_Click" After="ResetWdBangCap();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btn_EditBangCap" Hidden="true" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputBangCap();" />
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
        <ext:Button runat="server" ID="btnUpdateandCloseBangCap" Icon="Disk" Text="Cập nhật & đóng lại">
            <Listeners>
                <Click Handler="return CheckInputBangCap();" />
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
        <ext:Button runat="server" ID="btn_ThoatBangCap" Icon="Decline" Text="Đóng lại">
            <Listeners>
                <Click Handler="#{wdAddBangCap}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="#{btnUpdateBangCap}.show();#{btn_EditBangCap}.hide();#{btnUpdateandCloseBangCap}.show();ResetWdBangCap();" />
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
                            CtCls="requiredData" AnchorHorizontal="95%" AllowBlank="false" MaxLength="500">
                        </ext:TextField>
                        <ext:DateField runat="server" Vtype="daterange" EnableKeyEvents="true" ID="dfKNLVTuNgay"
                            FieldLabel="Từ ngày<span style='color:red;'>*</span>" CtCls="requiredData" Editable="true" MaskRe="/[0-9\/]/"
                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Format="d/M/yyyy" AnchorHorizontal="95%">
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="Container12" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:TextField runat="server" ID="txt_vitriconviec" FieldLabel="Vị trí công việc<span style='color:red;'>*</span>"
                            CtCls="requiredData" AllowBlank="false" AnchorHorizontal="100%" MaxLength="500">
                        </ext:TextField>
                        <ext:DateField runat="server" ID="dfKNLVDenNgay" Vtype="daterange" FieldLabel="Đến ngày"
                            Editable="true" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Format="d/M/yyyy" AnchorHorizontal="100%">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:TextField runat="server" ID="txtThanhTichTrongCongViec" FieldLabel="Thành tích"
            EmptyText="Thành tích đạt được trong công việc" AllowBlank="true" AnchorHorizontal="100%"
            MaxLength="500">
        </ext:TextField>
        <ext:Container AnchorHorizontal="100%" runat="server" Height="30" Layout="ColumnLayout">
            <Items>
                <ext:Container ColumnWidth="0.5" runat="server" Layout="FormLayout" Height="30">
                    <Items>
                        <ext:TextField MaskRe="[0-9]" ID="nbfMucLuong" AnchorHorizontal="95%" runat="server"
                            FieldLabel="Mức lương" MaxLength="15" />
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txtLyDoThoiViec" FieldLabel="Lý do thôi việc" ColumnWidth="0.5"
                    MaxLength="200" />
            </Items>
        </ext:Container>
        <ext:TextArea runat="server" ID="txtGhiChuKinhNghiemLamViec" FieldLabel="Ghi chú"
            AnchorHorizontal="100%" MaxLength="500" Height="50">
        </ext:TextArea>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="Update" Icon="Disk" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputKinhNghiemLamViec();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="Update_Click" After="ResetWdKinhNghiemLamViec();">
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
                <Click OnEvent="Update_Click">
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
                <Click OnEvent="Update_Click">
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
                <ext:Container runat="server" ID="Container11" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:ComboBox runat="server" ValueField="MA" DisplayField="TEN" MinChars="1" PageSize="15" ListWidth="250"
                            ID="cbx_tenchungchi" FieldLabel="Chứng chỉ<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="95%" Editable="true" ItemSelector="div.list-item">
                            <Store>
                                <ext:Store runat="server" ID="cbx_tenchungchiStore" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_CHUNGCHI" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_CHUNGCHI" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_CHUNGCHI" Mode="Value" />
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
                            <Listeners>
                                <Focus Handler="#{cbx_tenchungchiStore}.reload();" />
                                <Select Handler="this.triggers[0].show();" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="Container16" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:ComboBox runat="server" ID="cbx_XepLoaiChungChi" DisplayField="TEN_XEPLOAI" MinChars="1" PageSize="15" ListWidth="250"
                            ValueField="MA_XEPLOAI" FieldLabel="Xếp loại" AnchorHorizontal="100%" Editable="true"
                            ItemSelector="div.list-item">
                            <Store>
                                <ext:Store runat="server" ID="cbx_XepLoaiChungChiStore" AutoLoad="false">
                                    <Proxy>
                                        <ext:HttpProxy Method="POST" Url="SearchDanhMucHandler.ashx" />
                                    </Proxy>
                                    <BaseParams>
                                        <ext:Parameter Name="table" Value="DM_XEPLOAI" Mode="Value" />
                                        <ext:Parameter Name="ma" Value="MA_XEPLOAI" Mode="Value" />
                                        <ext:Parameter Name="ten" Value="TEN_XEPLOAI" Mode="Value" />
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
                            <Listeners>
                                <Focus Handler="#{cbx_XepLoaiChungChiStore}.reload();" />
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
            MaxLength="500">
        </ext:TextField>
        <ext:Container runat="server" ID="Container17" Layout="ColumnLayout" Height="27">
            <Items>
                <ext:Container runat="server" ID="Container23" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:DateField runat="server" ID="df_NgayCap" Vtype="daterange" FieldLabel="Ngày cấp"
                            Editable="true" MaskRe="/[0-9\/]/" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" Format="d/M/yyyy" AnchorHorizontal="95%">
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="Container24" Layout="FormLayout" ColumnWidth=".5">
                    <Items>
                        <ext:DateField runat="server" ID="df_NgayHetHan" Vtype="daterange" FieldLabel="Ngày hết hạn"
                            Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" AnchorHorizontal="100%">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
        </ext:Container>
        <ext:TextArea runat="server" ID="txtGhiChuChungChi" FieldLabel="Ghi chú" AnchorHorizontal="100%"
            MaxLength="5000">
        </ext:TextArea>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnUpdateChungChi" Icon="Disk" Text="Cập nhật">
            <Listeners>
                <Click Handler="return CheckInputChungChi();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateChungChi_Click" After="ResetWdChungChi();">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnEditChungChi" Hidden="true" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return CheckInputChungChi();" />
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
        <ext:Button runat="server" ID="btnUpdateandCloseChungChi" Icon="Disk" Text="Cập nhật & đóng lại">
            <Listeners>
                <Click Handler="return CheckInputChungChi();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdateChungChi_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="Button3" Icon="Decline" Text="Đóng lại">
            <Listeners>
                <Click Handler="#{wdAddChungChi}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="#{btnUpdateChungChi}.show();#{btnEditChungChi}.hide();#{btnUpdateandCloseChungChi}.show();ResetWdChungChi();" />
    </Listeners>
</ext:Window>
<ext:Window ID="wdTaiNanLaoDong" AutoHeight="true" Width="400" runat="server" Padding="6"
    EnableViewState="false" Layout="FormLayout" Modal="true" Hidden="true" Constrain="true"
    Icon="Add" Title="Tai nạn lao động" Resizable="false">
    <Items>
        <ext:DateField runat="server" ID="TaiNan_dfNgayXayRa" EnableKeyEvents="true" CtCls="requiredData"
            Editable="true" FieldLabel="Ngày xảy ra" AnchorHorizontal="100%" MaskRe="/[0-9\/]/"
            Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
            RegexText="Định dạng ngày không đúng" Vtype="daterange">
        </ext:DateField>
        <ext:TextField ID="TaiNan_txtLydo" runat="server" FieldLabel="Nguyên nhân<span style='color:red;'>*</span>"
            CtCls="requiredData" AnchorHorizontal="100%" MaxLength="500" />
        <ext:TextField runat="server" ID="TaiNan_txtDiaDiemXayRa" FieldLabel="Địa điểm<span style='color:red;'>*</span>"
            CtCls="requiredData" AnchorHorizontal="100%" MaxLength="500" />
        <ext:TextField runat="server" ID="TaiNan_txtThietHai" FieldLabel="Thiệt hại" AnchorHorizontal="100%"
            MaxLength="500" />
        <ext:TextField runat="server" ID="TaiNan_txtThuongTat" FieldLabel="Thương tật" AnchorHorizontal="100%"
            MaxLength="500" />
        <ext:TextField runat="server" ID="TaiNan_txtBoiThuong" MaskRe="/[0-9]/" FieldLabel="Bồi thường"
            AnchorHorizontal="100%" MaxLength="15">
        </ext:TextField>
        <ext:DateField runat="server" ID="TaiNan_txtNgayBoiThuong" EnableKeyEvents="true"
            Editable="true" FieldLabel="Ngày bồi thường" AnchorHorizontal="100%" MaskRe="/[0-9\/]/"
            Format="dd/MM/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
            RegexText="Định dạng ngày không đúng" Vtype="daterange">
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
<ext:Hidden runat="server" ID="hdfRecordID" />
<ext:TabPanel ID="TabPanelBottom" runat="server" EnableTabScroll="true" AnchorHorizontal="100%"
    Height="220" Border="false">
    <Plugins>
        <ext:TabCloseMenu CloseOtherTabsText="Đóng Tab khác" CloseAllTabsText="Đóng tất cả các Tab"
            CloseTabText="Đóng Tab">
        </ext:TabCloseMenu>
        <ext:TabScrollerMenu ID="TabScrollerMenu1" runat="server" />
    </Plugins>
    <Items>
        <ext:Panel ID="panelGeneralInformation" Cls="panelGeneralInformation" Title="<%$ Resources:HOSO, personal_information%>"
            Height="200" Padding="6" runat="server" Layout="FormLayout">
            <Items>
                <ext:Container ID="Container1" Layout="ColumnLayout" runat="server" Height="200"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container20" Layout="FormLayout" runat="server" Width="130">
                            <Items>
                                <ext:ImageButton ID="hsImage" OverImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg"
                                    ImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg" runat="server" Width="120"
                                    Height="150">
                                    <Listeners>
                                        <Click Handler="#{wdUploadImageWindow}.show();" />
                                    </Listeners>
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
                                                    runat="server" ID="txtMaCB">
                                                    <%--<Listeners>
                                                        <Focus Handler="this.blur();" />
                                                    </Listeners>--%>
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Họ tên" AnchorHorizontal="95%" runat="server" ID="txtFullName">
                                                    <%--<Listeners>
                                                        <Focus Handler="this.blur();" />
                                                    </Listeners>--%>
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Bí danh" AnchorHorizontal="95%" runat="server" ID="txtBiDanh" Hidden="true">
                                                    <%--<Listeners>
                                                        <Focus Handler="this.blur();" />
                                                    </Listeners>--%>
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Ngày thử việc" runat="server" AnchorHorizontal="95%" ID="txtNgayThuViec">
                                                    <%--<Listeners>
                                                        <Focus Handler="this.blur();" />
                                                    </Listeners>--%>
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Ngày nhận" runat="server" AnchorHorizontal="95%" ID="txtNgayNhan">
                                                    <%--<Listeners>
                                                        <Focus Handler="this.blur();" />
                                                    </Listeners>--%>
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Ngạch" runat="server" AnchorHorizontal="95%" ID="txtNgach">
                                                    <%--<Listeners>
                                                        <Focus Handler="this.blur();" />
                                                    </Listeners>--%>
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container2" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                            <Items>
                                                <ext:TextField FieldLabel="Số CMND" runat="server" AnchorHorizontal="95%" ID="txtSoCMND">
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Ngày cấp CMND" runat="server" AnchorHorizontal="95%" ID="txtNgayCapCMND">
                                                </ext:TextField>
                                                <ext:TextField AnchorHorizontal="95%" FieldLabel="Nơi cấp CMND" runat="server" ID="txtNoiCapCMND">
                                                </ext:TextField>
                                                <ext:TextField runat="server" FieldLabel="Người liên hệ" ID="txtNguoiLienHe" AnchorHorizontal="95%"
                                                    EmptyText="Người liên hệ trong trường hợp khẩn cấp">
                                                </ext:TextField>
                                                <ext:TextField runat="server" FieldLabel="Quan hệ với CB" ID="txtMoiQuanHe" AnchorHorizontal="95%"
                                                    EmptyText="Mối quan hệ với cán bộ">
                                                </ext:TextField>
                                                <ext:TextField runat="server" FieldLabel="SDT người LH" ID="txtSDTNguoiLienHe" AnchorHorizontal="95%"
                                                    EmptyText="Số điện thoại người liên hệ">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container3" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                            <Items>
                                                <ext:TextField FieldLabel="Điện thoại CQ" AnchorHorizontal="95%" runat="server" ID="txtDTCoQuan">
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Điện thoại nhà" runat="server" AnchorHorizontal="95%"
                                                    ID="txtDTNha">
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Số hộ chiếu" EnableKeyEvents="true" runat="server" AnchorHorizontal="95%"
                                                    ID="txtSoHoChieu">
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Ngày cấp HC" runat="server" AnchorHorizontal="95%" ID="txtNgayCapHC">
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Nơi cấp HC" AnchorHorizontal="95%" runat="server" ID="txtNoiCapHC">
                                                </ext:TextField>
                                                <ext:TextField FieldLabel="Loại HĐ" runat="server" AnchorHorizontal="95%" ID="txtLoaiHD">
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
        <ext:Panel ID="panelHoSoTuyenDung" Title="Hồ sơ tuyển dụng" Height="200" Hidden="true"
            runat="server" Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuShowHoSoTuyenDung}.setDisabled(false);" />
                <Activate Handler="" />
            </Listeners>
            <Items>
                <ext:GridPanel ID="GridPanelHoSoTuyenDung" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AnchorHorizontal="100%" AutoExpandColumn="NHAN_XET" Region="Center">
                    <Store>
                        <ext:Store ID="StoreHoSoTuyenDung" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreHoSoTuyenDung_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="VONG_THI" />
                                        <ext:RecordField Name="NGAY_THI" />
                                        <ext:RecordField Name="MA_MON_THI" />
                                        <ext:RecordField Name="TEN_MON_THI" />
                                        <ext:RecordField Name="DIEM" />
                                        <ext:RecordField Name="DIEM_DAT" />
                                        <ext:RecordField Name="TRONG_SO" />
                                        <ext:RecordField Name="NHAN_XET" />
                                        <ext:RecordField Name="MA_NGUOI_CHAM" />
                                        <ext:RecordField Name="TEN_NGUOI_CHAM" />
                                        <ext:RecordField Name="KET_QUA" />
                                        <ext:RecordField Name="NGAY_TAO" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel1" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="VONG_THI" Header="Vòng thi" Width="70" DataIndex="VONG_THI"
                                Align="Right" />
                            <ext:DateColumn ColumnID="NGAY_THI" Header="Ngày thi tuyển" Width="150" DataIndex="NGAY_THI"
                                Align="Right" />
                            <ext:Column ColumnID="TEN_MON_THI" Header="Môn thi" Width="75" DataIndex="TEN_MON_THI">
                            </ext:Column>
                            <ext:Column ColumnID="DIEM" Header="Điểm" Width="75" DataIndex="DIEM" Align="Right">
                            </ext:Column>
                            <ext:Column ColumnID="DIEM_DAT" Header="Điểm đạt" Width="75" DataIndex="DIEM_DAT"
                                Align="Right">
                            </ext:Column>
                            <ext:Column ColumnID="TEN_NGUOI_CHAM" Header="Người chấm" Width="150" DataIndex="TEN_NGUOI_CHAM">
                            </ext:Column>
                            <ext:Column ColumnID="KET_QUA" Header="Kết quả" Width="75" DataIndex="KET_QUA" Align="Center">
                                <Renderer Fn="GetBooleanIconHSUV" />
                            </ext:Column>
                            <ext:Column ColumnID="NHAN_XET" Header="Nhận xét" Width="75" DataIndex="NHAN_XET">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelHoSoTuyenDung" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelQuaTrinhDaoTao" Title="Quá trình đào tạo" Layout="BorderLayout"
            Hidden="true" runat="server" Closable="true" CloseAction="Hide">
            <Listeners>
                <Close Handler="#{mnuQuaTrinhDaoTao}.setDisabled(false);" />
                <Activate Handler="if(#{hdfQTDTRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreQuaTrinhDaoTao}.reload();
                                        #{hdfQTDTRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfQTDTRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelQTDT" runat="server" Region="Center" StripeRows="true"
                    Border="false" TrackMouseOver="true">
                    <Store>
                        <ext:Store ID="StoreQuaTrinhDaoTao" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesStoreQuaTrinhDaoTao" SkipIdForNewRecords="false"
                            RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreQuaTrinhDaoTao_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="DaThamGia" />
                                        <ext:RecordField Name="Diem" />
                                        <ext:RecordField Name="KetQua" />
                                        <ext:RecordField Name="NhanXetCuaGiaoVien" />
                                        <ext:RecordField Name="SoTienCongTyDong" />
                                        <ext:RecordField Name="SoTienNhanVienDong" />
                                        <ext:RecordField Name="DaoTaoTuNgay" />
                                        <ext:RecordField Name="KetThucDaoTao" />
                                        <ext:RecordField Name="MaKhoaDaoTao" />
                                        <ext:RecordField Name="TenKhoaDaoTao" />
                                        <ext:RecordField Name="DiaDiemDaoTao" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                            <ext:Column ColumnID="MaKhoaDaoTao" Locked="true" Header="Mã khóa học" Width="80"
                                DataIndex="MaKhoaDaoTao" />
                            <ext:Column ColumnID="TenKhoaDaoTao" Locked="true" Width="200" Header="Tên khóa đào tạo"
                                DataIndex="TenKhoaDaoTao" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="DaoTaoTuNgay" Header="Từ ngày" DataIndex="DaoTaoTuNgay" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="KetThucDaoTao" Header="Đến ngày" Width="70"
                                DataIndex="KetThucDaoTao" />
                            <ext:Column ColumnID="DiaDiemDaoTao" Header="Địa điểm đào tạo" Width="150" DataIndex="DiaDiemDaoTao" />
                            <ext:Column ColumnID="DaThamGia" Header="Đã Tham gia" DataIndex="DaThamGia">
                                <Editor>
                                    <ext:Checkbox runat="server" ID="chkDaThamGia" />
                                </Editor>
                                <Renderer Fn="GetBooleanIcon" />
                            </ext:Column>
                            <ext:Column ColumnID="Diem" Header="Điểm" Width="60" DataIndex="Diem">
                                <Editor>
                                    <ext:NumberField runat="server" ID="txtDiemNV" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="KetQua" Header="Kết quả" Width="120" DataIndex="KetQua">
                                <Editor>
                                    <ext:TextField runat="server" ID="txtKetQuaKhoaHoc" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="NhanXetCuaGiaoVien" Header="Giáo viên nhận xét" Width="200"
                                DataIndex="NhanXetCuaGiaoVien">
                                <Editor>
                                    <ext:TextField runat="server" ID="TextField1" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="SoTienCongTyDong" Header="Công ty hỗ trợ" Width="100" DataIndex="SoTienCongTyDong">
                                <Renderer Fn="RenderVND" />
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField1" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="SoTienNhanVienDong" Header="Nhân viên đóng" Width="100" DataIndex="SoTienNhanVienDong">
                                <Renderer Fn="RenderVND" />
                                <Editor>
                                    <ext:NumberField runat="server" ID="NumberField2" />
                                </Editor>
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <View>
                        <ext:LockingGridView ID="lkvKhoaDaoTao" />
                    </View>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelQuaTrinhDaoTao" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelBaoHiem" Title="Bảo hiểm" runat="server" Hidden="true" Closable="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuBaoHiem}.setDisabled(false);" />
                <Activate Handler="if(#{hdfBHRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreBaoHiem}.reload();
                                        #{hdfBHRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfBHRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelBaoHiem" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AnchorHorizontal="100%" Region="Center" AutoExpandColumn="TEN_CONGVIEC">
                    <Store>
                        <ext:Store ID="StoreBaoHiem" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreBaoHiems_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="TU_NGAY" />
                                        <ext:RecordField Name="DEN_NGAY" />
                                        <ext:RecordField Name="TEN_CONGVIEC" />
                                        <ext:RecordField Name="DON_VI" />
                                        <ext:RecordField Name="HS_LUONG" />
                                        <ext:RecordField Name="PHUCAP" />
                                        <ext:RecordField Name="MUC_LUONG" />
                                        <ext:RecordField Name="TYLE" />
                                        <ext:RecordField Name="GHI_CHU" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModelBaoHiem" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TEN_CONGVIEC" Header="Tên công việc" DataIndex="TEN_CONGVIEC" />
                            <ext:Column ColumnID="DON_VI" Width="220" Header="Đơn vị" DataIndex="DON_VI" />
                            <ext:Column ColumnID="HS_LUONG" Header="Hệ số lương" DataIndex="HS_LUONG" />
                            <ext:Column ColumnID="PHUCAP" Header="Phụ cấp" DataIndex="PHUCAP" />
                            <ext:Column ColumnID="MUC_LUONG" Header="Mức lương" DataIndex="MUC_LUONG">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="TYLE" Header="Tỷ lệ" DataIndex="TYLE">
                                <Renderer Fn="RenderPercent" />
                            </ext:Column>
                            <ext:Column ColumnID="TU_NGAY" Header="Từ ngày" Width="70" DataIndex="TU_NGAY" />
                            <ext:Column ColumnID="DEN_NGAY" Header="Đến ngày" Width="70" DataIndex="DEN_NGAY" />
                            <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelBaoHiem" runat="server" SingleSelect="true">
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
        <ext:Panel ID="panelDaiBieu" Title="Đại biểu" runat="server" Hidden="true" Closable="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuDaiBieu}.setDisabled(false);" />
                <Activate Handler="if(#{hdfDBRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreDaiBieu}.reload();
                                        #{hdfDBRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfDBRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelDaiBieu" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AnchorHorizontal="100%" Region="Center" AutoExpandColumn="LOAI_HINH">
                    <Store>
                        <ext:Store ID="StoreDaiBieu" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreDaiBieu_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="TU_NGAY" />
                                        <ext:RecordField Name="DEN_NGAY" />
                                        <ext:RecordField Name="LOAI_HINH" />
                                        <ext:RecordField Name="NHIEM_KY" />
                                        <ext:RecordField Name="GHI_CHU" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel3" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="LOAI_HINH" Header="Loại hình" DataIndex="LOAI_HINH" />
                            <ext:Column ColumnID="NHIEM_KY" Header="Nhiệm kỳ" DataIndex="NHIEM_KY" />
                            <ext:Column ColumnID="TU_NGAY" Header="Từ ngày" DataIndex="TU_NGAY">
                                <Renderer Fn="ConvertStringToDateFormat" />
                            </ext:Column>
                            <ext:Column ColumnID="DEN_NGAY" Header="Từ ngày" DataIndex="DEN_NGAY">
                                <Renderer Fn="ConvertStringToDateFormat" />
                            </ext:Column>
                            <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelDaiBieu" runat="server" SingleSelect="true">
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
        <ext:Panel ID="panelDanhGia" Title="Đánh giá" Border="false" runat="server" Hidden="true"
            Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuDanhGia}.setDisabled(false);" />
                <Activate Handler="if(#{hdfDGRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{hdfDGRecordID}.setValue(#{hdfRecordID}.getValue());
                                        #{StoreDanhGia}.reload();
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfDGRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelDanhGia" runat="server" StripeRows="true" Border="false"
                    Region="Center" TrackMouseOver="true" AnchorHorizontal="100%" AutoExpandColumn="TenDotDanhGia">
                    <Store>
                        <ext:Store ID="StoreDanhGia" AutoLoad="false" runat="server" IgnoreExtraFields="false">
                            <Proxy>
                                <ext:HttpProxy Method="GET" Url="HandlerDanhGia.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaCB" Value="hdfRecordID.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="MaDotDanhGia" />
                                        <ext:RecordField Name="TenDotDanhGia" />
                                        <ext:RecordField Name="TuNgay" />
                                        <ext:RecordField Name="DenNgay" />
                                        <ext:RecordField Name="DiemTuDanhGia" />
                                        <ext:RecordField Name="NguoiKhacDanhGia" />
                                        <ext:RecordField Name="DiemNguoiQLDanhGia" />
                                        <ext:RecordField Name="NhanXet" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel4" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="MaDotDanhGia" Header="Mã đợt" Width="70" DataIndex="MaDotDanhGia" />
                            <ext:Column ColumnID="TenDotDanhGia" Header="Tên đợt đánh giá" Width="200" DataIndex="TenDotDanhGia" />
                            <ext:Column ColumnID="TuNgay" Width="90" Header="Từ ngày" DataIndex="TuNgay" />
                            <ext:Column ColumnID="DenNgay" Width="90" Header="Đến ngày" DataIndex="DenNgay" />
                            <ext:Column ColumnID="DiemTuDanhGia" Width="80" Header="Tự đánh giá" DataIndex="DiemTuDanhGia" />
                            <ext:Column ColumnID="NguoiKhacDanhGia" Width="120" Header="Người khác đánh giá"
                                DataIndex="NguoiKhacDanhGia" />
                            <ext:Column ColumnID="DiemNguoiQLDanhGia" Width="130" Header="Người quản lý đánh giá"
                                DataIndex="DiemNguoiQLDanhGia" />
                        </Columns>
                    </ColumnModel>
                    <Plugins>
                        <ext:RowExpander runat="server" ID="rx">
                            <Template ID="Template1" runat="server">
                                <Html>
                                    <table border="0" cellpadding="10" cellspacing="5">
                                        <tr>
                                            <td><b>Nhận xét</b></td>
                                            <td><tpl if="NhanXet &gt; ''">{NhanXet}</tpl></td>
                                        </tr>
                                    </table>
                                </Html>
                            </Template>
                        </ext:RowExpander>
                    </Plugins>
                    <%--<BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                            PageSize="10" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                            DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                            <Items>
                                <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="5" />
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="15" />
                                    </Items>
                                    <SelectedItem Value="10" />
                                    <Listeners>
                                        <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>--%>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelDanhGia" runat="server" SingleSelect="true">
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelDienBienLuong" Title="Diễn biến lương" Hidden="true" runat="server"
            Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuDienBienLuong}.setDisabled(false);" />
                <Activate Handler="if(#{hdfDBLRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreDienBienLuong}.reload();
                                        #{hdfDBLRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfDBLRecordID" runat="server" />
                <ext:Hidden ID="hdfIDHoSoLuong" runat="server" />
                <ext:GridPanel ID="GridPanelDienBienLuong" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="GhiChu" AutoExpandMin="100">
                    <Store>
                        <ext:Store ID="StoreDienBienLuong" AutoSave="true" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                            RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreDienBienLuong_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="SoQuyetDinh" />
                                        <ext:RecordField Name="HeSoLuong" />
                                        <ext:RecordField Name="LuongCung" />
                                        <ext:RecordField Name="LuongDongBHXH" />
                                        <ext:RecordField Name="BacLuong" />
                                        <ext:RecordField Name="NgayHuongLuong" />
                                        <ext:RecordField Name="BacLuongNB" />
                                        <ext:RecordField Name="NgayHuongLuongNB" />
                                        <ext:RecordField Name="NgayQuyetDinh" />
                                        <ext:RecordField Name="NgayHieuLuc" />
                                        <ext:RecordField Name="NgayKetThucHieuLuc" />
                                        <ext:RecordField Name="NguoiQuyetDinh" />
                                        <ext:RecordField Name="LoaiLuong" />
                                        <ext:RecordField Name="GhiChu" />
                                        <ext:RecordField Name="PhanTramHuongLuong" />
                                        <ext:RecordField Name="CreatedDate" />
                                        <ext:RecordField Name="TrangThai" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel5" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="SoQuyetDinh" Width="85" Header="Số quyết định" DataIndex="SoQuyetDinh" />
                            <ext:Column ColumnID="HeSoLuong" Width="80" Header="Hệ số lương" DataIndex="HeSoLuong"
                                Align="Right" />
                            <ext:Column ColumnID="LuongCung" Width="100" Header="Lương cứng" DataIndex="LuongCung"
                                Align="Right">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="LuongDongBHXH" Width="100" Header="Lương đóng BHXH" DataIndex="LuongDongBHXH"
                                Align="Right">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <%--<ext:Column ColumnID="BacLuong" Width="65" Header="Bậc lương" DataIndex="BacLuong"
                                Align="Right" />--%>
                            <ext:DateColumn ColumnID="NgayHuongLuong" Width="110" Header="Ngày hưởng lương" Format="dd/MM/yyyy"
                                DataIndex="NgayHuongLuong" />
                            <%--<ext:Column ColumnID="BacLuongNB" Width="100" Header="Bậc lương nội bộ" DataIndex="BacLuongNB"
                                Align="Right" />--%>
                            <%--<ext:DateColumn ColumnID="NgayHuongLuongNB" Width="90" Header="Ngày HL nội bộ" Format="dd/MM/yyyy"
                                DataIndex="NgayHuongLuongNB" />--%>
                            <ext:Column ColumnID="NguoiQuyetDinh" Width="110" Header="Người quyết định" DataIndex="NguoiQuyetDinh" />
                            <ext:DateColumn Format="dd/MM/yyyy" Width="110" ColumnID="NgayQuyetDinh" Header="Ngày quyết định"
                                DataIndex="NgayQuyetDinh" />
                            <ext:DateColumn Format="dd/MM/yyyy" Width="100" ColumnID="NgayHieuLuc" Header="Ngày có hiệu lực"
                                DataIndex="NgayHieuLuc" />
                            <ext:DateColumn Format="dd/MM/yyyy" Width="100" ColumnID="NgayKetThucHieuLuc" Header="Ngày hết hiệu lực"
                                DataIndex="NgayKetThucHieuLuc" />
                            <%--<ext:Column ColumnID="LoaiLuong" Width="80" Header="Loại lương" DataIndex="LoaiLuong" />--%>
                            <%--<ext:Column ColumnID="PhanTramHuongLuong" Width="80" Header="Phần trăm HL" DataIndex="PhanTramHuongLuong" />--%>
                            <ext:Column ColumnID="TrangThai" Width="90" Header="Trạng thái" DataIndex="TrangThai">
                                <Renderer Fn="RenderTinhTrang" />
                            </ext:Column>
                            <%--<ext:DateColumn ColumnID="CreatedDate" Width="75" Header="Ngày tạo" Format="dd/MM/yyyy"
                                DataIndex="CreatedDate" />--%>
                            <ext:Column ColumnID="GhiChu" Width="100" Header="Ghi chú" DataIndex="GhiChu" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelDienBienLuong" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="#{hdfIDHoSoLuong}.setValue(#{RowSelectionModelDienBienLuong}.getSelected().id);" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelDeTai" Title="Đề tài" runat="server" Hidden="true" Closable="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuDeTai}.setDisabled(false);" />
                <Activate Handler="if(#{hdfDeTaiRecordID}.getValue()!= #{hdfRecordID}.getValue())
                                    {
                                        #{hdfDeTaiRecordID}.setValue(#{hdfRecordID}.getValue());
                                        #{StoreDetai}.reload();
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfDeTaiRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelDetai" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="TEN_DETAI">
                    <Store>
                        <ext:Store ID="StoreDetai" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreDetai_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="MaDeTai" />
                                        <ext:RecordField Name="TEN_DETAI" />
                                        <ext:RecordField Name="CAP_DETAI" />
                                        <ext:RecordField Name="TU_NGAY" />
                                        <ext:RecordField Name="DEN_NGAY" />
                                        <ext:RecordField Name="CHUNHIEM_DETAI" />
                                        <ext:RecordField Name="TUCACH_THAMGIA" />
                                        <ext:RecordField Name="KET_QUA" />
                                        <ext:RecordField Name="TepTinDinhKem" />
                                        <ext:RecordField Name="GHI_CHU" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel6" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
                            </ext:Column>
                            <ext:Column ColumnID="MaDeTai" Header="Mã đề tài" DataIndex="MaDeTai" />
                            <ext:Column ColumnID="TEN_DETAI" Header="Tên đề tài" DataIndex="TEN_DETAI" />
                            <ext:Column ColumnID="CAP_DETAI" Header="Cấp đề tài" DataIndex="CAP_DETAI" />
                            <ext:Column ColumnID="CHUNHIEM_DETAI" Header="Chủ nhiệm đề tài" DataIndex="CHUNHIEM_DETAI" />
                            <ext:Column ColumnID="TUCACH_THAMGIA" Header="Tư cách tham gia" DataIndex="TUCACH_THAMGIA" />
                            <ext:Column ColumnID="TU_NGAY" Header="Từ ngày" DataIndex="TU_NGAY">
                                <Renderer Fn="ConvertStringToDateFormat" />
                            </ext:Column>
                            <ext:Column ColumnID="DEN_NGAY" Header="Đến ngày" DataIndex="DEN_NGAY">
                                <Renderer Fn="ConvertStringToDateFormat" />
                            </ext:Column>
                            <ext:Column ColumnID="KET_QUA" Header="Kết quả" DataIndex="KET_QUA" />
                            <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelDeTai" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.TepTinDinhKem);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelHopDong" Title="Hợp đồng" runat="server" Hidden="true" Closable="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuHopDong}.setDisabled(false);" />
                <Activate Handler="if(#{hdfHDRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreHopDong}.reload();
                                        #{hdfHDRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfHDRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelHopDong" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="GhiChu">
                    <Store>
                        <ext:Store ID="StoreHopDong" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                            OnRefreshData="StoreHopDong_OnRefreshData" runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="SO_HDONG" />
                                        <ext:RecordField Name="TEN_LOAI_HDONG" />
                                        <ext:RecordField Name="TEN_CONGVIEC" />
                                        <ext:RecordField Name="NGAY_HDONG" />
                                        <ext:RecordField Name="NGAYKT_HDONG" />
                                        <ext:RecordField Name="NgayCoHieuLuc" />
                                        <ext:RecordField Name="TEN_TT_HDONG" />
                                        <ext:RecordField Name="TrangThaiHopDong" />
                                        <ext:RecordField Name="TepTinDinhKem" />
                                        <ext:RecordField Name="GhiChu" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel7" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
                            </ext:Column>
                            <ext:Column ColumnID="SO_HDONG" Header="Số hợp đồng" DataIndex="SO_HDONG" Width="100" />
                            <ext:Column ColumnID="TEN_LOAI_HDONG" Header="Loại hợp đồng" DataIndex="TEN_LOAI_HDONG"
                                Width="200" />
                            <ext:Column ColumnID="TEN_CONGVIEC" Width="120" Header="Công việc" DataIndex="TEN_CONGVIEC" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_HDONG" Header="Ngày ký kết" DataIndex="NGAY_HDONG" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayCoHieuLuc" Header="Ngày có hiệu lực"
                                DataIndex="NgayCoHieuLuc" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAYKT_HDONG" Header="Ngày kết thúc"
                                DataIndex="NGAYKT_HDONG" />
                            <ext:Column ColumnID="TEN_TT_HDONG" Header="Tình trạng" DataIndex="TEN_TT_HDONG" />
                            <ext:Column ColumnID="TrangThaiHopDong" Header="Trạng thái" DataIndex="TrangThaiHopDong">
                                <Renderer Fn="RenderTrangThaiHopDong" />
                            </ext:Column>
                            <ext:Column ColumnID="GhiChu" Header="Ghi chú" DataIndex="GhiChu" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelHopDong" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="" />
                        <ViewReady Handler="#{cbHopDongLoaiHopDongStore}.reload();
                            #{cbHopDongTinhTrangHopDongStore}.reload();
                            #{StoreCongViec}.reload();
                            #{cbx_HopDongChucVu_Store}.reload();" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.TepTinDinhKem);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelKhaNang" Title="Khả năng" runat="server" Hidden="true" Closable="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuKhaNang}.setDisabled(false);" />
                <Activate Handler="if(#{hdfKhaNangRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreKhaNang}.reload();
                                        #{hdfKhaNangRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfKhaNangRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelKhaNang" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="TEN_KHANANG">
                    <Store>
                        <ext:Store ID="StoreKhaNang" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreKhaNang_OnRefreshData"
                            runat="server">
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
                            <ext:RowNumbererColumn Width="35" Header="STT" />
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
                        <ViewReady Handler="#{cbKhaNangStore}.reload();
                            #{cbKhaNangXepLoaiStore}.reload();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelKhenThuong" Title="Khen thưởng" runat="server" Hidden="true"
            Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuKhenThuong}.setDisabled(false);" />
                <Activate Handler="if(#{hdfKhenThuongRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreKhenThuong}.reload();
                                        #{hdfKhenThuongRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfKhenThuongRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelKhenThuong" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="GHI_CHU">
                    <Store>
                        <ext:Store ID="StoreKhenThuong" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreKhenThuong_OnRefreshData"
                            runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="SO_QD" />
                                        <ext:RecordField Name="NGAY_QD" />
                                        <ext:RecordField Name="TEN_LYDO_KTHUONG" />
                                        <ext:RecordField Name="TEN_NGUOI_QD" />
                                        <ext:RecordField Name="TEN_HT_KTHUONG" />
                                        <ext:RecordField Name="SO_TIEN" />
                                        <ext:RecordField Name="GHI_CHU" />
                                        <ext:RecordField Name="TepTinDinhKem" />
                                        <ext:RecordField Name="Sodiem" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel9" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
                            </ext:Column>
                            <ext:Column ColumnID="TEN_LYDO_KTHUONG" Width="200" Header="Lý do khen thưởng" DataIndex="TEN_LYDO_KTHUONG" />
                            <ext:Column ColumnID="TEN_HT_KTHUONG" Width="150" Header="Hình thức khen thưởng"
                                DataIndex="TEN_HT_KTHUONG" />
                            <ext:Column ColumnID="SO_TIEN" Width="120" Header="Số tiền" DataIndex="SO_TIEN">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="Sodiem" Width="70" Align="Right" Header="Số điểm" DataIndex="Sodiem">
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
                                <RowSelect Handler="#{hdfButtonClick}.setValue('Edit');" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="" />
                        <ViewReady Handler="#{cbLyDoKhenThuongStore}.reload();
                            #{cbHinhThucKhenThuongStore}.reload();" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.TepTinDinhKem);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelKiLuat" Title="Kỷ luật" runat="server" Hidden="true" Closable="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuKyLuat}.setDisabled(false);" />
                <Activate Handler="if(#{hdfKyLuatRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreKyLuat}.reload();
                                        #{hdfKyLuatRecordID}.setValue(#{hdfRecordID}.getValue());
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
                                        <ext:RecordField Name="TEN_NGUOI_QD" />
                                        <ext:RecordField Name="NGAY_QD" />
                                        <ext:RecordField Name="TEN_LYDO_KYLUAT" />
                                        <ext:RecordField Name="TEN_HT_KYLUAT" />
                                        <ext:RecordField Name="SO_TIEN" />
                                        <ext:RecordField Name="GHI_CHU" />
                                        <ext:RecordField Name="TepTinDinhKem" />
                                        <ext:RecordField Name="Sodiem" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel10" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
                            </ext:Column>
                            <ext:Column ColumnID="TEN_LYDO_KYLUAT" Width="200" Header="Lý do kỷ luật" DataIndex="TEN_LYDO_KYLUAT" />
                            <ext:Column ColumnID="TEN_HT_KYLUAT" Width="150" Header="Hình thức kỷ luật" DataIndex="TEN_HT_KYLUAT" />
                            <ext:Column ColumnID="SO_TIEN" Width="110" Header="Số tiền" DataIndex="SO_TIEN">
                                <Renderer Fn="RenderVND" />
                            </ext:Column>
                            <ext:Column ColumnID="Sodiem" Width="70" Align="Right" Header="Số điểm" DataIndex="Sodiem">
                            </ext:Column>
                            <ext:Column ColumnID="SO_QD" Header="Số quyết định" DataIndex="SO_QD" />
                            <ext:Column ColumnID="TEN_NGUOI_QD" Header="Người quyết định" Width="120" DataIndex="TEN_NGUOI_QD" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_QD" Header="Ngày quyết định" DataIndex="NGAY_QD" />
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
                        <RowDblClick Handler="#{hdfButtonClick}.setValue('Edit');" />
                        <ViewReady Handler="#{cbLyDoKyLuatStore}.reload();
                           #{cbHinhThucKyLuatStore}.reload();" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.TepTinDinhKem);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelQuanHeGiaDinh" Title="Quan hệ gia đình" runat="server" Hidden="true"
            Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuQuanHeGiaDinh}.setDisabled(false);" />
                <Activate Handler="if(#{hdfQHGDRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreQHGD}.reload();
                                        #{hdfQHGDRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfQHGDRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelQHGD" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="GHI_CHU">
                    <Store>
                        <ext:Store ID="StoreQHGD" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreQHGD_OnRefreshData"
                            runat="server">
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
                                        <ext:RecordField Name="SoCMT" />
                                        <ext:RecordField Name="LaNguoiPhuThuoc" />
                                        <ext:RecordField Name="NgayBatDauGiamTru" Type="Date" />
                                        <ext:RecordField Name="NgayKetThucGiamTru" Type="Date" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel11" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="HO_TEN" Width="200" Header="Họ tên" DataIndex="HO_TEN" />
                            <ext:Column ColumnID="TUOI" Width="70" Header="Năm sinh" DataIndex="TUOI" />
                            <ext:Column ColumnID="GIOI_TINH" Width="50" Header="Giới tính" DataIndex="GIOI_TINH">
                                <Renderer Fn="GetRenderGT" />
                            </ext:Column>
                            <ext:Column ColumnID="TEN_QUANHE" Header="Quan hệ" DataIndex="TEN_QUANHE" />
                            <ext:Column ColumnID="NGHE_NGHIEP" Header="Nghề nghiệp" DataIndex="NGHE_NGHIEP" />
                            <ext:Column ColumnID="NOI_LAMVIEC" Header="Nơi làm việc" DataIndex="NOI_LAMVIEC" />
                            <ext:Column ColumnID="SoCMT" Header="Số CMT" Width="100" DataIndex="SoCMT" />
                            <ext:CheckColumn ColumnID="LaNguoiPhuThuoc" Header="Là người phụ thuộc" Width="110"
                                DataIndex="LaNguoiPhuThuoc" />
                            <ext:DateColumn ColumnID="NgayBatDauGiamTru" Width="70" Header="Ngày bắt đầu giảm trừ"
                                DataIndex="NgayBatDauGiamTru" />
                            <ext:DateColumn ColumnID="NgayKetThucGiamTru" Width="70" Header="Ngày kết thúc giảm trừ"
                                DataIndex="NgayKetThucGiamTru" />
                            <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" DataIndex="GHI_CHU" />
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
                        <ViewReady Handler="#{cbQuanHeGiaDinhStore}.reload();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelQuaTrinhCongTac" Title="Quá trình công tác" runat="server" Hidden="true"
            Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuQuaTrinhCongTac}.setDisabled(false);" />
                <Activate Handler="if(#{hdfQTCTRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreQuaTrinhCongTac}.reload();
                                        #{hdfQTCTRecordID}.setValue(#{hdfRecordID}.getValue());
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
                                        <ext:RecordField Name="TEN_NGUOI_QD" />
                                        <ext:RecordField Name="NgayQuyetDinh" />
                                        <ext:RecordField Name="NgayBatDau" />
                                        <ext:RecordField Name="NgayKetThuc" />
                                        <ext:RecordField Name="NoiDungCongViec" />
                                        <ext:RecordField Name="DiaDiemCongTac" />
                                        <ext:RecordField Name="TenNuoc" />
                                        <ext:RecordField Name="TepTinDinhKem" />
                                        <ext:RecordField Name="GhiChu" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel14" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
                            </ext:Column>
                            <ext:Column ColumnID="SoQuyetDinh" Header="Số quyết định" DataIndex="SoQuyetDinh" />
                            <ext:Column ColumnID="TEN_NGUOI_QD" Header="Người quyết định" DataIndex="TEN_NGUOI_QD" />
                            <ext:DateColumn ColumnID="NgayQuyetDinh" Header="Ngày quyết định" DataIndex="NgayQuyetDinh"
                                Format="dd/MM/yyyy" />
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
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="#{hdfButtonClick}.setValue('Edit');" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.TepTinDinhKem);" />
                        <ViewReady Handler="#{cbCongTacQuocGiaStore}.reload();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelQuaTrinhDieuChuyen" Title="Quá trình điều chuyển" runat="server"
            Hidden="true" Closable="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuQuaTrinhDieuChuyen}.setDisabled(false);" />
                <Activate Handler="#{btnAddRecordInDetailTable}.enable();
                                    if(#{hdfQTDCRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                    #{StoreQuaTrinhDieuChuyen}.reload();
                                    #{hdfQTDCRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }  
                                    " />
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
                            <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
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
                            <ext:Column ColumnID="TenCongViecCu" Header="Công việc cũ" Width="120" DataIndex="TenCongViecCu" />
                            <ext:Column ColumnID="TenCongViecMoi" Header="Công việc mới" Width="120" DataIndex="TenCongViecMoi" />
                            <ext:Column ColumnID="GhiChu" Header="Ghi chú" Width="100" DataIndex="GhiChu" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelQuaTrinhDieuChuyen" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="#{hdfButtonClick}.setValue('Edit');" />
                        <ViewReady Handler="#{cbxQTDCBoPhanCu_Store}.reload();
                             #{cbxQTDCChucVuCu_Store}.reload();#{cbxCongViecMoi_Store}.reload();" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.TepTinDinhKem);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelTaiSan" Title="Tài sản" runat="server" Closable="true" Hidden="true"
            CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{mnuTaiSan}.setDisabled(false);" />
                <Activate Handler="if(#{hdfTaiSanRecordID}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                    #{StoreTaiSan}.reload();
                                    #{hdfTaiSanRecordID}.setValue(#{hdfRecordID}.getValue());
                                    }" />
            </Listeners>
            <Items>
                <ext:Hidden ID="hdfTaiSanRecordID" runat="server" />
                <ext:GridPanel ID="GridPanelTaiSan" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Region="Center"
                    AutoExpandColumn="GHI_CHU">
                    <Store>
                        <ext:Store ID="StoreTaiSan" AutoSave="true" ShowWarningOnFailure="false" OnBeforeStoreChanged="HandleChangesDelete"
                            SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreTaiSan_OnRefreshData"
                            runat="server">
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
                                        <ext:RecordField Name="TepTinDinhKem" />
                                        <ext:RecordField Name="GHI_CHU" />
                                        <ext:RecordField Name="HanSuDung" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel12" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="MA_VTHH" Width="80" Header="Thẻ tài sản" DataIndex="MA_VTHH" />
                            <ext:Column ColumnID="TEN_VTHH" Width="200" Header="Tên tài sản" DataIndex="TEN_VTHH">
                            </ext:Column>
                            <ext:Column ColumnID="SoLuong" Width="80" Header="Số lượng" DataIndex="SoLuong" />
                            <ext:Column ColumnID="TEN_DVT" Width="100" Header="Đơn vị tính" DataIndex="TEN_DVT" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_NHAN" Header="Ngày nhận" DataIndex="NGAY_NHAN">
                            </ext:DateColumn>
                             <ext:DateColumn Format="dd/MM/yyyy" ColumnID="HanSuDung" Header="Hạn sử dụng" DataIndex="HanSuDung">
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
                        <ViewReady Handler="#{cbTaiSanStore}.reload();
                            #{cbxDonViTinh_Store}.reload();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelTepDinhKem" Title="Tệp tin đính kèm" runat="server" Closable="true"
            Hidden="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{MenuItemAttachFile}.setDisabled(false);" />
                <Activate Handler="" />
            </Listeners>
            <Items>
                <ext:GridPanel ID="grpTepTinDinhKem" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoExpandColumn="TenTepTin" AutoScroll="true" AnchorHorizontal="100%"
                    Region="Center">
                    <Store>
                        <ext:Store ID="grpTepTinDinhKemStore" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                            OnRefreshData="grpTepTinDinhKemStore_OnRefreshData" runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="PR_KEY">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="TenTepTin" />
                                        <ext:RecordField Name="Link" />
                                        <ext:RecordField Name="Ghichu" />
                                        <ext:RecordField Name="SizeKB" />
                                        <ext:RecordField Name="CreatedDate" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel17" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="Link" Width="25" DataIndex="" Align="Center" Locked="true">
                                <Commands>
                                    <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                        <ToolTip Text="Tải tệp tin đính kèm" />
                                    </ext:ImageCommand>
                                </Commands>
                                <PrepareCommand Fn="prepare" />
                            </ext:Column>
                            <ext:Column ColumnID="TenTepTin" Width="200" Header="Tên tệp tin" DataIndex="TenTepTin" />
                            <ext:Column ColumnID="SizeKB" Width="100" Header="Dung lượng(KB)" DataIndex="SizeKB" />
                            <ext:Column ColumnID="Ghichu" Width="300" Header="Ghi chú" DataIndex="Ghichu" />
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Width="100" Header="Ngày tạo"
                                DataIndex="CreatedDate" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelTepTinDinhKem" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="" />
                        <Command Handler="#{DirectMethods}.DownloadAttach(record.data.Link);" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelQuaTrinhHocTap" Title="Quá trình học tập" runat="server" Closable="true"
            Hidden="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{MenuItemHocTap}.setDisabled(false);" />
                <Activate Handler="if(#{hdfCheckQTHTLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{Store_BangCap}.reload();
                                        #{hdfCheckQTHTLoaded}.setValue(#{hdfRecordID}.getValue());
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden runat="server" ID="hdfCheckQTHTLoaded" />
                <ext:GridPanel ID="GridPanel_BangCap" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoExpandColumn="TEN_TRUONG_DAOTAO" AutoScroll="true"
                    AnchorHorizontal="100%" Region="Center">
                    <Store>
                        <ext:Store ID="Store_BangCap" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
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
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TEN_TRUONG_DAOTAO" Header="Trường đào tạo" DataIndex="TEN_TRUONG_DAOTAO" />
                            <ext:Column ColumnID="KHOA" Header="Khoa" DataIndex="KHOA" Width="150" />
                            <ext:DateColumn ColumnID="TU_NGAY" Format="yyyy" Width="70" Header="Từ năm" DataIndex="TU_NGAY" />
                            <ext:DateColumn ColumnID="DEN_NGAY" Format="yyyy" Width="70" Header="Đến năm" DataIndex="DEN_NGAY" />
                            <ext:Column ColumnID="TEN_CHUYENNGANH" Header="Chuyên ngành" DataIndex="TEN_CHUYENNGANH"
                                Width="200" />
                            <ext:Column ColumnID="TEN_TRINHDO" Width="70" Header="Trình độ" DataIndex="TEN_TRINHDO" />
                            <ext:Column ColumnID="TEN_HT_DAOTAO" Width="100" Header="Hình thức" DataIndex="TEN_HT_DAOTAO" />
                            <ext:Column ColumnID="TEN_XEPLOAI" Width="70" Header="Xếp loại" DataIndex="TEN_XEPLOAI" />
                            <ext:Column ColumnID="DA_TN" Width="100" Header="Đã tốt nghiệp" DataIndex="DA_TN">
                                <Renderer Fn="GetBooleanIcon" />
                            </ext:Column>
                            <ext:DateColumn ColumnID="NGAY_NHANBANG" Width="100" Header="Năm nhận bằng" DataIndex="NGAY_NHANBANG"
                                Format="yyyy" />
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
                        <DblClick Handler="" />
                        <ViewReady Handler="#{cbx_hinhthucdaotaobangStore}.reload();
                          #{cbx_xeploaiBangCapStore}.reload();
                          #{cbx_trinhdobangcapStore}.reload();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelKinhNghiemLamViec" Title="Kinh nghiệm làm việc" runat="server"
            Closable="true" Hidden="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{MenuItemKNLV}.setDisabled(false);" />
                <Activate Handler="if(#{hdfCheckKNLV}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{StoreKinhNghiemLamViec}.reload();
                                        #{hdfCheckKNLV}.setValue(#{hdfRecordID}.getValue());
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden runat="server" ID="hdfCheckKNLV" />
                <ext:GridPanel ID="GridPanelKinhNghiemLamViec" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoExpandColumn="GhiChu" AutoScroll="true" AnchorHorizontal="100%"
                    Region="Center">
                    <Store>
                        <ext:Store ID="StoreKinhNghiemLamViec" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
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
                            <ext:Column ColumnID="ViTriCongViec" Width="150" Header="Vị trí công việc" DataIndex="ViTriCongViec" />
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
        <ext:Panel ID="panelBangCapChungChi" Title="Chứng chỉ" runat="server" Closable="true"
            Hidden="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{MenuItemBangCapChungChi}.setDisabled(false);" />
                <Activate Handler="if(#{hdfCheckChungChiLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                        #{Store_BangCapChungChi}.reload();
                                        #{hdfCheckChungChiLoaded}.setValue(#{hdfRecordID}.getValue());
                                    }
                                    " />
            </Listeners>
            <Items>
                <ext:Hidden runat="server" ID="hdfCheckChungChiLoaded" />
                <ext:GridPanel ID="GridPanel_ChungChi" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoExpandColumn="TenChungChi" AutoScroll="true" AnchorHorizontal="100%"
                    Region="Center">
                    <Store>
                        <ext:Store ID="Store_BangCapChungChi" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                            AutoLoad="false" OnRefreshData="Store_BangCapChungChi_OnRefreshData" runat="server">
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
                            <ext:RowNumbererColumn Width="35" Header="STT" />
                            <ext:Column ColumnID="TenChungChi" Header="Tên chứng chỉ" DataIndex="TenChungChi" />
                            <ext:Column ColumnID="TEN_XEPLOAI" Header="Xếp loại" DataIndex="TEN_XEPLOAI" Width="60" />
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
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <Listeners>
                        <RowDblClick Handler="" />
                        <ViewReady Handler="#{cbx_tenchungchiStore}.reload();
                           #{cbx_XepLoaiChungChiStore}.reload();" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
        </ext:Panel>
        <ext:Panel ID="panelTaiNanLaoDong" Title="Tai nạn lao động" runat="server" Closable="true"
            Hidden="true" CloseAction="Hide" Layout="BorderLayout">
            <Listeners>
                <Close Handler="#{MenuItemTNLD}.setDisabled(false);" />
                <Activate Handler="if(#{hdfCheckTNLDLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                    {
                                    #{StoreTaiNanLaoDong}.reload();
                                    #{hdfCheckTNLDLoaded}.setValue(#{hdfRecordID}.getValue());
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
                                        <ext:RecordField Name="NGAY_XAY_RA" Type="Date" />
                                        <ext:RecordField Name="NgayBoiThuong" Type="Date" />
                                        <ext:RecordField Name="DIA_DIEM" />
                                        <ext:RecordField Name="THIET_HAI" />
                                        <ext:RecordField Name="THUONG_TAT" />
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
                            <ext:Column ColumnID="LY_DO" Header="Nguyên nhân tai nạn" Width="150" DataIndex="LY_DO">
                            </ext:Column>
                            <ext:Column ColumnID="DIA_DIEM" Header="Địa điểm" Width="150" DataIndex="DIA_DIEM">
                            </ext:Column>
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_XAY_RA" Width="100" Header="Ngày xảy ra"
                                DataIndex="NGAY_XAY_RA">
                            </ext:DateColumn>
                            <ext:Column ColumnID="BOI_THUONG" Width="150" Header="Bồi thường" DataIndex="BOI_THUONG"
                                Align="Right">
                                <Renderer Fn="RenderVND0" />
                            </ext:Column>
                            <ext:Column ColumnID="THUONG_TAT" Width="150" Header="Thương tật" DataIndex="THUONG_TAT">
                            </ext:Column>
                            <ext:Column ColumnID="THIET_HAI" Width="150" Header="Thiệt hại" DataIndex="THIET_HAI">
                            </ext:Column>
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayBoiThuong" Width="100" Header="Ngày bồi thường"
                                DataIndex="NgayBoiThuong">
                            </ext:DateColumn>
                            <ext:Column ColumnID="GHI_CHU" Width="150" Header="Ghi chú" DataIndex="GHI_CHU">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelTaiNanLaoDong" runat="server" SingleSelect="true">
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
        <ext:Panel ID="panelThuTucDauVao" Title="Thủ tục đầu vào" runat="server" Closable="true"
            Hidden="true" CloseAction="Hide" Layout="BorderLayout">
            <Items>
                <ext:GridPanel ID="GridThuTucDauVao" runat="server" StripeRows="true" Border="false"
                    TrackMouseOver="true" AutoExpandColumn="TenThuTuc" AutoScroll="true" AnchorHorizontal="100%"
                    Region="Center">
                    <Store>
                        <ext:Store ID="StoreThuTucDauVao" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                            OnBeforeStoreChanged="HandleChangesDelete" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                            OnRefreshData="grpThuTucDauVaoStore_OnRefreshData" runat="server">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="PrKeyHoSo" />
                                        <ext:RecordField Name="TenThuTuc" />
                                        <ext:RecordField Name="HoanThanh" />
                                        <ext:RecordField Name="CreatedDate" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel23" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="TenThuTuc" Width="200" Header="Tên thủ tục" DataIndex="TenThuTuc" />
                            <ext:CheckColumn ColumnID="HoanThanh" Width="100" Header="Đã hoàn thành" DataIndex="HoanThanh" />
<%--                            <ext:Column ColumnID="Ghichu" Width="300" Header="Ghi chú" DataIndex="Ghichu" />--%>
                            <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Width="150" Header="Ngày tạo"
                                DataIndex="CreatedDate" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionThuTuc" runat="server" SingleSelect="true">
                            <Listeners>
                                <RowSelect Handler="" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                </ext:GridPanel>
            </Items>
        </ext:Panel>

    </Items>
    <BottomBar>
        <ext:Toolbar ID="Toolbar1sdsds" Hidden="false" runat="server">
            <Items>
                <ext:Button ID="CloseTab1" runat="server" Text="Thông tin thêm" Icon="Information">
                    <Menu>
                        <ext:Menu runat="server" ID="menuAddMoreTab">
                            <Items>
                                <ext:MenuItem ID="mnuHopDong" runat="server" Text="Hợp đồng">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelHopDong});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreHopDong}.reload();}
                                                        #{hdfHDRecordID}.setValue(#{hdfRecordID}.getValue());
                                                        " />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuDienBienLuong" runat="server" Text="Diễn biến lương">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelDienBienLuong});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreDienBienLuong}.reload();}
                                                        #{hdfDBLRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuTaiSan" runat="server" Text="Tài sản">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelTaiSan});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoreTaiSan}.reload();
                                                        }
                                                        #{hdfTaiSanRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuKhenThuong" runat="server" Text="Khen thưởng">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelKhenThuong});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {#{StoreKhenThuong}.reload();}
                                                        #{hdfKhenThuongRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuKyLuat" runat="server" Text="Kỷ luật">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelKiLuat});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {#{StoreKyLuat}.reload();}
                                                        #{hdfKyLuatRecordID}.setValue(#{hdfRecordID}.getValue())" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem runat="server" ID="mnuShowHoSoTuyenDung" Text="Hồ sơ tuyển dụng">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelHoSoTuyenDung});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoreHoSoTuyenDung}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuKhaNang" runat="server" Text="Khả năng">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelKhaNang});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreKhaNang}.reload();}
                                                        #{hdfKhaNangRecordID}.setValue(#{hdfRecordID}.getValue())" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuQuanHeGiaDinh" runat="server" Text="Quan hệ gia đình">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelQuanHeGiaDinh});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {#{StoreQHGD}.reload();}
                                                        #{hdfQHGDRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuQuaTrinhDaoTao" runat="server" Text="Quá trình đào tạo">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelQuaTrinhDaoTao});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoreQuaTrinhDaoTao}.reload();
                                                        }
                                                        #{hdfQTDTRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuBaoHiem" runat="server" Text="Bảo hiểm">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelBaoHiem});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreBaoHiem}.reload();}
                                                        #{hdfBHRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuDaiBieu" runat="server" Text="Đại biểu" Hidden="true">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelDaiBieu});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreDaiBieu}.reload();}
                                                        #{hdfDBRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuDanhGia" runat="server" Text="Đánh giá">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelDanhGia});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreDanhGia}.reload();}
                                                        #{hdfDGRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuDeTai" runat="server" Text="Đề tài" Hidden="true">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelDeTai});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                            {#{StoreDetai}.reload();}
                                                        #{hdfDeTaiRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuQuaTrinhCongTac" runat="server" Text="Quá trình công tác">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelQuaTrinhCongTac});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {#{StoreQuaTrinhCongTac}.reload();}
                                                        #{hdfQTCTRecordID}.setValue(#{hdfRecordID}.getValue())" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuQuaTrinhDieuChuyen" runat="server" Text="Quá trình điều chuyển">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelQuaTrinhDieuChuyen});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {#{StoreQuaTrinhDieuChuyen}.reload();}
                                                        #{hdfQTDCRecordID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItemHocTap" runat="server" Text="Quá trình học tập">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelQuaTrinhHocTap});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{Store_BangCap}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItemKNLV" runat="server" Text="Kinh nghiệm làm việc">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelKinhNghiemLamViec});this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoreKinhNghiemLamViec}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItemBangCapChungChi" runat="server" Text="Chứng chỉ">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelBangCapChungChi});this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{Store_BangCapChungChi}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="MenuItemTNLD" runat="server" Text="Tai nạn lao động">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelTaiNanLaoDong});this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoreTaiNanLaoDong}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>
<%--                                <ext:MenuItem ID="mnuATM" runat="server" Text="Thẻ ngân hàng">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelTheNganHang});this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoregrpATM}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>--%>
                                <ext:MenuItem ID="MenuItemAttachFile" runat="server" Text="Tệp tin đính kèm">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelTepDinhKem});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{grpTepTinDinhKemStore}.reload();
                                                        }" />
                                    </Listeners>
                                </ext:MenuItem>
                                 <ext:MenuItem ID="MenuItemThuTucDauVao" runat="server" Text="Thủ tục đầu vào">
                                    <Listeners>
                                        <Click Handler="#{TabPanelBottom}.addTab(#{panelThuTucDauVao});
                                                        this.setDisabled(true);
                                                        if(#{hdfRecordID}.getValue()!='')
                                                        {
                                                            #{StoreThuTucDauVao}.reload();
                                                        };
                                            #{hdfThuTucID}.setValue(#{hdfRecordID}.getValue());" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:Button>
                <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                <ext:Hidden runat="server" ID="hdfButtonClick" />
                <ext:Button Text="Thêm mới" Disabled="true" runat="server" ID="btnAddRecordInDetailTable"
                    Icon="Add">
                    <Listeners>
                        <Click Handler="if(#{hdfRecordID}.getValue().trim()=='' || #{hdfRecordID}.getValue()== null)
                                        {
                                            Ext.Msg.alert('Thông báo','Bạn chưa chọn nhân viên nào !');
                                        }else
                                        {
                                            #{hdfButtonClick}.setValue('Insert');
                                            AddRecordClick(#{TabPanelBottom});
                                        }
                                        " />
                    </Listeners>
                </ext:Button>
                <ext:Button Text="Xóa" Disabled="true" runat="server" ID="btnDeleteRecord" Icon="Delete">
                    <Listeners>
                        <Click Handler="DeleteRecordOnGrid();" />
                    </Listeners>
                </ext:Button>
                <ext:Button Text="Sửa" Disabled="true" runat="server" ID="btnEditRecord" Icon="Pencil">
                    <Listeners>
                        <Click Handler="EditClick(#{DirectMethods}); #{hdfButtonClick}.setValue('Edit');" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnViewPhuCap" Hidden="true" Text="Xem phụ cấp" Icon="Money"
                    Disabled="true">
                    <Listeners>
                        <Click Handler="if (#{hdfDBLRecordID}.getValue() == '') {
                            alert('Bạn chưa chọn diễn biến lương nào');
                            return false;
                        }
                        #{wdPhuCap}.show();" />
                    </Listeners>
                </ext:Button>
            </Items>
        </ext:Toolbar>
    </BottomBar>
</ext:TabPanel>
