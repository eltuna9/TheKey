using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using TheKey.Models;

namespace TheKeyTest
{
    [TestClass]
    public class HtmlHelperTest
    {
        private const string URL = "https://infotrack.com.au";

        private const string LINK_TITLE_1 = "NSW Title Search Online | InfoTrack";
        private const string LINK_TITLE_2 = "Online Title Searchs | InfoTrack 2";


        //This string has 3 results, but only 2 valid result for our purpose.
        private const string HTML_TWO_RESULTS = @"<h3 class=""r""><a style=""display:block"" href=""https://infotrack.com.au/pagead/aclk?sa=L&amp"">"+ LINK_TITLE_1+ @"</a></h3>
                                                  <h3 class=""r""><a style=""display:block"" href=""https://othercompany.com.au/pagead/aclk?sa=L&amp""> | Instant Property Information</a></h3>
                                                  <h3 class=""r""><a style=""display:block"" href=""https://infotrack.com.au/pagead/aclk?sa=L&amp"">" + LINK_TITLE_2 + @"</a></h3>";

        //This string has 3 results, no one valid result for our purpose.
        private const string HTML_ZERO_RESULTS = @"<h3 class=""r""><a style=""display:block"" href=""https://othercompany.com.au/pagead/aclk?sa=L&amp"">NSW Title Search Online | Instant Property Information</a></h3>
                                                  <h3 class=""r""><a style=""display:block"" href=""https://othercompany.com.au/pagead/aclk?sa=L&amp"">NSW Title Search Online | Instant Property Information</a></h3>
                                                  <h3 class=""r""><a style=""display:block"" href=""https://othercompany.com.au/pagead/aclk?sa=L&amp"">NSW Title Search Online | Instant Property Information</a></h3>";

        [TestMethod]
        public void TestGetUrlAppearencesInHtmlWithTwoValidResults(){
            //GIVEN a string representing the html response with 2 appearences (HTML_TWO_RESULTS).            
            HtmlHelper htmlHelper = new HtmlHelper();
            //WHEN an HtmlHelper object get the appearences
            int appearencesCount = htmlHelper.GetUrlAppearencesInHtml(URL, HTML_TWO_RESULTS).Count;
            //THEN the lenght of the returned list is equals to 2.
            Assert.AreEqual(2, appearencesCount);
        }

        [TestMethod]
        public void TestGetUrlAppearencesInHtmlWithNoneValidResult()
        {
            //GIVEN a string representing the html response without any appearence (HTML_ZERO_RESULTS).            
            HtmlHelper htmlHelper = new HtmlHelper();
            //WHEN an HtmlHelper object get the appearences
            int appearencesCount = htmlHelper.GetUrlAppearencesInHtml(URL, HTML_ZERO_RESULTS).Count;
            //THEN the lenght of the returned list is equals to 2.
            Assert.AreEqual(0, appearencesCount);
        }

        [TestMethod]
        public void TestWellFormedLinkTitleAttribute()
        {
            //GIVEN a string representing the html response with 2 appearences (HTML_TWO_RESULTS).            
            HtmlHelper htmlHelper = new HtmlHelper();
            //WHEN a new Html helper object get the appearences
            List<SearchAppearence> appearences = htmlHelper.GetUrlAppearencesInHtml(URL, HTML_TWO_RESULTS);
            //THEN the LinkTitle attribute of the returned elements are correct
            Assert.AreEqual(appearences[0].LinkTitle, LINK_TITLE_1);
            Assert.AreEqual(appearences[1].LinkTitle, LINK_TITLE_2);
        }

        [TestMethod]
        public void TestCorrecAppearanceOrderAttribute()
        {
            //GIVEN a string representing the html response with 2 appearences (1st and 3rd in HTML_TWO_RESULTS).            
            HtmlHelper htmlHelper = new HtmlHelper();
            //WHEN a new Html helper object get the appearences
            List<SearchAppearence> appearences = htmlHelper.GetUrlAppearencesInHtml(URL, HTML_TWO_RESULTS);
            //THEN the LinkTitle attribute of the returned elements are correct
            Assert.AreEqual(appearences[0].AppearenceOrder, 1);
            Assert.AreEqual(appearences[1].AppearenceOrder, 3);
        }
    }
}
