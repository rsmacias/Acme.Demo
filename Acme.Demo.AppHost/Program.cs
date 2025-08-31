var builder = DistributedApplication.CreateBuilder(args);

var dbPassword = builder.AddParameter("sqlPassword");

var database = builder.AddSqlServer("acmedbconnstr", password: dbPassword, port: 7200)
    .WithLifetime(ContainerLifetime.Persistent)
    .WithDataVolume()
    .AddDatabase("AcmeDb");

builder.AddSqlProject<Projects.Demo_Database>("demo-db")
    .WithReference(database)
    .WaitFor(database);

builder.AddProject<Projects.Demo_Api>("demo-api")
    .WithReference(database)
    .WaitFor(database);

builder.Build().Run();
