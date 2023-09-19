## Instruções para execução

- Ter o MySQL instalado e o .Net instalado em sua máquina
- Utilize algum manager ou o terminal, e copie o seguinte código no banco de dados para criar a tabela:
    CREATE DATABASE db_products;
    USE db_products;
    CREATE TABLE info (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(150),
    price DECIMAL(10, 2));

- Abrir o projeto no Visual Studio

- No diretório Catalogo.cs, edite as informações da variável data_source se necessário

- Selecione crudProject.csproj como item de inicialização

- Inicialize o programa
