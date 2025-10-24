using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;
using System.ComponentModel;

namespace FiyiStackDeskApp.Generators.G1
{
    public partial class G1ConfigurationComponent : Component
    {
        public G1Configuration G1Configuration { get; set; }
        public G1FieldChainer G1FieldChainer { get; set; }

        public Project ChosenProject { get; set; }
        public DataBase ChosenDatabase { get; set; }
        public List<Table> LstTableInFiyiStackDeskAppDB { get; set; }
        public List<Table> LstTableToGenerate { get; set; }
        public List<Field> LstFieldToGenerate { get; set; }

        public G1ConfigurationComponent(G1Configuration g1Configuration,
            G1FieldChainer g1FieldChainer,
            Project projectChosen,
            DataBase databaseChosen,
            List<Table> lstTableInFiyiStackDeskAppDB,
            List<Table> lstTableToGenerate,
            List<Field> lstFieldToGenerate)
        {

            //Copy objects from parameters to properties
            G1Configuration = g1Configuration;
            G1FieldChainer = g1FieldChainer;
            ChosenProject = projectChosen;
            ChosenDatabase = databaseChosen;
            LstTableInFiyiStackDeskAppDB = lstTableInFiyiStackDeskAppDB;
            LstTableToGenerate = lstTableToGenerate;
            LstFieldToGenerate = lstFieldToGenerate;

            InitializeComponent();
        }
    }
}
