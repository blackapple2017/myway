<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="Modules_HoSoNhanSu_DuyetHoSo_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script type="text/javascript" src="../../../Resource/js/jquery-1.4.2.min.js"></script>
    <script src="../../../Resource/js/Extcommon.js" type="text/javascript"></script>
    <style type="text/css">
        div#grpThongTinMoi .x-panel-body
        {
            border-left: 1px solid #99BBE8 !important;
        }

        div#grpThongTinMoi .x-panel-header
        {
            border-left: 1px solid #99BBE8 !important;
        }

        div#dpfCanhBao
        {
            font-size: 12px !important;
            line-height: 18px;
        }
    </style>
    <script type="text/javascript">
        var RenderStatus = function (value, p, record) {
            if (value == "new") {
                return "<span style='color:red'>Nhập mới</span>";
            }
            if (value == "edit") {
                return "<span style='color:red'>Sửa đổi</span>";
            }
            if (value == "equal") {
                return "<span>Giữ nguyên</span>";
            }
            return "<span>Chưa nhập thông tin</span>";
        }

        var enterKeyPressHandler = function (f, e) {
            if (e.getKey() == e.ENTER) {
                RowSelectionModel1.clearSelections(); StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();
            }
            if (txtSearch.getValue() != '') {
                this.triggers[0].show();
            }
            else {
                this.triggers[0].hide();
            }
        }

        var checkSelect = function () {
            if (GridPanel1.getSelectionModel().getCount() == 0) {
                Ext.Msg.alert("Thông báo", "Bạn chưa chọn nhân viên nào!");
                return false;
            }
            return true;
        }
        var checkSelectOnlyOneRecord = function () {
            if (GridPanel1.getSelectionModel().getCount() > 1) {
                Ext.Msg.alert("Thông báo", "Bạn chỉ được phép chọn 1 nhân viên!");
                return false;
            }
            return true;
        }
        var RenderTrangThai = function (value, p, record) {
            if (value == "KhongDuyet") {
                return "<span style='color:red'>Không duyệt</span>";
            }
            if (value == "DaDuyet") {
                return "<span style='color:blue'>Đã duyệt</span>";
            }
            return "Chưa duyệt";
        }

        var setTitle = function () {
            $("div#wdDuyet .x-window-header-text").html("Bạn đang xem thông tin của nhân viên : " + RowSelectionModel1.getSelected().data.HoTen + " (" + RowSelectionModel1.getSelected().data.BoPhan + ")");
        }
        var setWindowTitle = function (strTitle, key) {
            $("div#wdSoSanhChiTiet .x-window-header-text").html(strTitle);
            hdfThongTinChiTiet.setValue(key);
        }

    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <ext:ResourceManager runat="server" ID="RM" />
            <ext:Hidden runat="server" ID="hdfSelectedUserID" />
            <ext:Hidden runat="server" ID="hdfMaDonVi" />
            <ext:Hidden runat="server" ID="hdfTenNhanVien" />
            <ext:Hidden runat="server" ID="hdfThongTinSaiLech" />
            <ext:Hidden runat="server" ID="hdfStoreDuyetThongTinSaiLech" />
            <ext:Hidden runat="server" ID="hdfThongTinChiTiet" />
            <ext:Hidden runat="server" ID="hdfThongTinDuyetHoSo" />
            <ext:Menu ID="RowContextMenu" runat="server">
                <Items>
                    <ext:MenuItem ID="mnuXemChiTiet" runat="server" Icon="PageWhiteStar" Text="Xem chi tiết">
                        <Listeners>
                            <Click Handler="if(checkSelectOnlyOneRecord()){wdDuyet.show();}" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem ID="mnuXoa" runat="server" Icon="Decline" Text="Xóa">
                        <Listeners>
                            <Click Handler="return checkSelect();" />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnDelete_Click">
                                <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không?" ConfirmRequest="true" />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                    <ext:MenuSeparator runat="server">
                    </ext:MenuSeparator>
                    <ext:MenuItem ID="MenuItem2" runat="server" Text="Không duyệt" Icon="Cross">
                        <Listeners>
                            <Click Handler="wdNhapLyDoKhongDuyet.show();" />
                        </Listeners>
                    </ext:MenuItem>
                    <ext:MenuItem runat="server" Text="Duyệt tất cả và chuyển sang Hồ sơ" Icon="Tick">
                        <DirectEvents>
                            <Click OnEvent="btnDuyetVaChuyenSangHoSo_Click">
                                <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn không ?" ConfirmRequest="true" />
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:MenuItem>
                </Items>
            </ext:Menu>
            <%--<ext:Menu ID="ContextMenuWindow" runat="server">
            <Items>
                <ext:MenuItem ID="MenuItem3" runat="server" Text="Duyệt những thông tin được chọn" Icon="Tick">
                    <DirectEvents>
                        <Click OnEvent="DuyetCacThongTinDuocChon">
                            <EventMask ShowMask="true" />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem5" runat="server" Text="Duyệt tất cả và chuyển sang Hồ sơ"
                    Icon="Tick">
                    <DirectEvents>
                        <Click OnEvent="btnDuyetVaChuyenSangHoSo_Click">
                            <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn không ?" ConfirmRequest="true" />
                            <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                        </Click>
                    </DirectEvents>
                </ext:MenuItem>
                <ext:MenuItem ID="MenuItem4" runat="server" Text="Không duyệt" Icon="Cross">
                    <Listeners>
                        <Click Handler="wdNhapLyDoKhongDuyet.show();" />
                    </Listeners>
                </ext:MenuItem>
            </Items>
        </ext:Menu>--%>
            <ext:Window ID="wdCanhBao" runat="server" Resizable="false" Constrain="true" Padding="6"
                Icon="Exclamation" AutoHeight="true" Layout="RowLayout" Hidden="true" Modal="true"
                Width="550" Title="Cảnh báo">
                <Items>
                    <ext:TextArea runat="server" ID="dpfCanhBao" Text="">
                        <Listeners>
                            <Focus Handler="this.blur();" />
                        </Listeners>
                    </ext:TextArea>
                    <ext:FieldSet runat="server" Layout="RowLayout" Height="100" Title="Chọn một hành động sau đó nhấn tiếp tục"
                        AnchorHorizontal="100%">
                        <Items>
                            <ext:RadioGroup runat="server" ID="rdg" ColumnsNumber="1">
                                <Items>
                                    <ext:Radio ID="rdDongYDuyet" runat="server" Checked="false" BoxLabel="Tôi đã xem các thông tin đó và đồng ý duyệt tất cả các thông tin">
                                    </ext:Radio>
                                    <ext:Radio ID="rdChiDuyetThongTinChinhXac" runat="server" Checked="false" BoxLabel="Tôi có duyệt nhưng chỉ chuyển những thông tin chính xác sang hồ sơ">
                                    </ext:Radio>
                                    <ext:Radio runat="server" ID="rdDuyetSau" Checked="false" BoxLabel="Tôi sẽ kiểm tra lại thông tin đó và duyệt sau">
                                    </ext:Radio>
                                </Items>
                            </ext:RadioGroup>
                        </Items>
                    </ext:FieldSet>
                </Items>
                <Listeners>
                    <Hide Handler="rdDongYDuyet.setValue(false);rdDuyetSau.setValue(false);" />
                </Listeners>
                <Buttons>
                    <ext:Button Text="Tiếp tục" Disabled="false" Icon="Accept" runat="server" ID="btnTiepTucDuyet">
                        <Listeners>
                            <Click Handler="if(rdDongYDuyet.getValue()=='' && rdDuyetSau.getValue()=='' && rdChiDuyetThongTinChinhXac.getValue()==''){
                                                alert('Bạn chưa chọn hành động nào');
                                               return false;
                                            }
                                            if(rdDuyetSau.getValue()==true)
                                            {
                                                wdCanhBao.hide();
                                                return false;
                                            }
                                            " />
                        </Listeners>
                        <DirectEvents>
                            <Click OnEvent="btnTiepTucDuyet_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Modal="true" Padding="0" Constrain="true" Layout="BorderLayout"
                Maximized="true" Maximizable="true" Title="Duyệt thông tin chi tiết" Hidden="true"
                ID="wdSoSanhChiTiet">
                <TopBar>
                    <ext:Toolbar runat="server" ID="tbb">
                        <Items>
                            <ext:Button runat="server" ID="btnThongTinThem1" Text="Thông tin thêm" Icon="Information">
                                <Menu>
                                    <ext:Menu runat="server" ID="mnuThongTinThem1">
                                        <Items>
                                            <%--                                            <ext:MenuItem ID="mnuDaiBieu1" runat="server" Text="1.Đại biểu">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip15" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Đại biểu','DaiBieu');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="DaiBieu" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuDeTai1" runat="server" Text="2.Đề tài">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip16" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Đề tài','DeTai');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="DeTai" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>--%>
                                            <ext:MenuItem ID="mnuKhaNang1" runat="server" Text="1.Khả năng">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip17" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Khả năng','KhaNang');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KhaNang" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuKhenThuong1" runat="server" Text="2.Khen thưởng">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip18" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Khen thưởng','KhenThuong');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KhenThuong" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuKyLuat1" runat="server" Text="5.Kỷ luật" Hidden="true">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip19" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Kỷ luật','KyLuat');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KyLuat" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuanHeGiaDinh1" runat="server" Text="3.Quan hệ gia đình">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip20" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Quan hệ gia đình','QuanHeGiaDinh');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuanHeGiaDinh" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuaTrinhCongTac1" runat="server" Text="4.Quá trình công tác">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip21" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Quá trình công tác','QuaTrinhCongTac');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuaTrinhCongTac" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuaTrinhDieuChuyen1" runat="server" Text="5.Quá trình điều chuyển">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip22" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Quá trình điều chuyển','QuaTrinhDieuChuyen');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuaTrinhDieuChuyen" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuTaiSan1" runat="server" Text="5.Tài sản">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip23" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Tài sản','TaiSan');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="TaiSan" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuTepTinDinhKem1" runat="server" Text="7.Tệp tin đính kèm">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip24" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Tệp tin đính kèm','TepTinDinhKem');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="TepTinDinhKem" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuaTrinhHocTap1" runat="server" Text="8.Quá trình học tập">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip25" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Quá trình học tập','QuaTrinhHocTap');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuaTrinhHocTap" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuKinhNghiemLamViec1" runat="server" Text="9.Kinh nghiệm làm việc">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip26" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Kinh nghiệm làm việc','KinhNghiemLamViec');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KinhNghiemLamViec" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuChungChi1" runat="server" Text="10.Bằng cấp chứng chỉ">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip27" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Bằng cấp chứng chỉ','BangCapChungChi');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="BangCapChungChi" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuTaiNanLaoDong1" runat="server" Text="11.Tai nạn lao động">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip28" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="setWindowTitle('Tai nạn lao động','TaiNanLaoDong');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="TaiNanLaoDong" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                                <ToolTips>
                                    <ext:ToolTip ID="ToolTip29" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                    </ext:ToolTip>
                                </ToolTips>
                            </ext:Button>
                            <ext:Button ID="btnDuyetChiTiet" runat="server" Text="Duyệt" Icon="Tick">
                                <DirectEvents>
                                    <Click OnEvent="btnDuyetChiTiet_Click">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn duyệt không ?" ConfirmRequest="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button ID="btnKhongDuyetChiTiet" runat="server" Text="Không duyệt" Icon="Cross">
                                <DirectEvents>
                                    <Click OnEvent="btnKhongDuyetChiTiet_Click">
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn không duyệt không ?" ConfirmRequest="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:ToolbarSeparator runat="server" />
                            <ext:Button ID="Button3" runat="server" Text="Đóng lại" Icon="Decline">
                                <Listeners>
                                    <Click Handler="wdSoSanhChiTiet.hide();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:Panel runat="server" Border="false" Region="Center">
                        <Items>
                            <ext:RowLayout ID="RowLayout1" runat="server" Split="true">
                                <Rows>
                                    <ext:LayoutRow RowHeight="0.5">
                                        <ext:GridPanel ID="grpThongTinCu" runat="server" Border="false" StripeRows="true"
                                            Title="Thông tin cũ" ColumnWidth="0.5">
                                            <Store>
                                                <ext:Store ID="grpThongTinCuStore" runat="server" AutoLoad="false">
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel3" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel3" runat="server" />
                                            </SelectionModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu" />
                                        </ext:GridPanel>
                                    </ext:LayoutRow>
                                    <ext:LayoutRow RowHeight="0.5">
                                        <ext:GridPanel ID="grpThongTinMoi" runat="server" Border="false" StripeRows="true"
                                            Title="Thông tin mới" ColumnWidth="0.5">
                                            <Store>
                                                <ext:Store ID="grpThongTinMoiStore" runat="server" AutoLoad="false">
                                                </ext:Store>
                                            </Store>
                                            <ColumnModel ID="ColumnModel4" runat="server">
                                                <Columns>
                                                    <ext:RowNumbererColumn Header="STT" Width="35" />
                                                </Columns>
                                            </ColumnModel>
                                            <SelectionModel>
                                                <ext:RowSelectionModel ID="RowSelectionModel4" runat="server" />
                                            </SelectionModel>
                                            <LoadMask ShowMask="true" Msg="Đang tải dữ liệu" />
                                        </ext:GridPanel>
                                    </ext:LayoutRow>
                                </Rows>
                            </ext:RowLayout>
                        </Items>
                    </ext:Panel>
                </Items>
            </ext:Window>
            <ext:Window runat="server" Modal="true" Layout="FormLayout" Padding="6" Width="350"
                AutoHeight="true" Title="Nhập lý do không duyệt" Hidden="true" ID="wdNhapLyDoKhongDuyet">
                <Items>
                    <ext:TextArea runat="server" ID="txtLyDoKhongDuyet" AnchorHorizontal="100%" FieldLabel="Nhập lý do"
                        EmptyText="Nhập lý do không duyệt" />
                </Items>
                <Buttons>
                    <ext:Button runat="server" ID="btnTiepTucKhongDuyet" Text="Tiếp tục" Icon="Accept">
                        <DirectEvents>
                            <Click OnEvent="btnTiepTucKhongDuyet_Click">
                                <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                            </Click>
                        </DirectEvents>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Window runat="server" Layout="BorderLayout" Title="Duyệt thông tin nhân viên tự cập nhật"
                ID="wdDuyet" Hidden="true" Modal="true" Minimizable="false" Closable="true" Maximizable="false"
                Maximized="true">
                <TopBar>
                    <ext:Toolbar runat="server" ID="tb">
                        <Items>
                            <ext:Button runat="server" Text="Thông tin thêm" ID="mnuInfomation" Icon="Information">
                                <Menu>
                                    <ext:Menu runat="server" ID="mnuThongTinThem">
                                        <Items>
                                            <%-- <ext:MenuItem ID="mnuDaiBieu" runat="server" Text="1.Đại biểu">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip1" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Đại biểu','DaiBieu');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="DaiBieu" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuDeTai" runat="server" Text="2.Đề tài">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip2" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Đề tài','DeTai');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="DeTai" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>--%>
                                            <ext:MenuItem ID="mnuKhaNang" runat="server" Text="1.Khả năng">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip3" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Khả năng','KhaNang');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KhaNang" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuKhenThuong" runat="server" Text="2.Khen thưởng">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip4" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Khen thưởng','KhenThuong');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KhenThuong" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuKyLuat" runat="server" Hidden="true" Text="5.Kỷ luật">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip5" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Kỷ luật','KyLuat');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KyLuat" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuanHeGiaDinh" runat="server" Text="3.Quan hệ gia đình">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip6" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Quan hệ gia đình','QuanHeGiaDinh');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuanHeGiaDinh" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuaTrinhCongTac" runat="server" Text="4.Quá trình công tác">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip7" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Quá trình công tác','QuaTrinhCongTac');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuaTrinhCongTac" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuaTrinhDieuChuyen" runat="server" Text="5.Quá trình điều chuyển">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip8" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Quá trình điều chuyển','QuaTrinhDieuChuyen');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuaTrinhDieuChuyen" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuTaiSan" runat="server" Text="6.Tài sản">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip9" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Tài sản','TaiSan');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="TaiSan" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuTepTinDinhKem" runat="server" Text="7.Tệp tin đính kèm">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip10" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Tệp tin đính kèm','TepTinDinhKem');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="TepTinDinhKem" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuQuaTrinhHocTap" runat="server" Text="8.Quá trình học tập">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip11" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Quá trình học tập','QuaTrinhHocTap');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="QuaTrinhHocTap" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuKinhNghiemLamViec" runat="server" Text="9.Kinh nghiệm làm việc">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip12" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Kinh nghiệm làm việc','KinhNghiemLamViec');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="KinhNghiemLamViec" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem ID="mnuChungChi" runat="server" Text="10.Bằng cấp chứng chỉ">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip13" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Bằng cấp chứng chỉ','BangCapChungChi');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="BangCapChungChi" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                            <ext:MenuItem runat="server" ID="mnuTaiNanLaoDong" Text="11.Tai nạn lao động">
                                                <ToolTips>
                                                    <ext:ToolTip ID="ToolTip14" AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                                    </ext:ToolTip>
                                                </ToolTips>
                                                <Listeners>
                                                    <Click Handler="wdSoSanhChiTiet.show();setWindowTitle('Tai nạn lao động','TaiNanLaoDong');" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="mnuThongTinThem_Click">
                                                        <ExtraParams>
                                                            <ext:Parameter Name="LoaiThongTin" Value="TaiNanLaoDong" />
                                                        </ExtraParams>
                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:MenuItem>
                                        </Items>
                                    </ext:Menu>
                                </Menu>
                                <ToolTips>
                                    <ext:ToolTip AutoHide="true" runat="server" Title="Hướng dẫn" Html="Dòng chữ màu đỏ ám chỉ đã có thông tin bị sửa đổi">
                                    </ext:ToolTip>
                                </ToolTips>
                            </ext:Button>
                            <ext:ComboBox runat="server" ID="cbLocTheoTrangThai" SelectedIndex="0" Editable="false"
                                Width="260" FieldLabel="Lọc theo trạng thái">
                                <Items>
                                    <ext:ListItem Text="Tất cả" Value="nothing;equal;edit;new" />
                                    <ext:ListItem Text="Nhập mới" Value="new" />
                                    <ext:ListItem Text="Sửa đổi" Value="edit" />
                                    <ext:ListItem Text="Giữ nguyên" Value="equal" />
                                    <ext:ListItem Text="Chưa nhập thông tin" Value="nothing" />
                                </Items>
                                <Triggers>
                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                </Triggers>
                                <Listeners>
                                    <Select Handler="this.triggers[0].show();grpCompareStore.reload();" />
                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide(); grpCompareStore.reload();}" />
                                </Listeners>
                            </ext:ComboBox>
                            <ext:Button runat="server" ID="btnDuyetDuocChon" Text="Duyệt các thông tin được chọn" Icon="Tick">
                                <Listeners>
                                    <Click Handler="if (CheckSelectedRow(grpCompare) == false) {return false;}" />
                                </Listeners>
                                <DirectEvents>
                                    <Click OnEvent="DuyetCacThongTinDuocChon">
                                        <EventMask ShowMask="true" />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" ID="btnDuyetVaChuyenSangHoSo" Text="Duyệt tất cả & chuyển sang Hồ sơ"
                                Icon="Tick">
                                <DirectEvents>
                                    <Click OnEvent="btnDuyetVaChuyenSangHoSo_Click">
                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn không ?" ConfirmRequest="true" />
                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                    </Click>
                                </DirectEvents>
                            </ext:Button>
                            <ext:Button runat="server" Text="Không duyệt" Icon="Cross" ID="btnKhongDuyet">
                                <Listeners>
                                    <Click Handler="wdNhapLyDoKhongDuyet.show();" />
                                </Listeners>
                            </ext:Button>
                        </Items>
                    </ext:Toolbar>
                </TopBar>
                <Items>
                    <ext:GridPanel ID="grpCompare" runat="server" StripeRows="true" Border="false" Region="Center"
                        TrackMouseOver="true">
                        <Store>
                            <ext:Store ID="grpCompareStore" GroupField="Group" AutoLoad="false" runat="server"
                                OnRefreshData="grpCompareStore_OnRefreshData">
                                <Reader>
                                    <ext:JsonReader IDProperty="InformationField">
                                        <Fields>
                                            <ext:RecordField Name="InformationField" />
                                            <ext:RecordField Name="InformationName" />
                                            <ext:RecordField Name="OldInformation" />
                                            <ext:RecordField Name="NewInformation" />
                                            <ext:RecordField Name="Status" />
                                            <ext:RecordField Name="Group" />
                                        </Fields>
                                    </ext:JsonReader>
                                </Reader>
                            </ext:Store>
                        </Store>
                        <ColumnModel ID="ColumnModel2" runat="server">
                            <Columns>
                                <ext:RowNumbererColumn Header="STT" Width="35" />
                                <ext:GroupingSummaryColumn DataIndex="Group">
                                </ext:GroupingSummaryColumn>
                                <ext:Column ColumnID="InformationName" Header="Tên thông tin" Width="160" DataIndex="InformationName" />
                                <ext:Column ColumnID="OldInformation" Header="Thông tin cũ" Width="360" DataIndex="OldInformation" />
                                <ext:Column ColumnID="NewInformation" Header="Thông tin mới" Width="360" DataIndex="NewInformation" />
                                <ext:Column ColumnID="Status" Header="Tình trạng" Width="160" DataIndex="Status">
                                    <Renderer Fn="RenderStatus" />
                                </ext:Column>
                            </Columns>
                        </ColumnModel>
                        <View>
                            <ext:GroupingView ID="GroupingView1" runat="server" ForceFit="false" MarkDirty="false"
                                ShowGroupName="false" EnableNoGroups="true" HideGroupedColumn="true" />
                        </View>
                        <SelectionModel>
                            <ext:CheckboxSelectionModel runat="server" ID="RowSelectionModelDuyet">
                            </ext:CheckboxSelectionModel>
                        </SelectionModel>
                        <%--<Listeners>
                        <RowContextMenu Handler="e.preventDefault(); #{ContextMenuWindow}.dataRecord = this.store.getAt(rowIndex);#{ContextMenuWindow}.showAt(e.getXY());#{grpCompare}.getSelectionModel().selectRow(rowIndex);" />
                    </Listeners>--%>
                        <LoadMask ShowMask="true" Msg="Đang tải dữ liệu..." />
                    </ext:GridPanel>
                </Items>
                <Listeners>
                    <BeforeShow Handler="setTitle();grpCompareStore.reload();" />
                    <Hide Handler="hdfThongTinSaiLech.reset();hdfStoreDuyetThongTinSaiLech.reset(); hdfThongTinDuyetHoSo.reset();" />
                </Listeners>
                <DirectEvents>
                    <BeforeShow OnEvent="wdDuyet_BeforeShow">
                    </BeforeShow>
                </DirectEvents>
                <Buttons>
                    <ext:Button runat="server" Text="Đóng lại" Icon="Decline">
                        <Listeners>
                            <Click Handler="wdDuyet.hide();" />
                        </Listeners>
                    </ext:Button>
                </Buttons>
            </ext:Window>
            <ext:Viewport runat="server" ID="vp">
                <Items>
                    <ext:BorderLayout runat="server" ID="br">
                        <Center>
                            <ext:GridPanel ID="GridPanel1" runat="server" TrackMouseOver="true" StripeRows="true" Border="false" AutoExpandColumn="HoTen">
                                <Store>
                                    <ext:Store ID="Store1" runat="server">
                                        <Proxy>
                                            <ext:HttpProxy Method="GET" Url="Handler.ashx" />
                                        </Proxy>
                                        <AutoLoadParams>
                                            <ext:Parameter Name="start" Value="={0}" />
                                            <ext:Parameter Name="limit" Value="={30}" />
                                        </AutoLoadParams>
                                        <BaseParams>
                                            <ext:Parameter Name="department" Mode="Raw" Value="hdfMaDonVi.getValue()">
                                            </ext:Parameter>
                                            <ext:Parameter Name="filter" Mode="Raw" Value="cbFilterTheoTrangThai.getValue()">
                                            </ext:Parameter>
                                            <ext:Parameter Name="searchKey" Mode="Raw" Value="txtSearch.getValue()">
                                            </ext:Parameter>
                                        </BaseParams>
                                        <Reader>
                                            <ext:JsonReader Root="Data" TotalProperty="TotalRecords" IDProperty="PR_KEY">
                                                <Fields>
                                                    <ext:RecordField Name="MaCB" />
                                                    <ext:RecordField Name="HoTen" />
                                                    <ext:RecordField Name="BoPhan" />
                                                    <ext:RecordField Name="CapNhatLanCuoi" />
                                                    <ext:RecordField Name="TrangThaiDuyet" />
                                                    <ext:RecordField Name="TaiKhoanDangNhap" />
                                                    <ext:RecordField Name="LyDoKhongDuyet" />
                                                    <ext:RecordField Name="NguoiDuyet" />
                                                    <ext:RecordField Name="PR_KEY" />
                                                    <ext:RecordField Name="UserID" />
                                                </Fields>
                                            </ext:JsonReader>
                                        </Reader>
                                    </ext:Store>
                                </Store>
                                <TopBar>
                                    <ext:Toolbar runat="server">
                                        <Items>
                                            <ext:Button ID="btnXemChiTiet" Disabled="true" runat="server" Text="Xem chi tiết"
                                                Icon="PageWhiteStar">
                                                <Listeners>
                                                    <Click Handler="if(checkSelectOnlyOneRecord()){wdDuyet.show();setWindowTitle();}" />
                                                </Listeners>
                                            </ext:Button>
                                            <ext:Button runat="server" Text="Xóa" ID="btnDelete" Disabled="true" Icon="Delete">
                                                <Listeners>
                                                    <Click Handler="return checkSelect();" />
                                                </Listeners>
                                                <DirectEvents>
                                                    <Click OnEvent="btnDelete_Click">
                                                        <EventMask ShowMask="true" Msg="Đang xóa dữ liệu..." />
                                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn muốn xóa không?" ConfirmRequest="true" />
                                                    </Click>
                                                </DirectEvents>
                                            </ext:Button>
                                            <ext:Button Text="Trạng thái duyệt" Disabled="true" ID="btnTrangThaiDuyet" Icon="Star"
                                                runat="server">
                                                <Menu>
                                                    <ext:Menu runat="server" ID="mnuChuyenTrangThai">
                                                        <Items>
                                                            <ext:MenuItem runat="server" ID="mnuKhongDuyet" Icon="Cross" Text="Không duyệt">
                                                                <Listeners>
                                                                    <Click Handler="if(checkSelect())wdNhapLyDoKhongDuyet.show();" />
                                                                </Listeners>
                                                            </ext:MenuItem>
                                                            <ext:MenuItem Text="Duyệt & chuyển sang Hồ sơ" Icon="Tick" runat="server">
                                                                <Listeners>
                                                                    <Click Handler="return checkSelect();" />
                                                                </Listeners>
                                                                <DirectEvents>
                                                                    <Click OnEvent="btnDuyetVaChuyenSangHoSo_Click">
                                                                        <Confirmation Title="Cảnh báo" Message="Bạn có chắc chắn không ?" ConfirmRequest="true" />
                                                                        <EventMask ShowMask="true" Msg="Chờ trong giây lát..." />
                                                                    </Click>
                                                                </DirectEvents>
                                                            </ext:MenuItem>
                                                        </Items>
                                                    </ext:Menu>
                                                </Menu>
                                            </ext:Button>
                                            <ext:ToolbarSeparator runat="server" ID="tbs" />
                                            <ext:ComboBox Editable="false" ID="cbFilterTheoTrangThai" SelectedIndex="3" runat="server"
                                                Width="230" FieldLabel="Lọc theo trạng thái">
                                                <Items>
                                                    <ext:ListItem Text="Đã duyệt" Value="DaDuyet" />
                                                    <ext:ListItem Text="Không duyệt" Value="KhongDuyet" />
                                                    <ext:ListItem Text="Chưa duyệt" Value="ChuaDuyet" />
                                                    <ext:ListItem Text="Tất cả" Value="" />
                                                </Items>
                                                <Triggers>
                                                    <ext:FieldTrigger Icon="Clear" HideTrigger="true" />
                                                </Triggers>
                                                <Listeners>
                                                    <Select Handler="this.triggers[0].show();StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();Store1.reload();" />
                                                    <BeforeQuery Handler="this.triggers[0][ this.getRawValue().toString().length == 0 ? 'hide' : 'show']();" />
                                                    <TriggerClick Handler="if (index == 0) { this.clearValue(); this.triggers[0].hide();StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();Store1.reload();}" />
                                                </Listeners>
                                            </ext:ComboBox>
                                            <ext:ToolbarFill runat="server" />
                                            <ext:TriggerField Width="220" HideTrigger="true" runat="server" ID="txtSearch" EmptyText="Nhập mã hoặc họ tên cán bộ"
                                                EnableKeyEvents="true">
                                                <Listeners>
                                                    <KeyPress Fn="enterKeyPressHandler" />
                                                    <TriggerClick Handler="txtSearch.reset();RowSelectionModel1.clearSelections();StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();this.triggers[0].hid();" />
                                                </Listeners>
                                            </ext:TriggerField>
                                            <ext:Button runat="server" Text="Tìm kiếm" Icon="Zoom">
                                                <Listeners>
                                                    <Click Handler="RowSelectionModel1.clearSelections();StaticPagingToolbar.pageIndex = 0; StaticPagingToolbar.doLoad();" />
                                                </Listeners>
                                            </ext:Button>
                                        </Items>
                                    </ext:Toolbar>
                                </TopBar>
                                <ColumnModel ID="ColumnModel1" runat="server">
                                    <Columns>
                                        <ext:RowNumbererColumn Header="STT" Width="35" />
                                        <ext:Column Header="Mã nhân viên" Width="85" DataIndex="MaCB">
                                        </ext:Column>
                                        <ext:Column ColumnID="HoTen" Header="Họ tên" Width="160" DataIndex="HoTen" />
                                        <ext:Column Header="Tài khoản" Width="100" DataIndex="TaiKhoanDangNhap">
                                        </ext:Column>
                                        <ext:Column Header="Bộ phận" Width="175" DataIndex="BoPhan">
                                        </ext:Column>
                                        <ext:DateColumn Header="Cập nhật lần cuối" Width="95" DataIndex="CapNhatLanCuoi"
                                            Format="dd/MM/yyyy hh:mm:ss" />
                                        <ext:Column Header="Trạng thái duyệt" Width="175" DataIndex="TrangThaiDuyet">
                                            <Renderer Fn="RenderTrangThai" />
                                        </ext:Column>
                                        <ext:Column Header="Lý do không duyệt" Width="175" DataIndex="LyDoKhongDuyet">
                                        </ext:Column>
                                        <ext:Column Header="Người duyệt" Width="90" DataIndex="NguoiDuyet">
                                        </ext:Column>
                                    </Columns>
                                </ColumnModel>
                                <Listeners>
                                    <RowContextMenu Handler="e.preventDefault(); #{RowContextMenu}.dataRecord = this.store.getAt(rowIndex);#{RowContextMenu}.showAt(e.getXY());#{GridPanel1}.getSelectionModel().selectRow(rowIndex);" />
                                </Listeners>
                                <SelectionModel>
                                    <ext:RowSelectionModel ID="RowSelectionModel1" runat="server">
                                        <Listeners>
                                            <RowSelect Handler="try{btnXemChiTiet.enable();}catch(e){} try{btnTrangThaiDuyet.enable();}catch(e){} try{btnDelete.enable();}catch(e){}
                                                                hdfSelectedUserID.setValue(RowSelectionModel1.getSelected().data.UserID);
                                                                hdfTenNhanVien.setValue(RowSelectionModel1.getSelected().data.HoTen);" />
                                        </Listeners>
                                    </ext:RowSelectionModel>
                                </SelectionModel>
                                <LoadMask ShowMask="true" />
                                <BottomBar>
                                    <ext:PagingToolbar ID="StaticPagingToolbar" IDMode="Static" EmptyMsg="Hiện không có dữ liệu"
                                        NextText="Trang sau" PrevText="Trang trước" LastText="Trang cuối cùng" FirstText="Trang đầu tiên"
                                        DisplayMsg="Dòng {0} đến dòng {1} / {2} dòng" runat="server">
                                        <Items>
                                            <ext:Label ID="Label1" runat="server" Text="Số bản ghi trên 1 trang:" />
                                            <ext:ToolbarSpacer ID="ToolbarSpacer1" runat="server" Width="10" />
                                            <ext:ComboBox ID="ComboBoxPaging" Editable="false" runat="server" Width="80">
                                                <Items>
                                                    <ext:ListItem Text="15" />
                                                    <ext:ListItem Text="20" />
                                                    <ext:ListItem Text="25" />
                                                    <ext:ListItem Text="30" />
                                                </Items>
                                                <Listeners>
                                                    <Select Handler="#{StaticPagingToolbar}.pageSize = parseInt(this.getValue()); #{StaticPagingToolbar}.doLoad();" />
                                                </Listeners>
                                            </ext:ComboBox>
                                        </Items>
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
