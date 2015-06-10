<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThietLapCaChoNhanVien.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_ThietLapCaChoNhanVien" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div#GridPanel1 .x-grid3-cell-inner, .x-grid3-hd-inner
        {
            white-space: nowrap !important;
        }
        .west-panel .x-layout-collapsed-west
        {
            background: url(../../Resource/images/LocTheoPhongBan.png) no-repeat center;
        }
        .south-panel .x-layout-collapsed-south
        {
            background: url(../../Resource/images/DangKyLamThemGio.png) no-repeat center;
        }
        div#pnlThongTinDonVi-xsplit
        {
            border: 1px solid #99BBE8 !important;
            border-bottom: none !important;
            border-top: none !important;
        }
        .cbStates-list
        {
            width: 298px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }
        
        .cbStates-list th
        {
            font-weight: bold;
        }
        
        .cbStates-list td, .cbStates-list th
        {
            padding: 3px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Store ID="Store2" runat="server">
            <Reader>
                <ext:JsonReader IDProperty="name">
                    <Fields>
                        <ext:RecordField Name="name" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" Icon="ClockAdd" ID="wdTaoBangPhanCa" Padding="6" Layout="FormLayout"
            Title="Phân ca cho nhân viên" Hidden="true" Width="500" Modal="true" Constrain="true"
            AutoHeight="true">
            <Items>
                <ext:CompositeField runat="server" FieldLabel="Thời gian">
                    <Items>
                        <ext:DisplayField runat="server" Text="Tháng" />
                        <ext:ComboBox Editable="false" runat="server">
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
                        </ext:ComboBox>
                        <ext:DisplayField ID="DisplayField1" runat="server" Text="Năm" />
                        <ext:NumberField runat="server" />
                    </Items>
                </ext:CompositeField>
                <ext:Checkbox runat="server" BoxLabel="Sao chép từ bảng phân ca khác" />
                <ext:ComboBox runat="server" FieldLabel="Chọn bảng phân ca">
                </ext:ComboBox>
                <ext:DropDownField runat="server" FieldLabel="Chọn phòng ban">
                </ext:DropDownField>
                <ext:ComboBox ID="ComboBox2" runat="server" FieldLabel="Chọn ca" EmptyText="Chọn ca làm việc">
                </ext:ComboBox>
                <ext:TextField runat="server" FieldLabel="Tên bảng phân ca" AnchorHorizontal="100%" />
            </Items>
            <Buttons>
                <ext:Button ID="Button7" runat="server" Text="Cập nhật" Icon="Disk">
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                </ext:Button>
                <ext:Button ID="Button8" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdTaoBangPhanCa.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <West Collapsible="true" Split="true">
                        <ext:Panel ID="pnlThongTinDonVi" runat="server" CtCls="west-panel" Collapsed="True"
                            Width="240" Border="false" Layout="BorderLayout" Title="Cơ cấu tổ chức">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfTreeID" />
                                <ext:TreePanel ID="TreeCapNhatHoSoNhanSu" Border="False" runat="server" Region="Center"
                                    Height="450" Icon="BookOpen" Title="Catalog" Header="false" RootVisible="false"
                                    AutoScroll="true">
                                    <TopBar>
                                        <ext:Toolbar ID="Toolbar1" runat="server">
                                            <Items>
                                                <ext:Button ID="Button3" Icon="ArrowOut" runat="server" Text="Mở rộng">
                                                    <Listeners>
                                                        <Click Handler="#{TreeCapNhatHoSoNhanSu}.expandAll();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="Button4" runat="server" Text="Thu nhỏ" Icon="ArrowIn">
                                                    <Listeners>
                                                        <Click Handler="#{TreeCapNhatHoSoNhanSu}.collapseAll();" />
                                                    </Listeners>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Root>
                                        <ext:TreeNode NodeID="1" Text="Test">
                                        </ext:TreeNode>
                                    </Root>
                                    <BottomBar>
                                        <ext:StatusBar ID="StatusBar1" runat="server" AutoClear="1500" />
                                    </BottomBar>
                                </ext:TreePanel>
                            </Items>
                        </ext:Panel>
                    </West>
                    <Center>
                        <ext:GridPanel ID="GridPanel1" runat="server" Title="Bảng phân ca tháng 8" StripeRows="true"
                            Width="600" Border="false" Height="290">
                            <Store>
                                <ext:Store ID="Store1" runat="server" OnRefreshData="MyData_Refresh">
                                    <Reader>
                                        <ext:ArrayReader>
                                            <Fields>
                                                <ext:RecordField Name="company" />
                                                <ext:RecordField Name="price" Type="Float" />
                                                <ext:RecordField Name="change" Type="Float" />
                                                <ext:RecordField Name="pctChange" />
                                                <ext:RecordField Name="lastChange" Type="Date" />
                                            </Fields>
                                        </ext:ArrayReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="Button6" runat="server" Text="Bảng phân ca" Icon="ClockAdd">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Tạo bảng phân ca thủ công">
                                                            <Listeners>
                                                                <Click Handler="wdTaoBangPhanCa.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Tạo bảng phân ca tự động">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Chọn bảng phân ca">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Quản lý bảng phân ca">
                                                        </ext:MenuItem> 
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button ID="Button1" Text="Quản lý giờ giấc" Icon="Clock" runat="server">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items> 
                                                        <ext:MenuItem Text="Đổi ca làm việc">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Đăng ký tăng/giảm ca">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Đăng ký làm thêm giờ">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem1" runat="server" Text="Sao chép ca giữa 2 nhân viên">
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button Icon="User" Text="Quản lý nhân viên" runat="server">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Thêm nhân viên">
                                                        </ext:MenuItem>
                                                        <ext:MenuItem Text="Loại bỏ nhân viên">
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TextField runat="server" Width="220" EmptyText="Nhập mã hoặc họ tên nhân viên..." />
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="Company" Header="Mã NV" Locked="true" Width="70" DataIndex="company" />
                                    <ext:Column ColumnID="Company" Header="Họ tên" Locked="true" Width="130" DataIndex="company" />
                                    <ext:Column ColumnID="Company" Header="Phòng ban" Locked="true" Width="150" DataIndex="company" />
                                    <ext:Column ColumnID="Company" Header="Tổ đội" Locked="true" Width="100" DataIndex="company" />
                                    <ext:Column Width="60" ColumnID="Ngay1" Header="Ngày 1" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay2" Header="Ngày 2" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay3" Header="Ngày 3" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay4" Header="Ngày 4" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay5" Header="Ngày 5" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay6" Header="Ngày 6" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay7" Header="Ngày 7" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay8" Header="Ngày 8" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay9" Header="Ngày 9" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay10" Header="Ngày 10" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay11" Header="Ngày 11" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay12" Header="Ngày 12" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay13" Header="Ngày 13" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay14" Header="Ngày 14" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay15" Header="Ngày 15" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay16" Header="Ngày 16" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay17" Header="Ngày 17" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay18" Header="Ngày 18" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay19" Header="Ngày 19" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay20" Header="Ngày 20" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay21" Header="Ngày 21" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay22" Header="Ngày 22" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay23" Header="Ngày 23" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay24" Header="Ngày 24" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay25" Header="Ngày 25" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay26" Header="Ngày 26" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay27" Header="Ngày 27" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay28" Header="Ngày 28" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay29" Header="Ngày 29" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay30" Header="Ngày 30" DataIndex="pctChange" />
                                    <ext:Column Width="60" ColumnID="Ngay31" Header="Ngày 31" DataIndex="pctChange" />
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="1" />
                                                <ext:ListItem Text="2" />
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="20" />
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
                    <South Split="true" Collapsible="true">
                        <ext:Panel Title="Đăng ký làm thêm giờ" Collapsed="true" CtCls="south-panel" Height="180" Border="false" Layout="BorderLayout"
                            runat="server">
                            <Items>
                                <ext:GridPanel ID="GridPanel2" runat="server" Region="Center" StoreID="Store1" Header="false"
                                    StripeRows="true" Border="false">
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                            <ext:Column ColumnID="Company" Header="Tên ca" Width="130" DataIndex="company" />
                                            <ext:Column ColumnID="Company" Header="Giờ vào" Width="70" DataIndex="company" />
                                            <ext:Column ColumnID="Company" Header="Giờ ra" Width="70" DataIndex="company" />
                                            <ext:Column ColumnID="Company" Header="Giờ được yêu cầu làm thêm" Width="170" DataIndex="company">
                                                <Renderer Handler="return 'Từ 17h30 đến 19h30'" />
                                            </ext:Column>
                                            <ext:Column ColumnID="Company" Header="Tổng thời gian làm thêm" Width="140" Align="Right" DataIndex="company">
                                                <Renderer Handler="return '2 giờ'" />
                                            </ext:Column>
                                            <ext:Column ColumnID="Company" Header="Ngày làm" Align="Center" Width="100" DataIndex="company">
                                                <Renderer Handler="return '9-8-2013'" />
                                            </ext:Column>
                                            <ext:Column ColumnID="Company" Header="Xóa/Sửa" Align="Center" Width="100" DataIndex="company">
                                                <Renderer Handler="return ''" />
                                                <Commands>
                                                    <ext:ImageCommand CommandName="Delete" Icon="Delete" Text="Xóa">
                                                        <ToolTip Text="Xóa" />
                                                    </ext:ImageCommand>
                                                    <ext:ImageCommand CommandName="Edit" Icon="NoteEdit" Text="Sửa">
                                                        <ToolTip Text="Sửa" />
                                                    </ext:ImageCommand>
                                                </Commands>
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
                                    </SelectionModel>
                                    <LoadMask ShowMask="true" />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
