namespace SheetPrintTool.Core
{
    public static class UnitlHelper
    {
        // 打印机单位 PrinterUnit = 1/100英寸
        // 1英寸 = 2.54厘米

        /// <summary>
        /// 将毫米转为打印机单位
        /// </summary>
        public static float MillimeterToPrinterUnit(float mm)
        {
            return mm / 25.4f;
        }

        /// <summary>
        /// 将毫米转为指定DPI的像素
        /// </summary>
        public static float MillimeterToPixelWithDpi(float mm, float dpi)
        {
            return mm / 10f * dpi / 2.54f;
        }
    }
}
