namespace Services.DataProviders
{
    public interface ICampingUserDataProvider
    {
        void AddCampingUser(string appUserId,
            string firstName, string lastName, string userName);
    }
}
