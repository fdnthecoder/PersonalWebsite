.PHONY: deploy push

local:
	dotnet build 
	dotnet run --project ./AmadouDialloPortfolio.csproj
prod:
	git add .
	git commit -m "auto push" # give option to input commit message else use default
	git push

all: push deploy

