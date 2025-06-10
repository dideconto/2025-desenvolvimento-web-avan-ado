"use client";

import api from "@/services/api";
import Produto from "@/types/produto";
import { Container, Typography, TableContainer, Paper, Table, TableHead, TableRow, TableCell, TableBody, TablePagination } from "@mui/material";
import axios from "axios";
import { useEffect, useState } from "react";

function ProdutoListar() {
  const [page, setPage] = useState(0);
  const [rowsPerPage, setRowsPerPage] = useState(5);
  const [produtos, setProdutos] = useState<Produto[]>([]);

  useEffect(() => {
    api
      .get<Produto[]>("/produto/listar")
      .then((resposta) => {
        setProdutos(resposta.data);
        console.table(resposta.data);
      })
      .catch((erro) => {
        console.log(erro);
      });
  }, []);

  return (
    <Container maxWidth="md" sx={{ mt: 4 }}>
      <Typography variant="h4" component="h1" gutterBottom>
        Listar Produtos
      </Typography>
      <TableContainer component={Paper} elevation={10}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Nome</TableCell>
              <TableCell>Criado Em</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {produtos
              .slice(
                page * rowsPerPage,
                page * rowsPerPage + rowsPerPage
              )
              .map((produto) => (
                <TableRow key={produto.id}>
                  <TableCell>{produto.id}</TableCell>
                  <TableCell>{produto.nome}</TableCell>
                  <TableCell>{produto.criadoEm}</TableCell>
                </TableRow>
              ))}
          </TableBody>
        </Table>
        <TablePagination
          component="div"
          count={produtos.length}
          page={page}
          onPageChange={(_, newPage) => setPage(newPage)}
          rowsPerPage={rowsPerPage}
          onRowsPerPageChange={(e) => {
            setRowsPerPage(parseInt(e.target.value, 10));
            setPage(0);
          }}
          labelRowsPerPage="Itens por página"
        />
      </TableContainer>
    </Container>
  );
}

export default ProdutoListar;
