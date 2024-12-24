
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
namespace ASP_Assignment1
{
    public partial class Validator : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            lblMessage.Text = "";
        }

        protected void checkBtn(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string familyName = txtFamilyName.Text.Trim();
            string address = txtAddress.Text.Trim();
            string city = txtCity.Text.Trim();
            string zip = txtZip.Text.Trim();
            string phone = txtPhone.Text.Trim();
            string email = txtEmail.Text.Trim();
            string validationMessage = ValidateFields(name, familyName, address, city, zip, phone, email);

            if (string.IsNullOrEmpty(validationMessage))
            {
                Console.WriteLine("\n Validation Successfull");
            }
            else
            {
                Console.WriteLine("\n Validation unsuccessfull");
            }
        }

        private string ValidateFields(string name, string familyName, string address, string city, string zip, string phone, string email)
        {
            if (name.ToLower() == familyName.ToLower())
                return "Name must be different from Family Name.";
            if (address.Length < 2)
                return "Address must be at least 2 letters.";
            if (city.Length < 2)
                return "City must be at least 2 letters.";

            if (zip.Length != 5 || !IsAllDigits(zip))
                return "Zip Code must be 5 digits.";
            if (!IsValidPhoneFormat(phone))
                return "Phone must be in the format XX-XXXXXXX or XXX-XXXXXXX.";
            if (!IsValidEmail(email))
                return "E-mail is not valid.";
            return string.Empty;
        }
        private bool IsAllDigits(string str)
        {
            foreach (char c in str)
            {
                if (c < '0' || c > '9')
                    return false;
            }
            return true;
        }
        private bool IsValidPhoneFormat(string phone)
        {
            return (phone.Length == 10 && phone[2] == '-' && IsAllDigits(phone.Substring(0, 2)) && IsAllDigits(phone.Substring(3))) ||
                   (phone.Length == 11 && phone[3] == '-' && IsAllDigits(phone.Substring(0, 3)) && IsAllDigits(phone.Substring(4)));
        }

        private bool IsValidEmail(string email)
        {
            int atTheRate = email.IndexOf('@');
            int dotMark = email.LastIndexOf('.');
            return (atTheRate > 0 && dotMark > atTheRate + 1 && dotMark < email.Length - 1);
        }
    }
}