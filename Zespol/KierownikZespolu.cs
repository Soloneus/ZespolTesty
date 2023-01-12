using System.Runtime.Serialization;

namespace Zespol
{
    [DataContract]
    public class KierownikZespolu : Osoba, ICloneable
    {
        #region Fields
        [DataMember]
        int doswiadczenieKierownicze; // liczba przepracowanych lat
        [DataMember]
        long telefonKontaktowy;
        #endregion Fields

        #region Constructors
        public KierownikZespolu() { }
        public KierownikZespolu(string imie, string nazwisko, EnumPlec plec)
            : base(imie, nazwisko, plec)
        { }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia,
            string pesel, EnumPlec plec)
            : base(imie, nazwisko, dataUrodzenia, pesel, plec)
        { }
        public KierownikZespolu(string imie, string nazwisko, string dataUrodzenia,
            string pesel, EnumPlec plec, int doswiadczenie, long telefon)
            : this(imie, nazwisko, dataUrodzenia, pesel, plec)
        {
            doswiadczenieKierownicze = doswiadczenie;
            telefonKontaktowy = telefon;
        }
        #endregion Constructors

        #region Methods
        public override string ToString()
        {
            return $"{base.ToString()}, {doswiadczenieKierownicze}, [{telefonKontaktowy:000-000-000}]";
        }
        public object Clone()
        {
            return MemberwiseClone();
        }
        #endregion Methods
    }
}
