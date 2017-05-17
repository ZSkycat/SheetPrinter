namespace SheetPrinter.Core
{
    /// <summary>
    /// 元素类型
    /// </summary>
    public enum ElementType
    {
        // 通用类型
        Text,
        // 时间类型
        Year = 100,
        Month,
        Day,
        Hour,
        // 常用字段
        寄件人姓名 = 200,
        寄件人单位,
        寄件人地址,
        寄件人邮编,
        寄件人电话,
        寄件人签名,
        物品名称,
        收件人姓名,
        收件人单位,
        收件人地址,
        收件人邮编,
        收件人电话,
        收件人目的地,
    }
}