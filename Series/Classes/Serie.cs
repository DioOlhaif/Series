﻿using System;
using System.Collections.Generic;
using System.Text;


namespace Series
{
   public  class Serie:EntidadeBase
    {
        private Genero Genero { get; set; }
        private string Titulo { get; set; }
        private string Descricao { get; set; }
        private int Ano { get; set; }
        private bool Excluido { get; set; }

        public Serie(int id, Genero genero, string titulo, string descricao, int ano)
        {
            this.Id = id;
            this.Titulo = titulo;
            this.Descricao = descricao;
            this.Ano = ano;
            this.Excluido = false;
            this.Genero = genero;
        }
        public override string ToString()
        {
            string retorno = "";
            retorno += " Gênero: " + this.Genero + Environment.NewLine;
            retorno += " Título: " + this.Titulo + Environment.NewLine;
            retorno += " Descrição: " + this.Descricao + Environment.NewLine;
            retorno += " Ano: " + this.Ano + Environment.NewLine;
            retorno += " Excluido:" + this.Excluido + Environment.NewLine;
            return retorno;
        }

        public string RetornaTitulo()
        {
            return this.Titulo;
        }

        public int RetornaId()
        {
            return this.Id;
        }

        public bool RetornaExcluido()
        {
            return this.Excluido;

        }

        public void Excluir()
        {
            this.Excluido = true;
        }

    }
}
