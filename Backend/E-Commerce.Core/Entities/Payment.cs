using E_Commerce.Core.Entities.Identity;
using E_Commerce.Core.Entities.Oreder_Agrigate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_Commerce.Core.Entities
{
    public enum PaymentMethod
    {
        casch,visa
    }
    public class Payment
    {

        public int id { get; set; }
        public decimal amount { get; set; }

        public PaymentMethod paymentMethod{ get; set; }
        
        public DateTime Date { get; set; }

        public string userId {  get; set; }
        public AppUser User { get; set; }//one-to-many

        public int orderId {  get; set; }
        public Order Order { get; set; }
        
    
    
    
    }
}
