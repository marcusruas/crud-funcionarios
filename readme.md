## Cadastro de funcionários
_Aplicação desenvolvida em ASP .NET MVC 5_

## Sobre o projeto
* Alguns pontos sobre este projeto
* Desenvolvimento da arquitetura em MVC devido ao escopo da aplicação. 
* Não optei pelo uso de padrões de desenvolvimento (_design patterns_) mais robustos pois apenas aumentaria a complexidade do projeto desnecessariamente. 
* Também não optei pela abordagem em DDD (_Domain Driven Design_) devido a pouca complexidade das regras de negócio do projeto, porém se a complexidade fosse maior haveria uma camada para essa abordagem, conforme meus outros projetos.
* O único padrão de desenvolvimento (relativamente) mais complexo utilizado neste projeto foi o de repositório, com o fim de organizar em uma única camada (repository) todos os assuntos relacionados ao "crud" no banco de dados.

## Por que utilizei o Dapper ao invés de Entity Framework?
Optei pelo uso do Dapper pois ele pode ser aplicado a uma gama maior de projetos (mais especificamente a projetos cujo banco de dados não possui uma boa modelagem). Apesar da maior complexidade para a implementação de "Helpers" entre outros, acabei optando pelo Dapper pelo motivo acima e também para tornar a camada de repositório mais robusta e fácil de implementação de novas queries com SP'S etc.
_Gostaria de deixar claro que não considero o framework Dapper superior ao Entity FrameWork em nenhuma forma, apenas optei por seu uso em meu projeto._

## Como posso iniciar o projeto?
Apenas abri-lo no visual studio e clicar na opção de rodar. O arquivo _conexoes.json_ foi propositalmente "commitado" na aplicação afim de tornar o processo mais fácil, mas em um projeto real é algo que eu jamais faria.

## conexoes.json
Optei por não incluir as _Connection Strings_ direto no Web.Config pois acredito que seja melhor te-las em um arquivo separado e de fácil alteração, afim de evitar que futuras pessoas que trabalhem em projetos realizem um commit com informações indevidas no mesmo.

## Script para criação de tabelas
O script de criação de tabelas é o mesmo que o informado via e-mail de teste, mas uma cópia do mesmo consta na camada Repository.