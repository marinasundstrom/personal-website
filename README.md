# My website
URL: http://robertsundstrom.com/
Content: https://github.com/robertsundstrom/blog

## Dependencies
Some notable package dependencies:

* [W3 UI](https://github.com/robertsundstrom/w3-ui) - for components
* [Sass Task](https://github.com/robertsundstrom/sass-task) (Requires Sass to be installed. See the link)

## Development
To set up the development environment, perform the following steps in the folder in which you have cloned the repo.

Assuming that you are using Bash.

### Setup
Set the ```dist``` folder up as the target GitHub repository,

```sh
$ cd bin/Debug/netstandard2.0/publish/PersonalSite
$ rm -rf dist
$ git clone git@github.com:robertsundstrom/robertsundstrom.github.io -o dist
```
### Publish
```sh
# Publish from the project root
$ dotnet publish

# Go to the 'dist' folder, commit and push changes.
$ cd bin/Debug/netstandard2.0/publish/PersonalSite
$ git add .
$ git commit
$ git push
```

Changes should be avaialble shortly after that on: http://robertsundstrom.com/