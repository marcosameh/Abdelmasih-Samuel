using DynamicData.Admin.Infrastructure.MultiUploadEntities;
using DynamicData.Admin.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Script.Serialization;
using System.Web.UI;

namespace DynamicData.Admin.Controls
{
    public partial class multi_upload : UserControl
    {
        public string targetFolder { get; set; }

        public bool resize { get; set; }

        public string photoThumbnail { get; set; }
        public string FieldHint
        {
            set
            {
                lblFieldHint.Text = value;
            }
        }
        private MultiUpload MultiUploadProperties
        {
            get
            {
                return new MultiUpload()
                {
                    TargetFolder = targetFolder,
                    Resize = resize,
                    PhotoThumbnail = photoThumbnail
                };
            }
        }

        public List<UploadedPhoto> UploadedPhotos
        {
            get
            {
                if (string.IsNullOrEmpty(hdnPhotoNamesArray.Value))
                    return new List<UploadedPhoto> { };

                return new JavaScriptSerializer().Deserialize<List<UploadedPhoto>>(hdnPhotoNamesArray.Value);
            }
        }

        public int[] DeletedPhotosIds
        {
            get
            {
                if (string.IsNullOrEmpty(hdnJsonDeletedPhotos.Value))
                    return new int[] { };

                return new JavaScriptSerializer().Deserialize<int[]>(hdnJsonDeletedPhotos.Value);
            }
        }

        protected void Page_Load(object sender, EventArgs e)
        {
            if (Request.Path.ToLower().Contains("edit.aspx"))
            {
                divSavedPhotos.Visible = true;
            }
            hdnJsonParam.Value = new JavaScriptSerializer().Serialize(MultiUploadProperties);
        }

        public IQueryable<EntityPhoto> lvPhotos_GetData()
        {
            AdminEntities db = new AdminEntities();
            string photoTableName = Page.Title + "Photos";

            //ToDo: set cases according to your entity 
            int itemId = Convert.ToInt32(Request.QueryString["Id"]);
            switch (photoTableName)
            {
                case "SectionsPhotos":
                    IQueryable<SectionPhoto> sectionsphotos = from l in db.SectionPhotoes where l.SectionId == itemId select l;

                    return sectionsphotos.Select(x => new EntityPhoto()
                    {
                        EntityId = x.SectionId,
                        EntityName = "sections",
                        PhotoId = x.Id,
                        PhotoPath = Setting.FrontendVirtualPath + "/photos/sections/" + x.Photo.Replace("_lg", "_sm")
                    });
            }
            return null;
        }

        private void InsertData(int itemId, AdminEntities db)
        {
            if (UploadedPhotos.Count > 0)
            {

                string photoTableName = Page.Title + "Photos";

                //ToDo: set cases according to your entity 
                switch (photoTableName)
                {
                    case "SectionsPhotos":
                        foreach (UploadedPhoto photo in UploadedPhotos)
                        {
                            db.SectionPhotoes.Add(new SectionPhoto()
                            {
                                SectionId = itemId,
                                Photo = photo.LargePhotoName
                            });

                        }
                        break;
                }
            }
        }

        private void DeletePhotos(int itemId, AdminEntities db)
        {
            if (DeletedPhotosIds.Length > 0)
            {
                string photoTableName = Page.Title + "Photos";

                //ToDo: set cases according to your entity 
                switch (photoTableName)
                {
                    case "SectionsPhotos":
                        foreach (int id in DeletedPhotosIds)
                        {
                            SectionPhoto photo = db.SectionPhotoes.First(x => x.Id == id);
                            db.SectionPhotoes.Remove(photo);
                        }
                        break;
                }
            }
        }

        public void SaveData(int itemId)
        {
            AdminEntities db = new AdminEntities();

            string requestPath = Request.Path.ToLower();
            if (requestPath.Contains("edit.aspx"))
            {
                DeletePhotos(itemId, db);
            }
            InsertData(itemId, db);
            db.SaveChanges();
        }
    }
}