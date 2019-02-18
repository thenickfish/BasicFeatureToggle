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

Push-Location src
try {
    exec { & dotnet restore -v q }
    exec { & dotnet build -v q }
    exec { & dotnet test --test-adapter-path:. --logger:Appveyor }
    # msbuild /v:q /m BasicFeatureToggle.sln
}
finally {
    Pop-Location
}
