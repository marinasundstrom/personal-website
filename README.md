# My website
* URL: http://robertsundstrom.com/
  * Repo: https://github.com/robertsundstrom/robertsundstrom.github.io
* Content: https://github.com/robertsundstrom/blog

## Dependencies
Some notable package dependencies:

* [W3 UI](https://github.com/robertsundstrom/w3-ui) - for components
* [Sass Task](https://github.com/robertsundstrom/sass-task) (Requires Sass to be installed. See the link)

## Development
To set up the development environment, perform the following steps in the folder in which you have cloned the repo.

Assuming that you are using Bash.

### Setup
Set the ```dist``` folder up as the source GitHub repository,

```sh
$ cd bin/Release/netstandard2.0/publish/PersonalSite/dist
$ git init
$ git remote add origin git@github.com:robertsundstrom/robertsundstrom.github.io
$ git fetch
$ git reset --hard origin/master
```
### Publish

```sh
# Publish from the project root
$ dotnet publish -c Release

# Go to the 'dist' folder, commit and push changes.
$ cd bin/Release/netstandard2.0/publish/PersonalSite
$ git add .
$ git commit
$ git push
```

Changes should be available shortly after that on: http://robertsundstrom.com/


**Note:** Make sure that that the ```/_framework/_bin``` directory contains the necessary assemblies.