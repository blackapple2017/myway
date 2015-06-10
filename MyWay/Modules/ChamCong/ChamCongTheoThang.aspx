<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChamCongTheoThang.aspx.cs"
    Inherits="Modules_ChamCong_ChamCongTheoThang" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<%@ Register Src="ImportFromExcel.ascx" TagName="ImportFromExcel" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <style type="text/css">
        #GridPanel1 {
            border-left: 1px solid #99bbe8 !important;
        }

        #pnlCoCauToChuc-xsplit {
            border-right: none !important;
        }
    </style>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../Resource/js/GridPanelEvent.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="Resource/ChamCongTheoThang.js" type="text/javascript"></script>
    <link href="Resource/ChamCongTheoThang.css" rel="stylesheet" type="text/css" />
    <asp:Literal Text="" ID="ltrweekendStyle" runat="server" />
    <script type="text/javascript">
        var afterEdit = function (e) {
            if (e.value == null || e.value == '')
                e.value = '  ';
            Store1.commitChanges();
            if (e.value != '') {
                Ext.net.DirectMethods.AfterEdit(e.record.data.PRKEY, e.field, e.value, e.originalValue);
            }
        };
        var StartEdit = function () {
            try {
                var record = grpDanhSachBangChamCong.getSelectionModel().getSelected();
                var index = grpDanhSachBangChamCong.store.indexOf(record);
                grpDanhSachBangChamCong.getRowEditor().stopEditing();
                grpDanhSachBangChamCong.getSelectionModel().selectRow(index);
                grpDanhSachBangChamCong.getRowEditor().startEditing(index);
            } catch (e) {
            }
        }
        var getTimeSignal = function (value, group) {
            var records = Store2.getRange();
            var time = 0;
            if (value == null) {
                return 0;
            }
            var signList = value.split(",");
            for (var i = 0; i < signList.length; i++) {
                for (var j = 0; j < records.length; j++) {
                    if (records[j].data.KYHIEU_TT_LAMVIEC == signList[i] && records[j].data.NhomKyHieu == group) {
                        time += records[j].data.SoCongHuongLuong;
                    }
                }
            }
            return time;
        }
        var rendererSignal = function (data, sign) {
            return getTimeSignal(data.NGAY01, sign) + getTimeSignal(data.NGAY02, sign) + getTimeSignal(data.NGAY03, sign) +
                   getTimeSignal(data.NGAY04, sign) + getTimeSignal(data.NGAY05, sign) + getTimeSignal(data.NGAY06, sign) +
                   getTimeSignal(data.NGAY07, sign) + getTimeSignal(data.NGAY08, sign) + getTimeSignal(data.NGAY09, sign) +
                   getTimeSignal(data.NGAY10, sign) + getTimeSignal(data.NGAY11, sign) + getTimeSignal(data.NGAY12, sign) +
                   getTimeSignal(data.NGAY13, sign) + getTimeSignal(data.NGAY14, sign) + getTimeSignal(data.NGAY15, sign) +
                   getTimeSignal(data.NGAY16, sign) + getTimeSignal(data.NGAY17, sign) + getTimeSignal(data.NGAY18, sign) +
                   getTimeSignal(data.NGAY19, sign) + getTimeSignal(data.NGAY20, sign) + getTimeSignal(data.NGAY21, sign) +
                   getTimeSignal(data.NGAY22, sign) + getTimeSignal(data.NGAY23, sign) + getTimeSignal(data.NGAY24, sign) +
                   getTimeSignal(data.NGAY25, sign) + getTimeSignal(data.NGAY26, sign) + getTimeSignal(data.NGAY27, sign) +
                   getTimeSignal(data.NGAY28, sign) + getTimeSignal(data.NGAY29, sign) + getTimeSignal(data.NGAY30, sign) +
                   getTimeSignal(data.NGAY31, sign);
        }
        var rendererKL = function (data) {
            return "<span style='float:right;color: red;'>" + rendererSignal(data, 'KL') + "</span>";
        }
        var rendererHL = function (data) {
            return rendererSignal(data, 'HL');
        }
        var rendererBHXH = function (data) {
            return rendererSignal(data, 'BHXH');
        }
        var rendererNP = function (data) {
            return rendererSignal(data, 'NP');
        }
        var rendererNB = function (data) {
            return rendererSignal(data, 'NB');
        }
        var rendererHLTV = function (data) {
            return rendererSignal(data, 'HLTV');
        }
        var getTotal = function (data) {
            return rendererHL(data) + rendererHLTV(data) + rendererNB(data) + rendererNP(data);
        }
        var rendererPhepCon = function (data) {
            return "<span style='float:right;color: blue;'>" + (data.SoPhepCon + (data.Phep - rendererNP(data))) + "</span>";
        }
        var rendererNBConLai = function (data) {
            if (data.NghiBuConLai == null) {
                return "<span style='float:right;color: blue;'>0</span>";
            }
            return "<span style='float:right;color: blue;'>" + (data.NghiBuConLai + (data.NB - rendererNB(data))) + "</span>";
        }
        var ResetValueTimeSheet = function () {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa trắng bảng công?', function (btn) {
                if (btn == "yes") {
                    Ext.net.DirectMethods.ResetValueTimeSheet();
                }
            });
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager ID="RM" runat="server" />
            <uc2:ImportFromExcel ID="ImportFromExcel1" runat="server" />
            <ext:Hidden runat="server" ID="hdfIdBangChamCong" EnableViewState="true" />
            <%--  <ext:Hidden runat="server" ID="hdfParttimeSignal" />
            <ext:Hidden runat="server" ID="hdfFullTimeSignal" />
            <ext:Hidden runat="server" ID="hdfVacationSignal" />
            <ext:Hidden runat="server" ID="hdfVacationPartSignal" />
            <ext:Hidden runat="server" ID="hdfHolidaySignal" />
            <ext:Hidden runat="server" ID="hdfWorkHolidaySignal" />
            <ext:Hidden runat="server" ID="hdfWorkInSunDaySignal" /--%>>
            <ext:Hidden runat="server" ID="hdfSignalInDay" />
            <ext:Store ID="Store2" runat="server">
                <Reader>
                    <ext:JsonReader IDProperty="KYHIEU_TT_LAMVIEC">
                        <Fields>
                            <ext:RecordField Name="KYHIEU_TT_LAMVIEC" />
                            <ext:RecordField Name="TEN_TT_LAMVIEC" />
                            <ext:RecordField Name="SoCongHuongLuong" Type="Float" />
                            <ext:RecordField Name="NhomKyHieu" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Window runat="server" Title="Chấm công ngày hôm nay cho tất cả nhân viên" Modal="true"
                Width="500" Hidden="true" Icon="ClockEdit" ID="wdChamCongHomNay" AutoHeight="true"
                Resizable="false">
                <Items>
                    <ext:Hidden runat="server" ID="hdfTinhTrangLamViecHomNay" />
                    <ext:GridPanel ID="GridPanel2" runat="server" Height="270" AnchorHorizontal="100%"
                        AutoExpandColumn="Common" Title="Tình trạng làm việc" Border="false" ClicksToEdit="1"
                        StoreID="Store2">
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:Column Header="Ký hiệu" DataIndex="KYHIEU_TT_LAMVIEC" Width="50" />
                                <ext:Column ColumnID="Common" Header="<%$ Resources:QuanLyThoiViec, TinhTrang%>" DataIndex="TEN_TT_LAMVIEC" Width="120" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel ID="RowSelectionModel2" runat="server" SingleSelect="false">
                            </ext:CheckboxSelectionModel>
                        </SelectionModel>
                        <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Đồng ý" Icon="Accept" ID="btnDongYChamCong">
                        <Listeners>
                            <Click Handler="hdfTinhTrangLamViecHomNay.setValue(GetChamCongValue(#{GridPanel2}));" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDongYChamCong_Click">
                                <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline" ID="Button7">
                        <Listeners>
                            <Click Handler="wdChamCongHomNay.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Menu ID="RowContextMenu" runat="server">
                <Items>
                    <ext:MenuItem ID="MenuItem1" runat="server" Icon="UserTick" Text="Bảng chấm công">
                        <Menu>
                            <ext:Menu runat="server" ID="Menu1">
                                <Items>
                                    <ext:MenuItem ID="MenuItem5" Icon="VcardAdd" runat="server" Text="Tạo bảng chấm công">
                                        <Listeners>
                                            <Click Handler="#{wdTaoBangChamCong}.show();" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem ID="MenuItem7" Icon="Table" runat="server" Text="Quản lý bảng chấm công">
                                        <Listeners>
                                            <Click Handler="#{wdQuanLyBangChamCong}.show();" />
                                        </Listeners>
                                    </ext:MenuItem>
                                </Items>
                            </ext:Menu>
                        </Menu>
                    </ext:MenuItem>
                    <ext:MenuSeparator ID="MenuSeparator1" runat="server" />
                    <ext:MenuItem ID="mnuEditUser" runat="server" Icon="UserAdd" Text="Thêm nhân viên">
                        <Listeners>
                            <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="MenuItem4" runat="server" Icon="UserDelete" Text="Loại bỏ nhân viên">
                        <Listeners>
                            <Click Handler="RemoveEmployee();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="MenuItem2" runat="server" Icon="UserGo" Text="Chuyển nhân viên sang bảng chấm công khác">
                        <Listeners>
                            <Click Handler="if (hdfIdBangChamCong.getValue() == '') {alert('Bạn chưa chọn bảng chấm công nào'); return false;}btnLoadTimeSheetBoard.hide();btnChangeUser.show();wdChonBangChamCong.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuSeparator runat="server" />
                    <ext:MenuItem ID="mnuToday" runat="server" Icon="Build" Text="Tiện ích">
                        <Menu>
                            <ext:Menu runat="server" ID="ddd">
                                <Items>
                                    <ext:MenuItem Text="Chấm công ngày hôm nay cho tất cả nhân viên" Icon="ClockEdit">
                                        <Listeners>
                                            <Click Handler="#{wdChamCongHomNay}.show();" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Chấm công theo khoảng thời gian" Icon="Clock">
                                        <Listeners>
                                            <Click Handler="#{wdChamCongTheoKhoangThoiGian}.show();" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Đọc từ Excel" Icon="PageExcel" Hidden="true">
                                        <Listeners>
                                            <Click Handler="ImportFromExcel1_wdReadFromExcel.show();" />
                                        </Listeners>
                                    </ext:MenuItem>
                                    <ext:MenuItem Text="Xóa trắng giá trị trên bảng chấm công" Icon="ClockDelete">
                                        <Listeners>
                                            <Click Handler="if (hdfIdBangChamCong.getValue() == '') {alert('Bạn chưa chọn bảng chấm công nào');}else{ResetValueTimeSheet();}" />
                                        </Listeners>
                                    </ext:MenuItem>
                                </Items>
                            </ext:Menu>
                        </Menu>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Store ID="Store1" ShowWarningOnFailure="true" SkipIdForNewRecords="false" RefreshAfterSaving="None" runat="server">
                <Proxy>
                    <ext:HttpProxy Json="true" Method="GET" Url="Handler/ChamCongTheoThangHandler.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="={0}" />
                    <ext:Parameter Name="limit" Value="={30}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="IdBangChamCong" Value="#{hdfIdBangChamCong}.getValue()" Mode="Raw" />
                    <ext:Parameter Name="SearhKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" IDProperty="PRKEY" TotalProperty="TotalRecords">
                        <Fields>
                            <ext:RecordField Name="PRKEY" />
                            <ext:RecordField Name="MACB" />
                            <ext:RecordField Name="BoPhan" />
                            <ext:RecordField Name="TONG_CONG" />
                            <ext:RecordField Name="NGAY01" />
                            <ext:RecordField Name="NGAY02" />
                            <ext:RecordField Name="NGAY03" />
                            <ext:RecordField Name="NGAY04" />
                            <ext:RecordField Name="NGAY05" />
                            <ext:RecordField Name="NGAY06" />
                            <ext:RecordField Name="NGAY07" />
                            <ext:RecordField Name="NGAY08" />
                            <ext:RecordField Name="NGAY09" />
                            <ext:RecordField Name="NGAY10" />
                            <ext:RecordField Name="NGAY11" />
                            <ext:RecordField Name="NGAY12" />
                            <ext:RecordField Name="NGAY13" />
                            <ext:RecordField Name="NGAY14" />
                            <ext:RecordField Name="NGAY15" />
                            <ext:RecordField Name="NGAY16" />
                            <ext:RecordField Name="NGAY17" />
                            <ext:RecordField Name="NGAY18" />
                            <ext:RecordField Name="NGAY19" />
                            <ext:RecordField Name="NGAY20" />
                            <ext:RecordField Name="NGAY21" />
                            <ext:RecordField Name="NGAY22" />
                            <ext:RecordField Name="NGAY23" />
                            <ext:RecordField Name="NGAY24" />
                            <ext:RecordField Name="NGAY25" />
                            <ext:RecordField Name="NGAY26" />
                            <ext:RecordField Name="NGAY27" />
                            <ext:RecordField Name="NGAY28" />
                            <ext:RecordField Name="NGAY29" />
                            <ext:RecordField Name="NGAY30" />
                            <ext:RecordField Name="NGAY31" />
                            <ext:RecordField Name="DIEMTHUONG" />
                            <ext:RecordField Name="DIEMPHAT" />
                            <ext:RecordField Name="GHICHU" />
                            <ext:RecordField Name="FullName" />
                            <ext:RecordField Name="Birthday" />
                            <ext:RecordField Name="HL" />
                            <ext:RecordField Name="KL" />
                            <ext:RecordField Name="BHXH" />
                            <ext:RecordField Name="Phep" />
                            <ext:RecordField Name="SoPhepCon" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Window Modal="true" Hidden="true" runat="server" ID="wdChamCongTheoKhoangThoiGian"
                Layout="FormLayout" Constrain="true" Title="Chấm công theo khoảng thời gian"
                Resizable="false" Icon="DateAdd" Width="500" LabelWidth="120" Padding="6" AutoHeight="true">
                <Items>
                    <ext:Container runat="server" Layout="ColumnLayout" Height="30">
                        <Items>
                            <ext:DateField ID="FromDate" Format="dd/MM/yyyy" Editable="false" runat="server"
                                TodayText="Hôm nay" Vtype="daterange" FieldLabel="Từ ngày" ColumnWidth="0.5"
                                EnableKeyEvents="true">
                            </ext:DateField>
                            <ext:DateField ID="ToDate" runat="server" Format="dd/MM/yyyy" Editable="false" TodayText="Hôm nay"
                                Vtype="daterange" FieldLabel="Đến ngày" ColumnWidth="0.5" EnableKeyEvents="true">
                            </ext:DateField>
                        </Items>
                    </ext:Container>
                    <ext:MultiCombo ID="cbTinhTrangLamViec" runat="server" EmptyText="Chọn tình trạng làm việc"
                        TypeAhead="true" AnchorHorizontal="100%" ForceSelection="true" StoreID="Store2"
                        DisplayField="TEN_TT_LAMVIEC" ValueField="KYHIEU_TT_LAMVIEC" FieldLabel="Tình trạng làm việc"
                        MinChars="1" PageSize="15">
                        <%--<Template ID="Template1" runat="server">
                            <Html>
                                <tpl for=".">
						        <tpl if="[xindex] == 1">
							        <table class="cbStates-list">
								        <tr>
									        <th>Kí hiệu</th>
									        <th>Tình trạng làm việc</th>
								        </tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{KYHIEU_TT_LAMVIEC}</td>
							        <td>{TEN_TT_LAMVIEC}</td>
						        </tr>
						        <tpl if="[xcount-xindex]==0">
							        </table>
						        </tpl>
					        </tpl>
                            </Html>
                        </Template>--%>
                    </ext:MultiCombo>
                    <ext:CompositeField AnchorHorizontal="100%" runat="server">
                        <Items>
                            <ext:Checkbox runat="server" ID="chkSaturday" FieldLabel="Bao gồm thứ 7">
                                <Listeners>
                                    <Check Handler="if(chkSaturday.checked){
                                                            MultiComboSaturday.enable();
                                                        }else
                                                        {
                                                            MultiComboSaturday.disable();
                                                        }" />
                                </Listeners>
                            </ext:Checkbox>
                            <ext:MultiCombo ID="MultiComboSaturday" Width="322" runat="server" EmptyText="Chọn tình trạng làm việc cho thứ 7"
                                TypeAhead="true" Disabled="true" ForceSelection="true" StoreID="Store2" Mode="Local"
                                DisplayField="TEN_TT_LAMVIEC" ValueField="KYHIEU_TT_LAMVIEC" MinChars="1" PageSize="15" Editable="false">
                                <%--<Template ID="Template2" runat="server">
                                    <Html>
                                        <tpl for=".">
						                        <tpl if="[xindex] == 1">
							                        <table class="cbStates-list">
								                        <tr>
									                        <th>Kí hiệu</th>
									                        <th>Tình trạng làm việc</th>
								                        </tr>
						                        </tpl>
						                        <tr class="list-item">
							                        <td style="padding:3px 0px;">{KYHIEU_TT_LAMVIEC}</td>
							                        <td>{TEN_TT_LAMVIEC}</td>
						                        </tr>
						                        <tpl if="[xcount-xindex]==0">
							                        </table>
						                        </tpl>
					                        </tpl>
                                    </Html>
                                </Template>--%>
                            </ext:MultiCombo>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="CompositeField1" AnchorHorizontal="100%" runat="server">
                        <Items>
                            <ext:Checkbox runat="server" ID="chkSunday" FieldLabel="Bao gồm CN">
                                <Listeners>
                                    <Check Handler="if(chkSunday.checked){
                                                            MultiComboSunday.enable();
                                                        }else
                                                        {
                                                            MultiComboSunday.disable();
                                                        }" />
                                </Listeners>
                            </ext:Checkbox>
                            <ext:MultiCombo ID="MultiComboSunday" Width="322" runat="server" EmptyText="Chọn tình trạng làm việc cho chủ nhật"
                                TypeAhead="true" ForceSelection="true" Disabled="true" StoreID="Store2" Mode="Local" WrapBySquareBrackets="true"
                                DisplayField="TEN_TT_LAMVIEC" ValueField="KYHIEU_TT_LAMVIEC" MinChars="1" PageSize="15" Editable="false">
                                <%--<Template ID="Template3" runat="server">
                                    <Html>
                                        <tpl for=".">
						                        <tpl if="[xindex] == 1">
							                        <table class="cbStates-list">
								                        <tr>
									                        <th>Kí hiệu</th>
									                        <th>Tình trạng làm việc</th>
								                        </tr>
						                        </tpl>
						                        <tr class="list-item">
							                        <td style="padding:3px 0px;">{KYHIEU_TT_LAMVIEC}</td>
							                        <td>{TEN_TT_LAMVIEC}</td>
						                        </tr>
						                        <tpl if="[xcount-xindex]==0">
							                        </table>
						                        </tpl>
					                        </tpl>
                                    </Html>
                                </Template>--%>
                            </ext:MultiCombo>
                        </Items>
                    </ext:CompositeField>
                    <ext:Checkbox runat="server" BoxLabel="Chỉ áp dụng cho những nhân viên được chọn"
                        ID="chkApplyforSelectedEmployee">
                        <Listeners>
                            <Check Handler="if(#{chkApplyforSelectedEmployee}.checked){
                                            if(RowSelectEvent.getCount()==0)
                                            {
                                                btnChamCongTheoKhoangThoiGian.disable();
                                                Ext.Msg.alert('Thông báo','Bạn chưa chọn nhân viên nào, bạn phải chọn ít nhất một nhân viên để thực hiện chức năng này'); 
                                            }
                                        }else
                                        {
                                            btnChamCongTheoKhoangThoiGian.enable();
                                        }" />
                        </Listeners>
                    </ext:Checkbox>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnChamCongTheoKhoangThoiGian" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="return CheckInputChamCongTheoKhoangThoiGian();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnChamCongTheoKhoangThoiGian_Click">
                                <EventMask ShowMask="true" Msg="Đợi trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdChamCongTheoKhoangThoiGian}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="chkApplyforSelectedEmployee.reset();cbTinhTrangLamViec.reset();MultiComboSunday.reset();chkSunday.reset();chkSaturday.reset();MultiComboSaturday.reset(); FromDate.reset(); ToDate.reset();" />
                </Listeners>
            </ext:Window>
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" DisplayWorkingStatus="DangLamViec" runat="server" />
            <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
                Title="Báo cáo chấm công" Maximized="true" Icon="Printer">
                <Items>
                    <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                        runat="server">
                    </ext:TabPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="#{pnReportPanel}.remove(0);addHomePage(#{pnReportPanel},'Homepage','../Report/BaoCao_CongThang.aspx?id='+#{hdfIdBangChamCong}.getValue(), 'Báo cáo chấm công')" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="Button2" runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdShowReport}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" Layout="FormLayout" Padding="6" ID="wdTaoBangChamCong" Constrain="true"
                Title="Tạo bảng chấm công" Icon="DateAdd" Width="500" AutoHeight="true">
                <Items>
                    <ext:Hidden runat="server" ID="hdfMaDonVi" />
                    <ext:ComboBox runat="server" Editable="false" ValueField="MA" DisplayField="TEN"
                        Note="Bạn phải chọn một đơn vị. Không được phép để trống !" ID="ddfDonvi" AnchorHorizontal="100%"
                        AllowBlank="false" BlankText="Bạn phải chọn đơn vị sử dụng" ItemSelector="div.list-item"
                        FieldLabel="Đơn vị sử dụng<span style='color:red'>*</span>" CtCls="requiredData">
                        <Template ID="Template37" runat="server">
                            <Html>
                                <tpl for=".">
						                                              <div class="list-item"> 
                                                                        <tpl if="MA &gt; '-a'">{TEN}</tpl>
                                                                        <tpl if="MA &lt; 0"><span class='lineThrough'>{TEN}</span></tpl> 
						                                              </div>
					                                               </tpl>
                            </Html>
                        </Template>
                        <Store>
                            <ext:Store runat="server" ID="cbx_bophan_Store" AutoLoad="false" OnRefreshData="cbx_bophan_Store_OnRefreshData">
                                <Reader>
                                    <ext:JsonReader IDProperty="MA">
                                        <Fields>
                                            <ext:RecordField Name="MA" />
                                            <ext:RecordField Name="TEN" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <Listeners>
                            <Expand Handler="if(ddfDonvi.store.getCount()==0) cbx_bophan_Store.reload();" />
                            <Select Handler="if(ddfDonvi.getValue() <= 0) {alert('Bạn không có quyền thao tác với bộ phận này!'); ddfDonvi.reset();}txtTenBangChamCong.setValue('Bảng chấm công tháng ' + cbMonth.getValue() + '/' + txtYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, '')); hdfMaDonVi.setValue(ddfDonvi.getValue());" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }; hdfMaDonVi.reset();" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:Container ID="Containerm" Height="27" runat="server" Layout="ColumnLayout">
                        <Items>
                            <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout">
                                <Items>
                                    <ext:NumberField FieldLabel="Chọn năm<span style='color:red'>*</span>" ID="txtYear" AllowBlank="false" AllowDecimals="false" CtCls="requiredData"
                                        AllowNegative="false" BlankText="Bạn phải nhập năm" runat="server" AnchorHorizontal="98%">
                                        <Listeners>
                                            <Blur Handler="txtTenBangChamCong.setValue('Bảng chấm công tháng ' + cbMonth.getValue() + '/' + txtYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, ''));" />
                                        </Listeners>
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                            <ext:ComboBox runat="server" ID="cbMonth" SelectedIndex="0" ColumnWidth="0.5" Editable="false" CtCls="requiredData"
                                FieldLabel="Chọn tháng<span style='color:red'>*</span>">
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
                                <Listeners>
                                    <Select Handler="txtTenBangChamCong.setValue('Bảng chấm công tháng ' + cbMonth.getValue() + '/' + txtYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, ''));" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:Container>
                    <ext:TextArea ID="txtTenBangChamCong" BlankText="Bạn bắt buộc phải nhập bảng chấm công"
                        Note="Tiêu đề bảng chấm công được sinh tự động, hoặc bạn có thể thay đổi tùy ý"
                        Text="" AllowBlank="false" AnchorHorizontal="100%" ColumnWidth="1.0" FieldLabel="Tiêu đề bảng chấm công"
                        runat="server" />
                </Items>
                <Listeners>
                    <BeforeShow Handler="txtTenBangChamCong.setValue('Bảng chấm công tháng ' + cbMonth.getValue() + '/' + txtYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, ''));" />
                    <Hide Handler="ddfDonvi.reset();txtTenBangChamCong.reset();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnTaoBangChamCong" runat="server" Icon="Accept" Text="Tạo bảng công">
                        <Listeners>
                            <Click Handler=" return checkInputClick();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnTaoBangChamCong_Click">
                                <EventMask ShowMask="true" Msg="Đang tạo bảng chấm công..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button3" runat="server" Icon="Decline" Text="<%$ Resources:CommonMessage, Close%>">
                        <Listeners>
                            <Click Handler="#{wdTaoBangChamCong}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" ID="wdQuanLyBangChamCong" Constrain="true"
                Title="Quản lý bảng chấm công" Icon="Table" Layout="FormLayout" Width="660" AutoHeight="true">
                <Items>
                    <ext:Hidden ID="hdfRecordID" runat="server" />
                    <ext:GridPanel ID="grpDanhSachBangChamCong" runat="server" StripeRows="true" Border="false"
                        AnchorHorizontal="100%" Header="false" Height="350" Title="Danh sách bảng chấm công"
                        AutoExpandColumn="Title">
                        <TopBar>
                            <ext:Toolbar runat="server" ID="tbgr">
                                <Items>
                                    <ext:Button runat="server" Disabled="true" ID="btnSuaBangChamCong" Text="<%$ Resources:CommonMessage, Edit%>" Icon="Pencil">
                                        <Listeners>
                                            <Click Handler="StartEdit();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="<%$ Resources:Language, delete%>" Icon="Delete" Disabled="true" ID="btnBangChamCongDelete">
                                        <DirectEvents>
                                            <Click OnEvent="btnBangChamCongDelete_Click">
                                                <Confirmation Title="<%$ Resources:CommonMessage, Warning%>" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:ToolbarFill runat="server" ID="tbf" />
                                    <ext:TriggerField ID="txtSearch" EnableKeyEvents="true" runat="server" EmptyText="Nhập từ khóa tìm kiếm...">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <KeyPress Fn="keyEnterPress3" />
                                            <TriggerClick Handler="this.clear();this.triggers[0].hide(); #{PagingToolbar2}.pageIndex=0;#{PagingToolbar2}.doLoad(); RowSelectionModelBangLuongChamCong.clearSelections();  " />
                                        </Listeners>
                                    </ext:TriggerField>
                                    <ext:Button runat="server" Text="<%$ Resources:Language, search%>" Icon="Zoom">
                                        <Listeners>
                                            <Click Handler="#{PagingToolbar2}.pageIndex=0;#{PagingToolbar2}.doLoad(); RowSelectionModelBangLuongChamCong.clearSelections(); " />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="grpDanhSachBangChamCongStore" AutoLoad="false" AutoSave="true" ShowWarningOnFailure="false"
                                SkipIdForNewRecords="false" RefreshAfterSaving="None" runat="server">
                                <Proxy>
                                    <ext:HttpProxy Json="true" Method="GET" Url="Handler/Handler.ashx" />
                                </Proxy>
                                <AutoLoadParams>
                                    <ext:Parameter Name="start" Value="={0}" />
                                    <ext:Parameter Name="limit" Value="={10}" />
                                </AutoLoadParams>
                                <BaseParams>
                                    <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                </BaseParams>
                                <Reader>
                                    <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                        <Fields>
                                            <ext:RecordField Name="ID" />
                                            <ext:RecordField Name="CreatedBy" />
                                            <ext:RecordField Name="CreatedDate" />
                                            <ext:RecordField Name="Title" />
                                            <ext:RecordField Name="Thang" />
                                            <ext:RecordField Name="Nam" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel3" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Width="30" />
                                <ext:Column ColumnID="Title" Header="Tên bảng chấm công" Width="160" DataIndex="Title">
                                    <Editor>
                                        <ext:TextField runat="server" MaxLength="500" ID="txtTitleOfTimeSheetBoard">
                                            <Listeners>
                                                <Blur Handler="Ext.net.DirectMethods.UpdateTimeSheetBoard(txtTitleOfTimeSheetBoard.getValue());" />
                                            </Listeners>
                                        </ext:TextField>
                                    </Editor>
                                </ext:Column>
                                <ext:Column ColumnID="ThoiGianChamCong" Align="Center" Header="Thời gian chấm công"
                                    Width="120" DataIndex="Thang">
                                    <Renderer Handler="return 'Tháng '+record.data.Thang+'/'+record.data.Nam" />
                                </ext:Column>
                                <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Header="Ngày tạo" Width="80"
                                    DataIndex="CreatedDate" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModelBangLuongChamCong" runat="server">
                                <Listeners>
                                    <RowSelect Handler="btnSuaBangChamCong.enable();hdfRecordID.setValue(RowSelectionModelBangLuongChamCong.getSelected().id);btnBangChamCongDelete.enable();" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <Plugins>
                            <ext:RowEditor ID="RowEditor1" runat="server" SaveText="<%$ Resources:Language, update%>" CancelText="Hủy" />
                        </Plugins>
                        <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                    <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                        <Items>
                                            <ext:ListItem Text="5" />
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="20" />
                                        </Items>
                                        <SelectedItem Value="10" />
                                        <Listeners>
                                            <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                                <Listeners>
                                    <Change Handler="RowSelectionModelBangLuongChamCong.clearSelections();" />
                                </Listeners>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnClosewdQuanLyBangChamCong" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdQuanLyBangChamCong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="#{grpDanhSachBangChamCongStore}.reload();" />
                </Listeners>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" ID="wdChonBangChamCong" Constrain="true"
                Title="Quản lý bảng chấm công" Icon="Table" Layout="FormLayout" Width="660" AutoHeight="true">
                <Items>
                    <ext:GridPanel ID="GridPanel3" runat="server" StripeRows="true" Border="false" AnchorHorizontal="100%"
                        Header="false" StoreID="grpDanhSachBangChamCongStore" Height="350" AutoExpandColumn="Title">
                        <ColumnModel ID="ColumnModel4" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Width="30" />
                                <ext:Column ColumnID="Title" Header="Tên bảng chấm công" Width="160" DataIndex="Title">
                                </ext:Column>
                                <ext:Column ColumnID="ThoiGianChamCong" Align="Center" Header="Thời gian chấm công"
                                    Width="120" DataIndex="Thang">
                                    <Renderer Handler="return 'Tháng '+record.data.Thang+'/'+record.data.Nam" />
                                </ext:Column>
                                <ext:DateColumn Format="dd/MM/yyyy" ColumnID="CreatedDate" Header="Ngày tạo" Width="80"
                                    DataIndex="CreatedDate" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel SingleSelect="true" ID="rslChooseTimeSheet" runat="server">
                            </ext:CheckboxSelectionModel>
                        </SelectionModel>
                        <LoadMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar3" runat="server" PageSize="10">
                                <Items>
                                    <ext:Label ID="Label3" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer3" runat="server" Width="10" />
                                    <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
                                        <Items>
                                            <ext:ListItem Text="5" />
                                            <ext:ListItem Text="10" />
                                            <ext:ListItem Text="20" />
                                        </Items>
                                        <SelectedItem Value="10" />
                                        <Listeners>
                                            <Select Handler="#{PagingToolbar3}.pageSize = parseInt(this.getValue()); #{PagingToolbar3}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                                <Listeners>
                                    <Change Handler="rslChooseTimeSheet.clearSelections();" />
                                </Listeners>
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="if(grpDanhSachBangChamCongStore.getCount()==0 || #{txtSearch}.getValue() != ''){#{txtSearch}.setValue(''); grpDanhSachBangChamCongStore.reload();}" />
                    <Hide Handler="btnLoadTimeSheetBoard.show();btnChangeUser.hide();" />
                </Listeners>
                <Buttons>
                    <ext:Button Text="Đồng ý" Icon="Accept" ID="btnLoadTimeSheetBoard" runat="server">
                        <Listeners>
                            <Click Handler="return CheckSelectedRows(GridPanel3);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnLoadTimeSheetBoard_Click">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button Text="Chuyển nhân viên" Icon="UserGo" ID="btnChangeUser" Hidden="true"
                        runat="server">
                        <Listeners>
                            <Click Handler="return CheckSelectedRows(GridPanel3);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDongYChuyenNhanVien_Click">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline" ID="btnClose" runat="server">
                        <Listeners>
                            <Click Handler="wdChonBangChamCong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Viewport ID="Viewport1" runat="server" Layout="Center">
                <Items>
                    <ext:BorderLayout Border="false" Header="false" runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" Border="false" ClicksToEdit="1" Icon="Date" EnableColumnMove="false"
                                TrackMouseOver="true" runat="server" StoreID="Store1" StripeRows="true" Header="true"
                                Title="Chưa có thông tin về bảng chấm công">
                                <TopBar>
                                    <ext:Toolbar ID="Toolbar1" runat="server">
                                        <Items>
                                            <ext:Button ID="btnBangChamCong" runat="server" Icon="UserTick" Text="Bảng chấm công">
                                                <Menu>
                                                    <ext:Menu ID="Menu2" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="btnChooseTable" Text="Chọn bảng chấm công" Icon="VcardKey">
                                                                <Listeners>
                                                                    <Click Handler="wdChonBangChamCong.setTitle('Danh sách bảng chấm công'); wdChonBangChamCong.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="btnTaoBangCC" Icon="VcardAdd" runat="server" Text="Tạo bảng chấm công">
                                                                <Listeners>
                                                                    <Click Handler="wdChonBangChamCong.setTitle('Quản lý bảng chấm công'); #{wdTaoBangChamCong}.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="btnQuanLyBangChamCong" Icon="Table" runat="server" Text="Quản lý bảng chấm công">
                                                                <Listeners>
                                                                    <Click Handler="#{wdQuanLyBangChamCong}.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:ToolbarSeparator />
                                            <ext:Button ID="btnQuanLyNhanVien" runat="server" Text="Quản lý nhân viên" Icon="User">
                                                <Menu>
                                                    <ext:Menu runat="server" ID="mnuQuanLyNhanVien">
                                                        <Items>
                                                            <ext:MenuItem ID="btnDeleteUser" runat="server" Disabled="true" Icon="UserDelete"
                                                                Text="Loại bỏ nhân viên">
                                                                <Listeners>
                                                                    <Click Handler="RemoveEmployee();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuThemNhanVien" runat="server" Icon="UserAdd" Text="Thêm nhân viên">
                                                                <Listeners>
                                                                    <Click Handler="if (hdfIdBangChamCong.getValue() == '') {alert('Bạn chưa chọn bảng chấm công nào'); return false;} ucChooseEmployee1_wdChooseUser.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuChuyenNhanVienSangBangChamCongKhac" runat="server" Icon="UserGo"
                                                                Text="Chuyển nhân viên sang bảng chấm công khác">
                                                                <Listeners>
                                                                    <Click Handler="if(CheckSelectedRow(GridPanel1)){ if (hdfIdBangChamCong.getValue() == '') {alert('Bạn chưa chọn bảng chấm công nào'); return false;}btnLoadTimeSheetBoard.hide();btnChangeUser.show();wdChonBangChamCong.show();}" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="btnTienIch" runat="server" Icon="Build" Text="Tiện ích">
                                                <Menu>
                                                    <ext:Menu runat="server" ID="mnuTienIch">
                                                        <Items>
                                                            <ext:MenuItem ID="mnuChamCongHomNay" runat="server" Text="Chấm công ngày hôm nay cho tất cả nhân viên"
                                                                Icon="Clock">
                                                                <Listeners>
                                                                    <Click Handler="if (hdfIdBangChamCong.getValue() == '') {
                                                                                        alert('Bạn chưa chọn bảng chấm công nào');
                                                                                    }else{
                                                                                        #{wdChamCongHomNay}.show();
                                                                                    }" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuChamCongTheoKhoangThoiGian" runat="server" Text="Chấm công theo khoảng thời gian"
                                                                Icon="Clock">
                                                                <Listeners>
                                                                    <Click Handler="if (hdfIdBangChamCong.getValue() == '') {
                                                                                        alert('Bạn chưa chọn bảng chấm công nào');
                                                                                    }else{
                                                                                         #{wdChamCongTheoKhoangThoiGian}.show();
                                                                                    }" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuDocExcel" runat="server" Text="Đọc từ Excel" Icon="PageExcel" Hidden="true">
                                                                <Listeners>
                                                                    <Click Handler="if (hdfIdBangChamCong.getValue() == '') {
                                                                                        alert('Bạn chưa chọn bảng chấm công nào');
                                                                                    }else{
                                                                                        ImportFromExcel1_wdReadFromExcel.show();
                                                                                    }" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuResetValueTimeSheet" runat="server" Text="Xóa trắng giá trị trên bảng chấm công"
                                                                Icon="ClockDelete">
                                                                <Listeners>
                                                                    <Click Handler="if (hdfIdBangChamCong.getValue() == '') {
                                                                                        alert('Bạn chưa chọn bảng chấm công nào');
                                                                                    }else{
                                                                                         ResetValueTimeSheet();
                                                                                    }" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="btnBaoCao" runat="server" Text="In bảng công" Icon="Printer">
                                                <Listeners>
                                                    <Click Handler="if (hdfIdBangChamCong.getValue() == '') {
                                                                        alert('Bạn chưa chọn bảng chấm công nào');
                                                                    }else{
                                                                       #{wdShowReport}.show();
                                                                    }" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc họ tên nhân viên..."
                                                ID="txtSearchKey">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                    <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();RowSelectEvent.clearSelections();" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button ID="btnSearch" runat="server" Text="<%$ Resources:Language, search%>" Icon="Zoom">
                                                <Listeners>
                                                    <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();RowSelectEvent.clearSelections(); " />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Width="30" Header="STT" Locked="true" />
                                        <ext:Column Header="<%$ Resources:HOSO, staff_code%>" Width="70" ColumnID="MACB" Locked="true" DataIndex="MACB"
                                            Sortable="false" Resizable="false">
                                        </ext:Column>
                                        <ext:Column Header="<%$ Resources:HOSO, staff_name%>" Width="150" ColumnID="FullName" Locked="true" DataIndex="FullName"
                                            Sortable="false">
                                            <Renderer Fn="RenderHightLight" />
                                        </ext:Column>
                                        <ext:Column Header="<%$ Resources:HOSO, staff_section%>" ColumnID="CV" DataIndex="BoPhan" Width="150" Sortable="false"
                                            Locked="false" Resizable="true" />
                                        <%-- <ext:Column Header="<%$ Resources:HOSO, staff_birthday%>" ColumnID="NS" Width="65" Locked="false" DataIndex="Birthday"
                                        Sortable="false" Resizable="false">
                                        <Renderer Fn="GetDateFormat" />
                                    </ext:Column>--%>
                                        <ext:Column Header="Ngày 01" ColumnID="Ngay1" Resizable="false" Width="60" DataIndex="NGAY01" />
                                        <ext:Column Header="Ngày 02" ColumnID="Ngay2" Resizable="false" Width="60" DataIndex="NGAY02" />
                                        <ext:Column Header="Ngày 03" ColumnID="Ngay3" Resizable="false" Width="60" DataIndex="NGAY03" />
                                        <ext:Column Header="Ngày 04" ColumnID="Ngay4" Resizable="false" Width="60" DataIndex="NGAY04" />
                                        <ext:Column Header="Ngày 05" ColumnID="Ngay5" Resizable="false" Width="60" DataIndex="NGAY05" />
                                        <ext:Column Header="Ngày 06" ColumnID="Ngay6" Resizable="false" Width="60" DataIndex="NGAY06" />
                                        <ext:Column Header="Ngày 07" ColumnID="Ngay7" Resizable="false" Width="60" DataIndex="NGAY07" />
                                        <ext:Column Header="Ngày 08" ColumnID="Ngay8" Resizable="false" Width="60" DataIndex="NGAY08" />
                                        <ext:Column Header="Ngày 09" ColumnID="Ngay9" Resizable="false" Width="60" DataIndex="NGAY09" />
                                        <ext:Column Header="Ngày 10" ColumnID="Ngay10" Resizable="false" Width="60" DataIndex="NGAY10" />
                                        <ext:Column Header="Ngày 11" ColumnID="Ngay11" Resizable="false" Width="60" DataIndex="NGAY11" />
                                        <ext:Column Header="Ngày 12" ColumnID="Ngay12" Resizable="false" Width="60" DataIndex="NGAY12" />
                                        <ext:Column Header="Ngày 13" ColumnID="Ngay13" Resizable="false" Width="60" DataIndex="NGAY13" />
                                        <ext:Column Header="Ngày 14" ColumnID="Ngay14" Resizable="false" Width="60" DataIndex="NGAY14" />
                                        <ext:Column Header="Ngày 15" ColumnID="Ngay15" Resizable="false" Width="60" DataIndex="NGAY15" />
                                        <ext:Column Header="Ngày 16" ColumnID="Ngay16" Resizable="false" Width="60" DataIndex="NGAY16" />
                                        <ext:Column Header="Ngày 17" ColumnID="Ngay17" Resizable="false" Width="60" DataIndex="NGAY17" />
                                        <ext:Column Header="Ngày 18" ColumnID="Ngay18" Resizable="false" Width="60" DataIndex="NGAY18" />
                                        <ext:Column Header="Ngày 19" ColumnID="Ngay19" Resizable="false" Width="60" DataIndex="NGAY19" />
                                        <ext:Column Header="Ngày 20" ColumnID="Ngay20" Resizable="false" Width="60" DataIndex="NGAY20" />
                                        <ext:Column Header="Ngày 21" ColumnID="Ngay21" Resizable="false" Width="60" DataIndex="NGAY21" />
                                        <ext:Column Header="Ngày 22" ColumnID="Ngay22" Resizable="false" Width="60" DataIndex="NGAY22" />
                                        <ext:Column Header="Ngày 23" ColumnID="Ngay23" Resizable="false" Width="60" DataIndex="NGAY23" />
                                        <ext:Column Header="Ngày 24" ColumnID="Ngay24" Resizable="false" Width="60" DataIndex="NGAY24" />
                                        <ext:Column Header="Ngày 25" ColumnID="Ngay25" Resizable="false" Width="60" DataIndex="NGAY25" />
                                        <ext:Column Header="Ngày 26" ColumnID="Ngay26" Resizable="false" Width="60" DataIndex="NGAY26" />
                                        <ext:Column Header="Ngày 27" ColumnID="Ngay27" Resizable="false" Width="60" DataIndex="NGAY27" />
                                        <ext:Column Header="Ngày 28" ColumnID="Ngay28" Resizable="false" Width="60" DataIndex="NGAY28" />
                                        <ext:Column Header="Ngày 29" ColumnID="Ngay29" Resizable="false" Width="60" DataIndex="NGAY29" />
                                        <ext:Column Header="Ngày 30" ColumnID="Ngay30" Resizable="false" Width="60" DataIndex="NGAY30" />
                                        <ext:Column Header="Ngày 31" ColumnID="Ngay31" Resizable="false" Width="60" DataIndex="NGAY31" />
                                        <%--<ext:Column Header="Điểm phạt" ColumnID="DIEMPHAT" Resizable="false" Width="80" DataIndex="DIEMPHAT">
                                            <Renderer Fn="RenderNumber" />
                                            <Editor>
                                                <ext:SpinnerField ID="SpinnerField2" runat="server" AllowDecimals="true" IncrementValue="0.1"
                                                    DecimalSeparator="." />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column Header="Điểm thưởng" ColumnID="DIEMTHUONG" Resizable="false" Width="80"
                                            DataIndex="DIEMTHUONG">
                                            <Renderer Fn="RenderNumber" />
                                            <Editor>
                                                <ext:SpinnerField ID="SpinnerField3" runat="server" AllowDecimals="true" IncrementValue="0.1"
                                                    DecimalSeparator="." />
                                            </Editor>
                                        </ext:Column>--%>
                                        <ext:Column Header="Hưởng lương (thử việc)" ColumnID="HL" Width="87" DataIndex="HLTV" Align="Right">
                                            <Renderer Handler="return rendererHLTV(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Hưởng lương (chính thức)" ColumnID="HL" Width="87" DataIndex="HL" Align="Right">
                                            <Renderer Handler="return rendererHL(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Nghỉ phép" ColumnID="HL" Width="87" DataIndex="Phep" Align="Right">
                                            <Renderer Handler="return rendererNP(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Nghỉ phép (còn lại)" ColumnID="SoPhepCon" Width="87" DataIndex="SoPhepCon" Align="Right">
                                            <Renderer Handler="return rendererPhepCon(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Nghỉ bù" ColumnID="NB" Width="80" DataIndex="NB" Align="Right">
                                            <Renderer Handler="return rendererNB(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Nghỉ bù (còn lại)" ColumnID="NBConLai" Width="80" Align="Right" DataIndex="NghiBuConLai">
                                            <Renderer Handler="return rendererNBConLai(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Tổng cộng" ColumnID="TONG_CONG" Width="80" DataIndex="TONG_CONG" Align="Right">
                                            <%-- <Renderer Fn="RenderNumber" />--%>
                                            <Renderer Handler="return getTotal(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Không lương" ColumnID="HL" Width="85" DataIndex="KL" Align="Right">
                                            <Renderer Handler="return rendererKL(record.data);" />
                                        </ext:Column>
                                        <ext:Column Header="Bảo hiểm xã hội" ColumnID="HL" Width="80" DataIndex="BHXH" Align="Right">
                                            <Renderer Handler="return rendererBHXH(record.data);" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectEvent" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="try{btnDeleteUser.enable();}catch(e){}" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask Msg="<%$ Resources:Language, LoadingMask%>" ShowMask="true" />
                                <View>
                                    <ext:LockingGridView ID="LockingGridView1" runat="server" />
                                </View>
                                <Listeners>
                                    <AfterEdit Fn="afterEdit" />
                                </Listeners>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="75" />
                                                    <ext:ListItem Text="100" />
                                                </Items>
                                                <SelectedItem Value="30" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                        <Listeners>
                                            <Change Handler="#{RowSelectEvent}.clearSelections();" />
                                        </Listeners>
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
