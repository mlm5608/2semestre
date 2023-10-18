
//Arrow Functions ==========================

// const somar = function name(x, y) {
//     return x + y
// }

// console.log(somar (50, 10));

// const dobro = (num) => {
//     return num * 2
// }
// ===========================

// const dobro = num => {
//     return num * 2
// }
// ===========================

// const dobro = num => num * 2   
// console.log(dobro(10));

// const boaTarde = () => { console.log("Boa Tarde!") }
// boaTarde();

// Listas =============================

const convidados = [
    {nome: "Sampaio", idade: 18},
    {nome: "Vascaino", idade: 17},
    {nome: "Vila Elba", idade: 18},
    {nome: "Peladinho", idade: 16},
    {nome: "Vini", idade: 19},
    {nome: "Heitor", idade: 36}
]

convidados.forEach( (p, i) => {
    console.log(`Convidado ${i + 1}: ${p}`); 
});