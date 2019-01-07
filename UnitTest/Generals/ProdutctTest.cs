using System;
using Domain.Generals;
using Xunit;

namespace Domain.UnitTest.Generals
{
    public class ProdutctTest
    {
        readonly string companyId = "companyId";
        readonly string id = "id";
        readonly string createdBy = "createdBy";
        readonly string name = "name";
        readonly ProductType productType = ProductType.Product;

        [Fact]
        public void EntityCreatedAndAllPropertyTested()
        {
            Product entity = Product.CreateNew(companyId,id, createdBy, name, productType);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(name, entity.Name);
            Assert.Equal(productType, entity.ProductType);
        }
    }
}
