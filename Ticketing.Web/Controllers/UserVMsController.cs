//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Data.Entity;
//using System.Linq;
//using System.Threading.Tasks;
//using System.Net;
//using System.Web;
//using System.Web.Mvc;
//using Ticketing.Data.TicketModel.ViewModels;
//using Ticketing.Identity;

//namespace Ticketing.Controllers
//{
//    public class UserVMsController : Controller
//    {
//        private ApplicationDbContext db = new ApplicationDbContext();

//        // GET: UserVMs
//        public async Task<ActionResult> Index()
//        {
//            return View(await db.UserVMs.ToListAsync());
//        }

//        // GET: UserVMs/Details/5
//        public async Task<ActionResult> Details(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserVM userVM = await db.UserVMs.FindAsync(id);
//            if (userVM == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userVM);
//        }

//        // GET: UserVMs/Create
//        public ActionResult Create()
//        {
//            return View();
//        }

//        // POST: UserVMs/Create
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Create([Bind(Include = "Id,FirstName,LastName,Email,IsEmailVerified,IsRegistrationApproved")] UserVM userVM)
//        {
//            if (ModelState.IsValid)
//            {
//                db.UserVMs.Add(userVM);
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }

//            return View(userVM);
//        }

//        // GET: UserVMs/Edit/5
//        public async Task<ActionResult> Edit(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserVM userVM = await db.UserVMs.FindAsync(id);
//            if (userVM == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userVM);
//        }

//        // POST: UserVMs/Edit/5
//        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
//        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
//        [HttpPost]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> Edit([Bind(Include = "Id,FirstName,LastName,Email,IsEmailVerified,IsRegistrationApproved")] UserVM userVM)
//        {
//            if (ModelState.IsValid)
//            {
//                db.Entry(userVM).State = EntityState.Modified;
//                await db.SaveChangesAsync();
//                return RedirectToAction("Index");
//            }
//            return View(userVM);
//        }

//        // GET: UserVMs/Delete/5
//        public async Task<ActionResult> Delete(string id)
//        {
//            if (id == null)
//            {
//                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
//            }
//            UserVM userVM = await db.UserVMs.FindAsync(id);
//            if (userVM == null)
//            {
//                return HttpNotFound();
//            }
//            return View(userVM);
//        }

//        // POST: UserVMs/Delete/5
//        [HttpPost, ActionName("Delete")]
//        [ValidateAntiForgeryToken]
//        public async Task<ActionResult> DeleteConfirmed(string id)
//        {
//            UserVM userVM = await db.UserVMs.FindAsync(id);
//            db.UserVMs.Remove(userVM);
//            await db.SaveChangesAsync();
//            return RedirectToAction("Index");
//        }

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing)
//            {
//                db.Dispose();
//            }
//            base.Dispose(disposing);
//        }
//    }
//}
