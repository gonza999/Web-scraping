using Conexion;
using HtmlAgilityPack;
using ScrapySharp.Extensions;
using Servicios;
using System.Collections.Generic;
using System.Linq;


namespace WebScraping.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            ServicioTitles servicioTitles = new ServicioTitles();
            List<string> Titulos = new List<string>();
            HtmlWeb html = new HtmlWeb();
            for (int i = 1; i <= 32; i++)
            {
                string url = "https://hdeleon.net/";
                if (i>1)
                {
                    url += "/page/" + i + "/";
                }
                HtmlDocument doc = html.Load(url);

                foreach (var nodo in doc.DocumentNode.CssSelect(".entry-title"))
                {
                    var NodoAnchor = nodo.CssSelect("a").First();
                    Titulos.Add(NodoAnchor.InnerHtml);
                    //foreach (var n in Titulos)
                    //{
                    //    Title title = new Title();
                    //    title.Nombre = n;
                    //    servicioTitles.Guardar(title);
                    //    System.Console.WriteLine(n);
                    //}
                }

            }
            //HtmlNode Body = doc.DocumentNode.CssSelect("head").First();
            //string body = Body.InnerHtml;
      
            foreach (var n in Titulos)
            {
                Title title = new Title();
                title.Nombre = n;
                servicioTitles.Guardar(title);
                System.Console.WriteLine(n);
            }
            System.Console.ReadKey();
        }
    }
}
