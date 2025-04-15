using Google.Apis.Auth.OAuth2;
using Google.Apis.Oauth2.v2.Data;
using Google.Apis.Oauth2.v2;
using Google.Apis.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Google.Apis.Util.Store;
using System.IO;

namespace SONA
{
    public partial class Login : UserControl
    {
        SONA S;
        public Login(SONA s)
        {
            InitializeComponent();
            S = s;
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void lbDangky_Click(object sender, EventArgs e)
        {
            SignUp l= new SignUp(S);
            S.pnLogin.Controls.Clear();
            S.pnLogin.Controls.Add(l);

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            Home h = new Home(S);
            S.pnMain.Controls.Clear();
            S.pnMain.Controls.Add(h);

        }

        private async void btnLoginGoogle_Click(object sender, EventArgs e)
        {
            try
            {
                string credPath = "token.json";

                if (Directory.Exists(credPath))
                {
                    Directory.Delete(credPath, true);
                }

                var clientSecrets = new ClientSecrets
                {
                    ClientId = "266768311409-sa0qg8353t75tscss8c71v44usk0cimq.apps.googleusercontent.com",       
                    ClientSecret = "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"
                };

                var scopes = new[] { "profile", "email" };

                var credential = await GoogleWebAuthorizationBroker.AuthorizeAsync(
                    clientSecrets,
                    scopes,
                    "user",
                    CancellationToken.None,
                    new FileDataStore(credPath, true)
                );

                if (credential != null && credential.Token != null)
                {
                    var oauthService = new Oauth2Service(new BaseClientService.Initializer()
                    {
                        HttpClientInitializer = credential
                    });

                    Userinfo userInfo = await oauthService.Userinfo.Get().ExecuteAsync();

                    MessageBox.Show($"Đăng nhập thành công!\nTên: {userInfo.Name}\nEmail: {userInfo.Email}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi đăng nhập: " + ex.Message);
            }
        }
    }
}
