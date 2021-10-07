using WebApplication1;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages().AddRazorRuntimeCompilation();

var app = builder.Build();

// register terminal middleware at the start of the pipeline to prevent any further processing

// app.Run(TerminalMiddleware);
// app.Run(async context => {
//     await context.Response.WriteAsync("That’s all, folks!");
// });

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

// app.Use(PassThroughMiddleware);

// typeof
app.UseMiddleware(typeof(IpAddressMiddleware));
// generic
app.UseMiddleware<IpAddressMiddleware>();
// extension method
app.UseIpAddressMiddleware();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.Run();

async Task TerminalMiddleware(HttpContext context)
{
    await context.Response.WriteAsync("That's all, folks!");
}

async Task PassThroughMiddleware(HttpContext context, Func<Task> next)
{
    if (context.Request.Query.ContainsKey("stop"))
    {
        await context.Response.WriteAsync("Stop the world");
    }
    else
    {
        await next();
    }
}