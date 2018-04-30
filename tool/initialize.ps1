Set-Location $PSScriptRoot
git.exe config --local core.autocrlf true
git.exe config --local core.safecrlf true
git.exe config --get-regexp user
Read-Host 'Exit'
