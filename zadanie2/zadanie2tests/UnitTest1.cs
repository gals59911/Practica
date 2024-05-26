using System;
using System.IO;
using System.Collections.Generic;
using Xunit;
using zadanie2;

namespace zadanie2tests
{
    public class UnitTest1
    {
        [Fact]
        public void TestGetConflictBrigadeCodes()
        {
            // Arrange

            string jsonString = "[{\"device\":{\"serialNumber\":\"896157052e13\",\"isOnline\":false},\"brigade\":{\"code\":\"843401330\"}},{\"device\":{\"serialNumber\":\"1298956514e13\",\"isOnline\":true},\"brigade\":{\"code\":\"843401330\"}},{\"device\":{\"serialNumber\":\"668144139e13\",\"isOnline\":false},\"brigade\":{\"code\":\"843466871\"}},]";
            Conflictp c = new Conflictp();
            c.jsonFilePath = jsonString;
            // Act
            string result = "843401330";
            HashSet<string> conflictBrigadeCodes = c.GetConflictBrigadeCodes(jsonString);

            // Assert
            Assert.Contains(result, conflictBrigadeCodes);
        }

        [Fact]
        public void TestGetConflictsList()
        {
            Conflictp c = new Conflictp();
            // Arrange
            HashSet<string> conflictBrigadeCodes = new HashSet<string> { "B001", "B002" };
            List<DeviceInfo> deviceInfos = new List<DeviceInfo>
    {
        new DeviceInfo { Brigade = new Brigade { Code = "B001" }, Device = new Device { SerialNumber = "12345", IsOnline = true } },
        new DeviceInfo { Brigade = new Brigade { Code = "B002" }, Device = new Device { SerialNumber = "54321"  , IsOnline = false } }
    };

            // Act
            List<Conflict> conflicts = c.GetConflictsList(conflictBrigadeCodes, deviceInfos);

            // Assert
            Assert.Equal(2, conflicts.Count);
        }
    }
}
