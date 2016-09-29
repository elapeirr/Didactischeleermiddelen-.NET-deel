using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Net.Mail;

namespace DidactischeLeermiddelen.Models.domain
{
    public class Student : User
    {

        public override void ReserveMaterial(Material material, int amount, DateTime start, DateTime creation)
        {

            if (Wishlist.Contains(material))
            {
                if (start < DateTime.Now)
                {
                    throw new ArgumentException("Het is niet mogelijk om materiaal te reserveren in het verleden.");
                }

                int amountAvailable = material.GetAmountAvailable(start);

                if (amount > amountAvailable)
                {
                    
                    throw new ArgumentException("Er zijn maar " + amountAvailable + " artikelen beschikbaar van " +
                                material.Name + " voor de gewenste datum.");
                    
                }


                Reservation r = new Reservation()
                {
                    User = this,
                    Material = material,
                    AmountReserved = amount,
                    StartDate = start,
                    name = material.Name,
                    useremail = this.Email,
                    CreationDate = creation,
                    EndDate = start.AddDays(7)
                };

                Reservations.Add(r);
                material.AddToReservations(r);
            }
                

                //MailMessage mail = new MailMessage("test@example.com", Email);
                //SmtpClient client = new SmtpClient();
                //client.Port = 25;
                //client.DeliveryMethod = SmtpDeliveryMethod.Network;
                //client.UseDefaultCredentials = false;
                //client.Host = "smtp.google.com";
                //mail.Subject = "Reservatie leermiddelen";
                //mail.Body = "Uw reservatie voor" + material.Name + "is bevestigd. U kan het op " + start.ToString() + "komen ophalen in het lokaal "+ material.Location;
                //client.Send(mail);
            }
        }
    }
