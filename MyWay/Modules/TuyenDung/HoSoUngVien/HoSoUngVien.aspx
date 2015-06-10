<%@ Page Language="C#" AutoEventWireup="true" CodeFile="HoSoUngVien.aspx.cs" Inherits="Modules_NhanSu_KEHOACH_TUYENDUNG" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%--<%@ Register Src="../../Base/UploadImageWindow/ucUploadImageForm.ascx" TagName="ucUploadImageForm"
    TagPrefix="uc5" %>--%>
<%@ Register Src="../../Base/DateTime/DateTime.ascx" TagName="DateTime" TagPrefix="uc3" %>
<%@ Register Src="../../Base/ComboBox/ComboBox.ascx" TagName="ComboBox" TagPrefix="uc4" %>
<%@ Register Src="ucPhanLoaiUngVien.ascx" TagName="ucPhanLoaiUngVien" TagPrefix="uc1" %>
<%@ Register Src="../uscTuyenDung_HoSoUngVien.ascx" TagName="uscTuyenDung_HoSoUngVien"
    TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .list-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
        
        #wdShowReport .x-tab-panel-header
        {
            display: none !important;
        }
        
        #GridPanel1 .x-grid3-cell-inner
        {
            white-space: nowrap !important;
        }
    </style>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="../Resource/UngVienDuTruJS.js" type="text/javascript"></script>
    <script src="../../../Resource/js/JScript.js" type="text/javascript"></script>
    <script src="../../../Resource/js/global.js" type="text/javascript"></script>
    <script src="HoSoUngVienJS.js" type="text/javascript"></script>
    <link href="CSS.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="RM" runat="server" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfType" />
        <ext:Hidden runat="server" ID="hdfKeHoachTuyenDung" />
        <ext:Hidden runat="server" ID="hdfVongPV" />
        <uc1:ucPhanLoaiUngVien ID="ucPhanLoaiUngVien1" runat="server" />
        <%--<uc5:ucUploadImageForm ID="ucUploadImageForm1" runat="server" />--%>
        <ext:Window runat="server" Title="Tìm kiếm nâng cao" Icon="Zoom" Constrain="true"
            ID="wdAdvanceSearch" Height="200" Modal="true" Width="900" Hidden="true" Padding="6">
            <Items>
                <ext:Container ID="Container24" runat="server" Height="210" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container25" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                            <Items>
                                <ext:NumberField ID="txt_MaUngVien" runat="server" FieldLabel="Mã ứng viên" TabIndex="2"
                                    AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự"
                                    Regex="/[\d]+/">
                                </ext:NumberField>
                                <ext:TextField ID="txt_TenUngVien" runat="server" FieldLabel="Họ tên" TabIndex="2"
                                    AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                </ext:TextField>
                                <ext:ComboBox runat="server" ID="cbx_gioitinh" Editable="false" SelectedIndex="0"
                                    FieldLabel="Giới tính" TabIndex="3" AnchorHorizontal="98%">
                                    <Items>
                                        <ext:ListItem Text="Nam" Value="M" />
                                        <ext:ListItem Text="Nữ" Value="F" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:NumberField ID="txt_Tuoi" runat="server" FieldLabel="Tuổi" TabIndex="2" AnchorHorizontal="98%"
                                    MaxLength="2" MaxLengthText="Bạn chỉ được nhập tối đa 2 ký tự" Regex="/[\d]+/">
                                </ext:NumberField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container26" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfTinhTrangHN" />
                                <ext:ComboBox ID="cbx_tt_honnhan" runat="server" FieldLabel="T/T hôn nhân" DisplayField="TEN_TT_HN"
                                    ValueField="MA_TT_HN" AnchorHorizontal="98%" TabIndex="5">
                                    <Store>
                                        <ext:Store ID="cbx_tt_honnhanstore" runat="server" AutoLoad="false" OnRefreshData="cbx_tt_honnhanstore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_TT_HN">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_TT_HN" />
                                                        <ext:RecordField Name="TEN_TT_HN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Focus Handler="#{cbx_tt_honnhanstore}.reload();" />
                                        <Select Handler="this.triggers[0].show();#{hdfTinhTrangHN}.setValue(#{cbx_tt_honnhan}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfTinhThanh" />
                                <ext:ComboBox runat="server" ID="cbx_tinhthanh" FieldLabel="Tỉnh thành" DisplayField="TEN"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ValueField="MA" AnchorHorizontal="98%"
                                    TabIndex="15" Editable="true" ItemSelector="div.list-item">
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
                                        <Focus Handler="if (#{cbx_quoctich}.getValue() == '') {#{cbx_tinhthanh_Store}.removeAll(); alert('Bạn phải chọn quốc tịch trước');} else {#{cbx_tinhthanh_Store}.reload();}" />
                                        <Select Handler="this.triggers[0].show();#{hdfTinhThanh}.setValue(#{cbx_tinhthanh}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfTruongDaoTao" />
                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" HideTrigger="false" DisplayField="TEN"
                                    runat="server" FieldLabel="Trường đào tạo" PageSize="15" ItemSelector="div.search-item"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ID="cbx_TruongDaoTao" LoadingText="Đang tải dữ liệu..."
                                    TabIndex="26">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="cbx_TruongDaoTao_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
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
                                        <Focus Handler="#{cbx_TruongDaoTao_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfTruongDaoTao}.setValue(#{cbx_TruongDaoTao}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfTruongDaoTao}.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfChuyenNganh" />
                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" DisplayField="TEN" runat="server"
                                    FieldLabel="Chuyên ngành" PageSize="15" HideTrigger="false" ItemSelector="div.search-item"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ID="cbx_ChuyenNganh" LoadingText="Đang tải dữ liệu..."
                                    TabIndex="27">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="cbx_ChuyenNganh_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
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
                                        <Focus Handler="#{cbx_ChuyenNganh_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfChuyenNganh}.setValue(#{cbx_ChuyenNganh}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfChuyenNganh}.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container5" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                            <Items>
                                <ext:TextField ID="txt_TongDiem" runat="server" FieldLabel="Tổng điểm" TabIndex="3"
                                    AnchorHorizontal="98%" MaxLength="3" MaxLengthText="Bạn chỉ được nhập tối đa 3 ký tự"
                                    MaskRe="/[0-9\.]/">
                                </ext:TextField>
                                <ext:NumberField ID="txt_kinhnghiem" runat="server" EmptyText="Số năm kinh ngiệm"
                                    FieldLabel="Kinh nghiệm" TabIndex="24" AnchorHorizontal="98%" MaxLength="2">
                                </ext:NumberField>
                                <ext:Hidden runat="server" ID="hdfCongViec" />
                                <ext:ComboBox runat="server" ID="cbx_congviec" FieldLabel="Công việc" DisplayField="TEN"
                                    MinChars="1" ValueField="MA" AnchorHorizontal="98%" ListWidth="200" TabIndex="5"
                                    Editable="true" ItemSelector="div.list-item" PageSize="15" LoadingText="<%$ Resources:HOSO, Loading%>"
                                    EmptyText="Gõ để tìm kiếm">
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
                                    <Listeners>
                                        <Focus Handler=" #{cbx_congviec_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show();#{hdfCongViec}.setValue(#{cbx_congviec}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } " />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAdvanceSearch.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo hồ sơ ứng viên chi tiết" Maximized="true" Icon="Printer">
            <Items>
                <ext:Hidden runat="server" ID="hdfTypeReport" />
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel}.remove(0);addHomePage(#{pnReportPanel},'Homepage','../../Report/BaoCao_Main.aspx?type=BaoCaoHoSoUngVienChiTiet&MaUngVien='+#{hdfRecordID}.getValue(), 'Báo cáo hồ sơ ứng viên chi tiết')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdChamDiemNhanXet" Padding="6" Layout="FormLayout"
            Hidden="true" Constrain="true" Title="Chấm điểm/Nhận xét" Icon="Lorry" Modal="true"
            Width="750" AutoHeight="true">
            <Items>
                <ext:Container ID="Container12" runat="server" Height="55" Layout="ColumnLayout">
                    <Items>
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfDiemDat" />
                                <ext:NumberField runat="server" AllowNegative="false" AnchorHorizontal="98%" ID="txt_vongPV"
                                    AllowDecimals="false" FieldLabel="Vòng thi" MaxLength="4">
                                    <Listeners>
                                    </Listeners>
                                </ext:NumberField>
                                <ext:Hidden ID="hdfMonThi" runat="server">
                                </ext:Hidden>
                                <ext:ComboBox runat="server" AnchorHorizontal="98%" ID="cboMonThi" CtCls="requiredData"
                                    FieldLabel="Môn thi<span style='color:red;'>*</span>" Editable="false" DisplayField="TEN_MON_THI"
                                    EmptyText="Môn thi phải có trong KH tuyển dụng" ValueField="MA_MON_THI">
                                    <Store>
                                        <ext:Store runat="server" AutoLoad="true" ID="cboMonThi_store">
                                            <Proxy>
                                                <ext:HttpProxy Method="GET" Url="../Handlers/ChamDiemNhanXetHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="planid" Value="#{hdfKeHoachTuyenDung}.getValue()" Mode="Raw" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader Root="Data" IDProperty="MA_MON_THI" TotalProperty="TotalRecords">
                                                    <Fields>
                                                        <ext:RecordField Name="ID_MON_THI" />
                                                        <ext:RecordField Name="MA_MON_THI" />
                                                        <ext:RecordField Name="MA_KE_HOACH_TD" />
                                                        <ext:RecordField Name="DIEM_DAT" />
                                                        <ext:RecordField Name="VONG_THI" />
                                                        <ext:RecordField Name="TEN_MON_THI" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Select Handler="#{hdfMonThi}.setValue(#{cboMonThi}.getValue());" />
                                        <TriggerClick Handler="#{hdfMonThi}.reset();" />
                                        <Focus Handler="#{cboMonThi_store}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:DateField runat="server" ID="dfNgayThiTuyen" Editable="true" FieldLabel="Ngày thi"
                                    AnchorHorizontal="98%" TabIndex="23" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                </ext:DateField>
                                <ext:TextField runat="server" FieldLabel="Điểm số<span style='color:red;'>*</span>"
                                    EmptyText="Sau khi nhập sẽ được nhân trọng số" CtCls="requiredData" ID="txtDiemSo"
                                    AnchorHorizontal="98%" LabelWidth="50" MaskRe="/[0-9\.]/" MaxLength="4" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Hidden runat="server" ID="hdfNguoiChamThi" />
                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                    CtCls="requiredData" DisplayField="TEN_NGUOI_CHAM" ValueField="MA_NGUOI_CHAM_THI"
                    LoadingText="Đang tìm kiếm..." AnchorHorizontal="99%" PageSize="10" ItemSelector="div.search-item"
                    MinChars="1" ID="cbb_NguoiChamThi" FieldLabel="Người chấm thi<span style='color:red;'>*</span>"
                    Note="Người chấm thi là những người có trong Hội đồng tuyển dụng của Kế hoạch tuyển dụng!"
                    Width="300">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store ID="StoreChonNguoiChamThi" runat="server" AutoLoad="true">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="../Handlers/ChonNguoiChamThiHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="KeHoachTuyenDung" Value="#{hdfKeHoachTuyenDung}.getValue()"
                                    Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID_HOI_DONG_TD">
                                    <Fields>
                                        <ext:RecordField Name="ID_HOI_DONG_TD" />
                                        <ext:RecordField Name="MA_KE_HOACH_TD" />
                                        <ext:RecordField Name="TEN_KE_HOACH_TD" />
                                        <ext:RecordField Name="GHI_CHU" />
                                        <ext:RecordField Name="NGAY_TAO" />
                                        <ext:RecordField Name="MA_NGUOI_TAO" />
                                        <ext:RecordField Name="TEN_NGUOI_TAO" />
                                        <ext:RecordField Name="VONG_THI" />
                                        <ext:RecordField Name="MA_NGUOI_CHAM_THI" />
                                        <ext:RecordField Name="TEN_NGUOI_CHAM" />
                                        <ext:RecordField Name="NGAY_SINH" />
                                        <ext:RecordField Name="MA_CHUC_VU" />
                                        <ext:RecordField Name="TEN_CHUC_VU" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Template ID="Template5" runat="server">
                        <Html>
                            <tpl for=".">
						                                <div class="search-item">
							                                <h3>{TEN_NGUOI_CHAM}</h3>
							                                {TEN_CHUC_VU}</BR>
                                                        Ngày sinh: {NGAY_SINH:date("d/m/Y")}
						                                </div>
					                                </tpl>
                        </Html>
                    </Template>
                    <Listeners>
                        <Focus Handler="cbb_NguoiChamThi.store.reload();" />
                        <Select Handler="this.triggers[0].show();#{hdfNguoiChamThi}.setValue(cbb_NguoiChamThi.getValue())" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                    <DirectEvents>
                        <Select OnEvent="CheckDaThoiViec">
                        </Select>
                    </DirectEvents>
                </ext:ComboBox>
                <ext:TextArea runat="server" FieldLabel="Nhận xét" ID="txtNhanXet" AnchorHorizontal="99%"
                    MaxLength="500">
                </ext:TextArea>
                <%--                <ext:ComboBox runat="server" Disabled="true" Editable="false" FieldLabel="Hành động"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:ListItem Text="Đưa vào danh sách trúng tuyển" />
                            <ext:ListItem Text="Hẹn vòng phỏng vấn tiếp theo" />
                            <ext:ListItem Text="Đưa vào danh sách ứng tuyển để chờ vòng phỏng vấn tiếp theo" />
                        </Items>
                    </ext:ComboBox>--%>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdateChamDiem" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="return CheckInputDiemPhongVan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChamDiem_Click" After="ResetwdChamDiemNhanXet">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditChamDiem" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputDiemPhongVan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChamDiem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateAndCloseChamDiem" Icon="Disk" Text="Cập nhật & đóng lại">
                    <Listeners>
                        <Click Handler="return CheckInputDiemPhongVan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChamDiem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button8" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="#{wdChamDiemNhanXet}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnUpdateChamDiem}.show();#{btnEditChamDiem}.hide();#{btnUpdateAndCloseChamDiem}.show();ResetwdChamDiemNhanXet();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Hidden="true" Resizable="false" Padding="6" Layout="FormLayout"
            Modal="true" Width="500" ID="wdAttachFile" Title="Tệp tin đính kèm" Icon="Attach"
            AutoHeight="true" Constrain="true">
            <Items>
                <ext:FileUploadField ID="file_cv" runat="server" FieldLabel="Tệp tin đính kèm<span style='color:red;'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="100%" Icon="Attach">
                    <Listeners>
                        <FileSelected Handler="txtFileName.setValue(file_cv.getValue());" />
                    </Listeners>
                </ext:FileUploadField>
                <ext:TriggerField ID="txtFileName" runat="server" AnchorHorizontal="100%" FieldLabel="Tên tệp tin<span style='color:red;'>*</span>"
                    CtCls="requiredData">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" />
                    </Triggers>
                    <Listeners>
                        <TriggerClick Handler="txtFileName.reset();" />
                    </Listeners>
                </ext:TriggerField>
                <ext:TextArea runat="server" FieldLabel="Ghi chú" ID="txtGhiChu" AnchorHorizontal="100%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button ID="btnUpdateAtachFile" runat="server" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="if(txtFileName.getValue().trim()==''){
                                            alert('Bạn chưa nhập tên tệp tin đính kèm');
                                            txtFileName.focus();
                                            return false;
                                        }
                                        if(file_cv.getValue().trim()==''){
                                            alert('Bạn chưa chọn tệp tin đính kèm');
                                            file_cv.focus();
                                            return false;
                                        }
                                       checkExtension(file_cv.getValue()); 
                                       return CheckInputAttachFile(#{file_cv}.fileInput.dom); " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateAtachFile_Click" After="ResetWdAttachFile">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Disk" Text="Cập nhật & Đóng lại">
                    <Listeners>
                        <Click Handler="if(txtFileName.getValue().trim()==''){
                                            alert('Bạn chưa nhập tên tệp tin đính kèm');
                                            txtFileName.focus();
                                            return false;
                                        }
                                        if(file_cv.getValue().trim()==''){
                                            alert('Bạn chưa chọn tệp tin đính kèm');
                                            file_cv.focus();
                                            return false;
                                        }
                                        return CheckInputAttachFile(#{file_cv}.fileInput.dom); " />
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
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAttachFile.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txtFileName.reset();txtGhiChu.reset();file_cv.reset(); ResetWdAttachFile(); " />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdAddBangCap" Width="600" EnableViewState="false"
            Title="Quá trình học tập" Resizable="false" Constrain="true" Modal="true" Icon="Add"
            AutoHeight="true" Hidden="true" Padding="6">
            <Items>
                <ext:Container runat="server" ID="Container8" Layout="ColumnLayout" Height="150">
                    <Items>
                        <ext:Container runat="server" ID="Container15" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfMaTruongDaoTao" />
                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" HideTrigger="false" DisplayField="TEN"
                                    runat="server" FieldLabel="Trường đào tạo<span style='color:red;'>*</span>" CtCls="requiredData"
                                    PageSize="15" ItemSelector="div.search-item" ListWidth="200" MinChars="1" EmptyText="Gõ để tìm kiếm"
                                    ID="cbx_NoiDaoTaoBangCap" LoadingText="Đang tải dữ liệu..." TabIndex="1">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="cbx_NoiDaoTaoBangCapStore" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../../HoSoNhanSu/SearchDanhMucHandler.ashx" />
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
                                    <Template ID="Template2" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="search-item">
							                            {TEN}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <ToolTips>
                                        <ext:ToolTip runat="server" ID="ToolTip1" Title="Hướng dẫn" Html="Nhập tên trường đào tạo để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                    </ToolTips>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show(); #{hdfMaTruongDaoTao}.setValue(#{cbx_NoiDaoTaoBangCap}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfMaTruongDaoTao}.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden ID="hdfHinhThucDaoTao" runat="server">
                                </ext:Hidden>
                                <ext:ComboBox Editable="false" runat="server" DisplayField="TEN_HT_DAOTAO" ValueField="MA_HT_DAOTAO"
                                    ID="cbx_hinhthucdaotaobang" FieldLabel="Hình thức<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AnchorHorizontal="98%" ItemSelector="div.list-item" TabIndex="3">
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
                                    <Template ID="Template20" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="list-item"> 
							                            {TEN_HT_DAOTAO}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show(); #{hdfHinhThucDaoTao}.setValue(#{cbx_hinhthucdaotaobang}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } #{hdfHinhThucDaoTao}.reset(); " />
                                        <Focus Handler="#{cbx_hinhthucdaotaobangStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField ID="txt_khoa" AllowBlank="true" runat="server" FieldLabel="Khoa" TabIndex="5"
                                    AnchorHorizontal="98%" MaxLength="200">
                                </ext:TextField>
                                <ext:Checkbox ID="Chk_DaTotNghiep" runat="server" AnchorHorizontal="98%" BoxLabel="Đã tốt nghiệp"
                                    Checked="false" TabIndex="8">
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
                                                    #{hdfXepLoaiBangCap}.reset();
                                                    #{txtNamNhanBang}.reset();
                                                }
                                            " />
                                    </Listeners>
                                </ext:Checkbox>
                                <ext:Hidden ID="hdfXepLoaiBangCap" runat="server">
                                </ext:Hidden>
                                <ext:ComboBox Editable="false" runat="server" ID="cbx_xeploaiBangCap" DisplayField="TEN_XEPLOAI"
                                    ValueField="MA_XEPLOAI" FieldLabel="Xếp loại" AnchorHorizontal="98%" ItemSelector="div.list-item"
                                    Disabled="true" TabIndex="9">
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
                                    <Template ID="Template23" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="list-item"> 
							                            {TEN_XEPLOAI}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show(); #{hdfXepLoaiBangCap}.setValue(#{cbx_xeploaiBangCap}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } #{hdfXepLoaiBangCap}.reset();" />
                                        <Focus Handler="#{cbx_xeploaiBangCapStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container18" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfMaChuyenNganh" />
                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" DisplayField="TEN" runat="server"
                                    FieldLabel="Chuyên ngành<span style='color:red;'>*</span>" CtCls="requiredData"
                                    PageSize="15" HideTrigger="false" ItemSelector="div.search-item" ListWidth="200"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ID="cbx_ChuyenNganhBangCap" LoadingText="Đang tải dữ liệu..."
                                    TabIndex="2">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="Store2" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../../HoSoNhanSu/SearchDanhMucHandler.ashx" />
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
                                        <ext:ToolTip runat="server" ID="ToolTip2" Title="Hướng dẫn" Html="Nhập tên chuyên ngành để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                    </ToolTips>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show(); #{hdfMaChuyenNganh}.setValue(#{cbx_ChuyenNganhBangCap}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfMaChuyenNganh}.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfTrinhDoBangCap" />
                                <ext:ComboBox Editable="false" runat="server" DisplayField="TEN_TRINHDO" ValueField="MA_TRINHDO"
                                    ID="cbx_trinhdobangcap" FieldLabel="Trình độ<span style='color:red;'>*</span>"
                                    CtCls="requiredData" TabIndex="4" AnchorHorizontal="98%" ItemSelector="div.list-item">
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
                                    <Template ID="Template22" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="list-item"> 
							                            {TEN_TRINHDO}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show(); #{hdfTrinhDoBangCap}.setValue(#{cbx_trinhdobangcap}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } #{hdfTrinhDoBangCap}.reset();" />
                                        <Focus Handler="#{cbx_trinhdobangcapStore}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txtTuNam" FieldLabel="Từ năm" AnchorHorizontal="98%"
                                    TabIndex="6" MaskRe="[0-9]" MaxLength="4" MinLength="4">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtDenNam" FieldLabel="Đến năm" AnchorHorizontal="98%"
                                    TabIndex="7" MaskRe="[0-9]" MaxLength="4" MinLength="4">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtNamNhanBang" FieldLabel="Năm nhận bằng" AnchorHorizontal="98%"
                                    TabIndex="10" MaskRe="[0-9]" MaxLength="4" MinLength="4" />
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
                        <Click OnEvent="btnUpdateBangCap_Click" After="ResetWdAddBangCap">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditBangCap" Hidden="true" Text="Cập nhật" Icon="Disk">
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
                <ext:Button runat="server" ID="btnUpdateAndCloseBangCap" Icon="Disk" Text="Cập nhật & đóng lại">
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
                <ext:Button runat="server" ID="Button7" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="#{wdAddBangCap}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnUpdateBangCap}.show();#{btnEditBangCap}.hide();#{btnUpdateAndCloseBangCap}.show();ResetWdAddBangCap();" />
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
                                    CtCls="requiredData" AnchorHorizontal="95%" AllowBlank="false" MaxLength="500"
                                    TabIndex="1">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfKNLVTuNgay" EnableKeyEvents="true" CtCls="requiredData"
                                    Editable="true" FieldLabel="Từ ngày<span style='color:red;'>*</span>" AnchorHorizontal="95%"
                                    TabIndex="3" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container7" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:TextField runat="server" ID="txt_vitricongviec" FieldLabel="Vị trí công việc<span style='color:red;'>*</span>"
                                    CtCls="requiredData" AllowBlank="false" AnchorHorizontal="100%" TabIndex="2"
                                    MaxLength="500">
                                </ext:TextField>
                                <ext:DateField runat="server" ID="dfKNLVDenNgay" EnableKeyEvents="true" CtCls="requiredData"
                                    Editable="true" FieldLabel="Đến ngày<span style='color:red;'>*</span>" AnchorHorizontal="95%"
                                    TabIndex="4" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txtThanhTichTrongCongViec" FieldLabel="Thành tích"
                    TabIndex="5" EmptyText="Thành tích đạt được trong công việc" AnchorHorizontal="100%"
                    MaxLength="500">
                </ext:TextField>
                <ext:Container AnchorHorizontal="100%" runat="server" Height="30" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ColumnWidth="0.5" runat="server" Layout="FormLayout" Height="30">
                            <Items>
                                <ext:NumberField ID="nbfMucLuong" AnchorHorizontal="95%" runat="server" MaxLength="15"
                                    TabIndex="6" FieldLabel="Mức lương" AllowNegative="false" MaskRe="[0-9]" />
                            </Items>
                        </ext:Container>
                        <ext:TextField runat="server" ID="txtLyDoThoiViec" FieldLabel="Lý do thôi việc" TabIndex="7"
                            MaxLength="100" ColumnWidth="0.5" />
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtGhiChuKinhNghiemLamViec" FieldLabel="Ghi chú"
                    TabIndex="8" AnchorHorizontal="100%" MaxLength="500" Height="50">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnUpdateKinhNghiem" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="return CheckInputKinhNghiemLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKinhNghiem_Click" After="ResetWdKinhNghiemLamViec">
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
                        <Click OnEvent="btnUpdateKinhNghiem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnUpdateAndCloseKinhNghiem" Icon="Disk" Text="Cập nhật & đóng lại">
                    <Listeners>
                        <Click Handler="return CheckInputKinhNghiemLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateKinhNghiem_Click">
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
                <Hide Handler="#{btnUpdateKinhNghiem}.show();#{btnEditKinhNghiem}.hide();#{btnUpdateAndCloseKinhNghiem}.show();ResetWdKinhNghiemLamViec();" />
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
                                <ext:Hidden ID="hdfTenChungChi" runat="server">
                                </ext:Hidden>
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
                                    <Template ID="Template24" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="list-item"> 
							                            {TEN_CHUNGCHI}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Focus Handler="#{cbx_tenchungchiStore}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfTenChungChi}.setValue(#{cbx_tenchungchi}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } #{hdfTenChungChi}.reset();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container16" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:Hidden ID="hdfTenXepLoai" runat="server">
                                </ext:Hidden>
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
                                    <Template ID="Template25" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="list-item"> 
							                            {TEN_XEPLOAI}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Focus Handler="#{cbx_XepLoaiChungChiStore}.reload();" />
                                        <Select Handler="this.triggers[0].show();#{hdfTenXepLoai}.setValue(#{cbx_XepLoaiChungChi}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }#{hdfTenXepLoai}.reset();" />
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
                        <ext:Container runat="server" ID="Container23" Layout="FormLayout" ColumnWidth=".5">
                            <Items>
                                <ext:DateField runat="server" ID="df_NgayCap" Vtype="daterange" FieldLabel="Ngày cấp"
                                    Editable="true" MaskRe="/[0-9\/]/" Format="d/M/yyyy" AnchorHorizontal="95%" TabIndex="4">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container6" Layout="FormLayout" ColumnWidth=".5">
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
                <ext:Button runat="server" ID="btnUpdateChungChi" Icon="Disk" Text="Cập nhật">
                    <Listeners>
                        <Click Handler="return CheckInputChungChi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateChungChi_Click" After="ResetWdChungChi">
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
        <ext:Window runat="server" ID="wdnoidungmail" Title="Nội dung Email" Icon="Mail"
            Hidden="true" Resizable="true" AutoHeight="true" Width="500" Layout="FitLayout"
            Constrain="true">
            <Content>
                <ext:HtmlEditor runat="server" ID="txtndmail" AnchorHorizontal="100%" Height="150"
                    Cls="padding">
                </ext:HtmlEditor>
            </Content>
            <Buttons>
                <ext:Button runat="server" ID="btmailthoat" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdnoidungmail}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <%--<ext:Window runat="server" Modal="true" ID="wdHenPhongVan" Title="Lịch hẹn phỏng vấn/Thi tuyển"
                Padding="6" Hidden="true" Icon="Clock" Width="320" Resizable="false" Height="170px">
                <Content>
                    <ext:ComboBox runat="server" Editable="false" Width="290" ID="cbx_lanhen" SelectedIndex="0"
                        FieldLabel="Lịch hẹn">
                        <Items>
                            <ext:ListItem Text="Hẹn vòng 1" Value="1" />
                            <ext:ListItem Text="Hẹn vòng 2" Value="2" />
                            <ext:ListItem Text="Hẹn vòng 3" Value="3" />
                            <ext:ListItem Text="Hẹn vòng 4" Value="4" />
                        </Items>
                        <Listeners>
                            <Select Handler="Ext.net.DirectMethods.CheckLichHen();" />
                        </Listeners>
                    </ext:ComboBox>
                    <uc3:DateTime ID="date_lichhen" Width="290" FieldLabel="Chọn ngày giờ" runat="server" />
                    <ext:Container ID="Container30" runat="server" Layout="Column" Height="50">
                        <Items>
                            <ext:Container ID="Container32" runat="server" LabelAlign="Top" Layout="Form" ColumnWidth=".5">
                                <Items>
                                    <ext:Checkbox runat="server" ID="chkSendMail" BoxLabel="Gửi mail phỏng vấn" AnchorHorizontal="95%">
                                        <Listeners>
                                            <Check Handler="if(#{chkSendMail}.checked==true){#{btxemtruocmail}.enable();}else{#{btxemtruocmail}.disable();}" />
                                        </Listeners>
                                    </ext:Checkbox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Content>
                <Buttons>
                    <ext:Button runat="server" ID="btxemtruocmail" Disabled="true" Text="Xem trước nội dung Email">
                        <Listeners>
                            <Click Handler="#{wdnoidungmail}.show();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="xemtruocndungmail">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnHenPhongVan" Icon="Accept" Text="Đồng ý">
                        <Listeners>
                            <Click Handler="return CheckInputngaypv(date_lichhen_DateField1);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnHenPhongVan_Click">
                                <EventMask ShowMask="true" Msg="Đang tiến hành lập lịch" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnHuyBo" Icon="Decline" Text="Đóng lại">
                        <Listeners>
                            <Click Handler="#{wdHenPhongVan}.hide();" />
                            <Hide Handler="#{date_lichhen}.reset();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>--%>
        <ext:Hidden runat="server" ID="hdfImageFile" />
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem Text="Thêm mới" Icon="Add">
                    <Listeners>
                        <Click Handler="#{wdAddUngVien}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem Text="Sửa" Icon="Pencil">
                    <Listeners>
                        <Click Handler="#{btn_UpdateUngVien}.hide();#{btn_EditUngVien}.show();#{btn_UpdateandCloseUngVien}.hide();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem Text="Xóa" Icon="Delete">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(GridPanel1,Store1);" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuSeparator runat="server" />
                <ext:MenuItem ID="mnuTienIch" Text="Tiện ích" Icon="Build">
                    <Menu>
                        <ext:Menu runat="server" ID="Menu2">
                            <Items>
                                <ext:MenuItem ID="MenuItem4" Text="Nhập từ Excel" Icon="PageExcel">
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuQuanLy" Text="Quản lý" Icon="ApplicationCascade">
                    <Menu>
                        <ext:Menu ID="Menu3" runat="server">
                            <Items>
                                <ext:MenuItem ID="mnuHenPhongVan" Disabled="true" Text="Hẹn phỏng vấn" Icon="Clock">
                                    <Listeners>
                                        <Click Handler="#{wdHenPhongVan}.show();" />
                                    </Listeners>
                                </ext:MenuItem>
                                <ext:MenuItem ID="mnuBaoCaoUngVien" Disabled="true" Text="Báo cáo" Icon="Printer">
                                    <Listeners>
                                        <Click Handler="wdShowReport.show();" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <uc2:uscTuyenDung_HoSoUngVien ID="uscTuyenDung_HoSoUngVien1" runat="server" />
        <ext:Window runat="server" Title="Chuyển lịch hẹn phỏng vấn" Resizable="false" Icon="Clock"
            Hidden="true" Padding="6" ID="wdChuyenLichHenPV" Width="350" Modal="true" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="frmPanelChuyenLichHenPV">
                    <Items>
                        <ext:DateField runat="server" ID="df_NgayPhongVan" Editable="true" FieldLabel="Ngày phỏng vấn"
                            AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                            RegexText="Định dạng ngày không đúng" Vtype="daterange" TabIndex="40">
                        </ext:DateField>
                        <ext:TimeField ID="tf_GioPhongVan" runat="server" MinTime="9:00" MaxTime="18:00"
                            Increment="30" SelectedTime="09:00" Format="H:mm" FieldLabel="Giờ phỏng vấn"
                            AnchorHorizontal="98%" />
                        <ext:NumberField runat="server" ID="txt_VongPhongVan" MaxLength="4" FieldLabel="Vòng phỏng vấn"
                            TabIndex="3" AnchorHorizontal="98%">
                        </ext:NumberField>
                        <ext:NumberField runat="server" ID="txt_ThuTuPhongVan" FieldLabel="Thứ tự phỏng vấn"
                            LabelWidth="100" Width="50" TabIndex="99" MaxLength="4" Regex="/[\d]+/" />
                        <ext:TextArea runat="server" ID="txt_ghichu" FieldLabel="Ghi chú" AnchorHorizontal="98%"
                            TabIndex="38" Height="90" MaxLength="500">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btn_ChuyenLichHenPV" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler=" return KiemTraDuLieuLichHenPV(); #{wdChuyenLichHenPV}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btn_ChuyenLichHenPV_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btn_Close" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChuyenLichHenPV}.hide(); ResetwdChuyenLichHenPV();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Hidden ID="hdfChuyen_LyDo" runat="server">
        </ext:Hidden>
        <ext:Window runat="server" Title="Chuyển ứng viên" Resizable="false" Icon="Group"
            Hidden="true" Constrain="true" Padding="6" ID="wdChuyenLyDo" Width="450" Modal="true"
            Layout="FormLayout" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="FormPanel1">
                    <Items>
                        <ext:ComboBox runat="server" Editable="false" CtCls="requiredData" ID="cbx_Chuyen_LyDo"
                            LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item" FieldLabel="Lý do"
                            AnchorHorizontal="98%" DisplayField="Value" ValueField="ID">
                            <Store>
                                <ext:Store runat="server" ID="cbx_Chuyen_LyDo_Store" AutoLoad="false" OnRefreshData="cbx_Chuyen_LyDo_Store_OnRefreshData">
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
                            <Template ID="Template37" runat="server">
                                <Html>
                                    <tpl for=".">
						                            <div class="list-item"> 
                                                        {Value}
						                            </div>
					                            </tpl>
                                </Html>
                            </Template>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Focus Handler="#{cbx_Chuyen_LyDo_Store}.reload();" />
                                <Select Handler="this.triggers[0].show(); #{hdfChuyen_LyDo}.setValue(#{cbx_Chuyen_LyDo}.getValue());" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfChuyen_LyDo.reset();s }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextArea runat="server" ID="txt_Chuyen_GhiChu" FieldLabel="Ghi chú" AnchorHorizontal="98%"
                            MaxLength="500">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnChuyenLyDo" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler=" return KiemTraDuLieuChuyenLyDo(); #{wdChuyenLyDo}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChuyenTiep_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button2" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChuyenLyDo}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetwdChuyenLyDo();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" Header="false" runat="server" StripeRows="true"
                            Icon="ApplicationViewColumns" TrackMouseOver="false" AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button runat="server" Text="Thêm mới" Icon="Add" ID="btnAddUngVien">
                                            <Listeners>
                                                <Click Handler="#{wdAddUngVien}.show();" />
                                            </Listeners>
                                            <%--<Menu>
                                                    <ext:Menu runat="server" ID="mnuNhapUngVien">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem28" runat="server" Icon="UserAdd" Text="Nhập mới ứng viên">
                                                                <Listeners>
                                                                    <Click Handler="#{wdAddUngVien}.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem30" Hidden="true" runat="server" Icon="PageExcel" Text="Nhập từ tệp tin tuyển dụng">
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>--%>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="Sửa" Disabled="true" Icon="Pencil" ID="btnEdit">
                                            <Listeners>
                                                <Click Handler=" if( CheckSelectedRecordPrint(GridPanel1,Store1)){setValueWdAddUngVien(checkboxSelection,0);#{wdAddUngVien}.show();} " />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" Text="Xóa" Disabled="true" Icon="Delete" ID="btnDelete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" Hidden="true" Text="Phân loại ứng viên" Icon="UserGo">
                                            <Listeners>
                                                <Click Handler="ucPhanLoaiUngVien1_wdPhanLoaiUngVien.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                                        <ext:Button runat="server" ID="btnPrint" Disabled="true" Text="In hồ sơ cá nhân"
                                            Hidden="true" Icon="Printer">
                                            <Listeners>
                                                <%--<Click Handler="if( CheckSelectedRecordPrint(GridPanel1,Store1)){#{wdShowReport}.show();}" />--%>
                                                <Click Handler=" alert('Chức năng đang được hoàn thiện')" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnNext" Text="Chuyển tiếp" Icon="ArrowBranch" runat="server" Disabled="true">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="btnStore" Text="Chuyển vào kho dự trữ" Icon="DatabaseYellow">
                                                            <Listeners>
                                                                <Click Handler="#{wdChuyenLyDo}.setTitle('Chuyển ứng viên vào kho dự trữ');#{wdChuyenLyDo}.show(); #{hdfType}.setValue('store')" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnBlack" Text="Chuyển vào danh sách đen (Blacklist)" Icon="UserGray">
                                                            <Listeners>
                                                                <Click Handler="#{wdChuyenLyDo}.setTitle('Chuyển ứng viên vào danh sách đen');#{wdChuyenLyDo}.show(); #{hdfType}.setValue('black')" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnLichHenPV" Hidden="true" Text="Chuyển vào lịch hẹn phỏng vấn"
                                                            Icon="Group">
                                                            <Listeners>
                                                                <Click Handler="#{wdChuyenLichHenPV}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnDaTrungTuyen" Text="Chuyển vào danh sách ứng viên trúng tuyển"
                                                            Icon="MedalGold1">
                                                            <Listeners>
                                                                <Click Handler="#{hdfType}.setValue('DaTrungTuyen')" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="btnChuyenTiep_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn chuyển vào Danh sách ứng viên trúng tuyển không!"
                                                                        Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="5">
                                            <Items>
                                                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Lọc theo đợt tuyển dụng"
                                                    DisplayField="TenKeHoach" ValueField="ID" LoadingText="Đang tìm kiếm..." AnchorHorizontal="100%"
                                                    PageSize="10" ItemSelector="div.search-item" MinChars="1" ID="cbx_dottuyendung"
                                                    Width="150" ListWidth="250">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="cbx_dottuyendung_Store" runat="server" AutoLoad="true">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="../Handlers/LocTheoDotTuyenDungHandler.ashx" />
                                                            </Proxy>
                                                            <AutoLoadParams>
                                                                <ext:Parameter Name="Start" Value="={0}" />
                                                                <ext:Parameter Name="Limit" Value="={10}" />
                                                            </AutoLoadParams>
                                                            <Reader>
                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="TenKeHoach" />
                                                                        <ext:RecordField Name="NgayBatDau" />
                                                                        <ext:RecordField Name="NgayKetThuc" />
                                                                        <ext:RecordField Name="HanNopHoSo" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Template ID="Template3" runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                            <div class="search-item">
							                                        <h3>{TenKeHoach}</h3>                                               
                                                                    Ngày bắt đầu: {NgayBatDau:date("d/m/Y")}</br>
                                                                    Ngày kết thúc: {NgayKetThuc:date("d/m/Y")}</br> 
						                                            </div>
					                                            </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_dottuyendung_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{Store1}.reload();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{Store1}.reload(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container13" Layout="FormLayout" LabelWidth="35">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxMonth" Width="70" Editable="false" FieldLabel="Tháng"
                                                    SelectedIndex="0">
                                                    <Items>
                                                        <ext:ListItem Text="Cả năm" Value="0" />
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
                                                        <Select Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSpacer ID="ToolbarSpacer6" runat="server" Width="5" />
                                        <ext:Container runat="server" ID="Container14" Layout="FormLayout" LabelWidth="35">
                                            <Items>
                                                <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Năm" Width="55">
                                                    <Listeners>
                                                        <Spin Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container19" Layout="FormLayout" LabelWidth="5">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="ck_ViewChuyenVaoHOSO" BoxLabel="Ứng viên chuyển vào HSNS">
                                                    <Listeners>
                                                        <Check Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:Checkbox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel"
                                            Hidden="false">
                                            <DirectEvents>
                                                <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="btfull" />
                                        <ext:Button runat="server" Text="Tìm kiếm nâng cao" Hidden="true" Icon="MagnifierZoomIn">
                                            <Listeners>
                                                <Click Handler="wdAdvanceSearch.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã, tên hoặc CMND ứng viên.."
                                            ID="HoSoUngVien_txtSearchKey">
                                            <Listeners>
                                                <KeyPress Fn="HSUVenterKeyPressHandler" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{Store1}.reload(); }" />
                                            </Listeners>
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                        </ext:TriggerField>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="Store1" GroupField="TEN_DOT_TUYEN_DUNG" AutoLoad="true" runat="server">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="../Handlers/HoSoUngVienHandler.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="SearchKey" Value="#{HoSoUngVien_txtSearchKey}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="DotTuyenDung" Value="#{cbx_dottuyendung}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="month" Value="#{cbxMonth}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="year" Value="#{spnYear}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="checkToHOSO" Value="#{ck_ViewChuyenVaoHOSO}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_UNG_VIEN">
                                            <Fields>
                                                <ext:RecordField Name="MA_UNG_VIEN" />
                                                <ext:RecordField Name="ANH" />
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="GIOI_TINH" />
                                                <ext:RecordField Name="TUOI" />
                                                <ext:RecordField Name="NGAY_SINH" />
                                                <ext:RecordField Name="MA_TTHN" />
                                                <ext:RecordField Name="TEN_TTHN" />
                                                <ext:RecordField Name="NOI_SINH" />
                                                <ext:RecordField Name="MA_TINHTHANH" />
                                                <ext:RecordField Name="TEN_TINHTHANH" />
                                                <ext:RecordField Name="HKTT" />
                                                <ext:RecordField Name="DIA_CHI_LH" />
                                                <ext:RecordField Name="DI_DONG" />
                                                <ext:RecordField Name="DT_CO_DINH" />
                                                <ext:RecordField Name="MUC_LUONG_TOI_THIEU" />
                                                <ext:RecordField Name="MUC_LUONG_MONG_MUON" />
                                                <ext:RecordField Name="MA_QUOC_TICH" />
                                                <ext:RecordField Name="TEN_QUOC_TICH" />
                                                <ext:RecordField Name="MA_DAN_TOC" />
                                                <ext:RecordField Name="TEN_DAN_TOC" />
                                                <ext:RecordField Name="MA_TON_GIAO" />
                                                <ext:RecordField Name="TEN_TON_GIAO" />
                                                <ext:RecordField Name="EMAIL" />
                                                <ext:RecordField Name="MA_TT_SUCKHOE" />
                                                <ext:RecordField Name="TEN_TT_SUCKHOE" />
                                                <ext:RecordField Name="NHOM_MAU" />
                                                <ext:RecordField Name="TEN_NHOM_MAU" />
                                                <ext:RecordField Name="CHIEU_CAO" />
                                                <ext:RecordField Name="CAN_NANG" />
                                                <ext:RecordField Name="CMT" />
                                                <ext:RecordField Name="NGAY_CAP_CMT" />
                                                <ext:RecordField Name="NOI_CAP_CMT" />
                                                <ext:RecordField Name="MA_NOI_CAP_CMT" />
                                                <ext:RecordField Name="NGAY_COTHEDILAM" />
                                                <ext:RecordField Name="MA_TRINH_DO_HV" />
                                                <ext:RecordField Name="TEN_TRINH_DO_HV" />
                                                <ext:RecordField Name="MA_CHUYEN_NGANH" />
                                                <ext:RecordField Name="TEN_CHUYEN_NGANH" />
                                                <ext:RecordField Name="MA_TRUONG_DT" />
                                                <ext:RecordField Name="TEN_TRUONG_DT" />
                                                <ext:RecordField Name="MA_TRINH_DO_NN" />
                                                <ext:RecordField Name="TEN_TRINH_DO_NN" />
                                                <ext:RecordField Name="MA_TRINH_DO_TIN_HOC" />
                                                <ext:RecordField Name="TEN_TRINH_DO_TIN_HOC" />
                                                <ext:RecordField Name="MA_TRINH_DO_VH" />
                                                <ext:RecordField Name="TEN_TRINH_DO_VH" />
                                                <ext:RecordField Name="NGAY_NOP_HO_SO" />
                                                <ext:RecordField Name="ANH" />
                                                <ext:RecordField Name="MA_KHA_NANG" />
                                                <ext:RecordField Name="UU_DIEM" />
                                                <ext:RecordField Name="NHUOC_DIEM" />
                                                <ext:RecordField Name="SO_THICH" />
                                                <ext:RecordField Name="DIEM" />
                                                <ext:RecordField Name="DA_TRUNG_TUYEN" />
                                                <ext:RecordField Name="LY_DO" />
                                                <ext:RecordField Name="MA_LY_DO" />
                                                <ext:RecordField Name="VI_TRI" />
                                                <ext:RecordField Name="MA_VI_TRI" />
                                                <ext:RecordField Name="TEN_DOT_TUYEN_DUNG" />
                                                <ext:RecordField Name="MA_DOT_TUYEN_DUNG" />
                                                <ext:RecordField Name="KINH_NGHIEM" />
                                                <ext:RecordField Name="GHI_CHU" />
                                                <ext:RecordField Name="NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="DIA_CHI_NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="DIEN_THOAI_NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="EMAIL_NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="QUAN_HE_VOI_UNG_VIEN" />
                                                <ext:RecordField Name="BLACK_OR_STORE" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="33" />
                                    <ext:Column ColumnID="MA_UNG_VIEN" Header="Mã ứng viên" Width="70" DataIndex="MA_UNG_VIEN" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="120" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="GIOI_TINH" Header="Giới tính" Width="50" DataIndex="GIOI_TINH">
                                        <Renderer Fn="RenderGender" />
                                    </ext:Column>
                                    <ext:Column ColumnID="NGAY_SINH" Header="Ngày sinh" DataIndex="NGAY_SINH" Width="85">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <%--<ext:Column ColumnID="TUOI" Header="Tuổi" Width="50" DataIndex="TUOI" Align="Right" />--%>
                                    <ext:Column ColumnID="DIEM" Header="Tổng điểm" Width="80" DataIndex="DIEM" Align="Right" />
                                    <ext:TemplateColumn ColumnID="DI_DONG" Header="Thông tin liên hệ" Width="110" DataIndex="DI_DONG">
                                        <Template ID="Template4" runat="server">
                                            <Html>
                                                <p>{EMAIL}</p>
                                                <p>{DI_DONG}</p>
                                            </Html>
                                        </Template>
                                    </ext:TemplateColumn>
                                    <ext:Column ColumnID="MUC_LUONG_MONG_MUON" Header="Mức lương mong muốn" DataIndex="MUC_LUONG_MONG_MUON"
                                        Width="70">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="MUC_LUONG_TOI_THIEU" Header="Mức lương tối thiểu" DataIndex="MUC_LUONG_TOI_THIEU"
                                        Width="70">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:TemplateColumn ColumnID="TEN_TRUONG_DT" Header="Trường đào tạo" Width="150"
                                        DataIndex="TEN_TRUONG_DT">
                                        <Template runat="server">
                                            <Html>
                                                    {TEN_TRUONG_DT}
                                                                <br />
                                                    <i>Chuyên ngành :{TEN_CHUYEN_NGANH}</i>
                                                </Html>
                                        </Template>
                                    </ext:TemplateColumn>
                                    <ext:Column ColumnID="TEN_TRINH_DO_HV" Header="Trình độ học vấn" DataIndex="TEN_TRINH_DO_HV"
                                        Width="95" />
                                    <ext:Column ColumnID="NGAY_NOP_HO_SO" Header="Ngày nộp hồ sơ" DataIndex="NGAY_NOP_HO_SO"
                                        Width="85">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" Width="180" DataIndex="GHI_CHU">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_DOT_TUYEN_DUNG" Header="Tên đợt tuyển dụng" Width="180"
                                        DataIndex="TEN_DOT_TUYEN_DUNG">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="checkboxSelection" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="
                                                #{hdfRecordID}.setValue(#{checkboxSelection}.getSelected().id); 
                                                #{hdfKeHoachTuyenDung}.setValue(#{checkboxSelection}.getSelected().data.MA_DOT_TUYEN_DUNG); 
                                                ReloadStoreOfTabIndex();                                                 
                                                " />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <Listeners>
                                <RowDblClick Handler="#{wdAddUngVien}.show();setValueWdAddUngVien(checkboxSelection,0); " />
                            </Listeners>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                    <HeaderRows>
                                        <%--<HeaderRows>
                                            <ext:HeaderRow>
                                                <Columns>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox2" Width="80" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
                                                                    <ext:ListItem Text="Nam" />
                                                                    <ext:ListItem Text="Nữ" />
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
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false" Cls="x-small-editor">
                                                        <Component>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                        <Component>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                        <Component>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox4" Width="175" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
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
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox5" Width="175" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
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
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox6" Width="175" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
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
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox7" Width="90" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
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
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                </Columns>
                                            </ext:HeaderRow>
                                        </HeaderRows>--%>
                                    </HeaderRows>
                                </ext:GroupingView>
                            </View>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="100" />
                                            </Items>
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                            </Listeners>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        </ext:GridPanel>
                    </Center>
                    <South>
                        <ext:TabPanel Border="false" AnchorHorizontal="100%" Height="200" ID="tpThongTinUngVien"
                            EnableViewState="false" runat="server">
                            <Items>
                                <ext:Panel ID="Panel1" Cls="panelGeneralInformation" runat="server" EnableViewState="false"
                                    Padding="6" Title="Thông tin chung">
                                    <Items>
                                        <ext:Container runat="server" Layout="ColumnLayout" Height="230">
                                            <Items>
                                                <ext:Container ID="Container4" runat="server" Layout="FormLayout" ColumnWidth="0.14"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:ImageButton ID="img_anhdaidien" OverImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg"
                                                            ImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg" runat="server" Width="120"
                                                            Height="150" TabIndex="0" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="#{wdUploadImageWindow}.show(); setValueUpLoadImage(checkboxSelection);" />
                                                            </Listeners>
                                                        </ext:ImageButton>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container1" runat="server" Layout="FormLayout" ColumnWidth="0.283"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:TextField runat="server" FieldLabel="Họ tên" ID="lblHoTen" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Giới tính" ID="lblGioiTinh" AnchorHorizontal="98%"
                                                            Height="27">
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" FieldLabel="Tình trạng hôn nhân" ID="lblTTHN" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Tuổi" ID="lblTuoi" Height="27" AnchorHorizontal="98%" />
                                                        <ext:TextField runat="server" FieldLabel="Email" ID="lblEmail" AnchorHorizontal="98%"
                                                            Height="27" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container2" runat="server" Layout="FormLayout" ColumnWidth="0.283"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:TextField runat="server" FieldLabel="Quốc gia" ID="lblQuocGia" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Tỉnh thành" ID="lblTinhThanh" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Dân tộc" ID="lblDanToc" Height="27" AnchorHorizontal="98%" />
                                                        <ext:TextField runat="server" FieldLabel="Tôn giáo" ID="lblTonGiao" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Nơi ở hiện nay" ID="lblNoiOHienNay" AnchorHorizontal="98%"
                                                            Height="27" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container3" runat="server" Layout="FormLayout" ColumnWidth="0.283"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:TextField runat="server" FieldLabel="Chuyên ngành" ID="lblChuyenNganh" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Trường đào tạo" ID="lblTruongDaoTao" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Kinh nghiệm" ID="lblKinhNghiem" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Ưu điểm" ID="lblUuDiem" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:TextField runat="server" FieldLabel="Nhược điểm" ID="lblNhuocDiem" AnchorHorizontal="98%"
                                                            Height="27" />
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="pnlBangCapCC" Title="Chứng chỉ" runat="server" Layout="BorderLayout">
                                    <BottomBar>
                                        <ext:Toolbar runat="server" ID="Toolbar1ds">
                                            <Items>
                                                <ext:Button ID="btn_Add_ChungChi" Disabled="true" runat="server" Text="Thêm mới"
                                                    Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{wdAddChungChi}.show(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Edit_ChungChi" Disabled="true" runat="server" Text="Sửa" Icon="Pencil">
                                                    <Listeners>
                                                        <Click Handler="#{wdAddChungChi}.show();setValuewdAddChungChi(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Delete_ChungChi" runat="server" Disabled="true" Text="Xóa" Icon="Delete">
                                                    <DirectEvents>
                                                        <Click OnEvent="btn_Delete_ChungChi_Click">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <Close Handler="" />
                                        <Activate Handler="if(#{hdfCheckChungChiLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                                            {
                                                                #{Store_BangCapChungChi}.reload();
                                                                #{btn_Edit_ChungChi}.disable();
                                                                #{btn_Delete_ChungChi}.disable();
                                                                #{RowSelectionModel_ChungChi}.clearSelections();
                                                                #{hdfCheckChungChiLoaded}.setValue(#{hdfRecordID}.getValue());
                                                            }
                                                            " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckChungChiLoaded" />
                                        <ext:GridPanel ID="GridPanel_ChungChi" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoFocusColumn="GHI_CHU" AutoScroll="true" AnchorHorizontal="100%"
                                            Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_BangCapChungChi" AutoSave="true" ShowWarningOnFailure="false"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="Store_BangCapChungChi_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="MA_CHUNG_CHI" />
                                                                <ext:RecordField Name="TEN_CHUNG_CHI" />
                                                                <ext:RecordField Name="MA_XEP_LOAI" />
                                                                <ext:RecordField Name="TEN_XEP_LOAI" />
                                                                <ext:RecordField Name="NOI_DAO_TAO" />
                                                                <ext:RecordField Name="NGAY_CAP" />
                                                                <ext:RecordField Name="NGAY_HET_HAN" />
                                                                <ext:RecordField Name="GHI_CHU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel18" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Width="35" Header="STT" />
                                                    <ext:Column ColumnID="TEN_CHUNG_CHI" Header="Tên chứng chỉ" DataIndex="TEN_CHUNG_CHI" />
                                                    <ext:Column ColumnID="TEN_XEP_LOAI" Header="Xếp loại" DataIndex="TEN_XEP_LOAI" Width="105" />
                                                    <ext:Column ColumnID="NOI_DAO_TAO" Header="Nơi đào tạo" DataIndex="NOI_DAO_TAO" Width="200" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_CAP" Width="80" Header="Ngày cấp"
                                                        DataIndex="NGAY_CAP" />
                                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NGAY_HET_HAN" Width="80" Header="Ngày hết hạn"
                                                        DataIndex="NGAY_HET_HAN" />
                                                    <ext:Column ColumnID="GHI_CHU" Width="150" Header="Ghi chú" DataIndex="GHI_CHU" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel_ChungChi" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btn_Edit_ChungChi}.enable();#{btn_Delete_ChungChi}.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="#{wdAddChungChi}.show();setValuewdAddChungChi(); " />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="pnlKinhNghiemLV" EnableViewState="false" runat="server" Title="Kinh nghiệm làm việc"
                                    Layout="BorderLayout">
                                    <BottomBar>
                                        <ext:Toolbar runat="server" ID="tbbt">
                                            <Items>
                                                <ext:Button ID="btn_Add_KNLV" Disabled="true" runat="server" Text="Thêm mới" Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{wdKinhNghiemLamViec}.show(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Edit_KNLV" Disabled="true" runat="server" Text="Sửa" Icon="Pencil">
                                                    <Listeners>
                                                        <Click Handler="#{wdKinhNghiemLamViec}.show();setValuewdKinhNghiemLamViec(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Delete_KNLV" runat="server" Disabled="true" Text="Xóa" Icon="Delete">
                                                    <DirectEvents>
                                                        <Click OnEvent="btn_Delete_KNLV_Click">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <Close Handler="" />
                                        <Activate Handler="if(#{hdfCheckKNLV}.getValue()!=#{hdfRecordID}.getValue())
                                                            {
                                                                #{Store_KinhNghiemLamViec}.reload();
                                                                #{btn_Edit_KNLV}.disable();
                                                                #{btn_Delete_KNLV}.disable();
                                                                #{RowSelectionModel_KinhNghiemLamViec}.clearSelections();
                                                                #{hdfCheckKNLV}.setValue(#{hdfRecordID}.getValue());
                                                            }
                                                            " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckKNLV" />
                                        <ext:GridPanel ID="GridPanel_KinhNghiemLamViec" runat="server" StripeRows="true"
                                            Border="false" TrackMouseOver="true" AutoFocusColumn="GhiChu" AutoScroll="true"
                                            AnchorHorizontal="100%" Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_KinhNghiemLamViec" AutoSave="true" ShowWarningOnFailure="false"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoLoad="false" OnRefreshData="StoreKinhNghiemLamViec_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID_KNLV">
                                                            <Fields>
                                                                <ext:RecordField Name="ID_KNLV" />
                                                                <ext:RecordField Name="FR_KEY" />
                                                                <ext:RecordField Name="NoiLamViec" />
                                                                <ext:RecordField Name="ViTriCongViec" />
                                                                <ext:RecordField Name="LyDoThoiViec" />
                                                                <ext:RecordField Name="CreatedUser" />
                                                                <ext:RecordField Name="DisplayName" />
                                                                <ext:RecordField Name="TuThangNam" />
                                                                <ext:RecordField Name="DenThangNam" />
                                                                <ext:RecordField Name="KinhNghiemDatDuoc" />
                                                                <ext:RecordField Name="GhiChu" />
                                                                <ext:RecordField Name="MucLuong" />
                                                                <ext:RecordField Name="DiaChiCongTy" />
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
                                                <ext:RowSelectionModel ID="RowSelectionModel_KinhNghiemLamViec" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btn_Edit_KNLV}.enable();#{btn_Delete_KNLV}.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="#{wdKinhNghiemLamViec}.show();setValuewdKinhNghiemLamViec(); " />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel ID="Panel_QuaTrinhHocTap" EnableViewState="false" runat="server" Title="Quá trình học tập"
                                    Layout="BorderLayout">
                                    <BottomBar>
                                        <ext:Toolbar runat="server" ID="Toolbar_QuaTrinhHocTap">
                                            <Items>
                                                <ext:Button ID="btn_Add_QuaTrinhHocTap" Disabled="true" runat="server" Text="Thêm mới"
                                                    Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{wdAddBangCap}.show(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Edit_QuaTrinhHocTap" runat="server" Disabled="true" Text="Sửa"
                                                    Icon="Pencil">
                                                    <Listeners>
                                                        <Click Handler="#{wdAddBangCap}.show();setValueWdAddBangCap(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Delete_QuaTrinhHocTap" runat="server" Text="Xóa" Disabled="true"
                                                    Icon="Delete">
                                                    <DirectEvents>
                                                        <Click OnEvent="btn_Delete_QuaTrinhHocTap_Click">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <Close Handler="" />
                                        <Activate Handler="if(#{hdfCheckQTHTLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                                            {
                                                                #{Store_BangCap}.reload();
                                                                #{btn_Edit_QuaTrinhHocTap}.disable();
                                                                #{btn_Delete_QuaTrinhHocTap}.disable();
                                                                #{RowSelectionModel_BangCap}.clearSelections();
                                                                #{hdfCheckQTHTLoaded}.setValue(#{hdfRecordID}.getValue());
                                                            }
                                                            " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckQTHTLoaded" />
                                        <ext:GridPanel ID="GridPanel_BangCap" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoFocusColumn="TEN_TRUONG_DAOTAO" AutoScroll="true" AnchorHorizontal="100%"
                                            Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_BangCap" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" OnRefreshData="Store_BangCap_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="FR_KEY" />
                                                                <ext:RecordField Name="MA_TRUONG_DAOTAO" />
                                                                <ext:RecordField Name="TEN_TRUONG_DAOTAO" />
                                                                <ext:RecordField Name="KHOA" />
                                                                <ext:RecordField Name="DEN_NGAY" />
                                                                <ext:RecordField Name="TU_NGAY" />
                                                                <ext:RecordField Name="MA_CHUYENNGANH" />
                                                                <ext:RecordField Name="TEN_CHUYENNGANH" />
                                                                <ext:RecordField Name="MA_TRINHDO" />
                                                                <ext:RecordField Name="TEN_TRINHDO" />
                                                                <ext:RecordField Name="MA_HT_DAOTAO" />
                                                                <ext:RecordField Name="TEN_HT_DAOTAO" />
                                                                <ext:RecordField Name="MA_XEPLOAI" />
                                                                <ext:RecordField Name="TEN_XEPLOAI" />
                                                                <ext:RecordField Name="DA_TN" />
                                                                <ext:RecordField Name="NGAY_NHANBANG" />
                                                                <ext:RecordField Name="USERNAME" />
                                                                <ext:RecordField Name="DATE_CREATE" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel20" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Width="35" Header="STT" />
                                                    <ext:Column ColumnID="TEN_TRUONG_DAOTAO" Header="Trường đào tạo" DataIndex="TEN_TRUONG_DAOTAO"
                                                        Width="200" />
                                                    <ext:Column ColumnID="KHOA" Header="Khoa" DataIndex="KHOA" Width="100" />
                                                    <ext:Column ColumnID="TEN_CHUYENNGANH" Header="Chuyên ngành" DataIndex="TEN_CHUYENNGANH"
                                                        Width="100" />
                                                    <ext:DateColumn ColumnID="TU_NGAY" Format="yyyy" Width="70" Header="Từ năm" DataIndex="TU_NGAY"
                                                        Align="Right" />
                                                    <ext:DateColumn ColumnID="DEN_NGAY" Format="yyyy" Width="70" Header="Đến năm" DataIndex="DEN_NGAY"
                                                        Align="Right" />
                                                    <ext:Column ColumnID="TEN_TRINHDO" Width="70" Header="Trình độ" DataIndex="TEN_TRINHDO" />
                                                    <ext:Column ColumnID="TEN_HT_DAOTAO" Width="100" Header="Hình thức" DataIndex="TEN_HT_DAOTAO" />
                                                    <ext:Column ColumnID="DA_TN" Width="100" Header="Đã tốt nghiệp" DataIndex="DA_TN"
                                                        Align="Center">
                                                        <Renderer Fn="GetBooleanIconHSUV" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="TEN_XEPLOAI" Width="70" Header="Xếp loại" DataIndex="TEN_XEPLOAI" />
                                                    <ext:DateColumn ColumnID="NGAY_NHANBANG" Width="100" Header="Năm nhận bằng" DataIndex="NGAY_NHANBANG"
                                                        Format="yyyy" Align="Right" />
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel_BangCap" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btn_Edit_QuaTrinhHocTap}.enable();#{btn_Delete_QuaTrinhHocTap}.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="#{wdAddBangCap}.show();setValueWdAddBangCap(); " />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="pnlTepTinDinhKem" Title="Tệp tin đính kèm" EnableViewState="false"
                                    Layout="BorderLayout">
                                    <BottomBar>
                                        <ext:Toolbar runat="server" ID="tbpnlTepTinDinhKem">
                                            <Items>
                                                <ext:Button ID="btn_Add_File" runat="server" Disabled="true" Text="Thêm mới" Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="wdAttachFile.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Download_File" Disabled="true" runat="server" Text="Tải về" Icon="Attach">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnDownloadAttachFile_Click" IsUpload="true">
                                                            <ExtraParams>
                                                                <ext:Parameter Name="AttachFile" Mode="Raw" Value="RowSelectionModel_TepTinDinhKem.getSelected().data.Link">
                                                                </ext:Parameter>
                                                            </ExtraParams>
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btn_Delete_File" Disabled="true" Text="Xóa" Icon="Delete">
                                                    <DirectEvents>
                                                        <Click OnEvent="btn_Delete_File_Click">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <Close Handler="" />
                                        <Activate Handler="if(#{hdfCheckTepTinLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                                            {
                                                                #{Store_TepTinDinhKem}.reload();
                                                                #{btn_Download_File}.disable();
                                                                #{btn_Delete_File}.disable();
                                                                #{RowSelectionModel_TepTinDinhKem}.clearSelections();
                                                                #{hdfCheckTepTinLoaded}.setValue(#{hdfRecordID}.getValue());
                                                            }
                                                            " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfCheckTepTinLoaded" />
                                        <ext:GridPanel ID="GridPanel_TepTinDinhkem" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoFocusColumn="CreatedDate" AutoScroll="true" AnchorHorizontal="100%"
                                            Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_TepTinDinhKem" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                                                    SkipIdForNewRecords="false" RefreshAfterSaving="None" OnRefreshData="grpTepTinDinhKemStore_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
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
                                            <ColumnModel ID="ColumnModel4" runat="server">
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
                                                <ext:RowSelectionModel ID="RowSelectionModel_TepTinDinhKem" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btn_Download_File}.enable();#{btn_Delete_File}.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                        <ext:Hidden runat="server" ID="hdfCurrent" />
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="pnlKetQuaPhongVan" Layout="BorderLayout" Title="Kết quả phỏng vấn/thi tuyển">
                                    <BottomBar>
                                        <ext:Toolbar runat="server" ID="Toolbar1">
                                            <Items>
                                                <ext:Button ID="btn_Add_KetQuaPV" Disabled="true" runat="server" Text="Thêm mới"
                                                    Icon="Add">
                                                    <Listeners>
                                                        <Click Handler="#{wdChamDiemNhanXet}.show(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Edit_KetQuaPV" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                                    <Listeners>
                                                        <Click Handler="#{wdChamDiemNhanXet}.show();setValuewdChamDiemNhanXet(); " />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btn_Delete_KetQuaPV" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                                    <DirectEvents>
                                                        <Click OnEvent="btn_Delete_KetQuaPV_Click">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <Close Handler="" />
                                        <Activate Handler="if(#{hdfCheckKQPVLoaded}.getValue()!=#{hdfRecordID}.getValue())
                                                            {
                                                                #{Store_KetQuaPV}.reload();
                                                                #{btn_Edit_KetQuaPV}.disable();
                                                                #{btn_Delete_KetQuaPV}.disable();
                                                                #{RowSelectionModel_KetQuaPV}.clearSelections();
                                                                #{hdfCheckKQPVLoaded}.setValue(#{hdfRecordID}.getValue());
                                                            }
                                                            " />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden ID="hdfCheckKQPVLoaded" runat="server">
                                        </ext:Hidden>
                                        <ext:GridPanel ID="GridPanel_KetQuaPV" runat="server" StripeRows="true" Border="false"
                                            TrackMouseOver="true" AutoFocusColumn="NHAN_XET" AutoScroll="true" AnchorHorizontal="100%"
                                            Height="200" Region="Center">
                                            <Store>
                                                <ext:Store ID="Store_KetQuaPV" AutoLoad="true" AutoSave="true" OnRefreshData="grpKetQuaPhongVanThiTuyen_Store_OnRefreshData"
                                                    runat="server">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="MA_UNG_VIEN" />
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
                                            <ColumnModel ID="ColumnModel6" runat="server">
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
                                                <ext:RowSelectionModel ID="RowSelectionModel_KetQuaPV" runat="server" SingleSelect="true">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btn_Edit_KetQuaPV}.enable();#{btn_Delete_KetQuaPV}.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="#{wdChamDiemNhanXet}.show();setValuewdChamDiemNhanXet(); " />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:TabPanel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
