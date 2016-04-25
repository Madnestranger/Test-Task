using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TestTask.Models;

namespace TestTask.Controllers
{
    public class GridViewController : Controller
    {

        private List<User> _users;

        public GridViewController()
        {
            _users = new List<User>() {
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Vadym Prosianiuk",Gender = Gender.Male, Age=18, Email="vvertigoo@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Danil Lystopadov",Gender = Gender.Male, Age=18, Email="koorool@gmail.com" },
                new User { Id=Guid.NewGuid().ToString(), Name = "Maiia Zajtseva",Gender = Gender.Female, Age=18, Email="zaiec@gmail.com" }
            };

        }
        public ActionResult Index()
        {
            Session["users"] = _users;
            return View();
        }

        [HttpGet]
        public JsonResult GetData()
        {
            _users = Session["users"] as List<User>;
            return Json(_users, JsonRequestBehavior.AllowGet);
        }

        [HttpPost]
        public JsonResult EditUser(User model)
        {


            _users = Session["users"] as List<User>;
            var success = true;
            //var genderValue = (Gender)Enum.Parse(typeof(Gender), model.Gender);
            // Enum myGender = model.Gender;
            if (!ModelState.IsValid) return Json(false);

            if (model.IsNew)
            {
                model.Id = Guid.NewGuid().ToString();
                model.IsNew = false;
                _users.Add(model);
            }
            else
            {
                var curUser = _users.FirstOrDefault(t => t.Id == model.Id);
                if (curUser != null)
                {
                    curUser.Name = model.Name;
                    curUser.Email = model.Email;
                    curUser.Age = model.Age;
                    curUser.Gender = model.Gender;
                    //curUser.Gender = myGender.ToString();
                }
                else
                    success = false;

            }

            return Json(success);

        }


        [HttpPost]
        public JsonResult DeleteUser(string id)
        {
            _users = Session["users"] as List<User>;
            var success = true;
            var user = _users.FirstOrDefault(t => t.Id == id);
            if (user != null)
            {
                _users.Remove(user);
            }
            else
                success = false;

            return Json(success);
        }
    }
}