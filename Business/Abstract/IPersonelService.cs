using Check.DTO;
using Core.Utilities.Results; 
using System.Collections.Generic;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        IDataResult<List<PersonelDTO>> GetPersonelList();
        IResult SubedePersonelVarmi(int subeId);

        IResult PersonelAdded(PersonelDTO dto);

        IResult PersonelUpdated(PersonelDTO dto);

    }
}
