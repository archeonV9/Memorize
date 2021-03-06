﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Memorize
{
    public partial class Form1 : Form
    {

        static string adresPlikuPL;
        int currentIndex = 0;
        private bool isStarted;

        int TogMove;
        int MValX;
        int MValY;



        Nauka nowaNauka = new Nauka();

        public Form1()
        {
            InitializeComponent();
            nazwaPlikuLabel.Visible = false;
            slowkaAngTextBox.Visible = false;
            slowkaPlTextBox.Visible = false;
            startNaukiBtn.Visible = false;
            wiemBtn.Visible = false;
            nieWiemBtn.Visible = false;
            odpPlLabel.Visible = false;
            pytanieAngielskie.Visible = false;
            odpPlLabel.Visible = false;




        }

        private void Form1_Load(object sender, EventArgs e)
        {
            materialyPanel.Visible = false;
            naukaPanel.Visible = false;
        }






        private void homeBtn_Click(object sender, EventArgs e)
        {
            materialyPanel.Visible = false;
        }

        private void naukaBtn_Click(object sender, EventArgs e)
        {
            materialyPanel.Visible = true;
        }





        private void wczytajPlikTxtBtn_Click(object sender, EventArgs e)
        {
            isStarted = true;
            OpenFileDialog PLopenFileDialog = new OpenFileDialog();
            PLopenFileDialog.Filter = "Text Files|*.txt";
            if (PLopenFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {

                if (PLopenFileDialog.OpenFile() != null)
                {
                    var fileProcesor = new FileReader();
                    fileProcesor.Czytaj(PLopenFileDialog.FileName);
                    adresPlikuPL = PLopenFileDialog.FileName;
                    slowkaAngTextBox.Lines = FileReader.slowkaANG.ToArray();
                    slowkaPlTextBox.Lines = FileReader.slowkaPL.ToArray();

                    nazwaPlikuLabel.Visible = true;
                    nazwaPlikuLabel.Text = Path.GetFileName(adresPlikuPL);
                    slowkaAngTextBox.Visible = true;
                    slowkaPlTextBox.Visible = true;
                    wczytajTxtLabel.Visible = false;
                    startNaukiBtn.Visible = true;
                    infoLabel1.Visible = false;
                    infoLabel2.Visible = false;

                }
            }
        }

        private void startNaukiBtn_Click(object sender, EventArgs e)
        {
            naukaPanel.Visible = true;
            pytanieAngielskie.Text = FileReader.slowkaANG[currentIndex];
            odpPlLabel.Text = FileReader.slowkaPL[currentIndex];
            pytanieAngielskie.Visible = true;
            liczbaPytan.Text = FileReader.slowkaANG.Count.ToString();
            aktualnyNrPytania.Text = currentIndex.ToString();
            podsumowanieNaukiPanel.Visible = false;

        }

        private void wiemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentIndex == FileReader.slowkaANG.Count - 1)
                {


                    liczbaSlowekLabel.Text = FileReader.slowkaANG.Count.ToString();
                    nowaNauka.slowkaNIEZNAM.Add(FileReader.slowkaANG[currentIndex]);
                    aktualnyNrPytania.Text = currentIndex.ToString();
                    nowaNauka.punktacja++;
                    ileSlowekUmiemLabel.Text = nowaNauka.punktacja.ToString();

                    Thread.Sleep(1000);
                    podsumowanieNaukiPanel.Visible = true;


                }
                else
                {

                    nowaNauka.slowkaZNAM.Add(FileReader.slowkaANG[currentIndex]);
                    odpPlLabel.Text = FileReader.slowkaPL[currentIndex];
                    nowaNauka.punktacja++;
                    //liczbaPoprawnychOdp.Text = nowaNauka.punktacja.ToString();
                    ileSlowekUmiemLabel.Text = nowaNauka.punktacja.ToString();
                    currentIndex++;
                    aktualnyNrPytania.Text = currentIndex.ToString();
                    pytanieAngielskie.Text = FileReader.slowkaANG[currentIndex];
                    //liczbaPoprawnychOdp.Visible = true;
                    odpPlLabel.Visible = false;
                    wiemBtn.Visible = false;
                    nieWiemBtn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private void nieWiemBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (currentIndex == FileReader.slowkaANG.Count - 1)
                {


                    liczbaSlowekLabel.Text = FileReader.slowkaANG.Count.ToString();
                    nowaNauka.slowkaNIEZNAM.Add(FileReader.slowkaANG[currentIndex] + "-" + FileReader.slowkaPL[currentIndex]);
                    aktualnyNrPytania.Text = currentIndex.ToString();
                    bledneOdpRichTextBox.Lines = nowaNauka.slowkaNIEZNAM.ToArray();
                    nowaNauka.punktacjaZle++;
                    ileSlowekNieUmiemLabel.Text = nowaNauka.punktacjaZle.ToString();

                    Thread.Sleep(1000);
                    podsumowanieNaukiPanel.Visible = true;




                }
                else
                {

                    nowaNauka.slowkaNIEZNAM.Add(FileReader.slowkaANG[currentIndex] + "-" + FileReader.slowkaPL[currentIndex]);
                    bledneOdpRichTextBox.Lines = nowaNauka.slowkaNIEZNAM.ToArray();
                    odpPlLabel.Text = FileReader.slowkaPL[currentIndex];
                    nowaNauka.punktacjaZle++;
                    ileSlowekNieUmiemLabel.Text = nowaNauka.punktacjaZle.ToString();
                    currentIndex++;
                    aktualnyNrPytania.Text = currentIndex.ToString();
                    pytanieAngielskie.Text = FileReader.slowkaANG[currentIndex];
                    bledneOdpRichTextBox.Lines = nowaNauka.slowkaNIEZNAM.ToArray();
                    odpPlLabel.Visible = false;
                    wiemBtn.Visible = false;
                    nieWiemBtn.Visible = false;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


        }

        private void pokazOdpBtn_Click(object sender, EventArgs e)
        {
            if (!isStarted)
            {
                MessageBox.Show("Zacznij od wczytania pliku");
            }
            else
            {
                if (currentIndex == FileReader.slowkaANG.Count)
                {
                    MessageBox.Show("Koniec nauki!");
                    podsumowanieNaukiPanel.Visible = true;
                    liczbaSlowekLabel.Text = FileReader.slowkaANG.Count.ToString();

                }
                else
                {
                    odpPlLabel.Text = FileReader.slowkaPL[currentIndex];
                    wiemBtn.Visible = true;
                    nieWiemBtn.Visible = true;
                    odpPlLabel.Visible = true;
                }


            }
        }

        private void exitBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void paneTop_MouseUp(object sender, MouseEventArgs e)
        {
            TogMove = 0;
        }

        private void paneTop_MouseMove(object sender, MouseEventArgs e)
        {
            if (TogMove == 1)
            {

                this.SetDesktopLocation(MousePosition.X - MValX, MousePosition.Y - MValY);
            }
        }

        private void paneTop_MouseDown(object sender, MouseEventArgs e)
        {
            TogMove = 1;
            MValX = e.X;
            MValY = e.Y;
        }

        private void minimalizeBtn_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void exitAppBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gitHubBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://github.com/archeonV9");
        }

        private void linkedInBtn_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.linkedin.com/in/bartosz-janiuk-89265717b/");
        }
    }
}
