<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachNgayLeTet.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_DanhSachNgayLeTet" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var renderDateType = function (value, p, record) {
            if (value == "1" || value == "True")
                return "<span style='color:blue'>Âm lịch</span>";
            else
                return "<span>Dương lịch</span>";
        }
        var checkInput = function () {
            if (!txtTenNgayLe.getValue()) {
                alert('Bạn chưa nhập tên ngày lễ, tết');
                txtTenNgayLe.focus();
                return false;
            }
            if (!cbbLoaiNgay.getValue()) {
                alert('Bạn chưa chọn loại ngày là âm lịch hay dương lịch');
                cbbLoaiNgay.focus();
                return false;
            }
            if(!txtNgay.getValue()||!txtThang.getValue()||txtNgay.getValue()*1>31||txtNgay.getValue()<1||txtThang.getValue()>12||txtThang.getValue<1)
            {
                alert('Ngày tháng nhập vào không đúng');
                txtNgay.focus();
                return false;
            } 
            return true;
        }
        var btnThemClick = function ()
        {
            wdAddWindow.setTitle("Thêm mới một ngày nghỉ lễ, tết");
            wdAddWindow.setIconClass("icon-add");
            btnCapNhatSua.hide(); btnCapNhatThem.show(); btnCapNhatThemVaDongLai.show(); wdAddWindow.show();
        }
        var resetForm = function () {
            txtTenNgayLe.reset();
            cbbLoaiNgay.reset();
            txtNgay.reset();
            txtThang.reset();
           // txtKyHieuChamCong.reset();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:Menu runat="server" ID="RowContextMenu">
                <Items>
                    <ext:MenuItem ID="Button1" runat="server" Text="Thêm mới" Icon="Add">
                            <Listeners>
                            <Click Handler="btnThemClick();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="Button2" runat="server" Text="Sửa" Icon="Pencil">
                        <DirectEvents>
                            <Click OnEvent="btnSuaClick">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuItem ID="Button3" runat="server" Text="Xóa" Icon="Delete">
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm đối tượng chấm công đặc biệt"
                LabelWidth="120">
                <Items>
                    <ext:TextField runat="server" ID="txtTenNgayLe" FieldLabel="Tên ngày lễ, tết<span style='color:red'>*</span>" AnchorHorizontal="99%" />
                    <ext:ComboBox runat="server" ID="cbbLoaiNgay" FieldLabel="Âm lịch/dương lịch<span style='color:red'>*</span>" Width="134"  Editable="false" >
                        <Items>
                            <ext:ListItem Value="False" Text="Dương lịch" />
                            <ext:ListItem Value="True" Text="Âm lịch" />
                        </Items>
                    </ext:ComboBox>
                    <ext:CompositeField runat="server" ID="cf1" FieldLabel="Ngày<span style='color:red'>*</span>" >
                        <Items>
                            <ext:TextField runat="server" ID="txtNgay" MaskRe="/[0-9]/" MaxLength="2"  Width="60" />
                            <ext:DisplayField runat="server" ID="dis1" Text="Tháng" />
                            <ext:TextField runat="server" ID="txtThang" MaskRe="/[0-9]/" MaxLength="2" Width="60" />
                        </Items>
                    </ext:CompositeField>
                    <%--<ext:TextField runat="server" ID="txtKyHieuChamCong"  FieldLabel="Ký hiệu chấm công<span style='color:red'>*</span>" Width="134"/>--%>
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
                    <ext:Button ID="btnCapNhatThemVaDongLai" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk" Hidden="true">
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
            <uc1:SingleGridPanel ID="grpDanhSachNgayLeTet" TableOrViewName="v_DanhSachNgayLe" TableForDeleting = "ChamCong.DanhSachNgayLe"
                Render="AmLich=renderDateType" ColumnWidth="TenNgayLe=250 " OrderBy="Thang,Ngay"
                IDProperty="ID" SearchField="TenNgayLe" ColumnHeader="ID, Tên ngày lễ, Ngày tháng,Loại ngày "
                ColumnName="ID,TenNgayLe,NgayThang,AmLich " runat="server" />
        </div>
    </form>
</body>
</html>
