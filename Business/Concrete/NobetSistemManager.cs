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

            var res = _nobetSistemDal.GetList(a => a.AktifMi, "NobetSistemRutbeIliski.RutbeKod,NobetSistemSabitNobetciIliski.SabitPersonel,NobetSistemSubeIliski.SubeKod,NobetSistemSabitNobetciIliski.SabitNobetSistemiKod");
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
            NobetSistem nobetSistem = _mapper.Map<NobetSistem>(dto);
            if (nobetSistem.NobetSistemRutbeIliski.Count == 0 || nobetSistem.NobetSistemSubeIliski.Count == 0)
            {
                return new ErrorResult("şube ve rütbe listesi aktarılamadı");
            }
            nobetSistem.AktifMi = true;
            var res = _nobetSistemDal.Add(nobetSistem).FirstOrDefault();
            int resto = res.Key;
            NobetSistem kaydolanKayit = res.Value;
            int subeSayisi = 0;
            int rutbeSayisi = 0;
            if (resto > 0)
            {
                if (nobetSistem.NobetSistemSubeIliski.Count > 0)
                {
                    foreach (var item in nobetSistem.NobetSistemSubeIliski)
                    {
                        item.AktifMi = true;
                        item.IlkKaydedenKullaniciId = kaydolanKayit.IlkKaydedenKullaniciId;
                        item.NobetSistemId = kaydolanKayit.Id;
                        subeSayisi += _nobetSistemSubeDal.Add(item).FirstOrDefault().Key;
                    }
                }
                if (nobetSistem.NobetSistemRutbeIliski.Count > 0)
                {
                    foreach (var item in nobetSistem.NobetSistemRutbeIliski)
                    {
                        item.AktifMi = true;
                        item.IlkKaydedenKullaniciId = kaydolanKayit.IlkKaydedenKullaniciId;
                        item.NobetSistemId = kaydolanKayit.Id;
                        rutbeSayisi += _nobetSistemRutbeDal.Add(item).FirstOrDefault().Key;
                    }
                }
                if (nobetSistem.NobetSistemRutbeIliski.Count != rutbeSayisi)
                    return new ErrorResult("rütbe ilişkileri oluşurken hata meydana geldi.");

                if (nobetSistem.NobetSistemSubeIliski.Count != subeSayisi)
                    return new ErrorResult("şube ilişkileri oluşurken hata meydana geldi.");
                return new SuccessResult("Nöbet Sistemi Eklenmiştir.");
            }
            else
                return new ErrorResult("Sorun meydana geldi.");
        }


        [ValidationAspect(typeof(NobetSistemValidator), Priority = 1)]
        [TransactionScopeAspect]
        public IResult NobetSistemUpdated(NobetSistemDTO dto)
        {
            NobetSistem dtoRequest = _mapper.Map<NobetSistem>(dto);
            dtoRequest.SonKaydedenKullaniciId = dto.SonKaydedenKullaniciId;
            dtoRequest.SonKayitTarihi = DateTime.Now;
            int ess = _nobetSistemDal.Update(dtoRequest);
            if (ess > 0)
            {
                int nobetSistemId = dtoRequest.Id;

                #region Rutbe Degisiklikleri
                var rutbeIliskisi = _nobetSistemRutbeDal.GetList(a => a.AktifMi && a.NobetSistemId == nobetSistemId).ToList();
                int sayacEklenecekR = 0;
                int sayacPasifEdilecekR = 0;
                int ss = dto.SonKaydedenKullaniciId.Value;

                foreach (var req in dtoRequest.NobetSistemRutbeIliski)
                {
                    foreach (var db in rutbeIliskisi)
                    {
                        if (req.RutbeKodId != db.RutbeKodId)
                        {
                            sayacEklenecekR++;
                            continue;
                        }
                    }
                    if (rutbeIliskisi.Count() == sayacEklenecekR)
                    {
                        NobetSistemRutbeIliski nobetSistemRutbe = new NobetSistemRutbeIliski
                        {
                            AktifMi = true,
                            IlkKaydedenKullaniciId = ss,
                            IlkKayitTarihi = DateTime.Now,
                            NobetSistemId = nobetSistemId,
                            RutbeKodId = req.RutbeKodId
                        };
                        int eSS = _nobetSistemRutbeDal.Add(nobetSistemRutbe).FirstOrDefault().Key;
                        if (eSS > 0)
                        {
                            eSS = 0;
                            sayacEklenecekR = 0;
                            continue;
                        }
                    }
                    sayacPasifEdilecekR = 0;
                }

                foreach (var db in rutbeIliskisi)
                {
                    foreach (var req in dtoRequest.NobetSistemRutbeIliski)
                    {
                        if (req.RutbeKodId != db.RutbeKodId)
                        {
                            sayacPasifEdilecekR++;
                            continue;
                        }
                    }
                    if (dtoRequest.NobetSistemRutbeIliski.Count() == sayacPasifEdilecekR)
                    {
                        db.AktifMi = false;
                        db.SonKaydedenKullaniciId = ss;
                        db.SonKayitTarihi = DateTime.Now;
                        int eSS = _nobetSistemRutbeDal.Update(db);
                        if (eSS > 0)
                        {
                            eSS = 0;
                            sayacPasifEdilecekR = 0;
                            continue;
                        }
                    }
                    sayacPasifEdilecekR = 0;
                }

                #endregion

                #region Sube Degisiklikleri
                var subeIliskisi = _nobetSistemSubeDal.GetList(a => a.AktifMi && a.NobetSistemId == nobetSistemId).ToList();
                int sayacEklenecekS = 0;
                int sayacPasifEdilecekS = 0;
                int ssS = dto.SonKaydedenKullaniciId.Value;

                foreach (var req in dtoRequest.NobetSistemSubeIliski)
                {
                    foreach (var db in subeIliskisi)
                    {
                        if (req.SubeKodId != db.SubeKodId)
                        {
                            sayacEklenecekS++;
                            continue;
                        }
                    }
                    if (subeIliskisi.Count() == sayacEklenecekS)
                    {
                        NobetSistemSubeIliski nobetSistemRutbe = new NobetSistemSubeIliski
                        {
                            AktifMi = true,
                            IlkKaydedenKullaniciId = ss,
                            IlkKayitTarihi = DateTime.Now,
                            NobetSistemId = nobetSistemId,
                            SubeKodId = req.SubeKodId
                        };
                        int eSS = _nobetSistemSubeDal.Add(nobetSistemRutbe).FirstOrDefault().Key;
                        if (eSS > 0)
                        {
                            eSS = 0;
                            sayacEklenecekS = 0;
                            continue;
                        }
                    }
                    sayacEklenecekS = 0;

                }

                foreach (var db in subeIliskisi)
                {
                    foreach (var req in dtoRequest.NobetSistemSubeIliski)
                    {
                        if (req.SubeKodId != db.SubeKodId)
                        {
                            sayacPasifEdilecekS++;
                            continue;
                        }
                    }
                    if (dtoRequest.NobetSistemRutbeIliski.Count() == sayacPasifEdilecekS)
                    {
                        db.AktifMi = false;
                        db.SonKaydedenKullaniciId = ss;
                        db.SonKayitTarihi = DateTime.Now;
                        int eSS = _nobetSistemSubeDal.Update(db);
                        if (eSS > 0)
                        {
                            eSS = 0;
                            sayacPasifEdilecekS = 0;
                            continue;
                        }
                    }
                    sayacPasifEdilecekS = 0;
                }

                #endregion

                return new SuccessResult("NÖBET SİSTEMİ BİLGİLERİ GÜNCELLENMİŞTİR.");

            }
            else
            {
                return new ErrorResult("NÖBET SİSTEMİ GÜNCELLEME İŞLEMİ SIRASINDA HATA MEYDANA GELDİ");
            }
        }


        [TransactionScopeAspect]
        public IResult NobetSistemSabitAdded(NobetSistemSabitNobetciIliskiDTO dto)
        {
            NobetSistemSabitNobetciIliski dtoRequest = _mapper.Map<NobetSistemSabitNobetciIliski>(dto);
            var res = _nobetSistemSabitNobetciDal.Add(dtoRequest).FirstOrDefault();
            int resto = res.Key;
            if (resto > 0)
            {
                return new SuccessResult("Sabit Nöbetçi Eklenmiştir.");
            }
            else
            {
                return new ErrorResult("Sorun meydana geldi.");

            }
        }
    }
}
