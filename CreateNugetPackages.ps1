$ErrorActionPreference = 'Stop'
Remove-Item -Force ./dist/*nupkg -ErrorAction Ignore
nuget pack Nicologies.SqlServerUtils.Metadata.csproj -OutputDirectory dist -Prop Configuration=Release
