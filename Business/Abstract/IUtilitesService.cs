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

        IResult KodAdded(KodDTO dto);

        IResult KodUpdated(KodDTO dto);

        IResult KodDeleted(KodDTO dto);
    }
}
