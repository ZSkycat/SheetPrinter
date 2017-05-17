using System;

namespace SheetPrinter.Core
{
    /// <summary>
    /// 单位转换
    /// </summary>
    public static class UnitConvert
    {
        // 打印机单位：1/100英寸
        // 1英寸 = 2.54厘米

        /// <summary>
        /// 将厘米转为打印机单位
        /// </summary>
        public static float CmToPrint(float value)
        {
            return value / 2.54f * 100f;
        }

        /// <summary>
        /// 将厘米转为打印机单位
        /// </summary>
        public static int CmToPrint_int(float value)
        {
            return Convert.ToInt32(Math.Round(CmToPrint(value)));
        }

        /// <summary>
        /// 将厘米转为指定 DPI 的像素
        /// </summary>
        public static float CmToPx(float value, float dpi)
        {
            return value / 2.54f * dpi;
        }

        /// <summary>
        /// 将厘米转为指定 DPI 的像素
        /// </summary>
        public static int CmToPx_int(float value, float dpi)
        {
            return Convert.ToInt32(Math.Round(CmToPx(value, dpi)));
        }

        /// <summary>
        /// 将指定 DPI 的像素转为为厘米
        /// </summary>
        public static float PxToCm(float value, float dpi)
        {
            return value / dpi * 2.54f;
        }
    }
}
