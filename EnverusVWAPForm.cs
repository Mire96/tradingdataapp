using Enverus.VWAPService.APIConnection;
using Enverus.VWAPService.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Enverus.VWAPService
{
    public partial class EnverusVWAPForm : Form
    {
        public EnverusVWAPForm()
        {
            InitializeComponent();
        }

        private async void sendRequestBtn_ClickAsync(object sender, EventArgs e)
        {
            if(symbolTxt.Text == "" || symbolTxt.Text == null)
            {
                MessageBox.Show("You must enter a symbol to request trading data!", "Symbol empty error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            try
            {
                List<TradingData> tradingDatas = await Controller.GetInstance().GetTradingDataAsync(symbolTxt.Text);
                tradingDataListBox.DataSource = null;
                tradingDataListBox.DataSource = tradingDatas;
            }
            catch (Exception)
            {
                MessageBox.Show("Incorrect symbol, please type in a valid symbol", "Symbol error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }



            
        }
    }
}
