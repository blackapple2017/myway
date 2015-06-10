<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BaoCaoKetQuaTuyenDung.aspx.cs"
    Inherits="Modules_TuyenDung_BaoCaoTuyenDung_BaoCaoKetQuaTuyenDung" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #pnlBieuDo
        {
            border-right: 1px solid #8DB2E3 !important;
        }
        #grp_ThongKe
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        #wdMoRong_IFrame
        {
            background: #fff !important;
        }
    </style>
    <script type="text/javascript">
        var ChonDotTuyenDung = function () {
            var id = cbxChonNam.getValue();
            var maDot = hdfMaDotDanhGia.getValue();
            switch (maDot) {
                case 'NguonUngVien':
                    document.getElementById('iframeChart').src = '../../../Modules/Home/chart/PieChart.aspx?type=NguonUngVien&MaDotTuyenDung=' + id;
                    hdfChartUrl.setValue('../../../Modules/Home/chart/PieChart.aspx?type=NguonUngVien&MaDotTuyenDung=' + id);
                    break;
                case 'TyLeTruot':
                    document.getElementById('iframeChart').src = '../../../Modules/Home/chart/PieChart.aspx?type=TyLeTruot&MaDotTuyenDung=' + id;
                    hdfChartUrl.setValue('../../../Modules/Home/chart/PieChart.aspx?type=TyLeTruot&MaDotTuyenDung=' + id);
                    break;
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMaDotDanhGia" />
        <ext:Window ID="wdMoRong" Layout="FormLayout" Icon="ChartBar" runat="server" Modal="true"
            Constrain="true" Title="Biểu đồ mở rộng" Maximized="true" Hidden="true">
            <Buttons>
                <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdMoRong}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Store ID="grp_ThongKe_Store" GroupField="TenPhong" AutoLoad="true"
            runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerTyLeUngVien.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={20}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaKHTD">
                    <Fields>
                        <ext:RecordField Name="MaKHTD" />
                        <ext:RecordField Name="TenKHTD" />
                        <ext:RecordField Name="TenPhong" />
                        <ext:RecordField Name="TenCongViec" />
                        <ext:RecordField Name="TyLeDatSoLoai" />
                        <ext:RecordField Name="TyLeTiepNhanThuViec" />
                        <ext:RecordField Name="TyLeTiepNhanChinhThuc" />
                        <ext:RecordField Name="TyLeNghiSauTuyenDung" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <West Split="true" Collapsible="true">
                        <ext:Panel ID="pnlBieuDo" runat="server" Collapsed="false" Width="360" Layout="FitLayout"
                            Border="false" Title="Biểu đồ" Icon="ChartBar">
                            <TopBar>
                                <ext:Toolbar ID="tbsBieuDo" runat="server">
                                    <Items>
                                        <ext:Button ID="btnChonLoaiBieuDo" runat="server" Icon="ChartPie" Text="Chọn loại biểu đồ">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="mnuNguonUngVien" runat="server" Icon="ChartPie" Text="Thống kê ứng viên theo nguồn">
                                                            <Listeners>
                                                                <Click Handler="hdfMaDotDanhGia.setValue('NguonUngVien'); document.getElementById('iframeChart').src = '../../../Modules/Home/chart/PieChart.aspx?type=NguonUngVien&MaDotTuyenDung=69';#{hdfChartUrl}.setValue('../../../Modules/Home/chart/PieChart.aspx?type=NguonUngVien&MaDotTuyenDung=69'); #{cbxChonNam}.show(); #{tbsChonDotTD}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTyLeTruot" runat="server" Icon="ChartPie" Text="Thống kê ứng viên theo đợt tuyển dụng">
                                                            <Listeners>
                                                                <Click Handler="hdfMaDotDanhGia.setValue('TyLeTruot'); document.getElementById('iframeChart').src = '../../../Modules/Home/chart/PieChart.aspx?type=TyLeTruot&MaDotTuyenDung=69';#{hdfChartUrl}.setValue('../../../Modules/Home/chart/PieChart.aspx?type=TyLeTruot&MaDotTuyenDung=69'); #{cbxChonNam}.show(); #{tbsChonDotTD}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <%--<ext:Button runat="server" ID="btnSetChartDefault" Text="Đặt làm biểu đồ mặc định"
                                            Icon="Tick">
                                            <DirectEvents>
                                                <Click OnEvent="btnSetChartDefault_Click">
                                                    <Confirmation Title="Thông báo" Message="Bạn có chắc chắn muốn đặt biểu đồ này làm mặc định ?"
                                                        ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>--%>
                                        <ext:Button runat="server" ID="btnFullScreen" Disabled="false" Icon="ArrowOut" Text="Mở rộng">
                                            <Listeners>
                                                <Click Handler="if (hdfChartUrl.getValue() != '') Ext.net.DirectMethods.showWindowMoRong();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="tbsChonDotTD" runat="server" />
                                        <ext:ComboBox runat="server" EmptyText="Chọn đợt tuyển dụng" Width="140" ID="cbxChonNam"
                                            Editable="false" ListWidth="200">
                                            <Items>
                                                <ext:ListItem Value="69" Text="Tuyển nhân viên chăm sóc khách hàng" />
                                                <ext:ListItem Value="70" Text="Tuyển nhân viên triển khai" />
                                                <ext:ListItem Value="71" Text="Tuyển lập trình viên ASP.NET" />
                                                <ext:ListItem Value="72" Text="Tuyển Tester gấp" />
                                            </Items>
                                            <SelectedItem Value="69" />
                                            <Listeners>
                                                <Select Handler="ChonDotTuyenDung();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Content>
                                <ext:Hidden runat="server" ID="hdfChartUrl" />
                                <ext:Label ID="lblIframe" runat="server" />
                            </Content>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grp_ThongKe" Border="false" runat="server" StoreID="grp_ThongKe_Store"
                            StripeRows="true" AutoExpandColumn="TenKHTD" TrackMouseOver="false" AnchorHorizontal="100%"
                            Title="Báo cáo thống kê tỷ lệ ứng viên">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button runat="server" ID="btnChonLoaiBaoCao" Text="Chọn loại báo cáo" Icon="Report">
                                            <Menu>
                                                <ext:Menu ID="Menu2" runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="MenuItem1" runat="server" Icon="UserAdd" Text="Báo cáo thống kê tỷ lệ ứng viên">
                                                            <Listeners>
                                                                <Click Handler="Ext.net.DirectMethods.ReloadStore(1);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem2" runat="server" Icon="UserAdd" Text="Báo cáo kết quả vòng thi phỏng vấn">
                                                            <Listeners>
                                                                <Click Handler="Ext.net.DirectMethods.ReloadStore(2);" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                                    <ext:Column ColumnID="MaKHTD" Header="Mã đợt" DataIndex="MaKHTD" Width="70" />
                                    <ext:Column ColumnID="TenKHTD" Width="150" Header="Tên kế hoạch tuyển dụng" DataIndex="TenKHTD" />
                                    <ext:Column ColumnID="TenPhong" Width="150" Header="Phòng ban" DataIndex="TenPhong" />
                                    <ext:Column ColumnID="TenCongViec" Width="150" Header="Công việc" DataIndex="TenCongViec" />
                                    <ext:Column ColumnID="TyLeDatSoLoai" Header="Tỷ lệ qua sơ loại/Tổng số ứng viên dự tuyển"
                                        DataIndex="TyLeDatSoLoai" Width="100" Align="Right" />
                                    <ext:Column ColumnID="TyLeTiepNhanThuViec" Width="100" Header="Tỷ lệ nhận thử việc/Tổng số ứng viên dự tuyển"
                                        DataIndex="TyLeTiepNhanThuViec" Align="Right" />
                                    <ext:Column ColumnID="TyLeTiepNhanChinhThuc" Width="100" Header="Tỷ lệ nhận chính thức/Tổng số ứng viên dự tuyển"
                                        DataIndex="TyLeTiepNhanChinhThuc" Align="Right" />
                                    <ext:Column ColumnID="TyLeNghiSauTuyenDung" Width="100" Header="Tỷ lệ nghỉ sau tuyển dụng/Tổng số ứng viên dự tuyển"
                                        DataIndex="TyLeNghiSauTuyenDung" Align="Right" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
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
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                            </Items>
                                            <SelectedItem Value="15" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
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
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
