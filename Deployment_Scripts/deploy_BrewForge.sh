#!/bin/bash
cd /deployments/repos/BrewForge
git fetch --all
git reset --hard origin/master
dotnet publish -o stage
#hopefully that worked....
cd /deployments/BrewForge
if [ ! -d stage ]; then
  mkdir stage;
fi
cp -r /deployments/repos/BrewForge/Brewforge/stage/* stage
rm -r wwwroot_backup
mv wwwroot wwwroot_backup
mv stage wwwroot