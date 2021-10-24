using System;
using System.Collections.Generic;
using System.Text;

namespace Check.Enum
{
    public enum KodTipEnum
    {
        Rutbe = 1,
        Sube = 9,
        Cinsiyet = 16,
        SabitNobetSistemi = 36,
        IzinMazeretSebebi = 39,
        NobetTuru = 47

    }


    public enum SubeEnum
    {
        ArGeSubeMudurlugu = 10,
        SilahSubeMudurlugu = 11,
        PatlayiciIslemlerSubeMudurlugu = 12,
        IdariIslerSubeMudurlugu = 13,
        EgitimSubeMudurlugu = 14,
        SirketlerSubeMudurlugu = 15
    }
    public enum NobetTuruEnum
    {
        Gece = 48,
        Gunduz = 49,
        Yedek = 50
    }

    public enum SabitNobetSistemiEnum
    {
        HaftaIciGunduz = 37,
        BirArtiBirGece = 38
    }
    
    
}
