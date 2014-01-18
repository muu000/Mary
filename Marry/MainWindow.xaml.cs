using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Marry
{
    /// <summary>
    /// MainWindow.xaml の相互作用ロジック
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var p = target.Width;
            var bmp = new RenderTargetBitmap((int)target.Width,
                     (int)target.Height,
                     96, 96,
                     PixelFormats.Pbgra32);

            bmp.Render(target);

            var enc = new PngBitmapEncoder();
            enc.Frames.Add(BitmapFrame.Create(bmp));

            // ひとまずデスクトップに保存
            string dir = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (var fs = File.Open(System.IO.Path.Combine(dir, "MaryOut.png"), FileMode.Create))
            {
                enc.Save(fs);
                MessageBox.Show("seikou");
            }
        }
    }
}
