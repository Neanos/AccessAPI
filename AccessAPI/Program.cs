WebApplication app = WebApplication.Create();
app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

List<superhero> heroes = new();
heroes.Add(new() {Name="Superman", Power=9001});
heroes.Add(new() {Name="Batman", Power=9});
heroes.Add(new() {Name="Wallman", Power=-5});

app.MapGet("/", Answer);


app.MapGet("/superhero/", () =>
{
    return heroes;
});

app.MapGet("/superhero/{num}", (int num) =>
{
    if( num >= 0 && num < heroes.Count)
    {
        return Results.Ok(heroes[num]);

    }
    return Results.NotFound();
});

app.MapPost("/superhero", (superhero h) =>
{
    Console.WriteLine(h.Name);
});

app.Run();

static string Answer()
{
    return "Hello";
}