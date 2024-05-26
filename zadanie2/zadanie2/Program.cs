using System;
using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;

namespace zadanie2
{
    public class DeviceInfo
    {
        public Device Device { get; set; }
        public Brigade Brigade { get; set; }
    }

    public class Device
    {
        public string SerialNumber { get; set; }
        public bool IsOnline { get; set; }
    }

    public class Brigade
    {
        public string Code { get; set; }
    }

    public class Conflict
    {
        public string BrigadeCode { get; set; }
        public string[] DevicesSerials { get; set; }
    }

    public class Conflictp
    {
        public string jsonFilePath;
        public string jsonv;
        public HashSet<string> GetConflictBrigadeCodes(string jsonString)
        {
            HashSet<string> conflictBrigadeCodes = new HashSet<string>();
            List<DeviceInfo> deviceInfos = JsonConvert.DeserializeObject<List<DeviceInfo>>(jsonString);

            foreach (DeviceInfo i in deviceInfos)
            {
                foreach (DeviceInfo j in deviceInfos)
                {
                    if (i.Brigade.Code == j.Brigade.Code && i != j)
                    {
                        if (i.Device.IsOnline || j.Device.IsOnline)
                        {
                            conflictBrigadeCodes.Add(i.Brigade.Code);
                        }
                    }
                }
            }

            return conflictBrigadeCodes;
        }
        public List<Conflict> GetConflictsList(HashSet<string> conflictBrigadeCodes, List<DeviceInfo> deviceInfos)
        {
            List<Conflict> conflicts = new List<Conflict>();

            foreach (var brigadeCode in conflictBrigadeCodes)
            {
                List<string> deviceSerialNumbers = new List<string>();
                foreach (DeviceInfo info in deviceInfos)
                {
                    if (info.Brigade.Code == brigadeCode)
                    {
                        deviceSerialNumbers.Add(info.Device.SerialNumber);
                    }
                }

                Conflict conflict = new Conflict
                {
                    BrigadeCode = brigadeCode,
                    DevicesSerials = deviceSerialNumbers.ToArray()
                };

                conflicts.Add(conflict);
            }

            return conflicts;
        }
        public void DetectAndSaveConflicts(string jsonFilePath, string outputFilePath)
        {
            string jsonString = File.ReadAllText(jsonFilePath);

            HashSet<string> conflictBrigadeCodes = GetConflictBrigadeCodes(jsonString);
            List<DeviceInfo> deviceInfos = JsonConvert.DeserializeObject<List<DeviceInfo>>(jsonString);
            List<Conflict> conflicts = GetConflictsList(conflictBrigadeCodes, deviceInfos);

            ShowConflicts(conflicts);

            string conflictsJson = JsonConvert.SerializeObject(conflicts, Formatting.Indented);
            File.WriteAllText(outputFilePath, conflictsJson);
        }
        public void ShowConflicts(List<Conflict> conflicts)
        {
            foreach (Conflict conflict in conflicts)
            {
                Console.WriteLine("BrigadeCode: " + conflict.BrigadeCode);

                Console.WriteLine("DevicesSerials: " + string.Join(",", conflict.DevicesSerials));

                Console.WriteLine();
            }
        }

    }

    internal class Program
    {


        static void Main()
        {
            string jsonFilePath = @"C:\zadanie2\Devices.json";
            string jsonv = @"C:\Users\Gals\Desktop\zadanie2\Conflicts.json";
            Conflictp con = new Conflictp();

            con.DetectAndSaveConflicts(jsonFilePath, jsonv);



        }
    }
}
