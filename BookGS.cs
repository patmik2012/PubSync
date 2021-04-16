using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSync
{
    class BookGS
    {
        public class publication
        {
            public int _id;//:0,
            public int num_citations;//:2,
            public string pub_year;//:"2016",
            public string title;//:"Kontrollcsoport-gener\u00e1l\u00e1si lehet\u0151s\u00e9gek retrospekt\u00edv eg\u00e9szs\u00e9g\u00fcgyi vizsg\u00e1latokhoz"},
        }

        public string affiliation; //:"University of Pannonia",
        public int citedby; //:5,
        public string[] coauthors; //:["Agnes Vathy-Fogarassy","Gy\u00f6rgy Fogarassy"],
        public string email_domain; //:"@dcs.uni-pannon.hu",
        public string[] interests; //:["data mining","healthcare informatics","control group selection","text processing"],
        public string name; //:"Szek\u00e9r Szabolcs",
        public int number_of_publications; //:9,
        public IList<publication> publications;
    }
}
