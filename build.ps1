Push-Location src
try {
    dotnet restore
    dotnet build
    # msbuild /v:q /m BasicFeatureToggle.sln
}
finally {
    Pop-Location
}
