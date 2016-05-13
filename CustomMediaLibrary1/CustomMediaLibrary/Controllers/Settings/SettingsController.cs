using CustomMediaLibrary.Model;
using CustomMediaLibrary.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMediaLibrary.Controllers.Settings
{
    public class SettingsController : IMediaLibraryController
    {

        public SettingsController()
        {
        }

        private MediaLibraryModel _Model;
        public MediaLibraryModel Model
        {
            get
            {
                return _Model;
            }
            set
            {
                _Model = value;
            }
        }


        public Form CreateView()
        {
            var settingsForm = new SettingsFormView();
            settingsForm.Controller = this;
            this.AttachView(settingsForm);
            settingsForm.Controller.Model.NotifyViewToReloadAllData(settingsForm);
            return settingsForm;
        }


        private void AttachView(IMediaLibraryView view)
        {
            var settingsView = view as SettingsFormView;
            if (settingsView == null)
            {
                return;
            }

            settingsView.SettingsChangedNotifycation += settingsView_SettingsChangedNotifycation;
        }

        void settingsView_SettingsChangedNotifycation(object sender, SettingsChangedEventArgs e)
        {
            this._Model.SupportedFiles = e.SupportedFileList;
            this._Model.SearchDirectories = e.SearchDirectoriesList;
            this._Model.MLUpdateInterval = e.MLUpdateInterval;
        }
    }
}
