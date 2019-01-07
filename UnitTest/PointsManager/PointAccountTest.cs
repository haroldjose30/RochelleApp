using System;
using Domain.PointsManager;
using Xunit;

namespace Domain.UnitTest.PointsManager
{
    public class PointAccountTest
    {
        readonly string companyId = "companyId";
        readonly string createdBy = "createdBy";
        readonly string customerId = "CustomerId";

        readonly DateTime date = DateTime.Now;
        double value = 10;
        string history = "history";
        string document = "document";
        PointExtractType pointExtractType = PointExtractType.Manual;
        DateTime? expiration = null;


        [Fact]
        public PointAccount EntityCreatedAndAllPropertyTested()
        {
            PointAccount entity = PointAccount.CreateNew(companyId,  createdBy, customerId);

            //assert
            Assert.Equal(createdBy, entity.CreatedBy);
            Assert.Equal(companyId, entity.CompanyId);
            Assert.Equal(customerId, entity.CustomerId);
            Assert.Equal(0, entity.Amount);
            return entity;
        }


        [Fact]
        public PointAccount AddPoints()
        {
            PointAccount entity = EntityCreatedAndAllPropertyTested();
            PointAccountDetail oPointAccountDetail = PointAccountDetail.CreateNew(companyId, createdBy, date, value, history, customerId, document, pointExtractType, expiration);
            entity.AddPoints(oPointAccountDetail);
            Assert.Equal(entity.Items.Count, 1);
            Assert.Equal(entity.Amount, oPointAccountDetail.Value);

            return entity;
        }

        [Fact]
        public PointAccount RemovePoints()
        {
            PointAccount entity = EntityCreatedAndAllPropertyTested();
            PointAccountDetail oPointAccountDetail = PointAccountDetail.CreateNew(companyId, createdBy, date, -value, history, customerId, document, pointExtractType, expiration);
            entity.RemovePoints(oPointAccountDetail);
            Assert.Equal(entity.Items.Count, -oPointAccountDetail.Value);
            return entity;
        }


        [Fact]
        public void TryAddAndRemoveInvalidValuePoints()
        {
            try
            {
                double ValueZero = 0;
                double ValuePositive = 1;
                double ValueNegative = -1;
                PointAccount entity = EntityCreatedAndAllPropertyTested();
                PointAccountDetail oPointAccountDetailZero = PointAccountDetail.CreateNew(companyId, createdBy, date, ValueZero, history, customerId, document, pointExtractType, expiration);
                PointAccountDetail oPointAccountDetailPositive = PointAccountDetail.CreateNew(companyId, createdBy, date, ValuePositive, history, customerId, document, pointExtractType, expiration);
                PointAccountDetail oPointAccountDetailNegative = PointAccountDetail.CreateNew(companyId, createdBy, date, ValueNegative, history, customerId, document, pointExtractType, expiration);
                entity.AddPoints(oPointAccountDetailZero);
                entity.AddPoints(oPointAccountDetailNegative);
                entity.RemovePoints(oPointAccountDetailPositive);
            }
            catch 
            {
                Assert.True(true,"Invalid value bloqued");
                return;
            }

            Assert.True(false, "Invalid value not bloqued");

        }


    }
}
