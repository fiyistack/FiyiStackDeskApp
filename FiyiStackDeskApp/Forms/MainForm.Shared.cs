namespace FiyiStackDeskApp.Forms
{
    public partial class MainForm : Form
    {
        private void UndockAllPanelsExcept(Panel panelToDock)
        {
            PanelLogin.Hide();
            PanelProject.Hide();
            PanelGenerator.Hide();

            panelToDock.Show();
            panelToDock.Dock = DockStyle.Fill;
        }

        private void UndockAllGeneratorPanelsExcept(Panel generatorPanelToDock)
        {
            PanelDatabase.Hide();
            PanelTable.Hide();
            PanelField.Hide();
            PanelSummary.Hide();

            generatorPanelToDock.Show();
            generatorPanelToDock.Dock = DockStyle.Fill;
        }
    }
}
