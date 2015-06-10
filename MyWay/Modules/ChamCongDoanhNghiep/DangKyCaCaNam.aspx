<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DangKyCaCaNam.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_ThietLapCaTheoThang" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../ChooseEmployee/ucChooseEmployee.ascx" TagName="ucChooseEmployee"
    TagPrefix="uc1" %>
<%@ Register Src="ucQuanLyBangPhanCa.ascx" TagName="ucQuanLyBangPhanCa" TagPrefix="uc2" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">

<head runat="server">
    <title></title>
    <style type="text/css">
        div#GridPanel1 .x-grid3-cell-inner, .x-grid3-hd-inner {
            white-space: nowrap !important;
        }

        .search-item {
            font: normal 11px tahoma, arial, helvetica, sans-serif;
            padding: 3px 10px 3px 10px;
            border: 1px solid #fff;
            border-bottom: 1px solid #eeeeee;
            white-space: normal;
            color: #555;
        }

            .search-item h3 {
                display: block;
                font: inherit;
                font-weight: normal;
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
    <script type="text/javascript" src="../../Resource/js/jquery-1.4.2.min.js"></script>
    <script type="text/javascript" src="Resource/jsDangKyCaNam.js"></script>
    <script type="text/javascript"  src="../../Resource/js/DDFTreeDonVi.js"></script>
    <script type="text/javascript">
        var changeGridpanelTitle = function (text) {
            $("div#GridPanel1 .x-panel-header-text").html(text);
        }

        var ResetNodeChecked = function (tree, stringallmadonvi) {
            if (stringallmadonvi.getValue().length != 0) {
                var str = stringallmadonvi.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        tree.getNodeById(str[i]).getUI().checkbox.checked = false;
                    }
                }
            }
        }

        var GetSelectedNodeDonVi = function (tree, stringallmadonvi, stringmadonvi) {
            if (stringallmadonvi.getValue().length != 0) {
                stringmadonvi.setValue('');
                stringmadonvi.reset();
                var str = stringallmadonvi.getValue().split(',');
                for (var i = 0; i < str.length; i++) {
                    if (str[i].length != 0) {
                        if (tree.getNodeById(str[i]).getUI().checkbox.checked == true) {
                            stringmadonvi.setValue(stringmadonvi.getValue() + "," + str[i]);
                        }
                    }
                }
                stringmadonvi.setValue(stringmadonvi.getValue().substring(1, stringmadonvi.getValue().length));
            }
        }

        var getTasks = function (tree) {
            var msg = [],
                    selNodes = tree.getChecked();
            msg.push("[");

            Ext.each(selNodes, function (node) {
                if (msg.length > 1) {
                    msg.push(",");
                }

                msg.push(node.text);
            });

            msg.push("]");

            return msg.join("");
        };
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM">
                <Listeners>
                    <DocumentReady Handler="wdChonBangPhanCa.show();" />
                </Listeners>
            </ext:ResourceManager>

            <ext:Menu runat="server" ID="RowContextMenu">
                <Items>
                    <ext:MenuItem runat="server" ID="mnuAddNew" Icon="UserAdd" Text="Thêm nhân viên">
                        <Listeners>
                            <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem runat="server" ID="mnuDelete" Icon="UserDelete" Text="Xoá nhân viên">
                        <DirectEvents>
                            <Click OnEvent="mnuXoaNhanVien_Click">
                                <Confirmation Title="Cảnh báo" ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không ?" />
                                <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuItem runat="server" ID="mnuMove" Icon="UserGo" Text="Chuyển nhân viên">
                        <Listeners>
                            <Click Handler="wdChuyenNhanVien.show();" />
                        </Listeners>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>


            <%--<ext:Menu ID="RowContextMenu" runat="server">
                <Items>
                    <ext:MenuItem ID="mnuAddNew" runat="server" Icon="Add" Text="Thêm mới">
                        <Listeners>
                            <Click Handler="#{wdAddWindow}.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuDelete" runat="server" Icon="Delete" Text="Xóa">
                        <Listeners>
                            <Click Handler="RemoveItemOnGrid(GridPanel1,Store1)" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuEdit" runat="server" Icon="Pencil" Text="Sửa">
                        <Listeners>
                            <Click Handler="#{btnCapNhat}.hide();#{btnSua}.show();#{Button2}.hide();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnEdit_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>--%>
            <uc2:ucQuanLyBangPhanCa ID="ucQuanLyBangPhanCa1" runat="server" ThangHayNam="Nam"/>
            <uc1:ucChooseEmployee ID="ucChooseEmployee1" runat="server" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfIdBangPhanCa" Text="-1" />
            <ext:Hidden runat="server" ID="hdfStringAllMaDonVi" />
            <ext:Hidden runat="server" ID="hdfStringMaDonVi" />
            <ext:Store runat="server" ID="cbChonCaStore" AutoLoad="false" OnRefreshData="cbChonCaStore_OnRefreshData">
                <Reader>
                    <ext:JsonReader IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="TenCa" />
                            <ext:RecordField Name="GioVao" />
                            <ext:RecordField Name="GioRa" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Store runat="server" ID="cbChonLaiBangPhanCaStore" OnRefreshData="cbChonLaiBangPhanCaStore_OnRefreshData"
                AutoLoad="false">
                <Reader>
                    <ext:JsonReader IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="TenBangPhanCa" />
                            <ext:RecordField Name="ID" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Window runat="server" ID="wdChuyenNhanVien" Constrain="true" Resizable="false"
                Layout="RowLayout" Padding="6" AutoHeight="true" Width="480" Hidden="true" Modal="true"
                Title="Chuyển nhân viên sang bảng phân ca khác">
                <Items>
                    <ext:CompositeField ID="CompositeField6" runat="server" AnchorHorizontal="100%">
                        <Items>
                            <ext:DisplayField ID="DisplayField18" runat="server" Text="Chọn năm" />
                            <ext:SpinnerField runat="server" ID="SpinnerField1" Width="60">
                                <Listeners>
                                    <Spin Handler="cbChonBangPhanCaStore.reload();cbChonBangPhanCa.reset();" />
                                </Listeners>
                            </ext:SpinnerField>
                            <ext:DisplayField ID="DisplayField19" runat="server" Text="Bảng phân ca" />
                            <ext:ComboBox runat="server" Width="240" ID="cbChonBangPhanCa"
                                DisplayField="TenBangPhanCa" ValueField="ID" Editable="false" ItemSelector="div.search-item">
                                <Store>
                                    <ext:Store runat="server" ID="cbChonBangPhanCaStore" OnRefreshData="cbChonBangPhanCaStore_OnRefreshData"
                                        AutoLoad="false">
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID">
                                                <Fields>
                                                    <ext:RecordField Name="TenBangPhanCa" />
                                                    <ext:RecordField Name="ID" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <Template ID="Template8" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenBangPhanCa}</h3> 
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Listeners>
                                    <Expand Handler="if(cbChonBangPhanCa.store.getCount()==0){
                                                    cbChonBangPhanCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                </Items>
                <Listeners>
                    <BeforeShow Handler="SpinnerField1.setValue(new Date().getFullYear());" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" ID="btnChuyenNhanVien" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="if(cbChonBangPhanCa.getValue()==''){
                                                Ext.Msg.alert('Thông báo','Bạn chưa chọn bảng phân ca');
                                                return false;
                                            }      ChuyenNhanVien(GridPanel1,Store1); wdChuyenNhanVien.hide();" />
                        </Listeners>
                        <%-- <DirectEvents>
                            <Click OnEvent="btnChuyenNhanVien_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>--%>
                    </ext:Button>
                    <ext:Button ID="Button2" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdChuyenNhanVien.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" ID="wdChonBangPhanCa" Constrain="true" Resizable="false"
                Layout="RowLayout" Padding="6" AutoHeight="true" Width="480" Hidden="true" Modal="true"
                Title="Chọn bảng phân ca">
                <Items>
                    <ext:CompositeField runat="server" AnchorHorizontal="100%">
                        <Items>
                            <ext:DisplayField runat="server" Text="Chọn năm" />
                            <ext:SpinnerField runat="server" ID="spfYear" Width="60">
                                <Listeners>
                                    <Spin Handler="cbChonLaiBangPhanCaStore.reload();cbChonLaiBangPhanCa.reset();" />
                                </Listeners>
                            </ext:SpinnerField>
                            <ext:DisplayField runat="server" Text="Bảng phân ca" />
                            <ext:ComboBox runat="server" Width="240" ID="cbChonLaiBangPhanCa" StoreID="cbChonLaiBangPhanCaStore"
                                DisplayField="TenBangPhanCa" ValueField="ID" Editable="false" ItemSelector="div.search-item">
                                <Template ID="Template7" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenBangPhanCa}</h3> 
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Listeners>
                                    <Select Handler="hdfIdBangPhanCa.setValue(cbChonLaiBangPhanCa.getValue());
                                         if(chkTaiDuLieu.checked){
                                            txtSearchKey.reset();#{PagingToolbar1}.pageIndex = 0; 
                                            #{PagingToolbar1}.doLoad();Store1.reload();
                                         }" />
                                    <Expand Handler="if(cbChonLaiBangPhanCa.store.getCount()==0){
                                                    cbChonLaiBangPhanCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:Checkbox runat="server" ID="chkTaiDuLieu" BoxLabel="Tải dữ liệu ngay sau khi chọn ca">
                        <Listeners>
                            <Check Handler="if(chkTaiDuLieu.checked){
                                                txtSearchKey.reset();#{PagingToolbar1}.pageIndex = 0; 
                                                #{PagingToolbar1}.doLoad();Store1.reload();
                                                changeGridpanelTitle(cbChonLaiBangPhanCa.getText());
                                            }" />
                        </Listeners>
                    </ext:Checkbox>
                </Items>
                <Listeners>
                    <Show Handler="spfYear.setValue(new Date().getFullYear());" />
                </Listeners>
                <Buttons>
                    <ext:Button runat="server" Text="Tải dữ liệu" Icon="Database">
                        <Listeners>
                            <Click Handler="if(cbChonLaiBangPhanCa.getValue()=='')
                                            {
                                                 Ext.Msg.alert('Thông báo','Bạn chưa chọn bảng phân ca nào');
                                            }
                                            else
                                            {
                                                if(chkTaiDuLieu.checked)
                                                {
                                                    wdChonBangPhanCa.hide();
                                                }else
                                                {
                                                    txtSearchKey.reset();#{PagingToolbar1}.pageIndex = 0; 
                                                    #{PagingToolbar1}.doLoad();Store1.reload();wdChonBangPhanCa.hide();
                                                }
                                                changeGridpanelTitle(cbChonLaiBangPhanCa.getText());
                                            }" />
                        </Listeners>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdChonBangPhanCa.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" ID="wdHuyBangPhanCa" Constrain="true" Layout="RowLayout"
                Icon="DateDelete" Padding="6" AutoHeight="true" Width="480" Hidden="true" Modal="true"
                Title="Hủy phân ca">
                <Items>
                    <ext:CheckboxGroup ID="CheckboxGroup1" runat="server">
                        <Items>
                            <ext:Checkbox ID="chkThang1" runat="server" BoxLabel="Tháng 1">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang2" runat="server" BoxLabel="Tháng 2">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang3" runat="server" BoxLabel="Tháng 3">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang4" runat="server" BoxLabel="Tháng 4">
                            </ext:Checkbox>
                        </Items>
                    </ext:CheckboxGroup>
                    <ext:CheckboxGroup ID="CheckboxGroup2" runat="server">
                        <Items>
                            <ext:Checkbox ID="chkThang5" runat="server" BoxLabel="Tháng 5">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang6" runat="server" BoxLabel="Tháng 6">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang7" runat="server" BoxLabel="Tháng 7">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang8" runat="server" BoxLabel="Tháng 8">
                            </ext:Checkbox>
                        </Items>
                    </ext:CheckboxGroup>
                    <ext:CheckboxGroup ID="CheckboxGroup3" runat="server">
                        <Items>
                            <ext:Checkbox ID="chkThang9" runat="server" BoxLabel="Tháng 9">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang10" runat="server" BoxLabel="Tháng 10">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang11" runat="server" BoxLabel="Tháng 11">
                            </ext:Checkbox>
                            <ext:Checkbox ID="chkThang12" runat="server" BoxLabel="Tháng 12">
                            </ext:Checkbox>
                        </Items>
                    </ext:CheckboxGroup>
                </Items>
                <Listeners>
                    <BeforeShow Handler="getCheckedMonths();" />
                    <Hide Handler="resetCheckedMonths();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnHuyBangPhanCa" runat="server" Icon="Accept" Text="Đồng ý">
                        <DirectEvents>
                            <Click OnEvent="btnHuyBangPhanCa_Click" Before="Store1.reload();">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Icon="Decline" Text="Đóng lại">
                        <Listeners>
                            <Click Handler="wdHuyBangPhanCa.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" ID="wdPhanCaNhanh" Icon="Clock" Constrain="true" Layout="RowLayout"
                Padding="8" AutoHeight="true" Width="540" Hidden="true" Modal="true" Title="Thiết lập ca nhanh">
                <Items>
                    <ext:CompositeField Height="30" runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayField1" runat="server" Text="Từ tháng" />
                            <ext:ComboBox runat="server" Editable="false" Width="90" ID="cbTuThang1">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbDenThang1.enable();CheckRangeValide(cbTuThang1,cbDenThang1,cbChonCa1);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); cbDenThang1.disable();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField2" runat="server" Text="Đến tháng" />
                            <ext:ComboBox runat="server" Disabled="true" Width="90" Editable="false" ID="cbDenThang1">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbChonCa1.enable();CheckRangeValide(cbTuThang1,cbDenThang1,cbChonCa1);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); cbChonCa1.disable();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField runat="server" Text="Chọn ca" />
                            <ext:ComboBox runat="server" StoreID="cbChonCaStore" ID="cbChonCa1" Disabled="true"
                                DisplayField="TenCa" ValueField="ID" Editable="false" Width="150" ItemSelector="div.search-item">
                                <Template ID="Template1" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    <Expand Handler="if(cbChonCa1.store.getCount()==0){
                                                    cbChonCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="CompositeField1" Height="30" runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayField3" runat="server" Text="Từ tháng" />
                            <ext:ComboBox runat="server" Editable="false" Width="90" ID="cbTuThang2">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbDenThang2.enable();CheckRangeValide(cbTuThang2,cbDenThang2,cbChonCa2); CheckRangeValideCa(cbDenThang1,cbTuThang2,cbChonCa2);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbDenThang2.disable(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField4" runat="server" Text="Đến tháng" />
                            <ext:ComboBox runat="server" Disabled="true" Width="90" Editable="false" ID="cbDenThang2">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbChonCa2.enable();CheckRangeValide(cbTuThang2,cbDenThang2,cbChonCa2);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbChonCa2.disable(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField5" runat="server" Text="Chọn ca" />
                            <ext:ComboBox runat="server" StoreID="cbChonCaStore" Disabled="true" ID="cbChonCa2"
                                DisplayField="TenCa" ValueField="ID" Editable="false" Width="150" ItemSelector="div.search-item">
                                <Template ID="Template2" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    <Expand Handler="if(cbChonCa2.store.getCount()==0){
                                                    cbChonCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="CompositeField2" Height="30" runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayField6" runat="server" Text="Từ tháng" />
                            <ext:ComboBox runat="server" Editable="false" Width="90" ID="cbTuThang3">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbDenThang3.enable();CheckRangeValide(cbTuThang3,cbDenThang3,cbChonCa3);CheckRangeValideCa(cbDenThang2,cbTuThang3,cbChonCa3);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbDenThang3.disable(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField7" runat="server" Text="Đến tháng" />
                            <ext:ComboBox runat="server" Disabled="true" Width="90" Editable="false" ID="cbDenThang3">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbChonCa3.enable();CheckRangeValide(cbTuThang3,cbDenThang3,cbChonCa3);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); cbChonCa3.disable();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField8" runat="server" Text="Chọn ca" />
                            <ext:ComboBox runat="server" StoreID="cbChonCaStore" ID="cbChonCa3" Disabled="true"
                                DisplayField="TenCa" ValueField="ID" Editable="false" Width="150" ItemSelector="div.search-item">
                                <Template ID="Template3" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbDenThang2.disable(); }" />
                                    <Expand Handler="if(cbChonCa3.store.getCount()==0){
                                                    cbChonCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="CompositeField3" Height="30" runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayField9" runat="server" Text="Từ tháng" />
                            <ext:ComboBox runat="server" Editable="false" Width="90" ID="cbTuThang4">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbDenThang4.enable();CheckRangeValide(cbTuThang4,cbDenThang4,cbChonCa4);CheckRangeValideCa(cbDenThang3,cbTuThang4,cbChonCa4);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbDenThang4.disable(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField10" runat="server" Text="Đến tháng" />
                            <ext:ComboBox runat="server" Width="90" Disabled="true" Editable="false" ID="cbDenThang4">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbChonCa4.enable();CheckRangeValide(cbTuThang4,cbDenThang4,cbChonCa4);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); cbChonCa4.disable();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField11" runat="server" Text="Chọn ca" />
                            <ext:ComboBox runat="server" StoreID="cbChonCaStore" ID="cbChonCa4" Disabled="true"
                                DisplayField="TenCa" ValueField="ID" Editable="false" Width="150" ItemSelector="div.search-item">
                                <Template ID="Template4" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    <Expand Handler="if(cbChonCa4.store.getCount()==0){
                                                    cbChonCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="CompositeField4" Height="30" runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayField12" runat="server" Text="Từ tháng" />
                            <ext:ComboBox runat="server" Editable="false" Width="90" ID="cbTuThang5">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbDenThang5.enable();CheckRangeValide(cbTuThang5,cbDenThang5,cbChonCa5);CheckRangeValideCa(cbDenThang4,cbTuThang5,cbChonCa5);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); cbDenThang5.disable();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField13" runat="server" Text="Đến tháng" />
                            <ext:ComboBox runat="server" Disabled="true" Width="90" Editable="false" ID="cbDenThang5">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbChonCa5.enable();CheckRangeValide(cbTuThang5,cbDenThang5,cbChonCa5);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbChonCa5.disable(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField14" runat="server" Text="Chọn ca" />
                            <ext:ComboBox runat="server" StoreID="cbChonCaStore" ID="cbChonCa5" Disabled="true"
                                DisplayField="TenCa" ValueField="ID" Editable="false" Width="150" ItemSelector="div.search-item">
                                <Template ID="Template5" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    <Expand Handler="if(cbChonCa5.store.getCount()==0){
                                                    cbChonCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:CompositeField ID="CompositeField5" Height="30" runat="server">
                        <Items>
                            <ext:DisplayField ID="DisplayField15" runat="server" Text="Từ tháng" />
                            <ext:ComboBox runat="server" Editable="false" Width="90" ID="cbTuThang6">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbDenThang6.enable();CheckRangeValide(cbTuThang6,cbDenThang6,cbChonCa6);CheckRangeValideCa(cbDenThang5,cbTuThang6,cbChonCa6);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();cbDenThang6.disable(); }" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField16" runat="server" Text="Đến tháng" />
                            <ext:ComboBox runat="server" Width="90" Disabled="true" Editable="false" ID="cbDenThang6">
                                <Items>
                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();cbChonCa6.enable();CheckRangeValide(cbTuThang6,cbDenThang6,cbChonCa6);" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); cbChonCa6.disable();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:DisplayField ID="DisplayField17" runat="server" Text="Chọn ca" />
                            <ext:ComboBox runat="server" StoreID="cbChonCaStore" ID="cbChonCa6" Disabled="true"
                                DisplayField="TenCa" ValueField="ID" Editable="false" Width="150" ItemSelector="div.search-item">
                                <Template ID="Template6" runat="server">
                                    <Html>
                                        <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                    </Html>
                                </Template>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                    <Expand Handler="if(cbChonCa6.store.getCount()==0){
                                                    cbChonCaStore.reload();
                                                 }" />
                                </Listeners>
                            </ext:ComboBox>
                        </Items>
                    </ext:CompositeField>
                    <ext:RadioGroup ColumnsNumber="1" runat="server">
                        <Items>
                            <ext:Radio ID="chkChiApDungChoNhanVienDuocChon" runat="server" BoxLabel="Chỉ áp dụng cho nhân viên được chọn">
                                <Listeners>
                                    <Check Handler="if(chkChiApDungChoNhanVienDuocChon.checked==true && GridPanel1.getSelectionModel().getCount() == 0){
                                                   alert('Bạn chưa chọn nhân viên nào');
                                                   chkChiApDungChoNhanVienDuocChon.setValue(false);
                                               }" />
                                </Listeners>
                            </ext:Radio>
                            <ext:Radio ID="chkAll" runat="server" BoxLabel="Áp dụng cho tất cả nhân viên trong bảng phân ca">
                            </ext:Radio>
                        </Items>
                    </ext:RadioGroup>
                </Items>
                <Listeners>
                    <Hide Handler="resetFormPhanCaNhanh();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnTienHanhPhanCaNhanh" runat="server" Text="Tiến hành phân ca" Icon="PlayBlue">
                        <Listeners>
                            <Click Handler="return validateFormPhanCaNhanh();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnTienHanhPhanCaNhanh_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button8" runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdPhanCaNhanh.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" ID="wdPhanCaTuDong" Constrain="true" Layout="FormLayout"
                Icon="Computer" Padding="6" AutoHeight="true" Width="500" Hidden="true" Modal="true"
                Title="Thiết lập ca tự động">
                <Items>
                    <ext:FieldSet runat="server" Title="Thông tin ca" AnchorHorizontal="100%" AutoHeight="true">
                        <Items>
                            <ext:MultiCombo runat="server" ID="cbChonCaTuDong" AnchorHorizontal="100%" StoreID="cbChonCaStore"
                                DisplayField="TenCa" ValueField="ID" FieldLabel="Chọn ca">
                                <%--<Template ID="Template7" runat="server">
                                <Html>
                                    <tpl for=".">
						                  <div class="search-item">
							                 <h3>{TenCa}</h3>
							                 Từ {GioVao} Đến {GioRa}
						                  </div>
					                   </tpl>
                                </Html>
                            </Template>--%>
                                <Listeners>
                                    <Expand Handler="if(cbChonCa.store.getCount()==0){cbChonCaStore.reload();}" />
                                </Listeners>
                            </ext:MultiCombo>
                            <ext:Container Height="30" runat="server" AnchorHorizontal="100%" Layout="ColumnLayout">
                                <Items>
                                    <ext:Container runat="server" ColumnWidth="0.5">
                                        <Items>
                                            <ext:ComboBox ID="cbFromMonth" Width="210" runat="server" FieldLabel="Từ tháng" Editable="false">
                                                <Items>
                                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                                </Items>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:Container>
                                    <ext:Container ID="Container3" runat="server" ColumnWidth="0.5">
                                        <Items>
                                            <ext:ComboBox ID="cbToMonth" Width="225" runat="server" FieldLabel="Đến tháng" Editable="false">
                                                <Items>
                                                    <ext:ListItem Text="Tháng 1" Value="1" />
                                                    <ext:ListItem Text="Tháng 2" Value="2" />
                                                    <ext:ListItem Text="Tháng 3" Value="3" />
                                                    <ext:ListItem Text="Tháng 4" Value="4" />
                                                    <ext:ListItem Text="Tháng 5" Value="5" />
                                                    <ext:ListItem Text="Tháng 6" Value="6" />
                                                    <ext:ListItem Text="Tháng 7" Value="7" />
                                                    <ext:ListItem Text="Tháng 8" Value="8" />
                                                    <ext:ListItem Text="Tháng 9" Value="9" />
                                                    <ext:ListItem Text="Tháng 10" Value="10" />
                                                    <ext:ListItem Text="Tháng 11" Value="11" />
                                                    <ext:ListItem Text="Tháng 12" Value="12" />
                                                </Items>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:Container>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FieldSet>
                    <ext:FieldSet ID="FieldSet1" runat="server" Layout="RowLayout" Title="Luân chuyển ca"
                        AnchorHorizontal="100%" AutoHeight="true">
                        <Items>
                            <ext:RadioGroup runat="server" ColumnsNumber="2" AnchorHorizontal="100%">
                                <Items>
                                    <ext:Radio runat="server" ID="rdKhongLuanChuyen" BoxLabel="Không luân chuyển ca"
                                        Note="(Áp dụng 1 ca 1 người / 1 năm)">
                                    </ext:Radio>
                                    <ext:Radio ID="rdCoLuanChuyenCa" runat="server" BoxLabel="Có luân chuyển ca">
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                            <ext:CompositeField runat="server">
                                <Items>
                                    <ext:DisplayField runat="server" Text="Số tháng luân chuyển ca 1 lần" />
                                    <ext:SpinnerField ID="spnSoThangLuanChuyenCa" runat="server" Text="3" />
                                </Items>
                            </ext:CompositeField>
                        </Items>
                    </ext:FieldSet>
                    <ext:DisplayField runat="server" FieldLabel="Chú ý" Text="Tính năng này sẽ phân ca tự động cho tất cả các cán bộ công nhân viên trong bảng phân ca. 
                                                                          Các thông tin phân ca cũ sẽ bị hủy và không thể lấy lại được." />
                </Items>
                <Listeners>
                    <Hide Handler="resetFormThietLapCaTuDong();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnPhanCaTuDong" runat="server" Text="Tiến hành phân ca" Icon="PlayBlue">
                        <Listeners>
                            <Click Handler="return validateFormThietLapCaTuDong();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnPhanCaTuDong_Click">
                                <EventMask ShowMask="true" Msg="Đang xử lý dữ liệu..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdPhanCaTuDong.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window Modal="true" Hidden="true" runat="server" ID="wdTaoBangPhanCa" Constrain="true"
                Title="Tạo mới bảng phân ca" Icon="DateAdd" Width="500" Resizable="false" AutoHeight="true">
                <Items>
                    <ext:FormPanel ID="Panel1" Layout="FormLayout" runat="server" Border="false" Padding="6"
                        Height="300">
                        <Items>
                            <ext:Container ID="Container1" Layout="FormLayout" LabelAlign="Top" Height="300"
                                runat="server">
                                <Items>
                                    <ext:DropDownField runat="server" Editable="false" Note="Bạn phải chọn một đơn vị hoặc bộ phận. Không được phép để trống !"
                                        ID="ddfDonVi" AnchorHorizontal="100%" AllowBlank="false" BlankText="Bạn phải chọn đơn vị hoặc bộ phận sử dụng"
                                        FieldLabel="Chọn bộ phận">
                                        <Component>
                                            <ext:TreePanel ID="TreePanelDonVi" runat="server" Header="false" Icon="Accept" Height="300"
                                                Shadow="None" UseArrows="true" AutoScroll="true" Animate="true" EnableDD="true"
                                                ContainerScroll="true" RootVisible="false">
                                                <Root>
                                                </Root>
                                                <Buttons>
                                                    <ext:Button ID="Button6" runat="server" Text="Đóng lại">
                                                        <Listeners>
                                                            <Click Handler="#{ddfDonVi}.collapse();" />
                                                        </Listeners>
                                                    </ext:Button>
                                                </Buttons>
                                            </ext:TreePanel>
                                        </Component>
                                        <Listeners>
                                            <Expand Handler="this.component.getRootNode().expand(true);" Single="false" Delay="10" />
                                        </Listeners>
                                    </ext:DropDownField>
                                    <ext:Container ID="Containerm" Height="57" runat="server" Layout="ColumnLayout">
                                        <Items>
                                            <ext:Container ID="Container2" runat="server" ColumnWidth="0.5">
                                                <Items>
                                                    <ext:NumberField FieldLabel="Nhập năm" ID="txtYear" LabelAlign="Top" AllowBlank="false"
                                                        AllowDecimals="false" AllowNegative="false" BlankText="Bạn phải nhập năm" runat="server"
                                                        Width="225">
                                                        <Listeners>
                                                            <Blur Handler="ChangeTitle();" />
                                                        </Listeners>
                                                    </ext:NumberField>
                                                </Items>
                                            </ext:Container>
                                            <ext:Container runat="server" ColumnWidth="0.5">
                                                <Items>
                                                    <ext:ComboBox runat="server" ID="cbChonCa" Note="Thiết lập ca nhanh từ tháng 1 đến tháng 12" StoreID="cbChonCaStore" DisplayField="TenCa"
                                                        ValueField="ID" FieldLabel="Chọn ca (Dùng để thiết lập nhanh)" Editable="false" Width="235">
                                                        <Triggers>
                                                            <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                        </Triggers>
                                                        <Listeners>
                                                            <Expand Handler="if(cbChonCa.store.getCount()==0){cbChonCaStore.reload();}" />
                                                            <Select Handler="this.triggers[0].show();" />
                                                            <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                            <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); }" />
                                                        </Listeners>
                                                    </ext:ComboBox>
                                                </Items>
                                            </ext:Container>
                                        </Items>
                                    </ext:Container>
                                    <ext:TextField ID="txtTenBangPhanCa" MaxLength="500" BlankText="Bạn bắt buộc phải nhập bảng chấm công"
                                        Note="Tiêu đề bảng chấm công được sinh tự động, hoặc bạn có thể thay đổi tùy ý"
                                        Text="" AllowBlank="false" AnchorHorizontal="100%" ColumnWidth="1.0" FieldLabel="Tiêu đề bảng chấm công"
                                        runat="server">
                                        <%--    <Listeners>
                                            <Focus Handler="#{txtTenBangPhanCa}.setValue('Bảng phân ca năm '+#{txtYear}.getValue()+' tại '+ #{ddfBoPhan}.getValue()); #{txtTenBangPhanCa}.setValue(#{txtTenBangPhanCa}.getValue().substring(1, str.length - 2))" />
                                        </Listeners>--%>
                                    </ext:TextField>
                                </Items>
                            </ext:Container>
                        </Items>
                    </ext:FormPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="ChangeTitle();txtYear.setValue(new Date().getFullYear());" />
                    <Hide Handler="resetForm();" />
                </Listeners>
                <Buttons>
                    <ext:Button ID="btnTaoBangPhanCa" runat="server" Icon="Accept" Text="Đồng ý">
                        <Listeners>
                            <Click Handler="return ValidateTaoMoiBangPhanCa();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnTaoBangPhanCa_Click">
                                <EventMask ShowMask="true" Msg="Đang tạo bảng phân ca..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button ID="Button7" runat="server" Icon="Decline" Text="Đóng lại">
                        <Listeners>
                            <Click Handler="#{wdTaoBangPhanCa}.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" runat="server" Title="Chưa có thông tin bảng phân ca" StripeRows="true"
                                Border="false">
                                <Store>
                                    <ext:Store ID="Store1" AutoLoad="false" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Json="true" Method="GET" Url="Handler/BangPhanCaNam.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={30}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="searchKey" Value="txtSearchKey.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="maBangPhanCa" Value="hdfIdBangPhanCa.getValue()" Mode="Raw" />
                                            <ext:Parameter Name="maDonVi" Value="hdfMaDonVi.getValue()" Mode="Raw" />
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader IDProperty="ID" Root="Data" TotalProperty="TotalRecords">
                                                <Fields>
                                                    <ext:RecordField Name="HoTen" />
                                                    <ext:RecordField Name="MaCB" />
                                                    <ext:RecordField Name="BoPhan" />
                                                    <ext:RecordField Name="ID" />
                                                    <ext:RecordField Name="Thang1" />
                                                    <ext:RecordField Name="Thang2" />
                                                    <ext:RecordField Name="Thang3" />
                                                    <ext:RecordField Name="Thang4" />
                                                    <ext:RecordField Name="Thang5" />
                                                    <ext:RecordField Name="Thang6" />
                                                    <ext:RecordField Name="Thang7" />
                                                    <ext:RecordField Name="Thang8" />
                                                    <ext:RecordField Name="Thang9" />
                                                    <ext:RecordField Name="Thang10" />
                                                    <ext:RecordField Name="Thang11" />
                                                    <ext:RecordField Name="Thang12" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <TopBar>
                                    <ext:Toolbar runat="server" ID="tb">
                                        <Items>
                                            <ext:Button ID="Button4" runat="server" Text="Bảng phân ca" Icon="Clock">
                                                <Menu>
                                                    <ext:Menu runat="server" ID="menuBangDangKyCa">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="Tạo bảng phân ca">
                                                                <Listeners>
                                                                    <Click Handler="#{wdTaoBangPhanCa}.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem2" runat="server" Text="Chọn bảng phân ca">
                                                                <Listeners>
                                                                    <Click Handler="wdChonBangPhanCa.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="MenuItem3" runat="server" Text="Quản lý bảng phân ca">
                                                                <Listeners>
                                                                    <Click Handler="ucQuanLyBangPhanCa1_wdQuanLyBangPhanCa.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="Button5" runat="server" Text="Quản lý nhân viên" Icon="User">
                                                <Menu>
                                                    <ext:Menu runat="server" ID="mnuQuanLyNhanVien">
                                                        <Items>
                                                            <ext:MenuItem ID="MenuItem1" runat="server" Text="Thêm nhân viên" Icon="UserAdd">
                                                                <Listeners>
                                                                    <Click Handler="ucChooseEmployee1_wdChooseUser.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem runat="server" Disabled="true" ID="mnuXoaNhanVien" Text="Xóa nhân viên"
                                                                Icon="UserCross">
                                                                <DirectEvents>
                                                                    <Click OnEvent="mnuXoaNhanVien_Click">
                                                                        <Confirmation Title="Cảnh báo" ConfirmRequest="true" Message="Bạn có chắc chắn muốn xóa không ?" />
                                                                        <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem runat="server" Disabled="true" ID="mnuChuyenNhanVien" Text="Chuyển nhân viên"
                                                                Icon="UserGo">
                                                                <Listeners>
                                                                    <Click Handler="wdChuyenNhanVien.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="Button1" runat="server" Text="Phân ca" Icon="Clock">
                                                <Menu>
                                                    <ext:Menu runat="server">
                                                        <Items>
                                                            <ext:MenuItem runat="server" Text="Thiết lập ca nhanh">
                                                                <Listeners>
                                                                    <Click Handler="wdPhanCaNhanh.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem runat="server" Text="Thiết lập ca tự động">
                                                                <Listeners>
                                                                    <Click Handler="wdPhanCaTuDong.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem ID="mnuHuyPhanCa" runat="server" Disabled="true" Text="Hủy phân ca">
                                                                <Listeners>
                                                                    <Click Handler="wdHuyBangPhanCa.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:Button ID="btnUpdate" runat="server" Text="Báo cáo" Icon="Printer">
                                            </ext:Button>
                                            <ext:ToolbarFill runat="server" ID="tbf" />
                                            <ext:TextField ID="txtSearchKey" EnableKeyEvents="true" runat="server" Width="220"
                                                EmptyText="Nhập mã, họ tên nhân viên...">
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                </Listeners>
                                            </ext:TextField>
                                            <ext:Button ID="Button3" runat="server" Text="Tìm kiếm" Icon="Zoom">
                                                <Listeners>
                                                    <Click Handler="#{PagingToolbar1}.pageIndex = 0; #{PagingToolbar1}.doLoad();Store1.reload();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <View>
                                    <ext:LockingGridView runat="server" ID="lkv">
                                    </ext:LockingGridView>
                                </View>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Locked="true" Width="35" />
                                        <ext:Column ColumnID="Company" Header="Mã NV" Locked="true" Width="70" DataIndex="MaCB" />
                                        <ext:Column ColumnID="Company" Header="Họ tên" Locked="true" Width="130" DataIndex="HoTen" />
                                        <ext:Column ColumnID="department" Header="Bộ phận" Locked="true" Width="150" DataIndex="BoPhan" />
                                        <ext:Column Width="70" Header="Tháng 1" DataIndex="Thang1">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 2" DataIndex="Thang2">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 3" DataIndex="Thang3">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 4" DataIndex="Thang4">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 5" DataIndex="Thang5">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 6" DataIndex="Thang6">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 7" DataIndex="Thang7">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 8" DataIndex="Thang8">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 9" DataIndex="Thang9">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 10" DataIndex="Thang10">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 11" DataIndex="Thang11">
                                        </ext:Column>
                                        <ext:Column Width="70" Header="Tháng 12" DataIndex="Thang12">
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="mnuXoaNhanVien.enable();mnuHuyPhanCa.enable();mnuChuyenNhanVien.enable();" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="30">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Cỡ trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBox1" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="10" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="30" />
                                                </Items>
                                                <SelectedItem Value="30" />
                                                <Listeners>
                                                    <Select Handler="#{PagingToolbar1}.pageSize = parseInt(this.getValue()); #{PagingToolbar1}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
                                    </ext:PagingToolbar>
                                </BottomBar>
                                <Listeners>
                                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                </Listeners>
                            </ext:GridPanel>
                        </Center>
                    </ext:BorderLayout>
                </Items>
            </ext:Viewport>
        </div>
    </form>
</body>
</html>
