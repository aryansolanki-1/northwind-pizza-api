using System;
using System.Collections.Generic;
using System.Text;

namespace NorthwindPizza.Api.DAL.Models
{
    public partial class AppSetting
    {
        public int SettingId { get; set; }

        public string? SettingKey { get; set; }

        public string SettingValue { get; set; } = string.Empty;
    }
}
