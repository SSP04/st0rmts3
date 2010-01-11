using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
namespace TS3.Executable.InterOp
{
    public class TS3Server
    {
#if x64
			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_initServerLib")]
			public static extern uint ts3server_initServerLib(ref server_callback_struct arg0, LogTypes arg1, string arg2);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_getServerLibVersion")]
			public static extern uint ts3server_getServerLibVersion(out IntPtr arg0);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_freeMemory")]
			public static extern uint ts3server_freeMemory(IntPtr arg0);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_destroyServerLib")]
			public static extern uint ts3server_destroyServerLib();

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_createVirtualServer")]
			public static extern uint ts3server_createVirtualServer(int serverPort, string ip, string serverName, string serverKeyPair, uint serverMaxClients, out UInt32 serverID);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_getGlobalErrorMessage")]
			public static extern uint ts3server_getGlobalErrorMessage(uint errorcode, out IntPtr errormessage);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_getVirtualServerKeyPair")]
			public static extern uint ts3server_getVirtualServerKeyPair(UInt32 serverID, out IntPtr result);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_setVirtualServerVariableAsString")]
			public static extern uint ts3server_setVirtualServerVariableAsString(UInt32 serverID, VirtualServerProperties flag, string result);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_flushVirtualServerVariable")]
			public static extern uint ts3server_flushVirtualServerVariable(UInt32 serverID);

			[DllImport("ts3server_win64.dll", EntryPoint = "ts3server_stopVirtualServer")]
			public static extern uint ts3server_stopVirtualServer(UInt32 serverID);
#else
        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_initServerLib")]
        public static extern uint ts3server_initServerLib(ref server_callback_struct arg0, LogTypes arg1, string arg2);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_getServerLibVersion")]
        public static extern uint ts3server_getServerLibVersion(out IntPtr arg0);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_freeMemory")]
        public static extern uint ts3server_freeMemory(IntPtr arg0);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_destroyServerLib")]
        public static extern uint ts3server_destroyServerLib();

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_createVirtualServer")]
        public static extern uint ts3server_createVirtualServer(int serverPort, string ip, string serverName, string serverKeyPair, uint serverMaxClients, out UInt32 serverID);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_getGlobalErrorMessage")]
        public static extern uint ts3server_getGlobalErrorMessage(uint errorcode, out IntPtr errormessage);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_getVirtualServerKeyPair")]
        public static extern uint ts3server_getVirtualServerKeyPair(UInt32 serverID, out IntPtr result);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_setVirtualServerVariableAsString")]
        public static extern uint ts3server_setVirtualServerVariableAsString(UInt32 serverID, VirtualServerProperties flag, string result);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_flushVirtualServerVariable")]
        public static extern uint ts3server_flushVirtualServerVariable(UInt32 serverID);

        [DllImport("ts3server_win32.dll", EntryPoint = "ts3server_stopVirtualServer")]
        public static extern uint ts3server_stopVirtualServer(UInt32 serverID);
#endif
    }
}
