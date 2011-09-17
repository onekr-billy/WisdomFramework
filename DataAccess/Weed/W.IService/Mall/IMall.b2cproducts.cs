using System.Collections.Generic;
using W.Entity.Mall;

namespace W.Service
{
    public partial interface IMall
    {
        
        List<B2cproduct> GetProductByClassId();

    }
}
