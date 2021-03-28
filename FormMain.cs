using OpenQA.Selenium;
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
using IronPython.Hosting;
using Microsoft.Scripting.Hosting;

namespace PubSync
{
    public partial class FormMain : Form
    {
        
        List<Book> lstBooks = new List<Book>();


        public void MTMTSearch(string author, int delay)
        {
            //MTMT oldalról adatok letöltése
            ChromeOptions options = new ChromeOptions();
            //Chrome böngésző ablak elrejtése
            options.AddArgument("headless"); 
            var driverService = ChromeDriverService.CreateDefaultService();
            //ChromeDriver Windows parancssor ablak elrejtáse
            driverService.HideCommandPromptWindow = true; 
            IWebDriver driverMTMT = new ChromeDriver(driverService,options);

            try
            {
                //MTMT-be szerző szerint keresünk
                driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
                driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
                //több szerzős találat kezelése (pl.: Süle Zoltán (műszaki informatika), Süle Zoltán (neurobiológia))

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

                //ne csak az első 20 találatot adja, hanem az összeset
                driverMTMT.FindElement(By.XPath("/ html / body / section / div / section[2] / div[1] / div[2] / div[2] / ul / li[2] / div / button")).Click();
                driverMTMT.FindElement(By.PartialLinkText("Teljes lista")).Click();
                driverMTMT.FindElement(By.XPath("/ html / body / section / div / section[2] / div[1] / div[2] / div[5] / div / div / div[2] / button")).Click();
                driverMTMT.FindElement(By.XPath("/ html / body / div[5] / div / div[2] / div / div / button")).Click();
                //5000 találatot teszünk ki az oldalra
                driverMTMT.FindElement(By.PartialLinkText("5000")).Click();
                driverMTMT.FindElement(By.XPath("/ html / body / div[5] / div / div[3] / div / a")).Click();
                Thread.Sleep(delay*2);

                //lescrapeljük az adatokat
                IList <IWebElement> titles = driverMTMT.FindElements(By.XPath("//div[@class='title']"));
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
            /*
            ScriptEngine pythone = Python.CreateEngine();
            try
            {
                pythone.ExecuteFile(".\\..\\..\\test.py");
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nem tudok Scholaron keresni! "+ ex.Message, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }*/
        }


        //Keresés gomb
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            DataClear();
            MTMTSearch(TxtBxAuthor.Text, 250);
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
