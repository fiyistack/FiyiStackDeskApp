using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using Microsoft.EntityFrameworkCore;
using System.Data;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm :Form
    {
        private void LoadProjectPanel() 
        {
            try
            {
                //PANEL: PROJECT

                cambiarDatosDeUsuarioToolStripMenuItem.Visible = true;
                cerrarSesionToolStripMenuItem.Visible = true;

                cmbConfigurationType.ValueMember = "Value";
                cmbConfigurationType.DisplayMember = "Text";
                cmbConfigurationType.DataSource = this.GetList("[ELEGIR]");


                //LOAD LISTVIEW PROJECTS
                LoadProjectsInListView();

                //SET TO EMPTY FIELDS
                txtProjectName.Text = string.Empty;
                txtProjectPath.Text = string.Empty;
                txtProjectHistoryUser.Text = string.Empty;

                Program.SharedComponent.WantNewProject = true;
                Program.SharedComponent.WantNewDatabase = true;
                Program.SharedComponent.WantNewTable = true;
                Program.SharedComponent.WantNewField = true;

                lblMessageDockedBottom.Text = "Seleccione un proyecto guardado o cree uno nuevo, luego pulse en EMPEZAR";
                
                this.Text = "FiyiStack | Gestión de proyectos";
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public DataTable GetList(string firstTextItem)
        {
            try
            {
                //Create DataTable with "Value" and "Text" columns
                DataTable DataTable = new();
                DataTable.Columns.Add("Value", typeof(string));
                DataTable.Columns.Add("Text", typeof(string));

                //Add first row to  TataTable with the parameter firstTextItem
                DataRow firstRow = DataTable.NewRow();
                firstRow["Value"] = "0";
                firstRow["Text"] = (firstTextItem ?? string.Empty).Trim();
                DataTable.Rows.Add(firstRow);

                DataRow g1Row = DataTable.NewRow();
                g1Row["Value"] = "1";
                g1Row["Text"] = "G1: Blazor + MS SQL Server";
                DataTable.Rows.Add(g1Row);

                DataRow g2Row = DataTable.NewRow();
                g2Row["Value"] = "2";
                g2Row["Text"] = "G2: API's REST en C# y .NET + MS SQL Server";
                DataTable.Rows.Add(g2Row);

                return DataTable;
            }
            catch (Exception ex)
            {
                throw new Exception("Error al obtener la lista de configuraciones", ex);
            }
        }

        private void LoadProjectsInListView()
        {
            try
            {
                ListViewProjects.Items.Clear();

                List<Project> lstProject = _projectRepository.GetAllByUserId
                    (Program.SharedComponent.LoggedUser.UserId);

                foreach (Project project in lstProject)
                {
                    Program.SharedComponent.lstSavedProjectsInFiyiStackDeskAppDB.Add(project);
                    ListViewItem item = new(project.Name)
                    {
                        Tag = project.ProjectId
                    };
                    ListViewProjects.Items.Add(item);
                }
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtSearchYourProjectByName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ListViewProjects.Items.Clear();

                    List<Project> lstProject = _projectRepository
                        .GetAllByUserIdByNameInSearchBar(Program.SharedComponent.LoggedUser.UserId,
                        txtSearchYourProjectByName.Text);

                    foreach (Project project in lstProject)
                    {
                        Program.SharedComponent.lstSavedProjectsInFiyiStackDeskAppDB.Add(project);
                        ListViewItem item = new(project.Name)
                        {
                            Tag = project.ProjectId
                        };
                        ListViewProjects.Items.Add(item);
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        private void btnNewProject_Click(object sender, EventArgs e)
        {
            lblMessageDockedBottom.Text = "Cargando proyecto nuevo...";
            
            Program.SharedComponent.WantNewProject = true;

            foreach (ListViewItem project in ListViewProjects.Items)
            {
                project.Checked = false;
                project.Selected = false;
            }

            txtProjectName.Text = string.Empty;
            txtProjectPath.Text = string.Empty;
            txtProjectHistoryUser.Text = string.Empty;

            cmbConfigurationType.SelectedValue = 0; // ELEGIR

            lblMessageDockedBottom.Text = "Proyecto nuevo cargado. Edite los atributos del mismo desde el panel de atributos, guarde y/o haga clic en EMPEZAR ";
            
        }

        private void btnDeleteYourProjects_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Borrando proyecto/s...";
                

                for (int i = 0; i < ListViewProjects.Items.Count; i++)
                {
                    if (ListViewProjects.Items[i].Checked)
                    {
                        Project ProjectToDelete = _projectRepository.GetByProjectId(Convert.ToInt32(ListViewProjects.Items[i].Tag));

                        _projectRepository.DeleteByProjectId(ProjectToDelete.ProjectId);

                        _g1ConfigurationRepository.DeleteByProjectId(ProjectToDelete.ProjectId);

                        List<Areas.FiyiStackDeskApp.DataBaseBack.Entities.DataBase> lstDataBase = _databaseRepository.GetAllByProjectIdByName(ProjectToDelete.ProjectId, txtSearchDatabaseByName.Text);
                        
                        foreach (Areas.FiyiStackDeskApp.DataBaseBack.Entities.DataBase DataBase in lstDataBase)
                        {
                            List<Areas.FiyiStackDeskApp.TableBack.Entities.Table> lstTable = _tableRepository.GetAllByDatabaseIdByName(DataBase.DataBaseId, txtSearchTable.Text);

                            foreach (Areas.FiyiStackDeskApp.TableBack.Entities.Table Table in lstTable)
                            {
                                List<Areas.FiyiStackDeskApp.FieldBack.Entities.Field> lstField = _fieldRepository.GetAllByTableIdByName(Table.TableId, txtSearchColumn.Text);

                                foreach (Areas.FiyiStackDeskApp.FieldBack.Entities.Field Field in lstField)
                                {
                                    _fieldRepository.DeleteByFieldId(Field.FieldId);
                                }

                                _tableRepository.DeleteByTableId(Table.TableId);
                            }

                            _databaseRepository.DeleteByDataBaseId(DataBase.DataBaseId);
                        }
                    }
                }
                LoadProjectsInListView();

                txtProjectName.Text = string.Empty;
                txtProjectPath.Text = string.Empty;
                txtProjectHistoryUser.Text = string.Empty;
                cmbConfigurationType.SelectedValue = 0; // ELEGIR

                lblMessageDockedBottom.Text = $@"Proyecto/s borrado/s correctamente. Ahora, cree un nuevo proyecto o editelo, luego haga clic en EMPEZAR";
                
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void ListViewYourProjects_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando proyecto...";
                

                foreach (ListViewItem project in ListViewProjects.Items)
                {
                    if (project.Selected)
                    {
                        Project ProjectChosen = Program.SharedComponent.lstSavedProjectsInFiyiStackDeskAppDB.Find(projectSaved =>
                                projectSaved.ProjectId == Convert.ToInt32(project.Tag));

                        //Load attributes panel of selected project
                        Program.SharedComponent.ChosenProject = _projectRepository.GetByProjectId(ProjectChosen.ProjectId);
                        txtProjectName.Text = Program.SharedComponent.ChosenProject.Name;
                        txtProjectPath.Text = Program.SharedComponent.ChosenProject.Path;
                        txtProjectHistoryUser.Text = Program.SharedComponent.ChosenProject.HistoryUser;
                        if (Program.SharedComponent.ChosenProject.ConfigurationTypeId == 1)
                        {
                            //G1
                            cmbConfigurationType.SelectedValue = 1;
                        }
                        else if (Program.SharedComponent.ChosenProject.ConfigurationTypeId == 2)
                        {
                            //G2
                            cmbConfigurationType.SelectedValue = 2;
                        }
                        else
                        {
                            //ELEGIR
                            cmbConfigurationType.SelectedValue = 0;
                        }
                    }
                }

                Program.SharedComponent.WantNewProject = false;

                lblMessageDockedBottom.Text = "Proyecto cargado correctamente. Puede optar por actualizar su información con el botón GUARDAR y/o continuar al generador haciendo clic en EMPEZAR";
                
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (txtProjectName.Text != string.Empty && 
                txtProjectPath.Text != string.Empty &&
                (string)cmbConfigurationType.SelectedValue != "0")
            {
                

                if (Program.SharedComponent.WantNewProject)
                {
                    //ADD PROJECT
                    lblMessageDockedBottom.Text = "Creando nuevo proyecto...";

                    Project ProjectToAdd = new()
                    {
                        ProjectId = 0,
                        Name = txtProjectName.Text.Trim(),
                        Path = txtProjectPath.Text.Trim(),
                        HistoryUser = txtProjectHistoryUser.Text.Trim(),
                        Active = true,
                        DateTimeCreation = DateTime.Now,
                        DateTimeLastModification = DateTime.Now,
                        UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                        UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                        ConfigurationTypeId = Convert.ToInt32((string)cmbConfigurationType.SelectedValue)
                    };

                    int AddedProjectId = _projectRepository.AddReturnId(ProjectToAdd);

                    ProjectToAdd.ProjectId = AddedProjectId;

                    Program.SharedComponent.ChosenProject = ProjectToAdd;

                    lblMessageDockedBottom.Text = $@"Proyecto {ProjectToAdd.Name} agregado correctamente. Haga clic en EMPEZAR para trabajar con el generador";
                }
                else
                {
                    //UPDATE PROJECT
                    lblMessageDockedBottom.Text = "Actualizando proyecto...";

                    Program.SharedComponent.ChosenProject.Name = txtProjectName.Text.Trim();
                    Program.SharedComponent.ChosenProject.Path = txtProjectPath.Text.Trim();
                    Program.SharedComponent.ChosenProject.HistoryUser = txtProjectHistoryUser.Text.Trim();

                    if ((string)cmbConfigurationType.SelectedValue == "1")
                    {
                        Program.SharedComponent.ChosenProject.ConfigurationTypeId = 1; // G1
                    }
                    else if ((string)cmbConfigurationType.SelectedValue == "2")
                    {
                        Program.SharedComponent.ChosenProject.ConfigurationTypeId = 2; // G2
                    }
                    else
                    {
                        MessageBox.Show("Debe elegir un tipo de generador para el proyecto", "FiyiStack | Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Program.SharedComponent.ChosenProject.ConfigurationTypeId = 0; // ELEGIR
                        return;
                    }

                    _projectRepository.Update(Program.SharedComponent.ChosenProject);

                    lblMessageDockedBottom.Text = $@"Proyecto {Program.SharedComponent.ChosenProject.Name} actualizado correctamente. Haga clic en EMPEZAR para trabajar con el generador";
                }

                LoadProjectsInListView();

                txtProjectName.Text = string.Empty;
                txtProjectPath.Text = string.Empty;
                txtProjectHistoryUser.Text = string.Empty;

                
            }
            else
            {
                MessageBox.Show("Rellene los campos Nombre del proyecto, Tipo de generador y Ubicación", "FiyiStack | Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            try
            {
                if (!string.IsNullOrEmpty(Program.SharedComponent.ChosenProject.Name)   &&
                    !string.IsNullOrEmpty(Program.SharedComponent.ChosenProject.Path))
                {
                    LoadPanelGenerator();
                }
                else
                {
                    MessageBox.Show("El proyecto a cargar para trabajar debe contener un nombre y una ubicación", "FiyiStack | Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnProjectSearchPath_Click(object sender, EventArgs e)
        {
            using FolderBrowserDialog FolderBrowserDialog = new();

            FolderBrowserDialog.Description = "Seleccioná una carpeta";
            FolderBrowserDialog.UseDescriptionForTitle = true;

            DialogResult DialogResult = FolderBrowserDialog.ShowDialog();

            if (DialogResult == DialogResult.OK && !string.IsNullOrWhiteSpace(FolderBrowserDialog.SelectedPath))
            {
                txtProjectPath.Text = FolderBrowserDialog.SelectedPath + "\\";
            }
        }
    }
}
