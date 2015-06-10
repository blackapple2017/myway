<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BangPhanCaNhanVien.aspx.cs" Inherits="Modules_ChamCongDoanhNghiep_BangPhanCaNhanVien" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<%@ Register Src="../Base/SingleGridPanel/SingleGridPanel.ascx" TagName="SingleGridPanel"
    TagPrefix="uc1" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <style type="text/css">
        #SingleGridPanel1_GridPanel1 {
            border-left: 1px solid #8DB2E3 !important;
        }

        #SingleGridPanel1_pnlCoCauToChuc-xsplit {
            border-right: none !important;
        }

        .cbStates-list {
            width: 298px;
            font: 11px tahoma,arial,helvetica,sans-serif;
        }
        .cbStates-list th {
            font-weight: bold;
        }
        .cbStates-list td, .cbStates-list th {
            padding: 3px;
        }
    </style>
    <script src="../../Resource/js/RenderJS.js" type="text/javascript"></script>
    <script type="text/javascript">
        var GetSelectedNodeDonVi = function (tree, stringallmadonvi, stringmadonvi) {
            try {
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
            } catch (e) {
                alert('Bạn chưa chọn đơn vị');
                return false;
            }
            return true;
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
        var CheckSua = function () {
            if (SingleGridPanel1_GridPanel1.getSelectionModel().getCount() == 0) {
                alert('Bạn chưa chọn một nhân viên');
                return false;
            }
            wdSua.show();
            return true;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:Hidden runat="server" ID="hdfStringAllMaDonVi">
            </ext:Hidden>
            <ext:Hidden runat="server" ID="hdfStringMaDonVi" />
            <ext:Menu runat="server" ID="RowContextMenu">
                <Items>
                    <ext:MenuItem ID="Button1" runat="server" Text="Nhập từ Excel" Icon="PageExcel">
                        <Listeners>
                            <Click Handler="wdImportExcelFile.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="Button2" runat="server" Text="Xuất ra Excel" Icon="PageExcel">
                        <Listeners>
                            <Click Handler="wdExport.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="Button3" runat="server" Text="Sử dụng mã nhân viên" Icon="User">
                        <Listeners>
                            <Click Handler="wdSuDungMaNhanVien.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="MenuItem1" runat="server" Text="Sửa" Icon="Pencil">
                        <Listeners>
                            <Click Handler="wdSua.show();" />
                        </Listeners>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <ext:Window runat="server" ID="wdSuDungMaNhanVien" Title="Sử dụng mã nhân viên làm mã chấm công"
                Padding="6" Hidden="true" Modal="true" Layout="FormLayout" Constrain="true" Width="500"
                AutoHeight="true">
                <Items>
                    <ext:DropDownField runat="server" Editable="false" ID="ddfDonVi" AnchorHorizontal="100%"
                        AllowBlank="false" BlankText="Bạn phải chọn đơn vị hoặc bộ phận sử dụng" FieldLabel="Chọn bộ phận">
                        <Component>
                            <ext:TreePanel ID="TreePanelDonVi" runat="server" Header="false" Icon="Accept" Height="300"
                                Shadow="None" UseArrows="true" AutoScroll="true" Animate="true" EnableDD="true"
                                ContainerScroll="true" RootVisible="false">
                                <Root>
                                </Root>
                                <Buttons>
                                    <ext:Button ID="Button4" Icon="Decline" runat="server" Text="Đóng lại">
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
                </Items>
                <Buttons>
                    <ext:Button ID="btnSuDungMaNhanVien" runat="server" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="GetSelectedNodeDonVi(TreePanelDonVi,hdfStringAllMaDonVi,hdfStringMaDonVi);" />
                        </Listeners>
                        <DirectEvents>
                            <%--<Click OnEvent="btnSuDungMaNhanVien_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>--%>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdSuDungMaNhanVien.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="rdChonDonVi.reset();hdfStringMaDonVi.reset();" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" ID="wdImportExcelFile" Constrain="true" Modal="true" Title="Nhập tệp tin chấm công"
                Padding="6" Icon="PageExcel" AutoHeight="true" Layout="FormLayout" Hidden="true"
                Width="450">
                <Items>
                    <ext:FileUploadField runat="server" ID="fUpload" SelectOnFocus="true" Regex="^.*\.xls$"
                        InvalidText="Tệp tin được chọn phải là Excel 2003" AnchorHorizontal="100%" FieldLabel="Chọn tệp tin">
                        <Listeners>
                            <FileSelected Handler="#{cbSheetNameStore}.reload();#{cbSheetName}.enable();" />
                        </Listeners>
                    </ext:FileUploadField>
                    <ext:ComboBox ID="cbSheetName" Disabled="true" FieldLabel="Chọn sheet" SelectedIndex="0"
                        Editable="false" AnchorHorizontal="100%" runat="server" DisplayField="SheetName"
                        ValueField="SheetName" SelectOnFocus="true">
                        <Store>
                            <ext:Store ID="cbSheetNameStore" runat="server" OnRefreshData="cbSheetNameStore_OnRefreshData"
                                AutoLoad="false" EnableViewState="false">
                                <DirectEventConfig>
                                    <EventMask ShowMask="false" />
                                </DirectEventConfig>
                                <Reader>
                                    <ext:JsonReader IDProperty="SheetName">
                                        <Fields>
                                            <ext:RecordField Name="SheetName" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                    </ext:ComboBox>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnImport" Text="Nhập dữ liệu" Icon="PageExcel">
                        <Listeners>
                            <Click Handler="if (#{fUpload}.getValue() == '') {alert('Bạn chưa chọn tệp tin đính kèm'); return false;}
                            if (#{cbSheetName}.getValue() == '' || cbSheetName.getValue() == null) {alert('Bạn chưa chọn sheet'); return false;}" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnImport_Click">
                                <EventMask ShowMask="true" Msg="Đang nhập dữ liệu. Vui lòng chờ..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnDongLai" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdImportExcelFile.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="#{fUpload}.reset(); #{cbSheetName}.reset();" />
                </Listeners>
            </ext:Window>
            <ext:Store ID="Store2" runat="server" OnRefreshData="Store2_OnRefresh">
                <Reader>
                    <ext:JsonReader IDProperty="ID">
                        <Fields>
                            <ext:RecordField Name="ID" />
                            <ext:RecordField Name="MaCa" />
                            <ext:RecordField Name="TenCa" />
                            <ext:RecordField Name="GioVao" />
                            <ext:RecordField Name="GioRa" />
                        </Fields>
                    </ext:JsonReader>
                </Reader>
            </ext:Store>
            <ext:Window runat="server" ID="wdSua" Width="400" AutoHeight="true" Resizable="false"
                Modal="true" Layout="FormLayout" LabelWidth="125" Constrain="true" Hidden="true"
                Title="Sửa mã ca" Icon="Pencil" Padding="6">
                <Items>
                    <ext:ComboBox ID="cbTinhTrangLamViec" runat="server" EmptyText="Chọn ca làm việc"
                        TypeAhead="true" AnchorHorizontal="100%" ForceSelection="true" StoreID="Store2"
                        Mode="Local" DisplayField="TenCa" ValueField="MaCa" FieldLabel="Chọn ca làm việc<span style='color:red;'>*</span>"
                        MinChars="1" ListWidth="300" PageSize="10" ItemSelector="tr.list-item" Editable="false">
                        <Template ID="Template1" runat="server">
                            <Html>
                                <tpl for=".">
						        <tpl if="[xindex] == 1">
							        <table class="cbStates-list">
								        <tr>
									        <th>Mã ca</th>
									        <th>Tên ca</th>
                                            <th>Giờ vào</th>
									        <th>Giờ ra</th>
								        </tr>
						        </tpl>
						        <tr class="list-item">
							        <td style="padding:3px 0px;">{MaCa}</td>
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
                        <Listeners>
                            <Focus Handler="Store2.reload();" />
                        </Listeners>
                    </ext:ComboBox>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnSuaDongY" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="if(SingleGridPanel1_GridPanel1.getSelectionModel().getCount() == 0){alert('Bạn chưa chọn một nhân viên');return false;}
                                        " />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnSuaDongYClick">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnSuaDongLai" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdSua.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
                <Listeners>
                    <Hide Handler="cbTinhTrangLamViec.reset();" />
                </Listeners>
            </ext:Window>
            <ext:Window runat="server" ID="wdExport" Width="470" AutoHeight="true" Resizable="false"
                Modal="true" Layout="FormLayout" Constrain="true" Hidden="true" Title="Export thông tin nhân viên và mã chấm công"
                Icon="PageExcel" Padding="6">
                <Items>
                    <ext:RadioGroup runat="server" ID="radgrp" FieldLabel="Lựa chọn" Vertical="false"
                        ColumnsNumber="1">
                        <Items>
                            <ext:Radio runat="server" ID="radExpTatCa" BoxLabel="Xuất tất cả cán bộ trong đơn vị">
                            </ext:Radio>
                            <ext:Radio runat="server" ID="radExpBoPhan" BoxLabel="Chỉ xuất những cán bộ trong bộ phận đang chọn"
                                Checked="true">
                            </ext:Radio>
                            <ext:Radio runat="server" ID="radExpChon" BoxLabel="Chỉ xuất những cán bộ được chọn">
                            </ext:Radio>
                        </Items>
                    </ext:RadioGroup>
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnImpDongY" Text="Đồng ý" Icon="Accept">
                        <Listeners>
                            <Click Handler="" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="ExportExcelClick">
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                    <ext:Button runat="server" ID="btnImpDongLai" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdExport.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Button runat="server" Text="Nhập từ Excel" Icon="PageExcel" ID="btnImportFromExcel">
                <Listeners>
                    <Click Handler="wdImportExcelFile.show();" />
                </Listeners>
            </ext:Button>
            <ext:Button runat="server" Text="Xuất ra excel" Icon="PageExcel" ID="btnExportToExcel">
                <Listeners>
                    <Click Handler="wdExport.show();" />
                </Listeners>
            </ext:Button>
            <%--<ext:Button runat="server" Text="Sử dụng mã nhân viên" Icon="User" ID="btnThietLapNhanh">
                <Menu>
                    <ext:Menu runat="server" ID="subMenu">
                        <Items>
                            <ext:MenuItem runat="server" Text="Áp dụng cho nhân viên được chọn">
                                <Listeners>
                                    <Click Handler="if(SingleGridPanel1_GridPanel1.getSelectionModel().getCount() == 0){
                                                        alert('Bạn chưa chọn nhân viên nào');
                                                        return false;
                                                    }" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="btnSuDungMaNhanVien_Click">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                        <ExtraParams>
                                            <ext:Parameter Name="SelectedEmployees" Value="OK" />
                                        </ExtraParams>
                                    </Click>
                                </DirectEvents>
                            </ext:MenuItem>
                            <ext:MenuItem ID="MenuItem2" runat="server" Text="Áp dụng cho bộ phận">
                                <Listeners>
                                    <Click Handler="wdSuDungMaNhanVien.show();" />
                                </Listeners>
                            </ext:MenuItem>
                        </Items>
                    </ext:Menu>
                </Menu>
            </ext:Button>--%>
            <uc1:SingleGridPanel ID="SingleGridPanel1" EnableWestPanelFilter="true" OrderBy="TEN_CB"
                ColumnName="MA_CB,HO_TEN,MA_GIOITINH,NGAY_SINH,TEN_DONVI,TEN_DIADIEM,MaCa" DisplayPrimaryColumn="true"
                ColumnHeader="Mã nhân viên, Họ tên, Giới tính, Ngày sinh, Bộ phận,Địa điểm làm việc, Mã ca" SingleSelect="true"
                ExpandWestPanelFilter="false" SearchField="MA_CB,HO_TEN" EmptyTextSearch="Nhập mã NV, họ tên hoặc mã chấm công..."
                MaDonViColumn="MA_DONVI" Render="MA_GIOITINH=GetGender" ColumnWidth="TEN_DONVI=230,ID_MAY_CHAMCONG=120,HO_TEN=170,TEN_DIADIEM=150"
                TableOrViewName="ChamCong_BangPhanCaNhanVien" IDProperty="MA_CB" runat="server" />
        </div>
    </form>
</body>
</html>
