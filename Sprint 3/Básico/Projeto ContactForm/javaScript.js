async function chamarApi() {
    const cep = document.getElementById("cep").value;
    const url = `https://viacep.com.br/ws/${cep}/json/`;
   try 
   {
        const promise = await fetch(url);
        const endereco = await promise.json();

        exibirEndereco(endereco);
   } catch (error) {
    alert("Deu ruim pae");
    
    limparEndereco()
    document.getElementById("not-found").innerText = "Cep Inválido"
   }
    
}