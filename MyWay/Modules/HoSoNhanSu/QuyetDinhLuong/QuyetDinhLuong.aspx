<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuyetDinhLuong.aspx.cs" Inherits="Modules_HoSoNhanSu_QuyetDinhLuong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="Script.js" type="text/javascript"></script>
    <script src="../../../Resource/js/global.js" type="text/javascript"></script>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <link href="StyleSheet.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #fpn_QDLuongHL .x-panel-footer
        {
            border-top: 1px solid #99BBE8;
        }
        
        #GridPanel1
        {
            border-left: 1px solid #99bbe8;
            border-bottom: 1px solid #99bbe8;
        }
        
        #pnlCacKhoanPhuCap
        {
            border-top: 1px solid #99bbe8;
        }
        
        #pnlCoCauToChuc-xsplit
        {
            border-right: none !important;
        }
        
        .disabled-control-style
        {
            color: Black !important;
        }
        
        .disabled-input-style
        {
            color: #595C6C !important;
        }
        
        #pnReportPanel .x-tab-panel-header
        {
            display: none !important;
        }
        
        .Download
        {
            background-image: url(../../../Resource/images/download.png) !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfButtonClick" />
        <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" ChiChonMotCanBo="false"
            DisplayWorkingStatus="DangLamViec" />
        <ext:Store runat="server" ID="cbHopDongLoaiHopDongStore" AutoLoad="false" OnRefreshData="cbHopDongLoaiHopDongStore_OnRefreshData">
            <Reader>
                <ext:JsonReader IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MaLoaiHopDong" />
                        <ext:RecordField Name="TenLoaiHopDong" />
                        <ext:RecordField Name="TenCongViec" />
                        <ext:RecordField Name="SoHopDong" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store runat="server" ID="cbxNgachCu_Store" AutoLoad="false" OnRefreshData="cbxNgachCu_Store_OnRefreshData">
            <Reader>
                <ext:JsonReader IDProperty="MA">
                    <Fields>
                        <ext:RecordField Name="MA" />
                        <ext:RecordField Name="TEN" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store runat="server" AutoLoad="false" OnRefreshData="cbLoaiLuongStore_OnRefreshData"
            ID="cbxLoaiLuongCu_Store">
            <Reader>
                <ext:JsonReader IDProperty="MA_LOAI_LUONG">
                    <Fields>
                        <ext:RecordField Name="MA_LOAI_LUONG" />
                        <ext:RecordField Name="TEN_LOAI_LUONG" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuApDungChoTatCa" runat="server" Icon="UserTick" Text="Áp dụng cho tất cả cán bộ">
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo quyết định lương" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../../Report/BaoCao_Main.aspx?type=QuyetDinhLuong&id=' + hdfRecordID.getValue(), 'Báo cáo quyết định lương');" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Icon="Money" Hidden="true" runat="server" Title="Thông tin phụ cấp"
            Padding="6" Width="550" Layout="FormLayout" Constrain="true" AutoHeight="true"
            ID="wdThemPhuCap" LabelWidth="105">
            <Items>
                <ext:ComboBox runat="server" ID="cbLoaiPhuCap" Editable="false" CtCls="requiredData"
                    ValueField="ID" DisplayField="Ten" AnchorHorizontal="100%" FieldLabel="Chọn phụ cấp<span style='color:red;'>*</span>">
                    <Store>
                        <ext:Store runat="server" ID="cbLoaiPhuCapStore" AutoLoad="false" OnRefreshData="cbLoaiPhuCapStore_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="Ten" />
                                        <ext:RecordField Name="HeSo" />
                                        <ext:RecordField Name="SoTien" />
                                        <ext:RecordField Name="PhanTram" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Listeners>
                        <Focus Handler=" cbLoaiPhuCapStore.reload(); " />
                        <Select Handler="GetDataFromStore(cbLoaiPhuCapStore);" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Container runat="server" Height="100" AnchorHorizontal="100%" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container4" runat="server" Height="85" Layout="FormLayout" ColumnWidth="0.5"
                            LabelWidth="105">
                            <Items>
                                <ext:TextField ID="txtHeSoPhuCap" runat="server" FieldLabel="Hệ số" AnchorHorizontal="98%"
                                    MaskRe="/[0-9.,]/" MaxLength="9">
                                </ext:TextField>
                                <ext:DateField ID="dfNgayQuyetDinhPhuCap" CtCls="requiredData" runat="server" FieldLabel="Ngày quyết định<span style='color:red;'>*</span>"
                                    AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" />
                                <ext:DateField runat="server" Vtype="daterange" EnableKeyEvents="true" ID="dfNgayHieuLucPhuCap"
                                    FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>" CtCls="requiredData"
                                    AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy">
                                </ext:DateField>
                                <ext:ComboBox ID="cbTrangThaiPhuCap" runat="server" CtCls="requiredData" AnchorHorizontal="98%"
                                    SelectedIndex="0" FieldLabel="Trạng thái<span style='color:red;'>*</span>" Editable="false">
                                    <Items>
                                        <ext:ListItem Text="Chờ duyệt" Value="ChoDuyet" />
                                        <ext:ListItem Text="Không duyệt" Value="KhongDuyet" />
                                        <ext:ListItem Text="Đã duyệt" Value="DaDuyet" />
                                    </Items>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" Layout="FormLayout" Height="100" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField ID="txtSoTien" runat="server" FieldLabel="Số tiền" AnchorHorizontal="100%"
                                    MaskRe="/[0-9]/" EnableKeyEvents="true" MaxLength="12">
                                </ext:TextField>
                                <ext:TextField ID="txtPhanTram" runat="server" FieldLabel="Phần trăm" AnchorHorizontal="100%"
                                    MaskRe="/[0-9.,]/" EnableKeyEvents="true" MaxLength="5">
                                </ext:TextField>
                                <ext:Hidden runat="server" ID="hdfNguoiQuyetDinhPhuCap" />
                                <ext:ComboBox AnchorHorizontal="100%" ValueField="PRKEY" DisplayField="HOTEN" runat="server"
                                    FieldLabel="Người quyết định" PageSize="10" HideTrigger="true" ItemSelector="div.search-item"
                                    MinChars="1" EmptyText="Nhập tên để tìm kiếm" ID="cbNguoiQuyetDinhPhuCap" LoadingText="Đang tải dữ liệu...">
                                    <Store>
                                        <ext:Store ID="Store3" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="SearchUserHandler.ashx" />
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
                                    <Template ID="Template3" runat="server">
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
                                        <Select Handler="hdfNguoiQuyetDinhPhuCap.setValue(cbNguoiQuyetDinhPhuCap.getValue());" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:DateField ID="dfHetHieuLucPhuCap" Vtype="daterange" EnableKeyEvents="true" runat="server"
                                    FieldLabel="Hết hiệu lực" AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy">
                                </ext:DateField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Listeners>
                <Hide Handler="resetFormPhuCap();btnCapNhatPhuCap.hide();btnThemPhuCap.show();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="btnCapNhatPhuCap" Hidden="true" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateForm();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemPhuCap_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update">
                                </ext:Parameter>
                                <ext:Parameter Name="RecordID" Value="#{RowSelectionModel2}.getSelected().data.ID"
                                    Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnThemPhuCap" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateForm();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemPhuCap_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThemPhuCap.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" Title="Tạo quyết định lương" Resizable="true" Layout="FormLayout"
            Padding="6" Width="870" Hidden="true" Icon="UserTick" ID="wdTaoQuyetDinhLuong"
            Modal="true" Constrain="true" AutoHeight="true">
            <Items>
                <ext:FieldSet runat="server" ID="FieldSet9" Layout="FormLayout" AnchorHorizontal="100%"
                    Title="Thông tin cán bộ">
                    <Items>
                        <ext:Container runat="server" ID="Ctn11" Layout="ColumnLayout" Height="50" AnchorHorizontal="100%">
                            <Items>
                                <ext:Container runat="server" ID="Ctn12" Layout="FormLayout" ColumnWidth="0.4">
                                    <Items>
                                        <ext:Hidden runat="server" ID="hdfChonCanBo" />
                                        <ext:ComboBox ID="cbxChonCanBo" CtCls="requiredData" ValueField="PRKEY" DisplayField="HOTEN"
                                            FieldLabel="Tên cán bộ<span style='color:red'>*</span>" PageSize="10" HideTrigger="true"
                                            ItemSelector="div.search-item" MinChars="1" EmptyText="Nhập tên để tìm kiếm"
                                            LoadingText="Đang tải dữ liệu..." AnchorHorizontal="98%" runat="server">
                                            <Store>
                                                <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="POST" Url="SearchUserHandler.ashx" />
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
                                                <Select Handler="hdfChonCanBo.setValue(cbxChonCanBo.getValue());" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Select OnEvent="cbxChonCanBo_Selected" />
                                            </DirectEvents>
                                        </ext:ComboBox>
                                        <ext:ComboBox runat="server" ID="cbx_bophan" FieldLabel="Bộ phận" DisplayField="TEN"
                                            ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
                                            AnchorHorizontal="98%" Editable="false" Disabled="true" DisabledClass="disabled-control-style">
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
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="Ctn13" Layout="FormLayout" ColumnWidth="0.6">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtChucVu" FieldLabel="Chức vụ" AnchorHorizontal="100%"
                                            Disabled="true" DisabledClass="disabled-input-style">
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtCongViec" FieldLabel="Vị trí công việc" AnchorHorizontal="100%"
                                            Disabled="true" DisabledClass="disabled-input-style">
                                        </ext:TextField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:Container runat="server" ID="Ctn15" Layout="ColumnLayout" Height="400" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="Ctn16" Layout="FormLayout" ColumnWidth="0.34">
                            <Items>
                                <ext:FieldSet runat="server" ID="Fs10" Layout="FormLayout" Title="Thông tin quyết định lương gần nhất"
                                    AnchorHorizontal="98%" Height="395">
                                    <Items>
                                        <ext:Container runat="server" ID="Ctn21" Layout="FormLayout" Height="150">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtSoQDCu" FieldLabel="Số quyết định" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtTenQDCu" FieldLabel="Tên quyết định" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:DateField runat="server" ID="dfNgayQDCu" FieldLabel="Ngày quyết định" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-control-style">
                                                </ext:DateField>
                                                <ext:TextField runat="server" ID="txtNguoiQDCu" FieldLabel="Người quyết định" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:DateField runat="server" ID="dfNgayCoHieuLucCu" FieldLabel="Ngày hiệu lực" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-control-style">
                                                </ext:DateField>
                                                <ext:TextField runat="server" ID="cbHopDongLoaiHopDongCu" FieldLabel="Loại hợp đồng"
                                                    AnchorHorizontal="100%" Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <%-- <ext:ComboBox runat="server" ID="cbHopDongLoaiHopDongCu" DisplayField="TEN_LOAI_HDONG"
                                                        ItemSelector="div.list-item" FieldLabel="Loại hợp đồng" Editable="false" ValueField="MA_LOAI_HDONG"
                                                        AnchorHorizontal="100%" Disabled="true" DisabledClass="disabled-control-style"
                                                        ListWidth="200" StoreID="cbHopDongLoaiHopDongStore">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        </Triggers>
                                                        <Template ID="Template11" runat="server">
                                                            <Html>
                                                                <tpl for=".">
						                                        <div class="list-item"> 
							                                        {TEN_LOAI_HDONG}
						                                        </div>
					                                        </tpl>
                                                            </Html>
                                                        </Template>
                                                        <Listeners>
                                                            <Expand Handler="#{cbHopDongLoaiHopDongStore}.reload();" />
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:ComboBox>--%>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Ctn22" Layout="FormLayout" Height="180">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxNgachCu" FieldLabel="Ngạch" DisplayField="TEN"
                                                    Disabled="true" ValueField="MA" AnchorHorizontal="100%" Editable="false" ItemSelector="div.list-item"
                                                    DisabledClass="disabled-control-style" StoreID="cbxNgachCu_Store">
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
                                                        <Expand Handler="if(cbxNgachCu.store.getCount()==0) cbxNgachCu_Store.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:TextField runat="server" ID="txtBacLuongCu" FieldLabel="Bậc lương" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtHeSoLuongCu" FieldLabel="Hệ số lương" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtMucLuongCu" FieldLabel="Lương hợp đồng" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtLuongDongBHCu" FieldLabel="Lương đóng BH" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhanTramHLCu" FieldLabel="% hưởng lương" AnchorHorizontal="100%"
                                                    Disabled="true" DisabledClass="disabled-input-style">
                                                </ext:TextField>
                                                <ext:ComboBox runat="server" ValueField="MA_LOAI_LUONG" DisplayField="TEN_LOAI_LUONG"
                                                    Hidden="true" FieldLabel="Loại lương" ID="cbxLoaiLuongCu" AnchorHorizontal="100%"
                                                    Editable="false" Disabled="true" DisabledClass="disabled-control-style" StoreID="cbxLoaiLuongCu_Store">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Expand Handler="if(cbxLoaiLuongCu.store.getCount()==0){cbxLoaiLuongCu_Store.reload();}" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Ctn17" Layout="FormLayout" ColumnWidth="0.66">
                            <Items>
                                <ext:FieldSet runat="server" ID="FieldSet5" Title="Thông tin quyết định mới" Layout="FormLayout"
                                    AnchorHorizontal="100%">
                                    <Items>
                                        <ext:Container runat="server" ID="Container18" Layout="ColumnLayout" AnchorHorizontal="100%"
                                            Height="26">
                                            <Items>
                                                <ext:Container runat="server" ID="Container19" Layout="FormLayout" ColumnWidth="0.5">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtSoQDMoi" AnchorHorizontal="99%" FieldLabel="Số quyết định"
                                                            MaxLength="20">
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ID="Container20" Layout="FormLayout" ColumnWidth="0.5"
                                                    LabelWidth="107">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayQDMoi" CtCls="requiredData" FieldLabel="Ngày quyết định"
                                                            Editable="true" MaskRe="/[0-9|/]/" Format="d/M/yyyy" AnchorHorizontal="100%">
                                                        </ext:DateField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:TextField runat="server" ID="txtTenQDMoi" FieldLabel="Tên quyết định<span style='color:red'>*</span>"
                                            AnchorHorizontal="100%" MaxLength="200" CtCls="requiredData">
                                        </ext:TextField>
                                        <ext:Container runat="server" ID="Container1" Layout="ColumnLayout" AnchorHorizontal="100%"
                                            Height="80">
                                            <Items>
                                                <ext:Container runat="server" ID="Container2" Layout="FormLayout" ColumnWidth="0.5">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayHieuLucMoi" CtCls="requiredData" FieldLabel="Ngày hiệu lực<span style='color:red'>*</span>"
                                                            Editable="true" MaskRe="/[0-9|/]/" Format="d/M/yyyy" AnchorHorizontal="99%" Vtype="daterange">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayHetHieuLucMoi}.setMinValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:Hidden runat="server" ID="hdfNguoiQuyetDinh" />
                                                        <ext:ComboBox ID="cbxChonNguoiQuyetDinh" ValueField="PRKEY" DisplayField="HOTEN"
                                                            FieldLabel="Người QĐ" ItemSelector="div.search-item" MinChars="1" EmptyText="Nhập tên để tìm kiếm"
                                                            LoadingText="Đang tải dữ liệu..." AnchorHorizontal="99%" runat="server" ListWidth="200">
                                                            <Store>
                                                                <ext:Store ID="cbxChonNguoiQuyetDinh_Store" runat="server" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="SearchUserHandler.ashx" />
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
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template5" runat="server">
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
                                                                <Select Handler="hdfNguoiQuyetDinh.setValue(cbxChonNguoiQuyetDinh.getValue()); this.triggers[0].show()" />
                                                                <TriggerClick Handler="hdfNguoiQuyetDinh.reset(); this.clearValue(); this.triggers[0].hide();" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:Hidden ID="hdfLoaiHopDong" runat="server">
                                                        </ext:Hidden>
                                                        <ext:ComboBox runat="server" ID="cbHopDongLoaiHopDongMoi" DisplayField="TenLoaiHopDong"
                                                            ItemSelector="div.list-item" FieldLabel="Loại hợp đồng<span style='color:red;'>*</span>"
                                                            Editable="false" ValueField="ID" AnchorHorizontal="99%" CtCls="requiredData"
                                                            ListWidth="200" StoreID="cbHopDongLoaiHopDongStore">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Template ID="Template10" runat="server">
                                                                <Html>
                                                                    <tpl for=".">
						                                                <div class="list-item"> 
							                                                <h3>{TenLoaiHopDong}</h3>
                                                                            Số HĐ: {SoHopDong}<br />
                                                                            Công việc: {TenCongViec}
						                                                </div>
					                                                </tpl>
                                                                </Html>
                                                            </Template>
                                                            <Listeners>
                                                                <Focus Handler="#{cbHopDongLoaiHopDongStore}.reload();" />
                                                                <Select Handler="hdfLoaiHopDong.setValue(cbHopDongLoaiHopDongMoi.getValue()); this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();  hdfLoaiHopDong.reset();}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ID="Container3" Layout="FormLayout" ColumnWidth="0.5"
                                                    LabelWidth="107">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayHetHieuLucMoi" FieldLabel="Hết hiệu lực"
                                                            Editable="true" MaskRe="/[0-9|/]/" Format="d/M/yyyy" AnchorHorizontal="100%"
                                                            Vtype="daterange">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayHieuLucMoi}.setMaxValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:ComboBox runat="server" ID="cbTrangThaiMoi" CtCls="requiredData" SelectedIndex="0"
                                                            Hidden="true" AnchorHorizontal="100%" Editable="false" FieldLabel="Trạng thái<span style='color:red'>*</span>">
                                                            <Items>
                                                                <ext:ListItem Text="Chờ duyệt" Value="ChoDuyet" />
                                                                <ext:ListItem Text="Đã duyệt" Value="DaDuyet" />
                                                                <ext:ListItem Text="Không duyệt" Value="KhongDuyet" />
                                                            </Items>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:Hidden runat="server" ID="hdfTepTinDinhKem" />
                                        <ext:CompositeField ID="composifieldAttach" runat="server" AnchorHorizontal="100%"
                                            FieldLabel="Tệp tin đính kèm">
                                            <Items>
                                                <ext:FileUploadField ID="fufTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                                                    ButtonText="" Icon="Attach" Width="363">
                                                </ext:FileUploadField>
                                                <ext:Button runat="server" ID="btnQDLDownload" Icon="ArrowDown" Hidden="true" ToolTip="Tải về">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnQDLDownload_Click" IsUpload="true" />
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" ID="btnQDLDelete" Icon="Delete" ToolTip="Xóa">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnQDLDelete_Click" After="#{fufTepTinDinhKem}.reset();">
                                                            <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                                                ConfirmRequest="true" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                            </Items>
                                        </ext:CompositeField>
                                        <ext:TextArea runat="server" ID="txtGhiChuMoi" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                                            Height="40" MaxLength="500" />
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet runat="server" ID="Fs6" AnchorHorizontal="100%" Title="Thông tin lương mới"
                                    Layout="FormLayout">
                                    <Items>
                                        <ext:Container runat="server" ID="Ctn5" Layout="ColumnLayout" Height="130" AnchorHorizontal="100%">
                                            <Items>
                                                <ext:Container runat="server" ID="Ctn6" Layout="FormLayout" ColumnWidth="0.5">
                                                    <Items>
                                                        <ext:ComboBox runat="server" ID="cbx_ngachMoi" FieldLabel="Ngạch" DisplayField="TEN"
                                                            StoreID="cbxNgachCu_Store" ValueField="MA" AnchorHorizontal="99%" Editable="false"
                                                            ItemSelector="div.list-item">
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
                                                                <Expand Handler="if(cbx_ngachMoi.store.getCount()==0) cbxNgachCu_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); cbxBacStore.reload();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txtHeSoLuongMoi" FieldLabel="Hệ số lương" Hidden="true"
                                                            AnchorHorizontal="99%" MaskRe="/[0-9.,]/" MaxLength="9" EmptyText="VD: 1.5">
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtLuongDongBHMoi" FieldLabel="Lương đóng BH<span style='color:red'>*</span>"
                                                            AnchorHorizontal="99%" MaxLength="15" MaskRe="/[0-9.,]/" CtCls="requiredData">
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtBacLuongNBMoi" FieldLabel="Bậc lương NB" AnchorHorizontal="99%"
                                                            MaxLength="15" MaskRe="/[0-9.,]/">
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtPhanTramHLMoi" FieldLabel="% hưởng lương" AnchorHorizontal="99%"
                                                            Hidden="true" MaxLength="3" MaskRe="/[0-9]/">
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtLuongTrachNhiemMoi" FieldLabel="Lương trách nhiệm"
                                                            AnchorHorizontal="99%" MaxLength="15" MaskRe="/[0-9.,]/">
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ID="Ctn7" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="107">
                                                    <Items>
                                                        <%--<ext:TextField runat="server" ID="txtBacLuongMoi" FieldLabel="Bậc lương" AnchorHorizontal="100%" MaxLength="20" MaskRe="/[0-9.,]/">
                                                        </ext:TextField>--%>
                                                        <ext:ComboBox runat="server" ID="cbxBacMoi" FieldLabel="Bậc lương" DisplayField="TEN"
                                                            ValueField="MA" AnchorHorizontal="100%" Editable="false" ItemSelector="div.list-item">
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
                                                                <ext:Store runat="server" ID="cbxBacStore" AutoLoad="false" OnRefreshData="cbxBacStore_OnRefreshData">
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
                                                                <Expand Handler="if (cbx_ngachMoi.getValue() == '') { cbxBacStore.removeAll(); alert('Bạn phải chọn ngạch trước');}" />
                                                                <Select Handler="this.triggers[0].show();Ext.net.DirectMethods.GetThongTinLuong();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txtMucLuongMoi" CtCls="requiredData" FieldLabel="Lương hợp đồng<span style='color:red'>*</span>"
                                                            AnchorHorizontal="100%" MaskRe="/[0-9.,]/" MaxLength="15">
                                                        </ext:TextField>
                                                        <ext:DateField runat="server" ID="dfNgayHLMoi" FieldLabel="Ngày hưởng lương" AnchorHorizontal="100%"
                                                            MaskRe="/[0-9|/]/" Format="d/M/yyyy" Note="'">
                                                        </ext:DateField>
                                                        <ext:DateField runat="server" ID="dfNgayHLNBMoi" FieldLabel="Ngày HL nội bộ" AnchorHorizontal="100%"
                                                            MaskRe="/[0-9|/]/" Format="d/M/yyyy">
                                                        </ext:DateField>
                                                        <ext:ComboBox runat="server" ValueField="MA_LOAI_LUONG" DisplayField="TEN_LOAI_LUONG"
                                                            Hidden="true" FieldLabel="Loại lương" ID="cbLoaiLuong" AnchorHorizontal="100%"
                                                            Editable="false" StoreID="cbxLoaiLuongCu_Store">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Expand Handler="if(cbLoaiLuong.store.getCount()==0){cbxLoaiLuongCu_Store.reload();}" />
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
                                <ext:Container runat="server" ID="Ctn57" Layout="FitLayout">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkSuDungPhuCapCu" Checked="true" BoxLabel="<span style='color:red;'>Áp dụng các phụ cấp cũ cho quyết định lương mới</span>">
                                        </ext:Checkbox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateWdTaoQuyetDinhLuong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu. Vui lòng chờ..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatSua" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateWdTaoQuyetDinhLuong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu. Vui lòng chờ..." />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatDongLai" Text="Cập nhật và đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return ValidateWdTaoQuyetDinhLuong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu. Vui lòng chờ..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLai" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdTaoQuyetDinhLuong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') Ext.net.DirectMethods.GenerateSoQD();" />
                <Hide Handler="ResetWdTaoQuyetDinhLuong();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Title="Tạo quyết định lương hàng loạt" Resizable="true"
            Layout="FormLayout" Padding="6" Width="1000" Hidden="true" Icon="UserTick" ID="wdTaoQuyetDinhLuongHangLoat"
            Modal="true" Constrain="true" AutoHeight="true">
            <Items>
                <ext:Container runat="server" ID="Container26" Layout="ColumnLayout" Height="245"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="Container27" Layout="FormLayout" ColumnWidth="0.51">
                            <Items>
                                <ext:FormPanel runat="server" ID="fpTTQD" Frame="true" AnchorHorizontal="99%" Title="Thông tin quyết định"
                                    Icon="BookOpen" Height="237">
                                    <Items>
                                        <ext:Container runat="server" ID="Container8" Layout="ColumnLayout" AnchorHorizontal="100%"
                                            Height="26">
                                            <Items>
                                                <ext:Container runat="server" ID="Container9" Layout="FormLayout" ColumnWidth="0.5">
                                                    <Items>
                                                        <ext:TextField runat="server" ID="txtSoQDHL" AnchorHorizontal="99%" FieldLabel="Số quyết định"
                                                            MaxLength="20">
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ID="Container10" Layout="FormLayout" ColumnWidth="0.5"
                                                    LabelWidth="107">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayQDHL" CtCls="requiredData" FieldLabel="Ngày quyết định"
                                                            Editable="true" MaskRe="/[0-9|/]/" Format="d/M/yyyy" AnchorHorizontal="100%">
                                                        </ext:DateField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:TextField runat="server" ID="txtTenQDHL" CtCls="requiredData" FieldLabel="Tên quyết định<span style='color:red'>*</span>"
                                            AnchorHorizontal="100%">
                                        </ext:TextField>
                                        <ext:Container runat="server" ID="Container14" Layout="ColumnLayout" AnchorHorizontal="100%"
                                            Height="53">
                                            <Items>
                                                <ext:Container runat="server" ID="Container23" Layout="FormLayout" ColumnWidth="0.5">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayHieuLucHL" CtCls="requiredData" FieldLabel="Ngày hiệu lực<span style='color:red'>*</span>"
                                                            Editable="true" MaskRe="/[0-9|/]/" Format="d/M/yyyy" AnchorHorizontal="99%" Vtype="daterange">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayHetHieuLucHL}.setMinValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:Hidden runat="server" ID="hdfNguoiQuyetDinhHL" />
                                                        <ext:ComboBox ID="cbxNguoiQuyetDinhHL" ValueField="PRKEY" DisplayField="HOTEN" FieldLabel="Người QĐ"
                                                            ItemSelector="div.search-item" MinChars="1" EmptyText="Nhập tên để tìm kiếm"
                                                            LoadingText="Đang tải dữ liệu..." AnchorHorizontal="99%" runat="server" ListWidth="200">
                                                            <Store>
                                                                <ext:Store ID="cbxNguoiQuyetDinhHL_Store" runat="server" AutoLoad="false">
                                                                    <Proxy>
                                                                        <ext:HttpProxy Method="POST" Url="SearchUserHandler.ashx" />
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
                                                            <Template ID="Template6" runat="server">
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
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="hdfNguoiQuyetDinhHL.setValue(cbxNguoiQuyetDinhHL.getValue()); this.triggers[0].show();" />
                                                                <TriggerClick Handler="this.clearValue(); hdfNguoiQuyetDinhHL.reset(); this.triggers[0].hide();" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ID="Container24" Layout="FormLayout" ColumnWidth="0.5"
                                                    LabelWidth="107">
                                                    <Items>
                                                        <ext:DateField runat="server" ID="dfNgayHetHieuLucHL" FieldLabel="Hết hiệu lực" Editable="true"
                                                            MaskRe="/[0-9|/]/" Format="d/M/yyyy" AnchorHorizontal="100%">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.reset(); #{dfNgayHieuLucHL}.setMinValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:ComboBox runat="server" CtCls="requiredData" ID="cbxTrangThaiQDHL" SelectedIndex="0"
                                                            Hidden="true" AnchorHorizontal="100%" Editable="false" FieldLabel="Trạng thái<span style='color:red'>*</span>">
                                                            <Items>
                                                                <ext:ListItem Text="Chờ duyệt" Value="ChoDuyet" />
                                                                <ext:ListItem Text="Đã duyệt" Value="DaDuyet" />
                                                                <ext:ListItem Text="Không duyệt" Value="KhongDuyet" />
                                                            </Items>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:Hidden runat="server" ID="hdfTepTinDinhKemHL" />
                                        <ext:CompositeField ID="cpfAttachHL" runat="server" AnchorHorizontal="100%" FieldLabel="Tệp tin đính kèm">
                                            <Items>
                                                <ext:FileUploadField ID="fufTepTinDinhKemHL" runat="server" EmptyText="Chọn tệp tin"
                                                    ButtonText="" Icon="Attach" Width="310">
                                                </ext:FileUploadField>
                                                <ext:Button runat="server" ID="btnHLDelete" Icon="Delete" ToolTip="Xóa">
                                                    <Listeners>
                                                        <Click Handler="#{fufTepTinDinhKemHL}.reset();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:CompositeField>
                                        <ext:TextArea runat="server" ID="txtGhiChuHL" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                                            Height="50" />
                                    </Items>
                                </ext:FormPanel>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container28" Layout="FormLayout" ColumnWidth="0.49">
                            <Items>
                                <ext:FormPanel runat="server" ID="fpn_QDLuongHL" Frame="true" AnchorHorizontal="100%"
                                    Title="Thông tin lương" Icon="Money" Height="237">
                                    <Items>
                                        <ext:Container runat="server" ID="Container29" Layout="ColumnLayout" Height="152"
                                            AnchorHorizontal="100%">
                                            <Items>
                                                <ext:Container runat="server" ID="Container30" Layout="FormLayout" ColumnWidth="0.5"
                                                    LabelWidth="110">
                                                    <Items>
                                                        <ext:ComboBox runat="server" ID="cbxNgachHL" FieldLabel="Ngạch" DisplayField="TEN"
                                                            StoreID="cbxNgachCu_Store" ValueField="MA" AnchorHorizontal="99%" Editable="false"
                                                            ItemSelector="div.list-item" ListWidth="200" DataIndex="MaNgach">
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
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                                <Expand Handler="return checkChooseEmployeeFirst();cbxNgachCu_Store.reload();" />
                                                                <Select Handler="this.triggers[0].show(); cbxBacLuongHLStore.reload();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txtHeSoLuongHL" FieldLabel="Hệ số lương" Hidden="true"
                                                            AnchorHorizontal="99%" MaskRe="/[0-9.,]/" MaxLength="9" DataIndex="HeSoLuong"
                                                            EmptyText="VD: 1.5" AllowBlank="false">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtLuongDongBHHL" FieldLabel="Lương đóng BH<span style='color:red'>*</span>"
                                                            AnchorHorizontal="99%" MaskRe="/[0-9.,]/" MaxLength="15" DataIndex="LuongDongBHXH"
                                                            CtCls="requiredData">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtBacLuongNBHL" FieldLabel="Bậc lương NB" AnchorHorizontal="99%"
                                                            DataIndex="BacLuongNB" MaskRe="/[0-9.,]/">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtPhanTramHuongLuongHL" FieldLabel="% hưởng lương"
                                                            AnchorHorizontal="99%" MaskRe="/[0-9.,]/" MaxLength="3" DataIndex="PhanTramHuongLuong">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:TextField runat="server" ID="txtLuongTrachNhiem" FieldLabel="Lương trách nhiệm"
                                                            AnchorHorizontal="99%" MaskRe="/[0-9.,]/" MaxLength="15" DataIndex="LuongTrachNhiem">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container runat="server" ID="Container31" Layout="FormLayout" ColumnWidth="0.5"
                                                    LabelWidth="107">
                                                    <Items>
                                                        <%--<ext:TextField runat="server" ID="txtBacLuongHL" FieldLabel="Bậc lương" AnchorHorizontal="100%"
                                                            DataIndex="BacLuong" MaskRe="/[0-9.,]/">
                                                        </ext:TextField>--%>
                                                        <ext:ComboBox runat="server" ID="cbxBacLuongHL" FieldLabel="Bậc lương" DisplayField="TEN"
                                                            ValueField="MA" AnchorHorizontal="100%" Editable="false" ItemSelector="div.list-item">
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
                                                                <ext:Store runat="server" ID="cbxBacLuongHLStore" AutoLoad="false" OnRefreshData="cbxBacLuongHLStore_OnRefreshData">
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
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                                <Expand Handler="return checkChooseEmployeeFirst(); if (cbxNgachHL.getValue() == ''){ cbxBacLuongHLStore.removeAll(); alert('Bạn phải chọn ngạch trước');}" />
                                                                <Select Handler="this.triggers[0].show();Ext.net.DirectMethods.GetThongTinLuong1();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:TextField runat="server" ID="txtMucLuongHL" CtCls="requiredData" FieldLabel="Lương hợp đồng<span style='color:red'>*</span>"
                                                            AnchorHorizontal="100%" MaskRe="/[0-9.,]/" MaxLength="15" DataIndex="LuongCung"
                                                            AllowBlank="false">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:DateField runat="server" ID="dfNgayHuongLuongHL" FieldLabel="Ngày hưởng lương"
                                                            AnchorHorizontal="100%" MaskRe="/[0-9|/]/" Format="d/M/yyyy" DataIndex="NgayHuongLuong"
                                                            Note="'">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:DateField runat="server" ID="dfNgayHuongLuongNBHL" FieldLabel="Ngày HL nội bộ"
                                                            AnchorHorizontal="100%" MaskRe="/[0-9|/]/" Format="d/M/yyyy" DataIndex="NgayHuongLuongNB">
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                            </Listeners>
                                                        </ext:DateField>
                                                        <ext:ComboBox runat="server" ValueField="MA_LOAI_LUONG" DisplayField="TEN_LOAI_LUONG"
                                                            FieldLabel="Loại lương" ID="cbxLoaiLuongHL" AnchorHorizontal="100%" Editable="false"
                                                            StoreID="cbxLoaiLuongCu_Store" DataIndex="MaLoaiLuong" AllowBlank="false">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <Focus Handler="return checkChooseEmployeeFirst();" />
                                                                <Expand Handler="return checkChooseEmployeeFirst(); if(cbxLoaiLuongHL.store.getCount()==0){cbxLoaiLuongCu_Store.reload();}" />
                                                                <Select Handler="this.triggers[0].show();" />
                                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                    <Buttons>
                                        <ext:Button runat="server" ID="btnCapNhatTTLuong" Text="Cập nhật" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="updateRecord(#{grp_DanhSachQuyetDinh});" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnCapNhatTatCaCanBo" Text="Cập nhật cho tất cả cán bộ"
                                            Icon="DiskMultiple">
                                            <Listeners>
                                                <Click Handler="updateAllRecord(#{grp_DanhSachQuyetDinh});" />
                                            </Listeners>
                                        </ext:Button>
                                    </Buttons>
                                </ext:FormPanel>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="Container25" Layout="BorderLayout" Height="250">
                    <Items>
                        <ext:GridPanel runat="server" ID="grp_DanhSachQuyetDinh" TrackMouseOver="true" Title="Danh sách cán bộ nhận quyết định"
                            StripeRows="true" Border="true" Region="Center" Icon="User">
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
                                                <Click Handler="#{grp_DanhSachQuyetDinh}.deleteSelected();#{fpn_QDLuongHL}.getForm().reset();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="grp_DanhSachQuyetDinh_Store" AutoSave="false" AutoLoad="false" runat="server"
                                    OnBeforeStoreChanged="HandleChanges" ShowWarningOnFailure="false" SkipIdForNewRecords="false"
                                    RefreshAfterSaving="None">
                                    <Reader>
                                        <ext:JsonReader IDProperty="PR_KEY">
                                            <Fields>
                                                <ext:RecordField Name="PR_KEY" />
                                                <ext:RecordField Name="MA_CB" />
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="TEN_DONVI" />
                                                <ext:RecordField Name="TEN_CHUCVU" />
                                                <ext:RecordField Name="MaNgach" />
                                                <ext:RecordField Name="TenNgach" />
                                                <ext:RecordField Name="BacLuong" />
                                                <ext:RecordField Name="HeSoLuong" Type="Float" />
                                                <ext:RecordField Name="LuongCung" Type="Float" />
                                                <ext:RecordField Name="LuongDongBHXH" Type="Float" />
                                                <ext:RecordField Name="LuongTrachNhiem" />
                                                <ext:RecordField Name="NgayHuongLuong" Type="Date" />
                                                <ext:RecordField Name="BacLuongNB" />
                                                <ext:RecordField Name="NgayHuongLuongNB" Type="Date" />
                                                <ext:RecordField Name="PhanTramHuongLuong" Type="Float" />
                                                <ext:RecordField Name="MaLoaiLuong" />
                                                <ext:RecordField Name="TrangThai" />
                                                <ext:RecordField Name="LuongTrachNhiem" Type="Float" />
                                                <ext:RecordField Name="PrkeyHoSoHopDong" />
                                                <ext:RecordField Name="TenLoaiHopDong" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel3" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="MA_CB" Header="Mã cán bộ" Locked="true" Width="70" DataIndex="MA_CB" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Locked="true" Width="150" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="200" DataIndex="TEN_DONVI">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_CHUCVU" Header="Chức vụ" Width="150" DataIndex="TEN_CHUCVU">
                                    </ext:Column>
                                    <ext:Column ColumnID="MaNgach" Header="Ngạch" Width="150" DataIndex="MaNgach">
                                        <Renderer Fn="ngachRenderer" />
                                        <Editor>
                                            <ext:ComboBox runat="server" ID="cbx_ngachGR" DisplayField="TEN" ValueField="MA"
                                                AnchorHorizontal="100%" Editable="false" ItemSelector="div.list-item" StoreID="cbxNgachCu_Store">
                                                <Template ID="Template33" runat="server">
                                                    <Html>
                                                        <tpl for=".">
						                                    <div class="list-item"> 
							                                    {TEN}
						                                    </div>
					                                    </tpl>
                                                    </Html>
                                                </Template>
                                                <Listeners>
                                                    <Expand Handler="if(cbx_ngachGR.store.getCount()==0) cbxNgachCu_Store.reload();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="BacLuong" Header="Bậc lương" Width="80" DataIndex="BacLuong">
                                    </ext:Column>
                                    <ext:Column ColumnID="HeSoLuong" Header="Hệ số lương" Width="80" DataIndex="HeSoLuong"
                                        Hidden="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="LuongCung" Header="Lương hợp đồng" Width="80" DataIndex="LuongCung">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="LuongDongBHXH" Header="Lương đóng BHXH" Width="100" DataIndex="LuongDongBHXH"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NgayHuongLuong" Header="Ngày hưởng lương" Width="120" DataIndex="NgayHuongLuong"
                                        Format="dd/MM/yyyy">
                                    </ext:DateColumn>
                                    <ext:Column ColumnID="PhanTramHuongLuong" Header="% hưởng lương" Width="100" DataIndex="PhanTramHuongLuong">
                                    </ext:Column>
                                    <ext:Column ColumnID="BacLuongNB" Header="Bậc lương NB" Width="80" DataIndex="BacLuongNB">
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NgayHuongLuongNB" Header="Ngày HL nội bộ" Width="100" DataIndex="NgayHuongLuongNB"
                                        Format="dd/MM/yyyy">
                                    </ext:DateColumn>
                                    <ext:Column ColumnID="MaLoaiLuong" Header="Loại lương" Width="100" DataIndex="MaLoaiLuong">
                                        <Renderer Fn="loaiLuongRenderer" />
                                    </ext:Column>
                                    <ext:Column ColumnID="LuongTrachNhiem" Header="Lương trách nhiệm" Width="100" DataIndex="LuongTrachNhiem"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="LockingGridView1" LockText="Cố định cột này lại"
                                    UnlockText="Hủy cố định cột" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModelQDHL" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="#{fpn_QDLuongHL}.getForm().loadRecord(record);#{fpn_QDLuongHL}.record = record;btnXoaCanBo.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="Container5" Layout="FitLayout">
                    <Items>
                        <ext:Checkbox runat="server" ID="chkSuDungPhuCapHL" Checked="true" BoxLabel="<span style='color:red;'>Áp dụng các phụ cấp cũ cho quyết định lương mới</span>">
                        </ext:Checkbox>
                    </Items>
                </ext:Container>
                <ext:Hidden runat="server" ID="hdfIsCloseWindows" Text="False" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatHL" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="if (ValidateWdTaoQuyetDinhLuongHangLoat() == false) return; #{grp_DanhSachQuyetDinh}.save();" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatDongLaiHL" Text="Cập nhật và đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="if (ValidateWdTaoQuyetDinhLuongHangLoat() == false) return; hdfIsCloseWindows.setValue('True'); #{grp_DanhSachQuyetDinh}.save();" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="Button6" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdTaoQuyetDinhLuongHangLoat}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (#{hdfButtonClick}.getValue() == 'Insert') Ext.net.DirectMethods.GenerateSoQDHL();" />
                <Hide Handler="ResetWdTaoQuyetDinhLuongHangLoat();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Title="Cấu hình các cột trên lưới" Resizable="false" Layout="FormLayout"
            Padding="6" Width="500" Hidden="true" Icon="Cog" ID="wdConfigGridPanel" Modal="true"
            Constrain="true" AutoHeight="true">
            <Items>
                <ext:FieldSet runat="server" ID="fs17" Title="Chọn các cột muốn hiển thị trên lưới"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="ctn105" AnchorHorizontal="100%" Layout="ColumnLayout"
                            Height="180">
                            <Items>
                                <ext:Container runat="server" ID="ctn106" ColumnWidth="0.5" Layout="RowLayout">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkLuongCung" BoxLabel="Lương hợp đồng" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkHeSoLuong" BoxLabel="Hệ số lương" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkPhanTramHL" BoxLabel="Phần trăm hưởng lương"
                                            Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkLoaiLuong" BoxLabel="Loại lương" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkLuongDongBHXH" BoxLabel="Lương đóng BHXH" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkBacLuong" BoxLabel="Bậc lương" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkBacLuongNB" BoxLabel="Bậc lương NB" Height="25"
                                            Checked="true" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn107" ColumnWidth="0.5" Layout="RowLayout">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkNgayHL" BoxLabel="Ngày hưởng lương" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNgayHLNB" BoxLabel="Ngày hưởng lương nội bộ"
                                            Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkSoQD" BoxLabel="Số quyết định" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNgayQD" BoxLabel="Ngày quyết định" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNgayHieuLuc" BoxLabel="Ngày hiệu lực" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNgayHetHieuLuc" BoxLabel="Ngày hết hiệu lực"
                                            Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNguoiQD" BoxLabel="Người quyết định" Height="25"
                                            Checked="true" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatCauHinh" Text="Cập nhật" Icon="Disk">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatCauHinh_Click">
                            <EventMask ShowMask="true" Msg="Đang tải dữ liệu. Vui lòng chờ..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLaiCauHinh" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdConfigGridPanel.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="Ext.net.DirectMethods.LoadConfigGridPanel();" />
                <Hide Handler="ResetWdConfig();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" TrackMouseOver="true" Header="false" runat="server"
                            Title="Bảng quyết định lương của cán bộ công nhân viên" StripeRows="true" Border="false"
                            AnchorHorizontal="100%">
                            <Store>
                                <ext:Store ID="Store1" AutoLoad="true" runat="server">
                                    <Listeners>
                                        <Load Handler="RowSelectionModel1.clearSelections();" />
                                    </Listeners>
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="QuyetDinhLuongHandler.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="maDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="searchKey" Value="txtSearchKey.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="trangThai" Value="DaDuyet" Mode="Value">
                                        </ext:Parameter>
                                        <ext:Parameter Name="userID" Value="hdfUserID.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="menuID" Value="hdfMenuID.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="SoQuyetDinh" />
                                                <ext:RecordField Name="MaCB" />
                                                <ext:RecordField Name="HoTen" />
                                                <ext:RecordField Name="TenBoPhan" />
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
                                                <ext:RecordField Name="GhiChu" />
                                                <ext:RecordField Name="PhanTramHuongLuong" />
                                                <ext:RecordField Name="LoaiLuong" />
                                                <ext:RecordField Name="NguoiQuyetDinh" />
                                                <ext:RecordField Name="TrangThai" />
                                                <ext:RecordField Name="GioiTinh" />
                                                <ext:RecordField Name="NgaySinh" />
                                                <ext:RecordField Name="HasPhuCap" />
                                                <ext:RecordField Name="IdNguoiQuyetDinhPhuCap" />
                                                <ext:RecordField Name="TepTinDinhKem" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnTaoQuyetDinh" runat="server" Text="Tạo quyết định" Icon="UserTick">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Tạo quyết định cho một cán bộ" ID="mnuTaoQDChoMotCB" Icon="User">
                                                            <Listeners>
                                                                <Click Handler="#{hdfButtonClick}.setValue('Insert');#{btnCapNhat}.show();#{btnCapNhatSua}.hide();#{btnCapNhatDongLai}.show();#{wdTaoQuyetDinhLuong}.show();#{chkSuDungPhuCapCu}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Tạo quyết định hàng loạt" Icon="User" ID="mnuTaoQDHangLoat">
                                                            <Listeners>
                                                                <Click Handler="#{hdfButtonClick}.setValue('Insert');#{wdTaoQuyetDinhLuongHangLoat}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="if(CheckSelectedRecord(#{GridPanel1}, #{Store1})){#{hdfButtonClick}.setValue('Edit')} else {return false};" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEdit_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Disabled="true" Text="Xóa" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation Message="Bạn có chắc chắn muốn xóa không ?" Title="Cảnh báo" ConfirmRequest="true" />
                                                    <EventMask ShowMask="true" Msg="Đang xóa dữ liệu" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnDownloadAttachFile" Text="Tải tệp tin đính kèm"
                                            Hidden="true" Icon="ArrowDown">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn quyết định lương nào'); return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnDownloadAttachFile_Click" />
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" ID="tbs" />
                                        <%--<ext:ComboBox runat="server" ID="cbFilterTrangThai" Editable="false" FieldLabel="Lọc"
                                            LabelWidth="50">
                                            <Items>
                                                <ext:ListItem Text="Chờ duyệt" Value="ChoDuyet" />
                                                <ext:ListItem Text="Không duyệt" Value="KhongDuyet" />
                                                <ext:ListItem Text="Đã duyệt" Value="DaDuyet" />
                                            </Items>
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Select Handler="this.triggers[0].show();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();Store1.reload();}" />
                                            </Listeners>
                                        </ext:ComboBox>--%>
                                        <%--<ext:Button ID="btnPrintQuyetDinh" runat="server" Text="In quyết định" Icon="Printer">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn quyết định lương nào'); return;} #{wdShowReport}.show();" />
                                            </Listeners>
                                        </ext:Button>--%>
                                        <ext:Button ID="btnCauHinh" runat="server" Text="Cấu hình" Icon="Cog">
                                            <Listeners>
                                                <Click Handler="wdConfigGridPanel.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập tên hoặc mã cán bộ"
                                            ID="txtSearchKey">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <KeyUp Handler="if (txtSearchKey.getValue() != '') this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.pageIndex = 0; #{Store1}.reload(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.pageIndex = 0; #{Store1}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <%--<ext:Column ColumnID="TepTinDinhKem" Header="" Locked="true" Width="25" DataIndex="TepTinDinhKem">
                                        <Renderer Fn="RenderTepTinDinhKem" />
                                    </ext:Column>--%>
                                    <ext:Column ColumnID="TepTinDinhKem" Width="25" DataIndex="" Align="Center" Locked="true">
                                        <Commands>
                                            <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                                <ToolTip Text="Tải tệp tin đính kèm" />
                                            </ext:ImageCommand>
                                        </Commands>
                                        <PrepareCommand Fn="prepare" />
                                    </ext:Column>
                                    <ext:Column ColumnID="MaCB" Header="Mã NV" Locked="true" Width="70" DataIndex="MaCB" />
                                    <ext:Column ColumnID="HoTen" Header="Họ tên" Locked="true" Width="160" DataIndex="HoTen" />
                                    <%--    <ext:Column ColumnID="TrangThai" Header="Tình trạng" Locked="false" Width="90" DataIndex="TrangThai">
                                            <Renderer Fn="RenderTinhTrang" />
                                        </ext:Column>--%>
                                    <ext:Column ColumnID="GioiTinh" Width="60" Align="Center" Header="Giới tính" DataIndex="GioiTinh">
                                        <Renderer Fn="GetGenderChar" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NgaySinh" Format="dd/MM/yyyy" Width="80" Header="Ngày sinh"
                                        DataIndex="NgaySinh">
                                    </ext:DateColumn>
                                    <ext:Column ColumnID="TenBoPhan" Width="150" Header="Bộ phận" DataIndex="TenBoPhan">
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_SOQD" Width="100" Align="Left" Header="Số quyết định" DataIndex="SoQuyetDinh">
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_LUONGDONGBHXH" Width="120" Align="Right" Header="Lương đóng BHXH"
                                        DataIndex="LuongDongBHXH">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_LUONGCUNG" Width="90" Align="Right" Header="Lương hợp đồng"
                                        DataIndex="LuongCung">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_HESOLUONG" Width="90" Align="Right" Header="Hệ số lương"
                                        DataIndex="HeSoLuong">
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_PHANTRAMHL" Width="100" Align="Right" Header="% hưởng lương"
                                        DataIndex="PhanTramHuongLuong">
                                        <Renderer Fn="RenderPercent" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_LOAILUONG" Width="100" Align="Right" Header="Loại lương"
                                        DataIndex="LoaiLuong">
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_BACLUONG" Width="100" Align="Right" Header="Bậc lương"
                                        DataIndex="BacLuong">
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_BACLUONGNB" Width="100" Align="Right" Header="Bậc lương NB"
                                        DataIndex="BacLuongNB">
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_NGAYQD" Width="120" Align="Left" Header="Ngày quyết định"
                                        DataIndex="NgayQuyetDinh">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_NGAYHL" Width="110" Align="Left" Header="Ngày hưởng lương"
                                        DataIndex="NgayHuongLuong">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_NGAYHLNB" Width="120" Align="Left" Header="Ngày hưởng lương NB"
                                        DataIndex="NgayHuongLuongNB">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_NGAYHIEULUC" Width="120" Align="Left" Header="Ngày hiệu lực"
                                        DataIndex="NgayHieuLuc">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_NGAYHETHIEULUC" Width="120" Align="Left" Header="Ngày hết hiệu lực"
                                        DataIndex="NgayKetThucHieuLuc">
                                        <Renderer Fn="RenderDate" />
                                    </ext:Column>
                                    <ext:Column ColumnID="QDL_NGUOIQD" Width="120" Align="Left" Header="Người quyết định"
                                        DataIndex="NguoiQuyetDinh">
                                    </ext:Column>
                                    <ext:Column ColumnID="Hidden" Width="0" DataIndex="" Align="Center" Locked="false">
                                        <Commands>
                                            <ext:ImageCommand CommandName="Hidden">
                                            </ext:ImageCommand>
                                        </Commands>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="try{btnEdit.enable();}catch(e){} try{btnDelete.enable();}catch(e){} try{btnAddPhuCap.enable();}catch(e){}
                                                             /*if(RowSelectionModel1.getSelected().data.HasPhuCap==true){pnlCacKhoanPhuCap.expand();}
                                                             else{pnlCacKhoanPhuCap.collapse();}*/
                                                            hdfRecordID.setValue(RowSelectionModel1.getSelected().id);grpPhuCapStore.reload();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <Listeners>
                                <ViewReady Handler="#{cbx_bophan_Store}.reload(); 
                                    try{cbxLoaiLuongCu_Store.reload();}catch(e){} 
                                    try{cbxNgachCu_Store.reload();}catch(e){}" />
                                <Command Handler="Ext.net.DirectMethods.DownloadAttach(record.data.TepTinDinhKem);" />
                            </Listeners>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
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
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Listeners>
                                        <Change Handler="RowSelectionModel1.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Center>
                    <South Split="true" Collapsible="true">
                        <ext:Panel Height="200" CtCls="south-panel" runat="server" Collapsed="false" Border="false"
                            Title="Các khoản phụ cấp" ID="pnlCacKhoanPhuCap" Layout="BorderLayout">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbPhuCap">
                                    <Items>
                                        <ext:Button runat="server" Disabled="true" ID="btnAddPhuCap" Text="Thêm phụ cấp"
                                            Icon="Money">
                                            <DirectEvents>
                                                <Click OnEvent="btnAddPhuCap_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="ngayQuyetDinh" Value="RowSelectionModel1.getSelected().data.NgayQuyetDinh"
                                                            Mode="Raw" />
                                                        <ext:Parameter Name="ngayHieuLuc" Value="RowSelectionModel1.getSelected().data.NgayHieuLuc"
                                                            Mode="Raw" />
                                                        <ext:Parameter Name="hetHieuLuc" Value="RowSelectionModel1.getSelected().data.NgayKetThucHieuLuc"
                                                            Mode="Raw" />
                                                    </ExtraParams>
                                                </Click>
                                            </DirectEvents>
                                            <Listeners>
                                                <Click Handler="cbNguoiQuyetDinhPhuCap.setValue(RowSelectionModel1.getSelected().data.NguoiQuyetDinh);  
                                                                    hdfNguoiQuyetDinhPhuCap.setValue(RowSelectionModel1.getSelected().data.IdNguoiQuyetDinhPhuCap);
                                                                    wdThemPhuCap.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnSuaPhuCap" Disabled="true" runat="server" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="if(CheckSelectedRecord(#{grpPhuCap}, #{grpPhuCapStore}) == true){ 
                                                                if(cbLoaiPhuCap.store.getCount()==0){
                                                                   cbLoaiPhuCapStore.reload();
                                                                }} else {return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnSuaPhuCap_Click">
                                                    <ExtraParams>
                                                        <ext:Parameter Name="RecordID" Value="#{RowSelectionModel2}.getSelected().data.ID"
                                                            Mode="Raw">
                                                        </ext:Parameter>
                                                    </ExtraParams>
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDeletePhuCap" runat="server" Disabled="true" Text="Xóa" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDeletePhuCap_Click">
                                                    <Confirmation Message="Bạn có chắc chắn muốn xóa ?" Title="Cảnh báo" ConfirmRequest="true" />
                                                    <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:GridPanel ID="grpPhuCap" AutoExpandColumn="TenPhuCap" Region="Center" runat="server"
                                    StripeRows="true" Border="false">
                                    <Store>
                                        <ext:Store runat="server" ID="grpPhuCapStore" OnRefreshData="grpPhuCapStore_OnRefreshData"
                                            AutoLoad="false">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="HeSo" />
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenPhuCap" />
                                                        <ext:RecordField Name="NgayHetHieuLuc" />
                                                        <ext:RecordField Name="NgayHieuLuc" />
                                                        <ext:RecordField Name="NgayQuyetDinh" />
                                                        <ext:RecordField Name="NguoiQuyetDinh" />
                                                        <ext:RecordField Name="SoTien" />
                                                        <ext:RecordField Name="PhanTram" />
                                                        <ext:RecordField Name="TrangThai" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                            <ext:Column ColumnID="TenPhuCap" Header="Loại phụ cấp" Width="90" DataIndex="TenPhuCap" />
                                            <ext:Column ColumnID="Company" Header="Số tiền" Width="100" DataIndex="SoTien" Align="Right">
                                                <Renderer Fn="RenderVND" />
                                            </ext:Column>
                                            <ext:Column ColumnID="Company2" Header="Hệ số" Width="80" DataIndex="HeSo" Align="Right" />
                                            <ext:Column ColumnID="ColPhanTram" Header="Phần trăm" Width="100" DataIndex="PhanTram"
                                                Align="Right">
                                                <Renderer Fn="RendererPhanTram" />
                                            </ext:Column>
                                            <ext:DateColumn Format="dd/MM/yyyy" Width="120" Align="Left" Header="Ngày quyết định"
                                                DataIndex="NgayQuyetDinh">
                                            </ext:DateColumn>
                                            <ext:DateColumn Format="dd/MM/yyyy" Width="120" Align="Left" Header="Ngày hiệu lực"
                                                DataIndex="NgayHieuLuc">
                                            </ext:DateColumn>
                                            <ext:DateColumn Format="dd/MM/yyyy" Width="120" Align="Left" Header="Ngày hết hiệu lực"
                                                DataIndex="NgayHetHieuLuc">
                                            </ext:DateColumn>
                                            <ext:Column Width="120" Align="Left" Header="Người quyết định" DataIndex="NguoiQuyetDinh">
                                            </ext:Column>
                                            <%--<ext:Column Width="120" Align="Left" Header="Trạng thái" DataIndex="TrangThai">
                                                <Renderer Fn="RenderTinhTrang" />
                                            </ext:Column>--%>
                                        </Columns>
                                    </ColumnModel>
                                    <%--<DirectEvents>
                                        <RowDblClick Before="btnCapNhatPhuCap.show();btnThemPhuCap.hide();
                                                                 if(cbLoaiPhuCap.store.getCount()==0){
                                                                    cbLoaiPhuCapStore.reload();}" OnEvent="btnSuaPhuCap_Click">
                                            <ExtraParams>
                                                <ext:Parameter Name="RecordID" Value="RowSelectionModel2.getSelected().id" Mode="Raw">
                                                </ext:Parameter>
                                            </ExtraParams>
                                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                        </RowDblClick>
                                    </DirectEvents>--%>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                            <Listeners>
                                                <RowSelect Handler="try{btnSuaPhuCap.enable();}catch(e){} try{btnDeletePhuCap.enable();}catch(e){}" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
