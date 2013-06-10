<%@ Page Language="C#" AutoEventWireup="true" %>
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
	<meta name="viewport" content="width=device-width,height=device-height,initial-scale=1" />
    <WebSharper:ScriptManager runat="server"/>
    
    <style>
        [data-role=page]{height: 100% !important; position:relative !important;}
        [data-role=footer]{bottom:0; position:absolute !important; top: auto !important; width:100%;}
    </style>
</head>
<body>
    <%--<div data-role="page" id="none"></div>--%>
    <Tests:AppControl runat="server" />
</body>
</html>
