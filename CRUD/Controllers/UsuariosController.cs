using AutoWrapper.Wrappers;
using CRUD.Dto;
using CRUD.Dto.Inputs;
using CRUD.Services;
using Microsoft.AspNetCore.Mvc;

namespace CRUD.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController: ControllerBase
    {
        private readonly IUsuariosServices _service;

        public UsuariosController(IUsuariosServices service)
        {
            _service = service;
        }

        [Route("consular")]
        [HttpGet]
        public async Task<IActionResult> GetUsuariosList()
        {
            var response = await _service.GetUsuarios();
                if (response != null)
            {
                return Ok(new ApiResponse("", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("", null, 404));
            }
            
        }

        [Route("insertar")]
        [HttpPost]
        public IActionResult InsertUsuario(InputUsuarioModels Dta)
        {
            var response = _service.InsertUsuario(Dta);

            if (response != null)
            {
                return Ok(new ApiResponse("Insert Usuario found.", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("Insert Usuario not found", null, 404));
            }
        }

        [Route("eliminar")]
        [HttpDelete]
        public IActionResult DeleteUsuarios(int Id)
        {
            var response = _service.DeleteUsuarios(Id);

            if (response != null)
            {
                return Ok(new ApiResponse("Delete Usuario found.", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("Delete Usuario not found", null, 404));
            }
        }

        [Route("actualizar")]
        [HttpPut]
        public IActionResult UpdateUsuarios(InputUsuarioModels Dta)
        {
            var response = _service.UpdateUsuarios(Dta);

            if (response != null)
            {
                return Ok(new ApiResponse("Update Usuario found.", response, 200));
            }
            else
            {
                return NotFound(new ApiResponse("Update Usuario not found", null, 404));
            }
        }

    }
}
