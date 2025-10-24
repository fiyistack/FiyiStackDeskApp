using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using FiyiStackDeskApp.Generators.G1;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        private void LoadPanelGenerator()
        {
            try
            {
                //PANEL: Generator

                txtDatabaseName.Text = string.Empty;
                txtDatabaseConnectionStringForMSSQLServer.Text = string.Empty;
                txtSearchDatabaseByName.Text = string.Empty;
                txtSearchDatabaseByName.Text = string.Empty;

                txtTableArea.Text = string.Empty;
                txtTableName.Text = string.Empty;
                txtTableScheme.Text = string.Empty;
                txtSearchTable.Text = string.Empty;

                UndockAllPanelsExcept(PanelGenerator);

                LoadDataBasesInListViewDatabase();

                //Search the Configuration for the selected project or create a new one
                G1Configuration Configuration = _g1ConfigurationRepository.GetByProjectId(Program.SharedComponent.ChosenProject.ProjectId) ?? new();

                if (Configuration.G1ConfigurationId == 0)
                {
                    //If Configuration not found create one
                    Configuration = SharedComponent.LoadDefaultConfiguration();
                    Configuration.ProjectId = Program.SharedComponent.ChosenProject.ProjectId;
                    Configuration.UserCreationId = Program.SharedComponent.LoggedUser.UserId;
                    Configuration.UserLastModificationId = Program.SharedComponent.LoggedUser.UserId;

                    _g1ConfigurationRepository.Add(Configuration);
                }

                SharedComponent.LoadConfiguration(_serviceProvider);

                Program.SharedComponent.ChosenDatabase = new();

                lblMessageDockedBottom.Text = $@"Proyecto cargado correctamente";

                
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnGenerate_Click(object sender, EventArgs e)
        {
            try
            {
                //Validation and preparing
                lblMessageDockedBottom.Text = "Validando datos y preparando...";
                UndockAllGeneratorPanelsExcept(PanelSummary);

                Program.SharedComponent.lstTableToGenerate = [];
                Program.SharedComponent.lstFieldToGenerate = [];

                //Before generation done
                TextBoxLogger.Clear();
                lblMessageDockedBottom.Text = "Empezando...";
                PanelSummary.Visible = true;

                //Start generation
                for (int i = 0; i < ListViewTable.Items.Count; i++)
                {
                    if (ListViewTable.Items[i].Checked)
                    {
                        Table TableChecked = _tableRepository.GetByTableId(Convert.ToInt32(ListViewTable.Items[i].Tag)) ?? new();

                        if (TableChecked.TableId == 0)
                        {
                            MessageBox.Show("No se encontró la tabla seleccionada. Por favor, verifique la selección.", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        if (TableChecked.TableId == 0)
                        {
                            MessageBox.Show("No esta permitido generar código con campos faltantes.", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            throw new Exception("No esta permitido generar código con campos faltantes");
                        }
                        else
                        {
                            //Fill a list of tables, fields and stored procedures to generate
                            Program.SharedComponent.lstTableToGenerate.Add(TableChecked);
                            foreach (Field field in _fieldRepository.GetAllByTableIdByName(TableChecked.TableId, txtSearchColumn.Text))
                            {
                                Program.SharedComponent.lstFieldToGenerate.Add(field);
                            }
                        }
                    }
                }

                if (Program.SharedComponent.lstTableToGenerate.Count == 0)
                {
                    lblMessageDockedBottom.Text = "Nada para generar";
                    TextBoxLogger.Text += "Nada para generar";

                    return;
                }

                

                //Need it to avoid Exceptions
                if (string.IsNullOrEmpty(Program.SharedComponent.ChosenProject.Path))
                {
                    Program.SharedComponent.ChosenProject.Path = "";
                }

                if (Program.SharedComponent.ChosenProject.Path.Trim() != "")
                {
                    if (Program.SharedComponent.ChosenProject.ConfigurationTypeId == 1)
                    {
                        //G1 Generator
                        TextBoxLogger.Text += G1.Start(_serviceProvider,
                         Program.SharedComponent.G1Configuration,
                                     new G1FieldChainer(),
                                     Program.SharedComponent.ChosenProject,
                                     Program.SharedComponent.ChosenDatabase,
                                     Program.SharedComponent.lstTableInFiyiStackDeskAppDB,
                                     Program.SharedComponent.lstTableToGenerate,
                                     Program.SharedComponent.lstFieldToGenerate);
                    }
                    else if (Program.SharedComponent.ChosenProject.ConfigurationTypeId == 2)
                    {
                        //G2 Generator
                    }
                    else
                    {
                        MessageBox.Show("No se ha configurado el tipo de generador para este proyecto.", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                }

                //After generation done
                LoadTablesInListViewTable();
                ListViewField.Clear();
                
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void labelDataBase_Click(object sender, EventArgs e)
        {
            UndockAllGeneratorPanelsExcept(PanelDatabase);
            picStep1Databases.Visible = true;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = false;
            picStep4Summary.Visible = false;
        }

        private void labelTables_Click(object sender, EventArgs e)
        {
            UndockAllGeneratorPanelsExcept(PanelTable);
            picStep1Databases.Visible = false;
            picStep2Tables.Visible = true;
            picStep3Properties.Visible = false;
            picStep4Summary.Visible = false;
        }

        private void labelFields_Click(object sender, EventArgs e)
        {
            UndockAllGeneratorPanelsExcept(PanelField);
            picStep1Databases.Visible = false;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = true;
            picStep4Summary.Visible = false;
        }

        private void labelSummary_Click(object sender, EventArgs e)
        {
            UndockAllGeneratorPanelsExcept(PanelSummary);
            picStep1Databases.Visible = false;
            picStep2Tables.Visible = false;
            picStep3Properties.Visible = false;
            picStep4Summary.Visible = true;
        }

        private void btnShowConfigurationForm_Click(object sender, EventArgs e)
        {
            if (Program.SharedComponent.ChosenProject.ConfigurationTypeId == 1)
            {
                GeneratorForms.G1ConfigurationForm G1ConfigurationForm = new(_serviceProvider);
                G1ConfigurationForm.ShowDialog();
            }
            else if (Program.SharedComponent.ChosenProject.ConfigurationTypeId == 2)
            {
                GeneratorForms.G2ConfigurationForm G2ConfigurationForm = new(_serviceProvider);
                G2ConfigurationForm.ShowDialog();
            }
            else
            {
                MessageBox.Show("No se ha configurado el tipo de generador para este proyecto.", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
