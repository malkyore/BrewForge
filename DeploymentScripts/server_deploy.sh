#!/bin/bash
#cd to directory
cd craftlyStaging/BrewForge/
#find the ID of the docker container
DOCKERID=$(sudo docker container ls -q -f "ancestor=craftly.beer_blazor")
#pull a fresh version of the repository
git fetch --all
git reset --hard origin/master
#stop the container
sudo docker stop $DOCKERID
#wait a little to make sure its stopped
sleep 2s
#run the docker build
sudo docker build -f ./Craftly.Beer_Blazor/DockerfileServer -t craftly.beer_blazor .
#start the container
sudo docker run -d -p 1666:80 craftly.beer_blazor