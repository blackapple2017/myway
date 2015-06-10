<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuyDinhVeBienDongBaoHiem.aspx.cs"
    Inherits="Modules_BaoHiem_QuyDinhChung_QuyDinhVeBienDongBaoHiem" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
      
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Window runat="server" Hidden="true" ID="wdQuyDinhVeBienDongBaoHiem" Padding="0"
                Title="Thêm mới biến động bảo hiểm" Constrain="true" Modal="true" Icon="Add"
                Width="440" Resizable="false" AutoHeight="true">
                <Items>
                    <ext:Panel ID="Panel4" Height="170" Padding="6" runat="server" Border="false">
                        <Items>
                            <ext:Container ID="Container4" runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                                <Content>
                                    <ext:DropDownField runat="server" ID="ddfLoaiBienDong" FieldLabel="Loại biến động"
                                        Width="300">
                                    </ext:DropDownField>
                                    <ext:TextField runat="server" ID="txtMaBienDong" FieldLabel="Mã biến động" Width="300">
                                    </ext:TextField>
                                    <ext:TextField runat="server" ID="txtTenBienDong" FieldLabel="Tên biến động" Width="300">
                                    </ext:TextField>
                                    <ext:CheckboxGroup ID="CheckboxGroup1" runat="server" Vertical="false" Width="300">
                                        <Items>
                                            <ext:Checkbox runat="server" ID="chkBHXH" BoxLabel="BHXH">
                                            </ext:Checkbox>
                                            <ext:Checkbox runat="server" ID="chkBHYT" BoxLabel="BHYT">
                                            </ext:Checkbox>
                                            <ext:Checkbox runat="server" ID="chkBHTN" BoxLabel="BHTN">
                                            </ext:Checkbox>
                                        </Items>
                                    </ext:CheckboxGroup>
                                    <ext:CheckboxGroup ID="CheckboxGroup2" runat="server" Vertical="false" Width="300">
                                        <Items>
                                            <ext:Checkbox runat="server" ID="chkDangSuDung" BoxLabel="Đang sử dụng" Checked="true">
                                            </ext:Checkbox>
                                        </Items>
                                    </ext:CheckboxGroup>
                                </Content>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                    <%--  <ext:Button runat="server" ID="btnUpdateQuyDinhBienDong" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckDuLieuDauVao();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateQuyDinhBienDong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnUpdateAndCloseQuyDinhBienDong" Text="Cập nhật & Đóng lại"
                        Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckDuLieuDauVao();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnUpdateQuyDinhBienDong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True"></ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnClose" Text="Đóng lại" Icon="Decline">
                         <Listeners>
                            <Click Handler="#{wdQuyDinhVeBienDongBaoHiem.hide();" />
                        </Listeners>
                    </ext:Button>--%>
                </Buttons>
            </ext:Window>
            <ext:GridPanel Border="false" ID="grpQuyDinhBienDongBaoHiem" runat="server" StripeRows="true"
                Header="false" Padding="0" StoreID="Store1" AutoExpandColumn="colTenBienDong"
                AutoHeight="true" AutoWidth="true">
                <TopBar>
                    <ext:Toolbar runat="server" ID="Toolbar1">
                        <Items>
                            <ext:Button ID="Button1" runat="server" Text="Thêm mới" Icon="Add">
                                <Listeners>
                                    <Click Handler="wdQuyDinhVeBienDongBaoHiem.show();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button2" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                            </ext:Button>
                            <ext:Button ID="Button4" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server" />
                            <ext:Button ID="Button13" runat="server" Text="Tiện ích" Icon="Build">
                                <Menu>
                                    <ext:Menu ID="Menu2" runat="server">
                                        <Items>
                                            <ext:MenuItem runat="server" Disabled="true" ID="MenuItem2" Text="Nhân đôi dữ liệu"
                                                Icon="DiskMultiple">
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                            </ext:Button>
                            <ext:ToolbarFill runat="server" ID="ToolbarFill2" />
                            <ext:TextField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                EmptyTex="Nhập từ khóa tìm kiếm" ID="TextField2">
                            </ext:TextField>
                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="Button14">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel3" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn />
                        <ext:Column ColumnID="colLoaiBienDong" Width="150" DataIndex="company" Header="Loại biến động">
                        </ext:Column>
                        <ext:Column ColumnID="colMaBienDong" Width="100" DataIndex="company" Header="Mã biến động">
                        </ext:Column>
                        <ext:Column ColumnID="colTenBienDong" DataIndex="company" Header="Tên biến động">
                        </ext:Column>
                        <ext:CheckColumn ColumnID="colBHXH" Width="100" DataIndex="price" Header="BHXH">
                        </ext:CheckColumn>
                        <ext:CheckColumn ColumnID="colBHYT" Width="100" DataIndex="price" Header="BHYT">
                        </ext:CheckColumn>
                        <ext:CheckColumn ColumnID="colBHTN" Width="100" DataIndex="price" Header="BHTN">
                        </ext:CheckColumn>
                        <ext:CheckColumn ColumnID="colDangSuDung" Width="100" DataIndex="price" Header="Đang sử dụng">
                        </ext:CheckColumn>
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
                </SelectionModel>
                <LoadMask ShowMask="true" />
            </ext:GridPanel>
        </div>
    </form>
</body>
</html>
