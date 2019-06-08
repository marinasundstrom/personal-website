pushd "/Users/robert/Projects/PersonalSite/src/PersonalSite"
dotnet publish -c Release
pushd "bin/Release/netstandard2.0/publish/PersonalSite"
git add .
git commit -m "Update app"
git push
popd
popd