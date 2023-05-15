# Store.Manager.Sell
Teste para Backend Developer - Find Soluções

Teste para Backend Developer
Você está participando da fase “Teste de codificação” do processo de
contratação da Find Soluções, esse teste nos permite avaliar seu código e
habilidades para propor arquiteturas e solucionar problemas.
Pré requisitos
O seu teste deve ser escrito utilizando a tecnologia .Net. O teste deve utilizar
como persistência de dados um banco MYSQL.
Instruções
• Crie um repositório no GitHub ou Bitbucket e nos envie o link por
Whatsapp;
• Qualquer dúvida em relação ao teste, pode enviar uma mensagem no
Whatsapp.
Aplicação
A solução proposta trata-se de um aplicativo backend para gerenciamento de
vendas de uma loja, com a seguinte especificação:
• Deve ter um cadastro de produtos com as seguintes informações do
produto:
o Nome (Texto, 80 dígitos);
o Preço (Decimal com duas casas após a vírgula);
o Descrição (Texto, 255 dígitos);
• Deve ter um cadastro de clientes com as seguintes informações:
o Nome (Texto, 100 dígitos);
o E-mail (Texto, 200 dígitos);
o Telefone (Texto, 20 dígitos).
• Deve ter uma função “Vender”:
• É uma forma de ligar um cliente a vários produtos, configurando-se a
venda dos produtos.
• É necessário salvar a data da venda.
• Deve ter um relatório de vendas realizadas onde conseguimos visualizar
os produtos que foram vendidos com seus respectivos preços.
• Não é permitido cadastrar produtos sem nome e preço;
• Não é permitido cadastrar clientes sem nome e e-mail;
• A aplicação precisa persistir os dados em um banco de dados MYSQL.
Requisitos obrigatórios
A aplicação irá expor uma API seguindo os padrões REST para:
• Criar/listar/remover/alterar os produtos;
• Criar/listar/remover/alterar os clientes;
• Criar/listar as vendas;
Critérios de avaliação:
• Qualidade da abstração da solução;
• Estrutura e qualidade do código;
• Padronização de código;
• Legibilidade do código;
Bônus:
Commits do git com mensagens claras e concisas.
