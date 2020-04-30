using System;
using System.Collections.Generic;
using System.Data;
using System.Dynamic;
using System.Linq;
using System.Windows.Forms;
using Flurl.Http;
using Flurl.Util;
using HealthCare020.Core.Entities;
using Healthcare020.WinUI.Helpers;
using Newtonsoft.Json;

namespace Healthcare020.WinUI.Gradovi
{
    public partial class frmGradoviPrikaz : Form
    {
        public frmGradoviPrikaz()
        {
            InitializeComponent();
        }

        

        private async void frmGradoviPrikaz_Load(object sender, EventArgs e)
        {
            var data = (await Auth.GetAuthorizedApiRequest("gradovi")
                .GetAsync()
                .ReceiveJson<IList<ExpandoObject>>());


            dgrvGradoviPrikaz.DataSource = data.ToDataTable();
        }

        
    }
}
