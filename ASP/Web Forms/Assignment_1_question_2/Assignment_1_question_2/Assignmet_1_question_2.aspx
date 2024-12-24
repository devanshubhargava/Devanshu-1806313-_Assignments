<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="ASP_Assignment1.Validator" %>
<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Selector</title>
    <style>
        body {
            font-family: Arial, sans-serif;
            background-color: #f4f4f4;
            margin: 0;
            padding: 0;
        }

        .container {
            width: 500px;
            margin: 50px auto;
            background-color: #fff;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 4px 8px rgba(0, 0, 0, 0.1);
        }

        h2 {
            text-align: center;
            color: #333;
        }

        .form-group {
            margin-bottom: 20px;
        }

        label {
            font-size: 14px;
            font-weight: bold;
            color: #333;
        }

        select, .btn {
            width: 100%;
            padding: 10px;
            font-size: 14px;
            border: 1px solid #ccc;
            border-radius: 4px;
            box-sizing: border-box;
        }

        .btn {
            background-color: #4CAF50;
            color: white;
            font-size: 16px;
            cursor: pointer;
            margin-top: 20px;
        }

        .btn:hover {
            background-color: #45a049;
        }

        .product-image {
            display: block;
            margin: 20px auto;
            max-width: 200px;
        }

        .price {
            font-size: 16px;
            font-weight: bold;
            color: #333;
            text-align: center;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <h2>Select a Product</h2>

            
            <div class="form-group">
                <label for="ddlProducts">Choose Product:</label>
                <asp:DropDownList ID="ddlProducts" runat="server" CssClass="form-control" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged" AutoPostBack="true">
                    <asp:ListItem Text="Select a Product" Value="0" />
                    <asp:ListItem Text="Product 1" Value="1" />
                    <asp:ListItem Text="Product 2" Value="2" />
                    <asp:ListItem Text="Product 3" Value="3" />
                </asp:DropDownList>
            </div>

            
            <asp:Image ID="imgProduct" runat="server" CssClass="product-image" />

            
            <asp:Button ID="btnShowPrice" runat="server" Text="Show Price" CssClass="btn" OnClick="btnShowPrice_Click" />

            
            <div class="price">
                <asp:Label ID="lblPrice" runat="server" CssClass="price"></asp:Label>
            </div>
        </div>
    </form>
</body>
</html>
