// console.clear()

// const camisaLacoste = {
//   descricao: "Camisa Lacoste",
//   preco: 399.98,
//   marca: "Lacoste",
//   tamanho: "GG",
//   cor: "Azul",
//   promo: false
// };

// const {descricao, preco, promo} = camisaLacoste

// console.log(`
// Produto: ${descricao}
// Preco: R$${preco.toFixed(2)}
// Promoção: ${promo? "Sim" : "Não"}
// `);

const evento = {
    dataEvento: new Date(2023,10,25),
    titulo: "JavaScript de cria",
    descricao: "JavaScript com crias certificados",
    presenca: true,
    comentario: "Odiei! :3"
}

const {dataEvento, titulo, descricao, ... resto} = evento

console.log(dataEvento);
console.log(titulo);
console.log(descricao);
console.log(resto);
// console.log(`
// Data do Evento : ${dataEvento}
// Título : ${titulo}
// Descrição : ${descricao}
// Presença: ${presenca ? "Confirmada" : "Não confirmada"}
// Comentário: ${comentario}
// `)