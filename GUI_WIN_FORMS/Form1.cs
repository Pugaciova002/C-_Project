using System;
using Cont;
using Tabel;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI_WIN_FORMS
{
    public partial class Form1 : Form
    {

        Fisier_Tabel fisier;
        //  $"{Tabel.ID[i]}.    Nume : {Temp.Nume} Prenume : {Temp.Prenume} Lot : {Temp.Lotul} " 

        private Label lblID;
        private Label lblNume;
        private Label lblPrenume;
        private Label lblLot;

        private Label lblReg_Suc;
        private Label lblReg_Bot;
        private Label lblData_Start;
        private Label lblData_END;


        private Label[] LBLID;
        private Label[] LBLNume;
        private Label[] LBLPrenume;
        private Label[] LBLLot;

        private Label[] LBLReg_Suc;
        private Label[] LBLReg_Bot;
        private Label[] LBLData_Start;
        private Label[] LBLData_END;

        private Label lblAdaugare;

        private Label lblIntr_Nume;
        private Label lblIntr_PreNume;
        private Label lblIntr_Lot;
        private Label lblIntr_Suceava;
        private Label lblIntr_Botosani;
        private Label lblIntr_Start;
        private Label lblIntr_End;


        private Label Control_Nume;
        private Label Control_Prenume;
        private Label Control_Lot;
        private Label Control_Reg_Suc;
        private Label Control_Reg_Bot;
        private Label Control_Data_Start;
        private Label Control_Data_End;


        private TextBox txtNume;
        private TextBox txtPrenume;
        private TextBox txtLot;
        private TextBox txtReg_Suc;
        private TextBox txtReg_Bot;
        private TextBox txtReg_Start;
        private TextBox txtReg_End;


        private Button btnFinalizeaza;
        private Button btnRefresh;


        private const int LATIME_CONTROL = 100;
        private const int DIMENSIUNE_PAS_Y = 30;
        private const int DIMENSIUNE_PAS_X = 120;




        public Form1()
        {
            InitializeComponent();

            string numeFisier = ConfigurationManager.AppSettings["NumeFisier"];
            string locatieFisierSolutie = Directory.GetParent(System.IO.Directory.GetCurrentDirectory()).Parent.Parent.FullName;
            string caleCompletaFisier = locatieFisierSolutie + "\\" + numeFisier;

            fisier = new Fisier_Tabel(caleCompletaFisier);
            int ACCS_count = 0;

            Account[] ACCS = fisier.GetAccounts(out ACCS_count);

            // Fereastra principala

            this.Size = new Size(500, 500);
            this.StartPosition = FormStartPosition.Manual;
            this.Location = new Point(100, 100);
            this.Font = new Font("Arial", 9, FontStyle.Bold);
            this.ForeColor = Color.LimeGreen;
            this.Text = "Tabel General";

            // Caseta ID
            int i = 1;

            lblID = new Label();
            lblID.Width = LATIME_CONTROL;
            lblID.Text = "ID";
            lblID.Left = i++ * DIMENSIUNE_PAS_X;
            lblID.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblID);


            // Caseta Nume

            lblNume = new Label();
            lblNume.Width = LATIME_CONTROL;
            lblNume.Text = "Nume";
            lblNume.Left = i++ * DIMENSIUNE_PAS_X;
            lblNume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblNume);


            // Caseta Prenume

            lblPrenume = new Label();
            lblPrenume.Width = LATIME_CONTROL;
            lblPrenume.Text = "Prenume";
            lblPrenume.Left = i++ * DIMENSIUNE_PAS_X;
            lblPrenume.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblPrenume);

            // Caseta Lotul

            lblLot = new Label();
            lblLot.Width = LATIME_CONTROL;
            lblLot.Text = "Lotul";
            lblLot.Left = i++ * DIMENSIUNE_PAS_X;
            lblLot.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblLot);


            int Latime_Plus = 100;

            lblReg_Suc = new Label();
            lblReg_Suc.Width = LATIME_CONTROL;
            lblReg_Suc.Text = "Suceava";
            lblReg_Suc.Left = i++ * DIMENSIUNE_PAS_X;
            lblReg_Suc.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblReg_Suc);


            lblReg_Bot = new Label();
            lblReg_Bot.Width = LATIME_CONTROL;
            lblReg_Bot.Text = "Botosani";
            lblReg_Bot.Left = i++ * DIMENSIUNE_PAS_X + Latime_Plus;
            lblReg_Bot.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblReg_Bot);


            lblData_Start = new Label();
            lblData_Start.Width = LATIME_CONTROL;
            lblData_Start.Text = "Start";
            lblData_Start.Left = i++ * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblData_Start.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblData_Start);


            lblData_END = new Label();
            lblData_END.Width = LATIME_CONTROL;
            lblData_END.Text = "End";
            lblData_END.Left = i++ * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblData_END.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblData_END);

            //      Adaugare Cont

            int const_Adaugare = i;
            int Y_DImension = 1;

            lblAdaugare = new Label();
            lblAdaugare.Width = LATIME_CONTROL;
            lblAdaugare.Text = "Adaugare:";
            lblAdaugare.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus + 50;
            lblAdaugare.ForeColor = Color.DarkGreen;
            this.Controls.Add(lblAdaugare);

            // Adaugare Nume

            lblIntr_Nume = new Label();
            lblIntr_Nume.Width = LATIME_CONTROL;
            lblIntr_Nume.Text = "Nume";
            lblIntr_Nume.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_Nume.ForeColor = Color.DarkGreen;
            lblIntr_Nume.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_Nume);

            txtNume = new TextBox();
            txtNume.Width = LATIME_CONTROL;
            txtNume.Left = DIMENSIUNE_PAS_X;

            txtNume.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtNume.Top = Y_DImension * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtNume);

            // Control Nume

            Control_Nume = new Label();
            Control_Nume.Width = LATIME_CONTROL;
            Control_Nume.Text = "Introdu Caseta";
            Control_Nume.Left = (const_Adaugare + 2) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            Control_Nume.ForeColor = Color.Red;
            Control_Nume.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;


            // Adaugare Prenume

            lblIntr_PreNume = new Label();
            lblIntr_PreNume.Width = LATIME_CONTROL;
            lblIntr_PreNume.Text = "Prenume";
            lblIntr_PreNume.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_PreNume.ForeColor = Color.DarkGreen;
            lblIntr_PreNume.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_PreNume);

            txtPrenume = new TextBox();
            txtPrenume.Width = LATIME_CONTROL;
            txtPrenume.Left = DIMENSIUNE_PAS_X;

            txtPrenume.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtPrenume.Top = Y_DImension * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtPrenume);

            // Control Prenume

            Control_Prenume = new Label();
            Control_Prenume.Width = LATIME_CONTROL;
            Control_Prenume.Text = "Introdu Caseta";
            Control_Prenume.Left = (const_Adaugare + 2) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            Control_Prenume.ForeColor = Color.Red;
            Control_Prenume.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;


            // Adaugare Lot

            lblIntr_Lot = new Label();
            lblIntr_Lot.Width = LATIME_CONTROL;
            lblIntr_Lot.Text = "Lot";
            lblIntr_Lot.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_Lot.ForeColor = Color.DarkGreen;
            lblIntr_Lot.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_Lot);

            txtLot = new TextBox();
            txtLot.Width = LATIME_CONTROL;
            txtLot.Left = DIMENSIUNE_PAS_X;

            txtLot.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtLot.Top = Y_DImension * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtLot);


            // Control  Lot

            Control_Lot = new Label();
            Control_Lot.Width = LATIME_CONTROL;
            Control_Lot.Text = "Introdu Caseta";
            Control_Lot.Left = (const_Adaugare + 2) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            Control_Lot.ForeColor = Color.Red;
            Control_Lot.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;

            // Adaugare Regiuni Suceava

            lblIntr_Suceava = new Label();
            lblIntr_Suceava.Width = LATIME_CONTROL;
            lblIntr_Suceava.Text = "Regs Suceava";
            lblIntr_Suceava.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_Suceava.ForeColor = Color.DarkGreen;
            lblIntr_Suceava.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_Suceava);

            txtReg_Suc = new TextBox();
            txtReg_Suc.Width = LATIME_CONTROL;
            txtReg_Suc.Left = DIMENSIUNE_PAS_X;

            txtReg_Suc.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtReg_Suc.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtReg_Suc);

            // Adaugare Regiuni Botosani

            lblIntr_Botosani = new Label();
            lblIntr_Botosani.Width = LATIME_CONTROL;
            lblIntr_Botosani.Text = "Regs Botosani";
            lblIntr_Botosani.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_Botosani.ForeColor = Color.DarkGreen;
            lblIntr_Botosani.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_Botosani);

            txtReg_Bot = new TextBox();
            txtReg_Bot.Width = LATIME_CONTROL;
            txtReg_Bot.Left = DIMENSIUNE_PAS_X;

            txtReg_Bot.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtReg_Bot.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtReg_Bot);

            // Adaugare data start

            lblIntr_Start = new Label();
            lblIntr_Start.Width = LATIME_CONTROL;
            lblIntr_Start.Text = "Data Start";
            lblIntr_Start.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_Start.ForeColor = Color.DarkGreen;
            lblIntr_Start.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_Start);

            txtReg_Start = new TextBox();
            txtReg_Start.Width = LATIME_CONTROL;
            txtReg_Start.Left = DIMENSIUNE_PAS_X;

            txtReg_Start.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtReg_Start.Top = Y_DImension * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtReg_Start);

            // Control  Lot

            Control_Data_Start = new Label();
            Control_Data_Start.Width = LATIME_CONTROL;
            Control_Data_Start.Text = "Introdu Caseta";
            Control_Data_Start.Left = (const_Adaugare + 2) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            Control_Data_Start.ForeColor = Color.Red;
            Control_Data_Start.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;

            // Adaugare data End

            lblIntr_End = new Label();
            lblIntr_End.Width = LATIME_CONTROL;
            lblIntr_End.Text = "Data End";
            lblIntr_End.Left = const_Adaugare * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            lblIntr_End.ForeColor = Color.DarkGreen;
            lblIntr_End.Top = Y_DImension * DIMENSIUNE_PAS_Y;
            this.Controls.Add(lblIntr_End);

            txtReg_End = new TextBox();
            txtReg_End.Width = LATIME_CONTROL;
            txtReg_End.Left = DIMENSIUNE_PAS_X;

            txtReg_End.Left = (const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            txtReg_End.Top = Y_DImension * DIMENSIUNE_PAS_Y;

            this.Controls.Add(txtReg_End);


            // Control  Lot

            Control_Data_End = new Label();
            Control_Data_End.Width = LATIME_CONTROL;
            Control_Data_End.Text = "Introdu Caseta";
            Control_Data_End.Left = (const_Adaugare + 2) * DIMENSIUNE_PAS_X + 2 * Latime_Plus;
            Control_Data_End.ForeColor = Color.Red;
            Control_Data_End.Top = Y_DImension++ * DIMENSIUNE_PAS_Y;




            // butonul de Finalizare a adaugarii


            btnFinalizeaza = new Button();
            btnFinalizeaza.Width = LATIME_CONTROL;
            btnFinalizeaza.Location = new System.Drawing.Point((const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus, Y_DImension * DIMENSIUNE_PAS_Y);
            btnFinalizeaza.Text = "Finalizeaza Adaugare";

            btnFinalizeaza.Click += OnButtonClick;


            this.Controls.Add(btnFinalizeaza);

            btnRefresh = new Button();
            btnRefresh.Width = LATIME_CONTROL;
            btnRefresh.Location = new System.Drawing.Point((const_Adaugare + 1) * DIMENSIUNE_PAS_X + 2 * Latime_Plus, Y_DImension * DIMENSIUNE_PAS_Y + 100);
            btnRefresh.Text = "Refresh";

            btnRefresh.Click += RefreshClick;


            this.Controls.Add(btnRefresh);



        }
       
        private void RefreshClick(object sender, EventArgs e)
        {
            AfiseazaStudenti();
        }



        private void OnButtonClick (object sender, EventArgs e)
        {
            bool valid_all = true;
            bool valid_nume = true;
            bool valid_prenume = true;
            bool valid_lot = true;
            bool valid_start = true;
            bool valid_end = true;
           
            string nume = txtNume.Text;

            if (nume == "")
            {
                this.Controls.Add(Control_Nume);
                valid_nume = false;
            }
            else
                this.Controls.Remove(Control_Nume);

            if (nume.Length > 15)
            {
                valid_nume = false;
                txtNume.BackColor = Color.Red;

            }
            else
                txtNume.BackColor = Color.White;


            string prenume = txtPrenume.Text;

            if (prenume == "")
            {
                this.Controls.Add(Control_Prenume);
                valid_prenume = false;
            }
            else
                this.Controls.Remove(Control_Prenume);

            if (prenume.Length > 15)
            {
                valid_prenume = false;
                txtPrenume.BackColor = Color.Red;
            }
            else txtPrenume.BackColor = Color.White;



            string lot = txtLot.Text;
            int verificare;

            if (lot == "")
            {
                this.Controls.Add(Control_Lot);
                valid_lot = false;
            }
            else
                this.Controls.Remove(Control_Lot);

            if (Int32.TryParse(lot,out verificare) == false)
            {
                valid_lot = false;
                txtLot.BackColor = Color.Red;
            }
            else txtLot.BackColor = Color.White;


            string start = txtReg_Start.Text;
            DateTime TeSt;

            if (start == "")
            {
                this.Controls.Add(Control_Data_Start);
                valid_start = false;
            }
            else
                this.Controls.Remove(Control_Data_Start);

            if (DateTime.TryParse(start, out TeSt) == false)
            {
                valid_start = false;
                txtReg_Start.BackColor = Color.Red;
            }
            else txtReg_Start.BackColor = Color.White;


            string end = txtReg_End.Text;
            DateTime TeEn;

            if (end == "")
            {
                this.Controls.Add(Control_Data_End);
                valid_end = false;
            }
            else
                this.Controls.Remove(Control_Data_End);

            if (DateTime.TryParse(end, out TeSt) == false)
            {
                valid_start = false;
                txtReg_End.BackColor = Color.Red;
            }
            else txtReg_End.BackColor = Color.White;

            valid_all = valid_nume && valid_prenume && valid_lot && valid_start && valid_end;
            if (valid_all == true)
            {
                string Reg_Suc = txtReg_Suc.Text;
                string Reg_Bot = txtReg_Bot.Text;

                Account ac = new Account("null","null","null","1.1.2021",nume,prenume, verificare, "null");
                ac.Adaugare_Inchiriere(Reg_Suc, Reg_Bot,start,end);

                fisier.Add_Rent_Entity(ac);

                txtNume.Text = "";
                this.Controls.Add(txtNume);

                txtPrenume.Text = "";
                this.Controls.Add(txtPrenume);

                txtLot.Text = "";
                this.Controls.Add(txtLot);

                txtReg_Suc.Text = "";
                this.Controls.Add(txtReg_Suc);

                txtReg_Bot.Text = "";
                this.Controls.Add(txtReg_Bot);
               
                txtReg_End.Text = "";
                this.Controls.Add(txtReg_End);
                
                txtReg_Start.Text = "";
                this.Controls.Add(txtReg_Start);
                AfiseazaStudenti();
            }

        }




        private void Form_Load(object sender, EventArgs e)
        {
            
            AfiseazaStudenti();
        }



        private void AfiseazaStudenti()
        {
            Account[] ACCS = fisier.GetAccounts(out int nrACC);

            LBLID = new Label[nrACC];
            LBLNume = new Label[nrACC];
            LBLPrenume = new Label[nrACC];
            LBLLot = new Label[nrACC];

            LBLReg_Suc = new Label[nrACC];
            LBLReg_Bot = new Label[nrACC];
            LBLData_Start = new Label[nrACC];
            LBLData_END = new Label[nrACC];

            int i = 0;


            foreach(Account account in ACCS) 
            {
                int X_Multiplier = 1;
                LBLID[i] = new Label();
                LBLID[i].Width = LATIME_CONTROL;
                LBLID[i].Text = i.ToString();
                LBLID[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X;
                LBLID[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLID[i]);


                LBLNume[i] = new Label();
                LBLNume[i].Width = LATIME_CONTROL;
                LBLNume[i].Text = account.Nume;
                LBLNume[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X;
                LBLNume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLNume[i]);


                LBLPrenume[i] = new Label();
                LBLPrenume[i].Width = LATIME_CONTROL;
                LBLPrenume[i].Text = account.Prenume;
                LBLPrenume[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X;
                LBLPrenume[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLPrenume[i]);


                LBLLot[i] = new Label();
                LBLLot[i].Width = LATIME_CONTROL;
                LBLLot[i].Text = account.Lotul.ToString();
                LBLLot[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X;
                LBLLot[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLLot[i]);


                int Latime_Plus = 100;

                LBLReg_Suc[i] = new Label();
                LBLReg_Suc[i].Width = LATIME_CONTROL + Latime_Plus;
                LBLReg_Suc[i].Text = account.lst[0].Suc.ToString();
                LBLReg_Suc[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X ;
                LBLReg_Suc[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLReg_Suc[i]);


                LBLReg_Bot[i] = new Label();
                LBLReg_Bot[i].Width = LATIME_CONTROL + 100;
                LBLReg_Bot[i].Text = account.lst[0].Bot.ToString();
                LBLReg_Bot[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X + Latime_Plus;
                LBLReg_Bot[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLReg_Bot[i]);


                LBLData_Start[i] = new Label();
                LBLData_Start[i].Width = LATIME_CONTROL;
                LBLData_Start[i].Text = account.lst[0].Start_Rent.ToString();
                LBLData_Start[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X + 2*Latime_Plus;
                LBLData_Start[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLData_Start[i]);


                LBLData_END[i] = new Label();
                LBLData_END[i].Width = LATIME_CONTROL;
                LBLData_END[i].Text = account.lst[0].End_Rent.ToString();
                LBLData_END[i].Left = X_Multiplier++ * DIMENSIUNE_PAS_X + 2*Latime_Plus;
                LBLData_END[i].Top = (i + 1) * DIMENSIUNE_PAS_Y;
                this.Controls.Add(LBLData_END[i]);

                i++;
                X_Multiplier = 0;
            }


        }



    }
}
