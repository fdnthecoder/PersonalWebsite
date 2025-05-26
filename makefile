.PHONY: deploy push

run:
	dotnet build 
	dotnet run --project ./AmadouDialloPortfolio.csproj
deploy:
	dotnet publish -c Release -o ./publish
	# add your deployment commands here, e.g., az webapp deploy

push:
	git add .
	git commit -m "auto push" # give option to input commit message else use default
	git push

all: push deploy

