using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using LinqToExcel;
using DAL;
using Ext.Net;
using ExtMessage;
using System.IO;

public partial class Modules_ChamCong_ImportFromExcel : System.Web.UI.UserControl
{
    public event EventHandler AfterClickImport;
    public event EventHandler AfterClickTestData;
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    private bool checkNumber(char c)
    {
        if (c >= '0' && c <= '9')
            return true;
        return false;
    }

    private void getConfig(out string startCell, out string endCell)
    {
        // get Config
        string file = Server.MapPath("config.txt");
        string[] lines = System.IO.File.ReadAllLines(file);
        int pos = lines[0].IndexOf(' ');
        startCell = lines[0].Substring(0, pos).Trim();
        endCell = lines[0].Substring(pos + 1).Trim();
        int maxLines = int.Parse(lines[1] == "" ? "1000" : lines[1]);

        // get end cell
        pos = 0;
        for (int i = 0; i < endCell.Length; i++)
        {
            if (checkNumber(endCell[i]))
            {
                pos = i;
                break;
            }
        }
        string text = endCell.Substring(0, pos);
        int number = int.Parse(endCell.Substring(pos)) + maxLines;
        endCell = text + number;
    }

    protected void DownloadBangChamCongMau(object sender, DirectEventArgs e)
    {
        try
        {
            string fileName = Server.MapPath("Files/Mau_Bang_Cham_Cong.xls");
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);

            if (file.Exists)
            {
                Response.Clear();
                Response.AddHeader("content-disposition", "attachment; filename=" + file.FullName);
                Response.AddHeader("Content-Length", file.Length.ToString());
                Response.ContentType = "application/vnd.ms-excel";
                Response.WriteFile(file.FullName);
                Response.End();
            }
            else
            {
                X.Msg.Alert("Thông báo", "File mẫu không tồn tại").Show();
            }
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }

    /// <summary>
    /// daibx 28/06/2013
    /// Đọc dữ liệu từ excel vào csdl sau khi đã kiểm tra các kí hiệu chấm công
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void ImportDataFromExcel(object sender, EventArgs e)
    {
        try
        {
            string extension = System.IO.Path.GetExtension(FileUploadField1.PostedFile.FileName).ToLower();

            if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
            {
                X.Msg.Alert("Thông báo", "Hãy chọn file excel").Show();
                return;
            }
            string fn = System.IO.Path.GetFileName(FileUploadField1.PostedFile.FileName);
            string saveLocation = Server.MapPath("Files") + "\\" + fn;

            var excel = new ExcelQueryFactory();
            excel.FileName = saveLocation;

            // get config
            string startCell = "";
            string endCell = "";
            getConfig(out startCell, out endCell);

            var datas = from x in excel.WorksheetRangeNoHeader(startCell, endCell, cbSheetName.Value.ToString())
                        select x;

            List<BangChamCongThangInfo> BangChamCong = new List<BangChamCongThangInfo>();

            foreach (var item in datas)
            {
                if (item[0] == "")
                    break;
                BangChamCong.Add(new BangChamCongThangInfo()
                {
                    MACB = item[0].ToString(),
                    NGAY01 = item[2].ToString(),
                    NGAY02 = item[3].ToString(),
                    NGAY03 = item[4].ToString(),
                    NGAY04 = item[5].ToString(),
                    NGAY05 = item[6].ToString(),
                    NGAY06 = item[7].ToString(),
                    NGAY07 = item[8].ToString(),
                    NGAY08 = item[9].ToString(),
                    NGAY09 = item[10].ToString(),
                    NGAY10 = item[11].ToString(),
                    NGAY11 = item[12].ToString(),
                    NGAY12 = item[13].ToString(),
                    NGAY13 = item[14].ToString(),
                    NGAY14 = item[15].ToString(),
                    NGAY15 = item[16].ToString(),
                    NGAY16 = item[17].ToString(),
                    NGAY17 = item[18].ToString(),
                    NGAY18 = item[19].ToString(),
                    NGAY19 = item[20].ToString(),
                    NGAY20 = item[21].ToString(),
                    NGAY21 = item[22].ToString(),
                    NGAY22 = item[23].ToString(),
                    NGAY23 = item[24].ToString(),
                    NGAY24 = item[25].ToString(),
                    NGAY25 = item[26].ToString(),
                    NGAY26 = item[27].ToString(),
                    NGAY27 = item[28].ToString(),
                    NGAY28 = item[29].ToString(),
                    NGAY29 = item[30].ToString(),
                    NGAY30 = item[31].ToString(),
                    NGAY31 = item[32].ToString(),
                });
            }

            // 
            if (AfterClickImport != null)
            {
                AfterClickImport(BangChamCong, null);
            }
            wdReadFromExcel.Hide();
        }
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo", ex.Message.ToString()).Show();
        }
    }

    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = FileUploadField1.PostedFile;

            if (file.ContentType != "application/vnd.ms-excel") //ko phải Excel 2003
            {
                Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("NotExcel2003"));
                return;
            }
            if (FileUploadField1.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                string path = string.Empty;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath("Files"));
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath("Files/") + FileUploadField1.FileName;
                    file.SaveAs(path);
                }
                catch (Exception ex)
                {
                    Dialog.ShowError(ex.Message);
                }
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowNotification(ex.Message);
        }
    }

    protected void cbSheetNameStore_OnRefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            UploadFile();
            if (new FileInfo(Server.MapPath("Files" + "/") + FileUploadField1.FileName).Exists)
            {
                List<object> sheetData = new List<object>();
                IEnumerable<string> sheetname = ExcelEngine.GetInstance().GetAllSheetName(Server.MapPath("Files" + "/") + FileUploadField1.FileName);
                foreach (var item in sheetname)
                {
                    sheetData.Add(new { SheetName = item });
                }
                cbSheetNameStore.DataSource = sheetData;
                cbSheetNameStore.DataBind();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message);
        }
    }

    /// <summary>
    /// daibx 28/06/2013
    /// Kiểm tra dữ liệu trong file excel có phù hợp với ký hiệu chấm công trong phần mềm hay không
    /// 
    /// - Các kí hiệu chấm công được lấy trong bảng DM_TT_LAMVIEC với ràng buộc IS_IN_USED = true (các kí hiệu vẫn đang sử dụng)
    /// - So sánh các kí hiệu này với các kí hiệu trong excel, nếu có một kí hiệu không phù hợp thì đưa ra thông báo và yêu cầu
    /// sửa lại cho đúng (không cho nhập dữ liệu sai). nếu không có lỗi nào xảy ra thì đưa ra thông báo và cho người dùng import 
    /// dữ liệu vào
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void btnTestDuLieu_Click(object sender, DirectEventArgs e)
    {
        // kiểm tra đường dẫn và loại file
        string extension = System.IO.Path.GetExtension(FileUploadField1.PostedFile.FileName).ToLower();
        if (!extension.Equals(".xls") && !extension.Equals(".xlsx"))
        {
            X.Msg.Alert("Thông báo", "Hãy chọn file excel").Show();
            return;
        }
        string fn = System.IO.Path.GetFileName(FileUploadField1.PostedFile.FileName);
        string saveLocation = Server.MapPath("Files") + "\\" + fn;

        // đọc quy ước chấm công trong bảng DM_TT_LAMVIEC
        HashSet<string> ds = new HashSet<string>();
        List<DAL.DM_TT_LAMVIEC> lists = new KyHieuChamCongController().GetAll();
        foreach (var item in lists)
        {
            ds.Add(item.KYHIEU_TT_LAMVIEC.ToLower());
        }

        var excel = new ExcelQueryFactory();
        excel.FileName = saveLocation;

        // get config
        string startCell = "";
        string endCell = "";
        getConfig(out startCell, out endCell);

        // đọc file excel
        var datas = from x in excel.WorksheetRangeNoHeader(startCell, endCell, cbSheetName.Value.ToString())
                    select x;

        string invalidSymbol = "";
        foreach (var item in datas)
        {
            if (item[0] == "")
                break;
            for (int i = 0; i < item.Count; i++)
            {
                if (i >= 2 && !string.IsNullOrEmpty(item[i]) && !ds.Contains(item[i].ToString().ToLower()))
                {
                    invalidSymbol += item[i] + ", ";
                }
            }
        }

        if (AfterClickTestData != null)
        {
            AfterClickTestData(invalidSymbol, null);
        }

        if (invalidSymbol == "")
        {
            btnTestDuLieu.Hide();
            btnImport.Show();
        }
    }
}