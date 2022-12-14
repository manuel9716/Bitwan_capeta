using CRUD.Dto;
using CRUD.Dto.Inputs;

namespace CRUD.Repositories
{
    public interface IUsuarioRepositories
    {
        Task<UsuarioModels> GetUsuarios();
        ResponseModels InsertUsuario(InputUsuarioModels Dta);
        ResponseModels DeleteUsuarios(int Id);
        ResponseModels UpdateUsuarios(InputUsuarioModels Dta);
    }
}
