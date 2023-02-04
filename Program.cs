using Autofac;
using Autofac.Extensions.DependencyInjection;
using chessAPI;
using chessAPI.business.interfaces;
using chessAPI.models.game;
using chessAPI.models.player;
using chessAPI.models.team;
using Microsoft.AspNetCore.Authorization;
using Serilog;
using Serilog.Events;

//Serilog logger (https://github.com/serilog/serilog-aspnetcore)
Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning)
    .Enrich.FromLogContext()
    .WriteTo.Console()
    .CreateBootstrapLogger();

try
{
    Log.Information("chessAPI starting");
    var builder = WebApplication.CreateBuilder(args);

    var connectionStrings = new connectionStrings();
    builder.Services.AddOptions();
    builder.Services.Configure<connectionStrings>(builder.Configuration.GetSection("ConnectionStrings"));
    builder.Configuration.GetSection("ConnectionStrings").Bind(connectionStrings);

    // Two-stage initialization (https://github.com/serilog/serilog-aspnetcore)
    builder.Host.UseSerilog((context, services, configuration) => configuration.ReadFrom
             .Configuration(context.Configuration)
             .MinimumLevel.Override("Microsoft.AspNetCore", LogEventLevel.Warning).ReadFrom
             .Services(services).Enrich
             .FromLogContext().WriteTo
             .Console());

    // Autofac como inyección de dependencias
    builder.Host.UseServiceProviderFactory(new AutofacServiceProviderFactory());
    builder.Host.ConfigureContainer<ContainerBuilder>(builder => builder.RegisterModule(new chessAPI.dependencyInjection<int, int>()));
    var app = builder.Build();
    app.UseSerilogRequestLogging();
    app.UseMiddleware(typeof(chessAPI.customMiddleware<int>));
    app.MapGet("/", () =>
    {
        return "hola mundo";
    });

    #region player

    app.MapPost("/player", 
    [AllowAnonymous] async(IPlayerBusiness<int> bs, clsNewPlayer newPlayer) => Results.Ok(await bs.addPlayer(newPlayer)));

    app.MapGet("/getplayers",
    [AllowAnonymous] async(IPlayerBusiness<int> bs) => Results.Ok(await bs.getPlayers()));

    app.MapPut("/updateplayer",
    [AllowAnonymous] async(IPlayerBusiness<int> bs, clsUpdatePlayer updatePlayer) => Results.Ok(await bs.updatePlayer(updatePlayer)));

    #endregion

    #region game

    app.MapPost("/game",
    [AllowAnonymous] async(IGameBusiness<int> bs, clsNewGame newGame) => Results.Ok(await bs.addGame(newGame)));

    app.MapGet("/getgames",
    [AllowAnonymous] async(IGameBusiness<int> bs) => Results.Ok(await bs.getGames()));

    app.MapPut("/updategame",
    [AllowAnonymous] async(IGameBusiness<int> bs, clsUpdateGame updateGame) => Results.Ok(await bs.updateGame(updateGame)));

    #endregion

    #region Team

    app.MapPost("/team",
    [AllowAnonymous] async(ITeamBusiness<int> bs, clsNewTeam newTeam) => Results.Ok(await bs.addTeam(newTeam)));

    app.MapGet("/getteams",
    [AllowAnonymous] async(ITeamBusiness<int> bs) => Results.Ok(await bs.getTeams()));

    app.MapPut("/updateteam",
    [AllowAnonymous] async(ITeamBusiness<int> bs, clsUpdateTeam updateTeam) => Results.Ok(await bs.updateTeam(updateTeam)));

    #endregion

    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "chessAPI terminated unexpectedly");
}
finally
{
    Log.CloseAndFlush();
}
