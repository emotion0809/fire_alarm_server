using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;
using FirebaseAdmin.Messaging;

namespace FireAlarmServer
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            InitializeFirebase.Initialize();
            ApplicationConfiguration.Initialize();
            Application.Run(new Form1());
            
        }

        //log����
        public static void writeLog(String text)
        {
            String path = String.Format(System.IO.Path.GetFullPath("..\\..\\..\\..\\logs\\log{0}.txt"), DateTime.Now.ToString("yyyyMMdd"));
            StreamWriter sw = new StreamWriter(path, true);
            sw.WriteLine(string.Format("{0}�G{1}", DateTime.Now.ToString("HH:mm:ss"), text));
            sw.Close();
        }

        /*static void InitializeFirebase()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("..\\..\\..\\..\\service-account.json"),
            });
        }*/

        public static async Task sendMessage()
        {

            // �]�m�n�o�e���q��
            var message = new FirebaseAdmin.Messaging.Message()
            {
                Notification = new Notification
                {
                    Title = "Hello",
                    Body = "This is a test notification"
                },
                Token = "ddW0Q8dbQgqEnjKWowVadb:APA91bGhg_a2xOG1IBe08fT31UMHyiSwet-GL58sOfLwGZ6ajO5NXsgkSjOFG9xgCpPmWnPkwIGzJGpK1f3da65wImON6lDoEbvDAFYH_Hhvri4ydqMnq8PFQWWm0bsbqkUMX1y_RnfI"
            };

            // �o�e�q��
            string response = await FirebaseMessaging.DefaultInstance.SendAsync(message);
            writeLog("Successfully sent message: " + response);
        }
    }
}