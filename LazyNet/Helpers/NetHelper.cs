using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using IPAddress = System.Net.IPAddress;

namespace Dekart.LazyNet.Helpers
{
    /// <summary>
    /// A class to get the MAC address from IP address. The same class can be
    /// modified a little to get the MAC address from the specified hostname.
    /// </summary>
    public static class NetHelper
    {
        /// <summary> Ping timeout (in ms) </summary>
        // ReSharper disable once InconsistentNaming
        const int PING_TIMEOUT = 1000;

        /// <summary>
        /// Gets the MAC address from specified <paramref name="address"/>
        /// using nbtstat in hyphen (-) separated format.
        /// </summary>
        /// <remarks>
        /// <para>
        /// The same class can be modified to accept hostname and then resolve
        /// the hostname to Ip address to get the MAC address or just pass "-a"
        /// argument to "nbtstat" to get the mac address from hostname. If you
        /// want to find the MAC address from only the IP address change the
        /// switch to "-A".
        /// </para>
        /// <para>
        /// The current program can resolve both hostname as well as IP address
        /// to MAC address. The "-a" argument can actually accept both IP address
        /// as well as hostname.
        /// </para>
        /// </remarks>
        /// <param name="address">The IP address or hostname for the machine
        /// for which the MAC address is desired.</param>
        /// <returns>A string containing the MAC address if MAC address could be
        /// found.An empty or null string otherwise.</returns>
        public static string GetMacAddress(string address)
        {
            var macAddress = String.Empty;

            if (!IsHostAccessible(address)) return null;

            try
            {
                var sfWindows = Environment.GetFolderPath(Environment.SpecialFolder.Windows);
                var processStartInfo = new ProcessStartInfo
                {
                    FileName = sfWindows + "\\sysnative\\nbtstat.exe",
                    RedirectStandardInput = false,
                    RedirectStandardOutput = true,
                    StandardOutputEncoding = Encoding.GetEncoding(866),

                    Arguments = "-a " + address,
                    UseShellExecute = false,
                    CreateNoWindow = true
                };
                var process = Process.Start(processStartInfo);
                if (process != null)
                {
                    var counter = -1;

                    while (counter <= -1 && macAddress != null)
                    {
                        counter = macAddress.IndexOf('=');

                        if (counter > -1)
                        {
                            try
                            {
                                var physicalAddress = PhysicalAddress.Parse(macAddress.Split('=')[1].Trim());
                                macAddress = BytesToString(physicalAddress.GetAddressBytes());
                                break;
                            }
                            catch (Exception)
                            {
                                counter = -1;
                            }
                        }
                        macAddress = process.StandardOutput.ReadLine();
                    }
                    process.WaitForExit();
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(ConstStrings.NetError + e);
            }
            return macAddress;
        }

        #region Getting MAC from ARP

        // *********************************************************************
        /// <summary>
        /// Gets the MAC address from ARP table in colon (:) separated format.
        /// </summary>
        /// <param name="hostNameOrAddress">Host name or IP address of the remote host for which MAC address is desired.</param>
        /// <param name="checkIsHostAccessible">Checks to see if the host specified by <paramref name="hostNameOrAddress"/> is currently accessible.</param>
        /// <returns>A string containing MAC address; null if MAC address could not be found.</returns>
        public static string GetMacAddressFromArp(string hostNameOrAddress, bool checkIsHostAccessible = true)
        {
            if (checkIsHostAccessible && !IsHostAccessible(hostNameOrAddress)) return null;

            IPAddress dst;
            if (!IPAddress.TryParse(hostNameOrAddress, out dst))
                dst = GetIPAddressFromHostName(hostNameOrAddress);

            if (dst == null) return null;

            var macAddr = new byte[6];
            var macAddrLen = (uint)macAddr.Length;
            // Please do not use the IPAddress.Address property
            // This API is now obsolete. --> http://msdn.microsoft.com/en-us/library/system.net.ipaddress.address.aspx
            // to get the IP in Integer mode use
            var uintAddress = BitConverter.ToUInt32(dst.GetAddressBytes(), 0);
            if (SendARP(uintAddress, 0, macAddr, ref macAddrLen) != 0)
                return null;
            return BytesToString(macAddr);
        }

        #endregion Getting MAC from ARP

        public static IPAddress GetIPAddressFromHostName(string hostName)
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(hostName);
                foreach (var address in hostEntry.AddressList)
                {
                    if (address.IsIPv4MappedToIPv6 || address.IsIPv6LinkLocal || address.IsIPv6Multicast || address.IsIPv6SiteLocal || address.IsIPv6Teredo) continue;
                    return address;
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(ConstStrings.NetError + e);
            }

            return null;
        }

        public static string GetHostByAddress(string ipAddress)
        {
            try
            {
                var hostEntry = Dns.GetHostEntry(ipAddress);
                return hostEntry.HostName;
            }
            catch (Exception e)
            {
                Console.WriteLine(ConstStrings.NetError + e);
            }

            return null;
        }

        // *********************************************************************
        /// <summary>
        /// Checks to see if the host specified by <paramref name="hostNameOrAddress"/> is currently accessible.
        /// </summary>
        /// <param name="hostNameOrAddress">Host name or IP address of the
        /// remote host for which MAC address is desired.</param>
        /// <returns><see langword="true" /> if the host is currently accessible;
        /// <see langword="false"/> otherwise.</returns>
        public static bool IsHostAccessible(string hostNameOrAddress)
        {
            var ping = new Ping();
            var reply = ping.Send(hostNameOrAddress, PING_TIMEOUT);
            return reply != null && reply.Status == IPStatus.Success;
        }

        /// <summary>
        /// return bytes in colon (:) separated format.
        /// </summary>
        static string BytesToString(IEnumerable<byte> bytes)
        {
            var macAddressString = new StringBuilder();
            foreach (var t in bytes)
            {
                if (macAddressString.Length > 0)
                    macAddressString.Append(":");

                macAddressString.AppendFormat("{0:X2}", t);
            }

            return macAddressString.ToString();
        }

        #region Retrieving IP and MAC addresses for a LAN

        /// <summary>
        /// MIB_IPNETROW structure returned by GetIpNetTable
        /// DO NOT MODIFY THIS STRUCTURE.
        /// </summary>
        [StructLayout(LayoutKind.Sequential)]
        // ReSharper disable InconsistentNaming
        // ReSharper disable MemberCanBePrivate.Local
        // ReSharper disable FieldCanBeMadeReadOnly.Local
        struct MIB_IPNETROW
        {
            [MarshalAs(UnmanagedType.U4)]
            public int dwIndex;
            [MarshalAs(UnmanagedType.U4)]
            public int dwPhysAddrLen;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac0;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac1;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac2;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac3;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac4;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac5;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac6;
            [MarshalAs(UnmanagedType.U1)]
            public byte mac7;
            [MarshalAs(UnmanagedType.U4)]
            public int dwAddr;
            [MarshalAs(UnmanagedType.U4)]
            public int dwType;
        }
        // ReSharper restore FieldCanBeMadeReadOnly.Local
        // ReSharper restore MemberCanBePrivate.Local
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// GetIpNetTable external method
        /// </summary>
        /// <param name="pIpNetTable"></param>
        /// <param name="pdwSize"></param>
        /// <param name="bOrder"></param>
        /// <returns></returns>
        [DllImport("IpHlpApi.dll")]
        [return: MarshalAs(UnmanagedType.U4)]
        static extern int GetIpNetTable(IntPtr pIpNetTable, [MarshalAs(UnmanagedType.U4)] ref int pdwSize, bool bOrder);

        [DllImport("IpHlpApi.dll", ExactSpelling = true)]
        // ReSharper disable InconsistentNaming
        static extern int SendARP(uint DestIP, uint SrcIP, byte[] pMacAddr, ref uint PhyAddrLen);
        // ReSharper restore InconsistentNaming

        /// <summary>
        /// Get the IP and MAC addresses of all known devices on the LAN
        /// </summary>
        /// <remarks>
        /// 1) This table is not updated often - it can take some human-scale time 
        ///    to notice that a device has dropped off the network, or a new device
        ///    has connected.
        /// 2) This discards non-local devices if they are found - these are multicast
        ///    and can be discarded by IP address range.
        /// </remarks>
        public static Dictionary<IPAddress, PhysicalAddress> GetAllDevicesOnLAN()
        {
            var all = new Dictionary<IPAddress, PhysicalAddress>();
            var spaceForNetTable = 0;
            // Get the space needed
            // We do that by requesting the table, but not giving any space at all.
            // The return value will tell us how much we actually need.
            GetIpNetTable(IntPtr.Zero, ref spaceForNetTable, false);
            // Allocate the space
            // We use a try-finally block to ensure release.
            var rawTable = IntPtr.Zero;
            try
            {
                rawTable = Marshal.AllocCoTaskMem(spaceForNetTable);

                // Get the actual data
                var errorCode = GetIpNetTable(rawTable, ref spaceForNetTable, false);
                if (errorCode != 0)
                {
                    // Failed for some reason - can do no more here.
                    throw new Exception($"Unable to retrieve network table. Error code {errorCode}");
                }

                // Get the rows count
                var rowsCount = Marshal.ReadInt32(rawTable);
                var currentBuffer = new IntPtr(rawTable.ToInt64() + Marshal.SizeOf(typeof(Int32)));

                // Convert the raw table to individual entries
                var rows = new MIB_IPNETROW[rowsCount];
                for (var index = 0; index < rowsCount; index++)
                {
                    rows[index] = (MIB_IPNETROW)Marshal.PtrToStructure(new IntPtr(currentBuffer.ToInt64() + (index * Marshal.SizeOf(typeof(MIB_IPNETROW)))), typeof(MIB_IPNETROW));
                }
                // Define the dummy entries list (we can discard these)
                var virtualMAC = new PhysicalAddress(new byte[] { 0, 0, 0, 0, 0, 0 });
                var broadcastMAC = new PhysicalAddress(new byte[] { 255, 255, 255, 255, 255, 255 });
                foreach (var row in rows)
                {
                    var ip = new IPAddress(BitConverter.GetBytes(row.dwAddr));
                    var rawMAC = new[] { row.mac0, row.mac1, row.mac2, row.mac3, row.mac4, row.mac5 };
                    var pa = new PhysicalAddress(rawMAC);
                    if (!pa.Equals(virtualMAC) && !pa.Equals(broadcastMAC) && !IsMulticast(ip))
                    {
                        // Console.WriteLine("IP: {0}\t\tMAC: {1}", ip.ToString(), pa.ToString());
                        if (!all.ContainsKey(ip))
                        {
                            all.Add(ip, pa);
                        }
                    }
                }
            }
            finally
            {
                // Release the memory.
                Marshal.FreeCoTaskMem(rawTable);
            }
            return all;
        }

        /// <summary>
        /// Returns true if the specified IP address is a multicast address
        /// </summary>
        /// <param name="ip"></param>
        /// <returns></returns>
        static bool IsMulticast(IPAddress ip)
        {
            bool result = true;
            if (!ip.IsIPv6Multicast)
            {
                byte highIP = ip.GetAddressBytes()[0];
                if (highIP < 224 || highIP > 239)
                {
                    result = false;
                }
            }
            return result;
        }

        #endregion

        #region Subnet methods

        public static Int64 AddressToInt(this IPAddress address)
        {
            var addressBits = address.GetAddressBytes();
            return addressBits.Aggregate<byte, long>(0, (current, t) => (current << 8) + t);
        }

        public static Int64 AddressToInt(string address)
        {
            return AddressToInt(IPAddress.Parse(address));
        }

        public static IPAddress IntToAddress(Int64 address)
        {
            return IPAddress.Parse(address.ToString(CultureInfo.InvariantCulture));
        }

        public static IPAddress CreateByHostBitLength(int hostpartLength)
        {
            var hostPartLength = hostpartLength;
            var netPartLength = 32 - hostPartLength;

            var binaryMask = new byte[4];

            for (var i = 0; i < 4; i++)
            {
                if (i * 8 + 8 <= netPartLength)
                    binaryMask[i] = 255;
                else if (i * 8 > netPartLength)
                    binaryMask[i] = 0;
                else
                {
                    var oneLength = netPartLength - i * 8;
                    var binaryDigit = String.Empty.PadLeft(oneLength, '1').PadRight(8, '0');
                    binaryMask[i] = Convert.ToByte(binaryDigit, 2);
                }
            }
            return new IPAddress(binaryMask);
        }

        public static IPAddress CreateByNetBitLength(int netpartLength)
        {
            var hostPartLength = 32 - netpartLength;
            return CreateByHostBitLength(hostPartLength);
        }

        public static IPAddress CreateByHostNumber(int numberOfHosts)
        {
            var maxNumber = numberOfHosts + 1;
            var b = Convert.ToString(maxNumber, 2);
            return CreateByHostBitLength(b.Length);
        }

        public static IPAddress GetSubnetMask(this IPAddress address)
        {
            foreach (NetworkInterface adapter in NetworkInterface.GetAllNetworkInterfaces())
            {
                foreach (UnicastIPAddressInformation unicastIPAddressInformation in adapter.GetIPProperties().UnicastAddresses)
                {
                    if (unicastIPAddressInformation.Address.AddressFamily == AddressFamily.InterNetwork)
                    {
                        if (address.Equals(unicastIPAddressInformation.Address))
                        {
                            return unicastIPAddressInformation.IPv4Mask;
                        }
                    }
                }
            }
            throw new ArgumentException($"Can't find subnetmask for IP address '{address}'");
        }

        public static IPAddress GetBroadcastAddress(this IPAddress address, IPAddress subnetMask)
        {
            var ipAdressBytes = address.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            var broadcastAddress = new byte[ipAdressBytes.Length];
            for (var i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] | (subnetMaskBytes[i] ^ 255));
            }
            return new IPAddress(broadcastAddress);
        }

        public static IPAddress GetNetworkAddress(this IPAddress address, IPAddress subnetMask)
        {
            var ipAdressBytes = address.GetAddressBytes();
            var subnetMaskBytes = subnetMask.GetAddressBytes();

            if (ipAdressBytes.Length != subnetMaskBytes.Length)
                throw new ArgumentException("Lengths of IP address and subnet mask do not match.");

            var broadcastAddress = new byte[ipAdressBytes.Length];
            for (var i = 0; i < broadcastAddress.Length; i++)
            {
                broadcastAddress[i] = (byte)(ipAdressBytes[i] & (subnetMaskBytes[i]));
            }
            return new IPAddress(broadcastAddress);
        }

        public static void GetAddressRange(IPAddress address, IPAddress subnetMask, out IPAddress startAddress, out IPAddress endAddress)
        {
            // Convert the IP address to bytes.
            byte[] ipBytes = address.GetAddressBytes();

            // BitConverter gives bytes in opposite order to GetAddressBytes().
            byte[] maskBytes = subnetMask.GetAddressBytes();

            var startIPBytes = new byte[ipBytes.Length];
            var endIPBytes = new byte[ipBytes.Length];

            // Calculate the bytes of the start and end IP addresses.
            for (var i = 0; i < ipBytes.Length; i++)
            {
                startIPBytes[i] = (byte)(ipBytes[i] & maskBytes[i]);
                endIPBytes[i] = (byte)(ipBytes[i] | ~maskBytes[i]);
            }

            // Convert the bytes to IP addresses.
            startAddress = new IPAddress(startIPBytes);
            endAddress = new IPAddress(endIPBytes);
        }

        #endregion

        public static bool IsHostNameValid(string hostName)
        {
            if (string.IsNullOrWhiteSpace(hostName)) return false;

            if (hostName.IndexOf('/') >= 0 || hostName.IndexOf('\\') >= 0) return false;
            
            return true;
        }

        public static bool IsIPAddressValid(string ipAddress)
        {
            if (String.IsNullOrWhiteSpace(ipAddress)) return false;

            try
            {
                // ReSharper disable once ObjectCreationAsStatement
                new IPv4Addr(ipAddress);
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
