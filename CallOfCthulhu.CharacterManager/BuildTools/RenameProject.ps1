param(
    [Parameter(Mandatory = $true)]
    [string] $NewProjectName,
    [Parameter(Mandatory = $true)]
    [string] $NewProjectFriendlyName
)

Push-Location "$PSScriptRoot\..\Source"


# Rename solution and project
$filesArray = @(
    "./ProjectQuickStart/ProjectQuickStart.csproj",
    "./ProjectQuickStart.sln",
    "./ProjectQuickStart.Install/ProjectQuickStart.Install.wixproj"
)

$filesArray | ForEach-Object {
    $file = Get-Item $_
    $NewName = $file.Name -replace "ProjectQuickStart", $NewProjectName

    $NewPath = Join-Path $file.DirectoryName "$NewName"
    $file.MoveTo($NewPath)
}

# rename project directories
$directoryArray = @(
    ".\ProjectQuickStart"
    ".\ProjectQuickStart.Install"
)

$directoryArray | ForEach-Object {
    $newDirName = $_ -replace "ProjectQuickStart", "$NewProjectName"
    Move-Item $_ $newDirName
}

$filesToUpdate = (Get-ChildItem -Exclude *.dll,*.ico -Recurse | Where-Object { !$_.PSIsContainer -and ($_.FullName -notmatch ".*(\\bin\\)|(\\obj\\)|(\\packages\\).*") }) +
    (Get-Item -Path "..\.gitignore")

$filesToUpdate | ForEach-Object {
    (Get-Content $_.PSPath) |
    ForEach-Object { $_ -replace "ProjectQuickStart", $NewProjectName} |
    Set-Content $_.PSPath
} 

$installProductXml = [xml](Get-Content .\$NewProjectName.Install\Product.wxs)
$newUpgradeCodeGuid = [guid]::NewGuid();
$installProductXml.Wix.Product.UpgradeCode = "$newUpgradeCodeGuid";
$installProductXml.Save("$PWD\$NewProjectName.Install\Product.wxs")

$installVariablesXml = [xml](Get-Content .\$NewProjectName.Install\Variables.wxi)
$installVariablesXml.Include.define = "ProductName=""$NewProjectFriendlyName"""
$installVariablesXml.Save("$PWD\$NewProjectName.Install\Variables.wxi")

Pop-Location