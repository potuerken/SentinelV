using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Aspects.Autofac.Transaction;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Business.Concrete
{
    public class IzinMazeretManager : IIzinMazeretService
    {

        private readonly IIzinMazeretDal _izinMazeretDal;
        private readonly IMapper _mapper;


        public IzinMazeretManager(IIzinMazeretDal izinMazeretDal, IMapper mapper)
        {
            _izinMazeretDal = izinMazeretDal;
            _mapper = mapper;
        }


        public IDataResult<List<IzinMazeretDTO>> GetIzinList()
        {
            var res = _izinMazeretDal.GetList(a => a.AktifMi, "IzinMazeretKod,Personel");
            List<IzinMazeretDTO> listIzin = _mapper.Map<List<IzinMazeretDTO>>(res);
            return new SuccessDataResult<List<IzinMazeretDTO>>(listIzin);
        }


        [TransactionScopeAspect]
        public IResult IzinAdded(IzinMazeretDTO dto)
        {
            var dtoRequest = _mapper.Map<IzinMazeret>(dto);
            dtoRequest.AktifMi = true;
            dtoRequest.IlkKaydedenKullaniciId = dto.IlkKaydedenKullaniciId;
            dtoRequest.IlkKayitTarihi = DateTime.Now;
            dtoRequest.PersonelId = dto.Personel.Id;
            dtoRequest.IzinMazeretKodId = dto.IzinMazeretKod.Id;
            var ess = _izinMazeretDal.Add(dtoRequest).FirstOrDefault().Key;
            if (ess > 0)
            {
                return new SuccessResult("izin eklendi");
            }
            else
            {
                return new SuccessResult("izin eklenirken hata meydana geldi");

            }
        }
    }
}
