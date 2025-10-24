using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.DataBaseBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.ProjectBack.Entities;
using FiyiStackDeskApp.Areas.System.FailureBack.Interfaces;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.G1ConfigurationBack.Entities;
using FiyiStackDeskApp.Areas.CMS.UserBack.Entities;
using Microsoft.Extensions.DependencyInjection;
using System.ComponentModel;
using System.Text;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.TableBack.Entities;
using FiyiStackDeskApp.Areas.FiyiStackDeskApp.FieldBack.Entities;

namespace FiyiStackDeskApp
{
    public partial class SharedComponent : Component
    {
        #region Properties
        //FOR ALL FORMS
        public Color BlackColorPlus1 = (Color)(new ColorConverter().ConvertFromString("#20262D") ?? Color.Coral);

        //FOR LOGIN FORM
        public User LoggedUser = new();

        //FOR GENERATOR FORM
        public bool WantNewProject = true;
        public bool WantNewDatabase = true;
        public bool WantNewTable = true;
        public bool WantNewField = true;

        public G1Configuration G1Configuration = new();

        public List<Project> lstSavedProjectsInFiyiStackDeskAppDB = [];
        public Project ChosenProject = new();

        public List<DataBase> lstSavedDataBasesInFiyiStackDeskAppDB = [];
        public DataBase ChosenDatabase = new();

        public List<Table> lstTableInFiyiStackDeskAppDB = [];
        public Table ChosenTable = new();

        public List<Field> lstFieldInFiyiStackDeskAppDB = [];
        public Field ChosenField = new();

        public List<Table> lstTableToGenerate = [];
        public List<Field> lstFieldToGenerate = [];
        #endregion

        public SharedComponent()
        {
            InitializeComponent();
        }

        public static G1Configuration LoadDefaultConfiguration()
        {
            G1Configuration Configuration = new()
            {
                G1ConfigurationId = 0,
                ProjectId = 0,
                Active = true,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                UserCreationId = 0,
                UserLastModificationId = 0,

                WantCSharp = true,
                WantMSSQLServer = true,

                DeleteTable = false,
                DeleteField = false,
                DeleteFiles = true,

                WantDTO = true,
                WantEntity = true,
                WantEntityConfiguration = true,
                WantInterfaces = true,
                WantRepository = true,
                WantBlazorPages = true,
                WantService = true
            };
            return Configuration;
        }

        public static void LoadConfiguration(ServiceProvider serviceProvider)
        {
            try
            {
                IG1ConfigurationRepository ConfigurationRepository = serviceProvider.GetRequiredService<IG1ConfigurationRepository>();

                G1Configuration Configuration = ConfigurationRepository.GetByProjectId(Program.SharedComponent.ChosenProject.ProjectId) ?? new();

                if (Configuration.G1ConfigurationId != 0)
                {
                    Program.SharedComponent.G1Configuration.ProjectId = Configuration.ProjectId;

                    Program.SharedComponent.G1Configuration.WantCSharp = Configuration.WantCSharp;
                    Program.SharedComponent.G1Configuration.WantMSSQLServer = Configuration.WantMSSQLServer;

                    Program.SharedComponent.G1Configuration.DeleteTable = Configuration.DeleteTable;
                    Program.SharedComponent.G1Configuration.DeleteField = Configuration.DeleteField;
                    Program.SharedComponent.G1Configuration.DeleteFiles = Configuration.DeleteFiles;

                    //C#
                    //Back-end
                    Program.SharedComponent.G1Configuration.WantDTO = Configuration.WantDTO;
                    Program.SharedComponent.G1Configuration.WantEntity = Configuration.WantEntity;
                    Program.SharedComponent.G1Configuration.WantEntityConfiguration = Configuration.WantEntityConfiguration;
                    Program.SharedComponent.G1Configuration.WantInterfaces = Configuration.WantInterfaces;
                    Program.SharedComponent.G1Configuration.WantRepository = Configuration.WantRepository;
                    Program.SharedComponent.G1Configuration.WantService = Configuration.WantService;
                    //Front-end
                    Program.SharedComponent.G1Configuration.WantBlazorPages = Configuration.WantBlazorPages;
                }
                else
                {
                    throw new Exception("Configuración no encontrada para el proyecto seleccionado.");
                }
            }
            catch (Exception) { throw; }
        }

        public static void CreateFile(string filePath, string content, bool deleteFile)
        {
            try
            {
                if (File.Exists(filePath))
                {
                    //EDIT THE FILE
                    if (deleteFile)
                    {
                        //Take all the information of the file and convert it to a string
                        string ContentOfFile = "";

                        using (FileStream filestream = new(filePath, FileMode.Open, FileAccess.Read))
                        {
                            //Convert the source file into a byte array
                            byte[] byteArray = new byte[filestream.Length];

                            int NumberOfBytesToRead = (int)filestream.Length;

                            int NumberOfBytesRead = 0;

                            while (NumberOfBytesToRead > 0)
                            {
                                //Read may return anything from 0 to NumberOfBytesToRead.
                                int TotalBytesRead = filestream.Read(byteArray, NumberOfBytesRead, NumberOfBytesToRead);
                                if (TotalBytesRead == 0)
                                {
                                    //Break when the end of the file is reached.
                                    break;
                                }

                                NumberOfBytesRead += TotalBytesRead;
                                NumberOfBytesToRead -= TotalBytesRead;
                            }
                            NumberOfBytesToRead = byteArray.Length;

                            ContentOfFile = Encoding.UTF8.GetString(byteArray);
                        }

                        using (FileStream filestream = new(filePath, FileMode.Open, FileAccess.Write))
                        {
                            byte[] arrayByte = new UTF8Encoding(true).GetBytes(content);
                            filestream.Write(arrayByte, 0, arrayByte.Length);
                        }
                    }
                }
                else
                {
                    //CREATE THE FILE
                    using FileStream FileStream = File.Create(filePath);

                    byte[] byteArray = new UTF8Encoding(true).GetBytes(content);

                    FileStream.Write(byteArray, 0, byteArray.Length);
                }
            }
            catch (Exception) { throw; }
        }

        public static void SetClipBoard(string textToClip)
        {
            StringBuilder StringBuilderTextToClip = new(textToClip);

            Clipboard.SetText(StringBuilderTextToClip.ToString());
        }

        public static void AddFailure(Exception ex, ServiceProvider serviceProvider)
        {
            IFailureRepository IFailureRepository = serviceProvider.GetRequiredService<IFailureRepository>();

            Areas.System.FailureBack.Entities.Failure Failure = new()
            {
                Active = true,
                UserCreationId = Program.SharedComponent.LoggedUser.UserId,
                UserLastModificationId = Program.SharedComponent.LoggedUser.UserId,
                DateTimeCreation = DateTime.Now,
                DateTimeLastModification = DateTime.Now,
                Message = ex.Message,
                StackTrace = ex.StackTrace ?? "",
                Source = ex.Source ?? ""
            };

            IFailureRepository.Add(Failure);
        }
    }
}
