## Create migration

	dotnet ef migrations add "InitialCreate" -o Db/Migrations


## Run migrations and update database
 
	dotnet ef database update


## Build and run docker-compose

	Go to root directory where solution file is present

	docker-compose build
	docker-compose up

## Setting up SSL on nginx

We use the makecert utility
	
	https://chocolatey.org/install

	https://github.com/FiloSottile/mkcert

Use following command to generate key and certificate files for following domains:

* app.auction.com 
* api.auction.com 
* id.auction.com

    mkcert -key-file auction.com.key -cert-file auction.com.crt app.auction.com api.auction.com id.auction.com

Put the created certificates in `devcerts` folder in the root of project.