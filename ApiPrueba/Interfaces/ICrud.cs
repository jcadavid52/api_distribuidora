using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiPrueba.Interfaces
{
    interface ICrud<model>
    {
        List<model> Listar();
        model Consultar(int id);
        bool Insertar(model createModel);
        bool Actualizar(model modifiedModel);
        bool Eliminar(model deleteModel);

    }
}
