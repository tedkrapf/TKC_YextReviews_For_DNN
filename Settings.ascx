<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="Settings.ascx.cs" Inherits="TechemistryTKC_YextReviews.Settings" %>


<!-- uncomment the code below to start using the DNN Form pattern to create and update settings -->
  

<%@ Register TagName="label" TagPrefix="dnn" Src="~/controls/labelcontrol.ascx" %>

	<h2 id="dnnSitePanel-BasicSettings" class="dnnFormSectionHead"><a href="" class="dnnSectionExpanded">TKCYEXT Review Settings</a></h2>
	<fieldset>
        <div class="dnnFormItem">
            API Key: <asp:TextBox ID="txtApiKey" runat="server" />
        </div>
        <div class="dnnFormItem">
            Reviews Limit: <asp:TextBox ID="txtQtyLimit" runat="server" Text="20" />
        </div>
        <div class="dnnFormItem">
            Entity ID: <asp:TextBox ID="txtEntityID" runat="server" Text="xyz123" />
        </div>
        <div class="dnnFormItem">
            Min Rating: <asp:TextBox ID="txtMinRating" runat="server" Text="4.0" />
        </div>
        <div class="dnnFormItem">
            Comment Reviews Only: <asp:CheckBox ID="chkCommentReviewsOnly" runat="server" />
        </div>
        <div class="dnnFormItem">
            Show Date: <asp:CheckBox ID="chkShowDate" runat="server" />
        </div>
        <div class="dnnFormItem">
            Show Date Format: <asp:TextBox ID="txtShowDateFormat" runat="server"  Text="MMMM yyyy"/>
        </div>

        <div class="dnnFormItem">
            Rotate JS: <asp:TextBox ID="txtRotateJS" runat="server" width="100%" Height="300px" TextMode="MultiLine"/>
        </div>

        <p>
            <b>Rotate JS Template</b><br />
            <pre>
    var blobsCnt = {{blobsCnt}};  //placeholder   
    var left = {{blobsWidth}};    //placeholder    
    var onBlob = 1;
    var leftOrRight = 1;

    $(document).ready(function() { 
	    setInterval(function() {
			    var current = $('.tkrContainer').scrollLeft();
			    if (onBlob == 1) {
				    leftOrRight = 1;
			    }
			    else if (onBlob == blobsCnt) {
				    leftOrRight = -1;
			    }
			    onBlob = onBlob + leftOrRight;
			    $('.tkrContainer').animate({ scrollLeft: current + (left * leftOrRight) }, 300);
			    console.log('on: ' + onBlob + ', lor: ' + leftOrRight + ', cnt: ' + blobsCnt);
		    }
		    , 3500);
    });	 

            </pre>

        </p>

        

    </fieldset>


