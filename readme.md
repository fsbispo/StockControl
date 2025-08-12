# StockControl

Sistema de controle de estoque desenvolvido em **.NET 8** utilizando os princípios de **Clean Architecture**, **Domain-Driven Design (DDD)** e **CQRS**.

---

## 🏗 Estrutura do Projeto

O projeto é dividido em **quatro camadas principais**, seguindo o padrão Clean Architecture.

src/
├── StockControl.Domain/
│   ├── Entities/
│   ├── ValueObjects/
│   ├── Enums/
│   └── Interfaces/
│
├── StockControl.Application/
│   ├── Commands/
│   ├── Handlers/
│   └── DTOs/
│
├── StockControl.Infrastructure/
│   ├── Repositories/
│   └── Data/
│
└── StockControl.WebAPI/
    ├── Controllers/
    └── Program.cs

markdown
Copiar
Editar

---

## 📂 Camadas

### 1. **Domain** (Regras de Negócio)
- **Responsabilidade:** Contém as regras de negócio puras, independentes de tecnologia.
- **O que contém:**
  - **Entities** → Objetos de negócio com comportamentos e propriedades.
  - **Value Objects** → Objetos imutáveis representando conceitos.
  - **Enums** → Constantes de negócio (ex.: `ProductType`, `OrderStatus`).
  - **Interfaces** → Contratos que outras camadas devem implementar (ex.: `IProductRepository`).

📌 **Não depende de nenhuma outra camada.**

---

### 2. **Application** (Casos de Uso)
- **Responsabilidade:** Orquestrar a aplicação, coordenando o fluxo de dados entre *Domain* e *Infrastructure*.
- **O que contém:**
  - **Commands** → Objetos que representam ações (ex.: `CreateProductCommand`).
  - **Handlers** → Classes que executam as ações dos commands (ex.: `CreateProductHandler`).
  - **DTOs** → Objetos para transferir dados entre camadas.

📌 **Depende apenas do Domain.** Não acessa infraestrutura diretamente.

---

### 3. **Infrastructure** (Infraestrutura)
- **Responsabilidade:** Implementação técnica (banco de dados, APIs externas, etc.).
- **O que contém:**
  - **Repositories** → Implementações das interfaces do *Domain* usando Entity Framework Core.
  - **Data** → Contexto do banco (`DbContext`).

📌 **Depende de Domain e Application.**

---

### 4. **WebAPI** (Interface de Entrada)
- **Responsabilidade:** Ponto de entrada da aplicação (endpoints HTTP).
- **O que contém:**
  - **Controllers** → Recebem requisições, chamam os handlers da camada Application.
  - **Program.cs** → Configuração do pipeline da API e injeção de dependências.

📌 **Depende do Application** (e indiretamente de Domain e Infrastructure via DI).

---

## 🔄 Fluxo da Aplicação (CQRS Simplificado)

1. **Controller** recebe a requisição HTTP.
2. Cria um **Command** com os dados recebidos.
3. O **Handler** processa o comando:
   - Aplica regras de negócio (*Domain*).
   - Usa **Repositories** para persistir/ler dados (*Infrastructure*).
4. Retorna a resposta para o Controller.
5. Controller envia a resposta HTTP ao cliente.

---

## 🚀 Como Executar

```bash
# Restaurar pacotes
dotnet restore

# Rodar a aplicação
dotnet run --project src/StockControl.WebAPI

# Acessar Swagger
http://localhost:5000/swagger