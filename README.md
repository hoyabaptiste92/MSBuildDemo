# MSBuildDemo

## Assembly Version update during build

### 1. Comment out Assembly Version Attributes in Properties/AssemblyInfo.cs

```csharp
// Version information for an assembly consists of the following four values:
//
//      Major Version
//      Minor Version
//      Build Number
//      Revision
//
// You can specify all the values or you can default the Build and Revision Numbers
// by using the '*' as shown below:
//[assembly: AssemblyVersion("1.0.*")]
//[assembly: AssemblyVersion("1.0.0.1")]
//[assembly: AssemblyFileVersion("1.0.0.2")]
```

### 2. Add this xml to each csproj file

This will tell MSBuild to create a Version.cs file on the fly with the Assembly Version attributes

```xml
<!--

ASSEMBLY VERSIONING
-->
<PropertyGroup>
    <Version>0.0.0</Version>
    <VersionFileName>$(BaseIntermediateOutputPath)Version.cs</VersionFileName>
</PropertyGroup>
<Target Name="GenerateVersionFile" BeforeTargets="BeforeBuild">
    <WriteLinesToFile
        File="$(VersionFileName)"
        Overwrite="True"
        Lines="
            [assembly: System.Reflection.AssemblyVersion(&quot;$(Version)&quot;)]
            [assembly: System.Reflection.AssemblyFileVersion(&quot;$(Version)&quot;)]" />
    <ItemGroup>
        <Compile Include="$(VersionFileName)" />
    </ItemGroup>
</Target>
```

### 3. To run pass Version parameter
```console
msbuild /property:Version=9.9.9.9 .\MSBuildDemo.sln  
```

or

```console
dotnet build /property:Version=9.9.9.9 .\MSBuildDemo.sln  
```