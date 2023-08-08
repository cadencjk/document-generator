using DocumentGenerator.Model;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Wordprocessing;
using log4net;
using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using System.Xml;

namespace DocumentGenerator
{
    public partial class DocumentGeneratorForm : Form
    {
        #region Variables
        private int noOfWordFiles;
        private static readonly ILog log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        private string fileName;
        private bool isError;
        private string templateFileToBeUsed;
        private int index;
        private string newTemplatePath;
        private string templateFile;
        private int updateValue;
        private FolderBrowserDialog fbd;
        private OpenFileDialog fdlg;
        private ConcurrentDictionary<string, string> propertyPlaceholder;
        private Dictionary<string, TreeNode> paragraphToNodeCache = new Dictionary<string, TreeNode>();
        private IList<FilePath> fpList;
        private List<Panel> panels = new List<Panel>();
        private Stack<Panel> previousPanels = new Stack<Panel>();
        private List<string> temporaryFiles = new List<string>();

        // Give a default value for placeholders but can be customised in xml configuration
        private char openingPlaceHolder = '{';
        private char closingPlaceHolder = '}';
        private char configOpeningPlaceHolder;
        private char configClosingPlaceHolder;
        #endregion

        #region Constructor
        public DocumentGeneratorForm()
        {
            try
            {
                log.Info(string.Format("DocumentGeneratorForm - START"));
                InitializeComponent();
                ReadProjectConfig();
                this.fbd = new System.Windows.Forms.FolderBrowserDialog();
                this.fdlg = new System.Windows.Forms.OpenFileDialog();
#if DEBUG
                tbInput.Text = @"C:\...";// ConfigurationSettings.AppSettings["DefaultInputPath"];
                tbOutput.Text = @"C:\...";// ConfigurationSettings.AppSettings["DefaultOutputPath"];
                tbTemplate.Text = @"C:\...";
#endif

                log.Info(string.Format("DocumentGeneratorForm - DefaultTemplatePath:{0}", tbTemplate.Text));
                log.Info(string.Format("DocumentGeneratorForm - END"));
                isError = false;
            }
            catch(Exception ex)
            {
                log.Error(string.Format("DocumentGeneratorForm - {0}", ex.Message));
                isError = true;
            }
        }
        #endregion

        #region Buttons

        private void btnOpenInput_Click(object sender, EventArgs e)
        {
            log.Info(string.Format("btnOpenInput_Click - START"));

            try
            {
                fbd.SelectedPath = tbInput.Text;
                ShowFolderDialog(((System.Windows.Forms.Button)sender).Name);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnOpenInput_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("btnOpenInput_Click - END"));
        }

        private void btnOpenOutput_Click(object sender, EventArgs e)
        {
            log.Info(string.Format("btnOpenOutput_Click - START"));
            try
            {
                fbd.SelectedPath = tbOutput.Text;
                ShowFolderDialog(((System.Windows.Forms.Button)sender).Name);
                isError = false;
            }
            catch(Exception ex)
            {
                log.Error(string.Format("btnOpenOutput_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("btnOpenOutput_Click - END"));
        }

        private void btnOpenTemplate_Click(object sender, EventArgs e)
        {
            log.Info(string.Format("btnOpenTemplate_Click - START"));
            try
            {
                fdlg.FileName = tbInput.Text;
                fdlg.Filter = "Word File (.docx ,.doc)|*.docx;*.doc";
                DialogResult result = fdlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    tbTemplate.Text = fdlg.FileName;
                }


                isError = false;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("DocumentGeneratorForm - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("btnOpenInput_Click - END"));
        }

        private void btnSelectSections_Click(object sender, EventArgs e)
        {
            log.Info(string.Format("btnSelectSections_Click - START"));
            try
            {
                isError = false;

                bool isValid = Validation();
                log.Info(string.Format("btnSelectSections_Click - isValid:{0}", isValid));

                if (radioButtonInsertSections.Checked)
                {

                    if (isValid)
                    {
                        GetAllSections();
                        log.Info(string.Format("btnSelectSections_Click - Completed!"));
                        DialogResult d;
                        if (isError)
                        {
                            d = ShowErrorDialog("There is an error, please check the logs!");
                        }
                        progressBar.Value = 0;
                        progressBar.Update();
                        btnGenerateFile.Enabled = true;
                        tbInput.BackColor = System.Drawing.Color.LightGreen;
                        tbOutput.BackColor = System.Drawing.Color.LightGreen;
                    }
                } 
                else
                {
                    if (isValid)
                    {
                        GetAllSections();
                        log.Info(string.Format("btnSelectSections_Click - Completed!"));
                        DialogResult d;
                        if (isError)
                        {
                            d = ShowErrorDialog("There is an error, please check the logs!");
                        }
                        progressBar.Value = 0;
                        progressBar.Update();
                        btnGenerateFile.Enabled = true;
                        tbOutput.BackColor = System.Drawing.Color.LightGreen;

                    }
                }

                isError = false;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnSelectSections_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("btnSelectSections_Click - END"));
        }

        private void btnGenerateFile_Click(object sender, EventArgs e)
        {
            log.Info("GenereateFileBtn_Click - START");
            try
            {

                progressBar.Value = 0;
                List<string> checkedFiles = CheckedFiles();

                updateValue = checkedFiles.Count() > 0 ? (100 / checkedFiles.Count()) : 0;
                int counter = 0;

                // Iterate each file and check if any of their sections should be exported
                foreach (string fileName in checkedFiles)
                {

                    if (radioButtonInsertSections.Checked)
                    {
                        string inputFile = tbInput.Text + "\\" + fileName;
                        string dateTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss");
                        string outputFile = tbOutput.Text + "\\" + dateTime + fileName;


                        string tempFile = CreateFilteredDocument(inputFile, fileName);

                        counter++;
                        progressBar.Value = updateValue * counter;

                        File.Delete(outputFile);
                        File.Copy(templateFile, outputFile);


                        using (WordprocessingDocument myDoc =
                        WordprocessingDocument.Open(outputFile, true))
                        {
                            string altChunkId = "AltChunkId1";
                            MainDocumentPart mainPart = myDoc.MainDocumentPart;
                            AlternativeFormatImportPart chunk =
                                mainPart.AddAlternativeFormatImportPart(
                                AlternativeFormatImportPartType.WordprocessingML, altChunkId);
                            using (FileStream fileStream = File.Open(tempFile, FileMode.Open))
                                chunk.FeedData(fileStream);
                            AltChunk altChunk = new AltChunk();
                            altChunk.Id = altChunkId;
                            mainPart.Document
                                .Body
                                .InsertAfter(altChunk, mainPart.Document.Body
                                .Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>().Last());
                            mainPart.DocumentSettingsPart.Settings.Append(new UpdateFieldsOnOpen() { Val = true });
                            mainPart.Document.Save();
                        }
                        isError = false;


                        File.Delete(tempFile);
                    }
                    else
                    {
                        FilterCurrentFile();
                    }


                }

                progressBar.Value = 100;
                ShowInfoDialog("Completed!");
                progressBar.Value = 0;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnGenerateFile_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("btnGenerateFile_Click - END");

        }

        private void btnNextFirstPanel_Click(object sender, EventArgs e)
        {
            log.Info("btnNextFirstPanel_Click - START");
            try
            {

                if (radioButtonNewTemplate.Checked)
                {
                    // New template has '{' and '}' placeholders bracelets. Should not be changed. 
                    openingPlaceHolder = '{';
                    closingPlaceHolder = '}';
                    GetAllPlaceholdersFromADocument(newTemplatePath);
                    templateFileToBeUsed = newTemplatePath;
                    if (!isError)
                    {
                        panel3.BringToFront();
                    }
                }
                else
                {
                    string strError = "";

                    // Opening and closing placeholders are read from config file
                    openingPlaceHolder = configOpeningPlaceHolder;
                    closingPlaceHolder = configClosingPlaceHolder;

                    try
                    {
                        if (String.IsNullOrEmpty(tbTemplate.Text))
                        {
                            tbTemplate.BackColor = System.Drawing.Color.IndianRed;
                            strError += "Template File is EMPTY!\n";
                        }
                        else if (!File.Exists(tbTemplate.Text))
                        {
                            tbTemplate.BackColor = System.Drawing.Color.IndianRed;
                            strError += "Template File does not EXIST!";
                        }
                        isError = false;
                    }
                    catch (Exception ex)
                    {
                        isError = true;
                        strError += ex.Message;
                    }

                    if (!String.IsNullOrEmpty(strError))
                    {
                        ShowErrorDialog(strError);
                        isError = true;
                    }
                    else
                    {
                        tbTemplate.BackColor = System.Drawing.Color.LightGreen;
                        GetAllPlaceholdersFromADocument(tbTemplate.Text);
                        if (!isError)
                        {
                            if (TemplateHasPlaceHolders())
                            {
                                // Go to placeholder panel
                                templateFileToBeUsed = tbTemplate.Text;
                                panel3.BringToFront();
                            }
                            else
                            {
                                // Skip straight to Section Selection Panel
                                templateFile = tbTemplate.Text;
                                panel2.BringToFront();
                            }
                        }


                    }
                }
                if (!isError)
                {
                    log.Info("btnNextFirstPanel_Click - ERROR");
                    previousPanels.Push(panel1);
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnNextFirstPanel_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("btnNextFirstPanel_Click - END");
        }

        private void btnSaveTemplate_Click(object sender, EventArgs e)
        {
            try
            {

                SaveFileDialog sf = new SaveFileDialog();
                sf.Filter = "XML File (.xml)|*.xml;";

                if (sf.ShowDialog() == DialogResult.OK)
                {
                    tbSaveTemplate.Text = sf.FileName;
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnSaveTemplate_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void buttonNextSecondPanel_Click(object sender, EventArgs e)
        {
            log.Info("buttonNextSecondPanel_Click - START");
            try
            {

                // Create file name for temporary template file
                string newTemporaryTemplate = Path.GetDirectoryName(templateFileToBeUsed) + "\\temp_" + Path.GetFileName(templateFileToBeUsed);
                temporaryFiles.Add(newTemporaryTemplate);
                File.Delete(newTemporaryTemplate);
                File.Copy(templateFileToBeUsed, newTemporaryTemplate, true);

                // Check if any of the placeholder values is empty
                bool hasEmptyPlaceHolders = HasEmptyPlaceHolders();

                if (hasEmptyPlaceHolders)
                {
                    ShowErrorDialog("Please make sure all placeholders are filled.");
                    return;
                }

                // Load data in the table back to dictionary
                LoadBackToDictionary();

                string errorMsg = "";

                // Perform steps to save the placeholder values to xml
                if (checkBoxSaveTemplate.Checked)
                {
                    if (!String.IsNullOrEmpty(tbSaveTemplate.Text) && Directory.Exists(Path.GetDirectoryName(tbSaveTemplate.Text)) &&
                        Path.GetExtension(tbSaveTemplate.Text) == ".xml")
                    {
                        DocumentGeneratorXml DocumentGeneratorXml = GenerateXmlContent();
                        XmlHelper.ToXmlFile(DocumentGeneratorXml, tbSaveTemplate.Text);
                        tbSaveTemplate.BackColor = System.Drawing.Color.LightGreen;
                    }
                    else
                    {
                        tbSaveTemplate.BackColor = System.Drawing.Color.IndianRed;
                        errorMsg += "Destination is not set correctly!";
                    }
                }

                // Replace all placeholders with the user defined values
                ReplacePlaceHolder(newTemporaryTemplate);

                templateFile = newTemporaryTemplate;

                if (String.IsNullOrEmpty(errorMsg) && !isError)
                {
                    panel2.BringToFront();
                    previousPanels.Push(panel3);
                }
                else
                {
                    isError = true;
                    ShowErrorDialog(errorMsg);
                    log.Error(string.Format("buttonNextSecondPanel_Click - {0}", errorMsg));
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("buttonNextSecondPanel_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("buttonNextSecondPanel_Click - END");
        }

        private void btnBackThirdPanel_Click(object sender, EventArgs e)
        {
            try
            {

                // Clear all sections from the read documents, in the event if the user changes the template document
                sectionsView.Nodes.Clear();
                btnGenerateFile.Enabled = false;
                btnBack_Click(sender, e);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnBackThirdPanel_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            log.Info("btnBack_Click - START");
            try
            {

                Panel previousPanel = previousPanels.Pop();
                previousPanel.BringToFront();
            }
            catch (Exception ex)
            {
                log.Error(string.Format("btnBack_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("btnBack_Click - END");
        }

        private void buttonRestorePlaceholders_Click(object sender, EventArgs e)
        {
            try
            {

                fdlg.Filter = "XML File (.xml)|*.xml";
                DialogResult result = fdlg.ShowDialog();
                if (result == DialogResult.OK)
                {
                    LoadFromXml(fdlg.FileName);
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("buttonRestorePlaceholders_Click - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        #endregion

        #region Dialogs

        private void ShowFolderDialog(string buttonName)
        {
            log.Info(string.Format("ShowFolderDialog - START"));
            try
            {
                switch (buttonName)
                {
                    case Constants.ButtonOpenInput:
                        fbd.SelectedPath = tbInput.Text ;
                        break;
                    case Constants.ButtonOpenOutput:
                        fbd.SelectedPath = tbOutput.Text;
                        break;
                    default:
                        break;
                }

                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK)
                {
                    switch (buttonName)
                    {
                        case Constants.ButtonOpenInput:
                            tbInput.Text = fbd.SelectedPath;
                            break;
                        case Constants.ButtonOpenOutput:
                            tbOutput.Text = fbd.SelectedPath;
                            break;
                        default:
                            break;
                    }

                    Environment.SpecialFolder root = folderBrowserDialog.RootFolder;
                }
                isError = false;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("ShowFolderDialog - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("ShowFolderDialog - END"));
        }
        private DialogResult ShowErrorDialog(string errorMessage)
        {
            DialogResult d;
            try
            {
                log.Info(string.Format("ShowErrorDialog - START"));
                d = MessageBox.Show(errorMessage, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Info(string.Format("ShowErrorDialog - END"));
                return d;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("ShowErrorDialog - {0}", ex.Message));
                isError = true;
            }
            return DialogResult.Cancel;
        }
        private DialogResult ShowInfoDialog(string infoMessage)
        {
            DialogResult d;
            try
            {
                log.Info(string.Format("ShowInfoDialog - START"));
                
                d = MessageBox.Show(infoMessage, "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                log.Info(string.Format("ShowInfoDialog - END"));
                return d;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("ShowInfoDialog - {0}", ex.Message));
                isError = true;
            }
            return DialogResult.Cancel;
        }
        #endregion

        #region Helpers
        private bool Validation()
        {
            log.Info(string.Format("Validation - START"));
            bool isValid = true;
            try
            {
                progressBar.Value = 0;
                progressBar.Update();
                noOfWordFiles = 0;

                isValid = true;
                string strError = "";
                strError += PathIsValid();
                if (!string.IsNullOrEmpty(strError))
                {
                    ShowErrorDialog(strError);
                    return false;
                }

                noOfWordFiles = NoOfInputWordFile().Count();
                strError += CheckNoOfWord(noOfWordFiles);
                if (!string.IsNullOrEmpty(strError))
                {
                    ShowErrorDialog(strError);
                    isValid = false;
                }

                log.Info(string.Format("Validation - isValid:{0}", isValid));
                isError = false;

                if (radioButtonInsertSections.Checked)
                {
                    tbTemplate.BackColor = System.Drawing.Color.LightGreen;
                    tbInput.BackColor = System.Drawing.Color.LightGreen;
                    tbOutput.BackColor = System.Drawing.Color.LightGreen;
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("Validation - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }

            log.Info(string.Format("Validation - END"));
            return isValid;
        }

        private string PathIsValid()
        {
            log.Info(string.Format("PathIsValid - START"));
            string strError = "";
            try
            {

                if (!radioButtonNewTemplate.Checked)
                {
                    if (String.IsNullOrEmpty(tbTemplate.Text))
                    {
                        tbTemplate.BackColor = System.Drawing.Color.IndianRed;
                        strError += "Template File is EMPTY!\n";
                    }
                    else if (!File.Exists(tbTemplate.Text))
                    {
                        tbTemplate.BackColor = System.Drawing.Color.IndianRed;
                        strError += "Template File does not EXIST!";
                    }
                }

                if (radioButtonInsertSections.Checked)
                {

                    if (String.IsNullOrEmpty(tbInput.Text))
                    {
                        tbInput.BackColor = System.Drawing.Color.IndianRed;
                        strError += "Document Path is EMPTY!\n";
                    }
                    else if (!Directory.Exists(tbInput.Text))
                    {
                        tbInput.BackColor = System.Drawing.Color.IndianRed;
                        strError += string.Format("Directory does NOT Exist! ({0})\n", tbInput.Text);
                    }
                } else
                {
                    if (!File.Exists(templateFile))
                    {
                        strError += "Template file does not exist!";
                    }
                }
 

                if (String.IsNullOrEmpty(tbOutput.Text))
                {
                    tbOutput.BackColor = System.Drawing.Color.IndianRed;
                    strError += "Output Path is EMPTY!\n";
                }
                else if (!Directory.Exists(tbOutput.Text))
                {
                    tbOutput.BackColor = System.Drawing.Color.IndianRed;
                    strError += string.Format("Directory does NOT Exist! ({0})\n", tbInput.Text);
                } else
                {
                    log.Info(string.Format("PathIsValid - {0}", strError));
                    isError = false;

                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("PathIsValid - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("PathIsValid - END"));
            return strError;
        }

        private IList<FilePath> NoOfInputWordFile()
        {
            log.Info(string.Format("NoOfInputWordFile - START"));
            try
            {
                fpList = new List<FilePath>();

                if (radioButtonInsertSections.Checked)
                {
                    string[] fileEntries = Directory.GetFiles(tbInput.Text);
                    foreach (string filePath in fileEntries)
                    {
                        string fileName = Path.GetFileName(filePath).ToLower();
                        //Avoid temporary/hidden files
                        if (fileName.Contains("~$"))
                            continue;

                        string extenstion = Path.GetExtension(fileName).ToLower();
                        if (extenstion == ".docx" || extenstion == ".doc")
                        {
                            FilePath fp = new FilePath();
                            fp.Path = filePath;
                            fp.FileName = fileName;

                            int nIndex = fileName.IndexOf("-");
                            if (nIndex != -1)
                            {
                                fp.UserName = fileName.Substring(0, nIndex);
                            }
                            fpList.Add(fp);

                            ListViewItem lvi = new ListViewItem(fileName);
                            lvi.SubItems.Add(fileName);

                        }
                    }
                } else
                {
                    FilePath file = new FilePath();
                    file.Path = templateFile; 
                    file.FileName = Path.GetFileName(templateFile).ToLower();
                    fpList.Add(file);
                }
                
                log.Info(string.Format("NoOfInputWordFile - fpList.Count():{0}", fpList.Count()));
                isError = false;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("NoOfInputWordFile - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("NoOfInputWordFile - END"));
            return fpList;
        }

        private string CheckNoOfWord(int numberOfWordFiles)
        {

            log.Info(string.Format("CheckNoOfWord - START"));
            string strError = "";
            try
            {
                
                if (numberOfWordFiles == 0)
                    strError = "No Word file found!";

                isError = false;
            }
            catch (Exception ex)
            {
                log.Error(string.Format("CheckNoOfWord - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info(string.Format("CheckNoOfWord - END"));

            return strError;
        }

        private bool IsHeadingStyle(DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph)
        {
            bool isHeading = false;
            try
            {
                // Check if the paragraph has a heading style
                isHeading = paragraph.ParagraphProperties != null &&
                       paragraph.ParagraphProperties.ParagraphStyleId != null &&
                       paragraph.ParagraphProperties.ParagraphStyleId.Val.HasValue &&
                       paragraph.ParagraphProperties.ParagraphStyleId.Val.Value.StartsWith("Heading", StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                log.Error(string.Format("IsHeadingStyle - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            return isHeading;
        }

        private int GetHeadingLevel(DocumentFormat.OpenXml.Wordprocessing.Paragraph paragraph)
        {
            int level = 0;
            try
            {
                // Get the level of the heading
                string styleId = paragraph.ParagraphProperties.ParagraphStyleId.Val.Value;
                level = int.Parse(styleId.Substring(7));

            }
            catch (Exception ex)
            {
                log.Error(string.Format("GetHeadingLevel - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            return level;
        }

        private void GetAllSections()
        {
            log.Info("GetAllSections - START");

            sectionsView.Nodes.Clear();
            if (fpList != null && fpList.Count != 0)
            {
                foreach (FilePath fp in fpList)
                {
                    PopulateTreeView(fp);
                }

            }

            log.Info("GetAllSections - END");
        }

        public List<string> CheckedFiles()
        {
            log.Info("CheckedFiles - START");
            List<string> checkedFiles = new List<string>();
            try
            {
                // Get all file names that are checked
                foreach (TreeNode treeNode in sectionsView.Nodes)
                {
                    if (treeNode.Checked)
                    {
                        checkedFiles.Add(treeNode.Text);
                    }
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("CheckedFiles - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("CheckedFiles - END");
            return checkedFiles;
        }

        private string CreateFilteredDocument(string inputFile, string fileName)
        {
            log.Info("CreateFilteredDocument - START");
            string outputFile = tbOutput.Text + "\\" + "temp_" + fileName;

            try
            {
                temporaryFiles.Add(outputFile);
                File.Delete(outputFile);
                File.Copy(inputFile, outputFile);

                List<OpenXmlElement> toBeDeleted = new List<OpenXmlElement>();
                using (WordprocessingDocument document = WordprocessingDocument.Open(outputFile, true))
                {
                    // Get the main part of the document
                    MainDocumentPart mainPart = document.MainDocumentPart;

                    // Get all the paragraphs with heading styles
                    var paragraphs = mainPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();

                    bool toDelete = true;

                    IEnumerable<OpenXmlElement> elems = mainPart.Document.Body.Descendants().ToList();
                    foreach (OpenXmlElement elem in elems)
                    {
                        if (elem is DocumentFormat.OpenXml.Wordprocessing.Paragraph)
                        {
                            if (IsHeadingStyle((DocumentFormat.OpenXml.Wordprocessing.Paragraph)elem))
                            {

                                if (paragraphToNodeCache.ContainsKey(((DocumentFormat.OpenXml.Wordprocessing.Paragraph)elem).ParagraphId))
                                {

                                    toDelete = !paragraphToNodeCache[((DocumentFormat.OpenXml.Wordprocessing.Paragraph)elem).ParagraphId].Checked;
                                }
                                else
                                {
                                    toDelete = true;
                                }
                            }
                        }
                        if (toDelete)
                        {
                            toBeDeleted.Add(elem);
                        }
                    }

                    for (int i = toBeDeleted.Count - 1; i >= 0; i--)
                    {
                        OpenXmlElement p = toBeDeleted[i];
                        p.RemoveAllChildren();
                        p.Remove();
                    }

                    if (mainPart.HeaderParts.Count() > 0 ||
                    mainPart.FooterParts.Count() > 0)
                    {
                        // Remove the header and footer parts.
                        mainPart.DeleteParts(mainPart.HeaderParts);
                        mainPart.DeleteParts(mainPart.FooterParts);

                        // Get a reference to the root element of the main
                        // document part.
                        DocumentFormat.OpenXml.Wordprocessing.Document documentHeaderFooter = mainPart.Document;

                        // Remove all references to the headers and footers.

                        // First, create a list of all descendants of type
                        // HeaderReference. Then, navigate the list and call
                        // Remove on each item to delete the reference.
                        var headers =
                          documentHeaderFooter.Descendants<HeaderReference>().ToList();
                        foreach (var header in headers)
                        {
                            header.Remove();
                        }

                        // First, create a list of all descendants of type
                        // FooterReference. Then, navigate the list and call
                        // Remove on each item to delete the reference.
                        var footers =
                          documentHeaderFooter.Descendants<FooterReference>().ToList();
                        foreach (var footer in footers)
                        {
                            footer.Remove();
                        }

                        // Save the changes.
                        document.Save();
                    }
                }

                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                ShowErrorDialog(ex.Message);
                log.Error(string.Format("CreatedFilteredDocument - {0}", ex.Message));
            }
            log.Info("CreateFilteredDocument - END");
            return outputFile;
        }

        private string FilterCurrentFile()
        {
            log.Info("FilterCurrentFile - START");
            string outputFile = "";
            try
            {
                string dateTime = DateTime.Now.ToString("yyyy-dd-M--HH-mm-ss--");

                if (radioButtonExistingTemplate.Checked)
                {
                    outputFile = tbOutput.Text + "\\" + dateTime + Path.GetFileName(tbTemplate.Text);
                }
                else
                {
                    outputFile = tbOutput.Text + "\\" + dateTime + fileName;
                }

                File.Delete(outputFile);
                File.Copy(templateFile, outputFile);

                progressBar.Value += (int)(updateValue * 0.2);

                //List<DocumentFormat.OpenXml.Wordprocessing.Paragraph> toBeDeleted = new List<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();

                List<OpenXmlElement> toBeDeleted = new List<OpenXmlElement>();

                using (WordprocessingDocument document = WordprocessingDocument.Open(outputFile, true))
                {
                    // Get the main part of the document
                    MainDocumentPart mainPart = document.MainDocumentPart;

                    // Get all the paragraphs with heading styles
                    var paragraphs = mainPart.Document.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();

                    bool toDelete = false;

                    IEnumerable<OpenXmlElement> elems = mainPart.Document.Body.Descendants().ToList();


                    foreach (OpenXmlElement elem in elems)
                    {
                        // White list footers, headers and properties from being deleted
                        if (elem is FooterReference || elem is HeaderReference || elem is SectionProperties)
                        {
                            continue;
                        }

                        if (elem is DocumentFormat.OpenXml.Wordprocessing.Paragraph)
                        {
                            if (IsHeadingStyle((DocumentFormat.OpenXml.Wordprocessing.Paragraph)elem))
                            {

                                if (paragraphToNodeCache.ContainsKey(((DocumentFormat.OpenXml.Wordprocessing.Paragraph)elem).ParagraphId))
                                {
                                    toDelete = !paragraphToNodeCache[((DocumentFormat.OpenXml.Wordprocessing.Paragraph)elem).ParagraphId].Checked;
                                }
                                else
                                {
                                    toDelete = true;
                                }
                            }
                        }
                        if (toDelete)
                        {
                            toBeDeleted.Add(elem);
                        }
                    }

                    progressBar.Value += (int)(updateValue * 0.4);

                    for (int i = toBeDeleted.Count - 1; i >= 0; i--)
                    {
                        OpenXmlElement p = toBeDeleted[i];
                        p.RemoveAllChildren();
                        p.Remove();
                    }

                    progressBar.Value += (int)(updateValue * 0.4);
                }
                isError = false;


            }
            catch (Exception ex)
            {
                log.Error(string.Format("FilterCurrentFile - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }

            log.Info("FilterCurrentFile - END");
            return outputFile;
        }

        public void FindAllPlaceHoldersInAText(string text)
        {
            try
            {
                var seperatedText = text.Split(openingPlaceHolder, closingPlaceHolder);

                if (seperatedText.Length < 3)
                {
                    return;
                }

                for (int i = 1; i < seperatedText.Length; i += 2)
                {
                    propertyPlaceholder[seperatedText[i]] = "";
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("FindAllPlaceHoldersInAText - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void GetAllPlaceholdersFromADocument(string templatePath)
        {
            log.Info("GetAllPlaceholdersFromADocument - START");
            try
            {
                dataGridView1.Rows.Clear();
                propertyPlaceholder = new ConcurrentDictionary<string, string>();
                using (WordprocessingDocument doc = WordprocessingDocument.Open(templatePath, true))
                {
                    MainDocumentPart mainPart = doc.MainDocumentPart;

                    IEnumerable<HeaderPart> headers = mainPart.HeaderParts.ToList();

                    foreach (HeaderPart headerPart in headers)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.Header header = headerPart.Header;
                        FindAllPlaceHoldersInAText(header.InnerText);
                    }

                    IEnumerable<FooterPart> footers = mainPart.FooterParts.ToList();

                    foreach (FooterPart footerPart in footers)
                    {
                        Footer footer = footerPart.Footer;
                        FindAllPlaceHoldersInAText(footer.InnerText);
                    }

                    IEnumerable<OpenXmlElement> elems = mainPart.Document.Body.Descendants().ToList();
                    foreach (OpenXmlElement elem in elems)
                    {
                        if (elem is DocumentFormat.OpenXml.Wordprocessing.Paragraph && !String.IsNullOrEmpty(elem.InnerText))
                        {
                            FindAllPlaceHoldersInAText(elem.InnerText);
                        }

                    }

                }

                foreach (KeyValuePair<string, string> pair in propertyPlaceholder)
                {
                    dataGridView1.Rows.Add(pair.Key, pair.Value);
                }
                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                ShowErrorDialog(ex.Message);
                log.Error(string.Format("GetAllPlaceholdersFromADocument - {0}", ex.Message));
            }
            log.Info("GetAllPlaceholdersFromADocument - END");

        }

        private bool TemplateHasPlaceHolders()
        {
            return propertyPlaceholder.Count > 0;
        }

        private void ReplacePlaceHolder(string templateFile)
        {
            log.Info("ReplacePlaceHolder - START");
            try
            {
                using (WordprocessingDocument doc = WordprocessingDocument.Open(templateFile, true))
                {

                    IEnumerable<HeaderPart> headers = doc.MainDocumentPart.HeaderParts.ToList();

                    foreach (HeaderPart headerPart in headers)
                    {
                        DocumentFormat.OpenXml.Wordprocessing.Header header = headerPart.Header;
                        var headerParas = header.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();

                        foreach (var para in headerParas)
                        {
                            SearchAndReplaceParagraphPlaceHolders(para);
                        }
                    }

                    IEnumerable<FooterPart> footers = doc.MainDocumentPart.FooterParts.ToList();

                    foreach (FooterPart footerPart in footers)
                    {

                        Footer footer = footerPart.Footer;
                        var footerParas = footer.Descendants<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();

                        foreach (var para in footerParas)
                        {
                            SearchAndReplaceParagraphPlaceHolders(para);
                        }
                    }



                    var body = doc.MainDocumentPart.Document.Body;
                    var paras = body.Elements<DocumentFormat.OpenXml.Wordprocessing.Paragraph>();

                    foreach (var para in paras)
                    {
                        SearchAndReplaceParagraphPlaceHolders(para);
                    }
                }
                isError = false;
            }
            catch (Exception ex)
            {
                isError = true;
                ShowErrorDialog(ex.Message);
                log.Error(string.Format("ReplacePlaceHolder - {0}", ex.Message));
            }
            log.Info("ReplacePlaceHolder - END");
        }

        private void SearchAndReplaceParagraphPlaceHolders(Paragraph para)
        {
            try
            {
                string s = "";
                bool isOpen = false;
                List<Text> listOfText = new List<Text>();

                foreach (var run in para.Elements<Run>())
                {
                    foreach (var text in run.Elements<Text>())
                    {

                        // The below has to be done because a single line can be split into multiple Runs after editing in Word Document
                        if (text.Text.Length > 0 && text.Text.Contains(openingPlaceHolder))
                        {
                            isOpen = true;
                        }

                        if (isOpen)
                        {
                            listOfText.Add(text);
                            s += text.Text;
                        }

                        if (isOpen && text.Text.Length > 0 && text.Text.Contains(closingPlaceHolder))
                        {
                            isOpen = false;
                            int openingIndex = s.IndexOf(openingPlaceHolder);
                            int closingIndex = s.IndexOf(closingPlaceHolder);
                            string wordToBeReplaced = s.Substring(openingIndex + 1, closingIndex - 1);

                            // Replace word

                            if (wordToBeReplaced.Length > 0 && !propertyPlaceholder.ContainsKey(wordToBeReplaced))
                            {
                                continue;
                            }

                            string replacedWord = propertyPlaceholder[wordToBeReplaced];
                            bool hasBeenReplaced = false;
                            foreach (Text t in listOfText)
                            {
                                if (!hasBeenReplaced)
                                {
                                    // In the event where the first character is the opening place holder
                                    openingIndex = Math.Max(0, t.Text.IndexOf(openingPlaceHolder) - 1);
                                    closingIndex = t.Text.IndexOf(closingPlaceHolder);

                                    // Case if text in current run does not contain the closing place holder
                                    if (closingIndex == -1)
                                    {
                                        t.Text = t.Text.Substring(0, openingIndex) + replacedWord;
                                    }
                                    else
                                    {
                                        t.Text = t.Text.Substring(0, openingIndex) + replacedWord + t.Text.Substring(closingIndex + 1);
                                    }

                                    hasBeenReplaced = true;
                                }
                                else
                                {
                                    t.Text = "";
                                }

                            }
                            // Reset
                            s = "";
                            listOfText.Clear();
                        }

                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("SearchAndReplaceParagraphPlaceHolders - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void LoadBackToDictionary()
        {
            log.Info("LoadBackToDictionary - START");
            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string key = (string)row.Cells["placeHolderKey"].Value;
                    string value = (string)row.Cells["placeHolderValue"].Value;

                    propertyPlaceholder[key] = value;
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("LoadBackToDictionary - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("LoadBackToDictionary - END");
        }

        private bool HasEmptyPlaceHolders()
        {   
            try
            {

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells["placeHolderValue"] == null || row.Cells["placeHolderValue"].Value == null)
                    {
                        return true;
                    }

                    string value = (string)row.Cells["placeHolderValue"].Value;

                    if (value.Length == 0)
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("HasEmptyPlaceHolders - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }

            return false;

        }

        private DocumentGeneratorXml GenerateXmlContent()
        {
            var DocumentGeneratorXml = new DocumentGeneratorXml();
            try
            {

                List<PlaceHolder> placeHolders = new List<PlaceHolder>();

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    PlaceHolder placeHolder = new PlaceHolder { Key = (string)row.Cells["placeHolderKey"].Value, Value = (string)row.Cells["placeHolderValue"].Value };
                    placeHolders.Add(placeHolder);
                }

                DocumentGeneratorXml = new DocumentGeneratorXml
                {
                    PlaceHolders = placeHolders
                };

            }
            catch (Exception ex)
            {
                log.Error(string.Format("DocumentGeneratorXml - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            return DocumentGeneratorXml;
        }

        private void LoadFromXml(string filePath)
        {
            log.Info("LoadFromXml - START");

            try
            {
                Dictionary<string, string> loadedXmlContent = new Dictionary<string, string>();
                DocumentGeneratorXml DocumentGeneratorXml = XmlHelper.FromXmlFile<DocumentGeneratorXml>(filePath);

                // Load contents from XML to a dictionary for faster reference
                foreach (PlaceHolder placeHolder in DocumentGeneratorXml.PlaceHolders)
                {
                    loadedXmlContent[placeHolder.Key] = placeHolder.Value;
                }

                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    string key = (string)row.Cells["placeHolderKey"].Value;

                    if (loadedXmlContent.ContainsKey(key))
                    {
                        row.Cells["placeHolderValue"].Value = loadedXmlContent[key];
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("LoadFromXml - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
            log.Info("LoadFromXml - END");
        }

        #endregion

        #region Algorithms

        TreeNode FindParentNode(TreeNode node, int targetSpacing, Dictionary<TreeNode, int> cache)
        {
            // Recurse up the tree till a parent with a suitable spacing level is found
            if (node == null) return null;

            if (cache[node] == targetSpacing) return node.Parent;

            return FindParentNode(node.Parent, targetSpacing, cache);
        }

        private void PopulateTreeView(FilePath fp)
        {
            // Conduct a depth first search to determine which parent section the subsection should belong to
            log.Info(string.Format("PopulateTreeView - Start"));

            try
            {
                string filePath = fp.Path;
                int previousSpacing = Int32.MaxValue;
                TreeNode previousNode = null;

                // Cache dictionary to keep track of the number of the indentation level of the Header
                Dictionary<TreeNode, int> cache = new Dictionary<TreeNode, int>();

                // Open the Word document
                using (WordprocessingDocument document = WordprocessingDocument.Open(filePath, false))
                {
                    // Get the main part of the document
                    MainDocumentPart mainPart = document.MainDocumentPart;

                    // Get all the paragraphs with heading styles
                    var headings = mainPart.Document.Descendants<Paragraph>().Where(p => IsHeadingStyle(p));

                    // Create the root node for the TreeView
                    TreeNode rootNode = new TreeNode(fp.FileName);
                    sectionsView.Nodes.Add(rootNode);

                    // Iterate through each heading and add to the TreeView
                    foreach (var heading in headings)
                    {
                        // Get the level of the heading
                        int level = GetHeadingLevel(heading);
                        TreeNode node = new TreeNode(heading.InnerText);

                        paragraphToNodeCache[heading.ParagraphId] = node;

                        cache[node] = level;


                        if (level > previousSpacing)
                        {
                            // Case where this heading belongs to the previous heading
                            previousNode.Nodes.Add(node);

                        }
                        else if (level == previousSpacing)
                        {
                            // Case where this heading belongs to the previous heading parents
                            TreeNode parentNode = previousNode.Parent;
                            if (parentNode != null)
                            {
                                parentNode.Nodes.Add(node);
                            }
                            else
                            {
                                rootNode.Nodes.Add(node);
                            }
                        }
                        else
                        {
                            // Case where this heading belongs to one of the previous parents nodes
                            // Recurse back up TreeNodes to find the corresponding parent node
                            TreeNode parentNode = FindParentNode(previousNode, level, cache);
                            if (parentNode == null)
                            {
                                rootNode.Nodes.Add(node);
                            }
                            else
                            {
                                parentNode.Nodes.Add(node);
                            }
                        }
                        previousSpacing = level;
                        previousNode = node;

                    }
                }
                isError = false;
            } 
            catch (Exception ex)
            {
                isError = true;
                ShowErrorDialog(ex.Message);
                log.Error(string.Format("PopulateTreeView - {0}", ex.Message));
            }
            log.Info(string.Format("PopulateTreeView - END"));

        }

        #endregion

        #region Configs

        public void ReadProjectConfig()
        {
            try
            {
                XmlDocument serverDoc = new XmlDocument();
                string filePath = Directory.GetCurrentDirectory() + @"\Config\ConfigGenerator.xml";
                serverDoc.Load(filePath);

                XmlNodeList xmlGeneral = serverDoc.SelectNodes("DocumentGenerator");

                foreach (XmlNode nodeG in xmlGeneral)
                {
                    configOpeningPlaceHolder = nodeG.SelectSingleNode("OpeningPlaceHolder").InnerText.ToCharArray()[0];
                    configClosingPlaceHolder = nodeG.SelectSingleNode("ClosingPlaceHolder").InnerText.ToCharArray()[0];
                    newTemplatePath = System.IO.Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) 
                        + nodeG.SelectSingleNode("DefaultNewTemplatePath").InnerText;
                    tbTemplate.Text = nodeG.SelectSingleNode("DefaultExistingTemplatePath").InnerText;
                    tbInput.Text = nodeG.SelectSingleNode("DefaultFolderInputPath").InnerText;
                    tbOutput.Text = nodeG.SelectSingleNode("DefaultFolderOutputPath").InnerText;

                }

                CheckConfigValidity();

            }
            catch (Exception ex)
            {
                log.Error(string.Format("ReadProjectConfig - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }


        }

        private void CheckConfigValidity()
        {
            try
            {
                // Check if opening and closing place holders are the same
                if (configOpeningPlaceHolder == '\0' || configClosingPlaceHolder == '\0' || configOpeningPlaceHolder == configClosingPlaceHolder)
                {
                    ShowErrorDialog("The opening and closing placeholder characters cannot be the same and should not be empty!");
                    log.Error("CheckConfigValidity - The opening and closing placeholder characters cannot be the same and should not be empty!");
                    this.Close();
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("CheckConfigValidity - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        #endregion

        #region Actions

        private void sectionsView_AfterCheck(object sender, TreeViewEventArgs e)
        {
            try
            {
                if (e.Action != TreeViewAction.Unknown)
                {
                    e.Node.Descendants().ToList().ForEach(x =>
                    {
                        x.Checked = e.Node.Checked;
                    });
                    e.Node.Ancestors().ToList().ForEach(x =>
                    {
                        bool check = false;

                        foreach (TreeNode treeNode in x.Descendants().ToList())
                        {
                            if (treeNode.Checked)
                            {
                                x.Checked = true;
                                break;
                            }
                        }
                        //x.Checked = x.Descendants().ToList().Any(y => y.Checked);
                    });
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("sectionsView_AfterCheck - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void DocumentGeneratorForm_Load(object sender, EventArgs e)
        {
            try
            {
                radioButtonNewTemplate.Enabled = true;
                tbTemplate.Enabled = false;
                btnOpenTemplate.Enabled = false;
                // Panel1 - First panel that welcomes the user
                // Panel2 - Placeholder panel that allows the user to enter the value of the placeholder
                // Panel3 - Final panel before generation of templates
                panels.Add(panel1);
                panels.Add(panel2);
                panels.Add(panel3);
                panel1.BringToFront();

            }
            catch (Exception ex)
            {
                log.Error(string.Format("DocumentGeneratorForm_Load - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void radioButtonNewTemplate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnNextFirstPanel.Enabled = true;
                if (radioButtonNewTemplate.Checked)
                {
                    radioButtonExistingTemplate.Checked = false;
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("radioButtonNewTemplate_CheckedChanged - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void radioButtonExistingTemplate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                btnNextFirstPanel.Enabled = true;
                if (radioButtonExistingTemplate.Checked)
                {
                    radioButtonNewTemplate.Checked = false;
                    tbTemplate.Enabled = true;
                    btnOpenTemplate.Enabled = true;
                } else
                {
                    tbTemplate.Enabled = false;
                    btnOpenTemplate.Enabled = false;
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("radioButtonExistingTemplate_CheckedChanged - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void checkBoxSaveTemplate_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                if (checkBoxSaveTemplate.Checked)
                {
                    tbSaveTemplate.Enabled = true;
                    btnSaveTemplate.Enabled = true;
                } else
                {
                    tbSaveTemplate.Enabled = false;
                    btnSaveTemplate.Enabled = false;
                    tbSaveTemplate.BackColor = System.Drawing.Color.White;
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("checkBoxSaveTemplate_CheckedChange - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void radioButtonFilter_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                sectionsView.Nodes.Clear();
                btnGenerateFile.Enabled = false;
                if (radioButtonFilter.Checked)
                {
                    radioButtonInsertSections.Checked = false;
                    tbInput.Enabled = false;
                    tbInput.Text = "";
                    tbInput.BackColor = System.Drawing.Color.LightGray;
                    btnOpenInput.Enabled = false;
                    btnSelectSections.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                log.Error(string.Format("radioButtonFilter_CheckedChanged - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void radioButtonInsertSections_CheckedChanged(object sender, EventArgs e)
        {
            try
            {
                sectionsView.Nodes.Clear();
                btnGenerateFile.Enabled = false;
                if (radioButtonInsertSections.Checked)
                {
                    radioButtonFilter.Checked = false;
                    tbInput.Enabled = true;
                    tbInput.BackColor = System.Drawing.Color.White;
                    btnOpenInput.Enabled = true;
                    btnSelectSections.Enabled = true;
                }

            }
            catch (Exception ex)
            {
                log.Error(string.Format("radioButtonInsertSections_CheckedChanged - {0}", ex.Message));
                ShowErrorDialog(ex.Message);
                isError = true;
            }
        }

        private void DocumentGeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Delete the temporary files
            foreach (string path in temporaryFiles)
            {
                try
                {
                    File.Delete(path);
                } catch { }

            }
        }

        #endregion

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/cadencjk/document-generator");
        }
    }

    #region Extensions
    public static class Extensions
    {
        internal static IEnumerable<TreeNode> Descendants(this TreeNodeCollection c)
        {
            foreach (var node in c.OfType<TreeNode>())
            {
                yield return node;

                foreach (var child in node.Nodes.Descendants())
                {
                    yield return child;
                }
            }
        }
        public static List<TreeNode> Descendants(this System.Windows.Forms.TreeView tree)
        {
            var nodes = tree.Nodes.Cast<TreeNode>();
            return nodes.SelectMany(x => x.Descendants()).Concat(nodes).ToList();
        }
        public static List<TreeNode> Descendants(this TreeNode node)
        {
            var nodes = node.Nodes.Cast<TreeNode>().ToList();
            return nodes.SelectMany(x => Descendants(x)).Concat(nodes).ToList();
        }
        public static List<TreeNode> Ancestors(this TreeNode node)
        {
            return AncestorsInternal(node).ToList();
        }
        private static IEnumerable<TreeNode> AncestorsInternal(TreeNode node)
        {
            while (node.Parent != null)
            {
                node = node.Parent;
                yield return node;
            }
        }
    }
    #endregion

}
