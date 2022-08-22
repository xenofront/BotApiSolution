namespace BotApi
{
    public static class C
    {
        //commands
        public static string Calendar => "/calendar";
        public static string Hotels => "/hotels";
        public static string QuestionRegionOrHotel => "/regionorhotelcmd";
        public static string Regions => "/regions";
        public static string Start => "/start";

        //callbacks
        public static string ChangeMonth => "change-month/";
        public static string CheckAvailabilityHotel => "check-availability-hotel/";
        public static string CheckAvailabilityRegion => "check-availability-region/";
        public static string HotelPick => "hotel-pick/";
        public static string NextYear => "next-year/";
        public static string NoCommandCell => "no-command-cell";
        public static string PickDateFrom => "pick-date-from/";
        public const string PickDateGeneric = "pick-date-generic/";
        public static string PickPax => "pick-pax/";
        public static string PickDateUntil => "pick-date-until/";
        public static string PreviousYear => "previous-year/";

        //other
        public const string DateFormat = @"yyyy\/MM\/dd";
    }

    public static class DBCollections
    {
        public static readonly string Reservation = "reservation";
        public static readonly string User = "user";
    }
}
