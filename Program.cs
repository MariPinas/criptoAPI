var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// (aqui ficam as logica do xor e nao sei oq, vms criar elas nas pastas dos service dps)
// builder.Services.AddSingleton<VernamService>();
// builder.Services.AddScoped<EncryptService>();
// builder.Services.AddScoped<DecryptService>();

var app = builder.Build();


if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();
app.Run();

//minimal api(como tava antes) X MVC(como ta agora) <------------------------

