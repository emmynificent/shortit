using Microsoft.EntityFrameworkCore;
using shortit.Data;
using shortit.Interface;
using shortit.UrlService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddScoped<IUrlService, UrlService>();
builder.Services.AddScoped<Random>();   

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<ShortenDbContext>(options=>{
    options.UseSqlServer(builder.Configuration.GetConnectionString("Shorter"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowBrowser", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });

   
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{ 
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseRouting();
app.UseCors("AllowBrowser");
app.UseAuthorization();
app.UseHttpsRedirection();


app.MapControllers();




app.Run();

