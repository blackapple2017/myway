<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ImportFromExcel.ascx.cs"
    Inherits="Modules_ChamCong_ImportFromExcel" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<ext:Window runat="server" ID="wdReadFromExcel" Width="500" Icon="PageExcel" Title="Đọc từ file excel"
    Height="140" Padding="10" Modal="true" Hidden="true" Layout="FormLayout">
    <Items>
        <ext:FormPanel ID="BasicForm" runat="server" Border="false" MonitorValid="true">
            <Items>
                <ext:FileUploadField ID="FileUploadField1" runat="server" Text="" FieldLabel="Chọn file Excel"
                    Icon="ImageAdd" AnchorHorizontal="100%" AllowBlank="false">
                    <Listeners>
                        <FileSelected Handler="if(#{FileUploadField1}.getValue().lastIndexOf('.xls')!=-1 && #{FileUploadField1}.getValue().lastIndexOf('.xlsx')==-1){
                                    #{cbSheetNameStore}.reload();#{cbSheetName}.enable();
                                    }" />
                    </Listeners>
                </ext:FileUploadField>
                <ext:ComboBox ID="cbSheetName" Disabled="true" FieldLabel="Chọn sheet" SelectedIndex="0"
                    Editable="false" AnchorHorizontal="100%" runat="server" DisplayField="SheetName"
                    ValueField="SheetName" SelectOnFocus="true" AllowBlank="false">
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
            <Listeners>
                <ClientValidation Handler="#{btnImport}.setDisabled(!valid); #{btnTestDuLieu}.setDisabled(!valid);" />
            </Listeners>
        </ext:FormPanel>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnTestDuLieu" Text="Kiểm tra dữ liệu" Icon="ArrowSwitchBluegreen">
            <DirectEvents>
                <Click OnEvent="btnTestDuLieu_Click" />
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnImport" runat="server" Text="Nhập dữ liệu" Hidden="true" Icon="Accept">
            <DirectEvents>
                <Click OnEvent="ImportDataFromExcel">
                    <EventMask ShowMask="true" />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="btnTaiTepMau" runat="server" Text="Tải file mẫu" Icon="Attach">
            <DirectEvents>
                <Click OnEvent="DownloadBangChamCongMau" IsUpload="true"></Click>
            </DirectEvents>
        </ext:Button>
    </Buttons>
    <Listeners>
        <Hide Handler="#{FileUploadField1}.reset(); #{cbSheetName}.reset();" />
    </Listeners>
</ext:Window>
