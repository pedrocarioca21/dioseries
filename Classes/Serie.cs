using System;

namespace dioseries
{
    public class Serie : EntidadeBase
    {
        private string titulo{get; set; }
        private string descricao{get; set; }
        private int anoLancamento{get; set; }
        private Plataforma plataforma {get; set;}
        private Genero genero {get; set;}
        private bool status {get; set;}

        public Serie(int id, Genero genero, Plataforma plataforma, string titulo, string descricao, int anoLancamento){
            this.Id = id;
            this.genero = genero;
            this.plataforma = plataforma;
            this.titulo = titulo;
            this.descricao = descricao;
            this.anoLancamento = anoLancamento;
            this.status = true;
        }

        public string retornaTitulo(){
            return this.titulo;
        }

        public int retornaId(){
            return this.Id;
        }

        public void alternaStatus(){
            this.status = !status;
        }

        public bool retornaStatus(){
            return status;
        }

        public override string ToString()
        {
            string retorno = "";
                
                retorno += "Título: " + this.titulo + Environment.NewLine;
                retorno += "Descrição: " + this.descricao + Environment.NewLine;
                retorno += "Genero: " + this.genero + Environment.NewLine;
                retorno += "Streaming: " + this.plataforma + Environment.NewLine;
                retorno += "Ano de lançamento: " + this.anoLancamento + Environment.NewLine;
                retorno += "Válido: " + this.status + Environment.NewLine;

            return retorno;
        }
    }
}