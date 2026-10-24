namespace NorthwindPizza.Api.DAL.Models;

public partial class AppSetting
{
    public int SettingId { get; set; }

    public string SettingKey { get; set; } = string.Empty;

    public string? SettingValue { get; set; }
}
