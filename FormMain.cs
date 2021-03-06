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

namespace PubSync
{
    public partial class FormMain : Form
    {
        public void MTMTSearch(string author, int delay)
        {
            List<MTMTBook> lstMTMBooks = new List<MTMTBook>();

            //MTMT oldalról adatok letöltése
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            IWebDriver driverMTMT = new ChromeDriver(options);

            driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
            driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(delay);
            
            //rossz szerző keresés kezelése

            driverMTMT.FindElement(By.PartialLinkText(author)).Click();
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
                    lstMTMBooks.Add(new MTMTBook()
                    {
                        authors = authors[i].Text.ToString(),
                        title = titles[i].Text.ToString(),
                        pubInfo = pubInfo[i].Text.ToString(),
                        pubEnd = pubEnd[i].Text.ToString()
                    });
                }
            }
            driverMTMT.Quit();

            lblMTMTCount.Text = lstMTMBooks.Count.ToString()+" db";

            //DataGrid inicializálása és feltöltése
            dGVMTMT.ColumnCount = 5;
            dGVMTMT.Columns[0].Name = "id";
            dGVMTMT.Columns[1].Name = "authors";
            dGVMTMT.Columns[2].Name = "title";
            dGVMTMT.Columns[3].Name = "pubInfo";
            dGVMTMT.Columns[4].Name = "pubEnd";
            dGVMTMT.Rows.Clear();

            if (lstMTMBooks.Count > 0)
            {
                for (int i = 0; i < lstMTMBooks.Count; i++)
                {
                    string[] row = new string[] { (i+1).ToString(), lstMTMBooks[i].authors, lstMTMBooks[i].title, lstMTMBooks[i].pubInfo, lstMTMBooks[i].pubEnd };
                    dGVMTMT.Rows.Add(row);
                }
            }
            dGVMTMT.AutoResizeColumns();
        }


        // ----- M A I N ------ //
        public FormMain()
        {
            InitializeComponent();
        }


        //Keresés gomb
        private void btnSearch_Click_1(object sender, EventArgs e)
        {
            MTMTSearch(txtBxAuthor.Text, 300);
        }
    }
}
