using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Caching;

namespace CacheDemo
{
    public partial class CacheDemoPage : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            string result = string.Empty;

            if (!IsPostBack)
            {
                result = DateTime.Now.ToString();
                Cache.Insert("Trigger", DateTime.Now, null,
    DateTime.Now.AddSeconds(60), Cache.NoSlidingExpiration);
                CacheDependency cd = new CacheDependency(null,
                new string[] { "Trigger" });
                Cache.Insert("ActiveBugs", result, cd, Cache.NoAbsoluteExpiration, TimeSpan.FromSeconds(15));
            }
            
            CachedItem.Text = Cache["ActiveBugs"].ToString();
        }
    }
}