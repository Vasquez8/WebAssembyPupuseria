using System;
using AppWebAssembly.Models;

namespace AppWebAssembly.Services.Interfaces;

public interface IUsuarioService
{
    Task<List<Usuario>> ObtenerUsuariosAsync();
    Task<Usuario> CrearUsuarioAsync(Usuario usuario);
}
