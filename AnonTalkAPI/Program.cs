using AnonTalkAPI.Data;
using AnonTalkAPI.Services;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.FileProviders;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IBoardService, BoardService>();
builder.Services.AddTransient<IPostService, PostService>();
builder.Services.AddTransient<ICommentService, CommentService>();
builder.Services.AddAutoMapper(typeof(Program).Assembly);
string? AnonTalkAPIConnection = builder.Configuration.GetConnectionString("AnonTalkAPI");
builder.Services.AddDbContext<AnonTalkAPIContext>(
    options => options.UseSqlServer(AnonTalkAPIConnection)
    );

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(
           Path.Combine(builder.Environment.ContentRootPath, "StaticFiles")),
    RequestPath = "/StaticFiles"
});

app.UseAuthorization();

app.MapControllers();

app.Run();
