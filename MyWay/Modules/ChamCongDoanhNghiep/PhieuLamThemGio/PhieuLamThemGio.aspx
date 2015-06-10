<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhieuLamThemGio.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_PhieuLamThemGio_PhieuLamThemGio" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee" TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../../Resource/js/Extcommon.js"></script>
    <style type="text/css">
        #grpPhieuLamThemGio {
            border-left: 1px solid #99bbe8 !important;
        }

        #pnlCoCauToChuc-xsplit {
            border-right: none !important;
        }

        .disabled-input-style {
            color: #353848 !important;
        }

        .search-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }

        #grpPhieuLamThemGio .x-grid3-cell-inner {
            white-space: nowrap !important;
        }

        .search-item h3 {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }

            .search-item h3 span {
                float: right;
                font-weight: normal;
                margin: 0 0 5px 5px;
                width: 100px;
                display: block;
                clear: none;
            }

        .list-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
    </style>
    <%--Check input data--%>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
                grpDangKyLamThemGio.getSelectionModel().clearSelections();
                hdfRecordID.setValue('');
                grpDangKyLamThemGioStore.reload();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
            if (txtSearch.getValue() == '') {
                this.triggers[0].hide();
            }
        }
        var CalculateTongGio = function (startTime, endTime) {
            if (startTime == '' || endTime == '')
                return;
            var startHour = parseInt(startTime.split(':')[0]);
            var startMinute = parseInt(startTime.split(':')[1]);

            var endHour = parseInt(endTime.split(':')[0]);
            var endMinute = parseInt(endTime.split(':')[1]);

            var total = (endHour * 60 + endMinute) - (startHour * 60 + startMinute);
            if (total < (-24 * 60))
                total = total + 24 * 60;
            if (total > (24 * 60))
                total = total - 24 * 60;

            var value = total / 60;
            txtLamNgayThuong.setValue(parseFloat(value + '').toFixed(1));
        }
        var CalculateTongGioHL = function (startTime, endTime) {
            if (startTime == '' || endTime == '')
                return;
            var startHour = parseInt(startTime.split(':')[0]);
            var startMinute = parseInt(startTime.split(':')[1]);

            var endHour = parseInt(endTime.split(':')[0]);
            var endMinute = parseInt(endTime.split(':')[1]);

            var total = (endHour * 60 + endMinute) - (startHour * 60 + startMinute);
            if (total < (-24 * 60))
                total = total + 24 * 60;
            if (total > (24 * 60))
                total = total - 24 * 60;

            var value = total / 60;
            txt_T_AM.setValue(parseFloat(value + '').toFixed(1));
        }
        var ResetWdThemCanBo = function () {
            hdfChonCanBo.reset(); cbxChonCanBo.reset(); tfGioBatDau.reset();
            dfNgayDK.reset(); tfGioKetThuc.reset(); txtNoiDungCongViec.reset();
            txtLamNgayThuong.reset(); txtLamNgayNghi.reset(); txtLamNgayLe.reset();
            txtLamNgayThuong_PM.reset(); txtLamNgayNghi_PM.reset(); txtLamNgayLe_PM.reset();
        }
        var ResetWdThemCanBoHL = function () {
            tfStart.reset();
            dfDate.reset();
            tfEnd.reset();
            txtCongViecHL.reset();
            txt_T_AM.reset(); txt_N_AM.reset(); txt_L_AM.reset();
            txt_T_PM.reset(); txt_N_PM.reset(); txt_L_PM.reset();
            grp_DanhSachCanBoStore.removeAll();
        }
        var RenderNumber = function (value, p, record) {
            if (value == 0 || value == null || value == '')
                return "<span style='float:right;'>-</span>";
            else {
                return "<span style='float:right;'>" + parseFloat('0' + value).toFixed(1).replace(".0", "") + "</span>";
                //return parseFloat('0' + value).toFixed(1);
            }
        }
        var CheckInput = function () {
            if (!hdfChonCanBo.getValue()) {
                alert('Bạn chưa chọn cán bộ');
                cbxChonCanBo.focus();
                return false;
            }
            if (!dfNgayDK.getValue()) {
                alert('Bạn chưa chọn ngày làm thêm giờ');
                dfNgayDK.focus();
                return false;
            }
            if (!tfGioBatDau.getValue()) {
                alert('Bạn chưa nhập giờ bắt đầu làm thêm');
                tfGioBatDau.focus();
                return false;
            }
            if (!tfGioKetThuc.getValue()) {
                alert('Bạn chưa nhập giờ kết thúc làm thêm');
                tfGioKetThuc.focus();
                return false;
            }
            return true;
        }
        var CheckInputHL = function () {
            if (grp_DanhSachCanBoStore.getRange().length < 1) {
                alert("Bạn chưa chọn nhân viên nào");
                return false;
            }
            if (!dfDate.getValue()) {
                alert('Bạn chưa chọn ngày làm thêm giờ');
                dfDate.focus();
                return false;
            }
            if (!tfStart.getValue()) {
                alert('Bạn chưa nhập giờ bắt đầu làm thêm');
                tfStart.focus();
                return false;
            }
            if (!tfEnd.getValue()) {
                alert('Bạn chưa nhập giờ kết thúc làm thêm');
                tfGioKetThuc.focus();
                return false;
            }
            return true;
        }
        var addRecord = function (pr_keyhoso, ma_cb, ho_ten, ten_donvi) {
            var rowindex = getSelectedIndexRow();
            grp_DanhSachCanBo.insertRecord(rowindex, {
                PR_KEY: pr_keyhoso,
                MA_CB: ma_cb,
                HO_TEN: ho_ten,
                TEN_DONVI: ten_donvi
            });
            grp_DanhSachCanBo.getView().refresh();
            grp_DanhSachCanBo.getSelectionModel().selectRow(rowindex);
            grp_DanhSachCanBoStore.commitChanges();
        }
        var getSelectedIndexRow = function () {
            var record = grp_DanhSachCanBo.getSelectionModel().getSelected();
            var index = grp_DanhSachCanBo.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }
        function getJsonOfStore(store) {
            var datar = new Array();
            var jsonDataEncode = "";
            var records = store.getRange();
            for (var i = 0; i < records.length; i++) {
                datar.push(records[i].data);
            }
            jsonDataEncode = Ext.util.JSON.encode(datar);
            return jsonDataEncode;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" DisplayWorkingStatus="DangLamViec" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfTotalRecord" />
            <ext:Window runat="server" ID="wdThemCanBo" Constrain="true" Modal="true" Title="Thêm cán bộ đăng ký làm thêm giờ"
                Icon="UserAdd" Layout="FormLayout" AutoHeight="true" Width="550" Hidden="true"
                Padding="6">
                <Items>
                    <ext:Container runat="server" ID="ctn1" Layout="ColumnLayout" AnchorHorizontal="100%"
                        Height="55">
                        <Items>
                            <ext:Container runat="server" ID="ctn2" Layout="FormLayout" ColumnWidth=".5">
                                <Items>
                                    <ext:Hidden runat="server" ID="hdfChonCanBo" />
                                    <ext:ComboBox ID="cbxChonCanBo" ValueField="PRKEY" DisplayField="HOTEN" FieldLabel="Tên cán bộ<span style='color:red'>*</span>"
                                        PageSize="10" HideTrigger="true" ItemSelector="div.search-item" MinChars="1" CtCls="requiredData"
                                        ListWidth="200" EmptyText="<%$ Resources:Language, enter_keyword%>" LoadingText="<%$ Resources:Language, LoadingMask%>" TabIndex="1"
                                        AnchorHorizontal="98%" runat="server">
                                        <Store>
                                            <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                                                <Proxy>
                                                    <ext:HttpProxy Method="POST" Url="../../HoSoNhanSu/QuyetDinhLuong/SearchUserHandler.ashx" />
                                                </Proxy>
                                                <Reader>
                                                    <ext:JsonReader Root="plants" TotalProperty="total">
                                                        <Fields>
                                                            <ext:RecordField Name="HOTEN" />
                                                            <ext:RecordField Name="MACB" />
                                                            <ext:RecordField Name="NGAYSINH" />
                                                            <ext:RecordField Name="PHONGBAN" />
                                                            <ext:RecordField Name="PRKEY" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Template ID="Template4" runat="server">
                                            <Html>
                                                <tpl for=".">
						                        <div class="search-item">
							                        <h3>{HOTEN}</h3>
                                                    {MACB} <br />
                                                    <tpl if="NGAYSINH &gt; ''">{NGAYSINH:date("d/m/Y")}</tpl><br />
							                        {PHONGBAN}
						                        </div>
					                        </tpl>
                                            </Html>
                                        </Template>
                                        <Listeners>
                                            <Select Handler="hdfChonCanBo.setValue(cbxChonCanBo.getValue());" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:TimeField ID="tfGioBatDau" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                        Format="H:mm" FieldLabel="Giờ bắt đầu<span style='color:red;'>*</span>" AnchorHorizontal="98%"
                                        MaskRe="/[0-9:]/" TabIndex="3" CtCls="requiredData">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show(); CalculateTongGio(tfGioBatDau.getValue(), tfGioKetThuc.getValue());" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" ID="ctn3" Layout="FormLayout" ColumnWidth=".5" LabelWidth="105">
                                <Items>
                                    <ext:DateField runat="server" ID="dfNgayDK" FieldLabel="Ngày<span style='color:red;'>*</span>"
                                        AnchorHorizontal="100%" Vtype="daterange" TabIndex="2"
                                        CtCls="requiredData" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                        Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="<%$ Resources:Language, Date_fomart_not_correct%>">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:DateField>
                                    <ext:TimeField ID="tfGioKetThuc" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                        Format="H:mm" FieldLabel="Giờ kết thúc<span style='color:red;'>*</span>" AnchorHorizontal="100%" TabIndex="4"
                                        MaskRe="/[0-9:]/" CtCls="requiredData">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show(); CalculateTongGio(tfGioBatDau.getValue(), tfGioKetThuc.getValue());" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextArea runat="server" ID="txtNoiDungCongViec" FieldLabel="Công việc" TabIndex="5"
                        AnchorHorizontal="100%">
                    </ext:TextArea>
                    <ext:Container runat="server" ID="Container7" AnchorHorizontal="100%" Layout="ColumnLayout" Height="90">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.68" LabelWidth="250">
                                <Items>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txtLamNgayThuong" FieldLabel="Cộng giờ làm thêm ngày thường (ban ngày)" TabIndex="6"
                                        AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txtLamNgayNghi" FieldLabel="Cộng giờ làm thêm ngày nghỉ (ban ngày)" TabIndex="8"
                                        AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txtLamNgayLe" FieldLabel="Cộng giờ làm thêm ngày lễ (ban ngày)" TabIndex="10"
                                        AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.32" LabelWidth="65">
                                <Items>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txtLamNgayThuong_PM" FieldLabel="(ban đêm)" TabIndex="7"
                                        AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txtLamNgayNghi_PM" FieldLabel="(ban đêm)" TabIndex="9"
                                        AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txtLamNgayLe_PM" FieldLabel="(ban đêm)" TabIndex="11"
                                        AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhat" Text="<%$ Resources:Language, update%>" Icon="Disk" TabIndex="12">
                        <Listeners>
                            <Click Handler="return CheckInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnEdit" Text="<%$ Resources:Language, update%>" Hidden="true" Icon="Disk" TabIndex="13">
                        <Listeners>
                            <Click Handler="return CheckInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Edit" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnCapNhatDongLai" Text="Cập nhật và đóng lại" Icon="Disk" TabIndex="14">
                        <Listeners>
                            <Click Handler="return CheckInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnClose" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline" TabIndex="15">
                        <Listeners>
                            <Click Handler="wdThemCanBo.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetWdThemCanBo();" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" ID="wdThemCanBoHL" Constrain="true" Modal="true" Title="Thêm cán bộ đăng ký làm thêm giờ"
                Icon="UserAdd" Layout="FormLayout" AutoHeight="true" Width="550" Hidden="true"
                Padding="6">
                <Items>
                    <ext:Container runat="server" ID="Container3" Layout="ColumnLayout" AnchorHorizontal="100%"
                        Height="55">
                        <Items>
                            <ext:Container runat="server" ID="Container4" Layout="FormLayout" ColumnWidth=".5">
                                <Items>
                                    <ext:DateField runat="server" ID="dfDate" FieldLabel="Ngày<span style='color:red;'>*</span>"
                                        AnchorHorizontal="98%" Vtype="daterange" TabIndex="2"
                                        CtCls="requiredData" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                        Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="<%$ Resources:Language, Date_fomart_not_correct%>">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:DateField>

                                    <ext:TimeField ID="tfStart" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                        Format="H:mm" FieldLabel="Giờ bắt đầu<span style='color:red;'>*</span>" AnchorHorizontal="98%"
                                        MaskRe="/[0-9:]/" TabIndex="3" CtCls="requiredData">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show(); CalculateTongGioHL(tfStart.getValue(), tfEnd.getValue());" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" ID="Container5" Layout="FormLayout" ColumnWidth=".5" LabelWidth="105">
                                <Items>
                                    <ext:DisplayField runat="server" ID="dpf1" Text="" Height="23" />
                                    <ext:TimeField ID="tfEnd" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                        Format="H:mm" FieldLabel="Giờ kết thúc<span style='color:red;'>*</span>" AnchorHorizontal="100%" TabIndex="4"
                                        MaskRe="/[0-9:]/" CtCls="requiredData">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Listeners>
                                            <Select Handler="this.triggers[0].show(); CalculateTongGioHL(tfStart.getValue(), tfEnd.getValue());" />
                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:TimeField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextArea runat="server" ID="txtCongViecHL" FieldLabel="Công việc" TabIndex="5"
                        AnchorHorizontal="100%">
                    </ext:TextArea>
                    <ext:Container runat="server" ID="Container6" AnchorHorizontal="100%" Layout="ColumnLayout" Height="90">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.68" LabelWidth="250">
                                <Items>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txt_T_AM" FieldLabel="Cộng giờ làm thêm ngày thường (ban ngày)" TabIndex="7"
                                        AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txt_N_AM" FieldLabel="Cộng giờ làm thêm ngày nghỉ (ban ngày)" TabIndex="9"
                                        AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txt_L_AM" FieldLabel="Cộng giờ làm thêm ngày lễ (ban ngày)" TabIndex="11"
                                        AnchorHorizontal="98%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.32" LabelWidth="65">
                                <Items>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txt_T_PM" FieldLabel="(ban đêm)" TabIndex="8"
                                        AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txt_N_PM" FieldLabel="(ban đêm)" TabIndex="10"
                                        AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                    <ext:NumberField runat="server" AllowNegative="false" ID="txt_L_PM" FieldLabel="(ban đêm)" TabIndex="12"
                                        AnchorHorizontal="100%" MaskRe="/[0-9.,]/">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Container runat="server" ID="ctn23" Layout="BorderLayout" Height="230">
                        <Items>
                            <ext:GridPanel runat="server" ID="grp_DanhSachCanBo" TrackMouseOver="true" Title="<%$ Resources:HopDong, DanhSachCanBo%>"
                                StripeRows="true" Border="true" Region="Center" Icon="User" AutoExpandColumn="TEN_DONVI"
                                AutoExpandMin="150">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tbDanhSachQD">
                                        <Items>
                                            <ext:Button runat="server" ID="btnChonDanhSachCanBo" Icon="UserAdd" Text="<%$ Resources:HOSO, ChooseStaff%>"
                                                TabIndex="13">
                                                <Listeners>
                                                    <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnXoaCanBo" Icon="Delete" Text="<%$ Resources:Language, delete%>" Disabled="true"
                                                TabIndex="14">
                                                <Listeners>
                                                    <Click Handler="#{grp_DanhSachCanBo}.deleteSelected(); #{hdfTotalRecord}.setValue(#{hdfTotalRecord}.getValue()*1 - 1);if(hdfTotalRecord.getValue() ==0){btnXoaCanBo.disable();}" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="grp_DanhSachCanBoStore" AutoLoad="false" runat="server" ShowWarningOnFailure="false"
                                        SkipIdForNewRecords="false" RefreshAfterSaving="None" AutoSave="false">
                                        <Reader>
                                            <ext:JsonReader IDProperty="PR_KEY">
                                                <Fields>
                                                    <ext:RecordField Name="PR_KEY" />
                                                    <ext:RecordField Name="MA_CB" />
                                                    <ext:RecordField Name="HO_TEN" />
                                                    <ext:RecordField Name="TEN_DONVI" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel3" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="40" />
                                        <ext:Column ColumnID="MA_CB" Header="<%$ Resources:HOSO, staff_code%>" Width="100" DataIndex="MA_CB" />
                                        <ext:Column ColumnID="HO_TEN" Header="<%$ Resources:HOSO, staff_name%>" Width="200" DataIndex="HO_TEN" />
                                        <ext:Column ColumnID="TEN_DONVI" Header="<%$ Resources:HOSO, staff_section%>" Width="100" DataIndex="TEN_DONVI">
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv1" />
                                </View>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="chkEmployeeRowSelection">
                                        <Listeners>
                                            <RowSelect Handler="btnXoaCanBo.enable();" />
                                            <RowDeselect Handler="btnXoaCanBo.disable();" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                            </ext:GridPanel>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="Button1" Text="<%$ Resources:Language, update%>" Icon="Disk" TabIndex="15">
                        <Listeners>
                            <Click Handler="return CheckInputHL();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatHL_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="json" Value="getJsonOfStore(grp_DanhSachCanBoStore)" Mode="Raw" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="Button33" Text="Cập nhật và đóng lại" Icon="Disk" TabIndex="16">
                        <Listeners>
                            <Click Handler="return CheckInputHL();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatHL_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="close" Value="True" />
                                    <ext:Parameter Name="json" Value="getJsonOfStore(grp_DanhSachCanBoStore)" Mode="Raw" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="Button4" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline" TabIndex="17">
                        <Listeners>
                            <Click Handler="wdThemCanBoHL.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetWdThemCanBo();" />
                </Listeners>
            </ext:Window>
            <ext:Store ID="grpPhieuLamThemGioStore" AutoLoad="true" runat="server">
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="HandlerPhieuLamThemGio.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="={0}" />
                    <ext:Parameter Name="limit" Value="={25}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="Month" Value="cbxMonth.getValue()" Mode="Raw" />
                    <ext:Parameter Name="Year" Value="spnYear.getValue()" Mode="Raw" />
                    <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                    <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="PrkeyHoSo" />
                            <ext:RecordField Name="MA_CB" />
                            <ext:RecordField Name="HO_TEN" />
                            <ext:RecordField Name="TEN_DONVI" />
                            <ext:RecordField Name="TuGio" />
                            <ext:RecordField Name="DenGio" />
                            <ext:RecordField Name="NgayDangKy" />
                            <ext:RecordField Name="LamThemNgayThuong_AM" />
                            <ext:RecordField Name="LamThemNgayNghi_AM" />
                            <ext:RecordField Name="LamThemNgayLe_AM" />
                            <ext:RecordField Name="LamThemNgayThuong_PM" />
                            <ext:RecordField Name="LamThemNgayNghi_PM" />
                            <ext:RecordField Name="LamThemNgayLe_PM" />
                            <ext:RecordField Name="NoiDung" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="grpPhieuLamThemGio" Border="false" TrackMouseOver="true" runat="server"
                                StripeRows="true" Header="false" StoreID="grpPhieuLamThemGioStore" AutoExpandColumn="NoiDung"
                                AutoExpandMin="250">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="bts">
                                        <Items>
                                            <ext:Button ID="mnThemNhanVien" runat="server" Text="Tạo phiếu làm thêm giờ" Icon="UserAdd">
                                                <Menu>
                                                    <ext:Menu runat="server" ID="mnUserAdd">
                                                        <Items>
                                                            <ext:MenuItem runat="server" ID="btnThemNhanVien" Text="Tạo phiếu cho một nhân viên" Icon="UserAdd">
                                                                <Listeners>
                                                                    <Click Handler="btnCapNhat.show(); btnEdit.hide(); btnCapNhatDongLai.show(); wdThemCanBo.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem runat="server" ID="btnThemNhanVienHL" Text="Tạo phiếu cho nhiều nhân viên" Icon="UserAdd">
                                                                <Listeners>
                                                                    <Click Handler="wdThemCanBoHL.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="btnDieuChinh" runat="server" Text="<%$ Resources:CommonMessage, Edit%>" Icon="Pencil" Disabled="true">
                                                <Listeners>
                                                    <Click Handler="if (CheckSelectedRow(#{grpPhieuLamThemGio}) == false) {return false;} btnCapNhat.hide(); btnEdit.show(); btnCapNhatDongLai.hide();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnDieuChinh_Click">
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button ID="btnXoa" runat="server" Text="<%$ Resources:Language, delete%>" Icon="Delete" Disabled="true">
                                                <Listeners>
                                                    <Click Handler="if (CheckSelectedRows(#{grpPhieuLamThemGio}) == false) {return false;} btnDieuChinh.disable(); btnXoa.disable();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnXoa_Click">
                                                        <EventMask ShowMask="true" Msg="Đang xóa dữ liệu. Vui lòng chờ..." />
                                                        <Confirmation Title="Xác nhận" Message="<%$ Resources:CommonMessage, ConfirmDelete%>" ConfirmRequest="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:ToolbarSeparator />
                                            <ext:Container runat="server" ID="Container1" Layout="FormLayout" LabelWidth="65">
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
                                            <ext:ToolbarFill runat="server" ID="tbf" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã hoặc họ tên cán bộ"
                                                ID="txtSearch">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                    <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{grpDangKyLamThemGioStore}.reload(); }" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button Text="<%$ Resources:Language, search%>" Icon="Zoom" runat="server" ID="btnSearch">
                                                <Listeners>
                                                    <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); #{grpDangKyLamThemGioStore}.reload();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="35" Locked="true" />
                                        <ext:Column ColumnID="colMA_CB" Header="<%$ Resources:HOSO, staff_code%>" Locked="true" Width="75" DataIndex="MA_CB" />
                                        <ext:Column ColumnID="colHO_TEN" Header="<%$ Resources:HOSO, staff_name%>" Locked="true" Width="150" DataIndex="HO_TEN" />
                                        <ext:Column ColumnID="colTEN_DONVI" Header="<%$ Resources:HOSO, staff_section%>" Width="180" DataIndex="TEN_DONVI" />
                                        <ext:DateColumn ColumnID="colNgay" Header="Ngày đăng ký" Width="85" DataIndex="NgayDangKy"
                                            Format="dd/MM/yyyy">
                                        </ext:DateColumn>
                                        <ext:Column ColumnID="colGioBatDau" Header="Từ giờ" Width="60" DataIndex="TuGio" />
                                        <ext:Column ColumnID="colGioKetThuc" Header="Đến giờ" Width="60" DataIndex="DenGio" />
                                        <ext:Column ColumnID="colNgayThuong" Header="Số giờ ngày thường (ban ngày)" Width="100" DataIndex="LamThemNgayThuong_AM">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNgayThuong" Header="Số giờ ngày thường (ban đêm)" Width="100" DataIndex="LamThemNgayThuong_PM">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNgayNghi" Header="Số giờ ngày nghỉ (ban ngày)" Width="100" DataIndex="LamThemNgayNghi_AM">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNgayNghi" Header="Số giờ ngày nghỉ (ban đêm)" Width="100" DataIndex="LamThemNgayNghi_PM">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNgayLe" Header="Số giờ ngày lễ (ban ngày)" Width="100" DataIndex="LamThemNgayLe_AM">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNgayLe" Header="Số giờ ngày lễ (ban đêm)" Width="100" DataIndex="LamThemNgayLe_PM">
                                            <Renderer Fn="RenderNumber" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNoiDung" Header="Nội dung" Width="200" DataIndex="NoiDung" />
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv" />
                                </View>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="hdfRecordID.setValue(RowSelectionModel1.getSelected().id); btnDieuChinh.enable(); btnXoa.enable();" />
                                            <RowDeselect Handler="hdfRecordID.reset(); btnDieuChinh.disable(); btnXoa.disable();" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <DirectEvents>
                                    <RowDblClick OnEvent="btnDieuChinh_Click" Before="if (CheckSelectedRow(#{grpPhieuLamThemGio}) == false) {return false;} btnCapNhat.hide(); btnEdit.show(); btnCapNhatDongLai.hide();">
                                        <EventMask ShowMask="true" />
                                    </RowDblClick>
                                </DirectEvents>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="25" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                </Items>
                                                <SelectedItem Value="25" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
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
