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
            IWebDriver driverMTMT = new ChromeDriver();
            driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
            driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
            driverMTMT.FindElement(By.PartialLinkText(author)).Click();

            IList<IWebElement> titles = driverMTMT.FindElements(By.XPath("//div[@class='title']"));
            IList<IWebElement> authors = driverMTMT.FindElements(By.XPath("//div[@class='authors']"));
            IList<IWebElement> pubInfo = driverMTMT.FindElements(By.XPath("//div[@class='pub-info']"));
            IList<IWebElement> pubEnd = driverMTMT.FindElements(By.XPath("//div[@class='pub-end']"));

            for (int i=0;i<titles.Count;i++)
            {
                lstMTMBooks.Add(new MTMTBook() 
                    {
                        authors = authors[i].ToString(),
                        title = titles[i].Text.ToString(),
                        pubInfo = pubInfo[i].Text.ToString(),
                        pubEnd = pubEnd[i].Text.ToString()
                });
            }

            MessageBox.Show("MTMT könyvek száma: "+titles.Count.ToString());
            //driverMTMT.Quit();


            /*
            //Google Scholar oldalról adatok letöltése
            IWebDriver driverGS = new ChromeDriver();
            driverGS.Navigate().GoToUrl("https://scholar.google.com/");
            driverGS.FindElement(By.Name("q")).SendKeys("author:"+ author + OpenQA.Selenium.Keys.Enter);
            */

        }
    }
}
