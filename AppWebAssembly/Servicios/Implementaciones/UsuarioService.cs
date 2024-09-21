using System;
using AppWebAssembly.Helpers;
using AppWebAssembly.Models;
using AppWebAssembly.Services.Interfaces;

namespace AppWebAssembly.Services.Implementaciones;

public class UsuarioService : IUsuarioService
{
    public readonly HttpClientHelper _clienteHelper;
    public UsuarioService(HttpClientHelper httpClientHelper){
        _clienteHelper = httpClientHelper;
    }

    public async Task<Usuario> CrearUsuarioAsync(Usuario usuario)
    {
        return await _clienteHelper.PostAsync("http://localhost:5263/api/Usuario", usuario);
    }

    public Task<List<Usuario>> ObtenerUsuariosAsync()
    {
        return _clienteHelper.GetTAsync<List<Usuario>>("http://localhost:5263/api/Usuario");
    }
}