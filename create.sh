proj=Microservices.Net
projFolder="$PWD"
microFolder=Microservices  
# /Microservices.Net

#create solution
dotnet new sln --name $proj

# create projects
dotnet new webapi -n Gateway.WebApi
cd "$projFolder"/Gateway.WebApi
dotnet add package Ocelot

# rm -rf -v !(.|*.sh)

cd $projFolder
mkdir -p $microFolder
cd $projFolder/$microFolder
dotnet new webapi -n Product.Microservice
dotnet new webapi -n Customer.Microservice

# rm -rf ./[!.]**