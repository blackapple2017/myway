<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TongHopCongTheoThang.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_TongHopCongTheoThang" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        div#grpTongHopCong .x-grid3-cell-inner, .x-grid3-hd-inner
        {
            white-space: nowrap !important;
        }
        #pnlCoCauToChuc-xsplit
        {
            border-right: none !important;
        }
        #pnlCoCauToChuc .x-panel-body
        {
            background-color: White !important;
        }
        #grpTongHopCong
        {
            border-left: 1px solid #98C0F4 !important;
        }
        .colored
        {
            background-color: #E8E8E8;
        }
        #wdShowReport .x-tab-panel-header
        {
            display: none !important;
        }
        #tb .x-form-item
        {
            margin-bottom: 0 !important;
        }
    </style>
    <script type="text/javascript" src="Resource/TongHopCongTheoThang.js"></script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <div id="sqlQuery" style="display: none;">
        </div>
        <div id="maCBChange" style="display: none;">
        </div>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfIdBangTongHopCong" />
        <%--Chứa mã bảng tổng hợp công đang được chọn--%>
        <ext:Hidden runat="server" ID="hdfTmpID" />
        <ext:Hidden runat="server" ID="hdfIsLocked" />
        <ext:Hidden runat="server" ID="hdfAction" Text="Insert" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="cmenuThemCanBo" runat="server" Icon="UserAdd" Text="Thêm cán bộ">
                    <Listeners>
                        <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="cmenuLoaiBoCanBo" Icon="UserDelete" Text="Loại bỏ cán bộ">
                    <Listeners>
                        <Click Handler="if (CheckSelectedRow(#{grpTongHopCong}) == false) {return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="mnuXoaNhanVien_Click">
                            <EventMask ShowMask="true" />
                            <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa cán bộ khỏi bảng tổng hợp công?"
                                ConfirmRequest="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <%--<ext:MenuItem runat="server" ID="cmenuXemChiTiet" Icon="Zoom" Text="Thông tin chi tiết">
                </ext:MenuItem>--%>
            </Items>
        </ext:Menu>
        <ext:Window runat="server" ID="wdImportExcelFile" Constrain="true" Modal="true" Title="Nhập tệp tin chấm công"
            Padding="6" Icon="PageExcel" AutoHeight="true" Layout="FormLayout" Hidden="true"
            Width="450">
            <%--<TopBar>
                <ext:Toolbar runat="server" ID="tbExcel">
                    <Items>
                        <ext:Button runat="server" ID="btnViewConfig" Text="Xem thông tin cấu hình" Icon="Zoom">
                            <Listeners>
                                <Click Handler="#{wdConfig}.show();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>--%>
            <Items>
                <ext:FileUploadField runat="server" ID="fUpload" SelectOnFocus="true" Regex="^.*\.xls$"
                    InvalidText="Tệp tin được chọn phải là Excel 2003" AnchorHorizontal="100%" FieldLabel="Chọn tệp tin">
                    <Listeners>
                        <FileSelected Handler="#{cbSheetNameStore}.reload();#{cbSheetName}.enable();" />
                    </Listeners>
                </ext:FileUploadField>
                <ext:ComboBox ID="cbSheetName" Disabled="true" FieldLabel="Chọn sheet" SelectedIndex="0"
                    Editable="false" AnchorHorizontal="100%" runat="server" DisplayField="SheetName"
                    ValueField="SheetName" SelectOnFocus="true">
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
                <ext:Checkbox runat="server" ID="chkXoa" BoxLabel="Xóa dữ liệu cũ" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnImport" Text="Nhập dữ liệu" Icon="PageExcel">
                    <Listeners>
                        <Click Handler="if (#{fUpload}.getValue() == '') {alert('Bạn chưa chọn tệp tin đính kèm'); return false;}
                            if (#{cbSheetName}.getValue() == '' || cbSheetName.getValue() == null) {alert('Bạn chưa chọn sheet'); return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnImport_Click">
                            <EventMask ShowMask="true" Msg="Đang nhập dữ liệu. Vui lòng chờ..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLai" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdImportExcelFile.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{fUpload}.reset(); #{cbSheetName}.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" ID="wdTaoBangTongHopCong" Constrain="true"
            Title="Tạo bảng tổng hợp công theo tháng" Icon="PageAdd" Width="450" AutoHeight="true">
            <Items>
                <ext:FormPanel ID="Panel1" Layout="FormLayout" runat="server" Border="false" Padding="6"
                    AutoHeight="true">
                    <Items>
                        <ext:Container ID="Container1" Layout="FormLayout" LabelAlign="Top" runat="server">
                            <Items>
                                <ext:Container ID="Containerm" Height="57" runat="server" Layout="ColumnLayout">
                                    <Items>
                                        <ext:NumberField FieldLabel="Chọn năm<span style='color:red;'>*</span>" ID="txtYear"
                                            AllowBlank="false" AllowDecimals="false" AllowNegative="false" BlankText="Bạn phải nhập năm"
                                            runat="server" ColumnWidth="0.45">
                                            <Listeners>
                                                <Blur Handler="ChangeTitle();" />
                                            </Listeners>
                                        </ext:NumberField>
                                        <ext:ComboBox runat="server" ID="cbMonth" SelectedIndex="0" ColumnWidth="0.5" Editable="false"
                                            FieldLabel="Chọn tháng<span style='color:red;'>*</span>">
                                            <Items>
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
                                                <Select Handler="ChangeTitle();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:TextField ID="txtTenBangChamCong" BlankText="Bạn bắt buộc phải nhập tên bảng tổng hợp công"
                                    Note="Tiêu đề bảng tổng hợp công được sinh tự động, hoặc bạn có thể thay đổi tùy ý"
                                    Text="" AllowBlank="false" AnchorHorizontal="100%" ColumnWidth="1.0" FieldLabel="Tiêu đề bảng tổng hợp công<span style='color:red;'>*</span>"
                                    runat="server" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="txtYear.setValue(new Date().getFullYear()); cbMonth.setValue(new Date().getMonth()+1); if (hdfAction.getValue() == 'Insert') {ChangeTitle();}" />
                <Hide Handler="txtYear.reset(); cbMonth.reset(); txtTenBangChamCong.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="btnTaoBangChamCong" runat="server" Icon="Accept" Text="Đồng ý">
                    <Listeners>
                        <Click Handler="if(txtYear.getValue()==''){alert('Bạn chưa nhập năm sử dụng bảng tổng hợp công');txtYear.focus();return false;}
                                        if(txtTenBangChamCong.getValue()==''){alert('Bạn chưa nhập tiêu đề bảng tổng hợp công');txtTenBangChamCong.focus();return false;}
                                       " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnTaoBangChamCong_Click">
                            <EventMask ShowMask="true" Msg="Đang tạo bảng chấm công..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhat" Icon="Disk" Text="Cập nhật">
                    <DirectEvents>
                        <Click OnEvent="btnTaoBangChamCong_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button5" runat="server" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="#{wdTaoBangTongHopCong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" Constrain="true" runat="server" ID="wdChonBangTongHopCong"
            Resizable="false" Title="Chọn bảng tổng hợp công theo tháng" Layout="FormLayout"
            Icon="DateAdd" Width="650" Padding="6" Height="400">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:Panel ID="Panel3" Border="false" Layout="BorderLayout" runat="server">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbChonBangChamCong">
                                    <Items>
                                        <%--<ext:Button runat="server" ID="btnThemMoi" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{wdTaoBangTongHopCong}.show();" />
                                            </Listeners>
                                        </ext:Button>--%>
                                        <ext:Button runat="server" ID="btnSua" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="if (CheckSelectedRows(#{grp_danhSachBangTongHopCong}) == false) {return false;} btnTaoBangChamCong.hide();hdfAction.setValue('Edit');btnCapNhat.show();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnSua_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnXoa" Text="Xóa" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnXoa_Click">
                                                    <EventMask ShowMask="true" Msg="Đang xóa dữ liệu. Vui lòng chờ..." />
                                                    <Confirmation Title="Xác nhận" Message="Khi xóa bảng tổng hợp công các dữ liệu liên quan cũng sẽ bị xóa. Bạn có chắc chắn muốn xóa?"
                                                        ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:ComboBox runat="server" Width="160" ID="cbChonThang" SelectedIndex="0" FieldLabel="Chọn tháng"
                                            Editable="false" LabelWidth="60">
                                            <Items>
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
                                                <Select Handler="grp_danhSachBangTongHopCongStore.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                        <ext:DisplayField ID="DisplayField1" runat="server" Text="Chọn năm">
                                        </ext:DisplayField>
                                        <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                        <ext:SpinnerField ID="txtCurrentYear" runat="server" Width="60" MaxLength="4" MinLength="4">
                                            <Listeners>
                                                <Spin Handler="grp_danhSachBangTongHopCongStore.reload();" />
                                            </Listeners>
                                        </ext:SpinnerField>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Items>
                                <ext:GridPanel ID="grp_danhSachBangTongHopCong" runat="server" Region="Center" StripeRows="true"
                                    Width="600" Border="false" Height="290" AutoExpandColumn="Title" AutoExpandMin="200">
                                    <Store>
                                        <ext:Store ID="grp_danhSachBangTongHopCongStore" runat="server" AutoLoad="false"
                                            OnRefreshData="grp_danhSachBangTongHopCongStore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenDonVi" />
                                                        <ext:RecordField Name="Title" />
                                                        <ext:RecordField Name="Thang" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel4" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="35" />
                                            <ext:Column ColumnID="Title" Header="Tiêu đề bảng tổng hợp công" Width="200" DataIndex="Title" />
                                            <ext:Column Header="Tháng chấm công" Width="100" DataIndex="Thang">
                                            </ext:Column>
                                            <ext:Column Header="Bộ phận" Width="250" DataIndex="TenDonVi">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel SingleSelect="true" ID="RowSelectionModelDanhSachBangTongHopCong"
                                            runat="server">
                                            <Listeners>
                                                <RowSelect Handler="hdfTmpID.setValue(RowSelectionModelDanhSachBangTongHopCong.getSelected().id);" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            <Listeners>
                <BeforeShow Handler="txtCurrentYear.setValue(new Date().getFullYear());cbChonThang.setValue(new Date().getMonth()+1);
                    grp_danhSachBangTongHopCongStore.reload();" />
            </Listeners>
            <Buttons>
                <ext:Button Text="Đồng ý" Icon="Accept" ID="btnDongYChon" runat="server">
                    <DirectEvents>
                        <Click OnEvent="btnDongYChon_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDongLai1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChonBangTongHopCong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <%--<ext:Window Modal="true" Hidden="true" Constrain="true" runat="server" ID="wdConfirm"
            Resizable="false" Title="Xác nhận" Layout="FormLayout" Icon="Information" Width="500"
            Padding="6" AutoHeight="true" LabelWidth="1">
            <Items>
                <ext:DisplayField runat="server" Text="Kết quả tổng hợp công đã tồn tại. Vui lòng chọn hành động:" />
                <ext:RadioGroup runat="server" ID="grp1" ColumnsNumber="1">
                    <Items>
                        <ext:Radio runat="server" ID="rdCapNhatLai" BoxLabel="Tính toán lại và ghi đè các kết quả tổng hợp công trước đó"
                            Checked="true">
                        </ext:Radio>
                        <ext:Radio runat="server" ID="rdBoQua" BoxLabel="Bỏ qua">
                        </ext:Radio>
                    </Items>
                </ext:RadioGroup>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYCapNhat" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnDongYCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Đang tổng hợp công. Vui lòng đợi" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDL1" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdConfirm.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>--%>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo hồ sơ nhân viên" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="wdShowReport.setTitle('Báo cáo tổng hợp công tháng');
                    pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../Report/BaoCao_Main.aspx?type=BaoCaoTongHopCongCuoiThang&IdBangTHC=' + hdfIdBangTongHopCong.getValue() + '&MaDonVi=' + hdfMaDonVi.getValue(), 'Báo cáo tổng hợp công tháng');" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Store ID="grpTongHopCongStore" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="Handler/HandlerTongHopCongTheoThang.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={25}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="Thang" Value="cbxMonth.getValue()" Mode="Raw" />
                <ext:Parameter Name="Nam" Value="spnYear.getValue()" Mode="Raw" />
                <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaBoPhan" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MA_CB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_DONVI" />
                        <ext:RecordField Name="NgayCongThucTe" />
                        <ext:RecordField Name="Gio130" />
                        <ext:RecordField Name="Gio150" />
                        <ext:RecordField Name="Gio195" />
                        <ext:RecordField Name="Gio200" />
                        <ext:RecordField Name="Gio260" />
                        <ext:RecordField Name="Gio300" />
                        <ext:RecordField Name="ComCa" />
                        <ext:RecordField Name="NghiBu" />
                        <ext:RecordField Name="NghiPhep" />
                        <ext:RecordField Name="NghiKhongLuong" />
                        <ext:RecordField Name="NghiCheDo" />
                        <ext:RecordField Name="Om" />
                        <ext:RecordField Name="NghiLe" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="grpTongHopCong" runat="server" Title="Bảng tổng hợp công" StripeRows="true"
                            Border="false" StoreID="grpTongHopCongStore" Icon="BookOpen" Header="false">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnChuanBiDuLieuDauVao" runat="server" Text="Nhập từ excel" Icon="PageExcel">
                                            <Listeners>
                                                <Click Handler="#{wdImportExcelFile}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnTongHopCong" runat="server" Text="Tổng hợp công" Icon="Sum">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="mnuLayCongLamThemGio" runat="server" Text="Lấy công làm thêm giờ" Icon="Sum">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuLayCongLamThemGio_Click">
                                                                    <EventMask ShowMask="true" Msg="Đang tính toán giờ làm thêm. Vui lòng đợi..." />
                                                                    <Confirmation Title="Xác nhận" Message="Số giờ làm thêm sẽ được tính toán lại. Bạn có chắc chắn muốn thực hiện?" ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTongHopTatCa" runat="server" Text="Tổng hợp tất cả" Icon="Sum">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuTongHopTatCa_Click">
                                                                    <EventMask ShowMask="true" Msg="Đang tổng hợp công. Vui lòng đợi..." />
                                                                    <Confirmation Title="Xác nhận" Message="Khi tổng hợp công, toàn bộ dữ liệu sẽ được tính toán lại. Bạn có chắc chắn muốn tổng hợp công không?" ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTongHopDuocChon" runat="server" Text="Tổng hợp đối với cán bộ được chọn"
                                                            Icon="Sum">
                                                            <Listeners>
                                                                <Click Handler="return CheckSelectedRow(grpTongHopCong);" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuTongHopDuocChon_Click">
                                                                    <EventMask ShowMask="true" Msg="Đang tổng hợp công. Vui lòng đợi..." />
                                                                    <Confirmation Title="Xác nhận" Message="Khi tổng hợp công, toàn bộ dữ liệu sẽ được tính toán lại. Bạn có chắc chắn muốn tổng hợp công không?" ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <%--<ext:Button ID="btnKhoaBangChamCong" runat="server" Text="Khóa bảng công" Icon="LockStop">
                                            <Listeners>
                                                <Click Handler="if (hdfIdBangTongHopCong.getValue() == '') {alert('Bạn chưa chọn bảng tổng hợp công nào'); return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnKhoaBangChamCong_Click">
                                                    <EventMask ShowMask="true" Msg="Đang khóa bảng công. Vui lòng đợi..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>--%>
                                        <%--<ext:Button ID="btnMoKhoaBangTongHopCong" runat="server" Text="Mở bảng công" Icon="LockOpen"
                                            Hidden="true">
                                            <Listeners>
                                                <Click Handler="if (hdfIdBangTongHopCong.getValue() == '') {alert('Bạn chưa chọn bảng tổng hợp công nào'); return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnMoKhoaBangTongHopCong_Click">
                                                    <EventMask ShowMask="true" Msg="Đang mở khóa bảng công. Vui lòng đợi..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>--%>
                                        <ext:Button runat="server" ID="btnCapNhatNgayPhep" Text="Cập nhật ngày phép" Icon="DateEdit"
                                            Hidden="true">
                                            <DirectEvents>
                                                <Click OnEvent="btnCapNhatNgayPhep_Click">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation Title="Xác nhận" Message="Phần mềm sẽ cập nhật lại số ngày phép còn lại. Bạn có chắc chắn muốn thực hiện?"
                                                        ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" ID="tbs" />
                                        <%--<ext:Button ID="Button1" runat="server" Text="In bảng công" Icon="Printer">
                                            <Listeners>
                                                <Click Handler="wdShowReport.show();" />
                                            </Listeners>
                                        </ext:Button>--%>
                                        <ext:Button ID="btnEditHangLoat" runat="server" Text="Quản lý nhân viên" Icon="User">
                                            <Menu>
                                                <ext:Menu runat="server" ID="mnuChucNangKhac">
                                                    <Items>
                                                        <%--<ext:MenuItem ID="mnuDieuChinhCong" runat="server" Text="Điều chỉnh công" Icon="Pencil">
                                                        </ext:MenuItem>--%>
                                                        <ext:MenuItem ID="mnuThemNhanVien" runat="server" Text="Thêm cán bộ" Icon="UserAdd">
                                                            <Listeners>
                                                                <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuXoaNhanVien" runat="server" Text="Loại bỏ cán bộ" Icon="UserDelete">
                                                            <Listeners>
                                                                <Click Handler="if (CheckSelectedRow(#{grpTongHopCong}) == false) {return false;}" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuXoaNhanVien_Click">
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa cán bộ khỏi bảng tổng hợp công?"
                                                                        ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="btnUpdate" Hidden="true" runat="server" Text="Cập nhật" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="btnUpdate.hide();btnEditHangLoat.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                        <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="65">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxMonth" Width="70" Editable="false" FieldLabel="Chọn tháng">
                                                    <Items>
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
                                                        <Select Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSpacer ID="ToolbarSpacer6" runat="server" Width="5" />
                                        <ext:Container runat="server" ID="Container2" Layout="FormLayout" LabelWidth="60">
                                            <Items>
                                                <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Chọn năm" Width="55">
                                                    <Listeners>
                                                        <Spin Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Button runat="server" ID="btnEditOnGrid" Hidden="true" />
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc tên cán bộ"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <KeyUp Handler="if (txtSearch.getValue() != '') this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{grpTongHopCongStore}.reload(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler=" PagingToolbar1.pageIndex = 0; #{grpTongHopCongStore}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                    <GetRowClass Fn="getRowClass" />
                                </ext:LockingGridView>
                            </View>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="MA_CB" Header="Mã cán bộ" Locked="true" Width="90" DataIndex="MA_CB" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Locked="true" Width="130" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="150" DataIndex="TEN_DONVI" />
                                    <ext:Column Width="90" Align="Right" Header="Số ngày công(Thực tế + Nghỉ lễ)" DataIndex="NgayCongThucTe">
                                        <%--<Renderer Fn="RenderGio" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField10" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="Nghỉ Lễ" DataIndex="NghiLe">
                                    </ext:Column> 
                                    <ext:Column Width="60" Align="Right" Header="130%" DataIndex="Gio130">
                                        <%--<Renderer Fn="RenderSoPhut" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField11" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="150%" DataIndex="Gio150">
                                        <%--<Renderer Fn="RenderSoLan" />--%>
                                        <%--<Editor>
                                            <ext:TextField runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="195%" DataIndex="Gio195">
                                        <%-- <Renderer Fn="RenderSoLan" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField1" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="200%" DataIndex="Gio200">
                                        <%--<Renderer Fn="RenderSoPhut" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField13" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="260%" DataIndex="Gio260">
                                        <%-- <Renderer Fn="RenderSoPhut" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField12" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="300%" DataIndex="Gio300">
                                        <%-- <Renderer Fn="RenderNumber" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField4" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="Cơm ca" DataIndex="ComCa">
                                        <%--<Renderer Fn="RenderNumber" />--%>
                                        <%-- <Editor>
                                            <ext:TextField ID="TextField5" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="60" Align="Right" Header="Nghỉ bù" DataIndex="NghiBu">
                                    </ext:Column>
                                    <ext:Column Width="90" Align="Right" Header="Ngày phép" DataIndex="NghiPhep">
                                        <%-- <Renderer Fn="RenderNumber" />--%>
                                        <%--<Editor>
                                            <ext:TextField ID="TextField6" runat="server" />
                                        </Editor>--%>
                                    </ext:Column>
                                    <ext:Column Width="110" Align="Right" Header="Nghỉ không lương" DataIndex="NghiKhongLuong">
                                    </ext:Column>
                                    <ext:Column Width="110" Align="Right" Header="Chế độ" DataIndex="NghiCheDo">
                                    </ext:Column>
                                    <ext:Column Width="110" Align="Right" Header="Nghỉ ốm" DataIndex="Om">
                                    </ext:Column> 
                                    <%--<ext:Column Width="70" Align="Right" Header="Con ốm" DataIndex="ConOm">
                                        <Renderer Fn="RenderNumber" />
                                        <Editor>
                                            <ext:TextField ID="TextField2" runat="server" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Thai sản" DataIndex="ThaiSan">
                                        <Renderer Fn="RenderNumber" />
                                        <Editor>
                                            <ext:TextField ID="TextField3" runat="server" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Ốm" DataIndex="Om">
                                        <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Tai nạn" DataIndex="TaiNan">
                                        <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Mất điện" DataIndex="MatDien">
                                        <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Học tập/Hội nghị" DataIndex="HocTapHoiNghi">
                                        <Renderer Fn="RenderNumber" />
                                    </ext:Column>--%>
                                    <%--<ext:Column Width="70" Align="Right" Header="Nghỉ vô tổ chức" DataIndex="NghiVoToChuc">
                                        <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="90" Align="Right" Header="Trừ giờ" DataIndex="ThoiGianRaNgoaiBiTru">
                                        <Renderer Fn="RenderSoPhut" />--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField19" runat="server" />
                                        </Editor>
                                    </ext:Column>--%>
                                    <%-- <ext:Column Width="100" Align="Right" Header="Tổng số ca làm ngày thường" DataIndex="TongCaLamViecNgayThuong">
                                        <Editor>
                                            <ext:TextField ID="TextField14" runat="server" />
                                        </Editor>
                                        <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="90" Align="Right" Header="Tổng số ca làm ngày lễ" DataIndex="TongCaLamViecNgayLe">--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField15" runat="server" />
                                        </Editor>--%>
                                    <%-- <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="90" Align="Right" Header="Tổng số ca làm ngày nghỉ" DataIndex="TongCaLamViecNgayNghi">--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField16" runat="server" />
                                        </Editor>--%>
                                    <%--<Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Tổng số ca nghỉ" DataIndex="TongCaNghi">--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField17" runat="server" />
                                        </Editor>--%>
                                    <%-- <Renderer Fn="RenderNumber" />
                                    </ext:Column>
                                    <ext:Column Width="120" Align="Right" Header="Thời gian làm thêm ngày thường" DataIndex="SoPhutLamThemNgayThuong">--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField2" runat="server" />
                                        </Editor>--%>
                                    <%-- <Renderer Fn="RenderSoPhut" />
                                    </ext:Column>
                                    <ext:Column Width="100" Align="Right" Header="Thời gian làm thêm ngày nghỉ" DataIndex="SoPhutLamThemNgayNghi">--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField3" runat="server" />
                                        </Editor>--%>
                                    <%--   <Renderer Fn="RenderSoPhut" />
                                    </ext:Column>
                                    <ext:Column Width="100" Align="Right" Header="Thời gian làm thêm ngày lễ" DataIndex="SoPhutLamThemNgayLe">--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField18" runat="server" />
                                        </Editor>--%>
                                    <%-- <Renderer Fn="RenderSoPhut" />
                                    </ext:Column>--%>
                                    <%-- <ext:Column Width="120" Align="Right" Header="Công thưởng" DataIndex="CongThuong">
                                    </ext:Column>
                                    <ext:Column Width="120" Align="Right" Header="Công quy đổi" DataIndex="CongQuyDoi">
                                    </ext:Column>
                                    <ext:Column Width="120" Align="Right" Header="Hệ số hoàn thành công việc" DataIndex="HeSoHoanThanhCongViec">
                                    </ext:Column>--%>
                                    <%-- <ext:Column Width="92" Align="Right" Header="Quên quẹt thẻ" DataIndex="SoLanQuenQuetThe">
                                        <Renderer Fn="RenderSoLan" />--%>
                                    <%--<Editor>
                                            <ext:TextField ID="TextField8" runat="server" />
                                        </Editor>--%>
                                    <%-- </ext:Column>--%>
                                    <%--<ext:Column Width="120" Align="Right" Header="Thời gian làm thừa" DataIndex="TongThoiGianLamThuaGio">
                                        <Renderer Fn="RenderSoPhut" />
                                    </ext:Column>--%>
                                    <%--<ext:Column Width="90" Align="Right" Header="Ngày công chuẩn" DataIndex="SoNgayCongChuan">
                                    </ext:Column>--%>
                                    <%-- <ext:Column Width="70" Align="Right" Header="Công hưởng lương cũ" DataIndex="SoNgayCongHuongLuongCu">
                                    </ext:Column>
                                    <ext:Column Width="70" Align="Right" Header="Công hưởng lương mới" DataIndex="SoNgayCongHuongLuongMoi">
                                    </ext:Column>--%>
                                    <%--<ext:Column Width="120" Align="Right" Header="Công hưởng lương" DataIndex="SoNgayCongHuongLuong">
                                        <Editor>
                                            <ext:TextField ID="TextField9" runat="server" />
                                        </Editor>
                                    </ext:Column>--%>
                                    <%--<ext:Column Width="90" Align="Right" Header="Số ca chuẩn" DataIndex="SoCaChuan">
                                    </ext:Column>
                                    <ext:Column Width="90" Align="Right" Header="Số ca thực tế" DataIndex="SoCaThucTe">
                                    </ext:Column>--%>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModelTongHopCong" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="40" />
                                            </Items>
                                            <SelectedItem Value="25" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:DisplayField runat="server" ID="dpfTrangThai" />
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <Listeners>
                                <AfterEdit Fn="afterEdit" />
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grpTongHopCong}.getSelectionModel().selectRow(rowIndex);" />
                            </Listeners>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
