using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BethanyPieShop.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BethanyPieShop.Controllers
{
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderRepository _orderRepository;
        private readonly ShoppingCart _shoppingCart;

        public OrderController(IOrderRepository orderRepository,
                               ShoppingCart shoppingCart)
        {
            _orderRepository = orderRepository;
           _shoppingCart = shoppingCart;
        }

        
        public IActionResult CheckOut()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CheckOut(Order order)
        {
            var items = _shoppingCart.GetShoppingCartItems();
            var testList =_shoppingCart.ShoppingCartItems;
            //_shoppingCart.ShoppingCartItems = items;

            if(_shoppingCart.ShoppingCartItems.Count == 0)
            {
                ModelState.AddModelError("", "Your cart is empty, add some pies first");
            }

            if(ModelState.IsValid)
            {
                _orderRepository.CreateOrder(order);
                _shoppingCart.ClearCart();
                return RedirectToAction("CheckOutComplete");
            }
            return View(order);
        }

        public IActionResult CheckOutComplete()
        {
            ViewBag.CheckOutCompleteMessage = "Thanks for your order. You'll soon enjoy our delicious pies!";
            return View();
        }
    }
}
