using SheetPrintTool.DataModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheetPrintTool
{
    public static class GlobalData
    {
        //config
        public static int InputModeIndxe { get; set; }

        public static List<TemplateData> TemplateList { get; set; } = new List<TemplateData>();
    }

    public enum InputMode
    {
        基本输入,
        淘宝物流格式
    }
}
