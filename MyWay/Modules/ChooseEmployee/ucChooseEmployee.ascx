<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucChooseEmployee.ascx.cs"
    Inherits="Modules_ChooseEmployee_ucChooseEmployee" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    var store3;
    var SetStore = function (s3) {
        store3 = s3;
    }
    var enterKeyToSearch = function (f, e) {
        try {
            this.triggers[0].show();
            if (e.getKey() == e.ENTER) {
                store3.reload();
            }
            if (txtFullName.getValue() == '') {
                this.triggers[0].hide();
            }
        } catch (e) {

        }
    }
    var btnAddEmployee_CheckSelectRow = function (gridPanel, hdfHoTenCanBo) {
        if (gridPanel.getSelectionModel().getCount() == 0) {
            Ext.Msg.alert("Thông báo", "Bạn phải chọn ít nhất một nhân viên !");
            return false;
        }
        getEmployeeName(gridPanel, hdfHoTenCanBo);
        return true;
    }

    var getEmployeeName = function (gridPanel, hdfHoTenCanBo) {
        var s = gridPanel.getSelectionModel().getSelections();
        var rs = "";
        for (var i = 0, r; r = s[i]; i++) {
            rs += r.data.HO_TEN + ", ";
        }
        hdfHoTenCanBo.setValue(rs);
    }
</script>
<%--<ext:Hidden runat="server" ID="hdfMaDonVi" />--%>
<ext:Hidden runat="server" ID="hdfChiChonMotCanBo" />
<ext:Hidden runat="server" ID="hdfHoTenCanBo" />
<ext:Hidden runat="server" ID="hdfMenuID" />
<ext:Window Modal="true" Resizable="false" Hidden="true" runat="server" ID="wdChooseUser"
    Constrain="true" Title="Chọn danh sách nhân viên" Icon="UserAdd" Width="600"
    Padding="6" AutoHeight="true">
    <Items>
        <ext:Container ID="Container1" runat="server" Height="330" Layout="FormLayout">
            <Items>
                <%--<ext:DropDownField runat="server" Editable="false" ID="DropDownField1" AnchorHorizontal="100%"
                    FieldLabel="Chọn phòng ban">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Component>
                        <ext:TreePanel ID="TreePanel2" runat="server" Icon="Accept" Height="300" Shadow="None"
                            EnableViewState="false" UseArrows="true" AutoScroll="true" Animate="true" EnableDD="true"
                            ContainerScroll="true" RootVisible="false">
                            <Root>
                            </Root>
                        </ext:TreePanel>
                    </Component>
                    <Listeners>
                        <Expand Handler=" this.component.getRootNode().expand(true);" Single="true" Delay="10" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();} #{Store3}.reload();" />
                    </Listeners>
                </ext:DropDownField>--%>
                <ext:ComboBox runat="server" ID="cbDepartmentList" FieldLabel="Chọn phòng ban"
                    CtCls="requiredData" DisplayField="TEN" ValueField="MA" LoadingText="Đang tải dữ liệu..."
                    ItemSelector="div.list-item" AnchorHorizontal="98%" TabIndex="33" Editable="false"
                    AllowBlank="false">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
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
                        <ext:Store runat="server" ID="stDepartmentList" AutoLoad="false" OnRefreshData="stDepartmentList_OnRefreshData">
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
                        <Expand Handler="if(#{stDepartmentList}.getCount()==0) #{stDepartmentList}.reload();" />
                        <Select Handler="#{PagingToolbar2}.pageIndex=0;#{PagingToolbar2}.doLoad();" />
                        <%--if(ddfDonvi.getValue() <= 0) {alert('Bạn không có quyền thao tác với bộ phận này!'); ddfDonvi.reset();}txtTenBangPhanCa.setValue('Bảng phân ca tháng ' + cbThang.getValue() + '/' + spfYear.getValue() + ' tại bộ phận ' + ddfDonvi.getText().replace('[', '').replace(']', '').replace(/-/g, '')); hdfStringMaDonVi.setValue(ddfDonvi.getValue());--%>
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:GridPanel runat="server" ID="EmployeeGrid" Icon="UserAdd" Header="false" Title="Danh sách nhân viên"
                    AutoExpandColumn="HoVaTen" AnchorHorizontal="100%" Height="300">
                    <TopBar>
                        <ext:Toolbar runat="server" ID="tbEmployeeGrid">
                            <Items>
                                <ext:ComboBox runat="server" LabelWidth="30" Width="200" SelectedIndex="0" Editable="false"
                                    ID="cbLoaiNhanVien" FieldLabel="Lọc">
                                    <Listeners>
                                        <Select Handler="#{Store3}.reload();" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <ext:TriggerField runat="server" EnableKeyEvents="true" ID="txtFullName" EmptyText="Nhập tên nhân viên">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <KeyPress Fn="enterKeyToSearch" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); store3.reload(); }" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:Button ID="Button3" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                    <Listeners>
                                        <Click Handler="#{Store3}.reload();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <SelectionModel>
                        <ext:CheckboxSelectionModel runat="server" ID="chkEmployeeRowSelection" />
                    </SelectionModel>
                    <ColumnModel ID="ColumnModel2" runat="server">
                        <Columns>
                            <ext:RowNumbererColumn Width="30" Header="STT" />
                            <ext:Column Header="Mã CB" Width="60" DataIndex="MA_CB">
                            </ext:Column>
                            <ext:Column Header="Họ Tên" ColumnID="HoVaTen" DataIndex="HO_TEN">
                            </ext:Column>
                            <ext:DateColumn Header="Ngày sinh" Format="dd/MM/yyyy" DataIndex="NGAY_SINH">
                            </ext:DateColumn>
                            <ext:Column Header="Giới tính" DataIndex="GIOI_TINH">
                            </ext:Column>
                            <ext:Column Header="Bộ phận" DataIndex="DonViCongTac">
                            </ext:Column>
                        </Columns>
                    </ColumnModel>
                    <Store>
                        <ext:Store ID="Store3" ShowWarningOnFailure="false" SkipIdForNewRecords="false" runat="server"
                            AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Json="true" Method="GET" Url="Handler.ashx" />
                            </Proxy>
                            <AutoLoadParams>
                                <ext:Parameter Name="start" Value="={0}" />
                                <ext:Parameter Name="limit" Value="={20}" />
                            </AutoLoadParams>
                            <BaseParams>
                                <ext:Parameter Name="MaDonVi" Value="#{cbDepartmentList}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="SearchKey" Value="#{txtFullName}.getValue()" Mode="Raw" />
                                <ext:Parameter Name="Loc" Value="#{cbLoaiNhanVien}.getValue()" Mode="Raw" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="Data" IDProperty="MA_CB" TotalProperty="TotalRecords">
                                    <Fields>
                                        <ext:RecordField Name="MA_CB" />
                                        <ext:RecordField Name="HO_TEN" />
                                        <ext:RecordField Name="NGAY_SINH" />
                                        <ext:RecordField Name="GIOI_TINH" />
                                        <ext:RecordField Name="DonViCongTac" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <SaveMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    <BottomBar>
                        <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                            PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                            DisplayMsg="{0}-{1} / tổng số {2} dòng" runat="server">
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Items>
        </ext:Container>
    </Items>
    <Buttons>
        <ext:Button runat="server" Text="Đồng ý" ID="btnAddEmployee" Icon="Accept">
            <Listeners>
                <Click Handler="return btnAddEmployee_CheckSelectRow(#{EmployeeGrid},#{hdfHoTenCanBo});" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnAddEmployee_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button ID="Button4" runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdChooseUser}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="SetStore(#{Store3});" />
        <Hide Handler="#{EmployeeGrid}.getSelectionModel().clearSelections();" />
    </Listeners>
</ext:Window>
