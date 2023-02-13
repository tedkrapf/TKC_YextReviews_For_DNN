/*
' Copyright (c) 2023  Techemistry.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System;
using DotNetNuke.Security;
using DotNetNuke.Services.Exceptions;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Entities.Modules.Actions;
using DotNetNuke.Services.Localization;
using RestSharp;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;

namespace TechemistryTKC_YextReviews
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The View class displays the content
    /// 
    /// Typically your view control would be used to display content or functionality in your module.
    /// 
    /// View may be the only control you have in your project depending on the complexity of your module
    /// 
    /// Because the control inherits from TKC_YextReviewsModuleBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// 
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class View : TKC_YextReviewsModuleBase, IActionable
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Settings.Contains("txtApiKey") || string.IsNullOrWhiteSpace(Settings["txtApiKey"].ToString()))
                {
                    lblLoadErrorMsg.Text = "The API Key and other settings must be configured in this module's settings.";
                    return;

                }
                else
                    LoadReviews();
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        private void LoadReviews()
        {
            try
            {
                string apiKey = Settings["txtApiKey"].ToString();
                int limit = string.IsNullOrWhiteSpace(Settings["txtQtyLimit"].ToString()) ? 20
                    : Int32.TryParse(Settings["txtQtyLimit"].ToString(), out limit) ? Convert.ToInt32(Settings["txtQtyLimit"].ToString()) : 20;
                string entityID = Settings["txtEntityID"].ToString();
                decimal minRating = string.IsNullOrWhiteSpace(Settings["txtMinRating"].ToString()) ? 4M
                    : decimal.TryParse(Settings["txtMinRating"].ToString(), out minRating) ? Convert.ToDecimal(Settings["txtMinRating"].ToString()) : 4M;
                
                bool onlyCommentReviews = false;
                if (Settings.Contains("chkCommentReviewsOnly") && !string.IsNullOrWhiteSpace(Settings["chkCommentReviewsOnly"].ToString()))
                    onlyCommentReviews = Settings["chkCommentReviewsOnly"].ToString() == "true";

                bool showDate = true;
                if (Settings.Contains("chkShowDate") && !string.IsNullOrWhiteSpace(Settings["chkShowDate"].ToString()))
                    showDate = Settings["chkShowDate"].ToString() == "true";

                string showDateFormat = "MMMM yyyy";
                if (Settings.Contains("txtShowDateFormat") && !string.IsNullOrWhiteSpace(Settings["txtShowDateFormat"].ToString()))
                    showDateFormat = Settings["txtShowDateFormat"].ToString();

                string rotateJS = "";
                if (Settings.Contains("txtRotateJS") && !string.IsNullOrWhiteSpace(Settings["txtRotateJS"].ToString()))
                    rotateJS = Settings["txtRotateJS"].ToString();



                string url = "https://api.yext.com/v2/accounts/2037600/reviews"
                    + "?api_key=" + apiKey
                    + "&limit=" + limit.ToString()
                    + "&v=" + DateTime.Now.AddDays(1).ToString("yyyyMMdd")
                    + "&entityIds=" + entityID
                    + "&minRating=" + minRating.ToString();

                var client = new RestClient(url);
                var rq = new RestRequest();
                var response = client.Get(rq);

                string json = response.Content;

                var reviewsObj = JsonConvert.DeserializeObject<YextReviews>(json);
                var revs = reviewsObj.response.reviews;

                List<TkcReview> reviews = new List<TkcReview>();
                foreach (var r in revs)
                    reviews.Add(new TkcReview(r, showDate, showDateFormat));


                

                if (onlyCommentReviews)
                    reviews = reviews.Where(c => c.comment != null && c.comment.Length > 6).ToList();

                lvReviews.DataSource = reviews.OrderByDescending(c => c.createdDate).ToList();

                lvReviews.DataBind();

                int blobWidth = 340;
                ltPaneStyle.Text = "<style>.tkrPane { width: " + (blobWidth * reviews.Count).ToString() + "px; }</style>";

                if (!string.IsNullOrWhiteSpace(rotateJS))
                    ltPaneStyle.Text += "<script>"
                        + rotateJS
                            .Replace("{{blobsCnt}}", reviews.Count().ToString())
                            .Replace("{{blobsWidth}}", blobWidth.ToString())
                        + "</script>";


            }
            catch (Exception ex)
            {
                if (Environment.MachineName.ToLower().Contains("monkey"))
                    lblLoadErrorMsg.Text = ex.ToString();
                else
                    lblLoadErrorMsg.Text = ex.Message;

                
            }



        }

        public class TkcReview
        {
            public string publisher { get; set; }
            public string publisherImage { get; set; }
            public decimal rating { get; set; }
            public string ratingImage { get; set; }
            public string authorName { get; set; }
            public string comment { get; set; }
            public string created { get; set; }
            public DateTime createdDate { get; set; }
            public string url { get; set; }


            public TkcReview(Review r, bool showDate, string showDateFormat)
            {
                publisher = r.publisherId;
                
                if (publisher.ToLower().Contains("google"))
                    publisherImage = "/portals/_default/Images/Google50xLogo.png";

                rating = (decimal)r.rating;

                if (rating > 0 && rating < 2)
                    ratingImage = "/portals/_default/Images/Star1.png";
                else if (rating >= 2 && rating < 3)
                    ratingImage = "/portals/_default/Images/Star2.png";
                else if (rating >= 3 && rating < 4)
                    ratingImage = "/portals/_default/Images/Star3.png";
                else if (rating >= 4 && rating < 5)
                    ratingImage = "/portals/_default/Images/Star4.png";
                else 
                    ratingImage = "/portals/_default/Images/Star5.png";


                authorName = r.authorName;
                comment = r.content;

                DateTime epoch = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);

                createdDate = epoch.AddMilliseconds(r.publisherDate);
                created = !showDate ? "" : createdDate.ToString(showDateFormat);

                url = r.url;
            }
        }

        public ModuleActionCollection ModuleActions
        {
            get
            {
                var actions = new ModuleActionCollection
                    {
                        {
                            GetNextActionID(), Localization.GetString("EditModule", LocalResourceFile), "", "", "",
                            EditUrl(), false, SecurityAccessLevel.Edit, true, false
                        }
                    };
                return actions;
            }
        }

        public static DateTime UnixTimeStampToDateTime(double unixTimeStamp)
        {
            // Unix timestamp is seconds past epoch
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(unixTimeStamp).ToLocalTime();
            return dateTime;
        }


        public class YextReviews
        {
            public Meta meta { get; set; }
            public Response response { get; set; }
        }

        public class Meta
        {
            public string uuid { get; set; }
            public object[] errors { get; set; }
        }

        public class Response
        {
            public Review[] reviews { get; set; }
            public string nextPageToken { get; set; }
            public float averageRating { get; set; }
            public int count { get; set; }
        }

        public class Review
        {
            public int id { get; set; }
            public float rating { get; set; }
            public string content { get; set; }
            public string authorName { get; set; }
            public string url { get; set; }
            public long publisherDate { get; set; }
            public string locationId { get; set; }
            public string accountId { get; set; }
            public string publisherId { get; set; }
            public long lastYextUpdateTime { get; set; }
            public Comment[] comments { get; set; }
            public string status { get; set; }
            public string externalId { get; set; }
            public string flagStatus { get; set; }
        }

        public class Comment
        {
            public int id { get; set; }
            public long publisherDate { get; set; }
            public string authorRole { get; set; }
            public string content { get; set; }
            public string visibility { get; set; }
        }

    }
}