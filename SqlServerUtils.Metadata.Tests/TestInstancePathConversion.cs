using Nicologies.SqlServerUtils.Metadata;
using NUnit.Framework;

namespace SqlServerUtils.Metadata.Test
{
    [TestFixture]
    public class TestInstancePathConversion
    {
        [Test]
        public void GivenDefaultInstancePath_ShouldReturnDot()
        {
            var path = InstancePathConversion.GetInstsPath("LOCALHOST", "MSSQLSERVER");
            Assert.That(path, Is.EqualTo("."));

            path = InstancePathConversion.GetInstsPath(".", "MSSQLSERVER");
            Assert.That(path, Is.EqualTo("."));
        }

        [Test]
        public void LocalHostShouldBeReplacedWithDot()
        {
            var path = InstancePathConversion.GetInstsPath("LOCALHOST", "SQLEXPRESS");
            Assert.That(path, Is.EqualTo(@".\SQLEXPRESS"));
        }

        [Test]
        public void GiveAnInstNameContainsMSSQLSERVER_ShouldntBeReplaced()
        {
            var path = InstancePathConversion.GetInstsPath("LOCALHOST", "MSSQLSERVER2012");
            Assert.That(path, Is.EqualTo(@".\MSSQLSERVER2012"));
        }
    }
}