using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestApplication.Models;

namespace TestApplication.Controllers
{
    public class UserController : Controller
    {
        // GET: User
        public ActionResult Index()
        {
            return View();
        }

        public List<string> GetPropertiesNameOfClass(UserModel olduser, UserModel newuser)
        {
            List<string> propertyNameList = new List<string>();
            List<string> propertyOldValue = new List<string>();
            List<string> propertyNewValue = new List<string>();


            if (olduser != null)
            {

                foreach (var prop in olduser.GetType().GetProperties())
                {

                    propertyNameList.Add(prop.Name);

                    //propertyOldValue = prop.ToString;


                    var value = prop;

                }

            }
            if (newuser != null)
            {
                foreach (var prp in newuser.GetType().GetProperties())
                {
                   // propertyNewValue = prp.ToString;
                }
            }

            propertyNameList.AddRange(propertyOldValue);
            propertyNameList.AddRange(propertyNewValue);

            return propertyNameList;
        }
    }
}