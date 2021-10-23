using Check.DTO;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IIzinMazeretService
    {
        IDataResult<List<IzinMazeretDTO>> GetIzinList();

        IResult IzinAdded(IzinMazeretDTO dto);

    }
}
