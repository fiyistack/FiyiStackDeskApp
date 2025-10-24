using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        // /////////////////////////////////////////////////////////////////////////////////////////
        // TABLES
        // /////////////////////////////////////////////////////////////////////////////////////////
        private void txtSearchTable_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtTableSearchTable_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ListViewTable.Items.Clear();

                    List<Table> lstTable = _tableRepository
                        .GetAllByDatabaseIdByNameInSearchBar(Program.SharedComponent.ChosenDatabase.DataBaseId,
                        txtSearchTable.Text);

                    foreach (Table table in lstTable)
                    {
                        ListViewItem lvi = new($"[{table.Scheme}].[{table.Area}.{table.Name}]")
                        {
                            Tag = table.TableId
                        };

                        ListViewTable.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewTable_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando tabla...";


                foreach (ListViewItem table in ListViewTable.Items)
                {
                    if (table.Selected)
                    {
                        Table ChosenTable = _tableRepository.GetByTableId(Convert.ToInt32(table.Tag))!;

                        Program.SharedComponent.ChosenTable = ChosenTable;

                        txtTableName.Text = ChosenTable.Name;
                        txtTableScheme.Text = ChosenTable.Scheme;
                        txtTableArea.Text = ChosenTable.Area;

                        Program.SharedComponent.WantNewTable = false;

                        LoadFieldsInListViewField();

                        lblMessageDockedBottom.Text = $@"Tabla {ChosenTable.Name} cargada correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnDeleteTables_Click(object sender, EventArgs e)
        {
            try
            {
                for (int i = 0; i < ListViewTable.Items.Count; i++)
                {
                    if (ListViewTable.Items[i].Checked)
                    {
                        Table TableToDelete = _tableRepository.GetByTableId(Convert.ToInt32(ListViewTable.Items[i].Tag))!;
                        //First, delete the Table inside FiyiStackDeskApp
                        _tableRepository.DeleteByTableId(TableToDelete.TableId);

                        List<Field> lstFieldsToDelete = _fieldRepository.GetAllByTableId(TableToDelete.TableId);

                        foreach (Field field in lstFieldsToDelete)
                        {
                            //Then, delete the Fields inside FiyiStackDeskApp
                            _fieldRepository.DeleteByFieldId(field.FieldId);
                        }
                    }
                }

                LoadTablesInListViewTable();
                ListViewField.Clear();

                txtTableName.Text = string.Empty;
                txtTableScheme.Text = string.Empty;
                txtTableArea.Text = string.Empty;

                lblMessageDockedBottom.Text = $@"Tabla/s borrada/s correctamente. Ahora, cree una nueva o editela, luego haga clic en la sección COLUMNAS";
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnNewTable_Click(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando tabla nueva...";

                Program.SharedComponent.WantNewTable = true;

                txtTableName.Text = string.Empty;
                txtTableScheme.Text = string.Empty;
                txtTableArea.Text = string.Empty;

                foreach (ListViewItem table in ListViewTable.Items)
                {
                    table.Checked = false;
                    table.Selected = false;
                }

                lblMessageDockedBottom.Text = "Tabla nueva cargada. Edite los atributos de la misma desde el panel de atributos, guarde y/o haga clic en COLUMNAS";
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSaveTable_Click(object sender, EventArgs e)
        {
            try
            {
                string TableNameToSave = txtTableName.Text.Trim();
                string TableSchemeToSave = txtTableScheme.Text.Trim();
                string TableAreaToSave = txtTableArea.Text.Trim();

                if (TableNameToSave != string.Empty && 
                    TableSchemeToSave != string.Empty &&
                    TableAreaToSave != string.Empty)
                {
                    if (Program.SharedComponent.WantNewTable)
                    {
                        //ADD TABLE

                        Table TableToAdd = new()
                        {
                            Name = TableNameToSave,
                            Scheme = TableSchemeToSave,
                            Area = TableAreaToSave,
                            DataBaseId = Program.SharedComponent.ChosenDatabase.DataBaseId,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            Version = "V1",
                            TableId = 0
                        };

                        int AddedTableId = _tableRepository.AddReturnId(TableToAdd);

                        TableToAdd.TableId = AddedTableId;

                        Program.SharedComponent.ChosenTable = TableToAdd;

                        Table TableAdded = _tableRepository.GetByTableId(AddedTableId)!;

                        Field FieldPrimaryKeyToAdd = new()
                        {
                            Name = TableAdded.Name + "Id",
                            DataTypeId = 8,
                            Nullable = false,
                            HistoryUser = "",
                            Regex = string.Empty,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            TableId = TableAdded.TableId,
                            FieldId = 0,
                            ForeignTableName = string.Empty,
                            MaxValue = string.Empty,
                            MinValue = string.Empty
                        };

                        _fieldRepository.Add(FieldPrimaryKeyToAdd);

                        Field FieldDateTimeCreation = new()
                        {
                            Name = "DateTimeCreation",
                            DataTypeId = 10,
                            Nullable = true,
                            HistoryUser = "",
                            Regex = string.Empty,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            TableId = TableAdded.TableId,
                            FieldId = 0,
                            ForeignTableName = string.Empty,
                            MaxValue = DateTime.MaxValue.ToString(),
                            MinValue = DateTime.MinValue.ToString()
                        };

                        _fieldRepository.Add(FieldDateTimeCreation);

                        Field FieldDateTimeLastModification = new()
                        {
                            Name = "DateTimeLastModification",
                            DataTypeId = 10,
                            Nullable = true,
                            HistoryUser = "",
                            Regex = string.Empty,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            TableId = TableAdded.TableId,
                            FieldId = 0,
                            ForeignTableName = string.Empty,
                            MaxValue = DateTime.MaxValue.ToString(),
                            MinValue = DateTime.MinValue.ToString()
                        };

                        _fieldRepository.Add(FieldDateTimeLastModification);

                        Field FieldUserCreationId = new()
                        {
                            Name = "UserCreationId",
                            DataTypeId = 3,
                            Nullable = true,
                            HistoryUser = "",
                            Regex = string.Empty,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            TableId = TableAdded.TableId,
                            FieldId = 0,
                            ForeignTableName = string.Empty,
                            MaxValue = $@"{int.MaxValue}",
                            MinValue = "1"
                        };

                        _fieldRepository.Add(FieldUserCreationId);


                        Field FieldUserLastModificationId = new()
                        {
                            Name = "UserLastModificationId",
                            DataTypeId = 3,
                            Nullable = true,
                            HistoryUser = "",
                            Regex = string.Empty,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            TableId = TableAdded.TableId,
                            FieldId = 0,
                            ForeignTableName = string.Empty,
                            MaxValue = $@"{int.MaxValue}",
                            MinValue = "1"
                        };

                        _fieldRepository.Add(FieldUserLastModificationId);

                        Field FieldActive = new()
                        {
                            Name = "Active",
                            DataTypeId = 4,
                            Nullable = true,
                            HistoryUser = "",
                            Regex = string.Empty,
                            Active = true,
                            DateTimeCreation = DateTime.Now,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                            UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                            TableId = TableAdded.TableId,
                            FieldId = 0,
                            ForeignTableName = string.Empty,
                            MaxValue = string.Empty,
                            MinValue = string.Empty
                        };

                        _fieldRepository.Add(FieldActive);

                        lblMessageDockedBottom.Text = $"Tabla {TableNameToSave} creada correctamente";
                    }
                    else
                    {
                        //UPDATE TABLE
                        lblMessageDockedBottom.Text = "Editando tabla...";

                        Program.SharedComponent.ChosenTable.Name = TableNameToSave;
                        Program.SharedComponent.ChosenTable.Scheme = TableSchemeToSave;
                        Program.SharedComponent.ChosenTable.Area = TableAreaToSave;

                        _databaseRepository.Update(Program.SharedComponent.ChosenDatabase);

                        lblMessageDockedBottom.Text = $"Tabla {TableNameToSave} actualizada correctamente";
                    }

                    LoadTablesInListViewTable();

                    txtTableName.Text = string.Empty;
                    txtTableScheme.Text = string.Empty;
                    txtTableArea.Text = string.Empty;
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

        private void btnSelectAllTable_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviTable in ListViewTable.Items)
            {
                lviTable.Checked = true;
            }
        }

        private void LoadTablesInListViewTable()
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando tablas...";
                

                if (Program.SharedComponent.ChosenDatabase.DataBaseId == 0)
                {
                    lblMessageDockedBottom.Text = "Primero, seleccione una base de datos";
                    return;
                }

                Table Table = new();

                Program.SharedComponent.lstTableInFiyiStackDeskAppDB = _tableRepository
                    .GetAllByDatabaseIdByName(Program.SharedComponent.ChosenDatabase.DataBaseId, txtSearchTable.Text);

                //Fill listview
                ListViewTable.Clear();
                foreach (Table table in Program.SharedComponent.lstTableInFiyiStackDeskAppDB)
                {
                    ListViewItem lvi = new($"[{table.Scheme}].[{table.Area}.{table.Name}]")
                    {
                        Tag = table.TableId
                    };

                    ListViewTable.Items.Add(lvi);
                }

                Table = new Table();
                Program.SharedComponent.ChosenTable = Table;

                lblMessageDockedBottom.Text = $@"Tablas de la base de datos {Program.SharedComponent.ChosenDatabase.Name} cargadas correctamente";
                
            }
            catch (Exception ex)
            {
                ListViewTable.Items.Clear();
                ListViewField.Items.Clear();

                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
