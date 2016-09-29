using System;
using System.Web;
using System.Web.Services;
using System.Web.Services.Protocols;
using System.ComponentModel;
using System.Linq;

namespace DidactischeLeermiddelen.Models.domain
{
    public class Lector : User
    {
        

        public override void ReserveMaterial(Material material, int amount, DateTime start, DateTime  creation) {

            if (Wishlist.Contains(material))
            {
                if (start < DateTime.Now)
                {
                     throw new ArgumentException("Het is niet mogelijk om materiaal te reserveren in het verleden.");                   
                }

                int amountAvailable = material.GetAmountAvailable(start);

                if (amount > amountAvailable)
                {

                    foreach (ReservedMaterial r in material.Reservations.OrderByDescending(r => r.CreationDate))
                    {
                        if(r is Reservation)
                        {
                            material.Reservations.Remove(r);
                            throw new ArgumentException("Je gaat een student overrulen.");
                        }
                        else
                        {
                            throw new ArgumentException("Er zijn maar " + amountAvailable + " artikelen beschikbaar van " +
                                        material.Name + " voor de gewenste datum.");
                        }

                    }
                    
                }
                    Blocking b = new Blocking()
                {
                    User = this,
                    Material = material,
                    AmountReserved = amount,
                    StartDate = start,
                    name = material.Name,
                    useremail = this.Email,
                    CreationDate = creation,
                    EndDate = start.AddDays(1)
                };

                if (b != null)
                {
                    material.AddToReservations(b);
                    Reservations.Add(b);
                }
            }

        }
    }
}