<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Stamp.aspx.cs" Inherits="Stamp" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        &nbsp;<table>
            <tr>
                <td>
                    <asp:Label ID="Label1" runat="server" Text="Select Field to Customize:"></asp:Label></td>
                <td>
                    <asp:DropDownList ID="DropDownListStampFields" runat="server" DataTextField="FieldName" DataValueField="FieldName" Width="349px" AutoPostBack="True" OnSelectedIndexChanged="DropDownListStampFields_SelectedIndexChanged">
                    </asp:DropDownList></td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td style="height: 40px">
                    <asp:Label ID="Label2" runat="server" Text="Enter Text:"></asp:Label></td>
                <td style="height: 40px">
                    <asp:TextBox ID="TextBoxFieldText" runat="server" Height="58px" TextMode="MultiLine" Width="340px">Copperline Constulting Services, Inc.
53 Ridge Rd.
Fairfax, CA 94930</asp:TextBox></td>
                <td style="height: 40px">
                </td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="Label3" runat="server" Text="Choose Graphic:"></asp:Label></td>
                <td>
                    <asp:FileUpload ID="FileUploadImage" runat="server" /></td>
                <td>
                    <asp:Image ID="ImageLogo" runat="server" /></td>
            </tr>
            <tr>
                <td>
                    <asp:Button ID="ButtonSubmit" runat="server" Text="Submit" OnClick="ButtonSubmit_Click" /></td>
                <td>
                </td>
                <td>
                </td>
            </tr>
            <tr>
                <td>
                </td>
                <td>
                    <asp:Label ID="LabelError" runat="server"></asp:Label></td>
                <td>
                </td>
            </tr>
        </table>
    
    </div>
        <asp:HiddenField ID="HiddenFieldFieldType" runat="server" />
    </form>
</body>
</html>
