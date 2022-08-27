var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddMemoryCache();
builder.Services.AddSession();
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
//DI
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DbConnection")));

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);

builder.Services.AddDbContext<AppIdentityDbContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("IdentityDbConnection")));
builder.Services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AppIdentityDbContext>()
                .AddDefaultTokenProviders();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();

builder.Services.AddScoped(sp => SessionShopCart.GetCart(sp));
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseStatusCodePages();
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
    db.Database.EnsureDeleted();
    db.Database.EnsureCreated();
}   
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseSession();

app.UseAuthentication();
app.UseAuthorization();

app.UseMvcWithDefaultRoute();
app.UseMvc(routes =>
{   
    routes.MapRoute(name: "pagination", template: "{controller=Category}/{action=ProductList}/{category}/{page?}");
    routes.MapRoute(name: "shopCart", template: "{controller=ShopCart}/{action=Cart}");
    routes.MapRoute(name: "AddshopCart", template: "{controller=ShopCart}/{action=AddToCart}/{id}");
    routes.MapRoute(name: "DeleteshopCart", template: "{controller=ShopCart}/{action=DeleteFromCart}/{id}");
    routes.MapRoute(name: "order", template: "{controller=Order}/{action=Checkout}/{order}");
});

app.Run();
