filter= ""

.PHONY: restore
restore:
	dotnet restore fc.sc.accountmanager.sln

.PHONY: build
build: stop restore
	docker-compose build

.PHONY: up
up:
	docker-compose up -d

.PHONY: stop
stop:
	docker-compose stop

.PHONY: down
down:
	docker-compose down

.PHONY: attach
attach: up
	docker-compose exec fc.sc.accountmanager.api bash

.PHONY: mysql
mysql: up
	docker-compose exec database mysql -u root -h database -proot --database fc.sc.accounts
    
.PHONY: migrate
migrate: up
	cd fc.sc.accountmanager.platform && dotnet ef database update

.PHONY: prune
prune: stop
	docker system prune

.PHONY: test
test:
	cd fc.sc.accountmanager.tests && dotnet test