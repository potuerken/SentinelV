using Check.DTO;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface INobetSistemService
    {
        IDataResult<List<NobetSistemDTO>> GetNobetSistemList();

        //IResult NobetSistemAdded(NobetSistemDTO dto);

        //IResult NobetSistemUpdated(NobetSistemDTO dto);
    }
}
