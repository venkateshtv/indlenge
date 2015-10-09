using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Office.Tools.Ribbon;
using Excel = Microsoft.Office.Interop.Excel;
using Office = Microsoft.Office.Core;
using Microsoft.Office.Tools.Excel;
using Microsoft.Office.Interop.Excel;
using System.Net;
using System.IO;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace APIDownload
{
    public partial class tabIndix
    {
        private void tabIndix_Load(object sender, RibbonUIEventArgs e)
        {

        }
        private async Task<string> GetPricingData()
        {
            var result = string.Empty;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("http://localhost:5000/");
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                HttpResponseMessage response = await client.GetAsync("GetPricingData");
                if (response.IsSuccessStatusCode)
                {
                    result = await response.Content.ReadAsStringAsync();
                }
            }
            return result;
        }
        private async void btnDownload_Click(object sender, RibbonControlEventArgs e)
        {
            Excel.Worksheet excelWorksheet = Globals.ThisAddIn.Application.ActiveSheet;
            try
            {
                var result = await GetPricingData();
                var jsreader = new JsonTextReader(new StringReader(result));
                var json = (JObject)new JsonSerializer().Deserialize(jsreader);
                //Writing the Categories
                var products = json["index"];
                excelWorksheet.Cells[1, 1] = "Categories";
                for (int i = 0; i < products.Count(); i++)
                {
                    excelWorksheet.Cells[i + 2, 1] = products[i].ToString();
                }
                //Writing the columns
                var columns = json["columns"];
                for (int i = 0; i < columns.Count(); i++)
                {
                    excelWorksheet.Cells[1, i + 2] = columns[i].ToString();
                }
                //Writing the values
                var values = json["values"];
                for (int i = 0; i < values.Count(); i++)
                {
                    var arr = values[i];
                    for (var j = 0; j < arr.Count(); j++)
                    {
                        excelWorksheet.Cells[i + 2, j + 2] = "$ " + arr[j].ToString();
                    }
                }
            }
            catch (Exception ex)
            {
                excelWorksheet.Cells[1, 1] = "Something went wrong! please try again";                
                
            }
        }
    }
}
