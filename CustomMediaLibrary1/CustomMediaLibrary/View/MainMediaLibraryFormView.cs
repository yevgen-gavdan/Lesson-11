using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CustomMediaLibrary.Controllers;
using CustomMediaLibrary.View;
using CustomMediaLibrary.Model;
using CustomMediaLibrary.Player;

namespace CustomMediaLibrary
{
    public partial class MainMediaLibraryFormView : Form, IMediaLibraryView
    {
        public MainMediaLibraryFormView()
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
        
        private void Model_ReloadAllData(object sender, MediLibraryReloadAllDataEventArgs e)
        {
            if (e.TargetView == this)
            {
                var model = sender as MediaLibraryModel;
                if (model==null)
                {
                    return;
                }

                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = model.AudioFiles;

            }
        }
        private void Model_PropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if (e.PropertyName == "AudioFiles")
            {
                var model = sender as MediaLibraryModel;
                if (model == null)
                {
                    return;
                }

                this.dataGridView1.DataSource = null;
                this.dataGridView1.DataSource = model.AudioFiles;
                FormatDataGridView();
            }
        }

        private void btnSettings_Click(object sender, EventArgs e)
        {
            MediaLibrarySettingsCalled.Invoke(this, new EventArgs());
        }

        #region EVENTS
        public event EventHandler<EventArgs> MediaLibrarySettingsCalled;


        #endregion

        private void btnPlayMedia_Click(object sender, EventArgs e)
        {
            //THIS CODE SHOULD BE LOCATED IN CONTROLLER:
            if (!(this.dataGridView1.SelectedRows.Count > 0))
	        {
                return;
	        }
            
		    var playlist = new List<string>() { this.dataGridView1.SelectedRows[0].Cells["FilePath"].Value.ToString() };
            var myPlayer = new CustomMediaLibrary.Player.Player();
            myPlayer.Show();
            myPlayer.PlayAudio(playlist);
        }

        private void toolStripButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void MainMediaLibraryFormView_Load(object sender, EventArgs e)
        {
            //TODOL THIS DATA SHOULD BE RETRIEVED FROM SQL
            var MLNode = new TreeNode("Media Library");
            var PlaylistNode = new TreeNode("Playlists");
            MLNode.Nodes.Add("Audio files");

            this.treeView.Nodes.Add(MLNode);
            this.treeView.Nodes.Add(PlaylistNode);

        }

        private void updateMediaLibraryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this._myController.Model.ReadMediaList();
            //this._myController.Model.NotifyViewToReloadAllData(this);
            FormatDataGridView();
        }

        private void FormatDataGridView()
        { 
            this.dataGridView1.Columns["ID"].Visible = false;
            this.dataGridView1.Columns["IsDeletedFromDB"].Visible = false;        
        }

        private void treeView_NodeMouseClick(object sender, TreeNodeMouseClickEventArgs e)
        {
            if (e.Node.Text == "Audio files")
            { 
                this._myController.Model.ReadMediaList();
                FormatDataGridView();
            }
        }
    }
}
