# TKC_YextReviews_For_DNN
Allows you to connect to the Yext API and retrieve an entity's reviews.

Requires:

-DNN (DotNetNuke) - tested with DNN v9+

-references to Newtonsoft.Json and RestSharp

-Yext.com account/subscription


Based on Chris Hammond's VS DNN Project Templates

https://marketplace.visualstudio.com/items?itemName=Chris-Hammond.DotNetNukeDNNDevelopmentProjectTemplates

DNN Module Settings / Features:

-Yext API Key

-Reviews Limit - number of reviews to display

-Entity ID - the Yext entity/location you want to display reviews for

-Min Rating - used for showing reviews that were scored x or higher

-Comment Reviews Only - only display reviews that contain review comments (not just "starred"-only ones)

-Show Date - toggle for showing or hiding the review's date

-Show Date Format - a format string for the date, e.g. MMMM yyyy

-Rotate JS - custom JS to make the reviews rotate/slide automatically in the module, optional, includes a working example that can be used



