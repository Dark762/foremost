using Xunit;
using Moq;
using API_Task.DbContextTask.Interface;
using API_Task.Services.Impl;
using CrossCutting.DTO;
using CrossCutting.DTO.Usuario;
using System.Threading.Tasks;
using CrossCutting.Models;

public class UsuarioServiceTests
{
    private readonly Mock<IUsuarioContext> _mockUsuarioContext;
    private readonly UsuarioService _usuarioService;

    public UsuarioServiceTests()
    {
        _mockUsuarioContext = new Mock<IUsuarioContext>();
        _usuarioService = new UsuarioService(_mockUsuarioContext.Object);
    }

    [Fact]
    public async Task ActualizarUsuario_SuccessfulUpdate_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new UsuarioUpdateDTO { Id = 1, Nombre = "Test" };
        _mockUsuarioContext.Setup(x => x.ActualizarUsuario(It.IsAny<UsuarioUpdateDTO>())).ReturnsAsync(true);

        // Act
        var response = await _usuarioService.ActualizarUsuario(request);

        // Assert
        Assert.True(response.Success);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task ActualizarUsuario_FailedUpdate_ReturnsFailureResponse()
    {
        // Arrange
        var request = new UsuarioUpdateDTO { Id = 1, Nombre = "Test" };
        _mockUsuarioContext.Setup(x => x.ActualizarUsuario(It.IsAny<UsuarioUpdateDTO>())).ReturnsAsync(false);

        // Act
        var response = await _usuarioService.ActualizarUsuario(request);

        // Assert
        Assert.False(response.Success);
        Assert.Equal(412, response.StatusCode);
        Assert.Equal("Ocurrio un problema al actualizar el usuario", response.Message);
    }
    [Fact]
    public async Task BorrarUsuario_SuccessfulDeletion_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new UsuarioFilterDTO { Id = 1 };
        _mockUsuarioContext.Setup(x => x.BorrarUsuario(It.IsAny<UsuarioFilterDTO>())).ReturnsAsync(true);

        // Act
        var response = await _usuarioService.BorrarUsuario(request);

        // Assert
        Assert.True(response.Success);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task BorrarUsuario_FailedDeletion_ReturnsFailureResponse()
    {
        // Arrange
        var request = new UsuarioFilterDTO { Id = 1 };
        _mockUsuarioContext.Setup(x => x.BorrarUsuario(It.IsAny<UsuarioFilterDTO>())).ReturnsAsync(false);

        // Act
        var response = await _usuarioService.BorrarUsuario(request);

        // Assert
        Assert.False(response.Success);
        Assert.Equal(412, response.StatusCode);
        Assert.Equal("Ocurrio un problema al botrar el usuario", response.Message);
    }
    [Fact]
    public async Task CrearUsuario_SuccessfulCreation_ReturnsSuccessResponse()
    {
        // Arrange
        var request = new UsuarioCreateDTO { Nombre = "Test" };
        _mockUsuarioContext.Setup(x => x.CrearUsuario(It.IsAny<UsuarioCreateDTO>())).ReturnsAsync(true);

        // Act
        var response = await _usuarioService.CrearUsuario(request);

        // Assert
        Assert.True(response.Success);
        Assert.Equal(200, response.StatusCode);
    }

    [Fact]
    public async Task CrearUsuario_FailedCreation_ReturnsFailureResponse()
    {
        // Arrange
        var request = new UsuarioCreateDTO { Nombre = "Test" };
        _mockUsuarioContext.Setup(x => x.CrearUsuario(It.IsAny<UsuarioCreateDTO>())).ReturnsAsync(false);

        // Act
        var response = await _usuarioService.CrearUsuario(request);

        // Assert
        Assert.False(response.Success);
        Assert.Equal(412, response.StatusCode);
        Assert.Equal("Ocurrio un problema al crear el usuario", response.Message);
    }

    [Fact]
    public async Task ListaUsuarios_SuccessfulListing_ReturnsUserList()
    {
        // Arrange
        var usuarios = new List<Usuario> { new Usuario { Id = 1, Nombre = "Test" } };
        _mockUsuarioContext.Setup(x => x.ListaUsuarios()).ReturnsAsync(usuarios);

        // Act
        var response = await _usuarioService.ListaUsuarios();

        // Assert
        Assert.True(response.Success);
        Assert.Equal(200, response.StatusCode);
        Assert.NotNull(response.Data);
        Assert.Single(response.Data);
    }

    [Fact]
    public async Task ListaUsuarios_FailedListing_ReturnsFailureResponse()
    {
        // Arrange
        _mockUsuarioContext.Setup(x => x.ListaUsuarios()).ThrowsAsync(new Exception("Database Error"));

        // Act
        var response = await _usuarioService.ListaUsuarios();

        // Assert
        Assert.False(response.Success);
        Assert.Equal(500, response.StatusCode);
        Assert.Equal("Ocurrio un error al listar los usuarios.", response.Message);
    }
}