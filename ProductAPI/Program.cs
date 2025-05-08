using Microsoft.EntityFrameworkCore;
using ProductAPI.Data;
using ProductAPI.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer(); // 👉 cần cho Swagger
builder.Services.AddSwaggerGen();           // 👉 cần cho Swagger
builder.Services.AddDbContext<ProductDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Enable Swagger UI in Development
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseRouting();
app.UseAuthorization(); // 👈 cần nếu có authentication
app.MapControllers();   // 👈 chính xác hơn `UseEndpoints`

app.Run();
