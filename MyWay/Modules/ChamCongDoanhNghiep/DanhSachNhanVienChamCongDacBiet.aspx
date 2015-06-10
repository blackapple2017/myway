<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachNhanVienChamCongDacBiet.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_DanhSachNhanVienChamCongDacBiet" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc1" %>
<%@ Register Src="~/Modules/ChooseEmployee/ucChooseEmployee.ascx" TagPrefix="uc1"
    TagName="ucChooseEmployee" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #grpDanhSachNhanVienChamCongDacBiet_GridPanel1
        {
            border-left: 1px solid #8DB2E3 !important;
        }
        #grpDanhSachNhanVienChamCongDacBiet_pnlCoCauToChuc-xsplit
        {
            border-right: none !important;
        }
    </style>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var checkInput = function () {
            if (!tgfMaCanBo.getValue()) {
                alert('Bạn chưa chọn cán bộ');
                return false;
            }
            if (!cbbSoLanChitTay.getValue()) {
                alert('Bạn chưa chọn số lần chít tay');
                return false;
            }
            return true;
        }
        var resetForm = function () {
            tgfMaCanBo.reset();
            txtHoTen.reset();
            cbbSoLanChitTay.reset();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ucChooseEmployee runat="server" ID="ucChooseEmployee1" />
        <ext:Menu runat="server" ID="RowContextMenu">
            <Items>
                <ext:MenuItem ID="Button1" runat="server" Text="Thêm nhân viên" Icon="UserAdd">
                    <DirectEvents>
                        <Click OnEvent="btnThemClick">
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="Button2" runat="server" Text="Sửa" Icon="Pencil">
                    <DirectEvents>
                        <Click OnEvent="btnSuaClick">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="Button3" runat="server" Text="Xóa" Icon="Delete">
                    <%--  <Listeners>
                            <Click Handler="RemoveItemOnGrid(grpNghiDaiNgay,grpNghiDaiNgayStore);" />
                        </Listeners>--%>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="400" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm đối tượng chấm công đặc biệt"
            Icon="Add">
            <Items>
                <ext:TriggerField runat="server" ID="tgfMaCanBo" AnchorHorizontal="99%" AllowBlank="false"
                    FieldLabel="Mã cán bộ<span style='color:red'>*</span>" Editable="false" EmptyText="Chọn cán bộ">
                    <Triggers>
                        <ext:FieldTrigger Icon="SimpleMagnify" />
                    </Triggers>
                    <Listeners>
                        <TriggerClick Handler="#{wdChooseUser}.show();" />
                    </Listeners>
                </ext:TriggerField>
                <ext:TextField runat="server" ID="txtHoTen" Disabled="true" FieldLabel="Họ tên" AnchorHorizontal="99%">
                </ext:TextField>
                <ext:ComboBox runat="server" ID="cbbSoLanChitTay" FieldLabel="Số lần quẹt thẻ<span style='color:red'>*</span>"
                    AnchorHorizontal="99%" Editable="false">
                    <Items>
                        <ext:ListItem Text="Không phải quẹt thẻ" Value="0" />
                        <ext:ListItem Text="Quẹt thẻ 1 lần" Value="1" />
                    </Items>
                </ext:ComboBox>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatThem" Text="Cập nhật" Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return checkInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatThem_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatSua" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return checkInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatSua_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatThemVaDongLai" runat="server" Text="Cập nhật & Đóng lại"
                    Icon="Disk" Hidden="true">
                    <Listeners>
                        <Click Handler="return checkInput();" />
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
                <Hide Handler="resetForm();" />
            </Listeners>
        </ext:Window>
        <%--<ext:Button runat="server" Icon="Add" Hidden="true" ID="btnThem" Text="fsdf">
                <DirectEvents>
                    <Click OnEvent="btnThem_Click"
                        After="hdfLoaiCapNhat.setValue('Them');#{btnLuuThem}.show();#{btnLuuSua}.hide();#{btnLuuThemDong}.show();"
                        Before="wdAddWindow.show();" />
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" Icon="Pencil" Hidden="true" ID="btnSua" Text="dsfsdf">
                <DirectEvents>
                    <Click OnEvent="btnSua_Click"
                        After="hdfLoaiCapNhat.setValue('Sua');#{btnLuuThem}.show();#{btnLuuSua}.hide();#{btnLuuThemDong}.show();"
                        Before="wdAddWindow.show();">
                    </Click>
                </DirectEvents>
            </ext:Button>--%>
        <uc1:SingleGridPanel ID="grpDanhSachNhanVienChamCongDacBiet" GroupField="SoLanChitTay"
            ColumnName="MaCB,HO_TEN,MA_GIOITINH,NGAY_SINH,TEN_DONVI,TEN_CHUCVU,TEN_CONGVIEC,SoLanChitTay,ID"
            ColumnHeader="Mã cán bộ, Họ tên, Giới tính,Ngày sinh,Bộ phận,Chức vụ,Vị trí công việc, Số lần quẹt thẻ, ID"
            ColumnWidth="MaCB=70,HO_TEN=150,MA_GIOI_TINH=60,NGAY_SINH=70, TEN_DONVI=200,TEN_CONGVIEC=120, SoLanChitTay=100,TEN_CHUCVU=150"
            OrderBy="TEN_CB,HO_TEN" SearchField="MaCB,HO_TEN" EmptyTextSearch="Nhập mã, tên cán bộ..."
            EnableWestPanelFilter="true" MaDonViColumn="MA_DONVI" Render="MA_GIOITINH=GetGender"
            TableForDeleting="ChamCong.DanhSachNhanVienChamCongDacBiet" TableOrViewName="v_DanhSachNhanVienChamCongDacBiet"
            IDProperty="ID" runat="server" HideGrouped="true" />
    </div>
    </form>
</body>
</html>
