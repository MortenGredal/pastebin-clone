using pastebin_clone_2.models;
using pastebin_clone_2.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.Configure<PastebinConnectionSettings>(
    builder.Configuration.GetSection("PasteDatabase"));

builder.Services.AddControllers()
    .AddJsonOptions(
        options => options.JsonSerializerOptions.PropertyNamingPolicy = null);


builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<PasteService>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.UseSwagger();
app.MapControllers();

app.UseSwaggerUI();

app.Run();