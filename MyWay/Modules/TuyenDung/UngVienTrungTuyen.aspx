<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UngVienTrungTuyen.aspx.cs"
    Inherits="Modules_TuyenDung_UngVienTrungTuyen" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/DateTime/DateTime.ascx" TagName="DateTime" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/Validation.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        div#pnReportPanel .x-tab-panel-header
        {
            display: none !important;
        }
        
        div#GridPanel1 .x-grid3-cell-inner, .x-grid3-hd-inner
        {
            white-space: nowrap !important;
        }
    </style>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="Resource/UngVienTrungTuyen.js" type="text/javascript"></script>
    <script src="Resource/UngVienDuTruJS.js" type="text/javascript"></script>
    <style type="text/css">
        .x-form-item
        {
            padding: 6px;
        }
        
        .x-label-value
        {
            padding-left: 10px;
            margin-bottom: 10px;
            font-size: 12px;
            height: 30px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfFilterGioiTinh" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfIdMcb" />
        <ext:Hidden runat="server" ID="hdfGioiTinh" />
        <ext:Hidden runat="server" ID="hdfViTriUngTuyen" />
        <ext:Hidden runat="server" ID="hdfMaUngVien" />
        <ext:Hidden runat="server" ID="hdfNgayDiLam" />
        <ext:Hidden runat="server" ID="hdfMaKeHoachTuyenDung" />
        <ext:Window runat="server" ID="wdRoiNgayDiLam" Modal="true" Width="390" Padding="6"
            Layout="FormLayout" Hidden="true" Title="Rời ngày đi làm" Icon="Clock" Constrain="true"
            AutoHeight="true">
            <Content>
                <ext:DateField runat="server" ID="DateTime1" EnableKeyEvents="true" CtCls="requiredData"
                    Editable="true" FieldLabel="Ngày đi làm<span style='color:red;'>*</span>" AnchorHorizontal="98%"
                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                </ext:DateField>
            </Content>
            <Buttons>
                <ext:Button runat="server" ID="Button6" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckInputDate();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnRoiNgayDiLam_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button7" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdRoiNgayDiLam}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Hidden ID="hdfIDKeHoachTuyenDung" runat="server">
        </ext:Hidden>
        <ext:Store runat="server" ID="cbx_diadiemlamviec_Store" AutoLoad="false">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx">
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
        <ext:Window runat="server" ID="wdForwardToHOSO" Modal="true" Width="350" Padding="6"
            Layout="FormLayout" Hidden="true" Title="Chuyển tiếp qua Hồ sơ nhân sự" Icon="User"
            Constrain="true" AutoHeight="true" LabelWidth="115">
            <Content>
                <ext:TextField runat="server" ID="txtMaCB" FieldLabel="Mã cán bộ<span style='color:red;'>*</span>"
                    AnchorHorizontal="98%" CtCls="requiredData" MaxLength="20" />
                <ext:DateField runat="server" ID="dfNgayThuViec" EnableKeyEvents="true" CtCls="requiredData"
                    Editable="true" FieldLabel="Ngày thử việc<span style='color:red;'>*</span>" AnchorHorizontal="98%"
                    MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                    RegexText="Định dạng ngày không đúng" Vtype="daterange">
                </ext:DateField>
                <ext:Hidden runat="server" ID="hdfDonViKyHopDong" />
                <ext:ComboBox runat="server" ID="cbx_DonViKyHopDong" FieldLabel="Đơn vị ký hợp đồng" DisplayField="TEN"
                    ValueField="MA" AnchorHorizontal="98%" Editable="false" ItemSelector="div.list-item" MinChars="1" PageSize="15" ListWidth="250"
                    StoreID="cbx_httuyen_Store">
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
                    <Listeners>
                        <Focus Handler="cbx_httuyen_Store.reload();" />
                        <Select Handler="this.triggers[0].show();hdfDonViKyHopDong.setValue(this.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfDonViKyHopDong.reset(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Hidden runat="server" ID="hdfDiaDiemLamViec" />
                <ext:ComboBox runat="server" ID="cbxDiaDiemLamViec" FieldLabel="Địa điểm làm việc"
                    DisplayField="TEN" ValueField="MA" AnchorHorizontal="98%" ItemSelector="div.list-item" MinChars="1" PageSize="15" ListWidth="250"
                    StoreID="cbx_diadiemlamviec_Store">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
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
                        <Select Handler="this.triggers[0].show(); hdfDiaDiemLamViec.setValue(this.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfDiaDiemLamViec.reset();}" />
                    </Listeners>
                </ext:ComboBox>
            </Content>
            <Buttons>
                <ext:Button runat="server" ID="btnForward" Text="Chuyển tiếp" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckInputForwardToHOSO();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnForward_Click">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancel" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdForwardToHOSO.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="Ext.net.DirectMethods.GenderMaCB();" />
                <Hide Handler="txtMaCB.reset(); dfNgayThuViec.reset(); 
                    hdfDonViKyHopDong.reset(); cbx_DonViKyHopDong.reset(); 
                    hdfDiaDiemLamViec.reset(); cbxDiaDiemLamViec.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Title="Chuyển ứng viên" Resizable="false" Icon="Group"
            Hidden="true" Constrain="true" Padding="6" ID="wdChuyenLyDo" Width="450" Modal="true"
            Layout="FormLayout" AutoHeight="true">
            <Items>
                <ext:Hidden runat="server" ID="hdfType">
                </ext:Hidden>
                <ext:Hidden runat="server" ID="hdfChuyen_LyDo">
                </ext:Hidden>
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
                        <Expand Handler="#{cbx_Chuyen_LyDo_Store}.reload();" />
                        <Select Handler="this.triggers[0].show(); #{hdfChuyen_LyDo}.setValue(#{cbx_Chuyen_LyDo}.getValue()); " />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfChuyen_LyDo}.reset();}" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextArea runat="server" ID="txt_Chuyen_GhiChu" FieldLabel="Ghi chú" AnchorHorizontal="98%"
                    MaxLength="500">
                </ext:TextArea>
            </Items>
            <Listeners>
                <Hide Handler="" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" ID="btnChuyenLyDo" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="if(cbx_Chuyen_LyDo.getValue()==''){alert('Bạn chưa chọn lý do');return false;}; #{wdChuyenLyDo}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChuyenTiep_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button2" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChuyenLyDo}.hide(); ResetwdChuyenLyDo();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <%--    <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo ứng viên trúng tuyển" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{pnReportPanel}.remove(0);addHomePage(#{pnReportPanel},'Homepage','../Report/BaoCao_Main.aspx?type=BaoCaoDanhSachUngVienTrungTuyen&id='+#{hdfIDKeHoachTuyenDung}.getValue(), 'Báo cáo ứng viên trúng tuyển');" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button9" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdTiepNhan" Title="Tiếp nhận" Modal="true" Padding="6"
            Layout="FormLayout" Hidden="true" Constrain="true" AutoHeight="true" Width="400"
            Icon="UserAdd">
            <Items>
                <ext:ComboBox runat="server" ID="cbLoaiHopDong" DisplayField="TEN_LOAI_HDONG" ValueField="MA_LOAI_HDONG"
                    Editable="false" AnchorHorizontal="98%" FieldLabel="Loại hợp đồng" SelectedIndex="0">
                    <Store>
                        <ext:Store runat="server" ID="cbLoaiHopDongStore" AutoLoad="true" OnRefreshData="HopDong_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="MA_LOAI_HDONG">
                                    <Fields>
                                        <ext:RecordField Name="MA_LOAI_HDONG" />
                                        <ext:RecordField Name="TEN_LOAI_HDONG" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý" ID="btnTiepNhan" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnTiepNhan_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                    <Listeners>
                        <Click Handler="if(#{cbLoaiHopDong}.getValue()==''){alert('Bạn chưa chọn loại hợp đồng');#{cbLoaiHopDong}.focus(); return false;} return true;" />
                    </Listeners>
                </ext:Button>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdTiepNhan}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if(#{cbLoaiHopDong}.store.getCount()==0){#{cbLoaiHopDongStore}.reload();}" />
                <Hide Handler="cbLoaiHopDong.reset();" />
            </Listeners>
        </ext:Window>--%>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StripeRows="true" Icon="ApplicationViewColumns"
                            TrackMouseOver="false" AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnTinhTrangDiLam" Disabled="true" runat="server" Text="Tình trạng đi làm"
                                            Icon="Tick">
                                            <Menu>
                                                <ext:Menu ID="mnuTinhTrangDiLam" runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="mnuTuChoiDiLam" Text="Từ chối đi làm" runat="server" Icon="UserCross">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuXacNhanDiLam_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <ExtraParams>
                                                                        <ext:Parameter Mode="Value" Name="XacNhan" Value="TuChoi">
                                                                        </ext:Parameter>
                                                                    </ExtraParams>
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn không?" Title="Xác nhận ứng viên từ chối đi làm" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuSanSangDiLam" Text="Sẵn sàng đi làm" runat="server" Icon="Accept">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuXacNhanDiLam_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <ExtraParams>
                                                                        <ext:Parameter Mode="Value" Name="XacNhan" Value="SanSang">
                                                                        </ext:Parameter>
                                                                    </ExtraParams>
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn không?" Title="Xác nhận ứng viên sẵn sàng đi làm" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnRoiNgayDiLam" Text="Rời ngày đi làm" Disabled="true" runat="server"
                                                            Icon="Clock">
                                                            <Listeners>
                                                                <Click Handler="#{wdRoiNgayDiLam}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="btnChuyenTiep" Text="Chuyển tiếp" Icon="ArrowBranch" runat="server"
                                            Disabled="true">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Chuyển vào kho dự trữ" Icon="DatabaseYellow" ID="mnu_ForwardToStore">
                                                            <Listeners>
                                                                <Click Handler="ResetwdChuyenLyDo(); #{wdChuyenLyDo}.setTitle('Chuyển ứng viên vào kho dự trữ');#{hdfType}.reset();#{hdfType}.setValue('store');#{wdChuyenLyDo}.show(); " />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Chuyển vào danh sách đen (Blacklist)" Icon="UserGray" ID="mnu_ForwardToBlackList">
                                                            <Listeners>
                                                                <Click Handler="ResetwdChuyenLyDo(); #{wdChuyenLyDo}.setTitle('Chuyển ứng viên vào danh sách đen');#{hdfType}.reset();#{hdfType}.setValue('black');#{wdChuyenLyDo}.show(); " />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Chuyển vào danh sách ứng tuyển" Icon="Group" ID="mnu_ForwardToEmpty">
                                                            <Listeners>
                                                                <Click Handler="#{hdfType}.reset();#{hdfType}.setValue('toList');" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="btnChuyenTiep_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn chuyển vào Danh sách ứng tuyển không!"
                                                                        Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Chuyển vào hồ sơ nhân sự" Icon="User" ID="mnu_ForwardToHOSO">
                                                            <Listeners>
                                                                <Click Handler="setValueWdForwardToHOSO();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button Text="Báo cáo" ID="btn_BaoCao" Disabled="false" runat="server" Icon="Printer"
                                            Hidden="true">
                                            <Listeners>
                                                <Click Handler="#{wdChonKeHoach}.show();" />
                                            </Listeners>
                                        </ext:Button>
                      <%--                  <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel"
                                            Hidden="false">
                                            <DirectEvents>
                                                <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>--%>
                                        <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="5">
                                            <Items>
                                                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Lọc theo đợt tuyển dụng"
                                                    DisplayField="TenKeHoach" ValueField="ID" LoadingText="Đang tìm kiếm..." AnchorHorizontal="100%"
                                                    PageSize="10" ItemSelector="div.search-item" MinChars="1" ID="cbx_dottuyendung" Width="150" ListWidth="250">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="cbx_dottuyendung_Store" runat="server" AutoLoad="true">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="Handlers/LocTheoDotTuyenDungHandler.ashx" />
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
                                                        <Expand Handler="#{cbx_dottuyendung_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{Store1}.reload();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{Store1}.reload(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container1" Layout="FormLayout" LabelWidth="35">
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
                                        <ext:Container runat="server" ID="Container2" Layout="FormLayout" LabelWidth="35">
                                            <Items>
                                                <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Năm" Width="55">
                                                    <Listeners>
                                                        <Spin Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:SpinnerField>
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
                                        <ext:TriggerField runat="server" Width="220" EnableKeyEvents="true" EmptyText="Nhập mã hoặc tên ứng viên.."
                                            ID="UngVienTrungTuyen_txtSearchKey">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="UVTTenterKeyPressHandler" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{Store1}.reload(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="Store1" GroupField="TenKeHoach" runat="server" ShowWarningOnFailure="true">
                                    <Listeners>
                                        <Load Handler="checkboxSelection.clearSelections();" />
                                    </Listeners>
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="Handlers/UngVienTrungTuyen.ashx" Json="true" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="searchKey" Value="UngVienTrungTuyen_txtSearchKey.getValue()"
                                            Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="gioiTinhHander" Value="hdfGioiTinh.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="vitriUngTuyenHanlder" Value="hdfViTriUngTuyen.getValue()" Mode="Raw">
                                        </ext:Parameter>
                                        <ext:Parameter Name="DotTuyenDung" Value="#{cbx_dottuyendung}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="month" Value="#{cbxMonth}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="year" Value="#{spnYear}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="0" Mode="Value">
                                        </ext:Parameter>
                                        <ext:Parameter Name="limit" Value="15" Mode="Value">
                                        </ext:Parameter>
                                    </AutoLoadParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaUngVien">
                                            <Fields>
                                                <ext:RecordField Name="MaUngVien" />
                                                <ext:RecordField Name="HoTen" />
                                                <ext:RecordField Name="GioiTinh" />
                                                <ext:RecordField Name="Email" />
                                                <ext:RecordField Name="NgaySinh" />
                                                <ext:RecordField Name="DiDong" />
                                                <ext:RecordField Name="MaViTriCongViec" />
                                                <ext:RecordField Name="XacNhanDiLam" />
                                                <ext:RecordField Name="Tuoi" />
                                                <ext:RecordField Name="MaNguonTuyenDung" />
                                                <ext:RecordField Name="MaDotTuyenDung" />
                                                <ext:RecordField Name="DIEM" />
                                                <ext:RecordField Name="TEN_CONGVIEC" />
                                                <ext:RecordField Name="TenKeHoach" />
                                                <ext:RecordField Name="GhiChu" />
                                                <ext:RecordField Name="NgayCoTheDiLam" DateFormat="dd/MM/yyyy" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                    <ext:Column ColumnID="MaUngVien" Locked="false" Header="Mã ứng viên" DataIndex="MaUngVien"
                                        Width="75" />
                                    <ext:Column ColumnID="HoTen" Locked="false" Header="Tên ứng viên" DataIndex="HoTen"
                                        Width="120" />
                                    <ext:Column ColumnID="GIOI_TINH" Header="Giới tính" DataIndex="GioiTinh" Width="60">
                                        <Renderer Fn="RenderGender" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NgaySinh" Header="Ngày sinh" Width="80" DataIndex="NgaySinh"
                                        Format="dd/MM/yyyy">
                                    </ext:DateColumn>
                                    <ext:Column ColumnID="DIEM" Header="Tổng điểm" DataIndex="DIEM" Width="80" Align="Right">
                                    </ext:Column>
                                    <ext:Column ColumnID="XacNhanDiLam" Header="Xác nhận đi làm" DataIndex="XacNhanDiLam"
                                        Width="100" Align="Center">
                                        <Renderer Fn="GetBooleanIcon" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NgayCoTheDiLam" Header="Ngày đi làm" DataIndex="NgayCoTheDiLam"
                                        Format="dd/MM/yyyy" Width="90" />
                                    <ext:TemplateColumn ColumnID="DI_DONG" Header="Thông tin liên hệ" Width="110" DataIndex="DI_DONG">
                                        <Template ID="Template2" runat="server">
                                            <Html>
                                                <p>{Email}</p>
                                                <p>{DiDong}</p>
                                            </Html>
                                        </Template>
                                    </ext:TemplateColumn>
                                    <ext:Column Width="200" ColumnID="TEN_CONGVIEC" Header="Vị trí ứng tuyển" DataIndex="TEN_CONGVIEC">
                                    </ext:Column>
                                    <ext:Column Width="197" ColumnID="TenKeHoach" Header="Đợt tuyển dụng" DataIndex="TenKeHoach">
                                    </ext:Column>
                                    <ext:Column Width="120" Header="Ghi chú" DataIndex="GhiChu" Hideable="true">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                </ext:GroupingView>
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="
                                                            #{hdfMaKeHoachTuyenDung}.setValue(#{checkboxSelection}.getSelected().data.MaDotTuyenDung);
                                                            #{btnRoiNgayDiLam}.enable();
                                                            #{hdfNgayDiLam}.setValue(#{checkboxSelection}.getSelected().data.NgayCoTheDiLam);
                                                            #{hdfMaUngVien}.setValue(#{checkboxSelection}.getSelected().data.MaUngVien);
                                                            #{btnChuyenTiep}.enable();
                                                            #{btnTinhTrangDiLam}.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="2" />
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
                            <LoadMask ShowMask="true" />
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
