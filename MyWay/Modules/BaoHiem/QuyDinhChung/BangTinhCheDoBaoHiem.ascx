<%@ Control Language="C#" AutoEventWireup="true" CodeFile="BangTinhCheDoBaoHiem.ascx.cs"
    Inherits="Modules_BaoHiem_tesst" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<style type="text/css">
    #ext-gen563
    {
        height: 35px !important;
        width: 60px !important;
    }
    #BangTinhCheDoBaoHiem1_Menu5
    {
        width: 238px !important;
    }
    #BangTinhCheDoBaoHiem1_FieldSet6
    {
        height: 120px !important;
    }
    .txtto
    {
        padding: 7px;
    }
    #ext-gen578
    {
        text-align: left !important;
    }
</style>
<script type="text/javascript">
    var XoaCongThuc = function () {
        var v = BangTinhCheDoBaoHiem1_txaCongThuc.getValue();
        var splited = v.split(' ');
        var rs = "";
        for (var i = 0; i < splited.length - 1; i++) {
            rs += splited[i] + ' ';
        }
        BangTinhCheDoBaoHiem1_txaCongThuc.setValue(rs.substring(0, rs.lastIndexOf(' ')));
    }
    var check = function () {
        if (BangTinhCheDoBaoHiem1_ddfCheDoNghi.getValue().length == 0) {
            alert('Bạn chưa chọn chế độ nghỉ');
            BangTinhCheDoBaoHiem1_ddfCheDoNghi.setValue('');
            BangTinhCheDoBaoHiem1_ddfCheDoNghi.focus();
            return false;
        }
        if (BangTinhCheDoBaoHiem1_txtMaDieuKienHuong.getValue().length == 0) {
            alert('Bạn chưa nhập mã điều kiện hưởng');
            BangTinhCheDoBaoHiem1_txtMaDieuKienHuong.setValue('');
            BangTinhCheDoBaoHiem1_txtMaDieuKienHuong.focus();
            return false;
        }
        if (BangTinhCheDoBaoHiem1_nfThoiGianDongBaoHiem.getValue().length == 0) {
            alert('Bạn chưa chọn năm đóng bảo hiểm');
            BangTinhCheDoBaoHiem1_nfThoiGianDongBaoHiem.setValue(''); BangTinhCheDoBaoHiem1_nfThoiGianDongBaoHiem.focus();
            return false;
        }
        if (BangTinhCheDoBaoHiem1_nfThoiGianHuongCheDo.getValue().length == 0) {
            alert('Bạn chưa chọn ngày hưởng chế độ');
            BangTinhCheDoBaoHiem1_nfThoiGianHuongCheDo.setValue('');
            BangTinhCheDoBaoHiem1_nfThoiGianHuongCheDo.focus();
            return false;
        }
        if (BangTinhCheDoBaoHiem1_txaCongThuc.getValue().length == 0) {
            alert('Bạn chưa nhập công thức');
            BangTinhCheDoBaoHiem1_txaCongThuc.setValue('');
            BangTinhCheDoBaoHiem1_txaCongThuc.focus();
            return false;
        }

        return true;
    }
    var resetWdBangTinhCheDo = function () {
        BangTinhCheDoBaoHiem1_ddfCheDoNghi.reset();
        BangTinhCheDoBaoHiem1_txtDieuKienHuong.reset();
        BangTinhCheDoBaoHiem1_nfThoiGianDongBaoHiem.reset();
        BangTinhCheDoBaoHiem1_nfThoiGianHuongCheDo.reset();
        BangTinhCheDoBaoHiem1_txaCongThuc.reset();
        BangTinhCheDoBaoHiem1_txaYeuCauThuTuc.reset();
        BangTinhCheDoBaoHiem1_txaDienGiai.reset();
        BangTinhCheDoBaoHiem1_txtMaDieuKienHuong.reset();
        BangTinhCheDoBaoHiem1_hdfCheDoNghi.reset();
    }
    var enterKeyPressHandler2 = function (f, e) {
        if (e.getKey() == e.ENTER) {
            //            BangTinhCheDoBaoHiem1_Store3.reload();
            BangTinhCheDoBaoHiem1_PagingToolbar1.pageIndex = 0;
            BangTinhCheDoBaoHiem1_PagingToolbar1.doLoad();
        }
        if (BangTinhCheDoBaoHiem1_txtsearch.getValue() != '') {
            this.triggers[0].show();
        }
    }
    var Grid_CheckSelectRow = function () {
        if (BangTinhCheDoBaoHiem1_hdfIdTinhCheDoBH.getValue() == '') {
            Ext.Msg.alert("Thông báo", "Bạn phải chọn ít nhất một chế độ bảo hiểm !");
            return false;
        }
        BangTinhCheDoBaoHiem1_btnedit.enable();
        BangTinhCheDoBaoHiem1_btndelete.enable();
        return true;
    }
    var RemoveItemOnGrid4 = function (grid, Store, id, DirectMethods) {
        Ext.Msg.confirm('Xác nhận', 'Bạn có chắc chắn muốn xóa không ?', function (btn) {
            if (btn == "yes") {
                try {
                    grid.getRowEditor().stopEditing();
                } catch (e) {

                }
                var s = grid.getSelectionModel().getSelections();
                for (var i = 0, r; r = s[i]; i++) {
                    Store.remove(r);
                    Store.commitChanges();

                    DirectMethods.DeleteRecord(r.data.IDBangTinhCheDoBaoHiem);
                    BangTinhCheDoBaoHiem1_btnedit.disable();
                    BangTinhCheDoBaoHiem1_btndelete.disable();
                }
            }
        });

    }
    var RenderNgayCheDoBH = function (value, p, record) {
        return value + " ngày";

    }
    var RenderNamCheDoBH = function (value, p, record) {

        return value + " tháng";
    }
    var CheckSelectedRows = function (grid) {
        var s = grid.getSelectionModel().getSelections();
        var count = 0;
        for (var i = 0, r; r = s[i]; i++) {
            count++;
        }
        if (count == 0) {
            alert('Bạn chưa chọn bản ghi nào!');
            return false;
        }
        if (count > 1) {
            alert('Bạn chỉ được chọn một bản ghi');
            return false;
        }
        return true;
    }
</script>
<ext:Hidden runat="server" ID="hdfIdTinhCheDoBH" Hidden="true">
</ext:Hidden>
<ext:Hidden runat="server" ID="hdfMaDonVi" Hidden="true">
</ext:Hidden>
<ext:Window runat="server" Hidden="true" ID="wdBangTinhCheDoBaoHiem" Title="Thêm mới công thức tính chế độ bảo hiểm"
    Icon="Add" Width="540" AutoHeight="true" Constrain="true" Modal="true">
    <Items>
        <ext:Panel ID="Panel7" AutoHeight="true" Padding="6" runat="server" Border="false">
            <Items>
                <ext:Container ID="Container8" runat="server" AnchorHorizontal="100%" Layout="FormLayout"
                    LabelWidth="125">
                    <Content>
                        <ext:Hidden runat="server" ID="hdfCheDoNghi" />
                        <ext:ComboBox runat="server" ID="ddfCheDoNghi" FieldLabel="Chế độ nghỉ<span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="99%" ValueField="ID" DisplayField="TenCheDoBaoHiem"
                            Editable="false">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear"  HideTrigger="true" />
                            </Triggers>
                            <Store>
                                <ext:Store runat="server" ID="Store_ddfCheDoNghi" OnRefreshData="Store_ddfCheDoNghi_OnRefreshData"
                                    AutoLoad="false">
                                    <Reader>
                                        <ext:JsonReader IDProperty="ID">
                                            <Fields>
                                                <ext:RecordField Name="ID">
                                                </ext:RecordField>
                                                <ext:RecordField Name="TenCheDoBaoHiem">
                                                </ext:RecordField>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <Listeners>
                                <Select Handler="#{hdfCheDoNghi}.setValue(this.getValue());this.triggers[0].show();" />
                                <TriggerClick Handler="#{hdfCheDoNghi}.reset(); this.clear(); this.triggers[0].hide();" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="txtMaDieuKienHuong" FieldLabel="Mã ĐK hưởng<span style='color:red;'>*</span>"
                            CtCls="requiredData" Width="300" AnchorHorizontal="99%" EmptyText="Mã điều kiện hưởng">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txtDieuKienHuong" FieldLabel="Điều kiện hưởng"
                            Width="300" AnchorHorizontal="99%">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="nfThoiGianDongBaoHiem" EmptyText="Số tháng đóng bảo hiểm"
                            MaskRe="/[0-9\.]/" FieldLabel="Số tháng đóng BH ><span style='color:red;'>*</span>"
                            CtCls="requiredData" AnchorHorizontal="99%" LabelWidth="170">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="nfThoiGianHuongCheDo" FieldLabel="Số ngày HCĐ <<span style='color:red;'>*</span>"
                            CtCls="requiredData" MaskRe="/[0-9\.]/" AnchorHorizontal="99%" LabelWidth="150"
                            EmptyText="Số ngày hưởng chế độ tối đa">
                        </ext:TextField>
                        <%-- <ext:TextArea runat="server" ID="txaCongThuc" FieldLabel="Công thức<span style='color:red;'>*</span>"
                            AnchorHorizontal="99%" GrowMin="30" Grow="true" GrowMax="60">
                        </ext:TextArea>--%>
                        <ext:TextArea ID="txaCongThuc" FieldLabel="Công thức<span style='color:red;'>*</span>"
                            CtCls="requiredData" runat="server" AnchorHorizontal="100%" Editable="false"
                            MaskRe="/[0-9\.\+\-\*\/]/">
                        </ext:TextArea>
                        <ext:Panel ID="Panel1" runat="server" Title="Hỗ trợ nhập công thức" Height="150"
                            AnchorHorizontal="100%">
                            <TopBar>
                                <ext:Toolbar ID="Toolbar1" runat="server">
                                    <Items>
                                        <ext:Toolbar ID="Toolbar2" runat="server" Width="105" Flat="false">
                                            <Defaults>
                                                <ext:Parameter Name="width" Value="33" Mode="Raw" />
                                            </Defaults>
                                            <Items>
                                                <ext:TableLayout ID="TableLayout1" runat="server" Columns="3">
                                                    <Cells>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button15" runat="server" Text="<span class='txtto'>0</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+0);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button19" runat="server" Text="<span class='txtto' >1</span> " StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+1);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button21" runat="server" Text="<span class='txtto'>2</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+2);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button22" runat="server" Text="<span class='txtto'>3</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+3);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button23" runat="server" Text="<span class='txtto'>4</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+4);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button24" runat="server" Text="<span class='txtto'>5</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+5);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button25" runat="server" Text="<span class='txtto'>6</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+6);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button26" runat="server" Text="<span class='txtto'>7</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+7);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button27" runat="server" Text="<span class='txtto'>8</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+8);" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button39" runat="server" Text="<span class='txtto'>9</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'9');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button40" runat="server" Text="<span class='txtto'>(</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'(');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button41" runat="server" Text="<span class='txtto'>)</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+')');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button34" runat="server" Text="<span class='txtto'>.</span>" StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'.');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button35" runat="server" Text="<span class='txtto'>%</span>" StandOut="true"
                                                                Disabled="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'%');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button36" runat="server" Text="<span class='txtto'>^</span>" StandOut="true"
                                                                Disabled="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'^');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                    </Cells>
                                                </ext:TableLayout>
                                            </Items>
                                        </ext:Toolbar>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator3" runat="server" />
                                        <ext:Toolbar ID="Toolbar4" runat="server" Width="190" Flat="false">
                                            <Defaults>
                                                <ext:Parameter Name="width" Value="33" Mode="Raw" />
                                            </Defaults>
                                            <Items>
                                                <ext:TableLayout ID="TableLayout2" runat="server" Columns="3">
                                                    <Cells>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button28" runat="server" Width="60" Height="50" Text="<span class='chuto'>+</span>"
                                                                StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+' +');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button29" Width="60" Height="50" runat="server" Text="<span class='chuto'>-</span>"
                                                                StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+' -');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button runat="server" ID="btxoa" Icon="Delete" Text="<%$ Resources:Language, delete%>" StandOut="true" Width="64"
                                                                Height="50">
                                                                <Listeners>
                                                                    <Click Handler="XoaCongThuc()" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button30" Width="60" Height="50" runat="server" Text="<span class='chuto'>*</span>"
                                                                StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+' *');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button31" Width="60" Height="50" runat="server" Text="<span class='chuto'>/</span>"
                                                                StandOut="true">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'/');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button runat="server" ID="Button1" Icon="Reload" Text="Nhập lại" StandOut="true"
                                                                Width="60" Height="50">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.reset()" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                    </Cells>
                                                </ext:TableLayout>
                                            </Items>
                                        </ext:Toolbar>
                                        <ext:ToolbarSeparator ID="ToolbarSeparator4" runat="server" />
                                        <ext:Toolbar ID="Toolbar5" runat="server" Width="250" Flat="false">
                                            <Defaults>
                                                <ext:Parameter Name="width" Value="99" Mode="Raw" />
                                            </Defaults>
                                            <Items>
                                                <ext:TableLayout ID="TableLayout3" runat="server" Columns="1">
                                                    <Cells>
                                                        <ext:Cell>
                                                            <ext:Button ID="MenuItem1" runat="server" Text="Lương đóng bảo hiểm tháng liền kề">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'LuongDongBHThangLienKe');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="MenuItem2" runat="server" Text="Công chuẩn" Width="20">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'CongChuan');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="SoNgayNghi" runat="server" Text="Số ngày nghỉ" Width="20">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'SoNgayNghi');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="Button32" runat="server" Text="Lương bình quân 6 tháng">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'LuongBHBQ6Thang');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                        <ext:Cell>
                                                            <ext:Button ID="LuongToiThieuChung" runat="server" Text="Lương tối thiểu chung">
                                                                <Listeners>
                                                                    <Click Handler="#{txaCongThuc}.setValue(#{txaCongThuc}.getValue()+'LuongToiThieuChung');" />
                                                                </Listeners>
                                                            </ext:Button>
                                                        </ext:Cell>
                                                    </Cells>
                                                </ext:TableLayout>
                                            </Items>
                                        </ext:Toolbar>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                        </ext:Panel>
                        <ext:TextArea runat="server" ID="txaYeuCauThuTuc" FieldLabel="Yêu cầu thủ tục" AnchorHorizontal="99%"
                            GrowMin="30" Grow="true" GrowMax="60">
                        </ext:TextArea>
                        <ext:TextArea runat="server" ID="txaDienGiai" FieldLabel="Diễn giải" AnchorHorizontal="99%"
                            GrowMin="30" Grow="true" GrowMax="60">
                        </ext:TextArea>
                    </Content>
                </ext:Container>
            </Items>
        </ext:Panel>
    </Items>
    <Buttons>
        <ext:Button runat="server" ID="btnsave" Text="<%$ Resources:Language, update%>" Icon="Disk">
            <Listeners>
                <Click Handler="return check();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="Add_Click" After="resetWdBangTinhCheDo();">
                    <EventMask ShowMask="true" Msg="<%$ Resources:Language, saving%>" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="False">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnupdate" Text="<%$ Resources:Language, update%>" Icon="Disk">
            <Listeners>
                <Click Handler="return check();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="Add_Click" After="#{wdBangTinhCheDoBaoHiem}.hide();">
                    <EventMask ShowMask="true" Msg="<%$ Resources:Language, saving%>" />
                    <ExtraParams>
                        <ext:Parameter Name="update" Value="True">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="btnexit" Text="<%$ Resources:Language, update_close%>" Icon="Disk">
            <Listeners>
                <Click Handler="return check();" />
            </Listeners>
            <DirectEvents>
                <Click OnEvent="Add_Click">
                    <EventMask ShowMask="true" Msg="<%$ Resources:Language, saving%>" />
                    <ExtraParams>
                        <ext:Parameter Name="Close" Value="True">
                        </ext:Parameter>
                    </ExtraParams>
                </Click>
            </DirectEvents>
        </ext:Button>
        <ext:Button runat="server" ID="Button33" Text="<%$ Resources:CommonMessage, Close%>" Icon="Decline">
            <Listeners>
                <Click Handler="#{wdBangTinhCheDoBaoHiem}.hide();#{DirectMethods}.Resetwindown();" />
            </Listeners>
        </ext:Button>
    </Buttons>
    <Listeners>
        <BeforeShow Handler="#{Store_ddfCheDoNghi}.reload();" />
        <Hide Handler="resetWdBangTinhCheDo();" />
    </Listeners>
</ext:Window>
<ext:BorderLayout runat="server" ID="br">
    <Center>
        <ext:GridPanel Border="false" ID="grpbangtinhchedobaohiem" runat="server" StripeRows="true"
            Header="false" Padding="0" Region="Center">
            <TopBar>
                <ext:Toolbar runat="server" ID="toolbar3">
                    <Items>
                        <ext:Button ID="btnaddnew" runat="server" Text="Thêm mới" Icon="add">
                            <Listeners>
                                <Click Handler="BangTinhCheDoBaoHiem1_wdBangTinhCheDoBaoHiem.show();#{btnupdate}.hide();#{btnsave}.show();#{btnexit}.show();#{txtMaDieuKienHuong}.enable();" />
                            </Listeners>
                            <%-- <DirectEvents>
                                <Click OnEvent="btnEdit_Click">
                                    <ExtraParams>
                                        <ext:Parameter Name="add" Value="true">
                                        </ext:Parameter>
                                    </ExtraParams>
                                   
                                </Click>
                            </DirectEvents>--%>
                        </ext:Button>
                        <ext:Button ID="btnedit" runat="server" Disabled="true" Text="<%$ Resources:CommonMessage, Edit%>" Icon="pencil">
                            <Listeners>
                                <Click Handler="if (CheckSelectedRows(grpbangtinhchedobaohiem)){ #{btnupdate}.show();#{btnsave}.hide();#{btnexit}.hide();#{txtMaDieuKienHuong}.disable();} else {return false;}" />
                            </Listeners>
                            <DirectEvents>
                                <Click OnEvent="btnEdit_Click">
                                </Click>
                            </DirectEvents>
                        </ext:Button>
                        <ext:Button ID="btndelete" runat="server" Text="<%$ Resources:Language, delete%>" Disabled="true" Icon="delete">
                            <Listeners>
                                <Click Handler="RemoveItemOnGrid4(#{grpbangtinhchedobaohiem},#{Store3},-1, #{DirectMethods})" />
                            </Listeners>
                        </ext:Button>
                        <ext:ToolbarSeparator ID="toolbarseparator1" runat="server" />
                        <ext:ToolbarFill runat="server" ID="tbfill" />
                        <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập từ khóa tìm kiếm"
                            emptytex="Nhập từ khóa tìm kiếm" ID="txtsearch">
                            <Triggers>
                                <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                            </Triggers>
                            <Listeners>
                                <KeyPress Fn="enterKeyPressHandler2" />
                            </Listeners>
                            <Listeners>
                                <TriggerClick Handler="this.triggers[0].hide(); this.clear(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:TriggerField>
                        <ext:Button Text="<%$ Resources:Language, search%>" Icon="zoom" runat="server" ID="btnsearch">
                            <Listeners>
                                <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:Button>
                    </Items>
                </ext:Toolbar>
            </TopBar>
            <ColumnModel ID="columnmodel1" runat="server">
                <Columns>
                    <ext:RowNumbererColumn Header="STT" Width="30" Align="Left">
                    </ext:RowNumbererColumn>
                    <ext:Column Header="Mã đk hưởng" Width="100" DataIndex="MaDieuKienHuong">
                    </ext:Column>
                    <ext:Column Header="Điều kiện hưởng" Width="200" DataIndex="TenDieuKienHuong">
                    </ext:Column>
                    <ext:Column Header="Chế độ nghỉ" Width="150" DataIndex="TenCheDoBaoHiem">
                    </ext:Column>
                    <ext:Column Header="Số tháng đóng bảo hiểm" Width="140" DataIndex="DKThoiGianDongBH"
                        Align="Right">
                        <Renderer Fn="RenderNamCheDoBH" />
                    </ext:Column>
                    <ext:Column Header="Số ngày hưởng chế độ" Width="140" DataIndex="DKThoiGianToiDaHuongCheDo"
                        Align="Right">
                        <Renderer Fn="RenderNgayCheDoBH" />
                    </ext:Column>
                    <ext:Column Header="Công thức" Width="283" DataIndex="CongThuc">
                    </ext:Column>
                    <ext:Column Header="Yêu cầu thủ tục" Width="200" DataIndex="YeuCauThuTuc">
                    </ext:Column>
                    <ext:Column Header="Diễn giải" Width="200" DataIndex="DienGiai">
                    </ext:Column>
                </Columns>
            </ColumnModel>
            <View>
                <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                    ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
            </View>
            <SelectionModel>
                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                    <Listeners>
                        <RowSelect Handler="BangTinhCheDoBaoHiem1_hdfIdTinhCheDoBH.setValue(BangTinhCheDoBaoHiem1_RowSelectionModel1.getSelected().id); BangTinhCheDoBaoHiem1_hdfIdTinhCheDoBH.setValue(BangTinhCheDoBaoHiem1_RowSelectionModel1.getSelected().id); return Grid_CheckSelectRow(); " />
                        <RowDeselect Handler="BangTinhCheDoBaoHiem1_hdfIdTinhCheDoBH.reset(); BangTinhCheDoBaoHiem1_hdfIdTinhCheDoBH.reset(); BangTinhCheDoBaoHiem1_btnedit.disable(); BangTinhCheDoBaoHiem1_btndelete.disable(); " />
                    </Listeners>
                </ext:RowSelectionModel>
            </SelectionModel>
            <Listeners>
                <DblClick Handler="#{btnsave}.hide();#{btnupdate}.show();#{btnexit}.hide();#{txtMaDieuKienHuong}.disable();" />
                <BeforeShow Handler="#{Store3}.reload();" />
            </Listeners>
            <DirectEvents>
                <DblClick OnEvent="btnEdit_Click">
                </DblClick>
            </DirectEvents>
            <Store>
                <ext:Store ID="Store3" ShowWarningOnFailure="false" SkipIdForNewRecords="false" runat="server"
                    GroupField="TenCheDoBaoHiem">
                    <Proxy>
                        <ext:HttpProxy Json="true" Method="GET" Url="BangTinhCheDoBaoHiem.ashx" />
                    </Proxy>
                    <AutoLoadParams>
                        <ext:Parameter Name="start" Value="={0}" />
                        <ext:Parameter Name="limit" Value="={30}" />
                    </AutoLoadParams>
                    <BaseParams>
                        <ext:Parameter Name="madonvi" Value="#{hdfmadonvi}.getValue()" Mode="raw" />
                        <ext:Parameter Name="searchkey" Value="#{txtsearch}.getValue()" Mode="raw" />
                    </BaseParams>
                    <Reader>
                        <ext:JsonReader Root="Data" IDProperty="IDBangTinhCheDoBaoHiem" TotalProperty="TotalRecords">
                            <Fields>
                                <ext:RecordField Name="IDBangTinhCheDoBaoHiem" />
                                <ext:RecordField Name="MaDieuKienHuong" />
                                <ext:RecordField Name="TenCheDoBaoHiem" />
                                <ext:RecordField Name="TenDieuKienHuong" />
                                <ext:RecordField Name="DKThoiGianDongBH" />
                                <ext:RecordField Name="DKThoiGianToiDaHuongCheDo" />
                                <ext:RecordField Name="CongThuc" />
                                <ext:RecordField Name="YeuCauThuTuc" />
                                <ext:RecordField Name="DienGiai" />
                            </Fields>
                        </ext:JsonReader>
                    </Reader>
                </ext:Store>
            </Store>
            <SaveMask ShowMask="true" Msg="<%$ Resources:Language, LoadingMask%>" />
            <%--            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar2" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                    PageSize="50" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                    DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                </ext:PagingToolbar>
            </BottomBar>--%>
            <BottomBar>
                <ext:PagingToolbar ID="PagingToolbar1" EmptyMsg="<%$ Resources:HOSO, no_data%>" NextText="<%$ Resources:HOSO, next_page%>"
                    PageSize="30" PrevText="<%$ Resources:HOSO, prev_page%>" LastText="<%$ Resources:HOSO, last_page%>" FirstText="<%$ Resources:HOSO, first_page%>"
                    DisplayMsg="<%$ Resources:HOSO, description_record%>" runat="server">
                    <Items>
                        <ext:Label ID="Label1" runat="server" Text="<%$ Resources:HOSO, number_line_per_page%>" />
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
                                <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                            </Listeners>
                        </ext:ComboBox>
                    </Items>
                    <Listeners>
                        <Change Handler="#{RowSelectionModel1}.clearSelections();" />
                    </Listeners>
                </ext:PagingToolbar>
            </BottomBar>
        </ext:GridPanel>
    </Center>
</ext:BorderLayout>
