import './App.css';
import Titulo from './components/Titulo/Titulo';
import CardEvento from './components/CardEvento/CardEvento';

function App() {
  return (
    <div className="App">
      <h1>Hello React</h1>
      <Titulo texto="Miguel"/>

       <CardEvento titulo = "Aula de React" texto = "Aula de React com o professor Eduardo!" textoLink = "Conectar"/>

      <CardEvento titulo = "Festa de fim de ano" texto = "Festa para todos os alunos em comemoração ao fim do ano letivo!" textoLink = "Conectar"/>
    </div>
  );
}

export default App;
