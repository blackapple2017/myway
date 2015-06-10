<%@ Control Language="C#" AutoEventWireup="true" CodeFile="uscTuyenDung_HoSoUngVien.ascx.cs" Inherits="Modules_TuyenDung_uscTuyenDung_HoSoUngVien" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/UploadImageWindow/ucUploadImageForm.ascx" TagName="ucUploadImageForm" TagPrefix="uc1" %>

<ext:Hidden runat="server" ID="hdfCommandType" Text="Edit" />
<ext:Hidden runat="server" ID="hdfRecordID" />
<ext:Hidden runat="server" ID="hdfType" />
<ext:Hidden runat="server" ID="hdfAnhDaiDien" />
<ext:Window runat="server" Title="Chọn ảnh" Resizable="false" Icon="ImageAdd" Hidden="true"
    Padding="6" ID="wdUploadImageWindow" Width="400" Modal="true" AutoHeight="true">
    <Items>
        <ext:FormPanel runat="server" Border="false" ID="frmPanelUploadImage">
            <Items>
                <ext:Hidden runat="server" Text="~/Modules/TuyenDung/AttachFile" ID="hdfImageFolder" />
                <ext:Hidden runat="server" ID="hdfUploadedImage" />
                <ext:FileUploadField runat="server" ID="fufUploadControl" AllowBlank="false" RegexText="Định dạng tệp tin không hợp lệ"
                    Regex="(http(s?):)|([/|.|\w|\s])*\.(?:jpg|gif|png|bmp|jpeg|JPG|PNG|GIF|BMP|JPEG)"
                    AnchorHorizontal="100%" FieldLabel="Chọn ảnh">
                    <Listeners>
                        <FileSelected Handler="if (#{frmPanelUploadImage}.getForm().isValid())
                                        {
                                            #{btnUpdateImage}.enable();    
                                        }else
                                        {
                                            alert('Định dạng file không hợp lệ, chương trình chỉ chấp nhận định dạng jpg, bmp, jpeg, gif, png!');
                                            #{btnUpdateImage}.disable();s
                                        } " />
                    </Listeners>
                </ext:FileUploadField>
            </Items>
        </ext:FormPanel>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnUpdateImage" Text="Đồng ý" Icon="Accept">
            <DirectEvents>
                <Click OnEvent="btnUpdateImage_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdUploadImageWindow}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{btnUpdateImage}.disable();" />
        <Hide Handler="" />
    </Listeners>
</ext:Window>
<ext:Window runat="server" ID="wdAddUngVien" Padding="6" Hidden="true" Title="Thông tin ứng viên"
    Constrain="true" Modal="true" Icon="Add" Width="870" Resizable="false" AutoHeight="true">
    <Items>
        <ext:TabPanel ID="Tab" runat="server" AutoHeight="true" Border="false" DeferredRender="false">
            <Items>
                <ext:Panel ID="thongtinchung" runat="server" Height="325" Title="Thông tin cá nhân" TabIndex="0"
                    Padding="6">
                    <Items>
                        <ext:FieldSet ID="fs" runat="server" Title="Thông tin cá nhân" Border="true">
                            <Items>
                                <ext:Container ID="containungvien" runat="server" Height="155" Layout="ColumnLayout">
                                    <Items>
                                        <ext:Container ID="Container1" runat="server" Layout="FormLayout" ColumnWidth="0.15">
                                            <Items>
                                                <ext:ImageButton runat="server" ID="anhdaidien" OverImageUrl="../NhanSu/ImageNhanSu/No_person.jpg"
                                                    ImageUrl="../NhanSu/ImageNhanSu/No_person.jpg" AnchorHorizontal="98%" Height="150"
                                                    Margins="5">
                                                    <Listeners>
                                                        <Click Handler="#{wdUploadImageWindow}.show();" />
                                                    </Listeners>
                                                </ext:ImageButton>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container15" runat="server" Layout="FormLayout" ColumnWidth="0.45">
                                            <Items>
                                                <ext:TextField ID="txt_tenungvien" runat="server" CtCls="requiredData" FieldLabel="<%$ Resources:HOSO, staff_name_required%>"
                                                    AllowBlank="false" TabIndex="1" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="<%$ Resources:HOSO, maximum_characters%>">
                                                    <Listeners>
                                                        <Blur Handler="ChuanHoaTenHSUV();" />
                                                    </Listeners>
                                                    <ToolTips>
                                                        <ext:ToolTip ID="ToolTip2" runat="server" Title="<%$ Resources:HOSO, guide%>" Html="Phần mềm sẽ tự động chuẩn hóa họ và tên của bạn. Ví dụ: bạn nhập nguyễn văn huy, kết quả trả về Nguyễn Văn Huy." />
                                                    </ToolTips>
                                                </ext:TextField>
                                                <ext:ComboBox runat="server" ID="cbx_gioitinh" Editable="false" SelectedIndex="0"
                                                    FieldLabel="Giới tính" TabIndex="2" AnchorHorizontal="98%">
                                                    <Items>
                                                        <ext:ListItem Text="Nam" Value="M" />
                                                        <ext:ListItem Text="Nữ" Value="F" />
                                                    </Items>
                                                </ext:ComboBox>
                                                <ext:DateField runat="server" ID="df_ngaysinh" CtCls="requiredData" FieldLabel="<%$ Resources:HOSO, staff_birthday_required%>" Editable="true"
                                                    AnchorHorizontal="98%" TabIndex="3" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/"
                                                    RegexText="Định dạng ngày sinh không đúng" Vtype="daterange">
                                                </ext:DateField>
                                                <ext:TextField ID="txt_noisinh" runat="server" FieldLabel="Nơi sinh<span style='color:red;'>*</span>" TabIndex="4" CtCls="requiredData"
                                                    AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự" />
                                                <ext:Hidden runat="server" ID="hdfCongViec" />
                                                <ext:ComboBox runat="server" ID="cbx_congviec" FieldLabel="Công việc<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%" ListWidth="250"
                                                    TabIndex="5" Editable="true" ItemSelector="div.list-item" PageSize="15" LoadingText="<%$ Resources:HOSO, Loading%>"
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
                                                <ext:Hidden runat="server" ID="hdfDotTuyenDung" />
                                                <ext:ComboBox runat="server" ID="cbx_dottuyendung" FieldLabel="Đợt tuyển dụng<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" DisplayField="TenKeHoach" MinChars="1" ValueField="ID" AnchorHorizontal="98%" ListWidth="250"
                                                    TabIndex="6" Editable="true" ItemSelector="div.list-item" PageSize="15" LoadingText="<%$ Resources:HOSO, Loading%>"
                                                    EmptyText="Gõ để tìm kiếm">
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
						                                        <div class="list-item">
							                                    <h3>{TenKeHoach}</h3>                                               
                                                                Ngày bắt đầu: {NgayBatDau:date("d/m/Y")}</br>
                                                                Ngày kết thúc: {NgayKetThuc:date("d/m/Y")}</br> 
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_dottuyendung_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show();#{hdfDotTuyenDung}.setValue(#{cbx_dottuyendung}.getValue());" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container16" runat="server" Layout="FormLayout" ColumnWidth="0.4">
                                            <Items>
                                                <ext:TextField ID="txt_hokhau" runat="server" FieldLabel="Hộ khẩu" TabIndex="7" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự" />
                                                <ext:Hidden runat="server" ID="hdfTinhTrangHN" />
                                                <ext:ComboBox ID="cbx_tt_honnhan" runat="server" FieldLabel="T/T hôn nhân" DisplayField="TEN_TT_HN"
                                                    ValueField="MA_TT_HN" AnchorHorizontal="98%" TabIndex="8" Editable="false">
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
                                                <ext:Hidden runat="server" ID="hdfTinhTrangSK" />
                                                <ext:ComboBox ID="cbx_tt_suckhoe" runat="server" FieldLabel="T/T sức khỏe" DisplayField="TEN_TT_SUCKHOE"
                                                    ValueField="MA_TT_SUCKHOE" Editable="false" AnchorHorizontal="98%" TabIndex="9">
                                                    <Store>
                                                        <ext:Store ID="cbx_tt_suckhoestore" runat="server" AutoLoad="false" OnRefreshData="cbx_tt_suckhoestore_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_TT_SUCKHOE">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_TT_SUCKHOE" />
                                                                        <ext:RecordField Name="TEN_TT_SUCKHOE" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_tt_suckhoestore}.reload();" />
                                                        <Select Handler="this.triggers[0].show();#{hdfTinhTrangSK}.setValue(#{cbx_tt_suckhoe}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:Hidden runat="server" ID="hdfNhomMau" />
                                                <ext:ComboBox ID="cbNhommau" runat="server" FieldLabel="Nhóm máu" AllowBlank="true"
                                                    TabIndex="10" Editable="false" AnchorHorizontal="98%" MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                    <Items>
                                                        <ext:ListItem Text="Nhóm A" Value="A" />
                                                        <ext:ListItem Text="Nhóm B" Value="B" />
                                                        <ext:ListItem Text="Nhóm AB" Value="AB" />
                                                        <ext:ListItem Text="Nhóm O" Value="O" />
                                                    </Items>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();#{hdfNhomMau}.setValue(#{cbNhommau}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:CompositeField ID="CompositeField7" runat="server" AnchorHorizontal="100%" FieldLabel="Cao/Cân nặng">
                                                    <Items>
                                                        <ext:NumberField runat="server" EmptyText="Cao" ID="txt_chieucao" Width="50" TabIndex="11" MaxLength="3" Regex="/[\d]+/" />
                                                        <ext:DisplayField ID="DisplayField11" runat="server" Text="cm  /" />
                                                        <ext:NumberField runat="server" ID="txt_cannang" EmptyText="Nặng" Width="50" TabIndex="12" MaxLength="3" Regex="/[\d]+/" />
                                                        <ext:DisplayField ID="DisplayField12" runat="server" Text="Kg" />
                                                    </Items>
                                                </ext:CompositeField>
                                                <ext:Hidden runat="server" ID="hdfLyDo" />
                                                <ext:ComboBox runat="server" Editable="false" ID="cbx_LyDo" FieldLabel="Lý do" AnchorHorizontal="98%" LabelWidth="50" DisplayField="Value" ValueField="ID" TabIndex="13" ListWidth="350">
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
                        </ext:FieldSet>
                        <ext:Container ID="Container12" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%">
                            <Items>
                                <ext:Container ID="Container13" runat="server" ColumnWidth="0.7" Layout="FormLayout" Height="210">
                                    <Items>
                                        <ext:FieldSet ID="FieldSet1" runat="server" AnchorHorizontal="98%" Title="Thông tin liên hệ" Border="true">
                                            <Items>
                                                <ext:Container ID="Container17" runat="server" Height="210" Layout="ColumnLayout">
                                                    <Items>
                                                        <ext:Container ID="Container20" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                                            <Items>
                                                                <ext:Hidden runat="server" ID="hdfQuocTich" />
                                                                <ext:ComboBox runat="server" ID="cbx_quoctich" FieldLabel="Quốc tịch<span style='color:red;'>*</span>"
                                                                    CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%" ListWidth="200"
                                                                    TabIndex="14" Editable="true" ItemSelector="div.list-item" PageSize="15" LoadingText="<%$ Resources:HOSO, Loading%>"
                                                                    EmptyText="Gõ để tìm kiếm">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Template ID="Template6" runat="server">
                                                                        <Html>
                                                                            <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                        </Html>
                                                                    </Template>
                                                                    <Store>
                                                                        <ext:Store ID="cbx_quoctich_Store" runat="server" AutoLoad="false">
                                                                            <Proxy>
                                                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                            </Proxy>
                                                                            <BaseParams>
                                                                                <ext:Parameter Name="table" Value="DM_NUOC" Mode="Value" />
                                                                                <ext:Parameter Name="ma" Value="MA_NUOC" Mode="Value" />
                                                                                <ext:Parameter Name="ten" Value="TEN_NUOC" Mode="Value" />
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
                                                                        <Focus Handler="#{cbx_quoctich_Store}.reload();" />
                                                                        <Select Handler="this.triggers[0].show();#{hdfQuocTich}.setValue(#{cbx_quoctich}.getValue());#{cbx_tinhthanh_Store}.reload();#{cbx_tinhthanh}.enable(); " />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="hdfTinhThanh" />
                                                                <ext:ComboBox runat="server" ID="cbx_tinhthanh" FieldLabel="Tỉnh thành" DisplayField="TEN" MinChars="1" EmptyText="Gõ để tìm kiếm" ValueField="MA" AnchorHorizontal="98%" TabIndex="15" Editable="true" ListWidth="250" ItemSelector="div.list-item">
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
                                                                        <Focus Handler="if (#{cbx_quoctich}.getValue() == '') 
                                                                            {
                                                                                #{cbx_tinhthanh_Store}.removeAll(); 
                                                                                alert('Bạn phải chọn quốc tịch trước');
                                                                            } 
                                                                            else 
                                                                            #{cbx_tinhthanh_Store}.reload();" />
                                                                        <Select Handler="this.triggers[0].show();
                                                                            #{hdfTinhThanh}.setValue(#{cbx_tinhthanh}.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) 
                                                                            { this.clearValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="hdfDanToc" />
                                                                <ext:ComboBox runat="server" ID="cbx_dantoc" FieldLabel="Dân tộc<span style='color:red;'>*</span>"
                                                                    CtCls="requiredData" DisplayField="TEN" MinChars="1" ValueField="MA" AnchorHorizontal="98%" EmptyText="Gõ để tìm kiếm" TabIndex="16" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Template ID="Template7" runat="server">
                                                                        <Html>
                                                                            <tpl for=".">
						                                        <div class="list-item"> 
							                                        {TEN}
						                                        </div>
					                                        </tpl>
                                                                        </Html>
                                                                    </Template>
                                                                    <Store>
                                                                        <ext:Store runat="server" ID="cbx_dantoc_Store" AutoLoad="false">
                                                                            <Proxy>
                                                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                            </Proxy>
                                                                            <BaseParams>
                                                                                <ext:Parameter Name="table" Value="DM_DANTOC" Mode="Value" />
                                                                                <ext:Parameter Name="ma" Value="MA_DANTOC" Mode="Value" />
                                                                                <ext:Parameter Name="ten" Value="TEN_DANTOC" Mode="Value" />
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
                                                                        <Focus Handler="#{cbx_dantoc_Store}.reload();" />
                                                                        <Select Handler="this.triggers[0].show();#{hdfDanToc}.setValue(#{cbx_dantoc}.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Hidden runat="server" ID="hdfTonGiao" />
                                                                <ext:ComboBox runat="server" ID="cbx_tongiao" MinChars="1" FieldLabel="Tôn giáo" DisplayField="TEN" ValueField="MA" EmptyText="Gõ để tìm kiếm" AnchorHorizontal="98%" TabIndex="17" Editable="true" ItemSelector="div.list-item">
                                                                    <Triggers>
                                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                    </Triggers>
                                                                    <Template ID="Template8" runat="server">
                                                                        <Html>
                                                                            <tpl for=".">
						                                                <div class="list-item"> 
							                                                {TEN}
						                                                </div>
					                                                </tpl>
                                                                        </Html>
                                                                    </Template>
                                                                    <Store>
                                                                        <ext:Store runat="server" ID="cbx_tongiao_Store" AutoLoad="false">
                                                                            <Proxy>
                                                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                                            </Proxy>
                                                                            <BaseParams>
                                                                                <ext:Parameter Name="table" Value="DM_TONGIAO" Mode="Value" />
                                                                                <ext:Parameter Name="ma" Value="MA_TONGIAO" Mode="Value" />
                                                                                <ext:Parameter Name="ten" Value="TEN_TONGIAO" Mode="Value" />
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
                                                                        <Focus Handler=" #{cbx_tongiao_Store}.reload();" />
                                                                        <Select Handler="this.triggers[0].show();#{hdfTonGiao}.setValue(#{cbx_tongiao}.getValue());" />
                                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                            </Items>
                                                        </ext:Container>
                                                        <ext:Container ID="Container3" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                                            <Items>
                                                                <ext:TextField ID="txt_didong" runat="server" MaskRe="/[0-9]/" FieldLabel="Di động"
                                                                    TabIndex="18" AnchorHorizontal="98%" MaxLength="20" MaxLengthText="Bạn chỉ được nhập tối đa 20 ký tự">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_dienthoaicodinh" MaskRe="/[0-9]/" runat="server" FieldLabel="ĐT nhà"
                                                                    TabIndex="19" AnchorHorizontal="98%" MaxLength="20" MaxLengthText="Bạn chỉ được nhập tối đa 20 ký tự">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_email" runat="server" FieldLabel="Email" TabIndex="20" AnchorHorizontal="98%"
                                                                    MaxLength="50" MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                                                    RegexText="Định dạng email không đúng">
                                                                </ext:TextField>
                                                                <ext:TextField ID="txt_diachilhe" runat="server" FieldLabel="Chỗ ở hiện nay" TabIndex="21"
                                                                    AnchorHorizontal="98%" MaxLength="100" MaxLengthText="Bạn chỉ được nhập tối đa 100 ký tự">
                                                                </ext:TextField>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:FieldSet>
                                    </Items>
                                </ext:Container>
                                <ext:FieldSet ID="FieldSet4" runat="server" Layout="ColumnLayout" Title="Chứng minh thư nhân dân"
                                    AutoHeight="true" AnchorHorizontal="99%" ColumnWidth="0.3">
                                    <Items>
                                        <ext:Container ID="Container2" runat="server" Layout="FormLayout" ColumnWidth="0.3"
                                            Height="100">
                                            <Items>
                                                <ext:TextField ID="txt_socmnd" runat="server" MaskRe="/[0-9\.]/" FieldLabel="Số CMND<span style='color:red;'>*</span>"
                                                    CtCls="requiredData" AllowBlank="true" TabIndex="22" AnchorHorizontal="98%" MaxLength="12"
                                                    MaxLengthText="Bạn chỉ được nhập tối đa 50 ký tự">
                                                </ext:TextField> 
                                                <ext:DateField runat="server" ID="df_ngaycapcmnd" Editable="true"  FieldLabel="Ngày cấp CMND" AnchorHorizontal="98%" TabIndex="23" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <KeyUp Fn="onKeyUp" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:DateField>
                                                <ext:Hidden runat="server" ID="hdfNoiCapCMND" />
                                                <ext:ComboBox runat="server" ID="cbx_noicapcmnd" FieldLabel="Nơi cấp CMND" DisplayField="TEN" MinChars="1" EmptyText="Gõ để tìm kiếm" ValueField="MA" AnchorHorizontal="98%" ListWidth="250" TabIndex="24" Editable="true" ItemSelector="div.list-item">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Template ID="Template4" runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                                        <div class="list-item"> 
							                                        {TEN}
						                                        </div>
					                                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbx_noicapcmnd_Store" AutoLoad="false">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                                                            </Proxy>
                                                            <BaseParams>
                                                                <ext:Parameter Name="table" Value="DM_NOICAP_CMND" Mode="Value" />
                                                                <ext:Parameter Name="ma" Value="MA_NOICAP_CMND" Mode="Value" />
                                                                <ext:Parameter Name="ten" Value="TEN_NOICAP_CMND" Mode="Value" />
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
                                                        <Focus Handler="#{cbx_noicapcmnd_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{hdfNoiCapCMND}.setValue(#{cbx_noicapcmnd}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel3" runat="server" Height="325" Padding="6" Title="Thông tin vị trí ứng tuyển" TabIndex="1">
                    <Items>
                        <ext:FieldSet ID="FieldSet2" runat="server" Title="Khả năng ứng viên" Border="true">
                            <Items>
                                <ext:Container ID="Container21" runat="server" Height="120" Layout="ColumnLayout">
                                    <Items>
                                        <ext:Container ID="Container28" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:Hidden runat="server" ID="hdfTrinhDoVanHoa" />
                                                <ext:ComboBox ID="cbx_trinhdovanhoa" runat="server" FieldLabel="Trình độ văn hóa"
                                                    DisplayField="TEN_TD_VANHOA" ValueField="MA_TD_VANHOA" Editable="false" AnchorHorizontal="98%" TabIndex="25">
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbx_trinhdovanhoastore" AutoLoad="false" OnRefreshData="cbx_trinhdovanhoastore_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_TD_VANHOA">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_TD_VANHOA" />
                                                                        <ext:RecordField Name="TEN_TD_VANHOA" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_trinhdovanhoastore}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{hdfTrinhDoVanHoa}.setValue(#{cbx_trinhdovanhoa}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:Hidden runat="server" ID="hdfTruongDaoTao" />
                                                <ext:ComboBox AnchorHorizontal="98%" ValueField="MA" HideTrigger="false" DisplayField="TEN"
                                                    runat="server" FieldLabel="Trường đào tạo" PageSize="15" ItemSelector="div.search-item" ListWidth="250"
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
                                                    FieldLabel="Chuyên ngành" PageSize="15" HideTrigger="false" ItemSelector="div.search-item" ListWidth="250"
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
                                                <ext:Hidden runat="server" ID="hdfTrinhDo" />
                                                <ext:ComboBox runat="server" ID="cbx_trinhdo" FieldLabel="Trình độ học vấn" DisplayField="TEN_TRINHDO"
                                                    ValueField="MA_TRINHDO" AnchorHorizontal="98%" Editable="false" TabIndex="28">
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbx_trinhdo_Store" AutoLoad="false" OnRefreshData="cbx_trinhdo_Store_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_TRINHDO">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_TRINHDO" />
                                                                        <ext:RecordField Name="TEN_TRINHDO" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_trinhdo_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{hdfTrinhDo}.setValue(#{cbx_trinhdo}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container23" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:Hidden runat="server" ID="hdfTrinhDoTinHoc" />
                                                <ext:ComboBox ID="cbx_trinhdotinhoc" runat="server" Editable="false" FieldLabel="Tin học" DisplayField="TEN_TINHOC"
                                                    ValueField="MA_TINHOC" AnchorHorizontal="98%" TabIndex="29">
                                                    <Store>
                                                        <ext:Store ID="cbx_trinhdotinhocstore" runat="server" AutoLoad="false" OnRefreshData="cbx_trinhdotinhocstore_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_TINHOC">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_TINHOC" />
                                                                        <ext:RecordField Name="TEN_TINHOC" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_trinhdotinhocstore}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{hdfTrinhDoTinHoc}.setValue(#{cbx_trinhdotinhoc}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:Hidden runat="server" ID="hdfTrinhDoNgoaiNgu" />
                                                <ext:ComboBox ID="cbx_trinhdongoaingu" runat="server" Editable="false" FieldLabel="Ngoại ngữ" DisplayField="TEN_NGOAINGU"
                                                    ValueField="MA_NGOAINGU" AnchorHorizontal="98%" TabIndex="30">
                                                    <Store>
                                                        <ext:Store ID="cbx_trinhdongoaingustore" runat="server" AutoLoad="false" OnRefreshData="cbx_trinhdongoaingustore_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_NGOAINGU">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_NGOAINGU" />
                                                                        <ext:RecordField Name="TEN_NGOAINGU" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Focus Handler="#{cbx_trinhdongoaingustore}.reload();" />
                                                        <Select Handler="this.triggers[0].show(); #{hdfTrinhDoNgoaiNgu}.setValue(#{cbx_trinhdongoaingu}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <ext:TextField ID="txt_mucluongtoithieu" MaskRe="/[0-9\.]/" runat="server" FieldLabel="Lương tối thiểu"
                                                    TabIndex="31" AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                </ext:TextField>
                                                <ext:TextField ID="txt_mucluongmongmuon" MaskRe="/[0-9\.]/" runat="server" FieldLabel="Lương mong muốn"
                                                    TabIndex="32" AnchorHorizontal="98%" MaxLength="15" MaxLengthText="Bạn chỉ được nhập tối đa 15 ký tự">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container22" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField ID="txt_kinhnghiem" runat="server" EmptyText="Số năm kinh ngiệm" FieldLabel="Kinh nghiệm"
                                                    TabIndex="33" AnchorHorizontal="98%" MaxLength="4" MaskRe="/[0-9\.]/">
                                                </ext:TextField>
                                                <ext:Hidden ID="hdfKhaNang" runat="server"></ext:Hidden>
                                                <ext:MultiCombo ID="mcb_KhaNang" runat="server" AnchorHorizontal="98%" FieldLabel="Khả năng" TabIndex="34">  
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show(); #{hdfKhaNang}.setValue(#{mcb_KhaNang}.getValue());" />
                                                        <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:MultiCombo>
                                                <ext:DateField runat="server" ID="df_ngaynophs" Editable="true"  FieldLabel="Ngày nộp hồ sơ" AnchorHorizontal="98%" TabIndex="23" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                </ext:DateField>
                                                <ext:DateField runat="server" ID="df_ngaycothedilam" Editable="true"  FieldLabel="Ngày có thể đi làm" AnchorHorizontal="98%" TabIndex="23" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                                </ext:DateField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                        <ext:Container ID="Container4" runat="server" Layout="ColumnLayout" AnchorHorizontal="100%">
                            <Items>
                                <ext:Container ID="Container5" runat="server" ColumnWidth="0.65" Layout="FormLayout" Height="210">
                                    <Items>
                                        <ext:FieldSet ID="FieldSet3" runat="server" Title="Thông tin khác" AnchorHorizontal="98%" Border="true">
                                            <Items>
                                                <ext:Container ID="Container24" runat="server" Height="210" Layout="ColumnLayout">
                                                    <Items>
                                                        <ext:Container ID="Container25" runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                                            <Items>
                                                                <ext:TextArea runat="server" ID="txt_sothich" FieldLabel="Sở thích" EmptyText="Sở thích ứng viên"
                                                                    AnchorHorizontal="98%" TabIndex="37" Height="30" MaxLength="500">
                                                                </ext:TextArea>
                                                                <ext:TextArea runat="server" ID="txt_ghichu" FieldLabel="Ghi chú" EmptyText="Các vấn đề khác về ứng viên"
                                                                    AnchorHorizontal="98%" TabIndex="38" Height="30" MaxLength="500">
                                                                </ext:TextArea>
                                                                <ext:TextArea runat="server" ID="txt_uudiem" FieldLabel="Ưu điểm" EmptyText="Ưu điểm của ứng viên"
                                                                    AnchorHorizontal="98%" TabIndex="39" Height="30" MaxLength="500">
                                                                </ext:TextArea>
                                                                <ext:TextArea runat="server" ID="txt_nhuocdiem" FieldLabel="Nhược điểm" EmptyText="Nhược điểm ứng viên"
                                                                    AnchorHorizontal="98%" TabIndex="40" Height="30" MaxLength="500">
                                                                </ext:TextArea>
                                                            </Items>
                                                        </ext:Container>
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:FieldSet>
                                    </Items>
                                </ext:Container>
                                <ext:FieldSet runat="server" ID="FieldSet6" Title="Liên hệ trong trường hợp khẩn cấp"
                                    Layout="FormLayout" AnchorHorizontal="100%" ColumnWidth="0.35">
                                    <Items>
                                        <ext:TextField ID="txt_nguoilienhe" CtCls="requiredDataWG" runat="server" FieldLabel="Người liên hệ"
                                            AnchorHorizontal="100%" AllowBlank="true" TabIndex="41" MaxLength="50" EmptyText="Họ và tên người liên hệ">
                                        </ext:TextField>
                                        <ext:TextField ID="txt_sdtnguoilh" CtCls="requiredDataWG" MaskRe="/[0-9]/" runat="server"
                                            FieldLabel="SDT người LH" EmptyText="SĐT người liên hệ" AnchorHorizontal="100%"
                                            TabIndex="42" MaxLength="20">
                                        </ext:TextField>
                                        <ext:TextField ID="txt_MoiQH" CtCls="requiredDataWG" runat="server" FieldLabel="Quan hệ với CB"
                                            EmptyText="Ví dụ: Bố, Mẹ, ..." AnchorHorizontal="100%" TabIndex="43" MaxLength="100">
                                        </ext:TextField>
                                        <ext:TextField ID="txt_emailnguoilh" CtCls="requiredDataWG" runat="server" FieldLabel="Email"
                                            EmptyText="Email người liên hệ" AnchorHorizontal="100%" MaxLength="100" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                            RegexText="Định dạng email không đúng" TabIndex="44">
                                        </ext:TextField>
                                        <ext:TextArea ID="txt_diachinguoilienhe" CtCls="requiredDataWG" runat="server" FieldLabel="Địa chỉ"
                                            AnchorHorizontal="100%" Height="25" MaxLength="1000" TabIndex="45">
                                        </ext:TextArea>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:TabPanel>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btn_UpdateUngVien" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler=" return KiemTraDuLieuDauVao();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btn_UpdateUngVien_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btn_EditUngVien" Hidden="true" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler=" return KiemTraDuLieuDauVao(); " />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btn_UpdateUngVien_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Command" Value="Edit">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btn_UpdateandCloseUngVien" Text="Cập nhật & Đóng lại"
            Icon="Disk">
            <Listeners>
                <Click Handler=" return KiemTraDuLieuDauVao(); " />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btn_UpdateUngVien_Click">
                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btn_Close" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdAddUngVien}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="ResetWdAddUngVien();" />
    </Listeners>
</ext:Window>
