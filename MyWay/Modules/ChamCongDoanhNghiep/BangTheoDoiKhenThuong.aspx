<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangTheoDoiKhenThuong.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_BangTheoDoiKhenThuong" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var validateForm = function () {
            if (hdfChonCanBo.getValue() == '') {
                alert("Bạn chưa nhập họ tên cán bộ nhân viên");
                return false;
            }
            if (dfNgayQD.getValue() == '') {
                alert("Bạn chưa nhập ngày quyết định");
                return false;
            }
            if (txtLyDoKhenThuong.getValue() == '') {
                alert("Bạn chưa nhập lý do khen thưởng");
                return false;
            }
            return true;
        }

        var resetForm = function () {
            hdfChonCanBo.reset();
            cbxChonCanBo.reset();
            txtSoQD.reset();
            dfNgayQD.reset();
            txtLyDoKhenThuong.reset();
            nbfSoTien.reset();
            nbfSoDiem.reset();
            txtDescription.reset();
            btnUpdate.hide(); btnInsert.show(); btnInsertAndClose.show();
        }

        var setValueForEdit = function () {
            hdfChonCanBo.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.FR_KEY);
            hdfEmployeeName.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.HO_TEN);
            txtSoQD.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.SO_QD);
            txtLyDoKhenThuong.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.LYDO_KTHUONG);
            nbfSoTien.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.SO_TIEN);
            nbfSoDiem.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.SoDiem);
            txtDescription.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.GHI_CHU);
            hdfDate.setValue(grpDanhSachKhenThuong_RowSelectionModel1.getSelected().data.NGAY_QD);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:Hidden runat="server" ID="hdfEmployeeName" />
        <ext:Hidden runat="server" ID="hdfDate" />
        <ext:Window runat="server" ID="wdKhenThuong" Modal="true" Hidden="true" Layout="FormLayout"
            Title="Cập nhật thông tin khen thưởng" Padding="6" Constrain="true" Width="500"
            AutoHeight="true">
            <Items>
                <ext:Hidden runat="server" ID="hdfChonCanBo" />
                <ext:ComboBox ID="cbxChonCanBo" CtCls="requiredData" ValueField="PRKEY" DisplayField="HOTEN"
                    FieldLabel="Tên cán bộ<span style='color:red'>*</span>" PageSize="10" HideTrigger="true"
                    ItemSelector="div.search-item" MinChars="1" EmptyText="nhập tên để tìm kiếm"
                    LoadingText="Đang tải dữ liệu..." AnchorHorizontal="100%" runat="server">
                    <Store>
                        <ext:Store ID="cbxChonCanBo_Store" runat="server" AutoLoad="false">
                            <Proxy>
                                <ext:HttpProxy Method="POST" Url="../HoSoNhanSu/QuyetDinhLuong/SearchUserHandler.ashx" />
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
                        <Select Handler="hdfChonCanBo.setValue(cbxChonCanBo.getValue());" />
                    </Listeners>
                </ext:ComboBox>
                <ext:Container ID="Container1" runat="server" Height="27" AnchorHorizontal="100%"
                    Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container2" Layout="FormLayout" runat="server" Height="27" ColumnWidth="0.5">
                            <Items>
                                <ext:DateField runat="server" CtCls="requiredData" AnchorHorizontal="98%" ID="dfNgayQD"
                                    FieldLabel="Ngày QĐ<span style='color:red;'>*</span>" />
                            </Items>
                        </ext:Container>
                        <ext:TextField ID="txtSoQD" runat="server" ColumnWidth="0.5" FieldLabel="Số QĐ" />
                    </Items>
                </ext:Container>
                <ext:TextField runat="server" FieldLabel="Lý do thưởng<span style='color:red;'>*</span>"
                    CtCls="requiredData" ID="txtLyDoKhenThuong" AnchorHorizontal="100%" />
                <ext:Container runat="server" Height="27" AnchorHorizontal="100%" Layout="ColumnLayout">
                    <Items>
                        <ext:Container Layout="FormLayout" runat="server" Height="27" ColumnWidth="0.5">
                            <Items>
                                <ext:NumberField ID="nbfSoTien" runat="server" AnchorHorizontal="98%" FieldLabel="Số tiền" />
                            </Items>
                        </ext:Container>
                        <ext:NumberField runat="server" ColumnWidth="0.5" ID="nbfSoDiem" FieldLabel="Số điểm" />
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" FieldLabel="Ghi chú" AnchorHorizontal="100%" ID="txtDescription" />
            </Items>
            <Listeners>
                <Hide Handler="resetForm();" />
            </Listeners>
            <Buttons>
                <ext:Button runat="server" Text="Cập nhật" Hidden="true" Icon="Disk" ID="btnUpdate">
                    <Listeners>
                        <Click Handler="return validateForm();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnInsert_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Update" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật" Icon="Disk" ID="btnInsert">
                    <Listeners>
                        <Click Handler="return validateForm();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnInsert_Click">
                            <EventMask ShowMask="true" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Reset" />
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Cập nhật & Đóng lại" Icon="Disk" ID="btnInsertAndClose">
                    <Listeners>
                        <Click Handler="return validateForm();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnInsert_Click">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdKhenThuong.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
        </ext:Window>
        <ext:Button runat="server" Text="Báo cáo" Icon="Printer" ID="btnReport">
        </ext:Button> 
        <ext:DisplayField runat="server" Text="Chọn tháng" />
        <ext:ComboBox runat="server" Editable="false" ID="cbMonth" EmptyText="Chọn tháng"></ext:ComboBox>
        <uc1:SingleGridPanel ID="grpDanhSachKhenThuong" EnableWhiteSpace="true" ColumnName="PR_KEY,SO_QD,MA_CB,HO_TEN,TEN_DONVI,LYDO_KTHUONG,SO_TIEN,SoDiem,NGAY_QD,GHI_CHU"
            TableForDeleting="HOSO_KHENTHUONG" ColumnHeader="PR_KEY,Số QĐ,Mã cán bộ, Họ tên,Phòng ban, Lý do khen thưởng, Số tiền, số điểm, ngày quyết định,Ghi chú"
            AutoExpandColumn="GHI_CHU" ColumnWidth="HO_TEN=130,LYDO_KTHUONG=200,TEN_DONVI=150,SO_TIEN=90,FR_KEY=0" MoreStoreField="FR_KEY"
            Render="SO_TIEN=RenderVND" SearchField="MA_CB,HO_TEN,LYDO_KTHUONG,GHI_CHU" TableOrViewName="view_DanhSachKhenThuong"
            IDProperty="PR_KEY" runat="server" />
        <%--EnableWestPanelFilter="true" MaDonViColumn="MA_DONVI"--%>
    </div>
    </form>
</body>
</html>
