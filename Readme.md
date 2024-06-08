## Create migration

	dotnet ef migrations add "InitialCreate" -o Db/Migrations


## Run migrations and update database
 
	dotnet ef database update


## Run docker-compose

	Go to root directory where solution file is present

	Run:  docker-compose up -d