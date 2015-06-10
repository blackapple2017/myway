<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyNghiBu.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_QuanLyNghiBu" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel" TagPrefix="uc1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        div#grpDanhSachNgayNghiBu .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }
    </style>
    <script type="text/javascript">
        var enterKeyPressHandler1 = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar2.pageIndex = 0;
                PagingToolbar2.doLoad();

                if (this.getValue() == '') {
                    this.triggers[0].hide();
                }
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var RenderValue = function (value, p, record) {
            if (value == 0 || value == null || value == '')
                return "<span style='float:right;'>-</span>";
            else {
                return "<span style='float:right;'>" + parseFloat('0' + value).toFixed(1).replace(".0", "") + "</span>";
                //return parseFloat('0' + value).toFixed(1);
            }
        }
        var RenderNumber = function (value, p, record) {
            if (value == null || value.length == 0)
                return "";
            return "<span style='float:right;'>" + value + "</span>";
        }
        var RenderTotal = function (value, p, record) {
            return "<b><span style='color:red;'>" + parseFloat('0' + value).toFixed(1).replace(".0", "") + "</span></b>";
        }
        var resetwdDieuChinhNghiBu = function () {
            nbfGiamT1.reset();
            nbfGiamT2.reset();
            nbfGiamT3.reset();
            nbfGiamT4.reset();
            nbfGiamT5.reset();
            nbfGiamT6.reset();
            nbfGiamT7.reset();
            nbfGiamT8.reset();
            nbfGiamT9.reset();
            nbfGiamT10.reset();
            nbfGiamT11.reset();
            nbfGiamT12.reset();
            nbfTangT1.reset();
            nbfTangT2.reset();
            nbfTangT3.reset();
            nbfTangT4.reset();
            nbfTangT5.reset();
            nbfTangT6.reset();
            nbfTangT7.reset();
            nbfTangT8.reset();
            nbfTangT9.reset();
            nbfTangT10.reset();
            nbfTangT11.reset();
            nbfTangT12.reset();
        }
        var setValuewdDieuChinhNghiBu = function () {
            var s = RowSelectionModel1.getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn nhân viên nào');
                return;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một nhân viên!');
                return;
            }
            var data = RowSelectionModel1.getSelected().data;
            if (data == null) {
                return;
            }
            // set value control
            nbfGiamT1.setValue(data.GiamT1);
            nbfGiamT2.setValue(data.GiamT2);
            nbfGiamT3.setValue(data.GiamT3);
            nbfGiamT4.setValue(data.GiamT4);
            nbfGiamT5.setValue(data.GiamT5);
            nbfGiamT6.setValue(data.GiamT6);
            nbfGiamT7.setValue(data.GiamT7);
            nbfGiamT8.setValue(data.GiamT8);
            nbfGiamT9.setValue(data.GiamT9);
            nbfGiamT10.setValue(data.GiamT10);
            nbfGiamT11.setValue(data.GiamT11);
            nbfGiamT12.setValue(data.GiamT12);
            nbfTangT1.setValue(data.TangT1);
            nbfTangT2.setValue(data.TangT2);
            nbfTangT3.setValue(data.TangT3);
            nbfTangT4.setValue(data.TangT4);
            nbfTangT5.setValue(data.TangT5);
            nbfTangT6.setValue(data.TangT6);
            nbfTangT7.setValue(data.TangT7);
            nbfTangT8.setValue(data.TangT8);
            nbfTangT9.setValue(data.TangT9);
            nbfTangT10.setValue(data.TangT10);
            nbfTangT11.setValue(data.TangT11);
            nbfTangT12.setValue(data.TangT12);
            wdDieuChinhNghiBu.show();

        }
        var checkDieuChinhNghiBu = function () {
            var soNgayTang = 0, soNgayGiam = 0;
            try {
                soNgayTang = parseFloat("0" + nbfTangT1.getValue()) +
                             parseFloat("0" + nbfTangT2.getValue()) +
                             parseFloat("0" + nbfTangT3.getValue()) +
                             parseFloat("0" + nbfTangT4.getValue()) +
                             parseFloat("0" + nbfTangT5.getValue()) +
                             parseFloat("0" + nbfTangT6.getValue()) +
                             parseFloat("0" + nbfTangT7.getValue()) +
                             parseFloat("0" + nbfTangT8.getValue()) +
                             parseFloat("0" + nbfTangT9.getValue()) +
                             parseFloat("0" + nbfTangT10.getValue()) +
                             parseFloat("0" + nbfTangT11.getValue()) +
                             parseFloat("0" + nbfTangT12.getValue());
                soNgayGiam = parseFloat("0" + nbfGiamT1.getValue()) +
                             parseFloat("0" + nbfGiamT2.getValue()) +
                             parseFloat("0" + nbfGiamT3.getValue()) +
                             parseFloat("0" + nbfGiamT4.getValue()) +
                             parseFloat("0" + nbfGiamT5.getValue()) +
                             parseFloat("0" + nbfGiamT6.getValue()) +
                             parseFloat("0" + nbfGiamT7.getValue()) +
                             parseFloat("0" + nbfGiamT8.getValue()) +
                             parseFloat("0" + nbfGiamT9.getValue()) +
                             parseFloat("0" + nbfGiamT10.getValue()) +
                             parseFloat("0" + nbfGiamT11.getValue()) +
                             parseFloat("0" + nbfGiamT12.getValue());
                if (soNgayGiam - soNgayTang > 0) {
                    alert("Tổng số ngày nghỉ bù đã sử dụng phải nhỏ hơn " + soNgayTang.toFixed(1).replace(".0", "") + " ngày!");
                    return false;
                }
            }
            catch (ex) {
                return false;
            }
            return true;
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM"></ext:ResourceManager>
            <ext:Hidden runat="server" ID="hdfRecordID"></ext:Hidden>
            <ext:Window Icon="Date" runat="server" ID="wdDieuChinhNghiBu" Resizable="false"
                Layout="FormLayout" Constrain="true" Hidden="true" AutoHeight="true" Width="615"
                Padding="6" Modal="true" Title="Điều chỉnh ngày nghỉ bù">
                <Items>
                    <ext:FieldSet runat="server" AutoHeight="true" LabelWidth="150" Title="Số ngày nghỉ bù được thêm"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:CompositeField runat="server" ID="CompositeField15" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField118" runat="server" Text="Tháng 01" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT1" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField8" runat="server" Text="Tháng 02" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT2" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField9" runat="server" Text="Tháng 03" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT3" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField10" runat="server" Text="Tháng 04" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT4" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" ID="CompositeField3" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField11" runat="server" Text="Tháng 05" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT5" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField12" runat="server" Text="Tháng 06" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT6" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField13" runat="server" Text="Tháng 07" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT7" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField14" runat="server" Text="Tháng 08" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT8" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" ID="CompositeField4" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField15" runat="server" Text="Tháng 09" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT9" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField16" runat="server" Text="Tháng 10" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT10" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField17" runat="server" Text="Tháng 11" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT11" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField18" runat="server" Text="Tháng 12" />
                                    <ext:TextField runat="server" Width="40" ID="nbfTangT12" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet runat="server" AutoHeight="true" LabelWidth="150" Title="Số ngày nghỉ bù đã sử dụng"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:CompositeField runat="server" ID="CompositeField1" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField runat="server" Text="Tháng 01" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT1" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField1" runat="server" Text="Tháng 02" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT2" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField2" runat="server" Text="Tháng 03" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT3" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField3" runat="server" Text="Tháng 04" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT4" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" ID="CompositeField2" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField4" runat="server" Text="Tháng 05" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT5" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField5" runat="server" Text="Tháng 06" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT6" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField6" runat="server" Text="Tháng 07" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT7" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField7" runat="server" Text="Tháng 08" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT8" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" ID="CompositeField5" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField19" runat="server" Text="Tháng 09" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT9" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField20" runat="server" Text="Tháng 10" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT10" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField21" runat="server" Text="Tháng 11" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT11" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                    <ext:DisplayField ID="DisplayField22" runat="server" Text="Tháng 12" />
                                    <ext:TextField runat="server" Width="40" ID="nbfGiamT12" MaskRe="/[0-9.,]/">
                                    </ext:TextField>
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnDieuChinhNghiBu" runat="server" Text="<%$ Resources:Language, accept%>" Icon="Accept">
                        <Listeners>
                            <Click Handler="return checkDieuChinhNghiBu();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDieuChinhNghiBu_Click">
                                <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdDieuChinhNghiBu.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeHide Handler="resetwdDieuChinhNghiBu();" />
                </Listeners>
            </ext:Window>
            <ext:Hidden ID="hdfYear" runat="server"></ext:Hidden>
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfMenuID" />
            <ext:Hidden runat="server" ID="hdfUserID" />
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="grpDanhSachNgayNghiBu" runat="server"
                                StripeRows="true" Border="false" Icon="BookOpen">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tbDanhSachNgayPhep">
                                        <Items>
                                            <%--<ext:Button ID ="Button1" runat="server" Icon="Pencil" Text="<%$ Resources:HOSO, edit%>"></ext:Button>--%>
                                            <ext:Button ID="btnEdit" runat="server" Icon="Pencil" Text="Sửa">
                                                <Listeners>
                                                    <Click Handler="setValuewdDieuChinhNghiBu();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarSpacer Width="20"></ext:ToolbarSpacer>
                                            <ext:DisplayField Text="<b>Năm</b>" runat="server"></ext:DisplayField>
                                            <ext:ToolbarSpacer Width="10"></ext:ToolbarSpacer>
                                            <ext:SpinnerField runat="server" ID="spfYear" MaskRe="/[0-9]/" EnableKeyEvents="true"
                                                Width="50" MinValue="1900" MaxValue="3000">
                                                <Listeners>
                                                    <Spin Handler=" hdfYear.setValue(spfYear.getValue()); PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();" />
                                                </Listeners>
                                            </ext:SpinnerField>
                                            <ext:ToolbarFill runat="server" ID="tbf1" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc tên cán bộ"
                                                ID="txtSearch">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler1" />
                                                    <TriggerClick Handler="this.reset(); this.triggers[0].hide(); PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button Text="<%$ Resources:Language, search%>" Icon="Zoom" runat="server" ID="btnSearch">
                                                <Listeners>
                                                    <Click Handler="PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv">
                                    </ext:LockingGridView>
                                </View>
                                <Store>
                                    <ext:Store runat="server" ID="stDanhSachNgayNghiBu" AutoLoad="true" GroupField="TEN_DONVI">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="Handler/HandlerQuanLyNghiBu.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={30}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="Year" Value="hdfYear.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="MA_CB" />
                                                    <ext:RecordField Name="HO_TEN" />
                                                    <ext:RecordField Name="TEN_DONVI" />
                                                    <ext:RecordField Name="TangT1" />
                                                    <ext:RecordField Name="TangT2" />
                                                    <ext:RecordField Name="TangT3" />
                                                    <ext:RecordField Name="TangT4" />
                                                    <ext:RecordField Name="TangT5" />
                                                    <ext:RecordField Name="TangT6" />
                                                    <ext:RecordField Name="TangT7" />
                                                    <ext:RecordField Name="TangT8" />
                                                    <ext:RecordField Name="TangT9" />
                                                    <ext:RecordField Name="TangT10" />
                                                    <ext:RecordField Name="TangT11" />
                                                    <ext:RecordField Name="TangT12" />
                                                    <ext:RecordField Name="GiamT1" />
                                                    <ext:RecordField Name="GiamT2" />
                                                    <ext:RecordField Name="GiamT3" />
                                                    <ext:RecordField Name="GiamT4" />
                                                    <ext:RecordField Name="GiamT5" />
                                                    <ext:RecordField Name="GiamT6" />
                                                    <ext:RecordField Name="GiamT7" />
                                                    <ext:RecordField Name="GiamT8" />
                                                    <ext:RecordField Name="GiamT9" />
                                                    <ext:RecordField Name="GiamT10" />
                                                    <ext:RecordField Name="GiamT11" />
                                                    <ext:RecordField Name="GiamT12" />
                                                    <ext:RecordField Name="SoNgayNghiBuConLai" />
                                                    <ext:RecordField Name="Nam" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel3" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="<%$ Resources:HOSO, Stt%>" Locked="true" Width="35" />
                                        <ext:Column ColumnID="MA_CB" Header="Mã nhân viên" Locked="true" Width="90" DataIndex="MA_CB" />
                                        <ext:Column ColumnID="HO_TEN" Header="<%$ Resources:HOSO, staff_name%>" Locked="true" Width="150" DataIndex="HO_TEN" />
                                        <ext:Column ColumnID="TEN_DONVI" Header="<%$ Resources:HOSO, staff_section%>" Locked="true" Width="150" DataIndex="TEN_DONVI" />
                                        <ext:Column Header="Tăng T1" Width="60" DataIndex="TangT1">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T1" Width="60" DataIndex="GiamT1">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T2" Width="60" DataIndex="TangT2">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T2" Width="60" DataIndex="GiamT2">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T3" Width="60" DataIndex="TangT3">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T3" Width="60" DataIndex="GiamT3">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T4" Width="60" DataIndex="TangT4">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T4" Width="60" DataIndex="GiamT4">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T5" Width="60" DataIndex="TangT5">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T5" Width="60" DataIndex="GiamT5">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T6" Width="60" DataIndex="TangT6">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T6" Width="60" DataIndex="GiamT6">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T7" Width="60" DataIndex="TangT7">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T7" Width="60" DataIndex="GiamT7">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T8" Width="60" DataIndex="TangT8">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T8" Width="60" DataIndex="GiamT8">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T9" Width="60" DataIndex="TangT9">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T9" Width="60" DataIndex="GiamT9">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T10" Width="60" DataIndex="TangT10">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T10" Width="60" DataIndex="GiamT10">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T11" Width="60" DataIndex="TangT11">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T11" Width="60" DataIndex="GiamT11">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Tăng T12" Width="60" DataIndex="TangT12">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Giảm T12" Width="60" DataIndex="GiamT12">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Số ngày nghỉ bù còn lại" Width="90" DataIndex="SoNgayNghiBuConLai" Align="Right">
                                            <Renderer Fn="RenderTotal" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="hdfRecordID.setValue(RowSelectionModel1.getSelected().data.ID);" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <Listeners>
                                    <DblClick Handler="setValuewdDieuChinhNghiBu();" />
                                </Listeners>
                                <LoadMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Updating_Data%>" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="30">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, page_size%>" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="60">
                                                <Items>
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="100" />
                                                    <ext:ListItem Text="200" />
                                                    <ext:ListItem Text="500" />
                                                    <ext:ListItem Text="1000" />
                                                    <ext:ListItem Text="5000" />
                                                    <ext:ListItem Text="10000" />
                                                </Items>
                                                <SelectedItem Value="30" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:DisplayField runat="server" ID="dpfTrangThai" />
                                        </Items>
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
