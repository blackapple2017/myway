<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DuyetDonNghiPhep.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_DuyetDonNghiPhep" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var lsnDuyetClick = function () {

        }
        var lsnChuyenTiepClick = function () {

        }
        var renderTrangThaiDuyet = function (value, p, record) {
            var str = '';
            if (value == 'DaDuyet') {
                str = "Đã duyệt";
            }
            if (value == 'KhongDuyet') {
                str = "Không duyệt";
            }
            if (value == 'HoanTatThuTuc') {
                str = "Hoàn tất thủ tục";
            }
            if (value == 'ChuaDuyet') {
                str = "Chưa duyệt";
            }
            //if (value == 'DaDuyet') {
            //    str = "<span style='color:#000CFF'>Đã duyệt</span>";
            //}
            //if (value == 'KhongDuyet') {
            //    str = "<span style='color:#FF0000'>Không duyệt</span>";
            //}
            //if (value == 'ChuyenTiep') {
            //    str = "<span style='color:#FF16AD'>Chuyển tiếp</span>";
            //}
            //if (value == 'ChuaDuyet') {
            //    str = "<span style='color:#266D43'>Chưa duyệt</span>";
            //}
            return str;
        }
        var enterKeyPressSearchKey = function (f, e) {
            if (e.getKey() == e.ENTER) {
                grpDuyetDonXinNghiStore.reload();
                hdfIDDonXinNghi.setValue('');
                grpLichSuDonXinNghiStore.reload();
            }
        }
        var CheckInputDongYKhongDuyet = function () {
            if (!txtLyDoKhongDuyet.getValue()) { alert('Bạn chưa nhập lý do không duyệt'); return false; }
            return true;
        }
        var CheckInputHoanTatThuTuc = function () {
            if (!txtSoNgayNghi.getValue()) {
                alert('Bạn chưa nhập số ngày nghỉ');
                return false;
            }
            return true;
        }
        var CheckChonNhieuDong = function (grid) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn đơn xin nghỉ phép nào');
                return false;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một dòng');
                return false;
            }
            wdHoanTatThuTuc.show();
            return true;
        }
        var resetFormHoanTatThuTuc = function () {
            dfNghiTuNgay.reset(); dfNghiDenNgay.reset(); txtSoNgayNghi.reset;
            txtSoNgayNghiPhep.reset();
            txtSoNgayNghiTruLuong.reset();
            txtSoNgayNghiCheDo.reset();
            txtMaLyDoNghi.reset();
            txtKyHieuChamCong.reset();
            txtPhanTramHuongLuong.reset();
            txtGhiChu.reset();
        }
        var GetTooltips = function (reLyDoNghi) {
            var html = "<div style='padding:5px;position:relative;z-index:10000;'>";
            html += "<fieldset style='padding:4px;border-bottom:none;border-left:none;border-right:none;border-top:1px solid #99bbe8;'><legend><b>Lý do nghỉ</b></legend>";
            if (reLyDoNghi != null && reLyDoNghi != "")
                html += reLyDoNghi + "</fieldset>";
            else
                html += "Không có dữ liệu</fieldset>";
            return html + "</div>";
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
        #grpDuyetDonXinNghi
        {
            border-bottom: 1px solid #99bbe8 !important;
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
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMaCB" />
        <ext:Hidden runat="server" ID="hdfTenCB" />
        <ext:Hidden runat="server" ID="hdfIDDonXinNghi" />
        <ext:Hidden runat="server" ID="hdfHCSNDuyet" />
        <ext:ToolTip ID="RowTip" runat="server" Width="400" AutoHide="false" Target="={#{grpDuyetDonXinNghi}.getView().mainBody}"
            Delegate=".x-grid3-row" TrackMouse="true">
            <Listeners>
                <Show Handler="var rowIndex = #{grpDuyetDonXinNghi}.view.findRowIndex(this.triggerElement);this.body.dom.innerHTML = GetTooltips(#{grpDuyetDonXinNghiStore}.getAt(rowIndex).get('LyDoNghi'));" />
            </Listeners>
        </ext:ToolTip>
        <ext:Menu runat="server" ID="RowContextMenu">
            <Items>
                <ext:MenuItem runat="server" ID="Button1" Text="Hoàn tất thủ tục" Icon="ScriptEdit">
                    <Listeners>
                        <Click Handler="return CheckChonNhieuDong(grpDuyetDonXinNghi);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnDuyetClick">
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="Button3" Text="Không duyệt" Icon="Decline">
                    <Listeners>
                        <Click Handler="txtLyDoKhongDuyet.setValue(hdfTenCB.getValue()+' không duyệt'); wdKhongDuyet.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem runat="server" ID="Button4" Text="Duyệt và chuyển tiếp" Icon="Accept">
                    <Listeners>
                        <Click Handler="txtGhiChuDuyetVaChuyenTiep.setValue(hdfTenCB.getValue()+' chuyển tiếp cho phòng HCNS '); wdDuyetVaChuyenTiep.show();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window runat="server" ID="wdKhongDuyet" Resizable="false" Constrain="true" Hidden="true"
            AutoHeight="true" Width="350" Padding="6" Modal="true" Title="Không duyệt đơn xin nghỉ phép"
            Icon="Decline" Layout="FormLayout">
            <Items>
                <ext:TextArea runat="server" ID="txtLyDoKhongDuyet" FieldLabel="Lý do không duyệt<span style='color:red;'>*</span>"
                    AnchorHorizontal="99%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYKhongduyet" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckInputDongYKhongDuyet();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnDongYKhongDuyetClick">
                            <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn không duyệt những đơn được chọn?"
                                ConfirmRequest="true" />
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLaiKhongDuyet" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdKhongDuyet.hide();disDanhSachCanBo.setValue('');txtLyDoKhongDuyet.reset();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="wdKhongDuyet.hide();txtLyDoKhongDuyet.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Store runat="server" ID="grpDuyetDonXinNghiStore">
            <Proxy>
                <ext:HttpProxy Url="Handler/DuyetDonXinNghi.ashx" Method="GET">
                </ext:HttpProxy>
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="Start" Value="={0}" Mode="Raw" />
                <ext:Parameter Name="Limit" Value="={15}" Mode="Raw" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaCB" Value="#{hdfMaCB}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                <ext:Parameter Name="HCSNDuyet" Value="#{hdfHCSNDuyet}.getValue()" Mode="Raw" />
                <ext:Parameter Name="LocTheoTrangThai" Value="#{cbbLocTheoTrangThai}.getValue()"
                    Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader TotalProperty="TotalRecords" Root="Data" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MaCB" />
                        <ext:RecordField Name="HoTen" />
                        <ext:RecordField Name="BoPhan" />
                        <ext:RecordField Name="TenCBDangDuyet" />
                        <ext:RecordField Name="NgayNopDon" />
                        <ext:RecordField Name="NghiTuNgay" />
                        <ext:RecordField Name="NghiDenNgay" />
                        <ext:RecordField Name="SoNgayNghi" />
                        <ext:RecordField Name="SoNgayNghiCheDo" />
                        <ext:RecordField Name="SoNgayNghiTruLuong" />
                        <ext:RecordField Name="SoNgaynghiTruPhep" />
                        <ext:RecordField Name="PhanTramHuongLuong" />
                        <ext:RecordField Name="KyHieuChamCong" />
                        <ext:RecordField Name="MaLyDoNghi" />
                        <ext:RecordField Name="LyDoNghi" />
                        <ext:RecordField Name="TrangThaiDuyet" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store runat="server" ID="grpLichSuDonXinNghiStore">
            <Proxy>
                <ext:HttpProxy Url="Handler/DonXinNghiLichSu.ashx" Method="GET">
                </ext:HttpProxy>
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="Start" Value="={0}" />
                <ext:Parameter Name="Limit" Value="={5}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="IDDonXinNghi" Value="#{hdfIDDonXinNghi}.getValue()" Mode="Raw">
                </ext:Parameter>
            </BaseParams>
            <Reader>
                <ext:JsonReader TotalProperty="TotalRecords" Root="Data">
                    <Fields>
                        <ext:RecordField Name="GhiChu" />
                        <ext:RecordField Name="MaCBDuyet" />
                        <ext:RecordField Name="NgayDuyet" />
                        <ext:RecordField Name="TenCBDuyet" />
                        <ext:RecordField Name="TrangThai" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdHoanTatThuTuc" Resizable="false" Constrain="true"
            Hidden="true" AutoHeight="true" Width="500" Padding="6" Modal="true" Title="Hoàn tất thủ tục xin nghỉ phép"
            Icon="ScriptEdit" Layout="FormLayout">
            <Items>
                <ext:FieldSet runat="server" ID="fsThongTinChung" AutoHeight="true" AnchorHorizontal="99%"
                    Title="Thông tin số ngày nghỉ:">
                    <Items>
                        <ext:CompositeField runat="server" ID="cpf1" FieldLabel="Nghỉ từ ngày" AnchorHorizontal="99%"
                            LabelWidth="85">
                            <Items>
                                <ext:DateField runat="server" ID="dfNghiTuNgay" Disabled="true" Width="125">
                                </ext:DateField>
                                <ext:DisplayField runat="server" ID="disfaca" Text="Đến ngày">
                                </ext:DisplayField>
                                <ext:DateField runat="server" ID="dfNghiDenNgay" Disabled="true" Width="125">
                                </ext:DateField>
                            </Items>
                        </ext:CompositeField>
                        <ext:Container runat="server" ID="ct1" AnchorHorizontal="100%" Layout="ColumnLayout"
                            Height="50" LabelWidth="140">
                            <Items>
                                <ext:Container runat="server" ID="ct11" ColumnWidth=".5">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtSoNgayNghi" MaskRe="/[0-9\.]/" FieldLabel="Số ngày nghỉ<span style='color:red;'>*</span>"
                                            Width="215">
                                        </ext:TextField>
                                        <ext:TextField runat="server" ID="txtSoNgayNghiTruLuong" MaskRe="/[0-9\.]/" FieldLabel="Số ngày nghỉ trừ lương"
                                            Width="215" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ct12" ColumnWidth=".5">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtSoNgayNghiPhep" MaskRe="/[0-9\.]/" FieldLabel="Số ngày nghỉ trừ phép"
                                            Width="215" />
                                        <ext:TextField runat="server" ID="txtSoNgayNghiCheDo" MaskRe="/[0-9\.]/" FieldLabel="Số ngày nghỉ chế độ"
                                            Width="215" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="fsThongTinLuong" Title="Thông tin chấm công, lương"
                    AutoHeight="true" AnchorHorizontal="99%" LabelWidth="120">
                    <Items>
                        <%--   <ext:TextField runat="server" ID="txtMaLyDoNghi" FieldLabel="Mã lý do nghỉ" AnchorHorizontal="99%"></ext:TextField>
                            <ext:TextField runat="server" ID="txtKyHieuChamCong" FieldLabel="Ký hiệu chấm công" AnchorHorizontal="99%"></ext:TextField>
                            <ext:TextField runat="server" ID="txtPhanTramHuongLuong" FieldLabel="% hưởng lương" AnchorHorizontal="99%"></ext:TextField>
                        --%>
                        <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="99%">
                        </ext:TextArea>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYHoanTatThuTuc" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckInputHoanTatThuTuc();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnDongYHoanTatThuTucClick">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button2" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdHoanTatThuTuc.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="wdHoanTatThuTuc.hide();resetFormHoanTatThuTuc(); " />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdDuyetVaChuyenTiep" Resizable="false" Constrain="true"
            Hidden="true" AutoHeight="true" Width="400" Padding="6" Modal="true" Title="Duyệt và chuyển tiếp"
            Icon="Accept" Layout="FormLayout" LabelWidth="110">
            <Items>
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
                    <Listeners>
                        <Select Handler="txtGhiChuDuyetVaChuyenTiep.setValue(hdfTenCB.getValue()+' chuyển tiếp tới '+ cbonhanvien.getText()); " />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextArea runat="server" ID="txtGhiChuDuyetVaChuyenTiep" FieldLabel="Ghi chú"
                    AnchorHorizontal="99%">
                </ext:TextArea>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongYDuyetVaChuyenTiep" Text="Đồng ý" Icon="Accept">
                    <DirectEvents>
                        <Click OnEvent="btnDongYDuyetVaChuyenTiepClick">
                            <Confirmation Title="Thông báo" Message="Bạn có chắc chắn chuyển tiếp những đơn bạn đã chọn?"
                                ConfirmRequest="true" />
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLaiDuyetVaChuyenTiep" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdDuyetVaChuyenTiep.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="cbonhanvien.reset();txtGhiChuDuyetVaChuyenTiep.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel runat="server" ID="pnl" Layout="BorderLayout" Border="false">
                            <Items>
                                <ext:Panel runat="server" ID="pnlDuyetDonXinNghi" AnchorHorizontal="99%" AnchorVertical="99%"
                                    Region="Center" Border="false" Layout="BorderLayout">
                                    <Items>
                                        <ext:GridPanel runat="server" ID="grpDuyetDonXinNghi" StoreID="grpDuyetDonXinNghiStore"
                                            Border="false" Region="Center" AutoExpandColumn="LyDoNghi" AutoExpandMin="200">
                                            <TopBar>
                                                <ext:Toolbar runat="server" ID="tbDuyetDonXinNghi">
                                                    <Items>
                                                        <ext:Button runat="server" ID="btnDuyet" Text="Hoàn tất thủ tục" Icon="ScriptEdit"
                                                            Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="return CheckChonNhieuDong(grpDuyetDonXinNghi);" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="btnDuyetClick">
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnKhongDuyet" Text="Không duyệt" Icon="Decline" Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="txtLyDoKhongDuyet.setValue(hdfTenCB.getValue()+' không duyệt'); wdKhongDuyet.show();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:Button runat="server" ID="btnChuyenTiep" Text="Duyệt và chuyển tiếp" Icon="Accept"
                                                            Disabled="true">
                                                            <Listeners>
                                                                <Click Handler="txtGhiChuDuyetVaChuyenTiep.setValue(hdfTenCB.getValue()+' chuyển tiếp cho phòng HCNS '); wdDuyetVaChuyenTiep.show();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                        <ext:ToolbarSeparator runat="server" ID="tps">
                                                        </ext:ToolbarSeparator>
                                                        <ext:ComboBox runat="server" ID="cbbLocTheoTrangThai" FieldLabel="Lọc theo trạng thái"
                                                            Width="250">
                                                            <Triggers>
                                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                            </Triggers>
                                                            <Items>
                                                                <ext:ListItem Value="ChuaDuyet" Text="Chưa duyệt" />
                                                                <ext:ListItem Value="DaDuyet" Text="Đã duyệt" />
                                                                <ext:ListItem Value="KhongDuyet" Text="Không duyệt" />
                                                                <ext:ListItem Value="HoanTatThuTuc" Text="Hoàn tất thủ tục" />
                                                            </Items>
                                                            <Listeners>
                                                                <Select Handler="this.triggers[0].show();grpDuyetDonXinNghiStore.reload();" />
                                                                <TriggerClick Handler="if(index==0){ this.clearValue();this.triggers[0].hide(); grpDuyetDonXinNghiStore.reload();}" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                        <ext:ToolbarFill runat="server" ID="tbf">
                                                        </ext:ToolbarFill>
                                                        <ext:TextField runat="server" ID="txtSearchKey" Width="250" EmptyText="Nhập mã cán bộ, họ tên"
                                                            LabelWidth="1" EnableKeyEvents="true">
                                                            <Listeners>
                                                                <KeyPress Fn="enterKeyPressSearchKey" />
                                                            </Listeners>
                                                        </ext:TextField>
                                                        <ext:Button runat="server" ID="btnSearch" Text="Tìm kiếm" Icon="Zoom">
                                                            <Listeners>
                                                                <Click Handler="#{grpDuyetDonXinNghiStore}.reload();hdfIDDonXinNghi.setValue('');#{grpLichSuDonXinNghiStore}.removeAll();" />
                                                            </Listeners>
                                                        </ext:Button>
                                                    </Items>
                                                </ext:Toolbar>
                                            </TopBar>
                                            <ColumnModel runat="server" ID="colmodel1">
                                                <Columns>
                                                    <ext:RowNumbererColumn ColumnID="STT" Align="Left" Header="STT" Width="30" Locked="true">
                                                    </ext:RowNumbererColumn>
                                                    <ext:Column ColumnID="colTrangThaiDuyet" DataIndex="TrangThaiDuyet" Header="Trạng thái đơn"
                                                        Width="87" Locked="true">
                                                        <Renderer Fn="renderTrangThaiDuyet" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="colMaCB" DataIndex="MaCB" Header="Mã cán bộ" Width="80" Align="Left"
                                                        Locked="true">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="colHoTen" DataIndex="HoTen" Header="Họ tên" Width="150" Align="Left"
                                                        Locked="true">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="colBoPhan" DataIndex="BoPhan" Header="Bộ phận" Width="150"
                                                        Align="Left">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="colTenCBDangDuyet" DataIndex="TenCBDangDuyet" Header="Người duyệt"
                                                        Width="150" Align="Left">
                                                    </ext:Column>
                                                    <ext:DateColumn ColumnID="colNgayNopDon" DataIndex="NgayNopDon" Header="Ngày nộp đơn"
                                                        Width="80" Format="dd/MM/yyyy">
                                                    </ext:DateColumn>
                                                    <ext:DateColumn ColumnID="colNghiTuNgay" DataIndex="NghiTuNgay" Header="Nghỉ từ ngày"
                                                        Width="80" Format="dd/MM/yyyy">
                                                    </ext:DateColumn>
                                                    <ext:DateColumn ColumnID="colNghiDenNgay" DataIndex="NghiDenNgay" Header="Nghỉ đến ngày"
                                                        Width="80" Format="dd/MM/yyyy">
                                                    </ext:DateColumn>
                                                    <ext:Column ColumnID="colSoNgayNghi" DataIndex="SoNgayNghi" Header="Số ngày nghỉ"
                                                        Width="89" Align="Right">
                                                    </ext:Column>
                                                    <ext:Column ColumnID="colSoNgayNghiTruPhep" DataIndex="SoNgayNghiTruPhep" Header="Phép"
                                                        Width="55" Align="Right" />
                                                    <ext:Column ColumnID="colSoNgayNghiTruLuong" DataIndex="SoNgayNghiTruLuong" Header="Không lương"
                                                        Width="85" Align="Right" />
                                                    <ext:Column ColumnID="colSoNgayNghiCheDo" DataIndex="SoNgayNghiCheDo" Header="Chế độ"
                                                        Align="Right" Width="60" />
                                                    <%--                                                        <ext:Column ColumnID="colMaLyDoNghi" DataIndex="MaLyDoNghi" Header="Lý do nghỉ" Align="Left" Width="60" />
                                                        <ext:Column ColumnID="colKyHieuChamCong" DataIndex="KyHieuChamCong" Header="Ký hiệu chấm công" Width="70" Align="Left" />
                                                        <ext:Column ColumnID="colPhanTramHuongLuong" DataIndex="PhanTramHuongLuong" Header="% hưởng lương" Width="90" Align="Left" />--%>
                                                    <ext:Column ColumnID="colLyDoNghi" DataIndex="LyDoNghi" Header="Lý do nghỉ" Width="200">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <View>
                                                <ext:LockingGridView runat="server" ID="lk1" ForceFit="false" MarkDirty="false" UnlockText="Không khóa cột này"
                                                    LockText="Khóa cột này lại" />
                                                <%--<ext:GroupingView ID="groupview1" runat="server" ForceFit="false" MarkDirty="false"
                                                        ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                                    </ext:GroupingView>--%>
                                            </View>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                                    PageSize="15" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                                    <Items>
                                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                                            <Items>
                                                                <ext:ListItem Text="10" />
                                                                <ext:ListItem Text="15" />
                                                                <ext:ListItem Text="20" />
                                                                <ext:ListItem Text="50" />
                                                                <ext:ListItem Text="100" />
                                                            </Items>
                                                            <SelectedItem Value="15" />
                                                            <Listeners>
                                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad(); " />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:PagingToolbar>
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel runat="server" ID="RowSelectDuyetDonXinNghi" SingleSelect="false">
                                                    <Listeners>
                                                        <RowSelect Handler="#{hdfIDDonXinNghi}.setValue(#{RowSelectDuyetDonXinNghi}.getSelected().id);grpLichSuDonXinNghiStore.reload(); btnKhongDuyet.enable();btnChuyenTiep.enable();btnDuyet.enable();" />
                                                    </Listeners>
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                            <LoadMask ShowMask="true" />
                                            <Listeners>
                                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grpDuyetDonXinNghi}.getSelectionModel().selectRow(rowIndex);" />
                                            </Listeners>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                                <ext:Panel runat="server" ID="pnlLichSuDon" Title="Lịch sử đơn xin nghỉ" Height="200"
                                    Layout="BorderLayout" Collapsed="false" Collapsible="true" Region="South" Border="false">
                                    <Items>
                                        <ext:GridPanel runat="server" ID="grpLichSuDonXinNghi" StoreID="grpLichSuDonXinNghiStore"
                                            Region="Center" Border="false" AutoExpandColumn="GhiChu" AutoExpandMin="150">
                                            <ColumnModel runat="server" ID="colmoder2">
                                                <Columns>
                                                    <ext:RowNumbererColumn ColumnID="STT" Align="Left" Header="STT" Width="30">
                                                    </ext:RowNumbererColumn>
                                                    <ext:Column ColumnID="colTenCBDuyet" DataIndex="TenCBDuyet" Header="Người duyệt"
                                                        Width="100" Align="Left">
                                                    </ext:Column>
                                                    <ext:DateColumn ColumnID="colNgayDuyet" DataIndex="NgayDuyet" Header="Ngày giờ duyệt"
                                                        Width="180" Align="Center" Format="dd/MM/yyyy hh:mm:ss">
                                                    </ext:DateColumn>
                                                    <ext:Column ColumnID="colTrangThai" DataIndex="TrangThai" Header="Trạng thái" Width="200"
                                                        Align="Left">
                                                        <Renderer Fn="renderTrangThaiDuyet" />
                                                    </ext:Column>
                                                    <ext:Column ColumnID="colGhiChu" DataIndex="GhiChu" Header="Ghi chú" Width="350"
                                                        Align="Left">
                                                    </ext:Column>
                                                </Columns>
                                            </ColumnModel>
                                            <BottomBar>
                                                <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                                    PageSize="5" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                                    <Items>
                                                        <ext:Label ID="Label2" runat="server" Text="Số bản ghi trên 1 trang:" />
                                                        <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                            <Items>
                                                                <ext:ListItem Text="10" />
                                                                <ext:ListItem Text="15" />
                                                                <ext:ListItem Text="20" />
                                                                <ext:ListItem Text="50" />
                                                                <ext:ListItem Text="100" />
                                                            </Items>
                                                            <SelectedItem Value="5" />
                                                            <Listeners>
                                                                <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                                            </Listeners>
                                                        </ext:ComboBox>
                                                    </Items>
                                                </ext:PagingToolbar>
                                            </BottomBar>
                                            <SelectionModel>
                                                <ext:RowSelectionModel runat="server" ID="rsm1">
                                                </ext:RowSelectionModel>
                                            </SelectionModel>
                                        </ext:GridPanel>
                                    </Items>
                                </ext:Panel>
                            </Items>
                        </ext:Panel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
