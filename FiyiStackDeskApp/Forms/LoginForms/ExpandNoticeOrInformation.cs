using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Repositories;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace FiyiStackDeskApp.Forms.LoginForms
{
    public partial class ExpandNoticeOrInformation : Form
    {
        private readonly ServiceProvider _serviceProvider;
        private readonly INewsInLoginPageRepository _newsInLoginPageRepository;

        public ExpandNoticeOrInformation(ServiceProvider serviceProvider)
        {
            try
            {
                _serviceProvider = serviceProvider;
                _newsInLoginPageRepository = serviceProvider.GetRequiredService<INewsInLoginPageRepository>();

                InitializeComponent();

                txtNews.Text = string.Empty;

                NewsInLoginPage NewsInLoginPage = _newsInLoginPageRepository.GetLastNews();

                txtNews.Text = NewsInLoginPage.New;
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider!);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            try
            {
                Close();
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnClose_Paint(object sender, PaintEventArgs e)
        {
            Library.UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }
    }
}
