using System;
using System.Collections.Generic;

namespace Ticketing.Data.TicketModel.ViewModels
{
    public class Products
    {
        public string name { get; set; }
        public double price { get; set; }
        public DateTime proDate { get; set; }
    }
    public class Test
    {
        public Test()
        {
            Products = new List<Products>();
        }

        public List<Products> Products { get; set; }
        public void Get()
        {

        }
    }

    public class ProductsViewModel
    {
        public ProductsViewModel()
        {
            Products = new List<Products>();
            EventCommand = "List";
            SearchEntity = new Products();
        }
        public string EventCommand { get; set; }
        public List<Products> Products { get; set; }
        public Products SearchEntity { get; set; }

        public void HandleRequest()
        {
            switch (EventCommand.ToLower())
            {
                case "list":
                case "search":
                    Get();
                    break;
                case "resetSearch":
                    ResetSearch();
                    Get();
                    break;
                default:
                    break;
            }
        }

        private void ResetSearch()
        {
            SearchEntity = new Products();
        }
        public void Get()
        {
            TestProductManager mgr = new TestProductManager();
            Products = mgr.Get(SearchEntity);
        }
    }

    public class TestProductManager
    {
        public List<Products> Get(Products entity)
        {
            List<Products> ret = new List<Products>();
            ret = CreateMockData();
            if (!string.IsNullOrEmpty(entity.name))
            {
                ret = ret.FindAll(p => p.name.ToLower().StartsWith(entity.name,StringComparison.CurrentCultureIgnoreCase));
            }
            return ret;
        }
        private List<Products> CreateMockData()
        {
            List<Products> ret = new List<Products>();
            ret.Add(new Products
            {
                name = "Computer",
                price = 44.3,
                proDate = Convert.ToDateTime("4/11/2012")
            });

            ret.Add(new Products
            {
                name = "Der Lamp",
                price = 44.3,
                proDate = Convert.ToDateTime("4/11/2012")
            });

            ret.Add(new Products
            {
                name = "Die Liecht",
                price = 44.3,
                proDate = Convert.ToDateTime("4/11/2012")
            });

            ret.Add(new Products
            {
                name = "Das Fernsehen",
                price = 44.3,
                proDate = Convert.ToDateTime("4/11/2012")
            });

            return ret;
        }
    }
}
