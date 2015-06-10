<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CongThucLuongKinhDoanh.aspx.cs"
    Inherits="Modules_TienLuong_CongThucLuongKinhDoanh" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var RenderPhanTram = function (value, p, record) {
            if (value == null || value.length == 0)
                return "";
            return value + " %";
        }
        var RenderName = function (value, p, record) {
            if (value == null || value.length == 0)
                return "";
            if (value.indexOf('#') != -1) {
                return '';
            }
            else {
                return value;
            }
        }
        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar1.pageIndex = 0; PagingToolbar1.doLoad();
            }
            if (txtSearch.getValue() != '')
                this.triggers[0].show();
        }
        var CheckInput = function () {
            if (!cbx_Nhom.getValue()) {
                alert('Bạn chưa chọn nhóm công thức lương kinh doanh');
                cbx_Nhom.focus();
                return false;
            }
            if (!cbx_chucvu.getValue()) {
                alert('Bạn chưa chọn chức vụ');
                cbx_chucvu.focus();
                return false;
            }
            return true;
        }
        var ResetForm = function () {
            /*cbx_Nhom.reset(); */cbx_Nhom.enable(); txtPhanTramTu.reset();
            txtSanLuongTu.reset(); txtPhanTramDen.reset(); txtSanLuongDen.reset();
            txtTienThuong.reset(); /*hdfChucVu.reset();*/
            /*cbx_chucvu.reset();*/

            wdAddWindow.setTitle('Thêm mới công thức lương kinh doanh');
        }
        var SetDetailData = function () {
            cbx_Nhom.setValue(checkboxSelection.getSelected().data.Nhom);
            txtPhanTramTu.setValue(checkboxSelection.getSelected().data.PhanTramTu);
            txtPhanTramDen.setValue(checkboxSelection.getSelected().data.PhanTramDen);
            txtSanLuongTu.setValue(checkboxSelection.getSelected().data.SanLuongTu);
            txtSanLuongDen.setValue(checkboxSelection.getSelected().data.SanLuongDen);
            txtTienThuong.setValue(checkboxSelection.getSelected().data.TienThuong);
            cbx_chucvu.setValue(checkboxSelection.getSelected().data.TEN_CHUCVU);
            hdfChucVu.setValue(checkboxSelection.getSelected().data.MaChucVu);
        }
        
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfRecordID" />
        <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
            Width="400" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới công thức lương kinh doanh"
            Icon="Add">
            <Items>
                <ext:ComboBox runat="server" ID="cbx_Nhom" FieldLabel="Nhóm<span style='color:red'>*</span>"
                    AnchorHorizontal="100%" CtCls="requiredData" EmptyText="Nhóm công thức lương kinh doanh"
                    TabIndex="1">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Items>
                        <ext:ListItem Text="Thưởng Target tháng" Value="ThuongTargetThang" />
                        <ext:ListItem Text="Phạt Target tháng" Value="PhatTargetThang" />
                        <ext:ListItem Text="Thưởng tăng trưởng tháng" Value="ThuongTangTruongThang" />
                        <ext:ListItem Text="Phạt tăng trưởng tháng" Value="PhatTangTruongThang" />
                        <ext:ListItem Text="Thưởng tăng trưởng quý" Value="ThuongTangTruongQuy" />
                        <ext:ListItem Text="Phạt tăng trưởng quý" Value="PhatTangTruongQuy" />
                        <ext:ListItem Text="Tiền xăng xe" Value="TienXangXe" />
                        <ext:ListItem Text="Tiền tiếp khách" Value="TienTiepKhach" />
                        <ext:ListItem Text="Tiền thưởng SPCL" Value="ThuongSPCL" />
                        <ext:ListItem Text="Tiền thưởng SPKK" Value="ThuongSPKK" />
                    </Items>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Hidden runat="server" ID="hdfChucVu" />
                <ext:ComboBox runat="server" ID="cbx_chucvu" FieldLabel="Chức vụ<span style='color:red'>*</span>"
                    DisplayField="TEN" PageSize="15" MinChars="1" ValueField="MA" AnchorHorizontal="100%"
                    TabIndex="37" Editable="true" ItemSelector="div.list-item" EmptyText="Gõ để tìm kiếm"
                    CtCls="requiredData" LoadingText="Đang tải dữ liệu">
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Template ID="Template20" runat="server">
                        <Html>
                            <tpl for=".">
						                                                                <div class="list-item"> 
							                                                                {TEN}
						                                                                </div>
					                                                                </tpl>
                        </Html>
                    </Template>
                    <Store>
                        <ext:Store ID="cbx_chucvu_Store" runat="server" AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/SearchDanhMucHandler.ashx" />
                            </Proxy>
                            <BaseParams>
                                <ext:Parameter Name="table" Value="DM_CHUCVU" Mode="Value" />
                                <ext:Parameter Name="ma" Value="MA_CHUCVU" Mode="Value" />
                                <ext:Parameter Name="ten" Value="TEN_CHUCVU" Mode="Value" />
                            </BaseParams>
                            <Reader>
                                <ext:JsonReader Root="plants" TotalProperty="total">
                                    <Fields>
                                        <ext:RecordField Name="MA" />
                                        <ext:RecordField Name="TEN" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <ToolTips>
                        <ext:ToolTip runat="server" ID="ToolTip7" Title="Hướng dẫn" Html="Nhập tên chức vụ để tìm kiếm. Nhập <span style='color:red;'>*</span> nếu muốn tìm tất cả." />
                    </ToolTips>
                    <Listeners>
                        <Expand Handler="cbx_chucvu_Store.reload();" />
                        <Select Handler="this.triggers[0].show(); hdfChucVu.setValue(cbx_chucvu.getValue());" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChucVu.reset(); }" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Container runat="server" ID="ctn1" Layout="ColumnLayout" AnchorHorizontal="100%"
                    Height="52">
                    <Items>
                        <ext:Container runat="server" ID="ctn2" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtPhanTramTu" FieldLabel="Phần trăm từ" MaskRe="/[0-9.,]/"
                                    AnchorHorizontal="98%" MaxLength="18" TabIndex="2">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtSanLuongTu" FieldLabel="Sản lượng từ" MaskRe="/[0-9.,]/"
                                    TabIndex="4" MaxLength="18" AnchorHorizontal="98%">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="ctn3" Layout="FormLayout" ColumnWidth="0.5">
                            <Items>
                                <ext:TextField runat="server" ID="txtPhanTramDen" FieldLabel="Phần trăm đến" MaxLength="100"
                                    TabIndex="3" AnchorHorizontal="100%">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txtSanLuongDen" FieldLabel="Sản lượng đến" MaskRe="/[0-9.,]/"
                                    AnchorHorizontal="100%" MaxLength="18" TabIndex="5">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" ID="txtTienThuong" FieldLabel="Tiền thưởng" MaskRe="/[-0-9.,]/"
                    TabIndex="6" AnchorHorizontal="100%" MaxLength="18">
                </ext:TextField>
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
                                <ext:Parameter Name="Edit" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btnCapNhatVaDongLai" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
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
                        <Click Handler="#{wdAddWindow}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="ResetForm();" />
            </Listeners>
        </ext:Window>
        <ext:Store ID="Store1" AutoLoad="true" runat="server" GroupField="TenNhom">
            <Proxy>
                <ext:HttpProxy Method="GET" Url="Handler/CongThucLuongKinhDoanhHandler.ashx" />
            </Proxy>
            <AutoLoadParams>
                <ext:Parameter Name="start" Value="={0}" />
                <ext:Parameter Name="limit" Value="={30}" />
            </AutoLoadParams>
            <BaseParams>
                <ext:Parameter Name="searchKey" Value="txtSearch.getValue()" Mode="Raw" />
            </BaseParams>
            <Reader>
                <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                    <Fields>
                        <ext:RecordField Name="ID" />
                        <ext:RecordField Name="Nhom" />
                        <ext:RecordField Name="PhanTramTu" />
                        <ext:RecordField Name="PhanTramDen" />
                        <ext:RecordField Name="SanLuongTu" />
                        <ext:RecordField Name="SanLuongDen" />
                        <ext:RecordField Name="TienThuong" />
                        <ext:RecordField Name="TenNhom" />
                        <ext:RecordField Name="TEN_CHUCVU" />
                        <ext:RecordField Name="MaChucVu" />
                    </Fields>
                </ext:JsonReader>
            </Reader>
        </ext:Store>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="GridCongThucLuongKinhDoanh" Border="false" runat="server" StoreID="Store1"
                            StripeRows="true" Icon="ApplicationViewColumns" TrackMouseOver="false" AnchorHorizontal="100%"
                            AutoExpandMin="180">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tb">
                                    <Items>
                                        <ext:Button ID="btnThemCongThuc" runat="server" Text="Thêm mới" Icon="UserAdd">
                                            <Listeners>
                                                <Click Handler="btnCapNhat.show();btnSua.hide();btnCapNhatVaDongLai.show();
                                                                #{wdAddWindow}.show();" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnEditCongThuc" Disabled="true" runat="server" Text="Sửa" Icon="Pencil">
                                            <Listeners>
                                                <Click Handler="SetDetailData();btnCapNhat.hide();btnSua.show();btnCapNhatVaDongLai.hide();
                                                                #{wdAddWindow}.show();wdAddWindow.setTitle('Cập nhật công thức lương kinh doanh');" />
                                            </Listeners>
                                        </ext:Button>
                                        <ext:Button ID="btnXoaCongThuc" runat="server" Disabled="true" Text="Xóa" Icon="Delete">
                                            <DirectEvents>
                                                <Click OnEvent="btnDelete_Click">
                                                    <Confirmation Message="Bạn có chắc chắn muốn xóa không?" ConfirmRequest="true" />
                                                </Click>
                                            </DirectEvents>
                                        </ext:Button>
                                        <ext:ToolbarFill runat="server" ID="tbfill" />
                                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập chức vụ"
                                            ID="txtSearch">
                                            <Listeners>
                                                <Blur Handler="this.triggers[0].show();" />
                                                <TriggerClick Handler="#{txtSearch}.reset(); #{PagingToolbar1}.pageIndex=0; #{PagingToolbar1}.doLoad(); this.triggers[0].hide();" />
                                                <KeyPress Fn="enterKeyPressHandler" />
                                            </Listeners>
                                            <Triggers>
                                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                            </Triggers>
                                        </ext:TriggerField>
                                        <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                            <Listeners>
                                                <Click Handler="#{PagingToolbar1}.pageIndex=0; #{PagingToolbar1}.doLoad();
                                                                    if (txtSearch.getValue() != '') {
                                                                        this.triggers[0].show();
                                                                    } else {
                                                                        this.triggers[0].hide();
                                                                    }" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Locked="true" Header="STT" Width="35" />
                                    <ext:Column ColumnID="TenNhom" Header="Tên nhóm" DataIndex="TenNhom" Width="150" />
                                    <ext:Column ColumnID="TEN_CHUCVU" Header="Chức vụ" DataIndex="TEN_CHUCVU" Width="150">
                                    </ext:Column>
                                    <ext:Column ColumnID="PhanTramTu" Header="Phần trăm từ" DataIndex="PhanTramTu" Width="90"
                                        Align="Right">
                                        <Renderer Fn="RenderPhanTram" />
                                    </ext:Column>
                                    <ext:Column ColumnID="PhanTramDen" Header="Phần trăm đến" DataIndex="PhanTramDen"
                                        Width="90" Align="Right">
                                        <Renderer Fn="RenderPhanTram" />
                                    </ext:Column>
                                    <ext:Column ColumnID="SanLuongTu" Header="Sản lượng từ" DataIndex="SanLuongTu" Width="90"
                                        Align="Right">
                                    </ext:Column>
                                    <ext:Column ColumnID="SanLuongDen" Header="Sản lượng đến" DataIndex="SanLuongDen"
                                        Width="90" Align="Right">
                                    </ext:Column>
                                    <ext:Column ColumnID="TienThuong" Header="Tiền thưởng" DataIndex="TienThuong" Width="120"
                                        Align="Right">
                                        <Renderer Fn="RenderVND" />
                                    </ext:Column>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                    <Listeners>
                                        <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);
                                            try{btnXoaCongThuc.enable();}catch(e){};
                                            try{btnEditCongThuc.enable();}catch(e){}" />
                                        <RowDeselect Handler="try{btnEditCongThuc.disable();}catch(e){};
                                                               try{btnXoaCongThuc.disable();}catch(e){};
                                                               hdfRecordID.reset();" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <View>
                                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="true" MarkDirty="false"
                                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                            </View>
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
                                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                            </Listeners>
                                        </ext:ComboBox>
                                    </Items>
                                </ext:PagingToolbar>
                            </BottomBar>
                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                            <Listeners>
                                <RowDblClick Handler="SetDetailData();btnCapNhat.hide();btnSua.show();btnCapNhatVaDongLai.hide();
                                                                #{wdAddWindow}.show();wdAddWindow.setTitle('Cập nhật công thức lương kinh doanh');">
                                </RowDblClick>
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
