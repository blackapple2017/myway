<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_CONGVIEC.aspx.cs" Inherits="Modules_DanhMuc_DM_CONGVIEC" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Store1.reload();
            }
        }

        var RemoveItemOnGrid = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.remove(r);
                        Store.commitChanges();
                        Ext.net.DirectMethods.DeleteRecord(r.data.MA_CONGVIEC);
                        btnEdit.disable();
                        btnDelete.disable();
                    }
                }
            });
        }

        var getSelectedIndexRow = function () {
            var record = GridPanel1.getSelectionModel().getSelected();
            var index = GridPanel1.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }

        addUpdatedRecord = function (ma_congviec, ten_congviec, username, date_create, ma_donvi) {
            var rowindex = getSelectedIndexRow();
            //xóa bản ghi cũ
            var s = GridPanel1.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store1.remove(r);
                Store1.commitChanges();
            }
            //Thêm bản ghi đã update
            GridPanel1.insertRecord(rowindex, {
                MA_CONGVIEC: ma_congviec,
                TEN_CONGVIEC: ten_congviec,
                USERNAME: username,
                DATE_CREATE: date_create,
                MA_DONVI: ma_donvi
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }

        var addRecord = function (ma_congviec, ten_congviec, username, date_create, ma_donvi) {
            var rowindex = getSelectedIndexRow();
            GridPanel1.insertRecord(rowindex, {
                MA_CONGVIEC: ma_congviec,
                TEN_CONGVIEC: ten_congviec,
                USERNAME: username,
                DATE_CREATE: date_create,
                MA_DONVI: ma_donvi
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }

        var CheckInput = function () {
            if (txtMA_CONGVIEC.getValue() == '') {
                alert("Bạn chưa nhập mã công việc");
                txtMA_CONGVIEC.focus();
                return false;
            }
            if (txtTEN_CONGVIEC.getValue() == '') {
                alert("Bạn chưa nhập tên công việc");
                txtTEN_CONGVIEC.focus();
                return false;
            } 
            
            return true;
        }

        var resetWindowHide = function () {
            txtMA_CONGVIEC.reset(); txtTEN_CONGVIEC.reset();
        }
         
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
            Padding="6" Constrain="false" Title="Nhập khóa chính mới" Hidden="true" Icon="Add"
            runat="server" AutoHeight="true">
            <Items>
                <ext:TextField FieldLabel="Nhập mã" runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%">
                </ext:TextField>
            </Items>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                    <Listeners>
                        <Click Handler="if(txtmaloaihdcoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnOK_Click">
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Thoát">
                    <Listeners>
                        <Click Handler="wdInputNewPrimaryKey.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="txtmaloaihdcoppy.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                    <Listeners>
                        <Click Handler="#{wdAddWindow}.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem4" runat="server" Icon="Delete" Text="Xóa">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                    <Listeners>
                        <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnEdit_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuSeparator runat="server" ID="mnuDuplicate" />
                <ext:MenuItem ID="mnuDuplicateData" runat="server" Icon="DiskMultiple" Text="Nhân đôi dữ liệu">
                    <Listeners>
                        <Click Handler="wdInputNewPrimaryKey.show();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới công việc"
            Icon="Add">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommand" />
                <ext:TextField runat="server" ID="txtMA_CONGVIEC" MaxLength="20" CtCls="requiredData" FieldLabel="Mã công việc<span style='color:red;'>*</span>" AnchorHorizontal="100%">
                </ext:TextField>
                <ext:TextField runat="server" ID="txtTEN_CONGVIEC" MaxLength="50" CtCls="requiredData" FieldLabel="Tên công việc<span style='color:red;'>*</span>" AnchorHorizontal="100%">
                </ext:TextField>
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
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
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
                        <Click Handler="#{wdAddWindow}.hide();resetWindowHide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show(); resetWindowHide(); Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="Store1" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerDM_CONGVIEC.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_CONGVIEC">
                    <Fields>
                        <ext:RecordField Name="MA_CONGVIEC" />
                        <ext:RecordField Name="TEN_CONGVIEC" />
                        <ext:RecordField Name="USERNAME" />
                        <ext:RecordField Name="DATE_CREATE" />
                        <ext:RecordField Name="MA_DONVI" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                            Icon="ApplicationViewColumns" AutoExpandColumn="TEN_CONGVIEC" TrackMouseOver="false"
                            AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                            <Listeners>
                                                <Click Handler="#{wdAddWindow}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEdit_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                        <ext:Button ID="Button1" runat="server" Text="Tiện ích" Icon="Build">
                                            <Menu>
                                                <ext:Menu ID="Menu4" runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="Nhân đôi dữ liệu"
                                                            Icon="DiskMultiple">
                                                            <Listeners>
                                                                <Click Handler="#{wdInputNewPrimaryKey}.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TextField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                            ID="txtSearch">
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                        </ext:TextField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="#{Store1}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Locked="true" Header="STT" />
                                    <ext:Column ColumnID="MA_CONGVIEC" Header="Mã công việc" DataIndex="MA_CONGVIEC" />
                                    <ext:Column ColumnID="TEN_CONGVIEC" Header="Tên công việc" DataIndex="TEN_CONGVIEC" />
                                    <ext:DateColumn Format="dd/MM/yyyy" ColumnID="DATE_CREATE" Header="Ngày tạo" DataIndex="DATE_CREATE" />
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);btnEdit.enable();btnDelete.enable();mnuNhanDoiDuLieu.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                    PageSize="30" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                    DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                        <ext:ComboBox ID="ComboBoxPaging" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                                <ext:ListItem Text="70" />
                                                <ext:ListItem Text="100" />
                                            </Items>
                                            <SelectedItem Value="30" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Listeners>
                                        <Change Handler="checkboxSelection.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                <DblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                            </Listeners>
                            <DirectEvents>
                                <DblClick OnEvent="btnEdit_Click">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </DblClick>
                            </DirectEvents>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
