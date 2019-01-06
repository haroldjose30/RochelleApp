using System;
using System.Threading.Tasks;
using Framework.NetStd.Models;
using Xunit;

namespace Domain.UnitTest.Models
{
    public class EntityTests
    {
        private readonly string id = "id";
        private readonly string UserTest1 = "UserTest1";
        private readonly string UserTest2 = "UserTest2";

        [Fact]
        public Entity EntityMustBeCreated()
        {
            Entity entity = new Entity(id: id, createdBy: UserTest1);

            //assert
            Assert.Equal(id, entity.Id);
            Assert.Equal(UserTest1, entity.CreatedBy);
            Assert.NotEmpty(entity.CreatedDate);
            Assert.False(entity.Deleted, "deleted entity created");
            return entity;
        }

        [Fact]
        public async Task EntityMustBeUpdatedAsync()
        {
            Entity entity = EntityMustBeCreated();

            var cCreatedDate = entity.CreatedDate;
            var cModifiedDate = entity.ModifiedDate;

            await Task.Delay(1000);

            entity.Update(UserTest2);

            Assert.NotEqual(UserTest2, entity.CreatedBy);
            Assert.Equal(UserTest2, entity.ModifiedBy);
            Assert.Equal(cCreatedDate, entity.CreatedDate);
            Assert.NotEqual(cModifiedDate, entity.ModifiedDate);
            Assert.False(entity.Deleted, "deleted entity updated");


        }





        [Fact]
        public async Task EntityMustBeDeleted()
        {
            Entity entity = EntityMustBeCreated();

            var cModifiedDate = entity.ModifiedDate;

            await Task.Delay(1000);

            entity.Delete(UserTest2);

            Assert.NotEqual(UserTest2, entity.CreatedBy);
            Assert.Equal(UserTest2, entity.ModifiedBy);
            Assert.NotEqual(cModifiedDate, entity.ModifiedDate);
            Assert.True(entity.Deleted, "not deleted");
        }

        [Fact]
        public void TryingUpdateADeletedEntity()
        {

            var lExceptionThrowed = false;

            try
            {
                Entity entity = EntityMustBeCreated();

                entity.Delete(UserTest2);
                Assert.True(entity.Deleted, "not deleted");

                entity.Update(UserTest1);

            }
            catch
            {
                lExceptionThrowed = true;
                Assert.True(lExceptionThrowed, "exception throwed");
                return;
            }

            Assert.True(lExceptionThrowed, "exception not throwed");
        }


        [Fact]
        public void TryingDeleteADeletedEntity()
        {

            var lExceptionThrowed = false;

            try
            {
                Entity entity = EntityMustBeCreated();

                entity.Delete(UserTest2);
                Assert.True(entity.Deleted, "not deleted");

                entity.Delete(UserTest1);

            }
            catch
            {
                lExceptionThrowed = true;
                Assert.True(lExceptionThrowed, "exception throwed");
                return;
            }

            Assert.True(lExceptionThrowed, "exception not throwed");
        }
    }
}
