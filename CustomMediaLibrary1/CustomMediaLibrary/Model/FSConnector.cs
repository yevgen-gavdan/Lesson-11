using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediaLibrary
{
    public class FSConnector
    {
        public FSConnector(List<string> SupportedFiles , List<string> SearchDirectories = null, bool SearchSubfolders = true)
        {
            this.SupportedFiles = SupportedFiles;
            this.SearchDirectories = SearchDirectories;
            this.SearchSubfolders = SearchSubfolders;
        }

        private List<string> sSupportedFiles;
        private List<string> sSearchDirectories;
        private bool bSearchSubfolders;

        public List<string> SupportedFiles
        {
            get { return sSupportedFiles; }
            set { sSupportedFiles = value; }
        }
        public List<string> SearchDirectories
        {
            get { return sSearchDirectories; }
            set { sSearchDirectories = value; }
        }
        public bool SearchSubfolders
        {
            get { return bSearchSubfolders; }
            set { bSearchSubfolders = value; }
        }

        public List<string> GetMediaFilesList()
        {
            if (SearchDirectories == null || SupportedFiles == null)
            {
                return null;
            }

            var outFileCollection = new List<string>();
            foreach (var location in this.SearchDirectories)
            {
                foreach (var filetype in this.SupportedFiles)
                {
                    outFileCollection.AddRange(Directory.GetFiles(location, filetype, this.SearchSubfolders ? SearchOption.AllDirectories : SearchOption.TopDirectoryOnly));
                }
            }
            return outFileCollection;
        }
    }
}

