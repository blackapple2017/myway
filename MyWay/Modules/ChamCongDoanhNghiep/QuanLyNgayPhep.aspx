<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyNgayPhep.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_QuanLyNgayPhep" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc1" %>
<%@ Register Src="ucQuyTacTinhNgayPhep.ascx" TagName="ucQuyTacTinhNgayPhep" TagPrefix="uc2" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="Resource/JsQuanLyNgayPhep.js" type="text/javascript"></script>
    <link href="Resource/Default.css" rel="stylesheet" type="text/css" />
    <style type="text/css">
        #grpDanhSachNgayPhep_GridPanel1 {
            border-left: 1px solid #99bbe8 !important;
        }

        #grpDanhSachNgayPhep_pnlCoCauToChuc-xsplit {
            border-right: none !important;
        }

        .list-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }

        div#grpDanhSachNgayPhep .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }
    </style>
    <script type="text/javascript">

        var RemoveItemOnGrid = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        hdfSelectedEmployees.setValue("," + hdfSelectedEmployees.getValue().replace("," + r.data.MA_CB + ",", "") + ",");
                        Store.remove(r);
                        btnDeleteEmployee.disable();
                    }
                }
            });
        }
        var CheckSelectedRecordPrint = function (grid, Store) {
            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count == 0) {
                alert('Bạn chưa chọn nhân viên nào');
                return false;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một nhân viên');
                return false;
            }
            return true;
        }
        var validateThemNhanVienVaoDanhSach = function () {
            if (cbDoiTuongApDung.getValue() == '') {
                alert("Bạn chưa chọn đối tượng áp dụng");
                return false;
            }
            //if (nbfSoNgayPhepNamNay.getValue() == '') {
            //    nbfSoNgayPhepNamNay.focus();
            //    alert("Bạn chưa nhập số ngày phép năm nay");
            //    return false;
            //}
            return true;
        }

        var resetThemNhanVienVaoDanhSach = function () {
            cbDoiTuongApDung.reset();
            cbHopDongLoaiHopDong.reset();
            nbfThamNien.reset();
            cbThoiGianThamNien.reset();
            cbxHinhThucLamViec.reset();
            nbfSoNgayPhepNamNay.reset();
            chkTuDongTinhNgayPhep.reset();
            nbfSoNgayPhepDuocThem.reset();
            nbfSoNgayPhepNamTruoc.reset();
            hdfSelectedEmployees.reset();
            dfHanSuDungNPNamTruoc.reset();
        }

        var changeTitle = function (triggerField) {
            $("div#grpDanhSachNgayPhep .x-panel-header-text").html("Danh sách ngày phép cán bộ công nhân viên năm " + triggerXemTheoNam.getValue());
        }

        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                //                grpDanhSachNgayPhep_hdfWhereClause.setValue('Nam = ' + grpDanhSachNgayPhep_triggerXemTheoNam.getValue());
                //                Store1.reload();
                //                changeTitle(grpDanhSachNgayPhep_triggerXemTheoNam);
            }
            if (triggerXemTheoNam.getValue() != '') {
                this.triggers[0].show();
            } else {
                this.triggers[0].hide();
            }
        }
        var enterKeyPressHandler1 = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar2.pageIndex = 0;
                PagingToolbar2.doLoad();
                RowSelectionModelNgayPhep.clearSelections();
                if (this.getValue() == '') {
                    this.triggers[0].hide();
                }
            }
            if (this.getValue() != '') {
                this.triggers[0].show();
            }
        }
        var enterKeyPressHandler2 = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar2.pageIndex = 0;
                PagingToolbar2.doLoad();
                changeTitle(this);
                RowSelectionModelNgayPhep.clearSelections();
            }
        }
        var resetwdDieuChinhNgayPhep = function () {
            nbfDieuChinhSoNPNamTruoc.reset();
            nbfDieuChinhNgayPhepNamNay.reset();
            nbfDieuChinhNgayPhepDuocThem.reset();
            nbfThang1.reset();
            nbfThang2.reset();
            nbfThang3.reset();
            nbfThang4.reset();
            nbfThang5.reset();
            nbfThang6.reset();
            nbfThang7.reset();
            nbfThang8.reset();
            nbfThang9.reset();
            nbfThang10.reset();
            nbfThang11.reset();
            nbfThang12.reset();
        }
        var setValuewdDieuChinhNgayPhep = function () {
            var data = RowSelectionModelNgayPhep.getSelected().data;
            if (data != null) {
                nbfDieuChinhSoNPNamTruoc.setValue(data.SoNgayPhepNamTruoc);
                nbfDieuChinhNgayPhepNamNay.setValue(data.SoNgayPhepNamNay);
                nbfDieuChinhNgayPhepDuocThem.setValue(data.SoNgayPhepDuocThem);
                nbfThang1.setValue(data.Thang1);
                nbfThang2.setValue(data.Thang2);
                nbfThang3.setValue(data.Thang3);
                nbfThang4.setValue(data.Thang4);
                nbfThang5.setValue(data.Thang5);
                nbfThang6.setValue(data.Thang6);
                nbfThang7.setValue(data.Thang7);
                nbfThang8.setValue(data.Thang8);
                nbfThang9.setValue(data.Thang9);
                nbfThang10.setValue(data.Thang10);
                nbfThang11.setValue(data.Thang11);
                nbfThang12.setValue(data.Thang12);
            }
        }
        var checkDieuChinhNgayPhepQuaHan = function () {
            if (!checkInput(nbfDieuChinhSoNPNamTruoc)) { return false; }
            if (!checkInput(nbfDieuChinhNgayPhepNamNay)) { return false; }
            if (!checkInput(nbfDieuChinhNgayPhepDuocThem)) { return false; }
            if (!checkInput(nbfThang1)) { return false; }
            if (!checkInput(nbfThang2)) { return false; }
            if (!checkInput(nbfThang3)) { return false; }
            if (!checkInput(nbfThang4)) { return false; }
            if (!checkInput(nbfThang5)) { return false; }
            if (!checkInput(nbfThang6)) { return false; }
            if (!checkInput(nbfThang7)) { return false; }
            if (!checkInput(nbfThang8)) { return false; }
            if (!checkInput(nbfThang9)) { return false; }
            if (!checkInput(nbfThang10)) { return false; }
            if (!checkInput(nbfThang11)) { return false; }
            if (!checkInput(nbfThang12)) { return false; }
            var a1 = parseFloat("0" + nbfDieuChinhSoNPNamTruoc.getValue());
            var a2 = parseFloat("0" + nbfDieuChinhNgayPhepNamNay.getValue());
            var a3 = parseFloat("0" + nbfDieuChinhNgayPhepDuocThem.getValue());
            var t1 = parseFloat("0" + nbfThang1.getValue());
            var t2 = parseFloat("0" + nbfThang2.getValue());
            var t3 = parseFloat("0" + nbfThang3.getValue());
            var t4 = parseFloat("0" + nbfThang4.getValue());
            var t5 = parseFloat("0" + nbfThang5.getValue());
            var t6 = parseFloat("0" + nbfThang6.getValue());
            var t7 = parseFloat("0" + nbfThang7.getValue());
            var t8 = parseFloat("0" + nbfThang8.getValue());
            var t9 = parseFloat("0" + nbfThang9.getValue());
            var t10 = parseFloat("0" + nbfThang10.getValue());
            var t11 = parseFloat("0" + nbfThang11.getValue());
            var t12 = parseFloat("0" + nbfThang12.getValue());
            if ((t1 + t2 + t3 + t4 + t5 + t6 + t7 + t8 + t9 + t10 + t11 + t12) > (a1 + a2 + a3)) {
                alert("Số ngày phép đã vượt quá số ngày phép được hưởng");
                nbfThang1.focus();
                return false;
            }
            return true;
        }
        var CheckNumber = function (value) {
            var a = isNaN(value);
            return a;
        }
        var checkInput = function (tf) {
            if (CheckNumber(tf.getValue()) == true) {
                alert('Định dạng số không đúng');
                tf.focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:Hidden runat="server" ID="hdfDateNow" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfMenuID" />
            <ext:Hidden runat="server" ID="hdfUserID" />
            <ext:ResourceManager runat="server" ID="RM">
                <Listeners>
                    <DocumentReady Handler="Ext.net.DirectMethods.DocumentReady_Event();" />
                </Listeners>
            </ext:ResourceManager>
            <uc3:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
            <ext:Window Icon="Date" runat="server" ID="wdTinhSoNgayPhep" Resizable="false" Constrain="true"
                Hidden="true" AutoHeight="true" Width="550" Padding="6" Modal="true" Title="Cập nhật ngày nghỉ phép">
                <Items>
                    <ext:FieldSet runat="server" AnchorHorizontal="100%" Title="Số ngày phép năm trước">
                        <Items>
                            <ext:CompositeField runat="server" FieldLabel="Số ngày phép">
                                <Items>
                                    <ext:DisplayField runat="server" Text="Năm nay" />
                                    <ext:NumberField runat="server" ID="nbfSoNgayPhep" Width="50">
                                        <ToolTips>
                                            <ext:ToolTip Closable="true" Draggable="true" AutoHide="false" ID="tl" runat="server"
                                                Title="Số ngày phép được hưởng trong 1 năm" Header="true" Frame="true" Html="Gợi ý : 12 ngày phép trong 1 năm">
                                            </ext:ToolTip>
                                        </ToolTips>
                                        <Listeners>
                                            <Blur Handler="tl.hide();" />
                                            <Focus Handler="tl.show();" />
                                        </Listeners>
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField1" runat="server" Text="Thưởng phép">
                                    </ext:DisplayField>
                                    <ext:NumberField ID="nbfSoNgayPhepThuongThem" runat="server" Width="50" FieldLabel="Thưởng phép">
                                        <ToolTips>
                                            <ext:ToolTip Closable="true" Draggable="true" AutoHide="false" ID="ToolTip1" runat="server"
                                                Title="Thưởng phép" Header="true" Frame="true" Html="Số ngày phép mà công ty thưởng thêm cho nhân viên">
                                            </ext:ToolTip>
                                        </ToolTips>
                                        <Listeners>
                                            <Blur Handler="ToolTip1.hide();" />
                                            <Focus Handler="ToolTip1.show();" />
                                        </Listeners>
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField2" runat="server" Text="Cộng dồn năm trước" />
                                    <ext:Checkbox ID="chkNgayNghiPhepNamTruoc" runat="server">
                                        <Listeners>
                                            <Check Handler="if(chkNgayNghiPhepNamTruoc.checked){
                                                    dfHanDungNgayPhepNamTruoc.enable();
                                                }else
                                                {
                                                    dfHanDungNgayPhepNamTruoc.disable();
                                                }" />
                                        </Listeners>
                                    </ext:Checkbox>
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" AnchorHorizontal="100%" FieldLabel="Hạn dùng">
                                <Items>
                                    <ext:DisplayField runat="server" Text="Năm trước" />
                                    <ext:DateField ID="dfHanDungNgayPhepNamTruoc" Width="100" NoteAlign="Top" runat="server">
                                        <ToolTips>
                                            <ext:ToolTip Closable="true" Draggable="true" AutoHide="false" ID="ToolTip2" runat="server"
                                                Title="Thời hạn sử dụng ngày phép của năm trước" Header="true" Frame="true" Html="Số ngày phép của năm trước mà nhân viên chưa sử dụng hết sẽ được đưa sang năm nay. Bạn hãy chọn thời hạn sử dụng những ngày phép của năm trước">
                                            </ext:ToolTip>
                                        </ToolTips>
                                        <Listeners>
                                            <Blur Handler="ToolTip2.hide();" />
                                            <Focus Handler="ToolTip2.show();" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:DisplayField ID="DisplayField3" runat="server" Text="Thưởng thêm" />
                                    <ext:DateField ID="dfHanDungNgayPhepThuongThem" Width="100" NoteAlign="Top" runat="server">
                                        <ToolTips>
                                            <ext:ToolTip Closable="true" Draggable="true" AutoHide="false" ID="ToolTip3" runat="server"
                                                Title="Thời hạn sử dụng ngày phép thưởng thêm" Header="true" Frame="true" Html="Thời hạn sử dụng những ngày phép mà công ty thưởng thêm cho nhân viên">
                                            </ext:ToolTip>
                                        </ToolTips>
                                        <Listeners>
                                            <Blur Handler="ToolTip3.hide();" />
                                            <Focus Handler="ToolTip3.show();" />
                                        </Listeners>
                                    </ext:DateField>
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" FieldLabel="Cộng dồn">
                                <Items>
                                    <ext:DisplayField ID="DisplayField4" runat="server" Text="Số ngày phép cộng dồn tối đa trong 1 tháng" />
                                    <ext:NumberField runat="server" ID="nbfSoNgayPhepCongDonToiDaTrong1Thang" Width="40"
                                        Text="1">
                                    </ext:NumberField>
                                    <ext:DisplayField runat="server" Text="Ngày" />
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet AnchorHorizontal="100%" Layout="RowLayout" runat="server" Title="Đối tượng được tính ngày nghỉ phép">
                        <Items>
                            <ext:RadioGroup ID="RadioGroup2" AnchorHorizontal="100%" runat="server" ColumnsWidths="550,550">
                                <Items>
                                    <ext:Radio ID="rdApDungChoTatCaNhanVien" runat="server" BoxLabel="Áp dụng cho tất cả nhân viên, bao gồm cả những nhân viên chưa có thông tin ngày phép"
                                        Checked="false" />
                                    <ext:Radio ID="rdChiNhungNhanVienDuocChon" runat="server" BoxLabel="Chỉ cập nhật lại ngày phép cho những nhân viên được chọn">
                                        <Listeners>
                                            <Check Handler="if(rdChiNhungNhanVienDuocChon.checked && GridPanel1.getSelectionModel().getCount()==0){
                                                            alert('Bạn chưa chọn nhân viên nào.');
                                                            rdChiNhungNhanVienDuocChon.setValue(false);
                                                        }" />
                                        </Listeners>
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnTinhSoNgayPhep" runat="server" Icon="Accept" Text="<%$ Resources:Language, accept%>">
                        <Listeners>
                            <Click Handler="return ValidateNgayPhep();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnTinhSoNgayPhep_Click">
                                <EventMask ShowMask="true" Msg="<%$ Resources:CommonMessage, Waiting%>" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Icon="Decline" Text="<%$ Resources:CommonMessage, Close%>">
                        <Listeners>
                            <Click Handler="wdTinhSoNgayPhep.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetForm();" />
                </Listeners>
            </ext:Window>
            <ext:Hidden runat="server" ID="hdfMaDonVi2" />
            <ext:Window Icon="Date" runat="server" ID="wdNhanVienCanLoaiBo" Resizable="false"
                Layout="BorderLayout" Constrain="true" Hidden="true" Height="400" Width="600"
                Padding="0" Modal="true" Title="Các nhân viên đã nghỉ">
                <Items>
                    <ext:GridPanel ID="grpDanhSachNhanVienDaNghi" Border="false" runat="server" StripeRows="true"
                        Title="Các nhân viên sau đã nghỉ việc, bạn có muốn loại bỏ các nhân viên này khỏi danh sách quản lý ngày phép không ?"
                        Region="Center" AutoExpandColumn="HOTEN">
                        <Store>
                            <ext:Store AutoLoad="false" ID="grpDanhSachNhanVienDaNghiStore" runat="server">
                                <Proxy>
                                    <ext:HttpProxy Method="GET" Url="Handler/DanhSachNhanVienNghiViecHandler.ashx">
                                    </ext:HttpProxy>
                                </Proxy>
                                <AutoLoadParams>
                                    <ext:Parameter Name="start" Value="={0}" />
                                    <ext:Parameter Name="limit" Value="={15}" />
                                </AutoLoadParams>
                                <BaseParams>
                                    <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi2.getValue()" Mode="Raw" />
                                </BaseParams>
                                <Reader>
                                    <ext:JsonReader IDProperty="PRKEY" TotalProperty="TotalRecords" Root="Data">
                                        <Fields>
                                            <ext:RecordField Name="PRKEY" />
                                            <ext:RecordField Name="MACB" />
                                            <ext:RecordField Name="HOTEN" />
                                            <ext:RecordField Name="NGAYSINH" />
                                            <ext:RecordField Name="NGAYNGHI" />
                                            <ext:RecordField Name="PHONGBAN" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel1" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="<%$ Resources:HOSO, Stt%>" Width="35" />
                                <ext:Column ColumnID="MACB" Header="<%$ Resources:HOSO, Staff_code1%>" Width="80" DataIndex="MACB" />
                                <ext:Column Header="<%$ Resources:HOSO, staff_name%>" Width="160" DataIndex="HOTEN">
                                </ext:Column>
                                <ext:DateColumn Format="dd/MM/yyyy" Header="<%$ Resources:HOSO, staff_birthday%>" Width="85" DataIndex="NGAYSINH">
                                </ext:DateColumn>
                                <ext:Column Header="<%$ Resources:HOSO, staff_section%>" Width="85" DataIndex="PHONGBAN">
                                </ext:Column>
                                <ext:DateColumn Header="Ngày nghỉ" Width="85" DataIndex="NGAYNGHI" Format="dd/MM/yyyy" />
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                        </SelectionModel>
                        <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="10">
                            </ext:PagingToolbar>
                        </BottomBar>
                    </ext:GridPanel>
                </Items>
                <BottomBar>
                    <ext:Toolbar runat="server" ID="tb2">
                        <Items>
                            <ext:Checkbox ID="chkNotifyToDeleteAgain" runat="server" BoxLabel="Không hiện lại thông báo này nữa." />
                        </Items>
                    </ext:Toolbar>
                </BottomBar>
                <Listeners>
                    <BeforeShow Handler="grpDanhSachNhanVienDaNghiStore.reload();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnLoaiBoNhanVienDaNghi" runat="server" Icon="Accept" Text="Đồng ý loại bỏ">
                        <DirectEvents>
                            <Click OnEvent="btnLoaiBoNhanVienDaNghi_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="LoaiBo" Value="True" />
                                </ExtraParams>
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát...." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnKhongLoaiBoNhanVien" Text="Không" Icon="Decline">
                        <DirectEvents>
                            <Click OnEvent="btnLoaiBoNhanVienDaNghi_Click">
                                <ExtraParams>
                                    <ext:Parameter Name="LoaiBo" Value="False" />
                                </ExtraParams>
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát...." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window Icon="Date" runat="server" ID="wdDieuChinhNgayPhep" Resizable="false"
                Layout="FormLayout" Constrain="true" Hidden="true" AutoHeight="true" Width="460"
                Padding="6" Modal="true" Title="Điều chỉnh ngày phép">
                <Items>
                    <ext:FieldSet runat="server" AutoHeight="true" LabelWidth="150" Title="Số ngày phép"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:CompositeField runat="server" ID="cp1" AnchorHorizontal="100%">
                                <Items>
                                    <ext:NumberField runat="server" Width="190" FieldLabel="Số ngày phép năm trước" ID="nbfDieuChinhSoNPNamTruoc"/>
                                    <ext:DisplayField ID="DisplayField5" runat="server" Text="Ngày" />
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" ID="CompositeField1" AnchorHorizontal="100%">
                                <Items>
                                    <ext:NumberField runat="server" Width="190" FieldLabel="Số ngày phép năm nay" ID="nbfDieuChinhNgayPhepNamNay"
                                        MaskRe="/[0-9.,]/" />
                                    <ext:DisplayField ID="DisplayField6" runat="server" Text="Ngày" />
                                </Items>
                            </ext:CompositeField>
                            <ext:CompositeField runat="server" ID="CompositeField2" AnchorHorizontal="100%">
                                <Items>
                                    <ext:NumberField runat="server" Width="190" FieldLabel="Số ngày phép được thêm" ID="nbfDieuChinhNgayPhepDuocThem"
                                        MaskRe="/[0-9.,]/" />
                                    <ext:DisplayField ID="DisplayField7" runat="server" Text="Ngày" />
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet runat="server" AutoHeight="true" Layout="RowLayout" Title="Chi tiết sử dụng"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:Container ID="Container3" runat="server" Height="5" AnchorHorizontal="100%">
                            </ext:Container>
                            <ext:CompositeField runat="server" ID="cps" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField runat="server" Text="Tháng 01" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang1" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField8" runat="server" Text="Tháng 02" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang2" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField9" runat="server" Text="Tháng 03" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang3" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField10" runat="server" Text="Tháng 04" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang4" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:CompositeField>
                            <ext:Container ID="Container4" runat="server" Height="5" AnchorHorizontal="100%">
                            </ext:Container>
                            <ext:CompositeField runat="server" ID="CompositeField3" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField11" runat="server" Text="Tháng 05" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang5" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField12" runat="server" Text="Tháng 06" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang6" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField13" runat="server" Text="Tháng 07" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang7" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField14" runat="server" Text="Tháng 08" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang8" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:CompositeField>
                            <ext:Container ID="Container5" runat="server" Height="5" AnchorHorizontal="100%">
                            </ext:Container>
                            <ext:CompositeField runat="server" ID="CompositeField4" AnchorHorizontal="100%">
                                <Items>
                                    <ext:DisplayField ID="DisplayField15" runat="server" Text="Tháng 09" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang9" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField16" runat="server" Text="Tháng 10" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang10" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField17" runat="server" Text="Tháng 11" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang11" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:DisplayField ID="DisplayField18" runat="server" Text="Tháng 12" />
                                    <ext:NumberField runat="server" Width="40" ID="nbfThang12" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Buttons>
                    <ext:Button ID="btnOKDieuChinhNgayPhep" runat="server" Text="<%$ Resources:Language, accept%>" Icon="Accept">
                        <Listeners>
                            <Click Handler="return checkDieuChinhNgayPhepQuaHan();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnOKDieuChinhNgayPhep_Click">
                                <%--<Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn thay đổi ngày phép không ?"
                                ConfirmRequest="true" />--%>
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdDieuChinhNgayPhep.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeHide Handler="resetwdDieuChinhNgayPhep();" />
                </Listeners>
            </ext:Window>
            <ext:Window Icon="Date" runat="server" ID="wdDanhSachNhanVien" Resizable="false"
                Constrain="true" Hidden="true" Height="350" Width="580" Padding="6" Modal="true"
                Layout="BorderLayout" Title="Danh sách nhân viên">
                <Items>
                    <ext:GridPanel ID="grpDanhSachNhanVien" runat="server" Region="Center" StripeRows="true"
                        Border="false" AutoExpandColumn="HO_TEN">
                        <TopBar>
                            <ext:Toolbar runat="server" ID="tbss">
                                <Items>
                                    <ext:Button runat="server" Text="<%$ Resources:CommonMessage, Add%>" Icon="Add" ID="btnAddEmployee">
                                        <Listeners>
                                            <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Disabled="true" Text="<%$ Resources:CommonMessage, Delete%>" Icon="Delete" ID="btnDeleteEmployee">
                                        <Listeners>
                                            <Click Handler="RemoveItemOnGrid(grpDanhSachNhanVien,grpDanhSachNhanVienStore);" />
                                        </Listeners>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="grpDanhSachNhanVienStore" runat="server">
                                <Reader>
                                    <ext:JsonReader IDProperty="MA_CB">
                                        <Fields>
                                            <ext:RecordField Name="MA_CB" />
                                            <ext:RecordField Name="HO_TEN" />
                                            <ext:RecordField Name="TEN_DONVI" />
                                            <ext:RecordField Name="TEN_CHUCVU" />
                                            <ext:RecordField Name="HinhThucLamViec" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Width="35" />
                                <ext:Column Header="Mã nhân viên" Width="90" DataIndex="MA_CB">
                                </ext:Column>
                                <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="160" DataIndex="HO_TEN" />
                                <ext:Column Header="Chức vụ" Width="100" DataIndex="TEN_CHUCVU">
                                </ext:Column>
                                <ext:Column Header="Phòng ban" Width="100" DataIndex="TEN_DONVI">
                                </ext:Column>
                                <ext:Column Header="Hình thức làm việc" Width="125" DataIndex="HinhThucLamViec">
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                <Listeners>
                                    <RowSelect Handler="btnDeleteEmployee.enable();" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <LoadMask ShowMask="true" />
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdDanhSachNhanVien.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window Icon="Date" runat="server" ID="wdThemNhanVien" Resizable="false" Constrain="true"
                Hidden="true" AutoHeight="true" Width="580" Padding="6" Modal="true" LabelWidth="120"
                Layout="FormLayout" Title="Thêm nhân viên vào bảng quản lý ngày phép">
                <Items>
                    <ext:FieldSet runat="server" Title="Điều kiện áp dụng" LabelWidth="110" AnchorHorizontal="100%"
                        AutoHeight="true">
                        <Items>
                            <ext:ComboBox ID="cbDoiTuongApDung" Editable="false" runat="server" FieldLabel="Đối tượng<span style='color:red;'>*</span>"
                                AnchorHorizontal="100%" CtCls="requiredData">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Ellipsis" HideTrigger="true" Qtip="Xem danh sách nhân viên đã chọn" />
                                </Triggers>
                                <Items>
                                    <ext:ListItem Value="ChuaCoTrongDanhSach" Text="Tất cả nhân viên" />
                                    <ext:ListItem Value="ChonTuDanhSach" Text="Chọn từ danh sách" />
                                </Items>
                                <Listeners>
                                    <Select Handler="if(cbDoiTuongApDung.getValue()=='ChonTuDanhSach'){
                                                           this.triggers[0].show();
                                                           ucChooseEmployee1_wdChooseUser.show();
                                                    }else{this.triggers[0].hide();}" />
                                    <TriggerClick Handler="wdDanhSachNhanVien.show();" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:Hidden runat="server" ID="hdfSelectedEmployees" />
                            <ext:RadioGroup runat="server" FieldLabel="Trùng nhân viên">
                                <Items>
                                    <ext:Radio ID="rdBoQuaKhongThem" runat="server" LabelWidth="130" BoxLabel="Bỏ qua không thêm">
                                    </ext:Radio>
                                    <ext:Radio runat="server" Checked="true" ID="rdGhiDeThongTinMoi" LabelWidth="150"
                                        BoxLabel="Ghi đè thông tin mới">
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                            <ext:MultiCombo runat="server" ID="cbHopDongLoaiHopDong" DisplayField="TEN_LOAI_HDONG"
                                FieldLabel="Loại hợp đồng" Editable="false" ValueField="MA_LOAI_HDONG" AnchorHorizontal="100%">
                                <Store>
                                    <ext:Store runat="server" ID="cbHopDongLoaiHopDongStore" AutoLoad="false" OnRefreshData="cbHopDongLoaiHopDongStore_OnRefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="MA_LOAI_HDONG">
                                                <Fields>
                                                    <ext:RecordField Name="MA_LOAI_HDONG" />
                                                    <ext:RecordField Name="TEN_LOAI_HDONG" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Expand Handler="this.triggers[0].show();#{cbHopDongLoaiHopDongStore}.reload();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:MultiCombo>
                            <ext:Container ID="Container1" Layout="ColumnLayout" runat="server" Height="30" AnchorHorizontal="100%">
                                <Items>
                                    <ext:Container ID="Container2" runat="server" Height="30" ColumnWidth="0.5" LabelWidth="110"
                                        Layout="FormLayout">
                                        <Items>
                                            <ext:CompositeField ID="CompositeField5" runat="server" AnchorHorizontal="98%" FieldLabel="Thâm niên">
                                                <Items>
                                                    <ext:NumberField ID="nbfThamNien" runat="server" Width="40">
                                                    </ext:NumberField>
                                                    <ext:ComboBox ID="cbThoiGianThamNien" SelectedIndex="0" runat="server" Width="100"
                                                        Editable="false">
                                                        <Items>
                                                            <ext:ListItem Value="UsingMonthUnit" Text="Tháng trở lên" />
                                                            <ext:ListItem Value="UsingYearUnit" Text="Năm trở lên" />
                                                        </Items>
                                                    </ext:ComboBox>
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:Container>
                                    <ext:ComboBox ID="cbxHinhThucLamViec" runat="server" LabelWidth="120" ColumnWidth="0.5"
                                        FieldLabel="Hình thức làm việc" DisplayField="Value" ValueField="ID" LoadingText="Đang tải dữ liệu..."
                                        ItemSelector="div.list-item" AnchorHorizontal="98%" Editable="false" AllowBlank="false">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Template ID="Template38" runat="server">
                                            <Html>
                                                <tpl for=".">
						                                                                <div class="list-item"> 
							                                                                {Value}
						                                                                </div>
					                                                                </tpl>
                                            </Html>
                                        </Template>
                                        <Store>
                                            <ext:Store runat="server" ID="cbxHinhThucLamViec_Store" AutoLoad="false" OnRefreshData="cbxHinhThucLamViec_Store_OnRefreshData">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="ID">
                                                        <Fields>
                                                            <ext:RecordField Name="ID" />
                                                            <ext:RecordField Name="Value" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Listeners>
                                            <Expand Handler="cbxHinhThucLamViec_Store.reload();" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet runat="server" AutoHeight="true" LabelWidth="110" Title="Chi tiết ngày phép"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:Container runat="server" ID="ctv1" Layout="ColumnLayout" Height="60" LabelWidth="110">
                                <Items>
                                    <ext:Container runat="server" ID="ctv11" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="110">
                                        <Items>
                                            <ext:NumberField runat="server" ID="nbfNamAPDungNgayPhep" Width="150" FieldLabel="Năm áp dụng"
                                                AnchorHorizontal="98%" Height="27" AllowNegative="false" AllowDecimals="false" />
                                            <ext:CompositeField ID="CompositeField6" AnchorHorizontal="98%" runat="server" Height="27"
                                                FieldLabel="">
                                                <Items>
                                                    <ext:NumberField runat="server" ID="nbfSoNgayPhepNamNay" Width="150"
                                                        AllowNegative="false" Hidden="true" />
                                                    <ext:Checkbox ID="chkTuDongTinhNgayPhep" runat="server" BoxLabel="Tự động tính toán dựa vào quy tắc"
                                                        Hidden="true">
                                                        <Listeners>
                                                            <Check Handler="if(chkTuDongTinhNgayPhep.checked){nbfSoNgayPhepNamNay.disable();}else{nbfSoNgayPhepNamNay.enable();}" />
                                                        </Listeners>
                                                    </ext:Checkbox>
                                                </Items>
                                            </ext:CompositeField>
                                        </Items>
                                    </ext:Container>
                                    <ext:Container runat="server" ID="Container6" Layout="FormLayout" ColumnWidth="0.5"
                                        LabelWidth="110">
                                        <Items>
                                            <ext:NumberField runat="server" Width="150" ID="nbfSoNgayPhepDuocThem" FieldLabel="Số NP được thêm"
                                                Height="27" AllowNegative="false" />
                                            <ext:DateField runat="server" Width="150" ID="dfHanSuDungNPNamTruoc" FieldLabel="Hạn NP năm trước"
                                                Height="27" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                RegexText="Định dạng ngày sinh không đúng" />
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                            <ext:Checkbox runat="server" ID="nbfSoNgayPhepNamTruoc" FieldLabel="Số NP năm trước"
                                BoxLabel="Tự động tìm nạp những ngày phép của năm trước" Checked="true" />
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Listeners>
                    <Hide Handler="resetThemNhanVienVaoDanhSach();" />
                    <BeforeShow Handler="nbfNamAPDungNgayPhep.setValue(new Date().getFullYear());" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" Text="Đồng ý" Icon="Accept" ID="btnAccept">
                        <Listeners>
                            <Click Handler="return validateThemNhanVienVaoDanhSach();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnAccept_Click">
                                <EventMask ShowMask="true" Msg="Đang xử lý dữ liệu..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="btnClosewdThemNhanVien">
                        <Listeners>
                            <Click Handler="wdThemNhanVien.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <uc2:ucQuyTacTinhNgayPhep ID="ucQuyTacTinhNgayPhep1" runat="server" />
            <ext:Menu ID="RowContextMenu1" runat="server">
                <Items>
                    <ext:MenuItem ID="MenuItem1" runat="server" Icon="UserAdd" Text="Thêm nhân viên">
                        <Listeners>
                            <Click Handler="wdThemNhanVien.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="MenuItemXoaNV" runat="server" Text="Loại bỏ nhân viên" Icon="UserDelete">
                        <DirectEvents>
                            <Click OnEvent="mnuLoaiBoNhanVien_Click">
                                <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ? " ConfirmRequest="true" />
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuItem runat="server" ID="mnuDieuChinhNgayPhep" Icon="Date" Text="Điều chỉnh ngày phép">
                        <Listeners>
                            <Click Handler="wdDieuChinhNgayPhep.show();" />
                        </Listeners>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <%--<uc1:SingleGridPanel ID="grpDanhSachNgayPhep" Header="true" IDProperty="ID" ColumnName="ID,MA_CB,HO_TEN,TEN_DONVI,SoNgayPhepNamTruoc,ThoiHanSuDungNgayPhepNamTruoc,SoNgayPhepNamNay,SoNgayPhepDuocThem,TongNgayPhepDuocHuong, DaSuDung,
	                                                                           Thang1,Thang2,Thang3,Thang4,Thang5,Thang6,Thang7,Thang8,Thang9,Thang10,Thang11,Thang12 "
            LockedColumn="MA_CB,HO_TEN" ColumnHeader="ID,Mã nhân viên, Họ tên, Bộ phận, Số NP năm trước,Thời hạn sử dụng phép năm trước, Số NP năm nay, Số NP được thêm, Tổng NP được hưởng, 
                                                                                  Số NP đã sử dụng,Tháng 1, Tháng 2, Tháng 3, Tháng 4, Tháng 5, Tháng 6, Tháng 7, Tháng 8, Tháng 9, Tháng 10, Tháng 11, Tháng 12"
            ColumnWidth="HO_TEN=120,Thang1=60,Thang2=60,Thang3=60,Thang4=60,Thang5=60,Thang6=60,Thang7=60,Thang8=60,Thang9=60,Thang10=60,Thang11=60,Thang12=60,TEN_DONVI=150,
                         SoNgayPhepNamTruoc=60,SoNgayPhepDuocThem=60,DaSuDung=60,TongNgayPhepDuocHuong=60,ThoiHanSuDungNgayPhepNamTruoc=60,SoNgayPhepNamNay=60"
            SearchField="MA_CB,HO_TEN" MaDonViColumn="MA_DONVI" EmptyTextSearch="Nhập mã hoặc họ tên nhân viên..."
            MenuContextID="RowContextMenu1" EnableWestPanelFilter="true" OrderBy="TEN_CB"
            DisplayPrimaryColumn="false" Render="Thang1=getUsedDayPerMonth,Thang2=getUsedDayPerMonth,Thang3=getUsedDayPerMonth,Thang4=getUsedDayPerMonth,Thang5=getUsedDayPerMonth,
                        Thang6=getUsedDayPerMonth,Thang7=getUsedDayPerMonth,Thang8=getUsedDayPerMonth,Thang9=getUsedDayPerMonth,Thang10=getUsedDayPerMonth,
                        Thang11=getUsedDayPerMonth,Thang12=getUsedDayPerMonth,TongNgayPhepDuocHuong=getTotalDaysPerYear,
                        SoNgayPhepNamTruoc=getDayNumber,SoNgayPhepNamNay=getDayNumber,SoNgayPhepDuocThem=getDayNumber,DaSuDung=getUsedDayPerYear"
            TableOrViewName="TongSoNgayPhep" runat="server" />--%>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="grpDanhSachNgayPhep" runat="server" Title="Danh sách ngày phép"
                                StripeRows="true" Border="false" Icon="BookOpen">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tbDanhSachNgayPhep">
                                        <Items>
                                            <ext:Button runat="server" ID="btnUserManager" Text="Quản lý nhân viên" Icon="User">
                                                <Menu>
                                                    <ext:Menu ID="mnuUserManager" runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="mnuThemNhanVien" runat="server" Icon="UserAdd" Text="Thêm nhân viên">
                                                                <Listeners>
                                                                    <Click Handler="wdThemNhanVien.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuLoaiBoNhanVien" Disabled="true" IDMode="Static" runat="server"
                                                                Icon="UserDelete" Text="Loại bỏ nhân viên">
                                                                <DirectEvents>
                                                                    <Click OnEvent="mnuLoaiBoNhanVien_Click">
                                                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ? " ConfirmRequest="true" />
                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem2" runat="server" Hidden="true" Icon="UserDelete" Text="Xóa những nhân viên đã nghỉ việc">
                                                                <Listeners>
                                                                    <Click Handler="wdNhanVienCanLoaiBo.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="btnCongThucTinhNgayPhep" Hidden="true" runat="server" Text="Tạo công thức tính ngày phép"
                                                Icon="Cog">
                                                <Listeners>
                                                    <Click Handler="ucQuyTacTinhNgayPhep1_wdQuyTacTinhNgayPhep.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="btnDieuChinhNgayPhep" Disabled="true" runat="server" Text="Điều chỉnh ngày phép"
                                                Icon="Date">
                                                <Listeners>
                                                    <Click Handler="if(CheckSelectedRecordPrint(grpDanhSachNgayPhep,stDanhSachNgayPhep)) {setValuewdDieuChinhNgayPhep(); wdDieuChinhNgayPhep.show();}" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:TriggerField runat="server" ID="triggerXemTheoNam" MaskRe="/[0-9\.]/" EnableKeyEvents="true"
                                                TriggerIcon="Search" Width="150" MaxLength="4" LabelWidth="80" FieldLabel="Xem theo năm">
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler2" />
                                                    <TriggerClick Handler="PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad(); changeTitle(#{triggerXemTheoNam}); RowSelectionModelNgayPhep.clearSelections();" />
                                                    <Blur Handler="changeTitle(#{triggerXemTheoNam});" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:ToolbarFill runat="server" ID="tbf1" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc tên cán bộ"
                                                ID="txtSearch">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler1" />
                                                    <TriggerClick Handler="this.reset(); this.triggers[0].hide(); PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad(); RowSelectionModelNgayPhep.clearSelections();" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                <Listeners>
                                                    <Click Handler="PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad(); RowSelectionModelNgayPhep.clearSelections();" />
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
                                    <ext:Store runat="server" ID="stDanhSachNgayPhep" AutoLoad="true">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="Handler/HandlerDanhSachNgayPhep.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={25}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="Year" Value="triggerXemTheoNam.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="MA_CB" />
                                                    <ext:RecordField Name="HO_TEN" />
                                                    <ext:RecordField Name="TEN_DONVI" />
                                                    <ext:RecordField Name="SoNgayPhepNamTruoc" />
                                                    <ext:RecordField Name="ThoiHanSuDungNgayPhepNamTruoc" />
                                                    <ext:RecordField Name="ThoiHanSuDungNgayPhepDuocThem" />
                                                    <ext:RecordField Name="SoNgayPhepNamNay" />
                                                    <ext:RecordField Name="SoNgayPhepDuocThem" />
                                                    <ext:RecordField Name="TongNgayPhepDuocHuong" />
                                                    <ext:RecordField Name="DaSuDung" />
                                                    <ext:RecordField Name="PhepTon" />
                                                    <ext:RecordField Name="Thang1" />
                                                    <ext:RecordField Name="Thang2" />
                                                    <ext:RecordField Name="Thang3" />
                                                    <ext:RecordField Name="Thang4" />
                                                    <ext:RecordField Name="Thang5" />
                                                    <ext:RecordField Name="Thang6" />
                                                    <ext:RecordField Name="Thang7" />
                                                    <ext:RecordField Name="Thang8" />
                                                    <ext:RecordField Name="Thang9" />
                                                    <ext:RecordField Name="Thang10" />
                                                    <ext:RecordField Name="Thang11" />
                                                    <ext:RecordField Name="Thang12" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel3" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                        <ext:Column ColumnID="MA_CB" Header="Mã nhân viên" Locked="true" Width="90" DataIndex="MA_CB" />
                                        <ext:Column ColumnID="HO_TEN" Header="Họ tên" Locked="true" Width="120" DataIndex="HO_TEN" />
                                        <ext:Column ColumnID="TEN_DONVI" Header="Bộ phận" Locked="true" Width="225" DataIndex="TEN_DONVI" />
                                        <ext:Column Header="Số NP năm trước" Width="60" DataIndex="SoNgayPhepNamTruoc">
                                            <Renderer Fn="getDayNumber" />
                                        </ext:Column>
                                        <ext:DateColumn Format="dd/MM/yyyy" Header="Thời hạn sử dụng ngày phép năm trước"
                                            Width="85" Align="Right" DataIndex="ThoiHanSuDungNgayPhepNamTruoc">
                                        </ext:DateColumn>
                                        <ext:Column Header="Số NP năm nay" Width="60" DataIndex="SoNgayPhepNamNay">
                                            <Renderer Fn="getDayNumber" />
                                        </ext:Column>
                                        <ext:Column Header="Số NP được thêm" Width="60" DataIndex="SoNgayPhepDuocThem">
                                            <Renderer Fn="getDayNumber" />
                                        </ext:Column>
                                        <ext:DateColumn Format="dd/MM/yyyy" Header="Thời hạn sử dụng ngày phép được thêm"
                                            Width="85" Align="Right" DataIndex="ThoiHanSuDungNgayPhepDuocThem">
                                        </ext:DateColumn>
                                        <ext:Column Header="Tổng ngày phép được hưởng" Width="60" DataIndex="TongNgayPhepDuocHuong">
                                            <Renderer Fn="getTotalDaysPerYear" />
                                        </ext:Column>
                                        <ext:Column Header="Số NP đã sử dụng" Width="60" DataIndex="DaSuDung">
                                            <Renderer Fn="getUsedDayPerYear" />
                                        </ext:Column>
                                        <ext:Column Header="Ngày phép còn lại" Width="60" DataIndex="PhepTon">
                                            <Renderer Fn="getTotalDaysPerYear" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 1" Width="60" DataIndex="Thang1">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 2" Width="60" DataIndex="Thang2">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 3" Width="60" DataIndex="Thang3">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 4" Width="60" DataIndex="Thang4">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 5" Width="60" DataIndex="Thang5">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 6" Width="60" DataIndex="Thang6">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 7" Width="60" DataIndex="Thang7">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 8" Width="60" DataIndex="Thang8">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 9" Width="60" DataIndex="Thang9">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 10" Width="60" DataIndex="Thang10">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 11" Width="60" DataIndex="Thang11">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                        <ext:Column Header="Tháng 12" Width="60" DataIndex="Thang12">
                                            <Renderer Fn="getUsedDayPerMonth" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModelNgayPhep" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="try{btnDieuChinhNgayPhep.enable();}catch(e){} try{mnuLoaiBoNhanVien.enable();}catch(e){}" />
                                            <%--<RowDeselect Handler="try{btnDieuChinhNgayPhep.disable();}catch(e){} try{mnuLoaiBoNhanVien.disable();}catch(e){}" />--%>
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <%--<Listeners>
                                <RowDblClick Handler="setValuewdDieuChinhNgayPhep(); wdDieuChinhNgayPhep.show();" />
                            </Listeners>--%>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="25">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Cỡ trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="100" />
                                                    <ext:ListItem Text="300" />
                                                    <ext:ListItem Text="500" />
                                                    <ext:ListItem Text="1000" />
                                                    <ext:ListItem Text="3000" />
                                                    <ext:ListItem Text="5000" />
                                                    <ext:ListItem Text="10000" />
                                                    <ext:ListItem Text="30000" />
                                                    <ext:ListItem Text="50000" />
                                                    <ext:ListItem Text="100000" />
                                                </Items>
                                                <SelectedItem Value="10" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:DisplayField runat="server" ID="dpfTrangThai" />
                                        </Items>
                                        <Listeners>
                                            <Change Handler="#{RowSelectionModelNgayPhep}.clearSelections();" />
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
