using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiyiStackDeskApp.Forms.GeneratorForms
{
    public partial class G2ConfigurationForm : Form
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly IG1ConfigurationRepository _configurationRepository;

        public G2ConfigurationForm(ServiceProvider serviceProvider)
        {
            try
            {
                _serviceProvider = serviceProvider;
                _configurationRepository = serviceProvider.GetRequiredService<IG1ConfigurationRepository>();


                InitializeComponent();

                ToolStatusLabel.Text = "Ready.";
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        #region Secondary configuration. Painting mostly
        private void StatusStrip_Click(object sender, EventArgs e)
        {
            SharedComponent.SetClipBoard(ToolStatusLabel.Text + "\n");
        }
        #endregion
    }
}
