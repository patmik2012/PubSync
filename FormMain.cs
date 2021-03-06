﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;

namespace PubSync
{
    public partial class FormMain : Form
    {
        
        List<Book> lstBooks = new List<Book>();


        public void MTMTSearch(string author, int delay)
        {
            //MTMT oldalról adatok letöltése
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless"); //Chrome böngésző elrejtése
            var driverService = ChromeDriverService.CreateDefaultService();
            driverService.HideCommandPromptWindow = true; //ChromeDriver Windows command window elrejtáse
            IWebDriver driverMTMT = new ChromeDriver(driverService,options);

            try
            {
                driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
                driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
                Thread.Sleep(delay);

                //rossz szerző keresés kezelése
                try
                {
                    driverMTMT.FindElement(By.PartialLinkText(author)).Click();
                }
                catch
                {
                    MessageBox.Show("Nem találtam adatot!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    DataClear();
                }
                Thread.Sleep(delay);

                IList<IWebElement> titles = driverMTMT.FindElements(By.XPath("//div[@class='title']"));
                IList<IWebElement> authors = driverMTMT.FindElements(By.XPath("//div[@class='authors']"));
                IList<IWebElement> pubInfo = driverMTMT.FindElements(By.XPath("//div[@class='pub-info']"));
                IList<IWebElement> pubEnd = driverMTMT.FindElements(By.XPath("//div[@class='pub-end']"));

                //Osztály feltöltése adatokkal
                if (titles.Count > 0)
                {
                    for (int i = 0; i < titles.Count; i++)
                    {
                        lstBooks.Add(new Book()
                        {
                            MTMTauthors = authors[i].Text.ToString(),
                            MTMTtitle = titles[i].Text.ToString(),
                            MTMTpubInfo = pubInfo[i].Text.ToString(),
                            MTMTpubEnd = pubEnd[i].Text.ToString()
                        });
                    }
                }
                driverMTMT.Quit();
            }
            catch
            {
                MessageBox.Show("Nem érem el az MTMT weboldalt!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //DataGrid inicializálása és feltöltése
        public void DGFill()
        { 
            DGVMTMT.ColumnCount = 5;
            DGVMTMT.Columns[0].Name = "id";
            DGVMTMT.Columns[1].Name = "authors";
            DGVMTMT.Columns[2].Name = "title";
            DGVMTMT.Columns[3].Name = "pubInfo";
            DGVMTMT.Columns[4].Name = "pubEnd";

            if (lstBooks.Count > 0)
            {
                DataExist();
                LblMTMTBooks.Text= "Művek száma az MTMT-ben: " + lstBooks.Count.ToString() + " db";
                for (int i = 0; i < lstBooks.Count; i++)
                {
                    string[] row = new string[] { (i + 1).ToString(), lstBooks[i].MTMTauthors, lstBooks[i].MTMTtitle, lstBooks[i].MTMTpubInfo, lstBooks[i].MTMTpubEnd };
                    DGVMTMT.Rows.Add(row);
                }
            }
            DGVMTMT.AutoResizeColumns();
        }

        public void DataClear()
        {
            LblMTMTBooks.Visible = false;
            lstBooks.Clear();
            DGVMTMT.Rows.Clear();
        }

        public void DataExist()
        {
            LblMTMTBooks.Visible = true;
        }


        // ----- M A I N ------ //
        public FormMain()
        {
            InitializeComponent();
            DataClear();
        }


        //Keresés gomb
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataClear();
            MTMTSearch(TxtBxAuthor.Text, 300);
            DGFill();
            Cursor.Current = Cursors.Default;
        }

        //TextBoxban Enterrel is lenyomja a keresés gombot
        private void TxtBxAuthor_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == System.Windows.Forms.Keys.Enter)
            {
                BtnSearch.PerformClick();
            }
        }
    }
}
