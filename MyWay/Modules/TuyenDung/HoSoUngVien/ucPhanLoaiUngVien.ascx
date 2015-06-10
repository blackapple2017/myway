<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucPhanLoaiUngVien.ascx.cs"
    Inherits="Modules_TuyenDung_HoSoUngVien_ucPhanLoaiUngVien" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<ext:Store ID="cbxTrangThaiUngVien_Store" runat="server" AutoLoad="false" OnRefreshData="cbxTrangThaiUngVien_Store_OnRefreshData">
    <Reader>
        <ext:JsonReader IDProperty="ID>">
            <Fields>
                <ext:RecordField Name="ID">
                </ext:RecordField>
                <ext:RecordField Name="Value">
                </ext:RecordField>
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Window runat="server" Layout="FormLayout" ID="wdPhanLoaiUngVien" Hidden="true"
    Icon="UserGo" EnableViewState="false" Modal="true" Constrain="true" Resizable="false"
    Width="800" AutoHeight="true" Title="Phân loại ứng viên" Padding="6">
    <Items>

        <ext:Panel ID="WizardPanel" Border="false" AnchorHorizontal="100%" runat="server"
            Height="280" Layout="card" ActiveIndex="0">
            <Items>
                <ext:Panel ID="Panel1" runat="server"
                    Border="false" Header="false">
                    <Items>
                        <ext:FieldSet runat="server" ID="fs_ChonDotTuyenDung" Title="Đợt tuyển dụng" AnchorHorizontal="100%" Layout="HBoxLayout">
                            <Items>
                                <ext:ComboBox runat="server" ID="ddfChonDotTuyenDung" FieldLabel="Chọn đợt tuyển dụng" LabelWidth="123" AnchorHorizontal="100%" Width="750">
                                </ext:ComboBox>
                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet runat="server" ID="fs_yeucautrinhdo" Title="Yêu cầu trình độ" AnchorHorizontal="100%">
                            <Items>
                                <ext:Container ID="Container18" runat="server" Layout="Column" Height="127">
                                    <Items>
                                        <ext:Container ID="Container19" Height="150" runat="server" Layout="Form" ColumnWidth=".33"
                                            LabelWidth="0">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxTrinhDo" FieldLabel="Trình độ" DisplayField="TEN_TRINHDO"
                                                    ValueField="MA_TRINHDO" Width="130" TabIndex="1" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbxTrinhDo_Store" AutoLoad="False" OnRefreshData="cbxTrinhDo_Store_OnRefreshData">
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
                                                    <Listeners>
                                                        <Expand Handler="if(#{cbxTrinhDo}.store.getCount()==0) #{cbxTrinhDo_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxChuyenNganh" FieldLabel="Chuyên ngành" DisplayField="TEN_CHUYENNGANH"
                                                    ValueField="MA_CHUYENNGANH" Width="130" TabIndex="2" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbxChuyenNganh_Store" AutoLoad="False" OnRefreshData="cbxChuyenNganh_Store_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_CHUYENNGANH">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_CHUYENNGANH" />
                                                                        <ext:RecordField Name="TEN_CHUYENNGANH" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Listeners>
                                                        <Expand Handler="if(#{cbxChuyenNganh}.store.getCount()==0) #{cbxChuyenNganh_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxXepLoai" FieldLabel="Xếp loại" DisplayField="TEN_XEPLOAI"
                                                    ValueField="MA_XEPLOAI" Width="130" TabIndex="3" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbxXepLoai_Store" AutoLoad="False" OnRefreshData="cbxXepLoai_Store_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_XEPLOAI">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_XEPLOAI" />
                                                                        <ext:RecordField Name="TEN_XEPLOAI" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Listeners>
                                                        <Expand Handler="if(#{cbxXepLoai}.store.getCount()==0) #{cbxXepLoai_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbxTDNgoaiNgu" FieldLabel="TĐ Ngoại ngữ" DisplayField="TEN_NGOAINGU"
                                                    ValueField="MA_NGOAINGU" Width="130" TabIndex="4" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbxTDNgoaiNgu_Store" AutoLoad="False" OnRefreshData="cbxTDNgoaiNgu_Store_OnRefreshData">
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
                                                    <Listeners>
                                                        <Expand Handler="if(#{cbxTDNgoaiNgu}.store.getCount()==0) #{cbxTDNgoaiNgu_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                            <Items>
                                                <ext:ComboBox ID="cbx_gioitinh" Editable="false" FieldLabel="Giới tính" runat="server"
                                                    Width="130" TabIndex="5" SelectedIndex="0">
                                                    <Items>
                                                        <ext:ListItem Text="Không yêu cầu" Value="Không yêu cầu" />
                                                        <ext:ListItem Text="Nam" Value="Nam" />
                                                        <ext:ListItem Text="Nữ" Value="Nữ" />
                                                    </Items>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container20" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".33"
                                            LabelWidth="100">
                                            <Items>
                                                <ext:Checkbox ID="chk_tdkhananglanhdao" runat="server" BoxLabel="Khả năng lãnh đạo"
                                                    TabIndex="6">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="chk_tdsansangcongtac" runat="server" BoxLabel="Sẵn sàng đi công tác"
                                                    TabIndex="7">
                                                </ext:Checkbox>
                                                <ext:NumberField ID="txt_tdkinhnghiem" runat="server" FieldLabel="Kinh nghiệm" AnchorHorizontal="95%"
                                                    EmptyText="0" TabIndex="8" MaxLength="3" />
                                                <ext:NumberField ID="txt_tdtuoitu" runat="server" FieldLabel="Tuổi từ" AnchorHorizontal="95%"
                                                    EmptyText="0" TabIndex="9" MinValue="0" MaxValue="100" />
                                                <ext:NumberField ID="txttddentuoi" runat="server" FieldLabel="Đến tuổi" AnchorHorizontal="95%"
                                                    EmptyText="0" TabIndex="10" MinValue="0" MaxValue="100">
                                                    <Listeners>
                                                        <Blur Handler="if((#{txt_tdtuoitu}.getValue() * 1) > (#{txttddentuoi}.getValue() * 1)){Ext.Msg.alert('Cảnh báo','Bạn phải nhập từ tuổi < đến tuổi')}" />
                                                    </Listeners>
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container1" runat="server" LabelAlign="left" Layout="Form" ColumnWidth=".33"
                                            LabelWidth="100">
                                            <Items>
                                                <ext:Checkbox ID="chk_tdcothethuyettrinh" runat="server" BoxLabel="Có thể thuyết trình"
                                                    TabIndex="11">
                                                </ext:Checkbox>
                                                <ext:Checkbox ID="chk_tdsansanglamthemgio" runat="server" BoxLabel="Sẵn sàng làm thêm giờ"
                                                    TabIndex="12">
                                                </ext:Checkbox>
                                                <ext:TextField ID="txt_td_hinhthuclamviec" runat="server" FieldLabel="Hình thức"
                                                    AnchorHorizontal="100%" EmptyText="Fulltime/PartTime" TabIndex="13" MaxLength="500" />
                                                <ext:DateField ID="date_tdngaybatdaudilam" runat="server" FieldLabel="Ngày đi làm"
                                                    AnchorHorizontal="100%" TabIndex="14" Editable="false">
                                                </ext:DateField>
                                                <ext:TextField ID="txt_tdthoigianthuviec" runat="server" FieldLabel="Thử việc" AnchorHorizontal="100%"
                                                    EmptyText="0 tháng/năm" TabIndex="15" MaxLength="50" />
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet runat="server" ID="fsYeuCauCongViec" Title="Yêu cầu công việc" AnchorHorizontal="100%">
                            <Items>
                                <ext:Container runat="server" Layout="ColumnLayout" Height="30">
                                    <Items>
                                        <ext:Container runat="server" Layout="FormLayout" ColumnWidth=".33">
                                            <Items>
                                                <ext:NumberField ID="tf_tdluongtoithieu" runat="server" FieldLabel="Lương tối thiểu"
                                                    EmptyText="0" AnchorHorizontal="95%" TabIndex="16" MaxLength="10">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container2" runat="server" Layout="FormLayout" ColumnWidth=".33">
                                            <Items>
                                                <ext:NumberField ID="tf_tdluongtoida" runat="server" FieldLabel="Lương tối đa" EmptyText="0"
                                                    AnchorHorizontal="95%" TabIndex="17" MaxLength="10">
                                                </ext:NumberField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container3" runat="server" Layout="FormLayout" ColumnWidth=".33">
                                            <Items></Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>

                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel2" runat="server" Border="false" Header="false">
                    <Items>
                        <ext:FieldSet runat="server" Title="Phân loại ứng viên" LabelWidth="400">
                            <Items>
                                <%--ext:ComboBox runat="server" ID="cbxTrinhDo" FieldLabel="Trình độ" DisplayField="TEN_TRINHDO"
                                                    ValueField="MA_TRINHDO" Width="130" TabIndex="1" Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store runat="server" ID="Store1" AutoLoad="False" OnRefreshData="cbxTrinhDo_Store_OnRefreshData">
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
                                                    <Listeners>
                                                        <Expand Handler="if(#{cbxTrinhDo}.store.getCount()==0) #{cbxTrinhDo_Store}.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>--%>
                                <ext:DisplayField ID="DisplayField1" runat="server" FieldLabel=" " LabelSeparator=" "></ext:DisplayField>


                                <ext:ComboBox runat="server" LabelPad="50" ID="cbxUngVienDapUngDuocYeuCau" FieldLabel="Ứng viên đáp ứng được yêu cầu" Width="200"
                                    DisplayField="Value" ValueField="ID" Editable="false" StoreID="cbxTrangThaiUngVien_Store">
                                    <Listeners>
                                        <Expand Handler="if(#{cbxUngVienDapUngDuocYeuCau}.store.getCount()==0) #{cbxTrangThaiUngVien_Store}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:Container runat="server" LabelWidth="400" Layout="HBoxLayout" Height="25">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkXoa" FieldLabel="Ứng viên không đáp ứng được yêu cầu" BoxLabel="Xóa" LabelWidth="363">
                                        </ext:Checkbox>
                                        <ext:ComboBox runat="server" ID="cbxUngVienKhongDapUngDuocYeuCau" LabelWidth="0" Width="200"
                                            DisplayField="Value" ValueField="ID" Editable="false" StoreID="cbxTrangThaiUngVien_Store">
                                            <Listeners>
                                                <Expand Handler="if(#{cbxUngVienDapUngDuocYeuCau}.store.getCount()==0) #{cbxTrangThaiUngVien_Store}.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:Container ID="Container4" runat="server" LabelWidth="400" Layout="HBoxLayout" Height="25">
                                    <Items>
                                        <ext:Checkbox runat="server" ID="chkUngVienHanChe" FieldLabel="Ứng viên nằm trong danh sách hạn chế" BoxLabel="Xóa" LabelWidth="363">
                                        </ext:Checkbox>
                                        <ext:ComboBox runat="server" ID="cbxUngVienHanChe" LabelWidth="0" Width="200"
                                            DisplayField="Value" ValueField="ID" Editable="false" StoreID="cbxTrangThaiUngVien_Store">
                                            <Listeners>
                                                <Expand Handler="if(#{cbxUngVienHanChe}.store.getCount()==0) #{cbxTrangThaiUngVien_Store}.reload();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:FieldSet>
                    </Items>
                </ext:Panel>
                <ext:Panel ID="Panel3" runat="server" Border="false" Header="false">
                    <Items>
                        <ext:FieldSet runat="server" Title="Kết quả " AnchorHorizontal="99%" LabelWidth="400">
                            <Items>
                                <ext:DisplayField runat="server" FieldLabel=" " LabelSeparator=" "></ext:DisplayField>
                                <ext:TextField runat="server" ID="txtSoNguoiTrungSoTuyen" FieldLabel="Số người trúng sơ tuyển" LabelWidth="200">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtSoNguoiBiLoaiSoTuyen" FieldLabel="Số người bị loại sơ tuyển" LabelWidth="200">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtUngVienNamTrongDanhSachHanChe" FieldLabel="Ứng viên nằm trong danh sách hạn chế" LabelWidth="200">
                                </ext:TextField>
                            </Items>
                        </ext:FieldSet>

                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>
    </Items>
    <Buttons>
        <ext:Button ID="btnPrev" runat="server" Text="Quay lại" Disabled="true" Icon="PreviousGreen">
            <DirectEvents>
                <Click OnEvent="Prev_Click">
                    <ExtraParams>
                        <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)"
                            Mode="Raw" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnNext" runat="server" Text="Tiếp tục" Icon="NextGreen">
            <DirectEvents>
                <Click OnEvent="Next_Click">
                    <ExtraParams>
                        <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)"
                            Mode="Raw" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdPhanLoaiUngVien}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
