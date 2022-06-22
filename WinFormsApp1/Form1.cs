using Business.Concrete;
using Core.Concrete.EntityFramework;
using DataAccess.Concrete.EntityFramework;

namespace WinFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

            RentaCarContext rc = new RentaCarContext();

            dataGridView1.DataSource = rc.Cars;

           // CarDetailsTest();
            CarManager carManager = new CarManager(new EfCarDal());
            dataGridView1.DataSource = carManager.GetAll().Data;
        }

        static void CarDetailsTest()
        {
            CarManager carManager = new CarManager(new EfCarDal());

            var result = carManager.GetCarDetails();

            if (result.Success == true)
            {
                foreach (var car in carManager.GetCarDetails().Data)
                {
                    MessageBox.Show(car.CarName + " " + car.BrandName + " " + car.ColorName);
                }
            }

            else
            {
                MessageBox.Show(result.Message);
            }


        }

    }
}
