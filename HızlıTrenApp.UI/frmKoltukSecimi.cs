﻿using HızlıTrenApp.DAL.Repository.Concrete;
using HızlıTrenApp.DATA;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HızlıTrenApp.UI
{
    public partial class frmKoltukSecimi : MetroFramework.Forms.MetroForm
    {
        Form gelenForm;
        int seferId = 0;
        string saat = "";
        public frmKoltukSecimi(Form form, int id, string tiklananSaat)
        {
            InitializeComponent();
            gelenForm = form;
            seferId = id;
            saat = tiklananSaat;
        }
        List<BiletBilgi> businessKadinBiletler;
        List<BiletBilgi> businessErkekBiletler;
        List<BiletBilgi> economyErkekBiletler;
        List<BiletBilgi> economyKadinBiletler;

        string economyErkekKoltuk = @"..\..\Images\Resized_Seats\seat_man_resized_economy.png";
        string economyKadinKoltuk = @"..\..\Images\Resized_Seats\seat_woman_resized_economy.png";
        string businessErkekKoltuk = @"..\..\Images\Resized_Seats\seat_man_resized_business.png";
        string businessKadinKoltuk = @"..\..\Images\Resized_Seats\seat_woman_resized_business.png";
        string businessBosKoltuk = @"..\..\Images\Resized_Seats\seat_available_resized_business.png";
        string economyBosKoltuk = @"..\..\Images\Resized_Seats\seat_available_resized_economy.png";
        string economyLuggage = @"..\..\Images\luggage_economy.png";
        private void frmKoltukSecimi_Load(object sender, EventArgs e)
        {
            SeferSaatleriDal ssd = new SeferSaatleriDal();
            int saatID = ssd.GetIdByDate(saat);

            BiletBilgiDal biletBilgiConcrete = new BiletBilgiDal();

            businessKadinBiletler = biletBilgiConcrete.BusinessWomanTickets(seferId, saatID);
            businessErkekBiletler = biletBilgiConcrete.BusinessManTickets(seferId, saatID);

            economyKadinBiletler = biletBilgiConcrete.EconomyWomanTickets(seferId, saatID);
            economyErkekBiletler = biletBilgiConcrete.EconomyManTickets(seferId, saatID);

            KoltuklariOlustur();

            BusinessKadinlar(grpBusiness1, grpBusiness2);
            BusinessErkekler(grpBusiness1, grpBusiness2);

            EconomyKadinlar(grpEconomy1, grpEconomy2);
            EconomyErkekler(grpEconomy1, grpEconomy2);
        }

        private void EconomyErkekler(GroupBox grpEconomy1, GroupBox grpEconomy2)
        {
            foreach (BiletBilgi bilet in economyErkekBiletler)
            {
                foreach (Control item in grpEconomy1.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = economyErkekKoltuk;
                    }
                }
                foreach (Control item in grpEconomy2.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = economyErkekKoltuk;
                    }
                }
            }
        }

        private void EconomyKadinlar(GroupBox grpEconomy1, GroupBox grpEconomy2)
        {
            foreach (BiletBilgi bilet in economyKadinBiletler)
            {
                foreach (Control item in grpEconomy1.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = economyKadinKoltuk;
                    }
                }
                foreach (Control item in grpEconomy2.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = economyKadinKoltuk;
                    }
                }
            }
        }

        private void BusinessErkekler(GroupBox grpBusiness1, GroupBox grpBusiness2)
        {
            foreach (BiletBilgi bilet in businessErkekBiletler)
            {
                foreach (Control item in grpBusiness1.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = businessErkekKoltuk;
                    }
                }
                foreach (Control item in grpBusiness2.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = businessErkekKoltuk;
                    }
                }
            }
        }

        private void BusinessKadinlar(GroupBox grpBusiness1, GroupBox grpBusiness2)
        {
            foreach (BiletBilgi bilet in businessKadinBiletler)
            {
                foreach (Control item in grpBusiness1.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = businessKadinKoltuk;
                    }
                }
                foreach (Control item in grpBusiness2.Controls)
                {
                    if (item is PictureBox && bilet.KoltukNo == item.Name)
                    {
                        ((PictureBox)item).ImageLocation = businessKadinKoltuk;
                    }
                }
            }
        }

        private void KoltuklariOlustur()
        {
            //Business pb ve lbl
            PictureBox pbB1;
            PictureBox pbB2;
            Label lblB1;
            Label lblB2;
            Label lblB1Masa;
            Label lblB2Masa;

            //Business Degiskenleri

            int businessSoldanBosluk = 60;
            int businessKoltukArasi = 20;
            int businessUsttenBosluk = 10;
            int businessKoltukSayisi = 8;

            lblB1Masa = new Label();
            lblB1Masa.AutoSize = false;
            lblB1Masa.TextAlign = ContentAlignment.MiddleCenter;
            lblB1Masa.Width = 269;
            lblB1Masa.Height = 20;
            lblB1Masa.Text = "MASA";
            lblB1Masa.BackColor = Color.LightGoldenrodYellow;
            grpBusiness1.Controls.Add(lblB1Masa);

            lblB2Masa = new Label();
            lblB2Masa.AutoSize = false;
            lblB2Masa.TextAlign = ContentAlignment.MiddleCenter;
            lblB2Masa.Width = 269;
            lblB2Masa.Height = 20;
            lblB2Masa.Text = "MASA";
            lblB2Masa.BackColor = Color.LightGoldenrodYellow;
            grpBusiness2.Controls.Add(lblB2Masa);

            for (int i = 0; i < 8; i++)
            {
                //grpBusiness1
                pbB1 = new PictureBox();
                lblB1 = new Label();
                pbB1.Name = "B" + i;
                lblB1.Text = pbB1.Name;
                KoltukAyarlari(pbB1, lblB1, null);




                grpBusiness1.Controls.Add(pbB1);
                grpBusiness1.Controls.Add(lblB1);

                //grpBusiness2
                pbB2 = new PictureBox();
                lblB2 = new Label();
                pbB2.Name = "B" + businessKoltukSayisi;
                lblB2.Text = pbB2.Name;
                businessKoltukSayisi++;
                KoltukAyarlari(pbB2, lblB2, null);


                grpBusiness2.Controls.Add(pbB2);
                grpBusiness2.Controls.Add(lblB2);

                if (i < 4)
                {
                    //grpBusiness1'de ust 4 koltuk
                    pbB1.Location = new Point((i * businessSoldanBosluk) + businessKoltukArasi, businessUsttenBosluk);
                    lblB1.Location = new Point(pbB1.Location.X, pbB1.Height + businessUsttenBosluk);


                    //grpBusiness2'de ust 4 koltuk
                    pbB2.Location = new Point((i * businessSoldanBosluk) + businessKoltukArasi, businessUsttenBosluk);
                    lblB2.Location = new Point(pbB2.Location.X, pbB2.Height + businessUsttenBosluk);
                }
                else
                {
                    //grpBusiness1'de alt 4 koltuk
                    pbB1.Location = new Point(((i - 4) * businessSoldanBosluk) + businessKoltukArasi, lblB1.Height + pbB1.Height + (businessUsttenBosluk * 4));
                    lblB1.Location = new Point(pbB1.Location.X, pbB1.Location.Y + (businessUsttenBosluk * 3));

                    //grpBusiness2'de alt 4 koltuk
                    pbB2.Location = new Point(((i - 4) * businessSoldanBosluk) + businessKoltukArasi, lblB2.Height + pbB2.Height + (businessUsttenBosluk * 4));
                    lblB2.Location = new Point(pbB2.Location.X, pbB2.Location.Y + (businessUsttenBosluk * 3));
                }
                lblB1Masa.Location = new Point(0, 60);
                lblB2Masa.Location = new Point(0, 60);
            }
            //Economy pb ve lbl
            PictureBox pbE1;
            PictureBox pbE2;
            Label lblE1;
            Label lblE2;
            PictureBox luggage;
            PictureBox luggage2;

            //Economy Degiskenleri

            int economySoldanBosluk = 60;
            int economyKoltukArasi = 20;
            int economyUsttenBosluk = 10;
            int economyLabelBosluk = 15;
            int economyKoltukSayisi = 12;
            for (int i = 0; i < 12; i++)
            {
                //grpEconomy1
                pbE1 = new PictureBox();
                lblE1 = new Label();
                luggage = new PictureBox();
                pbE1.Name = "E" + i;
                lblE1.Text = pbE1.Name;
                KoltukAyarlari(pbE1, lblE1, luggage);
                grpEconomy1.Controls.Add(pbE1);
                grpEconomy1.Controls.Add(lblE1);
                grpEconomy1.Controls.Add(luggage);

                //grpEconomy2
                pbE2 = new PictureBox();
                lblE2 = new Label();
                luggage2 = new PictureBox();
                pbE2.Name = "E" + economyKoltukSayisi;
                lblE2.Text = pbE2.Name;
                economyKoltukSayisi++;
                KoltukAyarlari(pbE2, lblE2, luggage2);
                grpEconomy2.Controls.Add(pbE2);
                grpEconomy2.Controls.Add(lblE2);

                if (i < 3)
                {
                    //grpEconomy1'de ust 4 koltuk
                    pbE1.Location = new Point((2 * i * economySoldanBosluk) + economyKoltukArasi, economyUsttenBosluk);
                    lblE1.Location = new Point(pbE1.Location.X, pbE1.Height + economyUsttenBosluk - 3);
                    luggage.Location = new Point(pbE1.Location.X + economySoldanBosluk - 5, economyUsttenBosluk);

                    //grpEconomy2'de ust 4 koltuk
                    pbE2.Location = new Point((i * economySoldanBosluk) + economyKoltukArasi, economyUsttenBosluk);
                    lblE2.Location = new Point(pbE2.Location.X, pbE2.Height + economyUsttenBosluk - 3);
                }
                else if (i >= 3 && i < 10)
                {
                    //grpEconomy1'de orta 4 koltuk
                    pbE1.Location = new Point(((i - 4) * businessSoldanBosluk) + businessKoltukArasi, lblE1.Height + pbE1.Height + economyUsttenBosluk);
                    lblE1.Location = new Point(pbE1.Location.X, pbE1.Location.Y + economyUsttenBosluk + economyLabelBosluk + 3);

                    //grpEconomy2'de orta 4 koltuk
                    pbE2.Location = new Point(((i - 4) * businessSoldanBosluk) + businessKoltukArasi, lblE2.Height + pbE2.Height + economyUsttenBosluk);
                    lblE2.Location = new Point(pbE2.Location.X, pbE2.Location.Y + economyUsttenBosluk + economyLabelBosluk + 3);
                }
                else
                {
                    //grpEconomy1'de alt 4 koltuk
                    grpEconomy1.Controls.Add(pbE1);
                    grpEconomy1.Controls.Add(lblE1);
                    grpEconomy1.Controls.Add(luggage);
                    luggage.Location = new Point(((i - 10) * businessSoldanBosluk) + businessKoltukArasi, lblE1.Height + pbE1.Height + economyUsttenBosluk + (economyUsttenBosluk * 3) + economyUsttenBosluk);
                    pbE1.Location = new Point((2 * (i - 10) * businessSoldanBosluk) + businessKoltukArasi, lblE1.Height + pbE1.Height + economyUsttenBosluk + (economyUsttenBosluk * 3) + economyUsttenBosluk);
                        lblE1.Location = new Point(pbE1.Location.X, pbE1.Location.Y + economyUsttenBosluk + 20);
                        

                    //grpEconomy2'de alt 4 koltuk
                    pbE2.Location = new Point(((i - 10) * businessSoldanBosluk) + businessKoltukArasi - 5, lblE2.Height + pbE2.Height + economyUsttenBosluk + (economyUsttenBosluk * 3) + economyUsttenBosluk + 5);
                    lblE2.Location = new Point(pbE2.Location.X, pbE2.Location.Y + economyUsttenBosluk + 20);
                }
            }
        }

        private void KoltukAyarlari(PictureBox pb, Label lbl, PictureBox luggage)
        {
            pb.Width = 40;
            pb.Height = 30;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Width = pb.Width;
            lbl.Height = 15;
            pb.ImageLocation = economyBosKoltuk;
            if (luggage != null)
            {
                luggage.Width = 40;
                luggage.Height = 30;
                luggage.ImageLocation = economyLuggage;
            }
        }

        private void BusinessKoltuk(PictureBox pb, Label lbl)
        {
            pb.Width = 40;
            pb.Height = 30;
            lbl.TextAlign = ContentAlignment.MiddleCenter;
            lbl.Width = pb.Width;
            lbl.Height = 15;
            pb.Click += Pb_Click;
            pb.ImageLocation = economyBosKoltuk;

        }

        private void Pb_Click(object sender, EventArgs e)
        {
            PictureBox tiklanan = sender as PictureBox;
            MessageBox.Show(tiklanan.Name);
        }
    }
}