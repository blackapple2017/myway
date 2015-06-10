<%@ Page Language="C#" AutoEventWireup="true" CodeFile="UngVienDuTru.aspx.cs" Inherits="Modules_TuyenDung_UngVienDuTru" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="uscTuyenDung_HoSoUngVien.ascx" TagName="uscTuyenDung_HoSoUngVien"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="Resource/UngVienDuTruJS.js" type="text/javascript"></script>
    <style type="text/css">
        .list-item
        {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
        
        #wdShowReport .x-tab-panel-header
        {
            display: none !important;
        }
        
        #GridPanel1 .x-grid3-cell-inner
        {
            white-space: nowrap !important;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="grpGridPanel1_Store.reload();" />
            </Listeners>
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfType" />
        <ext:Hidden runat="server" ID="hdfCommandType" Text="Edit" />
        <ext:Window runat="server" Title="Tìm kiếm nâng cao" Icon="Zoom" Constrain="true"
            ID="wdAdvanceSearch" Height="200" Modal="true" Width="900" Hidden="true" Padding="6">
            <Items>
                <ext:Container ID="Container24" runat="server" Height="210" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container25" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                            <Items>
                                <ext:NumberField ID="txt_MaUngVien" runat="server" FieldLabel="Mã ứng viên" TabIndex="2"
                                    AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự"
                                    Regex="/[\d]+/">
                                </ext:NumberField>
                                <ext:TextField ID="txt_TenUngVien" runat="server" FieldLabel="Họ tên" TabIndex="2"
                                    AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                </ext:TextField>
                                <ext:ComboBox runat="server" ID="cbx_gioitinh" Editable="false" SelectedIndex="0"
                                    FieldLabel="Giới tính" TabIndex="3" AnchorHorizontal="98%">
                                    <Items>
                                        <ext:ListItem Text="Nam" Value="M" />
                                        <ext:ListItem Text="Nữ" Value="F" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:NumberField ID="txt_Tuoi" runat="server" FieldLabel="Tuổi" TabIndex="2" AnchorHorizontal="98%"
                                    MaxLength="2" MaxLengthText="Bạn chỉ được nhập tối đa 2 ký tự" Regex="/[\d]+/">
                                </ext:NumberField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container26" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfTinhTrangHN" />
                                <ext:ComboBox ID="cbx_tt_honnhan" runat="server" FieldLabel="T/T hôn nhân" DisplayField="TEN_TT_HN"
                                    ValueField="MA_TT_HN" AnchorHorizontal="98%" TabIndex="5">
                                    <Store>
                                        <ext:Store ID="cbx_tt_honnhanstore" runat="server" AutoLoad="false" OnRefreshData="cbx_tt_honnhanstore_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA_TT_HN">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_TT_HN" />
                                                        <ext:RecordField Name="TEN_TT_HN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Focus Handler="#{cbx_tt_honnhanstore}.reload();" />
                                        <Select Handler="this.triggers[0].show();#{hdfTinhTrangHN}.setValue(#{cbx_tt_honnhan}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfTinhThanh" />
                                <ext:ComboBox runat="server" ID="cbx_tinhthanh" FieldLabel="Tỉnh thành" DisplayField="TEN"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ValueField="MA" AnchorHorizontal="98%"
                                    TabIndex="15" Editable="true" ItemSelector="div.list-item">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template9" runat="server">
                                        <Html>
                                            <tpl for=".">
						                                                        <div class="list-item"> 
							                                                        {TEN}
						                                                        </div>
					                                                        </tpl>
                                        </Html>
                                    </Template>
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_tinhthanh_Store" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="table" Value="DM_TINHTHANH" Mode="Value" />
                                                <ext:Parameter Name="ma" Value="MA_TINHTHANH" Mode="Value" />
                                                <ext:Parameter Name="ten" Value="TEN_TINHTHANH" Mode="Value" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader IDProperty="MA" Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="MA" />
                                                        <ext:RecordField Name="TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Focus Handler="if (#{cbx_quoctich}.getValue() == '') {#{cbx_tinhthanh_Store}.removeAll(); alert('Bạn phải chọn quốc tịch trước');} else {if(#{cbx_tinhthanh}.store.getCount()==0) #{cbx_tinhthanh_Store}.reload();}" />
                                        <Select Handler="this.triggers[0].show();#{hdfTinhThanh}.setValue(#{cbx_tinhthanh}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfTruongDaoTao" />
                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" HideTrigger="false" DisplayField="TEN"
                                    runat="server" FieldLabel="Trường đào tạo" PageSize="15" ItemSelector="div.search-item"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ID="cbx_TruongDaoTao" LoadingText="Đang tải dữ liệu..."
                                    TabIndex="26">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="cbx_TruongDaoTao_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="table" Value="DM_TRUONG_DAOTAO" Mode="Value" />
                                                <ext:Parameter Name="ma" Value="MA_TRUONG_DAOTAO" Mode="Value" />
                                                <ext:Parameter Name="ten" Value="TEN_TRUONG_DAOTAO" Mode="Value" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="MA" />
                                                        <ext:RecordField Name="TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template19" runat="server">
                                        <Html>
                                            <tpl for=".">
						                            <div class="search-item">
							                            {TEN}
						                            </div>
					                            </tpl>
                                        </Html>
                                    </Template>
                                    <ToolTips>
                                        <ext:ToolTip runat="server" ID="ttTruongDT" Title="Hướng dẫn" Html="Nhập tên trường đào tạo để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                    </ToolTips>
                                    <Listeners>
                                        <Focus Handler="#{cbx_TruongDaoTao_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfTruongDaoTao}.setValue(#{cbx_TruongDaoTao}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfTruongDaoTao}.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfChuyenNganh" />
                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" DisplayField="TEN" runat="server"
                                    FieldLabel="Chuyên ngành" PageSize="15" HideTrigger="false" ItemSelector="div.search-item"
                                    MinChars="1" EmptyText="Gõ để tìm kiếm" ID="cbx_ChuyenNganh" LoadingText="Đang tải dữ liệu..."
                                    TabIndex="27">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="cbx_ChuyenNganh_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="table" Value="DM_CHUYENNGANH" Mode="Value" />
                                                <ext:Parameter Name="ma" Value="MA_CHUYENNGANH" Mode="Value" />
                                                <ext:Parameter Name="ten" Value="TEN_CHUYENNGANH" Mode="Value" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="MA" />
                                                        <ext:RecordField Name="TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template11" runat="server">
                                        <Html>
                                            <tpl for=".">
						                                        <div class="search-item">
							                                        {TEN}
						                                        </div>
					                                        </tpl>
                                        </Html>
                                    </Template>
                                    <ToolTips>
                                        <ext:ToolTip runat="server" ID="ToolTip3" Title="Hướng dẫn" Html="Nhập tên chuyên ngành để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                                    </ToolTips>
                                    <Listeners>
                                        <Focus Handler="#{cbx_ChuyenNganh_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfChuyenNganh}.setValue(#{cbx_ChuyenNganh}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); #{hdfChuyenNganh}.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container1" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                            <Items>
                                <ext:NumberField ID="txt_TongDiem" runat="server" FieldLabel="Tổng điểm" TabIndex="3"
                                    AnchorHorizontal="98%" MaxLength="3" MaxLengthText="Bạn chỉ được nhập tối đa 3 ký tự"
                                    Regex="/[\d]+/">
                                </ext:NumberField>
                                <ext:NumberField ID="txt_kinhnghiem" runat="server" EmptyText="Số năm kinh ngiệm"
                                    FieldLabel="Kinh nghiệm" TabIndex="24" AnchorHorizontal="98%" MaxLength="2">
                                </ext:NumberField>
                                <ext:Hidden runat="server" ID="hdfCongViec" />
                                <ext:ComboBox runat="server" ID="cbx_congviec" FieldLabel="Công việc" DisplayField="TEN"
                                    MinChars="1" ValueField="MA" AnchorHorizontal="98%" ListWidth="200" TabIndex="5"
                                    Editable="true" ItemSelector="div.list-item" PageSize="15" LoadingText="<%$ Resources:HOSO, Loading%>"
                                    EmptyText="Gõ để tìm kiếm">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Template ID="Template1" runat="server">
                                        <Html>
                                            <tpl for=".">
						                                <div class="list-item"> 
							                                {TEN}
						                                </div>
					                                </tpl>
                                        </Html>
                                    </Template>
                                    <Store>
                                        <ext:Store ID="cbx_congviec_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="table" Value="DM_CONGVIEC" Mode="Value" />
                                                <ext:Parameter Name="ma" Value="MA_CONGVIEC" Mode="Value" />
                                                <ext:Parameter Name="ten" Value="TEN_CONGVIEC" Mode="Value" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="MA" />
                                                        <ext:RecordField Name="TEN" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Focus Handler="#{cbx_congviec_Store}.reload();" />
                                        <Select Handler="this.triggers[0].show();#{hdfCongViec}.setValue(#{cbx_congviec}.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Hidden runat="server" ID="hdfLyDo" />
                                <ext:ComboBox runat="server" Editable="false" ID="cbx_LyDo" FieldLabel="Lý do" AnchorHorizontal="98%"
                                    LabelWidth="50" DisplayField="Value" ValueField="ID">
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_LyDoStore" AutoLoad="false" OnRefreshData="cbx_LyDoStore_OnRefreshData">
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
                                        <Focus Handler="#{cbx_LyDoStore}.reload();" />
                                        <Select Handler="this.triggers[0].show(); #{hdfLyDo}.setValue(#{cbx_LyDo}.getValue());" />
                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdAdvanceSearch.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
            Title="Báo cáo hồ sơ ứng viên chi tiết" Maximized="true" Icon="Printer">
            <Items>
                <ext:Hidden runat="server" ID="hdfTypeReport" />
                <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                    runat="server">
                </ext:TabPanel>
            </Items>
            <Listeners>
                <BeforeShow Handler="ShowReportAction();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdShowReport}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window runat="server" Title="Chuyển lịch hẹn phỏng vấn" Resizable="false" Icon="Clock"
            Hidden="true" Padding="6" ID="wdChuyenLichHenPV" Width="350" Modal="true" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="frmPanelChuyenLichHenPV">
                    <Items>
                        <ext:DateField runat="server" LabelWidth="110" ID="df_NgayPhongVan" AnchorHorizontal="98%"
                            FieldLabel="Ngày phỏng vấn" Editable="false" TabIndex="40">
                        </ext:DateField>
                        <ext:TimeField ID="tf_GioPhongVan" runat="server" MinTime="9:00" MaxTime="18:00"
                            Increment="30" SelectedTime="09:00" Format="H:mm" FieldLabel="Giờ phỏng vấn"
                            AnchorHorizontal="98%" />
                        <ext:NumberField runat="server" ID="txt_VongPhongVan" MaxLength="4" FieldLabel="Vòng phỏng vấn"
                            TabIndex="3" AnchorHorizontal="98%">
                        </ext:NumberField>
                        <ext:NumberField runat="server" ID="txt_ThuTuPhongVan" FieldLabel="Thứ tự phỏng vấn"
                            LabelWidth="100" Width="50" TabIndex="99" MaxLength="4" Regex="/[\d]+/" />
                        <ext:TextArea runat="server" ID="txt_ghichu" FieldLabel="Ghi chú" AnchorHorizontal="98%"
                            TabIndex="38" Height="90" MaxLength="500">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btn_ChuyenLichHenPV" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler=" return KiemTraDuLieuLichHenPV(); #{wdChuyenLichHenPV}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btn_ChuyenLichHenPV_Click" After="ResetwdChuyenLichHenPV">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btn_Close" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChuyenLichHenPV}.hide(); ResetwdChuyenLichHenPV();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Hidden ID="hdfChuyen_LyDo" runat="server">
        </ext:Hidden>
        <ext:Window runat="server" Title="Chuyển ứng viên" Resizable="false" Icon="Group"
            Hidden="true" Constrain="true" Padding="6" ID="wdChuyenLyDo" Width="450" Modal="true"
            Layout="FormLayout" AutoHeight="true">
            <Items>
                <ext:FormPanel runat="server" Border="false" ID="FormPanel1">
                    <Items>
                        <ext:ComboBox runat="server" Editable="false" CtCls="requiredData" ID="cbx_Chuyen_LyDo"
                            LoadingText="Đang tải dữ liệu..." ItemSelector="div.list-item" FieldLabel="Lý do"
                            AnchorHorizontal="98%" DisplayField="Value" ValueField="ID">
                            <Store>
                                <ext:Store runat="server" ID="cbx_Chuyen_LyDo_Store" AutoLoad="false" OnRefreshData="cbx_Chuyen_LyDo_Store_OnRefreshData">
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
                            <Template ID="Template37" runat="server">
                                <Html>
                                    <tpl for=".">
						                            <div class="list-item"> 
                                                        {Value}
						                            </div>
					                            </tpl>
                                </Html>
                            </Template>
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <Focus Handler="#{cbx_Chuyen_LyDo_Store}.reload();" />
                                <Select Handler="this.triggers[0].show(); #{hdfChuyen_LyDo}.setValue(#{cbx_Chuyen_LyDo}.getValue());" />
                                <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfChuyen_LyDo.reset();s }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextArea runat="server" ID="txt_Chuyen_GhiChu" FieldLabel="Ghi chú" AnchorHorizontal="98%"
                            MaxLength="500">
                        </ext:TextArea>
                    </Items>
                </ext:FormPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnChuyenLyDo" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler=" return KiemTraDuLieuChuyenLyDo(); #{wdChuyenLyDo}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChuyenTiep_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="Button2" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdChuyenLyDo}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetwdChuyenLyDo();" />
            </Listeners>
        </ext:Window>
        <uc1:uscTuyenDung_HoSoUngVien ID="uscTuyenDung_HoSoUngVien1" runat="server" />
        <%--<ext:Window runat="server" ID="wdChooseUngVien" Padding="0" Hidden="true" Title="Chọn ứng viên"
            Constrain="true" Modal="true" Icon="Add" Width="680" Resizable="false" AutoHeight="true">
            <Items>
                <ext:ComboBox runat="server" Editable="false" ID="cbx_LyDo" FieldLabel="Lý do" Width="450" LabelWidth="50"
                    DisplayField="Value" ValueField="ID" >
                    <Store>
                        <ext:Store runat="server" ID="cbx_LyDo_Store" AutoLoad="false" OnRefreshData="cbx_LyDo_OnRefreshData">
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
                        <Focus Handler="if(cbx_LyDo.store.getCount()==0){
                                        cbx_LyDo_Store.reload();
                                        }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:GridPanel ID="GridPanel2" runat="server" StripeRows="true" Border="false" TrackMouseOver="true" AutoScroll="true" AnchorHorizontal="100%" Height="400" Region="Center" >                       
                    <Store>
                        <ext:Store ID="GridPanel2_Store" GroupField="VI_TRI" runat="server" OnRefreshData="GridPanel2_Store_OnRefreshData" AutoLoad ="true">
                            <Reader>
                                <ext:JsonReader>
                                    <Fields>
                                        <ext:RecordField Name="MA_UNG_VIEN" />
                                        <ext:RecordField Name="HO_TEN"/>
                                        <ext:RecordField Name="TUOI" />
                                        <ext:RecordField Name="DIEM" />                                            
                                        <ext:RecordField Name="DA_TRUNG_TUYEN" />
                                        <ext:RecordField Name="GIOI_TINH" />
                                        <ext:RecordField Name="LY_DO" />
                                        <ext:RecordField Name="VI_TRI" />
                                        <ext:RecordField Name="KINH_NGHIEM" />
                                        <ext:RecordField Name="GHI_CHU" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="MA_UNG_VIEN" Header="Mã ứng viên" Width="80" DataIndex="MA_UNG_VIEN" />
                            <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="250" DataIndex="HO_TEN" />
                            <ext:Column ColumnID="GIOI_TINH" Header="Giới tính" Width="80" DataIndex="GIOI_TINH">
                                <Renderer Fn="RenderGender" />
                            </ext:Column>
                            <ext:Column ColumnID="TUOI" Header="Tuổi" Width="50" DataIndex="TUOI" />
                            <ext:Column ColumnID="DIEM" Header="Điểm phỏng vấn" Width="90" DataIndex="DIEM" />
                            <ext:Column ColumnID="DA_TRUNG_TUYEN" Header="Đã trúng tuyển" Width="80" DataIndex="DA_TRUNG_TUYEN" >
                                <Renderer Fn="GetBooleanIcon" />
                            </ext:Column>                                
                            <ext:Column ColumnID="VI_TRI" Header="Vị trí ứng tuyển" DataIndex="VI_TRI">
                            </ext:Column> 
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                            <ext:CheckboxSelectionModel runat="server" ID="RowSelectionModel">
                            </ext:CheckboxSelectionModel>
                    </SelectionModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu" />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="10">
                            <Items>
                                <ext:Label ID="Label2" runat="server" Text="Page size:" />
                                <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                <ext:ComboBox ID="ComboBox3" runat="server" Width="80">
                                    <Items>
                                        <ext:ListItem Text="1" />
                                        <ext:ListItem Text="2" />
                                        <ext:ListItem Text="10" />
                                        <ext:ListItem Text="20" />
                                    </Items>
                                    <SelectedItem Value="10" />
                                    <Listeners>
                                        <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <View>
                        <ext:GroupingView ID="GroupingView2" runat="server" ForceFit="false" MarkDirty="false"
                            ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                            <HeaderRows>
                                <ext:HeaderRow>
                                    <Columns>
                                        <ext:HeaderColumn AutoWidthElement="false">
                                            <Component>

                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn AutoWidthElement="false" Cls="x-small-editor">
                                            <Component>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn>
                                            <Component>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn>
                                            <Component>
                                                <ext:ComboBox ID="ComboBox8" Width="80" Editable="false" runat="server">
                                                    <Items>
                                                        <ext:ListItem Text="Tất cả" />
                                                        <ext:ListItem Text="Nam" />
                                                        <ext:ListItem Text="Nữ" />
                                                    </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn AutoWidthElement="false">
                                            <Component>
                                                <ext:ComboBox ID="ComboBox9" Width="175" Editable="false" runat="server">
                                                    <Items>
                                                        <ext:ListItem Text="Tất cả" />
                                                    </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn AutoWidthElement="false">
                                            <Component>
                                                <ext:ComboBox ID="ComboBox10" Width="175" Editable="false" runat="server">
                                                    <Items>
                                                        <ext:ListItem Text="Tất cả" />
                                                    </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn AutoWidthElement="false">
                                            <Component>
                                                <ext:ComboBox ID="ComboBox11" Width="175" Editable="false" runat="server">
                                                    <Items>
                                                        <ext:ListItem Text="Tất cả" />
                                                    </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                        <ext:HeaderColumn AutoWidthElement="false">
                                            <Component>
                                                <ext:ComboBox ID="ComboBox12" Width="90" Editable="false" runat="server">
                                                    <Items>
                                                        <ext:ListItem Text="Tất cả" />
                                                    </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Component>
                                        </ext:HeaderColumn>
                                    </Columns>
                                </ext:HeaderRow>
                            </HeaderRows>                                                                                    
                        </ext:GroupingView>
                    </View>                              
                </ext:GridPanel>                           
            </Items>
            <Buttons>
                <ext:Button ID="btnTiepTucThem" runat="server" Text="Tiếp tục thêm" Icon="ArrowRight" ColumnWidth="0.2" Height="15">
                    <Listeners>
                        <Click Handler="wdChooseUngVien.hide();" />
                    </Listeners>
                </ext:Button>                                                                                                             
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ColumnWidth="0.1"  Height="15">
                    <Listeners>
                        <Click Handler="wdChooseUngVien.hide();" />
                    </Listeners>
                </ext:Button>   
            </Buttons>
        </ext:Window>--%>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" runat="server" StripeRows="true" Border="false" TrackMouseOver="true"
                            AnchorHorizontal="100%" Region="Center">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbar">
                                    <Items>
                                        <ext:Button ID="btnAdd" Text="Thêm mới" Icon="Add" runat="server">
                                            <%--<Menu>
                                                    <ext:Menu runat="server" ID="mnuAdd">
                                                        <Items>
                                                            <ext:MenuItem ID="mnuNhapMoi" runat="server" Text="Nhập mới ứng viên" Icon="Add">
                                                                <Listeners>
                                                                    <Click Handler="#{wdAddUngVien}.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuImport" runat="server" Icon="PageExcel" Text="Nhập từ tệp tin tuyển dụng">
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>--%>
                                            <Listeners>
                                                <Click Handler="#{wdAddUngVien}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" Text="Sửa" Icon="Pencil" runat="server" Disabled="true">
                                            <Listeners>
                                                <Click Handler=" if( CheckSelectedRecordPrint(GridPanel1,grpGridPanel1_Store)){setValueWdAddUngVien(RowSelectionModel3,1);#{wdAddUngVien}.show();} " />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" Text="Xóa" Icon="Delete" runat="server" Disabled="true">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <EventMask ShowMask="true" />
                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không!" Title="Cảnh báo" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnPrint" runat="server" Text="In hồ sơ cá nhân" Icon="Printer" Hidden="true">
                                            <Listeners>
                                                <%--<Click Handler="if( CheckSelectedRecordPrint(GridPanel1,grpGridPanel1_Store)){#{wdShowReport}.show();}" />--%>
                                                <Click Handler=" alert('Chức năng đang được hoàn thiện')" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnNext" Text="Chuyển tiếp" Icon="ArrowBranch" runat="server" Disabled="true">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem ID="btnStore" Text="Chuyển vào kho dự trữ" Icon="DatabaseYellow">
                                                            <Listeners>
                                                                <Click Handler="#{wdChuyenLyDo}.setTitle('Chuyển ứng viên vào kho dự trữ');#{wdChuyenLyDo}.show(); " />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnBlack" Text="Chuyển vào danh sách đen (Blacklist)" Icon="UserGray">
                                                            <Listeners>
                                                                <Click Handler="#{wdChuyenLyDo}.setTitle('Chuyển ứng viên vào danh sách đen');#{wdChuyenLyDo}.show(); " />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnList" Text="Chuyển vào danh sách ứng tuyển" Icon="Group">
                                                            <DirectEvents>
                                                                <Click OnEvent="btnChuyenTiep_Click">
                                                                    <ExtraParams>
                                                                        <ext:Parameter Name="type" Value="toList">
                                                                        </ext:Parameter>
                                                                    </ExtraParams>
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn chuyển vào Danh sách ứng tuyển không!"
                                                                        Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnLichHenPV" Hidden="true" Text="Chuyển vào lịch hẹn phỏng vấn"
                                                            Icon="Clock">
                                                            <Listeners>
                                                                <Click Handler="#{wdChuyenLichHenPV}.show(); " />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="btnDaTrungTuyen" Text="Chuyển vào danh sách ứng viên trúng tuyển"
                                                            Icon="MedalGold1">
                                                            <DirectEvents>
                                                                <Click OnEvent="btnChuyenTiep_Click">
                                                                    <ExtraParams>
                                                                        <ext:Parameter Name="type" Value="toDaTrungTuyen">
                                                                        </ext:Parameter>
                                                                    </ExtraParams>
                                                                    <EventMask ShowMask="true" />
                                                                    <Confirmation ConfirmRequest="true" Message="Bạn có chắc chắn muốn chuyển vào Danh sách ứng viên trúng tuyển không!"
                                                                        Title="Cảnh báo" />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="5">
                                            <Items>
                                                <ext:ComboBox runat="server" TypeAhead="false" EmptyText="Lọc theo đợt tuyển dụng"
                                                    DisplayField="TenKeHoach" ValueField="ID" LoadingText="Đang tìm kiếm..." AnchorHorizontal="100%"
                                                    PageSize="10" ItemSelector="div.search-item" MinChars="1" ID="cbx_dottuyendung"
                                                    Width="150" ListWidth="250">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="cbx_dottuyendung_Store" runat="server" AutoLoad="true">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="Handlers/LocTheoDotTuyenDungHandler.ashx" />
                                                            </Proxy>
                                                            <AutoLoadParams>
                                                                <ext:Parameter Name="Start" Value="={0}" />
                                                                <ext:Parameter Name="Limit" Value="={10}" />
                                                            </AutoLoadParams>
                                                            <Reader>
                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="TenKeHoach" />
                                                                        <ext:RecordField Name="NgayBatDau" />
                                                                        <ext:RecordField Name="NgayKetThuc" />
                                                                        <ext:RecordField Name="HanNopHoSo" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Template ID="Template3" runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                            <div class="search-item">
							                                        <h3>{TenKeHoach}</h3>                                               
                                                                    Ngày bắt đầu: {NgayBatDau:date("d/m/Y")}</br>
                                                                    Ngày kết thúc: {NgayKetThuc:date("d/m/Y")}</br> 
						                                            </div>
					                                            </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_dottuyendung_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{grpGridPanel1_Store}.reload();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();#{grpGridPanel1_Store}.reload(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container2" Layout="FormLayout" LabelWidth="35">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxMonth" Width="70" Editable="false" FieldLabel="Tháng"
                                                    SelectedIndex="0">
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
                                                        <Select Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:ToolbarSpacer ID="ToolbarSpacer6" runat="server" Width="5" />
                                        <ext:Container runat="server" ID="Container3" Layout="FormLayout" LabelWidth="35">
                                            <Items>
                                                <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Năm" Width="55">
                                                    <Listeners>
                                                        <Spin Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                                    </Listeners>
                                                </ext:SpinnerField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel"
                                            Hidden="false">
                                            <DirectEvents>
                                                <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:Button runat="server" Text="Tìm kiếm nâng cao" Hidden="true" Icon="MagnifierZoomIn">
                                            <Listeners>
                                                <Click Handler="wdAdvanceSearch.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập mã, tên hoặc CMND ứng viên.."
                                            ID="UngVienDuTru_txtSearchKey">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; #{grpGridPanel1_Store}.reload(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <%--<ext:TextField runat="server" ID="UngVienDuTru_txtSearchKey" Width="220" EmptyText="Nhập mã hoặc họ tên ứng viên..." />--%>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="grpGridPanel1_Store" GroupField="TEN_DOT_TUYEN_DUNG" AutoLoad="true"
                                    runat="server">
                                    <Listeners>
                                        <Load Handler="RowSelectionModel3.clearSelections();" />
                                    </Listeners>
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="Handlers/UngVienDuTruHandler.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={10}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="SearchKey" Value="UngVienDuTru_txtSearchKey.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="DotTuyenDung" Value="#{cbx_dottuyendung}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="blackorstore" Value="#{hdfType}.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="month" Value="cbxMonth.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="year" Value="spnYear.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_UNG_VIEN">
                                            <Fields>
                                                <ext:RecordField Name="MA_UNG_VIEN" />
                                                <ext:RecordField Name="ANH" />
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="GIOI_TINH" />
                                                <ext:RecordField Name="TUOI" />
                                                <ext:RecordField Name="NGAY_SINH" />
                                                <ext:RecordField Name="MA_TTHN" />
                                                <ext:RecordField Name="TEN_TTHN" />
                                                <ext:RecordField Name="NOI_SINH" />
                                                <ext:RecordField Name="MA_TINHTHANH" />
                                                <ext:RecordField Name="TEN_TINHTHANH" />
                                                <ext:RecordField Name="HKTT" />
                                                <ext:RecordField Name="DIA_CHI_LH" />
                                                <ext:RecordField Name="DI_DONG" />
                                                <ext:RecordField Name="DT_CO_DINH" />
                                                <ext:RecordField Name="MUC_LUONG_TOI_THIEU" />
                                                <ext:RecordField Name="MUC_LUONG_MONG_MUON" />
                                                <ext:RecordField Name="MA_QUOC_TICH" />
                                                <ext:RecordField Name="TEN_QUOC_TICH" />
                                                <ext:RecordField Name="MA_DAN_TOC" />
                                                <ext:RecordField Name="TEN_DAN_TOC" />
                                                <ext:RecordField Name="MA_TON_GIAO" />
                                                <ext:RecordField Name="TEN_TON_GIAO" />
                                                <ext:RecordField Name="EMAIL" />
                                                <ext:RecordField Name="MA_TT_SUCKHOE" />
                                                <ext:RecordField Name="TEN_TT_SUCKHOE" />
                                                <ext:RecordField Name="NHOM_MAU" />
                                                <ext:RecordField Name="TEN_NHOM_MAU" />
                                                <ext:RecordField Name="CHIEU_CAO" />
                                                <ext:RecordField Name="CAN_NANG" />
                                                <ext:RecordField Name="CMT" />
                                                <ext:RecordField Name="NGAY_CAP_CMT" />
                                                <ext:RecordField Name="NOI_CAP_CMT" />
                                                <ext:RecordField Name="MA_NOI_CAP_CMT" />
                                                <ext:RecordField Name="NGAY_COTHEDILAM" />
                                                <ext:RecordField Name="MA_TRINH_DO_HV" />
                                                <ext:RecordField Name="TEN_TRINH_DO_HV" />
                                                <ext:RecordField Name="MA_CHUYEN_NGANH" />
                                                <ext:RecordField Name="TEN_CHUYEN_NGANH" />
                                                <ext:RecordField Name="MA_TRUONG_DT" />
                                                <ext:RecordField Name="TEN_TRUONG_DT" />
                                                <ext:RecordField Name="MA_TRINH_DO_NN" />
                                                <ext:RecordField Name="TEN_TRINH_DO_NN" />
                                                <ext:RecordField Name="MA_TRINH_DO_TIN_HOC" />
                                                <ext:RecordField Name="TEN_TRINH_DO_TIN_HOC" />
                                                <ext:RecordField Name="MA_TRINH_DO_VH" />
                                                <ext:RecordField Name="TEN_TRINH_DO_VH" />
                                                <ext:RecordField Name="NGAY_NOP_HO_SO" />
                                                <ext:RecordField Name="ANH" />
                                                <ext:RecordField Name="MA_KHA_NANG" />
                                                <ext:RecordField Name="UU_DIEM" />
                                                <ext:RecordField Name="NHUOC_DIEM" />
                                                <ext:RecordField Name="SO_THICH" />
                                                <ext:RecordField Name="DIEM" />
                                                <ext:RecordField Name="DA_TRUNG_TUYEN" />
                                                <ext:RecordField Name="LY_DO" />
                                                <ext:RecordField Name="MA_LY_DO" />
                                                <ext:RecordField Name="VI_TRI" />
                                                <ext:RecordField Name="MA_VI_TRI" />
                                                <ext:RecordField Name="TEN_DOT_TUYEN_DUNG" />
                                                <ext:RecordField Name="MA_DOT_TUYEN_DUNG" />
                                                <ext:RecordField Name="KINH_NGHIEM" />
                                                <ext:RecordField Name="GHI_CHU" />
                                                <ext:RecordField Name="NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="DIA_CHI_NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="DIEN_THOAI_NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="EMAIL_NGUOI_LIEN_HE" />
                                                <ext:RecordField Name="QUAN_HE_VOI_UNG_VIEN" />
                                                <ext:RecordField Name="BLACK_OR_STORE" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                    <ext:Column ColumnID="MA_UNG_VIEN" Header="Mã ƯV" Width="60" DataIndex="MA_UNG_VIEN" />
                                    <ext:Column ColumnID="HO_TEN" Header="Họ tên" Width="120" DataIndex="HO_TEN" />
                                    <ext:Column ColumnID="GIOI_TINH" Header="Giới tính" Width="50" DataIndex="GIOI_TINH">
                                        <Renderer Fn="RenderGender" />
                                    </ext:Column>
                                    <ext:DateColumn ColumnID="NGAY_SINH" Header="Ngày sinh" Width="80" DataIndex="NGAY_SINH"
                                        Format="dd/MM/yyyy">
                                    </ext:DateColumn>
                                    <ext:Column ColumnID="DIEM" Header="Tổng điểm" Width="80" DataIndex="DIEM" Align="Right" />
                                    <ext:Column ColumnID="KINH_NGHIEM" Header="Kinh nghiệm" Width="100" DataIndex="KINH_NGHIEM"
                                        Align="Right" />
                                    <ext:TemplateColumn ColumnID="TEN_TRUONG_DT" Header="Trường đào tạo" Width="150"
                                        DataIndex="TEN_TRUONG_DT">
                                        <Template runat="server">
                                            <Html>
                                                    {TEN_TRUONG_DT}
<br />
                                                    <i>Chuyên ngành :{TEN_CHUYEN_NGANH}</i>
                                                </Html>
                                        </Template>
                                    </ext:TemplateColumn>
                                    <%--<ext:Column ColumnID="TEN_CHUYEN_NGANH" Header="Chuyên ngành" Width="110" DataIndex="TEN_CHUYEN_NGANH" />--%>
                                    <ext:Column ColumnID="TEN_TRINH_DO_HV" Header="Trình độ" Width="90" DataIndex="TEN_TRINH_DO_HV" />
                                    <ext:Column ColumnID="MUC_LUONG_MONG_MUON" Header="Mức lương mong muốn" Width="80"
                                        DataIndex="MUC_LUONG_MONG_MUON">
                                        <Renderer Fn="RenderVND0" />
                                    </ext:Column>
                                    <ext:TemplateColumn ColumnID="DI_DONG" Header="Thông tin liên hệ" Width="110" DataIndex="DI_DONG">
                                        <Template ID="Template2" runat="server">
                                            <Html>
                                                <p>{EMAIL}</p>
                                                <p>{DI_DONG}</p>
                                            </Html>
                                        </Template>
                                    </ext:TemplateColumn>
                                    <%--<ext:Column ColumnID="EMAIL" Header="Email" Width="110" DataIndex="EMAIL" />--%>
                                    <%--<ext:Column ColumnID="VI_TRI" Header="Vị trí tuyển dụng" Width="100" DataIndex="VI_TRI">
                                        </ext:Column>--%>
                                    <ext:Column ColumnID="LY_DO" Header="Lý do đưa vào kho dự trữ" Width="150" DataIndex="LY_DO">
                                    </ext:Column>
                                    <ext:Column ColumnID="GHI_CHU" Header="Ghi chú" Width="280" DataIndex="GHI_CHU">
                                    </ext:Column>
                                    <ext:Column ColumnID="TEN_DOT_TUYEN_DUNG" Header="Đợt tuyển dụng" Width="180" DataIndex="TEN_DOT_TUYEN_DUNG">
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel3" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="#{btnDelete}.enable();#{btnEdit}.enable(); #{btnNext}.enable(); #{btnPrint}.enable();
                                                #{hdfRecordID}.setValue(#{RowSelectionModel3}.getSelected().id);" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <Listeners>
                                <RowDblClick Handler="#{wdAddUngVien}.show();setValueWdAddUngVien(RowSelectionModel3,1); " />
                            </Listeners>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu" />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên một trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="2" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="100" />
                                            </Items>
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true">
                                    <HeaderRows>
                                        <%--                                             <ext:HeaderRow>
                                                <Columns>
                                                 <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false" Cls="x-small-editor">
                                                        <Component>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                        <Component>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                   <ext:HeaderColumn>
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox2" Width="80" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
                                                                    <ext:ListItem Text="Nam" />
                                                                    <ext:ListItem Text="Nữ" />
                                                                </Items>
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Listeners>
                                                                    <Select Handler="this.triggers[0].show();" />
                                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox4" Width="175" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
                                                                </Items>
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Listeners>
                                                                    <Select Handler="this.triggers[0].show();" />
                                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox5" Width="175" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
                                                                </Items>
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Listeners>
                                                                    <Select Handler="this.triggers[0].show();" />
                                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox6" Width="175" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
                                                                </Items>
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Listeners>
                                                                    <Select Handler="this.triggers[0].show();" />
                                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="ComboBox7" Width="90" Editable="false" runat="server">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" />
                                                                </Items>
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Listeners>
                                                                    <Select Handler="this.triggers[0].show();" />
                                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                </Columns>
                                            </ext:HeaderRow>--%>
                                    </HeaderRows>
                                </ext:GroupingView>
                            </View>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
