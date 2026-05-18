# 🐾 ClyvoVet API

## 👨‍💻 Desenvolvedor

* **Nome:** Leonardo Zerbinatti de Sales
* **Curso:** Análise e Desenvolvimento de Sistemas
* **Faculdade:** FIAP

---

# 📌 Sobre o Projeto

O **ClyvoVet** é uma API desenvolvida em **C# com .NET 10**, utilizando os conceitos de:

* Clean Architecture
* Entity Framework Core
* SQLite
* Controllers REST
* DTOs
* Relacionamentos entre entidades
* Migrations
* API HTTP

O objetivo do projeto é simular um sistema veterinário para gerenciamento de:

* Tutores
* Pets
* Eventos clínicos
* Lembretes

---

# 🛠️ Tecnologias Utilizadas

* C#
* .NET 10
* ASP.NET Core Web API
* Entity Framework Core
* SQLite
* Rider
* Git
* GitHub

---

# 📂 Estrutura do Projeto

```bash
ClyvoVet
│
├── ClyvoVet.Api
│   ├── Controllers
│   ├── appsettings.json
│   ├── Program.cs
│
├── ClyvoVet.Application
│   ├── DTOs
│   ├── Interfaces
│   ├── Services
│
├── ClyvoVet.Domain
│   ├── Commons
│   ├── Entities
│   ├── Enums
│
├── ClyvoVet.Infrastructure
│   ├── Data
│   ├── Mappings
│   ├── Migrations
│   ├── Repositories
```

---

# 🧱 Entidades Criadas

## Tutor

Responsável pelos pets.

### Campos:

* Id
* Nome
* Email
* Telefone
* CriadoEm
* Ativo

---

## Pet

Representa os animais cadastrados.

### Campos:

* Id
* Nome
* Espécie
* Raça
* DataNascimento
* TutorId

---

## EventoClinico

Eventos relacionados ao pet.

### Campos:

* Id
* Titulo
* Descricao
* DataEvento
* PetId

---

## Lembrete

Lembretes relacionados aos pets.

### Campos:

* Id
* Descricao
* Data
* PetId

---

# 🔗 Relacionamentos

## Tutor → Pets

* 1 Tutor pode possuir vários Pets
* Relacionamento: 1:N

## Pet → Eventos Clínicos

* 1 Pet pode possuir vários Eventos Clínicos
* Relacionamento: 1:N

## Pet → Lembretes

* 1 Pet pode possuir vários Lembretes
* Relacionamento: 1:N

---

# ⚙️ Funcionalidades Implementadas

## ✅ Tutor

* Criar Tutor
* Listar Tutores

## ✅ Pet

* Criar Pet
* Listar Pets

## ✅ Evento Clínico

* Criar Evento Clínico
* Listar Eventos Clínicos

---

# 🗄️ Banco de Dados

O projeto utiliza:

```bash
SQLite
```

Arquivo do banco:

```bash
clyvovet.db
```

---

# 🚀 Como Rodar o Projeto

## 1️⃣ Clonar o Repositório

```bash
git clone LINK_DO_REPOSITORIO
```

---

## 2️⃣ Entrar na Pasta do Projeto

```bash
cd ClyvoVet
```

---

## 3️⃣ Restaurar Dependências

```bash
dotnet restore
```

---

## 4️⃣ Criar o Banco de Dados

```bash
dotnet ef database update -p ClyvoVet.Infrastructure -s ClyvoVet.Api
```

---

## 5️⃣ Rodar a API

```bash
dotnet run --project ClyvoVet.Api
```

---

# 🌐 Endpoints da API

## 📌 Tutor

### Criar Tutor

```http
POST /api/tutor
```

### Listar Tutores

```http
GET /api/tutor
```

---

## 📌 Pet

### Criar Pet

```http
POST /api/pet
```

### Listar Pets

```http
GET /api/pet
```

---

## 📌 Evento Clínico

### Criar Evento Clínico

```http
POST /api/eventoclinico
```

### Listar Eventos Clínicos

```http
GET /api/eventoclinico
```

---

# 🧪 Exemplos de Requisição

## Criar Tutor

```json
{
  "nome": "Leonardo",
  "email": "leo@email.com",
  "telefone": "11999999999"
}
```

---

## Criar Pet

```json
{
  "nome": "Thor",
  "especie": "Cachorro",
  "raca": "Golden Retriever",
  "dataNascimento": "2020-05-10",
  "tutorId": "ID_DO_TUTOR"
}
```

---

## Criar Evento Clínico

```json
{
  "titulo": "Consulta",
  "descricao": "Consulta veterinária",
  "dataEvento": "2026-05-18T10:00:00",
  "petId": "ID_DO_PET"
}
```

---

# 📌 Conceitos Aplicados

Durante o desenvolvimento do projeto foram utilizados conceitos importantes como:

* Orientação a Objetos
* Clean Architecture
* Relacionamentos entre entidades
* Injeção de Dependência
* Controllers REST
* Entity Framework Core
* Migrations
* DTOs
* Serialização JSON
* SQLite
* Versionamento com Git/GitHub

---

# ✅ Projeto Finalizado

O projeto foi desenvolvido com foco em aprendizado de:

* APIs REST
* Banco de dados SQLlite
* Entity Framework Core
* Estrutura profissional de projetos em C#

---

# 🔗 GitHub

Link do repositório: https://github.com/LeonardoZerbinattiDeSales/ClyvoVet.Api.git

```bash
https://github.com/LeonardoZerbinattiDeSales/ClyvoVet.Api.git
```
