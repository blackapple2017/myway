using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Ext.Net;
using System.IO;
using ExtMessage;
using SoftCore.AccessHistory;
using SoftCore.Security;
using WebUI.Interface;
using SoftCore;
using System.Xml.Linq;
using DataController;
using LinqToExcel;

public partial class Modules_Base_ImportExcelFile_ImportExcelFile : UserControlBase, IWindow, IControl
{
    #region các thuộc tính
    /// <summary>
    /// File Excel mẫu dùng để nhập liệu đối với từng bảng CSDL
    /// </summary>
    public string ExcelTemplateUrl { get; set; }
    /// <summary>
    /// Vị trí lưu file Excel khi file được tải lên Server
    /// </summary>
    public string ExcelStoreFolder { get; set; }
    /// <summary>
    /// Xóa file Excel ngay sau khi Insert dữ liệu vào CSDL
    /// </summary>
    public bool DeleteExcelAfterInsert { get; set; }
    /// <summary>
    /// Bảng trong CSDL cần được Insert
    /// </summary>
    public string TableName { get; set; }
    /// <summary>
    /// Khóa chính của bảng
    /// </summary>
    public string PrimaryKeyName { get; set; }
    /// <summary>
    /// Khóa chính tự tăng hay không 
    /// </summary>
    public bool PrKeyIsAutoIncrement { get; set; }
    /// <summary>
    /// File XML chứa các qui tắc cho việc khớp nối
    /// </summary>
    public string MathRuleXmlUrl { get; set; }
    /// <summary>
    /// Danh sách các bảng danh mục đi kèm
    /// </summary>
    public string ListCategoriesTableName { get; set; }
    /// <summary>
    /// Số lượng bản ghi lớn nhất
    /// </summary>
    public int MaxRecord { get; set; }

    private List<MathRule> ruleList;
    #endregion

    private static Dictionary<string, string> dictionary;

    protected void Page_Load(object sender, EventArgs e)
    {

    }

    #region Button Next, Previous
    protected void Next_Click(object sender, DirectEventArgs e)
    {
        int index = int.Parse(e.ExtraParams["index"]);
        switch (index)
        {
            case 0:
                if (fUpload.HasFile == false)
                {
                    return;
                }
                //UploadFile();
                break;
            case 1:
                int chk = checkLoiKhopNoi();
                if (chk == 0)
                    InsertData();
                else if (chk < 0)
                {
                    X.Msg.Alert("Thông báo", "Có " + -chk + " cột bắt buộc nhập chưa được chọn").Show();
                    return;
                }
                else
                {
                    X.Msg.Alert("Thông báo", "Có " + chk + " cột bắt buộc nhập chưa được chọn").Show();
                    return;
                }
                break;
        }
        if ((index + 1) < this.WizardPanel.Items.Count)
        {
            this.WizardPanel.ActiveIndex = index + 1;
        }

        this.CheckButtons();
    }

    protected void Prev_Click(object sender, DirectEventArgs e)
    {
        int index = int.Parse(e.ExtraParams["index"]);

        if ((index - 1) >= 0)
        {
            this.WizardPanel.ActiveIndex = index - 1;
        }

        this.CheckButtons();
    }

    private void CheckButtons()
    {
        int index = this.WizardPanel.ActiveIndex;

        this.btnNext.Disabled = index == (this.WizardPanel.Items.Count - 1);
        this.btnPrev.Disabled = index == 0;
    }

    private void InsertData()
    {
        #region chuẩn bị
        //if (ruleList == null)
        ruleList = new XMLProcess().GetAll(XDocument.Load(Server.MapPath(MathRuleXmlUrl)));
        string sql = "insert into " + this.TableName + "({0}) values";
        string strUpdate = "update " + this.TableName + " set {0} where {1}";
        string col = "";

        List<MathRule> mr = new List<MathRule>();
        //Lấy ra các cột cần insert
        foreach (var item in RowSelectionModel1.SelectedRows)
        {
            col += "[" + item.RecordID + "],";
            MathRule mathRule = ruleList.Where(t => t.ColumnInDB == item.RecordID).FirstOrDefault();
            if (mathRule != null && mathRule.ColumnInExcel != "")
            {
                mr.Add(new MathRule()
                {
                    ColumnInDB = item.RecordID,
                    ColumnInExcel = mathRule.ColumnInExcel,
                    DataType = mathRule.DataType,
                    AllowBlank = mathRule.AllowBlank,
                    DisplayOnGrid = mathRule.DisplayOnGrid,
                    DefaultValue = mathRule.DefaultValue
                });
            }
        }
        //col += "[MA_DONVI],";
        if (col.LastIndexOf(",") != -1)
            sql = string.Format(sql, col.Remove(col.LastIndexOf(",")));

        string ExcelFileName = Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName;
        //Lấy các cột trong file Excel
        IEnumerable<string> ColumnInExcelFile = ExcelEngine.GetInstance().GetColumnName(ExcelFileName, cbSheetName.SelectedItem.Value);
        int completedRows = 0, updatedRows = 0;
        int errorLine = 1;
        List<object> errorData = new List<object>();
        #endregion

        List<Row> dataExcel = null;
        dataExcel = ExcelEngine.GetInstance().GetDataFromExcel(ExcelFileName, cbSheetName.SelectedItem.Value, 0, MaxRecord);

        #region lấy dữ liệu và insert
        foreach (var row in dataExcel)
        {
            bool isExist = false;   // đã tồn tại mã cán bộ hay chưa
            if (string.IsNullOrEmpty(row[0]))
                break;
            // lấy Trường mã cán bộ trong file Excel
            MathRule mr1 = ruleList.Where(t => t.ColumnInDB == "MA_CB").FirstOrDefault();
            DAL.HOSO hs = new HoSoController().GetByMaCB(row[mr1.ColumnInExcel]);
            if (hs != null)
                isExist = true;

            string v = "", u = "";
            foreach (MathRule rule in mr)
            {
                // bỏ qua prkey tự tăng
                if (rule.ColumnInDB.Equals("PR_KEY"))
                    continue;

                if (rule.DisplayOnGrid == false && string.IsNullOrEmpty(rule.DefaultValue) == false)
                {
                    if (isExist == true)
                    {
                        if (rd_CapNhatBanGhiTonTai.Checked == true)
                            u += "[" + rule.ColumnInDB + "] = N'" + GetDefaultValue(rule.DefaultValue) + "',";
                    }
                    else
                        v += "N'" + GetDefaultValue(rule.DefaultValue) + "',";
                    continue;
                }
                if (rule.ColumnInExcel.Contains(";") == false)
                {
                    string vTmp = row[rule.ColumnInExcel].ToString();
                    if (string.IsNullOrEmpty(vTmp))
                        vTmp = GetDefaultValue(rule.DefaultValue);
                    vTmp = GetCastedData(rule.DataType.ToLower(), vTmp);
                    if (vTmp == "$$$")
                    {
                        errorData.Add(new
                        {
                            Data = row[rule.ColumnInExcel].ToString(),
                            ErrorMessage = "Dữ liệu tại cột \"" + rule.ColumnInExcel + "\" dòng " + (errorLine + 1) + " trong tệp tin excel chưa tồn tại trong danh mục.",
                            LineInExcel = errorLine,
                        });
                        continue;
                    }
                    if (isExist == true)
                    {
                        if (rd_CapNhatBanGhiTonTai.Checked == true)
                            u += "[" + rule.ColumnInDB + "] = N'" + vTmp + "',";
                    }
                    else
                        v += "N'" + vTmp + "',";
                }
                else
                {
                    string[] tmp = rule.ColumnInExcel.Split(';');
                    foreach (var item in tmp)
                    {
                        if (string.IsNullOrEmpty(item) == false && ColumnInExcelFile.Contains(item))
                        {
                            if (string.IsNullOrEmpty(row[item].ToString()))
                            {
                                if (isExist == true)
                                {
                                    if (rd_CapNhatBanGhiTonTai.Checked == true)
                                        u += "[" + rule.ColumnInDB + "] = N'" + GetDefaultValue(rule.DefaultValue) + "',";
                                }
                                else
                                    v += "N'" + GetDefaultValue(rule.DefaultValue) + "',";
                            }
                            else
                            {
                                string tmp1 = GetCastedData(rule.DataType.ToLower(), row[item]);
                                if (tmp1 == "$$$")
                                {
                                    errorData.Add(new
                                    {
                                        Data = row[item].ToString(),
                                        ErrorMessage = "Dữ liệu tại cột \"" + rule.ColumnInExcel + "\" dòng " + (errorLine + 1) + " trong tệp tin excel chưa tồn tại trong danh mục.",
                                        LineInExcel = errorLine,
                                    });
                                    continue;
                                }
                                if (isExist == true)
                                {
                                    if (rd_CapNhatBanGhiTonTai.Checked == true)
                                        u += "[" + rule.ColumnInDB + "] = N'" + tmp1 + "',";
                                }
                                else
                                    v += "N'" + tmp1 + "',";
                            }
                            break;
                        }
                        else
                        {
                            //v += "N'',";
                        }
                    }
                }
            }
            //v += "N'" + Session["MaDonVi"] + "',";
            errorLine++;
            try
            {
                // insert
                string query = string.Empty;
                if (v != "")
                {
                    if (v.LastIndexOf(",") != -1)
                        query = sql + "(" + v.Remove(v.LastIndexOf(",")) + ")";
                    DataHandler.GetInstance().ExecuteNonQuery(query);
                    completedRows++;
                }
                // update
                if (u != "")
                {
                    string queryUpdate = string.Empty;
                    if (u.LastIndexOf(",") != -1)
                    {
                        queryUpdate = string.Format(strUpdate, u.Remove(u.LastIndexOf(",")), " MA_CB = N'" + row[mr1.ColumnInExcel] + "'");
                    }
                    DataHandler.GetInstance().ExecuteNonQuery(queryUpdate);
                    updatedRows++;
                }
            }
            catch (Exception ex)
            {
                string Er = string.Empty;
                if (ex.Message.Contains("Cannot insert duplicate key in object"))
                    Er = GlobalResourceManager.GetInstance().GetErrorMessageValue("DuplicateKey");
                else if (ex.Message.Contains("Error converting data type nvarchar to numeric."))
                {
                    Er = GlobalResourceManager.GetInstance().GetErrorMessageValue("NvarcharToNumeric");
                }
                else if (ex.Message.Contains("Conversion failed when converting date and/or time from character string."))
                {
                    Er = GlobalResourceManager.GetInstance().GetErrorMessageValue("DateFromString");
                }
                else
                    Er = ex.Message;
                errorData.Add(new
                {
                    Data = v.Replace("N", "").Replace("'", ""),
                    ErrorMessage = Er,
                    LineInExcel = errorLine,
                });
            }
        }
        #endregion

        // delete file
        FileInfo file = new FileInfo(ExcelFileName);
        if (file.Exists)
            file.Delete();

        #region thông báo kết quả insert
        lblCompletedRow.Html = "<span style='color:#15428B;font-weight:bold;display:block;margin-bottom:6px;'>Tổng số dòng được thêm thành công : " + completedRows + " dòng</span>";
        if (updatedRows > 0)
        {
            lblUpdatedRow.Html = "<span style='color:#15428B;font-weight:bold;display:block;margin-bottom:6px;'>Tổng số dòng được cập nhật thành công : " + updatedRows + " dòng</span>";
        }
        else
            lblUpdatedRow.Html = "";
        // lblError.Text = "Tổng số dòng bị lỗi : " + errorData.Count();
        grp_ErrorRows.Title = "Tổng số dòng bị lỗi : " + errorData.Count() + " dòng";
        Store2.DataSource = errorData;
        Store2.DataBind();
        #endregion
    }

    /// <summary>
    /// Lấy các giá trị mặc định của file Excel
    /// </summary>
    /// <param name="p"></param>
    /// <returns></returns>
    private string GetDefaultValue(string p)
    {
        switch (p)
        {
            case "CreatedDate":
                return DateTime.Now.Month + "/" + DateTime.Now.Day + "/" + DateTime.Now.Year;
            case "CreatedUser":
                return CurrentUser.ID.ToString();
            default:
                return p;
        }
    }

    /// <summary>
    /// Lấy dữ liệu đã được ép kiểu, ví dụ trong file Excel cột giới tính là Nam, Nữ thì phải ép thành M, F
    /// </summary>
    /// <param name="p"></param>
    /// <param name="vTmp"></param>
    /// <returns></returns>
    private string GetCastedData(string p, string vTmp)
    {
        try
        {
            switch (p)
            {
                case "datetime":
                    if (vTmp.Contains("SA") || vTmp.Contains("CH"))
                    {
                        vTmp = vTmp.Replace("SA", "AM").Replace("CH", "PM");
                    }
                    DateTime dt = DateTime.Parse(vTmp);
                    vTmp = dt.Year + "-" + dt.Month + "-" + dt.Day;
                    break;
                case "float":
                case "double":
                    vTmp = vTmp.Replace(",", ".");
                    break;
                case "gender":
                case "Gender":
                    if (vTmp.Contains("Nam") || vTmp.Contains("nam"))
                        vTmp = vTmp.Replace("Nam", "M").Replace("nam", "M");
                    else if (vTmp.Contains("Nữ") || vTmp.Contains("nữ"))
                        vTmp = vTmp.Replace("Nữ", "F").Replace("nữ", "F");
                    break;
                case "bit":
                case "boolean":
                case "bool":
                    if (vTmp.Contains("Có") || vTmp.Contains("có"))
                        vTmp = vTmp.Replace("Có", "1").Replace("có", "1");
                    if (vTmp.Contains("Không") || vTmp.Contains("không"))
                        vTmp = vTmp.Replace("Không", "1").Replace("không", "1");
                    break;
                case "married":
                    if (vTmp.Contains("Chưa kết hôn"))
                        vTmp = vTmp.Replace("Chưa kết hôn", "01");
                    else if (vTmp.Contains("Đã kết hôn"))
                        vTmp = vTmp.Replace("Đã kết hôn", "02");
                    else if (vTmp.Contains("Đã ly hôn"))
                        vTmp = vTmp.Replace("Đã ly hôn", "03");
                    break;
                case "danhmuc":
                    if (dictionary.ContainsKey(vTmp.ToLower().Trim()))
                    {
                        vTmp = dictionary[vTmp.ToLower().Trim()];
                    }
                    else
                    {
                        vTmp = "$$$";
                    }
                    break;
            }
            return vTmp;
        }
        catch (Exception ex)
        {
            return "$$$";
        }
    }

    private int checkLoiKhopNoi()
    {
        ruleList = new XMLProcess().GetAll(XDocument.Load(Server.MapPath(MathRuleXmlUrl)));
        ruleList = ruleList.Where(t => t.AllowBlank == "false").ToList();

        // kiểm tra đã chọn các cột bắt buộc nhập hay chưa
        int chuachon = 0;
        foreach (MathRule item in ruleList)
        {
            foreach (var it in RowSelectionModel1.SelectedRows)
            {
                if (item.ColumnInDB == it.RecordID)
                {
                    chuachon++;
                    break;
                }
            }
        }
        if (chuachon < ruleList.Count)
            return chuachon - ruleList.Count + 1;

        //Lấy các cột trong file Excel
        List<string> ColumnInExcelFile = ExcelEngine.GetInstance().GetColumnName(Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName, cbSheetName.SelectedItem.Value).ToList();
        int count = 0;
        foreach (MathRule item in ruleList)
        {
            if (item.ColumnInExcel.Contains(";"))
            {
                string[] arr = item.ColumnInExcel.Split(';');
                int k = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    if (ColumnInExcelFile.Contains(arr[i].Trim()))
                    {
                        k++;
                    }
                }
                if (k > 0)
                    count++;
            }
            else
            {
                if (ColumnInExcelFile.Contains(item.ColumnInExcel.Trim()))
                {
                    count++;
                }
            }
        }

        if (count == ruleList.Count - 1)
        {
            return 0;
        }

        return ruleList.Count - count - 1;
    }
    #endregion

    [DirectMethod]
    public void DeleteFileExcel()
    {
        try
        {
            if (this.DeleteExcelAfterInsert)
            {
                FileInfo f = new FileInfo(Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName);
                if (f.Exists)
                    f.Delete();
            }
        }
        catch
        {
        }
    }

    /// <summary>
    /// Create dictionary
    /// </summary>
    [DirectMethod]
    public void CreateDictionary()
    {
        List<StoreComboObject> list = new List<StoreComboObject>();
        dictionary = new Dictionary<string, string>();
        // lấy danh sách các bảng danh mục
        string[] dsDanhMuc = ListCategoriesTableName.Split(',');
        foreach (var it in dsDanhMuc)
        {
            switch (it.Trim())
            {
                case "DM_TT_HN":    // DM_TT_HN
                    list = new DM_TT_HNController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TINHTHANH":    // DM_TinhThanh
                    list = new DM_TINHTHANHController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NUOC":     // DM_NUOC
                    list = new DM_NUOCController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_DANTOC":   // DM_DANTOC
                    list = new DM_DANTOCController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TONGIAO":  // DM_TONGIAO
                    list = new DM_TONGIAOController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TT_SUCKHOE":   // DM_TT_SUCKHOE
                    list = new DM_TT_SUCKHOEController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TRINHDO":  // DM_TRINHDO
                    list = new DM_TRINHDOController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TD_VANHOA":    // DM_TD_VANHOA
                    list = new DM_TD_VANHOAController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NGOAINGU":     // DM_NGOAINGU
                    list = new DM_NGOAINGUController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TINHOC":   // DM_TINHOC
                    list = new DM_TINHOCController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CHUCVU":   // DM_CHUCVU
                    list = new DanhMucChucVuController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NGACH":    // DM_NGACH
                    list = new DM_NGACHController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_DONVI":    // DM_DONVI
                    list = new DM_DONVIController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NOICAP_CMND":  // DM_NOICAP_CMND
                    list = new DM_NOICAP_CMNDController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_LOAI_HDONG":   // DM_LOAI_HDONG
                    list = new DM_LOAI_HDONGController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CONGVIEC":     // DM_CONGVIEC
                    list = new DM_CONGVIECController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CHUYENNGANH":  // DM_CHUYENNGANH
                    list = new DM_CHUYENNGANHController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TP_BANTHAN":   // DM_TP_BANTHAN
                    list = new DM_TP_BANTHANController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TP_GIADINH":   // DM_TP_GIADINH
                    list = new DM_TP_GIADINHController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NOICAP_HOCHIEU":   // DM_NOICAP_HOCHIEU
                    list = new DM_NOICAP_HOCHIEUController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TRUONG_DAOTAO":    // DM_TRUONG_DAOTAO
                    list = new DM_TRUONG_DAOTAOController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_XEPLOAI":  // DM_XEPLOAI
                    list = new DM_XEPLOAIController().GetAll1();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_HT_TUYENDUNG":     // DM_HT_TUYENDUNG
                    list = new DM_HT_TUYENDUNGController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CONGTRINH":    // DM_CONGTRINH
                    list = new DM_CONGTRINHController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_LOAI_CS":      // DM_LOAI_CS
                    list = new DM_LOAI_CSController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NOI_KCB":  // DM_NOI_KCB
                    list = new DM_NOI_KCBController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NOICAP_BHXH":  // DM_NOICAP_BHXH
                    list = new DM_NOICAPBAOHIEMXHController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TD_CHINHTRI":  // DM_TD_CHINHTRI
                    list = new DM_TD_CHINHTRIController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CHUCVU_DANG":  // DM_CHUCVU_DANG
                    list = new DM_CHUCVU_DANGController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CHUCVU_DOAN":  // DM_CHUCVU_DOAN
                    list = new DM_CHUCVU_DOANController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_BAC_QDOI":     // DM_BAC_QDOI
                    list = new DM_CAPBAC_QDOIController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_CHUCVU_QDOI":  // DM_CHUCVU_QDOI
                    list = new DM_CHUCVU_QDOIController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TD_QUANLY":    // DM_TD_QUANLY
                    list = new DM_TD_QUANLYController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_TD_QLKT":  // DM_TD_QLKT
                    list = new DM_TD_QLKTController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_NH":   // DM_NH
                    list = new DM_NGANHANGController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
                case "DM_LYDO_NGHI":    // DM_LYDO_NGHI
                    list = new DM_LYDO_NGHIController().GetAll();
                    foreach (var item in list)
                        if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                            dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
                    break;
            }
        }
    }

    private string getColumnInExcel(List<string> excelInTuDien, List<string> excelInColumnExcel)
    {
        string rs = string.Empty;
        foreach (var item in excelInColumnExcel)
        {
            if (excelInTuDien.Contains(item))
            {
                rs = item;
                break;
            }
        }
        return rs;
    }

    public void btnCreateMathRuleFile_Click(object sender, DirectEventArgs e)
    {
        try
        {
            new XMLProcess().CreateNewMathRuleFile(Server.MapPath(MathRuleXmlUrl), TableName);
        }
        catch (Exception ex)
        {
            Dialog.ShowError("ExcelReader/btnCreateMathRuleFile_Click = " + ex.Message);
        }
    }

    /// <summary>
    /// Load khớp nối các cột
    /// </summary>
    /// <param name="sender"></param>
    /// <param name="e"></param>
    protected void MyData_Refresh(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            if (new FileInfo(Server.MapPath(MathRuleXmlUrl)).Exists == false)
            {
                Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("MathRuleFileNotExist"));
                return;
            }
            if (fUpload.HasFile == false)
                return;

            //Load các qui tắc khớp nối ở file XML
            ruleList = new XMLProcess().GetAll(XDocument.Load(Server.MapPath(MathRuleXmlUrl)), true); //chuyển thành true

            //Lấy các cột trong file Excel
            IEnumerable<string> ColumnInExcelFile = ExcelEngine.GetInstance().GetColumnName(Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName, cbSheetName.SelectedItem.Value);

            List<object> objData = new List<object>();
            foreach (string item in ColumnInExcelFile)
            {
                objData.Add(new { ColumnName = item });
            }
            ColumnStore.DataSource = objData;
            ColumnStore.DataBind();

            //List<string> listsID = new List<string>();
            List<object> db = new List<object>();
            foreach (var item in ruleList)
            {
                string mMathStatus = "false";

                List<string> lists = new List<string>();
                string[] objs = item.ColumnInExcel.Split(';');
                for (int i = 0; i < objs.Length; i++)
                {
                    lists.Add(objs[i].Trim());
                }

                string excelColumnName = getColumnInExcel(lists, ColumnInExcelFile.ToList());
                if (excelColumnName != "")
                    mMathStatus = "true";
                db.Add(new MathRule
                {
                    ColumnInDB = item.ColumnInDB,
                    ColumnInSoftware = item.ColumnInSoftware,
                    ColumnInExcel = excelColumnName,
                    AllowBlank = item.AllowBlank,
                    MathStatus = mMathStatus,
                    DataType = item.DataType,
                });
                if (mMathStatus == "false")
                    hdfMathStatus.Text += item.ColumnInDB + ", ";
            }
            Store1.DataSource = db;
            Store1.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("DefaultErrorMessage"));

            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("MathColumnInExcel"),
                MOTA = "ExcelReader/MyData_Refresh = " + ex.Message.Replace("'", ""),
                IsError = true,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
    }

    protected void HandleChanges(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<MathRule> mathRule = e.DataHandler.ObjectData<MathRule>();
        XMLProcess xmlProcess = new XMLProcess();
        foreach (var item in mathRule.Updated)
        {
            xmlProcess.Update(Server.MapPath(MathRuleXmlUrl), item);
            GridPanel1.UpdateCell(item.ColumnInDB, "MathStatus", "true");
            if (Store1.UseIdConfirmation)
            {
                e.ConfirmationList.ConfirmRecord(item.ColumnInDB.ToString());
            }
            hdfMathStatus.Text = hdfMathStatus.Text.Replace(item.ColumnInDB + ",", "");
        }
    }

    protected void RefreshData(object sender, StoreRefreshDataEventArgs e)
    {
        try
        {
            List<MathRule> tudien = new XMLProcess().GetAll(XDocument.Load(Server.MapPath(MathRuleXmlUrl)), true);
            List<object> obj = new List<object>();
            foreach (var item in tudien)
            {
                obj.Add(new { ColumnInDB = item.ColumnInDB, ColumnInSoftware = item.ColumnInSoftware, ColumnInExcel = item.ColumnInExcel, AllowBlank = item.AllowBlank, MathStatus = item.MathStatus, DataType = item.DataType });
            }
            Store3.DataSource = obj;
            Store3.DataBind();
        }
        catch (Exception ex)
        {
            Dialog.ShowError(ex.Message.ToString());
        }
    }

    protected void HandleChangesTuDien(object sender, BeforeStoreChangedEventArgs e)
    {
        ChangeRecords<MathRule> mathRule = e.DataHandler.ObjectData<MathRule>();
        XMLProcess xmlProcess = new XMLProcess();
        foreach (var item in mathRule.Updated)
        {
            xmlProcess.UpdateTuDien(Server.MapPath(MathRuleXmlUrl), item);
            GridPanel2.UpdateCell(item.ColumnInDB, "MathStatus", "true");
            if (Store3.UseIdConfirmation)
            {
                e.ConfirmationList.ConfirmRecord(item.ColumnInDB.ToString());
            }
            hdfMathStatus.Text = hdfMathStatus.Text.Replace(item.ColumnInDB + ",", "");
        }
    }

    protected void btnDownloadExcel_Click(object sender, DirectEventArgs e)
    {
        try
        {
            string fileName = Server.MapPath(ExcelTemplateUrl);
            System.IO.FileInfo file = new System.IO.FileInfo(fileName);

            if (file.Exists)
            {
                Response.Clear();
                Response.ContentType = "application/octet-stream";
                Response.AddHeader("Content-Disposition", "attachment; filename=" + ExcelTemplateUrl.Substring(ExcelTemplateUrl.LastIndexOf("/") + 1));
                Response.WriteFile(Server.MapPath(ExcelTemplateUrl));
                Response.End();
            }
            else
            {
                X.Msg.Alert("Thông báo", "File mẫu không tồn tại").Show();
            }
        }
        catch (Exception ex)
        {
            Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("DefaultErrorMessage"));

            NhatkyTruycapInfo accessDiary = new NhatkyTruycapInfo()
            {
                CHUCNANG = GlobalResourceManager.GetInstance().GetHistoryAccessValue("DownloadExcel"),
                MOTA = "ExcelReader/btnDownloadExcel_Click = " + ex.Message.Replace("'", ""),
                IsError = true,
                USERNAME = CurrentUser.UserName,
                THOIGIAN = DateTime.Now,
                MANGHIEPVU = "",
                TENMAY = Util.GetInstance().GetComputerName(Request.UserHostAddress),
                IPMAY = Request.UserHostAddress,
                THAMCHIEU = "",
            };
            new SoftCore.AccessHistory.AccessHistoryController().AddAccessHistory(accessDiary);
        }
    }

    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = fUpload.PostedFile;

            if (file.ContentType != "application/vnd.ms-excel") //ko phải Excel 2003
            {
                Dialog.ShowError(GlobalResourceManager.GetInstance().GetErrorMessageValue("NotExcel2003"));
                return;
            }
            if (fUpload.HasFile == false && file.ContentLength > 2000000)
            {
                Dialog.ShowNotification("File không được lớn hơn 200kb");
                return;
            }
            else
            {
                string path = string.Empty;
                try
                {
                    DirectoryInfo dir = new DirectoryInfo(Server.MapPath(ExcelStoreFolder));
                    if (dir.Exists == false)
                        dir.Create();
                    path = Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName;
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
            hdfMathStatus.Text = "";
            if (new FileInfo(Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName).Exists)
            {
                List<object> sheetData = new List<object>();
                IEnumerable<string> sheetname = ExcelEngine.GetInstance().GetAllSheetName(Server.MapPath(ExcelStoreFolder + "/") + fUpload.FileName);
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

    public void Show()
    {
        wdImportDataFromExcel.Show();
    }

    public string GetID()
    {
        return wdImportDataFromExcel.ClientID;
    }

    public object GetValue()
    {
        throw new NotImplementedException();
    }

    public void SetValue(object value)
    {
        throw new NotImplementedException();
    }
}