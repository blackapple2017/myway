<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ExcelReader.ascx.cs" Inherits="Modules_Base_ExcelReader_ExcelReader" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    function CheckUploadFile(uploadControl, gridPanel, WizardPanel) {
        if (uploadControl.getValue().lastIndexOf(".xls") == -1 && uploadControl.getValue().lastIndexOf(".xlsx") == -1) {
            Ext.Msg.alert("Thông báo", "Tệp tin bạn chọn không hợp lệ, chương trình chỉ hỗ trợ tệp tin Excel 2003 !");
            return false;
        }
        if (WizardPanel.items.indexOf(WizardPanel.layout.activeItem) == 1) {
            if (gridPanel.getSelectionModel().getCount() == 0) {
                Ext.Msg.alert("Thông báo", "Bạn phải chọn các cột để tiến hành nhập dữ liệu!");
                return false;
            }
            else {
                var s = gridPanel.getSelectionModel().getSelections();
                for (var i = 0, r; r = s[i]; i++) {
                    if (r.data.ColumnInExcel == '') {
                        Ext.Msg.alert("Thông báo", 'Cột "' + r.data.ColumnInDB + '" chưa được khớp nối!');
                        return false;
                    }
                }
            }

            //return checkInsert();
        }
        return true;
    }

    //    var checkInsert = function (gridPanel) {
    //        var count = 0;
    //        var s = gridPanel.getRowsValues();
    //        for (var i = 0, r; r = s[i]; i++) {
    //            if (r.data.AllowBlank == 'Bắt buộc nhập') {
    //                if (r.data.ColumnInExcel == '') {
    //                    count++;
    //                }
    //            }
    //        }
    //        if (count > 0) {
    //            Ext.Msg.alert("Thông báo", 'Có ' + count + ' cột bắt buộc nhập chưa khớp nối');
    //            return false;
    //        }
    //        else {
    //            Ext.Msg.alert("Thông báo", "Đã hoàn thành khớp nối");
    //        }
    //        return true;
    //    }
     
    var GetMathStatus = function (value, p, record) {
        if (value == "false")
            return "<span style='color:red;font-weight:bold;'>Không khớp nối được</span>";
        return "Thành công";
    }

    var GetDataType = function (value, p, record) {
        switch (value) {
            case "DateTime":
                return "Ngày tháng";
            case "String":
                return "Chuỗi";
            case "Gender":
                return "Giới tính";
            case "Bit":
                return "Đúng/Sai";
            case "Integer":
                return "Số nguyên";
            case "Float":
                return "Số thực";
            default:
                return value;
        }
    }

    var GetAllowBlank = function (value, p, record) {
        if (value == "false")
            return "<span style='color:red;font-weight:bold;'>Bắt buộc nhập</span>";
        return "Không";
    }
</script>
<style type="text/css">
    .x-panel-body {
        background: #DFE8F6 !important;
    }
</style>
<ext:Store ID="ColumnStore" runat="server" AutoLoad="false" EnableViewState="false">
    <DirectEventConfig>
        <EventMask ShowMask="false" />
    </DirectEventConfig>
    <Reader>
        <ext:JsonReader IDProperty="ColumnName">
            <Fields>
                <ext:RecordField Name="ColumnName" />
            </Fields>
        </ext:JsonReader>
    </Reader>
</ext:Store>
<ext:Hidden runat="server" ID="hdfNotBlankColumnNumber" Text="MA_CB" IDMode="Static" />
<ext:Hidden runat="server" ID="hdfMathStatus" IDMode="Static" />
<ext:Window runat="server" ID="wdSetupMathRule" Hidden="true" Width="500" Height="350"
    Modal="true" Icon="ArrowSwitchBluegreen" Constrain="true" Title="Thiết lập quy tắc khớp nối"
    Layout="FormLayout">
    <Items>
        <ext:GridPanel ID="GridPanel2" Header="false" runat="server" AutoExpandColumn="ColumnInExcel"
            Layout="FitLayout" TrackMouseOver="true" Border="false" ClicksToEdit="1" StripeRows="true"
            Height="300" AnchorHorizontal="100%">
            <Store>
                <ext:Store ID="Store3" runat="server" AutoSave="true" ShowWarningOnFailure="false" AutoLoad="false"
                    OnBeforeStoreChanged="HandleChangesTuDien" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                    OnRefreshData="RefreshData">
                    <Reader>
                        <ext:JsonReader IDProperty="ColumnInDB">
                            <Fields>
                                <ext:RecordField Name="ColumnInDB" />
                                <ext:RecordField Name="ColumnInSoftware" />
                                <ext:RecordField Name="ColumnInExcel" />
                                <ext:RecordField Name="AllowBlank" />
                                <ext:RecordField Name="MathStatus" />
                                <ext:RecordField Name="DataType" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel ID="ColumnModel3" runat="server">
                <Columns>
                    <ext:RowNumbererColumn Header="STT" Width="30" />
                    <ext:Column ColumnID="ColumnInSoftware" Header="Cột trong phần mềm" Width="150" DataIndex="ColumnInSoftware" />
                    <ext:Column Header="Cột trong file Excel" Width="150" ColumnID="ColumnInExcel" DataIndex="ColumnInExcel">
                        <Editor>
                            <ext:TextField ID="txtEditData" AnchorHorizontal="100%" runat="server" />
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="Bắt buộc nhập" Hidden="true" Width="100" DataIndex="AllowBlank">
                        <Renderer Fn="GetAllowBlank" />
                        <Editor>
                            <ext:ComboBox runat="server" ID="ComboBox2">
                                <Items>
                                    <ext:ListItem Text="Không" Value="true" />
                                    <ext:ListItem Text="Bắt buộc nhập" Value="false" />
                                </Items>
                            </ext:ComboBox>
                        </Editor>
                    </ext:Column>
                    <ext:Column Header="Tình trạng khớp nối" Hidden="true" Width="150" DataIndex="MathStatus">
                        <Renderer Fn="GetMathStatus" />
                    </ext:Column>
                    <ext:Column Header="Kiểu dữ liệu" Width="70" Hidden="true" DataIndex="DataType">
                        <Renderer Fn="GetDataType" />
                        <Editor>
                            <ext:ComboBox runat="server" Editable="false" ID="ComboBox3">
                                <Items>
                                    <ext:ListItem Text="Ngày tháng" Value="DateTime" />
                                    <ext:ListItem Text="Chuỗi" Value="String" />
                                    <ext:ListItem Text="Giới tính" Value="Gender" />
                                    <ext:ListItem Text="Đúng/Sai" Value="Bit" />
                                    <ext:ListItem Text="Số nguyên" Value="Integer" />
                                    <ext:ListItem Text="Số thực" Value="Float" />
                                </Items>
                            </ext:ComboBox>
                        </Editor>
                    </ext:Column>
                </Columns>
            </ColumnModel>
        </ext:GridPanel>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnDongLai" Text="Đóng" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdSetupMathRule}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{Store3}.reload();" />
    </Listeners>
</ext:Window>
<ext:FormPanel runat="server" Border="false" EnableViewState="false" AutoHeight="true"
    Resizable="false" Modal="true" Hidden="false" ID="wdImportDataFromExcel" AnchorHorizontal="100%">
    <Items>
        <ext:Panel Border="false" Layout="CardLayout" ActiveIndex="0" Padding="0" runat="server"
            EnableViewState="false" ID="WizardPanel">
            <Items>
                <ext:Panel runat="server" AutoHeight="true" Border="false" EnableViewState="false"
                    ID="Step1" Padding="6" Title="Bước 1/3 : Chọn tệp tin">
                    <Items>
                        <ext:FieldSet ID="FieldSet1" runat="server" Title="Chọn tệp tin" AutoHeight="true">
                            <Items>
                                <ext:FileUploadField runat="server" ID="fUpload" SelectOnFocus="true" Regex="^.*\.xls$"
                                    InvalidText="Tệp tin được chọn phải là Excel 2003" AnchorHorizontal="100%" FieldLabel="<%$ Resources:HopDong, ChonTepTin%>">
                                    <Listeners>
                                        <FileSelected Handler="if(#{fUpload}.getValue().lastIndexOf('.xls')!=-1 && #{fUpload}.getValue().lastIndexOf('.xlsx')==-1){
                                                                    #{cbSheetNameStore}.reload();#{cbSheetName}.enable();
                                                                  }" />
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
                            </Items>
                        </ext:FieldSet>
                        <%--<ext:Checkbox runat="server" ID="chkBoQuaBanGhiTrung" BoxLabel="Bỏ qua các mã cán bộ đã tồn tại"
                            Checked="true" />--%>
                        <ext:FieldSet runat="server" AutoHeight="true" Layout="RowLayout" AnchorHorizontal="100%" Title="Khi mã cán bộ bị trùng">
                            <Items>
                                <ext:RadioGroup runat="server" LabelAlign="Top" ColumnsNumber="1" ItemCls="x-check-group-alt">
                                    <Items>
                                        <ext:Radio runat="server" ID="rd_CapNhatBanGhiTonTai" BoxLabel="Ghi đè thông tin mới" Checked="true" />
                                        <ext:Radio runat="server" ID="rd_BoQuaCacBanGhiTonTai" BoxLabel="Bỏ qua không cập nhật" />
                                    </Items>
                                </ext:RadioGroup>
                            </Items>
                        </ext:FieldSet>
                        <ext:FieldSet ID="fsColumnConstraint" AutoHeight="true" runat="server" Hidden="true"
                            Title="Chọn dòng để nhập liệu">
                            <Items>
                                <ext:RadioGroup ID="rd" FieldLabel="Chọn dòng" runat="server">
                                    <Items>
                                        <ext:Radio ID="AllRows" runat="server" FieldLabel="Tất cả các dòng" Checked="true">
                                            <Listeners>
                                                <Check Handler="if(#{AllRows}.checked){
                                                                   #{txtSomeNumbers}.hide();
                                                                   #{txtInsideRange}.hide();
                                                                   #{txtOutRange}.hide();
                                                                }" />
                                            </Listeners>
                                        </ext:Radio>
                                        <ext:Radio ID="rdInsideRange" runat="server" FieldLabel="Trong khoảng">
                                            <Listeners>
                                                <Check Handler="if(#{rdInsideRange}.checked){
                                                                   #{txtSomeNumbers}.hide();
                                                                   #{txtInsideRange}.show();
                                                                   #{txtOutRange}.hide();
                                                                }" />
                                            </Listeners>
                                        </ext:Radio>
                                        <ext:Radio ID="rdOutRange" runat="server" FieldLabel="Ngoài khoảng">
                                            <Listeners>
                                                <Check Handler="if(#{rdOutRange}.checked){
                                                                   #{txtSomeNumbers}.hide();
                                                                   #{txtInsideRange}.hide();
                                                                   #{txtOutRange}.show();
                                                                }" />
                                            </Listeners>
                                        </ext:Radio>
                                        <ext:Radio ID="rdSomeRows" runat="server" FieldLabel="Dòng cụ thể">
                                            <Listeners>
                                                <Check Handler="if(#{rdSomeRows}.checked){
                                                                   #{txtSomeNumbers}.show();
                                                                   #{txtInsideRange}.hide();
                                                                   #{txtOutRange}.hide();
                                                                }" />
                                            </Listeners>
                                        </ext:Radio>
                                    </Items>
                                </ext:RadioGroup>
                                <ext:TextField FieldLabel="Nhập dòng" AnchorHorizontal="100%" Note="Hướng dẫn: giả sử bạn muốn nhập dòng số 7 thì bạn nhập số 7, nếu muốn nhập nhiều dòng khác nhau thì mỗi dòng cách nhau bằng dầu chấm phẩy, ví dụ như 7,8,23"
                                    NoteAlign="Top" Hidden="true" runat="server" ID="txtSomeNumbers" />
                                <ext:TextField ID="txtInsideRange" Hidden="true" FieldLabel="Trong khoảng" NoteAlign="Top"
                                    AnchorHorizontal="100%" Note="Hướng dẫn : giả sử bạn muốn nhập từ dòng 5 đến dòng 10 thì bạn nhập 5-10. Nếu muốn nhập nhiều khoảng thì mỗi khoảng cách nhau bằng dấu chấm phảy(;), ví dụ 5-10;7-8"
                                    runat="server" />
                                <ext:TextField ID="txtOutRange" Hidden="true" FieldLabel="Ngoài khoảng" NoteAlign="Top"
                                    AnchorHorizontal="100%" Note="Hướng dẫn : giả sử bạn loại bỏ dòng 5 đến dòng 10 thì bạn nhập 5-10, nếu có nhiều khoảng cần loại bỏ thì các khoảng cách nhau bằng dấu chấm phảy(;)"
                                    runat="server" />
                            </Items>
                        </ext:FieldSet>
                    </Items>
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tb">
                            <Items>
                                <ext:Button ID="btnDownloadExcel" Text="Tải tệp tin mẫu" runat="server" Icon="ArrowDown">
                                    <DirectEvents>
                                        <Click OnEvent="btnDownloadExcel_Click" IsUpload="true">
                                        </Click>
                                    </DirectEvents>
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip1" runat="server" Title="<%$ Resources:Language, help%>" Html="Nếu bạn chưa có tệp tin Excel mẫu để nhập liệu. Hãy ấn nút này để tải tệp tin mẫu về máy">
                                        </ext:ToolTip>
                                    </ToolTips>
                                </ext:Button>
                                <%--<ext:ToolbarSeparator runat="server" ID="ToolbarSeparator1" />
                                <ext:Button runat="server" ID="btnCreateMathRuleFile" Icon="ArrowSwitchBluegreen"
                                    Text="Tạo file qui tắc khớp nối">
                                    <DirectEvents>
                                        <Click OnEvent="btnCreateMathRuleFile_Click">
                                            <Confirmation ConfirmRequest="true" Title="<%$ Resources:CommonMessage, Warning%>" Message="Chức năng này được dùng để tạo mới tệp tin chứa qui tắc khớp nối, chính vì vậy các qui tắc cũ đã thiết lập trước đó sẽ bị mất hoàn toàn và không thể lấy lại được. Bạn nên cân nhắc trước khi thực hiện hành động này" />
                                            <EventMask ShowMask="true" Msg="Đợi trong giây lát..." />
                                        </Click>
                                    </DirectEvents>
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip2" runat="server" Title="<%$ Resources:Language, help%>" Html="Chức năng này được xử dụng khi tệp tin chứa qui tắc khớp nối bị mất hoặc chưa tồn tại">
                                        </ext:ToolTip>
                                    </ToolTips>
                                </ext:Button>--%>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                </ext:Panel>
                <ext:Panel ID="Step2" AutoHeight="true" Border="false" EnableViewState="false" runat="server"
                    Title="Bước 2/3 : Khớp nối các cột giữa cơ sở dữ liệu và Excel">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tbGridPanel1">
                            <Items>
                                <%--<ext:Button ID="btnCheckInsert" runat="server" Text="Kiểm tra khớp nối" Icon="CheckError">
                                    <DirectEvents>
                                        <Click OnEvent="btnCheckInsert_Click">
                                            <EventMask ShowMask="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>--%>
                                <ext:Button ID="btnTaoQuyTacKhopNoi" runat="server" Text="Thiết lập quy tắc khớp nối"
                                    Icon="ArrowSwitchBluegreen">
                                    <Listeners>
                                        <Click Handler="#{wdSetupMathRule}.show();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Items>
                        <ext:Hidden runat="server" ID="hdfIsSuccess" Text="false" />
                        <ext:GridPanel ID="GridPanel1" Header="false" runat="server" AutoExpandColumn="ColumnInExcel"
                            Layout="FitLayout" TrackMouseOver="true" Border="false" ClicksToEdit="1" StripeRows="true"
                            Height="300" AnchorHorizontal="100%">
                            <%--<BottomBar>
                                                <ext:StatusBar ID="StatusBar1" runat="server">
                                                    <Items>
                                                        <ext:Label ID="Label1" runat="server" Html="Có 2 khớp nối không thành công !" />
                                                    </Items>
                                                </ext:StatusBar>
                                            </BottomBar>--%>
                            <Store>
                                <ext:Store ID="Store1" runat="server" AutoSave="true" ShowWarningOnFailure="false" AutoLoad="false"
                                    OnBeforeStoreChanged="HandleChanges" SkipIdForNewRecords="false" RefreshAfterSaving="None"
                                    OnRefreshData="MyData_Refresh">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ColumnInDB">
                                            <Fields>
                                                <ext:RecordField Name="ColumnInDB" />
                                                <ext:RecordField Name="ColumnInSoftware" />
                                                <ext:RecordField Name="ColumnInExcel" />
                                                <ext:RecordField Name="AllowBlank" />
                                                <ext:RecordField Name="MathStatus" />
                                                <ext:RecordField Name="DataType" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="30" />
                                    <ext:Column ColumnID="ColumnInSoftware" Header="Cột trong phần mềm" Width="150" DataIndex="ColumnInSoftware" />
                                    <ext:Column Header="Cột trong file Excel" Width="150" ColumnID="ColumnInExcel" DataIndex="ColumnInExcel">
                                        <Editor>
                                            <ext:ComboBox StoreID="ColumnStore" Editable="false" ValueField="ColumnName" DisplayField="ColumnName"
                                                runat="server" ID="cbColumnInExcel" Shadow="Drop" Mode="Local">
                                                <Listeners>
                                                    <Expand Handler="if(#{cbColumnInExcel}.store.getCount()==0) #{ColumnStore}.reload();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Bắt buộc nhập" Width="100" DataIndex="AllowBlank">
                                        <Renderer Fn="GetAllowBlank" />
                                        <Editor>
                                            <ext:ComboBox runat="server" ID="cbAllowBlank">
                                                <Items>
                                                    <ext:ListItem Text="Không" Value="true" />
                                                    <ext:ListItem Text="Bắt buộc nhập" Value="false" />
                                                </Items>
                                            </ext:ComboBox>
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tình trạng khớp nối" Width="150" DataIndex="MathStatus">
                                        <Renderer Fn="GetMathStatus" />
                                    </ext:Column>
                                    <ext:Column Header="Kiểu dữ liệu" Hidden="true" Width="70" DataIndex="DataType">
                                        <Renderer Fn="GetDataType" />
                                        <Editor>
                                            <ext:ComboBox runat="server" Editable="false" ID="cbDataType">
                                                <Items>
                                                    <ext:ListItem Text="Ngày tháng" Value="DateTime" />
                                                    <ext:ListItem Text="Chuỗi" Value="String" />
                                                    <ext:ListItem Text="Giới tính" Value="Gender" />
                                                    <ext:ListItem Text="Đúng/Sai" Value="Bit" />
                                                    <ext:ListItem Text="Số nguyên" Value="Integer" />
                                                    <ext:ListItem Text="Số thực" Value="Float" />
                                                </Items>
                                            </ext:ComboBox>
                                        </Editor>
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:CheckboxSelectionModel ID="RowSelectionModel1" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" Msg="Đang khớp nối các cột..." />
                        </ext:GridPanel>
                        <ext:DisplayField ID="DisplayField1" runat="server" Html="<b>Chú ý:</b> Phần mềm chỉ nhập dữ liệu từ những cột bạn chọn ở trên" />
                    </Items>
                    <Listeners>
                        <AfterLayout Handler="#{Store1}.reload();" />
                    </Listeners>
                </ext:Panel>
                <ext:Panel runat="server" AutoHeight="true" Border="false" EnableViewState="false"
                    ID="Step3" Padding="6" Title="Bước 3/3 : Kết quả">
                    <Items>
                        <ext:Label runat="server" ID="lblCompletedRow" />
                        <ext:Label runat="server" ID="lblUpdatedRow" />
                        <ext:Label runat="server" ID="lblError" />
                        <ext:GridPanel Icon="Error" AnchorHorizontal="100%" Height="300" runat="server" Header="true"
                            ID="grp_ErrorRows" AutoExpandColumn="ErrorMessage" Title="Các dòng bị lỗi">
                            <Store>
                                <ext:Store ID="Store2" runat="server">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ColumnInDB">
                                            <Fields>
                                                <ext:RecordField Name="Data" />
                                                <ext:RecordField Name="LineInExcel" />
                                                <ext:RecordField Name="ErrorMessage" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Plugins>
                                <ext:RowExpander runat="server" ID="rx">
                                    <Template ID="Template1" runat="server">
                                        <Html>
                                            <b>Dòng có nguồn dữ liệu như sau bị lỗi :  </b>
                                            {Data}
                                        </Html>
                                    </Template>
                                </ext:RowExpander>
                            </Plugins>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel2" runat="server" />
                            </SelectionModel>
                            <ColumnModel ID="ColumnModel2" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn />
                                    <ext:Column ColumnID="Company" Header="Dữ liệu bị lỗi" Width="230" DataIndex="Data" />
                                    <ext:Column Header="Dòng trong Excel" Width="100" DataIndex="LineInExcel" />
                                    <ext:Column Header="Nguyên nhân bị lỗi" ColumnID="ErrorMessage" Width="85" DataIndex="ErrorMessage" />
                                </Columns>
                            </ColumnModel>
                            <BottomBar>
                                <ext:PagingToolbar runat="server" ID="pg">
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Items>
                </ext:Panel>
            </Items>
        </ext:Panel>
    </Items>
    <Listeners>
        <BeforeShow Handler="#{WizardPanel}.layout.setActiveItem(0); #{DirectMethods}.CreateDictionary();" />
        <Hide Handler="#{DirectMethods}.DeleteFileExcel();#{btnPrev}.disable();#{btnNext}.enable();#{fUpload}.reset();#{cbSheetName}.reset();" />
    </Listeners>
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
            <Listeners>
                <Click Handler="return CheckUploadFile(#{fUpload},#{GridPanel1},#{WizardPanel});" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="Next_Click">
                    <ExtraParams>
                        <ext:Parameter Name="index" Value="#{WizardPanel}.items.indexOf(#{WizardPanel}.layout.activeItem)"
                            Mode="Raw" />
                    </ExtraParams>
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" Icon="Decline" Text="<%$ Resources:CommonMessage, Close%>" ID="ctl679">
            <Listeners>
                <Click Handler="#{wdImportDataFromExcel}.hide(); try {wdNhapTuExcel.hide();} catch (e) {}" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:FormPanel>
