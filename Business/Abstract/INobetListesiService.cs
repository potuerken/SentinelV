using Check.DTO;
using Core.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface INobetListesiService
    {
        IDataResult<List<NobetListesiDTO>> GetNobetListesi();

        IResult NobetListeAdded(NobetListesiDTO dto);

        IDataResult<List<NobetListesiDetayDTO>> GetNobetListesiDetay(int Id);
    }
}
