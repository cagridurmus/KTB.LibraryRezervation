using KTB.LibraryRezervation.Web.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddMvc().AddRazorRuntimeCompilation();

builder.Services.AddHttpClient(); 
builder.Services.AddSingleton<IConfiguration>(builder.Configuration);

builder.Services.AddTransient<UserApiService>();
builder.Services.AddTransient<AuthApiService>();
builder.Services.AddTransient<LibraryHallApiService>();

builder.Services.AddTransient<DeskApiService>();
builder.Services.AddTransient<ReservationApiService>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Login}/{id?}");

app.Run();

