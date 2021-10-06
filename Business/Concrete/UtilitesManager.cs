using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Concrete
{
    public class UtilitesManager : IUtilitesService
    {
        private readonly IUtilitesDal _utilitesDal;
        private readonly IMapper _mapper;

        public UtilitesManager(IUtilitesDal utilitesDal, IMapper mapper)
        {
            _utilitesDal = utilitesDal;
            _mapper = mapper;
        }


        public IDataResult<List<KodDTO>> GetKodList(short kodTipId)
        {
            var result = _utilitesDal.GetAll(a => a.AktifMi && a.UstKodId == kodTipId);
            var dtoResult = _mapper.Map<List<KodDTO>>(result);
            return new DataResult<List<KodDTO>>(dtoResult, true);
        }


        public IResult KodAdded(KodDTO dto)
        {
            var dtoRequest = _mapper.Map<Kod>(dto);
            int ess = _utilitesDal.Add(dtoRequest);
            if (ess>0)
            {
                return new SuccessResult(dto.UstKodId.ToString() +" ekleme işlemi başarılı");
            }
            else
            {
                return new ErrorResult("ekleme işlemi başarısız");
            }
        }

    }
}
