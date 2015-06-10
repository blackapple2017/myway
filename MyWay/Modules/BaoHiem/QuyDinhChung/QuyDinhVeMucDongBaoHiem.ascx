<%@ Control Language="C#" AutoEventWireup="true" CodeFile="QuyDinhVeMucDongBaoHiem.ascx.cs"
    Inherits="Modules_BaoHiem_QuyDinhChung_QuyDinhVeMucDongBaoHiem" %>
<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<script type="text/javascript">
    var enterKeyPressHandler = function (f, e) {
        if (e.getKey() == e.ENTER) {
            //            QuyDinhVeMucDongBaoHiem1_Store1.reload();
            QuyDinhVeMucDongBaoHiem1_PagingToolbar1.pageIndex = 0;
            QuyDinhVeMucDongBaoHiem1_PagingToolbar1.doLoad();
        }
        if (this.getValue() != '') {
            this.triggers[0].show();
        }
    }
    var CheckSelectedRecord = function (grid, Store) {

        var s = grid.getSelectionModel().getSelections();
        var count = 0;
        for (var i = 0, r; r = s[i]; i++) {
            count++;
        }
        if (count > 1) {
            alert('Bạn chỉ được chọn một dòng');
            return false;
        }
        return true;
    }
    var RemoveItemOnGrid = function (grid, Store, DirectMethods) {
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
                    DirectMethods.DeleteRecord(r.data.ID);
                    QuyDinhVeMucDongBaoHiem1_btnEdit.disable();
                    QuyDinhVeMucDongBaoHiem1_btnDelete.disable();
                }
            }
        });
    }
    var CheckInputQuyDinhMucDongBH = function () {
        if (QuyDinhVeMucDongBaoHiem1_dfNgayHieuLuc.getValue() == '') {
            alert("Bạn chưa nhập ngày hiệu lực");
            QuyDinhVeMucDongBaoHiem1_dfNgayHieuLuc.focus();
            return false;
        }
        if (QuyDinhVeMucDongBaoHiem1_nfBHXHNhanVien.getValue() == '') {
            alert("Bạn chưa nhập tỷ lệ bảo hiểm xã hội nhân viên");
            QuyDinhVeMucDongBaoHiem1_nfBHXHNhanVien.focus();
            return false;
        }
        if (QuyDinhVeMucDongBaoHiem1_nfBHYTNhanVien.getValue() == '') {
            alert("Bạn chưa nhập tỷ lệ bảo hiểm y tế nhân viên ");
            QuyDinhVeMucDongBaoHiem1_nfBHYTNhanVien.focus();
            return false;

        }
        if (QuyDinhVeMucDongBaoHiem1_nfBHTNNhanVien.getValue() == '') {
            alert("Bạn chưa nhập tỷ lệ bảo hiểm thất nghiệp nhân viên ");
            QuyDinhVeMucDongBaoHiem1_nfBHTNNhanVien.focus();
            return false;
        }
        if (QuyDinhVeMucDongBaoHiem1_nfBHXHDonVi.getValue() == '') {
            alert("Bạn chưa nhập tỷ lệ bảo hiểm xã hội đơn vị");
            QuyDinhVeMucDongBaoHiem1_nfBHXHDonVi.focus();
            return false;
        }
        if (QuyDinhVeMucDongBaoHiem1_nfBHYTDonVi.getValue() == '') {
            alert("Bạn chưa nhập tỷ lệ bảo hiểm y tế đơn vị:");
            QuyDinhVeMucDongBaoHiem1_nfBHYTDonVi.focus();
            return false;
        }
        if (QuyDinhVeMucDongBaoHiem1_nfBHTNDonVi.getValue() == '') {
            alert("Bạn chưa nhập tỷ lệ bảo hiểm thất nghiệp đơn vị");
            QuyDinhVeMucDongBaoHiem1_nfBHTNDonVi.focus();
            return false;
        }
        if (parseInt('0' + QuyDinhVeMucDongBaoHiem1_nfSanBHXH.getValue()) > parseInt('0' + QuyDinhVeMucDongBaoHiem1_nfTranBHXH.getValue())) {
            alert('Mức sàn phải thấp hơn mức trần');
            QuyDinhVeMucDongBaoHiem1_nfTranBHXH.focus();
            return false;
        }
        //        if (parseInt('0' + QuyDinhVeMucDongBaoHiem1_nfSanBHYT.getValue()) > parseInt('0' + QuyDinhVeMucDongBaoHiem1_nfTranBHYT.getValue())) {
        //            alert('Mức sàn phải thấp hơn mức trần');
        //            QuyDinhVeMucDongBaoHiem1_nfTranBHYT.focus();
        //            return false;
        //        }
        //        if (parseInt('0' + QuyDinhVeMucDongBaoHiem1_nfSanBHTN.getValue()) > parseInt('0' + QuyDinhVeMucDongBaoHiem1_nfTranBHTN.getValue())) {
        //            alert('Mức sàn phải thấp hơn mức trần');
        //            QuyDinhVeMucDongBaoHiem1_nfTranBHTN.focus();
        //            return false;
        //        }
        return true;
    }
    var RenderMucDongBaoHiem = function (value, p, record) {
        if (value == null || value == "") {
            return "0" + " %";
        }
        return value.toString() + " %";
    }
    var getSelectedIndexRow = function () {
        var record = GridPanel1.getSelectionModel().getSelected();
        var index = GridPanel1.store.indexOf(record);
        if (index == -1)
            return 0;
        return index;
    }
    var ResetFormMucDongBaoHiem = function () {
        QuyDinhVeMucDongBaoHiem1_dfNgayHieuLuc.reset();
        QuyDinhVeMucDongBaoHiem1_nfSanBHXH.reset();
        //        QuyDinhVeMucDongBaoHiem1_nfSanBHYT.reset(); 
        //        QuyDinhVeMucDongBaoHiem1_nfSanBHTN.reset();
        QuyDinhVeMucDongBaoHiem1_nfBHXHNhanVien.reset();
        QuyDinhVeMucDongBaoHiem1_nfBHYTNhanVien.reset();
        QuyDinhVeMucDongBaoHiem1_nfBHTNNhanVien.reset();
        QuyDinhVeMucDongBaoHiem1_nfTranBHXH.reset();
        //        QuyDinhVeMucDongBaoHiem1_nfTranBHYT.reset();
        //        QuyDinhVeMucDongBaoHiem1_nfTranBHTN.reset(); 
        //        QuyDinhVeMucDongBaoHiem1_nfTranBHTN.reset();
        QuyDinhVeMucDongBaoHiem1_nfBHXHDonVi.reset();
        QuyDinhVeMucDongBaoHiem1_nfBHYTDonVi.reset();
        QuyDinhVeMucDongBaoHiem1_nfBHTNDonVi.reset();
    }
</script>
<script src="../../../Resource/js/RenderJS.js"></script>
<div>
    <ext:Hidden runat="server" ID="hdfRecordID" />
    <ext:Hidden runat="server" ID="hdfMaDonVi">
    </ext:Hidden>
    <ext:Window ID="wdInputNewPrimaryKey" Modal="true" Layout="FormLayout" Width="400"
        Padding="6" Constrain="false" Title="Nhập khóa chính mới" Hidden="true" Icon="Add"
        runat="server" AutoHeight="true">
        <Items>
            <ext:TextField FieldLabel="Nhập mã" runat="server" ID="txtmaloaihdcoppy" AnchorHorizontal="110%">
            </ext:TextField>
        </Items>
        <Listeners>
            <Hide Handler="txtmaloaihdcoppy.reset();" />
        </Listeners>
        <Buttons>
            <ext:Button runat="server" Icon="Accept" Text="Đồng ý" ID="btnOK">
                <Listeners>
                    <Click Handler="if(txtmaloaihdcoppy.getValue().trim()==''){alert('Bạn chưa nhập mã');txtmaloaihdcoppy.focus();return false;}" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnOK_Click">
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button runat="server" ID="btnCancel" Icon="Decline" Text="Thoát">
                <Listeners>
                    <Click Handler="#{wdInputNewPrimaryKey}.hide();" />
                </Listeners>
            </ext:Button>
        </Buttons>
        <Listeners>
            <Hide Handler="txtmaloaihdcoppy.reset();" />
        </Listeners>
    </ext:Window>
    <ext:Menu ID="RowContextMenu" runat="server">
        <Items>
            <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                <Listeners>
                    <Click Handler="#{wdAddWindow}.show();" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="MenuItem4" runat="server" Icon="Delete" Text="Xóa">
                <Listeners>
                    <Click Handler="RemoveItemOnGrid(#{GridPanel1},#{Store1},#{DirectMethods})" />
                </Listeners>
            </ext:MenuItem>
            <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                <Listeners>
                    <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();return CheckSelectedRecord(#{GridPanel1},#{Store1});" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnEdit_Click">
                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    </Click>
                </DirectEvents>
            </ext:MenuItem>
        </Items>
    </ext:Menu>
    <ext:Window runat="server" Resizable="false" Hidden="true" AutoHeight="true" Layout="FormLayout"
        Width="520" Modal="true" Padding="6" Constrain="true" ID="wdAddWindow" Title="Thêm mới quy định về mức đóng bảo hiểm"
        Icon="Add">
        <Items>
            <ext:Hidden runat="server" ID="hdfCommand" />
            <ext:Panel ID="Panel5" runat="server" Height="260" Padding="6" Border="false">
                <Items>
                    <ext:Container ID="Container1" runat="server" Layout="FormLayout" Height="150">
                        <Items>
                            <ext:FieldSet ID="FieldSet3" runat="server" Title="Thông tin chung" ColumnWidth="1"
                                Height="60">
                                <Items>
                                    <ext:DateField ID="dfNgayHieuLuc" runat="server" FieldLabel="Ngày hiệu lực<span style='color:red;'>*</span>"
                                        CtCls="requiredData" AnchorHorizontal="98%" MaskRe="/[0-9\/]/" Format="d/M/yyyy"
                                        Regex="/^(3[0-1]|[0-2]?[0-9])\/(1[0-2]|0?[0-9])\/[0-9]{4}$/" RegexText="Định dạng ngày hạn nộp hồ sơ không đúng">
                                    </ext:DateField>
                                </Items>
                            </ext:FieldSet>
                            <ext:Container ID="Container2" runat="server" Layout="ColumnLayout" ColumnWidth="1"
                                Height="60">
                                <Items>
                                    <ext:FieldSet ID="FieldSet1" runat="server" Title="Mức sàn" ColumnWidth="0.5" LabelWidth="70" Padding="6">
                                        <Items>
                                            <ext:NumberField ID="nfSanBHXH" runat="server" FieldLabel="BHXH" AnchorHorizontal="100%"
                                                AllowNegative="false" MaxLength="10" MaskRe="/[0-9\.]/" LabelWidth="70">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="tl" runat="server" Title="Mức sàn bảo hiểm xã hội"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập số tiền mức sàn bảo hiểm xã hội(tối đa là 10 số)">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <%--<ext:NumberField ID="nfSanBHYT" runat="server" FieldLabel="BHYT" AnchorHorizontal="98%"
                                                AllowNegative="false" MaxLength="8" MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip1" runat="server" Title="Mức sàn bảo hiểm y tế"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập số tiền mức sàn bảo hiểm y tế(tối đa là 8 số)">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <ext:NumberField ID="nfSanBHTN" runat="server" FieldLabel="BHTN" AnchorHorizontal="98%"
                                                AllowNegative="false" MaxLength="8" MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip2" runat="server" Title="Mức sàn bảo hiểm thất nghiệp"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập số tiền mức sàn bảo hiểm thất nghiệp(tối đa là 8 số)">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>--%>
                                        </Items>
                                    </ext:FieldSet>
                                    <ext:FieldSet ID="FieldSet2" runat="server" Title="Mức trần" ColumnWidth="0.5" LabelWidth="70" Padding="6">
                                        <Items>
                                            <ext:NumberField ID="nfTranBHXH" runat="server" FieldLabel="BHXH" AnchorHorizontal="100%"
                                                AllowNegative="false" MaxLength="10" MaskRe="/[0-9\.]/" LabelWidth="70">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip3" runat="server" Title="Mức trần bảo hiểm xã hội"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập số tiền mức trần bảo hiểm xã hội(tối đa là 10 số)">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <%--<ext:NumberField ID="nfTranBHYT" runat="server" FieldLabel="BHYT" AnchorHorizontal="98%"
                                                AllowNegative="false" MaxLength="8" MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip4" runat="server" MaxLength="8"
                                                        Title="Mức trần bảo hiểm y tế" Header="true" Frame="true" Html="Gợi ý : Nhập số tiền mức trần bảo hiểm y tế(tối đa là 8 số)">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <ext:NumberField ID="nfTranBHTN" runat="server" FieldLabel="BHTN" AnchorHorizontal="98%"
                                                AllowNegative="false" MaxLength="8" MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip5" runat="server" Title="Mức trần bảo hiểm thất nghiệp"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập số tiền mức trần bảo hiểm thất nghiệp(tối đa là 8 số)">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>--%>
                                        </Items>
                                    </ext:FieldSet>
                                </Items>
                            </ext:Container>
                            <ext:Container ID="FieldS3et3" Layout="ColumnLayout" runat="server"
                                ColumnWidth="1" LabelWidth="50" Height="110">
                                <Items>
                                    <ext:FieldSet ID="Container3" runat="server" Layout="FormLayout" ColumnWidth="0.5"  Title="Tỷ lệ đóng của nhân viên" Padding="6"
                                        LabelWidth="70">
                                        <Items>
                                            <%--<ext:DisplayField ID="DisplayField4" FieldLabel="Nhân viên" runat="server" AnchorHorizontal="98%"
                                                LabelWidth="70">
                                            </ext:DisplayField>--%>
                                            <ext:NumberField ID="nfBHXHNhanVien" runat="server" FieldLabel="BHXH(%)<span style='color:red'>*</span>"
                                                AllowNegative="false" CtCls="requiredData" AnchorHorizontal="100%" MaxLength="6"
                                                MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip6" runat="server" Title="Tỷ lệ % bảo hiểm xã hội của nhân viên"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập tỷ lệ % bảo hiểm xã hội của nhân viên">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <ext:NumberField ID="nfBHYTNhanVien" runat="server" FieldLabel="BHYT(%)<span style='color:red'>*</span>"
                                                AllowNegative="false" CtCls="requiredData" AnchorHorizontal="100%" MaxLength="6"
                                                MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip7" runat="server" Title="Tỷ lệ % bảo hiểm y tế của nhân viên"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập tỷ lệ % bảo hiểm y tế của nhân viên">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <ext:NumberField ID="nfBHTNNhanVien" runat="server" FieldLabel="BHTN(%)<span style='color:red'>*</span>"
                                                AllowNegative="false" CtCls="requiredData" AnchorHorizontal="100%" MaxLength="6"
                                                MaskRe="/[0-9\.]/" LabelWidth="50">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip8" runat="server" Title="Tỷ lệ % bảo hiểm thất nghiệp của nhân viên"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập tỷ lệ % bảo hiểm thất nghiệp của nhân viên">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                        </Items>
                                    </ext:FieldSet>
                                    <ext:FieldSet ID="Container5" AnchorHorizontal="50%" runat="server" Layout="FormLayout" Title="Tỷ lệ đóng của đơn vị" Padding="6"
                                        ColumnWidth="0.5" LabelWidth="70">
                                        <Items>
                                            <%--<ext:DisplayField ID="DisplayField5" FieldLabel="Đơn vị" runat="server" AnchorHorizontal="98%"
                                                LabelWidth="70">
                                            </ext:DisplayField>--%>
                                            <ext:NumberField ID="nfBHXHDonVi" runat="server" FieldLabel="BHXH(%)<span style='color:red'>*</span>"
                                                AllowNegative="false" CtCls="requiredData" AnchorHorizontal="100%" MaxLength="6"
                                                MaskRe="/[0-9\.]/" LabelWidth="70">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip9" runat="server" Title="Tỷ lệ % bảo hiểm xã hội của đơn vị"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập tỷ lệ % bảo hiểm xã hội của đơn vị">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <ext:NumberField ID="nfBHYTDonVi" runat="server" FieldLabel="BHYT(%)<span style='color:red'>*</span>"
                                                AllowNegative="false" CtCls="requiredData" AnchorHorizontal="100%" MaskRe="/[0-9\.]/"
                                                LabelWidth="70" MaxLength="6">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip10" runat="server" Title="Tỷ lệ % bảo hiểm y tế của đơn vị"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập tỷ lệ % bảo hiểm y tế của đơn vị">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                            <ext:NumberField ID="nfBHTNDonVi" runat="server" FieldLabel="BHTN(%)<span style='color:red'>*</span>"
                                                AllowNegative="false" CtCls="requiredData" AnchorHorizontal="100%" MaskRe="/[0-9\.]/"
                                                LabelWidth="70" MaxLength="6">
                                                <ToolTips>
                                                    <ext:ToolTip Draggable="true" AutoHide="true" ID="ToolTip11" runat="server" Title="Tỷ lệ % bảo hiểm thất nghiệp của đơn vị"
                                                        Header="true" Frame="true" Html="Gợi ý : Nhập tỷ lệ % bảo hiểm thất nghiệp của đơn vị">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                            </ext:NumberField>
                                        </Items>
                                    </ext:FieldSet>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:Container>
                </Items>
            </ext:Panel>
        </Items>
        <Buttons>
            <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInputQuyDinhMucDongBH();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click" After="ResetFormMucDongBaoHiem();">
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
                    <Click Handler="resetWindowHide(); return CheckInputQuyDinhMucDongBH();" />
                </Listeners>
                <DirectEvents>
                    <Click OnEvent="btnCapNhat_Click">
                        <EventMask ShowMask="true" Msg="Đang lưu dữ liệu..." />
                        <ExtraParams>
                            <ext:Parameter Name="Command" Value="Edit">
                            </ext:Parameter>
                        </ExtraParams>
                    </Click>
                </DirectEvents>
            </ext:Button>
            <ext:Button ID="Button2" runat="server" Text="Cập nhật & Đóng lại" Icon="Disk">
                <Listeners>
                    <Click Handler="return CheckInputQuyDinhMucDongBH()" />
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
            <Hide Handler="#{btnCapNhat}.show(); #{btnSua}.hide();
                               #{Button2}.show();#{DirectMethods}.ResetWindowTitle();
                               ResetFormMucDongBaoHiem();
                               " />
        </Listeners>
    </ext:Window>
    <ext:Store ID="Store1" AutoLoad="true" runat="server">
        <Proxy>
            <ext:HttpProxy Method="GET" Url="HandlerBHMUCDONGBAOHIEM.ashx" />
        </Proxy>
        <AutoLoadParams>
            <ext:Parameter Name="start" Value="={0}" />
            <ext:Parameter Name="limit" Value="={30}" />
        </AutoLoadParams>
        <BaseParams>
            <ext:Parameter Name="SearchKey" Value="#{txtSearch}.getValue()" Mode="Raw" />
            <ext:Parameter Name="MaDonVi" Value="#{hdfMaDonVi}.getValue()" Mode="Raw" />
        </BaseParams>
        <Reader>
            <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="ID">
                <Fields>
                    <ext:RecordField Name="ID" />
                    <ext:RecordField Name="NgayHieuLuc" />
                    <ext:RecordField Name="SanBHXH" />
                    <%--<ext:RecordField Name="SanBHYT" />
                    <ext:RecordField Name="SanBHTN" />--%>
                    <ext:RecordField Name="TranBHXH" />
                    <%--<ext:RecordField Name="TranBHYT" />
                    <ext:RecordField Name="TranBHTN" />--%>
                    <ext:RecordField Name="NVBYXH" />
                    <ext:RecordField Name="NVBHYT" />
                    <ext:RecordField Name="NVBHTN" />
                    <ext:RecordField Name="DVBHXH" />
                    <ext:RecordField Name="DVBHYT" />
                    <ext:RecordField Name="DVBHTN" />
                    <ext:RecordField Name="UserID" />
                    <ext:RecordField Name="DateCreate" />
                    <ext:RecordField Name="MaDonVi" />
                </Fields>
            </ext:JsonReader>
        </Reader>
    </ext:Store>
    <ext:BorderLayout runat="server" ID="brlayout">
        <Center>
            <ext:GridPanel ID="GridPanel1" Border="false" runat="server" StoreID="Store1" StripeRows="true"
                Icon="ApplicationViewColumns" TrackMouseOver="false" AnchorHorizontal="110%">
                <TopBar>
                    <ext:Toolbar runat="server" ID="tb">
                        <Items>
                            <ext:Button ID="btnAddNew" runat="server" Text="Thêm mới" Icon="Add">
                                <Listeners>
                                    <Click Handler="#{wdAddWindow}.show();" />
                                </Listeners>
                            </ext:Button>
                            <ext:Button ID="btnEdit" runat="server" Disabled="true" Text="Sửa" Icon="Pencil">
                                <Listeners>
                                    <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();return CheckSelectedRecord(#{GridPanel1},#{Store1});" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnEdit_Click">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="btnDelete" runat="server" Text="Xóa" Disabled="true" Icon="Delete">
                                <Listeners>
                                    <Click Handler="RemoveItemOnGrid(#{GridPanel1},#{Store1},#{DirectMethods})" />
                                </Listeners>
                            </ext:Button>
                            <ext:ToolbarSeparator ID="ToolbarSeparator1" runat="server" />
                            <ext:ToolbarFill runat="server" ID="tbfill" />
                            <ext:TriggerField runat="server" Width="200" EnableKeyEvents="true" EmptyText="Tìm kiếm theo mức trần, mức sàn"
                                ID="txtSearch">
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <KeyPress Fn="enterKeyPressHandler" />
                                    <TriggerClick Handler="this.clear(); this.triggers[0].hide(); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:TriggerField>
                            <ext:Button Text="Tìm kiếm" Icon="Zoom" runat="server" ID="btnSearch">
                                <Listeners>
                                    <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <ColumnModel ID="ColumnModel1" runat="server">
                    <Columns>
                        <ext:RowNumbererColumn Locked="true" Header="STT" Width="30" />
                        <ext:DateColumn ColumnID="colNgayHieuLuc" Format="dd/MM/yyyy" Width="110" Header="Ngày hiệu lực"
                            Locked="true" DataIndex="NgayHieuLuc">
                        </ext:DateColumn>
                        <ext:Column ColumnID="colBHXHNhanVien" Width="120" Header="% BHXH Nhân viên" DataIndex="NVBYXH"
                            Align="Right">
                            <Renderer Fn="RenderMucDongBaoHiem" />
                        </ext:Column>
                        <ext:Column ColumnID="colBHYTNhanVien" Width="120" Header="% BHYT Nhân viên" DataIndex="NVBHYT"
                            Align="Right">
                            <Renderer Fn="RenderMucDongBaoHiem" />
                        </ext:Column>
                        <ext:Column ColumnID="colBHTNNhanVien" Width="120" Header="% BHTN Nhân viên" DataIndex="NVBHTN"
                            Align="Right">
                            <Renderer Fn="RenderMucDongBaoHiem" />
                        </ext:Column>
                        <ext:Column ColumnID="colBHXHDonVi" Width="120" Header="% BHXH Đơn vị" DataIndex="DVBHXH"
                            Align="Right">
                            <Renderer Fn="RenderMucDongBaoHiem" />
                        </ext:Column>
                        <ext:Column ColumnID="colBHYTDonVi" Width="120" Header="% BHYT Đơn vị" DataIndex="DVBHYT"
                            Align="Right">
                            <Renderer Fn="RenderMucDongBaoHiem" />
                        </ext:Column>
                        <ext:Column ColumnID="colBHTNDonVi" Width="120" Header="% BHTN Đơn vị" DataIndex="DVBHTN"
                            Align="Right">
                            <Renderer Fn="RenderMucDongBaoHiem" />
                        </ext:Column>
                        <ext:Column ColumnID="colMucTranBHXH" Width="110" Header="Mức trần BHXH" DataIndex="TranBHXH"
                            Align="Right">
                            <Renderer Fn="RenderVND" />
                        </ext:Column>
                        <%--<ext:Column ColumnID="colMucTranBHYT" Width="110" Header="Mức trần BHYT" DataIndex="TranBHYT"
                            Align="Right">
                            <Renderer Fn="RenderVND" />
                        </ext:Column>
                        <ext:Column ColumnID="colMucTranBHTN" Width="110" Header="Mức trần BHTN" DataIndex="TranBHTN"
                            Align="Right">
                            <Renderer Fn="RenderVND" />
                        </ext:Column>--%>
                        <ext:Column ColumnID="colMucSanBHXH" Width="110" Header="Mức sàn BHXH" DataIndex="SanBHXH"
                            Align="Right">
                            <Renderer Fn="RenderVND" />
                        </ext:Column>
                        <%--<ext:Column ColumnID="colMucSanBHYT" Width="110" Header="Mức sàn BHYT" DataIndex="SanBHYT"
                            Align="Right">
                            <Renderer Fn="RenderVND" />
                        </ext:Column>
                        <ext:Column ColumnID="colMucSanBHTN" Width="110" Header="Mức sàn BHTN" DataIndex="SanBHTN"
                            Align="Right">
                            <Renderer Fn="RenderVND" />
                        </ext:Column>--%>
                    </Columns>
                </ColumnModel>
                <View>
                    <ext:LockingGridView runat="server" ID="lock1">
                    </ext:LockingGridView>
                </View>
                <SelectionModel>
                    <ext:RowSelectionModel runat="server" ID="checkboxSelection">
                        <Listeners>
                            <RowSelect Handler="#{hdfRecordID}.setValue(#{checkboxSelection}.getSelected().id);#{btnEdit}.enable();#{btnDelete}.enable();" />
                            <RowDeselect Handler="#{hdfRecordID}.reset();#{btnEdit}.disable();#{btnDelete}.disable();" />
                        </Listeners>
                    </ext:RowSelectionModel>
                </SelectionModel>
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
                                    <ext:ListItem Text="110" />
                                </Items>
                                <SelectedItem Value="30" />
                                <Listeners>
                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:PagingToolbar>
                </BottomBar>
                <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                <Listeners>
                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                    <DblClick Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                </Listeners>
                <DirectEvents>
                    <DblClick OnEvent="btnEdit_Click">
                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                    </DblClick>
                </DirectEvents>
            </ext:GridPanel>
        </Center>
    </ext:BorderLayout>
</div>
