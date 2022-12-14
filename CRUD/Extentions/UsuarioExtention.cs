using CRUD.Repositories;
using CRUD.Services;

namespace CRUD.Extentions
{
    public static class UsuarioExtention
    {
        public static IServiceCollection AddUsuarioExtention(this IServiceCollection Services)
        {
            Services.AddScoped<IUsuariosServices, UsuariosServices>();
            Services.AddScoped<IUsuarioRepositories, UsuarioRespositories>();
            return Services;
        }

    }
}
