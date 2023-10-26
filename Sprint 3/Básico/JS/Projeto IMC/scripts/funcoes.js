function Calcular() {
    event.preventDefault();

    let n1 = parseFloat(document.getElementById('numero1').value);
    let n2 = parseFloat(document.getElementById('numero2').value);
    let op = document.getElementById('operacao').value;
    let res;

    if(isNaN(n1) || isNaN(n2)){
        alert("Preencha todos os campos")
        return;
    }

    if(op == "+"){
        res = Soma(n1, n2);
        console.log(`Resultado = ${res}`);
    }else if(op == "-"){
        res = Subtração(n1, n2);
        console.log(`Resultado = ${res}`);
    }else if(op == "*"){
        res = multiplicação(n1, n2);
        console.log(`Resultado = ${res}`);
    } if(op == "/"){
        res = divisão(n1, n2);
        console.log(`Resultado = ${res}`);
    }else{
        res = "O operador é inválido"
        console.log(`${res}`);
    }
    document.getElementById("Resultado").innerText = res
}

function Soma(x, y) {
    return (x + y).toFixed(2) //somente onde é numero 
}

function Subtração(x, y) {
    return (x - y).toFixed(2) //somente onde é numero 
}

function multiplicação(x, y) {
    return (x * y).toFixed(2) //somente onde é numero 
}

function divisão(x, y) {
    if(y == 0)
    {
        return "Divisão invalida, é necessário um 2° numero diferente do 0"
    }

    return (x / y).toFixed(2) //somente onde é numero 

}
