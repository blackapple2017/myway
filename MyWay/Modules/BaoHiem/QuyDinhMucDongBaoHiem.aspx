<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuyDinhMucDongBaoHiem.aspx.cs"
    Inherits="Modules_BaoHiem_QuyDinhMucDongBaoHiem" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="QuyDinhChung/BangTinhCheDoBaoHiem.ascx" TagName="BangTinhCheDoBaoHiem"
    TagPrefix="uc1" %>
<%@ Register Src="QuyDinhChung/BangCheDoBaoHiem.ascx" TagName="BangCheDoBaoHiem"
    TagPrefix="uc2" %>
<%@ Register Src="QuyDinhChung/QuyDinhBienDong.ascx" TagName="QuyDinhBienDong" TagPrefix="uc3" %>
<%@ Register Src="QuyDinhChung/QuyDinhVeDoiTuongDongBaoHiem.ascx" TagName="QuyDinhVeDoiTuongDongBaoHiem"
    TagPrefix="uc4" %>
<%@ Register Src="QuyDinhChung/QuyDinhVeMucDongBaoHiem.ascx" TagName="QuyDinhVeMucDongBaoHiem"
    TagPrefix="uc5" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        div#pnlTop .x-panel-body {
            background-color: #DFE8F6 !important;
        }

        div#Panel4 .x-panel-body {
            background-color: #DFE8F6 !important;
        }

        #grpLoaiHopDong {
            border-left: 1px solid #8DB2E3 !important;
        }



        #grpLoaiBaoHiem {
            border-right: 1px solid #8DB2E3 !important;
        }
    </style>
    <script type="text/javascript">

        var CheckDuLieuDauVao = function () {
            if (ddfLoaiBienDong.getValue() == '') {
                alert('Bạn chưa chọn loại biến động');
                return false;
            }
            if (txtMaBienDong.getValue() == '') {
                txtMaBienDong.focus();
                alert('Bạn chưa nhập mã loại biến động');
                return false;
            }
            if (txtTenBienDong.getValue() == '') {
                alert('Bạn chưa nhập tên biến động');
                txtTenBienDong.focus();
                return false;
            }
            return true;
        }
        var CheckQuyDinhBienDong = function () {
            if (dfNgayHieuLuc.getValue() == '') {
                alert('Bạn chưa chọn ngày hiệu lực');
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="
                BangCheDoBaoHiem1_Store_cboCheDoBH.reload();QuyDinhBienDong1_Store_cboCheDoBH.reload();
            " />
            </Listeners>
        </ext:ResourceManager>
        <ext:Window runat="server" Hidden="true" ID="wdQuyDinhVeDoiTuongDongBaoHiem" Padding="0"
            Title="Thêm mới loại hợp đồng" Constrain="true" Modal="true" Icon="Add" Width="440"
            Resizable="false" AutoHeight="true">
            <Items>
                <ext:Panel runat="server" Padding="6" Height="185" Border="false">
                    <Items>
                        <ext:Container ID="Container6" runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                            <Content>
                                <ext:TextField runat="server" ID="TextField5" FieldLabel="Mã loại HD" Width="300">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="TextField6" FieldLabel="Tên loại HD" Width="300">
                                </ext:TextField>
                                <ext:NumberField runat="server" FieldLabel="Số tháng" Width="300">
                                </ext:NumberField>
                                <ext:CheckboxGroup ID="CheckboxGroup3" runat="server" Vertical="false" Width="300">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="Checkbox1" BoxLabel="BHYT">
                                        </ext:Checkbox>
                                        <ext:Checkbox runat="server" ID="Checkbox2" BoxLabel="BHXH">
                                        </ext:Checkbox>
                                        <ext:Checkbox runat="server" ID="Checkbox3" BoxLabel="BHTN">
                                        </ext:Checkbox>
                                    </Items>
                                </ext:CheckboxGroup>
                                <ext:TextArea runat="server" FieldLabel="Ghi chú" Width="300" Height="60">
                                </ext:TextArea>
                            </Content>
                        </ext:Container>
                    </Items>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="Button25" Text="Cập nhật" Icon="Disk">
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
                <ext:Button runat="server" ID="Button26" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckDuLieuDauVao();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuyDinhBienDong_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button27" Text="Đóng lại" Icon="Decline">
                </ext:Button>
            </Buttons>
        </ext:Window>
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
                <ext:Button runat="server" ID="btnUpdateQuyDinhBienDong" Text="Cập nhật" Icon="Disk">
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
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnClose" Text="Đóng lại" Icon="Decline">
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" Hidden="true" ID="wdCheDoBaoHiem" Padding="0" Title="Thêm mới chế độ bảo hiểm"
            Constrain="true" Modal="true" Icon="Add" Width="440" Resizable="false" AutoHeight="true">
            <Items>
                <ext:Panel ID="Panel6" Height="110" Padding="6" runat="server" Border="false">
                    <Items>
                        <ext:Container ID="Container7" runat="server" AnchorHorizontal="100%" Layout="FormLayout">
                            <Content>
                                <ext:TextField runat="server" ID="TextField7" FieldLabel="Mã chế độ" Width="300">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="TextField8" FieldLabel="Tên chế độ" Width="300">
                                </ext:TextField>
                                <ext:DropDownField runat="server" ID="DropDownField1" FieldLabel="Nhóm loại chế độ"
                                    Width="300">
                                </ext:DropDownField>
                            </Content>
                        </ext:Container>
                    </Items>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="Button28" Text="Cập nhật" Icon="Disk">
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
                <ext:Button runat="server" ID="Button29" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckDuLieuDauVao();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateQuyDinhBienDong_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button30" Text="Đóng lại" Icon="Decline">
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:FormPanel ID="FormPanel1" runat="server" Border="false" AnchorHorizontal="100%"
                            Title="Thông tin" Header="false" AutoScroll="true" Layout="BorderLayout">
                            <Items>
                                <ext:TabPanel ID="tabWrapper" Closable="false" Cls="bkGround" Region="Center" Padding="0"
                                    runat="server" AnchorHorizontal="100%" Border="false">
                                    <Items>
                                        <ext:Panel ID="Panel7" runat="server" Title="Quy định về mức đóng bảo hiểm">
                                            <Content>
                                                <uc5:QuyDinhVeMucDongBaoHiem ID="QuyDinhVeMucDongBaoHiem1" runat="server" />
                                            </Content>
                                        </ext:Panel>
                                        <ext:Panel ID="Panel3" runat="server" Title="Quy định về đối tượng đóng bảo hiểm">
                                            <Content>
                                                <uc4:QuyDinhVeDoiTuongDongBaoHiem ID="QuyDinhVeDoiTuongDongBaoHiem1" runat="server" />
                                            </Content>
                                        </ext:Panel>
                                        <ext:Panel ID="Panel2" runat="server" Title="Quy định về biến động bảo hiểm">
                                            <Content>
                                                <uc3:QuyDinhBienDong ID="QuyDinhBienDong1" runat="server" />
                                            </Content>
                                        </ext:Panel>
                                        <ext:Panel ID="Panel1" runat="server" Title="Chế độ bảo hiểm">
                                            <Content>
                                                <uc2:BangCheDoBaoHiem ID="BangCheDoBaoHiem1" runat="server" />
                                            </Content>
                                        </ext:Panel>
                                        <ext:Panel runat="server" Title="Bảng tính chế độ bảo hiểm" Padding="0">
                                            <Content>
                                                <uc1:BangTinhCheDoBaoHiem ID="BangTinhCheDoBaoHiem1" runat="server" />
                                            </Content>
                                        </ext:Panel>
                                    </Items>
                                </ext:TabPanel>
                            </Items>
                        </ext:FormPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </form>
</body>
</html>
