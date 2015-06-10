<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_DOITACDAOTAO.aspx.cs"
    Inherits="Modules_DaoTao_DM_DOITACDAOTAO" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                grp_DonViPhuTrachDaoTaoStore.reload();
            }
        }

        var CheckSelectedRecord = function (grid, Store) {
            if (hdfRecordID.getValue() == '') {
                alert('Bạn chưa chọn dòng nào');
                return false;
            }

            var s = grid.getSelectionModel().getSelections();
            var count = 0;
            for (var i = 0, r; r = s[i]; i++) {
                count++;
            }
            if (count > 1) {
                alert('Bạn chỉ được chọn một đơn vị phụ trách');
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
                        Ext.net.DirectMethods.DeleteRecord(r.data.Ma);
                    }
                    Store.reload();
                }
            });
        }

        var getSelectedIndexRow = function () {
            var record = grp_DonViPhuTrachDaoTao.getSelectionModel().getSelected();
            var index = grp_DonViPhuTrachDaoTao.store.indexOf(record);
            if (index == -1)
                return 0;
            return index;
        }

        addUpdatedRecord = function (ma, ten, diachilienhe, trusochinh, fax, phone, email, website, ma_donvi, createduser) {
            var rowindex = getSelectedIndexRow();
            //xóa bản ghi cũ
            var s = grp_DonViPhuTrachDaoTao.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                grp_DonViPhuTrachDaoTaoStore.remove(r);
                grp_DonViPhuTrachDaoTaoStore.commitChanges();
            }
            //Thêm bản ghi đã update
            grp_DonViPhuTrachDaoTao.insertRecord(rowindex, {
                Ma: ma,
                Ten: ten,
                Phone: phone,
                Email: email,
                Fax: fax,
                DiaChiLienHe: diachilienhe,
                TruSoChinh: trusochinh,
                Website: website
            });
            grp_DonViPhuTrachDaoTao.getView().refresh();
            grp_DonViPhuTrachDaoTao.getSelectionModel().selectRow(rowindex);
            grp_DonViPhuTrachDaoTaoStore.commitChanges();
        }

        var addRecord = function (ma, ten, diachilienhe, trusochinh, fax, phone, email, website, ma_donvi, createduser) {
            var rowindex = getSelectedIndexRow();
            grp_DonViPhuTrachDaoTao.insertRecord(rowindex, {
                Ma: ma,
                Ten: ten,
                Phone: phone,
                Email: email,
                Fax: fax,
                DiaChiLienHe: diachilienhe,
                TruSoChinh: trusochinh,
                Website: website
            });
            grp_DonViPhuTrachDaoTao.getView().refresh();
            grp_DonViPhuTrachDaoTao.getSelectionModel().selectRow(rowindex);
            grp_DonViPhuTrachDaoTaoStore.commitChanges();
        }

        var CheckInput = function () {
            reg1 = /^[0-9A-Za-z]+[0-9A-Za-z_]*@[\w\d.]+.\w{2,4}$/;
            testmail = reg1.test(txtEmail.getValue());

            if (txtMa.getValue() == '') {
                alert("Bạn chưa nhập mã đối tác");
                txtMa.focus();
                return false;
            }
            if (txtTen.getValue() == '') {
                alert("Bạn chưa nhập tên đối tác");
                txtTen.focus();
                return false;
            }
            if (!testmail && txtEmail.getValue().trim() != '') {
                alert('Định dạng email chưa đúng !');
                txtEmail.focus();
                return false
            }
            return true;
        }

        var resetWindowHide = function () {
            txtMa.reset(); txtTen.reset(); txtDiaChiLienHe.reset(); txtTruSoChinh.reset(); txtFax.reset();
            txtPhone.reset(); txtEmail.reset(); txtWebsite.reset();
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
                <ext:MenuItem ID="mnuDelete" runat="server" Icon="Delete" Text="Xóa">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(grp_DonViPhuTrachDaoTao,grp_DonViPhuTrachDaoTaoStore)" />
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
            Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới thông tin đơn vị phụ trách đào tạo"
            Icon="Add">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommand" />
                <ext:TextField runat="server" ID="txtMa" AllowBlank="false" FieldLabel="Mã đơn vị<span style='color:red'>*</span>"
                    MaskRe="[0-9\.|a-z|A-Z]" CtCls="requiredData" AnchorHorizontal="50%" MaxLength="50">
                </ext:TextField>
                <ext:TextField runat="server" ID="txtTen" AllowBlank="false" FieldLabel="Tên đơn vị<span style='color:red'>*</span>"
                    CtCls="requiredData" AnchorHorizontal="100%" MaxLength="500">
                </ext:TextField>
                <ext:TextField runat="server" ID="txtDiaChiLienHe" FieldLabel="Địa chỉ" AnchorHorizontal="100%"
                    MaxLength="500">
                </ext:TextField>
                <ext:TextField runat="server" ID="txtTruSoChinh" FieldLabel="Trụ sở chính" AnchorHorizontal="100%"
                    MaxLength="500">
                </ext:TextField>
                <ext:Container runat="server" ID="ctq1" Layout="ColumnLayout" Height="50">
                    <Items>
                        <ext:Container runat="server" ID="c1" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtFax" MaskRe="/[0-9\.]/" FieldLabel="Fax" AnchorHorizontal="98%"
                                    MaxLength="20">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtEmail" FieldLabel="Email" AnchorHorizontal="98%"
                                    MaxLength="200" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                    RegexText="Định dạng email không đúng">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container8" ColumnWidth=".5" Layout="FormLayout">
                            <Items>
                                <ext:TextField runat="server" ID="txtPhone" MaskRe="/[0-9\.]/" FieldLabel="Điện thoại"
                                    AnchorHorizontal="100%" MaxLength="20">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtWebsite" FieldLabel="Website" AnchorHorizontal="100%"
                                    MaxLength="100">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
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
                        <Click Handler="#{wdAddWindow}.hide();resetWindowHide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show(); resetWindowHide(); Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="grp_DonViPhuTrachDaoTaoStore" AutoLoad="true" runat="server">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="HandlerDM_DOITACDAOTAO.ashx" />
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
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="Ma">
                    <Fields>
                        <ext:RecordField Name="Ma" />
                        <ext:RecordField Name="Ten" />
                        <ext:RecordField Name="Phone" />
                        <ext:RecordField Name="Email" />
                        <ext:RecordField Name="Fax" />
                        <ext:RecordField Name="DiaChiLienHe" />
                        <ext:RecordField Name="TruSoChinh" />
                        <ext:RecordField Name="Website" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="grp_DonViPhuTrachDaoTao" Border="false" runat="server" StoreID="grp_DonViPhuTrachDaoTaoStore"
                            StripeRows="true" Icon="ApplicationViewColumns" TrackMouseOver="false" AnchorHorizontal="100%">
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
                                                <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();return CheckSelectedRecord(#{grp_DonViPhuTrachDaoTao}, #{grp_DonViPhuTrachDaoTaoStore});" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnEdit_Click">
                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                            <Listeners>
                                                <Click Handler="RemoveItemOnGrid(grp_DonViPhuTrachDaoTao,grp_DonViPhuTrachDaoTaoStore);" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                        <ext:Button ID="btnTienIch" runat="server" Text="Tiện ích" Icon="Build">
                                            <Menu>
                                                <ext:Menu ID="Menu4" runat="server">
                                                    <Items>
                                                        <ext:MenuItem runat="server" Disabled="true" ID="mnuNhanDoiDuLieu" Text="Nhân đôi dữ liệu"
                                                            Icon="DiskMultiple">
                                                            <Listeners>
                                                                <Click Handler="if(CheckSelectedRecord(#{grp_DonViPhuTrachDaoTao}, #{grp_DonViPhuTrachDaoTaoStore})==false){return;}else{#{wdInputNewPrimaryKey}.show();}" />
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
                                                <Click Handler="#{grp_DonViPhuTrachDaoTaoStore}.reload();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Locked="true" Header="STT" />
                                    <ext:Column ColumnID="Ma" Width="70" Header="Mã đối tác" DataIndex="Ma" />
                                    <ext:Column ColumnID="Ten" Width="230" Header="Tên đối tác" DataIndex="Ten" />
                                    <ext:Column ColumnID="Phone" Width="90" Header="Điện thoại" DataIndex="Phone" />
                                    <ext:Column ColumnID="Email" Width="170" Header="Email" DataIndex="Email" />
                                    <ext:Column ColumnID="Fax" Width="80" Header="Fax" DataIndex="Fax" />
                                    <ext:Column ColumnID="DiaChiLienHe" Header="Địa chỉ liên hệ" Width="250" DataIndex="DiaChiLienHe" />
                                    <ext:Column ColumnID="TruSoChinh" Width="230" Header="Trụ sở chính" DataIndex="TruSoChinh" />
                                    <ext:Column ColumnID="Website" Width="170" Header="Website" DataIndex="Website" />
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
                                    <Listeners>
                                          <Change Handler="checkboxSelection.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <Listeners>
                                <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{grp_DonViPhuTrachDaoTao}.getSelectionModel().selectRow(rowIndex);" />
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
