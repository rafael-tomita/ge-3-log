# ge-3-log

Testes de AoP:

## AspectConsole01
Teste simples do PostSharp.

###Observações
* Funciona injetando código na IL durante a compilação. Tem potencial para aumentar bastante tempo de compilação, mas não testei essa possibilidade.
 * Houveram implementações de melhoria de performance de build nas versões 2.1 e 3.1. A versão atual é a 4. Daí pode ser que nesta versão esteja bem melhor a performance de build.
* Bem simples de usar e bem legível. Contudo, nem todos os recursos são disponibilizados de forma gratuita.

## AspectConsole02
Teste simples da classe RealProxy.

### Observações:
* Toda classe que for envelopada, terá que extender a classe MarsharllByRef.
* O acesso ao método é por puro Reflection. Daí dá bastante impacto na performance em runtime.
* Para pegar a exceção dentro do aspecto, só se o throw estiver dentro de um try/catch.

## AspectConsole03

Teste simples do framework Castle.DynamicProxy

###Observações:
* Requisito:
 * Os métodos que serão envelopados terão obrigatoriamente que ser virtual.
* Pega os throws de boa, e sai do método retornando nulo se o tipo suportar. Caso contrário, dá rethrow.
* Uso de reflection só para pegar detalhes do método, se precisar.
* Parece ser bem leve, mas não testei performance de forma apropriada.