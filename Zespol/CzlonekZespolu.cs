using System;
using System.Buffers;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace Zespol
{
    public enum EnumFunkcja { programista, menedżer, grafik, tester, lider }
    public class CzlonekZespolu : Osoba, ICloneable
    {
        #region Fields
        DateTime dataWstapienia;
        EnumFunkcja? funkcjaWZespole;
        #endregion Fields

        #region Properties
        [DataMember]
        public DateTime DataWstapienia { get => dataWstapienia; set => dataWstapienia = value; }
        [DataMember]
        public EnumFunkcja? FunkcjaWZespole { get => funkcjaWZespole; set => funkcjaWZespole = value; }
        #endregion Properties

        #region Constructors
        public CzlonekZespolu() : base()
        { }
        public CzlonekZespolu(string imie, string nazwisko, EnumPlec plec)
            : base(imie, nazwisko, plec)
        { }
        public CzlonekZespolu(string imie, string nazwisko, string dataUrodzenia,
            string pesel, EnumPlec plec, DateTime dataWstapienia, string funkcjaWZespole)
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            DataWstapienia = dataWstapienia;
            if (Enum.TryParse(typeof(EnumFunkcja), funkcjaWZespole, out object? f))
            {
                FunkcjaWZespole = (EnumFunkcja)f;
            }
        }
        #endregion Constructors

        #region Methods
        public override string ToString()
        {
            return $"{base.ToString()}, {FunkcjaWZespole} [{DataWstapienia:MM-yyyy}]";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion Methods
    }
}
