using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;

namespace docomaticSharpLib.DOX
{
    /// <summary>
    /// Wrapper around DOX file (doc-o-matic project)
    /// </summary>
    public class DocomaticProject
    {
        public DocomaticProject()
        {
            HeaderComments = new List<string>();
            Control = new DoxItemBase();
            AutoTexts = new DoxItemBase();
            Hierarchies = new ClassHierarchyCollection();
            Colors = new DoxItemBase();
            Configurations = new ConfigurationCollection();
            DescriptionIncludeDirectories = new DoxItemBase();
            Dictionary = new DoxItemBase();
            DocumentationAutomatics = new DoxItemBase();
            ETPSettings = new DoxItemBase();
            EditorOptions = new DoxItemBase();
            ExportSymbols = new DoxItemBase();
            ExternalTopics = new ExternalTopicProperties();
            FileExtensions = new DoxItemBase();
            General = new DoxItemBase();
            GenericSources = new DoxItemBase();
            IgnoredUneditableEncodingFiles = new DoxItemBase();
            MacroHeaderFiles = new DoxItemBase();
            Modules = new DoxItemBase();
            Parsing = new Parsing();
            ProjectDatabaseFiles = new DoxItemBase();
            ProjectFileInfo = new DoxItemBase();
            Sections = new SectionCollection();
            SourceFiles = new DoxItemBase();
            SourceIncludeDirectories = new DoxItemBase();
            TopicReports = new TopicReportCollection();
            Workflows = new WorkflowCollection();
        }

        public void ReadFrom(string path)
        {
            var doxStringLines = File.ReadAllLines(path);

            bool isHeader = true;

            //Первый прогон только для формирования списка DoxItemBase
            DoxItemBase doxBlock = new DoxItemBase();
            bool isDoxBlockStart = false;
            List<DoxItemBase> doxList = new List<DoxItemBase>();
            foreach (string line in doxStringLines)
            {
                if (isHeader && line.StartsWith(";")) HeaderComments.Add(line);
                else isHeader = false;

                if (line.Contains("[") && line.Contains("]"))
                {
                    if (isDoxBlockStart) 
                    {
                        doxList.Add(doxBlock);
                    }
                    string blockName = line.Substring(line.IndexOf("[") + 1, line.IndexOf("]") - line.IndexOf("[") - 1);
                    doxBlock = new DoxItemBase() { NameRaw = blockName };
                    isDoxBlockStart = true;
                }
                else if (isDoxBlockStart && line.Contains("="))
                {
                    string key = line.Substring(0, line.IndexOf("="));
                    string value = line.Substring(line.IndexOf("=") + 1);
                    doxBlock.DataRaw.Add(key, value);
                }
            }

            //Второй прогон -- заполнение структуры класса
            for (int doxBlockCounter = 0; doxBlockCounter < doxList.Count; doxBlockCounter++)
            {
                DoxItemBase currentBlock = doxList[doxBlockCounter];

                if (currentBlock.NameRaw == "*Control*") this.Control = currentBlock;
                else if (currentBlock.NameRaw == "AutoTexts") this.AutoTexts = currentBlock;
                else if (currentBlock.NameRaw == "Class Hierarchy") this.Hierarchies.SetRawFrom(currentBlock);
                else if (currentBlock.NameRaw.StartsWith("Class Hierarchy"))
                {
                    int hierIndex = ParseNum(currentBlock.NameRaw);

                    if (!this.Hierarchies.ClassHierarchies.Where(c => c.Key == hierIndex).Any())
                    {
                        this.Hierarchies.ClassHierarchies.Add(hierIndex, new ClassHierarchy() { Index = hierIndex });
                        this.Hierarchies.ClassHierarchies[hierIndex].SetRawFrom(currentBlock);
                    }
                    else
                    {
                        this.Hierarchies.ClassHierarchies[hierIndex].Items.Add(currentBlock);
                    }
                }
                else if (currentBlock.NameRaw == "Colors") this.Colors = currentBlock;
                else if (currentBlock.NameRaw == "Configurations") this.Configurations.SetRawFrom(currentBlock);
                else if (currentBlock.NameRaw.StartsWith("Configurations"))
                {
                    string confName = ParseName(currentBlock.NameRaw);

                    if (!this.Configurations.Configurations.Where(c => c.Key == confName).Any())
                    {
                        this.Configurations.Configurations.Add(confName, new Configuration() { Name = confName });
                        this.Configurations.Configurations[confName].SetRawFrom(currentBlock);
                    }
                    else
                    {
                        this.Configurations.Configurations[confName].Items.Add(currentBlock);
                    }
                }
                else if (currentBlock.NameRaw == "Description Include Directories") this.DescriptionIncludeDirectories = currentBlock;
                else if (currentBlock.NameRaw == "Dictionary") this.Dictionary = currentBlock;
                else if (currentBlock.NameRaw == "Documentation Automatics") this.DocumentationAutomatics = currentBlock;
                else if (currentBlock.NameRaw == "ETP Settings") this.ETPSettings = currentBlock;
                else if (currentBlock.NameRaw == "Editor Options") this.EditorOptions = currentBlock;
                else if (currentBlock.NameRaw == "Export Symbols") this.ExportSymbols = currentBlock;
                else if (currentBlock.NameRaw == "External Topic Properties")
                {
                    this.ExternalTopics.SetRawFrom(currentBlock);
                    this.ExternalTopics.Initialize();
                }
                else if (currentBlock.NameRaw.StartsWith("External Topic Properties"))
                {
                    string topicName = ParseName(currentBlock.NameRaw);

                    if (!this.ExternalTopics.Topics.Where(c => c.Key == topicName).Any())
                    {
                        this.ExternalTopics.Topics.Add(topicName, new ExternalTopic() { TopicId = topicName });
                        this.ExternalTopics.Topics[topicName].SetRawFrom(currentBlock);
                        this.ExternalTopics.Topics[topicName].Initialize();
                    }
                    //здесь наследования свойств нет -- только один уровень вложенности
                }
                else if (currentBlock.NameRaw == "File Extensions") this.FileExtensions = currentBlock;
                else if (currentBlock.NameRaw == "General") this.General = currentBlock;
                else if (currentBlock.NameRaw == "Generic Sources") this.GenericSources = currentBlock;
                else if (currentBlock.NameRaw == "Ignored Uneditable Encoding Files") this.IgnoredUneditableEncodingFiles = currentBlock;
                else if (currentBlock.NameRaw == "Macro Header Files") this.MacroHeaderFiles = currentBlock;
                else if (currentBlock.NameRaw == "Modules") this.Modules = currentBlock;
                else if (currentBlock.NameRaw == "Parsing") this.Parsing.SetRawFrom(currentBlock);
                else if (currentBlock.NameRaw.StartsWith("Parsing"))
                {
                    string confName = ParseName(currentBlock.NameRaw);

                    if (confName == "ConditionalDefines") this.Parsing.ConditionalDefines = currentBlock;
                    else if (confName == "Excluded Source Files") this.Parsing.ExcludedSourceFiles = currentBlock;
                }
                else if (currentBlock.NameRaw == "Project Database Files") this.ProjectDatabaseFiles = currentBlock;
                else if (currentBlock.NameRaw == "Project File Info") this.ProjectFileInfo = currentBlock;
                else if (currentBlock.NameRaw.StartsWith("Section"))
                {
                    if (currentBlock.NameRaw == "Sections") this.Sections.SetRawFrom(currentBlock);
                    else
                    {
                        string sectionName = ParseName(currentBlock.NameRaw);
                        this.Sections.Sections.Add(currentBlock);
                    }
                }
                else if (currentBlock.NameRaw == "Source Files") this.SourceFiles = currentBlock;
                else if (currentBlock.NameRaw == "Source Include Directories") this.SourceIncludeDirectories = currentBlock;
                else if (currentBlock.NameRaw == "Topic Reports") this.TopicReports.SetRawFrom(currentBlock);
                else if (currentBlock.NameRaw.StartsWith("Topic Reports"))
                {
                    int topicReportIndex = ParseNum(currentBlock.NameRaw);

                    if (!this.TopicReports.TopicReports.Where(c => c.Key == topicReportIndex).Any())
                    {
                        this.TopicReports.TopicReports.Add(topicReportIndex, new TopicReport());
                        this.TopicReports.TopicReports[topicReportIndex].SetRawFrom(currentBlock);
                    }
                    else this.TopicReports.TopicReports[topicReportIndex].Items.Add(currentBlock);
                }
                else if (currentBlock.NameRaw.StartsWith("Workflows"))
                {
                    this.Workflows.Workflows.Add(currentBlock);
                }
            }
        }

        public void Save(string path)
        {
            StringBuilder doxFile = new StringBuilder();
            doxFile.AppendLine(string.Join(Environment.NewLine, this.HeaderComments));
            doxFile.AppendLine(this.Control.ToDoxString());
            doxFile.AppendLine(this.AutoTexts.ToDoxString());
            doxFile.AppendLine(this.Hierarchies.ToDoxString());
            doxFile.AppendLine(this.Colors.ToDoxString());
            doxFile.AppendLine(this.Configurations.ToDoxString());
            doxFile.AppendLine(this.DescriptionIncludeDirectories.ToDoxString());
            doxFile.AppendLine(this.Dictionary.ToDoxString());
            doxFile.AppendLine(this.DocumentationAutomatics.ToDoxString());
            doxFile.AppendLine(this.ETPSettings.ToDoxString());
            doxFile.AppendLine(this.EditorOptions.ToDoxString());
            doxFile.AppendLine(this.ExportSymbols.ToDoxString());
            doxFile.AppendLine(this.ExternalTopics.ToDoxString());

            doxFile.AppendLine(this.FileExtensions.ToDoxString());
            doxFile.AppendLine(this.General.ToDoxString());
            doxFile.AppendLine(this.GenericSources.ToDoxString());
            doxFile.AppendLine(this.IgnoredUneditableEncodingFiles.ToDoxString());
            doxFile.AppendLine(this.MacroHeaderFiles.ToDoxString());
            doxFile.AppendLine(this.Modules.ToDoxString());

            doxFile.AppendLine(this.Parsing.ToDoxString());
            doxFile.AppendLine(this.ProjectDatabaseFiles.ToDoxString());
            doxFile.AppendLine(this.ProjectFileInfo.ToDoxString());
            doxFile.AppendLine(this.Sections.ToDoxString());

            doxFile.AppendLine(this.SourceFiles.ToDoxString());
            doxFile.AppendLine(this.SourceIncludeDirectories.ToDoxString());
            doxFile.AppendLine(this.TopicReports.ToDoxString());
            doxFile.AppendLine(this.Workflows.ToDoxString());
            

            //File.WriteAllText(path, doxFile.ToString());

            using (StreamWriter writer = new StreamWriter(path, false, new UTF8Encoding(true)))
            {
                writer.WriteLine(doxFile.ToString());
            }
        }

        private string ParseName(string line)
        {
            string hierNameRaw = line.Substring(line.IndexOf("\\") + 1);
            if (hierNameRaw.Contains("\\")) hierNameRaw = hierNameRaw.Substring(0, hierNameRaw.IndexOf("\\"));
            return hierNameRaw;
        }
        private int ParseNum(string line)
        {
            string hierNameRaw = ParseName(line);
            return Convert.ToInt32(hierNameRaw);
        }



        public List<string> HeaderComments = new List<string>();  
        public DoxItemBase Control { get; set; }
        public DoxItemBase AutoTexts { get; set; }
        public ClassHierarchyCollection Hierarchies { get; set; }
        public DoxItemBase Colors { get; set; }
        public ConfigurationCollection Configurations { get; set; }
        public DoxItemBase DescriptionIncludeDirectories { get; set; }
        public DoxItemBase Dictionary { get; set; }
        public DoxItemBase DocumentationAutomatics { get; set; }
        public DoxItemBase ETPSettings { get; set; }
        public DoxItemBase EditorOptions { get; set; }
        public DoxItemBase ExportSymbols { get; set; }
        public ExternalTopicProperties ExternalTopics { get; set; }
        public DoxItemBase FileExtensions { get; set; }
        public DoxItemBase General { get; set; }
        public DoxItemBase GenericSources { get; set; }
        public DoxItemBase IgnoredUneditableEncodingFiles { get; set; }
        public DoxItemBase MacroHeaderFiles { get; set; }
        public DoxItemBase Modules { get; set; }
        public Parsing Parsing { get; set; }
        public DoxItemBase ProjectDatabaseFiles { get; set; }
        public DoxItemBase ProjectFileInfo { get; set; }
        public SectionCollection Sections { get; set; }
        public DoxItemBase SourceFiles { get; set; }
        public DoxItemBase SourceIncludeDirectories { get; set; }
        public TopicReportCollection TopicReports { get; set; }
        public WorkflowCollection Workflows { get; set; }
    }
}
