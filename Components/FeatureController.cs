/*
' Copyright (c) 2023 Techemistry.com
'  All rights reserved.
' 
' THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED
' TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL
' THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF
' CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER
' DEALINGS IN THE SOFTWARE.
' 
*/

using System.Collections.Generic;
//using System.Xml;
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Search;

namespace TechemistryTKC_YextReviews.Components
{

    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Controller class for TKC_YextReviews
    /// 
    /// The FeatureController class is defined as the BusinessController in the manifest file (.dnn)
    /// DotNetNuke will poll this class to find out which Interfaces the class implements. 
    /// 
    /// The IPortable interface is used to import/export content from a DNN module
    /// 
    /// The ISearchable interface is used by DNN to index the content of a module
    /// 
    /// The IUpgradeable interface allows module developers to execute code during the upgrade 
    /// process for a module.
    /// 
    /// Below you will find stubbed out implementations of each, uncomment and populate with your own data
    /// </summary>
    /// -----------------------------------------------------------------------------

    //uncomment the interfaces to add the support.
    public class FeatureController //: IPortable, ISearchable, IUpgradeable
    {


        #region Optional Interfaces

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ExportModule implements the IPortable ExportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be exported</param>
        /// -----------------------------------------------------------------------------
        //public string ExportModule(int ModuleID)
        //{
        //string strXML = "";

        //List<TKC_YextReviewsInfo> colTKC_YextReviewss = GetTKC_YextReviewss(ModuleID);
        //if (colTKC_YextReviewss.Count != 0)
        //{
        //    strXML += "<TKC_YextReviewss>";

        //    foreach (TKC_YextReviewsInfo objTKC_YextReviews in colTKC_YextReviewss)
        //    {
        //        strXML += "<TKC_YextReviews>";
        //        strXML += "<content>" + DotNetNuke.Common.Utilities.XmlUtils.XMLEncode(objTKC_YextReviews.Content) + "</content>";
        //        strXML += "</TKC_YextReviews>";
        //    }
        //    strXML += "</TKC_YextReviewss>";
        //}

        //return strXML;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// ImportModule implements the IPortable ImportModule Interface
        /// </summary>
        /// <param name="ModuleID">The Id of the module to be imported</param>
        /// <param name="Content">The content to be imported</param>
        /// <param name="Version">The version of the module to be imported</param>
        /// <param name="UserId">The Id of the user performing the import</param>
        /// -----------------------------------------------------------------------------
        //public void ImportModule(int ModuleID, string Content, string Version, int UserID)
        //{
        //XmlNode xmlTKC_YextReviewss = DotNetNuke.Common.Globals.GetContent(Content, "TKC_YextReviewss");
        //foreach (XmlNode xmlTKC_YextReviews in xmlTKC_YextReviewss.SelectNodes("TKC_YextReviews"))
        //{
        //    TKC_YextReviewsInfo objTKC_YextReviews = new TKC_YextReviewsInfo();
        //    objTKC_YextReviews.ModuleId = ModuleID;
        //    objTKC_YextReviews.Content = xmlTKC_YextReviews.SelectSingleNode("content").InnerText;
        //    objTKC_YextReviews.CreatedByUser = UserID;
        //    AddTKC_YextReviews(objTKC_YextReviews);
        //}

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// GetSearchItems implements the ISearchable Interface
        /// </summary>
        /// <param name="ModInfo">The ModuleInfo for the module to be Indexed</param>
        /// -----------------------------------------------------------------------------
        //public DotNetNuke.Services.Search.SearchItemInfoCollection GetSearchItems(DotNetNuke.Entities.Modules.ModuleInfo ModInfo)
        //{
        //SearchItemInfoCollection SearchItemCollection = new SearchItemInfoCollection();

        //List<TKC_YextReviewsInfo> colTKC_YextReviewss = GetTKC_YextReviewss(ModInfo.ModuleID);

        //foreach (TKC_YextReviewsInfo objTKC_YextReviews in colTKC_YextReviewss)
        //{
        //    SearchItemInfo SearchItem = new SearchItemInfo(ModInfo.ModuleTitle, objTKC_YextReviews.Content, objTKC_YextReviews.CreatedByUser, objTKC_YextReviews.CreatedDate, ModInfo.ModuleID, objTKC_YextReviews.ItemId.ToString(), objTKC_YextReviews.Content, "ItemId=" + objTKC_YextReviews.ItemId.ToString());
        //    SearchItemCollection.Add(SearchItem);
        //}

        //return SearchItemCollection;

        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpgradeModule implements the IUpgradeable Interface
        /// </summary>
        /// <param name="Version">The current version of the module</param>
        /// -----------------------------------------------------------------------------
        //public string UpgradeModule(string Version)
        //{
        //	throw new System.NotImplementedException("The method or operation is not implemented.");
        //}

        #endregion

    }

}
