using CustomMediaLibrary.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CustomMediaLibrary.View
{
    public interface IMediaLibraryView
    {
        IMediaLibraryController Controller { get; set; }
    }
}
