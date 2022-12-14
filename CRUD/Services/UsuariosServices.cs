using CRUD.Dto;
using CRUD.Dto.Inputs;
using CRUD.Repositories;

namespace CRUD.Services
{
    public class UsuariosServices : IUsuariosServices
    {
        private readonly IUsuarioRepositories _repository;

        public UsuariosServices(IUsuarioRepositories repository)
        {
            _repository = repository;
           
        }

        public async Task<UsuarioModels> GetUsuarios()
        {
           var GetResponse = await _repository.GetUsuarios();
            return GetResponse;
        }

        public ResponseModels InsertUsuario(InputUsuarioModels Dta)
        {
            var PostResponse = _repository.InsertUsuario(Dta);
            return PostResponse;
        }

        public ResponseModels DeleteUsuarios(int Id)
        {
            var DeleteResponse = _repository.DeleteUsuarios(Id);
            return DeleteResponse;
        }

        public ResponseModels UpdateUsuarios(InputUsuarioModels Dta)
        {
            var UpdateResponse = _repository.UpdateUsuarios(Dta);
            return UpdateResponse;
        }
    }
}
