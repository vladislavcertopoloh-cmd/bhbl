# Используем SDK 10.0 для сборки проекта
FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /app

# Копируем файл проекта и восстанавливаем зависимости
COPY *.csproj ./
RUN dotnet restore

# Копируем вообще все остальные файлы и папки (Models, Controllers и т.д.)
COPY . ./

# Собираем проект в папку 'out'
RUN dotnet publish -c Release -o out

# Используем среду выполнения ASP.NET 10.0
FROM mcr.microsoft.com/dotnet/aspnet:10.0
WORKDIR /app
COPY --from=build /app/out .

# Указываем файл запуска (убедись, что имя совпадает с твоим .csproj)
ENTRYPOINT ["dotnet", "WebApplication1.dll"]
