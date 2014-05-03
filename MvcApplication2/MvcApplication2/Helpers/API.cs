using MvcApplication2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace MvcApplication2.Helpers
{
    public class API
    {
        string tableBody = null;
        public void sendEmail(string recEmailId, string typeOfEmail, List<Cart> carts)
        {
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //Below is the new created email ID to send emails to customers
                client.Credentials = new NetworkCredential("shopcustomerserv@gmail.com","Hello12345");
                MailMessage msg = new MailMessage();
                msg.To.Add("amit.dikkar@gmail.com"); //Customer Mail ID
                msg.From = new MailAddress("shopcustomerserv@gmail.com");
                msg.Subject = "Hello"; //Subject of Mail
                msg.IsBodyHtml = true;
                msg.Body = @"<H3> Hello <H3>
                    <p>Thank you for shopping with us. We'd like to let you know that BootShop has received your order, 
                    and is preparing it for shipment. Your estimated delivery date is below and orders are shown below </p>
                    <table border=1>
                  <tr>
                    <th>Item Name</th>
                    <th>Estimated Shipping Date</th>
                    <th>Quantity<th>
                  </tr>"+//+ getTableBody(carts) +
                "</table>"+
                "<p>Please Message Back to shopcustomerserv@gmail.com for queries<p>"+
                "<p>Thanks for Shopping With US<p>"+
                "<br>"+
                "<p>-CustomerService, BootShop<p>"+
                    ";"; //Body of Mail
                client.Send(msg);
                //Response.Write("Mail Sent");
            }
            catch (Exception ex)
            {
                //Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }

        public void sendRegistrationEmail(User user)
        {
            string userEmail = user.email;
            string userPass = user.password;
            try
            {
                SmtpClient client = new SmtpClient("smtp.gmail.com", 587);
                client.EnableSsl = true;
                client.Timeout = 10000;
                client.DeliveryMethod = SmtpDeliveryMethod.Network;
                client.UseDefaultCredentials = false;
                //Below is the new created email ID to send emails to customers
                client.Credentials = new NetworkCredential("shopcustomerserv@gmail.com","Hello12345");
                MailMessage msg = new MailMessage();
                msg.To.Add("amit.dikkar@gmail.com"); //Customer Mail ID
                msg.From = new MailAddress("shopcustomerserv@gmail.com");
                msg.Subject = "Hello"; //Subject of Mail
                msg.IsBodyHtml = true;
                msg.Body = @"<H3> Hello <H3>
                    <p>Thank you for Registering with us. Here are your credentials for future login.</p>
                    <table border=1>
                  <tr>
                    <th>Username</th>
                    <th>Password</th>
                  </tr>" +//+ getTableBody(carts) +
                         "<tr>"+
                    "<td>"+userEmail+"</td>"+
                    "<td>"+userPass+"</td>" +
                    "<td>1<td>"+
                  "</tr>"+
                "</table>"+
                "<p>Please Message Back to shopcustomerserv@gmail.com for queries<p>"+
                "<p>Thanks for Shopping With US<p>"+
                "<br>"+
                "<p>-CustomerService, BootShop<p>"+
                    ";"; //Body of Mail
                client.Send(msg);
                //Response.Write("Mail Sent");
            }
            catch (Exception ex)
            {
                //Response.Write("Could not send the e-mail - error: " + ex.Message);
            }
        }
        /*
        private string getTableBody(List<Cart> carts)
        {
            string tablebody = "";
            foreach (Cart cart in carts)
            {
                tablebody = tablebody + "<tr>"+
                    <td>Nike Venom Boots</td>
                    <td>12-May-2104</td>
                    <td>1<td>
                  </tr>"
            }
        }*/
    }
}