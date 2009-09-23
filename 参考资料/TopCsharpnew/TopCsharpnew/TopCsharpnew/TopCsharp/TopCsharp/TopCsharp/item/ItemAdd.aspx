<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ItemAdd.aspx.cs" Inherits="TopCsharp.item.ItemAdd" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml" >
<head runat="server">
    <title>Untitled Page</title>
</head>
<body>

    <form id="form1" runat="server" method="post" enctype="multipart/form-data" accept-charset="UTF8">
    <div>
        SessionKey:<asp:TextBox ID="tbSessionKey" runat="server" Width="511px"></asp:TextBox>
</div>
     <table>
        <tr>
            <td>approve_status：</td>
            <td><asp:TextBox ID="status" runat="server" Text="Onsale"></asp:TextBox></td>
        </tr>
        <tr>
            <td >cid：</td>
            <td><asp:TextBox ID="cid" runat="server" Text="1403"></asp:TextBox></td>
        </tr>
       <tr>
          <td >props：</td>
          <td><asp:TextBox ID="props" runat="server" Text="20000:31938;31696:107066;31502:33123;20955:33117;20115:10015;20118:3229162;20101:28954;20124:21521;20930:32998;20879:21456;"></asp:TextBox></td>
      </tr>
      <tr>
         <td>num：</td>
         <td><asp:TextBox ID="num" runat="server" Text="10"></asp:TextBox></td>
      </tr>
      <tr>
         <td>price：</td>
         <td><asp:TextBox ID="price" runat="server" Text="6000"></asp:TextBox></td>
      </tr>
      <tr>
         <td>type：</td>
         <td><asp:TextBox ID="type" runat="server" Text="fixed"></asp:TextBox></td>
      </tr>
      <tr>
         <td>stuff_status：</td>
         <td><asp:TextBox ID="stuff" runat="server" Text="new"></asp:TextBox></td>
      </tr>
      <tr>
         <td>title：</td>
         <td><asp:TextBox ID="title" runat="server" Text="测试商品请匆拍卖"></asp:TextBox></td>
      </tr>
      <tr>
         <td>desc：</td>
         <td><asp:TextBox ID="desc" runat="server" Text="测试商品测试商品测试商品测试商品"></asp:TextBox></td>
      </tr>
      <tr>
         <td>location.state：</td>
         <td><asp:TextBox ID="state" runat="server" Text="浙江"></asp:TextBox></td>
      </tr>
      <tr>
         <td>location.city：</td>
         <td><asp:TextBox ID="city" runat="server" Text="杭州"></asp:TextBox></td>
      </tr>
      <tr>
         <td>image：</td>
         <td><input type="file" size="50" name="File" /></td>
      </tr>
      <tr>
         <td></td>
         <td> <asp:Button ID="btAdd" runat="server" Text="提交" onclick="btAdd_Click" /></td>
      </tr>
     
     </table>
        <asp:Label ID="textbox" runat="server" Height="80px" Width="600px"></asp:Label>
       
    </form>
</body>
</html>
