<%@ Control Language="C#" AutoEventWireup="true" CodeFile="ucQuyTacTinhNgayPhep.ascx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_ucQuyTacTinhNgayPhep" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
<script type="text/javascript">
    var renderSoNgayPhep = function (value, p, record) {
        return value + ' ngày';
    }

    var getTime = function (time, tinhTheoNam) {
        if (time == null) {
            return "";
        }
        if (tinhTheoNam == '1') {
            return time + " năm";
        }
        return time + " tháng";
    }

    var checkInputTaoQuyTac = function (nbfTu, nbfDen, nbfSoNPDuocHuong, cbHinhThucLamViec) {
        if (nbfTu.getValue() == '') {
            alert("Bạn chưa nhập khoảng thời gian bắt đầu");
            nbfTu.focus();
            return false;
        }
        if (nbfDen.getValue() == '') {
            alert("Bạn chưa nhập khoảng thời gian kết thúc");
            nbfDen.focus();
            return false;
        }
        if (nbfSoNPDuocHuong.getValue() == '') {
            alert("Bạn chưa nhập số ngày phép được hưởng");
            nbfSoNPDuocHuong.focus();
            return false;
        }
        if (cbHinhThucLamViec.getValue() == '') {
            alert("Bạn chưa chọn hình thức làm việc");
            cbHinhThucLamViec.focus();
            return false;
        }
        if (nbfTu.getValue() > nbfDen.getValue()) {
            alert("Bạn nhập thời gian bị mâu thuẫn");
            nbfTu.focus();
            return false;
        }
        return true;
    }
</script>
<ext:Window Icon="Cog" runat="server" ID="wdTaoQuyTac" Layout="FormLayout" Resizable="false"
    Constrain="true" Hidden="true" AutoHeight="true" Width="420" LabelWidth="130"
    Padding="6" Modal="true" Title="Tạo mới quy tắc">
    <Items>
        <ext:CompositeField runat="server" FieldLabel="Thời gian<span style='color:red;'>*</span>"
            AnchorHorizontal="100%" CtCls="requiredData">
            <Items>
                <ext:DisplayField runat="server" Text="Từ" ID="dpfTu" />
                <ext:NumberField runat="server" Width="60" ID="nbfTu" CtCls="requiredData" AllowNegative="false" MaxLength="9"/>
                <ext:DisplayField runat="server" Text="Đến" ID="dpfDen" />
                <ext:NumberField runat="server" Width="60" ID="nbfDen" CtCls="requiredData" AllowNegative="false" MaxLength="9"/>
                <ext:ComboBox runat="server" Width="81" Editable="false" SelectedIndex="0" ID="cbThoiGian">
                    <Items>
                        <ext:ListItem Text="Tháng" Value="False" />
                        <ext:ListItem Text="Năm" Value="True" />
                    </Items>
                </ext:ComboBox>
            </Items>
        </ext:CompositeField>
        <ext:NumberField runat="server" ID="nbfSoNPDuocHuong" AnchorHorizontal="100%" EmptyText="Nhập số ngày phép được hưởng" MaxLength="9"
            AllowNegative="false" FieldLabel="Số NP được hưởng<span style='color:red;'>*</span>"
            CtCls="requiredData" />
        <ext:ComboBox runat="server" FieldLabel="Hình thức làm việc<span style='color:red;'>*</span>"
            CtCls="requiredData" DisplayField="Value" ValueField="ID" Editable="false" IDMode="Static"
            AnchorHorizontal="100%" ID="cbHinhThucLamViec">
            <Store>
                <ext:Store runat="server" ID="cbHinhThucLamViecStore" AutoLoad="false" OnRefreshData="cbHinhThucLamViecStore_OnRefreshData">
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
        </ext:ComboBox>
        <ext:Checkbox runat="server" ID="chkIsInUsed" FieldLabel="Tình trạng" Checked="true"
            BoxLabel="Quy tắc này vẫn đang được sử dụng" />
    </Items>
    <Listeners>
        <BeforeShow Handler="if(#{cbHinhThucLamViec}.store.getCount()==0){#{cbHinhThucLamViecStore}.reload();}" />
        <Hide Handler="#{btnUpdateAfterEditting}.hide();#{btnUpdateAndClose}.show();#{btnUpdate}.show();
                       #{nbfTu}.reset(); #{nbfDen}.reset(); #{cbThoiGian}.reset(); #{nbfSoNPDuocHuong}.reset(); #{cbHinhThucLamViec}.reset(); #{chkIsInUsed}.reset();" />
    </Listeners>
    <Buttons>
        <ext:Button runat="server" ID="btnUpdate" Text="Cập nhật" Icon="Disk">
            <Listeners>
                <Click Handler="return checkInputTaoQuyTac(#{nbfTu}, #{nbfDen}, #{nbfSoNPDuocHuong}, #{cbHinhThucLamViec});" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdate_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnUpdateAfterEditting" Text="Cập nhật" Hidden="true"
            Icon="Disk">
            <Listeners>
                <Click Handler="return checkInputTaoQuyTac(#{nbfTu}, #{nbfDen}, #{nbfSoNPDuocHuong}, #{cbHinhThucLamViec});" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdate_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True">
                        </ext:Parameter>
                        <ext:Parameter Name="Command" Value="Update" />
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnUpdateAndClose" Text="Cập nhật & Đóng lại" Icon="Disk">
            <Listeners>
                <Click Handler="return checkInputTaoQuyTac(#{nbfTu}, #{nbfDen}, #{nbfSoNPDuocHuong}, #{cbHinhThucLamViec});" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="btnUpdate_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdTaoQuyTac}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
<ext:Window Icon="Cog" runat="server" ID="wdQuyTacTinhNgayPhep" Resizable="false"
    Constrain="true" Hidden="true" AutoHeight="true" Width="450" Padding="0" Modal="true"
    Title="Thiết lập quy tắc tính ngày phép">
    <Items>
        <ext:Hidden runat="server" ID="hdfLoaded" />
        <ext:GridPanel runat="server" ID="grpQuyTacTinhNgayPhep" Border="false" AnchorHorizontal="100%"
            AutoExpandColumn="HinhThucLamViec" Height="320" AutoExpandMin="150">
            <TopBar>
                <ext:Toolbar runat="server" ID="tb">
                    <Items>
                        <ext:Button runat="server" ID="btnAdd" Icon="Add" Text="Thêm">
                            <Listeners>
                                <Click Handler="#{wdTaoQuyTac}.show();" />
                            </Listeners>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnEdit" Disabled="true" Icon="Pencil" Text="Sửa">
                            <Listeners>
                                <Click Handler="#{btnUpdateAfterEditting}.show();#{btnUpdateAndClose}.hide();#{btnUpdate}.hide();" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnEdit_Click">
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button runat="server" ID="btnDelete" Disabled="true" Icon="Delete" Text="Xóa">
                            <DirectEvents>
                                <Click OnEvent="btnDelete_Click">
                                    <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ? " ConfirmRequest="true" />
                                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <Store>
                <ext:Store runat="server" ID="grpQuyTacTinhNgayPhepStore" GroupField="HinhThucLamViec"
                    AutoLoad="false" OnRefreshData="grpQuyTacTinhNgayPhepStore_OnRefreshData">
                    <Reader>
                        <ext:JsonReader IDProperty="ID">
                            <Fields>
                                <ext:RecordField Name="ID" />
                                <ext:RecordField Name="ThamNienTu" />
                                <ext:RecordField Name="ThamNienDen" />
                                <ext:RecordField Name="SoNgayPhepDuocHuong" />
                                <ext:RecordField Name="HinhThucLamViec" />
                                <ext:RecordField Name="TinhTheoNam" />
                                <ext:RecordField Name="IsInUsed" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <ColumnModel>
                <Columns>
                    <ext:RowNumbererColumn Header="STT" Width="35" />
                    <ext:Column DataIndex="ThamNienTu" Width="80" ColumnID="ThamNienTu" Header="Thời gian từ">
                        <Renderer Handler="return getTime(record.data.ThamNienTu,record.data.TinhTheoNam)" />
                    </ext:Column>
                    <ext:Column DataIndex="ThamNienDen" Width="90" ColumnID="ThamNienDen" Header="Thời gian đến">
                        <Renderer Handler="return getTime(record.data.ThamNienDen,record.data.TinhTheoNam)" />
                    </ext:Column>
                    <ext:Column DataIndex="SoNgayPhepDuocHuong" Width="150" Align="Right" ColumnID="SoNgayPhepDuocHuong"
                        Header="Số ngày phép được hưởng">
                        <Renderer Fn="renderSoNgayPhep" />
                    </ext:Column>
                    <ext:Column DataIndex="HinhThucLamViec" Width="100" ColumnID="HinhThucLamViec" Header="Hình thức làm việc" />
                    <ext:CheckColumn Width="50" DataIndex="IsInUsed" Header="Đang sử dụng" Align="Center">
                        <Renderer Fn="GetBooleanIcon" />
                    </ext:CheckColumn>
                </Columns>
            </ColumnModel>
            <View>
                <ext:GroupingView ID="GroupingView1" Header="Hình thức làm việc : " runat="server"
                    ForceFit="true" MarkDirty="false" ShowGroupName="false" EnableNoGroups="true"
                    HideGroupedColumn="true" />
            </View>
            <Listeners>
                <RowDblClick Handler="#{btnUpdateAfterEditting}.show();#{btnUpdateAndClose}.hide();#{btnUpdate}.hide();" />
                <ViewReady Handler="if(cbHinhThucLamViec.store.getCount()==0){cbHinhThucLamViecStore.reload();}" />
            </Listeners>
            <SelectionModel>
                <ext:RowSelectionModel runat="server" SingleSelect="true" ID="RowSelectionModel1">
                    <Listeners>
                        <RowSelect Handler="#{btnEdit}.enable();#{btnDelete}.enable();" />
                    </Listeners>
                </ext:RowSelectionModel>
            </SelectionModel>
            <DirectEvents>
                <RowDblClick OnEvent="btnEdit_Click">
                    <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                </RowDblClick>
            </DirectEvents>
        </ext:GridPanel>
    </Items>
    <Listeners>
        <BeforeShow Handler="if(#{hdfLoaded}.getValue()==''){#{grpQuyTacTinhNgayPhepStore}.reload();#{hdfLoaded}.setValue('True');}" />
    </Listeners>
    <Buttons>
        <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdQuyTacTinhNgayPhep}.hide();" />
            </Listeners>
        </ext:Button>
    </Buttons>
</ext:Window>
