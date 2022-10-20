namespace Watchlist.Data
{
    public class DataConstants
    {
        public class Genre
        {
            public const int GenreNameMax = 50;
            public const int GenreNameMin = 5;
        }
        public class Movie
        {
            public const int MovieTitleMax = 50;
            public const int MovieTitleMin = 10;

            public const int MovieDirectoreMax = 50;
            public const int MovieDirectorMin = 5;
        }
        public class User
        {
            public const int UserNameMax = 20;
            public const int UserNameMin = 5;

            public const int UserEmailMax = 60;
            public const int UserEmailMin = 10;

            public const int UserPasswordMax = 20;
            public const int UserPasswordMin = 5;
        }
    }
}
