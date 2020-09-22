using System;
using System.Security.Cryptography;
using System.Text;
using System.Net;
using System.Net.Mail;
using System.IO;
using System.Collections.Generic;
using System.Net.Sockets;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Linq;
using System.Drawing;

namespace vsk_betacent.Models
{
    //Class for code reusability functionalities
    public class CustomUtility
    {     
        //GET : Encryption
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

        public static string Decrypt(string myString)
        {
            TripleDESCryptoServiceProvider cryptDES3 = new TripleDESCryptoServiceProvider();
            MD5CryptoServiceProvider cryptMD5Hash = new MD5CryptoServiceProvider();
            string myKey = "jkfasbgjd12345hjkbhckjsdh";

            cryptDES3.Key = cryptMD5Hash.ComputeHash(ASCIIEncoding.ASCII.GetBytes(myKey));
            //cryptDES3.Mode = CipherMode.ECB;
            cryptDES3.Mode = CipherMode.ECB;
            ICryptoTransform desdencrypt = cryptDES3.CreateDecryptor();
            byte[] buff = Convert.FromBase64String(myString);
            return ASCIIEncoding.ASCII.GetString(desdencrypt.TransformFinalBlock(buff, 0, buff.Length));
        }

        // Send Email 
        public static void SendMail(string uname,string uid, string pwd, string useremail)
            {
                try
                {
                    MailMessage mm = new MailMessage("vskunitfour@gmail.com", useremail);
                    mm.Subject = "User Credentials!";
                    mm.Body = string.Format("Dear User<br/><br/>User ID :{0}<br/>Password :{1}<br/>Portal URL : http://www.vskunit4.com/ <br/>This is a system generated password. So Do not share with anyone.<br/>Thank You.", uid, pwd);
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential();
                    NetworkCred.UserName = "vskunitfour@gmail.com";
                    NetworkCred.Password = "Admin@123";
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
        // Custom Email 
        public static void CustomMail(string useremail,string subject,string body)
            {
                try
                {
                    MailMessage mm = new MailMessage("vskunitfour@gmail.com", useremail);
                    mm.Subject = subject;
                    mm.Body = body;
                    mm.IsBodyHtml = true;
                    SmtpClient smtp = new SmtpClient();
                    smtp.Host = "smtp.gmail.com";
                    smtp.EnableSsl = true;
                    NetworkCredential NetworkCred = new NetworkCredential();
                    NetworkCred.UserName = "vskunitfour@gmail.com";
                    NetworkCred.Password = "Admin@123";
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
            //Yes or No static status List
            public static IEnumerable<StatusList> statusList = new List<StatusList> { 
                new StatusList {
                    int_statusId = 1,
                    chrv_statusName = "Yes"
                },
                new StatusList {
                    int_statusId = 2,
                    chrv_statusName = "No"
                }
            };
            
          
        //Function to get value NA if null/empty
        public static dynamic GetValue(dynamic item)
        {
            if(item==null)
                return "-";
            else 
                return item;
        }
        //Function to get value NA if null/empty
        public static dynamic GetValueIfDouble(dynamic item)
        {
            if(item==0)
                return 0;
            else 
                return item;
        }
      
        //Function to get status NA if null/empty and yes/no
        public static dynamic GetStatus(dynamic item)
        {
            if(item==null || item==0)
                return "-";
            else if(item==1)
                return "Yes";
            else if(item==2)
                return "No";
            else 
                return item;
        }
        //Function to get status NA if null/empty and yes/no
        public static dynamic GetNumber(dynamic item)
        {
            if(item==null || item==0)
                return 0;
            else 
                return item; 
        }
         //Function to get Value NA if null/empty 
        public static dynamic GetNA(dynamic item)
        {
            if(item==null || item==0)
                return "NA";
            else 
                return item; 
        }
        
        //Function to get file name from URL
        public static string GetFileNameFromURL(string url)
        {
            if(url!=null)
            {
                return url.Substring(url.LastIndexOf("/")+1);
            }
            else
            {
                return "NA";
            }
        }
 
      
        public static int splitFbNm(List<string> fbNmList)
        {
            //string Nm="";
            if(fbNmList.Count!=0)
            {
                // string Nm = string.Empty;
                // foreach (var item in fbNmList)
                //     Nm = Nm + item + ",";
                // Nm = Nm.Remove(Nm.Length - 1);
                // return Nm;
                return fbNmList.Count;
            }
            else{
                return 0;
            }
        }
        public static string splitListWithComma(List<string> itemList)
        {
            if(itemList.Count!=0)
            {
                string output = string.Empty;
                foreach (var item in itemList)
                    output = output + item + ",";
                output = output.Remove(output.Length - 1);
                return output;
            }
            else{
                return null;
            }
        }
        
        
        
    }

    
    //Class for StatusList(Yes/No)
    public class StatusList
    {
        public int int_statusId { get; set; }
        public string chrv_statusName { get; set; }
    }
    //Class for StatusList(Yes/No)
    public class YearList
    {
        public int int_yearId { get; set; }
        public string chrv_year { get; set; }
    }
    //Class to generate randam password
    public static class RandomNumberGenerator  
    {  
        // Generate a random number between two numbers    
        public static int RandomNumber(int min, int max)  
        {  
            Random random = new Random();  
            return random.Next(min, max);  
        }  
        public static string RandomString(int size, bool lowerCase)  
        {  
            StringBuilder builder = new StringBuilder();  
            Random random = new Random();  
            char ch;  
            for (int i = 0; i < size; i++)  
            {  
                ch = Convert.ToChar(Convert.ToInt32(Math.Floor(26 * random.NextDouble() + 65)));  
                builder.Append(ch);  
            }  
            if (lowerCase)  
                return builder.ToString().ToLower();  
            return builder.ToString();  
        }  
        
        // Generate a random password of a given length (optional)  
        public static string RandomPassword(int size = 0)  
        {  
            StringBuilder builder = new StringBuilder();  
            builder.Append(RandomString(4, true));  
            builder.Append(RandomNumber(1000, 9999));  
            builder.Append(RandomString(2, false));  
            return builder.ToString();  
        } 
       
    }
    //Class for session object
    public static class SessionExtensions
    {
        public static void SetObject(this ISession session, string key, object value)
        {
            session.SetString(key, JsonConvert.SerializeObject(value));
        }

        public static T GetObject<T>(this ISession session, string key)
        {
            var value = session.GetString(key);

            return value == null ? default(T) : JsonConvert.DeserializeObject<T>(value);
        }
    }
    public class CustomSelectList
    {
        public int value { get; set; }
        public string text { get; set; }
    }
    
}  
