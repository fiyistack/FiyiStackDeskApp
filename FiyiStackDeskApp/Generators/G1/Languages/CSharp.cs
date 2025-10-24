using Microsoft.Extensions.DependencyInjection;
using FiyiStackDeskApp.Generators.G1;

namespace FiyiStackDeskApp.Generators.G1.Languages
{
    public static class CSharp
    {
        public static string Start(G1ConfigurationComponent g1ConfigurationComponent, ServiceProvider serviceProvider)
        {
            try
            {
                string LogText = "";

                foreach (Areas.FiyiStackDeskApp.TableBack.Entities.Table Table in g1ConfigurationComponent.LstTableToGenerate)
                {
                    // Fix: Ensure the correct constructor is used with all required parameters  
                    g1ConfigurationComponent.G1FieldChainer = new G1FieldChainer(serviceProvider, Table, g1ConfigurationComponent.ChosenProject);

                    LogText += $"Trabajando con {Table.Name} {Environment.NewLine}";
                    string Content = "";

                    #region C# DTO
                    if (g1ConfigurationComponent.G1Configuration.WantDTO)
                    {
                        string DTOPath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\DTOs\\";
                        if (Directory.Exists(DTOPath))
                        {
                            LogText += $"Carpeta {DTOPath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {DTOPath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(DTOPath);
                        }

                        Content = Modules.CSharp.CSharp.DTO(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{DTOPath}paginated{Table.Name}DTO.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Entity
                    if (g1ConfigurationComponent.G1Configuration.WantEntity)
                    {
                        string EntityPath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\Entities\\";
                        if (Directory.Exists(EntityPath))
                        {
                            LogText += $"Carpeta {EntityPath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {EntityPath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(EntityPath);
                        }

                        Content = Modules.CSharp.CSharp.Entity(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{EntityPath}{Table.Name}.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Interface for repository
                    if (g1ConfigurationComponent.G1Configuration.WantInterfaces)
                    {
                        string InterfacePath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\Interfaces\\";
                        if (Directory.Exists(InterfacePath))
                        {
                            LogText += $"Carpeta {InterfacePath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {InterfacePath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(InterfacePath);
                        }

                        Content = Modules.CSharp.CSharp.InterfaceRepository(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{InterfacePath}I{Table.Name}Repository.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Interface for service
                    if (g1ConfigurationComponent.G1Configuration.WantInterfaces)
                    {
                        string InterfacePath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\Interfaces\\";
                        if (Directory.Exists(InterfacePath))
                        {
                            LogText += $"Carpeta {InterfacePath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {InterfacePath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(InterfacePath);
                        }

                        Content = Modules.CSharp.CSharp.InterfaceService(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{InterfacePath}I{Table.Name}Service.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Repository
                    if (g1ConfigurationComponent.G1Configuration.WantRepository)
                    {
                        string RepositoryPath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\Repositories\\";
                        if (Directory.Exists(RepositoryPath))
                        {
                            LogText += $"Carpeta {RepositoryPath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {RepositoryPath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(RepositoryPath);
                        }

                        Content = Modules.CSharp.CSharp.Repository(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{RepositoryPath}{Table.Name}Repository.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Service
                    if (g1ConfigurationComponent.G1Configuration.WantService)
                    {
                        string ServicePath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\Services\\";
                        if (Directory.Exists(ServicePath))
                        {
                            LogText += $"Carpeta {ServicePath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {ServicePath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(ServicePath);
                        }

                        Content = Modules.CSharp.CSharp.Service(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{ServicePath}{Table.Name}Service.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# EntityConfiguration
                    if (g1ConfigurationComponent.G1Configuration.WantEntityConfiguration)
                    {
                        string RepositoryPath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Areas\\{Table.Area}\\{Table.Name}Back\\EntitiesConfiguration\\";
                        if (Directory.Exists(RepositoryPath))
                        {
                            LogText += $"Carpeta {RepositoryPath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {RepositoryPath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(RepositoryPath);
                        }

                        Content = Modules.CSharp.CSharp.EntityConfiguration(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{RepositoryPath}{Table.Name}Configuration.cs",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Blazor Pages (Query)
                    if (g1ConfigurationComponent.G1Configuration.WantBlazorPages)
                    {
                        string BlazorPagePath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Components\\Pages\\{Table.Area}Pages\\{Table.Name}Pages\\";
                        if (Directory.Exists(BlazorPagePath))
                        {
                            LogText += $"Carpeta {BlazorPagePath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {BlazorPagePath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(BlazorPagePath);
                        }

                        Content = Modules.CSharp.CSharp.BlazorPageQuery(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{BlazorPagePath}{Table.Name}QueryPage.razor",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion

                    #region C# Blazor Pages (Non-Query)
                    if (g1ConfigurationComponent.G1Configuration.WantBlazorPages)
                    {
                        string BlazorPagePath = $"{g1ConfigurationComponent.ChosenProject.Path}\\Components\\Pages\\{Table.Area}Pages\\{Table.Name}Pages\\";
                        if (Directory.Exists(BlazorPagePath))
                        {
                            LogText += $"Carpeta {BlazorPagePath} existe {Environment.NewLine}";
                        }
                        else
                        {
                            LogText += $"Carpeta {BlazorPagePath} no existe. Creandola {Environment.NewLine}";
                            Directory.CreateDirectory(BlazorPagePath);
                        }

                        Content = Modules.CSharp.CSharp.BlazorPageNonQuery(g1ConfigurationComponent, Table);

                        SharedComponent.CreateFile(
                        $"{BlazorPagePath}{Table.Name}NonQueryPage.razor",
                        Content,
                        g1ConfigurationComponent.G1Configuration.DeleteFiles);
                    }
                    #endregion
                }
                return LogText;
            }
            catch (Exception ex) { throw ex; }
        }
    }
}
