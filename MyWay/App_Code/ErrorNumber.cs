using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ErrorCode
/// </summary>
public class ErrorNumber
{
    public ErrorNumber()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public const int DUPLICATE_PRIMARY_KEY = 2627;
    public const int DATA_IS_INUSED_IN_OTHER_TABLE = 50000;
    public const int CONFLICT_FOREIGN_KEY = 547;
}