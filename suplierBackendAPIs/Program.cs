using Microsoft.EntityFrameworkCore;
using RepositoryLayer;
using RepositoryLayer.Repository;
using ServiceLayer.IServices;
using ServiceLayer.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngularDev", 
        builder =>builder.WithOrigins("http://localhost:4200")
        .AllowAnyMethod()
        .AllowAnyHeader());
});



// call startup class
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddDbContext<SupplierAPIDbContext>(options =>
                 options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
//estado
builder.Services.AddScoped<ITipoDocumentoService, TipoDocumentoService>();
//tipo documento
builder.Services.AddScoped<IEstadoService, EstadoService>();
//pais
builder.Services.AddScoped<IPaisService, PaisService>();
//ciudad
builder.Services.AddScoped<ICiudadService, CiudadService>();
//configuracion
builder.Services.AddScoped<IConfiguracionGeneralService, ConfiguracionGeneralService>();
//rol
builder.Services.AddScoped<IRolService, RolService>();
//auth
builder.Services.AddScoped<IAuthService, AuthService>();
//usuario
builder.Services.AddScoped<IUsuarioService, UsuarioService>();
//categoria
builder.Services.AddScoped<ICategoriaService, CategoriaService>();
//catalogo documento
builder.Services.AddScoped<ICatalogoDocumentoService, CatalogoDocumentoService>();
//tipo compra
builder.Services.AddScoped<ITipoCompraService, TipoCompraService>();
//subtipo compra
builder.Services.AddScoped<ISubtipoCompraService, SubtipoCompraService>();
//proveedor
builder.Services.AddScoped<IProveedorService, ProveedorService>();
//documento
builder.Services.AddScoped<IDocumentoService, DocumentoService>();
//configuracion notificacion
builder.Services.AddScoped<IConfiguracionNotificacionService, ConfiguracionNotificacionService>();
//proveedor categoria
//referencia
builder.Services.AddScoped<IReferenciaService, ReferenciaService>();
//proveedor categoria
builder.Services.AddScoped<IProveedorCategoriaService, ProveedorCategoriaService>();



var app = builder.Build();
app.UseCors("AllowAngularDev");

//Configure the HTTP request pipeline.

app.UseSwagger();
app.UseSwaggerUI();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
