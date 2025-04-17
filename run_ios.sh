#!/bin/bash

# Try to find the dotnet command
if command -v dotnet &> /dev/null; then
    DOTNET_CMD="dotnet"
elif [ -f "/usr/local/share/dotnet/dotnet" ]; then
    DOTNET_CMD="/usr/local/share/dotnet/dotnet"
elif [ -f "/usr/local/bin/dotnet" ]; then
    DOTNET_CMD="/usr/local/bin/dotnet"
else
    echo "Could not find the dotnet command. Please make sure .NET SDK is installed."
    exit 1
fi

# Build and run the app on the iOS simulator
echo "Using dotnet command: $DOTNET_CMD"
$DOTNET_CMD build -t:Run -f net9.0-ios
