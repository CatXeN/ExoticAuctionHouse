namespace ExoticAuctionHouse_API.Helpers
{
    public static class EnumHelper
    {
        public static string[] ExtractValues<T>()
        {
            return Enum.GetNames(typeof(T));
        }
    }
}
