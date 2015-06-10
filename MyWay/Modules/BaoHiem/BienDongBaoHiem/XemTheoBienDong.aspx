<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemTheoBienDong.aspx.cs"
    Inherits="Modules_BaoHiem_XemTheoBienDong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="~/Modules/BaoHiem/UC_BHNHANVIEN_BAOHIEM/BHNHANVIEN_BAOHIEM.ascx"
    TagPrefix="uc1" TagName="BHNHANVIEN_BAOHIEM" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">

        var RenderSoNam = function (value, p, record) {

            if (value == null || value == "") {
                return "0" + " tháng";
            }
            var nam = parseInt(value / 12);
            var sothang = value % 12;
            if (nam == 0) {
                value = sothang + " tháng";
            }
            else {
                value = nam + " năm " + sothang + " tháng";
            }
            return value;
        }
        var keyEnterPress = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                //                grpBienDongTheoThangStore.reload();
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var keyEnterspinNam = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                grpBienDongTheoThangStore.reload();
            }
        }
    </script>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" ID="RM" />
    <uc1:BHNHANVIEN_BAOHIEM runat="server" ID="BHNHANVIEN_BAOHIEM" />
    <ext:Hidden runat="server" ID="hdfMaDonVi">
    </ext:Hidden>
    <ext:Store ID="grpBienDongTheoThangStore" AutoLoad="true" runat="server" GroupField="Thang"
        GroupDir="DESC">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="HandlerBienDongTheoThang.ashx" />
        </Proxy>
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={15}" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
            <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            <ext:Parameter Name="Thang" Value="#{cbbThang}.getValue()" Mode="Raw" />
            <ext:Parameter Name="Nam" Value="#{spinNam}.getValue()" Mode="Raw" />
        </BaseParams>
        <Reader>
            <ext:JsonReader Root="Data" TotalProperty="TotalRecords">
                <Fields>
                    <ext:RecordField Name="IDBienDongBaoHiem" />
                    <ext:RecordField Name="IDQuyDinhBienDong" />
                    <ext:RecordField Name="IDNhanVien_BaoHiem" />
                    <ext:RecordField Name="MaCanBo" />
                    <ext:RecordField Name="HoTen" />
                    <ext:RecordField Name="PhongBan" />
                    <ext:RecordField Name="TenBienDong" />
                    <ext:RecordField Name="Loai" />
                    <ext:RecordField Name="TuNgay" />
                    <ext:RecordField Name="DenNgay" />
                    <ext:RecordField Name="SoNgay" />
                    <ext:RecordField Name="TienLuongCu" />
                    <ext:RecordField Name="TongPhuCapCu" />
                    <ext:RecordField Name="TienLuongMoi" />
                    <ext:RecordField Name="TongPhuCapMoi" />
                    <ext:RecordField Name="KhongTraThe" />
                    <ext:RecordField Name="DaCoSo" />
                    <ext:RecordField Name="DienGiai" />
                    <ext:RecordField Name="Thang" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:Viewport runat="server" ID="vp">
        <Items>
            <ext:BorderLayout runat="server" ID="BorderLayout1">
                <Center>
                    <ext:Panel ID="Panel1" runat="server" AnchorHorizontal="99%" AnchorVertical="99%"
                        Border="false">
                        <Items>
                            <ext:RowLayout ID="RowLayout2" runat="server" Split="false" AnchorHorizontal="99%"
                                AnchorVertical="99%">
                                <Rows>
                                    <ext:LayoutRow runat="server" RowHeight="0.65">
                                        <Items>
                                            <ext:Panel ID="Panel4" runat="server" AnchorHorizontal="99%" AnchorVertical="99%"
                                                Layout="BorderLayout" Border="false">
                                                <Items>
                                                    <ext:GridPanel runat="server" ID="grpBienDongTheoThang" Border="false" AnchorHorizontal="99%"
                                                        AnchorVertical="99%" StripeRows="true" TrackMouseOver="False" Region="Center"
                                                        AutoScroll="true" StoreID="grpBienDongTheoThangStore">
                                                        <TopBar>
                                                            <ext:Toolbar ID="Toolbar1" runat="server">
                                                                <Items>
                                                                    <ext:ComboBox runat="server" FieldLabel="Chọn tháng" EmptyText="Chọn tháng" LabelWidth="60"
                                                                        Editable="false" ID="cbbThang" Width="150">
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
                                                                            <Select Handler="if(spinNam.getValue()>0) {#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();}" />
                                                                        </Listeners>
                                                                        <%--  <DirectEvents>
                                                            <Select OnEvent="cbxThang_Selected" />
                                                        </DirectEvents>--%>
                                                                    </ext:ComboBox>
                                                                    <ext:ToolbarSeparator ID="tbsNam" runat="server" />
                                                                    <ext:Container ID="Container1" runat="server" Layout="MenuLayout" Width="110">
                                                                        <Items>
                                                                            <ext:SpinnerField ID="spinNam" runat="server" FieldLabel="Chọn năm" Width="110" LabelWidth="55"
                                                                                MinValue="1900" MaxValue="2100">
                                                                                <Listeners>
                                                                                    <Spin Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                                                    <KeyPress Fn="keyEnterspinNam" />
                                                                                </Listeners>
                                                                            </ext:SpinnerField>
                                                                        </Items>
                                                                    </ext:Container>
                                                                    <ext:ToolbarFill ID="ToolbarFill2" runat="server" />
                                                                    <ext:TriggerField runat="server" Width="180" EnableKeyEvents="true" ID="txtSearchKey"
                                                                        EmptyText="Tìm kiếm theo mã, tên nhân viên">
                                                                        <Triggers>
                                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        </Triggers>
                                                                        <Listeners>
                                                                            <KeyPress Fn="keyEnterPress" />
                                                                            <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                                        </Listeners>
                                                                    </ext:TriggerField>
                                                                    <ext:Button ID="Button9" runat="server" Text="<%$ Resources:Language, search%>" Icon="Zoom">
                                                                        <Listeners>
                                                                            <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                                        </Listeners>
                                                                    </ext:Button>
                                                                </Items>
                                                            </ext:Toolbar>
                                                        </TopBar>
                                                        <ColumnModel ID="ColumnModel4" runat="server">
                                                            <Columns>
                                                                <ext:RowNumbererColumn Header="STT" Width="30" Align="Left">
                                                                </ext:RowNumbererColumn>
                                                                <ext:Column ColumnID="colMaNhanVien" Width="100" DataIndex="MaCanBo" Header="<%$ Resources:HOSO, staff_code%>">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTenCanBo" Width="150" DataIndex="HoTen" Header="<%$ Resources:HOSO, staff_name%>">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colPhongBan" Width="150" DataIndex="PhongBan" Header="<%$ Resources:HOSO, staff_section%>">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTenBienDong" Width="150" DataIndex="TenBienDong" Header="Tên biến động">
                                                                </ext:Column>
                                                                <ext:DateColumn Format="dd/MM/yyyy" ColumnID="colTuNgay" Width="100" DataIndex="TuNgay"
                                                                    Header="Từ ngày" />
                                                                <ext:DateColumn Format="dd/MM/yyyy" ColumnID="colDenNgay" Width="100" DataIndex="DenNgay"
                                                                    Header="Đến ngày" />
                                                                <ext:Column ColumnID="colSoNgay" Width="70" DataIndex="SoNgay" Header="Số ngày" Align="Right" />
                                                                <ext:Column ColumnID="colTienLuongCu" Width="100" DataIndex="TienLuongCu" Header="Tiền lương cũ"
                                                                    Align="Right">
                                                                    <Renderer Fn="RenderVND" />
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTongPhuCapCu" Width="105" DataIndex="TongPhuCapCu" Header="Tổng phụ cấp cũ"
                                                                    Align="Right">
                                                                    <Renderer Fn="RenderVND" />
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTienLuongMoi" Width="100" DataIndex="TienLuongMoi" Header="Tiền lương mới"
                                                                    Align="Right">
                                                                    <Renderer Fn="RenderVND" />
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTongPhuCapMoi" Width="112" DataIndex="TongPhuCapMoi" Header="Tổng phụ cấp mới"
                                                                    Align="Right">
                                                                    <Renderer Fn="RenderVND" />
                                                                </ext:Column>
                                                                <ext:CheckColumn ColumnID="colKhongTraThe" Width="73" DataIndex="KhongTraThe" Header="Không trả thẻ">
                                                                </ext:CheckColumn>
                                                                <ext:CheckColumn ColumnID="colDaCoSo" Width="70" DataIndex="DaCoSo" Header="Đã có sổ">
                                                                </ext:CheckColumn>
                                                                <ext:Column ColumnID="colDienGiai" Width="100" DataIndex="DienGiai" Header="Diễn giải">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colThang" Width="100" DataIndex="Thang" Header="Tháng">
                                                                </ext:Column>
                                                            </Columns>
                                                        </ColumnModel>
                                                        <View>
                                                            <ext:GroupingView ID="GroupingView2" runat="server" ForceFit="false" MarkDirty="false"
                                                                ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                                            </ext:GroupingView>
                                                        </View>
                                                        <BottomBar>
                                                            <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                                                                PageSize="15" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                                                                DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                                                                <Items>
                                                                    <ext:Label ID="Label4" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                                                    <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                                                    <ext:ComboBox ID="ComboBox6" runat="server" Width="80">
                                                                        <Items>
                                                                            <ext:ListItem Text="15" />
                                                                            <ext:ListItem Text="30" />
                                                                            <ext:ListItem Text="50" />
                                                                            <ext:ListItem Text="70" />
                                                                            <ext:ListItem Text="100" />
                                                                            <ext:ListItem Text="200" />
                                                                            <ext:ListItem Text="500" />
                                                                            <ext:ListItem Text="1000" />
                                                                            <ext:ListItem Text="2000" />
                                                                        </Items>
                                                                        <SelectedItem Value="15" />
                                                                        <Listeners>
                                                                            <Select Handler=" #{PagingToolbar1}.pageSize = parseInt(this.getValue());#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                                        </Listeners>
                                                                    </ext:ComboBox>
                                                                </Items>
                                                            </ext:PagingToolbar>
                                                        </BottomBar>
                                                        <SelectionModel>
                                                            <ext:RowSelectionModel runat="server" ID="RowSelectionModel3">
                                                                <Listeners>
                                                                    <%-- <RowSelect Handler="#{Button1}.enable(); #{Button2}.disable();#{Button5}.disable(); #{hdfMaNhanVien}.setValue(#{RowSelectionModel2}.getSelected().id);grpChiTietNhanVienStore.reload();" />--%>
                                                                    <%--<RowSelect Handler="#{hdfNhomCha}.setValue(#{RowSelectionModel1}.getSelected().id);" />--%>
                                                                </Listeners>
                                                            </ext:RowSelectionModel>
                                                        </SelectionModel>
                                                        <LoadMask ShowMask="true" />
                                                    </ext:GridPanel>
                                                </Items>
                                            </ext:Panel>
                                        </Items>
                                    </ext:LayoutRow>
                                </Rows>
                            </ext:RowLayout>
                        </Items>
                    </ext:Panel>
                </Center>
                <%--  <South>
                    </South>--%>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
