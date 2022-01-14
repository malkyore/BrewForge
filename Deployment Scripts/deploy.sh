#!/bin/bash
ssh -t beer@rest.unacceptable.beer -- "sh -c 'sudo docker images -q craftly.beer_blazor'"