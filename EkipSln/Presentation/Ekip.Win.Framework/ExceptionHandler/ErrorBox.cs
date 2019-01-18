using System;
using TaskDialogInterop;

namespace Ekip.Framework.UI.ExceptionHandler
{
    public class ErrorBox
    {
        public ErrorBox()
        {
        }

        public static void Show(Exception exception)
        {
            TaskDialogOptions config = new TaskDialogOptions();
            config.Title = "Task Dialog Title";
            config.MainInstruction = "The main instruction text for the TaskDialog goes here";
            config.Content = "The content text for the task dialog is shown here and the text will automatically wrap as needed.";
            config.ExpandedInfo = "Any expanded content text for the task dialog is shown here and the text will automatically wrap as needed.";
            config.VerificationText = "Don't show me this message again";
            config.CustomButtons = new string[] { "&Save", "Do&n't save", "&Cancel" };
            config.MainIcon = VistaTaskDialogIcon.Shield;
            config.FooterText = "Optional footer text with an icon or <a href=\"testUri\">hyperlink</a> can be included.";
            config.FooterIcon = VistaTaskDialogIcon.Warning;
            config.AllowDialogCancellation = true;
            //config.Callback = taskDialog_Callback1;
            TaskDialogResult res = TaskDialog.Show(config);
            //UpdateResult(res);
        }
    }
}
