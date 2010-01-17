namespace TS3.Executable.InterOp
{
    public enum Visibility
    {
        ENTER_VISIBILITY = 0,
        RETAIN_VISIBILITY,
        LEAVE_VISIBILITY
    };

    public enum ConnectStatus
    {
        STATUS_DISCONNECTED = 0,       //There is no activity to the server, this is the default value
        STATUS_CONNECTING,             //We are trying to connect, we haven't got a clientID yet, we haven't been accepted by the server
        STATUS_CONNECTED,              //The server has accepted us, we can talk and hear and we got a clientID, but we don't have the channels and clients yet, we can get server infos (welcome msg etc.)
        STATUS_CONNECTION_ESTABLISHING,//we are CONNECTED and we are visible
        STATUS_CONNECTION_ESTABLISHED, //we are CONNECTED and we have the client and channels available
    };
    public enum TalkStatus
    {
        STATUS_NOT_TALKING = 0,
        STATUS_TALKING = 1,
        STATUS_TALKING_WHILE_DISABLED = 2,
    };

    public enum SpeexCodec
    {
        CODEC_SPEEX_NARROWBAND = 0,   //mono, 16bit,  8kHz, bitrate dependant on the quality setting
        CODEC_SPEEX_WIDEBAND,         //mono, 16bit, 16kHz, bitrate dependant on the quality setting
        CODEC_SPEEX_ULTRAWIDEBAND,    //mono, 16bit, 32kHz, bitrate dependant on the quality setting
        CODEC_CELT_MONO,              //mono, 16bit, 48kHz, bitrate dependant on the quality setting
        CODEC_DUMMY_MONO,             //mono, 16bit, 48kHz, no compression (=> bitrate == 93.75 KiB/s!)
    };

    public enum TextMessageTargetMode
    {
        TextMessageTarget_CLIENT = 1,
        TextMessageTarget_CHANNEL,
        TextMessageTarget_SERVER,
        TextMessageTarget_MAX
    };

    public enum MuteInputStatus
    {
        MUTEINPUT_NONE = 0,
        MUTEINPUT_MUTED,
    };

    public enum MuteOutputStatus
    {
        MUTEOUTPUT_NONE = 0,
        MUTEOUTPUT_MUTED,
    };

    public enum HardwareInputStatus
    {
        HARDWAREINPUT_DISABLED = 0,
        HARDWAREINPUT_ENABLED,
    };

    public enum HardwareOutputStatus
    {
        HARDWAREOUTPUT_DISABLED = 0,
        HARDWAREOUTPUT_ENABLED,
    };

    public enum InputDeactivationStatus
    {
        INPUT_ACTIVE = 0,
        INPUT_DEACTIVATED = 1,
    };

    public enum ReasonIdentifier
    {
        REASON_NONE = 0,  //no reason data
        REASON_MOVED = 1,  //{SectionInvoker}
        REASON_SUBSCRIPTION = 2,  //no reason data
        REASON_LOST_CONNECTION = 3,  //reasonmsg=reason
        REASON_KICK_CHANNEL = 4,  //{SectionInvoker} reasonmsg=reason               //{SectionInvoker} is only added server->client
        REASON_KICK_SERVER = 5,  //{SectionInvoker} reasonmsg=reason               //{SectionInvoker} is only added server->client
        REASON_KICK_SERVER_BAN = 6,  //{SectionInvoker} reasonmsg=reason bantime=time  //{SectionInvoker} is only added server->client
        REASON_SERVERSTOP = 7,  //reasonmsg=reason
        REASON_CLIENTDISCONNECT = 8,  //reasonmsg=reason
        REASON_CHANNELUPDATE = 9,  //no reason data
        REASON_CHANNELEDIT = 10, //{SectionInvoker}
        REASON_CLIENTDISCONNECT_SERVER_SHUTDOWN = 11,  //reasonmsg=reason
    };

    public enum ChannelProperties
    {
        CHANNEL_NAME = 0,                       //Available for all channels that are "in view", always up-to-date
        CHANNEL_TOPIC,                          //Available for all channels that are "in view", always up-to-date
        CHANNEL_DESCRIPTION,                    //Must be requested (=> requestChannelDescription)
        CHANNEL_PASSWORD,                       //not available client side
        CHANNEL_CODEC,                          //Available for all channels that are "in view", always up-to-date
        CHANNEL_CODEC_QUALITY,                  //Available for all channels that are "in view", always up-to-date
        CHANNEL_MAXCLIENTS,                     //Available for all channels that are "in view", always up-to-date
        CHANNEL_MAXFAMILYCLIENTS,               //Available for all channels that are "in view", always up-to-date
        CHANNEL_ORDER,                          //Available for all channels that are "in view", always up-to-date
        CHANNEL_FLAG_PERMANENT,                 //Available for all channels that are "in view", always up-to-date
        CHANNEL_FLAG_SEMI_PERMANENT,            //Available for all channels that are "in view", always up-to-date
        CHANNEL_FLAG_DEFAULT,                   //Available for all channels that are "in view", always up-to-date
        CHANNEL_FLAG_PASSWORD,                  //Available for all channels that are "in view", always up-to-date
        CHANNEL_ENDMARKER,
    };

    public enum ClientProperties
    {
        CLIENT_UNIQUE_IDENTIFIER = 0,           //automatically up-to-date for any client "in view", can be used to identify this particular client installation
        CLIENT_NICKNAME,                        //automatically up-to-date for any client "in view"
        CLIENT_VERSION,                         //for other clients than ourself, this needs to be requested (=> requestClientVariables)
        CLIENT_PLATFORM,                        //for other clients than ourself, this needs to be requested (=> requestClientVariables)
        CLIENT_FLAG_TALKING,                    //automatically up-to-date for any client that can be heard (in room / whisper)
        CLIENT_INPUT_MUTED,                     //automatically up-to-date for any client "in view", this clients microphone mute status
        CLIENT_OUTPUT_MUTED,                    //automatically up-to-date for any client "in view", this clients headphones/speakers mute status
        CLIENT_INPUT_HARDWARE,                  //automatically up-to-date for any client "in view", this clients microphone hardware status (is the capture device opened?)
        CLIENT_OUTPUT_HARDWARE,                 //automatically up-to-date for any client "in view", this clients headphone/speakers hardware status (is the playback device opened?)
        CLIENT_INPUT_DEACTIVATED,               //only usable for ourself, not propagated to the network
        CLIENT_IDLE_TIME,                       //internal use
        CLIENT_DEFAULT_CHANNEL,                 //only usable for ourself, the default channel we used to connect on our last connection attempt
        CLIENT_DEFAULT_CHANNEL_PASSWORD,        //internal use
        CLIENT_SERVER_PASSWORD,                 //internal use
        CLIENT_META_DATA,                       //automatically up-to-date for any client "in view", not used by TeamSpeak, free storage for sdk users
        CLIENT_IS_MUTED,                        //only make sense on the client side locally, "1" if this client is currently muted by us, "0" if he is not
        CLIENT_IS_RECORDING,                    //automatically up-to-date for any client "in view"
        CLIENT_VOLUME_MODIFICATOR,				//internal use
        CLIENT_ENDMARKER,
    };

    public enum VirtualServerProperties
    {
        VIRTUALSERVER_UNIQUE_IDENTIFIER = 0,    //available when connected, can be used to identify this particular server installation
        VIRTUALSERVER_NAME,                     //available and always up-to-date when connected
        VIRTUALSERVER_WELCOMEMESSAGE,           //available when connected, not updated while connected
        VIRTUALSERVER_PLATFORM,                 //available when connected
        VIRTUALSERVER_VERSION,                  //available when connected
        VIRTUALSERVER_MAXCLIENTS,               //only available on request (=> requestServerVariables), stores the maximum number of clients that may currently join the server
        VIRTUALSERVER_PASSWORD,                 //not available to clients, the server password
        VIRTUALSERVER_CLIENTS_ONLINE,           //only available on request (=> requestServerVariables),
        VIRTUALSERVER_CHANNELS_ONLINE,          //only available on request (=> requestServerVariables),
        VIRTUALSERVER_CREATED,                  //available when connected, stores the time when the server was created
        VIRTUALSERVER_UPTIME,                   //only available on request (=> requestServerVariables), the time since the server was started
        VIRTUALSERVER_ENDMARKER,
    };

    public enum ConnectionProperties
    {
        CONNECTION_PING = 0,                                        //average latency for a round trip through and back this connection
        CONNECTION_PING_DEVIATION,                                  //standard deviation of the above average latency
        CONNECTION_CONNECTED_TIME,                                  //how long the connection exists already
        CONNECTION_IDLE_TIME,                                       //how long since the last action of this client
        CONNECTION_CLIENT_IP,                                       //IP of this client (as seen from the server side)
        CONNECTION_CLIENT_PORT,                                     //Port of this client (as seen from the server side)
        CONNECTION_SERVER_IP,                                       //IP of the server (seen from the client side) - only available on yourself, not for remote clients, not available server side
        CONNECTION_SERVER_PORT,                                     //Port of the server (seen from the client side) - only available on yourself, not for remote clients, not available server side
        CONNECTION_PACKETS_SENT_SPEECH,                             //how many Speech packets were sent through this connection
        CONNECTION_PACKETS_SENT_KEEPALIVE,
        CONNECTION_PACKETS_SENT_CONTROL,
        CONNECTION_PACKETS_SENT_TOTAL,                              //how many packets were sent totally (this is PACKETS_SENT_SPEECH + PACKETS_SENT_KEEPALIVE + PACKETS_SENT_CONTROL)
        CONNECTION_BYTES_SENT_SPEECH,
        CONNECTION_BYTES_SENT_KEEPALIVE,
        CONNECTION_BYTES_SENT_CONTROL,
        CONNECTION_BYTES_SENT_TOTAL,
        CONNECTION_PACKETS_RECEIVED_SPEECH,
        CONNECTION_PACKETS_RECEIVED_KEEPALIVE,
        CONNECTION_PACKETS_RECEIVED_CONTROL,
        CONNECTION_PACKETS_RECEIVED_TOTAL,
        CONNECTION_BYTES_RECEIVED_SPEECH,
        CONNECTION_BYTES_RECEIVED_KEEPALIVE,
        CONNECTION_BYTES_RECEIVED_CONTROL,
        CONNECTION_BYTES_RECEIVED_TOTAL,
        CONNECTION_PACKETLOSS_SPEECH,
        CONNECTION_PACKETLOSS_KEEPALIVE,
        CONNECTION_PACKETLOSS_CONTROL,
        CONNECTION_PACKETLOSS_TOTAL,                                //the probability with which a packet round trip failed because a packet was lost
        CONNECTION_SERVER2CLIENT_PACKETLOSS_SPEECH,                 //the probability with which a speech packet failed from the server to the client
        CONNECTION_SERVER2CLIENT_PACKETLOSS_KEEPALIVE,
        CONNECTION_SERVER2CLIENT_PACKETLOSS_CONTROL,
        CONNECTION_SERVER2CLIENT_PACKETLOSS_TOTAL,
        CONNECTION_CLIENT2SERVER_PACKETLOSS_SPEECH,
        CONNECTION_CLIENT2SERVER_PACKETLOSS_KEEPALIVE,
        CONNECTION_CLIENT2SERVER_PACKETLOSS_CONTROL,
        CONNECTION_CLIENT2SERVER_PACKETLOSS_TOTAL,
        CONNECTION_BANDWIDTH_SENT_LAST_SECOND_SPEECH,               //howmany bytes of speech packets we sent during the last second
        CONNECTION_BANDWIDTH_SENT_LAST_SECOND_KEEPALIVE,
        CONNECTION_BANDWIDTH_SENT_LAST_SECOND_CONTROL,
        CONNECTION_BANDWIDTH_SENT_LAST_SECOND_TOTAL,
        CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_SPEECH,               //howmany bytes/s of speech packets we sent in average during the last minute
        CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_KEEPALIVE,
        CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_CONTROL,
        CONNECTION_BANDWIDTH_SENT_LAST_MINUTE_TOTAL,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_SPEECH,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_KEEPALIVE,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_CONTROL,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_SECOND_TOTAL,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_SPEECH,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_KEEPALIVE,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_CONTROL,
        CONNECTION_BANDWIDTH_RECEIVED_LAST_MINUTE_TOTAL,
        CONNECTION_ENDMARKER,
    };

    public enum LogTypes
    {
        LogType_NONE = 0x0000,
        LogType_FILE = 0x0001,
        LogType_CONSOLE = 0x0002,
        LogType_USERLOGGING = 0x0004,
        LogType_NO_NETLOGGING = 0x0008,
        LogType_DATABASE = 0x0010,
    };

   public enum LogLevel
    {
        LogLevel_CRITICAL = 0, //these messages stop the program
        LogLevel_ERROR,        //everything that is really bad, but not so bad we need to shut down
        LogLevel_WARNING,      //everything that *might* be bad
        LogLevel_DEBUG,        //output that might help find a problem
        LogLevel_INFO,         //informational output, like "starting database version x.y.z"
        LogLevel_DEVEL         //developer only output (will not be displayed in release mode)
    };
    public enum public_errors
    {
        //The idea here is: the values are 2 bytes wide, the first byte identifies the group, the second the count within that group

        //general
        ERROR_ok = 0x0000,
        ERROR_undefined = 0x0001,
        ERROR_not_implemented = 0x0002,
        ERROR_ok_no_update = 0x0003,
        ERROR_dont_notify = 0x0004,

        //dunno
        ERROR_command_not_found = 0x0100,
        ERROR_unable_to_bind_network_port = 0x0101,
        ERROR_no_network_port_available = 0x0102,

        //client
        ERROR_client_invalid_id = 0x0200,
        ERROR_client_nickname_inuse = 0x0201,
        ERROR_client_protocol_limit_reached = 0x0203,
        ERROR_client_invalid_type = 0x0204,
        ERROR_client_already_subscribed = 0x0205,
        ERROR_client_not_logged_in = 0x0206,
        ERROR_client_could_not_validate_identity = 0x0207,

        //channel
        ERROR_channel_invalid_id = 0x0300,
        ERROR_channel_protocol_limit_reached = 0x0301,
        ERROR_channel_already_in = 0x0302,
        ERROR_channel_name_inuse = 0x0303,
        ERROR_channel_not_empty = 0x0304,
        ERROR_channel_can_not_delete_default = 0x0305,
        ERROR_channel_default_require_permanent = 0x0306,
        ERROR_channel_invalid_flags = 0x0307,
        ERROR_channel_parent_not_permanent = 0x0308,
        ERROR_channel_maxclients_reached = 0x0309,
        ERROR_channel_maxfamily_reached = 0x030a,
        ERROR_channel_invalid_order = 0x030b,
        ERROR_channel_no_filetransfer_supported = 0x030c,
        ERROR_channel_invalid_password = 0x030d,

        //server
        ERROR_server_invalid_id = 0x0400,
        ERROR_server_running = 0x0401,
        ERROR_server_is_shutting_down = 0x0402,
        ERROR_server_maxclients_reached = 0x0403,
        ERROR_server_invalid_password = 0x0404,

        //parameter
        ERROR_parameter_quote = 0x0600,
        ERROR_parameter_invalid_count = 0x0601,
        ERROR_parameter_invalid = 0x0602,
        ERROR_parameter_not_found = 0x0603,
        ERROR_parameter_convert = 0x0604,
        ERROR_parameter_invalid_size = 0x0605,
        ERROR_parameter_missing = 0x0606,

        //unsorted, need further investigation
        ERROR_vs_critical = 0x0700,
        ERROR_connection_lost = 0x0701,
        ERROR_not_connected = 0x0702,
        ERROR_no_cached_connection_info = 0x0703,
        ERROR_currently_not_possible = 0x0704,
        ERROR_failed_connection_initialisation = 0x0705,
        ERROR_could_not_resolve_hostname = 0x0706,
        ERROR_invalid_server_connection_handler_id = 0x0707,
        ERROR_could_not_initialise_input_manager = 0x0708,
        ERROR_clientlibrary_not_initialised = 0x0709,
        ERROR_serverlibrary_not_initialised = 0x070a,

        //sound
        ERROR_sound_preprocessor_disabled = 0x0900,
        ERROR_sound_internal_preprocessor = 0x0901,
        ERROR_sound_internal_encoder = 0x0902,
        ERROR_sound_internal_playback = 0x0903,
        ERROR_sound_no_capture_device_available = 0x0904,
        ERROR_sound_no_playback_device_available = 0x0905,
        ERROR_sound_could_not_open_capture_device = 0x0906,
        ERROR_sound_could_not_open_playback_device = 0x0907,
        ERROR_sound_handler_has_device = 0x0908,
        ERROR_sound_invalid_capture_device = 0x0909,
        ERROR_sound_invalid_playback_device = 0x090a,

        //accounting
        ERROR_accounting_virtualserver_limit_reached = 0x0b00,
        ERROR_accounting_slot_limit_reached = 0x0b01,
        ERROR_accounting_license_file_not_found = 0x0b02,
        ERROR_accounting_license_date_not_ok = 0x0b03,
        ERROR_accounting_unable_to_connect_to_server = 0x0b04,
        ERROR_accounting_unknown_error = 0x0b05,
        ERROR_accounting_server_error = 0x0b06,
        ERROR_accounting_instance_limit_reached = 0x0b07,
        ERROR_accounting_instance_check_error = 0x0b08,
        ERROR_accounting_license_file_invalid = 0x0b09,
        ERROR_accounting_running_elsewhere = 0x0b0a,
        ERROR_accounting_instance_duplicated = 0x0b0b,
        ERROR_accounting_already_started = 0x0b0c,
        ERROR_accounting_not_started = 0x0b0d
    }

}