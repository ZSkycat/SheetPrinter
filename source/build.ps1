# Path
$msBuildPath = (Get-ChildItem "C:\Program Files (x86)\Microsoft Visual Studio\*\Community\MSBuild\*.*\Bin\")[0].FullName  # 无尾/
$projectPath = Split-Path $MyInvocation.MyCommand.Path  # 无尾/

# Build
Set-Location $projectPath
& "$msBuildPath/MSBuild.exe" "SheetPrinter.sln" /t:Build /p:Configuration=Release /p:Platform="Any CPU" /v:m

# Clear And Copy
$buildSheetPrinter = Join-Path $projectPath "build/SheetPrinter"

if (Test-Path $buildSheetPrinter) {
    Remove-Item -Recurse $buildSheetPrinter
}
mkdir $buildSheetPrinter | Out-Null

Copy-Item -Recurse "SheetPrinter\bin\Release\*" $buildSheetPrinter
Copy-Item "PrinterTool\bin\Release\PrinterTool.exe" $buildSheetPrinter
Copy-Item "SheetPrinter.Plugin.Default\bin\Release\SheetPrinter.Plugin.Default.dll" "$buildSheetPrinter/plugin"

Remove-Item "$buildSheetPrinter\*.pdb"
Remove-Item "$buildSheetPrinter\*.xml"

# End
Write-Host 'Build End!'
Read-Host