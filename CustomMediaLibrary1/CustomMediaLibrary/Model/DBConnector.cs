using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using CustomMediaLibrary.Model;

namespace CustomMediaLibrary
{
    class DBConnector
    {
        public DBConnector()
        {
            
        }
        public void InitializeDB()
        {


        }

        #region Write to DB
        public void SetAudio(List<Audio> AudioList)
        {
            using (var cnt = new MediaDBDataContext())
            {
                cnt.Audios.DeleteAllOnSubmit(cnt.Audios);
                cnt.SubmitChanges();
                cnt.Audios.InsertAllOnSubmit<Audio>(AudioList);
                cnt.SubmitChanges();
            }
        }
        public void WriteSupportedFiles(List<string> list)
        {
            using (var cnt = new MediaDBDataContext())
            {            
                foreach (var filter in list)
                {
                    var FF = new FileFilter() { Filter = filter };
                    cnt.FileFilters.InsertOnSubmit(FF);
                }
                cnt.SubmitChanges();
            }
        }
        public void WriteSearchDirectories(List<string> list)
        {
            using (var cnt = new MediaDBDataContext())
            {
                foreach (var dir in list)
                {
                    var LL = new MediaLibraryLocation() { Path = dir };
                    cnt.MediaLibraryLocations.InsertOnSubmit(LL);
                }
                cnt.SubmitChanges();
            }
        }
        public void WriteUpdateInterval(int intr)
        {
            using (var cnt = new MediaDBDataContext())
            {
                var NewInterval = cnt.MLConfigurations.SingleOrDefault(X => X.ConfigurationName == "MLUpdateInterval");
                NewInterval.ConfigurationValue = Convert.ToString(intr);
                cnt.SubmitChanges();
            }
        }
        #endregion

        #region READ DB
        public List<Audio> GetAudio()
        {
            using (var cnt = new MediaDBDataContext())
            {
                var queryresult = from audio in cnt.Audios
                                  select audio;

                return queryresult.ToList<Audio>();
            }
        }
        public int ReadUpdateInterval()
        { 
            using (var cnt = new MediaDBDataContext())
            {
                var queryresult = from config in cnt.MLConfigurations
                                  where config.ConfigurationName == "MLUpdateInterval"
                                  select config.ConfigurationValue;

                return Convert.ToInt32(queryresult.ToList<string>()[0]);
            }
        }
        public List<string> ReadSearchDirectories()
        { 
            var list = new List<string>();
            using (var cnt = new MediaDBDataContext())
            {
                var queryresult = from dir in cnt.MediaLibraryLocations
                                  select dir;
                foreach (var item in queryresult)
	            {
		            list.Add(item.Path);
	            }
            }
            return list;
        }
        public List<string> ReadSupportedFiles()
        { 
            var list = new List<string>();
            using (var cnt = new MediaDBDataContext())
            {
                var queryresult = from filter in cnt.FileFilters
                                  select filter;
                var queryLyst = queryresult.ToList<FileFilter>();
                foreach (var item in queryresult)
                {
                    list.Add(item.Filter);
                }
            }
            return list;
        }
        #endregion
        
        
        //TODO:
        public void GetPlaylists()
        { 
        
        }
        public void GetPlaylistMedia()
        {

            
        }

    }
}