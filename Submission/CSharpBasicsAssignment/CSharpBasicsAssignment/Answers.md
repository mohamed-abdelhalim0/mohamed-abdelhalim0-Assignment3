
## 1. .csproj contents

```xml
<Project Sdk="Microsoft.NET.Sdk">

  <PropertyGroup>
    <OutputType>Exe</OutputType>
    <TargetFramework>net10.0</TargetFramework>
    <ImplicitUsings>enable</ImplicitUsings>
    <Nullable>enable</Nullable>
  </PropertyGroup>

</Project>
```

The four properties mentioned in Part A are present:

- `OutputType`: present and set to `Exe`.
- `TargetFramework`: present and set to `net10.0`.
- `ImplicitUsings`: present and set to `enable`.
- `Nullable`: present and set to `enable`.

## 2. #region / #endregion

No, `#region` and `#endregion` do not change the compiled output.

They are used to organize and collapse sections of code in the editor, which can make large files easier to read.

## 3. /// XML documentation comments

I would use `///` XML documentation comments when I want to document a class, method, property, or other member.

They can be used by Visual Studio to show documentation and IntelliSense information.

## 4. Global variables in C#

C# does not have true global variables because it uses classes and scopes to organize data and control access to variables.

The closest equivalent is a `static` field inside a class, which can be accessed through the class.