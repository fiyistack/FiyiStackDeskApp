using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.NewsInLoginPageBack.Entities;
using System.Diagnostics;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        private void LoadPanelLogin()
        {
            try
            {
                //PANEL: LOGIN
                this.Text = "FiyiStack | Login";

                lblMessageDockedBottom.Text = "Por favor, ingrese sus credenciales";

                UndockAllPanelsExcept(PanelLogin);

                //TOOLSTRIP MENU VISIBILITY
                salirToolStripMenuItem.Visible = true;
                volverALaSeccionToolStripMenuItem.Visible = false;
                cambiarDatosDeUsuarioToolStripMenuItem.Visible = false;
                cerrarSesionToolStripMenuItem.Visible = false;

                txtEmail.Text = "novillo.matias1@gmail.com";
                txtLoginPassword.Text = "z";
                txtEmail.TabIndex = 0;
                txtLoginPassword.TabIndex = 1;

                //Get news
                NewsInLoginPage NewsInLoginPage = _newsInLoginPageRepository.GetLastNews();

                txtNews.Text = NewsInLoginPage.New;

            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente.", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Login()
        {
            try
            {
                if (txtEmail.Text != string.Empty && txtLoginPassword.Text != string.Empty)
                {
                    lblMessageDockedBottom.Text = "Intentando entrar...";

                    User UserToFind = _userRepository
                        .GetByFantasyNameByEmailByPassword(txtEmail.Text, Library.Security.EncodeString(txtLoginPassword.Text)) ?? new();

                    if (UserToFind.UserId == 0)
                    {
                        //USER NOT FOUND
                        lblMessageDockedBottom.Text = "Usuario no encontrado.";
                    }
                    else
                    {
                        //USER FOUND
                        Program.SharedComponent.LoggedUser = new()
                        {
                            UserId = UserToFind.UserId,
                            Email = UserToFind.Email,
                            Password = UserToFind.Password,
                            Active = UserToFind.Active,
                            DateTimeCreation = UserToFind.DateTimeCreation,
                            DateTimeLastModification = DateTime.Now,
                            UserCreationId = UserToFind.UserCreationId,
                            UserLastModificationId = UserToFind.UserLastModificationId
                        };

                        //TODO Save user visit in FiyiStackWeb

                        lblMessageDockedBottom.Text = "Usuario encontrado. Entrando...";

                        UndockAllPanelsExcept(PanelProject);

                        LoadProjectPanel();
                    }

                    //Reset fields
                    txtEmail.Text = string.Empty;
                    txtLoginPassword.Text = string.Empty;
                }
                else
                {
                    //FIELDS EMPTY
                    lblMessageDockedBottom.Text = "Por favor, complete todos los campos.";
                }
            }
            catch (Exception ex)
            {
                SharedComponent.AddFailure(ex, _serviceProvider);

                MessageBox.Show("Hubo un error inesperado en la aplicación. Intente nuevamente", "FiyiStack | Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //Code for Enter button
            {
                Login();
            }
        }

        private void txtFantasyNameOrEmail_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyValue == 13) //Code for Enter button
            {
                Login();
            }
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Login();
        }

        private void btnSee_MouseDown(object sender, MouseEventArgs e)
        {
            txtLoginPassword.PasswordChar = '\0';
            btnSeePassword.Visible = false;
        }

        private void btnSee_MouseUp(object sender, MouseEventArgs e)
        {
            txtLoginPassword.PasswordChar = '*';
            btnSeePassword.Visible = true;
        }

        private void LinkLabelWhatsApp_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open WhatsApp with specified number
            string URL = "https://wa.me/543512329541";
            Process.Start(new ProcessStartInfo
            {
                FileName = URL,
                UseShellExecute = true
            });
        }

        private void LinkLabelWebContact_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open Contact page in browser
            var url = "https://fiyistack.com/Contacto";
            Process.Start(new ProcessStartInfo
            {
                FileName = url,
                UseShellExecute = true
            });
        }

        private void LinkLabelEmail_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            //Open email client with recipient, subject and body
            var mailto = "mailto:support@fiyistack.com?subject=Consulta%20desde%20la%20app&body=Hola%20FiyiStack!";
            Process.Start(new ProcessStartInfo
            {
                FileName = mailto,
                UseShellExecute = true
            });
        }

        private void btnAmpliar_Click(object sender, EventArgs e)
        {
            LoginForms.ExpandNoticeOrInformation ExpandNoticeOrInformation = new(_serviceProvider);
            ExpandNoticeOrInformation.ShowDialog();
        }
    }
}
