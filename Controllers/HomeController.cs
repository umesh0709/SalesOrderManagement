using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using System.IO;
using SalesOrderManagement.Models;

namespace SalesOrderManagement.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet("/order")]
        public IActionResult Order()
        {
            var filePath = Path.Combine(Directory.GetCurrentDirectory(), "Data", "orders.json");
            if (!System.IO.File.Exists(filePath))
            {
                return NotFound();
            }

            var json = System.IO.File.ReadAllText(filePath);
            // Return raw JSON string to avoid serializer issues/double-serialization
            return Content(json, "application/json");
        }

        [HttpPost("/order/upload")]
        public IActionResult UploadOrder(IFormFile file)
        {
            // Confirm file has been received
            var fileReceived = file != null && file.Length > 0;
            var fileName = file?.FileName ?? "No file received";
            var fileSize = file?.Length ?? 0;

            // Return hardcoded response
            var response = new
            {
                orderLineItems = new[]
                {
                    new
                    {
                        itemName = "Laptop",
                        quantity = 2,
                        manufatcurer = "Dell",
                        price = (decimal?)388.89
                    },
                    new
                    {
                        itemName = "Mouse",
                        quantity = 5,
                        manufatcurer = "Logitech",
                        price = (decimal?)28.45
                    }
                },
                sourceFileName = "sample_purchase_order.msg",
                detectedType = "EmailFileParser",
                success = true,
                errorMessage = (string)null
            };

            return Ok(response);
        }

        [HttpPost("/order/create")]
        public IActionResult CreateOrder([FromBody] CreatePurchaseOrderRequestDto orderData)
        {
            return Ok();
        }

        [HttpGet("/items")]
        public IActionResult GetItems([FromQuery] int? itemId)
        {
            var items = new List<object>
            {
                new
                {
                    itemId = 1,
                    productName = "Wireless Mouse",
                    productDescription = "Wireless mouse by Logitech, ergonomic and responsive.",
                    price = 25.5,
                    desc = "Wireless mouse with high precision, ideal for office work and gaming.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 150,
                    manufacturer = "Logitech"
                },
                new
                {
                    itemId = 2,
                    productName = "Keyboard",
                    productDescription = "Microsoft ergonomic keyboard, soft-touch keys and adjustable height.",
                    price = 49.5,
                    desc = "Quiet and ergonomic design, perfect for long typing sessions.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 100,
                    manufacturer = "Microsoft"
                },
                new
                {
                    itemId = 3,
                    productName = "Laptop Bag",
                    productDescription = "Stylish and durable laptop bag from HP, fits up to 15\" laptops.",
                    price = 99.99,
                    desc = "A sleek and professional laptop bag with multiple compartments for your accessories.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 50,
                    manufacturer = "HP"
                },
                new
                {
                    itemId = 4,
                    productName = "USB Hub",
                    productDescription = "4-port USB Hub by Anker, fast data transfer, compact size.",
                    price = 50,
                    desc = "Compact and reliable USB hub with 4 high-speed ports for your devices.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 200,
                    manufacturer = "Anker"
                },
                new
                {
                    itemId = 5,
                    productName = "Bluetooth Speaker",
                    productDescription = "Portable Bluetooth speaker by JBL, 10 hours of battery life.",
                    price = 75.25,
                    desc = "High-quality portable speaker with clear sound, perfect for outdoor activities.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 120,
                    manufacturer = "JBL"
                },
                new
                {
                    itemId = 6,
                    productName = "HDMI Cable",
                    productDescription = "High-speed HDMI cable, supports 4K video.",
                    price = 15,
                    desc = "Durable HDMI cable that supports 4K resolution for superior picture quality.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 250,
                    manufacturer = "Belkin"
                },
                new
                {
                    itemId = 7,
                    productName = "Webcam",
                    productDescription = "Full HD Webcam by Logitech, ideal for video calls and streaming.",
                    price = 60,
                    desc = "HD resolution webcam with built-in microphone for crisp video and sound.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 80,
                    manufacturer = "Logitech"
                },
                new
                {
                    itemId = 8,
                    productName = "Monitor",
                    productDescription = "27-inch Full HD Monitor by Dell, slim design, anti-glare.",
                    price = 225,
                    desc = "A professional-grade monitor with anti-glare technology and vibrant color display.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 60,
                    manufacturer = "Dell"
                },
                new
                {
                    itemId = 9,
                    productName = "External HDD",
                    productDescription = "2TB External Hard Drive by Seagate, portable storage for all your data.",
                    price = 99.99,
                    desc = "External hard drive with large storage capacity and fast data transfer speed.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 100,
                    manufacturer = "Seagate"
                },
                new
                {
                    itemId = 10,
                    productName = "Wireless Earbuds",
                    productDescription = "True wireless earbuds by Samsung, high-quality sound and comfort.",
                    price = 120,
                    desc = "Comfortable and high-performance wireless earbuds with noise-canceling feature.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 150,
                    manufacturer = "Samsung"
                },
                new
                {
                    itemId = 11,
                    productName = "Power Bank",
                    productDescription = "Portable Power Bank by Mi, 10,000mAh capacity, compact design.",
                    price = 44.88,
                    desc = "Reliable and compact power bank to charge your devices on the go.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 200,
                    manufacturer = "Mi"
                },
                new
                {
                    itemId = 12,
                    productName = "Mechanical Keyboard",
                    productDescription = "RGB Mechanical Keyboard by Keychron, designed for gamers and typists.",
                    price = 175,
                    desc = "Responsive mechanical keyboard with customizable RGB backlighting for gaming or typing.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 80,
                    manufacturer = "Keychron"
                },
                new
                {
                    itemId = 13,
                    productName = "Mouse Pad",
                    productDescription = "Gaming Mouse Pad by SteelSeries, large size, anti-slip base.",
                    price = 15,
                    desc = "Durable mouse pad with extra-large surface for gaming and office use.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 300,
                    manufacturer = "SteelSeries"
                },
                new
                {
                    itemId = 14,
                    productName = "Portable Charger",
                    productDescription = "Compact and fast-charging portable charger by Anker.",
                    price = 40,
                    desc = "Portable charger with fast-charging capabilities to keep your devices powered on the go.",
                    createdOn = "2025-12-14T09:29:06.703",
                    availableQty = 150,
                    manufacturer = "Anker"
                }
            };

            if (itemId.HasValue)
            {
                var item = items.FirstOrDefault(i => ((dynamic)i).itemId == itemId.Value);
                if (item == null)
                {
                    return NotFound();
                }
                return Ok(item);
            }

            return Ok(items);
        }

        [HttpGet("/users/{customerId}")]
        public IActionResult GetUser(string customerId)
        {
            var user = new
            {
                userId = 2,
                firstName = "Amit",
                lastName = "Kumar",
                email = "amit@gmail.com",
                contactNo = "9876543210",
                address = "Shivaji Nagar,Pune",
                zipCode = "411222",
                userType = "Customer"
            };

            return Ok(user);
        }

        [HttpPost("/orders/{orderId}/cancel")]
        public IActionResult CancelOrder(int orderId)
        {
            return Ok();
        }
        
    }
}
