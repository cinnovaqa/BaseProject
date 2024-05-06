using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BaseProject.Login
{
    public class LoginFlow : LoginPage
    {

        public static void Login(string email, string password)
        {
            ControlUtils.ClickElement(Email);
            ControlUtils.EnterText(Email, email);
            ControlUtils.ClickElement(Password);
            ControlUtils.EnterText(Password, password);
            ControlUtils.ClickElement(LoginButton);
            ControlUtils.WaitForElement(DashboardHeader);
        }
        public static void VerifyLogin(string email, string password)
        {
            if (!LogOut())
            {
                Login(email,password);
            }
        }
    }

}

