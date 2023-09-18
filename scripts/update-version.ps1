$VersionElementName = "Version"
$AssemblyVersionElementName = "AssemblyVersion"
$FileVersionElementName = "FileVersion"
$InformationalVersionElementName = "InformationalVersion"

$PropertyGroupElementName = "PropertyGroup"
$ProjectElementName = "Project"

$ScriptFolderPath = $PSScriptRoot
$VersionPropsFileName = "Version.props"
$VersionPropsFilePath = Join-Path -Path $ScriptFolderPath -ChildPath "..\props\$VersionPropsFileName"

function Get-VersionInfo {
  $gitVersionInstalledGlobally = $null -ne (Get-Command "dotnet-gitversion" -ErrorAction SilentlyContinue)
  
  if ($gitVersionInstalledGlobally) {
    $output = dotnet-gitversion | out-string
  }
  else {
    $output = dotnet dotnet-gitversion | out-string
  }

  if ($LASTEXITCODE -eq 1) {
    $currentLocation = Get-Location
    throw "An error occurred while calling the dotnet-gitversion tool from the $currentLocation directory.
           Make sure you have GitVersion.Tool installed locally or globally."
  }

  $versionInfo = Read-VersionInfo $output
  return $versionInfo
}

function Read-VersionInfo {
  param(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$Value
  )

  $json = ConvertFrom-Json $Value

  $versionInfo = @{
    $VersionElementName              = $json.NugetVersion
    $AssemblyVersionElementName      = $json.AssemblySemVer
    $FileVersionElementName          = $json.AssemblySemFileVer
    $InformationalVersionElementName = $json.InformationalVersion
  }

  return $versionInfo
}

function New-VersionXml {
  param(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [Hashtable]$VersionInfo
  )

  $xml = New-Object System.Xml.XmlDocument
  Initialize-VersionXml $VersionInfo $xml

  return $xml
}

function Initialize-VersionXml {
  param (
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [Hashtable]$VersionInfo,

    [Parameter(Mandatory = $true)]
    [xml]$Xml
  )

  $Xml.RemoveAll()

  $versionElement = $Xml.CreateElement($VersionElementName)
  $versionElement.InnerText = $VersionInfo[$VersionElementName]

  $assemblyVersionElement = $Xml.CreateElement($AssemblyVersionElementName)
  $assemblyVersionElement.InnerText = $VersionInfo[$AssemblyVersionElementName]

  $fileVersionElement = $Xml.CreateElement($FileVersionElementName)
  $fileVersionElement.InnerText = $VersionInfo[$FileVersionElementName]

  $informationalVersionElement = $Xml.CreateElement($InformationalVersionElementName)
  $informationalVersionElement.InnerText = $VersionInfo[$InformationalVersionElementName]

  $propertyGroupElement = $Xml.CreateElement($PropertyGroupElementName)
  $propertyGroupElement.AppendChild($versionElement) | Out-Null
  $propertyGroupElement.AppendChild($assemblyVersionElement) | Out-Null
  $propertyGroupElement.AppendChild($fileVersionElement) | Out-Null
  $propertyGroupElement.AppendChild($informationalVersionElement) | Out-Null

  $projectElement = $Xml.CreateElement($ProjectElementName)
  $projectElement.AppendChild($propertyGroupElement) | Out-Null

  $Xml.AppendChild($projectElement) | Out-Null
}

function Save-VersionXml {
  param(
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [xml]$Xml,
    
    [Parameter(Mandatory = $true)]
    [ValidateNotNullOrEmpty()]
    [string]$FilePath
  )

  if (-not(Test-Path $FilePath)) {
    New-Item -ItemType File -Path $versionPropsFilePath -Force -ErrorAction Stop | Out-Null
    Write-Host "The file [$versionPropsFilePath] has been created."
  }
  
  $fullPath = (Get-Item $FilePath).FullName
  $Xml.Save($fullPath)
}

function Start-VersionUpdate {
  Write-Host "Acquiring GitVersion info...`n"
  $versionInfo = Get-VersionInfo

  foreach ($key in $versionInfo.Keys) {
    Write-Host "$key = '$($versionInfo[$key])'"
  }

  Write-Host "`nGenerating Version.props..."
  $xml = New-VersionXml $versionInfo

  Write-Host "Updating Version.props file..."
  Save-VersionXml $xml $VersionPropsFilePath

  Write-Host "`nApplication version has been successfully updated.`n"
}

$ErrorActionPreference = "Stop"
$currentLocation = Get-Location

try {
  Set-Location -Path $ScriptFolderPath
  Start-VersionUpdate
}
finally {
  Set-Location $currentLocation
}
