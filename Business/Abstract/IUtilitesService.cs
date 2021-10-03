using Check.DTO;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IUtilitesService
    {
        IDataResult<List<KodDTO>> GetKodList(short kodTipId);

    }
}
