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


        //Method for button click handling
        private async void sendRequestBtn_ClickAsync(object sender, EventArgs e)
        {

            //Emptying the list box so new data can be inserted
            tradingDataListBox.DataSource = null;

            //Showing loading icon and disabling button from further pressing
            spinnerPic.Visible = true;
            sendRequestBtn.Enabled = false;


            //Checking if the user entered any symbol
            if(symbolTxt.Text.Trim() == "")
            {
                MessageBox.Show("You must enter a symbol to request trading data!", "Symbol empty error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                
                //Hiding loading indicator and enabling the button for next requests
                spinnerPic.Visible = false;
                sendRequestBtn.Enabled = true;
                return;
            }
            try
            {
                //Requesting agregated trading data for 3 days back on a 10 minute interval
                List<TradingData> tradingDatas = await Controller.GetInstance().GetTradingDataAsync(symbolTxt.Text);
                
                tradingDataListBox.DataSource = tradingDatas;
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "Incorrect symbol, please type in a valid symbol", "Symbol error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            spinnerPic.Visible = false;
            sendRequestBtn.Enabled = true;



        }
    }
}
