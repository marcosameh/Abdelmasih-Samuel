<%@ Control Language="C#" AutoEventWireup="true" CodeBehind="LocalizedItem.ascx.cs"
    Inherits="DynamicData.Admin.Controls.Localized.LocalizedItem" %>

<%@ Register Src="~/Controls/Localized/LocalizedMetaTag.ascx" TagPrefix="uc1" TagName="LocalizedMetaTag" %>
<%@ Register Src="~/Controls/Localized/LocalizedNews.ascx" TagPrefix="uc1" TagName="LocalizedNews" %>
<%@ Register Src="~/Controls/Localized/LocalizedAlbum.ascx" TagPrefix="uc1" TagName="LocalizedAlbum" %>
<%@ Register Src="~/Controls/Localized/LocalizedHomeBanner.ascx" TagPrefix="uc1" TagName="LocalizedHomeBanner" %>




<uc1:LocalizedAlbum runat="server" ID="LocalizedAlbum" Visible="False" />
<uc1:LocalizedMetaTag runat="server" ID="LocalizedMetaTag" Visible="False" />
<uc1:LocalizedNews runat="server" ID="LocalizedNews" Visible="False" />
<uc1:LocalizedHomeBanner runat="server" ID="LocalizedHomeBanner" Visible="False" />
