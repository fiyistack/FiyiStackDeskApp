using FiyiStackDeskApp.Properties;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;
using FiyiStackDeskApp.Library;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        // /////////////////////////////////////////////////////////////////////////////////////////
        // FIELDS
        // /////////////////////////////////////////////////////////////////////////////////////////

        private void txtSearchColumn_KeyDown(object sender, KeyEventArgs e)
        {
        }

        private void txtSearchColumn_KeyPress(object sender, KeyPressEventArgs e)
        {
            try
            {
                if (e.KeyChar == (char)Keys.Enter)
                {
                    ListViewField.Items.Clear();

                    List<Field> lstField = _fieldRepository
                        .GetAllByTableIdByNameInSearchBar(Program.SharedComponent.ChosenTable.TableId,
                        txtSearchColumn.Text);

                    foreach (Field field in lstField)
                    {
                        ListViewItem lvi = new($"{field.Name} {(field.Nullable == true ? "(Acepta nulos)" : "")}")
                        {
                            Tag = field.FieldId,
                        };

                        if (field.FieldId != 0)
                        {
                            //lvi.ImageIndex = 0; OK 

                            //The next lines are to improve the UX of DataTypes
                            lvi.ImageIndex = field.DataTypeId switch
                            {
                                //Integer
                                3 => 4,
                                //Boolean
                                4 => 5,
                                //Text: Basic
                                5 => 6,
                                //Decimal
                                6 => 7,
                                //Primary Key (Id)
                                8 => 8,
                                //DateTime
                                10 => 9,
                                //Time
                                11 => 10,
                                //Foreign Key (Id): Options
                                13 => 11,
                                //Text: HexColour
                                14 => 6,
                                //Text: TextArea
                                15 => 6,
                                //Text: TextEditor
                                16 => 6,
                                //Text: Password
                                17 => 6,
                                //Text: PhoneNumber
                                18 => 6,
                                //Text: URL
                                19 => 6,
                                //Text: Email
                                20 => 6,
                                //Text: File
                                21 => 6,
                                //Text: Tag
                                22 => 6,
                                //Foreign Key (Id): DropDown
                                23 => 11,
                                _ => throw new Exception($"{field.Name} have a Data Type not recognized"),
                            };
                        }
                        else
                        {
                            lvi.ImageIndex = 3; //Need to import to FiyiStack
                        }

                        ListViewField.Items.Add(lvi);
                    }
                }
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ListViewField_ItemActivate(object sender, EventArgs e)
        {
            try
            {
                lblMessageDockedBottom.Text = "Cargando columna...";

                foreach (ListViewItem field in ListViewField.Items)
                {
                    if (field.Selected)
                    {
                        Field ChosenField = _fieldRepository.GetByFieldId(Convert.ToInt32(field.Tag))!;

                        Program.SharedComponent.ChosenField = ChosenField;

                        txtFieldName.Text = ChosenField.Name;
                        txtFieldHistoryUser.Text = ChosenField.HistoryUser;
                        chbNullable.Checked = ChosenField.Nullable;
                        cmbDataType.SelectedValue = Program.SharedComponent.ChosenField.DataTypeId;
                        if (ChosenField.Nullable)
                        {
                            chbNullable.Checked = true;
                        }
                        else
                        {
                            chbNullable.Checked = false;
                        }

                        switch (ChosenField.DataTypeId)
                        {
                            case 3: //Integer
                                txtIntMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtIntMin.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MinValue);
                                break;
                            case 4: //Boolean

                                break;
                            case 5: //Text: Basic
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 6: //Decimal
                                txtDecimalMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtDecimalMin.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MinValue);
                                break;
                            case 8: //Primary Key (Id)

                                break;
                            case 10: //DateTime
                                txtDateTimeMax.Text = Program.SharedComponent.ChosenField.MaxValue;
                                txtDateTimeMin.Text = Program.SharedComponent.ChosenField.MinValue;
                                break;
                            case 11: //Time
                                txtTimeSpanMax.Text = Program.SharedComponent.ChosenField.MaxValue;
                                txtTimeSpanMin.Text = Program.SharedComponent.ChosenField.MinValue;
                                break;
                            case 13: //Foreign Key (Id): Options
                                txtForeignTableName.Text = Program.SharedComponent.ChosenField.ForeignTableName;
                                txtForeignColumnName.Text = Program.SharedComponent.ChosenField.ForeignColumnName;
                                break;
                            case 14: //Text: HexColour
                                txtHexColourMax.Text = Program.SharedComponent.ChosenField.MaxValue;
                                txtHexColourMin.Text = Program.SharedComponent.ChosenField.MinValue;
                                break;
                            case 15: //Text: TextArea
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 16: //Text: TextEditor
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 17: //Text: Password
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 18: //Text: PhoneNumber
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 19: //Text: URL
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 20: //Text: Email
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 21: //Text: File
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 22: //Text: Tag
                                txtTextMin.Value = 1;
                                txtTextMax.Value = Program.SharedComponent.ChosenField.MaxValue == "" ? 1 : Convert.ToDecimal(Program.SharedComponent.ChosenField.MaxValue);
                                txtTextRegex.Text = Program.SharedComponent.ChosenField.Regex;
                                break;
                            case 23: //Foreign Key (Id): DropDown
                                txtForeignTableName.Text = Program.SharedComponent.ChosenField.ForeignTableName;
                                txtForeignColumnName.Text = Program.SharedComponent.ChosenField.ForeignColumnName;
                                break;
                            default:
                                throw new Exception($"The field have a Data Type not recognized");
                        }

                        lblMessageDockedBottom.Text = $@"Columna {ChosenField.Name} cargada correctamente";
                    }
                }
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDeleteField_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem field in ListViewField.Items)
                {
                    if (field.Checked)
                    {
                        _fieldRepository.DeleteByFieldId(Convert.ToInt32(field.Tag));
                    }
                }

                LoadFieldsInListViewField();

                txtFieldName.Text = string.Empty;
                txtFieldHistoryUser.Text = string.Empty;
                chbNullable.Checked = false;
                cmbDataType.SelectedIndex = 0;

                lblMessageDockedBottom.Text = $@"Fila/s borrada/s correctamente.";
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        
        private void btnNewField_Click(object sender, EventArgs e)
        {
            

            try
            {
                lblMessageDockedBottom.Text = "Cargando fila nueva...";

                txtFieldName.Text = string.Empty;
                txtFieldHistoryUser.Text = string.Empty;
                chbNullable.Checked = false;
                cmbDataType.SelectedIndex = 0;

                foreach (ListViewItem field in ListViewField.Items)
                {
                    field.Checked = false;
                    field.Selected = false;
                }

                //Hide all panels
                PanelText.Visible = false;
                PanelInteger.Visible = false;
                PanelDateTime.Visible = false;
                PanelTime.Visible = false;
                PanelHexColour.Visible = false;
                PanelDecimal.Visible = false;
                PanelPrimaryKey.Visible = false;
                PanelForeignKey.Visible = false;
                PanelBoolean.Visible = false;

                lblMessageDockedBottom.Text = "Fila nueva cargada. Edite los atributos de la misma desde el panel de atributos";
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void btnSaveField_Click(object sender, EventArgs e)
        {
            try
            {
                //Validations
                if (txtFieldName.Text.Trim() == "") 
                {
                    MessageBox.Show("Ingrese un nombre para la columna", 
                        "FiyiStack | Información", 
                        MessageBoxButtons.OK, 
                        MessageBoxIcon.Information);

                    return;
                }
                if (!Validator.IsRegexOk(txtFieldName.Text.Trim(), @"^[A-Za-z0-9]+$")) 
                {
                    MessageBox.Show("El nombre de la columna solo acepta numeros y letras",
                        "FiyiStack | Información",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);

                    return;
                }

                Field Field = new();

                foreach (ListViewItem field in ListViewField.Items)
                {
                    if (field.Selected)
                    {
                        Field = _fieldRepository.GetByFieldId(Convert.ToInt32(field.Tag))! ?? new();
                    }
                }

                //Collect data
                Field.Name = txtFieldName.Text;
                Field.TableId = Program.SharedComponent.ChosenTable.TableId;
                Field.HistoryUser = txtFieldHistoryUser.Text;
                Field.Nullable = chbNullable.Checked;
                Field.DataTypeId = Convert.ToInt32(cmbDataType.SelectedValue);
                Field.Active = true;
                Field.DateTimeLastModification = DateTime.Now;
                Field.UserLastModificationId = Program.SharedComponent.LoggedUser.UserId;

                switch (Convert.ToInt32(cmbDataType.SelectedValue))
                {
                    case 0:
                        throw new Exception("Seleccione un tipo de dato");
                    case 3: //Integer
                        if (txtIntMin.Value > txtIntMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtIntMin.Value > long.MaxValue || txtIntMin.Value < long.MinValue) { throw new Exception("The minimum entered is not supported"); }
                        if (txtIntMax.Value > long.MaxValue || txtIntMax.Value < long.MinValue) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtIntMin.Value.ToString();
                        Field.MaxValue = txtIntMax.Value.ToString();
                        break;
                    case 4: //Boolean
                        break;
                    case 5: //Text: Basic
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 6: //Decimal
                        if (txtDecimalMin.Value > txtDecimalMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtDecimalMin.Value > 9228162514264337593543950335m || txtDecimalMin.Value < -9228162514264337593543950335m) { throw new Exception("The minimum entered is not supported"); }
                        if (txtDecimalMax.Value > 9228162514264337593543950335m || txtDecimalMax.Value < -9228162514264337593543950335m) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtDecimalMin.Value.ToString();
                        Field.MaxValue = txtDecimalMax.Value.ToString();
                        break;
                    case 8: //Primary Key (Id)
                        break;
                    case 10: //DateTime
                        Field.MinValue = txtDateTimeMin.Text;
                        Field.MaxValue = txtDateTimeMax.Text;
                        break;
                    case 11: //Time
                        if (!Library.Validator.IsTimeSpan(txtTimeSpanMax.Text)) { throw new Exception("The maximum has a format not supported"); }
                        if (!Library.Validator.IsTimeSpan(txtTimeSpanMin.Text)) { throw new Exception("The minimum has a format not supported"); }
                        if (Convert.ToDateTime("01/01/1753 " + txtTimeSpanMin.Text) > Convert.ToDateTime("01/01/1753 " + txtTimeSpanMax.Text))
                        { throw new Exception("The minimum has to be at least equal to maximum"); }

                        Field.MinValue = txtTimeSpanMin.Text;
                        Field.MaxValue = txtTimeSpanMax.Text;
                        break;
                    case 13: //Foreign Key (Id): Options
                        Field.ForeignTableName = txtForeignTableName.Text;
                        Field.ForeignColumnName = txtForeignColumnName.Text;
                        break;
                    case 14: //Text: HexColour
                        if (!Validator.IsHexColour(txtHexColourMax.Text)) { throw new Exception("The maximum has a format not supported"); }
                        if (!Validator.IsHexColour(txtHexColourMin.Text)) { throw new Exception("The minimum has a format not supported"); }
                        char charValue2;
                        charValue2 = Validator.CompareStrings(txtHexColourMin.Text, txtHexColourMax.Text, true);
                        if (charValue2 == '\0') { throw new Exception("The inputs have different lengths"); }
                        if (charValue2 == 'A') { throw new Exception("The minimum has to be at least equal to maximum"); }
                        charValue2 = Validator.CompareStrings(txtHexColourMin.Text, "000000", true);
                        if (charValue2 == '\0') { throw new Exception("The minimum has a length not supported"); }
                        if (charValue2 == 'B') { throw new Exception("The minimum entered is not supported"); }
                        charValue2 = Validator.CompareStrings(txtHexColourMax.Text, "FFFFFF", true);
                        if (charValue2 == '\0') { throw new Exception("The maximum has a length not supported"); }
                        if (charValue2 == 'A') { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtHexColourMin.Text;
                        Field.MaxValue = txtHexColourMax.Text;
                        break;
                    case 15: //Text: TextArea
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 16: //Text: TextEditor
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 17: //Text: Password
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 18: //Text: PhoneNumber
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 19: //Text: URL
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 20: //Text: Email
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 21: //Text: File
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 22: //Text: Tag
                        if (txtTextMin.Value > txtTextMax.Value) { throw new Exception("The minimum has to be at least equal to maximum"); }
                        if (txtTextMin.Value > int.MaxValue || txtTextMin.Value < 1) { throw new Exception("The minimum entered is not supported"); }
                        if (txtTextMax.Value > int.MaxValue || txtTextMax.Value < 1) { throw new Exception("The maximum entered is not supported"); }

                        Field.MinValue = txtTextMin.Value.ToString();
                        Field.MaxValue = txtTextMax.Value.ToString();
                        Field.Regex = txtTextRegex.Text;
                        break;
                    case 23: //Foreign Key (Id): Options
                        Field.ForeignTableName = txtForeignTableName.Text;
                        Field.ForeignColumnName = txtForeignColumnName.Text;
                        break;
                    default:
                        throw new Exception("El tipo de dato seleccionado no es correcto");
                }

                if (Field.FieldId == 0)
                {
                    //ADD FIELD

                    Field.DateTimeCreation = DateTime.Now;
                    Field.UserCreationId = Program.SharedComponent.LoggedUser.UserId;

                    _fieldRepository.Add(Field);

                    lblMessageDockedBottom.Text = $"Field {txtFieldName.Text} added correctly";
                }
                else 
                {
                    //UPDATE FIELD

                    Field.DateTimeLastModification = DateTime.Now;
                    Field.UserLastModificationId = Program.SharedComponent.LoggedUser.UserId;

                    _fieldRepository.Update(Field);

                    lblMessageDockedBottom.Text = $"Field {txtFieldName.Text} updated correctly";
                }

                LoadFieldsInListViewField();

                txtFieldName.Text = string.Empty;
                txtFieldHistoryUser.Text = string.Empty;
                chbNullable.Checked = false;
                cmbDataType.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSelectAllField_Click(object sender, EventArgs e)
        {
            foreach (ListViewItem lviField in ListViewField.Items)
            {
                lviField.Checked = true;
            }
        }

        private void LoadFieldsInListViewField()
        {
            try
            {
                lblMessageDockedBottom.Text = "Loading";


                if (Program.SharedComponent.ChosenDatabase.DataBaseId == 0)
                {
                    throw new Exception("Select a database");
                }

                Field Field = new();
                Program.SharedComponent.lstFieldInFiyiStackDeskAppDB = _fieldRepository.GetAllByTableIdByName(Program.SharedComponent.ChosenTable.TableId, txtSearchColumn.Text);

                //Fill listview
                ListViewField.Clear();
                foreach (Field field in Program.SharedComponent.lstFieldInFiyiStackDeskAppDB)
                {
                    ListViewItem lvi = new($"{field.Name} {(field.Nullable == true ? "(Acepta nulos)" : "")}")
                    {
                        Tag = field.FieldId,
                    };

                    if (field.FieldId != 0)
                    {
                        //lvi.ImageIndex = 0; OK 

                        //The next lines are to improve the UX of DataTypes
                        lvi.ImageIndex = field.DataTypeId switch
                        {
                            //Integer
                            3 => 4,
                            //Boolean
                            4 => 5,
                            //Text: Basic
                            5 => 6,
                            //Decimal
                            6 => 7,
                            //Primary Key (Id)
                            8 => 8,
                            //DateTime
                            10 => 9,
                            //Time
                            11 => 10,
                            //Foreign Key (Id): Options
                            13 => 11,
                            //Text: HexColour
                            14 => 6,
                            //Text: TextArea
                            15 => 6,
                            //Text: TextEditor
                            16 => 6,
                            //Text: Password
                            17 => 6,
                            //Text: PhoneNumber
                            18 => 6,
                            //Text: URL
                            19 => 6,
                            //Text: Email
                            20 => 6,
                            //Text: File
                            21 => 6,
                            //Text: Tag
                            22 => 6,
                            //Foreign Key (Id): DropDown
                            23 => 11,
                            _ => throw new Exception($"{field.Name} have a Data Type not recognized"),
                        };
                    }
                    else
                    {
                        lvi.ImageIndex = 3; //Need to import to FiyiStack
                    }

                    ListViewField.Items.Add(lvi);
                }

                lblMessageDockedBottom.Text = "Fields loaded. Ready";
                txtFieldName.Text = "";
                txtFieldHistoryUser.Text = "";
                chbNullable.Checked = false;
                cmbDataType.SelectedIndex = 0;

            }
            catch (Exception ex)
            {
                ListViewField.Items.Clear();

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cmbDataType_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                //Hide all panels
                PanelText.Visible = false;
                PanelInteger.Visible = false;
                PanelDateTime.Visible = false;
                PanelTime.Visible = false;
                PanelHexColour.Visible = false;
                PanelDecimal.Visible = false;
                PanelPrimaryKey.Visible = false;
                PanelForeignKey.Visible = false;
                PanelBoolean.Visible = false;

                //Set to default all Data Type components
                txtTextMin.Value = 1;
                txtTextMax.Value = 8000;
                txtTextRegex.Text = "";
                txtForeignTableName.Text = "";
                txtForeignColumnName.Text = "";

                txtIntMax.Value = long.MaxValue;
                txtIntMin.Value = 0;

                txtTimeSpanMin.Text = "00:00";
                txtTimeSpanMax.Text = "23:59";

                DatePickerMax.Value = new DateTime(9998, 12, 30, 23, 59, 59, 999);
                DatePickerMin.Value = new DateTime(1753, 1, 1, 0, 0, 0, 0);
                TimePickerMax.Value = new DateTime(9998, 12, 30, 23, 59, 59, 999);
                TimePickerMin.Value = new DateTime(1753, 1, 1, 12, 0, 0, 0);
                txtDateTimeMax.Text = $@"{DatePickerMax.Value.ToString("yyyy-MM-ddT")}{TimePickerMax.Value.ToString("HH:mm")}";
                txtDateTimeMin.Text = $@"{DatePickerMin.Value.ToString("yyyy-MM-ddT")}{TimePickerMin.Value.ToString("HH:mm")}";

                txtHexColourMax.Text = "FFFFFF";
                txtHexColourMin.Text = "000000";

                txtDecimalMax.Value = 9228162514264337593543950335m;
                txtDecimalMin.Value = 0;

                switch (Convert.ToInt32(cmbDataType.SelectedValue))
                {
                    case 0:
                        break;
                    case 3: //Integer
                        PanelInteger.Visible = true;
                        break;
                    case 4: //Boolean
                        PanelBoolean.Visible = true;
                        break;
                    case 5: //Text: Basic
                        PanelText.Visible = true;
                        break;
                    case 6: //Decimal
                        PanelDecimal.Visible = true;
                        break;
                    case 8: //Primary Key (Id)
                        PanelPrimaryKey.Visible = true;
                        break;
                    case 10: //DateTime
                        PanelDateTime.Visible = true;
                        break;
                    case 11: //Time
                        PanelTime.Visible = true;
                        break;
                    case 13: //Foreign Key (Id): Options
                        PanelForeignKey.Visible = true;
                        break;
                    case 14: //Text: HexColour
                        PanelHexColour.Visible = true;
                        break;
                    case 15: //Text: TextArea
                        PanelBoolean.Visible = true;
                        break;
                    case 16: //Text: TextEditor
                        PanelBoolean.Visible = true;
                        break;
                    case 17: //Text: Password
                        PanelText.Visible = true;
                        break;
                    case 18: //Text: PhoneNumber
                        PanelText.Visible = true;
                        break;
                    case 19: //Text: URL
                        PanelText.Visible = true;
                        break;
                    case 20: //Text: Email
                        PanelText.Visible = true;
                        break;
                    case 21: //Text: File
                        PanelText.Visible = true;
                        break;
                    case 22: //Text: Tag
                        PanelText.Visible = true;
                        break;
                    case 23: //Foreign Key (Id): DropDown
                        PanelForeignKey.Visible = true;
                        break;
                    default:
                        throw new Exception("Error en el tipo de dato.");
                }
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
