<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangVaoRaCa.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_BangVaoRaCa" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
            }
            if (txtSearchKey.getValue() != '')
                this.triggers[0].show();
        }
        var afterEdit = function (e) {
            ChamCongVaoRaCa.AfterEdit(e.field, e.originalValue, e.value, e.record.data);
        };
        var beforeEdit = function (e) {
            if (e.value == "" || e.value == null) {
                return false;
            }
        };
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
        <div>
            <ext:Store ID="Store1" AutoLoad="true" runat="server">
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="Handler/HandlerBangVaoRaCa.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="={0}" />
                    <ext:Parameter Name="limit" Value="={30}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="max" Value="hdfMax.getValue()" Mode="Raw" />
                    <ext:Parameter Name="ngay" Value="dfNgayChamCong.getValue()" Mode="Raw" />
                    <ext:Parameter Name="searchKey" Value="txtSearchKey.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="MA_CB" />
                            <ext:RecordField Name="HO_TEN" />
                            <ext:RecordField Name="MaChamCong" />
                            <ext:RecordField Name="PhongBan" />
                            <ext:RecordField Name="TEN_DIADIEM" />
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
                                            <ext:DateField runat="server" ID="dfNgayChamCong" Editable="true" FieldLabel="<b>Chọn ngày</b>" Width="200" LabelWidth="60" EnableKeyEvents="true"
                                                MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                                                <Listeners>
                                                    <Select Handler="PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();" />
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
                                        <ext:Column ColumnID="MA_CB" Width="90" Header="Mã cán bộ" DataIndex="MA_CB" Locked="true">
                                        </ext:Column>
                                        <ext:Column ColumnID="HO_TEN" Width="130" Header="Họ tên" DataIndex="HO_TEN" Locked="true">
                                        </ext:Column>
                                        <ext:Column ColumnID="MaChamCong" Width="80" Header="Mã chấm công" DataIndex="MaChamCong"
                                            Locked="true">
                                        </ext:Column>
                                        <ext:Column ColumnID="PhongBan" Width="150" Header="Phòng ban" DataIndex="PhongBan">
                                        </ext:Column>
                                        <ext:Column ColumnID="DiaDiemLamViec" Width="150" Header="Địa điểm làm việc" DataIndex="TEN_DIADIEM">
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
