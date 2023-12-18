# Blood Donation Stock

O Blood Donation Stock é um projeto dedicado a executar uma rotina com base na configuração para verificar o estoque de sangue.

## Visão Geral do Projeto

O sistema foca na verificação do estoque, enviando um e-mail de notificação sempre que o estoque estiver abaixo do mínimo configurável.

## Instruções de Instalação

1. Clone o repositório.
2. Abra o projeto no Visual Studio.
3. Execute o projeto para realizar a instalação automática dos pacotes.
4. Configure o Docker Compose e execute o arquivo docker-compose.

## Requisitos do Sistema

- .NET 8
- RabbitMQ para mensageria
- Banco de dados SQL Server

## Como Utilizar a API

O projeto segue uma arquitetura de microservices. A API cuida da integração com o banco de dados, enquanto um serviço monitora o estoque de sangue, gerando e-mails quando necessário. O RabbitMQ facilita a comunicação entre os serviços.

## Configuração

É necessário configurar:

- Banco de dados
- RabbitMQ
- Serviço de e-mail SMTP

## Contato

Desenvolvido por Eglison Henrique da Silva de Souza,
LinkedIn: [Eglison Souza](https://www.linkedin.com/in/eglisonsouza/)
