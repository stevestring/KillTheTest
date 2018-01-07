using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace KillTheTest.Helpers
{
    public static class Helpers
    {
        public static MvcHtmlString ConvertHtml(string text)
        {
            string retVal=text;

            if (text == null)
            {
                retVal = "";
            }

            retVal = retVal.Replace("[lineBreak]", "<br />");
            retVal = retVal.Replace("[paraBreak]", "<br /><br />");
            retVal = retVal.Replace("[checkMark]", "&nbsp;<strong><span style='font-size: 13pt; color:grey;'>&#x2713;</span></strong>");
            retVal = retVal.Replace("[xMark]", "&nbsp;<strong><span style='font-size: 13pt; color:grey;'>&#x2717;</span></strong>");
            retVal = retVal.Replace("[rightArrow]", "&rarr;");
            retVal = retVal.Replace("[leftArrow]", "&larr;");

            retVal = retVal.Replace("[answer]", "<span id='answer' class='answer'>answer here</span>");

            retVal = retVal.Replace("[wrongClick]", "<span class='wrongClick'>");
            retVal = retVal.Replace("[/wrongClick]", "</span>");
            retVal = retVal.Replace("[rightClick]", "<span class='rightClick'>");
            retVal = retVal.Replace("[/rightClick]", "</span>");

            retVal = retVal.Replace("[hint]", "<span class='hint'>");
            retVal = retVal.Replace("[/hint]", "</span>");


            retVal = retVal.Replace("[strikeOut]", "<span style='text-decoration:line-through'>");
            retVal = retVal.Replace("[/strikeOut]", "</span>");
            retVal = retVal.Replace("[italics]", "<em>");
            retVal = retVal.Replace("[/italics]", "</em>");
            retVal = retVal.Replace("[bold]", "<strong>");
            retVal = retVal.Replace("[/bold]", "</strong>");
            retVal = retVal.Replace("[underline]", "<u>");
            retVal = retVal.Replace("[/underline]", "</u>");

            retVal = retVal.Replace("[orange]", "<span style='color:#ffa07a'>");
            retVal = retVal.Replace("[/orange]", "</span>");
            retVal = retVal.Replace("[red]", "<span style='color:#914746'>");
            retVal = retVal.Replace("[/red]", "</span>");
            retVal = retVal.Replace("[gray]", "<span style='color:#D0D0D0'>");
            retVal = retVal.Replace("[/gray]", "</span>");
            retVal = retVal.Replace("[blue]", "<span style='color:#2b426e'>");
            retVal = retVal.Replace("[/blue]", "</span>");




            return new MvcHtmlString(retVal);
        }


        public static MvcHtmlString Compliment()
        {
            string retVal = "";
            Random r = new Random();

            List<string> compliments = new List<string>{
            "Excellent. Killed it.",
            "Excellent. Killed it.",
            "Excellent. Killed it.",
            "Excellent. Killed it.",
            "Cool. Killed it.",
            "Good stuff.",
            "Ay-o! Nice.",
            "Sweet deal.",
            "Good deal.",
            "Ingenious.",
            "Brilliant.",
            "Killin' it.",
            "YAASSSS!",
            "Kilt' it.",
            "Killin' it.",
            "You're like a hyper-intelligent robot.",
            "Well, you've killed the question. Now what?"};

            int i = r.Next(compliments.Count());;

            retVal = compliments[i];

            return new MvcHtmlString(retVal);
        }

        public static MvcHtmlString Criticism()
        {
            string retVal = "";
            Random r = new Random();

            List<string> criticisms = new List<string>{
            "Be cool. Be cool.",
            "Slow your roll.",
            "You forgot to check yourself, and now you've wrecked yourself.",
            "Stop trying to make that answer happen.",
            "Whoa, there.",
            "The question is still very much alive.",
            "Not this time.",
            "Not yet."};

            int i = r.Next(criticisms.Count()); ;

            retVal = criticisms[i];

            return new MvcHtmlString(retVal);
        }

    }
}

