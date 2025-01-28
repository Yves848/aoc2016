param (
  [string]$project
)

mcd $project
dotnet new console
dotnet new sln
dotnet sln add $project".csproj"
cp ../Program.cs .
ni test.txt
ni data.txt
cd ..