# build server
FROM mcr.microsoft.com/dotnet/framework/sdk:4.8 as build

WORKDIR /src

# restore dependencies through docker caching
COPY Tyler.TMS.Bridge/Tyler.TMS.Bridge.sln .
COPY Tyler.TMS.Bridge/Tyler.TMS.Bridge.Admin/Tyler.TMS.Bridge.Admin.csproj Tyler.TMS.Bridge.Admin/Tyler.TMS.Bridge.Admin.csproj
COPY Tyler.TMS.Bridge/Tyler.TMS.Bridge.Core/Tyler.TMS.Bridge.Core.csproj Tyler.TMS.Bridge.Core/Tyler.TMS.Bridge.Core.csproj
COPY Tyler.TMS.Bridge/Tyler.TMS.Bridge.Desktop/Tyler.TMS.Bridge.Desktop.csproj Tyler.TMS.Bridge.Desktop/Tyler.TMS.Bridge.Desktop.csproj
COPY Tyler.TMS.Bridge/Tyler.TMS.Bridge.Service/Tyler.TMS.Bridge.Service.csproj Tyler.TMS.Bridge.Service/Tyler.TMS.Bridge.Service.csproj
COPY Tyler.TMS.Bridge/Tyler.TMS.Bridge.SetupHelper/Tyler.TMS.Bridge.SetupHelper.csproj Tyler.TMS.Bridge.SetupHelper/Tyler.TMS.Bridge.SetupHelper.csproj
COPY Tyler.TMS.Core/Tyler.TMS.Core.Common/Tyler.TMS.Core.Common.csproj /../Tyler.TMS.Core/Tyler.TMS.Core.Common/Tyler.TMS.Core.Common.csproj 
COPY Tyler.TMS.Core/Tyler.TMS.Core.ServiceClient/Tyler.TMS.Core.ServiceClient.csproj /../Tyler.TMS.Core/Tyler.TMS.Core.ServiceClient/Tyler.TMS.Core.ServiceClient.csproj 
COPY Tyler.Drive/Tyler.Drive.Model/Tyler.Drive.Model.csproj /../Tyler.Drive/Tyler.Drive.Model/Tyler.Drive.Model.csproj
COPY Tyler.TMS.Security/Tyler.TMS.Security.DomainModel/Tyler.TMS.Security.DomainModel.csproj /../Tyler.TMS.Security/Tyler.TMS.Security.DomainModel/Tyler.TMS.Security.DomainModel.csproj
COPY Tyler.TMS.Core/Tyler.TMS.Core.SearchEngine/Tyler.TMS.Core.SearchEngine.csproj /../Tyler.TMS.Core/Tyler.TMS.Core.SearchEngine/Tyler.TMS.Core.SearchEngine.csproj 
COPY Tyler.TMS.Core/Tyler.TMS.Core.Security/Tyler.TMS.Core.Security.csproj /../Tyler.TMS.Core/Tyler.TMS.Core.Security/Tyler.TMS.Core.Security.csproj
COPY Tyler.TMS/Tyler.TMS.DomainModel/Tyler.TMS.DomainModel.csproj /../Tyler.TMS/Tyler.TMS.DomainModel/Tyler.TMS.DomainModel.csproj

#run nuget restore OR msbuild /restore
RUN nuget restore 

#gives the view inside your docker container
RUN dir

# build
RUN msbuild /p:Configuration=Release /m 

# production runtime
FROM mcr.microsoft.com/dotnet/framework/runtime:4.8

WORKDIR /app
COPY --from=build /src/Tyler.TMS.Bridge.Service/bin/Release .

CMD ["Tyler.TMS.Bridge.Service.exe"]

