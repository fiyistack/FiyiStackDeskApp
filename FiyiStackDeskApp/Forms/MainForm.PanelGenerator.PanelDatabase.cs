using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        // /////////////////////////////////////////////////////////////////////////////////////////
        // DATABASES
        // /////////////////////////////////////////////////////////////////////////////////////////

        private void txtSearchDatabaseByName_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ListViewDatabase.Items.Clear();

                    List<DataBase> lstDatabase = _databaseRepository
                        .GetAllByProjectIdByNameInSearchBar(Program.SharedComponent.ChosenProject.ProjectId,
                        txtSearchDatabaseByName.Text);

                    foreach (DataBase database in lstDatabase)
                    {
                        ListViewItem item = new(database.Name)
                        {
                            Tag = database.DataBaseId,
                            ImageIndex = 0 //OK 
                        };
                        ListViewDatabase.Items.Add(item);
                    }
                }
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewDatabase_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando base de datos...";
                

                foreach (ListViewItem database in ListViewDatabase.Items)
                {
                    if (database.Selected)
                    {
                        DataBase ChosenDatabase = _databaseRepository.GetByDataBaseId(Convert.ToInt32(database.Tag))!;

                        Program.SharedComponent.ChosenDatabase = ChosenDatabase;

                        txtDatabaseName.Text = ChosenDatabase.Name;
                        txtDatabaseConnectionStringForMSSQLServer.Text = ChosenDatabase.ConnectionStringForMSSQLServer;

                        Program.SharedComponent.WantNewDatabase = false;

                        LoadTablesInListViewTable();
                    }
                }
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDeleteDataBases_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Borrando base/s de datos...";
                

                for (int i = 0; i < ListViewDatabase.Items.Count; i++)
                {
                    if (ListViewDatabase.Items[i].Checked)
                    {
                        //First, delete the Database
                        DataBase DataBaseToDelete = _databaseRepository
                            .GetByDataBaseId(Convert.ToInt32(ListViewDatabase.Items[i].Tag))!;

                        _databaseRepository.DeleteByDataBaseId(DataBaseToDelete.DataBaseId);

                        List<Table> lstTablesToDelete = _tableRepository
                            .GetAllByDatabaseId(Convert.ToInt32(DataBaseToDelete.DataBaseId));

                        //Second, delete the Tables associated to that Database
                        foreach (Table tableToDelete in lstTablesToDelete)
                        {
                            _tableRepository.DeleteByTableId(tableToDelete.TableId);

                            List<Field> lstFieldsToDelete = _fieldRepository.GetAllByTableId(tableToDelete.TableId);

                            //Third, delete the Fields associated to each Table associated to that DataBase
                            foreach (Field fieldToDelete in lstFieldsToDelete)
                            {
                                _fieldRepository.DeleteByFieldId(fieldToDelete.FieldId);
                            }
                        }
                    }
                }

                LoadDataBasesInListViewDatabase();
                ListViewTable.Clear();
                ListViewField.Clear();

                txtDatabaseName.Text = string.Empty;
                txtDatabaseConnectionStringForMSSQLServer.Text = string.Empty;

                lblMessageDockedBottom.Text = $@"Base/s de datos borrada/s correctamente. Ahora, cree una nueva o editela, luego haga clic en la sección TABLAS";
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNewDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando base de datos nueva...";
                

                Program.SharedComponent.WantNewDatabase = true;

                txtDatabaseConnectionStringForMSSQLServer.Text = string.Empty;
                txtDatabaseName.Text = string.Empty;

                foreach (ListViewItem database in ListViewDatabase.Items)
                {
                    database.Checked = false;
                    database.Selected = false;
                }

                lblMessageDockedBottom.Text = "Base de datos nueva cargada. Edite los atributos de la misma desde el panel de atributos, guarde y/o haga clic en TABLAS ";
                
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSaveDatabase_Click(object sender, EventArgs e)
        {
            try
            {
                string DatabaseName = txtDatabaseName.Text.Trim();
                string ConnectionStringForMSSQLServer = txtDatabaseConnectionStringForMSSQLServer.Text.Trim();

                if (DatabaseName != string.Empty && ConnectionStringForMSSQLServer != string.Empty)
                {
                    if (Program.SharedComponent.WantNewDatabase)
                    {
                        //ADD DATABASE
                        lblMessageDockedBottom.Text = "Creando nueva base de datos...";

                        DataBase DatabaseToAdd = new()
                        {
                            DataBaseId = 0,
                            ProjectId = Program.SharedComponent.ChosenProject.ProjectId,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            Name = DatabaseName,
                            ConnectionStringForMSSQLServer = ConnectionStringForMSSQLServer
                        };

                        int AddedDatabaseId = _databaseRepository.AddReturnId(DatabaseToAdd);

                        DatabaseToAdd.DataBaseId = AddedDatabaseId;

                        Program.SharedComponent.ChosenDatabase = DatabaseToAdd;

                        lblMessageDockedBottom.Text = $"Base de datos {DatabaseName} creada correctamente";
                    }
                    else
                    {
                        //UPDATE DATABASE
                        lblMessageDockedBottom.Text = "Editando base de datos...";

                        Program.SharedComponent.ChosenDatabase.Name = DatabaseName;
                        Program.SharedComponent.ChosenDatabase.ConnectionStringForMSSQLServer = ConnectionStringForMSSQLServer;

                        _databaseRepository.Update(Program.SharedComponent.ChosenDatabase);

                        lblMessageDockedBottom.Text = $"Base de datos {DatabaseName} actualizada correctamente";
                    }

                    LoadDataBasesInListViewDatabase();

                    txtDatabaseName.Text = string.Empty;
                    txtDatabaseConnectionStringForMSSQLServer.Text = string.Empty;
                }
                else
                {
                    MessageBox.Show("Por favor, complete todos los campos para guardar", "FiyiStack | Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadDataBasesInListViewDatabase()
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando lista de bases de datos...";
                

                DataBase DataBase = new();
                Program.SharedComponent.lstSavedDataBasesInFiyiStackDeskAppDB = _databaseRepository.GetAllByProjectIdByName(Program.SharedComponent.ChosenProject.ProjectId, txtSearchDatabaseByName.Text);

                //Fill listview
                ListViewDatabase.Clear();
                foreach (DataBase database in Program.SharedComponent.lstSavedDataBasesInFiyiStackDeskAppDB)
                {
                    ListViewItem lvi = new(database.Name)
                    {
                        Tag = database.DataBaseId,
                        ImageIndex = 0 //OK 
                    };
                    ListViewDatabase.Items.Add(lvi);
                }

                lblMessageDockedBottom.Text = "Bases de datos cargadas correctamente";
                
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnCopyDBLocalhost_Click(object sender, EventArgs e)
        {
            try
            {
                txtDatabaseConnectionStringForMSSQLServer.Text = "data source =.;initial catalog=[PUT_A_DATABASE_NAME];Integrated Security = SSPI;MultipleActiveResultSets=True;Pooling=false;persist security info=True;App=EntityFramework;TrustServerCertificate=True";
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnCopyDBProduction_Click(object sender, EventArgs e)
        {
            try
            {
                txtDatabaseConnectionStringForMSSQLServer.Text = "Password=[PUT_A_PASSWORD];Persist Security Info=True;User ID=[PUT_A_USER_ID];Initial Catalog=[PUT_A_DATABASE_NAME];Data Source=[PUT_A_SOURCE_(SERVER)];TrustServerCertificate=True";
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
