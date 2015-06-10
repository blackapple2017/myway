<%@ Control Language="C#" AutoEventWireup="true" CodeFile="SingleGridPanel.ascx.cs"
    Inherits="Modules_Base_SingleGridPanel_SingleGridPanel" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script src="../../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
<script type="text/javascript">
    var enterKeyPressHandler = function (f, e) {
        if (e.getKey() == e.ENTER) {
            StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();
        }
        if (txtSearchKey.getValue() != '') {
            this.triggers[0].show();
        } else {
            this.triggers[0].hide();
        }
    }
    var RenderHightLight = function (value, p, record) {
        if (value == null || value == "") {
            return "";
        }
        var keyword = document.getElementById("txtSearchKey").value;
        //    if (keyword == "" || keyword == "Nh?p t? khóa tìm ki?m...")
        //         return value;

        var rs = "<p>" + value + "</p>";
        var keys = keyword.split(" ");
        for (i = 0; i < keys.length; i++) {
            if ($.trim(keys[i]) != "") {
                var o = { words: keys[i] };
                rs = highlight(o, rs);
            }
        }
        return rs;
    }
    function highlight(options, content) {
        var o = {
            words: '',
            caseSensitive: false,
            wordsOnly: true,
            template: '$1<span class="highlight">$2</span>$3'
        }, pattern;
        $.extend(true, o, options || {});

        if (o.words.length == 0) { return; }
        pattern = new RegExp('(>[^<.]*)(' + o.words + ')([^<.]*)', o.caseSensitive ? "" : "ig");

        return content.replace(pattern, o.template);
    }

    var CheckSelectedRecord = function (grid, Store) {

        var s = grid.getSelectionModel().getSelections();
        var count = 0;
        for (var i = 0, r; r = s[i]; i++) {
            count++;
        }
        if (count > 1) {
            alert('Bạn chỉ được chọn một bản ghi');
            return false;
        }
        return true;
    }
     
</script>
<asp:Literal runat="server" ID="ltrCss" />
<style type="text/css">
    .highlight
    {
        background: yellow;
    }
</style>
<ext:ResourceManager ID="RM" runat="server" />
<ext:Hidden runat="server" ID="hdfDataSource" />
<ext:Hidden runat="server" ID="hdfColumn" />
<ext:Hidden runat="server" ID="hdfIDProperty" />
<ext:Hidden runat="server" ID="hdfSearchField" />
<ext:Hidden runat="server" ID="hdfOrderBy" />
<ext:Hidden runat="server" ID="hdfWhereClause" />
<ext:Hidden runat="server" ID="hdfMaDonVi" />
<ext:Hidden runat="server" ID="hdfMaDonViColumn" />
<ext:Store ID="Store1" IDMode="Static" ShowWarningOnFailure="true" runat="server">
    <Proxy>
        <ext:HttpProxy Json="true" Method="GET" Url="Handler.ashx" />
    </Proxy>
    <AutoLoadParams>
        <ext:Parameter Name="start" Value="={0}" />
        <ext:Parameter Name="limit" Value="={30}" />
    </AutoLoadParams>
    <BaseParams>
        <ext:Parameter Name="DataSource" Value="#{hdfDataSource}.getValue()" Mode="Raw" />
        <ext:Parameter Name="IDProperty" Value="#{hdfIDProperty}.getValue()" Mode="Raw" />
        <ext:Parameter Name="column" Value="#{hdfColumn}.getValue()" Mode="Raw" />
        <ext:Parameter Name="SearchField" Value="#{hdfSearchField}.getValue()" Mode="Raw" />
        <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
        <ext:Parameter Name="OrderBy" Value="#{hdfOrderBy}.getValue()" Mode="Raw" />
        <ext:Parameter Name="WhereClause" Value="#{hdfWhereClause}.getValue()" Mode="Raw" />
        <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
        <ext:Parameter Name="MaDonViColumn" Value="#{hdfMaDonViColumn}.getValue()" Mode="Raw" />
    </BaseParams>
    <Listeners>
        <Load Handler="#{GridPanel1}.getSelectionModel().clearSelections();" />
    </Listeners>
</ext:Store>
<ext:Viewport ID="Viewport1" runat="server" Layout="Center">
    <Items>
        <ext:BorderLayout ID="borderLayout" runat="server">
            <Center>
                <ext:GridPanel ID="GridPanel1" Border="false" runat="server" TrackMouseOver="true"
                    StoreID="Store1" StripeRows="true">
                    <TopBar>
                        <ext:Toolbar ID="Toolbar1" runat="server">
                            <Items>
                                <ext:Button ID="btnAddRecord" runat="server" Text="Thêm mới" Icon="Add">
                                </ext:Button>
                                <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                    <Listeners>
                                        <Click Handler="return CheckSelectedRecord(#{GridPanel1},#{Store1});" />
                                    </Listeners>
                                </ext:Button>
                                <ext:Button ID="btnDelete" Disabled="true" runat="server" Text="Xóa" Icon="Delete">
                                    <Listeners>
                                        <Click Handler="if(#{GridPanel1}.getSelectionModel().getCount() == 0){alert('Chưa có bản ghi nào được chọn');return false;}" />
                                    </Listeners>
                                    <DirectEvents>
                                        <Click OnEvent="btnDelete_Click">
                                            <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                            <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không ?" ConfirmRequest="true" />
                                        </Click>
                                    </DirectEvents>
                                </ext:Button>
                                <ext:ToolbarFill ID="ToolbarFill1" runat="server" />
                                <ext:TriggerField runat="server" Width="200" AllowBlank="false" IDMode="Static" BlankText="Nhập từ khóa tìm kiếm..."
                                    EmptyText="Nhập từ khóa tìm kiếm..." EnableKeyEvents="true" ID="txtSearchKey">
                                    <Listeners>
                                        <KeyPress Fn="enterKeyPressHandler" />
                                    </Listeners>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Blur Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="#{txtSearchKey}.reset();
                                                               #{GridPanel1}.getSelectionModel().clearSelections();
                                                               #{StaticPagingToolbar}.pageIndex=0;
                                                               #{StaticPagingToolbar}.doLoad();
                                                               this.triggers[0].hide();" />
                                    </Listeners>
                                </ext:TriggerField>
                                <ext:Button ID="btnSearch" Visible="true" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                    <Listeners>
                                        <Click Handler="#{StaticPagingToolbar}.pageIndex=0;#{StaticPagingToolbar}.doLoad();" />
                                    </Listeners>
                                </ext:Button>
                            </Items>
                        </ext:Toolbar>
                    </TopBar>
                    <SelectionModel>
                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                            <Listeners>
                                <RowSelect Handler="try{#{btnDelete}.enable();#{btnEdit}.enable();}catch(e){}" />
                            </Listeners>
                        </ext:RowSelectionModel>
                    </SelectionModel>
                    <ColumnModel>
                        <Columns>
                            <ext:RowNumbererColumn Locked="true" Header="STT" Width="35" />
                        </Columns>
                    </ColumnModel>
                    <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
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
                                        <ext:ListItem Text="50" />
                                        <ext:ListItem Text="100" />
                                        <ext:ListItem Text="200" />
                                        <ext:ListItem Text="500" />
                                        <ext:ListItem Text="1000" />
                                    </Items>
                                    <SelectedItem Value="30" />
                                    <Listeners>
                                        <Select Handler="#{StaticPagingToolbar}.pageSize = parseInt(this.getValue()); #{StaticPagingToolbar}.doLoad();" />
                                    </Listeners>
                                </ext:ComboBox>
                            </Items>
                        </ext:PagingToolbar>
                    </BottomBar>
                </ext:GridPanel>
            </Center>
        </ext:BorderLayout>
    </Items>
</ext:Viewport>
