namespace CalculateConcession__
{
    public class ConcessionCalculator
    {

        const double TotalFare = 500;

        public string CalculateConcession(int age)
        {
            
            if (age <= 5)
            {
                return $"Little Champs - Free Ticket";
            }
            else if (age > 60)
            {
                double concession = 0.30 * TotalFare;
                double discountedFare = TotalFare - concession;
                return $"Senior Citizen , Discounted Fare: {discountedFare}";
            }
            else
            {
                return $"Ticket Booked , Fare: {TotalFare}";
            }
        }


    }
}
