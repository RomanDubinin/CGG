using System.Drawing;
using System.Windows.Forms;

namespace Vsualization
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			pictureBox1.Image = new Bitmap(pictureBox1.Width, pictureBox1.Height);

			var graphics = Graphics.FromImage(pictureBox1.Image);

		}
	}
}
