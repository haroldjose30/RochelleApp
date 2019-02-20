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
        readonly Decimal value = 10;
        readonly string history = "history";
        readonly string document = "document";
        readonly PointExtractType pointExtractType = PointExtractType.Manual;
        readonly DateTime? expiration;


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

            //todo: verificar como bloquear para nao permitir adicionar um item em uma lista por fora da classe
            //entity.Items.Add(oPointAccountDetail);

            entity.AddPoints(oPointAccountDetail);
            Assert.Single(entity.Items);
            Assert.Equal(oPointAccountDetail.Value,entity.Amount);

            return entity;
        }

        [Fact]
        public PointAccount RemovePoints()
        {
            PointAccount entity = EntityCreatedAndAllPropertyTested();
            PointAccountDetail oPointAccountDetail = PointAccountDetail.CreateNew(companyId, createdBy, date, -value, history, customerId, document, pointExtractType, expiration);
            entity.RemovePoints(oPointAccountDetail);
            Assert.Single(entity.Items);
            Assert.Equal(oPointAccountDetail.Value,entity.Amount);
            return entity;
        }


        [Fact]
        public void TryAddAndRemoveInvalidValuePoints()
        {
            Decimal ValueZero = 0;
            Decimal ValuePositive = 1;
            Decimal ValueNegative = -1;
            PointAccount entity = EntityCreatedAndAllPropertyTested();
            PointAccountDetail oPointAccountDetailZero = PointAccountDetail.CreateNew(companyId, createdBy, date, ValueZero, history, customerId, document, pointExtractType, expiration);
            PointAccountDetail oPointAccountDetailPositive = PointAccountDetail.CreateNew(companyId, createdBy, date, ValuePositive, history, customerId, document, pointExtractType, expiration);
            PointAccountDetail oPointAccountDetailNegative = PointAccountDetail.CreateNew(companyId, createdBy, date, ValueNegative, history, customerId, document, pointExtractType, expiration);

            Exception ex = Assert.Throws<Exception>(() => entity.AddPoints(oPointAccountDetailZero));
            Exception ex2 = Assert.Throws<Exception>(() => entity.AddPoints(oPointAccountDetailNegative));
            Exception ex3 = Assert.Throws<Exception>(() => entity.RemovePoints(oPointAccountDetailZero));
            Exception ex4 = Assert.Throws<Exception>(() => entity.RemovePoints(oPointAccountDetailPositive));

        }


    }
}
