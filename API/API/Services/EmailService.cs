using API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;

namespace API.Services {
    public class EmailService {

        private int _maxEmailTargets =
            Convert.ToInt32(WebConfigurationManager.AppSettings["MaxEmailNotificationsPerDonation"]);

        private string _senderEmail = WebConfigurationManager.AppSettings["SMTPSendingEmail"];
        private string _emailBody = WebConfigurationManager.AppSettings["SMTPSendingBody"];
        private string _optionalContactBody = WebConfigurationManager.AppSettings["SMTPOptionalContact"];
        private string _optionalDescriptionBody = WebConfigurationManager.AppSettings["SMTOOptionalDescription"];
        private string _emailSubject = WebConfigurationManager.AppSettings["SMTOSubjectLine"];
        private string _senderPassword = WebConfigurationManager.AppSettings["SMTPPassword"];
        private bool _useDebugEmail = Convert.ToBoolean(WebConfigurationManager.AppSettings["UseDebugEmailAddress"]);
        private string _debugEmailAddress = WebConfigurationManager.AppSettings["DebugEmailAddress"];

        public void SendNearbyDonationEmail(Donation donation, List<FoodBank> foodBanksToGetEmail) {
            if (foodBanksToGetEmail.Count == 0)
                return;

            // Insure that the # passed is not greater than the amount that we can email.
            // If so, grab the appropriate number.
            // This assumes the list is already sorted in order of closest to farthest.
            if (foodBanksToGetEmail.Count > _maxEmailTargets) {
                foodBanksToGetEmail.GetRange(0, _maxEmailTargets);
            }

            MailMessage message = new MailMessage();
            // Check debug email boolean, so that we don't send testing emails to real food banks
            if (!_useDebugEmail) {
                foreach (FoodBank foodBank in foodBanksToGetEmail) {
                    message.To.Add(foodBank.Email);
                }
            } else {
                message.To.Add(_debugEmailAddress);
            }
            message.From = new MailAddress(_senderEmail);

            #region Construct Message Body
            string messageBody = _emailBody.Replace("%Address%", donation.Address)
                                           .Replace("%ExpirationDate%", donation.ExpirationDate.ToShortDateString());
            if (!string.IsNullOrEmpty(donation.Description)) {
                messageBody += _optionalDescriptionBody.Replace("%Description%", donation.Description);
            }
            string contact = "";
            if (!string.IsNullOrEmpty(donation.Phone))
                contact = "Tel: " + donation.Phone + " ";
            if (!string.IsNullOrEmpty(donation.Email))
                contact += "Email: " + donation.Email + " ";
            if (!string.IsNullOrEmpty(contact)) {
                messageBody += _optionalContactBody.Replace("%Contact%", contact);
            }
            #endregion
            message.Body = messageBody;
            message.Subject = _emailSubject;

            SmtpClient client = new SmtpClient();
            NetworkCredential credential = new NetworkCredential();
            credential.UserName = _senderEmail;
            credential.Password = _senderPassword;
            client.Credentials = credential;
            client.EnableSsl = true;
            client.Port = 587;
            client.Host = "smtp.gmail.com";
            client.Send(message);
        }
    }
}