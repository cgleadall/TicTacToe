#!/bin/bash

rm -rf ./t3Models.Tests/TestResults/*
dotnet test --collect:"XPlat Code Coverage" -r t3Models.Tests/TestResults

reportgenerator -reports:t3Models.Tests/TestResults/*/coverage*.xml -targetDir:./Coverage

rm -rf ./t3Models.Tests/TestResults/*
