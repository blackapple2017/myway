<%@ Page Language="C#" AutoEventWireup="true" CodeFile="TongHopCongCuoiThang.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_TongHopCongCuoiThang" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        div#grpTongHopCong .x-grid3-cell-inner, .x-grid3-hd-inner
        {
            white-space: nowrap !important;
        }
        
        #pnlCoCauToChuc-xsplit
        {
            border-right: none !important;
        }
        
        #pnlCoCauToChuc .x-panel-body
        {
            background-color: White !important;
        }
        
        #grpTongHopCong
        {
            border-left: 1px solid #98C0F4 !important;
        }
        
        .colored
        {
            background-color: #E8E8E8;
        }
        
        #wdShowReport .x-tab-panel-header
        {
            display: none !important;
        }
        
        #tb .x-form-item
        {
            margin-bottom: 0 !important;
        }
    </style>
    <script type="text/javascript" src="Resource/TongHopCongTheoThang.js"></script>
    <script type="text/javascript" src="../../Resource/js/RenderJS.js"></script>
    <script type="text/javascript">
        var RenderAlign = function (value, p, record) {
            if (value == "Left") {
                return "Trái";
            }
            else if (value == "Right")
                return "Phải";
            else if (value == "Center")
                return "Giữa";
            return value;
        }
        var Render = function (value, p, record) {
            if (value == 'RenderVND')
                return "Kiểu tiền tệ";
            if (value == 'RenderNumber')
                return "Kiểu số";
            else return value;
        }
        var RenderNumber = function (value, p, record) {
            if (value == 0 || value == null || value == '')
                return "<span style='float:right;'>-</span>";
            else {
                return "<span style='float:right;'>" + parseFloat('0' + value).toFixed(3).replace(".000", "") + "</span>";
                //return parseFloat('0' + value).toFixed(1);
            }
        }
        var afterEdit2 = function (e) {
            Ext.net.DirectMethods.AfterEdit2(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
        };
        var afterEdit = function (e) {
            Ext.net.DirectMethods.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <div id="sqlQuery" style="display: none;">
        </div>
        <div id="maCBChange" style="display: none;">
        </div>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfIdBangTongHopCong" />
        <%--Chứa mã bảng tổng hợp công đang được chọn--%>
        <ext:Hidden runat="server" ID="hdfTmpID" />
        <ext:Hidden runat="server" ID="hdfIsLocked" />
        <ext:Hidden runat="server" ID="hdfAction" Text="Insert" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMax" />
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo hồ sơ nhân viên" Maximized="true" Icon="Printer">
            <Items>
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="wdShowReport.setTitle('Báo cáo tổng hợp công tháng');
                    pnReportPanel.remove(0); addHomePage(pnReportPanel, 'Homepage', '../Report/BaoCao_Main.aspx?type=BaoCaoTongHopCongCuoiThang&IdBangTHC=' + hdfIdBangTongHopCong.getValue() + '&MaDonVi=' + hdfMaDonVi.getValue(), 'Báo cáo tổng hợp công tháng');" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuViewDetailTimeSheet" runat="server" Icon="Zoom" Text="Xem chi tiết chấm công">
                    <Listeners>
                        <Click Handler="wdChiTietChamCong.show();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window Modal="true" Hidden="true" Constrain="false" runat="server" ID="wdChiTietChamCong"
            Resizable="true" Title="Chi tiết chấm công" Layout="BorderLayout" Icon="Time"
            Width="580" Padding="6" Height="575">
            <Items>
                <ext:Hidden runat="server" ID="hdfPrKeyCurrent" />
                <%--                    <ext:Container runat="server" AnchorHorizontal="100%" ID="fs_ChiTietChamCong" LabelWidth="0">
                        <Items>
                            <ext:DisplayField runat="server" ID="dplHoTen" Text="Mã nhân viên: ____. Họ tên: _____________. Bộ phận: ______________." />
                            <ext:DisplayField runat="server" ID="dplSoGio" Text="Số giờ làm việc: ____. Số phút đi muộn: ____. Số phút về sớm: ____." />
                        </Items>
                    </ext:Container>--%>
                <ext:GridPanel ID="grpChiTietChamCongMay" runat="server" Region="Center" Border="false"
                    Height="400" AutoExpandMin="200">
                    <Store>
                        <ext:Store runat="server" AutoLoad="false" ID="stChiTietChamCong">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="Handler/HandlerChiTietChamCongNhanVien.ashx" />
                            </Proxy>
                            <BaseParams>
                                <ext:Parameter Name="PrKey" Value="hdfRecordID.getValue()" Mode="Raw" />
                                <ext:Parameter Name="Month" Value="cbxMonth.getValue()" Mode="Raw" />
                                <ext:Parameter Name="Year" Value="spnYear.getValue()" Mode="Raw" />
                                <ext:Parameter Name="max" Value="hdfMax.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="NgayChamCong">
                                    <Fields>
                                        <ext:RecordField Name="NgayChamCong" />
                                        <ext:RecordField Name="KyHieuChamCong" />
                                        <ext:RecordField Name="GhiChu" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:DateColumn ColumnID="NgayChamCong" Header="Ngày chấm công" Width="100" Align="Center"
                                DataIndex="NgayChamCong" Format="dd/MM/yyyys" />
                            <ext:Column ColumnID="KyHieuChamCong" Header="Ký hiệu chấm công" Width="110" Align="Left"
                                DataIndex="KyHieuChamCong" />
                            <ext:Column ColumnID="GhiChu" Header="Ghi chú" Width="100" Align="Left" DataIndex="GhiChu" />
                        </Columns>
                    </ColumnModel>
                </ext:GridPanel>
            </Items>
            <Listeners>
                <%--<BeforeShow Handler="if(hdfPrKeyCurrent.getValue() != hdfRecordID.getValue()){ hdfPrKeyCurrent.setValue(hdfRecordID.getValue()); stChiTietChamCong.reload();}" />--%>
                <BeforeShow Handler="stChiTietChamCong.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" Constrain="true" runat="server" ID="wdConfigTimeSheets"
            Resizable="false" Title="Cấu hình bảng tổng hợp công cuối tháng" Layout="BorderLayout"
            Icon="Cog" Width="800" Padding="6" Height="420">
            <Items>
                <ext:GridPanel ID="grpConfigTimeSheets" runat="server" Region="Center" Border="false"
                    Height="320" AutoExpandColumn="ColumnDescription" AutoExpandMin="200">
                    <Store>
                        <ext:Store runat="server" ID="stConfigTimeSheets" OnRefreshData="stConfigTimeSheets_RefreshData">
                            <Reader>
                                <ext:JsonReader IDProperty="ID">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="ColumnName" />
                                        <ext:RecordField Name="ColumnDescription" />
                                        <ext:RecordField Name="Width" />
                                        <ext:RecordField Name="Align" />
                                        <ext:RecordField Name="DisplayOnGrid" />
                                        <ext:RecordField Name="Order" />
                                        <ext:RecordField Name="RenderJS" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="colColumnName" Header="Tên cột" Width="100" DataIndex="ColumnName" />
                            <ext:Column ColumnID="colColumnDescription" Header="Diễn giải" Width="310" DataIndex="ColumnDescription">
                                <Editor>
                                    <ext:TextField runat="server" ID="txt1" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colOrder" DataIndex="Order" Width="95" Align="Right" Header="Thứ tự hiển thị">
                                <Editor>
                                    <ext:NumberField runat="server" ID="nf1" AllowNegative="false" AllowDecimals="false"
                                        MaxLength="5" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colRenderJs" DataIndex="RenderJS" Width="80" Header="Định dạng">
                                <Editor>
                                    <ext:ComboBox runat="server" ID="cbxRenderJS">
                                        <Items>
                                            <ext:ListItem Value="RenderVND" Text="Kiểu tiền tệ" />
                                            <ext:ListItem Value="RenderNumber" Text="Kiểu số" />
                                        </Items>
                                        <Listeners>
                                            <Change Fn="Render" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Editor>
                                <Renderer Fn="Render" />
                            </ext:Column>
                            <ext:Column ColumnID="colWidth" Header="Dài" Width="50" DataIndex="Width">
                                <Editor>
                                    <ext:NumberField runat="server" ID="nf2" AllowNegative="false" AllowDecimals="false"
                                        MaxLength="5" />
                                </Editor>
                            </ext:Column>
                            <ext:Column ColumnID="colAlign" DataIndex="Align" Width="60" Header="Căn lề">
                                <Editor>
                                    <ext:ComboBox Editable="false" runat="server" ID="cbbAlign">
                                        <Items>
                                            <ext:ListItem Text="Trái" Value="Left" />
                                            <ext:ListItem Text="Phải" Value="Right" />
                                            <ext:ListItem Text="Giữa" Value="Center" />
                                        </Items>
                                        <Listeners>
                                            <Change Fn="RenderAlign" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Editor>
                                <Renderer Fn="RenderAlign" />
                            </ext:Column>
                            <ext:Column ColumnID="colDisplayOnGrid" DataIndex="DisplayOnGrid" Width="80" Header="Hiển thị trên bảng công">
                                <Editor>
                                    <ext:ComboBox runat="server" ID="cbxDisplayOnGrid">
                                        <Items>
                                            <ext:ListItem Value="True" Text="True" />
                                            <ext:ListItem Value="False" Text="False" />
                                        </Items>
                                        <Listeners>
                                            <Change Fn="GetBooleanIcon" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Editor>
                                <Renderer Fn="GetBooleanIcon" />
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar3" runat="server" PageSize="25">
                        </ext:PagingToolbar>
                    </BottomBar>
                    <Listeners>
                        <AfterEdit Fn="afterEdit2" />
                    </Listeners>
                </ext:GridPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="#{stConfigTimeSheets}.reload();" />
            </Listeners>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" Constrain="true" runat="server" ID="wdConfigTimesToDay"
            Resizable="false" Title="Cấu hình giá trị thời gian tính công" Layout="FormLayout"
            Icon="Cog" Width="350" Padding="6" AutoHeight="true">
            <Items>
                <ext:Container runat="server" ID="container" Layout="ColumnLayout">
                    <Items>
                        <ext:DisplayField runat="server" ID="dpfStartTime" Text="Số giờ làm từ: " Width="70" />
                        <ext:DisplayField runat="server" Width="5" />
                        <ext:NumberField runat="server" ID="nbfStartTime" AllowNegative="false" Width="45"
                            EmptyText="giờ" MaxLength="5" />
                        <ext:DisplayField ID="ToolbarSpacer4" runat="server" Width="5" />
                        <ext:DisplayField runat="server" ID="dpfEndTime" Text="đến " Width="25" />
                        <ext:NumberField runat="server" ID="nbfEndTime" AllowNegative="false" Width="45"
                            EmptyText="giờ" MaxLength="5">
                            <Listeners>
                                <Blur Handler="nbfStartTime2.setValue(' ' + this.getValue()+' trở lên');" />
                            </Listeners>
                        </ext:NumberField>
                        <ext:DisplayField ID="ToolbarSpacer3" runat="server" Width="5" />
                        <ext:DisplayField runat="server" ID="DisplayField1" Text="Hưởng " Width="40" />
                        <ext:NumberField runat="server" ID="nbfDay1" AllowNegative="false" Width="45" MaxLength="5" />
                        <ext:DisplayField ID="DisplayField2" runat="server" Width="5" />
                        <ext:DisplayField runat="server" ID="DisplayField3" Text="ngày công" />
                    </Items>
                </ext:Container>
                <ext:DisplayField runat="server" Height="3" />
                <ext:Container runat="server" ID="container1" Layout="ColumnLayout">
                    <Items>
                        <ext:DisplayField runat="server" ID="DisplayField4" Text="Số giờ từ: " Width="70" />
                        <ext:DisplayField ID="DisplayField5" runat="server" Width="5" />
                        <ext:DisplayField runat="server" ID="nbfStartTime2" Width="70" Text="" />
                        <ext:DisplayField ID="DisplayField9" runat="server" Width="43" />
                        <ext:DisplayField runat="server" ID="DisplayField10" Text="Hưởng " Width="40" />
                        <ext:NumberField runat="server" ID="nbfDay2" AllowNegative="false" Width="45" MaxLength="5" />
                        <ext:DisplayField ID="DisplayField12" runat="server" Width="5" />
                        <ext:DisplayField runat="server" ID="DisplayField13" Text="ngày công" />
                    </Items>
                </ext:Container>
                <ext:DisplayField ID="DisplayField7" runat="server" Height="3" />
                <ext:Container runat="server" ID="container3" Layout="ColumnLayout">
                    <Items>
                        <ext:DisplayField runat="server" ID="DisplayField6" Text="Số giờ chênh lệch xác định ca gãy "
                            Width="228" />
                        <ext:NumberField runat="server" ID="nbfCaGay" AllowNegative="false" Width="45"
                            MaxLength="5" />
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnSave" Text="Lưu" Icon="Disk">
                    <Listeners>
                        <Click Handler="if(nbfStartTime.getValue() == ''){alert('Bạn phải nhập vào số giờ');nbfStartTime.focus();}
                                        if(nbfEndTime.getValue() == ''){alert('Bạn phải nhập vào số giờ');nbfEndTime.focus();}
                                        if(nbfDay1.getValue() == ''){alert('Bạn phải nhập vào số ngày công hưởng');nbfDay1.focus();}
                                        if(nbfDay2.getValue() == ''){alert('Bạn phải nhập vào số ngày công hưởng');nbfDay2.focus();}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancelSave" Text="Hủy" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdConfigTimesToDay.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="Ext.net.DirectMethods.LoadConfigTimeToDay();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grpTongHopCongStore" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="Handler/HandlerTongHopCongCuoiThang.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="Month" Value="cbxMonth.getValue()" Mode="Raw" />
                <ext:Parameter Name="Year" Value="spnYear.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaBoPhan" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                <ext:Parameter Name="menuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                <ext:Parameter Name="userID" Value="hdfUserID.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_CB">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MA_CB" />
                        <ext:RecordField Name="HO_TEN" />
                        <ext:RecordField Name="TEN_DONVI" />
                        <ext:RecordField Name="TEN_DIADIEM" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" ID="wdImportExcelFile" Constrain="true" Modal="true" Title="Nhập tệp tin chấm công"
            Padding="6" Icon="PageExcel" AutoHeight="true" Layout="FormLayout" Hidden="true"
            Width="450">
            <Items>
                <ext:FileUploadField runat="server" ID="fUpload" SelectOnFocus="true" Regex="^.*\.xls$"
                    InvalidText="Tệp tin được chọn phải là Excel 2003" AnchorHorizontal="100%" FieldLabel="Chọn tệp tin">
                    <Listeners>
                        <FileSelected Handler="#{cbSheetNameStore}.reload();#{cbSheetName}.enable();" />
                    </Listeners>
                </ext:FileUploadField>
                <ext:ComboBox ID="cbSheetName" Disabled="true" FieldLabel="Chọn sheet" SelectedIndex="0"
                    Editable="false" AnchorHorizontal="100%" runat="server" DisplayField="SheetName"
                    ValueField="SheetName" SelectOnFocus="true">
                    <Store>
                        <ext:Store ID="cbSheetNameStore" runat="server" OnRefreshData="cbSheetNameStore_OnRefreshData"
                            AutoLoad="false" EnableViewState="false">
                            <DirectEventConfig>
                                <EventMask ShowMask="false" />
                            </DirectEventConfig>
                            <Reader>
                                <ext:JsonReader IDProperty="SheetName">
                                    <Fields>
                                        <ext:RecordField Name="SheetName" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                </ext:ComboBox>
                <ext:Checkbox runat="server" ID="chkXoa" BoxLabel="Xóa dữ liệu cũ" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnImport" Text="Nhập dữ liệu" Icon="PageExcel">
                    <Listeners>
                        <Click Handler="if (#{fUpload}.getValue() == '') {alert('Bạn chưa chọn tệp tin đính kèm'); return false;}
                            if (#{cbSheetName}.getValue() == '' || cbSheetName.getValue() == null) {alert('Bạn chưa chọn sheet'); return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnImport_Click">
                            <EventMask ShowMask="true" Msg="Đang nhập dữ liệu. Vui lòng chờ..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLai" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdImportExcelFile.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{fUpload}.reset(); #{cbSheetName}.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="grpTongHopCong" runat="server" Title="Bảng tổng hợp công" StripeRows="true"
                            TrackMouseOver="true" Border="false" StoreID="grpTongHopCongStore" Icon="BookOpen"
                            Header="false">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnChuanBiDuLieuDauVao" runat="server" Text="Nhập giá trị chấm công từ excel"
                                            Icon="PageExcel">
                                            <Listeners>
                                                <Click Handler="#{wdImportExcelFile}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnTongHopCong" runat="server" Text="Tổng hợp công" Icon="Sum">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="mnuLayCongLamThemGio" runat="server" Text="Lấy công làm thêm giờ"
                                                            Icon="Sum" Hidden="true">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuLayCongLamThemGio_Click">
                                                                    <EventMask ShowMask="true" Msg="Đang tính toán giờ làm thêm. Vui lòng đợi..." />
                                                                    <Confirmation Title="Xác nhận" Message="Số giờ làm thêm sẽ được tính toán lại. Bạn có chắc chắn muốn thực hiện?"
                                                                        ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTongHopTatCa" runat="server" Text="Tổng hợp tất cả" Icon="Sum">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuTongHopTatCa_Click">
                                                                    <EventMask ShowMask="true" Msg="Đang tổng hợp công. Vui lòng đợi..." />
                                                                    <Confirmation Title="Xác nhận" Message="Khi tổng hợp công, toàn bộ dữ liệu sẽ được tính toán lại. Bạn có chắc chắn muốn tổng hợp công không?"
                                                                        ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuTongHopDuocChon" runat="server" Text="Tổng hợp đối với cán bộ được chọn"
                                                            Icon="Sum">
                                                            <Listeners>
                                                                <Click Handler="return CheckSelectedRow(grpTongHopCong);" />
                                                            </Listeners>
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuTongHopDuocChon_Click">
                                                                    <EventMask ShowMask="true" Msg="Đang tổng hợp công. Vui lòng đợi..." />
                                                                    <Confirmation Title="Xác nhận" Message="Khi tổng hợp công, toàn bộ dữ liệu sẽ được tính toán lại. Bạn có chắc chắn muốn tổng hợp công không?"
                                                                        ConfirmRequest="true" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="65">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxMonth" Width="70" Editable="false" FieldLabel="Chọn tháng">
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
                                                    <Listeners>
                                                        <Select Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSpacer ID="ToolbarSpacer6" runat="server" Width="5" />
                                        <ext:Container runat="server" ID="Container2" Layout="FormLayout" LabelWidth="60">
                                            <Items>
                                                <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Chọn năm" Width="55">
                                                    <Listeners>
                                                        <Spin Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                                    </Listeners>
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSeparator />
                                        <ext:Button runat="server" ID="mnConfig" Text="Cấu hình" Icon="Cog">
                                            <Menu>
                                                <ext:Menu runat="server" ID="menuConfig">
                                                    <Items>
                                                        <ext:MenuItem runat="server" ID="btnCauHinhBangTongHopCongThang" Text="Cấu hình các cột trên bảng công"
                                                            Icon="Cog">
                                                            <Listeners>
                                                                <Click Handler=" wdConfigTimeSheets.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem runat="server" ID="btnCauHinhGiaTriTinhCong" Text="Cấu hình giá trị tính công"
                                                            Icon="Cog">
                                                            <Listeners>
                                                                <Click Handler=" wdConfigTimesToDay.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel"
                                            Hidden="false">
                                            <DirectEvents>
                                                <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc tên cán bộ"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <KeyUp Handler="if (txtSearch.getValue() != '') this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{grpTongHopCongStore}.reload(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler=" PagingToolbar1.pageIndex = 0; #{grpTongHopCongStore}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                    <GetRowClass Fn="getRowClass" />
                                </ext:LockingGridView>
                            </View>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="MA_CB" Header="Mã cán bộ" Locked="true" Width="90" DataIndex="MA_CB" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Locked="true" Width="150" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Width="150" DataIndex="TEN_DONVI" />
                                    <ext:Column ColumnID="TEN_DIADIEM" Header="Địa điểm làm viêc" Width="100" DataIndex="TEN_DIADIEM" />
                                    <%--                                        <ext:Column ColumnID="HL" Width="70" Align="Right" Header="Hưởng lương" DataIndex="HL">
                                            <Renderer Fn="RenderNumber" />
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtEditorHL" MaskRe="/[0-9.-]/" MaxLength="9" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ColumnID="Phep" Width="70" Align="Right" Header="Phép" DataIndex="Phep">
                                            <Renderer Fn="RenderNumber" />
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtEditorPhep" MaskRe="/[0-9.-]/" MaxLength="9" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ColumnID="BHXH" Width="70" Align="Right" Header="BHXH" DataIndex="BHXH">
                                            <Renderer Fn="RenderNumber" />
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtEditorBHXH" MaskRe="/[0-9.-]/" MaxLength="9" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column ColumnID="KL" Width="70" Align="Right" Header="Không lương" DataIndex="KL">
                                            <Renderer Fn="RenderNumber" />
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtEditorKL" MaskRe="/[0-9.-]/" MaxLength="9" />
                                            </Editor>
                                        </ext:Column>--%>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModelTongHopCong" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(RowSelectionModelTongHopCong.getSelected().id);" />
                                        <RowDeselect Handler="hdfRecordID.reset();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="100" />
                                                <ext:ListItem Text="200" />
                                                <ext:ListItem Text="500" />
                                                <ext:ListItem Text="1000" />
                                            </Items>
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:DisplayField runat="server" ID="dpfTrangThai" />
                                    </Items>
                                    <Listeners>
                                        <Change Handler="RowSelectionModelTongHopCong.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <Listeners>
                                <AfterEdit Fn="afterEdit" />
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grpTongHopCong}.getSelectionModel().selectRow(rowIndex);" />
                            </Listeners>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
