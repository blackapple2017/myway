<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_TRINHDO.aspx.cs" Inherits="Modules_DanhMuc_DM_TRINHDO" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel" TagPrefix="uc1" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var renderNhTrinhDo = function (value, p, record) {
            if (value == "1.SDH") {
                return "Sau đại học";
            }
            if (value == "2.DH") {
                return "Đại học";
            }
            if (value == "3.CD") {
                return "Cao đẳng";
            }
            if (value == "4.TC") {
                return "Trung cấp";
            }
            if (value == "5.PTTH") {
                return "Phổ thông trung học";
            }
            if (value == "6.K") {
                return "Khác";
            }
            return value;
        }

        var CheckInput = function () {

            if (txtMaTrinhDo.getValue() == '') {
                alert("Bạn chưa nhập mã trình độ");
                return false;
            }
            if (txtTenTrinhDo.getValue() == '') {
                alert("Bạn chưa nhập tên trình độ");
                return false;
            }
            if (!cbbNhomTrinhDo.getValue()) {
                alert("Bạn chưa chọn nhóm trình độ");
                return false;
            }
            return true;
        }
        var resetForm = function () {
            txtMaTrinhDo.reset();
            txtMaTrinhDo.enable();
            txtTenTrinhDo.reset();
            cbbNhomTrinhDo.reset();
            txtGhiChu.reset();
            Ext.DirectMethod.ResetTitle();
            btnCapNhat.Show();
            Button2.Show();
            btnSua.Hide();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>

            <%-- <uc1:GridPanel ID="grp_dm_trinhdo" runat="server" />--%>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới trình độ"
                Icon="Add">
                <Items>
                    <ext:Hidden runat="server" ID="hdfCommand" />
                    <ext:TextField runat="server" ID="txtMaTrinhDo" AnchorHorizontal="99%" FieldLabel="Mã trình độ<span style='color:red'>*</span>">
                    </ext:TextField>
                    <ext:TextField runat="server" ID="txtTenTrinhDo" AnchorHorizontal="99%" FieldLabel="Tên trình độ<span style='color:red'>*</span>">
                    </ext:TextField>
                    <ext:ComboBox runat="server" ID="cbbNhomTrinhDo" AnchorHorizontal="99%" FieldLabel="Nhóm trình độ<span style='color:red'>*</span>"
                        Editable="false">
                        <Items>
                            <ext:ListItem Value="1.SDH" Text="Sau đại học" />
                            <ext:ListItem Value="2.DH" Text="Đại học" />
                            <ext:ListItem Value="3.CD" Text="Cao đẳng" />
                            <ext:ListItem Value="4.TC" Text="Trung cấp" />
                            <ext:ListItem Value="5.PTTH" Text="Phổ thông trung học" />
                            <ext:ListItem Value="6.K" Text="Khác" />
                        </Items>
                    </ext:ComboBox>
                    <ext:TextArea runat="server" ID="txtGhiChu" AnchorHorizontal="99%" FieldLabel="Ghi chú">
                    </ext:TextArea>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="False">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnSua" Hidden="true" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnEdit_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Edit">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button2" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInput();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                <ExtraParams>
                                    <ext:Parameter Name="Close" Value="True">
                                    </ext:Parameter>
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button5" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdAddWindow}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show(); resetForm();" />
                </Listeners>
            </ext:Window>
            <uc1:SingleGridPanel runat="server" ID="grpDanhMucTrinhDo" ColumnName="MA_TRINHDO,TEN_TRINHDO,NhomTrinhDo,GHI_CHU"
                TableForDeleting="DM_TRINHDO" 
                DisplayPrimaryColumn="true" Title="Danh mục trình độ" ColumnHeader="Mã trình độ, Tên trình độ, Nhóm trình độ, Ghi chú"
                ColumnWidth="MA_TRINHDO=100,TEN_TRINHDO=170,NhomTrinhDo=170,GHI_CHU=300" OrderBy="NhomTrinhDo" AutoExpandColumn="GHI_CHU"
                IDProperty="MA_TRINHDO" TableOrViewName="DM_TRINHDO" SearchField="MA_TRINHDO,TEN_TRINHDO" Render="NhomTrinhDo=renderNhTrinhDo" EmptyTextSearch="Nhập mã hoặc tên trình độ" />
        </div>
    </form>
</body>
</html>
