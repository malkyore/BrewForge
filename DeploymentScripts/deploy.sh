#!/bin/bash
ssh -t beer@rest.unacceptable.beer -- "sh -c 'sudo chmod +x craftlyStaging/BrewForge/DeploymentScripts/server_deploy.sh && ./craftlyStaging/BrewForge/DeploymentScripts/server_deploy.sh'"