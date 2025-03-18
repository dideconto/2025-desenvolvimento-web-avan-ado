import axios from "axios";
import { useEffect, useState } from "react";

function ListarProdutos() {
  const [produtos, setProdutos] = useState([]);

  useEffect(() => {
    axios.get("http://localhost:5082/api/produto/listar")
      .then((response) => {
        setProdutos(response.data);
    });
  }, []);

  return (
    <div>
      <h1>Componente da Listagem de Produtos</h1>
      <table>
        <tr>
            <th>Nome</th>
            <th>Preco</th>
        </tr>
        {produtos.map((produto : any) => (
            <tr>
                <td>{produto.nome}</td>
                <td>{produto.quantidade}</td>
            </tr>
        ))}
      </table>
      
    </div>
  );
}

export default ListarProdutos;
