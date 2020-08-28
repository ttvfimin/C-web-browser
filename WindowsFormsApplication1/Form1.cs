using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows.Forms;
using System.Threading;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        /// <summary>
        /// THE NEXT LINES UNTIL NEXT 3 LINE COMMENT ARE FOR CLEARING HISTORY, DATA, COOKIES, ETC
        /// </summary>
        private const int INTERNET_OPTION_END_BROWSER_SESSION = 42;
        [DllImport("wininet.dll", SetLastError = true)]
        private static extern bool InternetSetOption(IntPtr hInternet, int dwOption, IntPtr lpBuffer, int lpdwBufferLength);
        /// <summary>
        /// END OF PREVIOUS COMMENT REFERENCE
        /// </summary>
        
        public Form1()
        {
            InitializeComponent();
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string address = textBox1.Text;
            textBox1.Text = "";
            if (String.IsNullOrEmpty(address)) return;
            if (address.Equals("about:blank")) return;
            if (!address.StartsWith("http://") &&
                    !address.StartsWith("https://"))
            {
                address = "http://" + address;
            }
            try
            {
                webBrowser1.Navigate(new Uri(address));
            }
            catch (System.UriFormatException)
            {
                return;
            }


        }

        private void webBrowser1_Navigated(object sender, WebBrowserNavigatedEventArgs e)
        {
            textBox1.Text = webBrowser1.Url.ToString();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                textBox1.Text = webBrowser1.Url.ToString();
            }
            catch (Exception)
            {
                return;
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            string address = "https://github.com/ttvfimin/C-web-browser";
            webBrowser1.Navigate(new Uri(address));
        }

        private void button12_Click(object sender, EventArgs e)
        {
            InternetSetOption(IntPtr.Zero, INTERNET_OPTION_END_BROWSER_SESSION, IntPtr.Zero, 0);
            string[] theCookies = System.IO.Directory.GetFiles(Environment.GetFolderPath(Environment.SpecialFolder.Cookies));
            foreach (string currentFile in theCookies)
            {
                try
                {
                    System.IO.File.Delete(currentFile);
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Failed to clear cookies.");
                    Console.WriteLine(ex);
                }
            }
            webBrowser1.Navigate("javascript:void((function(){var a,b,c,e,f;f=0;a=document.cookie.split('; ');for(e=0;e<a.length&&a[e];e++){f++;for(b='.'+location.host;b;b=b.replace(/^(?:%5C.|[^%5C.]+)/,'')){for(c=location.pathname;c;c=c.replace(/.$/,'')){document.cookie=(a[e]+'; domain='+b+'; path='+c+'; expires='+new Date((new Date()).getTime()-1e11).toGMTString());}}}})())");
            webBrowser1.Navigate(new Uri("https://www.google.com/"));
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string address = "https://youtube.com";
            webBrowser1.Navigate(new Uri(address));
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string address = "https://google.com";
            webBrowser1.Navigate(new Uri(address));

        }

        private void button7_Click(object sender, EventArgs e)
        {

            string address = "https://roblox.com";
            webBrowser1.Navigate(new Uri(address));
        }

        private void button8_Click(object sender, EventArgs e)
        {

            string address = "https://wikipedia.org";
            webBrowser1.Navigate(new Uri(address));
        }

        private void button9_Click(object sender, EventArgs e)
        {

            string address = "https://docs.microsoft.com/en-us/dotnet/csharp/";
            webBrowser1.Navigate(new Uri(address));
        }

        private void button10_Click(object sender, EventArgs e)
        {
            string address = "https://docs.python.org/3/";
            webBrowser1.Navigate(new Uri(address));
        }

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HT_CAPTION = 0x2;

        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);
        [System.Runtime.InteropServices.DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(Handle, WM_NCLBUTTONDOWN, HT_CAPTION, 0);
            }
        }
    }
}
