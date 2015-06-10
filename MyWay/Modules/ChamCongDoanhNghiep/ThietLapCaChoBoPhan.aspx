<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThietLapCaChoBoPhan.aspx.cs"
    Inherits="Modules_ChamCongDoanhNghiep_ThietLapCaChoBoPhan" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Resource/DangKyCaTrongThang.css" rel="stylesheet" type="text/css" />
    <script type="text/javascript">
        //        function nodeLoad(node) {
        //            Ext.net.DirectMethods.NodeLoad(node.id, {
        //                success: function (result) {
        //                    var data = eval("(" + result + ")");
        //                    node.loadNodes(data);
        //                },
        //                failure: function (errorMsg) {
        //                    Ext.Msg.alert('Failure', errorMsg);
        //                }
        //            });
        //        }
        var setValuewdChinhSuaCaLamViec = function () {
            var data = RowSelectionModel1.getSelected().data;
            if (data != null) {
                cbCaLamViec.setValue(data.MaCa);
                cbCaThu7.setValue(data.MaCaThu7);
                cbCaChuNhat.setValue(data.MaCaChuNhat);
                txtSoNgayCongChuan.setValue(data.SoNgayCongChuan);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <ext:ResourceManager runat="server" ID="RM">
            <Listeners>
                <DocumentReady Handler="cbCaLamViecStore.reload();grpDanhSachDonViStore.reload();" />
            </Listeners>
        </ext:ResourceManager>
        <ext:Window runat="server" Title="Chỉnh sửa ca làm việc" Padding="6" Icon="Pencil"
            Modal="true" Width="450" AutoHeight="true" Constrain="true" ID="wdChinhSuaCaLamViec"
            Hidden="true" Layout="FormLayout">
            <Items>
                <ext:ComboBox runat="server" DisplayField="TenCa" ItemSelector="tr.list-item" ValueField="MaCa"
                    ID="cbCaLamViec" FieldLabel="Ngày thường<span style='color:red;'>*</span>" Editable="false"
                    AnchorHorizontal="100%" CtCls="requiredData">
                    <Store>
                        <ext:Store AutoLoad="false" runat="server" OnRefreshData="cbCaLamViecStore_OnRefreshData"
                            ID="cbCaLamViecStore">
                            <Reader>
                                <ext:JsonReader IDProperty="MaCa">
                                    <Fields>
                                        <ext:RecordField Name="MaCa" />
                                        <ext:RecordField Name="TenCa" />
                                        <ext:RecordField Name="GioVao" />
                                        <ext:RecordField Name="GioRa" />
                                    </Fields>
                                </ext:JsonReader>
                            </Reader>
                        </ext:Store>
                    </Store>
                    <Template runat="server">
                        <Html>
                            <tpl for=".">
						                        <tpl if="[xindex] == 1">
							                        <table class="cbStates-list">
								                        <tr>
									                        <th style="width:70px;">Mã ca</th>
									                        <th>Tên ca</th>
                                                            <th>Giờ vào</th>
                                                            <th>Giờ ra</th>
								                        </tr>
						                        </tpl>
						                        <tr class="list-item">
							                        <td style='padding:3px 0px;'>{MaCa}</td>
							                        <td>{TenCa}</td>
							                        <td>{GioVao}</td>
							                        <td>{GioRa}</td>
						                        </tr>
						                        <tpl if="[xcount-xindex]==0">
							                        </table>
						                        </tpl>
					                        </tpl>
                        </Html>
                    </Template>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();}" />
                        <Expand Handler="if(cbCaLamViecStore.getCount()==0){cbCaLamViecStore.reload();}" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox runat="server" DisplayField="TenCa" ItemSelector="tr.list-item" ValueField="MaCa"
                    ID="cbCaThu7" FieldLabel="Thứ 7" Editable="false" StoreID="cbCaLamViecStore"
                    AnchorHorizontal="100%">
                    <Template ID="Template1" runat="server">
                        <Html>
                            <tpl for=".">
						                        <tpl if="[xindex] == 1">
							                        <table class="cbStates-list">
								                        <tr>
									                        <th style="width:70px;">Mã ca</th>
									                        <th>Tên ca</th>
                                                            <th>Giờ vào</th>
                                                            <th>Giờ ra</th>
								                        </tr>
						                        </tpl>
						                        <tr class="list-item">
							                        <td style='padding:3px 0px;'>{MaCa}</td>
							                        <td>{TenCa}</td>
							                        <td>{GioVao}</td>
							                        <td>{GioRa}</td>
						                        </tr>
						                        <tpl if="[xcount-xindex]==0">
							                        </table>
						                        </tpl>
					                        </tpl>
                        </Html>
                    </Template>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();}" />
                        <Expand Handler="if(cbCaLamViecStore.getCount()==0){cbCaLamViecStore.reload();}" />
                    </Listeners>
                </ext:ComboBox>
                <ext:ComboBox runat="server" DisplayField="TenCa" ItemSelector="tr.list-item" ValueField="MaCa"
                    ID="cbCaChuNhat" FieldLabel="Chủ nhật" Editable="false" StoreID="cbCaLamViecStore"
                    AnchorHorizontal="100%">
                    <Template ID="Template2" runat="server">
                        <Html>
                            <tpl for=".">
						                        <tpl if="[xindex] == 1">
							                        <table class="cbStates-list">
								                        <tr>
									                        <th style="width:70px;">Mã ca</th>
									                        <th>Tên ca</th>
                                                            <th>Giờ vào</th>
                                                            <th>Giờ ra</th>
								                        </tr>
						                        </tpl>
						                        <tr class="list-item">
							                        <td style='padding:3px 0px;'>{MaCa}</td>
							                        <td>{TenCa}</td>
							                        <td>{GioVao}</td>
							                        <td>{GioRa}</td>
						                        </tr>
						                        <tpl if="[xcount-xindex]==0">
							                        </table>
						                        </tpl>
					                        </tpl>
                        </Html>
                    </Template>
                    <Triggers>
                        <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                    </Triggers>
                    <Listeners>
                        <Select Handler="this.triggers[0].show();" />
                        <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();}" />
                        <Expand Handler="if(cbCaLamViecStore.getCount()==0){cbCaLamViecStore.reload();}" />
                    </Listeners>
                </ext:ComboBox>
                <ext:TextField runat="server" ID="txtSoNgayCongChuan" MaskRe="/[0-9.,]/" FieldLabel="Số công chuẩn"
                    AnchorHorizontal="100%" />
            </Items>
            <Buttons>
                <ext:Button runat="server" ID="btnCapNhat" Text="Cập nhật" Icon="Disk">
                    <Listeners>
                        <Click Handler="if(cbCaLamViec.getValue()=='' || cbCaLamViec.getValue()==null){alert('Bạn chưa chọn ca làm việc');return false;}" />
                    </Listeners>
                    <DirectEvents>
                        <Click OnEvent="btnCapNhat_Click">
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:Button>
                <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                    <Listeners>
                        <Click Handler="wdChinhSuaCaLamViec.hide();" />
                    </Listeners>
                </ext:Button>
            </Buttons>
            <Listeners>
                <Hide Handler="cbCaThu7.reset();cbCaChuNhat.reset();cbCaLamViec.reset();" />
            </Listeners>
        </ext:Window>
        <ext:Viewport runat="server" ID="vp">
            <Items>
                <ext:BorderLayout runat="server" ID="brlayout">
                    <Center>
                        <ext:GridPanel ID="grpDanhSachDonVi" runat="server" Border="false" StripeRows="true">
                            <TopBar>
                                <ext:Toolbar runat="server" ID="tbs">
                                    <Items>
                                        <ext:Button runat="server" ID="btnEdit" Text="Thiết lập ca" Icon="Clock" Disabled="true">
                                            <Listeners>
                                                <Click Handler="setValuewdChinhSuaCaLamViec();wdChinhSuaCaLamViec.show();" />
                                            </Listeners>
                                        </ext:Button>
                                    </Items>
                                </ext:Toolbar>
                            </TopBar>
                            <Store>
                                <ext:Store ID="grpDanhSachDonViStore" AutoLoad="false" runat="server" OnRefreshData="grpDanhSachDonViStore_OnRefreshData">
                                    <Reader>
                                        <ext:JsonReader IDProperty="MaDonVi">
                                            <Fields>
                                                <ext:RecordField Name="MaDonVi" />
                                                <ext:RecordField Name="TenDonVi" />
                                                <ext:RecordField Name="MaCa" />
                                                <ext:RecordField Name="MaCaThu7" />
                                                <ext:RecordField Name="MaCaChuNhat" />
                                                <%--<ext:RecordField Name="SoNgayCongChuan" />--%>
                                            </Fields>
                                        </ext:JsonReader>
                                    </Reader>
                                </ext:Store>
                            </Store>
                            <ColumnModel ID="ColumnModel1" runat="server">
                                <Columns>
                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                    <ext:Column ColumnID="TenDonVi" Header="Tên đơn vị" Width="250" DataIndex="TenDonVi" />
                                    <ext:Column Header="Mã đơn vị" Width="75" DataIndex="MaDonVi">
                                    </ext:Column>
                                    <ext:Column Header="Ngày thường" Width="75" DataIndex="MaCa">
                                    </ext:Column>
                                    <ext:Column Header="Thứ 7" Width="65" DataIndex="MaCaThu7">
                                    </ext:Column>
                                    <ext:Column Header="Chủ nhật" Width="65" DataIndex="MaCaChuNhat">
                                    </ext:Column>
                                   <%-- <ext:Column Header="Số công chuẩn" Width="65" DataIndex="SoNgayCongChuan">
                                    </ext:Column>--%>
                                </Columns>
                            </ColumnModel>
                            <SelectionModel>
                                <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                    <Listeners>
                                        <RowSelect Handler="try{btnEdit.enable();}catch(e){}" />
                                        <RowDeselect Handler="try{btnEdit.disable();}catch(e){}" />
                                    </Listeners>
                                </ext:RowSelectionModel>
                            </SelectionModel>
                            <%--<Listeners>
                                <RowDblClick Handler="setValuewdChinhSuaCaLamViec();wdChinhSuaCaLamViec.show();" />
                            </Listeners>--%>
                            <LoadMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            <BottomBar>
                                <ext:PagingToolbar ID="PagingToolbar1" runat="server" PageSize="50">
                                    <Listeners>
                                        <Change Handler="RowSelectionModel1.clearSelections();" />
                                    </Listeners>
                                </ext:PagingToolbar>
                            </BottomBar>
                        </ext:GridPanel>
                    </Center>
                </ext:BorderLayout>
            </Items>
        </ext:Viewport>
    </div>
    </form>
</body>
</html>
