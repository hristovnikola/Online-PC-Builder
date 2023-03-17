using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Microsoft.AspNet.Identity;
using Proekt2.Models;

namespace Proekt2.Controllers
{
    [Authorize]
    public class PurchasedProductsController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: PurchasedProducts
        public ActionResult Index()
        {
            string userId = User.Identity.GetUserId();
            List<PurchasedProduct> purchasedProducts = db.PurchasedProducts.Where(product => product.UserId.Equals(userId)).ToList();
            return View(purchasedProducts);
        }

        public ActionResult EmptyCart()
        {
            string UserId = User.Identity.GetUserId();
            var products = db.PurchasedProducts.Where(product => product.UserId.Equals(UserId)).ToList();
            db.PurchasedProducts.RemoveRange(products);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        // GET: PurchasedProducts/AddToCart
        public ActionResult AddToCart(int? id, string returnUrl)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product product = db.Products.Find(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            PurchasedProduct purchasedProduct = new PurchasedProduct();
            purchasedProduct.UserId = User.Identity.GetUserId();
            purchasedProduct.Name = product.Name;
            purchasedProduct.ImgURL = product.ImgURL;
            purchasedProduct.Price = product.Price;
            
            db.PurchasedProducts.Add(purchasedProduct);
            db.SaveChanges();

            return Redirect(returnUrl);
        }


        // GET: PurchasedProducts/Delete/5
        public ActionResult Delete(int? id, string returnUrl)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PurchasedProduct purchasedProduct = db.PurchasedProducts.Find(id);
            if (purchasedProduct == null)
            {
                return HttpNotFound();
            }

            db.PurchasedProducts.Remove(purchasedProduct);
            db.SaveChanges();

            return Redirect(returnUrl);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
