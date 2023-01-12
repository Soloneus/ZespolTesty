using System.Runtime.Serialization;
using System.Text;

namespace Zespol
{
    class PeselComparator : IComparer<CzlonekZespolu>
    {
        public int Compare(CzlonekZespolu? x, CzlonekZespolu? y)
        {
            if (x is null) { return 1; }
            if (y is null) { return -1; }
            return x.Pesel.CompareTo(y.Pesel); ;
        }
    }
    interface IZapisywalna
    {
        void ZapiszDC(string fname);
    }

    [DataContract]
    [KnownType(typeof(CzlonekZespolu))]
    [KnownType(typeof(KierownikZespolu))]
    public class Zespol : ICloneable, IZapisywalna
    {
        #region Fields
        string nazwaZespolu;
        KierownikZespolu kierownik;
        List<CzlonekZespolu> czlonkowieZespolu;
        #endregion Fields

        #region Properties
        [DataMember]
        public string NazwaZespolu { get => nazwaZespolu; set => nazwaZespolu = value; }
        [DataMember]
        public KierownikZespolu Kierownik { get => kierownik; set => kierownik = value; }
        [DataMember]
        public List<CzlonekZespolu> CzlonkowieZespolu { get => czlonkowieZespolu; set => czlonkowieZespolu = value; }
        #endregion Properties

        #region Constructors
        public Zespol()
        {
            CzlonkowieZespolu = new();
        }
        public Zespol(string nazwaZespolu, KierownikZespolu kierownik)
            : this()
        {
            NazwaZespolu = nazwaZespolu;
            Kierownik = kierownik;
        }
        #endregion Constructors

        #region Methods
        public void DodajCzlonka(CzlonekZespolu c)
        {
            if (c is null) { return; }
            CzlonkowieZespolu.Add(c);
        }
        public void UsunCzlonka(string pesel)
        {
            CzlonkowieZespolu.RemoveAll(cz => cz.Pesel == pesel);
        }
        public void UsunWszystkichCzlonkow()
        {
            CzlonkowieZespolu.Clear();
        }
        public List<CzlonekZespolu> WyszukajFunkcja(string funkcja)
        {
            return CzlonkowieZespolu.FindAll(cz => cz.FunkcjaWZespole.ToString() == funkcja);
        }
        public List<CzlonekZespolu> WyszukajFunkcja(int miesiac)
        {
            return CzlonkowieZespolu.FindAll(cz => cz.DataWstapienia.Month == miesiac);
        }
        public void SortujNazwiskoImie()
        {
            CzlonkowieZespolu.Sort();
        }
        public void SortujPesel()
        {
            CzlonkowieZespolu.Sort(new PeselComparator());
        }
        public void SortujFunkcja()
        {
            CzlonkowieZespolu = CzlonkowieZespolu.OrderBy(cz => cz.FunkcjaWZespole).ToList();
        }
        public void SortujDataWstapienia()
        {
            CzlonkowieZespolu.Sort((x, y) => x.DataWstapienia.CompareTo(y.DataWstapienia));
        }
        public override string ToString()
        {
            StringBuilder sb = new();
            sb.AppendLine($"Zespół: {NazwaZespolu}");
            sb.AppendLine($"Kierownik: {Kierownik}");
            sb.AppendLine($"Członkowie: {new string('-', 50)}");
            CzlonkowieZespolu.ForEach(cz => sb.AppendLine(cz.ToString()));
            return sb.ToString();
        }
        public object? Clone()
        {
            DataContractSerializer dc = new(typeof(Zespol));
            using MemoryStream ms = new();
            dc.WriteObject(ms, this);
            ms.Seek(0, SeekOrigin.Begin);
            return dc.ReadObject(ms);
        }
        public void ZapiszDC(string fname)
        {
            using FileStream fs = new(fname, FileMode.Create);
            DataContractSerializer dc = new(typeof(Zespol));
            dc.WriteObject(fs, this);
        }
        public static Zespol? OdczytDC(string fname)
        {
            if (!File.Exists(fname)) { return null; }
            using FileStream fs = new(fname, FileMode.Open);
            DataContractSerializer dc = new(typeof(Zespol));
            return dc.ReadObject(fs) as Zespol;
        }
        #endregion Methods
    }
}
