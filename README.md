# Desafio - Testes Automatizados - Minhas Finanças

Repositório contendo **exclusivamente** os testes automatizados do desafio técnico.

## 🎯 Objetivo do Desafio

Validar as principais regras de negócio da aplicação:
- Menor de 18 anos **não pode** registrar receitas
- Categoria só pode ser usada conforme sua finalidade (Despesa / Receita / Ambas)
- Exclusão de Pessoa deve remover suas Transações (cascata)

---

## 🏗️ Pirâmide de Testes

| Camada                | Framework                  | Quantidade | Objetivo Principal                     |
|-----------------------|----------------------------|----------|----------------------------------------|
| **Unit Tests**        | xUnit + FluentAssertions   | 12       | Regras de negócio puras (Domínio)      |
| **Integration Tests** | xUnit + WebApplicationFactory | 6 (implementados, porém bloqueados por limitação da API)| API + Banco de Dados |
| **End-to-End Tests**  | Playwright + TypeScript    | 6        | Fluxos completos do usuário            |

---
## 💡 Estratégia da Pirâmide
- Usei testes unitários para validar a lógica de idade (regras de negócio).
- Integração para garantir que a exclusão em cascata funciona no banco.
- E2E para o fluxo completo de cadastro.

## ⚠️ Limitação nos Testes de Integração

- Durante a implementação dos testes de integração, foi identificado um problema estrutural na API que impede sua execução.
- Os testes foram inicialmente desenvolvidos utilizando `WebApplicationFactory<Program>`, conforme prática recomendada para testes de integração em aplicações ASP.NET.
- No entanto, ao executar os testes, ocorre o seguinte erro:

```csharp
CS0122: "Program" é inacessível devido ao seu nível de proteção
```

## 📌 Causa
A API utiliza top-level statements, e a classe Program não está exposta publicamente, impossibilitando seu acesso pelo projeto de testes.

Como o escopo do desafio proíbe ⛔ alterações no código da aplicação, não foi possível aplicar soluções como:
- Tornar Program público
- Utilizar InternalsVisibleTo

## 💾 Decisão Técnica
Diante dessa limitação:
- Os testes de integração foram mantidos no repositório como evidência da tentativa de implementação
- A validação dos endpoints e regras de negócio foi coberta através de testes End-to-End (Playwright), garantindo a verificação do comportamento real da aplicação

## 📸 Evidência

Veja detalhes completos e evidência do erro em: [docs/integration-tests.md](docs/integration-tests.md)

## 🚀 Como Executar os Testes

- 💻 .NET 9 SDK
- ❇️ Node.js 22+
- 🎭 Playwright (com browsers instalados via `npx playwright install`)

## 🧾 Pré-requisitos da aplicação

Para execução dos testes E2E, é necessário que:
- Frontend esteja rodando em: http://localhost:5173
- API esteja rodando em: http://localhost:5000

### 🧪 1. Testes Backend (.NET)

```bash
cd backend-tests
dotnet restore
dotnet build

# Executar todos os testes
dotnet test

# Executar apenas Unit Tests
dotnet test --filter "Category=Unit"

# Executar apenas Integration Tests
dotnet test --filter "Category=Integration"
```

## 🧪 2. Testes Frontend (Playwright)
```bash
cd frontend-tests
npm install
npx playwright install --with-deps

# Executar todos os testes E2E
npx playwright test

# Executar com interface gráfica (para debug)
npx playwright test --ui

# Ver relatório bonito
npx playwright show-report
```

## 🐞 Defeitos Identificados 
Durante a execução dos testes foram identificados os seguintes problemas:
- Impossibilidade de execução de testes de integração utilizando WebApplicationFactory devido ao nível de acesso da classe Program
- Ausência de exclusão em cascata ao deletar uma Pessoa (regra não implementada)
- Validação de menor de idade só ocorre no backend (frontend não previne)
- Mensagens de erro pouco amigáveis para o usuário final
- Falta de validação preventiva no formulário de transações
- Sistema permite cadastrar diversas vezes a mesma pessoa com o mesmo nome e data de nascimento

***Detalhes completos: [docs/bugs-encontrados.md](docs/bugs-encontrados.md)***


## 📁 Estrutura do Repositório
```
├── backend-tests/          ← Testes Unitários e de Integração (.NET)
├── frontend-tests/         ← Testes E2E (Playwright)
├── docs/                   ← Documentação de bugs
├── .github/workflows/      ← CI com GitHub Actions
├── README.md
└── .gitignore
```

## 📚 Documentação
- [📄 Bugs Encontrados](docs/bugs-encontrados.md)  
- [🐞 Falha nos Testes de Integração](docs/integration-tests.md)

## 🤝 Issues QA Criadas
Durante o processo de testes, foram abertas issues para rastrear os principais bugs:
- [1.Exclusão em cascata não implementada](https://github.com/janaina-valerio/teste-tecnico-analista-qa-software/issues/2)
- [2.Pessoa duplicada pode ser cadastrada]()

📄 Lista completa: [docs/issues-bug-qa](docs/issues-bug-qa/)


## 🛠️ Tecnologias Utilizadas

- Backend: .NET 9 + xUnit + FluentAssertions + WebApplicationFactory
- Frontend: Playwright + TypeScript
- CI/CD: GitHub Actions

## 🧠 Considerações Técnicas

- Durante o desenvolvimento dos testes, foi possível observar que a API não foi inicialmente projetada com suporte a testes de integração (testabilidade).
- Essa limitação impacta diretamente a capacidade de validação isolada da camada de API, exigindo o uso de testes end-to-end como alternativa.
- Ainda assim, a estratégia adotada garante cobertura das principais regras de negócio e fluxos críticos do sistema.

## ⚠️ OBSERVAÇÃO IMPORTANTE

- Este repositório foi criado exclusivamente para um desafio técnico.
- Qualquer dúvida, estou à disposição!

## 🚀 Considerações Finais

- Este projeto demonstra a aplicação prática de uma estratégia de testes orientada a regras de negócio, com foco em qualidade, organização e capacidade investigativa.
- Mesmo com limitações técnicas da aplicação base, foi possível garantir cobertura dos fluxos críticos e identificar falhas relevantes no sistema.
