using AutoMapper;
using Business.Abstract;
using Business.ValidationRules.FluentValidation;
using Check.DTO;
using Core.Aspects.Autofac.Transaction;
using Core.Aspects.Autofac.Validation;
using Core.Utilities.Results;
using DataAccess.Abstract;
using Entities.Models;
using System;
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

        [TransactionScopeAspect]
        public IDataResult<List<PersonelDTO>> GetPersonelList()
        {
            var res = _personelDal.GetList(a => a.AktifMi, "CinsiyetKod,RutbeKod,SubeKod");
            List<PersonelDTO> listPersonel = _mapper.Map<List<PersonelDTO>>(res);
            return new SuccessDataResult<List<PersonelDTO>>(listPersonel);
        }

        [TransactionScopeAspect]
        [ValidationAspect(typeof(PersonelValidator), Priority = 1)]
        public IResult PersonelAdded(PersonelDTO dto)
        {
            var dtoRequest = _mapper.Map<Personel>(dto);
            dtoRequest.AktifMi = true;
            dtoRequest.SonKaydedenKullaniciId = null;
            dtoRequest.IlkKayitTarihi = DateTime.Now;
            dtoRequest.IlkKaydedenKullaniciId = dto.IKKId;
            int ess = _personelDal.Add(dtoRequest);
            if (ess > 0)
            {
                return new SuccessResult("PERSONEL EKLEME İŞLEMİ BAŞARILI");
            }
            else
            {
                return new ErrorResult("PERSONEL EKLEME İŞLEMİ SIRASINDA HATA MEYDANA GELDİ");
            }
        }

        [ValidationAspect(typeof(PersonelValidator), Priority = 1)]
        public IResult PersonelUpdated(PersonelDTO dto)
        {
            Personel dtoRequest = _mapper.Map<Personel>(dto);
            dtoRequest.SonKaydedenKullaniciId = dto.SKKId;
            dtoRequest.SonKayitTarihi = DateTime.Now;
            int ess = _personelDal.Update(dtoRequest);
            if (ess > 0)
            {
                return new SuccessResult("PERSONEL BİLGİLERİ GÜNCELLENMİŞTİR.");

            }
            else
            {
                return new ErrorResult("PERSONEL BİLGİLERİ GÜNCELLEME İŞLEMİ SIRASINDA HATA MEYDANA GELDİ");
            }
        }

        public IResult PersonelDeleted(PersonelDTO dto)
        {
            //TODO: PERSONELIN ILISIGINI KESERKEN MUTLAKA NOBET VE CALISTAY KONTROLU EKLENMELI

            //var subedePersonelAny = _personelService.SubedePersonelVarmi(dto.Id);
            //if (subedePersonelAny.Success)
            //{
            //    return new ErrorResult(subedePersonelAny.Message + " BU YÜZDEN ŞUBE SİLME İŞLEMİ YAPILAMAZ.");
            //}
            var dbKod = _personelDal.Get(a => a.Id == dto.Id);
            dbKod.AktifMi = false;
            dbKod.SonKaydedenKullaniciId = dto.SKKId;
            dbKod.SonKayitTarihi = DateTime.Now;
            int ess = _personelDal.Update(dbKod);
            if (ess > 0)
                return new SuccessResult("SİLME İŞLEMİ BAŞARILI.");
            else
                return new ErrorResult("BİR HATA OLUŞTU VE ŞUBE SİLME İŞLEMİ BAŞARILI OLAMADI.");
        }

        public IResult SubedePersonelVarmi(int subeId)
        {
            var res = _personelDal.GetList(a => a.SubeKodId == subeId);
            if (res.Count == 0)
            {
                return new ErrorResult("ŞUBEDE PERSONEL BULUNMUYOR");
            }
            else
            {
                return new SuccessResult("ŞUBEDE PERSONEL BULUNMAKTA");
            }
        }
    }
}
