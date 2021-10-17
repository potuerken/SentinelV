using AutoMapper;
using Business.Abstract;
using Check.DTO;
using Core.Utilities.Results;
using DataAccess.Abstract;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using Entities.Models;
using Core.Aspects.Autofac.Validation;
using Business.ValidationRules.FluentValidation;
using System;
using DataAccess.Concrete.EntityFramework;
using Core.Aspects.Autofac.Transaction;

namespace Business.Concrete
{
    public class NobetSistemManager : INobetSistemService
    {
        private readonly INobetSistemiDal _nobetSistemDal;
        private readonly INobetSistemSabitNobetciDal _nobetSistemSabitNobetciDal;
        private readonly IMapper _mapper;
        private readonly INobetSistemRutbeIliskiDal _nobetSistemRutbeDal;
        private readonly INobetSistemSubeIliskiDal _nobetSistemSubeDal;


        public NobetSistemManager(INobetSistemiDal nobetSistemiDal, IMapper mapper, INobetSistemSabitNobetciDal nobetSistemSabitNobetciDal, INobetSistemRutbeIliskiDal nobetSistemRutbeIliskiDal, INobetSistemSubeIliskiDal nobetSistemSubeIliskiDal)
        {
            _nobetSistemDal = nobetSistemiDal;
            _mapper = mapper;
            _nobetSistemSabitNobetciDal = nobetSistemSabitNobetciDal;
            _nobetSistemSubeDal = nobetSistemSubeIliskiDal;
            _nobetSistemRutbeDal = nobetSistemRutbeIliskiDal;
        }

        public IDataResult<List<NobetSistemDTO>> GetNobetSistemList()
        {
            #region Orginal Code
            //var res = _nobetSistemDal.GetList(a => a.AktifMi, "NobetSistemRutbeIliski.RutbeKod,NobetSistemSabitNobetciIliski.PersonelDTO,NobetSistemSubeIliski.SubeKod");
            //List<NobetSistemDTO> listNobetSistemi = _mapper.Map<List<NobetSistemDTO>>(res);
            //return new SuccessDataResult<List<NobetSistemDTO>>(listNobetSistemi); 
            #endregion

            //var res = _nobetSistemDal.GetList(a => a.AktifMi && (a.NobetSistemRutbeIliski.Any(c=>c.AktifMi) && (a.NobetSistemSabitNobetciIliski.Any(d=>d.AktifMi)) && (a.NobetSistemSubeIliski.Any(f=>f.AktifMi))), "NobetSistemRutbeIliski.RutbeKod,NobetSistemSabitNobetciIliski.SabitPersonel,NobetSistemSubeIliski.SubeKod");

            var res = _nobetSistemDal.GetList(a => a.AktifMi, "NobetSistemRutbeIliski.RutbeKod,NobetSistemSabitNobetciIliski.SabitPersonel,NobetSistemSubeIliski.SubeKod");
            foreach (var item in res)
            {
                item.NobetSistemRutbeIliski = item.NobetSistemRutbeIliski.Where(a => a.AktifMi).ToList();
                item.NobetSistemSabitNobetciIliski = item.NobetSistemSabitNobetciIliski.Where(a => a.AktifMi).ToList();
                item.NobetSistemSubeIliski = item.NobetSistemSubeIliski.Where(a => a.AktifMi).ToList();
            }
            List<NobetSistemDTO> listNobetSistemi = _mapper.Map<List<NobetSistemDTO>>(res);
            return new SuccessDataResult<List<NobetSistemDTO>>(listNobetSistemi);
        }

        public IDataResult<List<PersonelDTO>> GetSabitNobetByNobetSistemId(int nobetSistemId)
        {
            var res = _nobetSistemSabitNobetciDal.GetList(a => a.AktifMi && a.NobetSistemId == nobetSistemId, "SabitPersonel");
            List<PersonelDTO> listSabitPersonel = new List<PersonelDTO>();
            foreach (var item in res)
            {
                listSabitPersonel.Add(_mapper.Map<PersonelDTO>(item.SabitPersonel));
            }
            if (listSabitPersonel.Count() > 0)
            {
                return new SuccessDataResult<List<PersonelDTO>>(listSabitPersonel, "Sabit Personel Listesi");
            }
            return new ErrorDataResult<List<PersonelDTO>>(null, "Sabit personel bulunamadı");
        }

        [ValidationAspect(typeof(NobetSistemValidator), Priority = 1)]
        [TransactionScopeAspect]
        public IResult NobetSistemAdded(NobetSistemDTO dto)
        {
            NobetSistem nS = _mapper.Map<NobetSistem>(dto);
            nS.AktifMi = true;
            var res = _nobetSistemDal.Add(nS).FirstOrDefault();
            int resto = res.Key;
            NobetSistem kaydolanKayit = res.Value;
            int subeSayisi = 0;
            int rutbeSayisi = 0;
            if (resto > 0)
            {
                if (nS.NobetSistemSubeIliski.Count > 0)
                {
                    foreach (var item in nS.NobetSistemSubeIliski)
                    {
                        item.AktifMi = true;
                        item.IlkKaydedenKullaniciId = kaydolanKayit.IlkKaydedenKullaniciId;
                        item.NobetSistemId = kaydolanKayit.Id;
                        subeSayisi += _nobetSistemSubeDal.Add(item).FirstOrDefault().Key;
                    }
                }
                if (nS.NobetSistemRutbeIliski.Count > 0)
                {
                    foreach (var item in nS.NobetSistemRutbeIliski)
                    {
                        item.AktifMi = true;
                        item.IlkKaydedenKullaniciId = kaydolanKayit.IlkKaydedenKullaniciId;
                        item.NobetSistemId = kaydolanKayit.Id;
                        rutbeSayisi += _nobetSistemRutbeDal.Add(item).FirstOrDefault().Key;
                    }
                }
                if (nS.NobetSistemRutbeIliski.Count != rutbeSayisi)
                    return new ErrorResult("rütbe ilişkileri oluşurken hata meydana geldi.");

                if (nS.NobetSistemSubeIliski.Count != subeSayisi)
                    return new ErrorResult("şube ilişkileri oluşurken hata meydana geldi.");
                return new SuccessResult("Nöbet Sistemi Eklenmiştir.");
            }
            else
                return new ErrorResult("Sorun meydana geldi.");
        }
    }
}
