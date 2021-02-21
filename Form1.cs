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

            
            //MTMT oldalról adatok letöltése
            IWebDriver driverMTMT = new ChromeDriver();
            driverMTMT.Navigate().GoToUrl("http://www.mtmt.hu");
            driverMTMT.FindElement(By.Name("searchfield")).SendKeys(author + OpenQA.Selenium.Keys.Enter);
            driverMTMT.FindElement(By.PartialLinkText(author)).Click();

            IList<IWebElement> MTMTBooks = driverMTMT.FindElements(By.XPath("//div[@class='title']"));
            MessageBox.Show("MTMT könyvek száma: "+MTMTBooks.Count.ToString());
            driverMTMT.Close();
            

            /*
            //Google Scholar oldalról adatok letöltése
            IWebDriver driverGS = new ChromeDriver();
            driverGS.Navigate().GoToUrl("https://scholar.google.com/");
            driverGS.FindElement(By.Name("q")).SendKeys("author:"+ author + OpenQA.Selenium.Keys.Enter);
            */

        }
    }
}
