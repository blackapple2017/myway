<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhSachCa.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_SapXepCaLamViec" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript" src="Resource/DanhSachCa.js"></script>
    <link href="Resource/DanhSachCa.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfAction" />
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuAdd" runat="server" Icon="Add" Text="Thêm mới">
                    <Listeners>
                        <Click Handler="#{btnCapNhat}.show(); #{btnEdit}.hide(); #{btnCapNhatVaDongLai}.show(); #{wdThemCaLamViec}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                    <Listeners>
                        <Click Handler="#{btnCapNhat}.hide(); #{btnEdit}.show(); #{btnCapNhatVaDongLai}.hide();#{hdfAction}.setValue('Edit');#{wdChonCaLamViec}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuDelete" runat="server" Icon="Delete" Text="Xóa">
                    <Listeners>
                        <Click Handler="#{hdfAction}.setValue('Delete');#{wdChonCaLamViec}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem ID="MenuItem1" runat="server" Icon="Build" Text="Tiện ích">
                    <Menu>
                        <ext:Menu ID="Menu2" runat="server">
                            <Items>
                                <ext:MenuItem ID="MenuItem2" runat="server" Icon="DiskMultiple" Text="Nhân đôi dữ liệu">
                                    <Listeners>
                                        <Click Handler="#{hdfAction}.setValue('Duplicate');#{wdChonCaLamViec}.show();" />
                                    </Listeners>
                                </ext:MenuItem>
                            </Items>
                        </ext:Menu>
                    </Menu>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <%--<ext:Window runat="server" ID="wdChonCaLamViec" Layout="FormLayout" Hidden="true"
            Padding="6" AutoHeight="true" Width="450" Icon="ClockEdit" Title="Chọn ca làm việc"
            Constrain="true" Modal="true">
            <Items>
                <ext:Container runat="server" ID="ctn1" Layout="FormLayout" AnchorHorizontal="100%"
                    LabelWidth="110">
                    <Items>
                        <ext:Hidden runat="server" ID="hdfPrkeyCa" />
                        <ext:ComboBox runat="server" ID="cbxCaLamViec" FieldLabel="Chọn ca làm việc"
                            DisplayField="TenCa" ValueField="ID" AnchorHorizontal="100%" Editable="false"
                            ItemSelector="div.list-item">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Template ID="Template6" runat="server">
                                <Html>
                                    <tpl for=".">
						                <div class="list-item"> 
							                <h3>{TenCa} (Mã ca: {MaCa})</h3>
                                            Ngày áp dụng: {NgayApDung}<br />
                                            Giờ vào: {GioVao} --- Giờ ra: {GioRa}
						                </div>
					                </tpl>
                                </Html>
                            </Template>
                            <Store>
                                <ext:Store runat="server" ID="cbxCaLamViecStore" AutoLoad="false" OnRefreshData="cbxCaLamViecStore_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="MaCa" />
                                                <ext:RecordField Name="TenCa" />
                                                <ext:RecordField Name="GioVao" />
                                                <ext:RecordField Name="GioRa" />
                                                <ext:RecordField Name="NgayApDung" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <Expand Handler="if(cbxCaLamViec.store.getCount()==0) cbxCaLamViecStore.reload();" />
                                <Select Handler="this.triggers[0].show(); #{hdfPrkeyCa}.setValue(#{cbxCaLamViec}.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfPrkeyCa}.setValue('');}" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnDongY" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="if (#{cbxCaLamViec}.getValue() == '' || #{cbxCaLamViec}.getValue() == null)
                            {
                                alert('Bạn chưa chọn ca làm việc');
                                #{cbxCaLamViec}.focus();
                                return false;
                            }
                        " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnDongY_Click">
                            <EventMask ShowMask="true" Msg="Đang xử lý. Vui lòng chờ..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnHuy" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChonCaLamViec}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{cbxCaLamViecStore}.reload();" />
                <Hide Handler="#{cbxCaLamViec}.reset();" />
            </Listeners>
        </ext:Window>--%>
        <ext:Window runat="server" ID="wdThemCaLamViec" Layout="FormLayout" Hidden="true"
            Padding="6" AutoHeight="true" Width="655" MinWidth="655" Icon="ClockAdd" Title="Thêm mới ca làm việc"
            Constrain="true" Modal="true">
            <Items>
                <ext:FieldSet runat="server" Title="Thông tin chung" Layout="FormLayout" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container1" runat="server" Height="27" AnchorHorizontal="100%"
                            Layout="ColumnLayout">
                            <Items>
                                <ext:Container runat="server" ID="ctn130" Layout="FormLayout" ColumnWidth="0.3" LabelWidth="80">
                                    <Items>
                                        <ext:TextField ID="txtMaCa" runat="server" CtCls="requiredData" FieldLabel="Mã ca"
                                            MaxLength="20" AnchorHorizontal="99%" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="Container2" Layout="FormLayout" ColumnWidth="0.7">
                                    <Items>
                                        <ext:TextField ID="txtTenCa" CtCls="requiredData" runat="server" FieldLabel="Tên ca làm việc"
                                            MaxLength="500" AnchorHorizontal="100%" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container11" Height="27" runat="server" AnchorHorizontal="100%"
                            Layout="ColumnLayout">
                            <Items>
                                <ext:Container runat="server" ID="ctn124" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="80">
                                    <Items>
                                        <ext:TextField runat="server" ID="txtTongSoGio" CtCls="requiredData" FieldLabel="Tổng số giờ"
                                            AnchorHorizontal="98%" MaskRe="/[0-9.,]/" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn125" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:Hidden ID="hdfLoaiCa" runat="server">
                                        </ext:Hidden>
                                        <ext:ComboBox runat="server" Editable="false" ID="cbxLoaiCa" FieldLabel="Loại ca"
                                            AnchorHorizontal="100%" LabelWidth="50" DisplayField="Value" ValueField="ID"
                                            TabIndex="13">
                                            <Store>
                                                <ext:Store runat="server" ID="cbxLoaiCaStore" AutoLoad="false" OnRefreshData="cbxLoaiCaStore_OnRefreshData">
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
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <Expand Handler="#{cbxLoaiCaStore}.reload();" />
                                                <Select Handler="this.triggers[0].show(); #{hdfLoaiCa}.setValue(#{cbxLoaiCa}.getValue());" />
                                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container12" Height="27" runat="server" AnchorHorizontal="100%"
                            Layout="ColumnLayout">
                            <Items>
                                <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="80">
                                    <Items>
                                        <ext:TextField ID="txtLuongCuaCa" AnchorHorizontal="98%" FieldLabel="Lương của ca"
                                            runat="server" MaskRe="/[0-9]/" MaxLength="18" />
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container13" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                    <Items>
                                        <ext:TextField runat="server" FieldLabel="Phụ cấp ca" ID="txtPhuCapCa" MaskRe="/[0-9]/"
                                            AnchorHorizontal="100%" MaxLength="18" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" Title="Thời gian làm việc trong ca" AnchorHorizontal="100%"
                    Layout="FormLayout" LabelWidth="80">
                    <Items>
                        <ext:Container runat="server" ID="ctn101" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="27">
                            <Items>
                                <ext:Container runat="server" ID="ctn102" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="80">
                                    <Items>
                                        <ext:CompositeField runat="server" ID="csf10" FieldLabel="Nửa ca đầu" AnchorHorizontal="99%">
                                            <Items>
                                                <ext:DisplayField runat="server" ID="dpf10" Text="Từ" />
                                                <ext:TimeField ID="tfBatDauCa" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                                    Format="H:mm" FieldLabel="Bắt đầu ca" Width="76" MaskRe="/[0-9:]/" CtCls="requiredData">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                                <ext:DisplayField runat="server" ID="dpf11" Text="Đến" />
                                                <ext:TimeField ID="tfNghiNuaCaDau" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" FieldLabel="Nghỉ nửa ca đầu" Width="76" MaskRe="/[0-9:]/">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn103" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="80">
                                    <Items>
                                        <ext:CompositeField runat="server" ID="cpf11" FieldLabel="Nửa ca sau" AnchorHorizontal="100%">
                                            <Items>
                                                <ext:DisplayField runat="server" ID="dpf12" Text="Từ" />
                                                <ext:TimeField ID="tfBatDauCaSau" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" FieldLabel="Bắt đầu nửa ca sau" Width="80" MaskRe="/[0-9:]/">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                                <ext:DisplayField runat="server" ID="dpf13" Text="Đến" />
                                                <ext:TimeField ID="tfKetThucCaSau" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" FieldLabel="Kết thúc ca" Width="80" MaskRe="/[0-9:]/"
                                                    CtCls="requiredData">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <%-- <ext:CompositeField runat="server" ID="csf15" FieldLabel="Làm thêm" AnchorHorizontal="99%">
                            <Items>
                                <ext:DisplayField runat="server" ID="dpf15" Text="Đầu giờ" />
                                <ext:TimeField ID="tfBatDauLamThemDauGio" runat="server" MinTime="00:00" MaxTime="23:59"
                                    Increment="1" Format="H:mm" FieldLabel="Làm thêm đầu giờ" Width="80"
                                    MaskRe="/[0-9:]/">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:TimeField>
                                <ext:DisplayField runat="server" ID="dpf16" Text="Cuối giờ" />
                                <ext:TimeField ID="tfBatDauLamThemCuoiGio" runat="server" MinTime="00:00" MaxTime="23:59"
                                    Increment="1" Format="H:mm" FieldLabel="Làm thêm cuối giờ" Width="80"
                                    MaskRe="/[0-9:]/">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:TimeField>
                            </Items>
                        </ext:CompositeField>--%>
                    </Items>
                </ext:FieldSet>
                <ext:FieldSet runat="server" ID="fs99" Layout="FormLayout" AnchorHorizontal="100%"
                    Title="Thời gian quẹt thẻ">
                    <Items>
                        <ext:Container runat="server" ID="ctn67" Layout="ColumnLayout" AnchorHorizontal="100%"
                            Height="50">
                            <Items>
                                <ext:Container runat="server" ID="ctn68" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="80">
                                    <Items>
                                        <ext:CompositeField runat="server" ID="csf70" CtCls="requiredData" FieldLabel="Đầu ca">
                                            <Items>
                                                <ext:DisplayField runat="server" ID="dpf200" Text="Từ" />
                                                <ext:TimeField ID="tfDauCaTu" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                                    Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                                <ext:DisplayField runat="server" ID="dpf201" Text="Đến" />
                                                <ext:TimeField ID="tfDauCaDen" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                                    Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:CompositeField>
                                        <ext:CompositeField runat="server" ID="csf71" FieldLabel="Vào ca sau">
                                            <Items>
                                                <ext:DisplayField runat="server" ID="dpf202" Text="Từ" />
                                                <ext:TimeField ID="tfGiuaCaVaoTu" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                                <ext:DisplayField runat="server" ID="dpf203" Text="Đến" />
                                                <ext:TimeField ID="tfGiuaCaVaoDen" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn69" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="80">
                                    <Items>
                                        <ext:CompositeField runat="server" ID="csf72" FieldLabel="Nghỉ giữa ca">
                                            <Items>
                                                <ext:DisplayField runat="server" ID="dpf204" Text="Từ" />
                                                <ext:TimeField ID="tfGiuaCaRaTu" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                                                    Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                                <ext:DisplayField runat="server" ID="dpf205" Text="Đến" />
                                                <ext:TimeField ID="tfGiuaCaRaDen" runat="server" MinTime="00:00" MaxTime="23:59"
                                                    Increment="1" Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:CompositeField>
                                        <ext:CompositeField runat="server" ID="csf73" FieldLabel="Cuối ca">
                                            <Items>
                                                <ext:DisplayField runat="server" ID="dpf206" Text="Từ" />
                                                <ext:TimeField ID="tfCuoiCaTu" runat="server" CtCls="requiredData" MinTime="00:00"
                                                    MaxTime="23:59" Increment="1" Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                                <ext:DisplayField runat="server" ID="dpf207" Text="Đến" />
                                                <ext:TimeField ID="tfCuoiCaDen" runat="server" CtCls="requiredData" MinTime="00:00"
                                                    MaxTime="23:59" Increment="1" Format="H:mm" MaskRe="/[0-9:]/" Width="80">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:TimeField>
                                            </Items>
                                        </ext:CompositeField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
                <ext:Container ID="Container6" runat="server" AutoHeight="true" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container7" runat="server" Height="27" Layout="FormLayout" ColumnWidth="0.5"
                            LabelWidth="110">
                            <Items>
                                <ext:CompositeField ID="CompositeField1" FieldLabel="Cho phép đi muộn" runat="server">
                                    <Items>
                                        <%--<ext:DisplayField ID="DisplayField1" runat="server" Text="Cho phép đi muộn" />--%>
                                        <ext:TextField ID="txtSoPhutChoPhepDiMuon" runat="server" Width="50" MaxLength="10"
                                            MaskRe="/[0-9]/" />
                                        <ext:DisplayField ID="DisplayField2" runat="server" Text="Phút" />
                                    </Items>
                                </ext:CompositeField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container8" runat="server" Height="27" Layout="FormLayout" ColumnWidth="0.5"
                            LabelWidth="110">
                            <Items>
                                <ext:CompositeField ID="CompositeField5" runat="server" FieldLabel="Cho phép về sớm">
                                    <Items>
                                        <%--<ext:DisplayField ID="DisplayField9" runat="server" Text="Cho phép về sớm" />--%>
                                        <ext:TextField runat="server" Width="50" ID="txtSoPhutChoPhepVeSom" MaxLength="10"
                                            MaskRe="/[0-9]/" />
                                        <ext:DisplayField ID="DisplayField10" runat="server" Text="Phút" />
                                    </Items>
                                </ext:CompositeField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="ctn121" Layout="ColumnLayout" AnchorHorizontal="100%"
                    Height="27">
                    <Items>
                        <ext:Container runat="server" ID="ctn122" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="110">
                            <Items>
                                <ext:Checkbox runat="server" ID="chkRaNgoaiKhongBiTruGio" BoxLabel="Ra ngoài không bị trừ giờ" />
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctn123" Layout="FormLayout" ColumnWidth="0.5" LabelWidth="1">
                            <Items>
                                <ext:Checkbox runat="server" ID="chkDangSuDung" BoxLabel="Đang sử dụng" Checked="true" />
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="btnCapNhat" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputDanhSachCaLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Closed" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnEdit" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputDanhSachCaLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatVaDongLai" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputDanhSachCaLamViec();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Closed" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdThemCaLamViec.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnCapNhat}.show(); #{btnEdit}.hide(); #{btnCapNhatVaDongLai}.show(); Ext.net.DirectMethods.ResetWindowsTitle(); resetForm();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdQuyTacLamThemGio" Layout="FormLayout" Hidden="true"
            Padding="6" AutoHeight="true" Width="400" Icon="ClockAdd" Title="Thêm mới quy tắc làm thêm giờ"
            Modal="true" Constrain="true" LabelWidth="110">
            <Items>
                <ext:TimeField ID="tfTuGio" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                    Format="H:mm" FieldLabel="Từ giờ" AnchorHorizontal="99%" EmptyText="Giờ bắt đầu"
                    MaskRe="/[0-9:]/" AllowBlank="false" />
                <ext:TimeField ID="tfDenGio" runat="server" MinTime="00:00" MaxTime="23:59" Increment="1"
                    Format="H:mm" FieldLabel="Đến giờ" AnchorHorizontal="99%" EmptyText="Giờ kết thúc"
                    MaskRe="/[0-9:]/" AllowBlank="false" />
                <ext:ComboBox runat="server" ID="cbxLoaiNgay" AnchorHorizontal="99%" FieldLabel="Loại ngày"
                    Editable="false" AllowBlank="false">
                    <Items>
                        <ext:ListItem Text="Ngày thường" Value="EveryDay" />
                        <ext:ListItem Text="Thứ 7" Value="Saturday" />
                        <ext:ListItem Text="Chủ nhật" Value="Sunday" />
                        <ext:ListItem Text="Ngày lễ" Value="Holiday" />
                    </Items>
                </ext:ComboBox>
                <ext:TextField runat="server" ID="txtHeSoLuong" FieldLabel="% hưởng lương" MaskRe="/[0-9,.]/"
                    AllowBlank="false" AnchorHorizontal="99%" MaxLength="10" />
                <ext:NumberField runat="server" ID="txtOrder" FieldLabel="Thứ tự" MaskRe="/[0-9,.]/"
                    AllowBlank="false" AllowNegative="false" AnchorHorizontal="99%" MaxLength="2">
                </ext:NumberField>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatQuyTac" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuyTacChamCong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatQuyTac_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="MaCa" Value="RowSelectionModel1.getSelected().data.MaCa" Mode="Raw" />
                                <ext:Parameter Name="Closed" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnEditQuyTac" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuyTacChamCong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatQuyTac_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="MaCa" Value="RowSelectionModel1.getSelected().data.MaCa" Mode="Raw" />
                                <ext:Parameter Name="Command" Value="Edit" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCapNhatVaDongLaiQuyTac" Text="Cập nhật và đóng lại"
                    Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInputQuyTacChamCong();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatQuyTac_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="MaCa" Value="RowSelectionModel1.getSelected().data.MaCa" Mode="Raw" />
                                <ext:Parameter Name="Closed" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLai" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdQuyTacLamThemGio}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetQuyTacLamThemGio(); Ext.net.DirectMethods.ResetWindowsQuyTac();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" Title="Cấu hình các cột trên lưới" Resizable="false" Layout="FormLayout"
            Padding="6" Width="500" Hidden="true" Icon="Cog" ID="wdConfigGridPanel" Modal="true"
            Constrain="true" AutoHeight="true">
            <Items>
                <ext:FieldSet runat="server" ID="fs17" Title="Chọn các cột muốn hiển thị trên lưới"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="ctn105" AnchorHorizontal="100%" Layout="ColumnLayout"
                            Height="270">
                            <Items>
                                <ext:Container runat="server" ID="ctn106" ColumnWidth="0.5" Layout="RowLayout">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkGioVao" BoxLabel="Giờ vào" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkGioRa" BoxLabel="Giờ ra" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkSoGioLam" BoxLabel="Số giờ làm" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkChoPhepDiMuon" BoxLabel="Cho phép đi muộn" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkChoPhepVeSom" BoxLabel="Cho phép về sớm" Height="25"
                                            Checked="true" />
                                        <%--
                                            Không xóa
                                         <ext:Checkbox runat="server" ID="chkBatDauTinhLamThemDauGio" BoxLabel="Bắt đầu tính làm thêm đầu giờ"
                                            Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkBatDauTinhLamThemCuoiGio" BoxLabel="Bắt đầu tính làm thêm cuối giờ"
                                            Height="25" Checked="true" />--%>
                                        <ext:Checkbox runat="server" ID="chkApDungTuNgay" BoxLabel="Áp dụng từ ngày" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkApDungDenNgay" BoxLabel="Áp dụng đến ngày" Height="25"
                                            Checked="true" />
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="ctn107" ColumnWidth="0.5" Layout="RowLayout">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkQuetTheDauCa" BoxLabel="Quẹt thẻ đầu ca" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkQuetTheNghiDauCa" BoxLabel="Quẹt thẻ nghỉ đầu ca"
                                            Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkQuetTheVaoCaSau" BoxLabel="Quẹt thẻ vào ca sau"
                                            Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkQuetTheCuoiCa" BoxLabel="Quẹt thẻ cuối ca" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkPhuCapCa" BoxLabel="Phụ cấp ca" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkMucLuongCa" BoxLabel="Mức lương của ca" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNgayApDung" BoxLabel="Ngày áp dụng" Height="25"
                                            Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkNgayTao" BoxLabel="Ngày tạo" Height="25" Checked="true" />
                                        <ext:Checkbox runat="server" ID="chkLoaiCa" BoxLabel="Loại ca" Height="25" Checked="true" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhatCauHinh" Text="Cập nhật" Icon="Disk">
                    <DirectEvents>
                        <Click OnEvent="btnCapNhatCauHinh_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu. Vui lòng chờ..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnDongLaiCauHinh" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdConfigGridPanel.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="Ext.net.DirectMethods.LoadConfigGridPanel();" />
                <Hide Handler="ResetWdConfig();" />
            </Listeners>
        </ext:Window>
        <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
            Padding="6" Constrain="true" Title="Nhập mã đợt đánh giá mới" Hidden="true" Icon="DiskMultiple"
            runat="server" AutoHeight="true">
            <Items>
                <ext:TextField FieldLabel="Nhập mã ca" runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%"
                    MaxLength="20" />
            </Items>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset(); FieldSet1.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                    <Listeners>
                        <Click Handler="if(txtmaloaihdcoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="mnuNhanDoi_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Đóng lại">
                    <Listeners>
                        <Click Handler="wdInputNewPrimaryKey.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grp_DanhSachCa_Store" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="Handler/HandlerDanhSachCa.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={15}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MaCa" />
                        <ext:RecordField Name="TenCa" />
                        <ext:RecordField Name="GioVao" />
                        <ext:RecordField Name="GioRa" />
                        <ext:RecordField Name="NghiGiuaCa" />
                        <ext:RecordField Name="VaoGiuaCa" />
                        <ext:RecordField Name="SoPhutChoPhepDiMuon" />
                        <ext:RecordField Name="SoPhutChoPhepVeSom" />
                        <ext:RecordField Name="BatDauTinhLamThemDauGio" />
                        <ext:RecordField Name="BatDauTinhLamThemCuoiGio" />
                        <ext:RecordField Name="PhuCapCa" />
                        <ext:RecordField Name="TienLuongCa" />
                        <ext:RecordField Name="RaNgoaiKhongBiTruGio" />
                        <ext:RecordField Name="QuetTheDauCa" />
                        <ext:RecordField Name="QuetTheNghiDauCa" />
                        <ext:RecordField Name="QuetTheVaoCaSau" />
                        <ext:RecordField Name="QuetTheCuoiCa" />
                        <ext:RecordField Name="ThoiGianApDungTu" />
                        <ext:RecordField Name="ThoiGianApDungDen" />
                        <ext:RecordField Name="NgayApDung" />
                        <ext:RecordField Name="CreatedDate" />
                        <ext:RecordField Name="TongGio" />
                        <ext:RecordField Name="LoaiCa" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brLayout">
                    <Center>
                        <ext:GridPanel ID="grp_DanhSachCa" runat="server" StoreID="grp_DanhSachCa_Store"
                            TrackMouseOver="true" StripeRows="true" Width="600" Border="false" AutoExpandColumn="TenCa"
                            AutoExpandMin="120">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbGrid">
                                    <Items>
                                        <ext:Button runat="server" ID="btnThemMoi" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{txtMaCa}.enable();#{btnCapNhat}.show(); #{btnEdit}.hide(); #{btnCapNhatVaDongLai}.show(); #{wdThemCaLamViec}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnSua" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <%--<Click Handler="if (CheckSelectedRows(#{grp_DanhSachCa}) == false) {return false;} #{btnCapNhat}.hide(); #{btnEdit}.show(); #{btnCapNhatVaDongLai}.hide();/*#{hdfAction}.setValue('Edit');*/#{wdChonCaLamViec}.show();" />--%>
                                                <Click Handler="if (CheckSelectedRows(#{grp_DanhSachCa}) == false) {return false;} #{btnCapNhat}.hide(); #{btnEdit}.show(); #{btnCapNhatVaDongLai}.hide();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="EditCaLamViec">
                                                    <EventMask ShowMask="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnXoa" Disabled="true" Text="Xóa" Icon="Delete">
                                            <Listeners>
                                                <%--<Click Handler="#{hdfAction}.setValue('Delete');#{wdChonCaLamViec}.show();" />--%>
                                                <Click Handler="return CheckSelectedRow(#{grp_DanhSachCa});" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnXoa_Click">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa?" ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" />
                                        <ext:Button runat="server" ID="btnTienIch" Text="Tiện ích" Icon="Build">
                                            <Menu>
                                                <ext:Menu runat="server" ID="mnuTienIch">
                                                    <Items>
                                                        <ext:MenuItem runat="server" ID="mnuNhanDoi" Text="Nhân đôi dữ liệu" Icon="DiskMultiple"
                                                            Disabled="true">
                                                            <Listeners>
                                                                <%--<Click Handler="#{hdfAction}.setValue('Duplicate');#{wdChonCaLamViec}.show();" />--%>
                                                                <Click Handler="if (CheckSelectedRows(#{grp_DanhSachCa}) == false) {return false;} wdInputNewPrimaryKey.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnConfig" Text="Cấu hình" Icon="Cog">
                                            <Listeners>
                                                <Click Handler="wdConfigGridPanel.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã ca hoặc tên ca"
                                            ID="txtSearch">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <KeyUp Handler="if (txtSearch.getValue() != '') this.triggers[0].show();" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{grp_DanhSachCa_Store}.reload(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler=" PagingToolbar1.pageIndex = 0; #{grp_DanhSachCa_Store}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="MaCa" Header="Mã ca" Locked="true" Width="50" DataIndex="MaCa" />
                                    <ext:Column ColumnID="TenCa" Header="Tên ca" Locked="true" Width="120" DataIndex="TenCa" />
                                    <ext:Column ColumnID="DSC_GIOVAO" Header="Giờ vào" Width="70" Locked="true" DataIndex="GioVao">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_GIORA" Width="70" Header="Giờ ra" Locked="true" DataIndex="GioRa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_NGAYAPDUNG" Width="80" Header="Ngày áp dụng" Locked="false"
                                        DataIndex="NgayApDung">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_LOAICA" Width="90" Header="Loại ca" Locked="false" DataIndex="LoaiCa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_SOGIOLAM" Width="70" Header="Số giờ làm" Locked="false"
                                        DataIndex="TongGio">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_QUETTHEDAUCA" Width="120" Header="Quẹt thẻ đầu ca" Align="Center"
                                        DataIndex="QuetTheDauCa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_QUETTHENGHIDAUCA" Width="120" Header="Quẹt thẻ nghỉ đầu ca"
                                        Align="Center" DataIndex="QuetTheNghiDauCa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_QUETTHEVAOCASAU" Width="120" Header="Quẹt thẻ vào ca sau"
                                        Align="Center" DataIndex="QuetTheVaoCaSau">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_QUETTHECUOICA" Width="120" Header="Quẹt thẻ cuối ca" Align="Center"
                                        DataIndex="QuetTheCuoiCa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_CHOPHEPDIMUON" Width="100" Header="Cho phép đi muộn" Align="Right"
                                        DataIndex="SoPhutChoPhepDiMuon">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_CHOPHEPVESOM" Width="100" Header="Cho phép về sớm" Align="Right"
                                        DataIndex="SoPhutChoPhepVeSom">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <%--
                                        Không xóa
                                        <ext:Column ColumnID="DSC_BATDAUTINHLAMTHEMDAUGIO" Width="120" Header="Bắt đầu tính làm thêm đầu giờ"
                                        Align="Right" DataIndex="BatDauTinhLamThemDauGio">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_BATDAULAMTHEMCUOIGIO" Width="120" Header="Bắt đầu tính làm thêm cuối giờ"
                                        Align="Right" DataIndex="BatDauTinhLamThemCuoiGio">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>--%>
                                    <ext:Column ColumnID="DSC_PHUCAPCA" Width="120" Header="Phụ cấp ca" Align="Right"
                                        DataIndex="PhuCapCa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_MUCLUONGCA" Width="120" Header="Mức lương của ca" Align="Right"
                                        DataIndex="TienLuongCa">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_APDUNGTUNGAY" Width="80" Header="Áp dụng từ" Align="Center"
                                        DataIndex="ThoiGianApDungTu">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_APDUNGDENNGAY" Width="80" Header="Áp dụng đến" Align="Center"
                                        DataIndex="ThoiGianApDungDen">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                    <ext:Column ColumnID="DSC_NGAYTAO" Width="80" Header="Ngày tạo" Align="Center" DataIndex="CreatedDate">
                                        <Renderer Fn="RenderMultiDataGrid" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{hdfRecordID}.setValue(RowSelectionModel1.getSelected().id); try {#{btnSua}.enable();}catch(e){} try{#{btnXoa}.enable();}catch(e){} 
                                            try{#{mnuNhanDoi}.enable();}catch(e){} try{#{btnAddQT}.enable();} catch(e) {}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="15">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                            </Items>
                                            <SelectedItem Value="15" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grp_DanhSachCa}.getSelectionModel().selectRow(rowIndex);" />
                                <%--<RowDblClick Handler="#{btnCapNhat}.hide(); #{btnEdit}.show(); #{btnCapNhatVaDongLai}.hide();#{hdfAction}.setValue('Edit');#{wdChonCaLamViec}.show();" />--%>
                                <ViewReady Handler="cbxLoaiCaStore.reload();" />
                            </Listeners>
                            <%--<DirectEvents>
                                <RowDblClick OnEvent="EditCaLamViec" Before="#{btnCapNhat}.hide(); #{btnEdit}.show(); #{btnCapNhatVaDongLai}.hide();">
                                    <EventMask ShowMask="true" />
                                </RowDblClick>
                            </DirectEvents>--%>
                        </ext:GridPanel>
                    </Center>
                    <South>
                        <ext:Panel ID="pnlSouth" Border="false" Height="200" runat="server" Layout="BorderLayout"
                            Visible="false" Hidden="false" Title="Quy tắc tính lương làm thêm giờ">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfIDQuyTac" />
                                <ext:GridPanel ID="grp_QuyTacLamThemGio" runat="server" Region="Center" StripeRows="true"
                                    Width="600" Border="false" Height="290">
                                    <TopBar>
                                        <ext:Toolbar runat="server" ID="tb">
                                            <Items>
                                                <ext:Button ID="btnAddQT" runat="server" Text="Thêm quy tắc" Icon="Add" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="#{btnCapNhatQuyTac}.show(); #{btnEditQuyTac}.hide(); #{btnCapNhatVaDongLaiQuyTac}.show(); #{wdQuyTacLamThemGio}.show();" />
                                                    </Listeners>
                                                </ext:Button>
                                                <ext:Button ID="btnEditQT" runat="server" Text="Sửa" Icon="Pencil" Disabled="true">
                                                    <Listeners>
                                                        <Click Handler="#{btnCapNhatQuyTac}.hide(); #{btnEditQuyTac}.show(); #{btnCapNhatVaDongLaiQuyTac}.hide();" />
                                                    </Listeners>
                                                    <DirectEvents>
                                                        <Click OnEvent="btnEditQT_Click">
                                                            <EventMask ShowMask="true" />
                                                        </Click>
                                                    </DirectEvents>
                                                </ext:Button>
                                                <ext:Button ID="btnXoaQT" runat="server" Text="Xóa" Icon="Delete" Disabled="true">
                                                    <%--<Listeners>
                                                        <Click Handler="RemoveItemOnGridQuyTac(#{grp_QuyTacLamThemGio}, #{grp_QuyTacLamThemGio_Store});" />
                                                    </Listeners>--%>
                                                </ext:Button>
                                            </Items>
                                        </ext:Toolbar>
                                    </TopBar>
                                    <Store>
                                        <ext:Store ID="grp_QuyTacLamThemGio_Store" AutoLoad="false" runat="server" OnRefreshData="grp_QuyTacLamThemGio_Store_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID">
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TuGio" />
                                                        <ext:RecordField Name="DenGio" />
                                                        <ext:RecordField Name="LoaiNgay" />
                                                        <ext:RecordField Name="NhanHeSo" />
                                                        <ext:RecordField Name="Order" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel2" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="35" />
                                            <ext:Column ColumnID="TuGio" Header="Từ giờ" Width="70" DataIndex="TuGio" />
                                            <ext:Column ColumnID="DenGio" Header="Đến giờ" Width="70" DataIndex="DenGio" />
                                            <ext:Column ColumnID="LoaiNgay" Width="100" Header="Loại ngày" DataIndex="LoaiNgay">
                                                <Renderer Fn="rendererLoaiNgay" />
                                                <Editor>
                                                    <ext:ComboBox Editable="false" runat="server" ID="cbLoaiNgay">
                                                        <Items>
                                                            <ext:ListItem Text="Ngày thường" Value="EveryDay" />
                                                            <ext:ListItem Text="Thứ 7" Value="Saturday" />
                                                            <ext:ListItem Text="Chủ nhật" Value="Sunday" />
                                                            <ext:ListItem Text="Ngày lễ" Value="Holiday" />
                                                        </Items>
                                                    </ext:ComboBox>
                                                </Editor>
                                            </ext:Column>
                                            <ext:Column ColumnID="NhanHeSo" Width="150" Header="Phần trăm hưởng lương" DataIndex="NhanHeSo">
                                                <Renderer Fn="RenderPercent" />
                                            </ext:Column>
                                            <ext:Column Header="Thứ tự" DataIndex="Order" Width="50">
                                            </ext:Column>
                                        </Columns>
                                    </ColumnModel>
                                    <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                            <Listeners>
                                                <RowSelect Handler="#{hdfIDQuyTac}.setValue(#{RowSelectionModel2}.getSelected().id); try{#{btnEditQT}.enable();}catch(e){} 
                                                        try{#{btnXoaQT}.enable();}catch(e){}" />
                                            </Listeners>
                                        </ext:RowSelectionModel>
                                    </SelectionModel>
                                    <Listeners>
                                        <%--<RowDblClick Handler="#{btnCapNhatQuyTac}.hide(); #{btnEditQuyTac}.show(); #{btnCapNhatVaDongLaiQuyTac}.hide();" />--%>
                                        <AfterEdit Fn="afterEdit" />
                                    </Listeners>
                                    <%--                                    <DirectEvents>
                                        <RowDblClick OnEvent="btnEditQT_Click">
                                            <EventMask ShowMask="true" />
                                        </RowDblClick>
                                    </DirectEvents>--%>
                                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu ..." />
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </South>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
