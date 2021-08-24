using System.Linq;
using Xunit;
using ZbW.ITB1821H.OrderManager.Model.Dto;
using ZbW.ITB1821H.OrderManager.Model.Entities;
using ZbW.ITB1821H.OrderManager.Model.Repository;
using ZbW.ITB1821H.OrderManager.Model.Service;

namespace ZbW.ITB1821H.OrderManager.Tests.ModelTest
{
    public class BaseTests
    {
        //#region Repository
        //[Fact]
        //public void RepositoryBaseGetAll_GetAllWithFilter_ReturnsTrue()
        //{
        //    using (DbContext)
        //    {
        //        var repo = new RepositoryBase<Customer>(DbContext);
        //        var customersContext = DbContext.Customers.Where(x => x.Name.StartsWith("C")).ToList();
        //        var customers = repo.GetAll(x => x.Name.StartsWith("C"));

        //        Assert.True(customers.Count == customersContext.Count);
        //    }
        //}

        //[Fact]
        //public void RepositoryBaseGetAll_GetAll_ReturnsTrue()
        //{
        //    using (DbContext)
        //    {
        //        var repo = new RepositoryBase<Customer>(DbContext);
        //        var customersContext = DbContext.Customers.ToList();
        //        var customers = repo.GetAll();

        //        Assert.True(customers.Count == customersContext.Count);
        //    }
        //}

        //[Fact]
        //public void RepositoryBaseGetSingle_GetSingle_ReturnsEqual()
        //{
        //    using (DbContext)
        //    {
        //        var repo = new RepositoryBase<Customer>(DbContext);
        //        var customerContext = DbContext.Customers.Where(x => x.Id == 12).SingleOrDefault();
        //        var customer = repo.GetSingle(12);

        //        Assert.Equal(customer, customerContext);
        //    }
        //}
        //#endregion Repository

        //#region Service
        ////[Fact]
        ////public void ServiceBaseGetAll_GetAllWithFilter_ReturnsTrue()
        ////{
        ////    var service = new ServiceBase<Customer, CustomerDto>(OptionsBuilder);
        ////    var customersContext = DbContext.Customers.Where(x => x.Name.StartsWith("C")).ToList();
        ////    var customers = service.GetAll(x => x.Name.StartsWith("C"));

        ////    Assert.Equal(customers.Count(), customersContext.Count());
        ////}

        ////[Fact]
        ////public void ServiceBaseGetAll_GetAll_ReturnsTrue()
        ////{
        ////    var service = new ServiceBase<Customer, CustomerDto>(OptionsBuilder);
        ////    var customersContext = DbContext.Customers.ToList();
        ////    var customers = service.GetAll();

        ////    Assert.True(customers.Count() == customersContext.Count());
        ////}

        ////[Fact]
        ////public void ServiceBaseGetSingle_GetSingle_ReturnsTrue()
        ////{
        ////    var service = new ServiceBase<Customer, CustomerDto>(OptionsBuilder);
        ////    var customerContext = DbContext.Customers.Where(x => x.Id == 12).SingleOrDefault();
        ////    var customer = service.GetSingle(12);

        ////    Assert.True(
        ////        customer.Id == customerContext.Id
        ////        && customer.Name == customerContext.Name
        ////        && customer.LastName == customerContext.LastName
        ////        && customer.Website == customerContext.Website);
        ////}
        //#endregion Service
    }
}
