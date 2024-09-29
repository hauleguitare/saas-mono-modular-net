FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["MonoModularNet.WebAppBootstrapper/MonoModularNet.WebAppBootstrapper.csproj", "MonoModularNet.WebAppBootstrapper/"]
COPY ["MonoModularNet.Infrastructure.CQRS/MonoModularNet.Infrastructure.CQRS.csproj", "MonoModularNet.Infrastructure.CQRS/"]
COPY ["SharedKernel/SharedKernel.csproj", "SharedKernel/"]
COPY ["MonoModularNet.Infrastructure.DAL/MonoModularNet.Infrastructure.DAL.csproj", "MonoModularNet.Infrastructure.DAL/"]
COPY ["Core/Core.csproj", "Core/"]
COPY ["MonoModularNet.Module.Auth.Infrastructure/MonoModularNet.Module.Auth.Infrastructure.csproj", "MonoModularNet.Module.Auth.Infrastructure/"]
COPY ["MonoModularNet.Module.Auth/MonoModularNet.Module.Auth.csproj", "MonoModularNet.Module.Auth/"]
COPY ["MonoModularNet.Infrastructure.Shared/MonoModularNet.Infrastructure.Shared.csproj", "MonoModularNet.Infrastructure.Shared/"]
COPY ["MonoModularNet.Module.Auth.Core/MonoModularNet.Module.Auth.Core.csproj", "MonoModularNet.Module.Auth.Core/"]
RUN dotnet restore "MonoModularNet.WebAppBootstrapper/MonoModularNet.WebAppBootstrapper.csproj"
COPY . .
WORKDIR "/src/MonoModularNet.WebAppBootstrapper"
RUN dotnet build "MonoModularNet.WebAppBootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "MonoModularNet.WebAppBootstrapper.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MonoModularNet.WebAppBootstrapper.dll"]
