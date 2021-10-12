using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class NobetSistemManager : INobetSistemService
    {
        private readonly INobetSistemiDal _nobetSistemDal;
        private readonly IMapper _mapper;
        public NobetSistemManager(INobetSistemiDal nobetSistemiDal, IMapper mapper)
        {
            _nobetSistemDal = nobetSistemiDal;
            _mapper = mapper;
        }

        public IDataResult<List<NobetSistemDTO>> GetNobetSistemList()
        {
            #region Orginal Code
            //var res = _nobetSistemDal.GetList(a => a.AktifMi, "NobetSistemRutbeIliski.RutbeKod,NobetSistemSabitNobetciIliski.PersonelDTO,NobetSistemSubeIliski.SubeKod");
            //List<NobetSistemDTO> listNobetSistemi = _mapper.Map<List<NobetSistemDTO>>(res);
            //return new SuccessDataResult<List<NobetSistemDTO>>(listNobetSistemi); 
            #endregion

            var res = _nobetSistemDal.GetList(a => a.AktifMi, "NobetSistemRutbeIliski.RutbeKod,NobetSistemSabitNobetciIliski.PersonelDTO,NobetSistemSubeIliski.SubeKod");
            List<NobetSistemDTO> listNobetSistemi = _mapper.Map<List<NobetSistemDTO>>(res);
            return new SuccessDataResult<List<NobetSistemDTO>>(listNobetSistemi);

            //var rest = _nobetSistemDal.IncludeMultiple(a=>a.)

            //var query = context.Customers
            //       .IncludeMultiple(
            //           c => c.Address,
            //           c => c.Orders.Select(o => o.OrderItems));

        }



    }
}
