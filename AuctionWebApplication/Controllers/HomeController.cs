using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using AuctionWebApplication.Models;
using ServiceReference1;

namespace AuctionWebApplication.Controllers
{
    public class HomeController : Controller
    {
        AuctionsServiceClient auctionService = new AuctionsServiceClient();
        public async Task<IActionResult> Index()
        {

            return View(await auctionService.GetAllAuctionItemsAsync());
        }

        public async Task<IActionResult> About(int id)
        {

            return View(await auctionService.GetAuctionItemAsync(id));
        }
        [HttpPost]
        public async Task<IActionResult> About(AuctionItem item)
        {
            await auctionService.ProvideBidAsync(item.ItemNumber, item.BidPrice, item.BidCustomName, item.BidCustomPhone);
            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
