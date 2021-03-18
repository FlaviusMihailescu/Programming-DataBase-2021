using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.ManagedDataAccess;
using Oracle.ManagedDataAccess.Client;
using System.Data.SqlClient;
using System.Data.OleDb;

namespace ProjectTPBD
{
    public partial class Form1 : Form
    {
        OleDbConnection conn = new OleDbConnection("Provider=MSDAORA;Data Source=xe;Persist Security Info=True;Password=student;User ID=student");

        OleDbCommand cmd;
        OleDbDataAdapter da;
        DataSet ds;
        string str;
        int i;
        bool DataError = false;

        private void Functie_tb_TextChanged(object sender, EventArgs e)
        {
            if (!String.IsNullOrEmpty(Functie_tb.Text))
            {
                check_functie_lbl.ForeColor = Color.Green;
                check_functie_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            else
            {
                check_functie_lbl.ForeColor = Color.Red;
                check_functie_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati completat corect toate campurile";
            }
        }


        public void Afisare()
        {
            {
                try
                {
                    string strAlfabetic = "SELECT * FROM ANGAJATI order by nume";
                    string strNr_crt = "SELECT * FROM ANGAJATI order by Nr_crt";
                    if (sortare_cbox.Text.Equals("Nume"))
                    {
                        da = new OleDbDataAdapter(strAlfabetic, conn);
                    }
                    else
                    {
                        if (sortare_cbox.Text.Equals("Nr_crt"))
                        {
                            da = new OleDbDataAdapter(strNr_crt, conn);
                        }
                    }
                    // ** Fill DataSet
                    ds = new DataSet();
                    da.Fill(ds, "angajati");
                    dataGridView1.DataSource = ds.Tables["angajati"];
                }
                catch
                {
                    MessageBox.Show("Eroare de afisare!");
                }
            }
        }

        public void AfisareProcente()
        {
            try
            {
                string strProcente = "SELECT * FROM PROCENTE";

                OleDbDataAdapter oda= new OleDbDataAdapter(strProcente, conn);
                DataTable dt = new DataTable();
                oda.Fill(dt);
                cas_procent_tb.Text =  dt.Rows[0][0].ToString();
                cass_procent_tb.Text = dt.Rows[0][1].ToString();
                impozit_procent_tb.Text = dt.Rows[0][2].ToString();

                //ds = new DataSet();
                //da.Fill(ds, "procente");
                //dataGridView1.DataSource = ds.Tables["procente"];
            }
            catch
            {
                MessageBox.Show("Eroare de afisare procente!");
            }
        }

        private void Stergere_date_btn_Click(object sender, EventArgs e)
        {
            Nume_tb.Clear();
            Prenume_tb.Clear();
            Functie_tb.Clear();
            Salar_baza_tb.Clear();
            //Spor_tb.Clear();
            //Premii_Brute_tb.Clear();
            //Retineri_tb.Clear();
            Total_brut_tb.Clear();
            Brut_impozitabil_tb.Clear();
            Impozit_tb.Clear();
            CAS_tb.Clear();
            CASS_tb.Clear();
            Virat_card_tb.Clear();
            Nume_tb.Focus();

        }

        private void anulare_stergere_btn_Click(object sender, EventArgs e)
        {
            nume_cautat_tb.Clear();
        }

        private void Prenume_tb_TextChanged(object sender, EventArgs e)
        {
            if (!Prenume_tb.Text.Equals(""))
            {
                check_prenume_lbl.ForeColor = Color.Green;
                check_prenume_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            else
            {
                check_prenume_lbl.ForeColor = Color.Red;
                check_prenume_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati completat corect toate campurile";
            }
        }

        private void Nr_crt_tb_TextChanged(object sender, EventArgs e)
        {

        }

        private void Nume_tb_TextChanged(object sender, EventArgs e)
        {
            if (!Nume_tb.Text.Equals(""))
            {
                check_nume_lbl.ForeColor = Color.Green;
                check_nume_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            else
            {
                check_nume_lbl.ForeColor = Color.Red;
                check_nume_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati completat corect toate campurile";
            }
        }

        private void Spor_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(Spor_tb.Text);
                check_spor_lbl.ForeColor = Color.Green;
                check_spor_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            catch
            {
                check_spor_lbl.ForeColor = Color.Red;
                check_spor_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati completat corect toate campurile";
                Spor_tb.Clear();
                Spor_tb.Focus();
            }
        }

        private void Premii_Brute_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(Premii_Brute_tb.Text);
                check_premii_brute_lbl.ForeColor = Color.Green;
                check_premii_brute_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            catch
            {
                check_premii_brute_lbl.ForeColor = Color.Red;
                check_premii_brute_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati introdus o valoare numerica";
                Premii_Brute_tb.Clear();
                Premii_Brute_tb.Focus();
            }
        }

        private void Retineri_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(Retineri_tb.Text);
                check_retineri_lbl.ForeColor = Color.Green;
                check_retineri_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            catch
            {
                check_retineri_lbl.ForeColor = Color.Red;
                check_retineri_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati introdus o valoare numerica";
                Retineri_tb.Clear();
                Retineri_tb.Focus();
            }
        }

        private void Salar_baza_tb_TextChanged(object sender, EventArgs e)
        {
            try
            {
                Int32.Parse(Salar_baza_tb.Text);
                check_salar_baza_lbl.ForeColor = Color.Green;
                check_salar_baza_lbl.Text = "OK";
                check_lbl.Text = "";
                hint_lbl.Text = "";
            }
            catch
            {
                check_salar_baza_lbl.ForeColor = Color.Red;
                check_salar_baza_lbl.Text = "Error";
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca ati introdus o valoare numerica";
                Salar_baza_tb.Clear();
                Salar_baza_tb.Focus();
            }
        }

        public Form1()
        {
            InitializeComponent();

        }

        private void Calcul_taxe_btn_Click(object sender, EventArgs e)
        {
            try
            {
                Angajat angajat = new Angajat( Nume_tb.Text, Prenume_tb.Text, Functie_tb.Text, float.Parse(Salar_baza_tb.Text), float.Parse(Spor_tb.Text), float.Parse(Premii_Brute_tb.Text), float.Parse(Retineri_tb.Text));

                Total_brut_tb.Text = angajat.CalculSalariuBrut().ToString();
                CAS_tb.Text = angajat.CalculCAS().ToString();
                CASS_tb.Text = angajat.CalculCASS().ToString();
                Brut_impozitabil_tb.Text = angajat.BrutImpozitabil().ToString();
                Impozit_tb.Text = angajat.CalculImpozit().ToString();
                Virat_card_tb.Text = angajat.CalculViratCard().ToString();
            }
            catch
            {
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Asigurati-va ca toate campurile au fost completate in mod corect";
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Va rugam, introduceti datele angajatului!");
        }

        private void Introducere_BD_btn_Click(object sender, EventArgs e)
        {
            Calcul_taxe_btn_Click(sender, e);
            try
            {
                conn.Open();

                //int nr = int.Parse(Nr_crt_tb.Text);
                string nume = Nume_tb.Text;
                string prenume = Prenume_tb.Text;
                string functie = Functie_tb.Text;
                int salar_baza = int.Parse(Salar_baza_tb.Text);
                int spor = int.Parse(Spor_tb.Text);
                int premii = int.Parse(Premii_Brute_tb.Text);
                int total = int.Parse(Total_brut_tb.Text);
                int brut_imp = int.Parse(Brut_impozitabil_tb.Text);
                int impozit = int.Parse(Impozit_tb.Text);
                int cas = int.Parse(CAS_tb.Text);
                int cass = int.Parse(CASS_tb.Text);
                int retineri = int.Parse(Retineri_tb.Text);
                int virat_card = int.Parse(Virat_card_tb.Text);

                //str = "insert into ANGAJATI values('" + nr + "','" + nume + "','" + prenume + "','" + functie + "','" + salar_baza + "','" + spor + "','" + premii + "','" + total + "','" + brut_imp + "','" + impozit + "','" + cas + "','" + cass + "','" + retineri + "','" + virat_card + "')";
                str = "insert into ANGAJATI values(0, '" + nume + "','" + prenume + "','" + functie + "','" + salar_baza + "','" + spor + "','" + premii + "','" + total + "','" + brut_imp + "','" + impozit + "','" + cas + "','" + cass + "','" + retineri + "','" + virat_card + "')";


                cmd = new OleDbCommand(str, conn);
                i = cmd.ExecuteNonQuery();
                Afisare();

                check_lbl.ForeColor = Color.Green;
                check_lbl.Text = "Adaugare Reusita";
                hint_lbl.Text = "";
                Generare_Raport();
                Generare_Fluturasi();
            }
            //catch when (!IsEmpty())
            //{
            //    check_lbl.ForeColor = Color.Red;
            //    check_lbl.Text = "Eroare de adaugare";
            //    hint_lbl.Text = "Hint: Este posibil ca Angajatul sa existe deja in baza de date";
            //}
            catch when (IsEmpty())
            {
                check_lbl.ForeColor = Color.Red;
                check_lbl.Text = "Eroare de introducere a datelor";
                hint_lbl.Text = "Hint: Completati toate campurile inainte de adaugare";
            }
            finally
            {
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }
        }


        private bool IsEmpty()
        {
            if (Nume_tb.Text.Equals("") || 
                Prenume_tb.Text.Equals("") || 
                Functie_tb.Text.Equals("") || 
                Salar_baza_tb.Text.Equals("") || 
                Spor_tb.Text.Equals("") || 
                Premii_Brute_tb.Text.Equals("") || 
                Retineri_tb.Text.Equals(""))
            {
                return true;
            }
            return false;
        }

        /*private void profilPicture_btn_Click(object sender, EventArgs e)
        {
            String imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "jpg files(*.jpg)|*.jpg| PNG files(*.png)|*.png| AllFiles(*.*)|*.*";
                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    poza_profil.ImageLocation = imageLocation;
                }
            }
            catch(Exception)
            {
                MessageBox.Show("Asigurati-va ca formatul imaginii alese este corect!", "Eroare incarcare imagine", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }*/

        public void AsignareProcente()
        {
            Procente.CAS = float.Parse(cas_procent_tb.Text);
            Procente.CASS = float.Parse(cass_procent_tb.Text);
            Procente.Impozit = float.Parse(impozit_procent_tb.Text);
        }
        private void Form1_Load_1(object sender, EventArgs e)
        {
            sortare_cbox.Text = "Nr_crt";
            try
            {
                AfisareProcente();
                AsignareProcente();
                Afisare();
                conn.Open();
                data_lbl.Text = "Connected to: " + conn.DataSource;
                server_lbl.Text = "Server: " + conn.ServerVersion;
                conn.Close();
                Generare_Raport();
                Generare_Fluturasi(); 

            }
            catch
            {
                check_lbl.Text = "Eroare de conectare";
                hint_lbl.Text = "Hint: Verificati conexiunea la internet!";
            }
            Spor_tb.Text = 0.ToString();
            Premii_Brute_tb.Text = 0.ToString(); 
            Retineri_tb.Text = 0.ToString();



        }


        private void nume_sters_tb_TextChanged(object sender, EventArgs e)
        {
            check_actualizare_lbl.Text = "";
            hint_actualizare_lbl.Text = "";
            string searchValue = nume_cautat_tb.Text;
            int rowIndex = -1;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            try
            {
                foreach (DataGridViewRow row in dataGridView1.Rows)
                {
                    if (row.Cells[1].Value.ToString().ToUpper().Contains(searchValue.ToUpper()))
                    {
                        sortare_cbox.Text = "Nume";
                        rowIndex = row.Index;
                        dataGridView1.ClearSelection();
                        row.Selected = true;
                        dataGridView1.FirstDisplayedScrollingRowIndex = rowIndex;
                        dataGridView1.CurrentCell = dataGridView1.Rows[rowIndex].Cells[0];
                        dataGridView1.Focus();
                        nume_cautat_tb.Focus();
                        check_stergere_lbl.ForeColor = Color.Green;
                        check_stergere_lbl.Text = "";
                        hint_stergere_lbl.Text = "";
                        CompletareCampuriActualizbile();
                        break;
                    }
                }
            }
            catch
            {
                check_stergere_lbl.ForeColor = Color.Red;
                check_stergere_lbl.Text = "Eroare de cautare";
                hint_stergere_lbl.Text = "Hint: Asigurati-va ca angajatul cautat exista in baza de date";
            }

        }
        public void CompletareCampuriActualizbile()
        {
            nume_act_tb.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            prenume_act_tb.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            functie_act_tb.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            salar_baza_act_tb.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
            spor_act_tb.Text = dataGridView1.CurrentRow.Cells[5].Value.ToString();
            premii_brute_act_tb.Text = dataGridView1.CurrentRow.Cells[6].Value.ToString();
            retineri_act_tb.Text = dataGridView1.CurrentRow.Cells[12].Value.ToString();
        }

        private void stergere_btn_Click_1(object sender, EventArgs e)
        {

            DialogResult dialog = MessageBox.Show("Doriti stergere?", "Stergere", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                if (ds.Tables["angajati"].Rows.Count > 0)
                {
                    int rownum = (dataGridView1.CurrentCell.RowIndex);
                    dataGridView1.Rows.RemoveAt(rownum);
                    DataRow Linie = ds.Tables["angajati"].Rows[rownum];
                    Linie.Delete();
                    //nume_sters_tb_TextChanged(sender, e);
                }
                else
                {
                    hint_stergere_lbl.Text = "Hint: Cautati un angajat existent!";
                }
                nume_cautat_tb.Clear();
            }

        }

        private void salvare_btn_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Aceasta operatiune poate genera modificari la nivelul bazei de date \n\t           Sunteti sigur ca doriti acest lucru?",
                "Salvare", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                OleDbCommandBuilder comanda = new OleDbCommandBuilder(da);
                da.Update(ds.Tables["angajati"]);
                sortare_cbox.Text = "Nr_crt";
                Generare_Raport();
                Generare_Fluturasi();
            }
        }

        private void anulare_stergere_btn_Click_1(object sender, EventArgs e)
        {
            nume_cautat_tb.Clear();
            //if (sortare_cbox.Text.Equals("Nr_crt"))
                sortare_cbox.Text = "Nume";
            //else
            //    sortare_cbox.Text = "Nr_crt";

        }

        private void sortare_cbox_SelectedIndexChanged(object sender, EventArgs e)
        {
            Afisare();
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            CompletareCampuriActualizbile();
            check_actualizare_lbl.Text = "";
            hint_actualizare_lbl.Text = "";
        }

        private void actualizare_btn_Click(object sender, EventArgs e)
        {
            DataError = false;
            if (nume_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[1].Value.ToString()) &
                prenume_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[2].Value.ToString()) &
                functie_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[3].Value.ToString()) &
                salar_baza_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[4].Value.ToString()) &
                spor_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[5].Value.ToString()) &
                premii_brute_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[6].Value.ToString()) &
                retineri_act_tb.Text.Equals(dataGridView1.CurrentRow.Cells[12].Value.ToString()))
            {

                check_actualizare_lbl.ForeColor = Color.Red;
                check_actualizare_lbl.Text = "Eroare de actualizare";
                hint_actualizare_lbl.Text = "Hint: Asigurati-va ca ati modificat cel putin un camp al angajatului";
            }
            else
            {
                dataGridView1.CurrentRow.Cells[1].Value = nume_act_tb.Text;
                dataGridView1.CurrentRow.Cells[2].Value = prenume_act_tb.Text;
                dataGridView1.CurrentRow.Cells[3].Value = functie_act_tb.Text;
                dataGridView1.CurrentRow.Cells[4].Value = salar_baza_act_tb.Text;
                dataGridView1.CurrentRow.Cells[5].Value = spor_act_tb.Text;
                dataGridView1.CurrentRow.Cells[6].Value = premii_brute_act_tb.Text;

                dataGridView1.CurrentRow.Cells[12].Value = retineri_act_tb.Text;

                if (!DataError)
                {
                    check_actualizare_lbl.ForeColor = Color.Green;
                    check_actualizare_lbl.Text = "Actualizare reusita";
                    hint_actualizare_lbl.Text = "";
                    CalculAngajat();
                }
                else
                {
                    check_actualizare_lbl.ForeColor = Color.Red;
                    check_actualizare_lbl.Text = "Eroare de introducere a datelor";
                    hint_actualizare_lbl.Text = "Hint: Asigurati-va ca ati introdus corect datele de modificare";
                }

            }

        }

        private void CalculAngajat()
        {
            Angajat angajat = new Angajat(dataGridView1.CurrentRow.Cells[1].Value.ToString(),
                                        dataGridView1.CurrentRow.Cells[2].Value.ToString(),
                                        dataGridView1.CurrentRow.Cells[3].Value.ToString(),
                                        float.Parse(dataGridView1.CurrentRow.Cells[4].Value.ToString()),
                                        float.Parse(dataGridView1.CurrentRow.Cells[5].Value.ToString()),
                                        float.Parse(dataGridView1.CurrentRow.Cells[6].Value.ToString()),
                                        float.Parse(dataGridView1.CurrentRow.Cells[12].Value.ToString()));

            dataGridView1.CurrentRow.Cells[7].Value = angajat.CalculSalariuBrut().ToString();
            dataGridView1.CurrentRow.Cells[8].Value = angajat.BrutImpozitabil().ToString();
            dataGridView1.CurrentRow.Cells[9].Value = angajat.CalculImpozit().ToString();
            dataGridView1.CurrentRow.Cells[10].Value = angajat.CalculCAS().ToString();
            dataGridView1.CurrentRow.Cells[11].Value = angajat.CalculCASS().ToString();
            dataGridView1.CurrentRow.Cells[13].Value = angajat.CalculViratCard().ToString();
        }

        private void CalculAngajati()
        {
            for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
            {
                Angajat angajat = new Angajat(dataGridView1.Rows[i].Cells[1].Value.ToString(),
                                            dataGridView1.Rows[i].Cells[2].Value.ToString(),
                                            dataGridView1.Rows[i].Cells[3].Value.ToString(),
                                            float.Parse(dataGridView1.Rows[i].Cells[4].Value.ToString()),
                                            float.Parse(dataGridView1.Rows[i].Cells[5].Value.ToString()),
                                            float.Parse(dataGridView1.Rows[i].Cells[6].Value.ToString()),
                                            float.Parse(dataGridView1.Rows[i].Cells[12].Value.ToString()));

                dataGridView1.Rows[i].Cells[7].Value = angajat.CalculSalariuBrut().ToString();
                dataGridView1.Rows[i].Cells[8].Value = angajat.BrutImpozitabil().ToString();
                dataGridView1.Rows[i].Cells[9].Value = angajat.CalculImpozit().ToString();
                dataGridView1.Rows[i].Cells[10].Value = angajat.CalculCAS().ToString();
                dataGridView1.Rows[i].Cells[11].Value = angajat.CalculCASS().ToString();
                dataGridView1.Rows[i].Cells[13].Value = angajat.CalculViratCard().ToString();
            }
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            DataError = true;
        }

        private void parola_tb_TextChanged(object sender, EventArgs e)
        {
            check_salvare_procente_lbl.Text = "";
            if(parola_tb.Text == "1234")
            {
                cas_procent_tb.ReadOnly = false;
                cass_procent_tb.ReadOnly = false;
                impozit_procent_tb.ReadOnly = false;
                check_parola_lbl.Text = "Introduceti noile date procentuale:";
            }
            else
            {
                cas_procent_tb.ReadOnly = true;
                cass_procent_tb.ReadOnly = true;
                impozit_procent_tb.ReadOnly = true;
                check_parola_lbl.Text = "";
            }
        }

        private void salvare_procente_btn_Click(object sender, EventArgs e)
        {

            try
            {
                conn.Open();
                str = "UPDATE Procente SET cas_procent = '" + float.Parse(cas_procent_tb.Text) + "', cass_procent = '" + float.Parse(cass_procent_tb.Text) + "', impozit_procent = '" + float.Parse(impozit_procent_tb.Text) + "' ";
                cmd = new OleDbCommand(str, conn);
                i = cmd.ExecuteNonQuery();

                AsignareProcente();
                CalculAngajati();

                salvare_btn_Click(sender, e);

                check_salvare_procente_lbl.ForeColor = Color.Green;
                check_salvare_procente_lbl.Text = "Salvat!";
            }
            catch
            {
                check_salvare_procente_lbl.ForeColor = Color.Red;
                check_salvare_procente_lbl.Text = "Eroare de salvare!";
            }
            finally
            {
                parola_tb.Clear();
                if (conn.State == ConnectionState.Open)
                    conn.Close();
            }

        }

        private void abandonare_procente_btn_Click(object sender, EventArgs e)
        {
            AfisareProcente();
            parola_tb.Clear();
            check_salvare_procente_lbl.Text = "";
        }

        private void Date_procentuale_tab_Click(object sender, EventArgs e)
        {
            parola_tb.Focus();
            nume_cautat_tb.Focus();
            Nume_tb.Focus();
        }

        private void salar_baza_act_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender,e);
        }

        private void spor_act_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender,e);
        }
        private void PreventieIntroducereGresita(object sender, KeyPressEventArgs e)
        {
            if ((!char.IsNumber(e.KeyChar)) && (!char.IsControl(e.KeyChar)) && (e.KeyChar != '*') && (e.KeyChar != '.'))
                e.Handled = true;
        }

        private void premii_brute_act_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender, e);
        }

        private void retineri_act_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender, e);
        }

        private void cas_procent_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender, e);
        }

        private void cass_procent_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender, e);
        }

        private void impozit_procent_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            PreventieIntroducereGresita(sender, e);
        }

        private void Generare_Raport()
        {
            try
            {
                str = "SELECT * FROM angajati ";
                da = new OleDbDataAdapter(str, conn);
                ds = new DataSet();
                da.Fill(ds, "angajati");
                dataGridView1.DataSource = ds.Tables["angajati"];
            }
            catch
            {
                MessageBox.Show("Eroare de conectare raport");
            }
            CrystalReport1 raport = new CrystalReport1();
            raport.SetDataSource(ds.Tables["angajati"]);
            crystalReportViewer1.ReportSource = raport;

        }
        private void Generare_Fluturasi()
        {
            try
            {
                str = "SELECT * FROM angajati ";
                da = new OleDbDataAdapter(str, conn);
                ds = new DataSet();
                da.Fill(ds, "angajati");
                dataGridView1.DataSource = ds.Tables["angajati"];
            }
            catch
            {
                MessageBox.Show("Eroare de conectare raport");
            }
            CrystalReport2 raport = new CrystalReport2();
            raport.SetDataSource(ds.Tables["angajati"]);
            crystalReportViewer2.ReportSource = raport;

        }


        BindingSource bindingSource1 = new BindingSource();
        private void nume_fluturas_tb_TextChanged(object sender, EventArgs e)
        {
            //DataView dv = new DataView();
            //int loc = bindingSource1.Find("nume", nume_fluturas_tb.Text);

            //dv.Sort = "nume DESC"; // optional
            //bindingSource1.Sort = "nume";
            //bindingSource1.DataSource = ds.Tables["angajati"];
            ////bindingNavigator1.BindingSource = bindingSource1;
            //dataGridView1.DataSource = bindingSource1;

            check_nume_fluturas_lbl.Text = "";

        }

        private void cautare_fluturas_btn_Click(object sender, EventArgs e)
        {

                crystalReportViewer2.SelectionFormula = "{angajati.nume}='" + nume_fluturas_tb.Text.ToString() + "'";

                crystalReportViewer2.Refresh();
                crystalReportViewer2.RefreshReport();
                nume_fluturas_tb.Focus();

        }

        private void anulare_fluturas_btn_Click(object sender, EventArgs e)
        {
            crystalReportViewer2.SelectionFormula.Remove(0);
            Generare_Fluturasi();
            Generare_Fluturasi();
            nume_fluturas_tb.Text = "";
        }

      
    }
}