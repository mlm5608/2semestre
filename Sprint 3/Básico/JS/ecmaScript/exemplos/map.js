//foreach - void
//map - novo array modificado
//filter - novo array somente com os elementos que atenderam a uma condição
//reduce - retorna a soma dos valores a partir de um valor inicial 

//Map ===================================================
// const numeros = [1,5,13,20,28];

// const dobro = numeros.map((n) => {
//     return n * 2
// });

// console.log(numeros);
// console.log(dobro);

//Filter ================================================

// const numeros = [1,5,13,20,28];

// const maiorQ10 = numeros.filter( e => {
//     return e > 10;
// });

// console.log(maiorQ10);

// const comentarios =[
//     {comentarios: "bla bla bla", exibe: true},
//     {comentarios: "que evento bosta", exibe: false},
//     {comentarios: "Ótimo evento", exibe: true}
// ];

// const comentariosOk = comentarios.filter( c => {
//     //return c.exibe == true;
//     return c.exibe
// });

// comentariosOk.forEach((c,i) => {
//     console.log(`Comentário ${i + 1}: ${c.comentarios}`);
// });

//Reduce=================================================

const numeros = [1,5,13,20,28];

const soma = numeros.reduce( (vlInicial, n) => {
    return vlInicial + n
}, 3/*valor que inicia a soma*/)

console.log(soma);