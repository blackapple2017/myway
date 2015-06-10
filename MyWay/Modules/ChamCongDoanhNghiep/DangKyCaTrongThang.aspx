<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKyCaTrongThang.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_ThietLapCaChoNhanVien" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #grpDanhSachBangPhanCaThang
        {
            border-left: 1px solid #99bbe8 !important;
        }
        
        #pnlCoCauToChuc-xsplit
        {
            border-right: none !important;
        }
    </style>
    <script type="text/javascript" src="../../Resource/js/Extcommon.js"></script>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <link href="Resource/DangKyCaTrongThang.css" rel="stylesheet" />
    <script type="text/javascript" src="../../Resource/js/jquery-1.4.2.min.js"></script>
    <script src="Resource/jsDangKyCaTrongThang.js" type="text/javascript"></script>
    <script type="text/javascript">
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
            }
            if (txtSearchKey.getValue() != '')
                this.triggers[0].show();
        }
        var ResetNodeChecked = function (tree, stringallmadonvi) {
            if (stringallmadonvi.getValue().length != 0) {
                var str = stringallmadonvi.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        tree.getNodeById(str[i]).getUI().checkbox.checked = false;
                    }
                }
            }
        }

        var GetSelectedNodeDonVi = function (tree, stringallmadonvi, stringmadonvi) {
            if (stringallmadonvi.getValue().length != 0) {
                stringmadonvi.setValue('');
                stringmadonvi.reset();
                var str = stringallmadonvi.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        if (tree.getNodeById(str[i]).getUI().checkbox.checked == true) {
                            stringmadonvi.setValue(stringmadonvi.getValue() + "," + str[i]);
                        }
                    }
                }
                stringmadonvi.setValue(stringmadonvi.getValue().substring(1, stringmadonvi.getValue().length));
            }
        }

        var getTasks = function (tree) {
            var msg = [],
                    selNodes = tree.getChecked();
            msg.push("[");

            Ext.each(selNodes, function (node) {
                if (msg.length > 1) {
                    msg.push(",");
                }

                msg.push(node.text);
            });

            msg.push("]");

            return msg.join("");
        };

        var afterEdit = function (e) {
            PhanCaTrongThang.AfterEdit(e.field, e.originalValue, e.value, e.record.data.ID)
        }
        var saveData = function () {
            var innerHTML = document.getElementById("sqlQuery").innerHTML;
            if (innerHTML.length != 0) {
                Ext.net.DirectMethods.SaveData(innerHTML);
            }
        }

        var clearSQL = function () {
            document.getElementById("sqlQuery").innerHTML = "";
        }

        var getPageIndex = function () {
            $("#ext-comp-1042").text;
        }

        $(function () {
            setInterval("saveData()", 1000 * 600); // 10" gửi request một lần
        });
    </script>
    <asp:Literal Text="" ID="ltrweekendStyle" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
        </ext:ResourceManager>
        <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        <div id="sqlQuery" style="display: none;">
        </div>
        <ext:Hidden runat="server" ID="hdfMaDonVi" />
        <ext:Hidden runat="server" ID="hdfStringAllMaDonVi">
        </ext:Hidden>
        <ext:Hidden runat="server" ID="hdfStringMaDonVi" />
        <ext:Hidden runat="server" ID="hdfIDBangPhanCa" />
        <ext:Hidden runat="server" ID="hdfUserID" />
        <ext:Hidden runat="server" ID="hdfMenuID" />
        <ext:Store ID="Store2" runat="server" AutoLoad="false">
            <Proxy>
                <ext:HttpProxy Method="POST" Url="Handler/HandlerSearchDanhSachCa.ashx">
                </ext:HttpProxy>
            </Proxy>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MaCa" />
                        <ext:RecordField Name="TenCa" />
                        <ext:RecordField Name="GioVao" />
                        <ext:RecordField Name="GioRa" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Store runat="server" ID="grpDanhSachBangPhanCaThangStore" AutoSave="false" OnBeforeStoreChanged="HandleChanges">
            <Proxy>
                <ext:HttpProxy Json="true" Method="GET" Url="Handler/BangPhanCaThang.ashx">
                </ext:HttpProxy>
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="Start" Value="={0}" />
                <ext:Parameter Name="Limit" Value="={25}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
                <ext:Parameter Name="IDBangPhanCa" Value="#{hdfIDBangPhanCa}.getValue()" Mode="Raw" />
                <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                <ext:Parameter Name="UserID" Value="#{hdfUserID}.getValue()" Mode="Raw" />
                <ext:Parameter Name="MenuID" Value="#{hdfMenuID}.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="MaCB" />
                        <ext:RecordField Name="TenCB" />
                        <ext:RecordField Name="BoPhan" />
                        <ext:RecordField Name="Ngay01" />
                        <ext:RecordField Name="Ngay02" />
                        <ext:RecordField Name="Ngay03" />
                        <ext:RecordField Name="Ngay04" />
                        <ext:RecordField Name="Ngay05" />
                        <ext:RecordField Name="Ngay06" />
                        <ext:RecordField Name="Ngay07" />
                        <ext:RecordField Name="Ngay08" />
                        <ext:RecordField Name="Ngay09" />
                        <ext:RecordField Name="Ngay10" />
                        <ext:RecordField Name="Ngay11" />
                        <ext:RecordField Name="Ngay12" />
                        <ext:RecordField Name="ngay13" />
                        <ext:RecordField Name="ngay14" />
                        <ext:RecordField Name="Ngay15" />
                        <ext:RecordField Name="Ngay16" />
                        <ext:RecordField Name="Ngay17" />
                        <ext:RecordField Name="Ngay18" />
                        <ext:RecordField Name="Ngay19" />
                        <ext:RecordField Name="Ngay20" />
                        <ext:RecordField Name="Ngay21" />
                        <ext:RecordField Name="Ngay22" />
                        <ext:RecordField Name="Ngay23" />
                        <ext:RecordField Name="Ngay24" />
                        <ext:RecordField Name="Ngay25" />
                        <ext:RecordField Name="Ngay26" />
                        <ext:RecordField Name="Ngay27" />
                        <ext:RecordField Name="Ngay28" />
                        <ext:RecordField Name="Ngay29" />
                        <ext:RecordField Name="Ngay30" />
                        <ext:RecordField Name="Ngay31" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Window runat="server" Icon="ClockAdd" ID="wdTaoBangPhanCa" Padding="6" Layout="FormLayout"
            Title="Tạo bảng phân ca" Hidden="true" LabelWidth="105" Width="470" Modal="true"
            Constrain="true" AutoHeight="true">
            <Items>
                <%--<ext:DropDownField runat="server" Editable="false" ID="ddfDonVi" AnchorHorizontal="99%"
                    AllowBlank="false" BlankText="Bạn phải chọn đơn vị hoặc bộ phận sử dụng" FieldLabel="Chọn bộ phận">
                    <Component>
                        <ext:TreePanel ID="TreePanelDonVi" runat="server" Header="false" Icon="Accept" Height="300"
                            Shadow="None" UseArrows="true" AutoScroll="true" Animate="true" EnableDD="true"
                            ContainerScroll="true" RootVisible="false">
                            <Root>
                            </Root>
                            <Buttons>
                                <ext:Button ID="Button2" Icon="Decline" runat="server" Text="Đóng lại">
                                    <Listeners>
                                        <Click Handler="#{ddfDonVi}.collapse();" />
                                    </Listeners>
                                </ext:Button>
                            </Buttons>
                        </ext:TreePanel>
                    </Component>
                    <Listeners>
                        <Expand Handler="this.component.getRootNode().expand(true);" Single="false" Delay="10" />
                    </Listeners>
                </ext:DropDownField>--%>
                <ext:ComboBox runat="server" Editable="false" ValueField="MA" DisplayField="TEN"
                    Note="Bạn phải chọn một đơn vị. Không được phép để trống !" ID="ddfDonvi" AnchorHorizontal="100%"
                    AllowBlank="false" BlankText="Bạn phải chọn đơn vị sử dụng" ItemSelector="div.list-item"
                    FieldLabel="Đơn vị sử dụng<span style='color:red'>*</span>" CtCls="requiredData">
                    <Template ID="Template37" runat="server">
                        <Html>
                            <tpl for=".">
						            <div class="list-item"> 
                                    <tpl if="MA &gt; '-a'">{TEN}</tpl>
                                    <tpl if="MA &lt; 0"><span class='lineThrough'>{TEN}</span></tpl> 
						            </div>
					            </tpl>
                        </Html>
                    </Template>
                    <Store>
                        <ext:Store runat="server" ID="cbx_bophan_Store" AutoLoad="false" OnRefreshData="cbx_bophan_Store_OnRefreshData">
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
                        <Expand Handler="if(ddfDonvi.store.getCount()==0) cbx_bophan_Store.reload();" />
                        <Select Handler="if(ddfDonvi.getValue() <= 0) {alert('Bạn không có quyền thao tác với bộ phận này!'); ddfDonvi.reset();}txtTenBangPhanCa.setValue('Bảng phân ca tháng ' + cbThang.getValue() + '/' + spfYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, '')); hdfStringMaDonVi.setValue(ddfDonvi.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }; hdfStringMaDonVi.reset();" />
                    </Listeners>
                </ext:ComboBox>
                <ext:CompositeField runat="server" FieldLabel="Thời gian<span style='color:red;'>*</span>"
                    Height="30">
                    <Items>
                        <ext:DisplayField runat="server" Text="Tháng" />
                        <ext:ComboBox Editable="false" ID="cbThang" Width="100" runat="server">
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
                                <Select Handler="txtTenBangPhanCa.setValue('Bảng phân ca tháng ' + cbThang.getValue() + '/' + spfYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, ''));" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:DisplayField ID="DisplayField1" runat="server" Text="Năm" />
                        <ext:SpinnerField ID="spfYear" AllowBlank="false" Width="100" runat="server">
                            <Listeners>
                                <Spin Handler="txtTenBangPhanCa.setValue('Bảng phân ca tháng ' + cbThang.getValue() + '/' + spfYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, ''));" />
                            </Listeners>
                        </ext:SpinnerField>
                    </Items>
                </ext:CompositeField>
                <ext:Checkbox runat="server" ID="chkLayTuThangTruoc" BoxLabel="Sao chép lịch phân ca từ bảng phân ca khác"
                    Checked="false" FieldLabel="Dữ liệu phân ca" Height="30" Hidden="true">
                </ext:Checkbox>
                <ext:TextArea runat="server" ID="txtTenBangPhanCa" FieldLabel="Tên bảng phân ca"
                    AnchorHorizontal="100%" />
            </Items>
            <Listeners>
                <BeforeShow Handler="cbThang.setValue(new Date().getMonth()+1);spfYear.setValue(new Date().getFullYear());" />
                <Hide Handler="resetTaoBangPhanCa();" />
            </Listeners>
            <Buttons>
                <ext:Button ID="btnTaoBangPhanCaThang" runat="server" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return validateForm(); GetSelectedNodeDonVi(TreePanelDonVi,hdfStringAllMaDonVi,hdfStringMaDonVi);" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnTaoBangPhanCaThang_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button8" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdTaoBangPhanCa.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Window Modal="true" Hidden="true" runat="server" ID="wdThietLapCaNhanh" Layout="FormLayout"
            Constrain="true" Title="Thiết lập ca nhanh" Resizable="false" Icon="DateAdd"
            Width="500" LabelWidth="120" Padding="6" AutoHeight="true">
            <Items>
                <ext:Container ID="Container1" runat="server" Layout="ColumnLayout" Height="30">
                    <Items>
                        <ext:DateField ID="FromDate" Format="dd/MM/yyyy" Editable="false" runat="server"
                            TodayText="Hôm nay" Vtype="daterange" FieldLabel="Từ ngày<span style='color:red;'>*</span>"
                            ColumnWidth="0.5" EnableKeyEvents="true">
                        </ext:DateField>
                        <ext:DateField ID="ToDate" runat="server" Format="dd/MM/yyyy" Editable="false" TodayText="Hôm nay"
                            Vtype="daterange" FieldLabel="Đến ngày<span style='color:red;'>*</span>" ColumnWidth="0.5"
                            EnableKeyEvents="true">
                        </ext:DateField>
                    </Items>
                </ext:Container>
                <ext:ComboBox ID="cbTinhTrangLamViec" runat="server" EmptyText="Chọn ca làm việc"
                    TypeAhead="true" AnchorHorizontal="100%" ForceSelection="true" StoreID="Store2"
                    Mode="Local" DisplayField="TenCa" ValueField="MaCa" FieldLabel="Chọn ca làm việc<span style='color:red;'>*</span>"
                    MinChars="1" ListWidth="300" PageSize="10" ItemSelector="tr.list-item" Editable="false">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						        <tpl if="[xindex] == 1">
							        <table class="cbStates-list">
								        <tr>
									        <th>Mã ca</th>
									        <th>Tên ca</th>
                                            <th>Giờ vào</th>
									        <th>Giờ ra</th>
								        </tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{MaCa}</td>
							        <td>{TenCa}</td>
                                    <td>{GioVao}</td>
                                    <td>{GioRa}</td>
						        </tr>
						        <tpl if="[xcount-xindex]==0">
							        </table>
						        </tpl>
					        </tpl>
                        </Html>
                    </Template>
                </ext:ComboBox>
                <ext:CompositeField ID="CompositeField1" AnchorHorizontal="100%" runat="server">
                    <Items>
                        <ext:Checkbox runat="server" ID="chkSaturday" FieldLabel="Bao gồm thứ 7">
                            <Listeners>
                                <Check Handler="if(chkSaturday.checked){
                                                            MultiComboSaturday.enable();
                                                        }else
                                                        {
                                                            MultiComboSaturday.disable();
                                                        }" />
                            </Listeners>
                        </ext:Checkbox>
                        <ext:ComboBox ID="MultiComboSaturday" runat="server" TypeAhead="true" Width="322"
                            AnchorHorizontal="100%" ForceSelection="true" StoreID="Store2" Mode="Local" DisplayField="TenCa"
                            ValueField="MaCa" EmptyText="Chọn ca làm việc cho thứ 7" MinChars="1" ListWidth="300"
                            PageSize="10" ItemSelector="tr.list-item" Editable="false">
                            <Template ID="Template4" runat="server">
                                <Html>
                                    <tpl for=".">
						        <tpl if="[xindex] == 1">
							        <table class="cbStates-list">
								        <tr>
									        <th>Mã ca</th>
									        <th>Tên ca</th>
                                            <th>Giờ vào</th>
									        <th>Giờ ra</th>
								        </tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{MaCa}</td>
							        <td>{TenCa}</td>
                                    <td>{GioVao}</td>
                                    <td>{GioRa}</td>
						        </tr>
						        <tpl if="[xcount-xindex]==0">
							        </table>
						        </tpl>
					        </tpl>
                                </Html>
                            </Template>
                        </ext:ComboBox>
                    </Items>
                </ext:CompositeField>
                <ext:CompositeField ID="CompositeField2" AnchorHorizontal="100%" runat="server">
                    <Items>
                        <ext:Checkbox runat="server" ID="chkSunday" FieldLabel="Bao gồm CN">
                            <Listeners>
                                <Check Handler="if(chkSunday.checked){
                                                            MultiComboSunday.enable();
                                                        }else
                                                        {
                                                            MultiComboSunday.disable();
                                                        }" />
                            </Listeners>
                        </ext:Checkbox>
                        <ext:ComboBox ID="MultiComboSunday" runat="server" EmptyText="Chọn ca làm việc cho chủ nhật"
                            TypeAhead="true" Width="322" AnchorHorizontal="100%" ForceSelection="true" StoreID="Store2"
                            Mode="Local" DisplayField="TenCa" ValueField="MaCa" MinChars="1" ListWidth="300"
                            PageSize="10" ItemSelector="tr.list-item" Editable="false">
                            <Template ID="Template2" runat="server">
                                <Html>
                                    <tpl for=".">
						        <tpl if="[xindex] == 1">
							        <table class="cbStates-list">
								        <tr>
									        <th>Mã ca</th>
									        <th>Tên ca</th>
                                            <th>Giờ vào</th>
									        <th>Giờ ra</th>
								        </tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{MaCa}</td>
							        <td>{TenCa}</td>
                                    <td>{GioVao}</td>
                                    <td>{GioRa}</td>
						        </tr>
						        <tpl if="[xcount-xindex]==0">
							        </table>
						        </tpl>
					        </tpl>
                                </Html>
                            </Template>
                        </ext:ComboBox>
                    </Items>
                </ext:CompositeField>
                <ext:RadioGroup runat="server" ColumnsNumber="1" FieldLabel="Đối tượng" AnchorHorizontal="100%">
                    <Items>
                        <ext:Radio runat="server" BoxLabel="Áp dụng cho bộ phận được chọn" ID="rdApplyforSelectedDepartment" />
                        <ext:Radio runat="server" BoxLabel="Chỉ áp dụng cho những nhân viên được chọn" ID="rdApplyforSelectedEmployee">
                            <Listeners>
                                <Check Handler="if(#{rdApplyforSelectedEmployee}.checked){
                                            if(grpDanhSachBangPhanCaThang.getSelectionModel().getCount() ==0)
                                            {
                                                btnThietLapCaNhanh.disable();                                                 
                                                Ext.Msg.alert('Thông báo','Bạn chưa chọn nhân viên nào, bạn phải chọn ít nhất một nhân viên để thực hiện chức năng này'); 
                                               
                                            }
                                        }else
                                        {
                                            btnThietLapCaNhanh.enable();
                                        }" />
                            </Listeners>
                        </ext:Radio>
                    </Items>
                </ext:RadioGroup>
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnThietLapCaNhanh" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return validateFormThietLapNhanh();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnThietLapCaNhanh_Click">
                            <EventMask ShowMask="true" Msg="Đợi trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button3" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdThietLapCaNhanh}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="rdApplyforSelectedDepartment.reset();rdApplyforSelectedEmployee.reset();MultiComboSunday.reset();
                                MultiComboSaturday.reset();cbTinhTrangLamViec.reset();FromDate.reset();ToDate.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Window runat="server" ID="wdChonBangPhanCa" Icon="Clock" Constrain="true" Resizable="false"
            Layout="FormLayout" Padding="6" Width="550" Hidden="true" Modal="true" Title="Chọn bảng phân ca"
            AutoHeight="true" LabelWidth="1">
            <Items>
                <%-- <ext:Checkbox runat="server" ID="chkTaiDuLieu" BoxLabel="Tải dữ liệu ngay sau khi chọn ca">
                    <Listeners>
                        <Check Handler="if(chkTaiDuLieu.checked){
                                                txtSearchKey.reset();#{PagingToolbar1}.pageIndex = 0; 
                                                #{PagingToolbar1}.doLoad();grpDanhSachBangPhanCaThangStore.reload();
                                                changeGridpanelTitle(cbChonLaiBangPhanCa.getText());
                                            }" />
                    </Listeners>
                </ext:Checkbox>--%>
                <ext:Hidden runat="server" ID="hdfChosseBangPhanCa" />
                <ext:GridPanel ID="grpDanhSachBangPhanCa" runat="server" StripeRows="true" Border="false"
                    AnchorHorizontal="100%" Header="false" Height="350" Title="Danh sách bảng phân ca"
                    AutoExpandColumn="TenBangPhanCa">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tbgr">
                            <Items>
                                <ext:Button runat="server" ID="btnTaoBangPhanCa" Text="Thêm" Icon="Add">
                                    <Listeners>
                                        <Click Handler="wdTaoBangPhanCa.show();" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Disabled="true" ID="btnSuaBangPhanCa" Text="Sửa" Icon="Pencil"
                                    Hidden="true">
                                    <Listeners>
                                        <Click Handler="return CheckSelectedRows(grpDanhSachBangPhanCa);" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button runat="server" Text="Xóa" Icon="Delete" Disabled="true" ID="btnXoaBangPhanCa">
                                    <Listeners>
                                        <Click Handler="return CheckSelectedRow(grpDanhSachBangPhanCa);" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="btnXoaBangPhanCa_Click">
                                            <Confirmation Title="Thông báo" Message="Bạn có chắc bạn muốn xóa bảng tính lương này?"
                                                ConfirmRequest="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:ToolbarFill />
                                <ext:Container runat="server" ID="ctn111" Layout="FormLayout" LabelWidth="65">
                                    <Items>
                                        <ext:ComboBox runat="server" ID="cbxMonth" Width="70" Editable="false" FieldLabel="Chọn tháng"
                                            SelectedIndex="0">
                                            <Items>
                                                <ext:ListItem Text="Cả năm" Value="0" />
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
                                                <Select Handler="PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:Container>
                                <ext:ToolbarSpacer ID="ToolbarSpacer6" runat="server" Width="5" />
                                <ext:Container runat="server" ID="Container2" Layout="FormLayout" LabelWidth="60">
                                    <Items>
                                        <ext:SpinnerField runat="server" ID="spnYear" FieldLabel="Chọn năm" Width="55">
                                            <Listeners>
                                                <Spin Handler="PagingToolbar2.pageIndex = 0; PagingToolbar2.doLoad();" />
                                            </Listeners>
                                        </ext:SpinnerField>
                                    </Items>
                                </ext:Container>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <Store>
                        <ext:Store ID="grpDanhSachBangPhanCaStore" AutoLoad="false" GroupField="Nam" runat="server">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="Handler/HandlerDanhSachBangPhanCa.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="limit" Value="={15}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="month" Value="cbxMonth.getValue()" Mode="Raw" />
                                <ext:Parameter Name="year" Value="spnYear.getValue()" Mode="Raw" />
                                <ext:Parameter Name="maDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                <ext:Parameter Name="userID" Value="hdfUserID.getValue()" Mode="Raw" />
                                <ext:Parameter Name="menuID" Value="hdfMenuID.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="ID" />
                                        <ext:RecordField Name="NguoiTao" />
                                        <ext:RecordField Name="Thang" />
                                        <ext:RecordField Name="Nam" />
                                        <ext:RecordField Name="TenBangPhanCa" />
                                        <ext:RecordField Name="NgayTao" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                            <Listeners>
                                <Load Handler="RowSelectionModelBangPhanCa.clearSelections();
                                    hdfChosseBangPhanCa.reset();" />
                            </Listeners>
                        </ext:Store>
                    </Store>
                    <ColumnModel ID="ColumnModel3" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Header="STT" Width="35" />
                            <ext:Column ColumnID="colTitle" Header="Tên bảng phân ca" Width="160" DataIndex="TenBangPhanCa" />
                            <ext:Column ColumnID="colMonth" Header="Tháng" Width="70" DataIndex="Thang" />
                            <ext:Column ColumnID="colYear" Header="Năm" Width="70" DataIndex="Nam" />
                            <ext:Column ColumnID="colCreatedBy" Header="Người tạo" Width="100" DataIndex="NguoiTao" />
                            <ext:DateColumn ColumnID="colCreateDate" Header="Ngày tạo" Width="70" Format="dd/MM/yyyy"
                                DataIndex="NgayTao" />
                        </Columns>
                    </ColumnModel>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModelBangPhanCa" runat="server">
                            <Listeners>
                                <RowSelect Handler="try{btnSuaBangPhanCa.enable();}catch(e){} 
                                            try{btnXoaBangPhanCa.enable()}catch(e){}; 
                                            hdfChosseBangPhanCa.setValue(RowSelectionModelBangPhanCa.getSelected().id);" />
                                <RowDeselect Handler="try{btnSuaBangPhanCa.disable();}catch(e){} 
                                            try{btnXoaBangPhanCa.disable()}catch(e){}; 
                                            hdfChosseBangPhanCa.reset();" />
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
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                    </Items>
                                    <SelectedItem Value="15" />
                                    <Listeners>
                                        <Select Handler="#{PagingToolbar2}.pageSize = parseInt(this.getValue()); #{PagingToolbar2}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                            <Listeners>
                                <Change Handler="RowSelectionModelBangPhanCa.clearSelections();" />
                            </Listeners>
                        </ext:PagingToolbar>
                    </BottomBar>
                    <DirectEvents>
                        <RowDblClick OnEvent="btnChonBangPhanCa_Click">
                        </RowDblClick>
                    </DirectEvents>
                </ext:GridPanel>
            </Items>
            <Buttons>
                <ext:Button runat="server" Text="Đồng ý" Icon="Accept">
                    <Listeners>
                        <Click Handler="return CheckSelectedRows(grpDanhSachBangPhanCa)" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnChonBangPhanCa_Click" />
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChonBangPhanCa.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <BeforeShow Handler="#{PagingToolbar2}.pageIndex = 0; #{PagingToolbar2}.doLoad();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:GridPanel ID="grpDanhSachBangPhanCaThang" TrackMouseOver="true" runat="server"
                            Title="Bảng phân ca" StripeRows="true" ClicksToEdit="1" Width="600" Border="false"
                            Height="290" StoreID="grpDanhSachBangPhanCaThangStore">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="Button6" runat="server" Text="Quản lý bảng phân ca" Icon="ClockAdd">
                                            <Listeners>
                                                <Click Handler="wdChonBangPhanCa.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="Button1" Text="Quản lý giờ giấc" Icon="Clock" runat="server">
                                            <Menu>
                                                <ext:Menu ID="Menu1" runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Thiết lập ca nhanh">
                                                            <Listeners>
                                                                <Click Handler="wdThietLapCaNhanh.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="MenuItem1" runat="server" Text="Sao chép ca giữa 2 nhân viên" Hidden="true">
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button Icon="User" Text="Quản lý nhân viên" runat="server">
                                            <Menu>
                                                <ext:Menu runat="server">
                                                    <Items>
                                                        <ext:MenuItem Text="Thêm nhân viên" ID="mnuThemNhanVien" Icon="UserAdd" Hidden="false">
                                                            <Listeners>
                                                                <Click Handler="ucChooseEmployee1_hdfMenuID.setValue(#{hdfMenuID}.getValue()); ucChooseEmployee1_wdChooseUser.show();" />
                                                            </Listeners>
                                                        </ext:MenuItem>
                                                        <ext:MenuItem ID="mnuLoaiBoNhanVien" Disabled="true" Text="Loại bỏ nhân viên" Icon="UserDelete">
                                                            <DirectEvents>
                                                                <Click OnEvent="mnuLoaiBoNhanVien_Click">
                                                                    <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                </Click>
                                                            </DirectEvents>
                                                        </ext:MenuItem>
                                                    </Items>
                                                </ext:Menu>
                                            </Menu>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnSave" Text="Lưu lại" Icon="Disk" Hidden="true">
                                            <%--  <listeners>
                                                <click handler="alert(document.getelementbyid('sqlquery').innerhtml);" />
                                            </listeners>--%>
                                            <DirectEvents>
                                                <Click OnEvent="btnSave_Click">
                                                    <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                                                    <ExtraParams>
                                                        <ext:Parameter Name="sqlQuery" Value="document.getElementById('sqlQuery').innerHTML"
                                                            Mode="Raw" />
                                                    </ExtraParams>
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:Button runat="server" ID="btnExportToExcel" Text="Xuất dữ liệu ra excel" Icon="PageExcel"
                                            Hidden="false">
                                            <Listeners>
                                                <Click Handler="if (!hdfIDBangPhanCa.getValue()) {alert('Bạn chưa chọn bảng phân ca nào'); return false;}" />
                                            </Listeners>
                                            <DirectEvents>
                                                <Click OnEvent="btnExportExcel_Click" IsUpload="true">
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbf" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa để tìm kiếm"
                                            ID="txtSearchKey">
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                            <Listeners>
                                                <KeyPress Fn="enterKeyPressHandler" />
                                                <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad(); }" />
                                            </Listeners>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="PagingToolbar1.pageIndex = 0;  PagingToolbar1.doLoad();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                    <ext:Column ColumnID="MaCB" Header="Mã NV" Locked="true" Width="70" DataIndex="MaCB" />
                                    <ext:Column ColumnID="TenCB" Header="Họ tên" Locked="true" Width="150" DataIndex="TenCB" />
                                    <ext:Column Width="150" ColumnID="BoPhan" Header="Phòng ban" DataIndex="BoPhan" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay1" Header="01" DataIndex="Ngay01" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay2" Header="02" DataIndex="Ngay02" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay3" Header="03" DataIndex="Ngay03" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay4" Header="04" DataIndex="Ngay04" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay5" Header="05" DataIndex="Ngay05" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay6" Header="06" DataIndex="Ngay06" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay7" Header="07" DataIndex="Ngay07" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay8" Header="08" DataIndex="Ngay08" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay9" Header="09" DataIndex="Ngay09" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay10" Header="10" DataIndex="Ngay10" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay11" Header="11" DataIndex="Ngay11" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay12" Header="12" DataIndex="Ngay12" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay13" Header="13" DataIndex="ngay13" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay14" Header="14" DataIndex="ngay14" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay15" Header="15" DataIndex="Ngay15" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay16" Header="16" DataIndex="Ngay16" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay17" Header="17" DataIndex="Ngay17" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay18" Header="18" DataIndex="Ngay18" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay19" Header="19" DataIndex="Ngay19" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay20" Header="20" DataIndex="Ngay20" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay21" Header="21" DataIndex="Ngay21" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay22" Header="22" DataIndex="Ngay22" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay23" Header="23" DataIndex="Ngay23" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay24" Header="24" DataIndex="Ngay24" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay25" Header="25" DataIndex="Ngay25" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay26" Header="26" DataIndex="Ngay26" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay27" Header="27" DataIndex="Ngay27" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay28" Header="28" DataIndex="Ngay28" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay29" Header="29" DataIndex="Ngay29" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay30" Header="30" DataIndex="Ngay30" />
                                    <ext:Column Resizable="false" Width="70" ColumnID="Ngay31" Header="31" DataIndex="Ngay31" />
                                </Columns>
                            </ColumnModel>
                            <View>
                                <ext:LockingGridView runat="server" ID="lkv">
                                </ext:LockingGridView>
                            </View>
                            <Listeners>
                                <AfterEdit Fn="afterEdit" />
                            </Listeners>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="mnuLoaiBoNhanVien.enable();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="25">
                                    <Items>
                                        <ext:Label ID="Label1" runat="server" Text="Page size:" />
                                        <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="30" />
                                        <ext:ComboBox ID="ComboBox1" Editable="false" runat="server" Width="80">
                                            <Items>
                                                <ext:ListItem Text="10" />
                                                <ext:ListItem Text="20" />
                                                <ext:ListItem Text="25" />
                                                <ext:ListItem Text="30" />
                                                <ext:ListItem Text="50" />
                                            </Items>
                                            <SelectedItem Value="25" />
                                            <Listeners>
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                    <Listeners>
                                        <Change Handler="RowSelectionModel1.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
