<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="HelpBook_Default" %>

<%@ Register Assembly="Ext.Net" Namespace="Ext.Net" TagPrefix="ext" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Hướng dẫn sử dụng</title>
    <script src="../Resource/js/Extcommon.js" type="text/javascript"></script>
    <script type="text/javascript">
        var AddContent = function (id, link, title) {
            addTab(TabContent, id, link, title);
        }
    </script>
</head>
<body>
    <ext:ResourceManager ID="RM" Theme="Default" runat="server">
    </ext:ResourceManager>
    <ext:Viewport ID="Viewport1" runat="server" Layout="border">
        <Items>
            <ext:Panel ID="Panel1" runat="server" Title="North" Header="false" Border="false"
                Region="North" Split="true" Height="30" Padding="0" Collapsible="true">
                <Content>
                    <div style="background: #DFE8F6; height: 30px; width: 100%;">
                        <h1>
                            Sách hướng dẫn sử dụng phần mềm quản trị nguồn nhân lực
                        </h1>
                    </div>
                </Content>
            </ext:Panel>
            <ext:Panel ID="Panel2" runat="server" Title="Mục lục" Icon="Book" Region="West" Layout="accordion"
                Width="250" MinWidth="250" MaxWidth="400" Split="true" Collapsible="true">
                <Items>
                    <ext:TreePanel ID="TreePanel2" runat="server" Width="300" Height="450" Icon="Monitor"
                        Title="Bàn làm việc" RootVisible="false" AutoScroll="true">
                        <Root>
                            <ext:TreeNode Expanded="true" Expandable="True" Text="Composers">
                                <Nodes>
                                    <ext:TreeNode Expanded="true" Text="Biểu đồ" Icon="Folder">
                                        <Nodes>
                                            <ext:TreeNode Text="Biểu đồ biến động nhân sự" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoBienDongNhanSu','HtmlBook/BanLamViec/BieuDoBienDongNhanSu.html','Biểu đồ biến động nhân sự');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ cấp bậc quân đội" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoCapBacQuanDoi','HtmlBook/BanLamViec/BieuDoCapBacQuanDoi.html','Biểu đồ cấp bậc quân đội');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ chức vụ đảng" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoChucVuDang','HtmlBook/BanLamViec/BieuDoChucVuDang.html','Biểu đồ chức vụ đảng');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ chức vụ đoàn" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoChucVuDoan','HtmlBook/BanLamViec/BieuDoChucVuDoan.html','Biểu đồ chức vụ đoàn');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ dân tộc" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoDanToc','HtmlBook/BanLamViec/BieuDoDanToc.html','Biểu đồ dân tộc');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ giới tính" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoGioiTinh','HtmlBook/BanLamViec/BieuDoGioiTinh.html','Biểu đồ giới tính');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ loại hợp đồng" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoLoaiHD','HtmlBook/BanLamViec/BieuDoLoaiHD.html','Biểu đồ loại hợp đồng');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ phòng ban" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoPhongBan','HtmlBook/BanLamViec/BieuDoPhongBan.html','Biểu đồ phòng ban');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ quốc tịch" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoQuocTich','HtmlBook/BanLamViec/BieuDoQuocTich.html','Biểu đồ quốc tịch');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ tỉnh thành" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoTinhThanh','HtmlBook/BanLamViec/BieuDoTinhThanh.html','Biểu đồ tỉnh thành');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ tôn giáo" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoTonGiao','HtmlBook/BanLamViec/BieuDoTonGiao.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ trình độ" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoTrinhDo','HtmlBook/BanLamViec/BieuDoTrinhDo.html','Biểu đồ tôn giáo');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Biểu đồ tình trạng hôn nhân" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idBieuDoTTHonNhan','HtmlBook/BanLamViec/BieuDoTTHonNhan.html','Biểu đồ tình trạng hôn nhân');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                                <ext:TreeNode Text="Thống kê nhân sự theo đơn vị" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idThongKeNhanSuTheoDonVi','HtmlBook/BanLamViec/ThongKeNhanSuTheoDonVi.html','Thống kê nhân sự theo đơn vị');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Thống kê nhân sự theo độ tuổi" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idThongKeTheoDoTuoi','HtmlBook/BanLamViec/ThongKeTheoDoTuoi.html','Thống kê nhân sự theo độ tuổi');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Thống kê theo thâm niên công tác" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idThongKeTheoThamNienCT','HtmlBook/BanLamViec/ThongKeTheoThamNienCT.html','Thống kê theo thâm niên công tác');"  />
                                                </Listeners>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Tra cứu nhanh thông tin nhân viên" Icon="BulletBlue">
                                        <Listeners>
                                            <Click Handler="addTab(#{TabContent},'idTraCuuNhanh','HtmlBook/BanLamViec/TraCuuNhanh.html','Tra cứu nhanh thông tin nhân viên');" />
                                        </Listeners>
                                    </ext:TreeNode>
                                    <ext:TreeNode Expanded="true" Text="Tiện ích" Icon="Folder">
                                        <Nodes>
                                            <ext:TreeNode Text="Chấm công ngày hôm nay" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idTienIch','HtmlBook/BanLamViec/TienIch.html','Chấm công ngày hôm nay');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Thông báo sinh nhật nhân viên" Icon="BulletBlue">
                                                <Listeners>
                                                   <Click Handler="addTab(#{TabContent},'idTienIch','HtmlBook/BanLamViec/TienIch.html','Thông báo sinh nhật nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Thông báo nhân viên sắp hết hợp đồng" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idTienIch','HtmlBook/BanLamViec/TienIch.html','Thông báo nhân viên sắp hết hợp đồng');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                        </Root>
                    </ext:TreePanel>
                    <ext:TreePanel ID="TreePanel1" runat="server" Width="300" Height="450" Icon="BookOpen"
                        Title="Danh mục" RootVisible="false" AutoScroll="true">
                        <Root>
                            <ext:TreeNode Expanded="true" Expandable="True" Text="Composers">
                                <Nodes>
                                    <ext:TreeNode Expanded="true" Text="Thông tin cá nhân" Icon="Folder">
                                        <Nodes>
                                            <ext:TreeNode Text="Danh mục cán bộ công nhân viên" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucCanBoCNVien','HtmlBook/DanhMuc/DanhMucCanBoCNVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục dân tộc" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucDanToc','HtmlBook/DanhMuc/DanhMucDanToc.html','Danh mục dân tộc');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục tôn giáo" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucTonGiao','HtmlBook/DanhMuc/DanhMucTonGiao.html','Danh mục tôn giáo');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục tình trạng sức khỏe" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucTTSucKhoe','HtmlBook/DanhMuc/DanhMucTTSucKhoe.html','Danh mục tình trạng sức khỏe');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục tình trạng hôn nhân" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucTTHonNhan','HtmlBook/DanhMuc/DanhMucTTHonNhan.html','Danh mục tình trạng hôn nhân');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục thành phần bản thân" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucThanhPhanBanThan','HtmlBook/DanhMuc/DanhMucThanhPhanBanThan.html','Danh mục thành phần bản thân');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục thành phần gia đình" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucThanhPhanGiaDinh','HtmlBook/DanhMuc/DanhMucThanhPhanGiaDinh.html','Danh mục thành phần gia đình');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                             <ext:TreeNode Text="Danh mục quan hệ gia đình" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucQuanHeGiaDinh','HtmlBook/DanhMuc/DanhMucQuanHeGiaDinh.html','Danh mục quan hệ gia đình');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục nơi cấp CMND" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucNoiCapCMND','HtmlBook/DanhMuc/DanhMucNoiCapCMND.html','Danh mục nơi cấp CMND');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục nơi cấp hộ chiếu" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucNoiCapHoChieu','HtmlBook/DanhMuc/DanhMucNoiCapHoChieu.html','Danh mục nơi cấp hộ chiếu');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục tỉnh thành" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucTinhThanh','HtmlBook/DanhMuc/DanhMucTinhThanh.html','Danh mục tỉnh thành');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục quốc tịch" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucQuocTich','HtmlBook/DanhMuc/DanhMucQuocTich.html','Danh mục quốc tịch');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục nơi cấp BHYT" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucNoiCapBHYT','HtmlBook/DanhMuc/DanhMucNoiCapBHYT.html','Danh mục nơi cấp BHYT');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục nơi cấp BHXH" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'idDanhMucNoiCapBHXH','HtmlBook/DanhMuc/DanhMucNoiCapBHXH.html','Danh mục nơi cấp BHXH');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục nơi khám chữa bệnh" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục nơi khám chữa bệnh');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Expanded="true" Text="Trình độ khả năng" Icon="Folder">
                                        <Nodes>
                                            <ext:TreeNode Text="Danh mục trình độ" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục trình độ văn hóa" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục chuyên ngành" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục chứng chỉ" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục ngoại ngữ" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục loại tốt nghiệp" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục tin học" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục trường đào tạo" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục xếp loại" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục trình độ quản lý" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục trình độ quản lý kinh tế" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục trình độ chính trị" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                            <ext:TreeNode Text="Danh mục khả năng" Icon="BulletBlue">
                                                <Listeners>
                                                    <Click Handler="addTab(#{TabContent},'id1','HtmlBook/DanhMuc/DanhMucCanBoCongNhanVien.html','Danh mục cán bộ công nhân viên');" />
                                                </Listeners>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                    <ext:TreeNode Text="Mozart" Icon="UserGray">
                                        <Nodes>
                                            <ext:TreeNode Text="Concertos">
                                                <Nodes>
                                                    <ext:TreeNode Text="Piano Concerto No. 12" Icon="Music" />
                                                    <ext:TreeNode Text="Piano Concerto No. 17" Icon="Music" />
                                                    <ext:TreeNode Text="Clarinet Concerto" Icon="Music" />
                                                    <ext:TreeNode Text="Violin Concerto No. 5" Icon="Music" />
                                                    <ext:TreeNode Text="Violin Concerto No. 4" Icon="Music" />
                                                </Nodes>
                                            </ext:TreeNode>
                                        </Nodes>
                                    </ext:TreeNode>
                                </Nodes>
                            </ext:TreeNode>
                        </Root>
                    </ext:TreePanel>
                </Items>
            </ext:Panel>
            <ext:TabPanel ID="TabContent" runat="server" Region="Center">
                <Items>
                </Items>
            </ext:TabPanel>
            <ext:Panel ID="Panel10" runat="server" Title="South" Region="South" Header="false"
                Split="true" Collapsible="true" Height="25" Padding="0">
                <Items>
                    <ext:StatusBar runat="server" ID="statusbar" Text="Phần mềm quản trị nguồn nhân lực, phiên bản 1.6">
                    </ext:StatusBar>
                </Items>
            </ext:Panel>
        </Items>
    </ext:Viewport>
</body>
</html>
