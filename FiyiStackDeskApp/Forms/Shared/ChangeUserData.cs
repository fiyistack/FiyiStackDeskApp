using FiyiStackDeskApp.Areas.CMS.UserBack.Interfaces;
using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using Microsoft.Extensions.DependencyInjection;
using FiyiStackDeskApp.Library;

namespace FiyiStackDeskApp.Forms.Shared
{
    public partial class ChangeUserData : Form
    {
        private readonly ServiceProvider _serviceProvider;

        private readonly IUserRepository? _userRepository;
        
        public ChangeUserData(ServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;

            try
            {
                _userRepository = serviceProvider.GetRequiredService<IUserRepository>();

                InitializeComponent();

            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnEditPassword_Paint(object sender, PaintEventArgs e)
        {
            UI.SetBorderRadiusToControl(ref sender, 10, 10);
        }

        private void btnEditUserData_Click(object sender, EventArgs e)
        {
            try
            {
                if(_userRepository == null)
                {
                    MessageBox.Show("No se pudo obtener el repositorio de usuarios.");
                    return;
                }

                string CurrentPassword = txtCurrentPassword.Text.Trim();
                string NewPassword = txtNewPassword.Text.Trim();
                string NewRepeatPassword = txtNewPasswordRepeated.Text.Trim();

                //Reset fields after reading them
                txtCurrentPassword.Text = string.Empty;
                txtNewPassword.Text = string.Empty;
                txtNewPasswordRepeated.Text = string.Empty;

                if (NewPassword != NewRepeatPassword)
                {
                    MessageBox.Show("Las contraseñas nuevas no coinciden. Intente nuevamente.");
                    return;
                }


                if (CurrentPassword == string.Empty ||
                    NewPassword == string.Empty ||
                    NewRepeatPassword == string.Empty)
                {
                    MessageBox.Show("No se permiten campos vacíos");
                    return;
                }

                User LoggedUser = Program.SharedComponent.LoggedUser;

                User UserTryingToChangePassword = _userRepository
                    .GetByFantasyNameByEmailByPassword(LoggedUser.Email!, Security.EncodeString(CurrentPassword)) ?? new();

                if (UserTryingToChangePassword.UserId == 0)
                {
                    MessageBox.Show("La contraseña actual es incorrecta. Intente nuevamente.");
                    return;
                }

                LoggedUser.Password = Security.EncodeString(NewPassword);

                _userRepository.Update(LoggedUser);

                MessageBox.Show("Datos actualizados correctamente");

                this.Close();
            }
            catch (Exception ex)
            {
                

                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }
    }
}
