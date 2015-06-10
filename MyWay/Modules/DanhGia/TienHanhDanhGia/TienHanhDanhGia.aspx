<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TienHanhDanhGia.aspx.cs"
    Inherits="Modules_DanhGia_TienHanhDanhGia_TienHanhDanhGia" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #Panel1
        {
            border-right: 1px solid #8DB2E3 !important;
        }
        #grp_TieuChiDanhGia
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        .x-layout-collapsed-west
        {
            background: url(../../../Resource/images/Danhsachcanbo.png) no-repeat center !important;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                grp_TieuChiDanhGia.getSelectionModel().clearSelections();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
        }
        var GetRenderPhanTram = function (value, p, record) {
            var rs = value + ' %';
            if (value * 1 < 100)
                rs = '<span style="color: red;">' + rs + '</span>';
            return rs;
        }
        var RendererTenTieuChi = function (value, p, record) {
            var rs = value.replace('_b_', '<b>');
            rs = rs.replace('_bb_', '</b>');
            rs = rs.replace('_br_', '<br>');
            return rs;
        }
        var GetNameHinhThuc = function (value, p, record) {
            if (value == '0') {
                return 'Đánh giá cả đơn vị';
            }
            else if (value == '1') {
                return 'Đánh giá trong phòng';
            }
            else if (value == '2') {
                return 'Chỉ định cán bộ đánh giá';
            }
        }

        //        var RenderDiem = function (value, p, record) {
        //            if (value != 0)
        //                return parseFloat(value).toFixed(2);
        //            return 0;
        //        }
        var CheckSelectedRow = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn bản ghi nào!');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfMaCanBo" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMaDotDanhGia" />
        <ext:Hidden runat="server" ID="hdfChonDotDanhGia" />
        <ext:Hidden runat="server" ID="hdfNhanXet" />
        <ext:Hidden runat="server" ID="hdfUser" />
        <ext:Hidden runat="server" ID="hdfIsNguoiQL" />
        <ext:Hidden runat="server" ID="hdfIsTuDanhGia" />
        <ext:Hidden runat="server" ID="hdfMaBoPhan" />
        <ext:Hidden runat="server" ID="hdfCreatedBy" />
        <ext:Hidden runat="server" ID="hdfIsChangedDG" />
        <ext:Window runat="server" Resizable="false" Hidden="true" Height="400" Layout="FormLayout"
            Width="700" Modal="true" Padding="6" Constrain="true" ID="wdChonDotDanhGia" Title="Chọn đợt đánh giá"
            Icon="Add">
            <Items>
                <ext:BorderLayout ID="BorderLayout1" runat="server">
                    <Center>
                        <ext:GridPanel ID="grp_ChonDotDanhGia" Border="false" runat="server" StripeRows="true"
                            AutoExpandColumn="TenDotDanhGia" AutoExpandMin="150" TrackMouseOver="false" AnchorHorizontal="100%"
                            Title="Danh sách các đợt đánh giá">
                            <Store>
                                <ext:Store ID="grp_ChonDotDanhGia_Store" AutoLoad="false" runat="server">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="HandlerChonDotDanhGia.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={10}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="MaCanBo" Value="hdfUser.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="IsNguoiQuanLy" Value="hdfIsNguoiQL.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="IsTuDanhGia" Value="hdfIsTuDanhGia.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="CurrentID" Value="hdfCreatedBy.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="TenDotDanhGia" />
                                                <ext:RecordField Name="CreatedDate" />
                                                <ext:RecordField Name="HinhThucDanhGia" />
                                                <ext:RecordField Name="TrangThaiDanhGia" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel4" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                    <ext:Column ColumnID="ID" Width="70" Header="Mã đợt" DataIndex="ID" />
                                    <ext:Column ColumnID="TenDotDanhGia" Width="150" Header="Tên đợt đánh giá" DataIndex="TenDotDanhGia" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Width="70" Header="Ngày tạo"
                                        DataIndex="CreatedDate" />
                                    <ext:Column ColumnID="HinhThucDanhGia" Width="110" Header="Hình thức đánh giá" DataIndex="HinhThucDanhGia">
                                        <Renderer Fn="GetNameHinhThuc" />
                                    </ext:Column>
                                    <ext:Column ColumnID="TrangThaiDanhGia" Width="100" Header="Trạng thái" DataIndex="TrangThaiDanhGia" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel runat="server" ID="checkboxSelectionChonDotDanhGia" SingleSelect="true">
                                    <Listeners>
                                        <RowSelect Handler="hdfMaDotDanhGia.setValue(checkboxSelectionChonDotDanhGia.getSelected().id);" />
                                    </Listeners>
                                </ext:CheckboxSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar3" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="10" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label2" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="5" />
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                            </Items>
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
                <ext:Button runat="server" ID="btnOK" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="
                            if (CheckSelectedRow(#{grp_ChonDotDanhGia}) == false)
                            {
                                return;
                            }
                            if (hdfMaDotDanhGia.getValue() != '')
                            {
                                Ext.net.DirectMethods.SetTitle();
                                grp_CanBoBiDanhGia.getSelectionModel().clearSelections();
                                hdfMaCanBo.reset();
                                grp_CanBoBiDanhGia_Store.reload();
                                grp_TieuChiDanhGia_Store.reload();
                                wdChonDotDanhGia.hide();
                            }" />
                    </Listeners>
                </ext:Button>
                <ext:Button runat="server" ID="btnHuy" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChonDotDanhGia.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if (hdfChonDotDanhGia.getValue() != hdfMaDotDanhGia.getValue()) {
                        grp_ChonDotDanhGia_Store.reload();
                        hdfChonDotDanhGia.setValue(hdfMaDotDanhGia.getValue());
                    }" />
                <Hide Handler="#{grp_ChonDotDanhGia}.getSelectionModel().clearSelections();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="550" Modal="true" Padding="6" Constrain="true" ID="wdNhanXet" Title="Nhận xét"
            Icon="Comment">
            <Items>
                <ext:TextArea runat="server" ID="txtLyDo" FieldLabel="Lý do đánh giá Dưới 30 điểm hoặc 100 điểm"
                    MaxLength="4000" AnchorHorizontal="100%">
                </ext:TextArea>
                <ext:TextArea runat="server" ID="txt_tunhanxet" AnchorHorizontal="100%" FieldLabel="Mặt tích cực"
                    MaxLength="4000">
                </ext:TextArea>
                <ext:TextArea runat="server" ID="txtLienQuanNhanXet" FieldLabel="Mặt hạn chế" MaxLength="4000"
                    AnchorHorizontal="100%">
                </ext:TextArea>
                <ext:TextArea runat="server" ID="txtQuanLyNhanXet" FieldLabel="Triển vọng" MaxLength="4000"
                    AnchorHorizontal="100%">
                </ext:TextArea>
                <ext:TextArea runat="server" ID="txtDeXuat" FieldLabel="Đề xuất" MaxLength="4000"
                    AnchorHorizontal="100%">
                </ext:TextArea>
                <ext:TextArea runat="server" ID="txtTomTat" FieldLabel="Tóm tắt trách nhiệm và mục tiêu công việc"
                    MaxLength="4000" AnchorHorizontal="100%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYNhanXet" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnDongYNhanXet_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnHuyNhanXet" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdNhanXet.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txt_tunhanxet.reset();txtLienQuanNhanXet.reset();txtQuanLyNhanXet.reset();
                    txtLyDo.reset(); txtDeXuat.reset(); txtTomTat.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grp_CanBoBiDanhGia_Store" GroupField="TEN_DONVI" AutoLoad="false"
            runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerCanBoBiDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={20}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDotDanhGia" Value="hdfMaDotDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaCB" Value="hdfUser.getValue()" Mode="Raw" />
                <ext:Parameter Name="IsNguoiQL" Value="hdfIsNguoiQL.getValue()" Mode="Raw" />
                <ext:Parameter Name="IsTuDanhGia" Value="hdfIsTuDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaBoPhan" Value="hdfMaBoPhan.getValue()" Mode="Raw" />
                <ext:Parameter Name="CreatedBy" Value="hdfCreatedBy.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaCB">
                    <Fields>
                        <ext:RecordField Name="MaCB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_DONVI" />
                        <ext:RecordField Name="TEN_CHUCVU" />
                        <ext:RecordField Name="TY_LE" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store ID="grp_TieuChiDanhGia_Store" AutoSave="false" OnBeforeStoreChanged="HandleChanges"
            ShowWarningOnFailure="false" SkipIdForNewRecords="false" RefreshAfterSaving="None"
            AutoLoad="false" runat="server" GroupField="TenNhomCha">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerTienHanhDanhGia.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={10}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaCB" Value="hdfMaCanBo.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDotDanhGia" Value="hdfMaDotDanhGia.getValue()" Mode="Raw" />
                <ext:Parameter Name="CreatedBy" Value="hdfCreatedBy.getValue()" Mode="Raw" />
                <ext:Parameter Name="IsNguoiQL" Value="hdfIsNguoiQL.getValue()" Mode="Raw" />
                <ext:Parameter Name="IsTuDanhGia" Value="hdfIsTuDanhGia.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" Type="Int" />
                        <ext:RecordField Name="MaNhom" />
                        <ext:RecordField Name="TenNhom" />
                        <ext:RecordField Name="HeSo" Type="Float" />
                        <ext:RecordField Name="TenNhomCha" />
                        <ext:RecordField Name="TuDanhGia" />
                        <ext:RecordField Name="Diem" Type="Float" />
                        <ext:RecordField Name="NhanXet" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <North Collapsible="false" Split="false">
                        <ext:Panel ID="tbNorth" runat="server" AutoHeight="true" AnchorHorizontal="100%"
                            Border="false" Title="Vui lòng chọn đợt đánh giá">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button ID="btnChonDotDanhGia" runat="server" Text="Chọn đợt đánh giá" Icon="BookOpenMark">
                                            <Listeners>
                                                <Click Handler="wdChonDotDanhGia.show();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                    </North>
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="Panel1" runat="server" Collapsed="false" Width="350" Border="false"
                            Layout="BorderLayout" Title="Danh sách cán bộ">
                            <Items>
                                <ext:GridPanel ID="grp_CanBoBiDanhGia" Border="false" runat="server" AutoExpandColumn="HO_TEN"
                                    AutoExpandMin="90" StripeRows="true" TrackMouseOver="false" Region="Center" Height="450"
                                    StoreID="grp_CanBoBiDanhGia_Store">
                                    <ColumnModel ID="ColumnModel9" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="30" Groupable="false" />
                                            <ext:Column ColumnID="MaCB" Header="Mã cán bộ" DataIndex="MaCB" Width="50" Groupable="false" />
                                            <ext:Column ColumnID="HO_TEN" Header="Tên cán bộ" DataIndex="HO_TEN" Groupable="false" />
                                            <ext:Column ColumnID="TY_LE" Header="Tỷ lệ hoàn thành" Width="80" DataIndex="TY_LE"
                                                Groupable="false" Align="Right">
                                                <Renderer Fn="GetRenderPhanTram" />
                                            </ext:Column>
                                            <ext:GroupingSummaryColumn ColumnID="TEN_DONVI" Width="150" Header="Bộ phận" Sortable="true"
                                                DataIndex="TEN_DONVI" Hideable="false">
                                            </ext:GroupingSummaryColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <View>
                                        <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                            ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                                    </View>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                            PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                            DisplayMsg="{0} đến {1} / {2} dòng" runat="server">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                    <SelectionModel>
                                        <ext:RowSelectionModel runat="server" ID="checkSelection" SingleSelect="true">
                                            <Listeners>
                                                <RowSelect Handler="grp_TieuChiDanhGia.save(); 
                                                    try{btnNhanXet.enable();}catch(e){}
                                                    grp_TieuChiDanhGia.setTitle('Đang đánh giá cho cán bộ: ' + checkSelection.getSelected().data.HO_TEN+' ('+checkSelection.getSelected().data.TEN_DONVI+')');" />
                                            </Listeners>
                                            <DirectEvents>
                                                <RowSelect OnEvent="DSCBRowSelected" Before="hdfMaCanBo.setValue(checkSelection.getSelected().id);" />
                                            </DirectEvents>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="grp_TieuChiDanhGia" Border="false" runat="server" StoreID="grp_TieuChiDanhGia_Store"
                            StripeRows="true" Title="Danh sách các tiêu chí đánh giá" AutoExpandColumn="TenNhom"
                            AutoExpandMin="200" TrackMouseOver="false" AnchorHorizontal="100%" ClicksToEdit="1">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar2" runat="server">
                                    <Items>
                                        <ext:Button runat="server" ID="btnSave" Text="Lưu lại" Icon="Disk">
                                            <Listeners>
                                                <Click Handler="#{grp_TieuChiDanhGia}.save();" />
                                            </Listeners>
                                            <%--<DirectEvents>
                                                <Click OnEvent="btnSave_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>--%>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnNhanXet" Text="Nhận xét" Icon="Comment" Disabled="true">
                                            <Listeners>
                                                <Click Handler="if (!hdfMaCanBo.getValue()) {alert('Bạn chưa chọn cán bộ nào'); return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEditNhanXet_Click">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" Groupable="false" />
                                    <ext:Column ColumnID="MaNhom" Header="Mã tiêu chí" Width="50" DataIndex="MaNhom"
                                        Groupable="false" />
                                    <ext:Column ColumnID="TenNhom" Header="Tên tiêu chí" Width="200" DataIndex="TenNhom"
                                        Groupable="false">
                                        <Renderer Fn="RendererTenTieuChi" />
                                    </ext:Column>
                                    <%--<ext:RatingColumn ColumnID="Diem" Header="Điểm đánh giá" Width="110" DataIndex="Diem"
                                        RoundToTick="false" Editable="true">
                                    </ext:RatingColumn>--%>
                                    <ext:Column ColumnID="DiemTuDanhGia" Hidden="true" Header="Tự đánh giá" DataIndex="TuDanhGia"
                                        Align="Center" Groupable="false">
                                    </ext:Column>
                                    <ext:Column ColumnID="Diem" Header="Điểm" Width="60" DataIndex="Diem" Align="Center"
                                        Groupable="false">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtPoint" MaxLength="5" MaskRe="/[0-9]/">
                                                <Listeners>
                                                    <Blur Handler="this.setValue(parseInt(this.getValue())); if (this.getValue()*1 > 100) {this.setValue(100);}" />
                                                </Listeners>
                                            </ext:TextField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="NhanXet" Header="Nhận xét" Align="Left" Width="150" DataIndex="NhanXet"
                                        Groupable="false">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtNhanXet" />
                                        </Editor>
                                    </ext:Column>
                                    <%--<ext:ImageCommandColumn Width="50" Align="Center" Header="Nhận xét" Groupable="false">
                                        <Commands>
                                            <ext:ImageCommand CommandName="NhanXet" Icon="CommentAdd">
                                                <ToolTip Text="Thêm nhận xét cho nhân viên" />
                                            </ext:ImageCommand>
                                        </Commands>
                                    </ext:ImageCommandColumn>--%>
                                    <ext:Column ColumnID="HeSo" Header="Hệ số" Align="Right" Width="40" DataIndex="HeSo"
                                        Groupable="false">
                                    </ext:Column>
                                    <ext:GroupingSummaryColumn ColumnID="TenNhomCha" Width="150" Header="Tên nhóm cha"
                                        Sortable="true" DataIndex="TenNhomCha" Hideable="false">
                                    </ext:GroupingSummaryColumn>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <View>
                                <ext:GroupingView ID="GroupingView2" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
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
                            <%--<Listeners>
                                <Command Handler="var recordIndex = grp_TieuChiDanhGia.store.indexOf(record); 
                                    grp_TieuChiDanhGia.getSelectionModel().selectRow(recordIndex);
                                    wdNhanXet.show();" />
                            </Listeners>--%>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
