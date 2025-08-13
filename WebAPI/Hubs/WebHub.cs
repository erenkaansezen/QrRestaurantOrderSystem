using Microsoft.AspNetCore.SignalR;
using Web.BusinessLayer.Abstract;
using Web.DataAccessLayer.Concrete;

namespace WebAPI.Hubs
{
    public class WebHub : Hub
    {
        private readonly ICategoryService _categoryService;
        private readonly IProductService _productService;
        private readonly IOrderDetailService _orderDetailService;
        private readonly IOrderService _orderService;
        private readonly IMoneyCaseService _moneyCaseService;
        private readonly IMenuTableService _menuTableService;
        private readonly IBookingService _bookingService;
        private readonly INotificationService _notificationService;


        public WebHub(ICategoryService categoryService, IProductService productService, IOrderService orderService, IOrderDetailService orderDetailService, IMoneyCaseService moneyCaseService, IMenuTableService menuTableService, IBookingService bookingService, INotificationService notificationService)
        {
            _categoryService = categoryService;
            _productService = productService;
            _orderService = orderService;
            _orderDetailService = orderDetailService;
            _moneyCaseService = moneyCaseService;
            _menuTableService = menuTableService;
            _bookingService = bookingService;
            _notificationService = notificationService;
        }
        public static int clientCount { get; set; } = 0;
        public async Task SendStatistic()
        {
            var countCategory=_categoryService.TCategoryCount();
            await Clients.All.SendAsync("ReceiveCategoryCount", countCategory);

            var countProduct = _productService.TProductCount();
            await Clients.All.SendAsync("ReceiveProductCount", countProduct);

            var countActive = _categoryService.TActiveCategoryCount();
            await Clients.All.SendAsync("ReceiveActiveCategoryCount", countActive);

            var countPassive = _categoryService.TPassiveCategoryCount();
            await Clients.All.SendAsync("ReceivePassiveCategoryCount", countPassive);

            var countProductByHamburger = _productService.TProductCountByCategoryHamburger();
            await Clients.All.SendAsync("ReceiveProductCountByHamburger", countProductByHamburger);

            var countProductByDrink = _productService.TProductCountByCategoryDrink();
            await Clients.All.SendAsync("ReceiveProductCountByDrink", countProductByDrink);

            var priceProductAvg = _productService.TProductPriceAvg();
            await Clients.All.SendAsync("ReceiveProductPriceAvg", priceProductAvg.ToString("0.00") + "₺");

            var nameProductByPriceMax = _productService.TProductNameByPriceByMax();
            await Clients.All.SendAsync("ReceiveProductNameByPriceMax", nameProductByPriceMax);

            var nameProductByPriceMin = _productService.TProductNameByPriceByMin();
            await Clients.All.SendAsync("ReceiveProductNameByPriceMin", nameProductByPriceMin);

            var totalOrderCount = _orderService.TTotalOrderCount();
            await Clients.All.SendAsync("ReceiveTotalOrderCount", totalOrderCount);

            var countActiveOrder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", countActiveOrder);

            var lastOrderPrice = _orderService.TLastOrderPrice();
            await Clients.All.SendAsync("ReceiveLastOrderPrice", lastOrderPrice.ToString("0.00") + "₺");

            var countMoneyCase = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", countMoneyCase.ToString("0.00") + "₺");

            var countDailyEarnings = 1000;
            await Clients.All.SendAsync("ReceiveCountDailyEarnings", countDailyEarnings.ToString("0.00") + "₺");

            var countMenuTable = _menuTableService.TMenuTableCount();
            await Clients.All.SendAsync("ReceiveMenuTableCount", countMenuTable);

            var countActiveMenuTable = _menuTableService.TActiveMenuTableCount();
            await Clients.All.SendAsync("ReceiveActiveMenuTableCount", countActiveMenuTable);
        }

        public async Task SendProgress()
        {
            var totalMoneyCaseAmount = _moneyCaseService.TTotalMoneyCaseAmount();
            await Clients.All.SendAsync("ReceiveTotalMoneyCaseAmount", totalMoneyCaseAmount.ToString("0.00") + "₺");

            var countDailyEarnings = 1000;
            await Clients.All.SendAsync("ReceiveCountDailyEarnings", countDailyEarnings.ToString("0.00") + "₺");

            var countActiveOrder = _orderService.TActiveOrderCount();
            await Clients.All.SendAsync("ReceiveActiveOrderCount", countActiveOrder);

            var countEmptyTables = _menuTableService.TNumberOfEmptyTables();
            await Clients.All.SendAsync("ReceiveNumberOfEmptyTables", countEmptyTables);
        }

        public async Task GetBookingList()
        {
            var bookingList = _bookingService.TGetAll();
            await Clients.All.SendAsync("ReceiveBookingList", bookingList);
        }

        public async Task SendNotification()
        {
            var count = _notificationService.TNotificationCountStatusFalse();
            await Clients.All.SendAsync("ReceiveNotificationCountStatusFalse", count);

            var notificationsList = _notificationService.TGetAllNotificationsByStatusFalse();
            await Clients.All.SendAsync("ReceiveAllNotificationsByStatusFalse", notificationsList);

        }

        public async Task GetTableStatus()
        {
            var value = _menuTableService.TGetAll();
            await Clients.All.SendAsync("ReceiveTableStatus", value);
        }
        public async Task SendMessage(string user,string message)
        { 
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
        public override async Task OnConnectedAsync()
        {
            clientCount++;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnConnectedAsync();
        }
        public override async Task OnDisconnectedAsync(Exception? exception)
        {
            clientCount--;
            await Clients.All.SendAsync("ReceiveClientCount", clientCount);
            await base.OnDisconnectedAsync(exception);
        }
    }
}
