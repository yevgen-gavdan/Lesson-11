using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMediaLibrary.Model;
using System.Windows.Forms;
using CustomMediaLibrary.View;
using CustomMediaLibrary.Controllers.Settings;

namespace CustomMediaLibrary.Controllers
{
    public class MediaLibraryController : IMediaLibraryController
    {
        public MediaLibraryController()
        {
            _model = new MediaLibraryModel();
        }

        public Form CreateView()
        {
            //TODO: If nesesary save in controller link to IView
            var mf = new MainMediaLibraryFormView();
            mf.Controller = this;
            this.AttachView(mf);
            mf.Controller.Model.NotifyViewToReloadAllData(mf);
            return mf;
        }

        private MediaLibraryModel _model;
        public MediaLibraryModel Model
        {
            get { return _model; }
            set { _model = value; }
        }


        private void AttachView(IMediaLibraryView view)
        {
            var mainView = view as MainMediaLibraryFormView;
            if (mainView == null)
            {
                return;
            }
            //TODO: Subscribe to View notifications here:
            mainView.MediaLibrarySettingsCalled += mainView_MediaLibrarySettingsCalled;
        }

        void mainView_MediaLibrarySettingsCalled(object sender, EventArgs e)
        {
            var settingsCnt = new SettingsController();
            settingsCnt.Model = this.Model;
            settingsCnt.CreateView().ShowDialog();
        }
    }


}
