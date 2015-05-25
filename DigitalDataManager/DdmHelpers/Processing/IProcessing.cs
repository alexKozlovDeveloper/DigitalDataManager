using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DdmHelpers.Processing
{
    public interface IProcessing
    {
        void Process(string sourceImage, string destImage);
        string ProcessingName { get; set; }
    }
}
