#define x64

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;
using anyID = System.UInt32;
namespace TS3.Executable.InterOp
{
    public class TS3Client
    {
#if x64
			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_initClientLib")]
			public static extern uint ts3client_initClientLib(ref client_callback_struct arg0, ref client_callbackrare_struct arg1, LogTypes arg2, string arg3);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_getClientLibVersion")]
			public static extern uint ts3client_getClientLibVersion(out IntPtr arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_freeMemory")]
			public static extern uint ts3client_freeMemory(IntPtr arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_spawnNewServerConnectionHandler")]
			public static extern uint ts3client_spawnNewServerConnectionHandler(int port, out anyID arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_getDefaultCaptureMode")]
			public static extern uint ts3client_getDefaultCaptureMode(out int arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_openCaptureDevice")]
			public static extern uint ts3client_openCaptureDevice(anyID arg0, int arg1, string arg2);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_getDefaultPlayBackMode")]
			public static extern uint ts3client_getDefaultPlayBackMode(out int arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_openPlaybackDevice")]
			public static extern uint ts3client_openPlaybackDevice(anyID arg0, int arg1, string arg2);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_createIdentity")]
			public static extern uint ts3client_createIdentity(out IntPtr arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_startConnection", CharSet = CharSet.Ansi)]
			public static extern uint ts3client_startConnection(anyID arg0, string identity, string ip, uint port, string nick, ref string defaultchannelarray, string defaultchannelpassword, string serverpassword);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_stopConnection")]
			public static extern uint ts3client_stopConnection(anyID arg0, string arg1);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_destroyServerConnectionHandler")]
			public static extern uint ts3client_destroyServerConnectionHandler(anyID arg0);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_destroyClientLib")]
			public static extern uint ts3client_destroyClientLib();

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_getChannelVariableAsString")]
			public static extern uint ts3client_getChannelVariableAsString(anyID arg0, anyID arg1, ChannelProperties arg2, out IntPtr arg3);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_getErrorMessage")]
			public static extern uint ts3client_getErrorMessage(uint arg0, IntPtr arg1);

			[DllImport("ts3client_win64.dll", EntryPoint = "ts3client_getClientVariableAsString")]
			public static extern uint ts3client_getClientVariableAsString(anyID arg0, anyID arg1, ClientProperties arg2, out IntPtr arg3);
#else
        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_initClientLib")]
        public static extern uint ts3client_initClientLib(ref client_callback_struct arg0, ref client_callbackrare_struct arg1, LogTypes arg2, string arg3);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_getClientLibVersion")]
        public static extern uint ts3client_getClientLibVersion(out IntPtr arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_freeMemory")]
        public static extern uint ts3client_freeMemory(IntPtr arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_spawnNewServerConnectionHandler")]
        public static extern uint ts3client_spawnNewServerConnectionHandler(int port, out anyID arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_getDefaultCaptureMode")]
        public static extern uint ts3client_getDefaultCaptureMode(out int arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_openCaptureDevice")]
        public static extern uint ts3client_openCaptureDevice(anyID arg0, int arg1, string arg2);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_getDefaultPlayBackMode")]
        public static extern uint ts3client_getDefaultPlayBackMode(out int arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_openPlaybackDevice")]
        public static extern uint ts3client_openPlaybackDevice(anyID arg0, int arg1, string arg2);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_createIdentity")]
        public static extern uint ts3client_createIdentity(out IntPtr arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_startConnection", CharSet = CharSet.Ansi)]
        public static extern uint ts3client_startConnection(anyID arg0, string identity, string ip, uint port, string nick, ref string defaultchannelarray, string defaultchannelpassword, string serverpassword);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_stopConnection")]
        public static extern uint ts3client_stopConnection(anyID arg0, string arg1);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_destroyServerConnectionHandler")]
        public static extern uint ts3client_destroyServerConnectionHandler(anyID arg0);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_destroyClientLib")]
        public static extern uint ts3client_destroyClientLib();

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_getChannelVariableAsString")]
        public static extern uint ts3client_getChannelVariableAsString(anyID arg0, anyID arg1, ChannelProperties arg2, out IntPtr arg3);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_getErrorMessage")]
        public static extern uint ts3client_getErrorMessage(uint arg0, IntPtr arg1);

        [DllImport("ts3client_win32.dll", EntryPoint = "ts3client_getClientVariableAsString")]
        public static extern uint ts3client_getClientVariableAsString(anyID arg0, anyID arg1, ClientProperties arg2, out IntPtr arg3);
#endif

        public static uint HandleError(Func<uint> f, string message)
        {
            uint result = f();
            if (result != (int)public_errors.ERROR_ok)
            {
                if (String.IsNullOrEmpty(message))
                    message = "A TS3 SDK funtion has returned an error code.";
                Logger.Error("{0}. Received error code {1:x2}.",message,  result);
            }
            return result;
        }


        anyID handle = 0;
        
        [System.ComponentModel.DefaultValue(false)]
        public bool Connected { get; set; }

        public delegate void ConnectStatusChangeHandler(uint handle, ConnectStatus status, public_errors error);
        public event ConnectStatusChangeHandler OnConnectStatusChanged;

        public TS3Client()
        {
            client_callback_struct callbacks = new client_callback_struct();

            client_callbackrare_struct rarecallbacks = new client_callbackrare_struct();

            callbacks.onConnectStatusChangeEvent_delegate = (id, status, errno) => {
                if (OnConnectStatusChanged != null)
                {
                    ConnectStatus c_status = (ConnectStatus)status;
                    public_errors c_errno = (public_errors)((int)errno);
                    OnConnectStatusChanged(id, c_status, c_errno);
                }
            };

            if (HandleError(() => ts3client_initClientLib(ref callbacks, ref rarecallbacks, LogTypes.LogType_NONE, null), "Failed to initialize server") != (int)public_errors.ERROR_ok)
            {
                Environment.Exit(1);
            }

            if (HandleError(() => ts3client_spawnNewServerConnectionHandler(0 /* any port */, out handle), "Failed to spawn new server connection handler.") != (int)public_errors.ERROR_ok)
            {
                Environment.Exit(1);
            }

            if (String.IsNullOrEmpty(Config.Instance.TS3Identity))
            {
                IntPtr ptr;
                ts3client_createIdentity(out ptr);
                Config.Instance.TS3Identity = Marshal.PtrToStringAnsi(ptr);
            }

        }

        public bool Connect()
        {
            if (Connected && !Disconnect("Connect requested without a disconnect. Automatically disconnected."))
                return false;
            string defchan = "";
            uint result = HandleError(() => ts3client_startConnection(handle, Config.Instance.TS3Identity,
                Config.Instance.TS3Host, Config.Instance.TS3Port, Config.Instance.TS3Nick, ref defchan, "", Config.Instance.TS3Pass), "Failed to connect.");
            Connected = result == (int)public_errors.ERROR_ok;
            return Connected;
        }

        public bool Disconnect(string reason)
        {
            if (Connected)
            {
                uint result = HandleError(() => ts3client_stopConnection(handle, reason), "Failed to disconnect.");
                if (result == (int)public_errors.ERROR_ok)
                    Connected = false;
            }
            return !Connected;
        }

        ~TS3Client()
        {
            if (Connected)
                ts3client_stopConnection(handle, this.GetType().Name + " went out of scope.");
            if (handle != 0)
                ts3client_destroyServerConnectionHandler(handle);
            ts3client_destroyClientLib();
        }
    }
}
