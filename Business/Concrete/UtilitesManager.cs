using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Business.Concrete
{
    public class UtilitesManager : IUtilitesService
    {
        private readonly IPersonelService _personelService;
        private readonly IUtilitesDal _utilitesDal;
        private readonly IMapper _mapper;

        public UtilitesManager(IUtilitesDal utilitesDal, IMapper mapper, IPersonelService personelService)
        {
            _personelService = personelService;
            _utilitesDal = utilitesDal;
            _mapper = mapper;
        }


        public IDataResult<List<KodDTO>> GetKodList(short kodTipId)
        {
            var result = _utilitesDal.GetList(a => a.AktifMi && a.UstKodId == kodTipId);
            var dtoResult = _mapper.Map<List<KodDTO>>(result);
            return new DataResult<List<KodDTO>>(dtoResult, true);
        }


        public IResult KodAdded(KodDTO dto)
        {
            var dtoRequest = _mapper.Map<Kod>(dto);
            //dtoRequest.IlkKayitTarihi = DateTime.Now;
            dtoRequest.IlkKaydedenKullaniciId = dto.IlkKaydedenKullaniciId;
            dtoRequest.AktifMi = true;
            int resto = _utilitesDal.Add(dtoRequest).FirstOrDefault().Key;
            if (resto > 0)
            {
                return new SuccessResult("Şube ekleme işlemi başarılı");
            }
            else
            {
                return new ErrorResult("Şube ekleme işlemi başarısız");
            }
        }

        public IResult KodUpdated(KodDTO dto)
        {
            var dbKod = _utilitesDal.Get(a => a.Id == dto.Id);
            dbKod.Ad = dto.Ad;
            dbKod.SonKaydedenKullaniciId = dto.SonKaydedenKullaniciId;
            dbKod.SonKayitTarihi = DateTime.Now;
            int ess = _utilitesDal.Update(dbKod);
            if (ess > 0)
            {
                return new SuccessResult("Şube güncelleme işlemi başarılı");

            }
            else
            {
                return new ErrorResult("Şube güncelleme işlemi başarısız");
            }
        }

        public IResult KodDeleted(KodDTO dto)
        {
            var subedePersonelAny = _personelService.SubedePersonelVarmi(dto.Id);
            if (subedePersonelAny.Success)
            {
                return new ErrorResult(subedePersonelAny.Message+ " BU YÜZDEN ŞUBE SİLME İŞLEMİ YAPILAMAZ.");
            }
            var dbKod = _utilitesDal.Get(a => a.Id == dto.Id);
            dbKod.AktifMi =false;
            dbKod.SonKaydedenKullaniciId = dto.SonKaydedenKullaniciId;
            dbKod.SonKayitTarihi = DateTime.Now;
            int ess = _utilitesDal.Update(dbKod);
            if (ess > 0)
                return new SuccessResult(subedePersonelAny.Message + " SİLME İŞLEMİ BAŞARILI.");
            else
                return new ErrorResult("BİR HATA OLUŞTU VE ŞUBE SİLME İŞLEMİ BAŞARILI OLAMADI.");
        }
    }
}
