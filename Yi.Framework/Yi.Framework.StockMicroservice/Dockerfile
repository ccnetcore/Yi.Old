#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Yi.Framework.StockMicroservice/Yi.Framework.StockMicroservice.csproj", "Yi.Framework.StockMicroservice/"]
COPY ["Yi.Framework.Service/Yi.Framework.Service.csproj", "Yi.Framework.Service/"]
COPY ["Yi.Framework.Core/Yi.Framework.Core.csproj", "Yi.Framework.Core/"]
COPY ["Yi.Framework.Model/Yi.Framework.Model.csproj", "Yi.Framework.Model/"]
COPY ["Yi.Framework.Common/Yi.Framework.Common.csproj", "Yi.Framework.Common/"]
COPY ["Yi.Framework.Interface/Yi.Framework.Interface.csproj", "Yi.Framework.Interface/"]
COPY ["Yi.Framework.DTOModel/Yi.Framework.DTOModel.csproj", "Yi.Framework.DTOModel/"]
COPY ["Yi.Framework.Task/Yi.Framework.Job.csproj", "Yi.Framework.Task/"]
COPY ["Yi.Framework.WebCore/Yi.Framework.WebCore.csproj", "Yi.Framework.WebCore/"]
RUN dotnet restore "Yi.Framework.StockMicroservice/Yi.Framework.StockMicroservice.csproj"
COPY . .
WORKDIR "/src/Yi.Framework.StockMicroservice"
RUN dotnet build "Yi.Framework.StockMicroservice.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Yi.Framework.StockMicroservice.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Yi.Framework.StockMicroservice.dll"]