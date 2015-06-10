<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ChamCongCom.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_ChamCongCom" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                // grp_ChamCongCom_Store.reload();
                PagingToolbar1.pageIndex = 0;
                PagingToolbar1.doLoad();
            }

        }
        var changCombobox = function (f, e) {

            PagingToolbar1.pageIndex = 0;
            PagingToolbar1.doLoad();
            grp_ChamCongCom_Store.reload();

        }
        var startEditing = function (e) {
            if (e.getKey() === e.ENTER) {
                var grid = grpEmployeeList,
                    record = grid.getSelectionModel().getSelected(),
                    index = grid.store.indexOf(record);

                grid.startEditing(index, 1);
            }
        };
        var afterEdit = function (e) {
            if (e.record.data.ID == null) {
                CompanyX.Insert(e.record.data.PR_KEY, e.field, e.originalValue, e.value, e.record.data);
            }
            else {
                CompanyX.AfterEdit(e.record.data.ID, e.record.data.PR_KEY, e.field, e.originalValue, e.value, e.record.data);
            } 
        };
        var RenderGender = function (value, p, record) {
            try { value = value.trim(); } catch (e) { }
            var nam = "<span style='color:blue'>Nam</span>";
            var nu = "<span style='color:red'>Nữ</span>";
            if (value == 'M')
                return nam;
            else if (value == 'F')
                return nu;
            else
                return '';
        }
    </script>
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="ResourceManager1" runat="server" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="grpEmployeeList" ClicksToEdit="1" runat="server" StripeRows="true"
                            Border="false" TrackMouseOver="true" AutoExpandColumn="Company">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:ToolbarSpacer runat="server" ID="ToolbarSpacer3" Width="5" />
                                        <ext:DisplayField runat="server" Text="Chọn tháng" />
                                        <ext:ToolbarSpacer runat="server" ID="ToolbarSpacer2" Width="5" />
                                        <ext:ComboBox ID="cbxThang" Width="80" runat="server" Editable="false" EmptyText="Chọn tháng">
                                            <Items>
                                                <ext:ListItem Text="Tháng 1" Value="01" />
                                                <ext:ListItem Text="Tháng 2" Value="02" />
                                                <ext:ListItem Text="Tháng 3" Value="03" />
                                                <ext:ListItem Text="Tháng 4" Value="04" />
                                                <ext:ListItem Text="Tháng 5" Value="05" />
                                                <ext:ListItem Text="Tháng 6" Value="06" />
                                                <ext:ListItem Text="Tháng 7" Value="07" />
                                                <ext:ListItem Text="Tháng 8" Value="08" />
                                                <ext:ListItem Text="Tháng 9" Value="09" />
                                                <ext:ListItem Text="Tháng 10" Value="10" />
                                                <ext:ListItem Text="Tháng 11" Value="11" />
                                                <ext:ListItem Text="Tháng 12" Value="12" />
                                            </Items>
                                            <Listeners>
                                                <Select Handler="txtSearchKey.reset();grp_ChamCongCom_Store.reload(); PagingToolbar1.pageIndex = 0;PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                        <ext:ToolbarSpacer runat="server" ID="tbs" Width="5" />
                                        <ext:DisplayField ID="DisplayField1" runat="server" Text="Chọn năm" />
                                        <ext:ToolbarSpacer runat="server" ID="ToolbarSpacer4" Width="5" />
                                        <ext:SpinnerField runat="server" Width="60" EmptyText="Năm" ID="nbfNam" >
                                        <Listeners>
                                                <SpinUp Handler="txtSearchKey.reset();grp_ChamCongCom_Store.reload();PagingToolbar1.pageIndex = 0;PagingToolbar1.doLoad();" />
                                                <SpinDown Handler="txtSearchKey.reset();grp_ChamCongCom_Store.reload();PagingToolbar1.pageIndex = 0;PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:SpinnerField>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TextField runat="server" ID="txtSearchKey" Width="220" EnableKeyEvents="true"
                                            EmptyText="Nhập từ khóa cần tìm kiếm">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                                            <Listeners>
                                                <Click Handler="#{grp_ChamCongCom_Store}.reload();PagingToolbar1.pageIndex = 0;PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="grp_ChamCongCom_Store" AutoLoad="true" AutoSave="true" runat="server">
                                    <Proxy>
                                        <ext:HttpProxy Method="GET" Url="Handler/ChamCongCom.ashx" />
                                    </Proxy>
                                    <AutoLoadParams>
                                        <ext:Parameter Name="start" Value="={0}" />
                                        <ext:Parameter Name="limit" Value="={25}" />
                                    </AutoLoadParams>
                                    <BaseParams>
                                        <ext:Parameter Name="SearchKey" Value="txtSearchKey.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="Month" Value="cbxThang.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="Year" Value="nbfNam.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="UserID" Value="hdfUserID.getValue()" Mode="Raw" />
                                        <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                                    </BaseParams>
                                    <Reader>
                                        <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_CB">
                                            <Fields>
                                                <ext:RecordField Name="ID" />
                                                <ext:RecordField Name="PR_KEY" />
                                                <ext:RecordField Name="MA_CB" />
                                                <ext:RecordField Name="HO_TEN" />
                                                <ext:RecordField Name="NGAY_SINH" />
                                                <ext:RecordField Name="MA_GIOITINH" />
                                                <ext:RecordField Name="Ngay1" />
                                                <ext:RecordField Name="Ngay2" />
                                                <ext:RecordField Name="Ngay3" />
                                                <ext:RecordField Name="Ngay4" />
                                                <ext:RecordField Name="Ngay5" />
                                                <ext:RecordField Name="Ngay6" />
                                                <ext:RecordField Name="Ngay7" />
                                                <ext:RecordField Name="Ngay8" />
                                                <ext:RecordField Name="Ngay9" />
                                                <ext:RecordField Name="Ngay10" />
                                                <ext:RecordField Name="Ngay11" />
                                                <ext:RecordField Name="Ngay12" />
                                                <ext:RecordField Name="Ngay13" />
                                                <ext:RecordField Name="Ngay14" />
                                                <ext:RecordField Name="Ngay15" />
                                                <ext:RecordField Name="Ngay16" />
                                                <ext:RecordField Name="Ngay17" />
                                                <ext:RecordField Name="Ngay18" />
                                                <ext:RecordField Name="Ngay19" />
                                                <ext:RecordField Name="Ngay20" />
                                                <ext:RecordField Name="Ngay21" />
                                                <ext:RecordField Name="Ngay22" />
                                                <ext:RecordField Name="Ngay23" />
                                                <ext:RecordField Name="Ngay24" />
                                                <ext:RecordField Name="Ngay25" />
                                                <ext:RecordField Name="Ngay26" />
                                                <ext:RecordField Name="Ngay27" />
                                                <ext:RecordField Name="Ngay28" />
                                                <ext:RecordField Name="Ngay29" />
                                                <ext:RecordField Name="Ngay30" />
                                                <ext:RecordField Name="Ngay31" />
                                                <ext:RecordField Name="TongCong" />
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <%--<KeyDown Fn="startEditing" />--%>
                                <AfterEdit Fn="afterEdit" />
                            </Listeners>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="Company" Locked="true" Header="Mã CB" Width="80" DataIndex="MA_CB" />
                                    <ext:Column ColumnID="Company" Locked="true" Header="Họ tên" Width="120" DataIndex="HO_TEN" />
                                    <ext:DateColumn Format="dd/MM/yyyy" Header="Ngày sinh" Locked="true" Width="75" DataIndex="NGAY_SINH">
                                    </ext:DateColumn>
                                    <ext:Column Header="Giới tính" Width="75" DataIndex="MA_GIOITINH">
                                        <Renderer Fn="RenderGender" />
                                    </ext:Column>
                                    <ext:Column Header="Ngày 01" Width="50" DataIndex="Ngay1" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay1" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 02" Width="50" DataIndex="Ngay2" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay2" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 03" Width="50" DataIndex="Ngay3" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay3" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 04" Width="50" DataIndex="Ngay4" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay4" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 05" Width="50" DataIndex="Ngay5" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay5" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 06" Width="50" DataIndex="Ngay6" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay6" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 07" Width="50" DataIndex="Ngay7" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay7" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 08" Width="50" DataIndex="Ngay8" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay8" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 09" Width="50" DataIndex="Ngay9" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay9" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 10" Width="50" DataIndex="Ngay10" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay10" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 11" Width="50" DataIndex="Ngay11" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay11" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 12" Width="50" DataIndex="Ngay12" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay12" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 13" Width="50" DataIndex="Ngay13" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay13" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 14" Width="50" DataIndex="Ngay14" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay14" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 15" Width="50" DataIndex="Ngay15" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay15" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 16" Width="50" DataIndex="Ngay16" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay16" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 17" Width="50" DataIndex="Ngay17" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay17" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 18" Width="50" DataIndex="Ngay18" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay18" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 19" Width="50" DataIndex="Ngay19" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay19" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 20" Width="50" DataIndex="Ngay20" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay20" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 21" Width="50" DataIndex="Ngay21" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay21" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 22" Width="50" DataIndex="Ngay22" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay22" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 23" Width="50" DataIndex="Ngay23" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay23" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 24" Width="50" DataIndex="Ngay24" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay24" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 25" Width="50" DataIndex="Ngay25" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay25" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 26" Width="50" DataIndex="Ngay26" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay26" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 27" Width="50" DataIndex="Ngay27" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay27" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 28" Width="50" DataIndex="Ngay28" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay28" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 29" Width="50" DataIndex="Ngay29" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay29" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 30" Width="50" DataIndex="Ngay30" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay30" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Ngày 31" Width="50" DataIndex="Ngay31" Align="Right">
                                        <Editor>
                                            <ext:TextField ID="txtNgay31" runat="server" MaskRe="[0-9]" />
                                        </Editor>
                                    </ext:Column>
                                    <ext:Column Header="Tổng cộng" Width="60" DataIndex="TongCong" Align="Right"></ext:Column>
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                            </SelectionModel>
                            <LoadMask ShowMask="true" />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="15" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="35" />
                                                <ext:ListItem Text="45" />
                                            </Items>
                                            <SelectedItem Value="25" />
                                            <Listeners>
                                                <Select Handler="txtSearchKey.reset();#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
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
