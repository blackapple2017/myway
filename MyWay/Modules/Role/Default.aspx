<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modules_Role_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <title></title>
    <link rel="stylesheet" href="Resource/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="Resource/gettheme.js"></script>
    <script type="text/javascript" src="Resource/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="Resource/jqxcore.js"></script>
    <script type="text/javascript" src="Resource/jqxbuttons.js"></script>
    <script type="text/javascript" src="Resource/jqxscrollbar.js"></script>
    <script type="text/javascript" src="Resource/jqxpanel.js"></script>
    <script type="text/javascript" src="Resource/jqxtree.js"></script>
    <script type="text/javascript" src="Resource/jqxcheckbox.js"></script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <style type="text/css">
        .x-layout-split
        {
            background: #DFE8F6 !important;
            border: 1px solid #99BBE8 !important;
            border-bottom: none !important;
            border-top: none !important;
        }
        
        .jqx-tree-dropdown-root
        {
            padding-top: 10px !important;
            min-width: 90% !important;
            width: 90% !important;
        }
        
        #jqxTree
        {
            width: 90% !important;
        }
        
        #paneljqxTree
        {
            width: 100% !important;
        }
        
        #paneljqxTreeverticalScrollBar
        {
            left: auto !important;
            right: 0 !important;
        }
        
        .jqx-widget-content
        {
            border-color: #FFFFFF !important;
        }
    </style>
    <script type="text/javascript">
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
                        //   alert(r.data.ID);
                        Ext.net.DirectMethods.DeleteRole(r.data.ID);
                        btnDeleteRole.disable();
                        btnEditRole.disable();
                        Store.commitChanges();
                    }
                }
            });
        }

        var validate = function () {
            if (hdfRecordID.getValue() == '') { alert('Bạn chưa chọn quyền !'); return false; }
            if (cbMenuList.getValue() == '') {
                alert('Bạn chưa chọn phân hệ nào !');
                return false;
            }
            return true;
        }

        var reloadTabPhanVungDuLieu = function () {
            if (tabPanel.getActiveTab().id == "pnlDepartment") {
                grpDepartmentStore.reload();
            }
        }

        $(document).ready(function () {
            // Create jqxTree 
            var theme = getDemoTheme();
            // create jqxTree
            var h = $(window).height() - 55;
            $('#jqxTree').jqxTree({ height: h + 'px', hasThreeStates: true, checkboxes: true, width: '400px', theme: theme });
            $('#jqxCheckBox').jqxCheckBox({ width: '200px', height: '25px', checked: true, theme: theme });
            $('#jqxCheckBox').on('change', function (event) {
                var checked = event.args.checked;
                $('#jqxTree').jqxTree({ hasThreeStates: checked });
            });

            //Sự kiện select trên Tree
            $('#jqxTree').on('select', function (event) {
                var args = event.args;
                var item = $('#jqxTree').jqxTree('getItem', args.element);
                var label = item.label;
                //  alert(label + "  " + args.element.id);
                var div = document.getElementById("functionTree" + args.element.id);
                $(".functionTree").css("display", "none");
                if (div != null) {
                    div.style.display = 'block';
                }
            });
        });

        //Chọn tất cả các node trên function tree
        function CheckAllFunction() {
            try {
                var item = $('#jqxTree').jqxTree('getSelectedItem');
                $('#functionTree' + item.id).jqxTree('checkAll');
            } catch (e) {

            }
        }
        //Hủy chọn tất cả các node trên function tree
        function UnCheckAllFunction() {
            try {
                var item = $('#jqxTree').jqxTree('getSelectedItem');
                $('#functionTree' + item.id).jqxTree('uncheckAll');
            } catch (e) {

            }
        }
        /*
        Lấy các menu và function được chọn
        */
        function getSelectedNode() {
            if (hdfRecordID.getValue() == '') {
                Ext.Msg.alert('Thông báo', 'Bạn chưa chọn quyền !');
                return false;
            }
            //Lấy các menu được check
            var items = $('#jqxTree').jqxTree('getItems');
            var rs = "";       // các node được checked
            var undefinedNode = "";
            var selectedFunction = "";      // các node được chọn (checked + undefined)
            for (var i = 0; i < items.length; i++) {
                if (items[i].checked != false) {
                    if (items[i].checked == null) {
                        undefinedNode += items[i].element.id + ",";
                        selectedFunction += getSelectedFuntion(items[i].element.id);
                    }
                    else {
                        rs += items[i].element.id + ",";
                        selectedFunction += getSelectedFuntion(items[i].element.id);
                    }
                }
            }
            Ext.net.DirectMethods.UpdateRoleForMenu(rs, undefinedNode, selectedFunction);
        }
        //Lay cac function dc chon
        function getSelectedFuntion(menuID) {
            var functionList = $("#functionTree" + menuID).jqxTree('getItems');
            var rs = "";
            try {
                for (var i = 0; i < functionList.length; i++) {
                    if (functionList[i].checked == null) {
                        rs += functionList[i].element.id.replace("F", "") + ";" + "True,";     // Dang (ID; IsUndefined),... (0 hoặc 1)
                    }
                    else if (functionList[i].checked == true) {
                        rs += functionList[i].element.id.replace("F", "") + ";" + "False,";
                    }
                }
            } catch (e) {

            }
            return rs;
        }

        /*
        Sự kiện được gọi khi người dùng click vào tên quyền trên grid thì sẽ tiến hành
        check các menu và function trên tree
        */
        function checkItem() {
            //Tiến hành check các node của menu
            $('#jqxTree').jqxTree('uncheckAll');
            var arr = hdfMenusOfRole.getValue().split(',');
            for (var i = 0; i < arr.length; i++) {
                if (arr[i].length != 0) {
                    $("#jqxTree").jqxTree('checkItem', $("#" + arr[i])[0], true);
                }
            }

            //Tiến hành check các node của function
            $(".functionTree").css("display", "none"); //ẩn tree function
            $('.functionTree').jqxTree('uncheckAll'); //hủy check
            var arr2 = hdfFunctionOfMenu.getValue().split(',');
            for (var i = 0; i < arr2.length; i++) {
                try {
                    var arr3 = arr2[i].split(';');
                    if (arr3[1].toString() == 'False') {
                        $(".functionTree").jqxTree('checkItem', $("#F" + arr3[0])[0], true); //Thêm F vào vì ID của funtion có chữ F đầu tiên
                    }
                } catch (e) {

                }
            }
        }

    </script>
    <script type="text/javascript">
        $(document).ready(function () {
            // Create jqxTree 
            var theme = getDemoTheme();
            // create jqxTree
            $('.functionTree').jqxTree({ height: '400px', hasThreeStates: true, checkboxes: true, width: '330px', theme: theme });
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager ID="RM" runat="server" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfMenusOfRole" />
        <ext:Hidden runat="server" ID="hdfFunctionOfMenu" />
        <ext:Window ID="wdAddRole" runat="server" Border="false" Padding="0" Icon="KeyAdd"
            Constrain="true" Width="460" Modal="true" Maximizable="false" Resizable="false"
            AutoHeight="true" Title="Thêm mới quyền" Hidden="true">
            <Items>
                <ext:Panel ID="Panel1" runat="server" Frame="true" Padding="6" Border="false" Layout="FormLayout">
                    <Items>
                        <ext:Hidden runat="server" ID="txtRoleCommand" />
                        <ext:TextField runat="server" ID="txtRoleName" CtCls="requiredData" FieldLabel="Tên quyền<span style='color:red'>*</span>"
                            AnchorHorizontal="100%" />
                        <ext:TextArea ID="txtDescription" runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%"
                            Height="110" EmptyText="Thông tin mô tả quyền..." />
                    </Items>
                </ext:Panel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Hidden="true" ID="btnDuplicateRole" Text="Đồng ý nhân đôi"
                    Icon="Disk">
                    <DirectEvents>
                        <Click OnEvent="btnDuplicateRole_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" AnchorHorizontal="center" Text="Cập nhật" Icon="Disk"
                    ID="btnUpdateRole">
                    <Listeners>
                        <Click Handler="if(#{txtRoleName}.getValue().trim()=='')
                                        {
                                           alert('Bạn chưa nhập tên quyền');#{txtRoleName}.focus();return false;
                                        } 
                                        " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateRole_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" AnchorHorizontal="center" Text="Cập nhật & Đóng lại" Icon="Disk"
                    ID="Button2">
                    <Listeners>
                        <Click Handler="if(#{txtRoleName}.getValue().trim()=='')
                                        {
                                           alert('Bạn chưa nhập tên quyền');#{txtRoleCommand}.focus();return false;
                                        } 
                                        " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateRole_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Hidden="true" AnchorHorizontal="center" Text="Cập nhật"
                    Icon="Disk" ID="btnEdit">
                    <Listeners>
                        <Click Handler="if(#{txtRoleName}.getValue().trim()=='')
                                        {
                                           alert('Bạn chưa nhập tên quyền');#{txtRoleCommand}.focus();return false;
                                        } 
                                        " />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnUpdateRole_Click">
                            <EventMask ShowMask="true" Msg="Đang cập nhật dữ liệu..." />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                                <ext:Parameter Name="Close" Value="True" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdAddRole}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="if(txtRoleCommand.getValue()=='Update'){
                                        btnUpdateRole.hide();Button2.hide();btnEdit.show();
                                    }" />
                <Hide Handler="txtRoleName.reset();txtDescription.reset();txtRoleCommand.reset();btnDuplicateRole.hide();btnUpdateRole.show();Button2.show();
                               btnUpdateRole.show();Button2.show();btnEdit.hide();Ext.net.DirectMethods.ResetWindowTitle();" />
            </Listeners>
        </ext:Window>
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem ID="mnuAddRole" runat="server" Icon="Add" Text="Thêm quyền">
                    <Listeners>
                        <Click Handler="wdAddRole.show();" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuItem ID="mnuUpdateRole" runat="server" Icon="Pencil" Text="Sửa"> 
                    <DirectEvents>
                        <Click OnEvent="btnEditRole_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="MnuDeleteRole" runat="server" Icon="Delete" Text="Xóa">
                    <Listeners>
                        <Click Handler="RemoveItemOnGrid(GridPanel1,Store1);" />
                    </Listeners>
                </ext:MenuItem>
                <ext:MenuSeparator />
                <ext:MenuItem ID="mnuDuplicateData" runat="server" Icon="DiskMultiple" Text="Nhân đôi dữ liệu">
                    <Listeners>
                        <Click Handler="wdAddRole.setTitle('Nhân đôi quyền');btnDuplicateRole.show();btnUpdateRole.hide();Button2.hide();wdAddRole.show();" />
                    </Listeners> 
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <ext:Viewport runat="server">
            <Items>
                <ext:ColumnLayout runat="server" FitHeight="true" Split="true" ID="br">
                    <Columns>
                        <ext:LayoutColumn ColumnWidth="0.4">
                            <ext:GridPanel ID="GridPanel1" FireSelectOnLoad="true" Border="false" AutoExpandColumn="RoleName"
                                runat="server">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:Button runat="server" Text="Thêm quyền" Icon="KeyAdd" ID="btnAddKey">
                                                <Listeners>
                                                    <Click Handler="wdAddRole.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" Text="Sửa" Icon="Pencil" Disabled="true" ID="btnEditRole">
                                                <DirectEvents>
                                                    <Click OnEvent="btnEditRole_Click">
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" Text="Xóa" Icon="Delete" Disabled="true" ID="btnDeleteRole">
                                                <Listeners>
                                                    <Click Handler="RemoveItemOnGrid(GridPanel1,Store1);" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarSeparator runat="server" ID="sp" />
                                            <ext:Button runat="server" Text="Nhân đôi dữ liệu" Icon="DiskMultiple">
                                                <Listeners>
                                                    <Click Handler="wdAddRole.setTitle('Nhân đôi quyền');btnDuplicateRole.show();btnUpdateRole.hide();Button2.hide();wdAddRole.show();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store ID="Store1" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="Handler.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={5}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader Root="Data" IDProperty="ID" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="RoleName" />
                                                    <ext:RecordField Name="CreatedOn" />
                                                    <ext:RecordField Name="Description" />
                                                    <ext:RecordField Name="IsDeleted" />
                                                    <ext:RecordField Name="CreatedOn" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="30" Locked="true" />
                                        <ext:Column Header="Mã quyền" DataIndex="ID" Locked="true" Width="60" />
                                        <ext:TemplateColumn Header="Tên quyền" ColumnID="RoleName" Width="220">
                                            <Template runat="server">
                                                <Html>
                                                    <div style="line-height: 18px;">
                                                        <b>{RoleName}</b><br />
                                                        <i>{Description}</i>
                                                    </div>
                                                </Html>
                                            </Template>
                                        </ext:TemplateColumn>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" SingleSelect="true" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="#{hdfRecordID}.setValue(#{RowSelectionModel1}.getSelected().id);Ext.net.DirectMethods.LoadMenuOfRole();
                                                                btnDeleteRole.enable();btnEditRole.enable();btnLuuThietLap.enable();reloadTabPhanVungDuLieu();
                                                               " />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                        PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                        DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <Listeners>
                                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                </Listeners>
                                <LoadMask ShowMask="true" />
                                <DirectEvents>
                                    <DblClick OnEvent="btnEditRole_Click">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                    </DblClick>
                                </DirectEvents>
                            </ext:GridPanel>
                        </ext:LayoutColumn>
                        <ext:LayoutColumn ColumnWidth="0.5">
                            <ext:TabPanel ID="tabPanel" Border="false" runat="server">
                                <Items>
                                    <ext:Panel ID="Panel3" Title="Danh sách chức năng" Border="false" runat="server">
                                        <Items>
                                            <ext:ColumnLayout ID="ColumnLayout1" runat="server" Split="true" FitHeight="true">
                                                <Columns>
                                                    <ext:LayoutColumn ColumnWidth="0.5">
                                                        <ext:Panel ID="Panel5" runat="server" Border="false">
                                                            <TopBar>
                                                                <ext:Toolbar runat="server" ID="tbds">
                                                                    <Items>
                                                                        <ext:Button runat="server" Disabled="true" ID="btnLuuThietLap" Text="Lưu thiết lập"
                                                                            Icon="Disk">
                                                                            <Listeners>
                                                                                <Click Handler="getSelectedNode();" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                    </Items>
                                                                </ext:Toolbar>
                                                            </TopBar>
                                                            <Content>
                                                                <div id='jqxWidget'>
                                                                    <div id='jqxTree' style='float: left; margin-left: 20px;'>
                                                                        <ul>
                                                                            <li id="5000">Bàn làm việc
                                                                                <ul>
                                                                                    <li id="5001">Biểu đồ
                                                                                        <ul>
                                                                                            <li id="5002">Loại biểu đồ
                                                                                                <ul>
                                                                                                    <li id="5003">Biểu đồ giới tính</li>
                                                                                                    <li id="5004">Biểu đồ trình độ</li>
                                                                                                    <li id="5008">Biểu đồ quốc tịch</li>
                                                                                                    <li id="5009">Thống kê theo tình trạng hôn nhân</li>
                                                                                                    <li id="5010">Biểu đồ tôn giáo</li>
                                                                                                    <li id="5011">Biểu đồ dân tộc</li>
                                                                                                    <li id="5012">Biểu đồ loại hợp đồng</li>
                                                                                                    <li id="5028">Biểu đồ tỉnh thành</li>
                                                                                                    <li id="5029">Biểu đồ chức vụ đoàn</li>
                                                                                                    <li id="5030">Biểu đồ chức vụ đảng</li>
                                                                                                    <li id="5031">Biểu đồ chức vụ quân đội</li>
                                                                                                    <li id="5026">Biểu đồ phòng ban</li>
                                                                                                    <li id="5027">Thống kê theo thâm niên công tác</li>
                                                                                                    <li id="5040">Thống kê lý do nghỉ việc</li>
                                                                                                    <li id="5005">Biểu đồ biến động nhân sự</li>
                                                                                                    <li id="5006">Biểu đồ độ tuổi</li>
                                                                                                    <li id="5007">Thống kê nhân sự theo đơn vị</li>
                                                                                                </ul>
                                                                                            </li>
                                                                                            <li id="5013">Đặt làm biểu đồ mặc định</li>
                                                                                        </ul>
                                                                                    </li> 
                                                                                    <li id="5015">Tra cứu nhanh thông tin nhân viên
                                                                                        <ul>
                                                                                            <li id="5016">Báo cáo</li>
                                                                                            <li id="5017">Gửi Email</li>
                                                                                            <li id="5100">Không hiển thị nút</li>
                                                                                        </ul>
                                                                                    </li>
                                                                                    <li id="5018">Sinh nhật nhân viên
                                                                                        <ul>
                                                                                            <li id="5019">In danh sách</li>
                                                                                            <li id="5020">Ẩn in danh sách</li>
                                                                                        </ul>
                                                                                    </li>
                                                                                    <li id="5021">Nhân viên sắp hết hợp đồng
                                                                                        <ul>
                                                                                            <li id="5022">In danh sách</li>
                                                                                            <li id="5023">Ẩn in danh sách</li>
                                                                                        </ul>
                                                                                    </li>
                                                                                </ul>
                                                                            </li>
                                                                            <asp:Literal runat="server" ID="ldlMenuTree" />
                                                                            <li id="6000">Hệ thống
                                                                                <ul>
                                                                                    <li id="6001">Danh mục quyền </li>
                                                                                    <li id="6002">Quản trị người dùng </li>
                                                                                    <li id="6003">Cấu hình thông tin hệ thống</li>
                                                                                    <li id="6004">Nhật ký truy cập </li>
                                                                                </ul>
                                                                            </li>
                                                                            <li id="6005">Menu phải(Menu chức năng)
                                                                                <ul>
                                                                                    <li id="6006">Thêm menu con</li>
                                                                                    <li id="6007">Thêm menu cùng cấp</li>
                                                                                    <li id="6008">Sửa</li>
                                                                                    <li id="6009">Xóa</li>
                                                                                    <li id="6010">Sắp xếp</li>
                                                                                    <li id="6011">Xác định, phân quyền chức năng</li>
                                                                                </ul>
                                                                            </li>
                                                                        </ul>
                                                                    </div>
                                                                </div>
                                                            </Content>
                                                        </ext:Panel>
                                                    </ext:LayoutColumn>
                                                    <ext:LayoutColumn ColumnWidth="0.5">
                                                        <ext:Panel ID="Panel2" Border="false" runat="server">
                                                            <TopBar>
                                                                <ext:Toolbar runat="server" ID="tbdscn">
                                                                    <Items>
                                                                        <ext:Button ID="Button3" runat="server" Text="Chọn tất cả" Icon="BulletTick">
                                                                            <Listeners>
                                                                                <Click Handler="CheckAllFunction()" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                        <ext:Button ID="Button4" runat="server" Text="Hủy chọn tất cả" Icon="BulletCross">
                                                                            <Listeners>
                                                                                <Click Handler="UnCheckAllFunction()" />
                                                                            </Listeners>
                                                                        </ext:Button>
                                                                    </Items>
                                                                </ext:Toolbar>
                                                            </TopBar>
                                                            <Content>
                                                                <asp:Literal runat="server" ID="Literal1" />
                                                            </Content>
                                                        </ext:Panel>
                                                    </ext:LayoutColumn>
                                                </Columns>
                                            </ext:ColumnLayout>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel runat="server" ID="pnlDepartment" Layout="BorderLayout" Title="Phân vùng dữ liệu theo bộ phận">
                                        <Listeners>
                                            <Activate Handler="if(hdfCurrentRoleID.getValue()!=hdfRecordID.getValue()){
                                                                    grpDepartmentStore.reload();
                                                                    hdfCurrentRoleID.setValue(hdfRecordID.getValue());
                                                               }" />
                                        </Listeners>
                                        <Items>
                                            <ext:Hidden runat="server" ID="hdfCurrentRoleID" />
                                            <ext:GridPanel ID="grpDepartment" ClicksToEdit="1" TrackMouseOver="true" runat="server"
                                                StripeRows="true" Region="Center" Border="false">
                                                <Store>
                                                    <ext:Store ID="grpDepartmentStore" OnRefreshData="grpDepartmentStore_OnRefreshData"
                                                        AutoLoad="false" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="MA">
                                                                <Fields>
                                                                    <ext:RecordField Name="MA" />
                                                                    <ext:RecordField Name="TEN" />
                                                                    <ext:RecordField Name="Check" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ToolTips>
                                                    <ext:ToolTip runat="server" Title="Hướng dẫn" Html="Nhấp đúp chuột để thiết lập hoặc hủy quyền">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <TopBar>
                                                    <ext:Toolbar runat="server" ID="tbb">
                                                        <Items>
                                                            <ext:ToolbarSpacer runat="server" Width="5" />
                                                            <ext:ComboBox ID="cbMenuList" DisplayField="MenuName" ValueField="ID" runat="server"
                                                                Width="260" Editable="false" LabelWidth="90" FieldLabel="Chọn phân hệ" ListWidth="250">
                                                                <Store>
                                                                    <ext:Store runat="server" ID="cbMenuListStore" OnRefreshData="cbMenuListStore_OnRefreshData"
                                                                        AutoLoad="false">
                                                                        <Reader>
                                                                            <ext:JsonReader IDProperty="ID">
                                                                                <Fields>
                                                                                    <ext:RecordField Name="MenuName" />
                                                                                    <ext:RecordField Name="ID" />
                                                                                </Fields>
                                                                            </ext:JsonReader>
                                                                        </Reader>
                                                                    </ext:Store>
                                                                </Store>
                                                                <Triggers>
                                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                                </Triggers>
                                                                <Listeners>
                                                                    <Expand Handler="if(cbMenuListStore.getCount()==0){cbMenuListStore.reload();}" />
                                                                    <Select Handler="this.triggers[0].show();grpDepartmentStore.reload();btnAllow.enable();btnDeny.enable();mnuDenyAll.enable();mnuAllowAll.enable();" />
                                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); grpDepartmentStore.reload();btnAllow.disable();btnDeny.disable();}" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                            <ext:Button runat="server" ID="btnAllow" Text="Cấp quyền" Disabled="true" Icon="Key">
                                                                <Menu>
                                                                    <ext:Menu runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="mnuAllowSelected" runat="server" Disabled="true" Text="Những bộ phận được chọn">
                                                                                <Listeners>
                                                                                    <Click Handler="return validate();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="btnAllow_Click">
                                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="Command" Value="AllowSelected" />
                                                                                        </ExtraParams>
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem runat="server" ID="mnuAllowAll" Disabled="true" Text="Tất cả">
                                                                                <Listeners>
                                                                                    <Click Handler="return validate();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="btnAllow_Click">
                                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:Button>
                                                            <ext:Button runat="server" ID="btnDeny" Text="Hủy quyền" Disabled="true" Icon="KeyDelete">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu1" runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="mnuDenySelected" runat="server" Disabled="true" Text="Những bộ phận được chọn">
                                                                                <Listeners>
                                                                                    <Click Handler="return validate();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="btnDeny_Click">
                                                                                        <ExtraParams>
                                                                                            <ext:Parameter Name="Command" Value="DenySelected" />
                                                                                        </ExtraParams>
                                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="mnuDenyAll" runat="server" Disabled="true" Text="Tất cả">
                                                                                <Listeners>
                                                                                    <Click Handler="return validate();" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="btnDeny_Click">
                                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </TopBar>
                                                <ColumnModel ID="ColumnModel2" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Width="30" />
                                                        <ext:Column Sortable="false" ColumnID="MA" Header="Mã bộ phận" Align="Right" Width="80"
                                                            DataIndex="MA" />
                                                        <ext:Column Sortable="false" ColumnID="Company" Header="Tên bộ phận" Width="260"
                                                            DataIndex="TEN" />
                                                        <ext:Column Sortable="false" Header="Quyền xem" Align="Center" Width="75" DataIndex="Check">
                                                            <Renderer Fn="GetBooleanIcon" />
                                                        </ext:Column>
                                                    </Columns>
                                                </ColumnModel>
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="RowSelectionModel2" runat="server">
                                                        <Listeners>
                                                            <RowSelect Handler="btnAllow.enable();btnDeny.enable();mnuAllowSelected.enable();mnuDenySelected.enable();" />
                                                        </Listeners>
                                                    </ext:RowSelectionModel>
                                                </SelectionModel>
                                                <Listeners>
                                                    <RowDblClick Handler="return validate();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <RowDblClick OnEvent="grpDepartment_RowDblClick">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="DepartmentID" Mode="Raw" Value="RowSelectionModel2.getSelected().id" />
                                                            <ext:Parameter Name="Checked" Mode="Raw" Value="RowSelectionModel2.getSelected().data.Check" />
                                                        </ExtraParams>
                                                    </RowDblClick>
                                                </DirectEvents>
                                                <Listeners>
                                                    <AfterEdit Handler="grpDepartmentStore.commitChanges();" />
                                                </Listeners>
                                                <LoadMask ShowMask="true" />
                                            </ext:GridPanel>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:TabPanel>
                        </ext:LayoutColumn>
                    </Columns>
                </ext:ColumnLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
