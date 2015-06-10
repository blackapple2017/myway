<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DanhMucPhuCapPhucLoi.aspx.cs"
    Inherits="Modules_DanhMuc_DanhMucPhuCapPhucLoi" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head id="Head1" runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                Store1.reload();
            }
        }
        var RenderKyHieu = function (value, p, record) {
            return "<b style='color:blue;'>" + value + "</b>";
        }
        var RendererPhanTram = function (value) {
            if (value != null) {
                return value + " %";
            }
            return "";
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
                        Ext.net.DirectMethods.DeleteRecord(r.data.ID);
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

        //        addUpdatedRecord = function (kyhieu_tt_lamviec, ten_tt_lamviec, dien_giai, stt, created_user, date_create, is_in_used, qui_uoc_cham_cong) {
        //            var rowindex = getSelectedIndexRow();
        //            //xóa bản ghi cũ
        //            var s = GridPanel1.getSelectionModel().getSelections();
        //            for (var i = 0, r; r = s[i]; i++) {
        //                Store1.remove(r);
        //                Store1.commitChanges();
        //            }
        //            //Thêm bản ghi đã update
        //            GridPanel1.insertRecord(rowindex, {
        //                KYHIEU_TT_LAMVIEC: kyhieu_tt_lamviec,
        //                TEN_TT_LAMVIEC: ten_tt_lamviec,
        //                DIEN_GIAI: dien_giai,
        //                STT: stt,
        //                CREATED_USER: created_user,
        //                DATE_CREATE: date_create,
        //                IS_IN_USED: is_in_used,
        //                QUI_UOC_CHAM_CONG: qui_uoc_cham_cong
        //            });
        //            GridPanel1.getView().refresh();
        //            GridPanel1.getSelectionModel().selectRow(rowindex);
        //            Store1.commitChanges();
        //        }

        //        var addRecord = function (kyhieu_tt_lamviec, ten_tt_lamviec, dien_giai, stt, created_user, date_create, is_in_used, qui_uoc_cham_cong, prkey) {
        //            var rowindex = getSelectedIndexRow();
        //            GridPanel1.insertRecord(rowindex, {
        //                PR_KEY: prkey,
        //                KYHIEU_TT_LAMVIEC: kyhieu_tt_lamviec,
        //                TEN_TT_LAMVIEC: ten_tt_lamviec,
        //                DIEN_GIAI: dien_giai,
        //                STT: stt,
        //                CREATED_USER: created_user,
        //                DATE_CREATE: date_create,
        //                IS_IN_USED: is_in_used,
        //                QUI_UOC_CHAM_CONG: qui_uoc_cham_cong
        //            });
        //            GridPanel1.getView().refresh();
        //            GridPanel1.getSelectionModel().selectRow(rowindex);
        //            Store1.commitChanges();
        //        }

        var CheckInput = function () {

            if (txtTenPhuCap.getValue() == '') {
                alert("Bạn chưa nhập tên phụ cấp");
                return false;
            }
            if (!cbbLaPhuCap.getValue()) {
                alert("Bạn chưa chọn loại phụ cấp");
                return false;
            }
            return true;
        }

        var resetWindowHide = function () {
            txtTenPhuCap.reset(); txtSoTien.reset(); txtHeSo.reset(); cbbNhomLoaiPhuCap.reset(); cbbLaPhuCap.reset(); ckTinhVaoBH.setValue(false);
        }
    </script>
    <style type="text/css">
        .list-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }
    </style>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM">
            </ext:ResourceManager>
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Menu ID="RowContextMenu" runat="server">
                <Items>
                    <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                        <Listeners>
                            <Click Handler="#{wdAddWindow}.show();" />
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
                    <ext:MenuItem ID="mnuDelete" runat="server" Icon="Delete" Text="Xóa">
                        <Listeners>
                            <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                        </Listeners>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới phụ cấp phúc lợi"
                Icon="Add" LabelWidth="120">
                <Items>
                    <ext:Hidden runat="server" ID="hdfCommand" />
                    <ext:TextField runat="server" ID="txtTenPhuCap" AnchorHorizontal="99%" FieldLabel="Tên phụ cấp<span style='color:red;'>*</span>">
                    </ext:TextField>
                    <ext:TextField runat="server" ID="txtSoTien" AnchorHorizontal="99%" FieldLabel="Số tiền"
                        MaskRe="/[0-9\.]/">
                    </ext:TextField>
                    <ext:TextField runat="server" ID="txtHeSo" AnchorHorizontal="99%" FieldLabel="Hệ số"
                        MaskRe="/[0-9\.]/">
                    </ext:TextField>
                    <ext:TextField runat="server" ID="txtPhanTram" AnchorHorizontal="99%" FieldLabel="Phần trăm"
                        MaskRe="/[0-9\.]/" MaxLength="5" EmptyText="Giá trị từ 0-> 100%">
                    </ext:TextField>
                    <ext:Hidden runat="server" ID="hdfNhomLoaiPhuCap" />
                    <ext:ComboBox runat="server" ID="cbbNhomLoaiPhuCap" FieldLabel="Nhóm loại phụ cấp"
                        DisplayField="TEN" ValueField="MA" AnchorHorizontal="99%" Editable="false" ItemSelector="div.list-item">
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
                            <ext:Store runat="server" ID="StoreNhomLoaiPhuCap" AutoLoad="false" OnRefreshData="StoreNhomLoaiPhuCap_Refresh">
                                <Reader>
                                    <ext:JsonReader IDProperty="MA">
                                        <Fields>
                                            <ext:RecordField Name="MA" />
                                            <ext:RecordField Name="TEN" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <Listeners>
                            <Expand Handler="StoreNhomLoaiPhuCap.reload();" />
                            <Select Handler="this.triggers[0].show(); hdfNhomLoaiPhuCap.setValue(cbbNhomLoaiPhuCap.getValue());" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfNhomLoaiPhuCap.reset(); }" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:ComboBox runat="server" ID="cbbLaPhuCap" FieldLabel="Là phụ cấp<span style='color:red;'>*</span>"
                        AnchorHorizontal="99%" Editable="false">
                        <Items>
                            <ext:ListItem Value="0" Text="Không phải là phụ cấp" />
                            <ext:ListItem Value="1" Text="Là phụ cấp" />
                        </Items>
                    </ext:ComboBox>
                    <ext:Checkbox runat="server" ID="ckTinhVaoBH" BoxLabel="Phụ cấp được tính vào Bảo hiểm" />
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInput(); Ext.net.DirectMethods.Reset;" />
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
                               #{Button2}.show(); resetWindowHide();" />
                </Listeners>
            </ext:Window>
            <ext:Store ID="Store1" AutoLoad="true" runat="server">
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="HandlerDanhMucPhuCapPhucLoi.ashx" />
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
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="Ten" />
                            <ext:RecordField Name="IsPhuCap" />
                            <ext:RecordField Name="SoTien" />
                            <ext:RecordField Name="HeSo" />
                            <ext:RecordField Name="PhanTram" />
                            <ext:RecordField Name="NhomLoaiPhuCap" />
                            <ext:RecordField Name="TinhVaoBH" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                                Icon="ApplicationViewColumns" AutoExpandColumn="Ten" TrackMouseOver="false" AnchorHorizontal="100%">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                                <Listeners>
                                                    <%--   <Click Handler="#{wdAddWindow}.show();" />--%>
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="Reset">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="Them" Value="True">
                                                            </ext:Parameter>
                                                        </ExtraParams>
                                                    </Click>
                                                </DirectEvents>
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
                                            <ext:ToolbarSeparator runat="server" />
                                            <%--  <ext:Button runat="server" Text="Trợ giúp" Icon="Help">
                                        </ext:Button>--%>
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
                                        <ext:Column ColumnID="colTen" DataIndex="Ten" Header="Tên" Width="250">
                                        </ext:Column>
                                        <ext:Column ColumnID="colIsPhuCap" DataIndex="IsPhuCap" Header="Là Phụ cấp" Width="70">
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colSoTien" DataIndex="SoTien" Header="Số tiền" Width="70">
                                            <Renderer Fn="RenderVND" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colHeSo" DataIndex="HeSo" Header="Hệ số" Width="70" Align="Right">
                                        </ext:Column>
                                        <ext:Column ColumnID="colPhanTram" DataIndex="PhanTram" Header="Phần trăm" Width="70" Align="Right">
                                            <Renderer Fn="RendererPhanTram" />
                                        </ext:Column>
                                        <ext:Column ColumnID="colNhomLoaiPhuCap" DataIndex="NhomLoaiPhuCap" Header="Nhóm loại phụ cấp"
                                            Width="200" Align="Left">
                                        </ext:Column>
                                        <ext:CheckColumn ColumnID="colTinhVaoBH" DataIndex="TinhVaoBH" Header="Tính vào bảo hiểm"
                                            Width="65" Align="Center">
                                        </ext:CheckColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                        <Listeners>
                                            <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);" />
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
                                    <DblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                                </Listeners>
                            </ext:GridPanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
