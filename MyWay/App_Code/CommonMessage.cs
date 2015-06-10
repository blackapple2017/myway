using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for CommonMessage
/// </summary>
public class CommonMessage
{
	public CommonMessage()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public const string INSERT_SUCCESSFULLY = "Cập nhật thành công!";
    public const string UPDATE_PG_ERROR = "Đã có thông tin PG trong dự án!";
    public const string UPDATE_EXPECT_ERROR = "Đã có thông tin về dự kiến doanh thu của khu vực này trong tháng!";
    public const string UPDATE_CUSTOMER_ERROR = "Mã khách hàng đã bị trùng!";
}