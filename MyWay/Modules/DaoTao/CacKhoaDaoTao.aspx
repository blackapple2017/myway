<%@ Page Language="C#" AutoEventWireup="true" CodeFile="CacKhoaDaoTao.aspx.cs" Inherits="Modules_DaoTao_CacKhoaDaoTao" %>

<%@ Register Src="../Base/GridPanel/GridPanel.ascx" TagName="GridPanel" TagPrefix="uc1" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc3" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc2" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript">
        var ResetValue = function () {
            frm_txtTenKhoaDaoTao.reset();
            frm_txtMaKhoaDaoTao.reset();
            frm_txtsoluonghocvien.reset();
            frm_txtdiadiemdaotao.reset();
            frm_txtKinhPhiDuKien.reset();
            frm_txtKinhPhiThucTe.reset();
            frm_txtCongTyHoTro.reset();
            frm_txtNhanVienDongGop.reset();
            cbx_chungchi.reset();
            cbxDonViPhuTrach.reset();
            frm_txtThoigiandukien.reset();
        }
        var RenderAlignRight = function (value, p, record) {
            if (value != 'null') {
                return "<span style='float:right'>" + value + "</span>";
            } if (value == 'null') {
                return "<span style='float:right'>0</span>";
            }
        }

        var CheckInput = function () {


            if (frm_txtMaKhoaDaoTao.getValue().trim() == '') {
                alert('Bạn chưa nhập mã khoa đào tạo');
                frm_txtMaKhoaDaoTao.focus();
                return false;
            }
            if (frm_txtTenKhoaDaoTao.getValue().trim() == '') {
                alert('Bạn chưa nhập tên khoa đào tạo');
                frm_txtTenKhoaDaoTao.focus();
                return false;
            }


        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:Window runat="server" ID="wdDaotao" Icon="UserSuitBlack" Padding="10" Resizable="false"
            Hidden="true" Title="Khóa đào tạo" Modal="true" Constrain="true" Width="720"
            LabelWidth="115" Layout="FormLayout" AutoHeight="true">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommand" />
                <ext:TextField runat="server" ID="frm_txtMaKhoaDaoTao" AllowBlank="false" FieldLabel="Mã khóa đào tạo<span style='color:red'>*</span>"
                    MaskRe="[0-9\.|a-z|A-Z]" CtCls="requiredData" AnchorHorizontal="40%" MaxLength="50" TabIndex="1" />
                <ext:TextField runat="server" ID="frm_txtTenKhoaDaoTao" AnchorHorizontal="100%" AllowBlank="false"
                    CtCls="requiredData" FieldLabel="Tên khóa đào tạo<span style='color:red'>*</span>"
                    TabIndex="2" MaxLength="50" />
                <ext:TextField runat="server" ID="frm_txtdiadiemdaotao" AnchorHorizontal="100%" FieldLabel="Địa điểm đào tạo"
                    TabIndex="3" MaxLength="200" />
                <ext:TextField runat="server" ID="frm_txtsoluonghocvien" AnchorHorizontal="40%" FieldLabel="Số lượng học viên"
                    TabIndex="4" MaxLength="10" MaskRe="/[0-9]/" />
                <ext:Container ID="Container1" runat="server" Height="140" Layout="ColumnLayout">
                    <Items>
                        <ext:Container ID="Container2" runat="server" Height="130" ColumnWidth="0.50" Layout="FormLayout">
                            <Items>
                                <ext:FieldSet AutoHeight="true" Title="Kinh phí" runat="server" ID="fs" AnchorHorizontal="98%">
                                    <Items>
                                        <ext:TextField runat="server" MaskRe="/[0-9\.]/" FieldLabel="Kinh phí dự kiến" ID="frm_txtKinhPhiDuKien"
                                            AnchorHorizontal="100%" MaxLength="18" TabIndex="5" />
                                        <ext:TextField runat="server" MaskRe="/[0-9\.]/" FieldLabel="Kinh phí thực tế" ID="frm_txtKinhPhiThucTe"
                                            AnchorHorizontal="100%" MaxLength="18" TabIndex="6" />
                                        <ext:Container ID="Container3" runat="server" Height="27" Layout="ColumnLayout">
                                            <Items>
                                                <ext:Container ID="Container4" runat="server" Height="23" ColumnWidth="0.80">
                                                    <Items>
                                                        <ext:TextField runat="server" MaskRe="/[0-9\.]/" EmptyText="Số tiền hỗ trợ cho 1 nhân viên"
                                                            TabIndex="7" FieldLabel="Công ty hỗ trợ" Width="240" ID="frm_txtCongTyHoTro"
                                                            MaxLength="18" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container5" runat="server" Height="23" ColumnWidth="0.20">
                                                    <Items>
                                                        <ext:Label ID="Label2" runat="server" Text=" VNĐ/1 NV" AnchorHorizontal="100%" />
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container ID="Container9" runat="server" Height="27" Layout="ColumnLayout">
                                            <Items>
                                                <ext:Container ID="Container10" runat="server" Height="23" ColumnWidth="0.80">
                                                    <Items>
                                                        <ext:TextField runat="server" MaskRe="/[0-9\.]/" EmptyText="Số tiền nhân viên phải đóng thêm"
                                                            TabIndex="8" FieldLabel="NV đóng góp" Width="240" MaxLength="18" ID="frm_txtNhanVienDongGop" />
                                                    </Items>
                                                </ext:Container>
                                                <ext:Container ID="Container11" runat="server" Height="23" ColumnWidth="0.20">
                                                    <Items>
                                                        <ext:Label ID="Label3" runat="server" Text=" VNĐ" AnchorHorizontal="100%" />
                                                    </Items>
                                                </ext:Container>
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Container>
                        <ext:Container ID="Container12" runat="server" Height="130" ColumnWidth="0.50">
                            <Items>
                                <ext:FieldSet AutoHeight="true" Title="Thông tin" runat="server" ID="FieldSet1" ColumnWidth="0.50">
                                    <Items>
                                        <ext:Container runat="server" ID="Container6" Layout="FormLayout" ColumnWidth="0.34"
                                            LabelWidth="115">
                                            <Items>
                                                <ext:ComboBox runat="server" ID="cbx_chungchi" FieldLabel="Chứng chỉ" DisplayField="TEN_CHUNGCHI"
                                                    LabelWidth="115" ValueField="MA_CHUNGCHI" AnchorHorizontal="100%" TabIndex="9"
                                                    Editable="false">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store runat="server" ID="cbx_chungchi_Store" AutoLoad="False" OnRefreshData="cbx_chungchi_Store_OnRefreshData">
                                                            <Reader>
                                                                <ext:JsonReader IDProperty="MA_CHUNGCHI">
                                                                    <Fields>
                                                                        <ext:RecordField Name="MA_CHUNGCHI" />
                                                                        <ext:RecordField Name="TEN_CHUNGCHI" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Listeners>
                                                        <Expand Handler="if(cbx_chungchi.store.getCount()==0) cbx_chungchi_Store.reload();" />
                                                        <Select Handler="this.triggers[0].show();" />
                                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container8" Layout="FormLayout" ColumnWidth="0.34"
                                            LabelWidth="115">
                                            <Items>
                                                <ext:Checkbox runat="server" ID="chk_nganhan" BoxLabel="Ngắn hạn" TabIndex="10" AnchorHorizontal="98%">
                                                </ext:Checkbox>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container18" Layout="FormLayout" ColumnWidth="0.34"
                                            LabelWidth="115">
                                            <Items>
                                                <ext:Hidden runat="server" ID="hdfChonTenDonViPhuTrach" />
                                                <ext:ComboBox runat="server" ID="cbxDonViPhuTrach" DisplayField="Ten" ValueField="Ma"
                                                    MinChars="1" EmptyText="Gõ để tìm kiếm" LoadingText="Đang tải dữ liệu..." PageSize="15"
                                                    FieldLabel="Đơn vị Phụ trách" AnchorHorizontal="100%" ItemSelector="div.search-item">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="stTrinhDo" runat="server" AutoLoad="false">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="../Base/ComboSearchHandler.ashx" />
                                                            </Proxy>
                                                            <BaseParams>
                                                                <ext:Parameter Name="Table" Value="dbo.DM_DOITACDAOTAO" Mode="Value" />
                                                                <ext:Parameter Name="ValueField" Value="Ma" Mode="Value" />
                                                                <ext:Parameter Name="DisplayField" Value="Ten" Mode="Value" />
                                                            </BaseParams>
                                                            <Reader>
                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                    <Fields>
                                                                        <ext:RecordField Name="Ma" />
                                                                        <ext:RecordField Name="Ten" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Template ID="Template1" runat="server">
                                                        <Html>
                                                            <tpl for=".">
                                                                  <div class="search-item">
                                                                                <h3>{Ten}</h3>
                                                                                {Ma} <br />
                                                                  </div>
                                                                 </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show();hdfChonTenDonViPhuTrach.setValue(cbxDonViPhuTrach.getValue());" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdfChonTenDonViPhuTrach.reset(); }" />
                                                        <Focus Handler="cbxDonViPhuTrach.store.reload();" />
                                                    </Listeners>
                                                </ext:ComboBox>
                                                <%--<ext:ComboBox ID="cbxDonViPhuTrach" ValueField="Ma" DisplayField="Ten" FieldLabel="Đơn vị Phụ trách"
                                                    TabIndex="11" PageSize="10" ListWidth="180" ItemSelector="div.search-item" MinChars="1"
                                                    EmptyText="Nhập tên hoặc mã đơn vị để tìm kiếm" LoadingText="Đang tải dữ liệu..."
                                                    AnchorHorizontal="100%" runat="server">
                                                    <Triggers>
                                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                    </Triggers>
                                                    <Store>
                                                        <ext:Store ID="cbxChonTenDonViPhuTrach_Store" runat="server" AutoLoad="false">
                                                            <Proxy>
                                                                <ext:HttpProxy Method="POST" Url="SearchTenDoiTacDaoTaoVi.ashx" />
                                                            </Proxy>
                                                            <Reader>
                                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                                    <Fields>
                                                                        <ext:RecordField Name="Ten" />
                                                                        <ext:RecordField Name="Ma" />
                                                                    </Fields>
                                                                </ext:JsonReader>
                                                            </Reader>
                                                        </ext:Store>
                                                    </Store>
                                                    <Template ID="Template1" runat="server">
                                                        <Html>
                                                            <tpl for=".">
						                        <div class="search-item">
							                        <h3>{Ten}</h3>
                                                    {Ma} <br />
						                        </div>
					                        </tpl>
                                                        </Html>
                                                    </Template>
                                                    <Listeners>
                                                        <Select Handler="this.triggers[0].show(); hdfChonTenDonViPhuTrach.setValue(cbxDonViPhuTrach.getValue());" />
                                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); hdfChonTenDonViPhuTrach.reset(); }" />
                                                        <Expand Handler="if(cbxDonViPhuTrach.store.getCount()==0){cbxDonViPhuTrach.store.reload();}" />
                                                    </Listeners>
                                                </ext:ComboBox>--%>
                                            </Items>
                                        </ext:Container>
                                        <ext:Container runat="server" ID="Container7" Layout="FormLayout" ColumnWidth="0.34"
                                            LabelWidth="115">
                                            <Items>
                                                <ext:TextField runat="server" ID="frm_txtThoigiandukien" AnchorHorizontal="100%"
                                                    FieldLabel="Thời gian dự kiến" TabIndex="12" MaxLength="50" />
                                            </Items>
                                        </ext:Container>
                                    </Items>
                                </ext:FieldSet>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
            </Items>
            <Buttons>
                <ext:Button ID="Button17" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="False">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="btn_EditKhoaDaoTao" runat="server" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Command" Value="Edit">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" ID="btn_UpdateClose" Text="Cập nhật & Đóng lại" Icon="Disk">
                    <Listeners>
                        <Click Handler="return CheckInput();" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnSave_Click">
                            <EventMask ShowMask="true" Msg="Đang lưu dữ liệu" />
                            <ExtraParams>
                                <ext:Parameter Name="Close" Value="True">
                                </ext:Parameter>
                            </ExtraParams>
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button ID="Button21" runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="#{wdDaotao}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{Button17}.show();#{btn_EditKhoaDaoTao}.hide();
                               #{btn_UpdateClose}.show();ResetValue();frm_txtMaKhoaDaoTao.enable();
                               btn_EditKhoaDaoTao.hide();btn_UpdateClose.show();Button17.show();hdfCommand.setValue('');" />
                <Show Handler="#{frm_txtMaKhoaDaoTao}.focus();if(hdfCommand.getValue()=='Edit'){
                                   btn_UpdateClose.hide();
                                   Button17.hide();
                                   btn_EditKhoaDaoTao.show(); 
                               }" />
            </Listeners>
        </ext:Window>
        <%--<uc1:GridPanel ID="grp_CacKhoaDaoTao" runat="server" />--%>
        <uc3:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        <uc2:SingleGridPanel ID="grpKhoaDaoTao" runat="server" Render="CHIPHIDUKIEN=RenderVND,SOLUONGHOCVIEN=RenderAlignRight,CHIPHITHUCTE=RenderVND,NhanVienDong=RenderVND,CongTyHoTro=RenderVND,IsNganHan=GetBooleanIcon"
            LockedColumn="MA_KHOA,TEN_KHOAHOC" ColumnWidth="TEN_KHOAHOC=200,MA_KHOA=80,ThoiGianDuKien=150,DIA_DIEM_DAO_TAO=180,Ten=200,SOLUONGHOCVIEN=100 "
            TableForDeleting="KHOA_DAOTAO" EmptyTextSearch="Nhập mã khóa và tên khóa..."
            SearchField="MA_KHOA,TEN_KHOAHOC" TableOrViewName="view_DanhSachKhoaTaoTao" DisplayPrimaryColumn="true"
            IDProperty="MA_KHOA" ColumnName="MA_KHOA,TEN_KHOAHOC,ThoiGianDuKien,CHIPHIDUKIEN,CHIPHITHUCTE,DIA_DIEM_DAO_TAO,SOLUONGHOCVIEN,NhanVienDong,CongTyHoTro,Ten,TEN_CHUNGCHI,IsNganHan"
            ColumnHeader="Mã khóa học,Tên khóa học,Thời gian dự kiến,Chi phí dự kiến,Chi phí thực tế,Địa điểm đào tạo,Số lượng học viên,Nhân viên đóng,Công ty hỗ trợ,Đơn vị phụ trách,Tên chứng chỉ,Ngắn hạn" />
    </div>
    </form>
</body>
</html>
