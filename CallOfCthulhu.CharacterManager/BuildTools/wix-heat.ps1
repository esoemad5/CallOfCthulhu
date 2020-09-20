param(
  [string] $BinPath,
  [string] $WorkFolder,
  [string] $OutputFile,
  [string] $ProjectName
)

if(Test-Path "$WorkFolder") {
  Remove-Item "$WorkFolder" -Recurse
}

Copy-Item -Path $BinPath -Destination $WorkFolder -Exclude *.vshost.*, *.pdb -Container -Recurse

& $env:WIX\bin\heat.exe dir "$WorkFolder" -ag -srd -cg AppFiles -suid -sfrag -gg -scom -dr INSTALLDIR -sreg -var "var.$ProjectName.TargetDir" -out "$OutputFile"

if(Test-Path "$WorkFolder") {
  Remove-Item "$WorkFolder" -Recurse
}