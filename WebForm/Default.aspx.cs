using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using BUS;
using DTO;

namespace TestWeb
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            List<ThietBi> tb = ThietBiBUS.ListTB();
            foreach (var item in tb)
            {
                HtmlTableRow row = new HtmlTableRow();
                HtmlTableCell cell = new HtmlTableCell();
                cell.InnerText = item.Matb;
                HtmlTableCell cell1 = new HtmlTableCell();
                cell1.InnerText = item.Tentb;
                HtmlTableCell cell2 = new HtmlTableCell();
                cell2.InnerText = item.Loaitb;

                HtmlTableCell cell3 = new HtmlTableCell();
                cell3.InnerText = item.Dongia.ToString();
                HtmlTableCell cell4 = new HtmlTableCell();
                cell4.InnerText = item.SL.ToString();
                row.Controls.Add(cell);
                row.Controls.Add(cell1);
                row.Controls.Add(cell2);
                row.Controls.Add(cell3);
                row.Controls.Add(cell4);
                tbl_ThietBi.Controls.Add(row);

            }
        }
    }
}