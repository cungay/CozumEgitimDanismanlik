using System;
using System.Linq;
using System.Windows.Forms;
using System.ComponentModel;
using Ekip.Framework.Entities;
using Ekip.Framework.Services;
using Ekip.Framework.Core;
using Ekip.Framework.Data;
using DevExpress.XtraEditors.Controls;
using DevExpress.XtraEditors;
using Ekip.Framework.UI.Forms;
using Ekip.Framework.UI.Extensions;
using Ekip.Framework.UI.XAF;
using Ekip.Framework.Core.ErrorHandling;
using DevExpress.XtraEditors.DXErrorProvider;
using Ekip.Win.Framework.Forms;

namespace Ekip.Win.UI.Modules
{
    public partial class ClientModule : BaseModule
    {
        #region Fields

        private readonly ClientService clientService = null;
        private readonly CalendarAgeService calendarAgeService = null;
        private readonly ProvinceService provinceService = null;
        private readonly ClientAddressService addressService = null;
        private readonly ClientMotherService motherService = null;
        private readonly ClientFatherService fatherService = null;

        #endregion

        #region Ctor

        public ClientModule()
        {
            InitializeComponent();
            CheckForIllegalCrossThreadCalls = false;

            clientService = new ClientService();
            calendarAgeService = new CalendarAgeService();

            provinceService = new ProvinceService();
            addressService = new ClientAddressService();
            
            motherService = new ClientMotherService();
            fatherService = new ClientFatherService();

            lkGender.BindEnum(typeof(Gender));
            rgBlood.BindEnum(typeof(Blood));
            lkFamilyStatus.BindEnum(typeof(FamilyStatus));
            lkAddressTitle.BindEnum(typeof(AddressTitles));

            var calendarAgeSource = DataRepository.CalendarAgeProvider.GetAll();
            lkCalendarAge.BindEnumarable<CalendarAge>(calendarAgeSource, "AgeDescription", "CalendarAgeId");

            VList<ProvinceView> provinces = DataRepository.ProvinceViewProvider.Get(whereClause: null, orderBy: "RowNumber ASC");
            lkProvince.Properties.DataSource = provinces;
            lkProvince.Properties.ValueMember = "Id";

            lkProvince.EditValueChanged += ProvinceChanged;
            lkTown.EditValueChanged += TownChanged;
            lkNeighborhood.EditValueChanged += NeighborhoodChanged;

            //lkProvince.ButtonClick += Province_ButtonClick;
            //lkTown.ButtonClick += Town_ButtonClick;
            //lkNeighborhood.ButtonClick += Neighborhood_ButtonClick;
            //lkStreet.ButtonClick += Street_ButtonClick;
            //lkAddressTitle.ButtonClick += AddressTitle_ButtonClick;

            Navigate(NavigateAction.Last);

            //var startTimeSpan = TimeSpan.Zero;
            //var periodTimeSpan = TimeSpan.FromMinutes(5);

            //var timer = new System.Threading.Timer((e) =>
            //{
            //    Application.DoEvents();
            //    //grpClient.Select();
            //    txtFullName.Select();
            //    txtFullName.Focus();
            //}, null, startTimeSpan, periodTimeSpan);

            txtFullName.EditValueChanged += Editor_ToUpper;
            txtMiddleName.EditValueChanged += Editor_ToUpper;
            txtPediatrician.EditValueChanged += Editor_ToUpper;
            txtReference.EditValueChanged += Editor_ToUpper;
            txtNotes.EditValueChanged += Editor_ToUpper;
            txtAddressLine.EditValueChanged += Editor_ToUpper;
            txtFamilyFullName.EditValueChanged += Editor_ToUpper;
            txtFamilyNotes.EditValueChanged += Editor_ToUpper;

            //deFirstContact.Properties.MaxValue = DateTime.Today;
            //deFirstContact.CustomDisplayText += FirstContactDate_CustomDisplayText;
            //deFirstContact.EditValueChanged += FirstContactDateOnChanged;
            deFirstContact.Validating += FirstContactOnValidating;
            deFirstContact.InvalidValue += FirstDateOnInvalidValue;

            //deBirthDate.Properties.MaxValue = DateTime.Today;
            //deBirthDate.CustomDisplayText += BirthDate_CustomDisplayText;
            //deBirthDate.EditValueChanged += BirthDateOnChanged;
            deBirthDate.Validating += BirthDateOnValidating;
            deBirthDate.InvalidValue += BirthDateOnInvalidValue;
        }

        #endregion

        #region Override ToolBar

        protected override bool HasNew => true;
        protected override bool HasSave => false;
        protected override bool HasRefresh => true;
        protected override bool HasImport => false;
        protected override bool HasPrinting => false;
        protected override bool HasFind => true;
        protected override bool HasNavigation => true;
        protected override bool HasSearch => true;

        #endregion

        #region Address Cascade

        private void ProvinceChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                SearchLookUpEdit edit = sender as SearchLookUpEdit;
                lkTown.Enabled = false;
                int provinceId = edit.EditValue.ToInt32();
                if (provinceId > 0)
                {
                    VList<TownView> towns = DataRepository.TownViewProvider.GetByProvinceId(provinceId);
                    lkTown.Properties.DataSource = towns;
                    lkTown.Properties.ValueMember = "TownId";
                    lkTown.EditValue = null;
                    lkTown.Enabled = towns.Count > 0;
                }
                else
                {
                    lkTown.Properties.DataSource = null;
                    lkTown.EditValue = null;
                    lkNeighborhood.EditValue = null;
                    edit.EditValue = null;
                }
            }
        }

        private void TownChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                SearchLookUpEdit edit = sender as SearchLookUpEdit;
                lkNeighborhood.Enabled = false;
                int townId = edit.EditValue.ToInt32();
                if (townId > 0)
                {
                    VList<NeighborhoodView> neighborhoods = DataRepository.NeighborhoodViewProvider.GetByTownId(townId);
                    lkNeighborhood.Properties.DataSource = neighborhoods;
                    lkNeighborhood.Properties.ValueMember = "NeighborhoodId";
                    lkNeighborhood.EditValue = null;
                    lkNeighborhood.Enabled = neighborhoods.Count > 0;
                }
                else
                {
                    lkNeighborhood.Properties.DataSource = null;
                    edit.EditValue = null;
                    lkNeighborhood.EditValue = null;
                }
            }
        }

        private void NeighborhoodChanged(object sender, EventArgs e)
        {
            using (new WaitCursor())
            {
                SearchLookUpEdit edit = sender as SearchLookUpEdit;
                lkStreet.Enabled = false;
                int neighborhoodId = edit.EditValue.ToInt32();
                if (neighborhoodId > 0)
                {
                    TList<Street> streets = DataRepository.StreetProvider.GetByNeighborhoodId(neighborhoodId);
                    lkStreet.Properties.DataSource = streets;
                    lkStreet.Properties.ValueMember = "StreetId";
                    lkStreet.EditValue = null;
                    lkStreet.Enabled = streets.Count > 0;
                }
                else
                {
                    lkStreet.Properties.DataSource = null;
                    edit.EditValue = null;
                    lkNeighborhood.EditValue = null;
                }
            }
        }

        #region Button Click

        private void AddressTitle_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Delete")
            {
                //lkAddressTitle.EditValue = 0;
            }
        }

        protected void Province_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Delete")
            {
                //lkProvince.EditValue = null;
            }
        }

        protected void Town_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Delete")
            {
                //lkTown.EditValue = null;
            }
        }

        protected void Neighborhood_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Delete")
            {
                //lkNeighborhood.EditValue = null;
            }
        }

        protected void Street_ButtonClick(object sender, ButtonPressedEventArgs e)
        {
            if (e.Button.Tag != null && e.Button.Tag.ToString() == "Delete")
            {
                //lkStreet.EditValue = null;
            }
        }

        #endregion

        #endregion

        #region Editor_ToUpper

        private void Editor_ToUpper(object sender, EventArgs e)
        {
            var editor = (TextEdit)sender;
            editor.BeginInvoke(new System.Action(() =>
            {
                var culture = System.Globalization.CultureInfo.CreateSpecificCulture("tr-TR");
                editor.EditValue = Convert.ToString(editor.EditValue).ToUpper(culture);
                editor.Select(editor.Text.Length + 1, 0);
            }));
        }

        #endregion

        #region DateEdit CustomDisplayText

        private void FirstContactDate_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            DateTime? contactDate = null;
            DateTime birthDate = deBirthDate.DateTime.Date;
            if (e.Value != null && e.Value != DBNull.Value)
                contactDate = Convert.ToDateTime(e.Value);
            if (contactDate.HasValue && contactDate.Value > DateTime.MinValue)
            {
                int calculatedAge = clientService.CalcAge(contactDate.Value, birthDate);
                var calendarAge = calendarAgeService.CalcCalendarAge(birthDate, contactDate.Value);
                e.DisplayText = StringExtensions.FormatCurrentCulture("{0} - (Başvuru Yaşı {1})",
                    contactDate.Value.ToLongDateString(),
                    calculatedAge).ToUpper();
            }
        }

        private void BirthDate_CustomDisplayText(object sender, CustomDisplayTextEventArgs e)
        {
            DateTime? selectedDate = null;
            if (e.Value != null && e.Value != DBNull.Value)
                selectedDate = Convert.ToDateTime(e.Value);
            if (selectedDate.HasValue && selectedDate.Value > DateTime.MinValue)
            {
                int calculatedAge = clientService.CalcAge(DateTime.Now, selectedDate.Value);
                e.DisplayText = StringExtensions.FormatCurrentCulture("{0} - (Şu anda {1} Yaşında)",
                    selectedDate.Value.ToLongDateString(),
                    calculatedAge).ToUpper();
            }
        }

        #endregion

        #region BirthDate Validation

        private void BirthDateOnValidating(object sender, CancelEventArgs e)
        {
            DateTime birthDate = (sender as DateEdit).DateTime;
            if (birthDate.Date > DateTime.Today)
                e.Cancel = true;
            DateTime contactDate = deFirstContact.DateTime;
            if (contactDate > DateTime.MinValue)
            {
                if (contactDate.Date < birthDate.Date)
                    e.Cancel = true;
            }
        }

        private void BirthDateOnInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            e.ExceptionMode = ExceptionMode.DisplayError;
            DateTime birthDate = (sender as DateEdit).DateTime;
            DateTime firstContactDate = deFirstContact.DateTime;
            if (birthDate.Year > DateTime.Today.Year)
                e.ErrorText = string.Format("Doğum tarihi {0} olamaz.", birthDate.ConvertToString());
            else if (firstContactDate > DateTime.MinValue)
            {
                if (firstContactDate.Date < birthDate.Date)
                {
                    e.ErrorText = "Doğum tarihi başvuru tarihinden sonraki bir tarih olamaz.\n";
                    e.ErrorText += string.Format("Doğum Tarihi: {0}\n", birthDate.ToLongDateString().ToUpper());
                    e.ErrorText += string.Format("Başvuru Tarihi: {0}\n", firstContactDate.ToLongDateString().ToUpper());
                }

            }
            if (!string.IsNullOrWhiteSpace(e.ErrorText))
            {
                ValidateException args = new ValidateException();
                e.ErrorText.Split(new[] { "\n" }, StringSplitOptions.None).ForEach(delegate (string errorMessage)
                {
                    args.ValidationErrors.Add(new ValidationError() { ErrorMessage = errorMessage });
                });
                DialogResult dialogResult = TaskDialog.ValidateException(args);
                if (dialogResult == DialogResult.Ignore)
                    e.ExceptionMode = ExceptionMode.Ignore;
            }
        }

        #endregion

        #region FirstContactDate Validation

        private void FirstContactOnValidating(object sender, CancelEventArgs e)
        {
            DateTime contactDate = (sender as DateEdit).DateTime.Date;
            DateTime birthDate = deBirthDate.DateTime.Date;
            if (contactDate > DateTime.Today)
                e.Cancel = true;
            else if (birthDate > DateTime.MinValue)
            {
                if (contactDate < birthDate)
                    e.Cancel = true;
            }
        }

        private void FirstDateOnInvalidValue(object sender, InvalidValueExceptionEventArgs e)
        {
            DateTime contactDate = deFirstContact.DateTime.Date;
            DateTime birthDate = deBirthDate.DateTime.Date;
            if (contactDate > DateTime.Today)
                e.ErrorText = string.Format("Başvuru tarihi {0} olamaz.", contactDate.ToLongDateString().ToUpper());
            else if (birthDate > DateTime.MinValue)
            {
                if (contactDate < birthDate)
                {
                    e.ErrorText = "Başvuru tarihi doğum tarihinden önceki bir tarih olamaz.\n";
                    e.ErrorText += string.Format("Başvuru Tarihi: {0}\n", contactDate.ToLongDateString().ToUpper());
                    e.ErrorText += string.Format("Doğum Tarihi: {0}\n", birthDate.ToLongDateString().ToUpper());
                }
            }
            if (!string.IsNullOrWhiteSpace(e.ErrorText))
            {
                ValidateException args = new ValidateException();
                e.ErrorText.Split(new[] { "\n" }, StringSplitOptions.None).ForEach(delegate (string errorMessage)
                {
                    args.ValidationErrors.Add(new ValidationError() { ErrorMessage = errorMessage });
                });
                DialogResult dialogResult = TaskDialog.ValidateException(args);
                if (dialogResult == DialogResult.Ignore)
                    e.ExceptionMode = ExceptionMode.Ignore;
            }
        }

        #endregion

        #region DataBind

        private void DataBind(Client client)
        {
            Actions[ActionKeys.Search].EditValue = client.FileNumber;

            #region Client
            txtFileNumber.DataBind(client);
            deFirstContact.DataBind(client);
            deBirthDate.DataBind(client);
            lkCalendarAge.DataBind(client);
            lkGender.DataBind(client);
            rgBlood.DataBind(client);
            txtFullName.DataBind(client);
            txtMiddleName.DataBind(client);
            txtPediatrician.DataBind(client);
            txtIdCard.DataBind(client);
            txtReference.DataBind(client);
            txtNotes.DataBind(client);
            client.AcceptChanges();
            client.PropertyChanged += Client_PropertyChanged;
            #endregion

            #region Address

            if (client.AddressId.HasValue && client.AddressId.Value > 0)
                client.AddressIdSource = addressService.GetByAddressId(client.AddressId.Value);
            else
                client.AddressIdSource = new ClientAddress();

            lkAddressTitle.DataBind(client.AddressIdSource);
            lkProvince.DataBind(client.AddressIdSource);
            lkTown.DataBind(client.AddressIdSource);
            lkNeighborhood.DataBind(client.AddressIdSource);
            lkStreet.DataBind(client.AddressIdSource);
            txtAddressLine.DataBind(client.AddressIdSource);
            txtPhone1.DataBind(client.AddressIdSource);
            txtPhone2.DataBind(client.AddressIdSource);
            txtGsm.DataBind(client.AddressIdSource);
            client.AddressIdSource.AcceptChanges();
            client.AddressIdSource.PropertyChanged += Address_PropertyChanged;

            #endregion

            #region Mother

            if (client.MotherId > 0)
                client.MotherIdSource = motherService.GetByMotherId(client.MotherId);
            else
                client.MotherIdSource = new ClientMother();

            TList<ClientMother> clientMothers = new TList<ClientMother>();
            clientMothers.Add(client.MotherIdSource);
            //vgMother.DataSource = clientMothers;
            //vgMother.ClearRowErrors();
            client.MotherIdSource.AcceptChanges();
            client.MotherIdSource.PropertyChanged += Mother_PropertyChanged;

            #endregion

            #region Father

            if (client.FatherId > 0)
                client.FatherIdSource = fatherService.GetByFatherId(client.FatherId);
            else
                client.FatherIdSource = new ClientFather();

            TList<ClientFather> clientFathers = new TList<ClientFather>();
            clientFathers.Add(client.FatherIdSource);
            //vgFather.DataSource = clientFathers;
            //vgFather.ClearRowErrors();
            client.FatherIdSource.AcceptChanges();
            client.FatherIdSource.PropertyChanged += Father_PropertyChanged;

            #endregion

            #region Seance

            //ucClientTab1.DataBind(client);

            #endregion

            Program.CurrentClient = client;

            //Application.DoEvents();
            deFirstContact.Focus();
            Application.DoEvents();
            //txtFullName.Select();
            //txtFullName.Focus();
            txtFileNumber.Select();
        }

        #endregion

        #region PropertyChanged

        private DialogResult HasDataChanged()
        {
            if (Program.CurrentClient == null)
                return DialogResult.None;

            bool hasDataChanged = Program.CurrentClient.HasChanged();

            //if (hasDataChanged)
            //    return UserDialog.FileChanged(this, Program.CurrentClient.FileNumber);

            return DialogResult.None;
        }

        private void OnPropertyChanged<T>(T entity, PropertyChangedEventArgs e) where T : EntityBase
        {
            if (string.IsNullOrWhiteSpace(e.PropertyName)) return;
            if (entity != null)
            {
                var obj = entity.GetType().GetProperty(e.PropertyName).GetValue(entity);
                if (obj != null && obj.GetType() == typeof(string))
                {
                    var value = obj.ToString().RemoveMultipleSpaces();
                    string target = string.IsNullOrWhiteSpace(value) ? null : value;
                    entity.GetType().GetProperty(e.PropertyName).SetValue(entity, target);
                }
                if (e.PropertyName == ClientColumn.FirstContactDate.ToString())
                {
                }
            }
        }

        private void Client_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var client = sender as Client;
            OnPropertyChanged(client, e);
        }

        private void Address_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var address = sender as ClientAddress;
            OnPropertyChanged(address, e);
        }

        private void Mother_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var mother = sender as ClientMother;
            OnPropertyChanged(mother, e);
        }

        private void Father_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            var father = sender as ClientFather;
            OnPropertyChanged(father, e);
        }

        #endregion

        #region Data Navigator

        protected int pageIndex = 0;
        protected int rowCount = 0;

        protected void Navigate(NavigateAction action)
        {
            var fileNumbers = clientService.GetAllFileNumbers();
            rowCount = fileNumbers.Count;
            switch (action)
            {
                case NavigateAction.Next:
                    pageIndex += 1;
                    break;
                case NavigateAction.Last:
                    pageIndex = rowCount - 1;
                    break;
                case NavigateAction.Prev:
                    pageIndex -= 1;
                    break;
                case NavigateAction.First:
                    pageIndex = 0;
                    break;
            }
            if (pageIndex < 0 || pageIndex >= rowCount)
            {
                pageIndex = (pageIndex < 0) ? 0 : ((pageIndex >= rowCount) ? (pageIndex = (rowCount - 1)) : 0);
                return;
            }

            DialogResult confirm = HasDataChanged();

            if (confirm != DialogResult.No)
            {
                var fileNumber = fileNumbers.ElementAt(pageIndex);
                var client = clientService.GetByFileNumber(fileNumber);
                if (client != null)
                {
                    DataBind(client);
                }
            }
        }

        protected override void DoNext()
        {
            Navigate(NavigateAction.Next);
        }

        protected override void DoLast()
        {
            Navigate(NavigateAction.Last);
        }

        protected override void DoPrev()
        {
            Navigate(NavigateAction.Prev);
        }

        protected override void DoFirst()
        {
            Navigate(NavigateAction.First);
        }

        #endregion

        #region Quick Search

        protected override void DoSearch()
        {
            Client client = null;
            int fileNumber = Actions[ActionKeys.Search].EditValue.ToInt32();
            if (fileNumber > 0)
            {
                var fileNumbers = clientService.GetAllFileNumbers();
                var mPageIndex = fileNumbers.IndexOf(fileNumber);
                if (mPageIndex >= 0)
                {
                    pageIndex = mPageIndex;
                    client = clientService.GetByFileNumber(fileNumber);
                    if (client != null)
                    {
                        DataBind(client);
                        return;
                    }
                }
                //if (client == null)
                //    UserDialog.FileNotFound(this, fileNumber);
            }
            Actions[ActionKeys.Search].EditValue = Program.CurrentClient.FileNumber;
        }

        #endregion

        #region Refresh

        protected override void DoRefresh()
        {
            DialogResult confirm = HasDataChanged();

            if (confirm != DialogResult.No)
            {
                var fileNumber = Program.CurrentClient.FileNumber;
                var client = clientService.GetByFileNumber(fileNumber);
                if (client != null)
                {
                    DataBind(client);
                    //UserDialog.RefreshFile(this, fileNumber);
                }
            }
        }

        #endregion

        #region Update Actions

        public override void UpdateActions()
        {
            base.UpdateActions();

            #region Navigator

            Actions[ActionKeys.LastFile].Enabled = (pageIndex + 1) < rowCount;
            Actions[ActionKeys.NextFile].Enabled = (rowCount - pageIndex) > 1;
            Actions[ActionKeys.FirstFile].Enabled = pageIndex != 0;
            Actions[ActionKeys.PrevFile].Enabled = pageIndex != 0;

            #endregion
        }

        #endregion
    }
}
