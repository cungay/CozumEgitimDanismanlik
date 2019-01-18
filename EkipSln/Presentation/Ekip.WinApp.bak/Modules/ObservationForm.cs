using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using AppFramework;
using System.IO;
using System.Reflection;
using Ekip.Framework.Entities;
using DevExpress.XtraEditors;
using Ekip.WinApp.Properties;
using Ekip.Framework.Core;
using Ekip.Win.Framework.Forms;
using Ekip.Win.Framework;
using Ekip.Framework.Data;

namespace Ekip.WinApp.Modules
{
    public partial class ObservationForm : BaseModule
    {
        public ObservationForm()
        {
            InitializeComponent();
            GetClientList();

            splitContainerControl1.PanelVisibility = SplitPanelVisibility.Panel2;
            webEditor.DocumentCompleted += OnCompleted;
        }

        #region Override ToolBar
        protected override bool HasNavigation { get { return true; } }
        protected override bool HasSearch { get { return true; } }
        protected override bool HasSave { get { return true; } }
        protected override bool HasPrinting { get { return true; } }
        //protected override bool HasShowClientList { get { return true; } }
        protected override bool HasRefresh { get { return true; } }
        protected override bool HasFind { get { return true; } }
        #endregion

        public override void InitForm()
        {
            string html = string.Empty;
            string inline = "";
            object obj = null;// Program.CurrentCache.Get("ObservationForm");

            if (obj == null)
            {
                #region GenerateHTML
                /*
                TList<ObservationFormGroup> groups = DataRepository.ObservationFormGroupProvider.GetAll();

                foreach (var g in groups)
                {
                    DataRepository.ObservationFormGroupProvider.DeepLoad(g, false, DeepLoadType.IncludeChildren, typeof(TList<Ekip.Framework.Entities.ObservationForm>));

                    inline += string.Format("<div class=\"group\">{0}</div>", g.GroupName);

                    foreach (var item in g.ObservationFormCollection)
                    {
                        DataRepository.ObservationFormProvider.DeepLoad(item, false, DeepLoadType.IncludeChildren, typeof(TList<ObservationFormOption>));

                        #region Question
                        inline += string.Format("<div class=\"question\" id={0}>", string.Format("{0}_{1}", item.QuestionRef, item.QuestionId));
                        inline += "<div class=\"title\">";
                        inline += "<table class=\"tbl\">";
                        inline += "<tbody>";
                        inline += "<tr>";

                        inline += string.Format("<th><span class=\"row_number\">{0}.&nbsp;</span></th>", item.LineNumber);
                        inline += string.Format("<td>{0}</td>", item.QuestionName);

                        inline += "</tbody>";
                        inline += "</tr>";
                        inline += "</table>";
                        inline += "</div>";
                        #endregion

                        #region Option
                        inline += "<div class=\"options\">";
                        for (int i = 0; i < item.ObservationFormOptionCollection.Count; i++)
                        {
                            string name = string.Format("rb.{0}", item.QuestionId);
                            string id = string.Format("{0}_{1}", item.QuestionId, item.ObservationFormOptionCollection[i].OptionId);
                            string value = item.ObservationFormOptionCollection[i].OptionId.ToString();
                            inline += "<div class=\"option\">";
                            inline += "<div class=\"rb\">";
                            inline += string.Format("<input type=\"radio\" name=\"{0}\" id=\"{1}\" value=\"{2}\" class=\"item\"><label for=\"{1}\" id=\"lbl_{1}\" class=\"item\">{3}</label>", name, id, value, item.ObservationFormOptionCollection[i].OptionName);
                            inline += "</div>";
                            inline += "</div>";
                        }

                        inline += "</div>";
                        #endregion

                        inline += "</div>";
                    }
                }
                */
                #endregion
                
                using (Stream stream = Assembly.GetExecutingAssembly().GetManifestResourceStream("Ekip.WinApp.Survey.gozlem_formu.html"))
                {
                    using (StreamReader reader = new StreamReader(stream))
                    {
                        obj = reader.ReadToEnd();
                    }
                }

                //Program.CurrentCache.Insert("ObservationForm", obj, Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration);
            }

            html = obj.ToString();

            DataRepository.ClientProvider.DeepLoad(Program.CurrentClient, false, DeepLoadType.IncludeChildren,
                typeof(ClientFather), typeof(ClientMother), typeof(ClientAddress));

            html = html.Replace("[file_number]", Program.CurrentClient.FileNumber.ToString());
            html = html.Replace("[fullname]", Program.CurrentClient.FullName);
            html = html.Replace("[birthdate]", Convert.ToDateTime(Program.CurrentClient.BirthDate).ToShortDateString());
            html = html.Replace("[mother]", Program.CurrentClient.MotherIdSource == null ? "-" : (!String.IsNullOrEmpty(Program.CurrentClient.MotherIdSource.FullName) ? Program.CurrentClient.MotherIdSource.FullName : "-"));
            html = html.Replace("[father]", Program.CurrentClient.FatherIdSource.FullName == null ? "-" : (!String.IsNullOrEmpty(Program.CurrentClient.FatherIdSource.FullName) ? Program.CurrentClient.FatherIdSource.FullName : "-"));
            html = html.Replace("[age]", Program.CurrentClient.Age.ToString());
            html = html.Replace("[ref]", Program.CurrentClient.Reference == null ? "-" : (!String.IsNullOrEmpty(Program.CurrentClient.Reference) ? Program.CurrentClient.Reference : "-"));
            html = html.Replace("[gender]", EnumExtensions.GetDescription((Gender)Program.CurrentClient.Gender));

            webEditor.DocumentText = html;
        }

        private void GetClientList()
        {
            TList<Client> clientList = DataRepository.ClientProvider.GetAll();
            dxGridControl1.DataSource = clientList;
        }

        #region Override Actions

        //protected override void DoShowClientList()
        //{
        //    splitContainerControl1.PanelVisibility =
        //        Actions[ActionKeys.ShowClientList].IsDown ? SplitPanelVisibility.Both : SplitPanelVisibility.Panel2;
        //}

        protected override void DoSave()
        {
            try
            {
                using (new WaitCursor())
                {
                    this.Validate();

                    DataRepository.ObservationFormAnswerProvider.DeepSave(Program.CurrentClient.ObservationFormAnswerCollection);

                    UserDialog.InfoMessage(this, "Kaydet", "Gözlem formu kaydedildi.");
                }
            }
            catch (Exception ex)
            {
                UserDialog.SaveFailure(this.Parent, ex.Message);
            }
        }

        protected override void DoRefresh()
        {
            using (new WaitCursor())
            {
                InitForm();
            }
        }

        protected override void DoPreview()
        {
            using (new WaitCursor())
            {
                webEditor.ShowPrintPreviewDialog();
            }
        }

        protected override void DoPrint()
        {
            using (new WaitCursor())
            {
                webEditor.ShowPrintDialog();
            }
        }

        protected override void DoFind()
        {
            using (new WaitCursor())
            {
                webEditor.Select();
                Application.DoEvents();
                SendKeys.Send("^f");
            }
        }

        #endregion

        #region Navigation
        private int totalCount = 0;
        private int startPage = 0;
        private int pageLength = 1;
        private void LoadQuestions(int startPage)
        {
            this.startPage = startPage;
            this.totalCount = 0;/*Program.CurrentClient.GetRowCountFromCache();*/
            Client client = DataRepository.ClientProvider.GetPaged(string.Empty, "FileNumber ASC", startPage, pageLength, out totalCount).SingleOrDefault();
            if (client != null)
            {
                Program.CurrentClient = client;
                InitForm();
            }
            Actions[ActionKeys.Search].EditValue = Program.CurrentClient.FileNumber;
        }

        public override void UpdateActions()
        {
            base.UpdateActions();
            Actions[ActionKeys.New].Visible = false;

            int nextItem = startPage + pageLength;
            Actions[ActionKeys.LastFile].Enabled =
            Actions[ActionKeys.NextFile].Enabled = totalCount != nextItem;
            Actions[ActionKeys.FirstFile].Enabled =
            Actions[ActionKeys.PrevFile].Enabled = startPage > 0;

            Actions[ActionKeys.Import].Enabled = Program.CurrentClient.ClientId > 0;
        }
        protected override void DoNext()
        {
            using (new WaitCursor())
            {
                startPage += 1;

                LoadQuestions(startPage);
            }
        }
        protected override void DoLast()
        {
            using (new WaitCursor())
            {
                startPage = totalCount - 1;

                LoadQuestions(startPage);
            }
        }
        protected override void DoPrev()
        {
            using (new WaitCursor())
            {
                if (startPage > 0)
                {
                    startPage -= 1;

                    LoadQuestions(startPage);
                }
            }
        }
        protected override void DoFirst()
        {
            using (new WaitCursor())
            {
                if (startPage != 0)
                {
                    startPage = 0;

                    LoadQuestions(startPage);
                }
            }
        }
        #endregion

        #region Search
        protected override void DoSearch()
        {
            int fileNumber = Actions[ActionKeys.Search].EditValue.ToInt32();

            if (fileNumber > 0)
            {
                using (new WaitCursor())
                {
                    int rowNumber = 0;// DataExtensions.GetRowNumber(fileNumber);

                    if (rowNumber > -1)
                    {
                        startPage = rowNumber - 1;

                        LoadQuestions(startPage);

                        return;
                    }
                }
            }
            XtraMessageBox.Show("Kayıt bulunamadı.", ResQuestionForm.DefaultCaption, MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
        #endregion

        #region WebBrowser EventArgs
        protected void OnCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            TList<ObservationFormAnswer> list = DataRepository.ObservationFormAnswerProvider.GetByClientId(Program.CurrentClient.ClientId);

            foreach (ObservationFormAnswer item in list)
            {
                HtmlElement element = webEditor.Document.GetElementsByTagName("input").Cast<HtmlElement>()
                      .Where(el => el.Id == string.Format("{0}_{1}", item.QuestionId, item.OptionId)).FirstOrDefault();

                if (element != null)
                {
                    webEditor.Document.GetElementById(element.Id).SetAttribute("checked", "true");
                }
            }

            foreach (HtmlElement item in webEditor.Document.GetElementsByTagName("label"))
                item.AttachEventHandler("onclick", (s, arg) => OnItemClick(item, EventArgs.Empty));
        }

        protected void OnItemClick(HtmlElement item, EventArgs arg)
        {
            string[] values = item.Id.Replace("lbl_", "").Split('_');
            int questionId = int.Parse(values[0]);
            int optionId = int.Parse(values[1]);

            int k = Program.CurrentClient.ObservationFormAnswerCollection.FindIndex(r => r.QuestionId == questionId);

            if (k >= 0)
            {
                Program.CurrentClient.ObservationFormAnswerCollection[k].OptionId = optionId;
                Program.CurrentClient.ObservationFormAnswerCollection[k].Description = null;
                Program.CurrentClient.ObservationFormAnswerCollection[k].UpdateOn = DateTime.Today;
            }
            else
            {
                ObservationFormAnswer obj = Program.CurrentClient.ObservationFormAnswerCollection.AddNew();
                obj.ClientId = Program.CurrentClient.ClientId;
                obj.QuestionId = questionId;
                obj.OptionId = optionId;
                obj.Description = null;
                obj.CreateOn = DateTime.Today;
            }
        }

        #endregion
    }
}
