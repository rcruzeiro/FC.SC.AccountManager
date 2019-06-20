# FC / SD Account Manager
Microsserviço para Gerenciamento de Conta visando atender cenário de teste prático FC / SD.

### Before you start
Este é um projeto de demonstração de um microsserviço desenhado seguindo princípios DDD, SOLID e RESTFUL.

Este projeto foi pensado visando simular o gerenciamento mais simples possível de uma conta corrente: transações de crédito e débito. Para tal fim, expõe 3 (três) endpoints (detalhados na seção **Docs** abaixo), sendo:

Um adendo ao projeto: uma solução simples de Blockchain que utiliza o MongoDB para guardar o track das transações realizadas pela API.

 | Verbo | Endpoint       | Descrição                         |
 | ----- | -------------- | --------------------------------- |
 | GET   | /Accounts/{id} | Utilize para consultar uma conta  |
 | POST  | /Accounts      | Utilize para criar uma nova conta |
 | POST  | /Accounts/{id} | Utilize para realizar uma transferência entre contas |

 É favor ter em mente que nem regras de negócio nem regras de segurança de acesso foram levados em consideração durante o desenvolvimento.

### Optional Requisite

* [Docker](https://www.docker.com/community-edition)
* [Docker Compose](https://docs.docker.com/compose/install)

### Up and running
O jeito mais prático de iniciar e testar o projeto é utilizando o docker.

O projeto está configurado com um conteiner contendo ambas bases de dados (MySQL e MongoDb) e possui mecanismo *Makefile*, que facilia a execução dos comandos mais comuns. Se já possuir Docker e Docker-compose instalado, recomendo que utilize esta opção.

```console
$ make build
$ make up
$ make migrate
```

Caso não deseje utilizar o Docker, poderá também utilizar o Kestrel para iniciar e executar o projeto. Note que, neste cenário, ambas bases de dados deverão estar instaladas e acessíveis e seus respectivos hosts deverão ser definidos no arquivo de configuração da API (appsettings.Development.json) antes de prosseguir com os testes.

### Docs
A documentação da API (Swagger) poderá ser acessada em:

Docker:
```console
[Documentação no Docker](http://localhost:8082/docs)
```

Kestrel:
```console
[Documentação no Kestrel](http://localhost:8081/docs)
```

### Testing before the test
A solução contém também um projeto de Testes do domínio, a título de exemplo, criado em xUnit e fazendo uso da biblioteca Moq.

Caso esteja usando Docker e Docker-compose, pode usar o comando Make abaixo para executar os testes diretamente de um terminal:

```console
$ make test
```