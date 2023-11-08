# TrybeHotel API

Este é o repositório da API TrybeHotel, uma API desenvolvida em várias etapas para controle de cidades, hotéis, quartos, reservas e integração com informações geográficas baseadas em endereços. A API foi desenvolvida em C# com ASP.NET e utiliza um banco de dados para armazenar informações sobre hotéis, cidades, quartos, usuários e reservas.

## Etapas do Projeto

O projeto TrybeHotel foi desenvolvido em quatro etapas distintas, cada uma com seus próprios requisitos e funcionalidades. Abaixo, você encontrará uma descrição de cada etapa do projeto e as tecnologias utilizadas:

### Fase A: Iniciando o Desenvolvimento

Nesta fase, o objetivo foi iniciar o desenvolvimento da API e criar rotas para as entidades de cidades, hotéis e quartos. Foram desenvolvidos endpoints para listar, criar e atualizar informações sobre essas entidades.

**Tecnologias Utilizadas:**
- ASP.NET
- C#
- Banco de dados

### Fase B: Adicionando Autenticação e Segurança

Nesta fase, a API foi expandida para incluir autenticação de usuários e políticas de autorização. Rotas de cadastro e login de usuários foram adicionadas, bem como políticas de autorização para operações seguras.

**Tecnologias Utilizadas:**
- ASP.NET
- C#
- Tokens JWT
- Políticas de Autorização

### Fase C: Integração com Informações Geográficas

Nesta fase, a API foi aprimorada para buscar hotéis com base em informações geográficas de endereços. Foram adicionados atributos e funcionalidades para melhorar a pesquisa de hotéis próximos a um endereço.

**Tecnologias Utilizadas:**
- ASP.NET
- C#
- Integração com API externa de informações geográficas

### Fase D: Preparando para Deploy

Na última fase, a API foi preparada para o deploy. Uma rota padrão para verificar o status da aplicação foi adicionada, e um Dockerfile foi criado para facilitar a implantação da API em um ambiente de produção.

**Tecnologias Utilizadas:**
- ASP.NET
- C#
- Docker

## Endpoints da API

A API TrybeHotel possui vários endpoints para acessar diferentes funcionalidades. Abaixo, listamos os principais endpoints e suas descrições:

### Cidades

- `GET /city`: Lista todas as cidades cadastradas.
- `POST /city`: Cria uma nova cidade.

### Hotéis

- `GET /hotel`: Lista todos os hotéis cadastrados.
- `POST /hotel`: Cria um novo hotel.

### Quartos

- `GET /room/:hotelId`: Lista todos os quartos de um hotel específico.
- `POST /room`: Cria um novo quarto.
- `DELETE /room/:roomId`: Exclui um quarto específico.

### Usuários

- `POST /user`: Cria um novo usuário.
- `POST /login`: Realiza o login de um usuário.
- `GET /user`: Lista todos os usuários cadastrados.

### Reservas

- `POST /booking`: Cria uma nova reserva.
- `GET /booking`: Lista todas as reservas realizadas.

### Informações Geográficas

- `GET /geo/status`: Verifica o status das informações geográficas.
- `GET /geo/address`: Busca hotéis próximos com base em um endereço.

## Como Utilizar a API

Para utilizar a API TrybeHotel, siga os seguintes passos:

1. Clone este repositório.
2. Abra o projeto em sua IDE de desenvolvimento favorita.
3. Certifique-se de que você possui todas as tecnologias necessárias instaladas.
4. Execute a API localmente ou faça o deploy em um ambiente de produção, se necessário.
5. Utilize os endpoints da API conforme necessário, fazendo requisições HTTP a eles.

Lembre-se de fornecer os dados de autenticação quando necessário e de seguir as políticas de autorização para acessar rotas seguras.




