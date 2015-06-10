<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TongHopCongTheoNgay.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_TongHopCongTheoNgay" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #grpVaoRaCa .x-grid3-cell-inner
        {
            white-space: nowrap !important;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
            }
            if (txtSearchKey.getValue() != '')
                this.triggers[0].show();
        }
        var afterEdit = function (e) {
            TongHopCongTheoNgay.AfterEdit(e.field, e.originalValue, e.value, e.record.data);
        };
        var beforeEdit = function (e) {
            if ((e.value == "" || e.value == null) && e.field.substring(0, 3) == "Lan") {
                return false;
            }
        };
        var kyHieuChamCongRenderer = function (value) {
            var r = StoreKyHieuChamCong.getById(value);
            if (Ext.isEmpty(r)) {
                return "";
            }
            return r.data.TEN_TT_LAMVIEC;
        }
        var CheckDataInput = function () {
            if (cbxChonCanBo.getValue() == '' || cbxChonCanBo.getValue() == null) {
                alert('Bạn chưa chọn cán bộ');
                cbxChonCanBo.focus();
                return false;
            }
            if (cbKyHieuChamCong.getValue() == '' || cbKyHieuChamCong.getValue() == null) {
                alert('Bạn chưa chọn ký hiệu chấm công');
                cbKyHieuChamCong.focus();
                return false;
            }

            return true;
        }
        var ResetwdAddWindow = function () {
            cbxChonCanBo.reset(); hdfChonCanBo.reset();
            cbKyHieuChamCong.reset(); hdfKyHieuChamCong.reset();
            txtArGhiChu.reset();
        }
        var ChangeDayTimeSheet = function (datefield, days) {
            var now = new Date(datefield.getValue());
            var late = new Date(now.getTime() + (days * 24 * 60 * 60 * 1000));
            datefield.setValue(late);
            PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager ID="RM" runat="server" />
    <ext:Hidden runat="server" ID="hdfMax" />
    <ext:Hidden runat="server" ID="hdfNgayChamCong" />
    <ext:Hidden runat="server" ID="hdfSelectedDepartment" />
    <ext:Hidden runat="server" ID="hdfUserID" />
    <ext:Hidden runat="server" ID="hdfMenuID" />
    <div>
        <ext:Store ID="Store2" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="KYHIEU_TT_LAMVIEC">
                    <Fields>
                        <ext:RecordField Name="KYHIEU_TT_LAMVIEC" />
                        <ext:RecordField Name="TEN_TT_LAMVIEC" />
                        <ext:RecordField Name="SoCongHuongLuong" Type="Float" />
                        <ext:RecordField Name="NhomKyHieu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="400" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm nhân viên chấm công theo ngay"
            LabelWidth="120">
            <Items>
                <ext:Hidden runat="server" ID="hdfChonCanBo" />
                <ext:ComboBox ID="cbxChonCanBo" CtCls="requiredData" ValueField="PRKEY" DisplayField="HOTEN"
                    FieldLabel="Tên cán bộ<span style='color:red'>*</span>" PageSize="10" HideTrigger="true"
                    ItemSelector="div.search-item" MinChars="1" EmptyText="nhập tên để tìm kiếm"
                    LoadingText="Đang tải dữ liệu..." AnchorHorizontal="100%" runat="server">
                    <Store>
                        <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/QuyetDinhLuong/SearchUserHandler.ashx" />
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
                    <%-- <DirectEvents>
                        <Select OnEvent="cbxChonCanBo_Selected" />
                    </DirectEvents>--%>
                </ext:ComboBox>
                <ext:Hidden runat="server" ID="hdfKyHieuChamCong" />
                <ext:MultiCombo ID="cbTinhTrangLamViec" runat="server" EmptyText="Chọn ký hiệu chấm công"
                    TypeAhead="true" AnchorHorizontal="100%" ForceSelection="true" StoreID="Store2"
                    CtCls="requiredData" DisplayField="TEN_TT_LAMVIEC" ValueField="KYHIEU_TT_LAMVIEC"
                    FieldLabel="Ký hiệu chấm công<span style='color:red;'>*</span>" MinChars="1"
                    PageSize="15">
                </ext:MultiCombo>
                <ext:TextArea runat="server" ID="txtArGhiChu" AnchorHorizontal="100%" FieldLabel="Ghi chú">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatThem" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckDataInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatVaDongLai" Text="Cập nhật & đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckDataInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnDongLai" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddWindow}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetwdAddWindow();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="Store1" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="Handler/HandlerTongHopCongTheoNgay.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="bophan" Value="hdfSelectedDepartment.getValue()" Mode="Raw" />
                <ext:Parameter Name="max" Value="hdfMax.getValue()" Mode="Raw" />
                <ext:Parameter Name="ngay" Value="dfNgayChamCong.getValue()" Mode="Raw" />
                <ext:Parameter Name="searchKey" Value="txtSearchKey.getValue()" Mode="Raw" />
                <ext:Parameter Name="menuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                <ext:Parameter Name="userID" Value="hdfUserID.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MA_CB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_CB" />
                        <ext:RecordField Name="MaChamCong" />
                        <ext:RecordField Name="PhongBan" />
                        <ext:RecordField Name="TEN_DIADIEM" />
                        <ext:RecordField Name="GioVao" />
                        <ext:RecordField Name="GioRa" />
                        <ext:RecordField Name="SoPhutDiMuon" />
                        <ext:RecordField Name="SoPhutVeSom" />
                        <ext:RecordField Name="SoGio" />
                        <ext:RecordField Name="Gio300" />
                        <ext:RecordField Name="KyHieuChamCong" />
                        <ext:RecordField Name="GhiChu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="grpVaoRaCa" runat="server" StripeRows="true" TrackMouseOver="true"
                            Width="1000" Height="400" Border="false" StoreID="Store1">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:DateField runat="server" ID="dfNgayChamCong" Editable="true" FieldLabel="<b>Chọn ngày</b>"
                                            Width="200" LabelWidth="60" MaskRe="/[0-9\/]/" Format="d/M/yyyy" EnableKeyEvents="true"
                                            Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                                            <Listeners>
                                                <Select Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:DateField>
                                        <ext:Button runat="server" ID="btnPreiousDay" Icon="PreviousGreen">
                                            <Listeners>
                                                <Click Handler="ChangeDayTimeSheet(dfNgayChamCong,-1)" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnNextDay" Icon="NextGreen">
                                            <Listeners>
                                                <Click Handler="ChangeDayTimeSheet(dfNgayChamCong,1)" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:Button runat="server" Icon="Add" Text="Thêm nhân viên" ID="btnAddNhanVien">
                                            <Listeners>
                                                <Click Handler="wdAddWindow.show()" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSpacer Width="5" ID="tbs" />
                                        <ext:Button runat="server" Icon="Printer" Text="Báo cáo" ID="btnReport" Hidden="true">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Danh sách đi muộn">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Danh sách về sớm">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Danh sách vắng mặt">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Danh sách có mặt">
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarSpacer Width="5" ID="ToolbarSpacer2" />
                                        <ext:DisplayField runat="server" Text="<b>Cập nhật lần cuối : 4 phút trước" ID="dpfPhut" />
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa để tìm kiếm"
                                            ID="txtSearchKey">
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
                                                <Click Handler="PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel runat="server" ID="ColumnModel1">
                                <Columns>
                                    <ext:RowNumbererColumn Width="35" Header="STT" Locked="true" />
                                    <ext:Column ColumnID="MA_CB" Width="80" Header="Mã cán bộ" DataIndex="MA_CB" Locked="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="HO_TEN" Width="120" Header="Họ tên" DataIndex="HO_TEN" Locked="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="MaChamCong" Width="90" Header="Mã chấm công" DataIndex="MaChamCong"
                                        Locked="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="PhongBan" Width="150" Header="Phòng ban" DataIndex="PhongBan">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_DIADIEM" Width="150" Header="Địa điểm làm việc" DataIndex="TEN_DIADIEM">
                                    </ext:Column>
                                    <ext:Column ColumnID="SoPhutDiMuon" Width="50" Header="Số phút đi muộn" DataIndex="SoPhutDiMuon"
                                        Align="Right">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtSoPhutDiMuon" MaskRe="/[0-9]/" MaxLength="16">
                                            </ext:TextField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="SoPhutVeSom" Width="50" Header="Số phút về sớm" DataIndex="SoPhutVeSom"
                                        Align="Right">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtSoPhutVeSom" MaskRe="/[0-9]/" MaxLength="16">
                                            </ext:TextField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="SoGio" Width="50" Header="Số giờ" DataIndex="SoGio" Align="Right">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtSoGio" MaskRe="/[0-9.]/" MaxLength="5">
                                            </ext:TextField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="Gio300" Width="50" Header="Số giờ ca gãy" DataIndex="Gio300"
                                        Align="Right">
                                        <Editor>
                                            <ext:TextField runat="server" ID="TextField1" MaskRe="/[0-9.]/" MaxLength="5">
                                            </ext:TextField>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="KyHieuChamCong" Header="Ký hiệu chấm công" Width="120" DataIndex="KyHieuChamCong">
                                        <%--<Renderer Fn="kyHieuChamCongRenderer" />--%>
                                        <Editor>
                                            <ext:MultiCombo ID="cbxEditorKyHieuChamCong" runat="server" TypeAhead="true" AnchorHorizontal="100%"
                                                ForceSelection="true" StoreID="Store2" DisplayField="TEN_TT_LAMVIEC" ValueField="KYHIEU_TT_LAMVIEC"
                                                ListWidth="250" MinChars="1" PageSize="15">
                                            </ext:MultiCombo>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column ColumnID="GhiChu" Width="200" Header="Ghi chú" DataIndex="GhiChu">
                                        <Editor>
                                            <ext:TextField runat="server" ID="txtGhiChu">
                                            </ext:TextField>
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="RowSelectionModel1">
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <Listeners>
                                <BeforeEdit Fn="beforeEdit" />
                                <AfterEdit Fn="afterEdit" />
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
                                                <ext:ListItem Text="200" />
                                                <ext:ListItem Text="500" />
                                                <ext:ListItem Text="1000" />
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
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu. Vui lòng chờ..." />
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
