WebApplication app = WebApplication.Create();
app.Urls.Add("http://localhost:3000");
app.Urls.Add("http://*:3000");

superhero hero = new superhero();
hero.Name = "Superman";
hero.Power = 9000;
hero.UnderwearOutside = true;

app.MapGet("/", Answer);

app.MapGet("/superhero/", () =>
{
    return hero;
});

app.Run();

static string Answer()
{
    return "Hello";
}