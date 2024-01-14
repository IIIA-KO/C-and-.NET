using WeatherClassLibrary;
namespace task_01
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            UpdateData();
        }

        private void UpdateData()
        {
            Weather weather = new Weather("https://www.gismeteo.ua/ua");
            try
            {
                labelTitle.Text = weather.Title;
                labelTemperature.Text = "Температура: " + weather.Temperature.ToString();
                labelWindSpeed.Text = "Швидкість вітру: " + weather.WindSpeed.ToString() + " м/с";
                labelWindDirection.Text = "Напрям вітру: " + weather.WindDirection;
                labelHumidity.Text = "Вологість: " + weather.Humidity.ToString() + " %";
                labelWaterTemperature.Text = "Температура води: " + weather.WaterTemperature.ToString();
                pictureBox1.ImageLocation = "https:" + weather.ImageLink;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }

        private void buttonUpdate_Click(object sender, EventArgs e)
        {
            UpdateData();
        }
    }
}