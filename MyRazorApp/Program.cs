var builder = WebApplication.CreateBuilder(args);
// Informar ao projeto que vamos trabalhar com RazorPages
builder.Services.AddRazorPages();

var app = builder.Build();

// Configuração para trabalhar com browser

// Trabalhar com HTTPS
app.UseHttpsRedirection();
// Trabalhar com arquivos estáticos
app.UseStaticFiles();

// Auxiliar no mapeamento das páginas
app.UseRouting();
app.MapRazorPages();


app.Run();
