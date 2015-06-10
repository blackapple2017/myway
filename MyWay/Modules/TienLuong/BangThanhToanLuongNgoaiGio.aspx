<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangThanhToanLuongNgoaiGio.aspx.cs" Inherits="Modules_TienLuong_BangThanhToanLuongNgoaiGio" %>

<%--<%@ Register Src="~/Modules/Base/SingleGridPanel/SingleGridPanel.ascx" TagPrefix="uc1" TagName="SingleGridPanel" %>--%>
<script src="../../Resource/js/RenderJS.js"></script>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        .search-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }

        .westDonXinNghi .x-layout-collapsed-west {
            background: url(../../Resource/images/CacDonDaGui.png) no-repeat center;
        }

        .search-item h3 {
            display: block;
            font: inherit;
            font-weight: bold;
            color: #222;
        }

            .search-item h3 span {
                float: right;
                font-weight: normal;
                margin: 0 0 5px 5px;
                width: 100px;
                display: block;
                clear: none;
            }
    </style>
    <script type="text/javascript">
        var keyEnterPress = function (f, e) {
            if (e.getKey() == e.ENTER) {
                PagingToolbar.pageIndex = 0; PagingToolbar.doLoad();
            }
        }
    </script>
    <script src="../../Resource/js/RenderJS.js"></script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Store runat="server" ID="grpLuongThemGioStore" AutoLoad="false">
                <Proxy>
                    <ext:HttpProxy Json="true" Method="GET" Url="Handler/BangThanhToanLuongNgoaiGioHandler.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="Start" Value="={0}" />
                    <ext:Parameter Name="Limit" Value="={20}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="IDBangChamCong" Value="cbbChonBangChamCong.getValue()" Mode="Raw" />
                    <ext:Parameter Name="SearchKey" Value="#{txtSearchKey}.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="MaNhanVien">
                        <Fields>
                            <ext:RecordField Name="PRKEY" />
                            <ext:RecordField Name="MaNhanVien" />
                            <ext:RecordField Name="HoTen" />
                            <ext:RecordField Name="BoPhan" />
                            <ext:RecordField Name="LuongCung" />
                            <ext:RecordField Name="NgayDangKyLamThem" />
                            <ext:RecordField Name="GioCongLamThemNgayThuong" />
                            <ext:RecordField Name="SoTienLamThemNgayThuong" />
                            <ext:RecordField Name="GioCongLamThemNgayNghi" />
                            <ext:RecordField Name="SoTienLamThemNgayNghi" />
                            <ext:RecordField Name="GioCongLamThemNgayLe" />
                            <ext:RecordField Name="SoTienLamThemNgayLe" />
                            <ext:RecordField Name="TongCongTien" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>

            <%--<ext:Window runat="server" Resizable="false" Hidden="false" AutoHeight="true" Layout="FormLayout"
                Width="400" Modal="true" Padding="10" Constrain="true" ID="wdChonBangChamCong" Title="Chọn bảng chấm công"
                Icon="Add" LabelWidth="125">
                <Items>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnDongY" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="wdChonBangChamCong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="cbbChonBangChamCong.reset();" />
                </Listeners>
            </ext:Window>--%>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="grpLuongThemGio" Border="false" runat="server"
                                AutoScroll="false" Title="Bảng thanh toán lương làm thêm giờ"
                                StripeRows="true" Region="Center" StoreID="grpLuongThemGioStore">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb1">
                                        <Items>
                                            <ext:ComboBox runat="server" ID="cbbChonBangChamCong" AnchorHorizontal="99%" FieldLabel="Chọn bảng chấm công<span style='color:red'>*</span>"
                                                ItemSelector="div.search-item" TypeAhead="false" DisplayField="Title" ValueField="ID" Editable="false" Width="350" LabelWidth="130">
                                                <Store>
                                                    <ext:Store ID="cbbChonBangChamCongStore" AutoLoad="false" GroupField="Nam" runat="server"
                                                        GroupDir="DESC">
                                                        <Proxy>
                                                            <ext:HttpProxy Json="true" Method="GET" Url="Handler/ChonBangChamCongHandler.ashx" />
                                                        </Proxy>
                                                        <AutoLoadParams>
                                                            <ext:Parameter Name="Start" Value="={0}" />
                                                            <ext:Parameter Name="Limit" Value="={10}" />
                                                        </AutoLoadParams>
                                                        <BaseParams>
                                                            <ext:Parameter Name="Thang" Value="={0}" Mode="Raw" />
                                                            <ext:Parameter Name="Nam" Value="={0}" Mode="Raw" />
                                                            <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                                        </BaseParams>
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                                <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="Title" />
                                                                    <ext:RecordField Name="DaKhoa" />
                                                                    <ext:RecordField Name="Thang" />
                                                                    <ext:RecordField Name="Nam" />
                                                                    <ext:RecordField Name="MaDonVi" />
                                                                    <ext:RecordField Name="TenDonVi" />
                                                                    <ext:RecordField Name="CreatedDate" />
                                                                    <ext:RecordField Name="CreatedBy" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <Template ID="Template3" runat="server">
                                                    <Html>
                                                        <tpl for=".">
						                                  <div class="search-item">
							                                 <h3>{Title}</h3>
							                                 {TEN_PHONG}</BR>
                                                             Đơn vị sử dụng:<b> {TenDonVi}</b><br />
                                                              Tình trạng: <b>{DaKhoa}</b>
						                                  </div>
					                                   </tpl>
                                                    </Html>
                                                </Template>
                                                <Listeners>
                                                    <Select Handler="grpLuongThemGioStore.reload();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ToolbarFill runat="server" ID="tbf" />
                                            <ext:TextField ID="txtSearchKey" EnableKeyEvents="true" Width="220" runat="server"
                                                EmptyText="Nhập từ khóa tìm kiếm...">
                                                <Listeners>
                                                    <KeyPress Fn="keyEnterPress" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:Button ID="Button1" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                                <Listeners>
                                                    <Click Handler="PagingToolbar.pageIndex=0;PagingToolbar.doLoad();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel ID="ColumnModer" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="1" Width="30"></ext:RowNumbererColumn>
                                        <ext:Column DataIndex="MaNhanVien" Header="" Width="70" Resizable="false"/>
                                        <ext:Column DataIndex="HoTen" Header="" Width="150" />

                                        <ext:Column DataIndex="BoPhan" Header="" Width="190" />
                                        <ext:TemplateColumn ColumnID="col1" Width="137">
                                                <Template runat="server">
                                                    <Html> {NgayDangKyLamThem}
                                                     </Html>
                                                </Template>
                                            </ext:TemplateColumn>
                                        <ext:Column DataIndex="LuongCung" Header="" Width="70" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <%--<ext:Column DataIndex="NgayDangKyLamThem" Width="100" />--%>
                                         
                                        <ext:Column DataIndex="GioCongLamThemNgayThuong" Header="Số giờ" Width="100" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <ext:Column DataIndex="SoTienLamThemNgayThuong" Header="Thành tiền" Width="70" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <ext:Column DataIndex="GioCongLamThemNgayNghi" Header="Số giờ" Width="70" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <ext:Column DataIndex="SoTienLamThemNgayNghi" Header="Thành tiền" Width="70">
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <ext:Column DataIndex="GioCongLamThemNgayLe" Header="Số giờ" Width="70" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <ext:Column DataIndex="SoTienLamThemNgayLe" Header="Thành tiền" Width="70" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                        <ext:Column DataIndex="TongCongTien" Header="Tổng cộng tiền" Width="100" >
                                            <Renderer Fn="RenderVND0" />
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <View>
                                    <ext:GridView>
                                        <HeaderGroupRows>
                                            <ext:HeaderGroupRow>
                                                <Columns>
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="STT" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Mã nhân viên" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tên nhân viên" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Bộ phận" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Ngày đăng ký làm thêm" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Lương cứng" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="2" Header="Làm thêm ngày thường" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="2" Header="Làm thêm ngày nghỉ" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="2" Header="Làm thêm ngày lễ" />
                                                    <ext:HeaderGroupColumn Align="Center" ColSpan="1" Header="Tổng cộng tiền" />
                                                </Columns>
                                            </ext:HeaderGroupRow>
                                        </HeaderGroupRows>
                                    </ext:GridView>
                                </View>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="rs1" SingleSelect="false">
                                        <Listeners>
                                            <%--<RowSelect Handler="if(getSelectedIndexRow(grpBangThanhToanTienLuong)!=getSelectedIndexRow(grpThongTinCanBo)) grpBangThanhToanTienLuong.getSelectionModel().selectRow(getSelectedIndexRow(grpThongTinCanBo));" />--%>
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar" EmptyMsg="Hiện không có dữ liệu" NextText="Trang sau"
                                        PageSize="20" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                        DisplayMsg="{1} / {2} " runat="server">
                                    </ext:PagingToolbar>
                                </BottomBar>
                            </ext:GridPanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>



            <%--<uc1:SingleGridPanel runat="server" ID="SingleGridPanel" EnableWestPanelFilter="true"
            OrderBy="TEN_CB,HO_TEN" ColumnName="MA_CB,HO_TEN,TEN_DONVI,LuongCung,GioCongLamThemNgayThuong,
            SoTienLamThemNgayThuong,GioCongLamThemNgayNghi,SoTienLamthemNgayNghi,GioCongLamThemNgayLe,
            SoTienLamThemNgayLe,TongCongTien " DisplayPrimaryColumn="true" ColumnHeader="Mã nhân viên, Họ tên, Bộ phận, Lương cơ bản, 
            Số giờ làm thêm ngày thường,Số tiền làm thêm ngày thường, số giờ làm thêm ngày nghỉ, Số tiền làm thêm ngày nghỉ, Số giờ làm thêm ngày lễ, Số tiền làm thêm ngày lễ
            ,Tổng cộng tiền" SearchField="MA_CB,HO_TEN" EmptyTextSearch="Nhập mã NV, họ tên hoặc mã chấm công..." 
            ColumnWidth="MA_CB=85,HO_TEN=160,TEN_DONVI=220,LuongCung=88,GioCongLamThemNgayThuong=88,SoTienLamThemNgayThuong=88,GioCongLamThemNgayNghi=88,SoTienLamthemNgayNghi=88,GioCongLamThemNgayLe=88,
            SoTienLamThemNgayLe=88,TongCongTien=88"
            Render="LuongCung=RenderVND,GioCongLamThemNgayThuong=RenderVND,SoTienLamThemNgayThuong=RenderVND,GioCongLamThemNgayNghi=RenderVND,SoTienLamthemNgayNghi=RenderVND,GioCongLamThemNgayLe=RenderVND,
            SoTienLamThemNgayLe=RenderVND,TongCongTien=RenderVND"
             MaDonViColumn="MA_DONVI"  TableOrViewName="v_BangThanhToanTienLamThemGio" IDProperty="MA_CB" />--%>
        </div>
    </form>
</body>
</html>
