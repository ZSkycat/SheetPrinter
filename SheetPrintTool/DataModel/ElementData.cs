using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SheetPrintTool.DataModel
{
    class ElementData
    {
        /// <summary>
        /// 是否启用
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// X坐标
        /// </summary>
        public int X { get; set; }
        /// <summary>
        /// Y坐标
        /// </summary>
        public int Y { get; set; }
        public string Key { get; set; }
        public string Value { get; set; }
    }
}
