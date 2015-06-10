<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangCongThucLuongKhoan.aspx.cs"
    Inherits="Modules_TienLuong_KhoanSanXuat_BangCongThucLuongKhoan" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="~/Modules/Base/SingleGridPanel/SingleGridPanel.ascx" TagPrefix="uc1"
    TagName="SingleGridPanel" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ShowCongThucEdit = function () {
        }
        var CheckInput = function () {

        }
        var HideCongThucEdit = function () {
            //hdfBoPhan.reset(); cbx_bophan.reset();
            //txt_TenCongThuc.reset();
            txt_DKSanLuongTu.reset();
            txt_DKSanLuongDen.reset();
            txt_TrongSo.reset();
            txt_CongThuc.reset();
            txt_GhiChu.reset();
            hdf_PRKEY.setValue(0);
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:Window runat="server" ID="wdCongThucKhoanSanXuatEdit" Icon="UserSuitBlack" Padding="6"
            Resizable="false" Hidden="True" Title="Công thức tính lương khoán sản xuất" Modal="true"
            Constrain="true" Width="600" AutoHeight="true">
            <Items>
                <ext:Hidden runat="server" ID="hdf_PRKEY" />
                <ext:Container runat="server" ID="c1" Layout="FormLayout" LabelWidth="200" AutoHeight="True"
                    AnchorHorizontal="100%">
                    <Items>
                        <%--<ext:ComboBox runat="server" ID="cbb_MaCa" FieldLabel="Chọn phòng ban" DisplayField="Ten"
                                ValueField="Ma" AnchorHorizontal="98%" Editable="false">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Store>
                                    <ext:Store runat="server" ID="cbb_MaCa_Store" AutoLoad="False" OnRefreshData="cbb_MaCa_Store_OnRefreshData">
                                        <Reader>
                                            <ext:JsonReader IDProperty="Ma">
                                                <Fields>
                                                    <ext:RecordField Name="Ma" />
                                                    <ext:RecordField Name="Ten" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Listeners>
                                    <Expand Handler="if(cbb_MaCa.store.getCount()==0) cbb_MaCa_Store.reload();" />
                                    <Select Handler="this.triggers[0].show();" />
                                    <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                </Listeners>
                            </ext:ComboBox>--%>
                        <ext:Hidden runat="server" ID="hdfBoPhan" />
                        <ext:ComboBox runat="server" ID="cbx_bophan" FieldLabel="Bộ phận<span style='color:red;'>*</span>"
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
                                        {TEN}
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
                                <Expand Handler="if(cbx_bophan.store.getCount()==0) cbx_bophan_Store.reload();" />
                                <Select Handler="this.triggers[0].show(); hdfBoPhan.setValue(cbx_bophan.getValue());" />
                                <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfBoPhan.reset(); }" />
                            </Listeners>
                        </ext:ComboBox>
                        <ext:TextField runat="server" ID="txt_TenCongThuc" FieldLabel="Tên công thức" AnchorHorizontal="98%"
                            MaxLength="100">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txt_DKSanLuongTu" MaskRe="/[0-9\.]/" FieldLabel="Điều kiện sản lượng từ(kg/giờ)"
                            AnchorHorizontal="98%" MaxLength="50">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txt_DKSanLuongDen" MaskRe="/[0-9\.]/" FieldLabel="Điều kiện sản lượng đến(kg/giờ)"
                            AnchorHorizontal="98%" MaxLength="50">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txt_CongThuc" FieldLabel="Công thức" AnchorHorizontal="98%"
                            MaxLength="1000">
                        </ext:TextField>
                        <ext:TextField runat="server" ID="txt_TrongSo" MaskRe="/[0-9\.]/" FieldLabel="Trọng số"
                            AnchorHorizontal="98%" MaxLength="50">
                        </ext:TextField>
                        <ext:TextArea runat="server" ID="txt_GhiChu" FieldLabel="Ghi chú" AnchorHorizontal="98%" />
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="btn_EditGiaoVien" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click" After="HideCongThucEdit();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btn_UpdateClose" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click" After="wdCongThucKhoanSanXuatEdit.hide();">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button21" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdCongThucKhoanSanXuatEdit}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="HideCongThucEdit();" />
                <%--<Show Handler="ShowCongThucEdit();" />--%>
            </Listeners>
        </ext:Window>
        <uc1:SingleGridPanel ID="grpCongThucLuongKhoan" TableOrViewName="v_TienLuong_CongThucLuongKhoan"
            ColumnWidth="PRKEY=80,MaDonVi=140,TEN_DONVI=100,TenCongThuc=300,DKSanLuongTu=85,DKSanLuongDen=85,CongThuc=255,TrongSo=100,GhiChu=170"
            OrderBy="MaDonVi,DKSanLuongTu" IDProperty="PRKEY" SearchField="TenCongThuc,MaDonVi"
            ColumnHeader="PRKEY, Mã bộ phận, Tên bộ phận,Tên công thức, Sản lượng từ (kg/giờ),Sản lượng đến (kg/giờ), Công thức,Trọng số, Ghi chú"
            ColumnName="PRKEY,MaDonVi,TEN_DONVI,TenCongThuc,DKSanLuongTu,DKSanLuongDen,CongThuc,TrongSo,GhiChu"
            TableForDeleting="TienLuong.CongThucKhoanSanXuat" runat="server" GroupField="TEN_DONVI"
            HideGrouped="true" />
    </div>
    </form>
</body>
</html>
