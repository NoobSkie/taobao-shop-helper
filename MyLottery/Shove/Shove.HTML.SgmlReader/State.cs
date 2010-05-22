using System;
using System.Collections.Generic;
using System.Text;

namespace Shove.HTML.SgmlReader
{
    internal enum State
    {
        Initial,   
        Markup,    
        EndTag,    
        Attr,     
        AttrValue,  
        Text,     
        PartialTag,
        AutoClose, 
        CData,     
        PartialText,
        PseudoStartTag,
        Eof
    }
}
