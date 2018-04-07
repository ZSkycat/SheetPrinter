# Constant
$MsBuild = (Get-ChildItem "C:\Program Files (x86)\Microsoft Visual Studio\*\*\MSBuild\*\Bin\MSBuild.exe")[0].FullName
$ProjectPath = $PSScriptRoot
$BuildPath = "$PSScriptRoot\build\SheetPrinter\"

# Build
& "$MsBuild" "$ProjectPath\SheetPrinter.sln" /t:Build /p:Configuration=Release /p:Platform="Any CPU" /v:m

# Clear And Copy
Remove-Item -Recurse $BuildPath -ErrorAction Ignore
New-Item $BuildPath -ItemType Directory -ErrorAction Ignore
New-Item "$BuildPath\plugin\" -ItemType Directory -ErrorAction Ignore

Copy-Item -Recurse -Exclude "*.pdb", "*.xml" "$ProjectPath\SheetPrinter\bin\Release\*" $BuildPath
Copy-Item "$ProjectPath\PrinterTool\bin\Release\PrinterTool.exe" $BuildPath
Copy-Item "$ProjectPath\SheetPrinter.Plugin.Default\bin\Release\SheetPrinter.Plugin.Default.dll" "$BuildPath\plugin\"

Read-Host 'Exit'
