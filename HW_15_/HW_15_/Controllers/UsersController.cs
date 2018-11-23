using HW_15_.Context;
using HW_15_.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HW_15_.Controllers
{
    public class UsersController : Controller
    {
        UsersContext db = new UsersContext();
        ListUsers users = new ListUsers();

        [HttpGet]
        public ActionResult Add(string id, string change)
        {
            if (change == "Change")
            {
                ViewBag.ID = Int32.Parse(id);

                ViewBag.Change = "Change";

                List<User> list = db.Users.ToList();

                return View(list[Int32.Parse(id)]);
            }
            else
            {
                ViewBag.ID = -1;

                ViewBag.Change = "Add";

                return View();
            }
        }

        [HttpPost]
        public ActionResult Add(User user, string type)
        {
            if (ModelState.IsValid)
            {
                if (type == "Change")
                {
                    db.Entry(user).State = EntityState.Modified;

                    db.SaveChanges();

                    return RedirectToAction("AllUsers");
                }
                else
                {
                    db.Users.Add(user);

                    db.SaveChanges();

                    ViewBag.ID = -1;

                    ViewBag.Change = "Add";

                    return View();
                }
            }
            else
            {
                ViewBag.Eror = "Не дообавлено";

                ViewBag.Change = "Add";

                ViewBag.ID = -1;

                return View(user);
            }
        }

        [HttpGet]
        public ActionResult AllUsers(string id)
        {
            if (id == "" || id == null)
            {
                return RedirectToRoute(new { id = 0 });
            }
            int idInt = Int32.Parse(id);

            return View(GetUserList(idInt));
        }

        [HttpPost]
        public ActionResult AllUsers(string usersId, string change, string search, string id)
        {
            int idInt = Int32.Parse(id);

            int maxId = db.Users.Count();

            if (change == "Change")
            {
                return RedirectToAction("Add", new { id = (Int32.Parse(usersId) + idInt * 20), change });
            }
            else if (change == "Remove")
            {
                users = Remove((Int32.Parse(usersId) + idInt * 20));

                return View(GetUserList(idInt, users));
            }
            else if (change == "Search")
            {
                if (search != null || search != "")
                {
                    users.UsersList = db.Users.Where(user => user.Name.Contains(search)).ToList();
                }
                else
                {
                    users.UsersList = db.Users.ToList();
                }
                return View(GetUserList(0, users));
            }
            else if (change == "Next" & (idInt + 1) * 20 <= maxId)
            {
                return RedirectToRoute(new { id = ++idInt });
            }
            else if (change == "Paste" & (idInt - 1) >= 0)
            {
                return RedirectToRoute(new { id = --idInt });
            }
            else
            {
                return View(GetUserList(idInt));
            }
        }

        private ListUsers Remove(int id)
        {
            users.UsersList = db.Users.ToList();

            db.Users.Remove(users.UsersList[id]);

            db.SaveChanges();

            users.UsersList.RemoveAt(id);

            return users;
        }

        private User Change(int id)
        {
            users.UsersList = db.Users.ToList();

            return users.UsersList[id];
        }

        private ListUsers GetUserList(int id)
        {
            users.UsersList = db.Users.ToList();

            int lenght = users.UsersList.Count;

            ListUsers listUsers = new ListUsers();
            listUsers.UsersList = new List<User>();

            for (int i = id * 20, j = 0; i < (id + 1) * 20 & i < lenght; i++, j++)
            {
                listUsers.UsersList.Add(users.UsersList[i]);
            }

            return listUsers;
        }

        private ListUsers GetUserList(int id, ListUsers users)
        {
            int lenght = users.UsersList.Count;

            ListUsers listUsers = new ListUsers();
            listUsers.UsersList = new List<User>();

            for (int i = id * 20, j = 0; i < (id + 1) * 20 & i < lenght; i++, j++)
            {
                listUsers.UsersList.Add(users.UsersList[i]);
            }

            return listUsers;
        }

    }
}