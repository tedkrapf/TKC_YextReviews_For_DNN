<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="View.ascx.cs" Inherits="TechemistryTKC_YextReviews.View" %>

<style>

    .tkrContainer { width: 100%; overflow-x: scroll;}
    

    

    .tkrBlob {
        width: 300px;
        padding: 10px;
        margin: 10px;
        border: 2px solid #EEE;
        box-shadow: rgba(0,0,0,0.2) 3px 3px;
        border-radius: 3px 3px;
        display: inline-block;
    }

    .tkrLogo {
        float: left;
        width: 30px;
        margin: 0 10px 0px 0px;
    }

    .tkrAuthor {
        font-size: 14pt;
        color: #0094ff;
        font-weight: bold;
    }

    .tkrComment {
        height: 100px;
        overflow-y: scroll;
        color: #808080;
        font-size: 0.8em;
    }

    .tkrStars {
        width: 100px;
    }

    .tkrCreated {
        display: inline-block;
        font-size: 0.7em;
        color: #808080;
        padding: -10px;
    }
</style>


<asp:Literal ID="ltPaneStyle" runat="server" Text="" />

<asp:Label ID="lblLoadErrorMsg" runat="server" />


<asp:ListView ID="lvReviews" runat="server">
    <LayoutTemplate>
        <div class="tkrContainer">
        <div class="tkrPane">

            <div id="itemPlaceholder" runat="server"></div>
        </div>
        </div>
    </LayoutTemplate>
    <EmptyItemTemplate>
        <i>no reviews found</i>
    </EmptyItemTemplate>
    <ItemTemplate>
        <div class="tkrBlob">

            <img src='<%# Eval("publisherImage") %>' alt="SevenStar Logistics - Google Reviews" class="tkrLogo" />

            <a href='<%# Eval("url") %>' target="_blank">
                <h3 class="tkrAuthor"><%# Eval("authorName") %></h3>
            </a>

            <img src='<%# Eval("ratingImage") %>' alt="SevenStar Logistics - Google Reviews" class="tkrStars" />
            <span class="tkrCreated"><%# Eval("created") %></span>

            <br />
            <p class="tkrComment">
                <%# Eval("comment") %>
            </p>
        </div>
    </ItemTemplate>
</asp:ListView>
