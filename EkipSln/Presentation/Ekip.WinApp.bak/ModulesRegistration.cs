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
            CategoriesInfo.Add("Dan��an Bilgileri", 0);
            ModuleInfoCollection.Add("Ki�isel Bilgiler", typeof(ClientInfo), CategoriesInfo.Instance["Dan��an Bilgileri"], 24);
            ModuleInfoCollection.Add("Soru Formu", typeof(QuestionForm), CategoriesInfo.Instance["Dan��an Bilgileri"], 25);
            ModuleInfoCollection.Add("G�zlem Formu", typeof(ObservationForm), CategoriesInfo.Instance["Dan��an Bilgileri"], 26);
            ModuleInfoCollection.Add("WISCR", typeof(Wiscr), CategoriesInfo.Instance["Dan��an Bilgileri"], 27);
            ModuleInfoCollection.Add("WIPPSI", typeof(Wippsi), CategoriesInfo.Instance["Dan��an Bilgileri"], 27);
            //ModuleInfoCollection.Add("De�erlendirme Formu", typeof(RatingForm), CategoriesInfo.Instance["Dan��an Bilgileri"], 28);
        }
	}
}
