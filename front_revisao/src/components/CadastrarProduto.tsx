import axios from "axios";
import { useState } from "react";

function CadastrarProduto() {
  const [nome, setNome] = useState("");

  function cadastrarProduto(e : any) {
    e.preventDefault();
    const produto : any = {
        nome : nome,
        quantidade : 123
    };

    axios.post("http://localhost:5082/api/produto/cadastrar", produto)
        .then((response) => {
            console.log("Enviamos o produto!");    
            console.log(response.data);
        });
  }

  return (
    <div>
      <form onSubmit={cadastrarProduto}>
        <h1>Cadastrar Produtos</h1>
        <div>
          <label>Nome</label>
          <input type="text" onChange={(e: any) => setNome(e.target.value)} />
        </div>
        <button type="submit">Cadastrar</button>
      </form>
    </div>
  );
}

export default CadastrarProduto;
