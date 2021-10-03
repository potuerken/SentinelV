﻿using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Collections.Generic;

namespace Business.Concrete
{
    public class PersonelManager : IPersonelService
    {
        private readonly IPersonelDal _personelDal;
        private readonly IMapper _mapper;


        public PersonelManager(IPersonelDal personelDal, IMapper mapper)
        {
            _personelDal = personelDal;
            _mapper = mapper;
        }


        public IDataResult<List<PersonelDTO>> GetPersonelList()
        {
            var res = _personelDal.GetAll(a => a.AktifMi);
            List<PersonelDTO> listPersonel = _mapper.Map<List<PersonelDTO>>(res);
            return new SuccessDataResult<List<PersonelDTO>>(listPersonel);

        }
    }
}
