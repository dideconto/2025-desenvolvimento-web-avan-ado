"use client";
import api from "@/services/api";
import Pais from "@/types/pais";
import {
  Box,
  Card,
  CardContent,
  CardMedia,
  Typography,
} from "@mui/material";
import { useParams } from "next/navigation";
import { useEffect, useState } from "react";

function Detalhes() {
  const params = useParams();
  const { codigo, nome, filtro } = params;
  const [pais, setPais] = useState<Pais>();
  useEffect(() => {
    api
      .get<Pais[]>(`alpha/${codigo}`)
      .then((resposta) => {
        setPais(resposta.data[0]);
      })
      .catch((erro) => {
        console.log(erro);
      });
  }, []);
  return (
    <Box sx={{ padding: 4 }}>
      <Typography variant="h3" gutterBottom>
        Detalhe do País
      </Typography>

      <Card
        sx={{
          display: "flex",
          flexDirection: { xs: "column", sm: "row" },
          alignItems: "center",
          padding: 2,
        }}
      >
        <CardMedia
          component="img"
          image={pais?.flags.png}
          alt={`Bandeira de ${pais?.name.common}`}
          sx={{
            width: 200,
            height: "auto",
            marginRight: { sm: 3 },
            borderRadius: 2,
          }}
        />

        <CardContent>
          <Typography variant="h4" component="div" gutterBottom>
            {pais?.name.common}
          </Typography>
          <Typography variant="body1" color="text.secondary">
            <strong>População:</strong>{" "}
            {pais?.population.toLocaleString()}
          </Typography>
          <Typography variant="body1" color="text.secondary">
            <strong>Código (CCN3):</strong> {pais?.ccn3}
          </Typography>
        </CardContent>
      </Card>
    </Box>
  );
}

export default Detalhes;
