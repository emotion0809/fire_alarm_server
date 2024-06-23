using FirebaseAdmin;
using Google.Apis.Auth.OAuth2;

namespace FireAlarmServer
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void test_Click(object sender, EventArgs e)
        {
            Task task = Program.sendMessage();
        }

        private void InitializeFirebase()
        {
            FirebaseApp.Create(new AppOptions()
            {
                Credential = GoogleCredential.FromFile("path/to/your-service-account-file.json"),
            });
        }
    }
}
