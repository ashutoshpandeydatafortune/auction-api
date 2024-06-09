## Create migration

	dotnet ef migrations add "InitialCreate" -o Db/Migrations


## Run migrations and update database
 
	dotnet ef database update


## Build and run docker-compose

	Go to root directory where solution file is present

	docker-compose build
	docker-compose up