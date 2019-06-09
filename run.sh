pushd "src/PersonalSite"
dotnet build -c Release
rm -rf "bin/Debug"
dotnet run -c Release
popd