using System;
using System.Collections.Generic;
using dioseries.Interfaces;

namespace dioseries
{
    public class SerieRepositorio : iRepositorio<Serie>
    {

        private List<Serie> listaSerie = new List<Serie>();

        public void atualiza(int id, Serie entidade)
        {
            listaSerie[id] = entidade;
        }

        public void excluir(int id)
        {
            listaSerie[id].alternaStatus();
        }

        public void insere(Serie entidade)
        {
            listaSerie.Add(entidade);
        }

        public List<Serie> Lista()
        {
            return listaSerie;
        }

        public int proximoId()
        {
            return listaSerie.Count;
        }

        public Serie RetornaPorId(int id)
        {
            return listaSerie[id];
        }
    }
}