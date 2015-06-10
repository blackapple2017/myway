<%@ Page Language="C#" AutoEventWireup="true" CodeFile="XemCheDoTheoThang.aspx.cs"
    Inherits="Modules_BaoHiem_XemCheDoTheoThang" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var RenderSoNam = function (value, p, record) {

            if (value == null || value == "") {
                return "0" + " tháng";
            }
            var nam = parseInt(value / 12);
            var sothang = value % 12;
            if (nam == 0) {
                value = sothang + " tháng";
            }
            else {
                value = nam + " năm " + sothang + " tháng";
            }
            return value;
        }
        var keyEnterspinNam = function (f, e) {
            if (e.getKey() == e.ENTER) {
                grpCheDoTheoThangStore.reload();
            }
            if (this.getValue != '') {
                this.triggers[0].show();
            }
        }
    </script>
    <script src="../../../Resource/js/RenderJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" ID="RM" />
    <ext:Hidden runat="server" ID="hdfMaDonVi">
    </ext:Hidden>
    <ext:Store ID="grpCheDoTheoThangStore" AutoLoad="true" runat="server" GroupField="Thang"
        GroupDir="DESC">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="HandlerNhanVienCheDoTheoThang.ashx" />
        </Proxy>
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={15}">
            </ext:Parameter>
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
            <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
            <ext:Parameter Name="Thang" Value="#{cbbThang}.getValue()" Mode="Raw" />
            <ext:Parameter Name="Nam" Value="#{spinNam}.getValue()" Mode="Raw" />
        </BaseParams>
        <Reader>
            <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDQuyDinhBienDong">
                <Fields>
                    <ext:RecordField Name="IDChiTietCheDoBaoHiem" />
                    <ext:RecordField Name="IDBangTinhCheDoBaoHiem" />
                    <ext:RecordField Name="IDNhanVien_BaoHiem" />
                    <ext:RecordField Name="MaCheDo" />
                    <ext:RecordField Name="TenCheDo" />
                    <ext:RecordField Name="DieuKienHuong" />
                    <ext:RecordField Name="MaNhanVien" />
                    <ext:RecordField Name="HoTen" />
                    <ext:RecordField Name="PhongBan" />
                    <ext:RecordField Name="NgayBatDau" />
                    <ext:RecordField Name="NgayKetThuc" />
                    <ext:RecordField Name="TienLuongTinhHuong" />
                    <ext:RecordField Name="SoNgayNghi" />
                    <ext:RecordField Name="SoTienDeNghi" />
                    <ext:RecordField Name="TinhTrangThanhToan" />
                    <ext:RecordField Name="Thang" />
                    <ext:RecordField Name="GhiChu" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <%--<ext:Window runat="server" ID="wdBienDongBaoHiem" Modal="true" Layout="FormLayout"
            Width="600" Constrain="true" Title="Quản lý biến động bảo hiểm CBCNV" Hidden="true"
            Icon="Add" AutoHeight="true">
            <Items>
                <ext:TabPanel runat="server" ID="tabPanel" Border="false">
                    <Items>
                        <ext:Panel ID="pnlThongTinChung" runat="server" Title="<%$ Resources:HOSO, ThongTinChung%>">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfCommandButton" Text="Insert" />
                                <ext:FieldSet ID="fs_ThongTinCanBo" runat="server" Title="Thông tin cán bộ" Layout="ColumnLayout"
                                    Height="130" Border="true">
                                    <Items>
                                        <ext:Container ID="Container1" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                                            <Items>
                                                <ext:TriggerField runat="server" ID="txtMaCanBo" AnchorHorizontal="99%" AllowBlank="false"
                                                    FieldLabel="<%$ Resources:HOSO, staff_code%>" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="SimpleMagnify" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <TriggerClick Handler="BHNHANVIEN_BAOHIEM1_wdChooseUser.show();" />
                                                    </Listeners>
                                                </ext:TriggerField>
                                                <ext:DropDownField runat="server" ID="ddfPhongBan" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="Tên phòng ban">
                                                </ext:DropDownField>
                                                <ext:NumberField runat="server" ID="nfSoCMND" AnchorHorizontal="99%" Disabled="true"
                                                    FieldLabel="Số CMND">
                                                </ext:NumberField>
                                                <ext:DateField runat="server" ID="dfNgaySinh" AnchorHorizontal="99%" Disabled="true"
                                                    FieldLabel="<%$ Resources:HOSO, staff_birthday%>">
                                                </ext:DateField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container2" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtHoTen" Disabled="true" AnchorHorizontal="99%"
                                                    AllowBlank="false" FieldLabel="<%$ Resources:HOSO, staff_name%>">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtsosobhxh" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="Số sổ BHXH">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtDiaChi" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="Địa chỉ">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtThoiGianDongBaoHiem" Disabled="true" AnchorHorizontal="99%"
                                                    FieldLabel="Thời gian đóng">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                                <ext:FieldSet ID="fs_ThongTinBienDong" runat="server" Title="Thông tin biến động"
                                    Layout="FormLayout" Height="135" Border="true">
                                    <Items>
                                        <ext:Container ID="Container3" runat="server" AnchorHorizontal="99%" Layout="ColumnLayout"
                                            Height="55">
                                            <Items>
                                                <ext:Container ID="Container4" runat="server" ColumnWidth=".5" Layout="FormLayout">
                                                    <Items>
                                                        <ext:TriggerField runat="server" ID="ddfLoaiBienDong" AnchorHorizontal="99%" AllowBlank="false"
                                                            FieldLabel="Chọn biến động" Editable="false">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="SimpleMagnify" />
                                                            </Triggers>
                                                            <Listeners>
                                                                <TriggerClick Handler="#{wdChonLoaiBienDong}.show();" />
                                                            </Listeners>
                                                        </ext:TriggerField>
                                                        <ext:DateField runat="server" ID="dfTuNgay" AnchorHorizontal="99%" FieldLabel="Từ ngày">
                                                        </ext:DateField>
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container5" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                                    Height="25">
                                                    <Items>
                                                        <ext:Container ID="Container6" runat="server" Layout="HBoxLayout">
                                                            <Items>
                                                                <ext:Checkbox runat="server" LabelWidth="100" FieldLabel="Trạng thái đóng" BoxLabel="BHXH"
                                                                    ID="chkTTBHXH" >
                                                                </ext:Checkbox>
                                                                <ext:Checkbox runat="server" LabelWidth="5" FieldLabel=" " LabelSeparator=" " BoxLabel="BHYT"
                                                                    ID="chkTTBHYT">
                                                                </ext:Checkbox>
                                                                <ext:Checkbox runat="server" LabelWidth="5" FieldLabel=" " LabelSeparator=" " BoxLabel="BHTN"
                                                                    ID="chkTTBHTN">
                                                                </ext:Checkbox>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:DateField runat="server" ID="dfDenNgay" AnchorHorizontal="99%" FieldLabel="Đến ngày">
                                                        </ext:DateField>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:TextArea runat="server" ID="txaDienGiai" FieldLabel="Diễn giải" AnchorHorizontal="99%"
                                            Height="50">
                                        </ext:TextArea>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="pnlThongTinLuong" runat="server" Title="Thông tin lương" Hidden="true">
                            <Items>
                                <ext:FieldSet ID="fs_ThongTinLuong" runat="server" Title="" Layout="ColumnLayout"
                                    Height="275" Border="true">
                                    <Items>
                                        <ext:Container runat="server" Height="230" ColumnWidth=".33" Layout="FormLayout"
                                            LabelWidth="150">
                                            <Items>
                                                <ext:DisplayField runat="server" FieldLabel=" " LabelSeparator=" " AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField runat="server" FieldLabel="Lương đóng BHXH" AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField runat="server" FieldLabel="Phụ cấp chức vụ" AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField runat="server" FieldLabel="Phụ cấp TNVK" AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                                <ext:DisplayField runat="server" FieldLabel="Phụ cấp Nghề" AnchorHorizontal="99%">
                                                </ext:DisplayField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" Height="230" ColumnWidth=".33" Layout="FormLayout"
                                            HideLabels="true">
                                            <Items>
                                                <ext:DisplayField runat="server" Text="Thông tin cũ" AnchorHorizontal="100%">
                                                </ext:DisplayField>
                                                <ext:TextField runat="server" ID="txtLuongDongBHXHCu" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapCVCu" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNVKCu" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNNCu" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" Height="230" ColumnWidth=".33" Layout="FormLayout"
                                            HideLabels="true">
                                            <Items>
                                                <ext:DisplayField ID="DisplayField5" runat="server" Text="Thông tin mới" AnchorHorizontal="100%"
                                                    LabelWidth="3">
                                                </ext:DisplayField>
                                                <ext:TextField runat="server" ID="txtLuongDongBHXHMoi" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapCVMoi" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNVKMoi" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                                <ext:TextField runat="server" ID="txtPhuCapTNNMoi" AnchorHorizontal="95%" MaskRe="/[0-9\.]/"
                                                    LabelWidth="3">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                        <ext:Panel ID="pnlTruyThoaithu" runat="server" Title="Truy thu/Thoái thu" Hidden="true">
                            <Items>
                                <ext:FieldSet ID="fs_TruyThoaiThu" runat="server" Title="Truy/Thoái thu" Layout="FormLayout"
                                    Height="275" Border="true">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkTrangThai" FieldLabel="Trạng thái" AnchorHorizontal="99%"
                                            BoxLabel="Đã đăng ký với CQBH" Height="30">
                                        </ext:Checkbox>
                                        <ext:Container ID="Container13" runat="server" Layout="HBoxLayout" Height="30">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Tháng đăng ký" LabelWidth="100" Editable="false"
                                                    SelectedIndex="0" ID="cbbThangBHXH" Width="200">
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
                                                <ext:DisplayField ID="DisplayField3" runat="server" FieldLabel="Năm" LabelWidth="40"
                                                    LabelAlign="Right">
                                                </ext:DisplayField>
                                                <ext:SpinnerField ID="spinNamBHXH" runat="server" Width="60" MinValue="1900" MaxValue="2100">
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container10" runat="server" Layout="HBoxLayout" Height="30">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Từ tháng" LabelWidth="100" Editable="false"
                                                    SelectedIndex="0" ID="cbbTuThang" Width="200">
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
                                                <ext:DisplayField ID="DisplayField1" runat="server" FieldLabel="Năm" LabelAlign="Right"
                                                    LabelWidth="40">
                                                </ext:DisplayField>
                                                <ext:SpinnerField ID="spinTuNam" runat="server" Width="60" MinValue="1900" MaxValue="2100">
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container11" runat="server" Layout="HBoxLayout" Height="30">
                                            <Items>
                                                <ext:ComboBox runat="server" FieldLabel="Đến tháng" LabelWidth="100" Editable="false"
                                                    SelectedIndex="0" ID="cbbDenThang" Width="200">
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
                                                <ext:DisplayField ID="DisplayField4" runat="server" FieldLabel="Năm" LabelWidth="40"
                                                    LabelAlign="Right">
                                                </ext:DisplayField>
                                                <ext:SpinnerField ID="spinDenNam" runat="server" Width="60" MinValue="1900" MaxValue="2100">
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container14" runat="server" AnchorHorizontal="99%" Layout="HBoxLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="chkBHXH" FieldLabel="BHXH">
                                                </ext:Checkbox>
                                                <ext:NumberField LabelWidth="50" runat="server" ID="nfSoTienBHXH" FieldLabel="<%$ Resources:QuanLyThoiViec, SoTien%>">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container15" runat="server" AnchorHorizontal="99%" Layout="HBoxLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="chkBHYT" FieldLabel="BHYT">
                                                </ext:Checkbox>
                                                <ext:NumberField LabelWidth="50" runat="server" ID="nfSoTienBHYT" FieldLabel="<%$ Resources:QuanLyThoiViec, SoTien%>">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container16" runat="server" AnchorHorizontal="99%" Layout="HBoxLayout"
                                            Height="30">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="chkBHTN" FieldLabel="BHTN">
                                                </ext:Checkbox>
                                                <ext:NumberField LabelWidth="50" runat="server" ID="nfSoTienBHTN" FieldLabel="<%$ Resources:QuanLyThoiViec, SoTien%>">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhat" runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckThemMoi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_addclick" After="ResetControl();">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Icon="Disk" Text="<%$ Resources:Language, update%>" ID="btnUpdateEdit" Hidden="true">
                </ext:Button>
                <ext:Button ID="btn_InsertandClose" runat="server" Text="<%$ Resources:Language, update_close%>" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckThemMoi();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="bt_addclick">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button6" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdThemSuaBienDongNhanVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetControl();" />
            </Listeners>
        </ext:Window>--%>
    <ext:Window runat="server" ID="wdXemTheoThangThem" Modal="true" Layout="FormLayout"
        Width="600" Padding="6" Constrain="true" Title="Quản lý chế độ bảo hiểm" Hidden="true"
        Icon="Add" AutoHeight="true">
        <Items>
            <ext:Hidden runat="server" ID="hdfCommandButton" Text="Insert" />
            <ext:FieldSet ID="fs_ThongTinCanBo" runat="server" Title="Thông tin cán bộ" Layout="ColumnLayout"
                Height="130" Border="true">
                <Items>
                    <ext:Container ID="Container1" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                        <Items>
                            <ext:TriggerField runat="server" ID="txtMaCanBo" AnchorHorizontal="99%" AllowBlank="false"
                                FieldLabel="<%$ Resources:HOSO, staff_code%>" Editable="false">
                                <Triggers>
                                    <ext:FieldTrigger Icon="SimpleMagnify" />
                                </Triggers>
                                <Listeners>
                                    <TriggerClick Handler="BHNHANVIEN_BAOHIEM1_wdChooseUser.show();" />
                                </Listeners>
                            </ext:TriggerField>
                            <ext:DropDownField runat="server" ID="ddfPhongBan" AnchorHorizontal="99%" FieldLabel="Tên phòng ban">
                            </ext:DropDownField>
                            <ext:NumberField runat="server" ID="nfSoCMND" AnchorHorizontal="99%" FieldLabel="Số CMND">
                            </ext:NumberField>
                            <ext:DateField runat="server" ID="dfNgaySinh" AnchorHorizontal="99%" FieldLabel="<%$ Resources:HOSO, staff_birthday%>">
                            </ext:DateField>
                        </Items>
                    </ext:Container>
                    <ext:Container ID="Container2" runat="server" Height="130" ColumnWidth=".5" Layout="FormLayout">
                        <Items>
                            <ext:TextField runat="server" ID="txtHoTen" AnchorHorizontal="99%" AllowBlank="false"
                                FieldLabel="<%$ Resources:HOSO, staff_name%>">
                            </ext:TextField>
                            <ext:TextField runat="server" ID="txtSoDienThoai" AnchorHorizontal="99%" FieldLabel="Số điện thoại">
                            </ext:TextField>
                            <ext:TextField runat="server" ID="txtDiaChi" AnchorHorizontal="99%" FieldLabel="Địa chỉ">
                            </ext:TextField>
                            <ext:TextField runat="server" ID="txtThoiGianDongBaoHiem" AnchorHorizontal="99%"
                                FieldLabel="Thời gian đóng">
                            </ext:TextField>
                        </Items>
                    </ext:Container>
                </Items>
            </ext:FieldSet>
            <ext:FieldSet ID="fs_ThongTinCheDo" runat="server" Title="Thông tin chế độ" Layout="FormLayout"
                Height="220" Border="true">
                <Items>
                    <ext:Container ID="Container3" runat="server" AnchorHorizontal="99%" Layout="ColumnLayout"
                        Height="145">
                        <Items>
                            <ext:Container ID="Container4" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                Height="145">
                                <Items>
                                    <ext:DropDownField runat="server" ID="ddfCheDo" AnchorHorizontal="99%" FieldLabel="Chế độ">
                                    </ext:DropDownField>
                                    <ext:DateField runat="server" ID="dfNgayBatDau" AnchorHorizontal="99%" FieldLabel="Ngày bắt đầu">
                                    </ext:DateField>
                                    <ext:Container ID="Container5" runat="server" AnchorHorizontal="99%" Layout="ColumnLayout"
                                        Height="40">
                                        <Items>
                                            <ext:Container ID="Container6" runat="server" ColumnWidth=".70" Layout="FormLayout">
                                                <Items>
                                                    <ext:TextField runat="server" ID="nfSoNgay" FieldLabel="Số ngày/Lũy kế" AnchorHorizontal="99%"
                                                        MaskRe="/[0-9\.]/">
                                                    </ext:TextField>
                                                </Items>
                                            </ext:Container>
                                            <ext:Container ID="Container7" runat="server" ColumnWidth=".30" Layout="HBoxLayout">
                                                <Items>
                                                    <ext:TextField runat="server" ID="nfLuyKe" AnchorHorizontal="90%" LabelWidth="6"
                                                        LabelSeparator="/" FieldLabel=" " Width="78" MaskRe="/[0-9\.]/">
                                                    </ext:TextField>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:Container>
                                    <ext:TextField runat="server" AnchorHorizontal="99%" ID="nfSoTienDeNghi" FieldLabel="Số tiền đề nghị">
                                    </ext:TextField>
                                    <ext:Checkbox runat="server" AnchorHorizontal="99%" ID="chkTinhTrangThanhToan" BoxLabel="Đã thanh toán">
                                    </ext:Checkbox>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="Container8" runat="server" ColumnWidth=".5" Layout="FormLayout"
                                Height="135">
                                <Items>
                                    <ext:DropDownField runat="server" ID="ddfDieuKienHuong" AnchorHorizontal="99%" FieldLabel="Điều kiện hưởng">
                                    </ext:DropDownField>
                                    <ext:DateField runat="server" ID="dfNgayKetThuc" AnchorHorizontal="99%" FieldLabel="Ngày kết thúc">
                                    </ext:DateField>
                                    <ext:NumberField runat="server" ID="nfLuongDongBH" AnchorHorizontal="99%" FieldLabel="Lương đóng BH"
                                        Disabled="true">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" ID="nfMucDoSuyGiamKNLD" AnchorHorizontal="99%" FieldLabel="Mức độ suy giảm KNLĐ"
                                        Hidden="true">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextArea runat="server" AnchorHorizontal="99%" ID="txaGhiChu" FieldLabel="Ghi chú"
                        Height="40">
                    </ext:TextArea>
                </Items>
            </ext:FieldSet>
        </Items>
        <Buttons>
            <ext:Button ID="btnCapNhat" runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk">
                <%--<Listeners>
                            <Click Handler="return ValidateInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btn_InsertandClose_Click" After="Ext.net.DirectMethods.GeneratePrimaryKey(); ResetControl();">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>--%>
            </ext:Button>
            <ext:Button runat="server" Icon="Disk" Text="<%$ Resources:Language, update%>" ID="btnUpdateEdit">
                <%--  <Listeners>
                            <Click Handler="return ValidateInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btn_InsertandClose_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Edit">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>--%>
            </ext:Button>
            <ext:Button ID="btn_InsertandClose" runat="server" Text="<%$ Resources:Language, update_close%>" Icon="Disk">
                <%--<Listeners>
                            <Click Handler="return ValidateInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btn_InsertandClose_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>--%>
            </ext:Button>
            <ext:Button ID="btnTuCapNhat" Hidden="true" runat="server" Text="<%$ Resources:Language, update%>" Icon="Disk">
                <%--  <Listeners>
                            <Click Handler="return ValidateInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btn_InsertandClose_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False">
                                    </ext:Parameter>
                                    <ext:Parameter Name="TuCapNhat" Value="True">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>--%>
            </ext:Button>
            <ext:Button ID="Button6" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Delete">
                <Listeners>
                    <Click Handler="#{wdCheDoBaoHiem}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
    </ext:Window>
    <ext:Viewport runat="server" ID="vp">
        <Items>
            <ext:BorderLayout runat="server" ID="BorderLayout1">
                <Center>
                    <ext:Panel ID="Panel1" runat="server" AnchorHorizontal="99%" AnchorVertical="99%"
                        Border="false">
                        <Items>
                            <ext:RowLayout ID="RowLayout2" runat="server" Split="false" AnchorHorizontal="99%"
                                AnchorVertical="99%">
                                <Rows>
                                    <ext:LayoutRow runat="server" RowHeight="0.65">
                                        <Items>
                                            <ext:Panel ID="Panel4" runat="server" AnchorHorizontal="99%" AnchorVertical="99%"
                                                Layout="BorderLayout" Border="false">
                                                <Items>
                                                    <ext:GridPanel runat="server" ID="grpCheDoTheoThang" Border="false" AnchorHorizontal="99%"
                                                        AnchorVertical="99%" StripeRows="true" TrackMouseOver="false" Region="Center"
                                                        AutoScroll="true" StoreID="grpCheDoTheoThangStore" AutoExpandMin="230">
                                                        <TopBar>
                                                            <ext:Toolbar ID="Toolbar1" runat="server">
                                                                <Items>
                                                                    <ext:ComboBox runat="server" FieldLabel="Chọn tháng" EmptyText="Chọn tháng" LabelWidth="60"
                                                                        Editable="false" ID="cbbThang" Width="150">
                                                                        <Items>
                                                                            <ext:ListItem Text="Cả năm" Value="0" />
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
                                                                        <Triggers>
                                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        </Triggers>
                                                                        <Listeners>
                                                                            <Select Handler="if(spinNam.getValue()>0) grpCheDoTheoThangStore.reload();" />
                                                                            <%--<TriggerClick Handler="cbbThang.reset(); cbbThang.clear(); this.triggers[0].hide(); grpCheDoTheoThangStore.reload(); " />--%>
                                                                        </Listeners>
                                                                    </ext:ComboBox>
                                                                    <ext:ToolbarSeparator ID="tbsNam" runat="server" />
                                                                    <ext:DisplayField runat="server" ID="dpF" Text="Chọn năm:" />
                                                                    <ext:ToolbarSpacer runat="server" Width="10">
                                                                    </ext:ToolbarSpacer>
                                                                    <ext:SpinnerField ID="spinNam" runat="server" Width="50" LabelWidth="40" MinValue="1900"
                                                                        MaxValue="2100">
                                                                        <Listeners>
                                                                            <Spin Handler="grpCheDoTheoThangStore.reload();" />
                                                                            <KeyPress Fn="keyEnterspinNam" />
                                                                        </Listeners>
                                                                    </ext:SpinnerField>
                                                                    <%--   <ext:Button runat="server" ID="btthem" Icon="Add" Text="Thêm mới"></ext:Button>
                                                                        <ext:Button runat="server" ID="btsua" Icon="Pencil" Text="<%$ Resources:CommonMessage, Edit%>"></ext:Button>
                                                                        <ext:Button runat="server" ID="btxoa" Icon="Delete" Text="<%$ Resources:Language, delete%>"></ext:Button>--%>
                                                                    <ext:ToolbarFill ID="ToolbarFill2" runat="server" />
                                                                    <ext:TriggerField runat="server" EnableKeyEvents="true" Width="250" ID="txtSearchKey"
                                                                        EmptyText="Tìm kiếm theo mã, tên nhân viên">
                                                                        <Triggers>
                                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                        </Triggers>
                                                                        <Listeners>
                                                                            <KeyPress Fn="keyEnterspinNam" />
                                                                            <TriggerClick Handler="this.clear(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                                        </Listeners>
                                                                    </ext:TriggerField>
                                                                    <ext:Button ID="Button9" runat="server" Text="<%$ Resources:Language, search%>" Icon="Zoom">
                                                                        <Listeners>
                                                                            <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                                        </Listeners>
                                                                    </ext:Button>
                                                                </Items>
                                                            </ext:Toolbar>
                                                        </TopBar>
                                                        <ColumnModel ID="ColumnModel4" runat="server">
                                                            <Columns>
                                                                <ext:RowNumbererColumn Header="STT" Width="30" Align="Left">
                                                                </ext:RowNumbererColumn>
                                                                <ext:Column ColumnID="colMaNhanVien" Width="100" DataIndex="MaNhanVien" Header="<%$ Resources:HOSO, staff_code%>">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTenCanBo" Width="150" DataIndex="HoTen" Header="<%$ Resources:HOSO, staff_name%>">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colPhongBan" Width="148" DataIndex="PhongBan" Header="<%$ Resources:HOSO, staff_section%>">
                                                                </ext:Column>
                                                                <%--      <ext:Column ColumnID="colMaCheDo" Width="140" DataIndex="MaCheDo"
                                                                        Header="Mã chế độ" Align="Right">
                                                                    </ext:Column>--%>
                                                                <ext:Column ColumnID="colTenCheDo" Width="250" DataIndex="TenCheDo" Header="Tên chế độ">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colDieuKienHuong" Width="230" DataIndex="DieuKienHuong" Header="Điều kiện hưởng">
                                                                </ext:Column>
                                                                <ext:DateColumn ColumnID="colNgayBatDau" Width="100" DataIndex="NgayBatDau" Header="Ngày bắt đầu"
                                                                    Format="dd/MM/yyyy">
                                                                </ext:DateColumn>
                                                                <ext:DateColumn ColumnID="colNgayKetThuc" Width="100" DataIndex="NgayKetThuc" Header="Ngày kết thúc"
                                                                    Format="dd/MM/yyyy">
                                                                </ext:DateColumn>
                                                                <ext:Column ColumnID="colSoNgaynghi" Width="100" DataIndex="SoNgayNghi" Header="Số ngày nghỉ"
                                                                    Align="Right">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colTienLuongTinhHuong" Width="131" DataIndex="TienLuongTinhHuong"
                                                                    Header="Tiền lương tính hưởng" Align="Right">
                                                                    <Renderer Fn="RenderVND" />
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colSoTienDeNghi" Width="100" DataIndex="SoTienDeNghi" Header="Số tiền đề nghị"
                                                                    Align="Right">
                                                                    <Renderer Fn="RenderVND" />
                                                                </ext:Column>
                                                                <ext:CheckColumn ColumnID="colTinhTrangThanhToan" DataIndex="TinhTrangThanhToan"
                                                                    Header="Tình trạng thanh toán" Width="70">
                                                                </ext:CheckColumn>
                                                                <ext:Column ColumnID="colThang" DataIndex="Thang" Header="Tháng" Width="100">
                                                                </ext:Column>
                                                                <ext:Column ColumnID="colGhiChu" DataIndex="GhiChu" Header="<%$ Resources:QuanLyThoiViec, GhiChu%>" Width="150">
                                                                </ext:Column>
                                                            </Columns>
                                                        </ColumnModel>
                                                        <View>
                                                            <ext:GroupingView ID="GroupingView2" runat="server" ForceFit="false" MarkDirty="false"
                                                                ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                                            </ext:GroupingView>
                                                        </View>
                                                        <BottomBar>
                                                            <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                                                PageSize="15" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                                                DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                                                                <Items>
                                                                    <ext:Label ID="Label4" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                                                    <ext:ToolbarSpacer ID="ToolbarSpacer4" runat="server" Width="10" />
                                                                    <ext:ComboBox ID="ComboBox6" runat="server" Width="80">
                                                                        <Items>
                                                                            <ext:ListItem Text="15" />
                                                                            <ext:ListItem Text="30" />
                                                                            <ext:ListItem Text="50" />
                                                                            <ext:ListItem Text="70" />
                                                                            <ext:ListItem Text="100" />
                                                                        </Items>
                                                                        <SelectedItem Value="15" />
                                                                        <Listeners>
                                                                            <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                                        </Listeners>
                                                                    </ext:ComboBox>
                                                                </Items>
                                                            </ext:PagingToolbar>
                                                        </BottomBar>
                                                        <SelectionModel>
                                                            <ext:RowSelectionModel runat="server" ID="RowSelectionModel3">
                                                                <Listeners>
                                                                    <%-- <RowSelect Handler="#{Button1}.enable(); #{Button2}.disable();#{Button5}.disable(); #{hdfMaNhanVien}.setValue(#{RowSelectionModel2}.getSelected().id);grpChiTietNhanVienStore.reload();" />--%>
                                                                    <%--<RowSelect Handler="#{hdfNhomCha}.setValue(#{RowSelectionModel1}.getSelected().id);" />--%>
                                                                </Listeners>
                                                            </ext:RowSelectionModel>
                                                        </SelectionModel>
                                                        <LoadMask ShowMask="true" />
                                                        <LoadMask ShowMask="true" />
                                                    </ext:GridPanel>
                                                </Items>
                                            </ext:Panel>
                                        </Items>
                                    </ext:LayoutRow>
                                </Rows>
                            </ext:RowLayout>
                        </Items>
                    </ext:Panel>
                </Center>
                <%--  <South>
                    </South>--%>
            </ext:BorderLayout>
        </Items>
    </ext:Viewport>
    </form>
</body>
</html>
