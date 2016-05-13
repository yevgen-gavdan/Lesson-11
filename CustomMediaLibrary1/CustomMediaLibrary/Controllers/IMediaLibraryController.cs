using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CustomMediaLibrary.Model;
using CustomMediaLibrary.View;
using System.Windows.Forms;

namespace CustomMediaLibrary.Controllers
{
    public interface IMediaLibraryController
    {
        MediaLibraryModel Model { get; set; }
        Form CreateView();
    }
}
