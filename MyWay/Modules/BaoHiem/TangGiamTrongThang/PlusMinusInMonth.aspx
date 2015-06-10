<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PlusMinusInMonth.aspx.cs"
    Inherits="Modules_BaoHiem_TangGiamTrongThang_PlusMinusInMonth" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #grpTangGiamBH .x-grid3-cell-inner
        {
            white-space: nowrap !important;
        }
    </style>
    <script type="text/javascript" src="../../../Resource/js/RenderJS.js"></script>
    <script type="text/javascript">
        var keyEnterPress = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                if (this.getValue() == '') {
                    this.triggers[0].hide();
                }
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var CheckSelectedRows = function (grid) {
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
        var enterKeyToSearch = function (f, e) {
            try {
                this.triggers[0].show();
                if (e.getKey() == e.ENTER) {
                    store3.reload();
                }
                if (txtFullName.getValue() == '') {
                    this.triggers[0].hide();
                }
            } catch (e) {

            }
        }
        var afterEdit = function (e) {
            Ext.net.DirectMethods.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Window runat="server" ID="wdAddNhanVienBaoHiem" Title="Tháng đăng ký với cơ quan bảo hiểm"
            Modal="true" Layout="FormLayout" Width="650" Padding="6" Constrain="true" Hidden="true"
            Icon="Add" AutoHeight="true">
            <Items>
                <ext:GridPanel runat="server" ID="EmployeeGrid" Icon="UserAdd" Header="false" Title="Danh sách nhân viên đang đóng bảo hiểm"
                    AutoExpandColumn="HoVaTen" AnchorHorizontal="100%" Height="300">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tbEmployeeGrid">
                            <Items>
                                <ext:ComboBox runat="server" ID="cbDepartmentList" FieldLabel="Phòng ban" CtCls="requiredData"
                                    DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item"
                                    Editable="false" Width="350" LabelWidth="65" AllowBlank="false">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template37" runat="server">
                                        <Html>
                                            <tpl for=".">
						                                              <div class="list-item"> 
                                                                        <tpl if="MA &gt; '-a'">{TEN}</tpl>
                                                                        <tpl if="MA &lt; 0"><span class='lineThrough'>{TEN}</span></tpl> 
						                                              </div>
					                                               </tpl>
                                        </Html>
                                    </Template>
                                    <Store>
                                        <ext:Store runat="server" ID="stDepartmentList" AutoLoad="false" OnRefreshData="stDepartmentList_OnRefreshData">
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
                                        <Expand Handler="if(#{stDepartmentList}.getCount()==0) #{stDepartmentList}.reload();" />
                                        <Select Handler="#{PagingToolbar2}.pageIndex=0;#{PagingToolbar2}.doLoad();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <ext:TriggerField runat="server" EnableKeyEvents="true" ID="txtFullName" EmptyText="Nhập tên nhân viên">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <KeyPress Fn="enterKeyToSearch" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); store3.reload(); }" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:Button ID="Button3" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                    <Listeners>
                                        <Click Handler="#{Store3}.reload();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel runat="server" ID="chkEmployeeRowSelection" />
                    </SelectionModel>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="30" Header="STT" />
                            <ext:Column Header="Mã CB" Width="60" DataIndex="MA_CB">
                            </ext:Column>
                            <ext:Column Header="Họ Tên" ColumnID="HoVaTen" DataIndex="HO_TEN">
                            </ext:Column>
                            <ext:DateColumn Header="Ngày sinh" Format="dd/MM/yyyy" DataIndex="NGAY_SINH">
                            </ext:DateColumn>
                            <ext:Column Header="Giới tính" DataIndex="GIOI_TINH">
                            </ext:Column>
                            <ext:Column Header="Bộ phận" DataIndex="DonViCongTac">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <Store>
                        <ext:Store ID="Store3" ShowWarningOnFailure="false" SkipIdForNewRecords="false" runat="server"
                            AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Method="GET" Url="HandlerSelectedUser.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="limit" Value="={20}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="#{cbDepartmentList}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" IDProperty="PR_KEY" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="PR_KEY" />
                                        <ext:RecordField Name="MA_CB" />
                                        <ext:RecordField Name="HO_TEN" />
                                        <ext:RecordField Name="NGAY_SINH" />
                                        <ext:RecordField Name="GIOI_TINH" />
                                        <ext:RecordField Name="DonViCongTac" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <SaveMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                            PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                            DisplayMsg="{0}-{1} / tổng số {2} dòng" runat="server">
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongY" Text="Thêm" Icon="Add">
                    <Listeners>
                        <Click Handler="return CheckSelectedRows(EmployeeGrid);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThemNhanVien_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnClosewdAddNhanVienBaoHiem" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAddNhanVienBaoHiem.hide()" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="chkEmployeeRowSelection.clearSelections();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel runat="server" ID="grpTangGiamBH" Border="false" EnableColumnMove="false"
                            TrackMouseOver="true" StripeRows="true" Header="false" AutoExpandColumn="Notes"
                            AutoExpandMin="150">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Button runat="server" ID="btnAdd" Text="Thêm" Icon="Add">
                                            <Listeners>
                                                <Click Handler="wdAddNhanVienBaoHiem.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnDelete" Text="Xóa" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="return CheckSelectedRows(#{grpTangGiamBH});" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation Message="Bạn có chắc chắn muốn xóa không?" ConfirmRequest="true" Title="Xác nhận" />
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator />
                                        <ext:DisplayField runat="server" ID="dpfMonth" Text="Chọn tháng" />
                                        <ext:ToolbarSpacer Width="5" />
                                        <ext:ComboBox runat="server" ID="cbMonth" SelectedIndex="0" Editable="false" Width="70">
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
                                                <Select Handler=" #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:ToolbarSpacer Width="10" />
                                        <ext:DisplayField runat="server" ID="dpfYear" Text="Chọn năm" />
                                        <ext:ToolbarSpacer Width="5" />
                                        <ext:SpinnerField ID="spinYear" AllowBlank="false" AllowDecimals="false" LabelWidth="0"
                                            AllowNegative="false" BlankText="Bạn phải nhập năm" runat="server" Width="60">
                                            <Listeners>
                                                <Blur Handler=" #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); checkBoxSelection.clearSelections();" />
                                            </Listeners>
                                        </ext:SpinnerField>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Tìm kiếm theo mã hoặc theo tên"
                                            ID="txtSearchKey">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="keyEnterPress" />
                                                <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); checkBoxSelection.clearSelections();" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad(); checkBoxSelection.clearSelections();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store runat="server" ID="stTangGiamBaoHiem" AutoLoad="true">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="HandlerTangGiamBHTrongThang.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={30}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="Month" Value="#{cbMonth}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="Year" Value="#{spinYear}.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID" TotalProperty="TotalRecords" Root="Data">
                                            <Fields>
                                                <ext:RecordField Name="ID" Type="Int" />
                                                <ext:RecordField Name="IDNhanVien_BaoHiem" />
                                                <ext:RecordField Name="MaNhanVien" />
                                                <ext:RecordField Name="HoTen" />
                                                <ext:RecordField Name="TenBoPhan" />
                                                <ext:RecordField Name="TenChucVu" />
                                                <ext:RecordField Name="LuongBaoHiem" />
                                                <ext:RecordField Name="Plus" />
                                                <ext:RecordField Name="Minus" />
                                                <ext:RecordField Name="Notes" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel>
                                <Columns>
                                    <ext:RowNumbererColumn ColumnID="colSTT" Header="STT" Width="30" Locked="true" />
                                    <ext:Column ColumnID="colMaCanBo" Width="100" DataIndex="MaNhanVien" Header="Mã cán bộ"
                                        Locked="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="colTenCanBo" Width="200" DataIndex="HoTen" Header="Họ tên"
                                        Locked="true">
                                    </ext:Column>
                                    <ext:Column ColumnID="colBoPhan" Width="200" DataIndex="TenBoPhan" Header="Bộ phận">
                                    </ext:Column>
                                    <ext:Column ColumnID="colChucVu" Width="160" DataIndex="TenChucVu" Header="Chức vụ">
                                    </ext:Column>
                                    <ext:Column ColumnID="colLuongDongBaoHiem" Width="100" DataIndex="LuongBaoHiem" Header="Lương đóng BH"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colPlus" Width="85" DataIndex="Plus" Header="Tăng">
                                        <Editor>
                                            <ext:NumberField runat="server" AllowNegative="true" AnchorHorizontal="100%" />
                                        </Editor>
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colMinus" Width="85" DataIndex="Minus" Header="Giảm">
                                        <Editor>
                                            <ext:NumberField runat="server" AllowNegative="true" AnchorHorizontal="100%" />
                                        </Editor>
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                    <ext:Column ColumnID="colNotes" Width="85" DataIndex="Notes" Header="Ghi chú">
                                        <Editor>
                                            <ext:TextField runat="server" AnchorHorizontal="100%" />
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="70" />
                                                <ext:ListItem Text="100" />
                                            </Items>
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Listeners>
                                        <Change Handler="checkBoxSelection.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <View>
                                <ext:LockingGridView runat="server" ForceFit="false" ID="lk1">
                                </ext:LockingGridView>
                            </View>
                            <Listeners>
                                <AfterEdit Fn="afterEdit" />
                            </Listeners>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkBoxSelection" ColumnPosition="0">
                                    <Listeners>
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
