const convidados = [
    {nome: "Sampaio", idade: 18},
    {nome: "Vascaino", idade: 17},
    {nome: "Vila Elba", idade: 18},
    {nome: "Peladinho", idade: 16},
    {nome: "Vini", idade: 19},
    {nome: "Heitor", idade: 36}
]

// const camisaLacoste ={
//     descricao: "Camisa da Lacoste",
//     preco: 399.98,
//     marca: "Lacoste",
//     tamanho: "G",
//     cor: "azul",
//     promo: true
// }

// // const descricao = camisaLacoste.descricao;
// // const preco = camisaLacoste.preco
// const {descricao, preco, promo} = camisaLacoste;

// console.log(`
//     Produto: ${descricao}
//     Preço: ${preco}
//     Promoção: ${promo ? "Sim" : "Não"}
// `);

/*crie um objeto evento com as propriedades 
    Data evento
    Descricao
    Titulo
    Presenca
    Comentario
*/

const evento =
{
    titulo: "Aula de javaScript",
    dataEvento: new Date(),
    descricao: "Aula básica de java script com os professores edu e carlos!",
    presenca: true,
    comentario:"Evento Incrível",
}

const { titulo, dataEvento, descricao, ...resto} = evento

console.log(`
    Evento: ${titulo}
    Descrição: ${descricao}
    Data: ${dataEvento}
    Presença: ${resto.presenca? "confirmado": "nao confirmado"}
    Comentario: ${resto.comentario}
`);