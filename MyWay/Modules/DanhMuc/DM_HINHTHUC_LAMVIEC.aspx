<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_HINHTHUC_LAMVIEC.aspx.cs" Inherits="Modules_DanhMuc_DM_HINHTHUC_LAMVIEC" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register src="../Base/SingleGridPanel/SingleGridPanel.ascx" tagname="SingleGridPanel" tagprefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        function validate() {
            if (txtWorkingStatusName.getValue() == '') {
                alert("Bạn chưa nhập hình thức làm việc !");
                txtWorkingStatusName.focus();
                return false;
            }
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:Window runat="server" Hidden="true" Padding="6" Title="Thêm mới hình thức làm việc" Layout="FormLayout" ID="wdWorkingStatus" Width="350" AutoHeight="true" Constrain="true" Modal="true" Resizable="false">
            <Items>
                <ext:TextField ID="txtWorkingStatusName" CtCls="requiredData" runat="server" AnchorHorizontal="100%" FieldLabel="Hình thức<span style='color:red;'>*</span>" />
                <ext:TextArea AnchorHorizontal="100%" ID="txtDescription" runat="server" FieldLabel="Ghi chú" />
            </Items>
            <Listeners>
                <Hide Handler="txtWorkingStatusName.reset();txtDescription.reset();btnUpdate.hide();btnInsert.show();btnInsertAndClose.show();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="btnUpdate" Hidden="true" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return validate();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdate_Click">
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnInsert" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return validate();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdate_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnInsertAndClose" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return validate();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdate_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Mode="Value" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdWorkingStatus.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <uc1:SingleGridPanel TableOrViewName="view_ThamSoTrangThai" TableForDeleting="ThamSoTrangThai" AutoExpandColumn="Value" ColumnWidth="Description=300" ColumnName="ID,Value,Description" ColumnHeader="Mã, Hình thức làm việc,Ghi chú"
         IDProperty="ID" ID="grpWorkingStatus" runat="server" />
    
    </div>
    </form>
</body>
</html>
