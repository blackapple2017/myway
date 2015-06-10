using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using SoftCore.Security;
using Ext.Net;
using WebUI.Interface;
using ExtMessage;
using System.IO;
using DataController;
using System.Data;
using System.Xml.Linq;
using SoftCore.AccessHistory;
using SoftCore;
using System.Xml.Xsl;
using LinqToExcel;

public partial class Modules_Base_ExcelReader_ExcelReader : UserControlBase, IWindow, IControl
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
    /// Số dòng tối đa được lấy từ file Excel để lưu vào CSDL
    /// </summary>
    public int MaxRecord { get; set; }
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
    private List<MathRule> ruleList;
    #endregion

    private static Dictionary<string, string> dictionary;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!X.IsAjaxRequest)
        {
            if (CurrentUser.IsSuperUser == false)
            {
                //  btnCreateMathRuleFile.Visible = false;
            }
        }
    }

    #region CardLayout
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

    /// <summary>
    /// Create dictionary
    /// </summary>
    [DirectMethod]
    public void CreateDictionary()
    {
        List<StoreComboObject> list = new List<StoreComboObject>();
        dictionary = new Dictionary<string, string>();
        // DM_TT_HN
        list = new DM_TT_HNController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TinhThanh
        list = new DM_TINHTHANHController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NUOC
        list = new DM_NUOCController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_DANTOC
        list = new DM_DANTOCController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TONGIAO
        list = new DM_TONGIAOController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TT_SUCKHOE
        list = new DM_TT_SUCKHOEController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TRINHDO
        list = new DM_TRINHDOController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TD_VANHOA
        list = new DM_TD_VANHOAController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TD_NGOAINGU
        list = new DM_NGOAINGUController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TD_TINHOC
        list = new DM_TINHOCController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CHUCVU
        list = new DanhMucChucVuController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NGACH
        list = new DM_NGACHController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_DONVI
        list = new DM_DONVIController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NOICAP_CMND
        list = new DM_NOICAP_CMNDController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_LOAI_HDONG
        list = new DM_LOAI_HDONGController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CONGVIEC
        list = new DM_CONGVIECController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CHUYENNGANH
        list = new DM_CHUYENNGANHController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TP_BANTHAN
        list = new DM_TP_BANTHANController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TP_GIADINH
        list = new DM_TP_GIADINHController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NOICAP_HOCHIEU
        list = new DM_NOICAP_HOCHIEUController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TRUONG_DAOTAO
        list = new DM_TRUONG_DAOTAOController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_XEPLOAI
        list = new DM_XEPLOAIController().GetAll1();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_HT_TUYENDUNG
        list = new DM_HT_TUYENDUNGController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CONGTRINH
        list = new DM_CONGTRINHController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_LOAI_CS
        list = new DM_LOAI_CSController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NOI_KCB
        list = new DM_NOI_KCBController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NOICAP_BHXH
        list = new DM_NOICAPBAOHIEMXHController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TD_CHINHTRI
        list = new DM_TD_CHINHTRIController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CHUCVU_DANG
        list = new DM_CHUCVU_DANGController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CHUCVU_DOAN
        list = new DM_CHUCVU_DOANController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_BAC_QDOI
        list = new DM_CAPBAC_QDOIController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_CHUCVU_QDOI
        list = new DM_CHUCVU_QDOIController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TD_QUANLY
        list = new DM_TD_QUANLYController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_TD_QLKT
        list = new DM_TD_QLKTController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_NH
        list = new DM_NGANHANGController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // DM_LYDO_NGHI
        list = new DM_LYDO_NGHIController().GetAll();
        foreach (var item in list)
            if (!dictionary.ContainsKey(item.TEN.ToLower().Trim()))
                dictionary.Add(item.TEN.ToLower().Trim(), item.MA);
        // HinhThucLamViec
        //IEnumerable<DAL.ThamSoTrangThai> lt = new ThamSoTrangThaiController().GetByParamName("HinhThucLamViec", true);
        //foreach (var item in lt)
        //{
        //    if (!dictionary.ContainsKey(item.Value.ToLower().Trim()))
        //        dictionary.Add(item.Value.ToLower().Trim(), item.ID.ToString());
        //}
    }

    //private bool KiemTraKetNoi()
    //{
    //    bool isChecked = false;
    //    List<MathRule> lists = new XMLProcess().GetAllByMathStatus(XDocument.Load(Server.MapPath(MathRuleXmlUrl)), false);
    //    foreach (var item in lists)
    //    {
    //        if (item)
    //    }
    //    return isChecked;
    //}

    private void InsertData()
    {
        try
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
            //col += "[HinhThucLamViec],";
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
            //if (AllRows.Checked)
            //{
            //    dataExcel = ExcelEngine.GetInstance().GetDataFromExcel(ExcelFileName, cbSheetName.SelectedItem.Value, 0, 10);
            //}
            //else if (rdInsideRange.Checked)
            //{ 

            //}
            //else if (rdOutRange.Checked)
            //{

            //}
            //else if (rdSomeRows.Checked)
            //{
            //    dataExcel = ExcelEngine.GetInstance().GetSomeRowFromExcel(ExcelFileName, cbSheetName.SelectedItem.Value, txtSomeNumbers.Text);
            //}

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
                            {
                                string value = "";
                                value = (rule.DataType.ToLower() == "datetime" && vTmp == "NULL") ? "NULL," : "N'" + vTmp + "',";
                                u += "[" + rule.ColumnInDB + "] = " + value;
                            }
                        }
                        else
                        {
                            string value = "";
                            value = (rule.DataType.ToLower() == "datetime" && vTmp == "NULL") ? "NULL," : "N'" + vTmp + "',";
                            v += value;
                        }
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
                                        {
                                            string value = "";
                                            value = (rule.DataType.ToLower() == "datetime" && tmp1 == "NULL") ? "NULL," : "N'" + tmp1 + "',";
                                            u += "[" + rule.ColumnInDB + "] = " + value;
                                        }
                                    }
                                    else
                                    {
                                        string value = "";
                                        value = (rule.DataType.ToLower() == "datetime" && tmp1 == "NULL") ? "NULL," : "N'" + tmp1 + "',";
                                        v += value;
                                    }
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
                //v += "N'Làm cả ngày',";
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
        catch (Exception ex)
        {
            X.Msg.Alert("Thông báo từ hệ thống", "Có lỗi xảy ra: " + ex.Message).Show();
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
            vTmp = vTmp.Trim();
            switch (p)
            {
                case "datetime":
                    if (vTmp.Contains("SA") || vTmp.Contains("CH"))
                    {
                        vTmp = vTmp.Replace("SA", "AM").Replace("CH", "PM");
                    }
                    if (string.IsNullOrEmpty(vTmp))
                    {
                        vTmp = "NULL";
                    }
                    else
                    {
                        DateTime dt = DateTime.Parse(vTmp);
                        vTmp = dt.Year + "-" + dt.Month + "-" + dt.Day;
                    }
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
                    else
                        vTmp = "M";
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
                    else if (dictionary.ContainsValue(vTmp.Trim()) || vTmp.Trim() == "")
                    {
                        break;
                    }
                    else
                    {
                        vTmp = "$$$";
                    }
                    break;
            }
            return vTmp;
        }
        catch
        {
            return "$$$";
        }
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

    private void BindData(DataTable dataTable)
    {
        if (dataTable == null)
            return;
        foreach (DataColumn col in dataTable.Columns)
        {
            cbColumnInExcel.Items.Add(new Ext.Net.ListItem()
            {
                Text = col.ColumnName,
                Value = col.ColumnName
            });
        }
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
    #endregion

    private void UploadFile()
    {
        try
        {
            //upload file 
            HttpPostedFile file = fUpload.PostedFile;

            if (file.FileName.IndexOf(".xls") == -1) //ko phải Excel 2003
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

    protected void btnDownloadExcel_Click(object sender, DirectEventArgs e)
    {
        try
        {
            Response.Clear();
            Response.ContentType = "application/octet-stream";
            Response.AddHeader("Content-Disposition", "attachment; filename=" + ExcelTemplateUrl.Substring(ExcelTemplateUrl.LastIndexOf("/") + 1));
            Response.WriteFile(Server.MapPath(ExcelTemplateUrl));
            Response.End();
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

    //protected void btnCheckInsert_Click(object sender, DirectEventArgs e)
    //{
    //    int chk = checkLoiKhopNoi();

    //    if (chk == 0)
    //    {
    //        Dialog.ShowNotification("Không có lỗi khớp nối");
    //    }
    //    else
    //    {
    //        Dialog.ShowNotification(string.Format("Có {0} cột bắt buộc nhập chưa được khớp nối", chk));
    //    }
    //}

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