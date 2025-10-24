namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string BlazorPageNonQuery(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"@page ""/CMS/{Table.Area}/{Table.Name}NonQueryPage/{{{Table.Name}Id:int}}""

@inherits {GeneratorConfigurationComponent.ChosenProject.Name}.Components.Base.CMSBase;

@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Repositories;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;

@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;
@inject IJSRuntime IJSRuntime;

<!--FOREIGN CALLS (TABLES)-->
{GeneratorConfigurationComponent.G1FieldChainer.Injections_BlazorNonQueryPage}

@if ({Table.Name}Id == 0)
{{
    <PageTitle>Agregar {Table.Name.ToLower()} - {Table.Area}</PageTitle>
}}
else
{{
    <PageTitle>Editar {Table.Name.ToLower()} - {Table.Area}</PageTitle>
}}

<{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._SideNavForDashboard lstFoldersAndPages=""lstFoldersAndPages""></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._SideNavForDashboard>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._NavBarForDashboard Pagina=""{Table.Name}""></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._NavBarForDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
             style=""background-image: url('assets/img/illustrations/Landscape2.jpg');"">
            <span class=""mask bg-gradient-primary opacity-6""></span>
        </div>
        <div class=""card card-body mx-3 mx-md-4 mt-n6"">
            <div class=""card-header mb-0 pb-0"">
                <h3 class=""mb-3"">
                    @if ({Table.Name}Id == 0)
                    {{
                        <span>Agregar {Table.Name.ToLower()}</span>
                    }}
                    else
                    {{
                        <span>Editar {Table.Name.ToLower()}</span>
                    }}
                </h3>
                <NavLink class=""btn btn-outline-dark"" href=""{Table.Area}/{Table.Name}Page"">
                    <span class=""fas fa-chevron-left""></span>
                    &nbsp;Volver
                </NavLink>
                <br />
                <div class=""alert alert-warning text-white font-weight-bold"" role=""alert"">
                    Los campos marcados con * son obligatorios
                </div>
                <hr />
            </div>
            <div class=""card-body px-0"">
                <form method=""post"" @onsubmit=""Submit""
                      @formname=""{Table.Name.ToLower()}-form"" class=""mb-4"">
                    <AntiforgeryToken />
                    {GeneratorConfigurationComponent.G1FieldChainer.PropertiesInHTML_BlazorNonQueryPage}
                    <hr />
                    @((MarkupString)Message)
                    <div class=""d-flex justify-content-between"">
                        <button id=""btn-submit"" type=""submit""
                                class=""btn btn-success"">
                            <i class=""fas fa-pen""></i>
                            @if ({Table.Name}Id == 0)
                            {{
                                <span>Agregar</span>
                            }}
                            else
                            {{
                                <span>Editar</span>
                            }}
                        </button>
                        <NavLink class=""btn btn-outline-dark mx-3"" href=""{Table.Area}/{Table.Name}Page"">
                            <span class=""fas fa-chevron-left""></span>
                            &nbsp;Volver
                        </NavLink>
                    </div>
                </form>
                
            </div>
        </div>
    </div>
    <!--Modals for FK-->
    {GeneratorConfigurationComponent.G1FieldChainer.ModalsInBlazorPageNonQuery}

    <!-- Initialization of tooltip -->
    <script>
        var tooltipTriggerList = [].slice.call(document.querySelectorAll('[data-bs-toggle-tooltip=""tooltip""]'))
        var tooltipList = tooltipTriggerList.map(function (tooltipTriggerEl) {{
            return new bootstrap.Tooltip(tooltipTriggerEl)
        }})
    </script>

    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FixedPluginForDashboard></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FixedPluginForDashboard>
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FooterForDashboard></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FooterForDashboard>
</div>

@code {{
    #region Properties
    public List<folderForCMSDTO> lstFoldersAndPages = [];

    [Parameter]
    public int {Table.Name}Id {{ get; set; }}

    public string Message {{ get; set; }} = """";

    [SupplyParameterFromForm]
    public {Table.Name} {Table.Name} {{ get; set; }} = new();

    public User User {{ get; set; }} = new();

    //Error messages for inputs
    {GeneratorConfigurationComponent.G1FieldChainer.ErrorMessage_InNonQueryBlazor}

    //Progress bars for uploaders
    {GeneratorConfigurationComponent.G1FieldChainer.ProgressBarForFile_BlazorNonQueryPage}
    
    //FOREIGN LISTS (TABLES)
    {GeneratorConfigurationComponent.G1FieldChainer.ForeignListsDeclaration_BlazorNonQueryPage}
    #endregion

    protected override void OnInitialized()
    {{
    }}

    protected override async Task OnAfterRenderAsync(bool firstRender)
    {{
        try
        {{
            if (firstRender)
            {{
                await base.SetStateContainerWithUserLoggedInUsingCookies();

                List<Menu> lstMenuWithPermission = rolemenuRepository
                                    .GetAllByRoleIdAndPathForPermission(base.StateContainer.User.RoleId, ""/{Table.Area}/{Table.Name}Page"");

                if (lstMenuWithPermission.Count == 0)
                {{
                    //Redirect to...
                    NavigationManager.NavigateTo(""403"");
                }}

                lstFoldersAndPages = rolemenuRepository
                                .GetAllPagesAndFoldersForCMSByRoleId(base.StateContainer.User.RoleId);

                User = base.StateContainer.User;

                //FOREIGN LISTS (TABLES)
                {GeneratorConfigurationComponent.G1FieldChainer.ForeignListsGet_BlazorNonQueryPage}

                if ({Table.Name}Id == 0)
                {{
                    //Create new {Table.Name}
                    {Table.Name} = new();
                }}
                else
                {{
                    //Edit {Table.Name}

                    {Table.Name} = {Table.Name.ToLower()}Repository
                                .GetOneBy{Table.Name}Id({Table.Name}Id);

                    {GeneratorConfigurationComponent.G1FieldChainer.EditPartFK_BlazorNonQueryPage}
                }}  

                await InvokeAsync(StateHasChanged);
            }}
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.show"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
    }}

    private async Task Submit()
    {{
        try
        {{
            if ({Table.Name}Id == 0)
            {{
                //Create new {Table.Name}
                {Table.Name}.Active = true;
                {Table.Name}.UserCreationId = User.UserId;
                {Table.Name}.UserLastModificationId = User.UserId;
                {Table.Name}.DateTimeCreation = DateTime.Now;
                {Table.Name}.DateTimeLastModification = DateTime.Now;

                if(Check("""") == null)
                {{
                    {Table.Name.ToLower()}Repository
                        .Add({Table.Name});

                    //Redirect to users page
                    NavigationManager.NavigateTo(""{Table.Area}/{Table.Name}Page"");
                }}


            }}
            else
            {{
                //Update data
                {Table.Name}.DateTimeLastModification = DateTime.Now;
                {Table.Name}.UserLastModificationId = User.UserId;

                if(Check("""") == null)
                {{
                    {Table.Name.ToLower()}Repository
                            .Update({Table.Name});

                    //Redirect to users page
                    NavigationManager.NavigateTo(""{Table.Area}/{Table.Name}Page"");
                }}
            }}
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.show"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page to show ScannedText
            await InvokeAsync(() => StateHasChanged()).ConfigureAwait(false);
        }}
    }}

    #region Uploaders
    {GeneratorConfigurationComponent.G1FieldChainer.UploadFileMethod_BlazorNonQueryPage}
    #endregion    

    #region SEARCHERS FOR FOREIGN TABLES
    {GeneratorConfigurationComponent.G1FieldChainer.Searchers_BlazorNonQueryPage}
    #endregion

    /// <summary>
    /// 
    /// </summary>
    /// <param name=""attributeToValid"">Debe estar encapsulado en []. Ejemplo: [Boolean]</param>
    /// <returns></returns>
    private ValidationResult Check(string attributeToValid)
    {{
        try
        {{
            List<ValidationResult> lstValidationResult = new List<ValidationResult>();
            ValidationContext ValidationContext = new ValidationContext({Table.Name});

            bool IsValid = Validator.TryValidateObject({Table.Name}, ValidationContext, lstValidationResult, true);

            ValidationResult ValidationResult = lstValidationResult
            .AsQueryable()
            .FirstOrDefault(x => x.ErrorMessage.StartsWith(attributeToValid));

            if (!IsValid)
            {{
                Message = $@""<div class=""""alert alert-danger text-white font-weight-bold"""" role=""""alert"""">
                                Para guardar correctamente debe completar los siguientes puntos: <br/> <ul>"";

                foreach (var validationResult in lstValidationResult)
                {{
                    validationResult.ErrorMessage = validationResult.ErrorMessage.Substring(validationResult.ErrorMessage.IndexOf(']') + 1);
                    Message += $@""<li>{{validationResult}}</li>"";
                }}

                Message = Message + ""</ul></div>"";
            }}
            else
            {{
                Message = $@""<div class=""""alert alert-successs text-white font-weight-bold"""" role=""""alert"""">
                                Todos los datos ingresados son correctos
                            </div>"";
            }}


            if (ValidationResult != null)
            {{
                ValidationResult.ErrorMessage = ValidationResult.ErrorMessage.Substring(ValidationResult.ErrorMessage.IndexOf(']') + 1);
            }}

            return ValidationResult;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            return null;
        }}
        finally
        {{

        }}
    }}

    #region Handlers
    {GeneratorConfigurationComponent.G1FieldChainer.Handlers_InNonQueryBlazor}
    #endregion
}}

";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
