namespace Library.Data
{
    public class DataConstants
    {
        public class Book
        {
            public const int BookTitleMax = 50;
            public const int BookTitleMin = 10;

            public const int BookAuthorMax = 50;
            public const int BookAuthorMin = 5;

            public const int BookDescriptionMax = 5000;
            public const int BookDescriptionMin = 5;
        }

        public class Category
        {
            public const int CategoryNameMax = 50;
            public const int CategoryNameMin = 5;
        }

        public class ApplicationUser
        {
            public const int ApplicationUserNameMax = 20;
            public const int ApplicationUserNameMin = 5;

            public const int ApplicationEmailMax = 60;
            public const int ApplicationEmailMin = 10;

            public const int ApplicationPasswordMax = 20;
            public const int ApplicationPasswordMin = 5;
        }
    }
}
