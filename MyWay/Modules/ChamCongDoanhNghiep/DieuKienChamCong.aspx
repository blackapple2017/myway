<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DieuKienChamCong.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_DieuKienChamCong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div#grpNhomDieuKien-xsplit
        {
            border-right: 1px solid #98C0F4;
            border-left: 1px solid #98C0F4;
        }
    </style>
    <script type="text/javascript">
        //Tên các nhóm điều kiện
        var cuoiTuanBaoGom = "Cuối tuần bao gồm";
        var tongHopCong = "Tổng hợp công";
        var excelDoc = "Cấu hình nhập Excel định dạng dọc";
        var excelNgang = "Cấu hình nhập Excel định dạng ngang";
        var tongHopCong = "Tổng hợp công";

        var renderValue = function (value, p, record) {
            var sImageCheck = "<img  src='../../Resource/Images/check.png'>"
            var sImageUnCheck = "<img src='../../Resource/Images/uncheck.gif'>"
            if (record.data.GroupDescription == cuoiTuanBaoGom || record.data.GroupDescription == "Quên chấm công") {
                if (value == "True") {
                    return sImageCheck;
                }
                else {
                    return sImageUnCheck;
                }
            }
            if (record.data.GroupDescription == excelDoc || record.data.GroupDescription == excelNgang) {
                if (value != null) {
                    return "Cột " + value;
                }
                return "";
            }
            if (record.data.GroupDescription == tongHopCong) {
                if (value == 'NGANG')
                    return 'Định dạng ngang';
                else if (value == 'DOC')
                    return 'Định dạng dọc';
                else if (value == 'THANG')
                    return 'Theo tháng';
                else if (value == 'BOPHAN')
                    return 'Theo bộ phận';
                else if (value == 'CalculateEveryMonth')
                    return 'Thay đổi từng tháng';
            }
            return value;
        }
        var updateAfterChange = function (e) {
            var id = e.record.data.ID;            
            Ext.net.DirectMethods.UpdateValue(e.record.data.ID, e.field, e.value);
            grpGiaTriStore.commitChanges();
        }
        //var showEditWindow = function () {
        //    if (RowSelectionModel1.getSelected().data.GroupDescription == cuoiTuanBaoGom) {
        //        wdCuoiTuanBaoGom.show();
        //    }
        //    else if (RowSelectionModel1.getSelected().data.GroupDescription == tongHopCong) {//tổng hợp công
        //        wdSoNgayCongChuan.show();
        //    }
        //    else if (RowSelectionModel1.getSelected().data.GroupDescription == excelNgang) {
        //        wdTepTinChamCong.show();
        //        nbfCotVao.hide();
        //        nbfCotRa.hide();
        //        nbfCotThoiGian.show();
        //        btnTepTinChamCongDoc.hide();
        //        btnTepTinChamCongNgang.show();
        //        hdfLoaiFileExcel.setValue('Ngang');
        //    }
        //    else if (RowSelectionModel1.getSelected().data.GroupDescription == excelDoc) {
        //        wdTepTinChamCong.show();
        //        nbfCotVao.show();
        //        nbfCotRa.show();
        //        nbfCotThoiGian.hide();
        //        btnTepTinChamCongDoc.show();
        //        btnTepTinChamCongNgang.hide();
        //        hdfLoaiFileExcel.setValue('Doc');
        //    }
        //}
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM">
                <Listeners>
                    <DocumentReady Handler="grpNhomDieuKienStore.reload();" />
                </Listeners>
            </ext:ResourceManager>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" LabelWidth="150" ID="wdQuenChamCong"
                Title="Quên chấm công" Icon="Pencil">
                <Items>
                    <ext:NumberField runat="server" MaxLength="2" FieldLabel="Số ngày công chuẩn" MaxValue="31"
                        AnchorHorizontal="100%" ID="NumberField1" />
                </Items>
                <DirectEvents>
                    <BeforeShow OnEvent="wdQuenChamCong_BeforeShow">
                    </BeforeShow>
                </DirectEvents>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhatQuenChamCong" Text="Cập nhật" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatQuenChamCong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button4" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdQuenChamCong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" LabelWidth="150" ID="wdSoNgayCongChuan"
                Title="Tổng hợp công" Icon="Pencil">
                <Items>
                    <ext:FieldSet runat="server" Title="Số ngày công chuẩn" AnchorHorizontal="100%">
                        <Items>
                            <ext:CompositeField runat="server" FieldLabel="Hình thức" AnchorHorizontal="100%">
                                <Items>
                                    <ext:ComboBox runat="server" ID="cbHinhThucNgayCong" Width="140" SelectedIndex="0" Editable="false">
                                        <Items>
                                            <ext:ListItem Text="cố định số ngày" Value="Fix" />
                                            <ext:ListItem Text="Thay đổi từng tháng" Value="CalculateEveryMonth" />
                                        </Items>
                                        <Listeners>
                                            <Select Handler="if(cbHinhThucNgayCong.getValue()=='CalculateEveryMonth'){nbfSoNgayCongChuan.disable();}
                                                         else{nbfSoNgayCongChuan.enable();}" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:DisplayField runat="server" ID="dpf" Text="Số ngày" />
                                    <ext:NumberField runat="server" MaxLength="2" FieldLabel="Số ngày công chuẩn" MaxValue="31"
                                        AnchorHorizontal="100%" ID="nbfSoNgayCongChuan" />
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet runat="server" ID="fsDinhDangExcelVaoRa" Title="Cấu hình định dạng file Excel vào ra ca"
                        AnchorHorizontal="100%" Layout="FormLayout" LabelWidth="1">
                        <Items>
                            <ext:RadioGroup runat="server" ID="chkg1" ColumnsNumber="1" AnchorHorizontal="100%">
                                <Items>
                                    <ext:Radio runat="server" ID="chkExcelNgang" BoxLabel="File Excel định dạng dữ liệu ngang"
                                        Checked="true">
                                        <ToolTips>
                                            <ext:ToolTip ID="tooltipNgang" runat="server" Title="Excel định dạng ngang" AutoWidth="true">
                                                <Content>
                                                    <img alt="File Excel định dạng ngang" src="../../Resource/images/excel_ngang.png" />
                                                </Content>
                                            </ext:ToolTip>
                                        </ToolTips>
                                    </ext:Radio>
                                    <ext:Radio runat="server" ID="chkExcelDoc" BoxLabel="File Excel định dạng dữ liệu dọc">
                                        <ToolTips>
                                            <ext:ToolTip ID="tooltipDoc" runat="server" Title="Excel định dạng dọc" AutoWidth="true">
                                                <Content>
                                                    <img alt="File Excel định dạng dữ liệu dọc" src="../../Resource/images/excel_doc.png" />
                                                </Content>
                                            </ext:ToolTip>
                                        </ToolTips>
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet runat="server" ID="fsCachPhanCa" Title="Cấu hình cách phân ca làm việc"
                        AnchorHorizontal="100%" Layout="FormLayout" LabelWidth="1">
                        <Items>
                            <ext:RadioGroup runat="server" ID="chkg2" ColumnsNumber="1" AnchorHorizontal="100%">
                                <Items>
                                    <ext:Radio runat="server" ID="chkPhanCaThang" BoxLabel="Phân ca theo tháng" Checked="true">
                                    </ext:Radio>
                                    <ext:Radio runat="server" ID="chkPhanCaTheoBoPhan" BoxLabel="Phân ca theo bộ phận">
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <DirectEvents>
                    <BeforeShow OnEvent="wdSoNgayCongChuan_BeforeShow">
                    </BeforeShow>
                </DirectEvents>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhatTongHopCong" Text="Cập nhật" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatTongHopCong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button3" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdSoNgayCongChuan.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" LabelWidth="120" ID="wdTepTinChamCong"
                Title="Định dạng tệp tin chấm công" Icon="Pencil">
                <Items>
                    <ext:NumberField runat="server" FieldLabel="Cột mã chấm công" AnchorHorizontal="100%"
                        ID="nbfMaCotChamCong" />
                    <ext:NumberField runat="server" FieldLabel="Cột ngày chấm công" AnchorHorizontal="100%"
                        ID="nbfCotNgayChamCong" />
                    <ext:NumberField runat="server" FieldLabel="Cột thời gian" AnchorHorizontal="100%"
                        ID="nbfCotThoiGian" />
                    <ext:NumberField runat="server" FieldLabel="Cột vào" AnchorHorizontal="100%" ID="nbfCotVao"
                        Hidden="true" />
                    <ext:NumberField runat="server" FieldLabel="Cột ra" AnchorHorizontal="100%" ID="nbfCotRa"
                        Hidden="true" />
                    <ext:Hidden runat="server" ID="hdfLoaiFileExcel" />
                </Items>
                <DirectEvents>
                    <BeforeShow OnEvent="wdTepTinChamCong_BeforeShow">
                        <ExtraParams>
                            <ext:Parameter Name="LoaiExcel" Value="hdfLoaiFileExcel.getValue()" Mode="Raw">
                            </ext:Parameter>
                        </ExtraParams>
                    </BeforeShow>
                </DirectEvents>
                <Buttons>
                    <ext:Button runat="server" ID="btnTepTinChamCongNgang" Text="Cập nhật" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnTepTinChamCong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                <ExtraParams>
                                    <ext:Parameter Name="ChamCongNgang" Value="True">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnTepTinChamCongDoc" Hidden="true" Text="Cập nhật"
                        Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnTepTinChamCong_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                <ExtraParams>
                                    <ext:Parameter Name="ChamCongNgang" Value="False">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdTepTinChamCong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="RowLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" ID="wdCuoiTuanBaoGom" Title="Cuối tuần bao gồm"
                Icon="Pencil">
                <Items>
                    <ext:CheckboxGroup AnchorHorizontal="100%" ColumnsNumber="1" runat="server" ID="checkBoxGroup">
                        <Items>
                            <ext:Checkbox runat="server" ID="chkSangThu6" BoxLabel="Sáng thứ 6">
                            </ext:Checkbox>
                            <ext:Checkbox runat="server" ID="chkChieuThu6" BoxLabel="Chiều thứ 6">
                            </ext:Checkbox>
                            <ext:Checkbox runat="server" ID="chkSangThu7" BoxLabel="Sáng thứ 7">
                            </ext:Checkbox>
                            <ext:Checkbox runat="server" ID="chkChieuThu7" BoxLabel="Chiều thứ 7">
                            </ext:Checkbox>
                            <ext:Checkbox runat="server" ID="chkChuNhat" BoxLabel="Chủ nhật">
                            </ext:Checkbox>
                        </Items>
                    </ext:CheckboxGroup>
                </Items>
                <DirectEvents>
                    <BeforeShow OnEvent="wdCuoiTuanBaoGom_BeforeShow">
                    </BeforeShow>
                </DirectEvents>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhatCuoiTuan" Text="Cập nhật" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatCuoiTuan_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdCuoiTuanBaoGom.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Button ID="btnEditValue" runat="server" Icon="Pencil" Text="Sửa">
                <DirectEvents>
                    <Click OnEvent="Modules_DieuKienChamCong_DirectClick">
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brLayout">
                        <West Split="true">
                            <ext:GridPanel ID="grpNhomDieuKien" TrackMouseOver="true" Border="false" runat="server"
                                StripeRows="true" Title="Nhóm điều kiện" Width="400" AutoExpandColumn="GroupDescription">
                                <Store>
                                    <ext:Store ID="grpNhomDieuKienStore" OnRefreshData="grpNhomDieuKienStore_grpNhomDieuKienStore"
                                        runat="server">
                                        <Reader>
                                            <ext:JsonReader IDProperty="GroupID">
                                                <Fields>
                                                    <ext:RecordField Name="GroupID" />
                                                    <ext:RecordField Name="GroupDescription" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="35" />
                                        <ext:Column ColumnID="GroupDescription" Header="Tên điều kiện" Width="160" DataIndex="GroupDescription" />
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="PagingToolbar1.pageIndex=0;PagingToolbar1.doLoad();grpGiaTriStore.reload();" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <BottomBar>
                                    <ext:PagingToolbar runat="server" ID="pgingToolbar">
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </West>
                        <Center>
                            <ext:GridPanel ID="grpGiaTri" Border="false" runat="server" StripeRows="true" Title="Thiết lập giá trị"
                                Width="250" AutoExpandColumn="Description">
                                <Store>
                                    <ext:Store ID="grpGiaTriStore" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="Handler/HandlerDieuKienChamCong.ashx">
                                            </ext:HttpProxy>
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}">
                                            </ext:Parameter>
                                            <ext:Parameter Name="limit" Value="={30}">
                                            </ext:Parameter>
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Mode="Raw" Value="RowSelectionModel1.getSelected().id" Name="groupID" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="ParamDescription" />
                                                    <ext:RecordField Name="Value" />
                                                    <ext:RecordField Name="IsInUsed" />
                                                    <ext:RecordField Name="GroupDescription" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <AfterEdit Fn="updateAfterChange" />
                                </Listeners>
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tbb">
                                        <Items>
                                            <%--<ext:Button runat="server" ID="btnSua" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="showEditWindow();" />
                                            </Listeners>
                                        </ext:Button>--%>
                                            <ext:Button runat="server" ID="Button1" Text="Khôi phục giá trị mặc định" Icon="ArrowRefresh">
                                                <DirectEvents>
                                                    <Click OnEvent="btnResetValue_Click">
                                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn khôi phục về giá trị mặc định ?"
                                                            ConfirmRequest="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel ID="ColumnModel2" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="35" />
                                        <ext:Column ColumnID="Value" Header="Giá trị" Width="160" DataIndex="Value">
                                            <Renderer Fn="renderValue" />
                                            <Editor>
                                                <ext:TextField runat="server" ID="txtValue" />
                                            </Editor>
                                        </ext:Column>
                                        <ext:Column Header="Mô tả" Width="175" DataIndex="ParamDescription" ColumnID="Description">
                                        </ext:Column>
                                        <ext:Column Header="Đang sử dụng" Width="100" DataIndex="IsInUsed">
                                            <Editor>
                                                <ext:Checkbox runat="server" ID="chkIsInUsed" />
                                            </Editor>
                                            <Renderer Fn="renderValue" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <BottomBar>
                                    <ext:PagingToolbar runat="server" ID="PagingToolbar1">
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
