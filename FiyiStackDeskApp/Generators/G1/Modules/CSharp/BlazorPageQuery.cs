namespace FiyiStackDeskApp.Generators.G1.Modules.CSharp
{
    public static partial class CSharp
    {
        public static string BlazorPageQuery(G1ConfigurationComponent GeneratorConfigurationComponent, Areas.FiyiStackDeskApp.TableBack.Entities.Table Table)
        {
            try
            {
                string Content =
                $@"@page ""/CMS/{Table.Area}/{Table.Name}QueryPage""

@inherits {GeneratorConfigurationComponent.ChosenProject.Name}.Components.Base.CMSBase;

@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Repositories;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Services;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.Entities;
@using {GeneratorConfigurationComponent.ChosenProject.Name}.Areas.{Table.Area}.{Table.Name}Back.DTOs;

@inject {Table.Name}Repository {Table.Name.ToLower()}Repository;
@inject {Table.Name}ExportationService {Table.Name.ToLower()}ExportationService;
@inject {Table.Name}ImportationService {Table.Name.ToLower()}ImportationService;
@inject IJSRuntime IJSRuntime;

<PageTitle>Buscar {Table.Name} - {Table.Area}</PageTitle>

<{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._SideNavForDashboard lstFoldersAndPagesForSideNavDTO=""lstFoldersAndPagesForSideNavDTO""></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._SideNavForDashboard>

<div class=""main-content position-relative max-height-vh-100 h-100"">
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._NavBarForDashboard Pagina=""{Table.Name}""></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._NavBarForDashboard>
    <div class=""container-fluid px-2 px-md-4"">
        <div class=""page-header min-height-300 border-radius-xl mt-4""
        style=""background-image: url('img/System/Landscape.jpg');"">
            <span class=""mask bg-gradient-dark opacity-6""></span>
        </div>
        <div class=""card mx-3 mx-md-4 mt-n6"">
            <!-- CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER -->
            <!-- CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER CARD HEADER -->
            <div class=""card-header mb-0 pb-0"">
                <div class=""d-flex flex-column flex-md-row justify-content-between align-items-start align-items-md-center"">
                    <h3 class=""mb-3 mb-md-0"">
                        Buscar {Table.Name.ToLower()}
                    </h3>
                    <div class=""d-flex gap-2"">
                        <NavLink class=""btn btn-outline-dark btn-sm text-nowrap"" 
                        href=""Dashboard"">
                            <span class=""fas fa-chevron-left"" aria-hidden=""true""></span>
                            &nbsp;Volver
                        </NavLink>
                        <NavLink class=""btn btn-success btn-sm text-white text-nowrap"" 
                        href=""/CMS/{Table.Area}/{Table.Name}NonQueryPage/0"">
                            <span class=""fas fa-plus"" aria-hidden=""true""></span>
                            &nbsp;Crear {Table.Name.ToLower()}
                        </NavLink>
                    </div>
                </div>
                <hr class=""mt-3"" />
            </div>
            <!-- CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY -->
            <!-- CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY CARD BODY -->
            <div class=""card-body px-3"">
                <!--Searchbox-->
                <div class=""input-group input-group-dynamic mb-3"">
                    <span class=""input-group-text"">
                        <i class=""fas fa-search"" aria-hidden=""true""></i>
                    </span>
                    <input class=""form-control"" 
                    @oninput=""SearchText""
                    placeholder=""Buscar {Table.Name.ToLower()} por {Table.Name}Id...""
                    type=""search"">
                </div>
                <div class=""row"">
                    <!-- FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS -->
                    <!-- FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS FUNCTIONS -->
                    <div class=""col-12"">
                        <div class=""accordion"" id=""accordionFaq"">
                            <div class=""accordion-item mb-3"">
                                <h6 class=""accordion-header"" id=""heading-functions"">
                                    <button class=""accordion-button border-bottom font-weight-bold text-start"" 
                                    type=""button"" 
                                    data-bs-toggle=""collapse"" 
                                    data-bs-target=""#collapse-functions"" 
                                    aria-expanded=""true"" 
                                    aria-controls=""collapse-functions"">
                                        FUNCIONES
                                        <i class=""collapse-close fa fa-plus text-xs pt-1 position-absolute end-0""></i>
                                        <i class=""collapse-open fa fa-minus text-xs pt-1 position-absolute end-0""></i>
                                    </button>
                                </h6>
                                <div id=""collapse-functions"" 
                                class=""accordion-collapse collapse show"" 
                                aria-labelledby=""heading-functions"">
                                    <div class=""accordion-body pb-0"">
                                        <div class=""row"">
                                            <!-- VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE -->
                                            <!-- VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE VIEW TYPE -->
                                            <div class=""col-12 col-lg-3"">
                                                <h6>
                                                    Tipo de vista
                                                </h6>
                                                <div class=""btn-group mb-3"" 
                                                role=""group"" 
                                                aria-label=""btngroup"">
                                                    <button type=""button""
                                                    class=""btn btn-dark""
                                                    onclick=@(() => ChangeView(""table""))>
                                                        <i class=""fas fa-table""></i>
                                                        Tabla
                                                    </button>
                                                    <button type=""button""
                                                    class=""btn btn-dark""
                                                    onclick=@(() => ChangeView(""list""))>
                                                        <i class=""fas fa-th-list""></i>
                                                        Lista
                                                    </button>
                                                </div>
                                            </div>
                                            <!-- REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE -->
                                            <!-- REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE REGISTERS PER PAGE -->
                                            <div class=""col-12 col-lg-3"">
                                                <h6>
                                                    Registros por página
                                                </h6>
                                                <div class=""dropdown"">
                                                    <button class=""btn btn-dark dropdown-toggle""
                                                    type=""button""
                                                    id=""dropdown-registers-per-page""
                                                    data-bs-toggle=""dropdown""
                                                    aria-expanded=""false"">
                                                        Ver @RegistersPerPage
                                                    </button>
                                                    <ul class=""dropdown-menu px-2 py-3"" 
                                                    aria-labelledby=""dropdown-registers-per-page"">
                                                        <li>
                                                            <a class=""dropdown-item border-radius-md""
                                                            href=""javascript:;""
                                                            @onclick=""(() => ChangeRegistersPerPage(50))"">
                                                                50
                                                            </a>
                                                        </li>
                                                        <li>
                                                            <button class=""dropdown-item border-radius-md""
                                                            @onclick=""(() => ChangeRegistersPerPage(500))"">
                                                                500
                                                            </button>
                                                        </li>
                                                        <li>
                                                            <a class=""dropdown-item border-radius-md""
                                                               href=""javascript:;""
                                                               @onclick=""(() => ChangeRegistersPerPage(5000))"">
                                                                5.000
                                                            </a>
                                                        </li>
                                                    </ul>
                                                </div>
                                            </div>
                                            <!-- EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS -->
                                            <!-- EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS EXTRA FUNCTIONS -->
                                            <div class=""col-12 col-lg-3"">
                                                <h6>
                                                    Funciones extras
                                                </h6>
                                                <div class=""row"">
                                                    <div class=""d-flex justify-content-start"">
                                                        <!--Import function-->
                                                        <button type=""button""
                                                        class=""btn btn-dark mx-2""
                                                        data-bs-toggle=""modal""
                                                        data-bs-target=""#modal-import""
                                                        data-bs-placement=""bottom""
                                                        data-bs-toggle-tooltip=""tooltip""
                                                        title=""Importar"">
                                                            <i class=""fas fa-file-import fa-xl""></i>
                                                        </button>
                                                        <!--Export function-->
                                                        <button type=""button""
                                                        class=""btn btn-dark mx-2""
                                                        data-bs-toggle=""modal""
                                                        data-bs-target=""#modal-export""
                                                        data-bs-placement=""bottom""
                                                        data-bs-toggle-tooltip=""tooltip""
                                                        title=""Exportar"">
                                                            <i class=""fas fa-file-export fa-xl""></i>
                                                        </button>
                                                        <!--Massive actions-->
                                                        <button type=""button""
                                                        class=""btn btn-dark mx-2""
                                                        data-bs-toggle=""modal""
                                                        data-bs-target=""#modal-massive-actions""
                                                        data-bs-placement=""bottom""
                                                        data-bs-toggle-tooltip=""tooltip""
                                                        title=""Acciones masivas"">
                                                            <i class=""fas fa-rocket fa-xl""></i>
                                                        </button>
                                                    </div>
                                                </div>
                                            </div>
                                            <!-- STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH -->
                                            <!-- STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH STRICT OR LAX SEARCH -->
                                            <div class=""col-12 col-lg-3"">
                                                <div>
                                                    <h6>
                                                        Búsqueda estricta o laxa
                                                        <i class=""fas fa-circle-info""
                                                        data-bs-toggle-tooltip=""tooltip""
                                                        data-bs-placement=""right""
                                                        title=""Una búsqueda laxa es más flexible, permite errores y devuelve resultados más amplios, algo que una búsqueda estricta no permite"">
                                                        </i>
                                                    </h6>

                                                    <div class=""form-check form-switch"">
                                                        <input class=""form-check-input""
                                                        type=""checkbox""
                                                        name=""strict-search""
                                                        @bind=""CheckStrict""
                                                        id=""strict-search"" />
                                                        <label class=""form-check-label""
                                                               for=""strict-search"">
                                                            Búsqueda estricta
                                                        </label>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            </div>
                        </div>
                    </div>
                </div>
                <!--Number of registers-->
                <h6 class=""mt-3"">
                    Nº de registros: @TotalRegisters
                </h6>
                @if (ChosenView == ""table"")
                {{
                    <!-- TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE -->
                    <!-- TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE TABLE -->
                    <div class=""table-responsive"">
                        <table class=""table table-striped table-hover table-bordered mt-4"">
                            <thead>
                                <tr>
                                    <th></th>
                                    {GeneratorConfigurationComponent.G1FieldChainer.PropertiesInHTML_TH_ForBlazorPageQuery}
                                    <th>Acciones</th>
                                </tr>
                            </thead>
                            <tbody>
                                @if (paginated{Table.Name}DTO != null)
                                {{
                                    @for (int i = 0; i < paginated{Table.Name}DTO.lst{Table.Name}.Count(); i++)
                                    {{
                                        int {Table.Name.ToLower()}Id = @paginated{Table.Name}DTO.lst{Table.Name}[i]!.{Table.Name}Id;
                                        string href = $@""CMS/{Table.Area}/{Table.Name}NonQueryPage/{{{Table.Name.ToLower()}Id}}"";
                                        <tr>
                                            <td>
                                                <input type=""checkbox""
                                                @onchange=""(() => CheckList({Table.Name.ToLower()}Id))"" />
                                            </td>
                                            {GeneratorConfigurationComponent.G1FieldChainer.PropertiesInHTML_TD_ForBlazorPageQuery}
                                            <td>
                                                <div class=""d-flex justify-content-start"">
                                                    <NavLink class=""btn btn-sm btn-outline-info mx-2""
                                                    href=""@href"">
                                                        <span class=""fas fa-pen"" aria-hidden=""true""></span>
                                                    </NavLink>
                                                    <button class=""btn btn-outline-danger btn-sm""
                                                    @onclick=""(() => ShowDeleteNotification({Table.Name.ToLower()}Id))"">
                                                        <span class=""fas fa-trash"" aria-hidden=""true""></span>
                                                    </button>
                                                </div>
                                            </td>
                                        </tr>
                                    }}
                                }}
                            </tbody>
                        </table>
                    </div>
                }}
                else
                {{
                    <!--LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST -->
                    <!--LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST LIST -->
                    @if (paginated{Table.Name}DTO != null && paginated{Table.Name}DTO.lst{Table.Name} != null)      
                    {{
                        <div class=""row"">
                            @for (int i = 0; i < paginated{Table.Name}DTO.lst{Table.Name}.Count(); i++)
                            {{
                                int {Table.Name.ToLower()}Id = @paginated{Table.Name}DTO.lst{Table.Name}[i]!.{Table.Name}Id;
                                string href = $@""CMS/{Table.Area}/{Table.Name}NonQueryPage/{{{Table.Name.ToLower()}Id}}"";
                                <div class=""col-12 col-md-4 mb-4"">
                                    <div class=""card shadow-lg mt-2"">
                                        <div class=""card-body"">
                                            {GeneratorConfigurationComponent.G1FieldChainer.PropertiesInHTML_Card_ForBlazorPageQuery}
                                        </div>
                                        <div class=""card-footer text-body-secondary"">
                                            <div class=""d-flex justify-content-end"">
                                                <div class=""checkbox-container d-flex align-items-center justify-content-center"">
                                                    <input class=""larger-checkbox""
                                                    type=""checkbox""
                                                    checked=""@lstINT{Table.Name}Checked.Contains({Table.Name.ToLower()}Id)""
                                                    @onchange=""(() => CheckList({Table.Name.ToLower()}Id))"" />
                                                </div>
                                                <NavLink class=""btn btn-outline-info mx-3 btn-sm""
                                                href=""@href"">
                                                    <span class=""fas fa-pen"" aria-hidden=""true""></span>
                                                </NavLink>
                                                <button class=""btn btn-outline-danger btn-sm""
                                                @onclick=""(() => ShowDeleteNotification({Table.Name.ToLower()}Id))"">
                                                    <span class=""fas fa-trash"" aria-hidden=""true""></span>
                                                </button>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            }}
                        </div>
                    }}
                    else
                    {{
                        <!--SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON -->
                        <!--SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON SKELETON -->
                        <div class=""row"">
                            @for (int i = 0; i < 3; i++)
                            {{
                                <div class=""col-12 col-md-4 mb-4"">
                                    <div class=""card shadow-lg mt-2"">
                                        <div class=""card-body placeholder-glow"">
                                            <p><span class=""placeholder col-4""></span></p>
                                            <p><span class=""placeholder col-8""></span></p>
                                            <p><span class=""placeholder col-10""></span></p>
                                            <p><span class=""placeholder col-6""></span></p>
                                            <p><span class=""placeholder col-7""></span></p>
                                            <p><span class=""placeholder col-9""></span></p>
                                            <p><span class=""placeholder col-5""></span></p>
                                            <div class=""d-flex justify-content-start mt-3"">
                                                <span class=""placeholder rounded-circle me-2"" style=""width:30px; height:30px;""></span>
                                                <span class=""placeholder rounded-pill col-6""></span>
                                            </div>
                                        </div>
                                        <div class=""card-footer text-body-secondary placeholder-wave"">
                                            <div class=""d-flex justify-content-end"">
                                                <span class=""placeholder rounded col-2 me-2"" style=""height:30px;""></span>
                                                <span class=""placeholder rounded col-2 me-2"" style=""height:30px;""></span>
                                                <span class=""placeholder rounded col-2"" style=""height:30px;""></span>
                                            </div>
                                        </div>
                                    </div>
                                </div>
                            }}
                        </div>
                    }}
                }}
                <!-- PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION -->
                <!-- PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION -->
                <nav aria-label=""Page navigation example"">
                    <ul class=""pagination justify-content-center mt-3"">
                        <li class=""page-item
                        @(paginated{Table.Name}DTO!.HasPreviousPage ? """" : ""disabled"")"">
                            <button class=""page-link""
                                    disabled=""@(!paginated{Table.Name}DTO.HasPreviousPage)""
                                    @onclick=""() => OnPreviousPage()"">
                                <i class=""fas fa-chevron-left""></i>
                            </button>
                        </li>
                        @foreach (int Page in GetVisiblePages())
                        {{
                            if (Page == -1 || Page == -2)
                            {{
                                <li class=""page-item disabled"">
                                    <span class=""page-link"">...</span>
                                </li>
                            }}
                            else
                            {{
                                <li class=""page-item @(Page == paginated{Table.Name}DTO.PageIndex ? ""active"" : """")"">
                                    <button class=""page-link""
                                    @onclick=""@(() => OnPageSelected(Page))"">
                                        @Page
                                    </button>
                                </li>
                            }}
                        }}
                        <li class=""page-item
                        @(paginated{Table.Name}DTO.HasNextPage ? """" : ""disabled"")"">
                            <button class=""page-link""
                                    disabled=""@(!paginated{Table.Name}DTO.HasNextPage)""
                                    @onclick=""() => OnNextPage()"">
                                <i class=""fas fa-chevron-right""></i>
                            </button>
                        </li>
                    </ul>
                </nav>
            </div>
        </div>
    </div>

    <!-- MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS -->
    <!-- MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS MODALS FOR FUNCTIONS -->

    <!-- MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT -->
    <!-- MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT MODAL FOR IMPORT -->
    <div class=""modal fade""
    id=""modal-import""
    tabindex=""-1""
    aria-labelledby=""modal-import-title""
    aria-hidden=""true"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-dark"">
                    <h5 class=""modal-title text-white"" 
                    id=""modal-import-title"">
                        Importar
                    </h5>
                </div>
                <div class=""modal-body bg-dark"">
                    <form role=""form"">
                        <div class=""input-group input-group-static mb-3"">
                            <label for=""importingfile"">
                                Archivo a importar
                            </label>
                            <InputFile type=""file""
                            id=""importingfile""
                            class=""form-control""
                            OnChange=""@UploadImportingExcelFile"" />
                        </div>
                    </form>
                </div>
                <div class=""modal-footer justify-content-between align-items-center bg-dark"">
                    <div class=""d-flex align-items-center"">
                        @if (ShowLoaderInImportationModal)
                        {{
                            <span class=""loader me-2""></span>
                            <span class=""text-info"">Procesando...</span>
                        }}
                        else
                        {{
                            <span>&nbsp;</span>
                        }}
                    </div>
                    <button type=""button""
                            class=""btn btn-white mb-0""
                            data-bs-dismiss=""modal"">
                        Cerrar
                    </button>
                </div>
            </div>
        </div>
    </div>
    <!-- MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT -->
    <!-- MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT MODAL FOR EXPORT -->
    <div class=""modal fade""
    id=""modal-export""
    tabindex=""-1"" 
    aria-labelledby=""modal-export-title"" 
    aria-hidden=""true"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-dark"">
                    <h5 class=""modal-title text-white"" 
                    id=""modal-export-title"">
                        Exportar
                    </h5>
                </div>
                <div class=""modal-body bg-dark"">
                    <form role=""form"">
                        <h6 class=""text-white"">
                            Registros a exportar
                        </h6>
                        <div class=""form-group mb-3"">
                            <div class=""custom-control custom-radio"">
                                <input name=""export"" 
                                type=""radio"" 
                                class=""custom-control-input"" 
                                checked
                                id=""export-only-chosen""
                                value=""only-chosen""
                                @onchange=""@(() => ExportationType = ""only-chosen"")"">
                                <label class=""custom-control-label text-white"" 
                                for=""export-only-chosen"">
                                    Sólo los registros seleccionados
                                </label>
                            </div>
                            <div class=""custom-control custom-radio"">
                                <input name=""export""
                                type=""radio"" 
                                class=""custom-control-input""
                                id=""export-all""
                                value=""all""
                                @onchange=""@(() => ExportationType = ""all"")"">
                                <label class=""custom-control-label text-white"" 
                                for=""export-all"">
                                    Todo
                                </label>
                            </div>
                        </div>
                        <h6>
                            Formatos
                        </h6>
                        <!-- Export as PDF file button -->
                        <div class=""d-flex justify-content-start"">
                            <button class=""btn btn-icon btn-white""
                            type=""button""
                            @onclick=""ExportToPDF"">
                                <span class=""btn-inner--icon"">
                                    <i class=""fas fa-file-pdf""></i>
                                </span>
                                <span class=""btn-inner--text"">
                                    Exportar como PDF
                                </span>
                            </button>
                            @if (DownloadPathForPDF != """")
                            {{
                                <a class=""btn btn-icon btn-success mx-3""
                                download
                                href=""@DownloadPathForPDF"">
                                    Descargar
                                </a>
                            }}
                        </div>
                        <!-- Export as Excel file button -->
                        <div class=""d-flex justify-content-start"">
                            <button class=""btn btn-icon btn-white""
                            type=""button""
                            @onclick=""ExportToExcel"">
                                <span class=""btn-inner--icon"">
                                    <i class=""fas fa-file-excel""></i>
                                </span>
                                <span class=""btn-inner--text"">
                                    Exportar como Excel
                                </span>
                            </button>
                            @if (DownloadPathForExcel != """")
                            {{
                                <a class=""btn btn-icon btn-success mx-3""
                                download
                                href=""@DownloadPathForExcel"">
                                    Descargar
                                </a>
                            }}
                        </div>
                        <!-- Export as CSV file button -->
                        <div class=""d-flex justify-content-start"">
                            <button class=""btn btn-icon btn-white""
                            type=""button""
                            @onclick=""ExportToCSV"">
                                <span class=""btn-inner--icon"">
                                    <i class=""fas fa-file-csv""></i>
                                </span>
                                <span class=""btn-inner--text"">
                                    Exportar como CSV
                                </span>
                            </button>
                            @if (DownloadPathForCSV != """")
                            {{
                                <a class=""btn btn-icon btn-success mx-3""
                                download
                                href=""@DownloadPathForCSV"">
                                    Descargar
                                </a>
                            }}
                        </div>
                    </form>
                </div>
                <div class=""modal-footer justify-content-between align-items-center bg-dark"">
                    <div class=""d-flex align-items-center"">
                        @if (ShowLoaderInExportationModal)
                        {{
                            <span class=""loader me-2""></span>
                            <span class=""text-info"">Procesando...</span>
                        }}
                        else
                        {{
                            <span>&nbsp;</span>
                        }}
                    </div>
                    <button type=""button""
                            class=""btn btn-white mb-0""
                            data-bs-dismiss=""modal"">
                        Cerrar
                    </button>
                </div>
            </div>
        </div>
    </div>
    <!-- MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS -->
    <!-- MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS MODAL FOR MASSIVE ACTIONS -->
    <div class=""modal fade""
    id=""modal-massive-actions""
    tabindex=""-1""
    aria-labelledby=""modal-massive-actions-title""
    aria-hidden=""true"">
        <div class=""modal-dialog"">
            <div class=""modal-content"">
                <div class=""modal-header bg-dark"">
                    <h5 class=""modal-title text-white""
                    id=""modal-massive-actions-title"">
                        Acciones masivas
                    </h5>
                </div>
                <div class=""modal-body bg-dark"">
                    <form role=""form"">
                        <h6 class=""text-white"">
                            Registros a seleccionar
                        </h6>
                        <div class=""form-group mb-3"">
                            <div class=""custom-control custom-radio"">
                                <input name=""massiveactions""
                                type=""radio""
                                class=""custom-control-input""
                                checked
                                id=""massiveactions-only-chosen""
                                @onchange=""@(() => MassiveActionType = ""only-chosen"")"">
                                <label class=""custom-control-label text-white""
                                for=""massiveactions-only-chosen"">
                                    Sólo los registros seleccionados
                                </label>
                            </div>
                            <div class=""custom-control custom-radio"">
                                <input name=""massiveactions""
                                type=""radio""
                                class=""custom-control-input""
                                id=""massiveactions-all""
                                @onchange=""@(() => MassiveActionType = ""all"")"">
                                <label class=""custom-control-label text-white""
                                for=""massiveactions-all"">
                                    Todo
                                </label>
                            </div>
                        </div>
                        <h6>
                            Acciones
                        </h6>
                        <div class=""form-group"">
                            <!-- Copy button -->
                            <button class=""btn btn-icon btn-white""
                            id=""copy-button-for-massive-actions""
                            type=""button""
                            @onclick=""MassiveActionCopy"">
                                <span class=""btn-inner--icon"">
                                    <i class=""fas fa-copy""></i>
                                </span>
                                <span class=""btn-inner--text"">
                                    Copiar
                                </span>
                            </button>
                        </div>
                        <div class=""form-group"">
                            <!-- Delete button -->
                            <button class=""btn btn-icon btn-white""
                            type=""button""
                            @onclick=""MassiveActionDelete"">
                                <span class=""btn-inner--icon"">
                                    <i class=""fas fa-trash""></i>
                                </span>
                                <span class=""btn-inner--text"">
                                    Eliminar
                                </span>
                            </button>
                        </div>
                    </form>
                </div>
                <div class=""modal-footer justify-content-between align-items-center bg-dark"">
                    <div class=""d-flex align-items-center"">
                        @if(ShowLoaderInMassiveActionModal)
                        {{
                            <span class=""loader me-2""></span>
                            <span class=""text-info"">Procesando...</span>
                        }}
                        else
                        {{
                            <span>&nbsp;</span>
                        }}
                    </div>
                    <button type=""button""
                            class=""btn btn-white mb-0""
                            data-bs-dismiss=""modal"">
                        Cerrar
                    </button>
                </div>
            </div>
        </div>
    </div>
    <!-- NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS -->
    <!-- NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS NOTIFICATIONS -->
    <div id=""delete-notification""
         class=""toast bg-dark fade p-3 position-fixed top-50 start-50 translate-middle""
         style=""z-index: 2000; min-width: 350px;""
         role=""alert"" aria-live=""assertive"" aria-atomic=""true"">
        <div class=""toast-header border-0 bg-transparent"">
            <p class=""text-white mb-0"">
                <i class=""fas fa-trash fa-xl""></i>&nbsp;
                Confirmar eliminación
            </p>
            <i class=""fas fa-times text-md ms-3 cursor-pointer text-white"" data-bs-dismiss=""toast""></i>
        </div>
        <hr class=""horizontal light m-0"">
        <div class=""toast-body text-white text-center"">
            ¿Seguro que deseas eliminar el registro con ID <b>@Selected{Table.Name}IdToDelete</b>?
            <br />
            <button class=""btn btn-outline-danger btn-sm mt-3 close-notification""
                    @onclick=""ConfirmDeletion"">
                Sí, eliminar
            </button>
        </div>
    </div>
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FixedPluginForDashboard></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FixedPluginForDashboard>
    <{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FooterForDashboard></{GeneratorConfigurationComponent.ChosenProject.Name}.Components.Shared.ComponentsForDashboard._FooterForDashboard>
</div>

@code {{

    //PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIESPROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES 
    //PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIESPROPERTIES PROPERTIES PROPERTIES PROPERTIES PROPERTIES 

    #region Properties
    private List<folderAndPagesForCMSDTO> lstFoldersAndPagesForSideNavDTO {{ get; set; }} = [];

    private int TotalRegisters {{ get; set; }} = 0;

    private string? ChosenView {{ get; set; }}

    private bool CheckStrict {{ get; set; }}

    private string? TextToSearch {{ get; set; }} = """";

    private string? ExportationType {{ get; set; }} = ""only-chosen"";
    private string? MassiveActionType {{ get; set; }} = ""only-chosen"";

    private string? DownloadPathForExcel {{ get; set; }} = """";
    private string? DownloadPathForPDF {{ get; set; }} = """";
    private string? DownloadPathForCSV {{ get; set; }} = """";

    private {Table.Name} {Table.Name} = new();

    paginated{Table.Name}DTO paginated{Table.Name}DTO = new();

    private List<int> lstINT{Table.Name}Checked = [];

    private int RegistersPerPage {{ get; set; }} = 50;

    private int? Selected{Table.Name}IdToDelete;

    private bool ShowLoaderInMassiveActionModal {{ get; set; }} = false;
    private bool ShowLoaderInExportationModal {{ get; set; }} = false;
    private bool ShowLoaderInImportationModal {{ get; set; }} = false;
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
                await base.GetUserIdFromCookies();

                await base.IsUserAvailableToUseThisPage(""/CMS/FiyiStackWeb/{Table.Name}QueryPage"");

                lstFoldersAndPagesForSideNavDTO = rolemenuRepository
                                .GetAllPagesAndFoldersForCMSByRoleId(base.User.RoleId);

                paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginatedAsync(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

                TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;

                ChosenView = ""list"";

                await InvokeAsync(StateHasChanged);
            }}
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
    }}

    //EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTSEVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTSEVENTS EVENTS EVENTS EVENTS EVENTS EVENTS
    //EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTSEVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTS EVENTSEVENTS EVENTS EVENTS EVENTS EVENTS EVENTS

    #region Events
    private async Task ChangeRegistersPerPage(int registersPerPage)
    {{
        try
        {{
            RegistersPerPage = registersPerPage;

            paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                .GetAllBy{Table.Name}IdPaginatedAsync(
                TextToSearch,
                CheckStrict,
                1,
                RegistersPerPage);

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task SearchText(ChangeEventArgs args)
    {{
        try
        {{
            TextToSearch = args.Value.ToString();

            paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                .GetAllBy{Table.Name}IdPaginatedAsync(
                TextToSearch,
                CheckStrict,
                1,
                RegistersPerPage);

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task ChangeView(string chosenView)
    {{
        ChosenView = chosenView;

        //Re-render the page
        await InvokeAsync(StateHasChanged);
    }}

    private async Task ShowDeleteNotification(int {Table.Name.ToLower()}Id)
    {{
        Selected{Table.Name}IdToDelete = {Table.Name.ToLower()}Id;
        await IJSRuntime.InvokeVoidAsync(""notificationHelper.showDeletionNotification"");
    }}

    private async Task ConfirmDeletion()
    {{
        try
        {{
            if (Selected{Table.Name}IdToDelete.HasValue)
            {{
                await {Table.Name.ToLower()}Repository.DeleteOneBy{Table.Name}IdAsync(Selected{Table.Name}IdToDelete.Value);

                paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                    .GetAllBy{Table.Name}IdPaginatedAsync(
                    TextToSearch,
                    CheckStrict,
                    1,
                    RegistersPerPage);

                TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;

                await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Éxito"", ""Registro borrado correctamente."", ""success"");
            }}
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task CheckList(int {Table.Name.ToLower()}Id)
    {{
        try
        {{
            int[] lst{Table.Name}Id = {{ {Table.Name.ToLower()}Id }};

            foreach (int {Table.Name}Id in lst{Table.Name}Id)
            {{
                if (lstINT{Table.Name}Checked.Contains({Table.Name}Id))
                {{
                    lstINT{Table.Name}Checked.Remove({Table.Name}Id);
                }}
                else
                {{
                    lstINT{Table.Name}Checked.Add({Table.Name}Id);
                }}
            }}
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}
    #endregion

    //PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATIONPAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION
    //PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATIONPAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION PAGINATION
    #region Pagination
    private List<int> GetVisiblePages()
    {{
        int MaxVisiblePages = 5;
        List<int> lstINTPages = new List<int>();

        if (paginated{Table.Name}DTO.TotalPages <= MaxVisiblePages + 2)
        {{
            //Show all pages if there are few
            for (int i = 1; i <= paginated{Table.Name}DTO.TotalPages; i++)
                lstINTPages.Add(i);
        }}
        else
        {{
            int Current = paginated{Table.Name}DTO.PageIndex;
            int Start = Math.Max(2, Current - 1);
            int End = Math.Min(paginated{Table.Name}DTO.TotalPages - 1, Current + 1);

            lstINTPages.Add(1); //Always show the first one

            if (Start > 2)
                lstINTPages.Add(-1); // -1 will be ""...""

            for (int i = Start; i <= End; i++)
                lstINTPages.Add(i);

            if (End < paginated{Table.Name}DTO.TotalPages - 1)
                lstINTPages.Add(-2); // -2 will be ""...""

            lstINTPages.Add(paginated{Table.Name}DTO.TotalPages); //Always show the latest
        }}

        return lstINTPages;
    }}

    private async Task OnPreviousPage()
    {{
        try
        {{
            if (paginated{Table.Name}DTO.HasPreviousPage)
            {{
                paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                    .GetAllBy{Table.Name}IdPaginatedAsync(
                    TextToSearch,
                    CheckStrict,
                    (paginated{Table.Name}DTO.PageIndex - 1),
                    paginated{Table.Name}DTO.PageSize);
            }}

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task OnPageSelected(int pageIndex)
    {{
        try
        {{
            paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                .GetAllBy{Table.Name}IdPaginatedAsync(
                TextToSearch,
                CheckStrict,
                pageIndex,
                paginated{Table.Name}DTO.PageSize);

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task OnNextPage()
    {{
        try
        {{
            if (paginated{Table.Name}DTO.HasNextPage)
            {{
                paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                    .GetAllBy{Table.Name}IdPaginatedAsync(
                    TextToSearch,
                    CheckStrict,
                    (paginated{Table.Name}DTO.PageIndex + 1),
                    paginated{Table.Name}DTO.PageSize);
            }}

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await InvokeAsync(StateHasChanged);
        }}
    }}
    #endregion

    //IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONSIMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONSIMPORTATIONS
    //IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONSIMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONS IMPORTATIONSIMPORTATIONS

    #region Importations
    private async Task UploadImportingExcelFile(InputFileChangeEventArgs e)
    {{

        try
        {{
            ShowLoaderInImportationModal = true;
            await InvokeAsync(StateHasChanged);

            //Neccesary data
            IBrowserFile File = e.File;

            long MaxFileSize = 1024L * 1024L * 3; //3MB max.

            string Extension = Path.GetExtension(File.Name)?.ToLowerInvariant();

            //Validation
            if (Extension != "".xlsx"")
            {{
                await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""Archivo inválido. Solo se permiten archivos Excel (.xlsx)."", ""warning"");
                return;
            }}

            //Prepare path to save
            string PathOnly = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Uploads"",
                ""{Table.Name}"");

            //Create folder if not exist
            if (!Directory.Exists(PathOnly))
            {{
                System.IO.Directory.CreateDirectory(PathOnly);
            }}

            //Prepare path to save with included file
            string PathWithFile = Path.Combine(PathOnly,
                File.Name);

            //Save file
            await using FileStream FileStream = new(PathWithFile, FileMode.Create);

            await File.OpenReadStream(MaxFileSize).CopyToAsync(FileStream);

            FileStream.Close();

            //Remove all content from the path up to wwwroot
            string Limitator = ""\\wwwroot"";
            int StartIndex = PathWithFile.IndexOf(Limitator);

            if (StartIndex != -1)
            {{
                PathWithFile = PathWithFile.Substring(StartIndex + Limitator.Length);
            }}

            //Replace \\ for /
            PathWithFile = $@""wwwroot/{{PathWithFile.Replace(""\\"", ""/"")}}"";

            //Import Excel file
            List<{Table.Name}> lst{Table.Name} = {Table.Name.ToLower()}ImportationService.ImportExcel(PathWithFile, User.UserId);

            //Save in DB
            await {Table.Name.ToLower()}Repository.AddRangeAsync(lst{Table.Name});

            //Update page with new records
            paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginatedAsync(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Éxito"", ""Importación finalizada correctamente."", ""success"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Error"", ""Hubo un error. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            await Task.Delay(1500);
            ShowLoaderInImportationModal = false;
            await InvokeAsync(StateHasChanged);
        }}
    }}
    #endregion

    //EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORT
    //EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORTATIONS EXPORT

    #region Exportations
    private async Task ExportToExcel()
    {{
        try
        {{
            ShowLoaderInExportationModal = true;
            await InvokeAsync(StateHasChanged);

            DataTable dt{Table.Name} = new();

            if (ExportationType == ""only-chosen"")
            {{
                //Validation
                if (lstINT{Table.Name}Checked.Count == 0)
                {{
                    await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""No hay registros para exportar. Proceso cancelado"", ""warning"");
                    return;
                }}

                dt{Table.Name} = {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdInDataTable(lstINT{Table.Name}Checked);
            }}
            else
            {{
                dt{Table.Name} = {Table.Name.ToLower()}Repository.GetAllInDataTable();
            }}

            //Prepare path to download
            string PathOnly = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Downloads"",
                ""ExcelFiles"",
                ""{Table.Name}"");

            //Create folder if not exist
            if (!Directory.Exists(PathOnly))
            {{
                System.IO.Directory.CreateDirectory(PathOnly);
            }}

            DownloadPathForExcel = $@""wwwroot/Downloads/ExcelFiles/{Table.Name}/{{base.User.UserId}}_{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.xlsx"";

            {Table.Name.ToLower()}ExportationService.ExportToExcel(DownloadPathForExcel,
            dt{Table.Name});

            //Delete wwwroot from path to download correctly
            DownloadPathForExcel = DownloadPathForExcel.Replace(""wwwroot"", """");

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Éxito"", ""Exportación a Excel finalizada correctamente."", ""success"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Error"", ""Hubo un error al exportar a Excel. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await Task.Delay(1500);
            ShowLoaderInExportationModal = false;
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task ExportToCSV()
    {{
        try
        {{
            ShowLoaderInExportationModal = true;
            await InvokeAsync(StateHasChanged);

            

            List<{Table.Name}?> lst{Table.Name} = [];

            if (ExportationType == ""only-chosen"")
            {{
                //Validation
                if (lstINT{Table.Name}Checked.Count == 0)
                {{
                    await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""No hay registros para exportar. Proceso cancelado"", ""warning"");
                    return;
                }}

                lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdCheckedAsync(lstINT{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllAsync();
            }}

            //Prepare path to download
            string PathOnly = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Downloads"",
                ""CSVFiles"",
                ""{Table.Name}"");

            //Create folder if not exist
            if (!Directory.Exists(PathOnly))
            {{
                System.IO.Directory.CreateDirectory(PathOnly);
            }}

            DownloadPathForCSV = $@""wwwroot/Downloads/CSVFiles/{Table.Name}/{{base.User.UserId}}_{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.csv"";

            {Table.Name.ToLower()}ExportationService.ExportToCSV(DownloadPathForCSV, lst{Table.Name});

            //Delete wwwroot from path to download correctly
            DownloadPathForCSV = DownloadPathForCSV.Replace(""wwwroot"", """");            

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Éxito"", ""Exportación a CSV finalizada correctamente."", ""success"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Error"", ""Hubo un error al exportar a CSV. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await Task.Delay(1500);
            ShowLoaderInExportationModal = false;
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task ExportToPDF()
    {{
        try
        {{
            ShowLoaderInExportationModal = true;
            await InvokeAsync(StateHasChanged);

            List<{Table.Name}?> lst{Table.Name} = [];

            if (ExportationType == ""only-chosen"")
            {{
                //Validation
                if (lstINT{Table.Name}Checked.Count == 0)
                {{
                    await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""No hay registros para exportar. Proceso cancelado"", ""warning"");
                    return;
                }}

                lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdCheckedAsync(lstINT{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllAsync();
            }}

            //Prepare path to download
            string PathOnly = Path.Combine(
                Environment.CurrentDirectory,
                ""wwwroot"",
                ""Downloads"",
                ""PDFFiles"",
                ""{Table.Name}"");

            //Create folder if not exist
            if (!Directory.Exists(PathOnly))
            {{
                System.IO.Directory.CreateDirectory(PathOnly);
            }}

            DownloadPathForPDF = $@""wwwroot/Downloads/PDFFiles/{Table.Name}/{{base.User.UserId}}_{{DateTime.Now.ToString(""yyyy_MM_dd_HH_mm_ss_fff"")}}.pdf"";

            {Table.Name.ToLower()}ExportationService.ExportToPDF(DownloadPathForPDF, lst{Table.Name});

            //Delete wwwroot from path to download correctly
            DownloadPathForPDF = DownloadPathForPDF.Replace(""wwwroot"", """");

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Éxito"", ""Exportación a PDF finalizada correctamente."", ""success"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Error"", ""Hubo un error al exportar a PDF. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await Task.Delay(1500);
            ShowLoaderInExportationModal = false;
            await InvokeAsync(StateHasChanged);
        }}
    }}
    #endregion

    //MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIV
    //MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIVE ACTIONS MASSIV

    #region Massive actions
    private async Task MassiveActionCopy()
    {{
        try
        {{
            ShowLoaderInMassiveActionModal = true;
            await InvokeAsync(StateHasChanged);

            List<{Table.Name}?> lst{Table.Name} = [];

            if (MassiveActionType == ""only-chosen"")
            {{
                //Validation
                if (lstINT{Table.Name}Checked.Count == 0)
                {{
                    await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""No hay registros para copiar. Proceso cancelado"", ""warning"");
                    return;
                }}

                lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdCheckedAsync(lstINT{Table.Name}Checked);
            }}
            else
            {{
                lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllAsync();
            }}

            //To avoid conflicts with EF Core
            foreach ({Table.Name} {Table.Name.ToLower()} in lst{Table.Name})
            {{
                {Table.Name.ToLower()}.{Table.Name}Id = 0;
            }}

            await {Table.Name.ToLower()}Repository.AddRangeAsync(lst{Table.Name});

            paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginatedAsync(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;

            lstINT{Table.Name}Checked.Clear();

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Éxito"", ""Registros copiados correctamente."", ""success"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Error"", ""Hubo un error al hacer el copiado masivo. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await Task.Delay(1500);
            ShowLoaderInMassiveActionModal = false;
            await InvokeAsync(StateHasChanged);
        }}
    }}

    private async Task MassiveActionDelete()
    {{
        try
        {{
            ShowLoaderInMassiveActionModal = true;
            await InvokeAsync(StateHasChanged);

            if (MassiveActionType == ""only-chosen"")
            {{
                //Validation
                if (lstINT{Table.Name}Checked.Count == 0)
                {{
                    await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithLimitedTime"", ""Atención"", ""No hay registros para eliminar. Proceso cancelado"", ""warning"");
                    return;
                }}

                List<{Table.Name}?> lst{Table.Name} = await {Table.Name.ToLower()}Repository.GetAllBy{Table.Name}IdCheckedAsync(lstINT{Table.Name}Checked);

                await {Table.Name.ToLower()}Repository.DeleteManyBy{Table.Name}IdAsync(lst{Table.Name});
            }}
            else
            {{
                await {Table.Name.ToLower()}Repository.DeleteAll{Table.Name}Async();
            }}

            paginated{Table.Name}DTO = await {Table.Name.ToLower()}Repository
                                                .GetAllBy{Table.Name}IdPaginatedAsync(
                                                    """",
                                                    CheckStrict,
                                                    1,
                                                    RegistersPerPage);

            TotalRegisters = paginated{Table.Name}DTO.TotalRegisters;

            lstINT{Table.Name}Checked.Clear();

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Éxito"", ""Registros eliminados correctamente"", ""success"");
        }}
        catch (Exception ex)
        {{
            base.CatchException(ex);

            await IJSRuntime.InvokeVoidAsync(""toastHelper.showWithUnlimitedTime"", ""Error"", ""Hubo un error al hacer el borrado masivo. Intente nuevamente."", ""error"");
        }}
        finally
        {{
            //Re-render the page
            await Task.Delay(1500);
            ShowLoaderInMassiveActionModal = false;
            await InvokeAsync(StateHasChanged);
        }}
    }}
    #endregion
}}

";

                return Content;
            }
            catch (Exception) { throw; }
        }
    }
}
