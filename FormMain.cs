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
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Web;
using Newtonsoft.Json;

namespace PubSync
{
    public partial class FormMain : Form
    {
        
        List<Book> lstBooks = new List<Book>();

        //MTMT-ből eredmények letöltése
        public void MTMTSearch(string author, int delay)
        {
            //MTMT oldalról adatok letöltése
            ChromeOptions options = new ChromeOptions();
            //Chrome böngésző ablak elrejtése
            options.AddArgument("headless"); 
            var driverService = ChromeDriverService.CreateDefaultService();
            //ChromeDriver Windows parancssor ablak elrejtáse
            driverService.HideCommandPromptWindow = true; 
            //Chrome v88-ig támogatja a Selenium v3.141!
            IWebDriver driverMTMT = new ChromeDriver(driverService,options);

            try
            {
                //MTMT-be szerző szerint keresünk
                driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
                driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
                //több szerzős találat kezelése (pl.: Süle Zoltán (műszaki informatika), Süle Zoltán (neurobiológia))
                IList<IWebElement> authorscount = driverMTMT.FindElements(By.XPath("//div[@class='item-right-inner']"));
                if (authorscount.Count>1) {
                    MessageBox.Show(authorscount.Count.ToString()+" különböző "+author+" nevű szerzőt találtam" + Environment.NewLine +
                        "Az elsőnek megtalált szerzővel dolgozom. Ha másik szerzőre kíváncsi, kérem pontosítsa a keresési feltételt!"
                        , "Figyelem!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                    }
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
                //Listák gombot lenyitja
                driverMTMT.FindElement(By.XPath("/ html / body / section / div / section[2] / div[1] / div[2] / div[2] / ul / li[2] / div / button")).Click();
                //Teljes lista gomb
                driverMTMT.FindElement(By.PartialLinkText("Teljes lista")).Click();
                Thread.Sleep(delay);
                //1-20 lapok gombra kattint
                driverMTMT.FindElement(By.XPath("/ html / body / section / div / section[2] / div[1] / div[2] / div[5] / div / div / div[2] / button")).Click();
                //20-at lenyitjuk
                driverMTMT.FindElement(By.XPath("/ html / body / div[5] / div / div[2] / div / div / button")).Click();
                //5000-re kattintunk
                driverMTMT.FindElement(By.PartialLinkText("5000")).Click();
                //kiválasztjuk az elsőt
                driverMTMT.FindElement(By.XPath("/ html / body / div[5] / div / div[3] / div / a")).Click();

                //meg kell várnunk amíg betöltődik az oldal (több találatnál többet kell várnunk)
                string talalatdb = driverMTMT.FindElement(By.ClassName("search-result-short")).Text;
                string talalatstr= talalatdb.Substring(0, talalatdb.Length - 8);
                int talalat = Int32.Parse(talalatstr);
                Thread.Sleep(talalat*5);

                //lescrapeljük az adatokat
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
            catch (Exception MTMTWebError)
            {
                MessageBox.Show("Hiba történt MTMT oldallal való interakció közben! " + Environment.NewLine + Environment.NewLine +
                    "Kérem a következő hibaüzentettel keresse meg a fejlesztőt: " + Environment.NewLine+
                    MTMTWebError, "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        //app.py Python Flask script - Scholar keresés 
        private void run_cmd()
        {
            string fileName = @"app.py";
            Process p = new Process();
            p.StartInfo = new ProcessStartInfo(@"C:\Python39\python.exe", fileName)
            {
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            p.Start();

            string output = p.StandardOutput.ReadToEnd();
            p.WaitForExit();
            Console.WriteLine(output);
            Console.ReadLine();
        }

        //Scholar eredmények letöltése            
        public void GSSearch(string author)
        {
            //szerző műveinek lekérdezése
            HttpClient httpClient = new HttpClient();
            httpClient.DefaultRequestHeaders.Add("Accept", "application/json;charset=UTF-8");
            //Scholar keresésnél a zárójeles részt kivesszük pl.: Süle Zoltán (műszaki informatika)
            string ScholarAuthor = author;
            if (author.Contains("("))
            {
                ScholarAuthor = author.Substring(0, author.IndexOf("("));
            }
            //scholar API használata
            var result = httpClient.GetAsync("http://localhost:5000/api/quick/"+ScholarAuthor).Result;
            result.Content.ReadAsStringAsync();

            //JSON DeSerializáció
            var jsonString = result.Content.ReadAsStringAsync();
            jsonString.Wait();
//ha nincs Scholar eredmény null-ra nem lehet deszerializáció
            BookGS BookGS = JsonConvert.DeserializeObject<BookGS>(jsonString.Result);

            //Scholar könyv MTMT könyhöz rendelése
            if (BookGS.number_of_publications > 0)
            {
                for (int GS = 0; GS < BookGS.publications.Count; GS++)
                {
                    for (int MTMT = 0; MTMT < lstBooks.Count; MTMT++)
                    {
                        //Egyező title keresés
                        string MTMTTitleResz = lstBooks[MTMT].MTMTtitle;
                        string GSTitleResz = BookGS.publications[GS].title;

                        //Egyező résztitle keresés
                        if (cBMatch.Checked)
                        {
                            //ha rövidebb a sztring, mint a substring, akkor a teljes sztringre keresünk,különben a részstringre
                            if (Int32.Parse(mTBMatch.Text) < lstBooks[MTMT].MTMTtitle.Length)
                                MTMTTitleResz = lstBooks[MTMT].MTMTtitle.Substring(0, Int32.Parse(mTBMatch.Text) - 1);
                            if (Int32.Parse(mTBMatch.Text) < BookGS.publications[GS].title.Length)
                                GSTitleResz = BookGS.publications[GS].title.Substring(0, Int32.Parse(mTBMatch.Text) - 1);
                        }

                        if (MTMTTitleResz == GSTitleResz)
                        {
                            //egyezést találtam cím vagy részcím vizsgálattal
                            lstBooks[MTMT].GStitle = BookGS.publications[GS].title;
                            lstBooks[MTMT].GSpub_year = BookGS.publications[GS].pub_year;
                            lstBooks[MTMT].GSnum_citations = BookGS.publications[GS].num_citations;
                            lstBooks[MTMT].Match = true;
                        }
                    }
                }
            }

            lblGSBooks.Text = "Művek száma a Google Scholarban: " + BookGS.number_of_publications.ToString() + " db";
        }

        //DataGrid inicializálása és feltöltése
        public void DGFill()
        {
            DGVMTMT.ColumnCount = 8;
            DGVMTMT.Columns[0].Name = "#";
            DGVMTMT.Columns[1].Name = "MTMTtitle";
            DGVMTMT.Columns[2].Name = "GStitle";
            DGVMTMT.Columns[3].Name = "authors";
            DGVMTMT.Columns[4].Name = "pub_year";
            DGVMTMT.Columns[5].Name = "num_citation";
            DGVMTMT.Columns[6].Name = "pubInfo";
            DGVMTMT.Columns[7].Name = "pubEnd";
            int Match = 0;

            if (lstBooks.Count > 0)
            {
                DataExist();
                LblMTMTBooks.Text= "Művek száma az MTMT-ben: " + lstBooks.Count.ToString() + " db";

                for (int i = 0; i < lstBooks.Count; i++)
                {
                    if (lstBooks[i].Match)
                    {
                        Match++;
                    }
                    string[] row = new string[] { (i + 1).ToString(), 
                                                  lstBooks[i].MTMTtitle, 
                                                  lstBooks[i].GStitle, 
                                                  lstBooks[i].MTMTauthors, 
                                                  lstBooks[i].GSpub_year,
                                                  lstBooks[i].GSnum_citations.ToString(),
                                                  lstBooks[i].MTMTpubInfo, 
                                                  lstBooks[i].MTMTpubEnd };
                    DGVMTMT.Rows.Add(row);

                    //sorok színezése
                    if (DGVMTMT.Rows[i].Cells[2].Value != null)
                        DGVMTMT.Rows[i].DefaultCellStyle.BackColor = Color.Aqua;
                    else
                        DGVMTMT.Rows[i].DefaultCellStyle.BackColor = Color.Gold;
                }

                lblMatch.Text = "Egyezések: " +Match.ToString()+ " db";
            }
            DGVMTMT.AutoResizeColumns();
        }

        public void DataClear()
        {
            LblMTMTBooks.Visible = false;
            lblGSBooks.Visible = false;
            lblMatch.Visible = false;
            lstBooks.Clear();
            DGVMTMT.Rows.Clear();
        }

        public void DataExist()
        {
            LblMTMTBooks.Visible = true;
            lblGSBooks.Visible = true;
            lblMatch.Visible = true;
        }


        // ----- M A I N ------ //
        public FormMain()
        {
            InitializeComponent();
            gBSettings.Visible = false;
            DataClear();

            //app.py Python Flask script indítás - Scholar keresés indítás
            Thread apppyth = new Thread(new ThreadStart(run_cmd));
            apppyth.Start();

        }

        //Keresés gomb
        private void BtnSearch_Click(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;

            DataClear();
            if (Int32.Parse(mTxtBDelay.Text) < 200) { mTxtBDelay.Text = "200"; }
            MTMTSearch(TxtBxAuthor.Text, Int32.Parse(mTxtBDelay.Text));
            GSSearch(TxtBxAuthor.Text);
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

        //Beállítások megjelenítése/elrejtése
        private void cBSettings_CheckedChanged(object sender, EventArgs e)
        {
            if (cBSettings.Checked)
            {
                gBSettings.Visible= true;
            }
            else
            {
                gBSettings.Visible = false;
            }

        }
    }
}
