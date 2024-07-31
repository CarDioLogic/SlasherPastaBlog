namespace SlasherPastaBlog.Helpers
{
    public class HelperMethods
    {
        public static string DetermineAgeRating(DateTime dateOfBirth)
        {
            DateTime today = DateTime.Today;
            int age = today.Year - dateOfBirth.Year;

            // Check if the birthday for this year has passed
            if (dateOfBirth.Date > today.AddYears(-age))
            {
                age--; // decrement if yes
            }
            if (age > 18)
            {
                return "RatingM";
            }
            else if (age > 13)
            {
                return "RatingT";
            }
            else
            {
                return "RatingE";
            }
        }
    }
}
