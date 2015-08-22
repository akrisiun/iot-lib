using System;
using Windows.UI.Popups;
using System.Threading.Tasks;

namespace App1
{
    // http://stackoverflow.com/questions/22909329/universal-apps-messagebox-the-name-messagebox-does-not-exist-in-the-current

    public sealed partial class App
    {
        public static async void MessageBox(string message)
        {
            var dlg = new MessageDialog(message);
            IUICommand x = await dlg.ShowAsync();
        }

        public static async void Confirm(string message, Action<bool> answer)
        {
            var msgbox = new MessageDialog(message);
            msgbox.Title = "Question";
            msgbox.Options = MessageDialogOptions.AcceptUserInputAfterDelay;

            msgbox.Commands.Clear();
            msgbox.Commands.Add(new UICommand { Label = "Yes", Id = 0 });
            msgbox.Commands.Add(new UICommand { Label = "No", Id = 1 });

            var res = await msgbox.ShowAsync();

            bool answerValue = (int)res.Id == 0;
            if (answer != null)
                answer(answerValue);
                // Task.Factory.StartNew(() => answer(answerValue));
        }
    }
}
