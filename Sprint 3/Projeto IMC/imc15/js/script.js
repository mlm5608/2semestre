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
    const situacao = geraSituacao(imc)

    const pessoa ={
        nome : nome,
        altura : altura,
        peso : peso,
        imc : imc,
        situacao : situacao
    }
    console.log(pessoa);
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