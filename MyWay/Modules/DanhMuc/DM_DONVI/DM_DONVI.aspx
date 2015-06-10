<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DM_DONVI.aspx.cs" Inherits="Modules_DanhMuc_DM_DONVI_DM_DONVI" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .list-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #ddd;
            white-space: normal;
            color: #000;
        }

        #sortable {
            list-style-type: none;
            margin: 20px auto;
            padding: 0;
            width: 60%;
            text-align: left;
        }

            #sortable li {
                margin: 10px 3px 3px;
                padding: 3px;
                border: solid 1px #ccc;
                font-family: Arial;
                font-size: 11px;
                cursor: move;
                background-color: #F9F9F9;
                font-weight: bold;
            }

       div#tgDonVi .x-tree-node .x-tree-selected {
            background: #dfe8f6 !important;
        }

           div#tgDonVi .x-tree-node .x-tree-selected span,div#tgDonVi .x-tree-node .x-tree-node-over span {
                color: #000 !important;
            }

       div#tgDonVi .x-tree-node .x-tree-node-over {
            background: #efefef !important; 
            color:#000 !important
        }
    </style>
    <script src="../../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <script src="../../../Resource/js/jquery.ui.core.min.js" type="text/javascript"></script>
    <script src="../../../Resource/js/jquery.ui.widget.min.js" type="text/javascript"></script>
    <script src="../../../Resource/js/jquery.ui.mouse.min.js" type="text/javascript"></script>
    <script src="../../../Resource/js/jquery.ui.sortable.min.js" type="text/javascript"></script>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                tgDonVi.getRootNode().reload();
            }
        }
        function nodeLoad(node) {
            Ext.net.DirectMethods.NodeLoad(node.id, {
                success: function (result) {
                    var data = eval("(" + result + ")");
                    node.loadNodes(data);
                },
                failure: function (errorMsg) {
                    Ext.Msg.alert('Failure', errorMsg);
                }
            });
        }
        var RemoveItemOnGrid = function (grid) {
            Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
                if (btn == "yes") {
                    if (hdfRecordID.getValue() == "") {
                        alert('Bạn chưa chọn bản ghi cần xóa');
                        return false;
                    }
                    try {
                        grid.getRowEditor().stopEditing();
                    }
                    catch (e) {

                    }
                    var id = hdfRecordID.getValue().toString();
                    Ext.net.DirectMethods.DeleteNode(id);

                    try {
                        btnEdit.disable();
                        btnDelete.disable();
                    }
                    catch (e) { }
                    return true;
                }
            });
        }
        var CheckInputDonVi = function () {
            if (txtMaDonVi.getValue().trim() == '') {
                alert('Bạn chưa nhập mã đơn vị');
                txtMaDonVi.focus();
                return false;
            }
            if (txtTenDonVi.getValue().trim() == '') {
                alert('Bạn chưa nhập tên đơn vị');
                txtTenDonVi.focus();
                return false;
            }
            if (cbxDonViCapCha.getValue() == '') {
                alert('Bạn chưa chọn đơn vị cấp cha');
                cbxDonViCapCha.focus();
                return false;
            }
            return true;
        }
        var ResetWindow = function () {
            txtMaDonVi.reset(); txtTenVietTat.reset(); txtTenDonVi.reset(); txtTenTienAnh.reset();
            txtDiaChi.reset(); cbxDonViCapCha.reset(); txtSoDT.reset(); txtGiamDoc.reset();
            txtMaSoThue.reset(); txtFax.reset(); txtKeToanTruong.reset(); txtSoTaiKhoan.reset();
            txtNganHang.reset();
        }
        var BeforeAddNew = function () {
            if (hdfRecordID.getValue() != '') {
                cbxDonViCapCha.setValue(hdfRecordID.getValue());
            }
            btnCapNhat.show();
            btnUpdate.hide();
            btnCapNhatVaDongLai.show();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM">
                <Listeners>
                    <DocumentReady Handler="cbxDonViCapCha_Store.reload();" />
                </Listeners>
            </ext:ResourceManager>
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfNodeOrder" />
            <ext:Hidden runat="server" ID="hdfIsChange" Text="False" />
            <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
                Padding="6" Constrain="false" Title="Nhập khóa chính mới" Hidden="true" Icon="KeyAdd"
                runat="server" AutoHeight="true">
                <Items>
                    <ext:TextField FieldLabel="Nhập mã" runat="server" ID="txtmacoppy" MaxLength="20"
                        MaxLengthText="Bạn chỉ được phép nhập tối đa 20 kí tự" AnchorHorizontal="100%">
                    </ext:TextField>
                </Items>
                <Buttons>
                    <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                        <Listeners>
                            <Click Handler="if(txtmacoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmacoppy.focus();return false;}" />
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
                    <Hide Handler="txtmacoppy.reset();" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" ID="wdAddWindow" Icon="Add" Padding="6" Title="Thêm mới một đơn vị"
                Layout="FormLayout" Width="600" AutoHeight="true" Hidden="true" Resizable="false" Constrain="true" Modal="true">
                <Items>
                    <ext:Container runat="server" Layout="ColumnLayout" AnchorHorizontal="100%" AutoHeight="true">
                        <Items>
                            <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout" Height="27">
                                <Items>
                                    <ext:TextField runat="server" CtCls="requiredData" ID="txtMaDonVi" AnchorHorizontal="98%" MaxLength="20"
                                        FieldLabel="Mã đơn vị<span style='color:red;'>*</span>" AllowBlank="false" MaskRe="[^,]" />
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout" Height="27">
                                <Items>
                                    <ext:TextField runat="server" ID="txtTenVietTat" AnchorHorizontal="98%" MaxLength="50"
                                        FieldLabel="Tên viết tắt" AllowBlank="true" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:TextField runat="server" ID="txtTenDonVi" CtCls="requiredData" AnchorHorizontal="99%" MaxLength="100"
                        FieldLabel="Tên đơn vị<span style='color:red;'>*</span>" />
                    <ext:TextField runat="server" ID="txtTenTienAnh" AnchorHorizontal="99%" MaxLength="100"
                        FieldLabel="Tên tiếng Anh" />
                    <ext:TextArea runat="server" ID="txtDiaChi" AnchorHorizontal="99%" MaxLength="500"
                        FieldLabel="Địa chỉ" />
                    <ext:ComboBox runat="server" ID="cbxDonViCapCha" FieldLabel="Đơn vị cấp cha<span style='color:red;'>*</span>" DisplayField="TEN_DONVI"
                        ValueField="MA_DONVI" AnchorHorizontal="99%" CtCls="requiredData" ItemSelector="div.list-item" Editable="false"
                        AllowBlank="false">
                        <Template ID="Template3" runat="server">
                            <Html>
                                <tpl for=".">
						        <div class="list-item"> 
							        {TEN_DONVI}
						        </div>
					        </tpl>
                            </Html>
                        </Template>
                        <Store>
                            <ext:Store runat="server" ID="cbxDonViCapCha_Store" AutoLoad="False" OnRefreshData="cbxDonViCapCha_Store_OnRefreshData">
                                <Reader>
                                    <ext:JsonReader IDProperty="MA_DONVI">
                                        <Fields>
                                            <ext:RecordField Name="MA_DONVI" />
                                            <ext:RecordField Name="TEN_DONVI" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <Listeners>
                            <Expand Handler="cbxDonViCapCha_Store.reload();" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:Container runat="server" Layout="ColumnLayout" AnchorHorizontal="100%" AutoHeight="true">
                        <Items>
                            <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout" Height="105">
                                <Items>
                                    <ext:TextField runat="server" ID="txtSoDT" AnchorHorizontal="98%" FieldLabel="Số điện thoại"
                                        MaxLength="50" />
                                    <ext:TextField runat="server" ID="txtGiamDoc" AnchorHorizontal="98%" FieldLabel="Giám đốc"
                                        MaxLength="50" />
                                    <ext:TextField runat="server" ID="txtMaSoThue" AnchorHorizontal="98%" FieldLabel="Mã số thuế"
                                        MaxLength="50" />
                                    <ext:Container runat="server" />
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" ColumnWidth="0.5" Layout="FormLayout" Height="105">
                                <Items>
                                    <ext:TextField runat="server" ID="txtFax" AnchorHorizontal="98%" FieldLabel="Fax"
                                        MaxLength="50" />
                                    <ext:TextField runat="server" ID="txtKeToanTruong" AnchorHorizontal="98%" FieldLabel="Kế toán trưởng"
                                        MaxLength="50" />
                                    <ext:TextField runat="server" ID="txtSoTaiKhoan" AnchorHorizontal="98%" FieldLabel="Số tài khoản"
                                        MaxLength="50" />
                                    <ext:TextField runat="server" ID="txtNganHang" AnchorHorizontal="98%" FieldLabel="Ngân hàng"
                                        MaxLength="50" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnCapNhat" Icon="Disk" Text="Cập nhật">
                        <Listeners>
                            <Click Handler="return CheckInputDonVi();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Closed" Value="False" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnUpdate" Icon="Disk" Text="Cập nhật">
                        <Listeners>
                            <Click Handler="return CheckInputDonVi();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Command" Value="Edit" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnCapNhatVaDongLai" Icon="Disk" Text="Cập nhật và đóng lại">
                        <Listeners>
                            <Click Handler="return CheckInputDonVi();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhat_Click">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Closed" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnDongLai" Icon="Decline" Text="Đóng lại">
                        <Listeners>
                            <Click Handler="#{wdAddWindow}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetWindow();Ext.net.DirectMethods.ResetWindowTitle();" />
                </Listeners>
            </ext:Window>
            <ext:Menu ID="mnuDonVi" runat="server">
                <Items>
                    <ext:MenuItem ID="mnuAdd" runat="server" Icon="Add" Text="Thêm mới">
                        <Listeners>
                            <Click Handler="BeforeAddNew(); #{wdAddWindow}.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                        <Listeners>
                            <Click Handler="#{btnCapNhat}.hide();#{btnCapNhatVaDongLai}.hide();#{btnUpdate}.show();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnEdit_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuItem ID="MnuDelete" runat="server" Icon="Delete" Text="Xóa">
                        <Listeners>
                            <Click Handler="RemoveItemOnGrid(#{tgDonVi});" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuSeparator />
                    <ext:MenuItem ID="mnuOrder" runat="server" Icon="SortAscending" Text="Sắp xếp thứ tự">
                        <DirectEvents>
                            <Click OnEvent="btnSort_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Window ID="wdSortAscending" runat="server" Icon="SortAscending" Width="500"
                Modal="false" Height="400" Title="Sắp xếp thứ tự đơn vị" Hidden="true">
                <TopBar>
                    <ext:Toolbar runat="server">
                        <Items>
                            <ext:Button Text="Cập nhật" runat="server" Icon="Disk" ID="btnSaveOrderedMenu">
                                <DirectEvents>
                                    <Click OnEvent="btnSaveOrderedMenu_Click">
                                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                        <ExtraParams>
                                            <ext:Parameter Name="order" Value="$('#sortable').sortable('toArray').toString()"
                                                Mode="Raw">
                                            </ext:Parameter>
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                                <Listeners>
                                    <Click Handler="wdSortAscending.hide();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Content>
                    <div style="background: #DFE8F6;">
                        <ext:Label runat="server" ID="lblOutput" />
                    </div>
                </Content>
            </ext:Window>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:TreeGrid ID="tgDonVi" runat="server" StripeRows="true" TrackMouseOver="true"
                                AnchorHorizontal="100%" NoLeafIcon="false" AutoExpandColumn="TEN_DONVI" AutoExpandMin="150"
                                EnableDD="false" Border="false" Animate="true" ContainerScroll="true" UseArrows="true"
                                EnableSort="false">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="Toolbar1">
                                        <Items>
                                            <ext:Button ID="btnAdd" runat="server" Text="Thêm mới" Icon="Add">
                                                <Listeners>
                                                    <Click Handler="BeforeAddNew(); #{wdAddWindow}.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                                <Listeners>
                                                    <Click Handler="#{btnCapNhat}.hide();#{btnCapNhatVaDongLai}.hide();#{btnUpdate}.show();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnEdit_Click">
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                                <Listeners>
                                                    <Click Handler="RemoveItemOnGrid(#{tgDonVi});" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                                            <ext:Button ID="Button1" runat="server" Text="Tiện ích" Icon="Build" Hidden="true">
                                                <Menu>
                                                    <ext:Menu ID="Menu1" runat="server">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Disabled="true" ID="MnuNhanDoi" Text="Nhân đôi dữ liệu"
                                                                Icon="DiskMultiple">
                                                                <Listeners>
                                                                    <Click Handler="#{wdInputNewPrimaryKey}.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnSort" Text="Sắp xếp" Icon="SortAscending" Hidden="false">
                                                <Listeners>
                                                    <Click Handler="if (hdfRecordID.getValue() == '')
                                                {
                                                    alert('Bạn chưa chọn đơn vị nào');
                                                    return false;
                                                }" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnSort_Click">
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" Text="Tải lại dữ liệu" Icon="Reload">
                                                <Listeners>
                                                    <Click Handler="#{tgDonVi}.getRootNode().reload();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarFill runat="server" ID="tbfill" />
                                            <ext:TextField runat="server" Width="200" EnableKeyEvents="true" Text="" ID="txtSearch" Hidden="true">
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch" Hidden="true">
                                                <Listeners>
                                                    <Click Handler="#{tgDonVi}.getRootNode().reload();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Columns>
                                    <ext:TreeGridColumn Header="Tên đơn vị" Width="150" DataIndex="TEN_DONVI">
                                    </ext:TreeGridColumn>
                                    <ext:TreeGridColumn Header="Mã đơn vị" Width="80" DataIndex="MA_DONVI" />
                                    <ext:TreeGridColumn Header="Tên viết tắt" Width="150" DataIndex="TEN_TAT" />
                                    <ext:TreeGridColumn Header="Tên tiếng Anh" Width="150" DataIndex="TEN_DONVI_EN" />
                                    <ext:TreeGridColumn Header="Địa chỉ" Width="150" DataIndex="DIA_CHI" />
                                </Columns>
                                <Root>
                                    <ext:AsyncTreeNode NodeID="0" Text="Root" />
                                </Root>
                                <SelectionModel>
                                    <ext:DefaultSelectionModel runat="server" ID="DefaultSelectionModel1">
                                        <Listeners>
                                            <SelectionChange Handler="#{hdfRecordID}.setValue(node.id);#{btnEdit}.enable();#{btnDelete}.enable();#{MnuNhanDoi}.enable(); " />
                                        </Listeners>
                                    </ext:DefaultSelectionModel>
                                </SelectionModel>
                                <Listeners>
                                    <BeforeLoad Fn="nodeLoad" />
                                    <ContextMenu Handler="e.preventDefault();#{mnuDonVi}.node = node;node.select();#{mnuDonVi}.showAt(e.getXY());" />
                                </Listeners>
                                <DirectEvents>
                                    <DblClick OnEvent="btnEdit_Click" Before="#{btnCapNhat}.hide();#{btnCapNhatVaDongLai}.hide();#{btnUpdate}.show();">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                    </DblClick>
                                </DirectEvents>
                            </ext:TreeGrid>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
