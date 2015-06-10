<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangLuongDong.aspx.cs" Inherits="Modules_TienLuong_BangLuongDong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link rel="stylesheet" href="../Role/Resource/jqx.base.css" type="text/css" />
    <link href="../Report/Resource/Style.css" rel="stylesheet" />
    <script type="text/javascript" src="../Role/Resource/gettheme.js"></script>
    <script src="../Role/Resource/jquery-1.8.3.min.js" type="text/javascript"></script>
    <script type="text/javascript" src="../Role/Resource/jqxcore.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxbuttons.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxpanel.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxtree.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxcheckbox.js"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script src="Resource/BangLuongDong.js" type="text/javascript"></script>
    <asp:Literal runat="server" ID="ltrShowSettingDialog"></asp:Literal>
    <style type="text/css">
        .x-html-editor-wrap {
            border: none !important;
        }

        #grpSelectedReportFilter {
            border-left: 1px solid #99bbe8;
        }

        #grpReportFilter {
            border-right: 1px solid #99bbe8;
        }
    </style>
    <script type="text/javascript">
        function getSelectedNode() {
            //Lấy các menu được check
            var items = $('#jqxTree').jqxTree('getItems');
            var rs = "";       // các node được checked 
            var selectedFunction = "";      // các node được chọn (checked + undefined)
            var str = "";
            for (var i = 0; i < items.length; i++) {
                if (items[i].checked == true) {
                    rs += items[i].element.id + ",";
                    str += "["+ items[i].label +"]"+ ",";
                }
            }
            rs = rs.substring(0, rs.length -1);
            hdfMaDonVi.setValue(rs);
            str = str.substring(0, str.length - 1);
            cbChonPhongBan.setValue(str);
            txtTenBangTinhLuong.setValue('Bảng tính lương tháng ' + cbChonThang.getValue() + ' năm ' + spinChonNam.getValue() + ' tại bộ phận ' + cbChonPhongBan.getValue());
        }
        function UnCheckAllFunction() {
            try {
                var item = $('#jqxTree').jqxTree('getSelectedItem');
                $('#functionTree' + item.id).jqxTree('uncheckAll');
            } catch (e) {

            }
        }
        $(document).ready(function () {
            // Create jqxTree 
            var theme = getDemoTheme();
            // create jqxTree
            $('#jqxTree').jqxTree({ height: '400px', hasThreeStates: true, checkboxes: true, width: '385px', theme: theme });
            $('#jqxCheckBox').jqxCheckBox({ width: '200px', height: '25px', checked: true, theme: theme });
            $('#jqxCheckBox').on('change', function (event) {
                var checked = event.args.checked;
                $('#jqxTree').jqxTree({ hasThreeStates: checked });
            });
            $("#jqxTree").jqxTree('selectItem', $("#home")[0]);
        });
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfSessionDepartment" />
            <ext:Hidden runat="server" ID="hdfMenuID" />
            <ext:Hidden runat="server" ID="hdfIDBangLuong" />
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfIsLocked" />
            <ext:Hidden runat="server" ID="hdfMaDonViList" />
            <ext:Window runat="server" ID="wdChooseDepartment" Hidden="true" Icon="House" Constrain="true" Resizable="false"
                Modal="true" Title="Chọn bộ phận" Height="400" Width="400">
                <Content>
                    <div id='jqxWidget'>
                        <div style='float: left;'>
                            <div id='jqxTree' style='float: left;'>
                                <ul>
                                    <asp:Literal runat="server" ID="ldlMenuTree" />
                                </ul>
                            </div>
                </Content>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="getSelectedNode();wdChooseDepartment.hide();" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="UnCheckAllFunction();wdChooseDepartment.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" ID="wdThemBangTinhLuong" Modal="true" Hidden="true" Constrain="true"
                Title="Thêm bảng tính lương" Icon="Add" Layout="FormLayout" Width="500" AutoHeight="true"
                Padding="10" LabelWidth="120">
                <Items> 
                    <ext:TriggerField runat="server" ID="cbChonPhongBan" CtCls="requiredData" FieldLabel="Chọn bộ phận"
                        AnchorHorizontal="100%">
                        <Listeners>
                            <TriggerClick Handler="wdChooseDepartment.show();" />
                            <Focus Handler="wdChooseDepartment.show();" />
                        </Listeners>
                    </ext:TriggerField>
                    <%--<ext:DropDownField ID="Field3" runat="server" FieldLabel="Chọn bộ phận" Editable="false"
                        AnchorHorizontal="100%" TriggerIcon="SimpleArrowDown">
                        <Component>
                            <ext:TreePanel ID="TreePanel1" runat="server" Title="" Icon="Accept" Height="300"  
                                Shadow="None" UseArrows="true" AutoScroll="true" Animate="true" EnableDD="false"
                                ContainerScroll="true" RootVisible="false">
                                <Root>
                                </Root>
                                <Buttons>
                                    <ext:Button ID="Button2" runat="server" Text="<%$ Resources:CommonMessage, Close%>">
                                        <Listeners>
                                            <Click Handler="#{Field3}.collapse();" />
                                        </Listeners>
                                    </ext:Button>
                                </Buttons>
                                <Listeners>
                                   <Hide Handler="TreePanel1.uncheckAll();" />
                                    <CheckChange Handler="this.dropDownField.setValue(getTasks(this), false); hdfMaDonVi.setValue(getCheckedID(#{TreePanel1}));
                                            txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue() + ' tại bộ phận ' + Field3.getValue());" />
                                </Listeners>
                            </ext:TreePanel>
                        </Component>
                        <Listeners>
                            <Expand Handler="this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                        </Listeners>
                    </ext:DropDownField> --%>
                    <ext:CompositeField runat="server" ID="cf1" FieldLabel="Chọn tháng">
                        <Items>
                            <ext:ComboBox runat="server" Width="160" ID="cbChonThang" SelectedIndex="0" FieldLabel="Chọn tháng"
                                Editable="false" LabelWidth="60">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Listeners>
                                    <Select Handler="txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue() + ' tại bộ phận ' + cbChonPhongBan.getRawValue());" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField1" runat="server" Text="Chọn năm">
                                <Listeners>
                                </Listeners>
                            </ext:DisplayField>
                            <ext:SpinnerField ID="spinChonNam" runat="server" Width="60" MaxLength="4" MinLength="4">
                                <Listeners>
                                    <Spin Handler="txtTenBangTinhLuong.setValue('Bảng tính lương tháng '+cbChonThang.getValue()+' năm '+spinChonNam.getValue() + ' tại bộ phận ' + cbChonPhongBan.getRawValue());" />
                                </Listeners>
                            </ext:SpinnerField>
                        </Items>
                    </ext:CompositeField>
                    <ext:TextArea runat="server" ID="txtTenBangTinhLuong" AnchorHorizontal="100%" FieldLabel="Tên bảng tính lương" />
                    <ext:TextArea runat="server" ID="txtDescription" AnchorHorizontal="100%" FieldLabel="Mô tả" />
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnDongYThemBangTinh" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return ValidateAddSalaryBoard();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDongYThemBangTinhClick">
                                <EventMask Msg="Đang xử lý..." ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnUpdateEdit" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return ValidateAddSalaryBoard();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDongYThemBangTinhClick">
                                <EventMask ShowMask="true" />
                                <ExtraParams>
                                    <ext:Parameter Name="Edit" Value="True" />
                                </ExtraParams>
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnDongLaiThemBangTinh" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdThemBangTinhLuong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetFormAddSalaryBoard();" />
                </Listeners>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" ID="wdQuanLyBangTinhLuong"
                Constrain="true" Title="Quản lý bảng tính lương" Icon="Table" Layout="FormLayout"
                Width="700" AutoHeight="true">
                <Items>
                    <ext:Hidden runat="server" ID="hdfChosseBangLuong" />
                    <ext:GridPanel ID="grpDanhSachBangTinhLuong" runat="server" StripeRows="true" Border="false"
                        AnchorHorizontal="100%" Header="false" Height="350" Title="Danh sách bảng tính lương"
                        AutoExpandColumn="Title">
                        <TopBar>
                            <ext:Toolbar runat="server" ID="tbgr">
                                <Items>
                                    <ext:Button runat="server" ID="btnThemBangTinhLuong" Text="Thêm" Icon="Add">
                                        <Listeners>
                                            <Click Handler="btnDongYThemBangTinh.show(); btnUpdateEdit.hide(); wdThemBangTinhLuong.show();" />
                                        </Listeners>
                                    </ext:Button>
                                    <ext:Button runat="server" Disabled="true" ID="btnSuaBangTinhLuong" Text="Sửa" Icon="Pencil">
                                        <Listeners>
                                            <Click Handler="if (CheckSelectedRows(grpDanhSachBangTinhLuong) == false) {return false;}
                                                btnDongYThemBangTinh.hide(); btnUpdateEdit.show();" />
                                        </Listeners>
                                        <DirectEvents>
                                            <Click OnEvent="btnSuaBangTinhLuong_Click">
                                                <EventMask ShowMask="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                    <ext:Button runat="server" Text="Xóa" Icon="Delete" Disabled="true" ID="btnXoaBangTinhLuong">
                                        <Listeners>
                                            <Click Handler="if (CheckSelectedRows(grpDanhSachBangTinhLuong) == false) {return false;}" />
                                        </Listeners>
                                        <DirectEvents>
                                            <Click OnEvent="btnXoaBangTinhLuongClick">
                                                <Confirmation Title="Thông báo" Message="Bạn có chắc bạn muốn xóa bảng tính lương này?"
                                                    ConfirmRequest="true" />
                                            </Click>
                                        </DirectEvents>
                                    </ext:Button>
                                </Items>
                            </ext:Toolbar>
                        </TopBar>
                        <Store>
                            <ext:Store ID="grpDanhSachBangTinhLuongStore" AutoLoad="false" GroupField="Year"
                                runat="server">
                                <Proxy>
                                    <ext:HttpProxy Json="true" Method="GET" Url="Handler/DanhSachBangLuong.ashx" />
                                </Proxy>
                                <AutoLoadParams>
                                    <ext:Parameter Name="start" Value="={0}" />
                                    <ext:Parameter Name="limit" Value="={10}" />
                                </AutoLoadParams>
                                <BaseParams>
                                    <ext:Parameter Name="MaDonVi" Value="hdfSessionDepartment.getValue()" Mode="Raw" />
                                    <ext:Parameter Name="MenuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                                </BaseParams>
                                <Reader>
                                    <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                        <Fields>
                                            <ext:RecordField Name="ID" />
                                            <ext:RecordField Name="CreatedBy" />
                                            <ext:RecordField Name="CreatedDate" />
                                            <ext:RecordField Name="DaKhoa" />
                                            <ext:RecordField Name="Month" />
                                            <ext:RecordField Name="Year" />
                                            <ext:RecordField Name="Title" />
                                            <ext:RecordField Name="Description" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                                <Listeners>
                                    <Load Handler="RowSelectionModelBangTinhLuong.clearSelections();
                                    hdfChosseBangLuong.reset();" />
                                </Listeners>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel3" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Width="30" />
                                <ext:Column ColumnID="colTitle" Header="Tên bảng tính lương" Width="160" DataIndex="Title" />
                                <ext:Column ColumnID="colMonth" Header="Tháng" Width="70" DataIndex="Month" />
                                <ext:Column ColumnID="colYear" Header="Năm" Width="70" DataIndex="Year" />
                                <ext:Column ColumnID="colCreatedBy" Header="Người tạo" Width="100" DataIndex="CreatedBy" />
                                <ext:DateColumn ColumnID="colCreateDate" Header="Ngày tạo" Width="70" Format="dd/MM/yyyy"
                                    DataIndex="CreatedDate" />
                                <ext:Column ColumnID="colDaKhoa" Header="Khóa" Width="70" DataIndex="DaKhoa" Align="Center">
                                    <Renderer Fn="GetBooleanIcon" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <SelectionModel>
                            <ext:RowSelectionModel ID="RowSelectionModelBangTinhLuong" runat="server" SingleSelect="true">
                                <Listeners>
                                    <RowSelect Handler="try{btnSuaBangTinhLuong.enable();}catch(e){} 
                                            try{btnXoaBangTinhLuong.enable()}catch(e){}; 
                                            hdfChosseBangLuong.setValue(RowSelectionModelBangTinhLuong.getSelected().id);" />
                                    <RowDeselect Handler="try{btnSuaBangTinhLuong.disable();}catch(e){} 
                                            try{btnXoaBangTinhLuong.disable()}catch(e){}; 
                                            hdfChosseBangLuong.reset();" />
                                </Listeners>
                            </ext:RowSelectionModel>
                        </SelectionModel>
                        <View>
                            <ext:GroupingView runat="server" ID="gv" HideGroupedColumn="true">
                            </ext:GroupingView>
                        </View>
                        <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                        <BottomBar>
                            <ext:PagingToolbar ID="PagingToolbar2" runat="server" PageSize="15">
                                <Items>
                                    <ext:Label ID="Label2" runat="server" Text="Page size:" />
                                    <ext:ToolbarSpacer ID="ToolbarSpacer2" runat="server" Width="10" />
                                    <ext:ComboBox ID="ComboBox2" runat="server" Width="80">
                                        <Items>
                                            <ext:ListItem Text="15" />
                                            <ext:ListItem Text="20" />
                                            <ext:ListItem Text="30" />
                                        </Items>
                                        <SelectedItem Value="15" />
                                        <Listeners>
                                            <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:PagingToolbar>
                        </BottomBar>
                        <DirectEvents>
                            <RowDblClick OnEvent="btnChonBangTinhLuongClick">
                                <EventMask ShowMask="true" />
                            </RowDblClick>
                        </DirectEvents>
                    </ext:GridPanel>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnDongYBangTinhLuong" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="if (!hdfChosseBangLuong.getValue()) {alert('Bạn chưa chọn bảng lương'); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnChonBangTinhLuongClick">
                                <EventMask Msg="Đang xử lý..." ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnDongQuanLyBangTinhLuong" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdQuanLyBangTinhLuong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="#{grpDanhSachBangTinhLuongStore}.reload();" />
                    <Hide Handler="try{RowSelectionModelBangTinhLuong.clearSelections();}catch(e){}" />
                </Listeners>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" ID="wdDieuChinh" Constrain="true"
                Title="Điều chỉnh" Icon="Pencil" Layout="FormLayout" Width="450" AutoHeight="true"
                Padding="6">
                <Items>
                    <ext:ComboBox runat="server" ID="cbxSelectColumn" Editable="false" FieldLabel="Chọn cột<span style='color:red'>*</span>" CtCls="requiredData"
                        DisplayField="ColumnDescription" ValueField="ColumnName" AnchorHorizontal="100%"
                        TabIndex="93">
                        <Triggers>
                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                        </Triggers>
                        <Store>
                            <ext:Store runat="server" ID="cbxSelectColumnStore" AutoLoad="false" OnRefreshData="cbxSelectColumnStore_OnRefreshData">
                                <Reader>
                                    <ext:JsonReader IDProperty="ColumnName">
                                        <Fields>
                                            <ext:RecordField Name="ColumnName" />
                                            <ext:RecordField Name="ColumnDescription" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <Listeners>
                            <Expand Handler="if(cbxSelectColumn.store.getCount()==0) cbxSelectColumn.store.reload();" />
                            <Select Handler="this.triggers[0].show();" />
                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                        </Listeners>
                    </ext:ComboBox>
                    <ext:TextField runat="server" ID="txtValueAdjustment" FieldLabel="Giá trị<span style='color:red'>*</span>" AnchorHorizontal="100%" CtCls="requiredData"
                        MaskRe="/[0-9.,]/" />
                    <ext:CompositeField runat="server" ID="cpf" FieldLabel="Áp dụng<span style='color:red'>*</span>" AnchorHorizontal="100%">
                        <Items>
                            <ext:Container runat="server" ID="ctn" Layout="FormLayout" AnchorHorizontal="100%"
                                LabelWidth="1">
                                <Items>
                                    <ext:Checkbox runat="server" ID="chkApplySelectedEmployee" BoxLabel="Cho những nhân viên được chọn" />
                                    <ext:Checkbox runat="server" ID="chkApplyForAll" BoxLabel="Cho tất cả nhân viên trong bảng lương" />
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:CompositeField>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnAcceptAdjustment" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="return ValidateAjustment();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnAcceptAdjustment_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="Button3" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdDieuChinh.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="ResetAjustmentWindow();" />
                </Listeners>
            </ext:Window>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel runat="server" Border="false" ID="grpSalaryBoard" Title="Vui lòng chọn bảng lương" EnableColumnMove="false"
                                TrackMouseOver="true">
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button runat="server" Text="Quản lý bảng lương" Icon="Table">
                                                <Listeners>
                                                    <Click Handler="wdQuanLyBangTinhLuong.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="btnEmployee" runat="server" Text="Nhân viên" Icon="User" Disabled="true">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="mnuAddEmployee" runat="server" Icon="Add" Text="Thêm nhân viên">
                                                                <Listeners>
                                                                    <Click Handler="if (!hdfIDBangLuong.getValue()) {alert('Bạn chưa chọn bảng lương nào'); return false;} 
                                                                    ucChooseEmployee1_wdChooseUser.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuDeleteEmployee" runat="server" Icon="Delete" Text="Xóa nhân viên">
                                                                <Listeners>
                                                                    <Click Handler="if (CheckSelectedRow(#{grpSalaryBoard}) == false) {return false;}" />
                                                                </Listeners>
                                                                <DirectEvents>
                                                                    <Click OnEvent="mnuXoaNhanVien_Click">
                                                                        <EventMask ShowMask="true" />
                                                                        <Confirmation Title="Xác nhận" Message="Bạn có chắc chắn muốn xóa cán bộ khỏi bảng lương"
                                                                            ConfirmRequest="true" />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnAdjustment" Text="Điều chỉnh" Icon="Pencil" Disabled="true">
                                                <Listeners>
                                                    <Click Handler="wdDieuChinh.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnCalculateSalary" Text="Tính lương" Icon="Calculator"
                                                Disabled="true">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem ID="mnuLayDuLieuChamCong" runat="server" Text="Bước 1: Lấy dữ liệu chấm công">
                                                                <Menu>
                                                                    <ext:Menu ID="Menu1" runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="mnuLayTatCa" runat="server" Text="Lấy cho tất cả nhân viên">
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="mnuGetDataForAll_Click">
                                                                                        <EventMask ShowMask="true" />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="mnuLayDuocChon" runat="server" Text="Lấy cho những nhân viên được chọn">
                                                                                <Listeners>
                                                                                    <Click Handler="return CheckSelectedRow(grpSalaryBoard);" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="mnuGetDataForSelectedEmployee_Click">
                                                                                        <EventMask ShowMask="true" />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuTinhLuong" runat="server" Text="Bước 2: Tính toán lương">
                                                                <Menu>
                                                                    <ext:Menu runat="server">
                                                                        <Items>
                                                                            <ext:MenuItem ID="mnuTinhChoTatCa" runat="server" Text="Tính cho tất cả nhân viên">
                                                                                <Listeners>
                                                                                    <Click Handler="if (!hdfIDBangLuong.getValue()) {alert('Bạn chưa chọn bảng lương nào'); return false;}" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="btnCalculateSalary_Click">
                                                                                        <EventMask ShowMask="true" Msg="Đang tính lương. Vui lòng đợi..." />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="mnuCalculateSelected" runat="server" Text="Tính cho những nhân viên được chọn">
                                                                                <Listeners>
                                                                                    <Click Handler="if (CheckSelectedRow(#{grpSalaryBoard}) == false) {return false;}" />
                                                                                </Listeners>
                                                                                <DirectEvents>
                                                                                    <Click OnEvent="mnuCalculateSelected_Click">
                                                                                        <EventMask ShowMask="true" />
                                                                                    </Click>
                                                                                </DirectEvents>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnKhoaBangLuong" Text="Khóa bảng lương" Icon="Lock"
                                                Hidden="true">
                                                <DirectEvents>
                                                    <Click OnEvent="btnKhoaBangLuongClick">
                                                        <EventMask ShowMask="true" Msg="Đang khóa bảng lương. Vui lòng đợi..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button ID="btnMoKhoaBangLuong" runat="server" Text="Mở bảng lương" Icon="LockOpen"
                                                Hidden="true">
                                                <DirectEvents>
                                                    <Click OnEvent="btnMoBangLuongClick">
                                                        <EventMask ShowMask="true" Msg="Đang mở khóa bảng lương. Vui lòng đợi..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel" Hidden="false">
                                                <Listeners>
                                                    <Click Handler="if (!hdfIDBangLuong.getValue()) {alert('Bạn chưa chọn bảng lương nào'); return false;}" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <%--<ext:Button runat="server" Text="In bảng lương" Icon="Printer">
                                            </ext:Button>
                                            <ext:Button runat="server" ToolTip="Gửi mail thông báo lương tới nhân viên" Text="Gửi email" Icon="Mail">
                                            </ext:Button>--%>

                                            <%--Sử dụng phân quyền sửa trên grid--%>
                                            <ext:Button runat="server" ID="btnEditOnGrid" Hidden="true" />
                                            <ext:ToolbarFill runat="server" ID="tbf" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập tên hoặc mã cán bộ"
                                                ID="txtSearch">
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                    <TriggerClick Handler="if (index == 0) {this.reset(); this.triggers[0].hide(); 
                                                    StaticPagingToolbar.pageIndex = 0;StaticPagingToolbar.doLoad();
                                                         grpSalaryBoard.getSelectionModel().clearSelections();
                                                    }" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                <Listeners>
                                                    <Click Handler="PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
                                                    grpSalaryBoard.getSelectionModel().clearSelections();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <Store>
                                    <ext:Store runat="server" ID="stSalaryBoard" AutoLoad="false" IDMode="Static">
                                        <Proxy>
                                            <ext:HttpProxy Json="true" Method="GET" Url="Handler/BangLuongDong.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={20}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="IDBangLuong" Value="hdfIDBangLuong.getValue()" Mode="Raw" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="MA_CB" />
                                                    <ext:RecordField Name="HO_TEN" />
                                                    <ext:RecordField Name="TEN_CHUCVU" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <AfterEdit Fn="afterEdit" />
                                    <ViewReady Handler="Ext.net.DirectMethods.LoadTongLuong();" />
                                </Listeners>
                                <ColumnModel>
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="30" Locked="true" />
                                        <ext:Column Header="Mã cán bộ" DataIndex="MA_CB" Width="80" Locked="true">
                                        </ext:Column>
                                        <ext:Column Header="Họ tên" DataIndex="HO_TEN" Width="130" Locked="true">
                                        </ext:Column>
                                        <ext:Column Header="Chức vụ" DataIndex="TEN_CHUCVU" Width="120" Locked="true">
                                        </ext:Column>
                                        <%--<ext:Column Header="Giới tính" DataIndex="MA_GIOITINH" Width="90">
                                        <Renderer Fn="GetGender" />
                                    </ext:Column>
                                    <ext:DateColumn Header="Ngày sinh" DataIndex="NGAY_SINH" Width="90" Format="dd/MM/yyyy">
                                    </ext:DateColumn>--%>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="RowSelectionModelSalaryBoard" />
                                </SelectionModel>
                                <BottomBar>
                                    <ext:PagingToolbar ID="StaticPagingToolbar" IDMode="Static" EmptyMsg="Hiện không có dữ liệu"
                                        NextText="Trang sau" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                        DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server" PageSize="30">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBoxPaging" Editable="false" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="15" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="25" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="35" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="10000" />
                                                </Items>
                                                <SelectedItem Value="30" />
                                                <Listeners>
                                                    <Select Handler="#{StaticPagingToolbar}.pageSize = parseInt(this.getValue()); #{StaticPagingToolbar}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv" />
                                </View>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu. Vui lòng chờ" />
                            </ext:GridPanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        </div>
    </form>
</body>
</html>
