using System;
using System.Collections.Generic;
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
        internal DocomaticProject()
        {
            Control = new DoxItemBase();
            AutoTexts = new DoxItemBase();
            Hierarchies = new ClassHierarchyCollection();
            Colors = new DoxItemBase();
            Configurations = new ConfigurationCollection();
            DescriptionIncludeDirectories = new DoxItemBase();
            Dictionary = new DoxItemBase();
            DocumentationAutomatics = new DoxItemBase();
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

        }

        public void Save(string path)
        {

        }

        public DoxItemBase Control { get; set; }
        public DoxItemBase AutoTexts { get; set; }
        public ClassHierarchyCollection Hierarchies { get; set; }
        public DoxItemBase Colors { get; set; }
        public ConfigurationCollection Configurations { get; set; }
        public DoxItemBase DescriptionIncludeDirectories { get; set; }
        public DoxItemBase Dictionary { get; set; }
        public DoxItemBase DocumentationAutomatics { get; set; }
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
