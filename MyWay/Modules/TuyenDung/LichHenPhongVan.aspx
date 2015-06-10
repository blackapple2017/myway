<%@ Page Language="C#" AutoEventWireup="true" CodeFile="LichHenPhongVan.aspx.cs"
    Inherits="Modules_TuyenDung_LichHenPhongVan" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/DateTime/DateTime.ascx" TagName="DateTime" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="../../Resource/js/Validation.js" type="text/javascript"></script>
    <script src="Resource/LichHenPhongVan.js" type="text/javascript"></script>
    <link href="Resource/LichHenPhongVan.css" rel="stylesheet" type="text/css" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="RM" runat="server" />
        <ext:Hidden runat="server" ID="hdfIDLichHen" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaUngVien" />
        <ext:Hidden runat="server" ID="hdfMaMonThi" />
        <ext:Hidden runat="server" ID="hdfVongThi" />
        <ext:Hidden runat="server" ID="hdfVongPV" />
        <ext:Hidden runat="server" ID="hdfIDKetQuaThi" />
        <ext:Hidden runat="server" ID="hdfNhanXet" />
        <ext:Hidden runat="server" ID="hdfKetQua" />
        <ext:Hidden runat="server" ID="hdfNguoiCham" />
        <ext:Hidden runat="server" ID="hdfDiemSo" />
        <ext:Hidden runat="server" ID="hdfCreatedDate" />
        <ext:Hidden runat="server" ID="hdfKeHoachTuyenDung" />
        <ext:Hidden runat="server" ID="hdfDiemDat" />
        <ext:Hidden runat="server" ID="hdfTrangThaiLuaChon" />
        <%--<ext:Window Modal="true" Hidden="true" runat="server" EnableViewState="false" ID="wdKhongTheThamGia"
            Title="Báo cáo hồ sơ ứng viên" Maximized="false" Width="300" AutoHeight="true"
            Icon="Printer">
            <Items>
                <ext:DisplayField runat="server" Text="Ứng viên này không thể tham gia, bạn muốn thực hiện chức năng nào sau đây">
                </ext:DisplayField>
                <ext:Radio ID="Radio1" runat="server" Checked="true" FieldLabel="Đưa vào kho ứng viên">
                </ext:Radio>
                <ext:Radio ID="Radio2" runat="server" FieldLabel="Chuyển nhóm ứng viên">
                </ext:Radio>
                <ext:Radio runat="server" FieldLabel="Không làm gì cả">
                </ext:Radio>
                <ext:Checkbox runat="server" FieldLabel="" BoxLabel="Đánh dấu làm mặc định và không hiện hộp thoại này nữa">
                </ext:Checkbox>
            </Items>
            <Buttons>
                <ext:Button ID="Button9" runat="server" Text="Đồng ý" Icon="Accept">
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                </ext:Button>
            </Buttons>
        </ext:Window>--%>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" EnableViewState="false"
            ID="wdReportHoSoUngVien" Title="Báo cáo hồ sơ ứng viên" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="TabPanel1" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{TabPanel1}.remove(0);addHomePage(#{TabPanel1},'Homepage','../Report/BaoCao_Main.aspx?type=ReportHoSoUngVienFromLichHenPV&id='+#{hdfRecordID}.getValue(), 'Báo cáo hồ sơ ứng viên')" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button4" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdReportHoSoUngVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" ID="wdChamDiemNhanXet" Padding="6" Layout="FormLayout"
            Hidden="true" Constrain="true" Title="Chấm điểm/Nhận xét" Icon="Lorry" Modal="true"
            Width="550" AutoHeight="true">
            <Items>
                <ext:Container ID="Container24" runat="server" Height="55" Layout="ColumnLayout">
                    <Items>
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:NumberField runat="server" AllowNegative="false" AnchorHorizontal="98%" ID="txt_VongPhongVan"
                                    AllowDecimals="false" CtCls="requiredData" FieldLabel="Vòng phỏng vấn" MaxLength="4" >
                                </ext:NumberField>
                                <ext:ComboBox runat="server" AnchorHorizontal="98%" ID="cboMonThi" CtCls="requiredData" FieldLabel="Môn thi<span style='color:red;'>*</span>" Editable="false" DisplayField="TEN_MON_THI" ValueField="MA_MON_THI">
                                    <Store>
                                        <ext:Store runat="server" AutoLoad="true" ID="cboMonThi_store">
                                            <Proxy>
                                                <ext:HttpProxy Method="GET" Url="Handlers/ChamDiemNhanXetHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="planid" Value="#{hdfKeHoachTuyenDung}.getValue()" Mode="Raw" />
                                                <ext:Parameter Name="vong" Value="#{hdfVongPV}.getValue()" Mode="Raw" />
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
                                        <TriggerClick Handler="#{hdfDiemDat}.setValue(getDiemDat(MA_MON_THI,cboMonThi_store))"/>
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>                
                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:DateField runat="server" Editable="false" AnchorHorizontal="98%" FieldLabel="Ngày thi"
                                    ID="dfNgayThiTuyen" LabelWidth="50" />                        
                                <ext:NumberField runat="server" FieldLabel="Điểm số<span style='color:red;'>*</span>" CtCls="requiredData" ID="txtDiemSo" AnchorHorizontal="98%"
                                    LabelWidth="50" MaxLength="4"/>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" FieldLabel="Nhận xét" ID="txtNhanXet" AnchorHorizontal="99%"
                    MaxLength="500" />
                <ext:Hidden runat="server" ID="hdfNguoiChamThi" />
                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                    CtCls="requiredData" DisplayField="HO_TEN" ValueField="PR_KEY" LoadingText="Đang tìm kiếm..."
                    AnchorHorizontal="100%" PageSize="10" ItemSelector="div.search-item" MinChars="1" ID="cbb_NguoiChamThi" FieldLabel="Người chấm thi<span style='color:red;'>*</span>"
                    Width="300">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store ID="StoreChonNguoiChamThi" runat="server" AutoLoad="true">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="Handlers/ChonNguoiChamThiHandler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="Start" Value="={0}" />
                                <ext:Parameter Name="Limit" Value="={10}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="KeHoachTuyenDung" Value="#{hdfKeHoachTuyenDung}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="VongThi" Value="#{hdfVongPV}.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" TotalProperty="TotalRecords">
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
                        <Select Handler="#{hdfNguoiChamThi}.setValue(cbb_NguoiChamThi.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); } hdfNguoiChamThi.reset();" />
                        <Expand Handler="if(cbb_NguoiChamThi.store.getCount()==0){cbb_NguoiChamThi.store.reload();}" />
                    </Listeners>
                    <DirectEvents>
                        <Select OnEvent="CheckDaThoiViec">
                        </Select>
                    </DirectEvents>
                </ext:ComboBox>
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
                <ext:Button ID="btnChamDiem" runat="server" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler=" return CheckInputDiemPhongVan();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChamDiem_Click" After="ResetwdChamDiemNhanXet">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="btnDongNhanXet">
                    <Listeners>
                        <Click Handler="#{wdChamDiemNhanXet}.hide(); ResetwdChamDiemNhanXet();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetwdChamDiemNhanXet();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Layout="FormLayout" ID="wdChonDotTuyenDung" Hidden="true"
            EnableViewState="false" Modal="true" Constrain="true" Resizable="false" Width="400"
            AutoHeight="true" Title="Chọn đợt tuyển dụng" Padding="6">
            <Items>
                <ext:ComboBox AnchorHorizontal="100%" Editable="false" SelectedIndex="0" ID="cbDotTuyenDung"
                    runat="server" FieldLabel="Đợt tuyển dụng">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
            </Items>
            <Buttons>
                <ext:Button ID="btnAcceptDotTuyenDung" runat="server" Text="Đồng ý" Icon="Accept">
                    <%--<DirectEvents>
                        <Click OnEvent="btnAcceptDotTuyenDung_Click">
                            <EventMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        </Click>
                    </DirectEvents>--%>
                </ext:Button>
                <ext:Button ID="Button3" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChonDotTuyenDung}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" Title="Rời lịch phỏng vấn" Resizable="false" Icon="Clock" Hidden="true"
            Padding="6" ID="wdChuyenLichHenPV" Width="350" Modal="true" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="frmPanelChuyenLichHenPV">
                    <Items>
                        <ext:DateField runat="server" LabelWidth="110" ID="df_NgayPhongVan" AnchorHorizontal="98%" FieldLabel="Ngày phỏng vấn" 
                            Editable="false" TabIndex="40" Format="dd/mm/yyyy">
                        </ext:DateField>
                        <ext:TimeField ID="tf_GioPhongVan" runat="server" MinTime="9:00" MaxTime="18:00" Increment="30" SelectedTime="09:00:00" Format="H:mm:ss" FieldLabel="Giờ phỏng vấn" AnchorHorizontal="98%"></ext:TimeField>
                        <ext:NumberField runat="server" ID="txt_ThuTuPhongVan" FieldLabel="Thứ tự phỏng vấn" LabelWidth="100" Width="50" 
                            TabIndex="99" MaxLength="4" Regex="/[\d]+/" />  
                        <ext:TextArea runat="server" ID="txt_ghichu" FieldLabel="Ghi chú"
                            AnchorHorizontal="98%" TabIndex="38" Height="90" MaxLength="500">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btn_ChuyenLichHenPV" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler=" return KiemTraDuLieuLichHenPV(); #{wdChuyenLichHenPV}.hide();"   />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btn_ChuyenLichHenPV_Click" After="ResetwdChuyenLichHenPV">
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
        <ext:Window runat="server" ID="wdTiepNhan" Title="Chuyển tiếp" Modal="true" Padding="6"
            Layout="FormLayout" Hidden="true" Constrain="true" AutoHeight="true" Width="400"
            Icon="UserAdd">
            <Items>
                <ext:ComboBox runat="server" ID="cbNoiTiepNhan" Editable="false" AnchorHorizontal="100%"
                    FieldLabel="Nơi tiếp nhận" SelectedIndex="0">
                    <Items>
                        <ext:ListItem Text="Danh sách ứng viên trúng tuyển" Value="HoSoTrungTuyen" />
                        <ext:ListItem Text="Hồ sơ nhân sự" Value="HoSoNhanSu" />
                    </Items>
                    <Listeners>
                        <Select Handler="if(#{cbNoiTiepNhan}.getValue()=='HoSoNhanSu'){
                                            #{cbLoaiHopDong}.enable();
                                            if(#{cbLoaiHopDong}.store.getCount()==0){
                                                 #{cbLoaiHopDongStore}.reload();
                                            }
                                         }else
                                         {
                                            #{cbLoaiHopDong}.disable();
                                         }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox Disabled="true" runat="server" ID="cbLoaiHopDong" DisplayField="TEN_LOAI_HDONG"
                    ValueField="MA_LOAI_HDONG" Editable="false" AnchorHorizontal="100%" FieldLabel="Loại hợp đồng"
                    SelectedIndex="0">
                    <Store>
                        <ext:Store runat="server" ID="cbLoaiHopDongStore" AutoLoad="false">
                            <%--OnRefreshData="cbLoaiHopDongStore_OnRefreshData"--%>
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
                <ext:DateField runat="server" Editable="false" AnchorHorizontal="100%" FieldLabel="Ngày đi làm"
                    ID="dfNgayDiLam">
                </ext:DateField>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý" ID="btnTiepNhan" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckInputDate(dfNgayDiLam,'Bạn chưa nhập thông tin ngày đi làm')" />
                    </Listeners>
                    <%--<DirectEvents>
                        <Click OnEvent="btnChuyenTiep_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>--%>
                </ext:Button>
                <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdTiepNhan}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" ClicksToEdit="1" runat="server" StripeRows="true"
                            Selectable="true" Header="false" Width="600" Height="290" >
                            <TopBar>
                                <ext:Toolbar runat="server">
                                    <Items>
                                        <ext:Button ID="btnThoiGian" runat="server" Text="Rời lịch phỏng vấn" Icon="Clock" Disabled="true">
                                                <Listeners>
                                                    <Click Handler=" if( CheckSelectedRecordPrint(GridPanel1,Store1)){setValuewdChuyenLichHenPV();#{wdChuyenLichHenPV}.show();} " />
                                                </Listeners>                                      
                                        </ext:Button>                                        
                                        <ext:Button Icon="Delete" runat="server" Text="Xóa" ID="btnDelete" Disabled="true">
                                            <DirectEvents>
                                                <Click OnEvent="mnXoaLichHenPV_Click">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnPrint" runat="server" Icon="Printer" Text="In hồ sơ" Disabled="true">
                                            <Listeners>
                                                <Click Handler="if( CheckSelectedRecordPrint(GridPanel1,Store1)){#{wdReportHoSoUngVien}.show();} " />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" Icon="CommentAdd" Text="Chấm điểm/nhận xét" Disabled="true"
                                            ID="btnChamDiemNX">
                                            <Listeners>
                                               <Click Handler="ResetwdChamDiemNhanXet(); #{hdfTrangThaiLuaChon}.setValue('add'); #{wdChamDiemNhanXet}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" />
                                        <ext:TextField runat="server" Width="220" ID="txtSearch" EmptyText="Nhập mã hoặc họ tên ứng viên..."
                                            EnableKeyEvents="true">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                                            <Listeners>
                                                <Click Handler="#{hdfMaUngVien}.reset();#{Store1}.reload();#{KetQuaStore}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="Store1" runat="server" AutoLoad="True" GroupField="MA_DOT_TUYEN_DUNG">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="Handlers/LichHenPhongVanHandler.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="searchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID_LICH_HEN">
                                            <Fields>
                                                <ext:RecordField Name="MA_UNG_VIEN" />
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="TUOI" />
                                                <ext:RecordField Name="GIOI_TINH" />
                                                <ext:RecordField Name="DI_DONG" />
                                                <ext:RecordField Name="EMAIL" />
                                                <ext:RecordField Name="NOI_SINH" />
                                                <ext:RecordField Name="DIEM" />
                                                <ext:RecordField Name="DOT_TUYEN_DUNG" />
                                                <ext:RecordField Name="MA_DOT_TUYEN_DUNG" />
                                                <ext:RecordField Name="TEN_CONG_VIEC" />
                                                <ext:RecordField Name="DA_THAM_GIA" />
                                                <ext:RecordField Name="NGAY_HEN"/>
                                                <ext:RecordField Name="GIO_HEN" />
                                                <ext:RecordField Name="THU_TU_PV" />
                                                <ext:RecordField Name="VONG_PV" />
                                                <ext:RecordField Name="GHI_CHU" />
                                                <ext:RecordField Name="ID_LICH_HEN" />
                                                <ext:RecordField Name="MA_CONG_VIEC" />
                                                <ext:RecordField Name="NHAN_XET" />
                                                <ext:RecordField Name="DA_TRUNG_TUYEN" />
                                                <ext:RecordField Name="MA_NGUOI_CHAM" />
                                                <ext:RecordField Name="TEN_NGUOI_CHAM" />
                                                <ext:RecordField Name="MA_NGUOI_TAO" />
                                                <ext:RecordField Name="TEN_NGUOI_TAO" />
                                                <ext:RecordField Name="XAC_NHAN_THAM_GIA" />
                                                <ext:RecordField Name="NGAY_TAO" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" Locked="true"/>
                                    <ext:Column ColumnID="DOT_TUYEN_DUNG" Header="Đợt tuyển dụng" Width="230" DataIndex="DOT_TUYEN_DUNG" Locked="true" Sortable="true"></ext:Column>
                                    <ext:Column ColumnID="MA_UNG_VIEN" Header="Mã ứng viên" Width="80" DataIndex="MA_UNG_VIEN" Locked="true"/>
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="130" DataIndex="HO_TEN" Locked="true"/>
                                    <ext:Column ColumnID="GIOI_TINH" Header="Giới tính" Width="50" DataIndex="GIOI_TINH">
                                        <Renderer Fn="RenderGender" />
                                    </ext:Column>
                                    <ext:Column ColumnID="TUOI" Header="Tuổi" Width="50" DataIndex="TUOI" Align="Right"/>
                                    <ext:Column ColumnID="TEN_CONG_VIEC" Header="Vị trí tuyển dụng" Width="100" DataIndex="TEN_CONG_VIEC" />
                                    <ext:Column ColumnID="NGAY_HEN" Header="Ngày hẹn" Width="80" DataIndex="NGAY_HEN" Align="Right">
                                        <Renderer Fn="RenderDate" /> 
                                    </ext:Column>
                                    <ext:Column ColumnID="GIO_HEN" Header="Giờ hẹn" Width="80" DataIndex="GIO_HEN" Align="Right" />
                                    <ext:Column ColumnID="THU_TU_PV" Header="Thứ tự phỏng vấn" Width="110" DataIndex="THU_TU_PV" Align="Right">
                                        <Renderer Fn="RenderVND0" />
                                    </ext:Column>
                                    <ext:Column ColumnID="VONG_PV" Header="Vòng phỏng vấn" Width="110" DataIndex="VONG_PV" Align="Right"/>
                                    <ext:Column ColumnID="VONG_PV" Header="Đã tham gia" Width="80" DataIndex="VONG_PV" Align="Center">
                                        <Renderer Fn="GetBooleanIcon" />
                                    </ext:Column>
                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" Width="250" DataIndex="GHI_CHU" />                                    
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="
                                            #{hdfMaUngVien}.setValue(#{RowSelectionModel1}.getSelected().data.MA_UNG_VIEN);
                                            #{hdfRecordID}.setValue(#{RowSelectionModel1}.getSelected().id); 
                                            #{hdfVongPV}.setValue(#{RowSelectionModel1}.getSelected().data.VONG_PV);
                                            #{hdfKeHoachTuyenDung}.setValue(#{RowSelectionModel1}.getSelected().data.MA_DOT_TUYEN_DUNG);
                                            #{KetQuaStore}.reload();
                                            #{btnChamDiemNX}.enable(); 
                                            #{btnXoaKetQua}.disable();
                                            #{btnSuaKetQua}.disable();
                                            #{btnThoiGian}.enable();
                                            #{btnDelete}.enable(); 
                                            #{btnPrint}.enable();
                                            "/>
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <Listeners>
                                <RowDblClick Handler="setValuewdChuyenLichHenPV();#{wdChuyenLichHenPV}.show(); " />
                            </Listeners>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <View>
                                <ext:LockingGridView ID="GroupingView1" runat="server" ShowGroupName="false">

                                </ext:LockingGridView>
                            </View>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>                                                
                                                <ext:ListItem Text="1" />
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="40" />
                                                <ext:ListItem Text="50" />
                                            </Items>
                                            <SelectedItem Value="10" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Center>
                    <South Collapsible="false" Split="false">
                        <ext:TabPanel runat="server" Height="200" Border="false">
                            <Items>
                                <ext:Panel ID="Panel1" runat="server" Layout="BorderLayout" Collapsed="false" CtCls="south-panel"
                                    Border="false" Title="Kết quả phỏng vấn" Height="180">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button runat="server" Icon="Delete" Text="Xóa" ID="btnXoaKetQua" Disabled="true">
                                                    <DirectEvents>
                                                        <Click OnEvent="btnXoaKetQua_Click">
                                                            <EventMask ShowMask="true" />
                                                            <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button runat="server" Icon="Pencil" Text="Sửa" ID="btnSuaKetQua" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="#{hdfTrangThaiLuaChon}.setValue('edit'); setValuewdChamDiemNhanXet();#{wdChamDiemNhanXet}.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Items>
                                        <ext:GridPanel ID="GridPanel2" Border="false" Region="Center" ClicksToEdit="1" runat="server"
                                            StripeRows="true" Header="false" Width="600" Height="290" AutoExpandColumn="NHAN_XET">
                                            <Store>
                                                <ext:Store runat="server" ID="KetQuaStore" AutoLoad="true" ShowWarningOnFailure="true">
                                                    <Proxy>
                                                        <ext:HttpProxy Method="GET" Url="Handlers/KetQuaThiTuyenHandler.ashx" />
                                                    </Proxy>
                                                    <BaseParams>
                                                        <ext:Parameter Name="maUngVien" Value="#{hdfMaUngVien}.getValue()" Mode="Raw" />
                                                        <ext:Parameter Name="maVongPV" Value="#{hdfVongPV}.getValue()" Mode="Raw" />
                                                    </BaseParams>
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="ID" TotalProperty="TotalRecords" Root="Data">
                                                            <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="MA_UNG_VIEN" />
                                                                    <ext:RecordField Name="VONG_THI" />
                                                                    <ext:RecordField Name="VONG_PV" />
                                                                    <ext:RecordField Name="NGAY_THI" />
                                                                    <ext:RecordField Name="MA_MON_THI" />
                                                                    <ext:RecordField Name="TEN_MON_THI" />
                                                                    <ext:RecordField Name="DIEM" />
                                                                    <ext:RecordField Name="DIEM_DAT" />
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
                                                        <ext:Column ColumnID="VONG_THI" Header="Vòng thi" Width="70" DataIndex="VONG_THI" Align="Right"/>
                                                        <ext:DateColumn ColumnID="NGAY_THI" Header="Ngày thi tuyển" Width="110" DataIndex="NGAY_THI" Align="Right">
                                                            <Renderer Fn="RenderDate" />    
                                                        </ext:DateColumn>
                                                        <ext:Column ColumnID="TEN_MON_THI" Header="Môn thi" Width="75" DataIndex="TEN_MON_THI">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="DIEM" Header="Điểm" Width="75" DataIndex="DIEM" Align="Right">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="DIEM_DAT" Header="Điểm đạt" Width="75" DataIndex="DIEM_DAT" Align="Right">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="NGUOI_CHAM" Header="Người chấm" Width="110" DataIndex="NGUOI_CHAM">
                                                        </ext:Column>
                                                        <ext:Column ColumnID="KET_QUA" Header="Kết quả" Width="75" DataIndex="KET_QUA" Align="Center">
                                                            <Renderer Fn="GetBooleanIcon" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="NHAN_XET" Header="Nhận xét" Width="175" DataIndex="NHAN_XET">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                                    <Listeners>
                                                        <RowSelect Handler="#{btnSuaKetQua}.enable();#{btnXoaKetQua}.enable();
                                               #{hdfMaMonThi}.setValue(#{RowSelectionModel2}.getSelected().data.MA_MON_THI);  
                                                 #{hdfVongThi}.setValue(#{RowSelectionModel2}.getSelected().data.VONG_THI);
                                                   #{hdfIDKetQuaThi}.setValue(#{RowSelectionModel2}.getSelected().id); 
                                                   #{hdfNguoiCham}.setValue(#{RowSelectionModel2}.getSelected().data.NGUOI_CHAM); 
                                                     #{hdfDiemSo}.setValue(#{RowSelectionModel2}.getSelected().data.DIEM);
                                                     #{hdfKetQua}.setValue(#{RowSelectionModel2}.getSelected().data.KET_QUA);
                                                       #{hdfNhanXet}.setValue(#{RowSelectionModel2}.getSelected().data.NHAN_XET);
                                                       #{hdfCreatedDate}.setValue(#{RowSelectionModel2}.getSelected().data.NGAY_TAO);
                                                  
                                                     " />
                                                    </Listeners>                                                  
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                            <Listeners>
                                                <RowDblClick Handler="#{hdfTrangThaiLuaChon}.setValue('edit'); setValuewdChamDiemNhanXet();#{wdChamDiemNhanXet}.show();"/>
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
