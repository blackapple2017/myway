<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_TT_LAMVIEC.aspx.cs" Inherits="Modules_DanhMuc_DM_TT_LAMVIEC" %>

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
            if (txtSearch.getValue() != '') {
                this.triggers[0].show();
            } else {
                this.triggers[0].hide();
            }
        }
        var RenderKyHieu = function (value, p, record) {
            return "<b style='color:blue;'>" + value + "</b>";
        }
        var RendererGroupSignal = function (value, p, record) {
            switch (value) {
                case "HLTV":
                    return "<span style='color:blue;'>Hưởng lương (thử việc)</span>";
                case "HL":
                    return "<span style='color:blue;'>Hưởng lương (chính thức)</span>";
                case "KL":
                    return "<span style='color:red;'>Không lương</span>";
                case "BHXH":
                    return "<span style='color:blue;'>Bảo hiểm xã hội</span>";
                case "NP":
                    return "<span style='color:blue;'>Nghỉ phép</span>";
                case "NB":
                    return "<span style='color:blue;'>Nghỉ bù</span>";
                default:
                    return ""
            }
        }
        var RendererSoNgayQuyDoi = function (value, p, record) {
            return "<b>" + value + "</b> ngày";
        }
        var RemoveItemOnGrid = function (grid, Store) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ? Nó có thể dẫn đến việc chấm công bị tính toán sai.', function (btn) {
                if (btn == "yes") {
                    try {
                        grid.getRowEditor().stopEditing();
                    } catch (e) {

                    }
                    var s = grid.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        Store.remove(r);
                        Store.commitChanges();
                        Ext.net.DirectMethods.DeleteRecord(r.data.PR_KEY);
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

        addUpdatedRecord = function (kyhieu_tt_lamviec, ten_tt_lamviec, dien_giai, stt, created_user, date_create, is_in_used, qui_uoc_cham_cong) {
            var rowindex = getSelectedIndexRow();
            //xóa bản ghi cũ
            var s = GridPanel1.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                Store1.remove(r);
                Store1.commitChanges();
            }
            //Thêm bản ghi đã update
            GridPanel1.insertRecord(rowindex, {
                KYHIEU_TT_LAMVIEC: kyhieu_tt_lamviec,
                TEN_TT_LAMVIEC: ten_tt_lamviec,
                DIEN_GIAI: dien_giai,
                STT: stt,
                CREATED_USER: created_user,
                DATE_CREATE: date_create,
                IS_IN_USED: is_in_used,
                QUI_UOC_CHAM_CONG: qui_uoc_cham_cong
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }

        var addRecord = function (kyhieu_tt_lamviec, ten_tt_lamviec, dien_giai, stt, created_user, date_create, is_in_used, qui_uoc_cham_cong, prkey) {
            var rowindex = getSelectedIndexRow();
            GridPanel1.insertRecord(rowindex, {
                PR_KEY: prkey,
                KYHIEU_TT_LAMVIEC: kyhieu_tt_lamviec,
                TEN_TT_LAMVIEC: ten_tt_lamviec,
                DIEN_GIAI: dien_giai,
                STT: stt,
                CREATED_USER: created_user,
                DATE_CREATE: date_create,
                IS_IN_USED: is_in_used,
                QUI_UOC_CHAM_CONG: qui_uoc_cham_cong
            });
            GridPanel1.getView().refresh();
            GridPanel1.getSelectionModel().selectRow(rowindex);
            Store1.commitChanges();
        }

        var CheckInput = function () {

            if (txtKYHIEU_TT_LAMVIEC.getValue() == '') {
                alert("Bạn chưa nhập kí hiệu chấm công");
                txtKYHIEU_TT_LAMVIEC.focus();
                return false;
            }
            if (txtTEN_TT_LAMVIEC.getValue() == '') {
                alert("Bạn chưa nhập diễn giải cho kí hiệu chấm công");
                txtTEN_TT_LAMVIEC.focus();
                return false;
            }
            return true;
        }

        var resetWindowHide = function () {
            txtKYHIEU_TT_LAMVIEC.reset();
            txtTEN_TT_LAMVIEC.reset();
            txtDIEN_GIAI.reset();
            txtSTT.reset();
            chkIsIS_IN_USED.reset();
            //txtQUI_UOC_CHAM_CONG.reset();
            nfSoCongHuong.reset();
            cbxNhomKyHieu.clear();
            cbxNhomKyHieu.reset();
        }
        var RenderQuiTacChamCong = function (value, p, record) {
            if (value == "NB") {
                return "<span style='color:blue;'>Nghỉ bù</span>";
            }
            if (value == "NKL") {
                return "<span style='color:blue;'>Nghỉ không lương</span>";
            }
            if (value == "NKL/2") {
                return "<span style='color:blue;'>Nghỉ nửa ngày không lương</span>";
            }
            if (value == "P") {
                return "<span style='color:blue;'>Nghỉ phép</span>";
            }
            if (value == "P/2") {
                return "<span style='color:blue;'>Nghỉ nửa ngày phép</span>";
            }
            if (value == "CD") {
                return "<span style='color:blue;'>Nghỉ theo chế độ</span>";
            }
            if (value == "O") {
                return "<span style='color:blue;'>Nghỉ ốm</span>";
            }
            if (value == "O/2") {
                return "<span style='color:blue;'>Nghỉ ốm nửa ngày</span>";
            }
            if (value == "VLD") {
                return "<span style='color:blue;'>Nghỉ vô lý do</span>";
            }
            return value;
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
            <ext:Menu ID="RowContextMenu" runat="server">
                <Items>
                    <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                        <Listeners>
                            <Click Handler="#{wdAddWindow}.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuDelete" runat="server" Icon="Delete" Text="Xóa">
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
                </Items>
            </ext:Menu>
            <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
                Width="530" Modal="true" Padding="6" LabelWidth="120" Constrain="true" ID="wdAddWindow"
                Title="Thêm mới kí hiệu chấm công" Icon="Add">
                <Items>
                    <ext:Hidden runat="server" ID="hdfCommand" />
                    <ext:Container runat="server" LabelWidth="120" Height="30" Layout="ColumnLayout">
                        <Items>
                            <ext:Container runat="server" Height="30" LabelWidth="120" Layout="FormLayout" ColumnWidth="0.45">
                                <Items>
                                    <ext:TextField runat="server" MaxLength="20" CtCls="requiredData" MaxLengthText="Bạn chỉ được nhập tối đa 20 kí tự"
                                        ID="txtKYHIEU_TT_LAMVIEC" FieldLabel="Ký hiệu<span style='color:red;'>*</span>" MaskRe="/[A-Z|a-z|\/|0-9\.]/"
                                        AnchorHorizontal="98%">
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.55">
                                <Items>
                                    <ext:NumberField ID="txtSTT" AllowDecimals="false" runat="server" FieldLabel="Số thứ tự" AnchorHorizontal="100%">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <%--<ext:ComboBox runat="server" SelectedIndex="0" Editable="false" ID="txtQUI_UOC_CHAM_CONG"
                        FieldLabel="Qui ước chấm công" AnchorHorizontal="100%">
                        <Items>
                            <ext:ListItem Text="Nghỉ bù" Value="NB" />
                            <ext:ListItem Text="Nghỉ không lương" Value="NKL" />
                            <ext:ListItem Text="Nghỉ nửa ngày không lương" Value="NKL/2" />
                            <ext:ListItem Text="Nghỉ phép" Value="P" />
                            <ext:ListItem Text="Nghỉ nửa ngày phép" Value="P/2" />
                            <ext:ListItem Text="Nghỉ theo chế độ" Value="CD" />
                            <ext:ListItem Text="Nghỉ ốm" Value="O" />
                            <ext:ListItem Text="Nghỉ ốm nửa ngày" Value="O/2" />
                            <ext:ListItem Text="Nghỉ vô lý do" Value="VLD" />
                        </Items>
                        <Listeners>
                            <Select Handler="txtTEN_TT_LAMVIEC.setValue(txtQUI_UOC_CHAM_CONG.getText());" />
                        </Listeners>
                    </ext:ComboBox>--%>
                    <ext:TextField runat="server" ID="txtTEN_TT_LAMVIEC" MaxLength="50" CtCls="requiredData"
                        MaxLengthText="Bạn chỉ được phép nhập tối đa 50 kí tự" FieldLabel="Diễn giải<span style='color:red;'>*</span>"
                        AnchorHorizontal="100%">
                    </ext:TextField>
                    <ext:Container runat="server" Layout="ColumnLayout" Height="30">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.45" LabelWidth="120">
                                <Items>
                                    <ext:NumberField runat="server" ID="nfSoCongHuong" FieldLabel="Số ngày quy đổi<span style='color:red'>*</span>" MaxLength="4" AnchorHorizontal="98%" CtCls="requiredData">
                                    </ext:NumberField>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.45">
                                <Items>
                                    <ext:ComboBox runat="server" SelectedIndex="0" Editable="false" ID="cbxNhomKyHieu"
                                        FieldLabel="Nhóm ký hiệu<span style='color:red'>*</span>" AnchorHorizontal="100%" CtCls="requiredData">
                                        <Items>
                                            <ext:ListItem Text="Hưởng lương (chính thức)" Value="HL" />
                                            <ext:ListItem Text="Hưởng lương (thử việc)" Value="HLTV" />
                                            <ext:ListItem Text="Nghỉ phép" Value="NP" />
                                            <ext:ListItem Text="Nghỉ bù" Value="NB" />
                                            <ext:ListItem Text="Không lương" Value="KL" />
                                            <ext:ListItem Text="Bảo hiểm xã hội" Value="BHXH" />
                                        </Items>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextArea Height="70" runat="server" ID="txtDIEN_GIAI" MaxLength="4000" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                    </ext:TextArea>
                    <ext:Checkbox ID="chkIsIS_IN_USED" Checked="true" FieldLabel="Tình trạng" BoxLabel="Đang được sử dụng"
                        runat="server" />
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
                    <BeforeShow Handler="if(hdfCommand.getValue()=='Update'){txtKYHIEU_TT_LAMVIEC.disable();}else{txtKYHIEU_TT_LAMVIEC.enable();}" />
                    <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show(); resetWindowHide(); Ext.net.DirectMethods.ResetWindowTitle();" />
                </Listeners>
            </ext:Window>
            <ext:Store ID="Store1" AutoLoad="true" runat="server">
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="HandlerDM_TT_LAMVIEC.ashx" />
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
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="PR_KEY">
                        <Fields>
                            <ext:RecordField Name="KYHIEU_TT_LAMVIEC" />
                            <ext:RecordField Name="TEN_TT_LAMVIEC" />
                            <ext:RecordField Name="DIEN_GIAI" />
                            <ext:RecordField Name="STT" />
                            <ext:RecordField Name="CREATED_USER" />
                            <ext:RecordField Name="DATE_CREATE" />
                            <ext:RecordField Name="IS_IN_USED" />
                            <ext:RecordField Name="QUI_UOC_CHAM_CONG" />
                            <ext:RecordField Name="PHANTRAM_HUONGLUONG" />
                            <ext:RecordField Name="SoCongHuongLuong" />
                            <ext:RecordField Name="NhomKyHieu" />
                            <ext:RecordField Name="PR_KEY" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                                Icon="ApplicationViewColumns" AutoExpandColumn="TEN_TT_LAMVIEC" TrackMouseOver="true"
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
                                            <ext:ToolbarFill runat="server" ID="tbfill" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                                                EmptyTex="Nhập từ khóa tìm kiếm" ID="txtSearch">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                    <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); GridPanel1.reload(); }" />
                                                </Listeners>
                                            </ext:TriggerField>
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
                                        <ext:Column ColumnID="KYHIEU_TT_LAMVIEC" Header="Kí hiệu" DataIndex="KYHIEU_TT_LAMVIEC">
                                            <Renderer Fn="RenderKyHieu" />
                                        </ext:Column>
                                        <ext:Column ColumnID="TEN_TT_LAMVIEC" Header="Diễn giải" DataIndex="TEN_TT_LAMVIEC" />
                                        <ext:Column ColumnID="DIEN_GIAI" Header="Ghi chú" Width="150" DataIndex="DIEN_GIAI" />
                                        <ext:Column ColumnID="STT" Header="Số thứ tự" DataIndex="STT" Width="85" Align="Right" />
                                        <%--<ext:Column ColumnID="QUI_UOC_CHAM_CONG" Width="200" Header="Qui ước chấm công" DataIndex="QUI_UOC_CHAM_CONG">
                                            <Renderer Fn="RenderQuiTacChamCong" />
                                        </ext:Column>--%>
                                        <ext:Column Header="Số ngày quy đổi" DataIndex="SoCongHuongLuong" Width="100" Align="Left">
                                            <Renderer Fn="RendererSoNgayQuyDoi" />
                                        </ext:Column>
                                        <ext:Column Header="Nhóm ký hiệu" DataIndex="NhomKyHieu" Width="160" Align="Left">
                                            <Renderer Fn="RendererGroupSignal" />
                                        </ext:Column>
                                        <ext:Column ColumnID="IS_IN_USED" Header="Đang sử dụng" Align="Center" DataIndex="IS_IN_USED">
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column ColumnID="CREATED_USER" Header="Người tạo" Width="150" DataIndex="CREATED_USER" />
                                        <ext:DateColumn Format="dd/MM/yyyy" ColumnID="Ngày tạo" Width="70" Header="Ngày tạo"
                                            DataIndex="DATE_CREATE" />
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
                                    <RowDblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
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
