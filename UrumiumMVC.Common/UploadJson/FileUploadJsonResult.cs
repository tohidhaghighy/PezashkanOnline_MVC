using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UrumiumMVC.Common.UploadJson
{
    public class FileUploadJsonResult
    {
        public FileUploadJsonResult()
        {

        }
        public FileUploadTemplate GetJson(string deleteUrl, string folder, List<string> files)
        {
            var res = new FileUploadTemplate
            {
                error = "",
                errorkeys = new List<int>(),
                append = true,
                initialPreview = new List<string>(),
                initialPreviewConfig = new List<PreviewConfig>(),
                initialPreviewThumbTags = new List<string>()
            };
            foreach (var file in files)
            {

                res.initialPreview.Add($"<img src='{folder}{file}' class='file-preview-upload' alt='{file}'>");
                res.initialPreviewConfig.Add(new PreviewConfig
                {
                    caption = file,
                    extra = "{id:" + file + "}",
                    key = file,
                    url = deleteUrl,
                    with = "150px"
                });
            }

            return res;
        }
    }


    public class FileUploadTemplate
    {
        public string error { set; get; }
        public List<int> errorkeys { set; get; }
        public List<string> initialPreview { set; get; }
        public List<PreviewConfig> initialPreviewConfig { set; get; }
        public List<string> initialPreviewThumbTags { set; get; }
        public bool append { set; get; }
    }
    public class PreviewConfig
    {
        public string caption { set; get; }
        public string with { set; get; }
        public string url { set; get; }
        public string key { set; get; }
        public string extra { set; get; }
    }
}
