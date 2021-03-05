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
        public FormMain()
        {
            InitializeComponent();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            const string author = "Szekér Szabolcs";
            
            List<MTMTBook> lstMTMBooks = new List<MTMTBook>();

            //MTMT oldalról adatok letöltése
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            IWebDriver driverMTMT = new ChromeDriver(options);
            
            driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
            driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
            Thread.Sleep(500);
            driverMTMT.FindElement(By.PartialLinkText(author)).Click();

            IList<IWebElement> titles = driverMTMT.FindElements(By.XPath("//div[@class='title']"));
            IList<IWebElement> authors = driverMTMT.FindElements(By.XPath("//div[@class='authors']"));
            IList<IWebElement> pubInfo = driverMTMT.FindElements(By.XPath("//div[@class='pub-info']"));
            IList<IWebElement> pubEnd = driverMTMT.FindElements(By.XPath("//div[@class='pub-end']"));

            for (int i=0;i<titles.Count;i++)
            {
                lstMTMBooks.Add(new MTMTBook() 
                    {
                        authors = authors[i].Text.ToString(),
                        title = titles[i].Text.ToString(),
                        pubInfo = pubInfo[i].Text.ToString(),
                        pubEnd = pubEnd[i].Text.ToString()
                });
            }

            driverMTMT.Quit();
            lblMTMTCount.Text = lstMTMBooks.Count.ToString();
            //MessageBox.Show("MTMT könyvek száma: " + lstMTMBooks.Count.ToString());

            dGVMTMT.ColumnCount = 4;
            dGVMTMT.Columns[0].Name = "authors";
            dGVMTMT.Columns[1].Name = "title";
            dGVMTMT.Columns[2].Name = "pubInfo";
            dGVMTMT.Columns[3].Name = "pubEnd";

            if (lstMTMBooks.Count>0)
            {
                for (int i = 0; i < lstMTMBooks.Count; i++)
                {
                    string[] row = new string[] { lstMTMBooks[i].authors, lstMTMBooks[i].title, lstMTMBooks[i].pubInfo, lstMTMBooks[i].pubEnd};
                    dGVMTMT.Rows.Add(row);
                }
            }


            /*
            //Google Scholar oldalról adatok letöltése
            IWebDriver driverGS = new ChromeDriver();
            driverGS.Navigate().GoToUrl("https://scholar.google.com/");
            driverGS.FindElement(By.Name("q")).SendKeys("author:"+ author + OpenQA.Selenium.Keys.Enter);
            */

        }
    }
}
