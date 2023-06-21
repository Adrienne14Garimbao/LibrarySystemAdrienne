using LibrarySystemAdrienne.Debugging;

namespace LibrarySystemAdrienne
{
    public class LibrarySystemAdrienneConsts
    {
        public const string LocalizationSourceName = "LibrarySystemAdrienne";

        public const string ConnectionStringName = "Default";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "c33b3186a7a64dcca5fc0ab3ed2b9f1c";
    }
}
