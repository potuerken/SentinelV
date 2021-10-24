using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Core.Aspects.Autofac.Transaction;
using Entities.Models;

namespace Business.Concrete
{
    public class NobetListesiManager : INobetListesiService
    {
        private readonly INobetListesiDal _nobetListesiDal;
        private readonly INobetListesiDetayDal _nobetListesiDetayDal;
        private readonly IMapper _mapper;
        private readonly IOzelGunListesiDal _ozelGunListesiDal;
        private readonly IPersonelNobetDetayDal _personelNobetDetayDal;


        public NobetListesiManager(INobetListesiDal nobetListesiDal, INobetListesiDetayDal nobetListesiDetayDal, IMapper mapper, IOzelGunListesiDal ozelGunListesiDal, IPersonelNobetDetayDal personelNobetDetayDal)
        {
            _nobetListesiDal = nobetListesiDal;
            _nobetListesiDetayDal = nobetListesiDetayDal;
            _mapper = mapper;
            _ozelGunListesiDal = ozelGunListesiDal;
            _personelNobetDetayDal = personelNobetDetayDal;
        }


        public IDataResult<List<NobetListesiDTO>> GetNobetListesi()
        {
            var res = _nobetListesiDal.GetList(a => a.AktifMi,"NobetSistem");
            List<NobetListesiDTO> listNobetListesi = _mapper.Map<List<NobetListesiDTO>>(res);
            return new SuccessDataResult<List<NobetListesiDTO>>(listNobetListesi);
        }


        public IDataResult<List<NobetListesiDetayDTO>> GetNobetListesiDetay(int Id)
        {
            var res = _nobetListesiDetayDal.GetList(a => a.AktifMi && a.NobetListesiId == Id);
            List<NobetListesiDetayDTO> listNobetListesi = _mapper.Map<List<NobetListesiDetayDTO>>(res);
            return new SuccessDataResult<List<NobetListesiDetayDTO>>(listNobetListesi);
        }



        [TransactionScopeAspect]
        public IResult NobetListeAdded(NobetListesiDTO dto)
        {
            NobetListesi nobetSistem = _mapper.Map<NobetListesi>(dto);
            var NobetListesiVarMi = _nobetListesiDal.GetList(a => a.AktifMi).ToList();
            bool varMi = NobetListesiVarMi.Any(a => a.Ay == dto.Ay && a.Yil == dto.Yil && a.NobetSistemId == dto.NobetSistem.Id);
            if (varMi)
            {
                return new ErrorResult("aynı nöbet listesi ile nöbet oluşturulamaz.");
            }

            nobetSistem.AktifMi = true;
            var res = _nobetListesiDal.Add(nobetSistem).FirstOrDefault().Key;
            if (res > 0)
            {
                return new SuccessResult("Nöbet Listesi Eklendi");
            }
            else
            {
                return new ErrorResult("nöbet listesi eklenirken hata meydana geldi");
            }
        }
    }
}
