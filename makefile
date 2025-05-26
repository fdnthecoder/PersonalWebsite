.PHONY: local prod all # Declare targets as phony so they are always executed

local:
	dotnet build 
	dotnet run --project ./AmadouDialloPortfolio.csproj
prod:
	git add .
	git commit -m "auto push" # give option to input commit message else use default
	git push

all: push deploy
