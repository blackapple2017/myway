<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_LOAI_HDONG.aspx.cs" Inherits="Modules_DanhMuc_DM_LOAI_HDONG" %>

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
        var RenderTime = function (value, p, record) {
            if (value != '' && value != null) {
                var month = value * 1;
                if (isNaN(month) == false) {
                    if (month < 12) {
                        return value + " Tháng";
                    }
                    if (month % 12 == 0) {
                        return month / 12 + " năm";
                    }
                    return (month - month % 12) / 12 + " năm " + month % 12 + " tháng";
                }
            }
            return "";
        }

        var CheckInput = function () {
            if (txtmaloaihd.getValue().trim() == '') {
                alert("Bạn phải nhập mã loại hợp đồng");
                txtmaloaihd.focus();
                return false;
            }
            if (txtTenLoaiHopDong.getValue().trim() == '') {
                alert("Bạn chưa nhập tên loại hợp đồng");
                txtTenLoaiHopDong.focus();
                return false;
            }
            if (txtThoiGian.getValue() == '') {
                alert("Bạn phải nhập số tháng hợp đồng");
                txtThoiGian.focus();
                return false;
            }
            return true

        }
        var CheckMaLoaiHD = function () {
            if (txtmaloaihdcoppy.getValue().trim() == '') {
                alert("Bạn phải nhập mã loại hợp đồng");
                txtmaloaihdcoppy.focus();
                return false;
            }
            return true;
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
                        Ext.net.DirectMethods.DeleteHopDong(r.data.MA_LOAI_HDONG);
                    }
                }
            });
        }

        var addHopDong = function (rowindex, ma, tenhopdong, thoigian, ghichu) {
            GridPanel1.insertRecord(rowindex, {
                MA_LOAI_HDONG: ma,
                TEN_LOAI_HDONG: tenhopdong,
                THOI_HAN_HOPDONG: thoigian,
                GHI_CHU: ghichu
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM">
            </ext:ResourceManager>
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Width="400" Padding="6" Constrain="false"
                Title="Nhập mã loại hợp đồng" Hidden="true" Icon="Add" runat="server" AutoHeight="true"
                Layout="FormLayout">
                <Items>
                    <ext:TextField FieldLabel="Mã loại hợp đồng<span style='color:red;'>*</span>" CtCls="requiredData"
                        runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%">
                    </ext:TextField>
                </Items>
                <Listeners>
                    <Hide Handler="txtmaloaihdcoppy.reset();" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                        <Listeners>
                            <Click Handler="return CheckMaLoaiHD(); wdInputNewPrimaryKey.hide();" />
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
                            <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();
                               #{Button2}.hide();" />
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
                            <Click Handler="#{wdInputNewPrimaryKey}.show();" />
                        </Listeners>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới loại hợp đồng"
                Icon="Add">
                <Items>
                    <ext:Hidden runat="server" ID="hdfCommand" />
                    <ext:Container Height="27" runat="server" ID="ct" AnchorHorizontal="100%" Layout="ColumnLayout">
                        <Items>
                            <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout">
                                <Items>
                                    <ext:TextField runat="server" ID="txtmaloaihd" CtCls="requiredData" FieldLabel="Mã loại HĐ<span style='color:red;'>*</span>"
                                        AnchorHorizontal="98%">
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                            <ext:TextField runat="server" ID="nbfHeSo" FieldLabel="Hệ số" ColumnWidth="0.5" MaskRe="/[0-9.]/"></ext:TextField>
                            <%--<ext:NumberField runat="server" FieldLabel="Hệ số" ColumnWidth="0.5" ID="nbfHeSo"></ext:NumberField>--%>
                        </Items>
                    </ext:Container>
                    <ext:TextField runat="server" ID="txtTenLoaiHopDong" CtCls="requiredData" FieldLabel="Tên loại HĐ<span style='color:red;'>*</span>"
                        AnchorHorizontal="100%">
                    </ext:TextField>
                    <ext:Container runat="server" Height="27" Layout="ColumnLayout" AnchorHorizontal="100%">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:NumberField runat="server" ID="txtThoiGian" FieldLabel="Thời hạn HĐ<span style='color:red;'>*</span>"
                                        CtCls="requiredData" EmptyText="Thời hạn hợp đồng được tính bằng số tháng" AnchorHorizontal="98%">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                            <ext:ComboBox runat="server" ID="txtGhiChu" Editable="false" FieldLabel="Loại hợp đồng" ColumnWidth="0.5" AnchorHorizontal="100%">
                                <Items>
                                    <ext:ListItem Text="Chính thức" Value="Chính thức" />
                                    <ext:ListItem Text="Thử việc" Value="HV/Thử việc" />
                                    <ext:ListItem Text="Thời vụ" Value="Thời vụ" />
                                </Items>
                            </ext:ComboBox>
                        </Items>
                    </ext:Container>
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
                            <Click Handler="#{wdAddWindow}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="if(#{hdfCommand}.getValue()=='Update'){txtmaloaihd.disable();} else {txtmaloaihd.enable();}" />
                    <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();nbfHeSo.reset();
                               #{Button2}.show(); #{txtmaloaihd}.setValue(''); hdfCommand.setValue('');
                               #{txtTenLoaiHopDong}.reset();#{txtThoiGian}.reset();
                               #{txtGhiChu}.reset();Ext.net.DirectMethods.ResetWindowTitle();" />
                </Listeners>
            </ext:Window>
            <ext:Store ID="Store1" AutoLoad="true" runat="server">
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="HopDongHandler.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="={0}" />
                    <ext:Parameter Name="limit" Value="={30}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MA_LOAI_HDONG">
                        <Fields>
                            <ext:RecordField Name="MA_LOAI_HDONG" />
                            <ext:RecordField Name="TEN_LOAI_HDONG" />
                            <ext:RecordField Name="GHI_CHU" />
                            <ext:RecordField Name="THOI_HAN_HOPDONG" />
                            <ext:RecordField Name="HE_SO" /> 
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                                Icon="ApplicationViewColumns" TrackMouseOver="true" AutoExpandColumn="TEN_LOAI_HDONG"
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
                                                EmptyTex="Nhập từ khóa tìm kiếm" ID="txtSearch">
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
                                        <ext:RowNumbererColumn Locked="true" Width="35" Header="STT" />
                                        <ext:Column ColumnID="MA_LOAI_HDONG" Header="Mã" Width="100" Sortable="true" DataIndex="MA_LOAI_HDONG">
                                        </ext:Column>
                                        <ext:Column ColumnID="TEN_LOAI_HDONG" Header="Tên loại hợp đồng" Width="50" Sortable="true"
                                            DataIndex="TEN_LOAI_HDONG">
                                        </ext:Column>
                                        <ext:Column Header="Hệ số" Align="Right" DataIndex="HE_SO" Width="60"></ext:Column>
                                        <ext:Column ColumnID="THOI_HAN_HOPDONG" Align="Right" Header="Thời hạn hợp đồng"
                                            Width="120" Sortable="true" DataIndex="THOI_HAN_HOPDONG">
                                            <Renderer Fn="RenderTime" />
                                        </ext:Column>
                                        <ext:Column ColumnID="GHI_CHU" Header="Loại hợp đồng" Width="100" Sortable="true"
                                            DataIndex="GHI_CHU">
                                        </ext:Column>
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
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <Listeners>
                                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                    <DblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();
                               #{Button2}.hide();" />
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
