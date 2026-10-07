using AppFloraClick.Components;
using AppFloraClick.DAO;
using AppFloraClick.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddRazorComponents()
    .AddInteractiveServerComponents();

builder.Services.AddScoped<ClienteDAO>();
builder.Services.AddScoped<ProdutoDAO>();
builder.Services.AddScoped<AgendamentoDataDAO>();
builder.Services.AddScoped<ContatoVendedorDAO>();
builder.Services.AddScoped<SessaoUsuario>();

var app = builder.Build();

if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error", createScopeForErrors: true);
    app.UseHsts();
}

app.UseHttpsRedirection();

app.UseStaticFiles();

app.UseAntiforgery();

app.MapRazorComponents<App>()
    .AddInteractiveServerRenderMode();

app.Run();