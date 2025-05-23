.PHONY: deploy push

deploy:
	dotnet publish -c Release -o ./publish
	# add your deployment commands here, e.g., az webapp deploy

push:
	git add .
	git commit -m "Auto commit"
	git push

all: push deploy

