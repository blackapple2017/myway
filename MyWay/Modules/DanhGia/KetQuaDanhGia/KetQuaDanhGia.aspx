<%@ Page Language="C#" AutoEventWireup="true" CodeFile="KetQuaDanhGia.aspx.cs" Inherits="Modules_DanhGia_KetQuaDanhGia" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        #Panel1
        {
            border-right: 1px solid #8DB2E3 !important;
        }
        #pnReportPanel .x-tab-panel-header
        {
            display: none !important;
        }
        #grp_TongKetDanhGia
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/DanhSachDotDanhGia.png) no-repeat center !important;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                grp_TongKetDanhGia.getSelectionModel().clearSelections();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
        }

        var GetBooleanIcon = function (value, p, record) {
            var sImageCheck = "<img  src='../../../Resource/Images/check.png'>";
            var sImageUnCheck = "<img src='../../../Resource/Images/uncheck.gif'>";
            if (value.toString() == 'true') {
                return sImageCheck;
            } else if (value.toString() == 'false') {
                return sImageUnCheck;
            }
            return "";
        }

        var RenderDiem = function (value, p, record) {
            if (value == null || value == '0')
                return '';
            return value;
        }

        var RenderTongDiem = function (value, p, record) {
            return "<span style='color:red'><b>" + value + "</b></span>";
        }

        var ShowReportAction = function () {
            var type = hdfTypeReport.getValue();
            switch (type) {
                case 'BaoCaoTheoPhongBan':
                    wdShowReport.setTitle('Báo cáo kết quả đánh giá theo phòng ban');
                    pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../../Report/BaoCao_Main.aspx?type=BaoCaoKetQuaDanhGiaTheoPhongBan&ddg=' + hdfMaDotDanhGia.getValue(),
                                                                'Báo cáo kết quả đánh giá theo phòng ban');
                    break;
                case 'BaoCaoTheoNhanVien':
                    wdShowReport.setTitle('Báo cáo kết quả đánh giá của nhân viên');
                    //                    pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../../Report/BaoCao_Main.aspx?type=BaoCaoKetQuaDanhGiaTheoNhanVien&mcb=' + hdfRecordID.getValue() + '&ddg=' + hdfMaDotDanhGia.getValue(), 'Báo cáo kết quả đánh giá của nhân viên');
                    pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../../Report/BaoCao_Main.aspx?type=DanhGiaHoanThanhCongViec&macb=' + hdfRecordID.getValue() + '&ddg=' + hdfMaDotDanhGia.getValue() + '&uid=' + hdfUserID.getValue(), 'Báo cáo kết quả đánh giá của nhân viên');
                    break;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMaDotDanhGia" />
        <ext:Hidden runat="server" ID="hdfTuDanhGia" />
        <ext:Hidden runat="server" ID="hdfQuanLyDanhGia" />
        <ext:Hidden runat="server" ID="hdfNguoiKhacDanhGia" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Window ID="wdChonNguoiQuanLy" Layout="FormLayout" Icon="Printer" runat="server"
            Padding="6" Modal="true" Constrain="true" Title="Báo cáo" Width="400" AutoHeight="true"
            Hidden="true" Resizable="false" LabelAlign="Top">
            <Items>
                <ext:ComboBox runat="server" ID="cbxNguoiQLDanhGia" FieldLabel="Chọn cán bộ quản lý"
                    DisplayField="DisplayName" ValueField="ID" AnchorHorizontal="100%" Editable="false">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Store>
                        <ext:Store runat="server" ID="cbxNguoiQLDanhGiaStore" AutoLoad="False" OnRefreshData="cbxNguoiQLDanhGia_Store_OnRefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="DisplayName" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Listeners>
                        <Expand Handler="cbxNguoiQLDanhGia.store.reload();" />
                        <Select Handler="this.triggers[0].show(); hdfUserID.setValue(cbxNguoiQLDanhGia.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();}" />
                    </Listeners>
                </ext:ComboBox>
            </Items>
            <Buttons>
                <ext:Button ID="btnDongYBaoCao" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="hdfTypeReport.setValue('BaoCaoTheoNhanVien'); wdShowReport.show();wdChonNguoiQuanLy.hide();" />
                    </Listeners>
                </ext:Button>
                <ext:Button Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChonNguoiQuanLy.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="cbxNguoiQLDanhGia.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grp_ChiTietKetQuaDanhGia_Store" AutoLoad="false" runat="server" GroupField="HO_TEN"
            IgnoreExtraFields="false">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerChiTietKetQuaDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={20}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDotDanhGia" Value="hdfMaDotDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaCB" Value="hdfRecordID.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="cbxTenNguoiDanhGia.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaNhom">
                    <Fields>
                        <ext:RecordField Name="MaNhom" />
                        <ext:RecordField Name="TenNhom" />
                        <ext:RecordField Name="Diem" />
                        <ext:RecordField Name="HeSo" />
                        <ext:RecordField Name="IsQuanLyDanhGia" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TenCB" />
                        <ext:RecordField Name="NhanXet" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window ID="wdChiTiet" Layout="FormLayout" Icon="ChartBar" runat="server" Modal="true"
            Constrain="true" Title="Kết quả đánh giá chi tiết" Width="800" Height="500" Hidden="true"
            Resizable="false">
            <Items>
                <ext:BorderLayout runat="server" ID="brdlayout">
                    <Center>
                        <ext:GridPanel ID="grp_ChiTietKetQuaDanhGia" Border="false" runat="server" StoreID="grp_ChiTietKetQuaDanhGia_Store"
                            StripeRows="true" AutoExpandColumn="TenNhom" AutoExpandMin="200" TrackMouseOver="false"
                            AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="Toolbar1">
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbxTenNguoiDanhGia" FieldLabel="Người đánh giá"
                                            DisplayField="TenMaCB" ValueField="TenCB" Width="270" TabIndex="6" Editable="false"
                                            LabelWidth="80">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Store>
                                                <ext:Store runat="server" ID="cbxTenNguoiDanhGia_Store" AutoLoad="False" OnRefreshData="cbxTenNguoiDanhGia_Store_OnRefreshData">
                                                    <Reader>
                                                        <ext:JsonReader IDProperty="TenCB">
                                                            <Fields>
                                                                <ext:RecordField Name="TenCB" />
                                                                <ext:RecordField Name="TenMaCB" />
                                                            </Fields>
                                                        </ext:JsonReader>
                                                    </Reader>
                                                </ext:Store>
                                            </Store>
                                            <Listeners>
                                                <Expand Handler="cbxTenNguoiDanhGia_Store.reload();" />
                                                <Select Handler="this.triggers[0].show(); grp_ChiTietKetQuaDanhGia_Store.reload();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); grp_ChiTietKetQuaDanhGia_Store.reload();}" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Width="30" Header="STT" Groupable="false" />
                                    <ext:Column ColumnID="MaNhom" Width="70" Header="Mã tiêu chí" DataIndex="MaNhom"
                                        Groupable="false" />
                                    <ext:Column ColumnID="TenNhom" Width="200" Header="Tên tiêu chí" DataIndex="TenNhom"
                                        Groupable="false" />
                                    <%--<ext:RatingColumn ColumnID="Diem" Width="90" Header="Điểm" DataIndex="Diem" Editable="false"
                                        Groupable="false" />--%>
                                    <ext:Column ColumnID="DiemBangSo" Width="90" Align="Right" Header="Điểm" DataIndex="Diem"
                                        Groupable="false" />
                                    <ext:Column ColumnID="HeSo" Align="Right" Width="60" Header="Hệ số" DataIndex="HeSo"
                                        Groupable="false" />
                                    <ext:Column ColumnID="IsQuanLyDanhGia" Align="Center" Width="110" Header="Người QL đánh giá"
                                        DataIndex="IsQuanLyDanhGia" Groupable="false">
                                        <Renderer Fn="GetBooleanIcon" />
                                    </ext:Column>
                                    <ext:GroupingSummaryColumn ColumnID="HO_TEN" Width="90" Header="Cán bộ đánh giá"
                                        Sortable="true" DataIndex="HO_TEN" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                </Columns>
                            </ColumnModel>
                            <Plugins>
                                <ext:RowExpander runat="server" ID="RowExpander1">
                                    <Template ID="Template2" runat="server">
                                        <Html>
                                            <table border="0" cellpadding="10" cellspacing="5">
                                                <tr>
                                                    <td>
                                                        <b>Nhận xét</b> 
                                                    </td>
                                                    <td><tpl if="NhanXet &gt; ''">{NhanXet}</tpl></td>
                                                </tr>
                                            </table>
                                        </Html>
                                    </Template>
                                </ext:RowExpander>
                            </Plugins>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection1">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection1.getSelected().id);" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar3" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" Value="15" />
                                                <ext:ListItem Text="20" Value="20" />
                                                <ext:ListItem Text="25" Value="25" />
                                                <ext:ListItem Text="30" Value="30" />
                                            </Items>
                                            <SelectedItem Value="20" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar3}.pageSize = parseInt(this.getValue()); #{PagingToolbar3}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChiTiet}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="Ext.net.DirectMethods.SetTitleWindowsDetail(); grp_ChiTietKetQuaDanhGia_Store.reload();" />
                <Hide Handler="cbxTenNguoiDanhGia.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo đánh giá" Maximized="true" Icon="Printer">
            <Items>
                <ext:Hidden runat="server" ID="hdfTypeReport" />
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="ShowReportAction();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Store ID="grp_TongKetDanhGia_Store" GroupField="TenXepLoai" AutoLoad="false"
            runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerKetQuaDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDotDanhGia" Value="hdfMaDotDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="TuDanhGia" Value="hdfTuDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="QuanLyDanhGia" Value="hdfQuanLyDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="NguoiKhacDanhGia" Value="hdfNguoiKhacDanhGia.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaCB">
                    <Fields>
                        <ext:RecordField Name="MaCB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_DONVI" />
                        <ext:RecordField Name="TEN_CHUCVU" />
                        <ext:RecordField Name="DiemTuDanhGia" />
                        <ext:RecordField Name="NguoiKhacDanhGia" />
                        <ext:RecordField Name="DiemNguoiQLDanhGia" />
                        <%--<ext:RecordField Name="CreatedDate" />--%>
                        <ext:RecordField Name="TongDiem" />
                        <ext:RecordField Name="TrangThaiDanhGia" />
                        <ext:RecordField Name="TenXepLoai" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store ID="grp_DotDanhGia_Store" AutoLoad="true" runat="server" IgnoreExtraFields="false">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerKetQuaDanhGia_DotDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="TenDotDanhGia" />
                        <ext:RecordField Name="TuNgay" />
                        <ext:RecordField Name="DenNgay" />
                        <ext:RecordField Name="TrangThaiDanhGia" />
                        <ext:RecordField Name="GhiChu" />
                        <ext:RecordField Name="CreatedBy" />
                        <ext:RecordField Name="CreatedDate" />
                        <ext:RecordField Name="HinhThucDanhGia" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="Panel1" runat="server" Collapsed="false" Width="300" Border="false"
                            Layout="BorderLayout" Title="Danh sách đợt đánh giá">
                            <Items>
                                <ext:GridPanel ID="grp_DotDanhGia" Border="false" runat="server" AutoExpandColumn="TenDotDanhGia"
                                    AutoExpandMin="150" StripeRows="true" TrackMouseOver="false" Region="Center"
                                    Height="450" StoreID="grp_DotDanhGia_Store">
                                    <%--<TopBar>
                                        <ext:Toolbar runat="server" ID="tbw">
                                            <Items>
                                                <ext:Button runat="server" ID="btnReportDepartment" Icon="Printer" Text="Báo cáo">
                                                    <Listeners>
                                                        <Click Handler="if (hdfMaDotDanhGia.getValue() == '') {alert('Bạn chưa chọn đợt đánh giá nào!'); return false;}
                                                            hdfTypeReport.setValue('BaoCaoTheoPhongBan'); wdShowReport.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>--%>
                                    <ColumnModel ID="ColumnModel9" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" />
                                            <ext:Column ColumnID="TenDotDanhGia" Header="Tên đợt đánh giá" DataIndex="TenDotDanhGia" />
                                        </Columns>
                                    </ColumnModel>
                                    <Plugins>
                                        <ext:RowExpander runat="server" ID="rx">
                                            <Template ID="Template1" runat="server">
                                                <Html>
                                                    <table border="0" cellpadding="10" cellspacing="5">
                                                        <tr>
                                                            <td>
                                                                <b>Từ ngày</b> 
                                                            </td>
                                                            <td><tpl if="TuNgay &gt; ''">{TuNgay:date("d/m/Y")}</tpl></td>
                                                        </tr>
                                                        <tr>
                                                            <td><b>Đến ngày</b></td>
                                                            <td><tpl if="DenNgay &gt; ''">{DenNgay:date("d/m/Y")}</tpl></td>
                                                        </tr>
                                                        <tr>
                                                            <td><b>Trạng thái</b></td>
                                                            <td><tpl if="TrangThaiDanhGia &gt; ''">{TrangThaiDanhGia}</tpl></td>
                                                        </tr>
                                                        <tr>
                                                            <td><b>Hình thức</b></td>
                                                            <td>
                                                                <tpl if="HinhThucDanhGia == 0">Đánh giá cả công ty</tpl>
                                                                <tpl if="HinhThucDanhGia == 1">Đánh giá trong phòng</tpl>
                                                                <tpl if="HinhThucDanhGia == 2">Chỉ định đánh giá</tpl>
                                                            </td>
                                                        </tr>
                                                        <tr>
                                                            <td><b>Ngày tạo</b></td>
                                                            <td><tpl if="CreatedDate &gt; ''">{CreatedDate:date("d/m/Y")}</tpl></td>
                                                        </tr>
                                                    </table>
                                                </Html>
                                            </Template>
                                        </ext:RowExpander>
                                    </Plugins>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                            PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                            DisplayMsg="{0} đến {1} / {2}" runat="server">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="checkSelection" SingleSelect="true">
                                            <DirectEvents>
                                                <RowSelect OnEvent="DotDanhGia_Click" Before="hdfMaDotDanhGia.setValue(checkSelection.getSelected().id);">
                                                    <EventMask ShowMask="true" />
                                                </RowSelect>
                                            </DirectEvents>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <View>
                                        <ext:GridView ID="GridView1" runat="server" ForceFit="true" />
                                    </View>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grp_TongKetDanhGia" Border="false" runat="server" StoreID="grp_TongKetDanhGia_Store"
                            StripeRows="true" AutoExpandColumn="TEN_DONVI" AutoExpandMin="120" TrackMouseOver="false"
                            AnchorHorizontal="100%" Title="Danh sách cán bộ trong các đợt đánh giá">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <%--<ext:Button runat="server" ID="btnChiTiet" Text="Chi tiết" Icon="ChartBar">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn cán bộ nào!'); return false;} wdChiTiet.show(); return true;" />
                                            </Listeners>
                                        </ext:Button>--%>
                                        <%--<ext:Button runat="server" ID="btnBaoCao" Text="Báo cáo" Icon="Printer">
                                            <Listeners>
                                                <Click Handler="if (hdfRecordID.getValue() == '') {alert('Bạn chưa chọn nhân viên nào!'); return false;}
                                                        wdChonNguoiQuanLy.show();" />
                                            </Listeners>
                                        </ext:Button>--%>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
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
                                    <ext:RowNumbererColumn Width="30" Header="STT" />
                                    <ext:Column ColumnID="MaCB" Width="60" Header="Mã cán bộ" DataIndex="MaCB" />
                                    <ext:Column ColumnID="HO_TEN" Width="120" Header="Họ tên" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="TEN_DONVI" Width="120" Header="Phòng ban" DataIndex="TEN_DONVI" />
                                    <ext:Column ColumnID="TEN_CHUCVU" Width="90" Header="Chức vụ" DataIndex="TEN_CHUCVU" />
                                    <ext:Column ColumnID="DiemTuDanhGia" Align="Right" Width="110" Header="Điểm tự đánh giá"
                                        DataIndex="DiemTuDanhGia">
                                        <Renderer Fn="RenderDiem" />
                                    </ext:Column>
                                    <ext:Column ColumnID="NguoiKhacDanhGia" Align="Right" Width="150" Header="Điểm người khác đánh giá"
                                        DataIndex="NguoiKhacDanhGia">
                                        <Renderer Fn="RenderDiem" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DiemNguoiQLDanhGia" Align="Right" Width="130" Header="Điểm quản lý đánh giá"
                                        DataIndex="DiemNguoiQLDanhGia">
                                        <Renderer Fn="RenderDiem" />
                                    </ext:Column>
                                    <ext:Column ColumnID="TongDiem" Width="90" Align="Right" Header="Trung bình" DataIndex="TongDiem">
                                        <Renderer Fn="RenderTongDiem" />
                                    </ext:Column>
                                    <ext:GroupingSummaryColumn ColumnID="TenXepLoai" Width="150" Header="TenXepLoai"
                                        Sortable="true" DataIndex="TenXepLoai" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                    <%--<ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayDanhGia" Header="Ngày đánh giá"
                                        DataIndex="NgayDanhGia" Width="85" />--%>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:GroupingView ID="GroupingView2" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                            </Items>
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <Listeners>
                                <RowDblClick Handler="wdChiTiet.show();" />
                            </Listeners>
                            <%--<DirectEvents>
                                <DblClick OnEvent="">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </DblClick>
                            </DirectEvents>--%>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
