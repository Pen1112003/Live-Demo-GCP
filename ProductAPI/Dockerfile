# Sử dụng image nền cho ASP.NET
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080
EXPOSE 8081

# Sử dụng image SDK cho quá trình build
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["ProductAPI/ProductAPI.csproj", "ProductAPI/"]
RUN dotnet restore "ProductAPI/ProductAPI.csproj"
COPY . .
WORKDIR "/src/ProductAPI"
RUN dotnet build "ProductAPI.csproj" -c $BUILD_CONFIGURATION -o /app/build

# Tạo bản publish cho ứng dụng
FROM build AS publish
RUN dotnet publish "ProductAPI.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

# Cuối cùng, sử dụng image base và copy kết quả từ bước publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ProductAPI.dll"]
