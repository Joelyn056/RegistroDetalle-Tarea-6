using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Linq.Expressions;

namespace RegistroDetalleTarea6.DAL
{
    public interface JRepository<T> where T : class
    {
        List<T> GetList(Expression<Func<T, bool>> expression);

        T Buscar(int id);
        bool Guardar(T entity);
        bool Modificar(T entity);
        bool Eliminar(int id);
    }
}
