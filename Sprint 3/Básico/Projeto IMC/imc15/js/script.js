//lista glogal
const listaPessoas = []; //lista vazia

function calcular(e) {
    e.preventDefault();

    let nome = document.getElementById("nome").value.trim();
    let peso = parseFloat(document.getElementById("peso").value);
    let altura = parseFloat(document.getElementById("altura").value);

    if(isNaN(peso) || isNaN(altura) || nome.lenght <= 2)
    {
        alert('É necessário preencher todos os campos, e de forma correta')
        return;
    }

    const imc = calcularIMC(peso, altura)
    const txtsituacao = geraSituacao(imc)

    const pessoa ={nome, altura, peso, imc: imc, situacao : txtsituacao}
    
    //Insere uma pessoa no array
    listaPessoas.push(pessoa);

    exibirDados();
    limparForm()
}


function calcularIMC(peso, altura) {
    return peso / (altura * altura)    
    //return peso / (altura ** 2)    
    //return peso / Math.pow(altura,2) 
}

function geraSituacao(imc) {
    if(imc < 18.5){
        return "magreza severa"
    }else if (imc <= 24.99){
        return "peso normal"
    }else if (imc <= 29.99){
        return "acima do peso"
    }else if (imc <= 34.99){
        return "obesidade I"
    }else if (imc <= 39.99){
        return "obesidade II"
    }else{
        alert("Procure um médico rapidamente, sua situação é extrema!")
        return "Obesidade III"
    }
}

function exibirDados() {
    let linhas = ""

    listaPessoas.forEach(function (oPessoa){
        linhas +=
        `
        <tr>
            <td data-cell="nome">${oPessoa.nome}</td>
            <td data-cell="altura">${oPessoa.altura}</td>
            <td data-cell="peso">${oPessoa.peso}</td>
            <td data-cell="IMC">${oPessoa.imc}</td>
            <td data-cell="Situação">${oPessoa.situacao}</td>
        </tr>
        `;
    });

    document.getElementById("corpo-tabela").innerHTML = linhas
}

function limparForm() {
    document.getElementById("nome").value = ""
    document.getElementById("peso").value = ""
    document.getElementById("altura").value = ""
}