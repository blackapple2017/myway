<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GuiDonNghiPhep.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_GuiDonNghiPhep" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var CheckInput = function () {
            if (!dfTuNgay.getValue()) {
                alert('Bạn chưa chọn từ ngày');
                return false;
            }
            if (!dfDenNgay.getValue()) {
                alert('Bạn chưa chọn đến ngày');
                return false;
            }
            if (!txtLyDo.getValue()) {
                alert('Bạn chưa nhập lý do nghỉ');
                return false;
            }
            return true;
        }
        var resetForm = function () {
            dfTuNgay.reset();
            dfDenNgay.reset();
            txtLyDo.reset();
            txtLyDo.reset();
            cbonhanvien.reset();
            dfTuNgay.setMinValue();
            dfDenNgay.setMinValue();
            dfTuNgay.setMaxValue();
            dfDenNgay.setMaxValue();
        }
        var RenderTrangThaiDuyet = function (value, p, record) {
            var str = '';
            if (value == 'ChuaDuyet') str = 'Chưa duyệt';
            if (value == 'DaDuyet') str = 'Đã duyệt';
            if (value == 'KhongDuyet') str = 'Không duyệt';
            return str;
        }
    </script>
    <style type="text/css">
        .search-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }
        .westDonXinNghi .x-layout-collapsed-west
        {
            background: url(../../Resource/images/CacDonDaGui.png) no-repeat center;
        }
        .search-item h3
        {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }
        
        .search-item h3 span
        {
            float: right;
            font-weight: normal;
            margin: 0 0 5px 5px;
            width: 100px;
            display: block;
            clear: none;
        }
        
        p
        {
            width: 650px;
        }
        
        .ext-ie .x-form-text
        {
            position: static !important;
        }
        div#wrapper
        {
            padding: 10px;
            width: 700px;
            margin: 0px auto;
        }
        #pnlThu_Content
        {
            border-left: 1px solid #99bbe8 !important;
        }
        #pnlDonXinNghi
        {
            border-right: 1px solid #99bbe8 !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <ext:ResourceManager runat="server" ID="RM" />
    <ext:Hidden runat="server" ID="hdfMaDonVi" />
    <ext:Hidden runat="server" ID="hdfMaCanBo" />
    <ext:Store runat="server" ID="grpDanhSachDonNghiPhepStore">
        <Proxy>
            <ext:HttpProxy Url="Handler/HandlerGuiDonNghiPhep.ashx" Json="true" Method="GET" />
        </Proxy>
        <AutoLoadParams>
            <ext:Parameter Name="Start" Value="={0}" />
            <ext:Parameter Name="Limit" Value="={10}" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="SearchKey" Value="''" Mode="Raw" />
            <ext:Parameter Name="MaCB" Value="#{hdfMaCanBo}.getValue()" Mode="Raw" />
        </BaseParams>
        <Reader>
            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="MaCB" />
                    <ext:RecordField Name="NghiTuNgay" />
                    <ext:RecordField Name="NghiDenNgay" />
                    <ext:RecordField Name="LyDoNghi" />
                    <ext:RecordField Name="TrangThaiDuyet" />
                    <ext:RecordField Name="MaCBDangDuyet" />
                    <ext:RecordField Name="TenCBDangDuyet" />
                    <ext:RecordField Name="TenPhongCBDangDuyet" />
                    <ext:RecordField Name="SoNgayNghi" />
                    <ext:RecordField Name="NgayNopDon" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <div>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel runat="server" ID="pnlThu" Width="600" AutoScroll="true" Border="false">
                            <Content>
                                <div id="wrapper">
                                    <center>
                                        <div style="line-height: 25px; font-weight: bold;">
                                            <p>
                                                CỘNG HÒA XÃ HỘI CHỦ NGHĨA VIỆT NAM
                                            </p>
                                            <p>
                                                Độc lập - Tự do - Hạnh phúc</p>
                                            <p style="font-weight: bold; font-size: larger">
                                                ĐƠN XIN NGHỈ PHÉP</p>
                                        </div>
                                    </center>
                                    <br />
                                    Kính gửi: Ban lãnh đạo (Bộ phận tổ chức hành chính)<br />
                                    <table border="0" cellpadding="5" cellspacing="5">
                                        <tr>
                                            <td>
                                                Họ tên:
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtTen" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Giới tính :
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtGioiTinh" Width="100" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Ngày sinh :
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtNgaySinh" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Địa chỉ thường trú:
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtDiaChi" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Điện thoại liên hệ khi cần:
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtDienThoai" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Đơn vị công tác:
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtDonViCongTac" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                Chức vụ:
                                            </td>
                                            <td>
                                                <ext:DisplayField runat="server" ID="txtChucVu" />
                                            </td>
                                        </tr>
                                    </table>
                                    <table border="0" cellpadding="5" cellspacing="5">
                                        <tr>
                                            <td colspan="2">
                                                <b style="font-style: italic;">Nay tôi làm đơn này xin đề nghị Ban lãnh đạo công ty
                                                    cho tôi được nghỉ phép</b>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td>
                                                <ext:DateField runat="server" ID="dfTuNgay" Vtype="daterange" AnchorHorizontal="99%"
                                                    FieldLabel="Từ ngày<span style='color:red'>*</span>" Width="300">
                                                </ext:DateField>
                                            </td>
                                            <td>
                                                <ext:DateField runat="server" ID="dfDenNgay" Vtype="daterange" AnchorHorizontal="99%"
                                                    FieldLabel="Đến ngày<span style='color:red'>*</span>" Width="300">
                                                </ext:DateField>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <ext:TextArea runat="server" ID="txtLyDo" Width="400" FieldLabel="Lý do<span style='color:red'>*</span>" />
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Nhập từ khóa để tìm kiếm"
                                                    DisplayField="HO_TEN" ValueField="MA_CB" LoadingText="Đang tìm kiếm..." AnchorHorizontal="99%"
                                                    PageSize="10" HideTrigger="false" ItemSelector="div.search-item" MinChars="1"
                                                    Note="Không chọn tức gửi thẳng tới phòng HCNS" ID="cbonhanvien" FieldLabel="Chọn người duyệt"
                                                    Width="300" LabelWidth="120">
                                                    <Store>
                                                        <ext:Store ID="Store1" runat="server" AutoLoad="false">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="Handler/ChonNhanVien.ashx" />
                                                            </Proxy>
                                                            <AutoLoadParams>
                                                                <ext:Parameter Name="Start" Value="={0}" />
                                                                <ext:Parameter Name="Limit" Value="={10}" />
                                                            </AutoLoadParams>
                                                            <BaseParams>
                                                                <ext:Parameter Name="MaDonVi" Value="#{hdfmadonvi}.getValue()" Mode="Raw" />
                                                            </BaseParams>
                                                            <Reader>
                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                    <Fields>
                                                                        <ext:RecordField Name="HO_TEN" />
                                                                        <ext:RecordField Name="MA_CB" />
                                                                        <ext:RecordField Name="TEN_PHONG" />
                                                                        <ext:RecordField Name="NGAY_SINH" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Template ID="Template3" runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                  <div class="search-item">
							                                 <h3>{HO_TEN}</h3>
							                                 {TEN_PHONG}</BR>
                                                            Ngày sinh: {NGAY_SINH:date("d/m/Y")}
						                                  </div>
					                                   </tpl>
                                                        </Html>
                                                    </Template>
                                                </ext:ComboBox>
                                            </td>
                                        </tr>
                                        <tr>
                                            <td colspan="2">
                                                <div style="float: right;">
                                                    Trân trọng !<br />
                                                    <b>
                                                        <ext:DisplayField runat="server" ID="txtNgayThangNam" />
                                                    </b>
                                                    <br />
                                                    <b>Người làm đơn</b><br />
                                                    <ext:DisplayField runat="server" ID="dpfNguoiLamDon" />
                                                </div>
                                            </td>
                                        </tr>
                                    </table>
                                </div>
                            </Content>
                            <BottomBar>
                                <ext:Toolbar runat="server" ID="tb1">
                                    <Items>
                                        <ext:Button runat="server" ID="btnNopDon" Text="Nộp đơn" Icon="ApplicationGo">
                                            <Listeners>
                                                <Click Handler="return CheckInput();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnNopDonClick">
                                                    <Confirmation Title="Thông báo" Message="Đơn xin nghỉ của bạn sẽ được gửi đến cán bộ duyệt.<br /> Bạn có chắc chắn gửi?"
                                                        ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </BottomBar>
                        </ext:Panel>
                    </Center>
                    <West Split="false">
                        <ext:Panel ID="pnlDonXinNghi" CtCls="westDonXinNghi" Collapsed="true" Collapsible="true"
                            Border="false" runat="server" Title="Các đơn phép đã gửi" Width="335" AnchorVertical="100%"
                            Layout="BorderLayout">
                            <Items>
                                <ext:GridPanel runat="server" ID="grpDanhSachDonNghiPhep" AutoExpandColumn="col1"
                                    TrackMouseOver="true" StoreID="grpDanhSachDonNghiPhepStore" AnchorVertical="100%"
                                    Region="Center" Border="false">
                                    <ColumnModel>
                                        <Columns>
                                            <ext:TemplateColumn ColumnID="col1">
                                                <Template runat="server">
                                                    <Html>
                                                        <div style='line-height: 18px;'>
                                                             Nghỉ từ 
                                                                    <b> {NghiTuNgay:date("d/m/Y")}</b> đến  
                                                                    <b>{NghiDenNgay:date("d/m/Y")}</b>
                                                                    <br />
                                                            Lý do :
                                                                <b>{LyDoNghi}</b>
                                                                            <br />
                                                            Ngày nộp đơn
                                                                    <b> {NgayNopDon:date("d/m/Y")}</b>
                                                                    <br /> 
                                                            Người duyệt:
                                                                <b>{TenCBDangDuyet}({TenPhongCBDangDuyet})</b>
                                                                <br />  
                                                            Trạng thái :
                                                            <b>{TrangThaiDuyet}</b>
                                                        </div>
                                                    </Html>
                                                </Template>
                                            </ext:TemplateColumn>
                                        </Columns>
                                    </ColumnModel>
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                            PageSize="10" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                            DisplayMsg="{0} đến {1} / {2}" runat="server">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </West>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
