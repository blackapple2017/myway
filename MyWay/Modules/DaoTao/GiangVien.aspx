<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GiangVien.aspx.cs" Inherits="Modules_DaoTao_GiangVien" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc2" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc3" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var ResetValue = function () {
            gv_txtMaGiaoVien.reset();
            gv_txtHoten.reset();
            df_ngaysinh.reset();
            txt_chucvu.reset();
            cbx_trinhdo.reset();
            txt_email.reset();
            txt_dtcq.reset();
            chk_nvcongty.reset();
            chk_QuanLyPhuTrach.reset();
            txt_donvicongtac.reset();
            txt_diachi.reset();
            txt_didong.reset();
            txt_kinhnghiem.reset();
            cbx_gioitinh.reset();
        }

        var GetGender = function (value, p, record) {
            if (value == "1")
                return "<span style='color:blue'>Nam</span>";
            else
                return "<span style='color:red'>Nữ</span>";
        }
        var CheckInput = function () {
            reg1 = /^[0-9A-Za-z]+[0-9A-Za-z_]*@[\w\d.]+.\w{2,4}$/;
            testmail = reg1.test(txt_email.getValue());

            if (gv_txtMaGiaoVien.getValue().trim() == '') {
                alert('Bạn chưa nhập mã giáo viên');
                gv_txtMaGiaoVien.focus();
                return false;
            }
            if (gv_txtHoten.getValue().trim() == '') {
                alert('Bạn chưa nhập tên giáo viên');
                gv_txtHoten.focus();
                return false;
            }
            if (!testmail && txt_email.getValue().trim() != '') {
                alert('Định dạng Email chưa đúng !');
                txt_email.focus();
                return false
            }
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
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:Window runat="server" ID="wdGiaoVien" Icon="UserSuitBlack" Padding="10" Resizable="false"
            Hidden="true" Title="Giáo viên đào tạo" Modal="true" Constrain="true" Width="600"
            AutoHeight="true">
            <Items>
                <ext:Hidden runat="server" ID="hdfCommand" />
                <ext:Container runat="server" ID="ctq1" Layout="ColumnLayout" Height="190">
                    <Items>
                        <ext:Container runat="server" ID="c1" ColumnWidth=".5" Layout="FormLayout" Padding="6">
                            <Items>
                                <ext:TextField runat="server" ID="gv_txtMaGiaoVien" FieldLabel="Mã giáo viên<span style='color:red'>*</span>"
                                    MaskRe="[0-9\.|a-z|A-Z]" CtCls="requiredData"  MaxLength="20" AnchorHorizontal="98%" />
                                <ext:DateField runat="server" ID="df_ngaysinh" FieldLabel="Ngày sinh" AnchorHorizontal="98%"
                                    EnableKeyEvents="true"  Editable="true" Format="d/M/yyyy">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); #{df_ngaysinh}.setMinValue(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:DateField>
                                <ext:TextField runat="server" ID="txt_chucvu" FieldLabel="Chức vụ" AnchorHorizontal="98%"
                                     MaxLength="100">
                                </ext:TextField>
                                <ext:Hidden runat="server" ID="hdftrinhdo" />
                                <ext:ComboBox runat="server" ID="cbx_trinhdo" DisplayField="TEN_TRINHDO" ValueField="MA_TRINHDO"
                                     MinChars="1" EmptyText="Gõ để tìm kiếm" LoadingText="Đang tải dữ liệu..." ListWidth="250"
                                    PageSize="15" FieldLabel="Trình độ" AnchorHorizontal="98%" ItemSelector="div.search-item">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store ID="stTrinhDo" runat="server" AutoLoad="false">
                                            <Proxy>
                                                <ext:HttpProxy Method="POST" Url="../Base/ComboSearchHandler.ashx" />
                                            </Proxy>
                                            <BaseParams>
                                                <ext:Parameter Name="Table" Value="dbo.DM_TRINHDO" Mode="Value" />
                                                <ext:Parameter Name="ValueField" Value="MA_TRINHDO" Mode="Value" />
                                                <ext:Parameter Name="DisplayField" Value="TEN_TRINHDO" Mode="Value" />
                                            </BaseParams>
                                            <Reader>
                                                <ext:JsonReader Root="plants" TotalProperty="total">
                                                    <Fields>
                                                        <ext:RecordField Name="MA_TRINHDO" />
                                                        <ext:RecordField Name="TEN_TRINHDO" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Template ID="Template1" runat="server">
                                        <Html>
                                            <tpl for=".">
                                      <div class="search-item">
                                      
                                       <h3>{TEN_TRINHDO}</h3>
                                                    {MA_TRINHDO} <br />
                                      </div>
                                     </tpl>
                                        </Html>
                                    </Template>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();hdftrinhdo.setValue(cbx_trinhdo.getValue());" />
                                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();hdftrinhdo.reset(); }" />
                                        <Expand Handler="if(cbx_trinhdo.store.getCount()==0){cbx_trinhdo.store.reload();}" />
                                    </Listeners>
                                </ext:ComboBox>
                                <%--<ext:ComboBox runat="server" ID="cbx_trinhdo" FieldLabel="Học vấn" DisplayField="TEN_TRINHDO"
                                    ValueField="TEN_TRINHDO" AnchorHorizontal="98%" TabIndex="24" Editable="false">
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Store>
                                        <ext:Store runat="server" ID="cbx_trinhdo_Store" AutoLoad="False" OnRefreshData="cbx_trinhdo_Store_OnRefreshData">
                                            <Reader>
                                                <ext:JsonReader IDProperty="TEN_TRINHDO">
                                                    <Fields>
                                                        <ext:RecordField Name="TEN_TRINHDO" />
                                                        <ext:RecordField Name="TEN_TRINHDO" />
                                                    </Fields>
                                                </ext:JsonReader>
                                            </Reader>
                                        </ext:Store>
                                    </Store>
                                    <Listeners>
                                        <Expand Handler="if(cbx_trinhdo.store.getCount()==0) cbx_trinhdo_Store.reload();" />
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>--%>
                                <ext:TextField runat="server" ID="txt_email" Regex="^([0-9a-zA-Z]([-.\w]*[0-9a-zA-Z])*@([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,9})$"
                                    FieldLabel="Email" AnchorHorizontal="98%"  MaxLength="100" RegexText="Định dạng email không đúng!">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txt_dtcq" MaskRe="/[0-9\.]/" FieldLabel="Điện thoại CQ"
                                    AnchorHorizontal="98%"  MaxLength="50">
                                </ext:TextField>
                            </Items>
                        </ext:Container>
                        <ext:Container runat="server" ID="Container8" ColumnWidth="0.5" Layout="FormLayout">
                            <Items>
                               <ext:TextField runat="server" ID="gv_txtHoten" Width="565" FieldLabel="Họ tên<span style='color:red'>*</span>" AnchorHorizontal="100%" CtCls="requiredData"
                                 MaxLength="100" />
                                <ext:ComboBox runat="server" ID="cbx_gioitinh" Editable="false" SelectedIndex="0"
                                    FieldLabel="Giới tính" AnchorHorizontal="100%" >
                                    <Items>
                                        <ext:ListItem Text="Nam" Value="True" />
                                        <ext:ListItem Text="Nữ" Value="False" />
                                    </Items>
                                    <Triggers>
                                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                    </Triggers>
                                    <Listeners>
                                        <Select Handler="this.triggers[0].show();" />
                                        <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                    </Listeners>
                                </ext:ComboBox>
                                <ext:TextField runat="server" ID="txt_donvicongtac" FieldLabel="Đơn vị công tác"
                                    AnchorHorizontal="100%"  MaxLength="200">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txt_diachi" FieldLabel="Địa chỉ liên hệ" AnchorHorizontal="100%"
                                     MaxLength="500">
                                </ext:TextField>
                                <ext:TextField runat="server" ID="txt_didong" MaskRe="/[0-9\.]/" FieldLabel="Di động"
                                    AnchorHorizontal="100%"  MaxLength="50">
                                </ext:TextField>
                                <ext:Checkbox runat="server" ID="chk_QuanLyPhuTrach" BoxLabel="Là Quản lý/Phụ trách" 
                                    AnchorHorizontal="98%">
                                </ext:Checkbox>
                                <ext:Checkbox runat="server" ID="chk_nvcongty" BoxLabel="Là nhân viên công ty" 
                                    AnchorHorizontal="98%">
                                </ext:Checkbox>
                            </Items>
                        </ext:Container>
                    </Items>
                </ext:Container>
                <ext:TextArea runat="server" ID="txt_kinhnghiem" Width="565" Height="100" FieldLabel="Kinh nghiệm"
                    EmptyText="Kinh nghiệm giảng dạy"  MaxLength="500">
                </ext:TextArea>
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
                <ext:Button ID="btn_EditGiaoVien" runat="server" Hidden="true" Text="Cập nhật" Icon="Disk">
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
                        <Click Handler="#{wdGiaoVien}.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="#{Button17}.show();#{btn_EditGiaoVien}.hide();
                               #{btn_UpdateClose}.show();ResetValue();gv_txtMaGiaoVien.enable();
                               btn_EditGiaoVien.hide();btn_UpdateClose.show();Button17.show();hdfCommand.setValue('');" />
                <Show Handler="#{gv_txtMaGiaoVien}.focus();if(hdfCommand.getValue()=='Edit'){
                                   btn_UpdateClose.hide();
                                   Button17.hide();
                                   btn_EditGiaoVien.show(); 
                               }" />
            </Listeners>
        </ext:Window>
        <ext:Button runat="server" Text="Thêm mới" Icon="Add" ID="btnAddGiangVien">
            <Menu>
                <ext:Menu runat="server">
                    <Items>
                        <ext:MenuItem runat="server" Text="Nhập mới" Icon="UserAdd">
                            <Listeners>
                                <Click Handler="wdGiaoVien.show();" />
                            </Listeners>
                        </ext:MenuItem>
                        <ext:MenuItem runat="server" Text="Chọn từ danh sách nhân viên" Icon="UserAdd">
                            <Listeners>
                                <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                            </Listeners>
                        </ext:MenuItem>
                    </Items>
                </ext:Menu>
            </Menu>
        </ext:Button>
        <%--<uc1:GridPanel ID="grp_DanhSachGiangVien" DisableEditWindow="true" runat="server" />--%>
        <uc2:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
        <uc3:SingleGridPanel ID="grpTeacherList" DisplayPrimaryColumn="true" Render="GioiTinh=GetGender,LaNhanvienCty=GetBooleanIcon,LaQuanLyPhuTrach=GetBooleanIcon"
            EmptyTextSearch="Nhập mã hoặc họ tên giáo viên..." SearchField="MaGV,HoTenGV"
            LockedColumn="MaGV,HoTenGV" ColumnWidth="HoTenGV=130,DonViCongTac=200,DiaChiLienHe=200,Email=150"
            ColumnName="MaGV,HoTenGV,GioiTinh,NgaySinh,DiaChiLienHe,Email,ChucVu,DonViCongTac,DiDong,HocVan,DTCoQuan,KinhNghiemGiangDay,LaNhanvienCty,LaQuanLyPhuTrach"
            ColumnHeader="Mã,Họ tên giáo viên,Giới tính,Ngày sinh,Địa chỉ liên hệ,Email,Chức vụ,Đơn vị công tác,Di động,Học vấn,Địa chỉ cơ quan,Kinh nghiệm giảng dạy,Là Nhân viên công ty, Là Quản lý/Phụ trách"
            TableOrViewName="DM_GiaoVienDaoTao" TableForDeleting="DM_GiaoVienDaoTao" IDProperty="MaGV"
            runat="server" />
    </div>
    </form>
</body>
</html>
