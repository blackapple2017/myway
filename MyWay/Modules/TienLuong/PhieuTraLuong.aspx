<%@ Page Language="C#" AutoEventWireup="true" CodeFile="PhieuTraLuong.aspx.cs" Inherits="Modules_TienLuong_PhieuTraLuong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/jquery-1.4.2.min.js" type="text/javascript"></script>
    <style type="text/css">
        div#pnlDanhSachPhieuLuong-xsplit
        {
            border-right: 1px solid #98C0F4;
            border-left: 1px solid #98C0F4;
        }
    </style> 
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM" />
        <ext:Hidden runat="server" ID="hdfMaCB" />
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="br">
                    <Center>
                        <ext:Panel runat="server" Title="Phiếu trả lương cho nhân viên" Border="false" ID="pnlPhieuLuong">
                            <Content>
                                <div style="padding: 10px; width:600px; margin:10px auto;line-height:20px;">
                                    <center> 
                                            <h1>PHIẾU TRẢ LƯƠNG</h1> 
                                        <ext:DisplayField runat="server" ID="dpfPhieuLuong"/>
                                    </center>
                                    <table border="0" cellpadding="0" cellspacing="0">
                                        <tr>
                                            <td><b>Họ tên : </b></td>
                                            <td><ext:DisplayField runat="server" ID="dpfHoTen" /></td>
                                        </tr>
                                        <tr>
                                            <td><b>Bộ phận :</b> </td>
                                            <td><ext:DisplayField runat="server" ID="dpfBoPhan" /></td>
                                        </tr>
                                    </table> 
                                    <h2>Các khoản thu nhập</h2>
                                    <ul>
                                        <li><ext:DisplayField runat="server" ID="dpfLuongCB" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfLuongTrachNhiem" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfPhuCapAnCa" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfPhuCapChucVu" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfPhuCapKiemNhiem" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfPhuCapKhac" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfLuong100" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfLuong150" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfLuong200" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfLuong300" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfLuongThang13" /></li>
                                    </ul>
                                    <h2>Các khoản giảm trừ</h2>
                                    <ul>
                                        <li><ext:DisplayField runat="server" ID="dpfBHXH" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfBHYT" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfBHTN" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfKPCD" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfGiamTruTienAn" /></li>
                                        <li><ext:DisplayField runat="server" ID="dpfGiamTruTienPhat" /></li>
                                    </ul>
                                    <h2><ext:DisplayField runat="server" ID="dpfTongSoTien" /></h2>
                                </div>
                            </Content>
                        </ext:Panel>
                    </Center>
                    <East Split="true">
                        <ext:Panel runat="server" Width="400" Layout="BorderLayout" Border="false" ID="pnlDanhSachPhieuLuong"
                            Title="Danh sách phiếu lương">
                            <Items>
                                <ext:GridPanel ID="grpDanhSachPhieuLuong" runat="server" Border="false" StripeRows="true"
                                    TrackMouseOver="true" Region="Center" AutoExpandColumn="Title" >
                                    <Store>
                                        <ext:Store ID="grpDanhSachPhieuLuongStore" AutoLoad="true" runat="server">
                                            <Proxy>
                                                <ext:HttpProxy Method="GET" Url="Handler/PhieuTraLuongHandler.ashx">
                                                </ext:HttpProxy>
                                            </Proxy>
                                            <AutoLoadParams>
                                                <ext:Parameter Name="start" Value="={0}" />
                                                <ext:Parameter Name="limit" Value="={30}" />
                                            </AutoLoadParams>
                                            <BaseParams>
                                                <ext:Parameter Name="MaCB" Mode="Raw" Value="hdfMaCB.getValue()"></ext:Parameter>
                                            </BaseParams> 
                                            <Reader>
                                                <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                    <Fields>
                                                        <ext:RecordField Name="Title" />
                                                        <ext:RecordField Name="ID"/>
                                                        <ext:RecordField Name="Month"/>
                                                        <ext:RecordField Name="Year" /> 
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <ColumnModel ID="ColumnModel1" runat="server">
                                        <Columns>
                                            <ext:RowNumbererColumn Header="STT" Width="35" />
                                            <ext:TemplateColumn ColumnID="Title" Header="Danh sách bảng lương" Width="160" DataIndex="Title">
                                                <Template runat="server">
                                                    <Html>
                                                        <%--{Title}<br />--%>
                                                        Tháng {Month} - năm {Year}
                                                    </Html>
                                                </Template>
                                            </ext:TemplateColumn> 
                                        </Columns>
                                    </ColumnModel>
                                     <SelectionModel>
                                        <ext:RowSelectionModel ID="RowSelectionModel1" runat="server" />
                                    </SelectionModel>
                                    <DirectEvents>
                                        <RowClick OnEvent="grpDanhSachPhieuLuong_RowClick">
                                            <ExtraParams>
                                                <ext:Parameter Name="idBangLuong" Value="RowSelectionModel1.getSelected().id" Mode="Raw" />
                                                <ext:Parameter Name="month" Value="RowSelectionModel1.getSelected().data.Month" Mode="Raw" />
                                                <ext:Parameter Name="year" Value="RowSelectionModel1.getSelected().data.Year" Mode="Raw" />
                                            </ExtraParams>
                                        </RowClick>
                                    </DirectEvents> 
                                    <LoadMask ShowMask="true" />
                                    <BottomBar>
                                        <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
                                        </ext:PagingToolbar>
                                    </BottomBar>
                                </ext:GridPanel>
                            </Items>
                        </ext:Panel>
                    </East>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
