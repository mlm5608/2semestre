let eduardo = {
    nome: "eduardo",
    idade: 41,
    altura: 1.67
};

eduardo.peso = 89;


let carlos = new Object();

carlos.nome = 'carlos';
carlos.idade = 36;
carlos.sobrenome = 'roque'


let pessoas = []; 
pessoas.push(carlos);
pessoas.push(eduardo)

//console.log(pessoas);
// node ./scripts/objetos.js

pessoas.forEach((/*function*/f, i) => {
    console.log(`Pessoa ${i + 1}: ${f.nome}`)
})