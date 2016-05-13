using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using CustomMediaLibrary.View;
using System.IO;

namespace CustomMediaLibrary.Model
{
    public class MediaLibraryModel : INotifyPropertyChanged
    {
        #region Private DATA
        private List<string> _SupportedFiles;
        private List<string> _SearchDirectories;
        private bool _SearchSubfolders;
        private int _MLUpdateInterval;
        private List<Audio> _AudioFiles;
        private DBConnector _SQLDB;
        private FSConnector _FileSystem;
        #endregion

        #region Properties
        public List<Audio> AudioFiles
        {
            get { return _AudioFiles; }
            set 
            {
                _AudioFiles = value;
                if (PropertyChanged!=null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("AudioFiles"));
                }
                this.WriteMediaList();
            }
        }
        public List<string> SupportedFiles
        {
            get { return _SupportedFiles; }
            set 
            { 
                _SupportedFiles = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SupportedFiles"));
                }
                WriteSupportedFiles();

            }
        }
        public List<string> SearchDirectories
        {
            get { return _SearchDirectories; }
            set 
            { 
                _SearchDirectories = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SearchDirectories"));
                }
                WriteSearchDirectories();
            }
        }
        public bool SearchSubfolders
        {
            get { return _SearchSubfolders; }
            set
            { 
                _SearchSubfolders = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("SearchSubfolders"));
                }
            }
        }
        public int MLUpdateInterval
        {
            get { return _MLUpdateInterval; }
            set 
            { 
                _MLUpdateInterval = value;
                if (PropertyChanged != null)
                {
                    PropertyChanged(this, new PropertyChangedEventArgs("MLUpdateInterval"));
                }
                WriteUpdateInterval();
            }
        }
        #endregion

        public MediaLibraryModel()
        {
            ReadMLConfiguration();
        }

        #region Read/Publish DATA from/to SQL
        private List<string> ReadSupportedFiles()
        {
            _SQLDB = new DBConnector();
            return _SQLDB.ReadSupportedFiles();
        }
        private List<string> ReadSearchDirectories()
        {
            _SQLDB = new DBConnector();
            return _SQLDB.ReadSearchDirectories();
        }
        private int ReadUpdateInterval()
        {
            _SQLDB = new DBConnector();
            return _SQLDB.ReadUpdateInterval();
        }
        public void ReadMLConfiguration()
        {
            _SupportedFiles = ReadSupportedFiles();
            _SearchDirectories = ReadSearchDirectories();
            _MLUpdateInterval = ReadUpdateInterval();
        }
        private void WriteSupportedFiles()
        {
            _SQLDB = new DBConnector();
            _SQLDB.WriteSupportedFiles(this._SupportedFiles);
        }
        private void WriteSearchDirectories()
        {
            _SQLDB = new DBConnector();
            _SQLDB.WriteSearchDirectories(this._SearchDirectories);
        }
        private void WriteUpdateInterval()
        {
            _SQLDB = new DBConnector();
            _SQLDB.WriteUpdateInterval(this._MLUpdateInterval);
        }
        public void WriteMLConfiguration()
        {
            WriteSupportedFiles();
            WriteSearchDirectories();
            WriteUpdateInterval();
        }
        public void WriteMediaList()
        {
            _SQLDB = new DBConnector();
            _SQLDB.SetAudio(this._AudioFiles);
        }
        #endregion

        #region Read DATA from HDD
        public void ReadMediaList()
        { 
            _FileSystem = new FSConnector(_SupportedFiles, _SearchDirectories);
            var listOfMediaSources = _FileSystem.GetMediaFilesList();

            var listOfAudioFiles = new List<Audio>();

            foreach (var mediaSource in listOfMediaSources)
            {
                var tempAudioFile = new Audio();
                tempAudioFile.FileName = Path.GetFileName(mediaSource);
                tempAudioFile.FilePath = mediaSource;
                tempAudioFile.FileType = Path.GetExtension(mediaSource);
                tempAudioFile.Name = Path.GetFileNameWithoutExtension(mediaSource);
                listOfAudioFiles.Add(tempAudioFile);
            }
            this.AudioFiles = listOfAudioFiles;
        }
        #endregion

        public void SaveData()
        { 
            
        }

        public void NotifyViewToReloadAllData(IMediaLibraryView targetView)
        {
            if (targetView==null)
            {
                return;
            }
            ReloadAllData.Invoke(this, new MediLibraryReloadAllDataEventArgs(targetView));
        }

        public event ReloadAllDataEventHandler ReloadAllData;
        public event PropertyChangedEventHandler PropertyChanged;
    }

    public delegate void ReloadAllDataEventHandler(object sender, MediLibraryReloadAllDataEventArgs e);
    public class MediLibraryReloadAllDataEventArgs : EventArgs
    {
        public MediLibraryReloadAllDataEventArgs(IMediaLibraryView TargetView)
        {
            this.TargetView = TargetView;
        }
        public virtual IMediaLibraryView TargetView { get; private set; }
    }
}
