namespace TeleMistUI.DB
{
    public static class Helper
    {
        public static string ConStr()
        {
            string str = (string) App.Current.TryFindResource("ConnectionString");
            return str;
        }
    }
}
