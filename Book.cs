using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PubSync
{
    public class Book
    {
        //MTMT adatok
        public string MTMTauthors;
        //	"Csalódi, Róbert ; Süle, Zoltán ; Jaskó, Szilárd ; Holczinger, Tibor ; Abonyi, János"	
        //"Szekér, Szabolcs ; Vathy-Fogarassy, Ágnes"
        public string MTMTtitle;
        //		"Industry 4.0-Driven Development of Optimization Algorithms: A Systematic Overview"	
        //"Weighted nearest neighbours-based control group selection method for observational studies"
        public string MTMTpubInfo;
        //	"COMPLEXITY 2021 pp. 1-22. , 22 p. (2021)"	
        //"PLOS ONE 15 : 7 Paper: e0236531 (2020)"
        public string MTMTpubEnd;
        //		"DOI Egyéb URL\r\nTudományos"	
        //"DOI Scopus PubMed Egyéb URL\r\nTudományos"

        
        //Google Scholar egyező adatok
        public string GStitle;//:"Kontrollcsoport-gener\u00e1l\u00e1si lehet\u0151s\u00e9gek retrospekt\u00edv eg\u00e9szs\u00e9g\u00fcgyi vizsg\u00e1latokhoz"},
                              //"Weighted nearest neighbours-based control group selection method for observational studies"
        public string GSpub_year;//:"2016",
                                 //"2020"
        public int GSnum_citations;//:2,
                                   //0

        //egyezés
        public bool Match;


    }
}
