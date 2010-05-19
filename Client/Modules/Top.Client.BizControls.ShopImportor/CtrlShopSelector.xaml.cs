using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;
using Top.Client.Components.DM;
using System.Threading;

namespace Top.Client.BizControls
{
    public partial class CtrlShopSelector : UserControl
    {
        public CtrlShopSelector()
        {
            InitializeComponent();
        }

        private void Search_Click(object sender, RoutedEventArgs e)
        {
            //ThreadPool.QueueUserWorkItem((state) =>
            //{
            //    Thread.Sleep(busySeconds * 1000);
            //    Dispatcher.BeginInvoke(() => DataContext = false);
            //});

            Thread thread = new Thread(GetTitle);
            thread.Start(txtNick.Text);
        }

        private void GetTitle(object nick)
        {
            try
            {
                ShopDM dm = new ShopDM("http://localhost:8886/Top/WcfServer");
                string title = dm.GetFullShopInfoByNick(nick.ToString());

                Dispatcher.BeginInvoke(
                    () => MessageBox.Show(title));
            }
            catch (Exception ex)
            {
                Dispatcher.BeginInvoke(
                    () => MessageBox.Show(ex.Message));
            }
        }
    }
}
