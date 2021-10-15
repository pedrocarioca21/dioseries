using System.Collections.Generic;

namespace dioseries.Interfaces

{
    public interface iRepositorio<T>
    {
         List<T> Lista();
         T RetornaPorId(int id);
         void insere(T entidade);
         void excluir(int id);
         void atualiza(int id, T entidade);
         int proximoId();
    }
}