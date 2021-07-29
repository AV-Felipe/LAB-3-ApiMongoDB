# Digital Innovation One - Prática .NET

## API CRUD Conectada com MongoDB

### Projeto Prático 3

API para cadastro e acesso de itens em um banco de dados com informações de alimentos. O foco deste projeto está na implementação da conexão com um banco de dados MongoDB.

Por se tratar de um projeto pedagógico, fez-se uso abundante de comentários, evidenciando detalhes já explícitos no código.

Buscamos explorar a versatilidade do padrão NoSQL do Mongo, explorando o uso de matrizes com variados comprimentos dentro dos documentos da coleção.

Essencialmente, esta API se conecta a uma instância local do MongoDB, nela ela adiciona, documentos com três campos string informados pelo usuário. O campo "Benefits" recebe uma string onde cada espaço é considerado como uma divisão, assim, cada palavra será transposta para um diferente campo, em uma matriz, no documento do banco.

A API cuida da datação da criação e alteração das entradas, além de gerar um id do tipo GUID, para evitar a manipulação do _id gerado pelo MongoDB.


 
