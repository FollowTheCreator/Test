using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Linq;
using Web.Models;

namespace Web.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index(int page = 1)
        {
            DataContext db = new DataContext(@"data source=(localdb)\MSSQLLocalDB;initial catalog=TestDB;integrated security=True;MultipleActiveResultSets=True;App=EntityFramework");
            int count = db.GetTable<rss>().Count();
            int pageSize = 10;

            IEnumerable<rss> currentNews = (from item in db.GetTable<rss>()
                                            select item)
                                            .Skip((page - 1) * pageSize)
                                            .Take(pageSize);

            pageInfo pageInfo = new pageInfo { pageNumber = page, pageSize = pageSize, totalItems = count };
            indexViewModel ivm = new indexViewModel { pageInfo = pageInfo, rssList = currentNews };
            return View(ivm);
        }
    }
}