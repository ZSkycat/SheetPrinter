# SheetPrintTool
物流运单打印工具。  
为方便家人打印快递单而开发的小工具，专注于打印，没有各种高级功能。

## 开发和构建
开发环境：Visual Studio 2017。  
确保已经安装`MSBuild.exe`，使用`PowerShell`执行`\source\build.ps1`，完整程序文件将生成到`\source\build\`。

## 功能
- 使用json配置的运单模版
- 填充模板，在录入数据时可以一键填充信息
- 多种数据录入模式 (支持插件扩展)
- 字体配置
- 可批量打印的任务功能

## 模版配置
- 模版文件位置 .\template\*.json
- 属性 Width, Height, X, Y 的单位是 cm
- 属性 Type 由 ElementType 规定
- 更多信息请查看源码

## Dependency
- [Newtonsoft.Json](https://github.com/JamesNK/Newtonsoft.Json)

# License
Licensed under the [MIT License](https://github.com/ZSkycat/SheetPrintTool/blob/master/LICENSE).