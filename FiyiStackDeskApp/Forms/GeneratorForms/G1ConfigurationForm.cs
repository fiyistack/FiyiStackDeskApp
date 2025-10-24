using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiyiStackDeskApp.Forms.GeneratorForms
{
    public partial class G1ConfigurationForm : Form
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IG1ConfigurationRepository _g1ConfigurationRepository;

        public G1ConfigurationForm(ServiceProvider serviceProvider)
        {
            try
            {
                _serviceProvider = serviceProvider;
                _g1ConfigurationRepository = serviceProvider.GetRequiredService<IG1ConfigurationRepository>();


                InitializeComponent();

                //Load Configuration inside WinForm
                chbDeleteTable.Checked = Program.SharedComponent.G1Configuration.DeleteTable;
                chbDeleteField.Checked = Program.SharedComponent.G1Configuration.DeleteField;
                chbDeleteFiles.Checked = Program.SharedComponent.G1Configuration.DeleteFiles;
                chbWantCSharp.Checked = Program.SharedComponent.G1Configuration.WantCSharp;
                chbWantMSSQLServer.Checked = Program.SharedComponent.G1Configuration.WantMSSQLServer;

                //Back-end
                if (Program.SharedComponent.ChosenProject.Path.Trim() != "")
                {
                    ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("DTO"));
                    ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Entity"));
                    ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Entity configuration"));
                    ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Interfaces"));
                    ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Repository"));
                    ListViewBackEndFilesGenerators.Items.Add(new ListViewItem("Service"));
                    ListViewBackEndFilesGenerators.Items[0].Checked = Program.SharedComponent.G1Configuration.WantDTO;
                    ListViewBackEndFilesGenerators.Items[1].Checked = Program.SharedComponent.G1Configuration.WantEntity;
                    ListViewBackEndFilesGenerators.Items[2].Checked = Program.SharedComponent.G1Configuration.WantEntityConfiguration;
                    ListViewBackEndFilesGenerators.Items[3].Checked = Program.SharedComponent.G1Configuration.WantInterfaces;
                    ListViewBackEndFilesGenerators.Items[4].Checked = Program.SharedComponent.G1Configuration.WantRepository;
                    ListViewBackEndFilesGenerators.Items[5].Checked = Program.SharedComponent.G1Configuration.WantService;
                }

                //Front-end
                if (Program.SharedComponent.ChosenProject.Path.Trim() != "")
                {
                    ListViewFrontEndFilesGenerators.Items.Add(new ListViewItem("Blazor pages"));
                    ListViewFrontEndFilesGenerators.Items[0].Checked = Program.SharedComponent.G1Configuration.WantBlazorPages;
                }
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (Program.SharedComponent.ChosenProject.ProjectId == 0) { throw new Exception("Project not selected"); }
                else
                {
                    Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities.G1Configuration Configuration = _g1ConfigurationRepository.GetByProjectId(Program.SharedComponent.ChosenProject.ProjectId);

                    Configuration.DeleteTable = chbDeleteTable.Checked;
                    Configuration.DeleteField = chbDeleteField.Checked;
                    Configuration.DeleteFiles = chbDeleteFiles.Checked;
                    Configuration.WantCSharp = chbWantCSharp.Checked;
                    Configuration.WantMSSQLServer = chbWantMSSQLServer.Checked;

                    //Back-end
                    if (Program.SharedComponent.ChosenProject.Path.Trim() != "")
                    {
                        Configuration.WantDTO = ListViewBackEndFilesGenerators.Items[0].Checked;
                        Configuration.WantEntity = ListViewBackEndFilesGenerators.Items[1].Checked;
                        Configuration.WantEntityConfiguration = ListViewBackEndFilesGenerators.Items[2].Checked;
                        Configuration.WantInterfaces = ListViewBackEndFilesGenerators.Items[3].Checked;
                        Configuration.WantRepository = ListViewBackEndFilesGenerators.Items[4].Checked;
                        Configuration.WantService = ListViewBackEndFilesGenerators.Items[5].Checked;
                    }

                    //Front-end
                    if (Program.SharedComponent.ChosenProject.Path.Trim() != "")
                    {
                        Configuration.WantBlazorPages = ListViewFrontEndFilesGenerators.Items[0].Checked;
                    }

                    if (Configuration.G1ConfigurationId != 0) //Edit
                    {
                        Configuration.DateTimeLastModification = DateTime.Now;
                        Configuration.UserLastModificationId = Program.SharedComponent.LoggedUser.UserId;

                        _g1ConfigurationRepository.Update(Configuration);
                    }
                    else //Add
                    {
                        Configuration.DateTimeCreation = DateTime.Now;
                        Configuration.DateTimeLastModification = DateTime.Now;
                        Configuration.UserCreationId = Program.SharedComponent.LoggedUser.UserId;
                        Configuration.UserLastModificationId = Program.SharedComponent.LoggedUser.UserId;

                        _g1ConfigurationRepository.Add(Configuration);
                    }
                }

                SharedComponent.LoadConfiguration(_serviceProvider);
                this.Close();
            }
            catch (Exception ex) 
            { 
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Secondary configuration. Painting mostly

        private void btnSave_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void ListViewGenerators_BackColorChanged(object sender, EventArgs e)
        {
            Library.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }
        #endregion
    }
}
