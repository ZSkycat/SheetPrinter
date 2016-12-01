using System;

namespace SheetPrintTool.Core
{
    /// <summary>
    /// 单位转换工具
    /// </summary>
    public static class UnitlHelper
    {
        // 打印机单位 PrinterUnit = 1/100英寸
        // 1英寸 = 2.54厘米

        /// <summary>
        /// 将毫米转为打印机单位
        /// </summary>
        public static int MmToPrinterUnit(float mm)
        {
            return Convert.ToInt32(Math.Round(mm / 25.4d * 100));
        }

        /// <summary>
        /// 将毫米转为打印机单位
        /// </summary>
        public static int MmToPrinterUnit_f(float mm)
        {
            return Convert.ToInt32(Math.Round(mm / 25.4d * 100));
        }

        /// <summary>
        /// 将毫米转为指定DPI的像素
        /// </summary>
        public static int MmToPx(float mm, float dpi)
        {
            return Convert.ToInt32(Math.Round(mm / 10d * dpi / 2.54d));
        }

        /// <summary>
        /// 将毫米转为指定DPI的像素
        /// </summary>
        public static float MmToPx_f(float mm, float dpi)
        {
            return mm / 10f * dpi / 2.54f;
        }
    }
}
