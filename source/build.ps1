# Path
$msBuildPath = (Get-ChildItem 'C:\Program Files (x86)\Microsoft Visual Studio\*\Community\MSBuild\*.*\Bin\')[0].FullName
$projectPath = Split-Path $MyInvocation.MyCommand.Path

# Build
$slnFile = Join-Path $projectPath 'SheetPrinter.sln'
Set-Location $msBuildPath
.\MSBuild.exe $slnFile /t:Build /p:Configuration=Release /p:Platform="Any CPU" /v:m

# Copy to build
$sheetPrinterBuild = Join-Path $projectPath 'build/SheetPrinter'
Set-Location $projectPath

if (Test-Path $sheetPrinterBuild) {
    Remove-Item -Recurse $sheetPrinterBuild
}
mkdir $sheetPrinterBuild | Out-Null
Copy-Item -Recurse 'SheetPrinter\bin\Release\*' $sheetPrinterBuild
Copy-Item "SheetPrinter.Plugin.Default\bin\Release\SheetPrinter.Plugin.Default.dll" $sheetPrinterBuild
Remove-Item "$sheetPrinterBuild\*.pdb"
Remove-Item "$sheetPrinterBuild\*.xml"

# End
Write-Host 'Build End!'
Read-Host