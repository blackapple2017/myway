using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Configuration;


/// <summary>
/// Summary description for GlobalManager
/// </summary>
public class GlobalResourceManager
{
    public GlobalResourceManager()
    {
        Instance = null;
    }

    private static GlobalResourceManager Instance;

    public static GlobalResourceManager GetInstance()
    {
        if (Instance == null)
            Instance = new GlobalResourceManager();
        return Instance;
    }
    // language
    public string GetLanguageValue(string Key, System.Globalization.CultureInfo ci)
    {
        return Resources.Language.ResourceManager.GetString(Key, ci);
    }

    public string GetLanguageValue(string Key)
    {
        return Resources.Language.ResourceManager.GetString(Key);
    }
    // desktop
    public string GetDesktopValue(string Key, System.Globalization.CultureInfo ci)
    {
        return Resources.Desktop.ResourceManager.GetString(Key, ci);
    }

    public string GetDesktopValue(string Key)
    {
        return Resources.Desktop.ResourceManager.GetString(Key);
    }
    // ho so
    public string GetHoSoValue(string Key, System.Globalization.CultureInfo ci)
    {
        return Resources.HOSO.ResourceManager.GetString(Key, ci);
    }

    public string GetHoSoValue(string Key)
    {
        return Resources.HOSO.ResourceManager.GetString(Key);
    }

    public string GetHistoryAccessValue(string Key)
    {
        return Resources.HistoryAccess.ResourceManager.GetString(Key);
    }

    public string GetErrorMessageValue(string Key, System.Globalization.CultureInfo ci)
    {
        return Resources.ErrorMessage.ResourceManager.GetString(Key, ci);
    }

    public string GetErrorMessageValue(string Key)
    {
        return Resources.ErrorMessage.ResourceManager.GetString(Key);
    }
    /// <summary>
    /// Lấy ngôn ngữ của chương trình hiện tại, kết quả trả về là vi-VN hay en-US....
    /// </summary>
    /// <returns></returns>
    public string GetCurrentCulture()
    {
        var globalizationSection = WebConfigurationManager.GetSection("system.web/globalization") as GlobalizationSection;
        return globalizationSection.Culture;
    }
}