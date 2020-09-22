using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Security.Cryptography;

namespace vsk_betacent.Models
{
    public class UtilityModel
    {
        public static string Alphabet = "0123456789";
        //Encryption
        public static string Encrypt(string myString)
        {
            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
            string myKey = "jkfasbgjd12345hjkbhckjsdh";

            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateEncryptor();
            var MyASCIIEncoding = new ASCIIEncoding();
            byte[] buff = ASCIIEncoding.ASCII.GetBytes(myString);
            return Convert.ToBase64String(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        //Decryption

        public static string Decrypt(string myString)
        {
            myString = myString.Replace(' ', '+');
            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
            string myKey = "jkfasbgjd12345hjkbhckjsdh";

            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            byte[] buff = Convert.FromBase64String(myString);
            return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        //Create password for User
        public static string generateRandomNo(int fno, int lno)
        {
            try
            {
                Random rand = new Random();
                int num = rand.Next(fno, lno);
                return num.ToString();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        //Create password for User
        public static string generatePassword(string fname)
        {
            try
            {
                Random rand = new Random();
                char[] chars = new char[5];
                string pwd = "";
                for (int i = 0; i < 5; i++)
                {
                    if (i == 0)
                    {
                        pwd = fname.Substring(0, 3).ToString().Trim() + Alphabet[rand.Next(Alphabet.Length)].ToString();
                    }
                    else
                    {
                        pwd = pwd + Alphabet[rand.Next(Alphabet.Length)].ToString();
                    }
                }
                pwd = Encrypt(pwd);
                return pwd;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        // Send Email 

        public static void SendMail(string name, string userid, string pwd, string useremail, string type)
        {
            try
            {
                //     SLUMDBCONTEXT db=new SLUMDBCONTEXT(DbContextOptions<SLUMDBCONTEXT> options);
                MailMessage mm = new MailMessage("amitkumar.sarangi60@gmail.com", useremail);
                pwd = Decrypt(pwd);
                if (type == "registration")
                {
                    mm.Subject = "Login Credentials";
                    mm.Body = string.Format("Dear " + name + ", <br /> You are successfully registered to Slum Information Management System. Please find your login details below.<br />  User ID : " + userid + " <br/> Password :" + pwd + "<br /> <br /> click here: <a href='http://111.93.174.107/SLUM_GIS'>http://111.93.174.107/SLUM_GIS</a> to start using application now. <br/> <br/> Thank You, <br/> <a href='http://www.sparcindia.com'>SPARC Pvt. ltd.</a><br/>");
                }
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "amitkumar.sarangi60@gmail.com";
                NetworkCred.Password = "sweetpupun";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        //Random password
        public static string RandomPassword(int length = 8)
        {
            Random random = new Random();
            // Create a string of characters, numbers, special characters that allowed in the password
            string alphabet = "ABCDEFGHJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789!@#$%^&*?_-=+";
            //remember to declare pass as an array
            char[] Password = new char[length];
            //put the length -1 in cache
            int alphaLength = alphabet.Length - 1;
            // Select one random character at a time from the string and create an array of chars
            for (int i = 0; i < length; i++)
            {
                Password[i] = alphabet[random.Next(0, alphaLength)];
            }
            //turn the array into a string
            return new string(Password);
        }
        //Send Mail for forgot password
        public static void SendMail_FP(string pwd, string emailId)
        {
            try
            {

                //   MailMessage mail = new MailMessage();
                //   mail.Subject = "Your Subject";
                //     mail.From = new MailAddress("ocac.dowr@gmail.com");
                //     mail.To.Add(emailId);
                //      mail.Body = string.Format("<div style='border:1px solid #ddd;border-bottom:none;padding:10px'><img src='@Url.Content('~/images/dowr.jpg')' style='height:50px;'></div><div style='border:1px solid #ddd;border-bottom:none;padding:10px'><strong>Your New password is : </strong>{0} </div><div style='border:1px solid #ddd;border-bottom:none;padding:10px'>This is a system generated password. So Do not share with anyone.</div><div style='border:1px solid #ddd;;padding:10px'><b><i>Thank You.</i></b></div>", pwd);
                //     mail.IsBodyHtml = true;
                //     SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587);
                //     smtp.EnableSsl = true;
                //     NetworkCredential netCre = new NetworkCredential("ocac.dowr@gmail.com","Dowr@123" );
                //     smtp.Credentials = netCre;
                //     smtp.Send(mail);

                MailMessage mm = new MailMessage("sparc.testmail@gmail.com", emailId);
                mm.Subject = "User Credentials!";
                mm.Body = string.Format("Your  User Name is {0} <br /><br />Your  password is : <br/>{1}<br/>This is a system generated password. So Do not share with anyone.<br/>Thank You.", emailId, pwd);
                mm.IsBodyHtml = true;
                SmtpClient smtp = new SmtpClient();
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                NetworkCredential NetworkCred = new NetworkCredential();
                NetworkCred.UserName = "sparc.testmail@gmail.com";
                NetworkCred.Password = "sparc@123";
                smtp.UseDefaultCredentials = true;
                smtp.Credentials = NetworkCred;
                smtp.Port = 587;
                smtp.Send(mm);
            }
            catch (Exception ex)
            {

                throw ex;
            }
        }
        public static string Grivance_Id(String Gid)
        {
            var arr = "";
            var AGid = Gid.Split("/");

            var date = DateTime.Now.ToShortDateString();
            var datewithout = date.Replace("-", "");
            if (Gid != null)
            {
                int abc = Convert.ToInt32(AGid[2]) + 1;
                if (abc < 9)
                {
                    arr = "DoWRGMS/" + datewithout + "/00" + abc;
                }

                else if (abc < 99)
                {
                    arr = "DoWRGMS/" + datewithout + "/0" + abc;
                }
                else
                {
                    arr = "DoWRGMS/" + datewithout + "/" + abc;
                }
            }
            else
            {
                arr = "DoWRGMS/" + datewithout + "/001";
            }
            return new string(arr);

        }
    }
}
