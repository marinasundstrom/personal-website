pushd "src/PersonalSite"
dotnet build --project "src/PersonalSite/PersonalSite.csproj" -c Release
rm -rf "bin/Debug"
dotnet run --project "src/PersonalSite/PersonalSite.csproj" -c Release
popd