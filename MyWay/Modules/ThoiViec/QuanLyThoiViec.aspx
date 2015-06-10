<%@ Page Language="C#" AutoEventWireup="true" CodeFile="QuanLyThoiViec.aspx.cs" Inherits="Modules_ThoiViec_QuanLyThoiViec" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript" src="Resource/JavaScript.js"></script>
    <script src="../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <link href="Resource/css.css" rel="stylesheet" />
    <style type="text/css">
        #GridPanel1 .x-grid3-cell-inner {
            white-space: nowrap !important;
        }

        #pnReportPanel .x-tab-panel-header {
            display: none !important;
        }

        #hsImage {
            border: 1px solid #99BBE8 !important;
        }

        .Download {
            background-image: url(../../Resource/images/download.png) !important;
        }

        .cell-imagecommand-value {
            padding: 0px !important;
            margin: 0px !important;
        }

        #GridPanel1 {
            border-left: 1px solid #99BBE8 !important;
        }

        #pnlCoCauToChuc-xsplit {
            border-right: none !important;
        }
    </style>
    <script type="text/javascript">
        // Attachment
        var prepare = function (grid, command, record, row, col, value) {
            if ((record.data.AttachFile == '' || record.data.AttachFile == null) && command.command == "Download") {
                command.hidden = true;
                command.hideMode = "visibility";
            }
        }
        var CheckValidFile = function (el) {
            var regex = /^.+\.(?:(?:[eE][xX][eE]?)|(?:[mM][sS][iI]))$/;
            testFile = regex.test(fufAttach_AttachFile.getValue());
            if (testFile && fufAttach_AttachFile.getValue().trim() != '') {
                alert('Phần mềm không hỗ trợ hai định dạng .exe và .msi');
                fufAttach_AttachFile.focus();
                return false;
            }
            var size = 0;
            for (var num1 = 0; num1 < el.files.length; num1++) {
                var file = el.files[num1];
                size += file.size;
            }
            if (size > 10485760) {
                alert('Kích thước của tệp tin vượt quá quy định (10MB)');
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfRecordID" />
            <ext:Hidden runat="server" ID="hdfButton" />
            <ext:Hidden runat="server" ID="hdfIdCacKhoanCongNo" />
            <ext:Hidden runat="server" ID="hdfQuery" />
            <ext:Menu ID="RowContextMenu" runat="server">
                <Items>
                    <ext:MenuItem ID="mnuAdd" runat="server" Icon="Add" Text="Thêm nhân viên sắp thôi việc">
                        <Listeners>
                            <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuCapNhatThuTuc" runat="server" Icon="PageGreen" Text="Cập nhật thủ tục">
                        <Listeners>
                            <Click Handler="return CheckSelectedRows(#{GridPanel1});" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnCapNhatThuTuc_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuHuyThuTuc" runat="server" Icon="Delete" Text="Hủy thủ tục">
                        <%--  <Listeners>
                        <Click Handler="return CheckSelectedRows(#{GridPanel1});" />
                    </Listeners>--%>
                        <DirectEvents>
                            <Click OnEvent="mnuHuyThuTuc_Click">
                                <EventMask ShowMask="true" />
                                <Confirmation ConfirmRequest="true" Title="Cảnh báo" Message="Bạn chỉ sử dụng tính năng này khi nhân viên muốn ngừng thủ tục thôi việc và tiếp tục làm việc tại công ty ?" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Window runat="server" Layout="FormLayout" Padding="6" Modal="true" Title="Cập nhật thanh toán công nợ"
                Width="400" Constrain="true" Resizable="false" ID="wdCapNhatThanhToanCongNo"
                Icon="Money" AutoHeight="true" Hidden="true">
                <Items>
                    <ext:DateField runat="server" Editable="false" ID="dfNgayThanhToan" FieldLabel="Ngày thanh toán"
                        AnchorHorizontal="100%">
                    </ext:DateField>
                    <ext:NumberField runat="server" ID="nbfSoTienConNo" FieldLabel="Số tiền còn nợ<span style='color:red'>*</span>"
                        AnchorHorizontal="100%" />
                    <ext:CompositeField runat="server" FieldLabel="Số tiền" ID="cpsSoTien">
                        <Items>
                            <ext:NumberField runat="server" ID="nbfSoTienThanhToan" Width="120">
                                <Listeners>
                                    <Blur Handler="if(nbfSoTienThanhToan.getValue()*1>=CheckBoxSelectionModelCongNo.getSelected().data.SoTienConLai*1){chkDaThanhToanDu.setValue('true')}else{chkDaThanhToanDu.setValue('false')}" />
                                </Listeners>
                            </ext:NumberField>
                            <ext:Checkbox runat="server" ID="chkDaThanhToanDu" BoxLabel="Đã thanh toán đủ">
                                <Listeners>
                                    <Check Handler="if(chkDaThanhToanDu.checked){
                                                        nbfSoTienThanhToan.setValue(CheckBoxSelectionModelCongNo.getSelected().data.SoTienConLai);
                                                    }
                                                    else
                                                    {
                                                        nbfSoTienThanhToan.setValue('');
                                                    }" />
                                </Listeners>
                            </ext:Checkbox>
                        </Items>
                    </ext:CompositeField>
                    <ext:Hidden runat="server" ID="hdfFileAttachment" />
                    <ext:FileUploadField runat="server" ID="fup_fileAttachment" AnchorHorizontal="100%"
                        FieldLabel="Đính kèm">
                    </ext:FileUploadField>
                    <ext:TextArea runat="server" ID="txtGhiChuThanhToan" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                    </ext:TextArea>
                </Items>
                <Listeners>
                    <Hide Handler="dfNgayThanhToan.reset();txtGhiChuThanhToan.reset();
                                   dfNgayThanhToan.enable();nbfSoTienThanhToan.reset();
                                   chkDaThanhToanDu.reset();nbfSoTienConNo.reset();cpsSoTien.show();
                                   fup_fileAttachment.reset();hdfFileAttachment.reset();
                                  " />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnChuaThanhToan" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="if(nbfSoTienConNo.getValue()==''){alert('Bạn chưa nhập số tiền còn nợ');return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnChuaThanhToan_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnDaThanhToan" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="if(dfNgayThanhToan.getValue()==''){alert('Bạn chưa nhập ngày thanh toán !');return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDaThanhToan_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button3" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdCapNhatThanhToanCongNo.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" Layout="BorderLayout" ID="wdShowReport"
                Title="In quyết định thôi việc" Maximized="true" Icon="Printer">
                <Items>
                    <ext:TabPanel ID="pnReportPanel" Region="Center" AnchorVertical="100%" Border="false"
                        runat="server">
                    </ext:TabPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="#{pnReportPanel}.remove(0);addHomePage(#{pnReportPanel},'Homepage','../Report/BaoCao_Main.aspx?type=QuyetDinhThoiViec&MaCB='+#{checkboxSelection}.getSelected().data.MaCB, 'In quyết định thôi việc')" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="Button1" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="#{wdShowReport}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Layout="FormLayout" Padding="6" Modal="true" Title="Cập nhật bàn giao tài sản"
                Width="400" Constrain="true" ID="wdCapNhatTaiSan" Icon="Pencil" AutoHeight="true"
                Hidden="true">
                <Items>
                    <ext:DateField runat="server" Editable="false" ID="dfNgayBanGiao" FieldLabel="Ngày bàn giao"
                        AnchorHorizontal="100%">
                    </ext:DateField>
                    <ext:Hidden runat="server" ID="hdfAttach_AttachFile" />
                    <ext:FileUploadField ID="fufAttach_AttachFile" runat="server" FieldLabel="Chọn tệp tin"
                        AnchorHorizontal="100%" Icon="Attach">
                        <Listeners>
                            <FileSelected Handler="CheckValidFile(this.fileInput.dom);" />
                        </Listeners>
                    </ext:FileUploadField>
                    <ext:TextArea runat="server" ID="txtGhiChu" FieldLabel="Ghi chú" AnchorHorizontal="100%">
                    </ext:TextArea>
                </Items>
                <Listeners>
                    <Hide Handler="dfNgayBanGiao.reset();txtGhiChu.reset();dfNgayBanGiao.enable();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnChuaBanGiao" runat="server" Text="Cập nhật" Icon="Disk">
                        <DirectEvents>
                            <Click OnEvent="btnChuaBanGiao_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="btnDaBanGiao" runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="if(dfNgayBanGiao.getValue()==''){alert('Bạn chưa nhập ngày bàn giao !');return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDaBanGiao_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button6" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdCapNhatTaiSan.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Layout="FormLayout" Padding="6" Modal="true" Title="Cập nhật thủ tục"
                Width="600" Constrain="true" ID="wdCapNhatThuTuc" Icon="Pencil" AutoHeight="true"
                Hidden="true" Resizable="true">
                <Items>
                    <ext:Container runat="server" Layout="ColumnLayout" AnchorHorizontal="100%" Height="105">
                        <Items>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:TextField runat="server" ID="txtSoQuyetDinh" AnchorHorizontal="98%" FieldLabel="Số quyết định">
                                    </ext:TextField>
                                    <ext:DateField runat="server" ID="dfNgayNghi" Editable="true" FieldLabel="Ngày thôi việc<span style='color:red;'>*</span>" CtCls="requiredData" AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                    </ext:DateField>
                                    <ext:ComboBox ID="cbTraTheBHYT" Editable="false" AnchorHorizontal="98%" FieldLabel="Thẻ BHYT"
                                        runat="server">
                                        <Items>
                                            <ext:ListItem Text="Chưa trả" Value="False" />
                                            <ext:ListItem Text="Đã trả thẻ BHYT" Value="True" />
                                        </Items>
                                        <Listeners>
                                            <Select Handler="if(#{cbTraTheBHYT}.getValue()=='True'){
                                                     #{dfNgayTraThe}.enable();
                                                 }
                                                 else
                                                 {
                                                    #{dfNgayTraThe}.disable();
                                                 }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox ID="cbSoBHXH" Editable="false" AnchorHorizontal="98%" FieldLabel="Sổ BHXH"
                                        runat="server">
                                        <Items>
                                            <ext:ListItem Text="Chưa trả" Value="False" />
                                            <ext:ListItem Text="Đã trả sổ BHXH" Value="True" />
                                        </Items>
                                        <Listeners>
                                            <Select Handler="if (#{cbSoBHXH}.getValue()=='True') {
                                                    #{dfNgayTraSo}.enable();
                                                }
                                                else
                                                {
                                                    #{dfNgayTraSo}.disable();
                                                }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:Checkbox runat="server" Hidden="true" ID="chkThemVaoDsHanChe" AnchorHorizontal="98%"
                                        BoxLabel="Đưa vào danh sách hạn chế">
                                        <Listeners>
                                            <Change Handler="if (#{chkThemVaoDsHanChe}.checked) {
                                            #{cbxLyDoHanChe}.enable();
                                        }
                                        else {
                                            #{cbxLyDoHanChe}.disable();
                                        }" />
                                        </Listeners>
                                    </ext:Checkbox>
                                </Items>
                            </ext:Container>
                            <ext:Container runat="server" Layout="FormLayout" ColumnWidth="0.5">
                                <Items>
                                    <ext:Hidden runat="server" ID="hdfCanBoDuyet" />
                                    <ext:ComboBox AnchorHorizontal="100%" ValueField="PRKEY" DisplayField="HOTEN" runat="server"
                                        FieldLabel="Cán bộ duyệt" PageSize="10" HideTrigger="false" ItemSelector="div.search-item"
                                        MinChars="1" EmptyText="nhập tên để tìm kiếm" ID="cbxCanBoDuyet" LoadingText="Đang tải dữ liệu...">
                                        <Store>
                                            <ext:Store ID="Store3" runat="server" AutoLoad="false">
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
                                        <Template ID="Template2" runat="server">
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
                                            <Select Handler="hdfCanBoDuyet.setValue(cbxCanBoDuyet.getValue());" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:ComboBox runat="server" ID="cbx_lydonghi" Disabled="false" FieldLabel="Lý do thôi việc<span style='color:red;'>*</span>"
                                        CtCls="requiredData" DisplayField="TEN_LYDO_NGHI" ValueField="MA_LYDO_NGHI" AnchorHorizontal="100%"
                                        Editable="false" ItemSelector="div.list-item">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Template ID="Template1" runat="server">
                                            <Html>
                                                <tpl for=".">
						                        <div class="list-item"> 
							                        {TEN_LYDO_NGHI}
						                        </div>
					                        </tpl>
                                            </Html>
                                        </Template>
                                        <Store>
                                            <ext:Store runat="server" ID="cbx_lydonghi_Store" AutoLoad="False" OnRefreshData="cbx_lydonghi_Store_OnRefreshData">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="MA_LYDO_NGHI">
                                                        <Fields>
                                                            <ext:RecordField Name="MA_LYDO_NGHI" />
                                                            <ext:RecordField Name="TEN_LYDO_NGHI" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Listeners>
                                            <Expand Handler="if(cbx_lydonghi.store.getCount()==0) cbx_lydonghi_Store.reload();" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                    <ext:DateField runat="server" ID="dfNgayTraThe" Disabled="true" Editable="true" FieldLabel="Ngày trả thẻ" AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                    </ext:DateField>
                                    <ext:DateField runat="server" ID="dfNgayTraSo" Disabled="true" Editable="true" FieldLabel="Ngày trả sổ" AnchorHorizontal="100%" MaskRe="/[0-9\/]/" Format="d/M/yyyy" Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày không đúng" Vtype="daterange">
                                    </ext:DateField>
                                    <%--<ext:DateField runat="server" ID="dfNgayHoanThanh" AnchorHorizontal="99%" Editable="false"
                                        FieldLabel="Ngày hoàn thành" />--%>
                                    <ext:ComboBox runat="server" ID="cbxLyDoHanChe" Disabled="true" Hidden="true" FieldLabel="Lý do hạn chế"
                                        DisplayField="TEN_LYDO_HC" ValueField="MA_LYDO_HC" AnchorHorizontal="100%" Editable="false"
                                        ItemSelector="div.list-item">
                                        <Triggers>
                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                        </Triggers>
                                        <Template ID="Template3" runat="server">
                                            <Html>
                                                <tpl for=".">
						                        <div class="list-item"> 
							                        {TEN_LYDO_HC}
						                        </div>
					                        </tpl>
                                            </Html>
                                        </Template>
                                        <Store>
                                            <ext:Store runat="server" ID="cbxLyDoHanChe_Store" AutoLoad="False" OnRefreshData="cbxLyDoHanChe_Store_OnRefreshData">
                                                <Reader>
                                                    <ext:JsonReader IDProperty="MA_LYDO_HC">
                                                        <Fields>
                                                            <ext:RecordField Name="MA_LYDO_HC" />
                                                            <ext:RecordField Name="TEN_LYDO_HC" />
                                                        </Fields>
                                                    </ext:JsonReader>
                                                </Reader>
                                            </ext:Store>
                                        </Store>
                                        <Listeners>
                                            <Expand Handler="if(cbxLyDoHanChe.store.getCount()==0) cbxLyDoHanChe_Store.reload();" />
                                            <Select Handler="this.triggers[0].show();" />
                                            <TriggerClick Handler="if (index == 0) { this.reset(); this.triggers[0].hide(); }" />
                                        </Listeners>
                                    </ext:ComboBox>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                    <ext:Hidden runat="server" ID="hdfTepTinDinhKem" />
                    <ext:CompositeField ID="CompositeField11" runat="server" AnchorHorizontal="100%"
                        FieldLabel="Tệp tin đính kèm">
                        <Items>
                            <ext:FileUploadField ID="fufTepTinDinhKem" runat="server" EmptyText="Chọn tệp tin"
                                ButtonText="" Icon="Attach" Width="415">
                            </ext:FileUploadField>
                            <ext:Button runat="server" ID="btnDownload" Icon="ArrowDown" ToolTip="Tải về" Hidden="true">
                                <DirectEvents>
                                    <Click OnEvent="btnDownload_Click" IsUpload="true" />
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" ID="btnTepTinDelete" Icon="Delete" ToolTip="Xóa">
                                <Listeners>
                                    <Click Handler="return checkDeleteAttackFile(#{fufTepTinDinhKem}.fileInput.dom);" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnAttachDelete_Click">
                                        <Confirmation Title="Thông báo từ hệ thống" Message="Bạn có chắc chắn muốn xóa tệp tin đính kèm?"
                                            ConfirmRequest="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                        </Items>
                    </ext:CompositeField>
                    <ext:Checkbox ID="chkHoanTatThuTuc" runat="server" BoxLabel="Chính thức đánh dấu nhân viên này đã nghỉ việc">
                        <Listeners>
                            <Check Handler="checkHoanTatThucTuc(checkboxSelection,chkHoanTatThuTuc);" />
                        </Listeners>
                    </ext:Checkbox>
                    <ext:TextArea runat="server" ID="txtGhiChuTV" AnchorHorizontal="100%" FieldLabel="Ghi chú" />
                </Items>
                <Buttons>
                    <ext:Button runat="server" Text="Cập nhật" Icon="Disk">
                        <Listeners>
                            <Click Handler="return CheckInputThuTuc(#{fufTepTinDinhKem}.fileInput.dom);" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="CapNhatThuTuc_Click">
                                <EventMask ShowMask="true" />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdCapNhatThuTuc.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <BeforeShow Handler="if(cbx_lydonghi.store.getCount()==0) cbx_lydonghi_Store.reload();
                    if(cbxLyDoHanChe.store.getCount()==0) cbxLyDoHanChe_Store.reload(); 
                    if(#{chkThemVaoDsHanChe}.checked) {#{cbxLyDoHanChe}.enable();}" />
                    <Hide Handler="hdfCanBoDuyet.reset(); txtSoQuyetDinh.reset(); dfNgayNghi.reset();
                    cbTraTheBHYT.reset(); cbSoBHXH.reset(); chkThemVaoDsHanChe.reset();
                    cbxCanBoDuyet.reset(); cbx_lydonghi.reset(); dfNgayTraThe.reset();
                    dfNgayTraSo.reset(); cbxLyDoHanChe.reset(); hdfTepTinDinhKem.reset();
                    fufTepTinDinhKem.reset(); chkHoanTatThuTuc.reset(); txtGhiChuTV.reset();" />
                </Listeners>
            </ext:Window>
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" DisplayWorkingStatus="DangLamViec"
                ChiChonMotCanBo="false" />
            <ext:Store ID="Store1" AutoLoad="true" runat="server">
                <Listeners>
                    <Load Handler="checkboxSelection.clearSelections();" />
                </Listeners>
                <Proxy>
                    <ext:HttpProxy Method="GET" Url="QuanLyThoiViecHandler.ashx" />
                </Proxy>
                <AutoLoadParams>
                    <ext:Parameter Name="start" Value="={0}" />
                    <ext:Parameter Name="limit" Value="={30}" />
                </AutoLoadParams>
                <BaseParams>
                    <ext:Parameter Name="SearchKey" Value="txtSearch.getValue()" Mode="Raw" />
                    <ext:Parameter Name="MaDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                    <ext:Parameter Name="Query" Value="hdfQuery.getValue()" Mode="Raw" />
                </BaseParams>
                <Reader>
                    <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="MaCB" />
                            <ext:RecordField Name="HoTen" />
                            <ext:RecordField Name="PhongBan" />
                            <ext:RecordField Name="SoQuyetDinh" />
                            <ext:RecordField Name="LyDoNghi" />
                            <ext:RecordField Name="FrKeyHoSo" />
                            <ext:RecordField Name="DaTraTheBHYT" />
                            <ext:RecordField Name="DaTraSoBHXH" />
                            <ext:RecordField Name="DaHoanThanhThuTuc" />
                            <ext:RecordField Name="NgayTraTheBHYT" />
                            <ext:RecordField Name="NgayTraSoBHXH" />
                            <ext:RecordField Name="NgayHoanThanhThuTuc" />
                            <ext:RecordField Name="NgayNghi" />
                            <ext:RecordField Name="IsBelongToBlackList" />
                            <ext:RecordField Name="DiaChiLienHe" />
                            <ext:RecordField Name="Email" />
                            <ext:RecordField Name="DiDong" />
                            <ext:RecordField Name="ChucVu" />
                            <ext:RecordField Name="ViTriCongViec" />
                            <ext:RecordField Name="NgaySinh" />
                            <ext:RecordField Name="GioiTinh" />
                            <ext:RecordField Name="NgayLamChinhThuc" />
                            <ext:RecordField Name="NgayThuViec" />
                            <ext:RecordField Name="CanBoDuyetNghi" />
                            <ext:RecordField Name="Photo" />
                            <ext:RecordField Name="HoanTatCongNo" />
                            <ext:RecordField Name="BanGiaoTaiSan" />
                            <ext:RecordField Name="AttachFile" />
                            <ext:RecordField Name="GhiChu" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="brlayout">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                                Icon="ApplicationViewColumns" TrackMouseOver="false" AnchorHorizontal="100%"
                                AutoExpandMin="180">
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:Button ID="btnThemNhanVien" runat="server" Text="Thêm nhân viên sắp thôi việc"
                                                Icon="UserAdd">
                                                <Listeners>
                                                    <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button ID="btnCapNhatThuTuc" Disabled="true" runat="server" Text="Cập nhật thủ tục"
                                                Icon="Pencil">
                                                <Listeners>
                                                    <Click Handler="return CheckSelectedRows(#{GridPanel1});" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnCapNhatThuTuc_Click">
                                                        <EventMask ShowMask="true" />
                                                    </Click>
                                                </DirectEvents>
                                                <ToolTips>
                                                    <ext:ToolTip runat="server" AutoHide="false" Title="Hướng dẫn" Html="Chức năng này cho phép bạn cập nhật các thủ tục cho nhân viên như đã trả sổ, trả thẻ bảo hiểm.
                                                         Đồng thời chức năng này chính thức chuyển một nhân viên đang làm việc sang trạng thái thôi việc">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:Button>
                                            <ext:Button ID="btnHuyThuTuc" runat="server" Disabled="true" Text="Hủy thủ tục" Icon="Delete">
                                                <%-- <Listeners>
                                                <Click Handler="return CheckSelectedRows(#{GridPanel1});" />
                                            </Listeners>--%>
                                                <ToolTips>
                                                    <ext:ToolTip runat="server" Title="Hướng dẫn" AutoHide="false" Html="Khi bấm nút <b>Hủy thủ tục</b> thì nhân viên này sẽ được đưa trở lại danh sách nhân viên và được coi như là một nhân viên đang làm việc bình thường !">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuHuyThuTuc_Click">
                                                        <EventMask ShowMask="true" />
                                                        <Confirmation ConfirmRequest="true" Title="Cảnh báo" Message="Bạn chỉ sử dụng tính năng này khi nhân viên muốn ngừng thủ tục thôi việc và tiếp tục làm việc tại công ty ?" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button runat="server" ID="btnPrintReport" Text="In quyết định" Icon="Printer" Hidden="true"
                                                ToolTip="In quyết định thôi việc">
                                                <Listeners>
                                                    <Click Handler="CheckSelectedRows(#{GridPanel1});wdShowReport.show();" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:ToolbarFill runat="server" ID="tbfill" />
                                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Nhập họ tên hoặc mã cán bộ"
                                                ID="txtSearch">
                                                <Listeners>
                                                    <Blur Handler="this.triggers[0].show();" />
                                                    <TriggerClick Handler="#{txtSearch}.reset();
                                                                           #{PagingToolbar1}.pageIndex=0;
                                                                           #{PagingToolbar1}.doLoad();
                                                                           this.triggers[0].hide();" />
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                </Listeners>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                            </ext:TriggerField>
                                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                                <Listeners>
                                                    <Click Handler="#{PagingToolbar1}.pageIndex=0;
                                                                    #{PagingToolbar1}.doLoad();
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
                                <DirectEvents>
                                    <RowDblClick OnEvent="btnCapNhatThuTuc_Click">
                                        <EventMask ShowMask="true" />
                                    </RowDblClick>
                                </DirectEvents>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                                        <ext:Column ColumnID="AttachFile" Width="25" DataIndex="" Align="Center" Locked="true">
                                            <Commands>
                                                <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                                    <ToolTip Text="Tải tệp tin đính kèm" />
                                                </ext:ImageCommand>
                                            </Commands>
                                            <PrepareCommand Fn="prepare" />
                                        </ext:Column>
                                        <ext:Column ColumnID="MaCB" Header="Mã cán bộ" DataIndex="MaCB" Locked="true" Width="70" />
                                        <ext:Column ColumnID="HoTen" Width="130" Header="Họ tên" Locked="true" DataIndex="HoTen" />
                                        <ext:Column ColumnID="DaHoanThanhThuTuc" Width="120" Header="Tình trạng" Locked="false"
                                            DataIndex="DaHoanThanhThuTuc">
                                            <Renderer Fn="RenderThuTuc" />
                                        </ext:Column>
                                        <ext:Column ColumnID="PhongBan" Width="250" Header="Bộ phận" DataIndex="PhongBan" />
                                        <%--<ext:Column ColumnID="ChucVu" Width="120" Header="Chức vụ" DataIndex="ChucVu" />
                                            <ext:Column ColumnID="ViTriCongViec" Width="150" Header="Vị trí công việc" DataIndex="ViTriCongViec" />--%>
                                        <ext:Column ColumnID="SoQuyetDinh" Width="100" Align="Left" Header="Số quyết định"
                                            DataIndex="SoQuyetDinh" />
                                        <ext:DateColumn Format="dd/MM/yyyy" ColumnID="NgayNghi" Width="80" Header="Ngày thôi việc"
                                            DataIndex="NgayNghi" />
                                        <ext:Column ColumnID="DaTraTheBHYT" Width="95" Align="Center" Header="Hoàn tất công nợ"
                                            DataIndex="HoanTatCongNo">
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column ColumnID="DaTraTheBHYT" Width="90" Align="Center" Header="Bàn giao tài sản"
                                            DataIndex="BanGiaoTaiSan">
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column ColumnID="DaTraTheBHYT" Width="90" Align="Center" Header="Đã trả thẻ BHYT"
                                            DataIndex="DaTraTheBHYT">
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column ColumnID="DaTraSoBHXH" Width="90" Align="Center" Header="Đã trả sổ BHXH"
                                            DataIndex="DaTraSoBHXH">
                                            <Renderer Fn="GetBooleanIcon" />
                                        </ext:Column>
                                        <ext:Column Width="180" Header="Lý do thôi việc" DataIndex="LyDoNghi">
                                        </ext:Column>
                                        <ext:Column Width="200" Header="Ghi chú" DataIndex="GhiChu" />
                                        <%--<ext:Column ColumnID="IsBelongToBlackList" Width="180" Header="Không cho ứng tuyển lại"
                                            DataIndex="IsBelongToBlackList">
                                            <Renderer Fn="GetBlackListComment" />
                                        </ext:Column>--%>
                                        <ext:Column ColumnID="Hidden" Width="0" DataIndex="" Align="Center" Locked="false">
                                            <Commands>
                                                <ext:ImageCommand CommandName="Hidden">
                                                </ext:ImageCommand>
                                            </Commands>
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                                        <Listeners>
                                            <RowSelect Handler="hdfRecordID.setValue(checkboxSelection.getSelected().id);
                                            try{btnHuyThuTuc.enable();}catch(e){} SetDetailData();btnThemCongNo.disable();
                                            try{btnCapNhatThuTuc.enable();}catch(e){}
                                            LoadDataInSouthPanel();" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv">
                                        <HeaderRows>
                                            <ext:HeaderRow>
                                                <Columns>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="cbx_TinhTrang" runat="server" Width="120" SelectedIndex="0" Editable="false">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" Value="-1" />
                                                                    <ext:ListItem Text="Chưa làm thủ tục" Value="0" />
                                                                    <ext:ListItem Text="Hoàn tất thủ tục" Value="1" />
                                                                </Items>
                                                                <Listeners>
                                                                    <Select Handler="Ext.net.DirectMethods.SetValueQuery();" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false" />
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="cbHoanTatCongNo" runat="server" Width="90" SelectedIndex="0" Editable="false">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" Value="-1" />
                                                                    <ext:ListItem Text="Chưa trả" Value="0" />
                                                                    <ext:ListItem Text="Đã trả" Value="1" />
                                                                </Items>
                                                                <Listeners>
                                                                    <Select Handler="Ext.net.DirectMethods.SetValueQuery();" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="cbBanGiaoTaiSan" runat="server" Width="90" SelectedIndex="0" Editable="false">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" Value="-1" />
                                                                    <ext:ListItem Text="Chưa trả" Value="0" />
                                                                    <ext:ListItem Text="Đã trả" Value="1" />
                                                                </Items>
                                                                <Listeners>
                                                                    <Select Handler="Ext.net.DirectMethods.SetValueQuery();" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="cbxDaTraTheBHYT" runat="server" Width="90" SelectedIndex="0" Editable="false">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" Value="-1" />
                                                                    <ext:ListItem Text="Chưa trả" Value="0" />
                                                                    <ext:ListItem Text="Đã trả" Value="1" />
                                                                </Items>
                                                                <Listeners>
                                                                    <Select Handler="Ext.net.DirectMethods.SetValueQuery();" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                    <ext:HeaderColumn AutoWidthElement="false">
                                                        <Component>
                                                            <ext:ComboBox ID="cbxDaTraSoBHXH" runat="server" Width="90" SelectedIndex="0" Editable="false">
                                                                <Items>
                                                                    <ext:ListItem Text="Tất cả" Value="-1" />
                                                                    <ext:ListItem Text="Chưa trả" Value="0" />
                                                                    <ext:ListItem Text="Đã trả" Value="1" />
                                                                </Items>
                                                                <Listeners>
                                                                    <Select Handler="Ext.net.DirectMethods.SetValueQuery();" />
                                                                </Listeners>
                                                            </ext:ComboBox>
                                                        </Component>
                                                    </ext:HeaderColumn>
                                                </Columns>
                                            </ext:HeaderRow>
                                        </HeaderRows>
                                    </ext:LockingGridView>
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
                                                    <ext:ListItem Text="15" />
                                                    <ext:ListItem Text="30" />
                                                    <ext:ListItem Text="40" />
                                                    <ext:ListItem Text="50" />
                                                    <ext:ListItem Text="100" />
                                                    <ext:ListItem Text="200" />
                                                    <ext:ListItem Text="500" />
                                                    <ext:ListItem Text="1000" />
                                                    <ext:ListItem Text="2000" />
                                                    <ext:ListItem Text="5000" />
                                                    <ext:ListItem Text="10000" />
                                                </Items>
                                                <SelectedItem Value="30" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                        <Listeners>
                                            <Change Handler="checkboxSelection.clearSelections();" />
                                        </Listeners>
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                <Listeners>
                                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                    <Command Handler="Ext.net.DirectMethods.DownloadAttach(record.data.AttachFile);" />
                                </Listeners>
                            </ext:GridPanel>
                        </Center>
                        <South>
                            <ext:TabPanel ID="tabPanel" Border="false" runat="server" Title="Thông tin chung"
                                Height="200">
                                <Items>
                                    <ext:Panel Title="Thông tin nhân viên" Padding="6" AnchorHorizontal="100%" runat="server"
                                        ID="pnlThongTinNhanVien" Border="false">
                                        <Items>
                                            <ext:Container ID="Container1" Layout="ColumnLayout" runat="server" Height="200">
                                                <Items>
                                                    <ext:Container ID="Container20" Layout="FormLayout" runat="server" Width="130">
                                                        <Items>
                                                            <ext:Image ImageUrl="~/Modules/NhanSu/ImageNhanSu/No_person.jpg" Width="120"
                                                                Cls="hsImage" Height="160" runat="server" ID="hsImage" />
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container ID="Contain1" Layout="FormLayout" LabelWidth="120" runat="server"
                                                        ColumnWidth=".33">
                                                        <Items>
                                                            <ext:TextField FieldLabel="Mã cán bộ" EnableKeyEvents="true" AnchorHorizontal="95%"
                                                                runat="server" ID="txtMaCB">
                                                                <Listeners>
                                                                    <KeyDown Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Họ tên" AnchorHorizontal="95%" runat="server" ID="txtFullName">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Giới tính" AnchorHorizontal="95%" runat="server" ID="txtGioiTinh">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Ngày sinh" AnchorHorizontal="95%" runat="server" ID="txtNgaySinh">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Ngày thử việc" runat="server" AnchorHorizontal="95%" ID="txtNgayThuViec">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Ngày làm chính thức" runat="server" AnchorHorizontal="95%"
                                                                ID="txtNgayLamChinhThuc">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container ID="Container2" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                                        <Items>
                                                            <ext:TextField FieldLabel="Chức vụ" runat="server" AnchorHorizontal="95%" ID="txtChucVu">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Vị trí công việc" runat="server" AnchorHorizontal="95%"
                                                                ID="txtViTriCongViec">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField AnchorHorizontal="95%" FieldLabel="Di động" runat="server" ID="txtDiDong">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextField FieldLabel="Email" AnchorHorizontal="95%" runat="server" ID="txtEmail">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextArea Height="50" FieldLabel="Địa chỉ liên hệ" runat="server" AnchorHorizontal="95%"
                                                                ID="txtDiaChiLienHe">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextArea>
                                                        </Items>
                                                    </ext:Container>
                                                    <ext:Container ID="Container3" Layout="FormLayout" runat="server" ColumnWidth=".33">
                                                        <Items>
                                                            <ext:TextField FieldLabel="Người duyệt nghỉ" EnableKeyEvents="true" runat="server"
                                                                AnchorHorizontal="95%" ID="txtNguoiDuyetNghi">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextField>
                                                            <ext:TextArea FieldLabel="Lý do thôi việc" runat="server" AnchorHorizontal="95%"
                                                                ID="txtLyDoNghi">
                                                                <Listeners>
                                                                    <Focus Handler="this.blur();" />
                                                                </Listeners>
                                                            </ext:TextArea>
                                                        </Items>
                                                    </ext:Container>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel Title="Công nợ nhân viên" Layout="BorderLayout" AnchorHorizontal="100%" Hidden="true"
                                        runat="server" ID="pnlCongNoNhanVien" Border="false">
                                        <Items>
                                            <ext:Hidden runat="server" ID="hdfLoadedEmployee" />
                                            <ext:GridPanel ID="grpCongNoNhanVien" Region="Center" runat="server" StripeRows="true"
                                                Border="false" TrackMouseOver="true" AutoExpandColumn="GhiChu" AutoScroll="true"
                                                AnchorHorizontal="100%" Height="200">
                                                <Store>
                                                    <ext:Store ID="grpCongNoNhanVienStore" AutoLoad="false" ShowWarningOnFailure="false"
                                                        OnRefreshData="grpCongNoNhanVienStore_OnRefreshData" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="ID">
                                                                <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="GhiChu" />
                                                                    <ext:RecordField Name="SoTien" />
                                                                    <ext:RecordField Name="SoTienDaTra" />
                                                                    <ext:RecordField Name="SoTienConLai" />
                                                                    <ext:RecordField Name="DaThanhToanHet" />
                                                                    <ext:RecordField Name="LyDoTamUng" />
                                                                    <ext:RecordField Name="NgayThanhToan" />
                                                                    <ext:RecordField Name="AttachFile" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel2" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Width="30" />
                                                        <ext:Column ColumnID="AttachFile" Width="25" DataIndex="" Align="Center">
                                                            <Commands>
                                                                <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                                                    <ToolTip Text="Tải tệp tin đính kèm" />
                                                                </ext:ImageCommand>
                                                            </Commands>
                                                            <PrepareCommand Fn="prepare" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="SoTien" Header="Số tiền tạm ứng" DataIndex="SoTien" Width="130">
                                                            <Renderer Fn="RenderVND" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="SoTien" Header="Số tiền đã trả" DataIndex="SoTienDaTra" Width="130">
                                                            <Renderer Fn="RenderVND" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="SoTien" Header="Số tiền còn nợ" DataIndex="SoTienConLai" Width="130">
                                                            <Renderer Fn="RenderVND" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="DaHoanThanh" Header="Tình trạng" DataIndex="DaThanhToanHet"
                                                            Width="100">
                                                            <Renderer Fn="RenderThanhToan" />
                                                        </ext:Column>
                                                        <ext:DateColumn Format="dd/MM/yyyy" Width="100" Header="Ngày thanh toán" DataIndex="NgayThanhToan" />
                                                        <ext:Column ColumnID="GhiChu" Width="150" Header="Lý do tạm ứng" DataIndex="LyDoTamUng" />
                                                        <ext:Column ColumnID="GhiChu" Width="150" Header="Ghi chú" DataIndex="GhiChu" />
                                                    </Columns>
                                                </ColumnModel>
                                                <Listeners>
                                                    <Command Handler="Ext.net.DirectMethods.DownloadAttach(record.data.AttachFile);" />
                                                </Listeners>
                                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="CheckBoxSelectionModelCongNo" runat="server">
                                                        <Listeners>
                                                            <RowSelect Handler="btnThemCongNo.enable();" />
                                                        </Listeners>
                                                    </ext:RowSelectionModel>
                                                </SelectionModel>
                                                <BottomBar>
                                                    <ext:Toolbar runat="server" ID="tb2">
                                                        <Items>
                                                            <ext:Button ID="btnThemCongNo" Disabled="true" runat="server" Text="Cập nhật trạng thái thanh toán"
                                                                Icon="Money">
                                                                <Listeners>
                                                                    <Click Handler="if(hdfRecordID.getValue()==''){alert('Bạn chưa chọn nhân viên nào');}" />
                                                                </Listeners>
                                                                <Menu>
                                                                    <ext:Menu runat="server" ID="mnuThanhToanCongNo">
                                                                        <Items>
                                                                            <ext:MenuItem runat="server" ID="mnuDaThanhToan" Text="Đã thanh toán" Icon="Add">
                                                                                <Listeners>
                                                                                    <Click Handler="nbfSoTienConNo.hide();wdCapNhatThanhToanCongNo.show();
                                                                                                btnDaThanhToan.show();btnChuaThanhToan.hide();
                                                                                                hdfFileAttachment.setValue(CheckBoxSelectionModelCongNo.getSelected().data.AttachFile);" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem ID="mnuChuaThanhToan" runat="server" Text="Chưa thanh toán" Icon="Delete">
                                                                                <Listeners>
                                                                                    <Click Handler="nbfSoTienConNo.show();cpsSoTien.hide();wdCapNhatThanhToanCongNo.show();btnDaThanhToan.hide();btnChuaThanhToan.show();dfNgayThanhToan.disable();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </BottomBar>
                                            </ext:GridPanel>
                                        </Items>
                                    </ext:Panel>
                                    <ext:Panel Title="Bàn giao tài sản" AnchorHorizontal="100%" runat="server" ID="pnlBanGiaoTaiSan"
                                        Border="false">
                                        <Items>
                                            <ext:Hidden runat="server" ID="Hidden1" />
                                            <ext:Hidden runat="server" ID="IDBanGiaoTaiSan" />
                                            <ext:GridPanel ID="GridPanel2" Region="Center" runat="server" StripeRows="true" Border="false"
                                                TrackMouseOver="true" AutoExpandColumn="TenTaiSan" AutoScroll="true" AnchorHorizontal="100%"
                                                Height="172">
                                                <Store>
                                                    <ext:Store ID="grpBanGiaoTaiSanStore" AutoLoad="false" ShowWarningOnFailure="false"
                                                        OnRefreshData="grpBanGiaoTaiSanStore_OnRefreshData" runat="server">
                                                        <Reader>
                                                            <ext:JsonReader IDProperty="ID">
                                                                <Fields>
                                                                    <ext:RecordField Name="ID" />
                                                                    <ext:RecordField Name="MaTaiSan" />
                                                                    <ext:RecordField Name="TenTaiSan" />
                                                                    <ext:RecordField Name="TinhTrang" />
                                                                    <ext:RecordField Name="DaBanGiao" />
                                                                    <ext:RecordField Name="GhiChu" />
                                                                    <ext:RecordField Name="NgayBanGiao" />
                                                                    <ext:RecordField Name="DonViTinh" />
                                                                    <ext:RecordField Name="NgayTao" />
                                                                    <ext:RecordField Name="SoLuong" />
                                                                    <ext:RecordField Name="AttachFile" />
                                                                </Fields>
                                                            </ext:JsonReader>
                                                        </Reader>
                                                    </ext:Store>
                                                </Store>
                                                <ColumnModel ID="ColumnModel4" runat="server">
                                                    <Columns>
                                                        <ext:RowNumbererColumn Header="STT" Width="30" />
                                                        <ext:Column ColumnID="AttachFile" Width="25" DataIndex="" Align="Center">
                                                            <Commands>
                                                                <ext:ImageCommand CommandName="Download" IconCls="Download" Style="margin: 0 !important;">
                                                                    <ToolTip Text="Tải tệp tin đính kèm" />
                                                                </ext:ImageCommand>
                                                            </Commands>
                                                            <PrepareCommand Fn="prepare" />
                                                        </ext:Column>
                                                        <ext:Column ColumnID="MaTaiSan" Header="Mã tài sản" DataIndex="MaTaiSan" Width="80" />
                                                        <ext:Column ColumnID="TenTaiSan" Header="Tên tài sản" DataIndex="TenTaiSan" Width="130" />
                                                        <ext:Column ColumnID="TenTaiSan" Header="Số lượng" DataIndex="SoLuong" Width="60" />
                                                        <ext:Column ColumnID="TenTaiSan" Header="Đơn vị tính" DataIndex="DonViTinh" Width="70" />
                                                        <ext:Column ColumnID="TinhTrang" Header="Tình trạng" DataIndex="TinhTrang" Width="130" />
                                                        <ext:Column ColumnID="DaBanGiao" Header="Trạng thái bàn giao" DataIndex="DaBanGiao"
                                                            Width="110">
                                                            <Renderer Fn="RenderTrangThaiBanGiao" />
                                                        </ext:Column>
                                                        <ext:DateColumn Format="dd/MM/yyyy" Width="100" Header="Ngày bàn giao" DataIndex="NgayBanGiao" />
                                                        <ext:Column ColumnID="GhiChu" Width="220" Header="Ghi chú" DataIndex="GhiChu" />
                                                        <%--<ext:DateColumn Format="dd/MM/yyyy" Width="90" Header="Ngày tạo" DataIndex="NgayTao" />--%>
                                                    </Columns>
                                                </ColumnModel>
                                                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                                                <SelectionModel>
                                                    <ext:RowSelectionModel ID="CheckBoxSelectionModelTaiSan" runat="server">
                                                        <Listeners>
                                                            <RowSelect Handler="try{btnSuaTaiSan.enable();}catch(e){} IDBanGiaoTaiSan.setValue(CheckBoxSelectionModelTaiSan.getSelected().id);btnDanhDauTrangThaiBanGiao.enable();" />
                                                        </Listeners>
                                                    </ext:RowSelectionModel>
                                                </SelectionModel>
                                                <BottomBar>
                                                    <ext:Toolbar runat="server" ID="Toolbar1">
                                                        <Items>
                                                            <ext:Button runat="server" Icon="Tick" ID="btnDanhDauTrangThaiBanGiao" Disabled="true"
                                                                Text="Đánh dấu trạng thái bàn giao">
                                                                <Menu>
                                                                    <ext:Menu runat="server" ID="mnuTrangThaiBanGiao">
                                                                        <Items>
                                                                            <ext:MenuItem runat="server" Text="Đã bàn giao" Icon="Accept" ID="mnuDaBanGiao">
                                                                                <Listeners>
                                                                                    <Click Handler="wdCapNhatTaiSan.show();btnDaBanGiao.show();
                                                                                                btnChuaBanGiao.hide();hdfAttach_AttachFile.setValue(CheckBoxSelectionModelTaiSan.getSelected().data.AttachFile);" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                            <ext:MenuItem runat="server" Text="Chưa bàn giao" Icon="Delete" ID="mnuChuaBanGiao">
                                                                                <Listeners>
                                                                                    <Click Handler="wdCapNhatTaiSan.show();btnChuaBanGiao.show();btnDaBanGiao.hide();dfNgayBanGiao.disable();" />
                                                                                </Listeners>
                                                                            </ext:MenuItem>
                                                                        </Items>
                                                                    </ext:Menu>
                                                                </Menu>
                                                            </ext:Button>
                                                        </Items>
                                                    </ext:Toolbar>
                                                </BottomBar>
                                                <Listeners>
                                                    <Command Handler="Ext.net.DirectMethods.DownloadAttach(record.data.AttachFile);" />
                                                </Listeners>
                                            </ext:GridPanel>
                                        </Items>
                                    </ext:Panel>
                                </Items>
                            </ext:TabPanel>
                        </South>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
