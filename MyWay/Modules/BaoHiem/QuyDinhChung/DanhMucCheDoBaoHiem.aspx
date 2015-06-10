<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhMucCheDoBaoHiem.aspx.cs" Inherits="Modules_BaoHiem_QuyDinhChung_DanhMucCheDoBaoHiem" %>


<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Window runat="server" Hidden="true" ID="wdCheDoBaoHiem"
                Padding="0" Title="Thêm mới chế độ bảo hiểm" Constrain="true" Modal="true"
                Icon="Add" Width="440" Resizable="false" AutoHeight="true">
                <Items>
                    <ext:Panel ID="Panel6" Height="110" Padding="6" runat="server" Border="false">
                        <Items>
                            <ext:Container ID="Container7" runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                                <Content>

                                    <ext:TextField runat="server" ID="TextField7" FieldLabel="Mã chế độ" Width="300"></ext:TextField>
                                    <ext:TextField runat="server" ID="TextField8" FieldLabel="Tên chế độ" Width="300"></ext:TextField>
                                    <ext:DropDownField runat="server" ID="DropDownField1" FieldLabel="Nhóm loại chế độ" Width="300"></ext:DropDownField>
                                </Content>
                            </ext:Container>
                        </Items>
                    </ext:Panel>
                </Items>
                <Buttons>
                 <%--   <ext:Button runat="server" ID="Button28" Text="Cập nhật" Icon="Disk">
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
                    <ext:Button runat="server" ID="Button29" Text="Cập nhật & Đóng lại"
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
                    <ext:Button runat="server" ID="Button30" Text="Đóng lại" Icon="Decline">
                         <Listeners>
                            <Click Handler="#{wdQuyDinhVeBienDongBaoHiem.hide();" />
                        </Listeners>
                    </ext:Button>--%>
                </Buttons>
            </ext:Window>
            <ext:GridPanel
                Border="false"
                ID="grpDanhMucCheDoBaoHiem"
                runat="server"
                StripeRows="true"
                Header="false"
                Padding="0"
                StoreID="Store1"
                AutoExpandColumn="colNgayTao">
                <TopBar>
                    <ext:Toolbar runat="server" ID="Toolbar2">
                        <Items>
                            <ext:Button ID="Button7" runat="server" Text="Thêm mới" Icon="Add">
                                <Listeners>
                                    <Click Handler="wdCheDoBaoHiem.show();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="Button8" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                            </ext:Button>
                            <ext:Button ID="Button9" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator2" runat="server" />
                            <ext:Button ID="Button11" runat="server" Text="Tiện ích" Icon="Build">
                                <Menu>
                                    <ext:Menu ID="Menu1" runat="server">
                                        <Items>
                                            <ext:MenuItem runat="server" Disabled="true" ID="MenuItem1" Text="Nhân đôi dữ liệu"
                                                Icon="DiskMultiple">
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                            </ext:Button>
                            <ext:ToolbarFill runat="server" ID="ToolbarFill1" />
                            <ext:TextField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                EmptyTex="Nhập từ khóa tìm kiếm" ID="TextField1">
                            </ext:TextField>
                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="Button12">
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn Header="STT" Width="20"></ext:RowNumbererColumn>
                        <ext:Column ColumnID="colMaCheDo" Header="Mã chế độ" Width="100"></ext:Column>
                        <ext:Column ColumnID="colTenCheDo" Header="Tên chế độ" Width="200"></ext:Column>
                        <ext:DateColumn ColumnID="colNgayTao" Header="Ngày tạo" Width="100"></ext:DateColumn>
                    </Columns>
                </ColumnModel>
            </ext:GridPanel>
        </div>
    </form>
</body>
</html>
