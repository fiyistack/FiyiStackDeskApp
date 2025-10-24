using FiyiStackDeskApp.Areas.CMS.UserBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataTypeBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.VersionControlBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Interfaces;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        //SERVICE PROVIDER FOR ALL REPOSITORIES
        private readonly ServiceProvider _serviceProvider;

        //AREA: CMS  
        private readonly IUserRepository _userRepository;

        //AREA: FiyiStackDeskApp  
        private readonly IDataTypeRepository _dataTypeRepository;
        private readonly IProjectRepository _projectRepository;
        private readonly IDataBaseRepository _databaseRepository;
        private readonly ITableRepository _tableRepository;
        private readonly IFieldRepository _fieldRepository;
        private readonly IVersionControlRepository _versionControlRepository;
        private readonly INewsInLoginPageRepository _newsInLoginPageRepository;

        private readonly IG1ConfigurationRepository _g1ConfigurationRepository;

        public MainForm(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider ?? throw new InvalidOperationException("IUserRepository service is not registered.");
            _userRepository = serviceProvider.GetRequiredService<IUserRepository>() ?? throw new InvalidOperationException("IUserRepository service is not registered.");
            _dataTypeRepository = serviceProvider.GetRequiredService<IDataTypeRepository>() ?? throw new InvalidOperationException("IDataTypeRepository service is not registered.");
            _projectRepository = serviceProvider.GetRequiredService<IProjectRepository>() ?? throw new InvalidOperationException("IProjectRepository service is not registered.");
            _databaseRepository = serviceProvider.GetRequiredService<IDataBaseRepository>() ?? throw new InvalidOperationException("IDataBaseRepository service is not registered.");
            _tableRepository = serviceProvider.GetRequiredService<ITableRepository>() ?? throw new InvalidOperationException("ITableRepository service is not registered.");
            _fieldRepository = serviceProvider.GetRequiredService<IFieldRepository>() ?? throw new InvalidOperationException("IFieldRepository service is not registered.");
            _versionControlRepository = serviceProvider.GetRequiredService<IVersionControlRepository>() ?? throw new InvalidOperationException("IVersionControlRepository service is not registered.");
            _newsInLoginPageRepository = serviceProvider.GetRequiredService<INewsInLoginPageRepository>() ?? throw new InvalidOperationException("INewsInLoginPageRepository service is not registered.");

            _g1ConfigurationRepository = serviceProvider.GetRequiredService<IG1ConfigurationRepository>() ?? throw new InvalidOperationException("IG1ConfigurationRepository service is not registered.");

            //INITIALIZE UI COMPONENTS
            InitializeComponent();

            Initialize();

            //VERIFY VERSION OF THE APPLICATION
            decimal CurrentVersion = (decimal)1.01;
            decimal LastVersion = _versionControlRepository.GetByVersionControlId(1).VersionNumber;

            if (CurrentVersion < LastVersion)
            {
                //SHOW UPDATE MESSAGE
                MessageBox.Show($"Hay una nueva versión de FiyiStack disponible. Por favor, actualice la aplicación.", "FiyiStack | Actualización disponible", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            LoadPanelLogin();
        }

        private void Initialize()
        {
            LinkLabelWhatsApp.Text = "+543512329541";
            LinkLabelWebContact.Text = "fiyistack.com/contacto";
            LinkLabelEmail.Text = "support@fiyistack.com";

            lblMessageDockedBottom.Text = "";

            #region Manage radius of WinForms components
            //PANEL: LOGIN
            txtEmail.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtLoginPassword.BackColor = Program.SharedComponent.BlackColorPlus1;

            //PANEL: PROJECT
            txtSearchYourProjectByName.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtProjectName.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtProjectPath.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtProjectHistoryUser.BackColor = Program.SharedComponent.BlackColorPlus1;
            ListViewProjects.BackColor = Program.SharedComponent.BlackColorPlus1;
            ListViewDatabase.BackColor = Program.SharedComponent.BlackColorPlus1;


            ListViewTable.BackColor = Program.SharedComponent.BlackColorPlus1;
            ListViewField.BackColor = Program.SharedComponent.BlackColorPlus1;
            TextBoxLogger.BackColor = Program.SharedComponent.BlackColorPlus1;

            txtFieldName.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtFieldHistoryUser.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtTextRegex.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtDateTimeMax.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtDateTimeMin.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtTimeSpanMax.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtTimeSpanMin.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtHexColourMax.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtHexColourMin.BackColor = Program.SharedComponent.BlackColorPlus1;
            txtForeignTableName.BackColor = Program.SharedComponent.BlackColorPlus1;

            cmbDataType.BackColor = Program.SharedComponent.BlackColorPlus1;
            #endregion

            //STEP's IN GENERATOR PANEL
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = false;
            picStep4Summary.Visible = false;

            //LOAD COMBOBOX FOR DATA TYPES
            cmbDataType.ValueMember = "Value";
            cmbDataType.DisplayMember = "Text";
            cmbDataType.DataSource = _dataTypeRepository.GetList("");

            UndockAllGeneratorPanelsExcept(PanelDatabase);
        }
    }
}
