using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectTPBD
{
    public class Angajat
    {
        public string Nume { get; set; }
        public string Prenume { get; set; }
        public string Functie { get; set; }
        public float Salar_baza { get; set; }
        public float Spor { get; set; }
        public float Premii_Brute { get; set; }
        public float Retineri { get; set; }

        public Angajat(string Nume, string Prenume, string Functie, float Salar_baza, float Spor, float Premii_Brute, float Retineri)
        {

            this.Nume = Nume;
            this.Prenume = Prenume;
            this.Functie = Functie;
            this.Salar_baza = Salar_baza;
            this.Spor = Spor;
            this.Premii_Brute = Premii_Brute;
            this.Retineri = Retineri;
        }

        public int CalculSalariuBrut()
        {
            return (int)(Salar_baza* (1 + Spor / 100) + Premii_Brute);   
        }
        public int CalculCAS()
        {
            return (int)(CalculSalariuBrut() * Procente.CAS);
        }
        public int CalculCASS()
        {
            return (int)(CalculSalariuBrut() * Procente.CASS);
        }
        public int BrutImpozitabil()
        {
            return (int)(CalculSalariuBrut() - CalculCAS() - CalculCASS());
        }
        public int CalculImpozit()
        {
            return (int)(BrutImpozitabil() * Procente.Impozit);
        }
        public int CalculViratCard()
        {
            return (int)(CalculSalariuBrut() - CalculImpozit() - CalculCAS() - CalculCASS() - Retineri);
        }
    }
}
