namespace AMVC.Helper
{
    public static class ApiList
    {
        private static string baseUri = "https://api.spacexdata.com/v3";
        public static string History = $"{baseUri}/history";
        public static string Missions = $"{baseUri}/missions";
    }
}