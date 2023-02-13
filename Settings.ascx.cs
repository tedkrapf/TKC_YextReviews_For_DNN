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
using DotNetNuke.Entities.Modules;
using DotNetNuke.Services.Exceptions;

namespace TechemistryTKC_YextReviews
{
    /// -----------------------------------------------------------------------------
    /// <summary>
    /// The Settings class manages Module Settings
    /// 
    /// Typically your settings control would be used to manage settings for your module.
    /// There are two types of settings, ModuleSettings, and TabModuleSettings.
    /// 
    /// ModuleSettings apply to all "copies" of a module on a site, no matter which page the module is on. 
    /// 
    /// TabModuleSettings apply only to the current module on the current page, if you copy that module to
    /// another page the settings are not transferred.
    /// 
    /// If you happen to save both TabModuleSettings and ModuleSettings, TabModuleSettings overrides ModuleSettings.
    /// 
    /// Below we have some examples of how to access these settings but you will need to uncomment to use.
    /// 
    /// Because the control inherits from TKC_YextReviewsSettingsBase you have access to any custom properties
    /// defined there, as well as properties from DNN such as PortalId, ModuleId, TabId, UserId and many more.
    /// </summary>
    /// -----------------------------------------------------------------------------
    public partial class Settings : TKC_YextReviewsModuleSettingsBase
    {
        #region Base Method Implementations

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// LoadSettings loads the settings from the Database and displays them
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void LoadSettings()
        {
            try
            {
                if (Page.IsPostBack == false)
                {
                    //Check for existing settings and use those on this page
                    //Settings["SettingName"]

                    if(Settings.Contains("txtApiKey"))
                        txtApiKey.Text = Settings["txtApiKey"].ToString();

                    if (Settings.Contains("txtQtyLimit"))
                        txtQtyLimit.Text = Settings["txtQtyLimit"].ToString();

                    if (Settings.Contains("txtEntityID"))
                        txtEntityID.Text = Settings["txtEntityID"].ToString();

                    if (Settings.Contains("txtMinRating"))
                        txtMinRating.Text = Settings["txtMinRating"].ToString();

                    if (Settings.Contains("chkCommentReviewsOnly"))
                        chkCommentReviewsOnly.Checked = Settings["chkCommentReviewsOnly"].ToString() == "true";

                    if (Settings.Contains("chkShowDate"))
                        chkShowDate.Checked = Settings["chkShowDate"].ToString() == "true";

                    if (Settings.Contains("txtShowDateFormat"))
                        txtMinRating.Text = Settings["txtShowDateFormat"].ToString();

                    if (Settings.Contains("txtRotateJS"))
                        txtRotateJS.Text = Settings["txtRotateJS"].ToString();

                }
            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        /// -----------------------------------------------------------------------------
        /// <summary>
        /// UpdateSettings saves the modified settings to the Database
        /// </summary>
        /// -----------------------------------------------------------------------------
        public override void UpdateSettings()
        {
            try
            {
                var modules = new ModuleController();

                //the following are two sample Module Settings, using the text boxes that are commented out in the ASCX file.
                //module settings
                //modules.UpdateModuleSetting(ModuleId, "Setting1", txtSetting1.Text);
                //modules.UpdateModuleSetting(ModuleId, "Setting2", txtSetting2.Text);

                //tab module settings
                modules.UpdateTabModuleSetting(TabModuleId, "txtApiKey", txtApiKey.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "txtQtyLimit", txtQtyLimit.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "txtEntityID", txtEntityID.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "txtMinRating", txtMinRating.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "chkCommentReviewsOnly", chkCommentReviewsOnly.Checked ? "true" : "false");
                modules.UpdateTabModuleSetting(TabModuleId, "chkShowDate", chkShowDate.Checked ? "true" : "false");
                modules.UpdateTabModuleSetting(TabModuleId, "txtShowDateFormat", txtMinRating.Text);
                modules.UpdateTabModuleSetting(TabModuleId, "txtRotateJS", txtRotateJS.Text);

            }
            catch (Exception exc) //Module failed to load
            {
                Exceptions.ProcessModuleLoadException(this, exc);
            }
        }

        #endregion
    }
}