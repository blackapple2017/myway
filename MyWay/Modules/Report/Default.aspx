<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modules_Report_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <link rel="stylesheet" href="../Role/Resource/jqx.base.css" type="text/css" />
    <script type="text/javascript" src="../Role/Resource/gettheme.js"></script>
    <script type="text/javascript" src="../Role/Resource/jquery-1.8.3.min.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxcore.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxbuttons.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxscrollbar.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxpanel.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxtree.js"></script>
    <script type="text/javascript" src="../Role/Resource/jqxcheckbox.js"></script>
    <link href="Resource/Style.css" rel="stylesheet" />
    <asp:Literal runat="server" ID="ltrShowSettingDialog"></asp:Literal>
    <script type="text/javascript" src="Resource/Js.js"></script>
    <style type="text/css">
        .x-html-editor-wrap
        {
            border: none !important;
        }
        #grpSelectedReportFilter
        {
            border-left: 1px solid #99bbe8;
        }
        #grpReportFilter
        {
            border-right: 1px solid #99bbe8;
        }
    </style>
    <script type="text/javascript">
        function resetReportFilterForm() {
            txtReportTitle.reset();
            cbChooseFilterTable.reset();
            //    hdfReportID.reset();
            hdfCurrentReportID.reset();
            storeFilterValues.clearData();
            storeFilterTable.clearData();
            storeFilterValues.reload();
            txtSeniority.enable(); txtSeniority.show(); txtSeniority.reset();
            cbWorkingStatus.enable(); cbWorkingStatus.show(); cbWorkingStatus.reset();
            txtAge.enable(); txtAge.show(); txtAge.reset();
            dfStartDate.enable(); dfStartDate.show(); dfStartDate.reset();
            dfEndDate.enable(); dfEndDate.show(); dfEndDate.reset();
            cbMonth.enable(); cbMonth.show(); cbMonth.reset();
            cbGender.enable(); cbGender.show(); cbGender.reset();
            cbChonPhongBan.enable(); cbChonPhongBan.show(); cbChonPhongBan.reset();
            hdfMaDonViList.reset(); spfyear.enable(); spfyear.show();
            hdfChonCanBo.reset(); cbxChonCanBo.reset(); cbxChonCanBo.enable(); cbxChonCanBo.show(); htmlNote.reset();
            txttieudechuky1.reset();
            txttieudechuky2.reset();
            txttieudechuky3.reset();
            txtnguoiky1.reset();
            txtnguoiky2.reset();
            txtnguoiky3.reset();
        }
        //lấy giá trị trong store dựa vào ID property
        function getWhereField(id) {
            for (var i = 0; i < storeFilterTable.getCount(); i++) {
                if (storeFilterTable.getAt(i).data.ID == id) {
                    return storeFilterTable.getAt(i).data.WhereField;
                }
            }
            return "";
        }

        function addSelectedValues() {
            if (grpReportFilter.getSelectionModel().getCount() == 0) {
                Ext.Msg.alert("Thông báo", "Bạn chưa chọn điều kiện nào cả!");
                return false;
            }
            else {
                var s = grpReportFilter.getSelectionModel().getSelections();
                for (var i = 0, r; r = s[i]; i++) {
                    if (!checkExits(r.data.ID, cbChooseFilterTable.getText())) {
                        grpSelectedReportFilter.insertRecord(0, {
                            ID: r.data.ID,
                            DisplayText: cbChooseFilterTable.getText(),
                            Value: r.data.Value,
                            WhereField: getWhereField(cbChooseFilterTable.getValue())
                        });
                    }
                }
                storeSelectedReportFilter.commitChanges();
            }
        }

        var checkExits = function (ID, DisplayText) {
            var count = storeSelectedReportFilter.getCount();
            for (var j = 0; j < count; j++) {
                try {
                    grpSelectedReportFilter.getSelectionModel().selectRow(j);
                    var s = grpSelectedReportFilter.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        if (r.data.DisplayText == DisplayText && r.data.ID == ID) {
                            return true;
                        }
                    }
                } catch (e) {
                    alert(e);
                }
            }
            return false;
        }

        //gen code sql
        var getSelectedFilter = function () {
            var rs = "";
            var count = storeSelectedReportFilter.getCount();
            for (var j = 0; j < count; j++) {
                try {
                    grpSelectedReportFilter.getSelectionModel().selectRow(j);
                    var s = grpSelectedReportFilter.getSelectionModel().getSelections();
                    for (var i = 0, r; r = s[i]; i++) {
                        rs += r.data.WhereField + '=' + r.data.ID + ';';
                    }
                } catch (e) {
                    alert(e);
                }
            }
            return rs;
            //alert(rs);
        }

        var removeFilter = function () {
            if (grpSelectedReportFilter.getSelectionModel().getCount() == 0) {
                Ext.Msg.alert("Thông báo", "Bạn chưa chọn điều kiện nào cả!");
                return false;
            }
            var s = grpSelectedReportFilter.getSelectionModel().getSelections();
            for (var i = 0, r; r = s[i]; i++) {
                storeSelectedReportFilter.remove(r);
            }
        }

        var afterEdit = function (e) {
            /*
            Properties of 'e' include:
            e.grid - This grid
            e.record - The record being edited
            e.field - The field name being edited
            e.value - The value being set
            e.originalValue - The original value for the field, before the edit.
            e.row - The grid row index
            e.column - The grid column index
            */

            // Call DirectMethod
            e.record.data.ID =
            CompanyX.AfterEdit(e.record.data.ID, e.field, e.originalValue, e.value, e.record.data);
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfTitle" />
        <ext:Hidden runat="server" ID="hdfReportID" />
        <ext:Hidden runat="server" ID="hdfCurrentReportID" />
        <ext:Menu ID="RowContextMenu" runat="server">
            <Items>
                <ext:MenuItem runat="server" Text="Xem báo cáo" Icon="Printer">
                    <Listeners>
                        <Click Handler="ShowSettingDialog();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>
        <div id="divReportPreview">
            <h1>
                Mẫu báo cáo
            </h1>
            <a href="#" id="aClose" onclick="document.getElementById('divReportPreview').style.display='none';">
            </a>
            <img id="imgReportPreview" src="" alt="Report preview" width="600" />
        </div>
        <ext:Hidden runat="server" ID="hdfMaDonViList" />
        <ext:Window runat="server" ID="wdChooseDepartment" Hidden="true" Icon="House" Constrain="true"
            Modal="true" Title="Chọn bộ phận" Height="400" Width="340">
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
                <ext:Button ID="Button3" runat="server" Text="Đồng ý" Icon="Accept">
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
        <ext:Window runat="server" ID="wdReportFilter" Hidden="true" Modal="true" AutoHeight="true"
            ConstrainHeader="true" Width="650" Icon="Printer" Padding="6" Constrain="true"
            Layout="FormLayout" Title="Điều kiện báo cáo" Resizable="false">
            <Items>
                <ext:TriggerField runat="server" AnchorHorizontal="100%" FieldLabel="Tiêu đề báo cáo"
                    ID="txtReportTitle">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" Qtip="Xóa trắng" HideTrigger="false" />
                    </Triggers>
                    <Listeners>
                        <TriggerClick Handler="txtReportTitle.reset();" />
                    </Listeners>
                </ext:TriggerField>
                <ext:Container runat="server" ID="ctn5" Layout="ColumnLayout" Height="27" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="Container1" Layout="FormLayout" ColumnWidth="0.34">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfChonCanBo" />
                                <ext:ComboBox ID="cbxChonCanBo" ValueField="PRKEY" DisplayField="HOTEN" FieldLabel="Tên cán bộ"
                                    PageSize="10" ListWidth="180" ItemSelector="div.search-item" MinChars="1" EmptyText="nhập tên để tìm kiếm"
                                    LoadingText="Đang tải dữ liệu..." AnchorHorizontal="99%" runat="server">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="SearchUserHandler.ashx" />
                                            </Proxy>
                                            <Reader>
                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="HOTEN" />
                                                        <ext:RecordField Name="MACB" />
                                                        <ext:RecordField Name="NGAYSINH" />
                                                        <ext:RecordField Name="PHONGBAN" />
                                                        <ext:RecordField Name="PRKEY" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template4" runat="server">
                                        <Html>
                                            <tpl for=".">
						                        <div class="search-item">
							                        <h3>{HOTEN}</h3>
                                                    {MACB} <br />
                                                    <tpl if="NGAYSINH &gt; ''">{NGAYSINH:date("d/m/Y")}</tpl><br />
							                        {PHONGBAN}
						                        </div>
					                        </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show(); hdfChonCanBo.setValue(cbxChonCanBo.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChonCanBo.reset(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Container>
                        <ext:ComboBox runat="server" LabelWidth="70" ID="cbGender" Editable="false" ColumnWidth="0.33"
                            FieldLabel="Giới tính">
                            <Items>
                                <ext:ListItem Text="Tất cả" Value="" />
                                <ext:ListItem Text="Nam" Value="M" />
                                <ext:ListItem Text="Nữ" Value="F" />
                            </Items>
                        </ext:ComboBox>
                        <ext:ComboBox runat="server" ID="cbWorkingStatus" SelectedIndex="1" FieldLabel="Tình trạng"
                            Editable="false" ColumnWidth="0.33" LabelWidth="80" AnchorHorizontal="100%">
                            <Items>
                                <ext:ListItem Text="Tất cả" Value="" />
                                <ext:ListItem Text="Đang làm việc" Value="0" />
                                <ext:ListItem Text="Đã thôi việc" Value="1" />
                            </Items>
                        </ext:ComboBox>
                    </Items>
                </ext:Container>
                <ext:Container ID="Container10" runat="server" Height="27" Layout="ColumnLayout"
                    AnchorHorizontal="100%">
                    <Items>
                        <ext:Container ID="Container11" runat="server" ColumnWidth="0.67" Layout="FormLayout">
                            <Items>
                                <ext:Hidden runat="server" ID="hdfMaDonvi" />
                                <ext:TriggerField runat="server" ID="cbChonPhongBan" CtCls="requiredData" FieldLabel="Chọn phòng ban"
                                    AnchorHorizontal="99%">
                                    <Listeners>
                                        <TriggerClick Handler="wdChooseDepartment.show();" />
                                        <Focus Handler="wdChooseDepartment.show();" />
                                    </Listeners>
                                </ext:TriggerField>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container12" runat="server" ColumnWidth="0.33" Layout="FormLayout"
                            LabelWidth="80">
                            <Items>
                                <ext:TextField runat="server" ID="txtAge" AnchorHorizontal="100%" FieldLabel="Độ tuổi">
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip2" runat="server" Title="Hướng dẫn" Html="Độ tuổi được tính theo năm, ví dụ:<br/>>=30 : những người có độ tuổi lớn hơn hoặc bằng 30<br/>=35: những người có độ tuổi bằng 35<br/>30-35: những người có độ tuổi từ 30-35">
                                        </ext:ToolTip>
                                    </ToolTips>
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:Container runat="server" ID="ctn1" Layout="ColumnLayout" Height="53" AnchorHorizontal="100%">
                    <Items>
                        <ext:Container runat="server" ID="ctn2" Layout="FormLayout" ColumnWidth="0.34">
                            <Items>
                                <ext:ComboBox ID="cbMonth" runat="server" Editable="false" AnchorHorizontal="99%"
                                    FieldLabel="Tháng">
                                    <Items>
                                        <ext:ListItem Text="Cả năm" Value="FullYear" />
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
                                        <ext:ListItem Text="Quý 1" Value="I" />
                                        <ext:ListItem Text="Quý 2" Value="II" />
                                        <ext:ListItem Text="Quý 3" Value="III" />
                                        <ext:ListItem Text="Quý 4" Value="IV" />
                                    </Items>
                                </ext:ComboBox>
                                <ext:Container runat="server" ID="ctn6" Layout="FormLayout" ColumnWidth="0.34">
                                    <Items>
                                        <ext:SpinnerField runat="server" FieldLabel="Năm" ID="spfyear" AnchorHorizontal="99%" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctn3" Layout="FormLayout" ColumnWidth="0.33" LabelWidth="70">
                            <Items>
                                <ext:DateField ID="dfStartDate" runat="server" FieldLabel="Từ ngày" AnchorHorizontal="99%" Format="d/M/yyyy"/>
                                <ext:TextField ID="txtSeniority" runat="server" FieldLabel="Thâm niên" AnchorHorizontal="99%">
                                    <ToolTips>
                                        <ext:ToolTip ID="ToolTip1" runat="server" Title="Hướng dẫn" Html="Thâm niên được tính theo tháng, ví dụ:<br/>=6 : những người có thâm niên 6 tháng<br/>>12: những người có thâm niên hơn 1 năm<br/>12-24: những người từ 1 đến 2 năm">
                                        </ext:ToolTip>
                                    </ToolTips>
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctn4" Layout="FormLayout" ColumnWidth="0.33" LabelWidth="80">
                            <Items>
                                <ext:DateField ID="dfEndDate" runat="server" FieldLabel="Đến ngày" AnchorHorizontal="100%" Format="d/M/yyyy"/>
                                <ext:Container runat="server" ID="Container9" LabelWidth="80" Layout="FormLayout"
                                    ColumnWidth="0.5">
                                    <Items>
                                        <ext:DateField runat="server" AnchorHorizontal="100%" FieldLabel="Ngày báo cáo" CtCls="requiredData"
                                            ID="dfReportDate" Format="d/M/yyyy" />
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TabPanel runat="server" ID="tbpnl" AnchorHorizontal="100%" Border="true" Height="250">
                    <Items>
                        <ext:Panel runat="server" ID="pnlDKL" Title="Các điều kiện lọc" Border="false" Layout="FormLayout"
                            AnchorHorizontal="100%">
                            <Items>
                                <ext:Container ID="Container2" runat="server" Height="220" AnchorHorizontal="100%"
                                    Layout="ColumnLayout">
                                    <Items>
                                        <ext:Container ID="Container3" runat="server" Height="220" Layout="BorderLayout"
                                            ColumnWidth="0.5">
                                            <Items>
                                                <ext:GridPanel Border="false" AnchorHorizontal="98%" ID="grpReportFilter" runat="server"
                                                    StripeRows="true" AutoExpandColumn="Value" Title="" Region="Center" TrackMouseOver="false">
                                                    <Store>
                                                        <ext:Store runat="server" OnRefreshData="storeFilterValues_OnRefreshData" ID="storeFilterValues"
                                                            AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="ID">
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <TopBar>
                                                        <ext:Toolbar ID="Toolbar2" runat="server">
                                                            <Items>
                                                                <ext:ComboBox runat="server" ValueField="ID" DisplayField="DescriptionTableName"
                                                                    ID="cbChooseFilterTable" LabelWidth="70" EmptyText="Chọn điều kiện" Editable="false">
                                                                    <Store>
                                                                        <ext:Store runat="server" OnRefreshData="storeFilterTable_OnRefreshData" AutoLoad="false"
                                                                            ID="storeFilterTable">
                                                                            <Reader>
                                                                                <ext:JsonReader>
                                                                                    <Fields>
                                                                                        <ext:RecordField Name="ID" />
                                                                                        <ext:RecordField Name="DescriptionTableName" />
                                                                                        <ext:RecordField Name="WhereField" />
                                                                                    </Fields>
                                                                                </ext:JsonReader>
                                                                            </Reader>
                                                                        </ext:Store>
                                                                    </Store>
                                                                    <Listeners>
                                                                        <Expand Handler="if(hdfCurrentReportID.getValue()!=hdfReportID.getValue()){
                                                                               hdfCurrentReportID.setValue(hdfReportID.getValue()); 
                                                                               storeFilterTable.reload();  
                                                                         }" />
                                                                        <Select Handler="storeFilterValues.reload();" />
                                                                    </Listeners>
                                                                </ext:ComboBox>
                                                                <ext:Button ID="Button4" runat="server" Text="Đồng ý chọn" Icon="Accept">
                                                                    <Listeners>
                                                                        <Click Handler="addSelectedValues();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </Items>
                                                        </ext:Toolbar>
                                                    </TopBar>
                                                    <ColumnModel>
                                                        <Columns>
                                                            <ext:Column Header="Mã" Width="70" DataIndex="ID">
                                                            </ext:Column>
                                                            <ext:Column Header="Giá trị" ColumnID="Value" DataIndex="Value">
                                                            </ext:Column>
                                                        </Columns>
                                                    </ColumnModel>
                                                    <SelectionModel>
                                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel1" runat="server">
                                                        </ext:CheckboxSelectionModel>
                                                    </SelectionModel>
                                                </ext:GridPanel>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container4" runat="server" Layout="FormLayout" Width="6">
                                        </ext:Container>
                                        <ext:Container ID="Container5" runat="server" Layout="BorderLayout" ColumnWidth="0.5">
                                            <Items>
                                                <ext:GridPanel Border="false" AnchorHorizontal="98%" ID="grpSelectedReportFilter"
                                                    runat="server" StripeRows="true" AutoExpandColumn="Value"
                                                    Icon="Tick" Region="Center" TrackMouseOver="false">
                                                    <TopBar>
                                                        <ext:Toolbar ID="Toolbar3" runat="server">
                                                            <Items>
                                                                <ext:ToolbarSpacer runat="server" Width="5" />
                                                                <ext:Label runat="server" Icon="Tick" />
                                                                <ext:ToolbarSpacer runat="server" Width="3" />
                                                                <ext:DisplayField ID="dplfDieuKien" runat="server" Text="<b style='color:#15428B'>Điều kiện đã chọn</b>"></ext:DisplayField>
                                                                <ext:ToolbarFill runat="server" />
                                                                <ext:Button ID="btnDeleteReportFilter" runat="server" Text="Xóa" Icon="Delete">
                                                                    <Listeners>
                                                                        <Click Handler="removeFilter();" />
                                                                    </Listeners>
                                                                </ext:Button>
                                                            </Items>
                                                        </ext:Toolbar>
                                                    </TopBar>
                                                    <Store>
                                                        <ext:Store ID="storeSelectedReportFilter" runat="server" AutoLoad="false">
                                                            <Reader>
                                                                <ext:JsonReader>
                                                                    <Fields>
                                                                        <ext:RecordField Name="ID" />
                                                                        <ext:RecordField Name="DisplayText" />
                                                                        <ext:RecordField Name="WhereField" />
                                                                        <ext:RecordField Name="Value" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <ColumnModel>
                                                        <Columns>
                                                            <ext:Column Header="Điều kiện" Width="120" DataIndex="DisplayText">
                                                            </ext:Column>
                                                            <ext:Column Header="Giá trị" ColumnID="Value" DataIndex="Value">
                                                                <Editor>
                                                                    <ext:TextField ID="txtValue" runat="server">
                                                                        <Listeners>
                                                                            <Focus Handler="txtValue.blur();" />
                                                                        </Listeners>
                                                                    </ext:TextField>
                                                                </Editor>
                                                            </ext:Column>
                                                        </Columns>
                                                    </ColumnModel>
                                                    <SelectionModel>
                                                        <ext:CheckboxSelectionModel ID="CheckboxSelectionModel2" runat="server">
                                                            <Listeners>
                                                                <RowSelect Handler="btnDeleteReportFilter.enable();" />
                                                            </Listeners>
                                                        </ext:CheckboxSelectionModel>
                                                    </SelectionModel>
                                                    <Listeners>
                                                        <AfterEdit Fn="afterEdit" />
                                                    </Listeners>
                                                </ext:GridPanel>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" ID="pnlDieuKienThem" Title="Điều kiện thêm" Border="false"
                            Layout="FormLayout" AnchorHorizontal="100%" Padding="6">
                            <Items>
                                <ext:ComboBox runat="server" ValueField="ID" DisplayField="TenDotDanhGia" FieldLabel="Đợt đánh giá"
                                    ID="cbxDotDanhGia" EmptyText="Chọn đợt đánh giá" Editable="false" AnchorHorizontal="100%">
                                    <Store>
                                        <ext:Store runat="server" OnRefreshData="cbxDotDanhGia_OnRefreshData" AutoLoad="false"
                                            ID="cbxDotDanhGiaStore">
                                            <Reader>
                                                <ext:JsonReader>
                                                    <Fields>
                                                        <ext:RecordField Name="ID" />
                                                        <ext:RecordField Name="TenDotDanhGia" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Expand Handler="cbxDotDanhGiaStore.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:Panel>
                        <ext:Panel runat="server" ID="Panel1" Title="Ghi chú" Border="false" Layout="FitLayout" Hidden="true"
                            AnchorHorizontal="100%">
                            <Items>
                                <ext:HtmlEditor runat="server" ID="htmlNote">
                                </ext:HtmlEditor>
                            </Items>
                        </ext:Panel>
                    </Items>
                </ext:TabPanel>
                <ext:FieldSet runat="server" ID="fsnhomchuky" Title="Cấu hình chữ ký ">
                    <Items>
                        <ext:Container runat="server" ID="columnlayout" Layout="FormLayout" AnchorHorizontal="100%">
                            <Items>
                                <ext:Container runat="server" ID="column1" Layout="ColumnLayout" LabelAlign="Top"
                                    Height="25">
                                    <Items>
                                        <ext:Container ID="Container6" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField runat="server" ID="txttieudechuky1" FieldLabel="Tiêu đề 1" LabelWidth="65"
                                                    AnchorHorizontal="95%">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container7" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField runat="server" ID="txttieudechuky2" AnchorHorizontal="95%" FieldLabel="Tiêu đề 2"
                                                    LabelWidth="65">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container16" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField runat="server" ID="txttieudechuky3" AnchorHorizontal="100%" FieldLabel="Tiêu đề 3"
                                                    LabelWidth="65">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                                <ext:Container runat="server" ID="Container8" Layout="ColumnLayout" LabelAlign="Top"
                                    Height="25">
                                    <Items>
                                        <ext:Container ID="Container17" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtnguoiky1" FieldLabel="Người ký 1" LabelWidth="65"
                                                    AnchorHorizontal="95%">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container18" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtnguoiky2" AnchorHorizontal="95%" FieldLabel="Người ký 2"
                                                    LabelWidth="65">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container19" runat="server" Layout="FormLayout" ColumnWidth="0.33">
                                            <Items>
                                                <ext:TextField runat="server" ID="txtnguoiky3" AnchorHorizontal="100%" FieldLabel="Người ký 3"
                                                    LabelWidth="65">
                                                </ext:TextField>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:FieldSet>
            </Items>
            <Listeners>
                <BeforeShow Handler="storeSelectedReportFilter.reload();wdReportFilter.setTitle(hdfTitle.getValue());if(hdfCurrentReportID.getValue()!=hdfReportID.getValue()){
                                                                            hdfCurrentReportID.setValue(hdfReportID.getValue());storeFilterTable.reload(); }" />
                <Hide Handler="resetReportFilterForm();$('#jqxTree').jqxTree('uncheckAll');" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý" Icon="Accept" ID="btnShowReport">
                    <DirectEvents>
                        <Click OnEvent="btnShowReport_Click" After="#{wdReportFilter}.hide();">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát.." />
                            <ExtraParams>
                                <ext:Parameter Name="SQL" Value="getSelectedFilter()" Mode="Raw" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline" ID="btnClose">
                    <Listeners>
                        <Click Handler="#{wdReportFilter}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Viewport runat="server" ID="vReport">
            <Items>
                <ext:BorderLayout runat="server" ID="brLayout">
                    <Center Split="true">
                        <ext:TabPanel ID="pnTabReport" Border="false" EnableTabScroll="true" runat="server">
                            <Plugins>
                                <ext:TabCloseMenu CloseOtherTabsText="Đóng Tab khác" CloseAllTabsText="Đóng tất cả các Tab"
                                    CloseTabText="Đóng Tab">
                                </ext:TabCloseMenu>
                                <ext:TabScrollerMenu ID="TabScrollerMenu1" runat="server">
                                </ext:TabScrollerMenu>
                            </Plugins>
                        </ext:TabPanel>
                    </Center>
                    <West Collapsible="true" Split="true">
                        <ext:TreePanel Border="false" ID="TreePanel1" CtCls="west-report" runat="server"
                            Width="300" Icon="Report" Title="Mẫu báo cáo"
                            RootVisible="false" AutoScroll="true">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:ToolbarTextItem ID="ToolbarTextItem1" runat="server" Text="Tìm kiếm" />
                                        <ext:ToolbarSpacer />
                                        <ext:TriggerField ID="TriggerField1" runat="server" EnableKeyEvents="true">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyUp Fn="filterTree" Buffer="250" />
                                                <TriggerClick Handler="clearFilter();" />
                                            </Listeners>
                                            <ToolTips>
                                                <ext:ToolTip runat="server" Title="Hướng dẫn" Html="Nhập một từ khóa trong tên của báo cáo"
                                                    ID="tl" />
                                            </ToolTips>
                                        </ext:TriggerField>
                                        <ext:ToolbarSeparator runat="server" ID="ts" />
                                        <ext:Button ID="Button1" runat="server" Text="Mở rộng">
                                            <Listeners>
                                                <Click Handler="#{TreePanel1}.expandAll();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:ToolbarSeparator runat="server" ID="ToolbarSeparator1" />
                                        <ext:Button ID="Button2" runat="server" Text="Thu nhỏ">
                                            <Listeners>
                                                <Click Handler="#{TreePanel1}.collapseAll();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Root>
                            </Root>
                        </ext:TreePanel>
                    </West>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
