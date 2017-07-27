# Visual Studio 路径
$vsPath = 'C:\Program Files (x86)\Microsoft Visual Studio\2017\Community\Common7\IDE'
Set-Location $vsPath

.\devenv.com D:\Workspace\SheetPrinter\source\SheetPrinter.sln /Rebuild "Release|Any CPU"