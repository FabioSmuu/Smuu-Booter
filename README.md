# StringEdit

Este projeto foi criado com o intuito de facilitar o uso de cores, poscionamento e formatação de string de forma leve e individual tratando pequenas funções como uma promise.
```js
const se = require('StringEdit')
```

### Oque tem nesta versão:
- Mudar cor de fundo e da fonte sem alterar todo o console.
- As strings são formçadas a ficar em uma só linha ate que se use "\n" na estrutura.
- Cores funcionais em console.log
- Metodo proprio de imprimir string no console.
- Escolher em qual linha do console um determinado texto aparecerá
- Formatar textos com uma nova estrutura exemplo: XX/XX/XX

### Como usar:
O uso deste projeto é bem simples, pois suas funções são totalmente propriás.

Com a StrindEdit importada em seu projeto será possivel dar uma cor a sua fonte da seguinte forma:
```js
console.log('String normal' + se.FgRed + se.BgCyan + 'Editada' + se.Reset)
console.log('a' + se.FgRed + se.BgCyan + 'c')
console.log('d' + se.FgRed + se.BgCyan + 'e' + se.Bright + se.FgMagenta + 'f')
```
Resultado:
#
![N|Solid](https://i.imgur.com/yW5n5LJ.png)

Outra forma de efetua este mesmo processo, mas de uma maneira mais efetiva e performatica seria usando a função .log da StringEdit
```js
let exemplo = {
	fonte: 'Magenta',
	fundo: 'Blue',
	estilo: 'Bright'
}

se.log('\n\n\nFabio ', exemplo)
se.log('Smuu\n\n\n ~ Smuu', exemplo)
```
Resultado:
![N|Solid](https://i.imgur.com/pr2qCr2.png)

Oustras formas de colorir, mas de mesmo resultado:
```js
se.log('Olá Mundo!', {
	fonte: 'Cyan',
	fundo: 'Red',
	estilo: 'Dim'
})
```

Usando esta mesma estrutura, se torna possivel a manipulação de linhas da seguinte forma:
```js
var linhas = {
    linha: 3
}

se.log('Esta é a linha 3', linhas)
linhas.linha = 2
se.log('Esta é a linha 2', linhas)
```
Resultado:
![N|Solid](https://i.imgur.com/p2dnQe1.png)

Um dos fortes da StringEdit é exatamente mudar a formatação de uma string atravez do protótipo .mask como mostra este exemplo:

```js
let num = 1234567890
let a = num.mask('**/**/**', '*')   //resultado: 12/34/56
let b = 'Exemplo'.mask('XXXX-X')    //resultado: Exem-p

console.log(a)  //resultado: 12/34/56
console.log(b)  //resultado: Exem-p
```

Outros exemplos usando .mask:
```js
12345678.mask('XXX-XXXX')		// resultado: 123-4567
12345678.mask('XX-XX-XX')		// resultado: 12-34-56
12345678.mask('XX/XX/XX')		// resultado: 12/34/56
'StringEdit'.mask('XX.XX.XX')		// resultado: St.ri.ng
'Fabio Smuu'.mask('XX/XX/XX/XX/XX')	// resultado: Fa/bi/o /Sm/uu
```

Um pequeno exemplo do uso quase completo da EditString:
```js
var i = 0,
estrutura = {
	fonte: 'Magenta',
	fundo: 'Blue',
	estilo: 'Bright',
	linha: se.linhas
}

setInterval(function(){
	if (i < 10) {
		let a = '-'.repeat(i)  + '#' +   ' '.repeat(9-i)
		se.log(`\r[${a}]`, estrutura)
	} else {
		se.resetar()
		estrutura.fonte = 'Green'
		estrutura.fundo = 'Cyan'
		estrutura.linha = 0
		se.log('[Concluido]\n', estrutura)
		process.exit()
	}
	i++
}, 600)
```


### Informações Extras:
||Resultado|Tipo|
| - | - | - |
| se.resetar() | Limpa o console por completo. | Função |
| se.log(string, object) | Imprime um texto no console usando uma estrutura | Função |
| se.linha(number) | Força todas strings ser impressas apartir desta linha | Função |
| se.linhas | Retorna a contia de linhas imprimidas no console | Saida |
| se.colunas | Retorna a contia total de colunas no console | Saida |
|se.Fg<Cor>| Insere nas strings do  console a Cor descrita apos Fg| Saida |
|se.Bg<Cor>| Insere no fundo do console a Cor descrita apos Bg| Saida |
| valor.mask(string, string)|Muda o formato de impressão da string| Expressão|

### Lista de Cores:
| Nome | Ação |
|-|-|
|Reset|Retorna a fonte padrão
|Bright|Clareia a fonte
|Dim|Escurece a fonte
|Underscore|Sublinha a fonte
|Blink|Destaca Fonte e Fundo
|Reverse|Destaca o Fundo
|Hidden|Como o reset, porem menos efetivo
|||
|Black|Tonalidade Preta
|Red|Tonalidade Veremlha
|Green|Tonaldiade Verde
|Yellow|Tonalidade Amarela
|Blue|Tonalidade Azul
|Magenta|Tonalidade Roxa
|Cyan|Tonalidade Azul Claro
|White|Tonalidade Branca

**Obrigado pela sua atenção!**
