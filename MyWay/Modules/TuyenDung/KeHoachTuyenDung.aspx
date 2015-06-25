<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KeHoachTuyenDung.aspx.cs"
    Inherits="Modules_TuyenDung_KeHoachTuyenDungNEW" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register TagPrefix="a" Namespace="Ext.Net" Assembly="Ext.Net, Version=1.5.0.0, Culture=neutral, PublicKeyToken=2e12ce3d0176cd87" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="Resource/KeHoachTuyenDung.js" type="text/javascript"></script>
    <style type="text/css">
        div#pnReportPanel .x-tab-panel-header
        {
            display: none !important;
        }
        
        #grp_KeHoachTuyenDung .x-grid3-cell-inner
        {
            white-space: nowrap !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden ID="hdfRecordID" runat="server" />
        <ext:Store ID="StoreChonNhanVien" runat="server" AutoLoad="true">
            <Proxy>
                <ext:HttpProxy Method="POST" Url="Handlers/ChonNhanVien.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="Start" Value="={0}" />
                <ext:Parameter Name="Limit" Value="={10}" />
            </AutoLoadParams>
            <Reader>
                <ext:JsonReader Root="plants" TotalProperty="total">
                    <Fields>
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="PR_KEY" />
                        <ext:RecordField Name="MA_CB" />
                        <ext:RecordField Name="TEN_PHONG" />
                        <ext:RecordField Name="NGAY_SINH" />
                        <ext:RecordField Name="MA_PHONG" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window Hidden="true" ID="wdInsertKeHoachTuyenDung" runat="server" Title="Kế hoạch tuyển dụng"
            Padding="6" Icon="Add" Constrain="true" Modal="true" Width="700" AutoHeight="true"
            Layout="FormLayout" Resizable="false">
            <Items>
                <ext:Hidden runat="server" ID="hdfIDKeHoachTD" />
                <ext:Container ID="Container67" runat="server" Layout="FormLayout" LabelWidth="115">
                    <Items>
                        <ext:TextField runat="server" ID="txt_TenKeHoach" AllowBlank="false" AnchorHorizontal="100%"
                            FieldLabel="Tên kế hoạch<span style='color:red;'> *</span>" CtCls="requiredData"
                            MaxLength="500">
                        </ext:TextField>
                        <ext:Container ID="Container16" runat="server" LabelAlign="Left" LabelWidth="115"
                            Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container17" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:NumberField runat="server" ID="txt_SoLuongCanTuyen" AllowNegative="false" AllowBlank="false"
                                            AllowDecimals="false" AnchorHorizontal="98%" FieldLabel="Số lượng tuyển<span style='color:red'>*</span>"
                                            CtCls="requiredData" MaxLength="6">
                                        </ext:NumberField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container21" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:NumberField runat="server" AllowNegative="false" AnchorHorizontal="100%" ID="txt_SoVongPhongVan"
                                            AllowDecimals="false" FieldLabel="Số vòng phỏng vấn" MaxLength="4">
                                        </ext:NumberField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container22" runat="server" LabelAlign="Left" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container23" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfMaChucVu" />
                                        <ext:ComboBox runat="server" ID="cbx_MaChucVu" DisplayField="TEN_CHUCVU" ValueField="MA_CHUCVU"
                                            MinChars="1" EmptyText="Gõ để tìm kiếm" LoadingText="Đang tải dữ liệu..." PageSize="15"
                                            ListWidth="250" FieldLabel="Chức vụ" AnchorHorizontal="98%" ItemSelector="div.search-item">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store ID="stChucVu" runat="server" AutoLoad="false">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="POST" Url="../Base/ComboSearchHandler.ashx" />
                                                    </Proxy>
                                                    <BaseParams>
                                                        <ext:Parameter Name="Table" Value="dbo.DM_CHUCVU" Mode="Value" />
                                                        <ext:Parameter Name="ValueField" Value="MA_CHUCVU" Mode="Value" />
                                                        <ext:Parameter Name="DisplayField" Value="TEN_CHUCVU" Mode="Value" />
                                                    </BaseParams>
                                                    <Reader>
                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                            <Fields>
                                                                <ext:RecordField Name="MA_CHUCVU" />
                                                                <ext:RecordField Name="TEN_CHUCVU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Template ID="Template2" runat="server">
                                                <Html>
                                                    <tpl for=".">
                                                          <div class="search-item">
                                      
                                                           <h3>{TEN_CHUCVU}</h3>
                                                                        {MA_CHUCVU} <br />
                                                          </div>
                                                         </tpl>
                                                </Html>
                                            </Template>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();hdfMaChucVu.setValue(cbx_MaChucVu.getValue());" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{hdfMaChucVu}.reset(); }" />
                                                <Focus Handler="cbx_MaChucVu.store.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container24" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfMaCongViec" />
                                        <ext:ComboBox runat="server" ID="cbx_MaCongViec" DisplayField="TEN_CONGVIEC" ValueField="MA_CONGVIEC"
                                            MinChars="1" EmptyText="Gõ để tìm kiếm" LoadingText="Đang tải dữ liệu..." PageSize="15"
                                            CtCls="requiredData" FieldLabel="Công việc <span style='color:red'>*</span>"
                                            ListWidth="250" AnchorHorizontal="100%" ItemSelector="div.search-item">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store ID="stCongViec" runat="server" AutoLoad="false">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="POST" Url="../Base/ComboSearchHandler.ashx" />
                                                    </Proxy>
                                                    <BaseParams>
                                                        <ext:Parameter Name="Table" Value="dbo.DM_CONGVIEC" Mode="Value" />
                                                        <ext:Parameter Name="ValueField" Value="MA_CONGVIEC" Mode="Value" />
                                                        <ext:Parameter Name="DisplayField" Value="TEN_CONGVIEC" Mode="Value" />
                                                    </BaseParams>
                                                    <Reader>
                                                        <ext:JsonReader Root="plants" TotalProperty="total">
                                                            <Fields>
                                                                <ext:RecordField Name="MA_CONGVIEC" />
                                                                <ext:RecordField Name="TEN_CONGVIEC" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Template ID="Template3" runat="server">
                                                <Html>
                                                    <tpl for=".">
                                      <div class="search-item">
                                      
                                       <h3>{TEN_CONGVIEC}</h3>
                                                    {MA_CONGVIEC} <br />
                                      </div>
                                     </tpl>
                                                </Html>
                                            </Template>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();hdfMaCongViec.setValue(cbx_MaCongViec.getValue());" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{hdfMaCongViec}.reset(); }" />
                                                <Focus Handler="cbx_MaCongViec.store.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container71" runat="server" LabelAlign="Left" LabelWidth="115"
                            Layout="Form" ColumnWidth="0.5">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfMaDonVi" />
                                <ext:ComboBox runat="server" ID="cbx_Ma_DonVi" FieldLabel="Bộ phận<span style='color:red;'>*</span>"
                                    CtCls="requiredData" DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..."
                                    ItemSelector="div.list-item" AnchorHorizontal="100%" AllowBlank="false" Editable="false">
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
                                        <ext:Store runat="server" ID="stDonVi" AutoLoad="false" OnRefreshData="stDonVi_OnRefreshData">
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
                                        <Select Handler="this.triggers[0].show(); if (cbx_Ma_DonVi.getValue() <= 0) {alert('Bạn không có quyền thao tác với bộ phận này!'); cbx_Ma_DonVi.reset();}else{hdfMaDonVi.setValue(cbx_Ma_DonVi.getValue());}" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfMaDonVi.reset(); }" />
                                        <Focus Handler="cbx_Ma_DonVi.store.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container28" runat="server" LabelAlign="Left" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container29" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:TextField runat="server" EnableKeyEvents="true" ID="txt_MucLuongDuKienToiThieu"
                                            AnchorHorizontal="98%" FieldLabel="Lương tối thiếu" EmptyText="Lương tối thiểu dự kiến"
                                            MaskRe="[0-9]" MaxLength="15" AllowNegative="false" AllowDecimals="false">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container30" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:TextField runat="server" EnableKeyEvents="true" ID="txt_MucLuongDuKienToiDa"
                                            MaskRe="[0-9]" AnchorHorizontal="100%" FieldLabel="Lương tối đa" MaxLength="15"
                                            EmptyText="Lương tối đa dự kiến" AllowNegative="false" AllowDecimals="false">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container31" runat="server" LabelAlign="Left" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container32" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:NumberField runat="server" EnableKeyEvents="true" ID="txt_KinhPhiDuTru" AnchorHorizontal="98%"
                                            AllowNegative="false" AllowDecimals="false" FieldLabel="Kinh phí dự trù" MaxLength="15"
                                            EmptyText="Chi phí dự kiến cho đợt tuyển dụng">
                                        </ext:NumberField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container33" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:TextField runat="server" ID="txt_ThoiGianThuViec" AnchorHorizontal="100%" FieldLabel="Thời gian thử việc"
                                            EmptyText="Thời gian thử việc tính theo tháng" MaskRe="[0-9]" MaxLength="4">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container25" runat="server" LabelAlign="Left" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container26" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:DateField runat="server" ID="df_HanNopHoSo" Vtype="daterange" AnchorHorizontal="98%"
                                            MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                            RegexText="Định dạng ngày hạn nộp hồ sơ không đúng" FieldLabel="Hạn nộp hồ sơ">
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
                                <ext:Container ID="Container27" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfLyDoTuyenDung" />
                                        <ext:ComboBox ID="cbx_LyDoTuyenDung" runat="server" FieldLabel="Lý do tuyển dụng"
                                            Editable="false" DisplayField="Value" ValueField="ID" AnchorHorizontal="100%">
                                            <Store>
                                                <ext:Store ID="stLyDoTuyenDung" runat="server" AutoLoad="false" OnRefreshData="stLyDoTuyenDung_OnRefreshData">
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
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Focus Handler="#{stLyDoTuyenDung}.reload();" />
                                                <Select Handler="this.triggers[0].show();#{hdfLyDoTuyenDung}.setValue(#{cbx_LyDoTuyenDung}.getValue());" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container34" runat="server" LabelAlign="Left" Layout="ColumnLayout">
                            <Items>
                                <ext:Container ID="Container35" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:DateField runat="server" ID="df_NgayBatDau" Vtype="daterange" CtCls="requiredData" AnchorHorizontal="98%"
                                            MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                            RegexText="Định dạng ngày bắt đầu không đúng" FieldLabel="Ngày bắt đầu">
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
                                <ext:Container ID="Container36" runat="server" LabelAlign="Left" LabelWidth="115"
                                    Height="27" ColumnWidth="0.5" Layout="FormLayout">
                                    <Items>
                                        <ext:DateField runat="server" ID="df_NgayKetThuc" Vtype="daterange" CtCls="requiredData" AnchorHorizontal="100%"
                                            MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                            RegexText="Định dạng ngày kết thúc không đúng" FieldLabel="Ngày kết thúc">
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
                        <ext:TextArea runat="server" ID="txt_GhiChu" AnchorHorizontal="100%" Height="50"
                            LabelWidth="115" FieldLabel="Ghi chú" MaxLength="500">
                        </ext:TextArea>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhatKeHoachTuyenDung" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputThemMoiKHTD();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKeHoachTuyenDung_Click" After="resetForm">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditKeHoachTuyenDung" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputThemMoiKHTD();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKeHoachTuyenDung_Click" After="resetForm">
                            <EventMask ShowMask="true" Msg="Đang cập nhật" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhat_DongLaiKHTD" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="DiskMultiple">
                    <Listeners>
                        <Click Handler="return checkInputThemMoiKHTD();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatKeHoachTuyenDung_Click" After="resetForm">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnClose" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdInsertKeHoachTuyenDung}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetForm();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdChonTrangThai" Padding="6" Title="Chọn điệu kiện báo cáo"
            Modal="true" Hidden="true" Layout="FormLayout" Icon="Application" Width="461"
            Constrain="true" AutoHeight="true">
            <Items>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel}.remove(0);addHomePage(#{pnReportPanel},'Homepage','../Report/Baocao_Nhansu_Chitiet.aspx?prkey='+#{hdfRecordID }.getValue(), 'Báo cáo kế hoạch tuyển dụng')" />
                <Hide Handler="cbxchontrangthai.reset();cbChonPhongBan.reset();cbongaythangnam.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" ID="btn_InBaoCao" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="wdShowReport.show();" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btn_Thoat" Text="Hủy bỏ" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChonTrangThai.hide(); " />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo kế hoạch tuyển dụng" Maximized="true" Icon="Printer" Constrain="true">
            <Items>
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel}.remove(0);addHomePage(#{pnReportPanel},'Homepage','../Report/BaoCaoKeHoachTuyenDung.aspx?prkey='+#{hdfRecordID }.getValue(), 'Báo cáo kế hoạch tuyển dụng')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Hidden="true" ID="wdThemMoiYeuCauTuyenDung" runat="server" Title="Thêm mới yêu cầu tuyển dụng"
            Icon="Add" Constrain="true" Modal="true" Width="800" AutoHeight="true" EnableViewState="false"
            Layout="FormLayout" Padding="6">
            <Items>
                <ext:FieldSet runat="server" ID="fs_yeucautrinhdo" Title="Yêu cầu trình độ" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container18" runat="server" Layout="Column" Height="127">
                            <Items>
                                <ext:Container ID="Container19" Height="150" runat="server" Layout="Form" ColumnWidth=".33"
                                    LabelWidth="0">
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbxTrinhDo" FieldLabel="Trình độ" DisplayField="TEN_TRINHDO"
                                            ValueField="MA_TRINHDO" Width="130" TabIndex="1" Editable="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxTrinhDo_Store" AutoLoad="False">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="MA_TRINHDO">
                                                            <Fields>
                                                                <ext:RecordField Name="MA_TRINHDO" />
                                                                <ext:RecordField Name="TEN_TRINHDO" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Focus Handler="cbxTrinhDo_Store.reload();" />
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbxChuyenNganh" FieldLabel="Chuyên ngành" DisplayField="TEN_CHUYENNGANH"
                                            ValueField="MA_CHUYENNGANH" Width="130" TabIndex="2" Editable="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxChuyenNganh_Store" AutoLoad="False">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="MA_CHUYENNGANH">
                                                            <Fields>
                                                                <ext:RecordField Name="MA_CHUYENNGANH" />
                                                                <ext:RecordField Name="TEN_CHUYENNGANH" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Focus Handler="cbxChuyenNganh_Store.reload();" />
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbxXepLoai" FieldLabel="Xếp loại" DisplayField="TEN_XEPLOAI"
                                            ValueField="MA_XEPLOAI" Width="130" TabIndex="3" Editable="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxXepLoai_Store" AutoLoad="False">
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
                                            <Listeners>
                                                <Focus Handler="cbxXepLoai_Store.reload();" />
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbxTDNgoaiNgu" FieldLabel="TĐ Ngoại ngữ" DisplayField="TEN_NGOAINGU"
                                            ValueField="MA_NGOAINGU" Width="130" TabIndex="4" Editable="false">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxTDNgoaiNgu_Store" AutoLoad="False">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="MA_NGOAINGU">
                                                            <Fields>
                                                                <ext:RecordField Name="MA_NGOAINGU" />
                                                                <ext:RecordField Name="TEN_NGOAINGU" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Focus Handler="cbxTDNgoaiNgu_Store.reload();" />
                                                <Select Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Items>
                                        <ext:ComboBox ID="cbx_gioitinh" Editable="false" FieldLabel="Giới tính" runat="server"
                                            Width="130" TabIndex="5" SelectedIndex="0">
                                            <Items>
                                                <ext:ListItem Text="Không yêu cầu" Value="Không yêu cầu" />
                                                <ext:ListItem Text="Nam" Value="Nam" />
                                                <ext:ListItem Text="Nữ" Value="Nữ" />
                                            </Items>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container20" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".33"
                                    LabelWidth="100">
                                    <Items>
                                        <ext:Checkbox ID="chk_tdkhananglanhdao" runat="server" BoxLabel="Khả năng lãnh đạo"
                                            TabIndex="6">
                                        </ext:Checkbox>
                                        <ext:Checkbox ID="chk_tdsansangcongtac" runat="server" BoxLabel="Sẵn sàng đi công tác"
                                            TabIndex="7">
                                        </ext:Checkbox>
                                        <ext:NumberField ID="txt_tdkinhnghiem" runat="server" FieldLabel="Kinh nghiệm" AnchorHorizontal="98%"
                                            EmptyText="0" TabIndex="8" MaxLength="3" />
                                        <ext:NumberField ID="txt_tdtuoitu" runat="server" FieldLabel="Tuổi từ" AnchorHorizontal="98%"
                                            EmptyText="0" TabIndex="9" MinValue="0" MaxValue="100" />
                                        <ext:NumberField ID="txttddentuoi" runat="server" FieldLabel="Đến tuổi" AnchorHorizontal="98%"
                                            EmptyText="0" TabIndex="10" MinValue="0" MaxValue="100">
                                            <Listeners>
                                                <Blur Handler="if((#{txt_tdtuoitu}.getValue() * 1) > (#{txttddentuoi}.getValue() * 1)){Ext.Msg.alert('Cảnh báo','Bạn phải nhập từ tuổi < đến tuổi')}" />
                                            </Listeners>
                                        </ext:NumberField>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container1" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".33"
                                    LabelWidth="100">
                                    <Items>
                                        <ext:Checkbox ID="chk_tdcothethuyettrinh" runat="server" BoxLabel="Có thể thuyết trình"
                                            TabIndex="11">
                                        </ext:Checkbox>
                                        <ext:Checkbox ID="chk_tdsansanglamthemgio" runat="server" BoxLabel="Sẵn sàng làm thêm giờ"
                                            TabIndex="12">
                                        </ext:Checkbox>
                                        <ext:TextField ID="txt_td_hinhthuclamviec" runat="server" FieldLabel="Hình thức"
                                            AnchorHorizontal="100%" EmptyText="Fulltime/PartTime" TabIndex="13" MaxLength="500" />
                                        <ext:DateField ID="date_tdngaybatdaudilam" runat="server" FieldLabel="Ngày đi làm"
                                            AnchorHorizontal="100%" TabIndex="14" Editable="false">
                                        </ext:DateField>
                                        <ext:TextField ID="txt_tdthoigianthuviec" runat="server" FieldLabel="Thử việc" AnchorHorizontal="100%"
                                            EmptyText="0 tháng/năm" TabIndex="15" MaxLength="50" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="FieldSet1" Title="Yêu cầu công việc" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container2" runat="server" Layout="Column" Height="113">
                            <Content>
                                <ext:Container ID="Container3" Height="150" runat="server" Layout="Form" ColumnWidth=".4"
                                    LabelWidth="100">
                                    <Content>
                                        <ext:NumberField ID="tf_tdluongtoithieu" runat="server" FieldLabel="Lương tối thiểu"
                                            EmptyText="0" AnchorHorizontal="98%" TabIndex="16" MaxLength="10">
                                        </ext:NumberField>
                                        <ext:NumberField ID="tf_tdluongtoida" runat="server" FieldLabel="Lương tối đa" EmptyText="0"
                                            AnchorHorizontal="98%" TabIndex="17" MaxLength="10">
                                            <Listeners>
                                                <Blur Handler="if((#{tf_tdluongtoithieu}.getValue() * 1) > (#{tf_tdluongtoida}.getValue() * 1)){Ext.Msg.alert('Cảnh báo','Bạn phải nhập lương tối thiểu < lương tối đa')}" />
                                            </Listeners>
                                        </ext:NumberField>
                                        <ext:TextArea ID="txt_tdnoilamviec" Height="60" FieldLabel="Nơi làm việc" EmptyText="Nơi ứng viên làm việc...."
                                            AnchorHorizontal="98%" runat="server" TabIndex="18" MaxLength="500">
                                        </ext:TextArea>
                                    </Content>
                                </ext:Container>
                                <ext:Container ID="Container4" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".6">
                                    <Items>
                                        <ext:TextArea ID="txt_tduutien" Height="110" FieldLabel="Ưu tiên" EmptyText="Danh sách đối tượng được ưu tiên tuyển...."
                                            AnchorHorizontal="100%" runat="server" TabIndex="19">
                                        </ext:TextArea>
                                    </Items>
                                </ext:Container>
                            </Content>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="FieldSet2" Title="Yêu cầu hồ sơ" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container6" runat="server" Layout="Column" Height="120">
                            <Content>
                                <ext:Container ID="Container5" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".4"
                                    LabelWidth="100">
                                    <Items>
                                        <ext:TextArea ID="txt_tdmotacongviec" Height="110" FieldLabel="Mô tả công việc" EmptyText="Mô tả về công việc tuyển dụng...."
                                            AnchorHorizontal="98%" runat="server" TabIndex="20" MaxLength="500">
                                        </ext:TextArea>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container7" Height="150" runat="server" Layout="Form" ColumnWidth=".6">
                                    <Content>
                                        <ext:TextArea ID="txt_tdyeucauhoso" Height="90" FieldLabel="Hồ sơ " EmptyText="Yêu cầu về hồ sơ tuyển dụng...."
                                            AnchorHorizontal="100%" runat="server" TabIndex="21" MaxLength="500">
                                        </ext:TextArea>
                                        <ext:DateField ID="date_ngayBatDau_hidden" Vtype="daterange" runat="server" Editable="false"
                                            Hidden="true">
                                        </ext:DateField>
                                        <ext:DateField ID="date_tdhethanhoso" runat="server" Vtype="daterange" FieldLabel="Hết hạn hồ sơ"
                                            AnchorHorizontal="50%" TabIndex="22" Editable="false">
                                        </ext:DateField>
                                        <ext:DateField ID="date_ngayKetThuc_hidden" runat="server" Vtype="daterange" Editable="false"
                                            Hidden="true">
                                        </ext:DateField>
                                    </Content>
                                </ext:Container>
                            </Content>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btn_CapNhatYeuCau" Icon="Disk" Text="Cập nhật">
                </ext:Button>
                <ext:Button runat="server" ID="btn_HuyBo" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="#{wdThemMoiYeuCauTuyenDung}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="
                        #{cbxTrinhDo}.reset(); 
                        #{cbxChuyenNganh}.reset(); 
                        #{cbxXepLoai}.reset(); 
                        #{cbxTDNgoaiNgu}.reset();
                        #{cbx_gioitinh}.reset(); 
                        #{chk_tdkhananglanhdao}.reset();
                        #{chk_tdsansangcongtac}.reset(); 
                        #{txt_tdkinhnghiem}.reset(); 
                        #{txt_tdtuoitu}.reset();
                        #{txttddentuoi}.reset(); 
                        #{chk_tdcothethuyettrinh}.reset(); 
                        #{chk_tdsansanglamthemgio}.reset(); 
                        #{txt_td_hinhthuclamviec}.reset();
                        #{date_tdngaybatdaudilam}.reset(); 
                        #{txt_tdthoigianthuviec}.reset(); 
                        #{tf_tdluongtoithieu}.reset(); 
                        #{tf_tdluongtoida}.reset();
                        #{txt_tdnoilamviec}.reset(); 
                        #{txt_tduutien}.reset(); 
                        #{txt_tdmotacongviec}.reset();
                        #{txt_tdyeucauhoso}.reset(); 
                        #{date_tdhethanhoso}.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="500" Modal="true" Constrain="true" ID="wdCacKhoanChiPhi" Title="Các khoản chi phí"
            Padding="6" Icon="Money">
            <Items>
                <ext:TextField ID="txtTenKhoanChiPhi" runat="server" AllowBlank="false" AnchorHorizontal="100%"
                    CtCls="requiredData" FieldLabel="Tên khoản chi<span style='color:red'>*</span>"
                    MaxLength="500" />
                <ext:TextField ID="txtNguonChi" runat="server" AnchorHorizontal="100%" FieldLabel="Nguồn chi"
                    MaxLength="500" />
                <ext:Container runat="server" ID="ctvKhoanChi" Layout="ColumnLayout" Height="27">
                    <Items>
                        <ext:Container runat="server" ID="Container37" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtSoTienChiPhi" MaskRe="/[0-9\.]/" AllowBlank="true"
                                    FieldLabel="Số tiền" AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 chữ số">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container38" Layout="FormLayout" ColumnWidth="0.5"
                            LabelWidth="65">
                            <Items>
                                <ext:DateField runat="server" ID="dfNgayChi" EnableKeyEvents="true" Editable="true"
                                    FieldLabel="Ngày chi" AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                    Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng"
                                    Vtype="daterange">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txtGhiChuCacKhoanChi" FieldLabel="Ghi chú" MaxLength="500"
                    AnchorHorizontal="100%" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatChiPhi" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckWdCacKhoanChiPhi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatChiPhi_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatVaDongLaiChiPhi" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckWdCacKhoanChiPhi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatChiPhi_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="true" Mode="Value" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditCapNhatChiPhi" runat="server" Text="Cập nhật" Hidden="true"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckWdCacKhoanChiPhi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatChiPhi_Click">
                            <ExtraParams>
                                <ext:Parameter Name="type" Value="edit" Mode="Value" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button8" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdCacKhoanChiPhi}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="resetWdCacKhoanChiPhi();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdNhanDoiDuLieu" Hidden="true" Padding="6" Height="170" Width="400"
            runat="server" Title="Nhân đôi dữ liệu">
            <Items>
                <ext:Container ID="Container9" runat="server" LabelAlign="left" Layout="Form" ColumnWidth="0.5">
                    <Items>
                        <ext:TextField runat="server" ID="txt_NewID" AllowBlank="false" Width="200" FieldLabel="Mã kế hoạch"
                            MaxLength="50">
                        </ext:TextField>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="Button22" runat="server" Text="Nhân đôi" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputNhanKHTD();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnNhanDoiDuLieu_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button25" runat="server" Text="Hủy" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdNhanDoiDuLieu}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txt_NewID.reset();" />
                <Close Handler="txt_NewID.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdAddRequest" Resizable="false" Hidden="true" Width="500"
            Constrain="true" Modal="true" Height="250" Padding="5" Title="Thêm yêu cầu tuyển dụng">
            <Items>
                <ext:Container ID="Container8" runat="server" Layout="FormLayout" LabelWidth="165">
                    <Items>
                        <ext:Hidden ID="hd_ThuTu" runat="server" Text="1">
                        </ext:Hidden>
                        <ext:Hidden ID="hd_MaKeHoachTuyenDung" runat="server">
                        </ext:Hidden>
                        <ext:ComboBox DisplayField="TEN" ValueField="MA" FieldLabel="Yêu cầu tuyển dụng"
                            AnchorHorizontal="100%" ID="YCTD_CbYeuCauList_YeuCau" runat="server">
                        </ext:ComboBox>
                        <ext:ComboBox DisplayField="TEN" ValueField="MA" FieldLabel="Chọn thao tác áp dụng"
                            AnchorHorizontal="100%" ID="YCTD_CbThaoTac_MaThaoTac" runat="server">
                        </ext:ComboBox>
                        <%--<ext:MultiCombo--%>
                        <ext:ComboBox DisplayField="TEN" ValueField="MA" FieldLabel="Chọn giá trị" AnchorHorizontal="100%"
                            ID="YCTD_McbValueList_DapUng" runat="server">
                            <Store>
                                <ext:Store ID="Store2" runat="server" AutoLoad="false">
                                    <Reader>
                                        <ext:JsonReader Root="YeuCaus" IDProperty="TotalRecords">
                                            <Fields>
                                                <ext:RecordField Name="TEN" />
                                                <ext:RecordField Name="MA" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                        </ext:ComboBox>
                        <ext:Checkbox FieldLabel="Ưu tiên" ID="YCTD_CbUuTien_UuTien" runat="server" Checked="true">
                        </ext:Checkbox>
                        <ext:ComboBox DisplayField="TEN" ValueField="MA" FieldLabel="Chọn thao tác ngoại tuyến"
                            ID="YCTD_CbThaoTac_RecordRelation" AnchorHorizontal="100%" runat="server">
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="Button4" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputThemMoiYCTD();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemYeuCauTuyenDung_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button6" runat="server" Text="Cập nhật & đóng lại" Icon="DiskMultiple">
                    <Listeners>
                        <Click Handler="return checkInputThemMoiYCTD();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemYeuCauTuyenDung_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button10" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddRequest}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="hideWdAddRequest();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdChiPhi" Resizable="false" Hidden="true" Width="460"
            Constrain="true" Modal="true" AutoHeight="true" Padding="5" Title="Thêm các khoản chi">
            <Items>
                <ext:Container ID="Container10" runat="server" Width="450">
                    <Items>
                        <ext:TextField ID="txt_TenChiPhi" LabelWidth="150" Width="400" runat="server" FieldLabel="Tên khoản chi"
                            AnchorHorizontal="100%">
                        </ext:TextField>
                        <ext:TextField ID="txt_SoTien" LabelWidth="150" Width="400" runat="server" FieldLabel="Số Tiền"
                            AnchorHorizontal="100%">
                        </ext:TextField>
                        <ext:TextField ID="txt_NguonChi" LabelWidth="150" Width="400" runat="server" FieldLabel="Nguồn chi"
                            AnchorHorizontal="100%">
                        </ext:TextField>
                        <ext:DateField ID="txt_NgayChi" LabelWidth="150" Width="350" runat="server" FieldLabel="Ngày chi"
                            AnchorHorizontal="100%">
                        </ext:DateField>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Thêm & tiếp tục" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputWdChiPhi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemChiPhiTuyenDung_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button11" runat="server" Text="Thêm & Đóng lại" Icon="DiskMultiple">
                    <Listeners>
                        <Click Handler="return checkInputWdChiPhi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemChiPhiTuyenDung_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button12" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChiPhi}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdMonThi" Resizable="false" Hidden="true" Width="500"
            Constrain="true" Modal="true" AutoHeight="true" Padding="6" Title="Môn thi tuyển dụng"
            Layout="FormLayout">
            <Items>
                <ext:Hidden runat="server" ID="hdfMaMonThi" />
                <ext:ComboBox ID="cbMaMonThi" runat="server" FieldLabel="Môn thi<span style='color:red;'>*</span>"
                    CtCls="requiredData" DisplayField="Value" Editable="false" ValueField="ID" AnchorHorizontal="100%"
                    TabIndex="5">
                    <Store>
                        <ext:Store ID="storeMaMonThi" runat="server" AutoLoad="false" OnRefreshData="storeMaMonThi_OnRefreshData">
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
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Focus Handler="#{storeMaMonThi}.reload();" />
                        <Select Handler="this.triggers[0].show();#{hdfMaMonThi}.setValue(#{cbMaMonThi}.getValue());" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Container runat="server" ID="ctvsubject" Layout="ColumnLayout" Height="27">
                    <Items>
                        <ext:Container runat="server" ID="Container11" ColumnWidth="0.5" Layout="FormLayout">
                            <Items>
                                <ext:TextField ID="txt_TrongSo" runat="server" FieldLabel="Trọng số <span style='color:red'>*</span>"
                                    MaskRe="[0-9\.]" EmptyText="VD: 1.5" AnchorHorizontal="98%" CtCls="requiredData"
                                    AllowNegative="false" AllowDecimals="false" MaxLength="8">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container15" ColumnWidth="0.5" Layout="FormLayout">
                            <Items>
                                <ext:TextField ID="txt_DiemDat" runat="server" FieldLabel="Điểm đạt<span style='color:red'>*</span>"
                                    MaskRe="[0-9\.]" EmptyText="VD: 8.5" AnchorHorizontal="100%" CtCls="requiredData"
                                    AllowNegative="false" AllowDecimals="false" MaxLength="8">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Hidden runat="server" ID="hdfNguoiChamThi" />
                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                    CtCls="requiredData" DisplayField="HO_TEN" ValueField="PR_KEY" LoadingText="Đang tìm kiếm..."
                    AnchorHorizontal="100%" PageSize="10" ItemSelector="div.search-item" MinChars="1"
                    StoreID="StoreChonNhanVien" Note="Bạn phải chọn 1 cán bộ" ID="cbb_NguoiChamThi"
                    FieldLabel="Chọn cán bộ<span style='color:red;'>*</span>" Width="300">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						                                  <div class="search-item">							                                 
                                                              <h3>{HO_TEN}</h3> 
                                                              <h3>Mã CB: {MA_CB}</h3>
                                                              Ngày sinh: {NGAY_SINH:date("d/m/Y")}</br>                                                         
							                                 Phòng ban: {TEN_PHONG}</BR>                                                            
                                                              (Mã phòng ban: {MA_PHONG})     </BR>                                                         
						                                  </div>
					                                   </tpl>
                        </Html>
                    </Template>
                    <Listeners>
                        <Select Handler="#{hdfNguoiChamThi}.setValue(#{cbb_NguoiChamThi}.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                        <Focus Handler="cbb_NguoiChamThi.store.reload();" />
                    </Listeners>
                    <DirectEvents>
                        <Select OnEvent="CheckDaThoiViec">
                        </Select>
                    </DirectEvents>
                </ext:ComboBox>
                <ext:NumberField ID="txt_Vong" runat="server" FieldLabel="Vòng thi <span style='color:red'>*</span>"
                    AnchorHorizontal="100%" CtCls="requiredData" AllowNegative="false" AllowDecimals="false"
                    MaxLength="8">
                </ext:NumberField>
                <ext:TextArea ID="txt_GhiChuMonThi" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button ID="btnAddSubjectList" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputWdMonThi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddSubjectList_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditSubjectList" runat="server" Text="Cập nhật" Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return checkInputWdMonThi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddSubjectList_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="type" Value="edit" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnAddAndCloseSubjectList" runat="server" Text="Cập nhật & đóng lại"
                    Icon="DiskMultiple">
                    <Listeners>
                        <Click Handler="return checkInputWdMonThi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddSubjectList_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCloseWdMonThi" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdMonThi}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdHoiDong" Resizable="false" Hidden="true" Width="500"
            Constrain="true" Modal="true" AutoHeight="true" Padding="5" Title="Thêm thành viên hội đồng chấm thi">
            <Items>
                <ext:Container runat="server" ID="ctv1" Layout="FormLayout">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfGiamKhao" />
                        <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                            CtCls="requiredData" DisplayField="HO_TEN" ValueField="PR_KEY" LoadingText="Đang tìm kiếm..."
                            AnchorHorizontal="100%" PageSize="10" ItemSelector="div.search-item" MinChars="1"
                            StoreID="StoreChonNhanVien" Note="Bạn phải chọn 1 cán bộ" ID="cbx_GiamKhao" FieldLabel="Chọn cán bộ<span style='color:red;'>*</span>"
                            Width="300">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Template ID="Template5" runat="server">
                                <Html>
                                    <tpl for=".">
						                                  <div class="search-item">
                                                              <h3>{HO_TEN}</h3> 
                                                              <h3>Mã CB: {MA_CB}</h3>
                                                              Ngày sinh: {NGAY_SINH:date("d/m/Y")}</br>                                                         
							                                 Phòng ban: {TEN_PHONG}</BR>                                                            
                                                              (Mã phòng ban: {MA_PHONG})     </BR>                                                              
						                                  </div>
					                                   </tpl>
                                </Html>
                            </Template>
                            <Listeners>
                                <Select Handler="#{hdfGiamKhao}.setValue(cbx_GiamKhao.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } hdfGiamKhao.reset();" />
                                <Focus Handler="cbx_GiamKhao.store.reload();" />
                            </Listeners>
                            <DirectEvents>
                                <Select OnEvent="CheckDaThoiViec">
                                </Select>
                            </DirectEvents>
                        </ext:ComboBox>
                        <ext:NumberField ID="txt_VongCham" runat="server" FieldLabel="Vòng thi" AnchorHorizontal="100%"
                            AllowNegative="false" AllowDecimals="false" MaxLength="8">
                        </ext:NumberField>
                        <ext:TextArea ID="txtNoteHoiDong" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                        </ext:TextArea>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="btnAddGiamKhao" runat="server" Text="Cập nhất" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputWdHoiDong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddGiamKhao_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnAddAndCloseGiamKhao" runat="server" Text="Cập nhật & đóng lại"
                    Icon="DiskMultiple">
                    <Listeners>
                        <Click Handler="return checkInputWdHoiDong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddGiamKhao_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="true">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEditGiamKhao" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInputWdHoiDong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnAddGiamKhao_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật..." />
                            <ExtraParams>
                                <ext:Parameter Name="type" Value="edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button21" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdHoiDong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport ID="vp" runat="server" HideBorders="true">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="grp_KeHoachTuyenDung" TrackMouseOver="true" Header="false" runat="server"
                            StripeRows="true" Border="false" AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnAddKHTD" runat="server" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="resetForm();#{wdInsertKeHoachTuyenDung}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEditKHTD" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="if(CheckSelectedRecordPrint(grp_KeHoachTuyenDung,stKeHoachTuyenDung)){setValueWdKeHoachTuyenDung();}" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnDeleteKHTD" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDeleteKHTD_Click">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" Hidden="true" ID="btnBaoCao" Icon="Printer" Text="Báo cáo"
                                            Disabled="true">
                                            <ToolTips>
                                                <ext:ToolTip ID="ToolTip1" runat="server" Title="Hướng dẫn" Html="Chức năng báo cáo danh sách các kế hoạch tuyển dụng để cấp trên duyệt">
                                                </ext:ToolTip>
                                            </ToolTips>
                                            <Listeners>
                                                <Click Handler=" if( CheckSelectedRecordPrint(grp_KeHoachTuyenDung,stKeHoachTuyenDung)){wdShowReport.show();}" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:ComboBox runat="server" ID="cbxMonth" Width="120" Editable="false" FieldLabel="Tháng"
                                            SelectedIndex="0" LabelWidth="35">
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
                                        <ext:ToolbarSpacer ID="ToolbarSpacer6" runat="server" Width="5" />
                                        <ext:DisplayField runat="server" Text="Năm" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="5" />
                                        <ext:SpinnerField runat="server" ID="spnYear" Width="55">
                                            <Listeners>
                                                <Spin Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:SpinnerField>
                                        <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel"
                                            Hidden="false">
                                            <DirectEvents>
                                                <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc tên kế hoạch để tìm kiếm"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                            <Listeners>
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide();} #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="#{stKeHoachTuyenDung}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="stKeHoachTuyenDung" AutoLoad="true" runat="server">
                                    <Listeners>
                                        <Load Handler="checkboxSelection.clearSelections();" />
                                    </Listeners>
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="Handlers/KeHoachTuyenDungHandler.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="month" Value="#{cbxMonth}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="year" Value="#{spnYear}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="MaKeHoach" />
                                                <ext:RecordField Name="TenKeHoach" />
                                                <ext:RecordField Name="NgayBatDau" />
                                                <ext:RecordField Name="NgayKetThuc" />
                                                <ext:RecordField Name="TrangThaiXuLy" />
                                                <ext:RecordField Name="SoLuongCanTuyen" />
                                                <ext:RecordField Name="SoVongPhongVan" />
                                                <ext:RecordField Name="LyDoTuyen" />
                                                <ext:RecordField Name="KinhPhiDuTru" />
                                                <ext:RecordField Name="TEN_CONGVIEC" />
                                                <ext:RecordField Name="TEN_CHUCVU" />
                                                <ext:RecordField Name="TEN_DONVI" />
                                                <ext:RecordField Name="HanNopHoSo" />
                                                <ext:RecordField Name="MucLuongDuKienToiThieu" />
                                                <ext:RecordField Name="MucLuongDuKienToiDa" />
                                                <ext:RecordField Name="NoiLamViec" />
                                                <ext:RecordField Name="NgayBatDauDiLam" />
                                                <ext:RecordField Name="HoSoBaoGom" />
                                                <ext:RecordField Name="ThoiGianThuViec" />
                                                <ext:RecordField Name="HinhThucLamViec" />
                                                <ext:RecordField Name="MoTaCongViec" />
                                                <ext:RecordField Name="MaCongViec" />
                                                <ext:RecordField Name="MaChucVu" />
                                                <ext:RecordField Name="MA_DONVI" />
                                                <ext:RecordField Name="MaLyDoTuyen" />
                                                <ext:RecordField Name="GhiChu" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <View>
                                <ext:LockingGridView ID="GridView1" runat="server">
                                    <%-- <HeaderRows>
                                        <ext:HeaderRow>
                                            <Columns>
                                                <ext:HeaderColumn Cls="x-small-editor">
                                                    <Component>
                                                        <ext:Hidden runat="server">
                                                        </ext:Hidden>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor">
                                                    <Component>
                                                        <ext:Hidden runat="server">
                                                        </ext:Hidden>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor" AutoWidthElement="true">
                                                    <Component>
                                                        <ext:ComboBox ID="cbxTenKeHoachList" DisplayField="TEN" ValueField="MA" runat="server"
                                                            Editable="false">
                                                            <Store>
                                                                <ext:Store ID="stCbxTenKeHoachList" AutoLoad="false" runat="server">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="../../Handlers/HandlerCongViecList.ashx" />
                                                                    </Proxy>
                                                                    <AutoLoadParams>
                                                                        <ext:Parameter Name="start" Value="={0}" />
                                                                        <ext:Parameter Name="limit" Value="={30}" />
                                                                    </AutoLoadParams>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="type" Value="" />
                                                                    </BaseParams>
                                                                    <Reader>
                                                                        <ext:JsonReader Root="Data" IDProperty="MA">
                                                                            <Fields>
                                                                                <ext:RecordField Name="ID" />
                                                                                <ext:RecordField Name="TenKeHoach" />
                                                                            </Fields>
                                                                        </ext:JsonReader>
                                                                    </Reader>
                                                                </ext:Store>
                                                            </Store>
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="dhnCongViec.setValue(cbxTenKeHoachList.getValue()); stKeHoachTuyenDung.reload(); this.triggers[0].show();$('#cbxTenKeHoachList').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } dhnCongViec.reset(); stKeHoachTuyenDung.reload(); $('#cbxTenKeHoachList').removeClass('combo-selected');" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor">
                                                    <Component>
                                                        <ext:ComboBox ID="cbxViTriTuyenList" DisplayField="TEN" ValueField="MA" runat="server"
                                                             Editable="false">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="dhnCongViec.setValue(cbxTenKeHoachList.getValue()); stKeHoachTuyenDung.reload(); this.triggers[0].show();$('#cbxTenKeHoachList').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } dhnCongViec.reset(); stKeHoachTuyenDung.reload(); $('#cbxTenKeHoachList').removeClass('combo-selected');" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor" AutoWidthElement="true">
                                                    <Component>
                                                        <ext:ComboBox ID="cbbChucVuList" runat="server" DisplayField="TEN" ValueField="MA"
                                                            Editable="false">
                                                            <Store>
                                                                <ext:Store ID="store4" AutoLoad="false" runat="server">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="../../Handlers/HandlerChucVuList.ashx" />
                                                                    </Proxy>
                                                                    <AutoLoadParams>
                                                                        <ext:Parameter Name="start" Value="={0}" />
                                                                        <ext:Parameter Name="limit" Value="={30}" />
                                                                    </AutoLoadParams>
                                                                    <BaseParams>
                                                                        <ext:Parameter Name="Type" Value="LoadChucVuList" Mode="Value" />
                                                                    </BaseParams>
                                                                    <Reader>
                                                                        <ext:JsonReader Root="Data" IDProperty="MA">
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
                                                            <Listeners>
                                                                <Select Handler="hdnChucVu.setValue(cbbChucVuList.getValue());  stKeHoachTuyenDung.reload(); this.triggers[0].show();$('#cbbChucVuList').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } hdnChucVu.reset(); stKeHoachTuyenDung.reload();  $('#cbbChucVuList').removeClass('combo-selected');" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor">
                                                    <Component>
                                                        <ext:Hidden runat="server">
                                                        </ext:Hidden>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor">
                                                    <Component>
                                                        <ext:Hidden runat="server">
                                                        </ext:Hidden>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor" AutoWidthElement="true">
                                                    <Component>
                                                        <ext:DateField ID="dfFilter_NgayBatDau" runat="server">
                                                            <Listeners>
                                                                <Select Handler="stKeHoachTuyenDung.reload(); this.triggers[0].show(); $('#dfFilter_NgayBatDau').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); } stKeHoachTuyenDung.reload(); $('#dfFilter_NgayBatDau').removeClass('combo-selected');" />
                                                            </Listeners>
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                        </ext:DateField>
                                                    </Component>
                                                </ext:HeaderColumn>
                                                <ext:HeaderColumn Cls="x-small-editor" AutoWidthElement="true">
                                                    <Component>
                                                        <ext:DateField ID="dfFilter_NgayKetThuc" runat="server">
                                                            <Listeners>
                                                                <Select Handler="stKeHoachTuyenDung.reload(); this.triggers[0].show(); $('#dfFilter_NgayKetThuc').addClass('combo-selected');" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); } stKeHoachTuyenDung.reload(); $('#dfFilter_NgayKetThuc').removeClass('combo-selected');" />
                                                            </Listeners>
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                        </ext:DateField>
                                                    </Component>
                                                </ext:HeaderColumn>
                                            </Columns>
                                        </ext:HeaderRow>
                                    </HeaderRows>--%>
                                </ext:LockingGridView>
                            </View>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Width="35" Header="STT" Locked="true" />
                                    <ext:Column ColumnID="ID" Width="70" Header="Mã kế hoạch" DataIndex="ID" Hidden="false"
                                        Locked="true" />
                                    <ext:Column ColumnID="TenKeHoach" Width="200" Header="Tên kế hoạch" DataIndex="TenKeHoach"
                                        Locked="true" />
                                    <ext:Column ColumnID="TEN_CHUCVU" Width="150" Header="Chức vụ" DataIndex="TEN_CHUCVU" />
                                    <ext:Column ColumnID="TEN_CONGVIEC" Width="130" Header="Vị trí công việc" DataIndex="TEN_CONGVIEC" />
                                    <ext:Column Align="Right" Width="70" Header="Số lượng cần tuyển" DataIndex="SoLuongCanTuyen">
                                    </ext:Column>
                                    <ext:Column Align="Right" Width="90" Header="Số vòng phỏng vấn" DataIndex="SoVongPhongVan" />
                                    <ext:DateColumn ColumnID="NgayBatDau" Format="dd/MM/yyyy" Width="80" Header="Ngày bắt đầu"
                                        DataIndex="NgayBatDau" />
                                    <ext:DateColumn ColumnID="NgayKetThuc" Format="dd/MM/yyyy" Width="80" Header="Ngày kết thúc"
                                        DataIndex="NgayKetThuc" />
                                    <ext:Column ColumnID="MucLuongDuKienToiThieu" Width="90" Header="Mức lương tối thiểu"
                                        Align="Right" DataIndex="MucLuongDuKienToiThieu">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="MucLuongDuKienToiDa" Width="80" Header="Mức lương tối đa" Align="Right"
                                        DataIndex="MucLuongDuKienToiDa">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="KinhPhiDuTru" Width="80" Header="Kinh phí dự trù" DataIndex="KinhPhiDuTru"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="HanNopHoSo" Format="dd/MM/yyyy" Width="90" Header="Hạn nộp hồ sơ"
                                        DataIndex="HanNopHoSo" />
                                    <ext:Column ColumnID="ThoiGianThuViec" Width="80" Header="Thời gian thử việc" DataIndex="ThoiGianThuViec">
                                        <Renderer Fn="RenderTimeJob" />
                                    </ext:Column>
                                    <ext:Column ColumnID="GhiChu" Width="90" Header="Ghi chú" DataIndex="GhiChu" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="checkboxSelection" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="try{btnEditKHTD.enable();}catch(e){}; try{btnDeleteKHTD.enable();}catch(e){}; 
                                                            try{btnBaoCao.enable();}catch(e){}; 
                                                            try{hdfRecordID.setValue(checkboxSelection.getSelected().data.ID);}catch(e){}; 
                                                            LoadTableRelation();
                                                            btnAddChiPhi.enable();
                                                            btnAddSubject.enable();
                                                            btnAddCouncilRecruitment.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <Listeners>
                                <BeforeShow Handler="checkboxSelection.clearSelections();" />
                                <RowDblClick Handler="if (hdfRecordID.getValue() == '') 
                                        {
                                            alert('Bạn chưa chọn kế hoạch tuyển dụng nào'); 
                                            return false;
                                        } 
                                        else 
                                        { setValueWdKeHoachTuyenDung();}" />
                            </Listeners>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên một trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="5" />
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
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grp_KeHoachTuyenDung}.getSelectionModel().selectRow(rowIndex);" />
                            </Listeners>
                        </ext:GridPanel>
                    </Center>
                    <South>
                        <ext:TabPanel Border="false" ID="pnlYeuCauTuyenDung" runat="server" Title="Yêu cầu tuyển dụng"
                            AnchorHorizontal="100%" Height="230">
                            <Items>
                                <ext:Panel ID="pnlYCTuyenDung" Title="Yêu cầu tuyển dụng" Hidden="true" Padding="6"
                                    runat="server">
                                    <BottomBar>
                                        <ext:Toolbar runat="server">
                                            <Items>
                                                <ext:Button ID="btnAddRequest" runat="server" Text="Thêm mới yêu cầu tuyển dụng"
                                                    Icon="Add">
                                                    <Listeners>
                                                        <Click Handler=" #{wdAddRequest}.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </BottomBar>
                                    <Listeners>
                                        <Activate Handler="if (hdfRecordID.getValue() != hdfPanelYeuCauTuyenDung.getValue() && hdfRecordID.getValue() != '')
                                        { 
                                            hdfPanelYeuCauTuyenDung.setValue(hdfRecordID.getValue());
                                        }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Container runat="server" Layout="ColumnLayout" Height="230">
                                            <Items>
                                                <ext:Hidden runat="server" ID="hdfPanelYeuCauTuyenDung" />
                                                <ext:Container ID="Container12" runat="server" Layout="FormLayout" ColumnWidth="0.35"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:DisplayField runat="server" FieldLabel="Số lượng tuyển" ID="lbSoLuongTuyen"
                                                            AnchorHorizontal="98%" Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Số vòng phỏng vấn" ID="lbSoVongPV" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Chức vụ" ID="lbChucVu" Height="27" AnchorHorizontal="98%" />
                                                        <ext:DisplayField runat="server" FieldLabel="Công việc" ID="lbCongViec" AnchorHorizontal="98%"
                                                            Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Bộ phận" ID="lbBoPhan" AnchorHorizontal="98%"
                                                            Height="27" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container13" runat="server" Layout="FormLayout" ColumnWidth="0.35"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:DisplayField runat="server" FieldLabel="Mức lương tối thiểu" ID="lbMucLuongToiThieu"
                                                            AnchorHorizontal="98%" Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Mức lương tối đa" ID="lbMucLuongToiDa"
                                                            AnchorHorizontal="98%" Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Kinh phí dự trù" ID="lbKinhPhiDuTru"
                                                            Height="27" AnchorHorizontal="98%" />
                                                        <ext:DisplayField runat="server" FieldLabel="Thời gian thử việc" ID="lbThoiGianThuViec"
                                                            AnchorHorizontal="98%" Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Lý do tuyển dụng" ID="lbLyDoTuyenDung"
                                                            AnchorHorizontal="98%" Height="27" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container14" runat="server" Layout="FormLayout" ColumnWidth="0.3"
                                                    LabelWidth="120">
                                                    <Items>
                                                        <ext:DisplayField runat="server" FieldLabel="Yêu cầu bằng cấp" ID="lbYeuCauBangCap"
                                                            AnchorHorizontal="100%" Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Yêu cầu giới tính" ID="lbYeuCauGioiTinh"
                                                            AnchorHorizontal="100%" Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Hạn nộp hồ sơ" ID="lbHanNopHoSo" AnchorHorizontal="100%"
                                                            Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Ngày bắt đầu" ID="lbNgayBatDau" AnchorHorizontal="100%"
                                                            Height="27" />
                                                        <ext:DisplayField runat="server" FieldLabel="Ngày kết thúc" ID="lbNgayKetThuc" AnchorHorizontal="100%"
                                                            Height="27" />
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="pnchiphituyendung" Title="Các khoản chi phí" Layout="BorderLayout"
                                    CloseAction="Hide">
                                    <Listeners>
                                        <Activate Handler="if (hdfRecordID.getValue() != hdfPanelChiPhiTuyenDung.getValue() && hdfRecordID.getValue() != '')
                                                                {
                                                                    stChiPhiTuyenDung.reload();
                                                                    hdfPanelChiPhiTuyenDung.setValue(hdfRecordID.getValue());
                                                                }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfPanelChiPhiTuyenDung" />
                                        <ext:Hidden runat="server" ID="hdfChiPhiID" />
                                        <ext:GridPanel runat="server" ID="grdchiphituyendung" Region="Center" Border="false"
                                            AutoFocusColumn="GhiChu" AutoLoad="false" AnchorHorizontal="100%" Height="120">
                                            <BottomBar>
                                                <ext:Toolbar runat="server" ID="tbcptd">
                                                    <Items>
                                                        <ext:Button runat="server" ID="btnAddChiPhi" Icon="Add" Text="Thêm mới" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="if(CheckSelectedRecordPrint(grp_KeHoachTuyenDung,stKeHoachTuyenDung)) {wdCacKhoanChiPhi.show(); }  " />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnEditChiPhi" Icon="Pencil" Text="Sửa" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="return CheckSelectedRecordPrint(grdchiphituyendung,stChiPhiTuyenDung);
                                                                               #{btnCapNhatChiPhi}.hide();
                                                                                #{btnCapNhatVaDongLaiChiPhi}.hide();
                                                                                #{btnEditCapNhatChiPhi}.show(); 
                                                                                setValueWdCacKhoanChiPhi(); wdCacKhoanChiPhi.show();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnDeleteChiPhi" Icon="Delete" Text="Xóa" Disabled="true">
                                                            <DirectEvents>
                                                                <Click OnEvent="btnDeleteChiPhi_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </BottomBar>
                                            <Store>
                                                <ext:Store runat="server" ID="stChiPhiTuyenDung" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                                    AutoLoad="true">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="POST" Url="Handlers/HandlerChiPhiTuyenDung.ashx" />
                                                    </Proxy>
                                                    <BaseParams>
                                                        <ext:Parameter Name="PlanID" Value="hdfRecordID.getValue()" Mode="Raw" />
                                                    </BaseParams>
                                                    <Reader>
                                                        <ext:JsonReader Root="Data" IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="TenChiPhi" />
                                                                <ext:RecordField Name="SoTien" />
                                                                <ext:RecordField Name="NguonChi" />
                                                                <ext:RecordField Name="NgayChi" />
                                                                <ext:RecordField Name="GhiChu" />
                                                                <ext:RecordField Name="CreatedDate" />
                                                                <ext:RecordField Name="NguoiTao" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel3" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                                    <ext:Column Header="Tên khoản chi" Width="300" DataIndex="TenChiPhi">
                                                    </ext:Column>
                                                    <ext:Column Header="Nguồn chi" Width="200" DataIndex="NguonChi">
                                                    </ext:Column>
                                                    <ext:Column Header="Số tiền" Width="100" DataIndex="SoTien" Align="Right">
                                                        <Renderer Fn="RenderVND" />
                                                    </ext:Column>
                                                    <ext:DateColumn Header="Ngày chi" Format="dd/MM/yyyy" ColumnID="NgayChi" Width="100"
                                                        DataIndex="NgayChi" Align="Right">
                                                    </ext:DateColumn>
                                                    <ext:Column Header="Ghi chú" DataIndex="GhiChu" Align="Left" Width="300" />
                                                    <ext:DateColumn Header="Ngày tạo" Width="80" Format="dd/MM/yyyy" DataIndex="CreatedDate">
                                                    </ext:DateColumn>
                                                    <ext:Column Header="Người tạo" DataIndex="NguoiTao">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel_CPTD" runat="server">
                                                    <Listeners>
                                                        <RowSelect Handler="btnEditChiPhi.enable(); btnDeleteChiPhi.enable(); hdfChiPhiID.setValue(RowSelectionModel_CPTD.getSelected().data.ID);" />
                                                        <RowDeselect Handler="resetButtonAfterDeleteChiPhi();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="#{btnCapNhatChiPhi}.hide();
                                                                      #{btnCapNhatVaDongLaiChiPhi}.hide();
                                                                      #{btnEditCapNhatChiPhi}.show(); 
                                                                      setValueWdCacKhoanChiPhi(); wdCacKhoanChiPhi.show();" />
                                            </Listeners>
                                            <LoadMask Msg="Đang tải dữ liệu" ShowMask="true" />
                                        </ext:GridPanel>
                                    </Items>
                                    <Listeners>
                                        <Activate Handler="#{stChiPhiTuyenDung}.reload();" />
                                    </Listeners>
                                </ext:Panel>
                                <ext:Panel ID="pnHoiDongTuyenDung" runat="server" Layout="BorderLayout" Title="Hội đồng tuyển dụng">
                                    <Listeners>
                                        <Activate Handler="if (hdfRecordID.getValue() != hdfPanelHoiDongTuyenDung.getValue() && hdfRecordID.getValue() != '')
                                                            {
                                                                stCouncilRecruitment.reload();
                                                                hdfPanelHoiDongTuyenDung.setValue(hdfRecordID.getValue());
                                                            }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfPanelHoiDongTuyenDung" />
                                        <ext:Hidden runat="server" ID="hdfCouncilRecruitment" />
                                        <ext:GridPanel ID="grpCouncilRecruitment" runat="server" AutoFocusColumn="Note" StripeRows="true"
                                            Region="Center" Header="false" Border="false">
                                            <BottomBar>
                                                <ext:Toolbar runat="server" ID="Toolbar2">
                                                    <Items>
                                                        <ext:Button runat="server" ID="btnAddCouncilRecruitment" Icon="Add" Text="Thêm mới"
                                                            Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="if (hdfRecordID.getValue() != '') {resetWdHoiDong(); wdHoiDong.show(); } 
                                                                    else {alert('Bạn chưa chọn kế hoạch tuyển dụng nào!')}" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnEditCouncilRecruitment" Icon="Pencil" Text="Sửa"
                                                            Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="return CheckSelectedRecordPrint(grpCouncilRecruitment,stCouncilRecruitment);
                                                                                setValueWdHoiDong(); 
                                                                                wdHoiDong.show(); 
                                                                                btnAddGiamKhao.hide();
                                                                                btnAddAndCloseGiamKhao.hide();
                                                                                btnEditGiamKhao.show();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnDeleteCouncilRecruitment" Icon="Delete" Text="Xóa"
                                                            Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="btnDeleteCouncilRecruitment_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </BottomBar>
                                            <Store>
                                                <ext:Store ID="stCouncilRecruitment" runat="server" AutoLoad="false" OnRefreshData="stCouncilRecruitment_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="PrKeyHoSo" />
                                                                <ext:RecordField Name="MA_CB" />
                                                                <ext:RecordField Name="HO_TEN" />
                                                                <ext:RecordField Name="Note" />
                                                                <ext:RecordField Name="VongThi" />
                                                                <ext:RecordField Name="TEN_CHUCVU" />
                                                                <ext:RecordField Name="TEN_DONVI" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel2" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                    <ext:Column Header="Mã cán bộ" Width="70" DataIndex="MA_CB" Align="Left" />
                                                    <ext:Column Header="Họ tên" Width="160" DataIndex="HO_TEN" Align="Left" />
                                                    <ext:Column Header="Chức vụ" Width="125" DataIndex="TEN_CHUCVU" Align="Left">
                                                    </ext:Column>
                                                    <ext:Column Header="Phòng ban" Width="150" DataIndex="TEN_DONVI">
                                                    </ext:Column>
                                                    <ext:Column Header="Vòng thi" Width="100" DataIndex="VongThi" Align="Right" />
                                                    <ext:Column Header="Ghi chú" ColumnID="Note" Width="75" DataIndex="Note" Align="Left">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                                    <Listeners>
                                                        <RowSelect Handler="try{
                                                                #{hdfNguoiChamThi}.reset();
                                                                #{hdfCouncilRecruitment}.setValue(#{RowSelectionModel1}.getSelected().data.ID);
                                                                #{hdfNguoiChamThi}.setValue(#{RowSelectionModel1}.getSelected().data.PrKeyHoSo);
                                                                }catch(e){};
                                                                        btnEditCouncilRecruitment.enable(); 
                                                                        btnDeleteCouncilRecruitment.enable();" />
                                                        <RowDeselect Handler="resetButtonAfterDeleteHoiDong();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="setValueWdHoiDong(); 
                                                                        wdHoiDong.show(); 
                                                                        btnAddGiamKhao.hide();
                                                                        btnAddAndCloseGiamKhao.hide();
                                                                        btnEditGiamKhao.show();" />
                                            </Listeners>
                                            <LoadMask ShowMask="true" />
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" Layout="BorderLayout" ID="pnlMonThiTuyen" Title="Các môn thi tuyển"
                                    CloseAction="Hide">
                                    <Listeners>
                                        <Activate Handler="if (hdfRecordID.getValue() != hdfPanelCacMonThiTuyen.getValue() && hdfRecordID.getValue() != '')
                                                                {
                                                                    stSubjectList.reload();
                                                                    hdfPanelCacMonThiTuyen.setValue(hdfRecordID.getValue());
                                                                }" />
                                    </Listeners>
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfPanelCacMonThiTuyen" />
                                        <ext:Hidden runat="server" ID="hdfCacMonThiTuyen" />
                                        <ext:GridPanel ID="gpCacMonThiTuyen" runat="server" Width="800" Height="400" AutoFocusColumn="GhiChu"
                                            Border="false" Region="Center">
                                            <BottomBar>
                                                <ext:Toolbar runat="server" ID="Toolbar1">
                                                    <Items>
                                                        <ext:Button runat="server" ID="btnAddSubject" Icon="Add" Text="Thêm mới" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="if (hdfRecordID.getValue() != '') {resetWdMonThi(); wdMonThi.show(); } 
                                                                    else {alert('Bạn chưa chọn kế hoạch tuyển dụng nào!')}" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnEditSubject" Icon="Pencil" Text="Sửa" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="return CheckSelectedRecordPrint(gpCacMonThiTuyen,stSubjectList);
                                                                                setValueWdMonThi(); 
                                                                                wdMonThi.show(); 
                                                                                btnAddAndCloseSubjectList.hide();
                                                                                btnAddSubjectList.hide();
                                                                                btnEditSubjectList.show();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnDeleteSubject" Icon="Delete" Text="Xóa" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="btnDeleteSubject_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </BottomBar>
                                            <Store>
                                                <ext:Store ID="stSubjectList" runat="server" AutoLoad="false" OnRefreshData="stSubjectList_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID">
                                                            <Fields>
                                                                <ext:RecordField Name="ID" />
                                                                <ext:RecordField Name="MaMonThi" />
                                                                <ext:RecordField Name="TenMon" />
                                                                <ext:RecordField Name="TrongSo" />
                                                                <ext:RecordField Name="DiemDat" />
                                                                <%--<ext:RecordField Name="DSNguoiCham" />--%>
                                                                <ext:RecordField Name="NguoiCham" />
                                                                <ext:RecordField Name="Vong" />
                                                                <ext:RecordField Name="HO_TEN" />
                                                                <ext:RecordField Name="PrKeyHoSo" />
                                                                <ext:RecordField Name="GhiChu" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                                    <Listeners>
                                                        <RowSelect Handler="btnEditSubject.enable(); 
                                                                #{hdfMaMonThi}.setValue(RowSelectionModel2.getSelected().data.MaMonThi);
                                                                            btnDeleteSubject.enable(); 
                                                                            hdfCacMonThiTuyen.setValue(RowSelectionModel2.getSelected().data.ID);" />
                                                        <RowDeselect Handler="resetButtonAfterDeleteSubject();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <Listeners>
                                                <RowDblClick Handler="setValueWdMonThi(); 
                                                                    wdMonThi.show(); 
                                                                    btnAddAndCloseSubjectList.hide();
                                                                    btnAddSubjectList.hide();
                                                                    btnEditSubjectList.show();" />
                                            </Listeners>
                                            <ColumnModel>
                                                <Columns>
                                                    <ext:RowNumbererColumn Align="Right" Header="STT" Width="40" />
                                                    <ext:Column ColumnID="MonThi" Header="Môn thi" DataIndex="TenMon" Width="150" Sortable="true"
                                                        Align="Left">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="TrongSo" Header="Trọng số" DataIndex="TrongSo" Width="90" Sortable="true"
                                                        Align="Right">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="DiemDat" DataIndex="DiemDat" Header="Điểm đạt" Width="80" Align="Right">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="HO_TEN" Header="Người chấm thi" DataIndex="HO_TEN" Tooltip=""
                                                        Align="Left" Width="200">
                                                        <%--<Editor>
                                                            <ext:ComboBox Editable="True" DisplayField="HOTEN" ValueField="TENCB" runat="server"
                                                                ID="cbNguoiChamList" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm" LabelWidth="60"
                                                                Width="369" LoadingText="Đang tìm kiếm..." AnchorHorizontal="99%" HideTrigger="true"
                                                                ItemSelector="div.search-item" MinChars="1">
                                                                <Store>
                                                                    <ext:Store ID="cbStoreDonViList" AutoLoad="False" runat="server">
                                                                        <Proxy>
                                                                            <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/HandlerFindHoSo.ashx" />
                                                                        </Proxy>
                                                                        <AutoLoadParams>
                                                                            <ext:Parameter Name="Start" Value="={0}" />
                                                                            <ext:Parameter Name="Limit" Value="={10}" />
                                                                        </AutoLoadParams>
                                                                        <Reader>
                                                                            <ext:JsonReader Root="Hosos" IDProperty="total">
                                                                                <Fields>
                                                                                    <ext:RecordField Name="MACB" />
                                                                                    <ext:RecordField Name="TENCB" />
                                                                                    <ext:RecordField Name="HOTEN" />
                                                                                    <ext:RecordField Name="PHONGBAN" />
                                                                                    <ext:RecordField Name="CONGVIEC" />
                                                                                    <ext:RecordField Name="CHUCVU" />
                                                                                </Fields>
                                                                            </ext:JsonReader>
                                                                        </Reader>
                                                                    </ext:Store>
                                                                </Store>
                                                                <Template runat="server">
                                                                    <Html>
                                                                        <tpl for=".">
						                                                <div class="search-item">
							                                                <h3>{HOTEN}</h3>                                                                        							                                            
                                                                        Công việc: {CONGVIEC}</BR>
                                                                        Đơn vị: {PHONGBAN}</BR>
                                                                        Chức vụ: {CHUCVU}
						                                                </div>
					                                               </tpl>
                                                                    </Html>
                                                                </Template>
                                                                <Listeners>
                                                                    <Select Handler="SetNguoiChamThi(record.get('MACB'));" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Editor>--%>
                                                    </ext:Column>
                                                    <ext:Column ColumnID="VongThi" DataIndex="Vong" Header="Vòng thi" Width="70" Align="Right">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="GhiChu" DataIndex="GhiChu" Header="Ghi chú" Width="200" Align="Left">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <LoadMask ShowMask="true" />
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
