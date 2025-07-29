using Aspire.Hosting.ApplicationModel;

var builder = DistributedApplication.CreateBuilder(args);

// Register microservices with HTTP endpoints
var userAuthService = builder.AddProject("UserAuthService", "../UserAuthService/UserAuthService.csproj")
    .WithHttpEndpoint(name: "userauth-http");

var accountsService = builder.AddProject("AccountsService", "../AccountsService/AccountsService.csproj")
    .WithHttpEndpoint(name: "accounts-http");

var transactionsService = builder.AddProject("TransactionsService", "../TransactionsService/TransactionsService.csproj")
    .WithHttpEndpoint(name: "transactions-http");

var budgetingService = builder.AddProject("BudgetingService", "../BudgetingService/BudgetingService.csproj")
    .WithHttpEndpoint(name: "budgeting-http");

var analyticsService = builder.AddProject("AnalyticsService", "../AnalyticsService/AnalyticsService.csproj")
    .WithHttpEndpoint(name: "analytics-http");

// Gateway
var gateway = builder.AddProject("Gateway", "../Gateway/Gateway.csproj")
    .WithHttpEndpoint(name: "gateway-http")
    .WithReference(userAuthService)
    .WithReference(accountsService)
    .WithReference(transactionsService)
    .WithReference(budgetingService)
    .WithReference(analyticsService);

builder.Build().Run();
