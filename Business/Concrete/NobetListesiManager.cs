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
using Check.Enum;

namespace Business.Concrete
{
    public class NobetListesiManager : INobetListesiService
    {
        private readonly INobetListesiDal _nobetListesiDal;
        private readonly INobetListesiDetayDal _nobetListesiDetayDal;
        private readonly IMapper _mapper;
        private readonly IOzelGunListesiDal _ozelGunListesiDal;
        private readonly IPersonelNobetDetayDal _personelNobetDetayDal;
        private readonly IPersonelDal _personelDal;


        public NobetListesiManager(INobetListesiDal nobetListesiDal, INobetListesiDetayDal nobetListesiDetayDal, IMapper mapper, IOzelGunListesiDal ozelGunListesiDal, IPersonelNobetDetayDal personelNobetDetayDal, IPersonelDal personelDal)
        {
            _nobetListesiDal = nobetListesiDal;
            _nobetListesiDetayDal = nobetListesiDetayDal;
            _mapper = mapper;
            _ozelGunListesiDal = ozelGunListesiDal;
            _personelNobetDetayDal = personelNobetDetayDal;
            _personelDal = personelDal;
        }

        [TransactionScopeAspect]

        public IDataResult<List<NobetListesiDTO>> GetNobetListesi()
        {
            var res = _nobetListesiDal.GetList(a => a.AktifMi, "NobetSistem");
            List<NobetListesiDTO> listNobetListesi = _mapper.Map<List<NobetListesiDTO>>(res);
            return new SuccessDataResult<List<NobetListesiDTO>>(listNobetListesi);
        }

        [TransactionScopeAspect]

        public IDataResult<List<NobetListesiDetayDTO>> GetNobetListesiDetay(int Id)
        {
            var res = _nobetListesiDetayDal.GetList(a => a.AktifMi && a.NobetListesiId == Id, "NobetListesi.NobetSistem,Personel.RutbeKod,Personel.SubeKod,TurKod");
            if (res.Count() > 0)
            {
                List<NobetListesiDetayDTO> listNobetListesi = _mapper.Map<List<NobetListesiDetayDTO>>(res);
                return new SuccessDataResult<List<NobetListesiDetayDTO>>(listNobetListesi);
            }
            var cres = NobetListesiOlusturma(Id);
            if (cres.Success)
            {
                return cres;
            }
            return new ErrorDataResult<List<NobetListesiDetayDTO>>();

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


        [TransactionScopeAspect]
        public IDataResult<List<NobetListesiDetayDTO>> NobetListesiOlusturma(int id)
        {
            var nobetListesi = _nobetListesiDal.GetList(a => a.AktifMi, "NobetSistem.NobetSistemSubeIliski,NobetSistem.NobetSistemRutbeIliski,NobetSistem.NobetSistemSabitNobetciIliski.SabitNobetSistemiKod,NobetSistem.NobetSistemSabitNobetciIliski.SabitPersonel").FirstOrDefault();
            List<int> subeler = nobetListesi.NobetSistem.NobetSistemSubeIliski.Select(a => a.SubeKodId).ToList();
            List<int> rutbeler = nobetListesi.NobetSistem.NobetSistemRutbeIliski.Select(a => a.RutbeKodId).ToList();
            List<NobetSistemSabitNobetciIliskiDTO> sabitler = _mapper.Map<List<NobetSistemSabitNobetciIliskiDTO>>(nobetListesi.NobetSistem.NobetSistemSabitNobetciIliski.ToList());

            var personelListesi = _personelDal.GetList(a => a.AktifMi == true, "SubeKod,RutbeKod").ToList();
            List<PersonelDTO> personelListesiDto = _mapper.Map<List<PersonelDTO>>(personelListesi);
            List<PersonelDTO> subeSuzmesi = new List<PersonelDTO>();
            List<PersonelDTO> rutbeSuzmesi = new List<PersonelDTO>();


            foreach (int sube in subeler)
            {
                subeSuzmesi.AddRange(personelListesiDto.Where(a => a.SubeKod.Id == sube).ToList());
            }

            foreach (int rutbe in rutbeler)
            {
                rutbeSuzmesi.AddRange(subeSuzmesi.Where(a => a.RutbeKod.Id == rutbe).ToList());
            }


            rutbeSuzmesi = rutbeSuzmesi.OrderByDescending(a => a.Sicil).ToList();

            foreach (var item in sabitler)
            {
                rutbeSuzmesi.Remove(item.SabitPersonel);
            }


            List<NobetListesiDetayDTO> result = new List<NobetListesiDetayDTO>();

            DateTime ayinIlkGunu = new DateTime(nobetListesi.Yil, nobetListesi.Ay, 1);
            DateTime ayinSonGunu = ayinIlkGunu.AddMonths(1).AddDays(-1);
            int gunSayisi = Convert.ToInt32((ayinSonGunu - ayinIlkGunu).TotalDays);
            gunSayisi = gunSayisi + 1;

            for (int i = 0; i < gunSayisi; i++)
            {
                if (ayinIlkGunu.DayOfWeek == DayOfWeek.Monday || ayinIlkGunu.DayOfWeek == DayOfWeek.Tuesday || ayinIlkGunu.DayOfWeek == DayOfWeek.Wednesday || ayinIlkGunu.DayOfWeek == DayOfWeek.Thursday || ayinIlkGunu.DayOfWeek == DayOfWeek.Friday)
                {
                    if (nobetListesi.NobetSistem.HaftaIciGunduzNobetciSayisi>0)
                    {
                        for (int j = 0; j < nobetListesi.NobetSistem.HaftaIciGunduzNobetciSayisi; j++)
                        {
                            result.Add(new NobetListesiDetayDTO
                            {
                                AktifMi = true,
                                NobetListesi = new NobetListesiDTO {Id = nobetListesi.Id },
                                IlkKaydedenKullaniciId = 4,
                                IlkKayitTarihi = DateTime.Now,
                                Tarih = ayinIlkGunu,
                                TurKod = new KodDTO
                                {
                                    Id = (short)NobetTuruEnum.Gunduz,
                                    SiraNo = 0
                                },
                                Saat = nobetListesi.NobetSistem.HaftaIciGunduzSaat
                            });
                        }
                    }
                    if (nobetListesi.NobetSistem.HaftaIciGeceNobetciSayisi > 0)
                    {
                        for (int k = 0; k < nobetListesi.NobetSistem.HaftaIciGeceNobetciSayisi; k++)
                        {
                            result.Add(new NobetListesiDetayDTO
                            {
                                NobetListesi = new NobetListesiDTO { Id = nobetListesi.Id },
                                AktifMi = true,
                                IlkKaydedenKullaniciId = 4,
                                IlkKayitTarihi = DateTime.Now,
                                Tarih = ayinIlkGunu,
                                TurKod = new KodDTO
                                {
                                    Id = (short)NobetTuruEnum.Gece,
                                    SiraNo = 1
                                },
                                Saat = nobetListesi.NobetSistem.HaftaIciGeceSaat
                            });
                        }
                    }
                    if (nobetListesi.NobetSistem.HaftaIciYedekNobetciOlacakMi)
                    {
                        result.Add(new NobetListesiDetayDTO
                        {
                            NobetListesi = new NobetListesiDTO { Id = nobetListesi.Id },
                            AktifMi = true,
                            IlkKaydedenKullaniciId = 4,
                            IlkKayitTarihi = DateTime.Now,
                            Tarih = ayinIlkGunu,
                            TurKod = new KodDTO
                            {
                                Id = (short)NobetTuruEnum.Yedek,
                                SiraNo = 2
                            },
                            Saat = nobetListesi.NobetSistem.HaftaIciGunduzSaat
                        });
                    }
                }
                else if (ayinIlkGunu.DayOfWeek == DayOfWeek.Saturday || ayinIlkGunu.DayOfWeek == DayOfWeek.Sunday)
                {
                    if (nobetListesi.NobetSistem.HaftaSonuGunduzNobetciSayisi > 0)
                    {
                        for (int l = 0; l < nobetListesi.NobetSistem.HaftaSonuGunduzNobetciSayisi; l++)
                        {
                            result.Add(new NobetListesiDetayDTO
                            {
                                NobetListesi = new NobetListesiDTO { Id = nobetListesi.Id },
                                AktifMi = true,
                                IlkKaydedenKullaniciId = 4,
                                IlkKayitTarihi = DateTime.Now,
                                Tarih = ayinIlkGunu,
                                TurKod = new KodDTO
                                {
                                    Id = (short)NobetTuruEnum.Gunduz,
                                    SiraNo = 0
                                },
                                Saat = nobetListesi.NobetSistem.HaftaSonuGunduzSaat
                            });
                        }
                    }
                    if (nobetListesi.NobetSistem.HaftaSonuGeceNobetciSayisi > 0)
                    {
                        for (int m = 0; m < nobetListesi.NobetSistem.HaftaSonuGeceNobetciSayisi; m++)
                        {
                            result.Add(new NobetListesiDetayDTO
                            {
                                NobetListesi = new NobetListesiDTO { Id = nobetListesi.Id },
                                AktifMi = true,
                                IlkKaydedenKullaniciId = 4,
                                IlkKayitTarihi = DateTime.Now,
                                Tarih = ayinIlkGunu,
                                TurKod = new KodDTO
                                {
                                    Id = (short)NobetTuruEnum.Gece,
                                    SiraNo = 1
                                },
                                Saat = nobetListesi.NobetSistem.HaftaSonuGeceSaat
                            });
                        }
                    }
                    if (nobetListesi.NobetSistem.HaftaSonuYedekNobetciOlacakMi)
                    {
                        result.Add(new NobetListesiDetayDTO
                        {
                            NobetListesi = new NobetListesiDTO { Id = nobetListesi.Id },
                            AktifMi = true,
                            IlkKaydedenKullaniciId = 4,
                            IlkKayitTarihi = DateTime.Now,
                            Tarih = ayinIlkGunu,
                            TurKod = new KodDTO
                            {
                                Id = (short)NobetTuruEnum.Yedek,
                                SiraNo = 2
                            },
                            Saat = nobetListesi.NobetSistem.HaftaSonuGunduzSaat
                        });
                    }
                }
                ayinIlkGunu = ayinIlkGunu.AddDays(1);
            }
            if (sabitler.Any(a=>a.SabitNobetSistemiKod.Id == (short)SabitNobetSistemiEnum.HaftaIciGunduz))
            {
                var haftaiciSabitler = sabitler.Where(a => a.SabitNobetSistemiKod.Id == (short)SabitNobetSistemiEnum.HaftaIciGunduz).ToList();
                if (nobetListesi.NobetSistem.HaftaIciGunduzNobetciSayisi < haftaiciSabitler.Count())
                {
                    return new ErrorDataResult<List<NobetListesiDetayDTO>>("sabit nöbetçiler hafta içi sınırını aşıyor.");
                }
                foreach (var gun in result)
                {
                    if (gun.TurKod.Id == (short)NobetTuruEnum.Gunduz && gun.Tarih.DayOfWeek == DayOfWeek.Monday || gun.Tarih.DayOfWeek == DayOfWeek.Tuesday || gun.Tarih.DayOfWeek == DayOfWeek.Wednesday || gun.Tarih.DayOfWeek == DayOfWeek.Thursday || gun.Tarih.DayOfWeek == DayOfWeek.Friday)
                    {
                        if (result.Any(a=>a.Tarih == gun.Tarih && a.Personel.Id > 0))
                        {
                            continue;
                        }
                        gun.Personel = haftaiciSabitler.FirstOrDefault().SabitPersonel;
                        continue;
                    }
                }
            }
            if (sabitler.Any(a => a.SabitNobetSistemiKod.Id == (short)SabitNobetSistemiEnum.BirArtiBirGece) && (nobetListesi.NobetSistem.HaftaIciGeceNobetciSayisi > 0 || nobetListesi.NobetSistem.HaftaSonuGeceNobetciSayisi > 0))
            {
                var gececiler = sabitler.Where(a => a.SabitNobetSistemiKod.Id == (short)SabitNobetSistemiEnum.BirArtiBirGece).ToList();
                
                if (gececiler.Count == 1)
                {
                    foreach (var gun in result)
                    {
                        if (gun.TurKod.Id == (short)NobetTuruEnum.Gece)
                        {
                            if (result.Any(a=>a.Personel.Id > 0 && (a.Tarih == gun.Tarih || a.Tarih == gun.Tarih.AddDays(1))))
                            {
                                continue;
                            }
                            gun.Personel = gececiler.FirstOrDefault().SabitPersonel;
                            continue;
                        }
                    }
                }
                if (gececiler.Count == 2)
                {
                    List<PersonelDTO> gececiTeam = new List<PersonelDTO>();
                    foreach (var item in gececiler)
                    {
                        gececiTeam.Add(item.SabitPersonel);
                    }
                    var gececi1 = gececiTeam.FirstOrDefault();
                    gececiTeam.Remove(gececi1);
                    var gececi2 = gececiTeam.FirstOrDefault();
                    bool bigunBiribigunBiri = false;
                    foreach (var gun in result)
                    {
                        if (gun.TurKod.Id == (short)NobetTuruEnum.Gece)
                        {
                            if (bigunBiribigunBiri)
                            {
                                gun.Personel = gececi2;
                                bigunBiribigunBiri = false;
                                continue;
                            }
                            gun.Personel = gececi1;
                            bigunBiribigunBiri = true;
                            continue;
                        }
                    }
                }
            }
            foreach (var gun in result)
            {
                if ((gun.Tarih.DayOfWeek == DayOfWeek.Sunday || gun.Tarih.DayOfWeek == DayOfWeek.Saturday) && gun.Personel.Id <=0 && gun.TurKod.Id == (short)NobetTuruEnum.Gunduz)
                {
                    gun.Personel = rutbeSuzmesi.OrderByDescending(a => a.Sicil).FirstOrDefault();
                    rutbeSuzmesi.Remove(gun.Personel);
                }
            }
            foreach (var gun in result)
            {
                if ((gun.Tarih.DayOfWeek == DayOfWeek.Friday || gun.Tarih.DayOfWeek == DayOfWeek.Monday || gun.Tarih.DayOfWeek == DayOfWeek.Thursday|| gun.Tarih.DayOfWeek == DayOfWeek.Tuesday || gun.Tarih.DayOfWeek == DayOfWeek.Wednesday) && gun.Personel.Id <= 0 && gun.TurKod.Id == (short)NobetTuruEnum.Gunduz)
                {
                    gun.Personel = rutbeSuzmesi.OrderByDescending(a => a.Sicil).FirstOrDefault();
                    rutbeSuzmesi.Remove(gun.Personel);
                }
            }

            if (nobetListesi.NobetSistem.HaftaSonuYedekNobetciOlacakMi)
            {
                foreach (var gun in result)
                {
                    if ((gun.Tarih.DayOfWeek == DayOfWeek.Sunday || gun.Tarih.DayOfWeek == DayOfWeek.Saturday) && gun.Personel.Id <= 0 && gun.TurKod.Id == (short)NobetTuruEnum.Yedek)
                    {
                        gun.Personel = rutbeSuzmesi.OrderByDescending(a => a.Sicil).FirstOrDefault();
                        rutbeSuzmesi.Remove(gun.Personel);
                    }
                }
            }
            if (nobetListesi.NobetSistem.HaftaIciYedekNobetciOlacakMi)
            {
                foreach (var gun in result)
                {
                    if ((gun.Tarih.DayOfWeek == DayOfWeek.Friday || gun.Tarih.DayOfWeek == DayOfWeek.Monday || gun.Tarih.DayOfWeek == DayOfWeek.Thursday || gun.Tarih.DayOfWeek == DayOfWeek.Tuesday || gun.Tarih.DayOfWeek == DayOfWeek.Wednesday) && gun.Personel.Id <= 0 && gun.TurKod.Id == (short)NobetTuruEnum.Yedek)
                    {
                        gun.Personel = rutbeSuzmesi.OrderByDescending(a => a.Sicil).FirstOrDefault();
                        rutbeSuzmesi.Remove(gun.Personel);
                    }
                }
            }

            int totalEss = 0;
            List<NobetListesiDetay> NobetListesiDetay = _mapper.Map<List<NobetListesiDetay>>(result);
            foreach (var item in NobetListesiDetay)
            {
                totalEss += _nobetListesiDetayDal.Add(item).FirstOrDefault().Key;
            }
            if (totalEss == result.Count())
            {
                return new SuccessDataResult<List<NobetListesiDetayDTO>>(result);
            }
            return new ErrorDataResult<List<NobetListesiDetayDTO>>();

        }
    }
}
