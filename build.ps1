function Exec {
    [CmdletBinding()]
    param(
        [Parameter(Position = 0, Mandatory = 1)][scriptblock]$cmd,
        [Parameter(Position = 1, Mandatory = 0)][string]$errorMessage = ($msgs.error_bad_command -f $cmd)
    )
    & $cmd
    if ($lastexitcode -ne 0) {
        throw ("Exec: " + $errorMessage)
    }
}

if (Test-Path src/BasicFeatureToggle/artifacts) {
    Remove-Item src/BasicFeatureToggle/artifacts -Recurse -Force
}

Push-Location src/BasicFeatureToggle
try {
    exec { & dotnet restore -v q }
    exec { & dotnet build -v q -c Release }
}
finally {
    Pop-Location
}

Push-Location src/BasicFeatureToggle.Tests
try {
    exec { & dotnet test --test-adapter-path:. --logger:Appveyor }
}
finally {
    Pop-Location
}
$version = @{ $true = $env:APPVEYOR_REPO_TAG_NAME; $false = 0 }[$null -ne $env:APPVEYOR_REPO_TAG_NAME];
exec { & dotnet pack .\src\BasicFeatureToggle\BasicFeatureToggle.csproj -c Release -o .\artifacts --no-build -p:PackageVersion=$version }