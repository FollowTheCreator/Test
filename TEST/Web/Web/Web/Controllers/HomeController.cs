using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq;
using Web.Models;
using System.Data.Linq.SqlClient;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        //путь к бд нужно менять, '..\..\..\..\' не сработало
        DataContext db = new DataContext(@"data source=(localdb)\MSSQLLocalDB;AttachDbFilename=C:\Users\Artyom\Test\TEST\TestDB.mdf;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");

        public ActionResult Index(int page = 1, string source = "%", string sort = "date")
        {
            int count = (from item in db.GetTable<rss>()
                         where SqlMethods.Like(item.source, source)
                         select item)
                        .Count();
            int pageSize = 10;

            IEnumerable<rss> currentNews = rssQuery(sort, source, page, pageSize, db);

            pageInfo pageInfo = new pageInfo { pageNumber = page, pageSize = pageSize, totalItems = count };
            indexViewModel ivm = new indexViewModel { pageInfo = pageInfo, rssList = currentNews };
            return View(ivm);
        }

        [HttpPost]
        public ActionResult ajaxPageLinks(int page = 1, string source = "%", string sort = "date")
        {
            int count = (from item in db.GetTable<rss>()
                         where SqlMethods.Like(item.source, source)
                         select item)
                        .Count();
            int pageSize = 10;

            IEnumerable<rss> currentNews = rssQuery(sort, source, page, pageSize, db);

            pageInfo pageInfo = new pageInfo { pageNumber = page, pageSize = pageSize, totalItems = count };
            indexViewModel ivm = new indexViewModel { pageInfo = pageInfo, rssList = currentNews };
            return PartialView(ivm);
        }

        public static IEnumerable<rss> rssQuery(string sort, string source, int page, int pageSize, DataContext db)
        {
            IEnumerable<rss> currentNews;
            if (sort == "date")
            {
                currentNews = (from item in db.GetTable<rss>()
                               where SqlMethods.Like(item.source, source)
                               orderby item.date descending
                               select item)
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize);
            }
            else
            {
                currentNews = (from item in db.GetTable<rss>()
                               where SqlMethods.Like(item.source, source)
                               orderby item.source
                               select item)
                               .Skip((page - 1) * pageSize)
                               .Take(pageSize);
            }
            return currentNews;
        }
    }
}