# SheetPrinter
物流运单打印工具。<br>
为方便家人打印快递单而开发的小工具，只专注于打印，目前已经弃用。

## 开发和构建
使用`Visual Studio 2017`开发，目标`.NET Framework 3.5`。<br>
确保已经`还原 NuGet`，执行`\tool\build.ps1`，完整程序文件将生成到`\publish\`。

## 功能
- 使用 `json` 配置的运单模版
- 多种数据录入模式 (支持插件扩展)
- 支持批量打印的任务功能
- 支持配置打印字体
- 支持配置数据填充模板

## 模版配置
- 模版文件所在路径 `.\template\*.json`
- 属性类型由 `ElementType` 定义
- 属性长度单位是 `cm`

## 依赖
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

## 协议
[MIT](https://github.com/ZSkycat/SheetPrintTool/blob/master/LICENSE).
