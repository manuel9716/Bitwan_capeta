using CRUD.Dto;
using CRUD.Dto.Inputs;

namespace CRUD.Services
{
    public interface IUsuariosServices
    {
        Task<UsuarioModels> GetUsuarios();
        ResponseModels InsertUsuario(InputUsuarioModels Dta);
        ResponseModels DeleteUsuarios(int Id);
        ResponseModels UpdateUsuarios(InputUsuarioModels Dta);

    }
}
