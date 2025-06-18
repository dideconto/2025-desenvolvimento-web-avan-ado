"use client";

import page from "@/app/page";
import api from "@/services/api";
import Pais from "@/types/pais";
import {
  Box,
  Link,
  Paper,
  Table,
  TableBody,
  TableCell,
  TableContainer,
  TableHead,
  TablePagination,
  TableRow,
  TextField,
  Typography,
} from "@mui/material";
import { useEffect, useState } from "react";

function ListarPaises() {
  const [paises, setPaises] = useState<Pais[]>([]);
  const [filtro, setFiltro] = useState<Pais[]>([]);
  const [busca, setBusca] = useState("");
  useEffect(() => {
    api
      .get<Pais[]>("all?fields=name,flags,population,ccn3")
      .then((resposta) => {
        console.table(resposta.data);
        setPaises(resposta.data);
        setFiltro(resposta.data);
      })
      .catch((erro) => {
        console.log(erro);
      });
  }, []);

  function filtrar(texto: string) {
    const resultado = paises.filter((pais) => {
      return pais.name.common
        .toLowerCase()
        .includes(texto.toLowerCase());
    });
    setFiltro(resultado);
  }

  return (
    <Box>
      <Typography variant="h4">Listar Países</Typography>

      <TextField
        fullWidth
        margin="normal"
        label="País"
        type="text"
        required
        onChange={(e) => filtrar(e.target.value)}
      />

      <TableContainer component={Paper} elevation={10}>
        <Table>
          <TableHead>
            <TableRow>
              <TableCell>#</TableCell>
              <TableCell>Nome</TableCell>
              <TableCell>População</TableCell>
              <TableCell>Detalhes</TableCell>
            </TableRow>
          </TableHead>
          <TableBody>
            {filtro.map((pais) => (
              <TableRow key={pais.ccn3}>
                <TableCell>{pais.ccn3}</TableCell>
                <TableCell>{pais.name.common}</TableCell>
                <TableCell>{pais.population}</TableCell>
                <TableCell>
                  <Link href={`/paises/detalhes/${pais.ccn3}`}>
                    Detalhes
                  </Link>
                </TableCell>
              </TableRow>
            ))}
          </TableBody>
        </Table>
      </TableContainer>
    </Box>
  );
}

export default ListarPaises;
