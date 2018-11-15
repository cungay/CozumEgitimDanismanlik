using AppFramework;
using Ekip.WinApp.Modules;

namespace Ekip.WinApp
{
	/// <summary>
	/// Summary description for ModuleRegistration.
	/// </summary>
	public class ModulesRegistration
	{
		//Register your modules here
        static public void Register()
        {
            CategoriesInfo.Add("Danýþan Bilgileri", 0);
            ModuleInfoCollection.Add("Kiþisel Bilgiler", typeof(ClientInfo), CategoriesInfo.Instance["Danýþan Bilgileri"], 24);
            ModuleInfoCollection.Add("Soru Formu", typeof(QuestionForm), CategoriesInfo.Instance["Danýþan Bilgileri"], 25);
            ModuleInfoCollection.Add("Gözlem Formu", typeof(ObservationForm), CategoriesInfo.Instance["Danýþan Bilgileri"], 26);
            ModuleInfoCollection.Add("WISCR", typeof(Wiscr), CategoriesInfo.Instance["Danýþan Bilgileri"], 27);
            ModuleInfoCollection.Add("WIPPSI", typeof(Wippsi), CategoriesInfo.Instance["Danýþan Bilgileri"], 27);
            //ModuleInfoCollection.Add("Deðerlendirme Formu", typeof(RatingForm), CategoriesInfo.Instance["Danýþan Bilgileri"], 28);
        }
	}
}
