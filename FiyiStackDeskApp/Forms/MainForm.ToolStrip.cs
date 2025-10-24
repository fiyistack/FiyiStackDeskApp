using FiyiStackDeskApp.Forms.Shared;

namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        private void cambiarDatosDeUsuarioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangeUserData ChangeUserData = new(_serviceProvider);
            ChangeUserData.ShowDialog();
        }

        private void volverAProyectosToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UndockAllPanelsExcept(PanelProject);
            //lblTitle.Text = "Load or edit a project";
            //lblSubtitle.Text = $@"";
        }

        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void cerrarSesionToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Program.SharedComponent.ChosenProject = new();
            Program.SharedComponent.ChosenTable = new();
            Program.SharedComponent.ChosenField = new();

            txtLoginPassword.Text = "";

            lblMessageDockedBottom.Text = "Sesión correctamente cerrada. Para entrar nuevamente, ingrese sus credenciales";

            cerrarSesionToolStripMenuItem.Visible = false;
            cambiarDatosDeUsuarioToolStripMenuItem.Visible = false;

            UndockAllPanelsExcept(PanelLogin);
        }
    }
}
