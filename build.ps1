Push-Location src
try {
    dotnet restore
    dotnet build
}
finally {
    Pop-Location
}
