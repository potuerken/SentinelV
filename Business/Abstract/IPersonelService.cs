using Core.Utilities.Results;
using Entities.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Abstract
{
    public interface IPersonelService
    {
        IDataResult<List<PersonelDTO>> GetPersonelList();
    }
}
