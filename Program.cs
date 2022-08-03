var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddMvc(options => options.EnableEndpointRouting = false);
builder.Services.AddSession();

//DI
builder.Services.AddDbContext<ShopDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection")));
builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICategoryRepository, CategoryRepository>();
builder.Services.AddTransient<IShopCartRepository, ShopCartRepository>();
builder.Services.AddTransient<IOrderRepository, OrderRepository>();
builder.Services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
builder.Services.AddScoped(sp =>
{
    var shopCart = new ShopCart();
    return shopCart.GetShopCart(sp);
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    using var scope = app.Services.CreateScope();
    var db = scope.ServiceProvider.GetRequiredService<ShopDbContext>();
    db.Database.EnsureCreated();
}   
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();

app.UseAuthorization();


app.UseMvcWithDefaultRoute();
app.UseMvc(routes =>
{   
    routes.MapRoute(name: "categoryFilter", template: "{controller=Category}/{action=ProductList}/{category?}");
});

app.Run();
