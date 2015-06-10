<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuyDinhBienDong.ascx.cs"
    Inherits="Modules_BaoHiem_QuyDinhChung_QuyDinhBienDong" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    var enterKeyPressHandler3 = function (f, e) {
        if (e.getKey() == e.ENTER) {
            //            QuyDinhBienDong1_Store1.reload();
            QuyDinhBienDong1_PagingToolbar1.pageIndex = 0;
            QuyDinhBienDong1_PagingToolbar1.doLoad();
        }
        if (this.getValue() != '') {
            this.triggers[0].show();
        }
    }
    var GenLoaiAnhHuong = function (value, p, record) {
        if (value == "TLD")
            return "Tăng lao động";
        if (value == "GLD")
            return "Giảm lao động";
        if (value == "TMD")
            return "Tăng mức đóng";
        if (value == "GMD")
            return "Giảm mức đóng";
        if (value == "TruyThu")
            return "Truy thu";
        if (value == "ThoaiThu")
            return "Thoái thu";
    }
    var RemoveItemOnGrid1 = function (grid, Store, DirectMethods) {
        Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
            if (btn == "yes") {
                try {
                    grid.getRowEditor().stopEditing();
                } catch (e) {

                }
                var s = grid.getSelectionModel().getSelections();

                for (var i = 0, r; r = s[i]; i++) {
                    DirectMethods.DeleteRecord(r.data.IDQuyDinhBienDong);
                    Store.remove(r);
                    Store.commitChanges();
                    QuyDinhBienDong1_btnEdit.disable();
                    QuyDinhBienDong1_btnDelete.disable();
                }
            }
        });
    }

    var getSelectedIndexRow = function () {
        var record = QuyDinhBienDong1_GridPanel1.getSelectionModel().getSelected();
        var index = QuyDinhBienDong1_GridPanel1.store.indexOf(record);
        if (index == -1)
            return 0;
        return index;
    }
    var CheckInput = function () {

        if (QuyDinhBienDong1_txtMaBienDong.getValue() == '') {
            alert("Bạn chưa nhập mã biến động");
            QuyDinhBienDong1_txtMaBienDong.focus();
            return false;
        }
        if (QuyDinhBienDong1_txtTenBienDong.getValue() == '') {
            alert("Bạn chưa nhập tên biến động");
            QuyDinhBienDong1_txtTenBienDong.focus();
            return false;
        }
        if (QuyDinhBienDong1_cboloaianhhuong.getValue() == '') {
            alert("Bạn chưa chọn loại ảnh hưởng");
            QuyDinhBienDong1_cboloaianhhuong.focus();
            return false;
        }


        return true;
    }

    var resetWindowHide = function () {
        QuyDinhBienDong1_txtMaBienDong.reset();
        QuyDinhBienDong1_txtTenBienDong.reset();
        QuyDinhBienDong1_cboloaianhhuong.reset();
        QuyDinhBienDong1_cboCheDoBH.reset();
        alert('hello');
    }
    var NhanDoiDuLieu = function () {
        Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn nhân đôi dữ liệu?', function (btn) {
            if (btn == "yes") {
                try {
                    Ext.net.DirectMethods.NhanDoiDuLieuTuTang();
                } catch (e) {

                }
            }
        });
    }

    var CheckSelectedRecord = function (grid, Store) {

        var s = grid.getSelectionModel().getSelections();
        var count = 0;
        for (var i = 0, r; r = s[i]; i++) {
            count++;
        }
        if (count > 1) {
            alert('Bạn chỉ được chọn một dòng');
            return false;
        }
        return true;
    }
</script>
<div>
    <ext:Hidden runat="server" ID="hdfRecordID" />
    <ext:Hidden runat="server" ID="hdfMaDonVi">
    </ext:Hidden>
    <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
        Padding="6" Constrain="false" Title="Nhập khóa chính mới" Hidden="true" Icon="Add"
        runat="server" AutoHeight="true">
        <Items>
            <ext:TextField FieldLabel="Nhập mã" runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="100%">
            </ext:TextField>
        </Items>
        <Listeners>
            <Hide Handler="#{txtmaloaihdcoppy}.reset();" />
        </Listeners>
        <Buttons>
            <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                <Listeners>
                    <Click Handler="if(#{txtmaloaihdcoppy}.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnOK_Click">
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Thoát">
                <Listeners>
                    <Click Handler="#{wdInputNewPrimaryKey}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <Hide Handler="#{txtmaloaihdcoppy}.reset();" />
        </Listeners>
    </ext:Window>
    <ext:Menu ID="RowContextMenu" runat="server">
        <Items>
            <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                <Listeners>
                    <Click Handler="#{wdAddWindow}.show();#{txtMaBienDong}.enable();" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem4" runat="server" Icon="Delete" Text="Xóa">
                <Listeners>
                    <Click Handler="RemoveItemOnGrid1(#{GridPanel1},#{Store1},#{DirectMethods})" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                <Listeners>
                    <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();#{txtMaBienDong}.disable();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnEdit_Click">
                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    </Click>
                </DirectEvents>
            </ext:MenuItem>
            <ext:MenuSeparator runat="server" ID="mnuDuplicate" />
        </Items>
    </ext:Menu>
    <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
        Width="500" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới quy định biến động bảo hiểm"
        Icon="Add">
        <Items>
            <ext:Hidden runat="server" ID="hdfCommand" />
            <ext:TextField runat="server" ID="txtMaBienDong" FieldLabel="Mã biến động<span style='color:red;'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%">
            </ext:TextField>
            <ext:TextField runat="server" ID="txtTenBienDong" FieldLabel="Tên biến động<span style='color:red;'>*</span>"
                CtCls="requiredData" AnchorHorizontal="100%">
            </ext:TextField>
            <ext:ComboBox runat="server" ID="cboloaianhhuong" FieldLabel="Loại ảnh hưởng<span style='color:red;'>*</span>"
                CtCls="requiredData" AnchorHorizontal="99%" Editable="false">
                <Items>
                    <ext:ListItem Value="TLD" Text="Tăng lao động" />
                    <ext:ListItem Value="GLD" Text="Giảm lao động" />
                    <ext:ListItem Value="TMD" Text="Tăng mức đóng" />
                    <ext:ListItem Value="GMD" Text="Giảm mức đóng" />
                    <ext:ListItem Value="TruyThu" Text="Truy thu" />
                    <ext:ListItem Value="ThoaiThu" Text="Thoái thu" />
                </Items>
            </ext:ComboBox>
            <ext:ComboBox runat="server" ID="cboCheDoBH" FieldLabel="Chế độ bảo hiểm" AnchorHorizontal="99%"
                ValueField="IDCheDoBaoHiem" DisplayField="TenCheDoBaoHiem" Editable="false" Hidden="true">
                <Store>
                    <ext:Store runat="server" ID="Store_cboCheDoBH" OnRefreshData="Store_cboCheDoBH_OnRefreshData"
                        AutoLoad="false">
                        <Reader>
                            <ext:JsonReader IDProperty="IDCheDoBaoHiem">
                                <Fields>
                                    <ext:RecordField Name="IDCheDoBaoHiem">
                                    </ext:RecordField>
                                    <ext:RecordField Name="TenCheDoBaoHiem">
                                    </ext:RecordField>
                                </Fields>
                            </ext:JsonReader>
                        </Reader>
                    </ext:Store>
                </Store>
            </ext:ComboBox>
            <ext:Container runat="server" Layout="ContainerLayout" AnchorVertical="100%">
                <Items>
                    <ext:Container runat="server" Layout="ColumnLayout" ColumnWidth="1">
                        <Items>
                            <ext:Checkbox ID="chkIsIsBHXH" BoxLabel="Bảo hiểm XH" runat="server" Width="100" />
                            <ext:Checkbox ID="chkIsIsBHYT" BoxLabel="Bảo hiểm YT" runat="server" Width="100" />
                            <ext:Checkbox ID="chkIsIsBHTN" BoxLabel="Bảo hiểm TN" runat="server" Width="100" />
                            <ext:Checkbox ID="chkIsDangSuDung" BoxLabel="Đang sử dụng" runat="server" Width="100" />
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
                    <Click OnEvent="btnCapNhat_Click" After="QuyDinhBienDong1_txtMaBienDong.reset();
        QuyDinhBienDong1_txtTenBienDong.reset();
        QuyDinhBienDong1_cboloaianhhuong.reset();
        QuyDinhBienDong1_cboCheDoBH.reset();QuyDinhBienDong1_chkIsIsBHXH.reset();QuyDinhBienDong1_chkIsIsBHYT.reset();
        QuyDinhBienDong1_chkIsIsBHTN.reset();QuyDinhBienDong1_chkIsDangSuDung.reset();">
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
            <BeforeShow Handler="#{Store_cboCheDoBH}.reload();" />
            <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
             QuyDinhBienDong1_txtMaBienDong.reset();
        QuyDinhBienDong1_txtTenBienDong.reset();
        QuyDinhBienDong1_cboloaianhhuong.reset();
        QuyDinhBienDong1_cboCheDoBH.reset();QuyDinhBienDong1_chkIsIsBHXH.reset();QuyDinhBienDong1_chkIsIsBHYT.reset();
        QuyDinhBienDong1_chkIsIsBHTN.reset();QuyDinhBienDong1_chkIsDangSuDung.reset();
                               #{Button2}.show(); #{DirectMethods}.ResetWindowTitle();" />
        </Listeners>
    </ext:Window>
    <ext:Store ID="Store1" AutoLoad="true" runat="server">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="HandlerBHQUYDINHBIENDONG.ashx" />
        </Proxy>
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={30}" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
            <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonvi}.getValue()" Mode="Raw" />
        </BaseParams>
        <Reader>
            <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="IDQuyDinhBienDong">
                <Fields>
                    <ext:RecordField Name="IDQuyDinhBienDong" />
                    <ext:RecordField Name="MaBienDong" />
                    <ext:RecordField Name="TenBienDong" />
                    <ext:RecordField Name="LoaiAnhHuong" />
                    <ext:RecordField Name="TenCheDoBaoHiem" />
                    <ext:RecordField Name="IsBHXH" />
                    <ext:RecordField Name="IsBHYT" />
                    <ext:RecordField Name="IsBHTN" />
                    <ext:RecordField Name="DangSuDung" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:BorderLayout runat="server" ID="brlayout">
        <Center>
            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                Icon="ApplicationViewColumns" TrackMouseOver="false" AutoExpandColumn="TenBienDong"
                AnchorHorizontal="100%">
                <TopBar>
                    <ext:Toolbar runat="server" ID="tb">
                        <Items>
                            <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{wdAddWindow}.show();#{txtMaBienDong}.enable();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                <Listeners>
                                    <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();#{txtMaBienDong}.disable();" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnEdit_Click">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                <Listeners>
                                    <Click Handler="RemoveItemOnGrid1(#{GridPanel1},#{Store1},#{DirectMethods})" />
                                </Listeners>
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                            <ext:ToolbarFill runat="server" ID="tbfill" />
                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                EmptyTex="Nhập từ khóa tìm kiếm" ID="txtSearch">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <KeyPress Fn="enterKeyPressHandler3" />
                                    <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:TriggerField>
                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                <Listeners>
                                    <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                        <ext:Column ColumnID="IDQuyDinhBienDong" Header="Mã biến động" DataIndex="MaBienDong" />
                        <ext:Column ColumnID="TenBienDong" Header="Tên biến động BH" DataIndex="TenBienDong" />
                        <ext:Column ColumnID="LoaiAnhHuong" Header="Loại ảnh hưởng" DataIndex="LoaiAnhHuong">
                            <Renderer Fn="GenLoaiAnhHuong" />
                        </ext:Column>
                        <%--<ext:Column ColumnID="TenCheDoBaoHiem" Header="Tên chế độ bảo hiểm" DataIndex="TenCheDoBaoHiem"
                            Width="160" />--%>
                        <ext:CheckColumn ColumnID="IsBHXH" Header="Bảo hiểm xã hội" DataIndex="IsBHXH" Align="Center" />
                        <ext:CheckColumn ColumnID="IsBHYT" Header="Bảo hiểm y tế" DataIndex="IsBHYT" />
                        <ext:CheckColumn ColumnID="IsBHTN" Header="Bảo hiểm thất nghiệp" DataIndex="IsBHTN"
                            Width="120" />
                        <ext:CheckColumn ColumnID="DangSuDung" Header="Được sử dụng" DataIndex="DangSuDung" />
                    </Columns>
                </ColumnModel>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                        <Listeners>
                            <RowSelect Handler="#{hdfRecordID}.setValue(#{checkboxSelection}.getSelected().id);#{btnEdit}.enable();#{btnDelete}.enable();" />
                            <RowDeselect Handler="#{hdfRecordID}.reset();#{btnEdit}.disable();#{btnDelete}.disable();" />
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
                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue());#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                        <Listeners>
                            <Change Handler="#{checkboxSelection}.clearSelections();" />
                        </Listeners>
                    </ext:PagingToolbar>
                </BottomBar>
                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                <Listeners>
                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                    <DblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();#{txtMaBienDong}.disable();" />
                </Listeners>
                <DirectEvents>
                    <DblClick OnEvent="btnEdit_Click">
                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    </DblClick>
                </DirectEvents>
            </ext:GridPanel>
        </Center>
    </ext:BorderLayout>
</div>
