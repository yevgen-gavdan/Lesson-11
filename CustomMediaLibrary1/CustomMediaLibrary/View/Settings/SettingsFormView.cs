using CustomMediaLibrary.Controllers;
using CustomMediaLibrary.Model;
using CustomMediaLibrary.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CustomMediaLibrary
{
    public partial class SettingsFormView : Form, IMediaLibraryView
    {
        public SettingsFormView()
        {
            InitializeComponent();
        }

        private IMediaLibraryController _myController;
        public IMediaLibraryController Controller
        {
            get { return _myController; }
            set
            {
                if (_myController == value)
                {
                    return;
                }
                else if (value == null)
                {
                    UnSubscribeFromModelEvents();
                }
                else
                {
                    _myController = value;
                    SubscribeToModelEvents();
                }
            }
        }

        private void SubscribeToModelEvents()
        {
            _myController.Model.ReloadAllData += Model_ReloadAllData;
            _myController.Model.PropertyChanged += Model_PropertyChanged;  
        }
        private void UnSubscribeFromModelEvents()
        {
            _myController.Model.ReloadAllData -= Model_ReloadAllData;
            _myController.Model.PropertyChanged -= Model_PropertyChanged;  
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            //TODO: Implement
        }
        private void Model_ReloadAllData(object sender, MediLibraryReloadAllDataEventArgs e)
        {
            if (e.TargetView == this )
            {
                var model = sender as MediaLibraryModel;
                if (model == null)
                {
                    return;
                }

                this.listSupportedFileTypes.Items.Clear();
                this.listMediaLibraryLocations.Items.Clear();

                foreach (var item in model.SupportedFiles)
	            {
		            this.listSupportedFileTypes.Items.Add(item);
	            }
                foreach (var item in model.SearchDirectories)
                {
                    this.listMediaLibraryLocations.Items.Add(item);
                }
                this.numericUpdateInterval.Value = model.MLUpdateInterval;
            }
        }

        private void btnAddSupportedFileType_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(this.textFileType.Text) || this.listSupportedFileTypes.Items.Contains(this.textFileType.Text))
            {
                this.textFileType.Text = String.Empty;
                return;
            }

            this.listSupportedFileTypes.Items.Add(this.textFileType.Text);

        }

        private void textFileType_TextChanged(object sender, EventArgs e)
        {
            this.btnAddSupportedFileType.Enabled = !String.IsNullOrEmpty(this.textFileType.Text);
            
        }

        private void btnRemoveSupportedFileType_Click(object sender, EventArgs e)
        {
            int selectedItem = this.listSupportedFileTypes.SelectedIndex;
            if (selectedItem >= 0)
	        {
                this.listSupportedFileTypes.Items.RemoveAt(selectedItem);
	        }
        }

        private void btnAddFolder_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            DialogResult result = fbd.ShowDialog();

            if (result != DialogResult.OK)
            {
                return;
            }
            
            string path = fbd.SelectedPath;
            
            if (this.listMediaLibraryLocations.Items.Contains(path))
            {
                return;
            }
            else
            {
                this.listMediaLibraryLocations.Items.Add(path);
            }
        }

        private void btnRemoveFolder_Click(object sender, EventArgs e)
        {
            int selectedItem = this.listMediaLibraryLocations.SelectedIndex;
            if (selectedItem >= 0)
	        {
                this.listMediaLibraryLocations.Items.RemoveAt(selectedItem);
	        }
        }

        private void btnSettingsApply_Click(object sender, EventArgs e)
        {
            if (this.SettingsChangedNotifycation != null)
            {
                List<string> locations = new List<string>();
                List<string> filters = new List<string>();

                foreach (var item in this.listSupportedFileTypes.Items)
                {
                    filters.Add((string)item);
                }
                foreach (var item in this.listMediaLibraryLocations.Items)
                {
                    locations.Add((string)item);
                }

                SettingsChangedNotifycation.Invoke(this,  new SettingsChangedEventArgs(filters, locations, (int)this.numericUpdateInterval.Value));           
            }
            this.Close();
        }

        public event SettingsChangedEventHandler SettingsChangedNotifycation;
    }
    
    public delegate void SettingsChangedEventHandler(object sender, SettingsChangedEventArgs e);
    public class SettingsChangedEventArgs : EventArgs
    {
        public SettingsChangedEventArgs(List<string> SupportedFileList, List<string> SearchDirectoriesList, int MLUpdateInterval)
        {
            this.SupportedFileList = SupportedFileList;
            this.SearchDirectoriesList = SearchDirectoriesList;
            this.MLUpdateInterval = MLUpdateInterval;
        }

        public  List<string> SupportedFileList { get; private set; }
        public  List<string> SearchDirectoriesList { get; private set; }
        public  int MLUpdateInterval { get; private set; }
    }
}
