# Constant
$MsBuild = (Get-ChildItem "C:\Program Files (x86)\Microsoft Visual Studio\*\*\MSBuild\*\Bin\MSBuild.exe")[0].FullName
$ProjectPath = Resolve-Path "$PSScriptRoot\..\source"
$PublishPath = $ExecutionContext.SessionState.Path.GetUnresolvedProviderPathFromPSPath("$PSScriptRoot\..\publish\SheetPrinter\")

# Build
& "$MsBuild" "$ProjectPath\SheetPrinter.sln" /t:Build /p:Configuration=Release /v:m

# Clear And Copy
Remove-Item -Recurse $PublishPath -ErrorAction Ignore
New-Item $PublishPath -ItemType Directory -ErrorAction Ignore
New-Item "$PublishPath\plugin\" -ItemType Directory -ErrorAction Ignore

Copy-Item -Recurse -Exclude "*.pdb", "*.xml" "$ProjectPath\SheetPrinter\bin\Release\*" $PublishPath
Copy-Item "$ProjectPath\PrinterTool\bin\Release\PrinterTool.exe" $PublishPath
Copy-Item "$ProjectPath\SheetPrinter.Plugin.Default\bin\Release\SheetPrinter.Plugin.Default.dll" "$PublishPath\plugin\"

Read-Host 'Exit'
