using System;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Web.DynamicData;
using System.Web.Routing;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.Expressions;
using Humanizer;
using DynamicData.Admin.Controls.Localized; 

namespace DynamicData.Admin.CustomPages.Sections
{
    public partial class Edit : System.Web.UI.Page
    {
        protected MetaTable table;

        protected void Page_Init(object sender, EventArgs e)
        {
            table = DynamicDataRouteHandler.GetRequestMetaTable(Context);
            FormView1.SetMetaTable(table);
            DetailsDataSource.EntityTypeFilter = table.EntityType.Name;
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            Title = table.DisplayName;
            DetailsDataSource.Include = table.ForeignKeyColumnsNames;
        }

        protected void FormView1_ItemCommand(object sender, FormViewCommandEventArgs e)
        {
            if (e.CommandName == DataControlCommands.CancelCommandName)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void FormView1_ItemUpdated(object sender, FormViewUpdatedEventArgs e)
        {
            if (e.Exception == null || e.ExceptionHandled)
            {
                Response.Redirect(table.ListActionPath);
            }
        }

        protected void DetailsDataSource_Updated(object sender, Microsoft.AspNet.EntityDataSource.EntityDataSourceChangedEventArgs e)
        {
            if (e.Exception == null)
            {
                var Station = e.Entity as Model.Section;
                if (Station != null)
                {
                    int itemId = Station.Id;
                    var ucLocalizedItems = (FormView1.FindControl("LocalizedItems") as LocalizedItems);
                    Controls.multi_upload ucMultiUploaders = (FormView1.FindControl("multiupload") as Controls.multi_upload);
                    ucLocalizedItems.SaveData(itemId);
                    ucMultiUploaders.SaveData(itemId);
                }
            }
        }

    }
}
